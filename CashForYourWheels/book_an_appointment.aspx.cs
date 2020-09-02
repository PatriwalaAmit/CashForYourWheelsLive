using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using log4net;

public partial class book_an_appointment : System.Web.UI.Page
{
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            log.Debug("Into IsPostBack");

            imgCarPhoto.Src = "~/getcarimage.aspx";

            ////get the brach information
            //DataTable dtLocation = BAL_location.GetCMSByCMSId(0);
            //string strBranchinformation = dtLocation.Rows[0]["LocationName"].ToString();
            //hdnId.Value = dtLocation.Rows[0]["LocationId"].ToString();
            DataTable dt = BAL_location.GetCMSByCMSId(0);
            DataRow tdr = dt.NewRow();
            tdr[0] = "0";
            tdr[1] = "Please select";
            dt.Rows.InsertAt(tdr, 0);
            ddlChooseBranch.DataSource = dt;
            ddlChooseBranch.DataValueField = dt.Columns["LocationId"].ToString();
            ddlChooseBranch.DataTextField = dt.Columns["LocationName"].ToString();
            ddlChooseBranch.DataBind();

            Session["branchname"] = ddlChooseBranch.SelectedItem.Text;

            DataTable dtBrachtiming = BAL_branchtime.GetTiming(ddlChooseBranch.SelectedItem.Value);
            ViewState["LocationData"] = dtBrachtiming;

            ddlAvailabletimeslot.Items.Clear();
            ddlChoosedate.Items.Clear();

            // date selection
            //ddlChoosedate.Items.Add(new ListItem("Please select date", "-1"));
            DataTable dtApDate = new DataTable();
            dtApDate.Columns.Add("ApDate", Type.GetType("System.DateTime"));

            DataTable dtAppBlockDate = new DataTable();
            dtAppBlockDate = BALBlockedAppointments.SelectBlockAppointment("appstatus", 0, int.Parse(ddlChooseBranch.SelectedItem.Value));

            ViewState["BlockDate"] = dtAppBlockDate;

            for (int selecteddate = 0; selecteddate < 14; selecteddate++)
            {
                foreach (DataRow dr in dtBrachtiming.Rows)
                {
                    if (dr["WorkingHoursFrom"].ToString() != dr["WorkingHoursTo"].ToString())
                    {
                        //select the date using the week
                        string strDay = dr["WorkingDay"].ToString();
                        DateTime currentdate = System.DateTime.Now;
                        currentdate = currentdate.AddDays(selecteddate);
                        //Response.Write("<br>" + currentdate.Date.DayOfWeek.ToString().ToLower() + " " + strDay.ToString().ToLower());

                        //check the blockdate
                        Boolean Isblocked = false;
                        foreach (DataRow item in dtAppBlockDate.Rows)
                        {
                            //if (Convert.ToDateTime(item["appdate"].ToString()) == currentdate)
                            if (Convert.ToDateTime(item["appdate"].ToString()).ToShortDateString() == currentdate.ToShortDateString())
                            {
                                if (item["op"].ToString().ToLower() == "Restrict".ToLower())
                                {
                                    Isblocked = true;
                                }
                            }
                        }

                        if (currentdate.Date.DayOfWeek.ToString().ToLower() == strDay.ToLower())
                        {
                            if (!Isblocked)
                            {
                                if (Session["branchname"].ToString().ToLower() == "swansea")
                                {
                                    if (currentdate.CompareTo(DateTime.Parse("02/12/2013")) <= 0)
                                    {
                                        DataRow drAp = dtApDate.NewRow();
                                        drAp["ApDate"] = currentdate.ToShortDateString();
                                        dtApDate.Rows.Add(drAp);
                                    }
                                }
                                else
                                {
                                    DataRow drAp = dtApDate.NewRow();
                                    drAp["ApDate"] = currentdate.ToShortDateString();
                                    dtApDate.Rows.Add(drAp);
                                }
                            }
                        }
                    }
                }
            }
            DataView dvAp = dtApDate.DefaultView;
            dvAp.Sort = "Apdate ASC";

            foreach (DataRowView item in dvAp)
            {
                ddlChoosedate.Items.Add(new ListItem(((DateTime)item[0]).ToShortDateString(), ((DateTime)item[0]).Date.ToShortDateString()));
            }

