using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for AppUtility
/// </summary>
public class AppUtility
{
    public AppUtility()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //Function to Clear all TextBoxes
    public static void clearTextBoxes(Control p1)
    {
        foreach(Control ctrl in p1.Controls)
        {
            if(ctrl is TextBox)
            {
                TextBox t = ctrl as TextBox;
                if (t != null)
                {
                    t.Text = String.Empty;
                }
            }
            else
            {
                if (ctrl.Controls.Count > 0)
                {
                    clearTextBoxes(ctrl);
                }
            }
        }
    }

}