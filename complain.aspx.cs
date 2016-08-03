using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.IO;
using MySql.Data.MySqlClient;

public partial class complain : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCaptcha();
        }
        ;
        if (!String.IsNullOrEmpty(Request.QueryString.Get("id")))
        {
            getReportSummary(Convert.ToInt64(Request.QueryString.Get("id")));
        }
    }

    //Generated Captcha Code
    void FillCaptcha()
    {
        try
        {
            Random random = new Random();
            string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i < 6; i++)
                captcha.Append(combination[random.Next(combination.Length)]);
            Session["captcha"] = captcha.ToString();
            CaptchaImage.ImageUrl = "~/img/CaptchaImage.aspx?" + DateTime.Now.Ticks.ToString();
        }
        catch
        {
            throw;
        }
    }
    //Refresh Captcha Code (Load a New Captcha)
    protected void CaptchaRefresh_ServerClick(object sender, EventArgs e)
    {
        FillCaptcha();
        this.CaptchaTextBox.Focus();
    }

    protected void SubmitComplain_Click(object sender, EventArgs e)
    {
        //If Session is expired, regenrate new Captcha
        if (String.IsNullOrEmpty(Session["captcha"].ToString())){
            FillCaptcha();
        }

        //Check if Submitted Captcha Code is Correct or Not
        if (Session["captcha"].ToString().Equals(CaptchaTextBox.Text))
        {
            //reset the captcha code so that form cannot be resubmitted accidently
            FillCaptcha();

            long ReportID = 0; //variable to store just inserted Complaint Report ID . It will help to generate summary page
            try
            {
                using (MySqlConnection Connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString))
                {
                    Random r = new Random();
                    String name = "FileName" + r.Next();
                    Connection.Open();
                    //Open a transaction because we have to run two SQL statements and another is dependent on first statement
                    MySqlTransaction Transaction = Connection.BeginTransaction();
                    MySqlCommand Command = new MySqlCommand(String.Format("INSERT INTO `onlinecrimereport`.`reports` (`Name`, `Email`, `Mobile`, `Address`, `Description`, `file`, `virtualname`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');", NameTextBox.Text, EmailTextBox.Text, MobileNumberTextBox.Text, AddressTextBox.Text, DetailedComplainTextBox.Text, file.FileName, name), Connection, Transaction);
                    int AffectedRows = Command.ExecuteNonQuery();
                    if (AffectedRows > 0)//Will go into if condition only if the data is inserted , ie Affected Rows is >0
                    {


                        Command = new MySqlCommand("select last_insert_id() from onlinecrimereport.reports;", Connection, Transaction);
                        ReportID = Convert.ToInt64(Command.ExecuteScalar());
                    }
                    else
                    {
                        throw new Exception("Sorry, Server is Too Busy or Not Responding. Your Complain is not Registered. Try Again Later");
                    }
                    //Since everything is ok here so commit the transaction
                    if (file.HasFile)
                    {
                        if(System.IO.Path.GetExtension(file.FileName)!=".asp" || System.IO.Path.GetExtension(file.FileName) != ".aspx"|| System.IO.Path.GetExtension(file.FileName) != ".cs" || System.IO.Path.GetExtension(file.FileName) != ".vb")
                        {
                            try
                            {
                                file.SaveAs(MapPath("~/Uploads/" + name));
                            }catch(Exception ex)
                            {
                                Response.Write(ex.Message);
                            }
                        }
                    }
                    Transaction.Commit();
                    Response.Redirect("complain.aspx?id=" + ReportID);
                }
            }catch(Exception ex)
            {
                //hide the form to create space for displaying error message
                form.InnerHtml = "<div style = 'text-align:center'><i class='fa fa-exclamation-triangle fa-3x'></i><p>" + ex.Message + "</p></div>";
                
            }
            

        }
        else
        {
            //Captcha code enterd by user is wrong so, program will regenrate new captch and display a error message
            CaptchaRefresh_ServerClick(sender, e);
            CaptchaWarningLabel.Visible = true;
        }
    }


    //Generated Report Summary of a given id (Sl No of the Complain)
    void getReportSummary(long id)
    {
        //hide form and display summary(reply) page(div)
        form.Visible = false;
        reply.Visible = true;
        try
        {
            using (MySqlConnection Connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString))
            {
                Connection.Open();
                MySqlCommand Command = new MySqlCommand(String.Format("SELECT * FROM onlinecrimereport.reports where reports.idReports={0};", id), Connection);
                MySqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    //read all columns from mysql and assign to predefined labels
                    SlNoLabel.Text = Reader.GetInt64("idReports").ToString();
                    DateTimeLabel.Text = Reader.GetDateTime("DateTime").Date.ToLongDateString() +" / " +Reader.GetDateTime("DateTime").ToShortTimeString();
                    NameLabel.Text = Reader.GetString("Name");
                    EmailLabel.Text = Reader.GetString("Email");
                    MobileLabel.Text = Reader.GetString("Mobile");
                    //Replace function used to preserve line breaks while displaying in html
                    AddressLabel.Text = Reader.GetString("Address").Replace(Environment.NewLine, "<br />");
                    DescriptionLabel.Text = Reader.GetString("Description").Replace(Environment.NewLine, "<br/>");
                    StatusLabel.Text = Reader.GetString("StatusMessage").Replace(Environment.NewLine, "<br/>");
                }
                else
                {
                    //Give a error message that the information about id is not available
                    reply.InnerHtml = "<div style='text-align:center'><i class='fa fa-frown-o fa-4x'></i><h3>Sorry, the ID/Sl-No. is Invalid<br/> Please try again with a valid ID</h3 ></div>";
                }
                   
            }
        }
        catch(Exception ex)
        {
            reply.InnerHtml = "<div style='text-align:center'><i class='fa  fa-exclamation-triangle fa-3x'></i><p>" + ex.Message+ "</p></div>";
        }
    }
}