            ddlChoosedate.Items.Insert(0, new ListItem("Please select date", "-1"));
            //timing selection
            ddlAvailabletimeslot.Items.Insert(0, new ListItem("Please select time", "-1"));
        }

        ddlAvailabletimeslot.Visible = true;
        spanBooked.Visible = false;
        hlCarButton.Visible = true;
    }

    protected void hlCarButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            trError.Visible = false;

            if (Session["userdata"] != null)
            {
                string strCustomerName = Convert.ToString(Session["CustomerName"]);
                string phonenumber = Convert.ToString(Session["Phonenumber"]);
                string emailaddress = Convert.ToString(Session["EmailAddress"]);
                string zipcode = Convert.ToString(Session["PostCode"]);
                string carplate = Convert.ToString(Session["CarPlate"]);
                string carValuation = Convert.ToString(Session["Valuation"]);
                //Response.Write("Customer Name" + strCustomerName + "<br> Phone number" + phonenumber + " <br> Email " + emailaddress + " <br> Zipcode" + zipcode + "<br> CarPlate" + carplate);

                BAL_BookAppointment.UpdateAppointment("0", strCustomerName, phonenumber, emailaddress, zipcode, ddlChoosedate.SelectedItem.Text.ToString(), ddlAvailabletimeslot.SelectedItem.Text.ToString(), "0", carplate, carValuation, int.Parse(ddlChooseBranch.SelectedItem.Value));

                Session["appdate"] = ddlChoosedate.SelectedItem.Text;
                Session["apptime"] = ddlAvailabletimeslot.SelectedItem.Text;

                /*email send code*/

                //Appointment Confirmation Email           
                String strCustFileName = Server.MapPath("~/MailContent") + "\\appconfirmation.html";


                if (Session["branchname"] != null)
                {
                    if (Session["branchname"].ToString().ToLower().Trim() == "bridgend")
                    {
                        strCustFileName = Server.MapPath("~/MailContent") + "\\bridgend-appconfirmation.html";
                    }
                    else if (Session["branchname"].ToString().ToLower().Trim() == "bristol")
                    {
                        strCustFileName = Server.MapPath("~/MailContent") + "\\bristol-appconfirmation.html";
                    }
                    else if (Session["branchname"].ToString().ToLower().Trim() == "cardiff")
                    {
                        strCustFileName = Server.MapPath("~/MailContent") + "\\cardiff-appconfirmation.html";
                    }

                }

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

                string brnchEmailAddress = string.Empty;
                string ccEmail = string.Empty;

                switch (Session["branchname"].ToString().ToLower().Trim())
                {
                    case "bridgend":
                        sbMessage.Replace("@officenumber", ConfigurationManager.AppSettings["Bridgend_Phone"].ToString());
                        sbMessage.Replace("@address", ConfigurationManager.AppSettings["Bridgend_Address"].ToString());
                        brnchEmailAddress = ConfigurationManager.AppSettings["adminEmailAddress"].ToString();
                        ccEmail = ConfigurationManager.AppSettings["Cardiff_Email"].ToString();
                        break;
                    case "cardiff":
                        brnchEmailAddress = ConfigurationManager.AppSettings["Cardiff_Email"].ToString();
                        sbMessage.Replace("@officenumber", ConfigurationManager.AppSettings["Cardiff_Phone"].ToString());
                        sbMessage.Replace("@address", ConfigurationManager.AppSettings["Cardiff_Address"].ToString());
                        ccEmail = ConfigurationManager.AppSettings["adminEmailAddress"].ToString();
                        break;
                    case "swansea":
                        brnchEmailAddress = ConfigurationManager.AppSettings["Swansea_Email"].ToString();
                        sbMessage.Replace("@officenumber", ConfigurationManager.AppSettings["Swansea_Phone"].ToString());
                        sbMessage.Replace("@address", ConfigurationManager.AppSettings["Swansea_Address"].ToString());
                        ccEmail = ConfigurationManager.AppSettings["adminEmailAddress"].ToString();
                        break;
                    case "newport":
                        brnchEmailAddress = ConfigurationManager.AppSettings["Newport_Email"].ToString();
                        sbMessage.Replace("@officenumber", ConfigurationManager.AppSettings["Newport_Phone"].ToString());
                        sbMessage.Replace("@address", ConfigurationManager.AppSettings["Newport_Address"].ToString());
                        ccEmail = ConfigurationManager.AppSettings["adminEmailAddress"].ToString();
                        break;
                    case "bristol":
                        brnchEmailAddress = ConfigurationManager.AppSettings["Bristol_Email"].ToString();
                        sbMessage.Replace("@officenumber", ConfigurationManager.AppSettings["Bristol_Phone"].ToString());
                        sbMessage.Replace("@address", ConfigurationManager.AppSettings["Bristol_Address"].ToString());
                        ccEmail = ConfigurationManager.AppSettings["adminEmailAddress"].ToString();
                        break;
                    case "gloucester":
                        brnchEmailAddress = ConfigurationManager.AppSettings["gloucester_email"].ToString();
                        sbMessage.Replace("@officenumber", ConfigurationManager.AppSettings["gloucester_phone"].ToString());
                        sbMessage.Replace("@address", ConfigurationManager.AppSettings["gloucester_address"].ToString());
                        ccEmail = ConfigurationManager.AppSettings["adminEmailAddress"].ToString();
                        break;
                    case "swindon":
                        brnchEmailAddress = ConfigurationManager.AppSettings["swindon_email"].ToString();
                        sbMessage.Replace("@officenumber", ConfigurationManager.AppSettings["swindon_phone"].ToString());
                        sbMessage.Replace("@address", ConfigurationManager.AppSettings["swindon_address"].ToString());
                        ccEmail = ConfigurationManager.AppSettings["adminEmailAddress"].ToString();
                        break;
                    default:
                        brnchEmailAddress = "";
                        sbMessage.Replace("@officenumber", "01452835619");
                        sbMessage.Replace("@address", "");
                        ccEmail = ConfigurationManager.AppSettings["adminEmailAddress"].ToString();
                        break;
                }

                log.Debug("Sending appointment emails");
                Utilities.SendMail(ConfigurationManager.AppSettings["adminEmailAddress"], brnchEmailAddress, "Appointment Confirmation Email " + ((clsCarselection)(Session["userdata"])).CarPlate, sbMessage.ToString(), ccEmail);
                //Utilities.SendMail("info@cashforyourwheels.co.uk", "amit@ibusiness-management.com", "Appointment Confirmation Email " + ((clsCarselection)(Session["userdata"])).CarPlate, sbMessage.ToString());
                Utilities.SendMail(ConfigurationManager.AppSettings["adminEmailAddress"], Convert.ToString(Session["EmailAddress"]), "Appointment Confirmation Email " + ((clsCarselection)(Session["userdata"])).CarPlate, sbMessage.ToString(), string.Empty);

                /*email send code*/
                Utilities.RemoveFollowup(emailaddress);

                Response.Redirect("~/appointment_confirmation.aspx");

                lblError.Text = "Appointment booking succesfully";
            }
            else
            {
                trError.Visible = true;
                lblError.Text = "Please contact your Administrator";
            }
        }
    }

    protected void ddlChooseBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        log.Debug("Into ChooseBranch");
        Session["branchname"] = ddlChooseBranch.SelectedItem.Text;

        DataTable dtBrachtiming = BAL_branchtime.GetTiming(ddlChooseBranch.SelectedItem.Value);
        ViewState["LocationData"] = dtBrachtiming;

        ddlAvailabletimeslot.Items.Clear();
        ddlChoosedate.Items.Clear();

        // date selection
        //ddlChoosedate.Items.Add(new ListItem("Please select date", "-1"));
        DataTable dtApDate = new DataTable();
        dtApDate.Columns.Add("ApDate", Type.GetType("System.DateTime"));

        DataTable dtAppBlockDate = new DataTable();
        //dtAppBlockDate = BALBlockedAppointments.SelectBlockAppointment("appstatus", 0, int.Parse(ddlChooseBranch.SelectedItem.Value));
        dtAppBlockDate = BALBlockedAppointments.SelectBlockAppointment("appstatuslocationwise", 0, int.Parse(ddlChooseBranch.SelectedItem.Value));

        ViewState["BlockDate"] = dtAppBlockDate;

        for (int selecteddate = 0; selecteddate < 14; selecteddate++)
        {
            foreach (DataRow dr in dtBrachtiming.Rows)
            {
                if (dr["WorkingHoursFrom"].ToString() != dr["WorkingHoursTo"].ToString())
                {
                    //select the date using the week
                    string strDay = dr["WorkingDay"].ToString();
                    DateTime currentdate = System.DateTime.Now;
                    currentdate = currentdate.AddDays(selecteddate);
                    //Response.Write("<br>" + currentdate.Date.DayOfWeek.ToString().ToLower() + " " + strDay.ToString().ToLower());

                    //check the blockdate
                    Boolean Isblocked = false;
                    foreach (DataRow item in dtAppBlockDate.Rows)
                    {
                        //if (Convert.ToDateTime(item["appdate"].ToString()) == currentdate)
                        if (Convert.ToDateTime(item["appdate"].ToString()).ToShortDateString() == currentdate.ToShortDateString())
                        {
                            if (item["op"].ToString().ToLower() == "Restrict".ToLower())
                            {
                                Isblocked = true;
                            }
                        }
                    }

                    if (currentdate.Date.DayOfWeek.ToString().ToLower() == strDay.ToLower())
                    {
                        if (!Isblocked)
                        {
                            if (Session["branchname"].ToString().ToLower() == "swansea")
                            {
                                if (currentdate.CompareTo(DateTime.Parse("02/12/2013")) <= 0)
                                {
                                    DataRow drAp = dtApDate.NewRow();
                                    drAp["ApDate"] = currentdate.ToShortDateString();
                                    dtApDate.Rows.Add(drAp);
                                }
                            }
                            else
                            {
                                DataRow drAp = dtApDate.NewRow();
                                drAp["ApDate"] = currentdate.ToShortDateString();
                                dtApDate.Rows.Add(drAp);
                            }
                        }
                    }
                }
            }
        }
        DataView dvAp = dtApDate.DefaultView;
        dvAp.Sort = "Apdate ASC";

        foreach (DataRowView item in dvAp)
        {
            ddlChoosedate.Items.Add(new ListItem(((DateTime)item[0]).ToShortDateString(), ((DateTime)item[0]).Date.ToShortDateString()));
        }

        ddlChoosedate.Items.Insert(0, new ListItem("Please select date", "-1"));
        //timing selection
        ddlAvailabletimeslot.Items.Insert(0, new ListItem("Please select time","-1"));

        log.Debug("Done Choosebranch");
    }

    protected void ddlChoosedate_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAvailabletimeslot.Items.Clear();

        if (ddlChoosedate.SelectedIndex == 0)
        {
            ddlAvailabletimeslot.Items.Add(new ListItem("Please select time"));
            return;
        }

        if (ddlChoosedate.SelectedIndex != -1)
        {
            DataTable dt = (DataTable)ViewState["LocationData"];
            DataTable dtBlockDate = (DataTable)ViewState["BlockDate"];
            foreach (DataRow dr in dt.Rows)
            {
                string strDay = dr["WorkingDay"].ToString();
                //Response.Write("<br>" + ddlChoosedate.SelectedValue.ToString().ToLower() + " " + strDay.ToLower());
                //if (ddlChoosedate.SelectedValue.ToString().ToLower() == strDay.ToLower())              

                if (Convert.ToDateTime(ddlChoosedate.SelectedValue.ToString()).DayOfWeek.ToString().ToLower() == strDay.ToLower())
                {

                    string[] starttime = Convert.ToString(dr["WorkingHoursFrom"]).Split(' ');
                    string[] endtime = Convert.ToString(dr["WorkingHoursTo"]).Split(' ');

                    string[] startsplit = starttime[0].Split(':');
                    string[] endsplit = endtime[0].Split(':');

                    DateTime start;
                    DateTime finish;

                    if (startsplit.Length > 1)
                        start = new DateTime(1900, 1, 1, int.Parse(startsplit[0]), int.Parse(startsplit[1]), 0);
                    else
                        start = new DateTime(1900, 1, 1, int.Parse(startsplit[0]), 0, 0);

                    if (endsplit.Length > 1)
                        finish = new DateTime(1900, 1, 1, int.Parse(endsplit[0]) + 12, int.Parse(endsplit[1]), 0);
                    else
                        finish = new DateTime(1900, 1, 1, int.Parse(endsplit[0]) + 12, 0, 0);

                    DateTime current = start;
                    while (current < finish)
                    {
                        ddlAvailabletimeslot.Items.Add(new ListItem(current.ToString("h:mm tt"), current.ToString("h:mm tt")));

                        if (Session["branchname"] != null)
                        {
                            if (Session["branchname"].ToString().ToLower() == "Bristol".ToLower())
                            {
                                current = current.AddMinutes(45);
                            }
                            else
                            {
                                current = current.AddMinutes(30);
                            }
                        }
                    }
                }
            }

            foreach (DataRow drBlock in dtBlockDate.Rows)
            {
                if (DateTime.Now.Date.ToShortDateString() == Convert.ToDateTime(ddlChoosedate.SelectedItem.Text).ToShortDateString())
                {
                    foreach (ListItem item in ddlAvailabletimeslot.Items)
                    {
                        string[] itemTime = item.Text.Split(' ');
                        string[] itemTimeSplit = itemTime[0].Split(':');

                        DateTime dtItemTime;

                        if (itemTime[1].Trim().ToLower() == "am")
                            dtItemTime = new DateTime(1900, 1, 1, int.Parse(itemTimeSplit[0]), int.Parse(itemTimeSplit[1]), 0);
                        else
                        {
                            if (itemTimeSplit[0].Trim() == "12")
                                dtItemTime = new DateTime(1900, 1, 1, 0, int.Parse(itemTimeSplit[1]), 0);
                            else
                                dtItemTime = new DateTime(1900, 1, 1, int.Parse(itemTimeSplit[0]) + 12, int.Parse(itemTimeSplit[1]), 0);
                        }

                        if (dtItemTime.TimeOfDay < DateTime.Now.TimeOfDay)
                        {
                            item.Enabled = false;
                        }
                    }
                }

                if (Convert.ToDateTime(drBlock["appdate"].ToString()).ToShortDateString() == Convert.ToDateTime(ddlChoosedate.SelectedItem.Text).ToShortDateString())
                {
                    foreach (ListItem item in ddlAvailabletimeslot.Items)
                    {
                        //if (item.Text.ToLower() == drBlock["appfrom"].ToString().ToLower())
                        //{
                        //    item.Enabled = false;
                        //}
                        switch (drBlock["op"].ToString().ToLower())
                        {
                            case "booked":
                                if (item.Text.ToLower() == drBlock["appfrom"].ToString().ToLower())
                                {
                                    item.Enabled = false;
                                }
                                break;
                            case "partial-booked":
                                string sFromTime = drBlock["appfrom"].ToString().ToLower();
                                string sToTime = drBlock["appto"].ToString().ToLower();

                                string[] fromTime = sFromTime.Split(' ');
                                string[] fromTimeSplit = fromTime[0].Split(':');

                                string[] toTime = sToTime.Split(' ');
                                string[] toTimeSplit = toTime[0].Split(':');

                                int ifromStart = Convert.ToInt32(fromTimeSplit[0]) + (fromTime[1] == "pm" ? 12 : 0);
                                int itoStart = Convert.ToInt32(toTimeSplit[0]) + (toTime[1] == "pm" ? 12 : 0);

                                string strBookedTime = string.Empty;
                                string dAMPM = fromTime[1] == "pm" ? "pm" : "am";

                                for (int i = ifromStart; i < itoStart; i++)
                                {
                                    if (i == 12 && dAMPM == "am")
                                    {
                                        dAMPM = "pm";
                                    }

                                    strBookedTime += "," + (i > 12 ? i - 12 : i).ToString() + ":00 " + dAMPM;

                                    if (Session["branchname"].ToString().ToLower() == "Bristol".ToLower())
                                    {
                                        strBookedTime += "," + (i > 12 ? i - 12 : i).ToString() + ":15 " + dAMPM;
                                        strBookedTime += "," + (i > 12 ? i - 12 : i).ToString() + ":30 " + dAMPM;
                                        strBookedTime += "," + (i > 12 ? i - 12 : i).ToString() + ":45 " + dAMPM;
                                    }
                                    else
                                    {
                                        strBookedTime += "," + (i > 12 ? i - 12 : i).ToString() + ":30 " + dAMPM;
                                    }
                                }

                                strBookedTime += "," + sToTime;

                                foreach (var _booked in strBookedTime.Split(','))
                                {
                                    if (!string.IsNullOrEmpty(_booked))
                                    {
                                        if (item.Text.ToLower() == _booked.ToLower())
                                        {
                                            item.Enabled = false;
                                        }
                                    }
                                }


                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            int countEnable = 0;

            foreach (ListItem item in ddlAvailabletimeslot.Items)
            {
                if (item.Enabled == false)
                {
                    countEnable++;
                }
            }

            if (countEnable == ddlAvailabletimeslot.Items.Count)
            {
                ddlAvailabletimeslot.Visible = false;
                spanBooked.Visible = true;
                hlCarButton.Visible = false;
            }
        }
    }
}