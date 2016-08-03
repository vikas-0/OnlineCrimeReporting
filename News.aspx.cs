using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class News : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using(MySqlConnection Connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString))
        {
            Connection.Open();
            MySqlCommand Command = new MySqlCommand("SELECT title, news, datetime, author FROM onlinecrimereport.news order by datetime desc;", Connection);
            DataTable dt=new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(Command);
                da.Fill(dt);           
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            
        }
    }
}