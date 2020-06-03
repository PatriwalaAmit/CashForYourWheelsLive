using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Net.Mail;

public partial class sitemap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SmtpClient mailClient = new SmtpClient();
        mailClient.Host = "smtp.123-reg.co.uk";        
        System.Net.NetworkCredential credentials =
            new System.Net.NetworkCredential("valuation@cashforyourwheels.co.uk", "Z621kwql");        
        mailClient.Credentials = credentials;
        // Create the mail message
        MailMessage mailMessage = new MailMessage("valuation@cashforyourwheels.co.uk","amit@timeseo.com","please check","test");
        mailMessage.IsBodyHtml = true;
        // Send mail
        try
        {
            mailClient.Send(mailMessage);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}
