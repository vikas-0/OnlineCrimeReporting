using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["username"] != null))
        {
            this.LoginLink.Visible = false;
        }
        else
        {
            this.AdminLink.Visible = false;
            this.LogoutLink.Visible = false;
        }
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        using (MySqlConnection Connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString))
        {
            Connection.Open();
            MySqlCommand Command = new MySqlCommand("Select password from login where username='"+ UserID.Text +"'",Connection);
            MySqlDataReader rdr = Command.ExecuteReader();
            if (rdr.Read())
            {
                if (Password.Text == rdr.GetString(0))
                {
                    Session["username"] = UserID.Text;
                    Response.Redirect("~/Admin.aspx");
                }
                else {
                    errr.InnerText = "Invalid Passowrd or Username";
                        }
            }
            else
            {
                errr.InnerText = "Invalid Passowrd or Username";
            }
        }
            
    }

    protected void SubmitReportIDButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/complain.aspx?id="+ReportIDTextBox.Text);
    }
}
