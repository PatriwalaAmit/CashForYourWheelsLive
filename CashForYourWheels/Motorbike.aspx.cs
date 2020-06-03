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
using System.Xml;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using log4net;

public partial class Motorbike : System.Web.UI.Page
{
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    protected void CustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = new Regex("(GIR 0AA|[A-PR-UWYZ]([0-9]{1,2}|([A-HK-Y][0-9]|[A-HK-Y][0-9]([0-9]|[ABEHMNPRV-Y]))|[0-9][A-HJKS-UW]) [0-9][ABD-HJLNP-UW-Z]{2})",
        RegexOptions.IgnoreCase).IsMatch(args.Value);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //((LinkButton)Page.Master.FindControl("aValueMyCar")).CssClass = "active";
        ((LinkButton)Page.Master.FindControl("aValueMyCar")).CssClass = "-active";
        ((LinkButton)Page.Master.FindControl("aSellMotorbike")).CssClass = "active"; 
    }
    protected void btnGetValuation_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                log.Debug("Entered code");
                Session["saluation"] = ddlSaluation.SelectedItem.Text;
                Session["CustomerName"] = txtFirstName.Text + " " + txtLastName.Text;
                Session["Lastname"] = txtLastName.Text;
                Session["Phonenumber"] = txtPhoneNumber.Text;
                Session["EmailAddress"] = txtEmailAddress.Text;
                Session["PostCode"] = txtPostcode.Text;

                try
                {
                    String strFileName = Server.MapPath("~/MailContent") + "\\motorbikeregistrationdetail.html";

                    StreamReader srHTML = new StreamReader(strFileName);
                    StringBuilder sb = new StringBuilder(srHTML.ReadToEnd());
                    sb.Replace("@registration", txtRegistration.Text);
                    sb.Replace("@datetime", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                    sb.Replace("@makemodel", txtMakeModel.Text);
                    sb.Replace("@make", txtMake.Text);
                    sb.Replace("@colour", txtColour.Text);
                    sb.Replace("@previous", txtPrev.Text);
                    sb.Replace("@year", txtYear.Text);
                    sb.Replace("@mileage", txtMileage.Text);
                    sb.Replace("@title", ddlSaluation.SelectedItem.Text);
                    sb.Replace("@firstname", txtFirstName.Text);
                    sb.Replace("@lastname", txtLastName.Text);
                    sb.Replace("@phonenumber", txtPhoneNumber.Text);
                    sb.Replace("@emailaddress", txtEmailAddress.Text);
                    sb.Replace("@postcode", txtPostcode.Text);
                    sb.Replace("@otherinfo", txtOtherInfo.Text);
                    Utilities.SendMail(ConfigurationManager.AppSettings["adminEmailAddress"], ConfigurationManager.AppSettings["adminEmailAddress"], "Motorbike Enquiry - Reg: " + txtRegistration.Text, sb.ToString(), string.Empty);

                    strFileName = Server.MapPath("~/MailContent") + "\\lmbemail.html";
                    srHTML = new StreamReader(strFileName);
                    sb = new StringBuilder(srHTML.ReadToEnd());
                    Session["VehicleType"] = "MB";
                    sb.Replace("@firstname", ddlSaluation.SelectedItem.Text +" "+txtFirstName.Text);
                    sb.Replace("<<VEHICLEIMAGE>>", "motorbike.jpg");
                    Utilities.SendMail(ConfigurationManager.AppSettings["adminEmailAddress"], txtEmailAddress.Text, "Vehicle Enquiry from CashForYourWheels", sb.ToString(), string.Empty);
                    srHTML.Close();


                    Response.Redirect("~/thanks.aspx", false);
                }
                catch (Exception ex)
                {
                    ShowMessage("There seems to be a problem with your form submission, please call the office on 0845 519 0898 and we will provide you with an instant quote over the phone.");
                    //ShowMessage(ex.Message);
                }
            }
        }
        catch (Exception ex)
        {
            log.Error("Error in LeisureVehicle", ex);
        }
    }

    private void ShowMessage(string msg)
    {
        DisplayAlertMessage.CreateMessageAlert(this, msg, "alertKey");
    }

    //protected void btnassumption_Click(object sender, EventArgs e)
    //{
    //    mdlPopup.Show();
    //}

    //protected void btnTC_click(object sender, EventArgs e)
    //{
    //    mpTC.Show();
    //}   
}
