using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CashForYourWheels
{
    public partial class car_sourcing : System.Web.UI.Page
    {
        private Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
         
                if (this.Session["CaptchaImageText"] == null)
                {
                    this.Session["CaptchaImageText"] = GenerateRandomCode(); // Create a random code and store it in the Session object.                   
                }
                else
                {
                    if (this.Session["CaptchaImageText"].ToString() != txtCaptcha.Text)
                    {
                        this.txtCaptcha.Text = "";
                        this.Session["CaptchaImageText"] = GenerateRandomCode();                        
                    }
                }                
            }
            else
            {
                lblCaptchMessage.Text = "Please enter the code shown in the image above";

                // On a postback, check the user input.
                if (txtCaptcha.Text != this.Session["CaptchaImageText"].ToString())
                {
                    // Display an error message.                                
                    this.txtCaptcha.Text = "";
                    this.Session["CaptchaImageText"] = GenerateRandomCode();

                }                
            }
        }

        //
        // Returns a string of six random digits.
        //
        private string GenerateRandomCode()
        {            
            string s = DateTime.Now.Millisecond.ToString();
            for (int i = 0; i < 6; i++)
                s = String.Concat(s, this.random.Next(10).ToString());
         
            return s.Substring(0, 4);
        }

        private void clearOutput()
        {
            txtFullName.Text = string.Empty;
            txtPostCode.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtEmailAddress.Text = string.Empty;
            txtCarDetails.InnerText = string.Empty;
            txtBudget.Text = string.Empty;
            txtFinance.Text = string.Empty;
            lblCaptchMessage.Text = string.Empty;
        }

        protected void btnSubmit_click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string strFullName = txtFullName.Text;
                string strPostCode = txtPostCode.Text;
                string strPhoneNumber = txtPhoneNumber.Text;
                string strEmailAddress = txtEmailAddress.Text;
                string strCarDetails = txtCarDetails.InnerText;
                string strBudget = txtBudget.Text;
                string strFinance = txtFinance.Text;

                if (BAL_CarSourcing.InsertUpdateDeleteCarSourcing("insert", 0, strFullName, strPostCode, strPhoneNumber, strEmailAddress, strCarDetails, strBudget, strFinance, true, false))                {
                    
                    lblMessage.Text = "Thank you for sending us your enquiry. We endeavour to reply to your enquiry as soon as possible";
                    clearOutput();
                    //Response.Redirect("Thanks.aspx");
                }
            }
        }
    }
}
