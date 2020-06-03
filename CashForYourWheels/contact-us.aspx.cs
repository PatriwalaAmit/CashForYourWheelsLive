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

public partial class contact_us : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {     
	((LinkButton)Page.Master.FindControl("aValueMyCar")).CssClass = "-active"; 
        ((LinkButton)Page.Master.FindControl("aContact")).CssClass = "active";    
    }

    protected void btnSumit_click(object sender, EventArgs e)
    {
        revPhonenumber.Display = ValidatorDisplay.Dynamic;
        if (Page.IsValid)
        {
            string strBody = string.Empty;
            strBody = "<html> <body> Name : " + txtName.Text + "<br>";            
            strBody += "Enquiry : " + txtenquiry.Value + "<br>";
            strBody += "Phone Number : " + txtPhoneNumber.Text + "<br>";
            strBody += "Email Address : : " + txtEmailAddress.Text + "<br>";
            strBody += "</body></html>";

	        Utilities.SendMail("info@cashforyourwheels.com", txtEmailAddress.Text , "Thanks for contact to Cashforyourwheels", strBody, string.Empty);            
            Utilities.SendMail("info@cashforyourwheels.com", "info@cashforyourwheels.co.uk", "New Enquiry !!", strBody, string.Empty);

            lblMessage.Text = "Thank you for sending us your enquiry. We endeavour to reply to your enquiry as soon as possible";

            txtName.Text = string.Empty;
            txtenquiry.Value = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtEmailAddress.Text = string.Empty;
            //Response.Redirect("Thanks.aspx");
        }
    }   
}
