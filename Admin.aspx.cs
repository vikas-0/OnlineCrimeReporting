using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(Session["username"] != null))
        {
            Response.Redirect("index.aspx");
        }

        using (MySqlConnection Connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString))
        {
            Connection.Open();
            MySqlCommand Command = new MySqlCommand("SELECT * FROM onlinecrimereport.reports order by DateTime desc ", Connection);
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(Command);
            da.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void SecureFileDownload(string filename, string actualname)
    {
        if(String.IsNullOrEmpty(filename) || String.IsNullOrEmpty(actualname)) {
            alert.InnerHtml = "<script> alert('No File') </script>";
        }
        else { 
        string strFilepath = MapPath("~/Uploads/" + filename);
        FileInfo myfile = new FileInfo(strFilepath);
        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment; filename=" + actualname);
        Response.AddHeader("Content-Length", myfile.Length.ToString());
        Response.WriteFile(myfile.FullName);
        Response.End();
        }
    }

    protected void DownloadButton_Click(object sender, EventArgs e)
    {
        using (MySqlConnection Connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString))
        {
            Connection.Open();
            MySqlCommand Command = new MySqlCommand("SELECT file, virtualname FROM onlinecrimereport.reports where idReports='"+TextBox2.Text.Trim()+"' ", Connection);
            MySqlDataReader rdr = Command.ExecuteReader();
            if (rdr.Read())
            {
                SecureFileDownload(rdr.GetString(1), rdr.GetString(0));
            }

        }
    }



    protected void ResponseSubmit_ServerClick(object sender, EventArgs e)
    {
        
        using (MySqlConnection Connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString))
        {
            Connection.Open();
            MySqlCommand Command = new MySqlCommand("UPDATE `onlinecrimereport`.`reports` SET `StatusMessage`= '"+TextBox1.Text+"' WHERE `idReports`= '" + TextBox2.Text.Trim() + "' ", Connection);
            Command.ExecuteNonQuery();
            Connection.Close();
            Response.Redirect(Request.RawUrl);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        using (MySqlConnection Connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString))
        {
            Connection.Open();
            MySqlCommand Command = new MySqlCommand(String.Format("INSERT INTO `onlinecrimereport`.`news` (`news`, `author`, `title`) VALUES('{0}', '{1}', '{2}');", NewsTextBox.Text.Trim(), Session["username"].ToString(), TitleTextBox.Text.Trim()), Connection);
            Command.ExecuteNonQuery();
            Connection.Close();
            Response.Redirect(Request.RawUrl);
        }

    }
}