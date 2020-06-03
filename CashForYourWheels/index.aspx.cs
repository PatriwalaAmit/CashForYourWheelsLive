using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using log4net;

public partial class index : System.Web.UI.Page
{
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    protected void Page_Load(object sender, EventArgs e)
    {
        ((LinkButton)Page.Master.FindControl("aValueMyCar")).CssClass = "active";
        ((LinkButton)Page.Master.FindControl("aBranchLocator")).CssClass = "-active";
        ((LinkButton)Page.Master.FindControl("aTestimonials")).CssClass = "-active";
        ((LinkButton)Page.Master.FindControl("aNews")).CssClass = "-active";
        ((LinkButton)Page.Master.FindControl("aContact")).CssClass = "-active";
        ((LinkButton)Page.Master.FindControl("aSellMotorbike")).CssClass = "-active";
        ((LinkButton)Page.Master.FindControl("aSellLeisure")).CssClass = "-active";

        string strError = Convert.ToString(Request.QueryString["error"]);

        log.Debug("Index -> PageLoad");

        if (!string.IsNullOrEmpty(strError))
        {
            if (strError == "data")
            {
                ShowMessage("There seems to be a problem with your particular plate, please call the office on 0845 519 0898 and we will provide you with an instant quote over the phone.");
            }
            else if (strError == "van")
            {
                ShowMessage("There seems to be a problem with your selection, you need to select VAN tab for the valuation");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertKey", "getMsg();", true);
            }
        }
    }
    protected void btnCarGo_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Session["CapId"] = null;
            Session["userdata"] = null;
            Session["CarRegNumber"] = null;

            string strUserIp = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            if (!string.IsNullOrEmpty(strUserIp))
            {
                /*if development mode*/
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["DevelopmentMode"]))
                {
                    log.Debug("Go -> Development mode");
                    Session["CarRegNumber"] = txtSellCarRegNumber.Text;
                    Response.Redirect("car.aspx?carnumber=" + txtSellCarRegNumber.Text);
                }

                //check the ipaddress in db
                if (BAL_Zones.VisitorTracking(strUserIp))
                {
                    log.Debug("Go -> Live mode");
                    Session["CarRegNumber"] = txtSellCarRegNumber.Text;
                    Response.Redirect("car.aspx?carnumber=" + txtSellCarRegNumber.Text);
                }
                else
                {
                    ShowMessage("You have used our service too many times in the last 24 hours or your IP address has been blacklisted. Please call us or retry tomorrow");
                }
            }
        }
    }

    protected void btnCarGo2_Click(object sender, EventArgs e)
    {
        Response.Redirect("leisure.aspx");
    }

    protected void btnCarGo3_Click(object sender, EventArgs e)
    {
        Response.Redirect("leisure.aspx");
    }

    private void ShowMessage(string msg)
    {
        DisplayAlertMessage.CreateMessageAlert(this, msg, "alertKey");
    }
}
