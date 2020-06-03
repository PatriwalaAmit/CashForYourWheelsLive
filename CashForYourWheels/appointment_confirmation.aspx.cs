using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class appointment_confirmation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Appointment Confirmation Email

            /*
             * String strCustFileName = Server.MapPath("~/MailContent") + "\\appconfirmation.html";

            System.IO.StreamReader srCustHTML = new System.IO.StreamReader(strCustFileName);
            System.Text.StringBuilder sbMessage = new System.Text.StringBuilder(srCustHTML.ReadToEnd());
            srCustHTML.Close();

            sbMessage.Replace("@title", Convert.ToString(Session["saluation"]));
            sbMessage.Replace("@surname", Convert.ToString(Session["Lastname"]));
            sbMessage.Replace("@valuation", Convert.ToString(Session["CarValuation"]));
            sbMessage.Replace("@apptime", Convert.ToString(Session["apptime"]).Replace(" ", string.Empty));
            sbMessage.Replace("@appdate", Convert.ToString(Session["appdate"]));
            sbMessage.Replace("@branch", Convert.ToString(Session["branchname"]));
            sbMessage.Replace("@carnumber", Convert.ToString(Session["CarPlate"]));
            sbMessage.Replace("@registration", ((clsCarselection)(Session["userdata"])).Registration);
            sbMessage.Replace("@vehicle", ((clsCarselection)(Session["userdata"])).Model);
            sbMessage.Replace("@mileage", ((clsCarselection)(Session["userdata"])).cs2_CurrentMileage);


            sbMessage.Replace("@footerValue", BAL_CMS.GetDetailsByLinkName("Home Page Footer"));


            Utilities.SendMail("info@cashforyourwheels.co.uk", "info@cashforyourwheels.co.uk", "Appointment Confirmation Email " + ((clsCarselection)(Session["userdata"])).CarPlate, sbMessage.ToString());
            Utilities.SendMail("info@cashforyourwheels.co.uk", Convert.ToString(Session["EmailAddress"]), "Appointment Confirmation Email " + ((clsCarselection)(Session["userdata"])).CarPlate, sbMessage.ToString());
             * */
        }
    }
}
