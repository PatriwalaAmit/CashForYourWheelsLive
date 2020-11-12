using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

public partial class getcaptchaimage : System.Web.UI.Page
{
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    private void Page_Load(object sender, System.EventArgs e)
    {
        log.Debug("Entered Page_Load - getcaptchaimage");
        log.Debug("Value of captcha session: " + this.Session["CaptchaImageText"] != null ? this.Session["CaptchaImageText"].ToString() : string.Empty);
        // Create a CAPTCHA image using the text stored in the Session object.
        CaptchaImage ci = new CaptchaImage(this.Session["CaptchaImageText"].ToString(), 200, 50, "Century Schoolbook");

        // Change the response headers to output a JPEG image.
        this.Response.Clear();
        this.Response.ContentType = "image/jpeg";

        // Write the image to the response stream in JPEG format.
        ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);

        // Dispose of the CAPTCHA image object.
        ci.Dispose();
        log.Debug("Exiting Page_Load - getcaptchaimage");
    }
}