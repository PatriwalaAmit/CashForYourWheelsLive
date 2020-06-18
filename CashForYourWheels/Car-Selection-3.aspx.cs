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

public partial class Car_Selection_3 : System.Web.UI.Page
{
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    protected void CustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = new Regex("(GIR 0AA|[A-PR-UWYZ]([0-9]{1,2}|([A-HK-Y][0-9]|[A-HK-Y][0-9]([0-9]|[ABEHMNPRV-Y]))|[0-9][A-HJKS-UW]) [0-9][ABD-HJLNP-UW-Z]{2})",
        RegexOptions.IgnoreCase).IsMatch(args.Value);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ((LinkButton)Page.Master.FindControl("aValueMyCar")).CssClass = "active";
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
                Session["CarPlate"] = ((clsCarselection)(Session["userdata"])).CarPlate;

                if (!chkAgree.Checked)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Please select";
                    return;
                }
                if (Session["userdata"] != null)
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        /*Session["getCurrentTime"] = System.DateTime.Now;*/

                        log.Debug("Getting valuation");

                        /*here we have called -1 year*/
                        dt = BAL_Valuation.GetValuation(((clsCarselection)(Session["userdata"])).CapId.ToString(), -1, Convert.ToDateTime(((clsCarselection)(Session["userdata"])).FirstRegister).Month, ((clsCarselection)(Session["userdata"])).cs2_CurrentMileage + "!!" + Convert.ToString(Session["SValuation"]));

                        if (dt != null)
                        {
                            int iYear = Convert.ToDateTime(((clsCarselection)(Session["userdata"])).FirstRegister).Year;
                            int iMonth = Convert.ToDateTime(((clsCarselection)(Session["userdata"])).FirstRegister).Month;

                            DataTable dt1 = new DataTable();
                            dt1 = BAL_Valuation.GetValuation(((clsCarselection)(Session["userdata"])).CapId.ToString(), iYear, iMonth, ((clsCarselection)(Session["userdata"])).cs2_CurrentMileage + "!!" + Convert.ToString(Session["SValuation"]));

                            if (dt1.Rows.Count > 0)
                            {
                                dt.Clear();
                                dt = dt1;
                            }

                            //if (dt.Rows.Count == 0)
                            //{
                            //    int iYear = Convert.ToDateTime(((clsCarselection)(Session["userdata"])).FirstRegister).Year;
                            //    int iMonth = Convert.ToDateTime(((clsCarselection)(Session["userdata"])).FirstRegister).Month;

                            //    dt = BAL_Valuation.GetValuation(((clsCarselection)(Session["userdata"])).CapId.ToString(), iYear, iMonth, ((clsCarselection)(Session["userdata"])).cs2_CurrentMileage + "!!" + Convert.ToString(Session["SValuation"]));
                            //}
                            //else
                            //{
                            //    if (Convert.ToInt32(dt.Rows[0]["Uvt_Month"]) != Convert.ToDateTime(((clsCarselection)(Session["userdata"])).FirstRegister).Month)
                            //    {
                            //        int iYear = Convert.ToDateTime(((clsCarselection)(Session["userdata"])).FirstRegister).Year;
                            //        int iMonth = Convert.ToDateTime(((clsCarselection)(Session["userdata"])).FirstRegister).Month;

                            //        dt = BAL_Valuation.GetValuation(((clsCarselection)(Session["userdata"])).CapId.ToString(), iYear, iMonth, ((clsCarselection)(Session["userdata"])).cs2_CurrentMileage + "!!" + Convert.ToString(Session["SValuation"]));
                            //    }
                            //}
                        }
                        else
                        {
                            int iYear = Convert.ToDateTime(((clsCarselection)(Session["userdata"])).FirstRegister).Year;
                            int iMonth = Convert.ToDateTime(((clsCarselection)(Session["userdata"])).FirstRegister).Month;

                            dt = BAL_Valuation.GetValuation(((clsCarselection)(Session["userdata"])).CapId.ToString(), iYear, iMonth, ((clsCarselection)(Session["userdata"])).cs2_CurrentMileage + "!!" + Convert.ToString(Session["SValuation"]));
                        }

                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                //mail code
                                string strMessage = "Value of Car : Retail - " + dt.Rows[0]["uvt_retail"].ToString() + " | | | Average : " + dt.Rows[0]["uvt_average"].ToString() + " | | | Below - " + dt.Rows[0]["uvt_below"].ToString();
                                log.Debug(strMessage);
                                // CODE BY MARK
                                double capAvg = 0;
                                double capClean = 0;
                                double capBelow = 0;

                                double dCapAvg = 0;
                                double dCapClean = 0;
                                double dCapBelow = 0;

                                double.TryParse(dt.Rows[0]["uvt_average"].ToString(), out capAvg);
                                double.TryParse(dt.Rows[0]["uvt_clean"].ToString(), out capClean);
                                double.TryParse(dt.Rows[0]["uvt_below"].ToString(), out capBelow);

                                string strAvg = string.Empty;

                                dCapAvg = capAvg;
                                dCapBelow = capBelow;
                                dCapClean = capClean;

                                if (capAvg > 0 && capClean > 0)
                                {
                                    XmlDocument xmlDoc = new XmlDocument();
                                    xmlDoc.LoadXml(BAL_Valuation.GetValAdjustmentXML());

                                    // Establish what figures we are going to use
                                    //objcls.IsVan
                                    if (((clsCarselection)(Session["userdata"])).IsVan == false)
                                    {
                                        //getting new valuation
                                        capAvg = BAL_Rules.GetValuationBasedonRules(capAvg);
                                        capClean = BAL_Rules.GetValuationBasedonRules(capClean);
                                        capBelow = BAL_Rules.GetValuationBasedonRules(capBelow);


                                        log.Debug("New Car Value Based on the Rules -> Clean - " + capClean.ToString() + " | | | Average : " + capAvg.ToString() + " | | | Below - " + capBelow.ToString());

                                        switch (xmlDoc.SelectSingleNode("ValResource/ValType").InnerText)
                                        {
                                            case "0":
                                                {
                                                    strAvg = capClean.ToString("F0");
                                                    break;
                                                }
                                            case "1":
                                                {
                                                    strAvg = capAvg.ToString("F0");
                                                    break;
                                                }
                                            case "2":
                                                {
                                                    strAvg = capBelow.ToString("F0");
                                                    break;
                                                }
                                            case "3": // Custom calculation
                                                {
                                                    strAvg = ((capAvg + capClean) / 2).ToString("F0");
                                                    break;
                                                }
                                        }
                                    }
                                    else
                                    {
                                        // Its a van
                                        switch (xmlDoc.SelectSingleNode("ValResource/VanValType").InnerText)
                                        {
                                            case "0":
                                                {
                                                    strAvg = capClean.ToString("F0");
                                                    break;
                                                }
                                            case "1":
                                                {
                                                    strAvg = capAvg.ToString("F0");
                                                    break;
                                                }
                                            case "2":
                                                {
                                                    strAvg = capBelow.ToString("F0");
                                                    break;
                                                }
                                            case "3": // Custom calculation
                                                {
                                                    strAvg = ((capAvg + capClean) / 2).ToString("F0");
                                                    break;
                                                }
                                        }
                                    }


                                    // Now check if we are adding any additional stuff
                                    double pounds = 0;
                                    double percent = 0;

                                    if (((clsCarselection)(Session["userdata"])).IsVan == false)
                                    {
                                        double.TryParse(xmlDoc.SelectSingleNode("ValResource/PoundsMarkup").InnerText, out pounds);
                                        double.TryParse(xmlDoc.SelectSingleNode("ValResource/PercentMarkup").InnerText, out percent);
                                    }
                                    else
                                    {
                                        double.TryParse(xmlDoc.SelectSingleNode("ValResource/VanPounds").InnerText, out pounds);
                                        double.TryParse(xmlDoc.SelectSingleNode("ValResource/VanPercent").InnerText, out percent);
                                    }

                                    if (pounds != 0)
                                    {
                                        double tempVal = double.Parse(strAvg);
                                        tempVal += pounds;
                                        strAvg = tempVal.ToString("F0");
                                    }
                                    if (percent != 0)
                                    {
                                        double tempVal = double.Parse(strAvg);
                                        tempVal += ((tempVal / 100) * percent);
                                        strAvg = tempVal.ToString("F0");
                                    }

                                }
                                else
                                {
                                    strAvg = dt.Rows[0]["uvt_average"].ToString();
                                }
                                if (!string.IsNullOrEmpty(strAvg))
                                {
                                    if (strAvg.Contains("."))
                                    {
                                        string[] temp = strAvg.Split('.');

                                        if (temp[1].Length < 2)
                                        {
                                            temp[1] = temp[1] + "00";
                                            strAvg = temp[0].ToString() + "." + temp[1].Substring(0, temp[1].Length - 1);
                                        }
                                    }
                                }
                                // ROUNDING - move this into it's own class at some point
                                double adjAverage = double.Parse(strAvg);
                                if (adjAverage <= 1000)
                                    strAvg = ((double)Math.Round(((double)adjAverage) / 10, 0, MidpointRounding.AwayFromZero) * 10).ToString();
                                else if (adjAverage <= 10000)
                                    strAvg = ((double)Math.Round(((double)adjAverage) / 25, 0, MidpointRounding.AwayFromZero) * 25).ToString();
                                else if (adjAverage <= 30000)
                                    strAvg = ((double)Math.Round(((double)adjAverage) / 50, 0, MidpointRounding.AwayFromZero) * 50).ToString();
                                else if (adjAverage > 30000)
                                    strAvg = ((double)Math.Round(((double)adjAverage) / 100, 0, MidpointRounding.AwayFromZero) * 100).ToString();

                                String strCustFileName = Server.MapPath("~/MailContent") + "\\email.html";

                                StreamReader srCustHTML = new StreamReader(strCustFileName);
                                StringBuilder sbMessage = new StringBuilder(srCustHTML.ReadToEnd());
                                srCustHTML.Close();

                                sbMessage.Replace("@avgValue", strAvg);

                                string strFirstName = ddlSaluation.SelectedItem.Text + " " + txtLastName.Text.ToString().Substring(0, 1).ToUpper() + txtLastName.Text.ToString().Substring(1).ToLower();
                                sbMessage.Replace("@firstname", strFirstName);
                                sbMessage.Replace("@footerValue", BAL_CMS.GetDetailsByLinkName("Home Page Footer"));

                                // This is nonsense - use one valuation session variable!
                                Session["CarValuation"] = strAvg;
                                Session["Valuation"] = strAvg;

                                Utilities.SendMail(ConfigurationManager.AppSettings["adminEmailAddress"], txtEmailAddress.Text, "Value of Vehicle : " + ((clsCarselection)(Session["userdata"])).CarPlate, sbMessage.ToString(), string.Empty);

                                /*Administrator email*/
                                string strBodyWork = string.Empty;
                                DataTable dtBodyWork = ((clsCarselection)(Session["userdata"])).cs3_BodyWork;
                                if (dtBodyWork != null)
                                {
                                    if (dtBodyWork.Rows.Count > 0)
                                    {
                                        strBodyWork = "";
                                    }
                                }

                                String strFileName = Server.MapPath("~/MailContent") + "\\carregistrationdetail.html";

                                StreamReader srHTML = new StreamReader(strFileName);
                                StringBuilder sb = new StringBuilder(srHTML.ReadToEnd());
                                sb.Replace("@registration", ((clsCarselection)(Session["userdata"])).Registration);
                                sb.Replace("@valuation", "£" + Convert.ToString(strAvg));
                                sb.Replace("@capclean", "£" + Convert.ToString(BAL_Rules.RoundingValues(dCapClean)));
                                sb.Replace("@capaverage", "£" + Convert.ToString(BAL_Rules.RoundingValues(dCapAvg)));
                                sb.Replace("@capbelow", "£" + Convert.ToString(BAL_Rules.RoundingValues(dCapBelow)));
                                sb.Replace("@manufacturer", ((clsCarselection)(Session["userdata"])).Manufacturer);
                                sb.Replace("@model@", ((clsCarselection)(Session["userdata"])).Model);
                                sb.Replace("@modelyear@", ((clsCarselection)(Session["userdata"])).ModelYear);
                                sb.Replace("@colour", ((clsCarselection)(Session["userdata"])).Colour);
                                sb.Replace("@transmission", ((clsCarselection)(Session["userdata"])).Transmission);
                                sb.Replace("@enginesize", ((clsCarselection)(Session["userdata"])).EngineSize);
                                sb.Replace("@firstregistered", ((clsCarselection)(Session["userdata"])).FirstRegister);

                                sb.Replace("@cs2_currentmileage", ((clsCarselection)(Session["userdata"])).cs2_CurrentMileage);
                                sb.Replace("@cs2_carimport", ((clsCarselection)(Session["userdata"])).cs2_CarImport);
                                sb.Replace("@cs2_pregistration", ((clsCarselection)(Session["userdata"])).cs2_PRegistration);
                                sb.Replace("@cs2_insurance", ((clsCarselection)(Session["userdata"])).cs2_Insurance);
                                sb.Replace("@cs2_powners", ((clsCarselection)(Session["userdata"])).cs2_POwners);
                                sb.Replace("@cs2_shistory", ((clsCarselection)(Session["userdata"])).cs2_SHistory);
                                sb.Replace("@cs2_mot", ((clsCarselection)(Session["userdata"])).cs2_MOT);
                                sb.Replace("@cs2_vcondition", ((clsCarselection)(Session["userdata"])).cs2_VCondition);
                                sb.Replace("@cs2_v5", ((clsCarselection)(Session["userdata"])).cs2_V5);
                                sb.Replace("@cs2_ofinance", ((clsCarselection)(Session["userdata"])).cs2_OFinance);

                                sb.Replace("@title", ddlSaluation.SelectedItem.Text);
                                sb.Replace("@firstname", txtFirstName.Text);
                                sb.Replace("@lastname", txtLastName.Text);
                                sb.Replace("@phonenumber", txtPhoneNumber.Text);
                                sb.Replace("@emailaddress", txtEmailAddress.Text);
                                sb.Replace("@postcode", txtPostcode.Text);

                                //Utilities.SendMail("info@cashforyourwheels.co.uk", "info@cashforyourwheels.co.uk", "Detailed Report " + ((clsCarselection)(Session["userdata"])).CarPlate, sb.ToString());
                                Utilities.SendMail(ConfigurationManager.AppSettings["adminEmailAddress"], ConfigurationManager.AppSettings["adminEmailAddress"], "Detailed Report " + ((clsCarselection)(Session["userdata"])).CarPlate, sb.ToString(), string.Empty);
                                Utilities.LogVisitor(ddlSaluation.SelectedItem.Text, txtFirstName.Text, txtLastName.Text, txtEmailAddress.Text, ((clsCarselection)(Session["userdata"])).CarPlate.ToString(), Convert.ToString(strAvg));

                                Response.Redirect("~/yourvaluation.aspx", false);
                            }
                            else
                            {
                                ShowMessage("There seems to be a problem with your particular plate, please call the office on 0845 519 0898 and we will provide you with an instant quote over the phone.");
                            }
                        }
                        else
                        {
                            ShowMessage("There seems to be a problem with your particular plate, please call the office on 0845 519 0898 and we will provide you with an instant quote over the phone.");
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowMessage("There seems to be a problem with your particular plate, please call the office on 0845 519 0898 and we will provide you with an instant quote over the phone.");
                        //ShowMessage(ex.Message);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            log.Error("Error in Val", ex);
        }
    }

    private void ShowMessage(string msg)
    {
        DisplayAlertMessage.CreateMessageAlert(this, msg, "alertKey");
    }

    protected void btnassumption_Click(object sender, EventArgs e)
    {
        mdlPopup.Show();
    }

    protected void btnTC_click(object sender, EventArgs e)
    {
        mpTC.Show();
    }
}
