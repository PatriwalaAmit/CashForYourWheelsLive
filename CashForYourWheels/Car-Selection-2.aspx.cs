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
using System.Diagnostics;
using log4net;

public partial class Car_Selection_2 : System.Web.UI.Page
{
    private Random random = new Random();

    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


    protected void Page_Load(object sender, EventArgs e)
    {

        //     trMileage.BgColor = "#ffcccc";

        ((LinkButton)Page.Master.FindControl("aValueMyCar")).CssClass = "active";
        log.Debug("Into PageLoad");

        if (!this.IsPostBack)
        {
            log.Debug("Into !this.IsPostback");
            if (this.Session["CaptchaImageText"] == null)
            {
                this.Session["CaptchaImageText"] = GenerateRandomCode(); // Create a random code and store it in the Session object.
                log.Debug("CaptchaImage Text:" + this.Session["CaptchaImageText"].ToString());
            }
            else
            {
                if (this.Session["CaptchaImageText"].ToString() != txtCaptcha.Text)
                {
                    this.txtCaptcha.Text = "";
                    this.Session["CaptchaImageText"] = GenerateRandomCode();
                    log.Debug("CaptchaImage Cleared and set to Text:" + this.Session["CaptchaImageText"].ToString());
                }
            }
            log.Debug("Exiting !this.IsPostback");
        }
        else
        {
            log.Debug("Into Else Block");
            rfvMileage.ErrorMessage = "Please enter";
            cvMileage.ErrorMessage = "Value must be a numeric!";
            revMileage.ErrorMessage = "Please enter maxium 1,000,000";
            RequiredFieldValidator1.Text = "Please enter the code shown in the image above";

            //log.Debug("SessionText=" + this.Session["CaptchaImageText"] == null ? "" : this.Session["CaptchaImageText"].ToString());
            log.Debug("txtCaptcha.Text=" + this.txtCaptcha.Text);

            // On a postback, check the user input.
            if (txtCaptcha.Text != this.Session["CaptchaImageText"].ToString())
            {
                // Display an error message.                                
                this.txtCaptcha.Text = "";
                this.Session["CaptchaImageText"] = GenerateRandomCode();

            }
            log.Debug("Exiting Else Block");
        }
    }

