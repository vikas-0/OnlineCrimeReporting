using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

public partial class img_CaptchaImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();

        int height = 30;

        int width = 100;

        Bitmap bmp = new Bitmap(width, height);
        RectangleF rectf = new RectangleF(10, 5, 0, 0);
        Graphics g = Graphics.FromImage(bmp);
        g.Clear(Color.Gray);
        g.SmoothingMode = SmoothingMode.HighSpeed;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
        g.DrawString(Session["captcha"].ToString(), new Font("Thaoma", 16, FontStyle.Strikeout), Brushes.Black, rectf);
        g.DrawRectangle(new Pen(Color.Gray), 1, 1, width - 2, height - 2);
        g.DrawLine(new Pen(Color.Gray), 0, 1, width, height);
        g.Flush();
        Response.ContentType = "image/jpeg";
        bmp.Save(Response.OutputStream, ImageFormat.Jpeg);
        g.Dispose();
        bmp.Dispose();
    }
}