    //
    // Returns a string of six random digits.
    //
    private string GenerateRandomCode()
    {
        log.Debug("Entered GenerateRandomCode()");
        string s = DateTime.Now.Millisecond.ToString();
        for (int i = 0; i < 6; i++)
            s = String.Concat(s, this.random.Next(10).ToString());
        log.Debug("Returning " + s.Substring(0, 4));
        return s.Substring(0, 4);        
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        log.Debug("Into btnNext_Click");
        if (Page.IsValid)
        {
            log.Debug("Into Page.IsValid");
            /*collect the data*/
            string strMileage = txtMileage.Value;

            try
            {
                if (Convert.ToInt64(strMileage)*1000 >= 140000)
                {
                    lblMessage.Visible = true;
                    btnNext.Visible = false;                    
                    return;
                }
            }
            catch (Exception ex)
            {
                log.Debug("Car Mileage Check > 140000 - " + ex.InnerException);
            }
            //string strCar_Import = rbImport.SelectedItem.Text;
            //string strCar_Personalised = rbPersonalised.SelectedItem == null ? "" : rbPersonalised.SelectedItem.Text;
            string strCar_Insurance = ddlRoadTax.SelectedItem.Value == string.Empty ? "" : ddlRoadTax.SelectedItem.Text;
            //string strCar_PreviousOwner = rbPersonalOwner.SelectedItem == null ? "" : rbPersonalOwner.SelectedItem.Text;
            string strCar_ServiceHistory = rbServiceHistory.SelectedItem == null ? "" : rbServiceHistory.SelectedItem.Text;
            string strCar_MOT = rbMOT.SelectedItem == null ? "" : rbMOT.SelectedItem.Text;
            //string strCar_Condition = rbVehicleCondition.SelectedItem == null ? "" : rbVehicleCondition.SelectedItem.Text;
            string strCar_V5 = rbV5.SelectedItem == null ? "" : rbV5.SelectedItem.Text;
            string strCar_OutStanding = rbOutstandingfinance.SelectedItem == null ? "" : rbOutstandingfinance.SelectedItem.Text;

            /*end collection of data*/

            ((clsCarselection)Session["userdata"]).cs2_CurrentMileage = (Convert.ToInt32(strMileage) * 1000).ToString();
            //((clsCarselection)Session["userdata"]).cs2_CarImport = strCar_Import;
            //((clsCarselection)Session["userdata"]).cs2_PRegistration = strCar_Personalised;
            ((clsCarselection)Session["userdata"]).cs2_Insurance = strCar_Insurance;
            // ((clsCarselection)Session["userdata"]).cs2_POwners = strCar_PreviousOwner;
            ((clsCarselection)Session["userdata"]).cs2_SHistory = strCar_ServiceHistory;
            ((clsCarselection)Session["userdata"]).cs2_MOT = strCar_MOT;
            //((clsCarselection)Session["userdata"]).cs2_VCondition = strCar_Condition;
            ((clsCarselection)Session["userdata"]).cs2_V5 = strCar_V5;
            ((clsCarselection)Session["userdata"]).cs2_OFinance = strCar_OutStanding;

            log.Debug("Parsing data for parallelval");

            string strCapId = ((clsCarselection)(Session["userdata"])).CapId.ToString();
            string strYear = Convert.ToDateTime(((clsCarselection)(Session["userdata"])).FirstRegister).Year.ToString();
            string strMonth = Convert.ToDateTime(((clsCarselection)(Session["userdata"])).FirstRegister).Month.ToString();
            Session["SValuation"] = Session.SessionID.ToString().Substring(1, 10);
            string strSessionId = Convert.ToString(Session["SValuation"]);
            string strCurrentMileage = (((clsCarselection)(Session["userdata"])).cs2_CurrentMileage);
            string strCarVan = string.Empty;

            if (bool.Parse((((clsCarselection)Session["userdata"]).IsVan).ToString()) == true)
                strCarVan = "V";
            else
                strCarVan = "C";            

            string objArgument = strCapId + "^" + strYear + "^" + strMonth + "^" + strSessionId + "^" + strCurrentMileage + "^" + strCarVan;

            log.Debug("Value of arguments: " + objArgument);

            //BAL_Valuation.GetValuation(strCapId, Convert.ToInt32(strYear), Convert.ToInt32(strMonth), strCurrentMileage, strSessionId);

            Process pValuation = new Process();

            ProcessStartInfo ObjParallelValuation = new System.Diagnostics.ProcessStartInfo(Server.MapPath(@"~\parallelprocessvaluation") + @"\ParallelValuation.exe");//Replace with your console exe

            ObjParallelValuation.Arguments = objArgument;

            pValuation.StartInfo = ObjParallelValuation;


            try { pValuation.Start(); }
            catch (Exception ex)
            {
                log.Error("Error in processstart", ex);
            }
        
            Response.Redirect("~/Car-Selection-3.aspx");
        }
        else
        {
            log.Debug("Page is not valid");
            txtCaptcha.Text = string.Empty;
            Page.Validate();
            ClientScript.RegisterStartupScript(GetType(), "Validation", "<script language='javascript'> document.getElementById('trCaptch').style.backgroundColor = '#ffcccc'; </script>");
            //ClientScript.RegisterStartupScript(GetType(), "Validation", "<script language='javascript'> Check(); CheckCapt(); WebForm_OnSubmit(); </script>");
            //lblCaptchMessage.Text = "Please enter the code shown in the image above";     	   
        }
    }
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(((clsCarselection)Session["userdata"]).CarPlate))
            Response.Redirect("Car.aspx?carnumber='" + ((clsCarselection)Session["userdata"]).CarPlate + "'");
        else
            Response.Redirect("findmycar.aspx");
    }
}
