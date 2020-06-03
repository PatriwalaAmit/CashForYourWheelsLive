using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using log4net;
using CashForYourWheels.CarwebService;

public partial class Admin_CheckValuation : System.Web.UI.Page
{
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //get the brach information
            DataTable dt = BAL_location.GetCMSByCMSId(0);
            ddlBranchName.DataSource = dt;
            ddlBranchName.DataValueField = dt.Columns["LocationId"].ToString();
            ddlBranchName.DataTextField = dt.Columns["LocationName"].ToString();
            ddlBranchName.DataBind();

            Session["branchname"] = ddlBranchName.SelectedItem.Value;

            DataTable dtBrachtiming = BAL_branchtime.GetTiming(ddlBranchName.SelectedItem.Value);
            ViewState["LocationData"] = dtBrachtiming;

            ddlAvailabletimeslot.Items.Clear();
            ddlChoosedate.Items.Clear();

            // date selection
            //ddlChoosedate.Items.Add(new ListItem("Please select date", "-1"));
            DataTable dtApDate = new DataTable();
            dtApDate.Columns.Add("ApDate", Type.GetType("System.DateTime"));

            DataTable dtAppBlockDate = new DataTable();
            dtAppBlockDate = BALBlockedAppointments.SelectBlockAppointment("appstatuslocationwise", 0, int.Parse(ddlBranchName.SelectedItem.Value));

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
                                DataRow drAp = dtApDate.NewRow();
                                drAp["ApDate"] = currentdate.ToShortDateString();
                                dtApDate.Rows.Add(drAp);
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
    }

    protected void ddlBranchName_SelectedIndexChange(object sender, EventArgs e)
    {
        Session["branchname"] = ddlBranchName.SelectedItem.Value;
        DataTable dtBrachtiming = BAL_branchtime.GetTiming(ddlBranchName.SelectedItem.Value);
        ViewState["LocationData"] = dtBrachtiming;

        ddlAvailabletimeslot.Items.Clear();
        ddlChoosedate.Items.Clear();

        // date selection
        //ddlChoosedate.Items.Add(new ListItem("Please select date", "-1"));
        DataTable dtApDate = new DataTable();
        dtApDate.Columns.Add("ApDate", Type.GetType("System.DateTime"));

        DataTable dtAppBlockDate = new DataTable();

        dtAppBlockDate = BALBlockedAppointments.SelectBlockAppointment("appstatuslocationwise", 0, int.Parse(ddlBranchName.SelectedItem.Value));

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
                            DataRow drAp = dtApDate.NewRow();
                            drAp["ApDate"] = currentdate.ToShortDateString();

                            if (Session["branchname"].ToString() == "3" && (drAp["ApDate"].ToString() == "22/07/2013 00:00:00" || drAp["ApDate"].ToString() == "21/07/2013 00:00:00" || drAp["ApDate"].ToString() == "20/07/2013 00:00:00" || drAp["ApDate"].ToString() == "19/07/2013 00:00:00"))
                                continue;

                            dtApDate.Rows.Add(drAp);
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;

        /*get the CAPID*/
        /* get the data using CARWEB service */

        CarweBVRRWebService obj = new CarweBVRRWebService();
        string CarRegNumber = txtRegistration.Text;
        if (!string.IsNullOrEmpty(CarRegNumber))
            CarRegNumber = CarRegNumber.Replace(" ", "").Trim();
        /*Load data from CarWeb*/
        string strURL = "https://www1.carwebuk.com/CarweBVRRB2Bproxy/carwebvrrwebservice.asmx?op=strB2BGetVehicleByVRM";
        string strUsername = "Cashforyourwheels";
        string strPassword = "44448666";
        string strClientRef = "test";
        string strClientDescription = "test";
        string str1Key = "cf45ht67";
        string strVRM = CarRegNumber;
        string strVersion = "0.31.1";
        System.Xml.XmlNode xmlCarWeb = obj.strB2BGetVehicleByVRM(strUsername, strPassword, strClientRef, strClientDescription, str1Key, strVRM, strVersion);
        XmlTextReader xtr = new XmlTextReader(xmlCarWeb.OuterXml, XmlNodeType.Element, null);
        DataSet dataset = new DataSet();
        dataset.ReadXml(xtr);
        if (dataset != null)
        {
            string strCapID = string.Empty;
            if (dataset.Tables["CapCodes"] != null)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dataset.Tables["CapCodes"].Rows[0]["Capcodes_ID"])))
                    strCapID = Convert.ToString(dataset.Tables["CapCodes"].Rows[0]["Capcodes_ID"]);
            }
            if (dataset.Tables["CapCode1"] != null)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dataset.Tables["CapCode1"].Rows[0]["Capcode_part1"])))
                    strCapID = Convert.ToString(dataset.Tables["CapCode1"].Rows[0]["Capcode_part1"]);
            }
            if (dataset.Tables["CapCode2"] != null)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dataset.Tables["CapCode2"].Rows[0]["Capcode_part1"])))
                    strCapID = Convert.ToString(dataset.Tables["CapCode2"].Rows[0]["Capcode_part1"]);
            }
            if (dataset.Tables["CapCode3"] != null)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dataset.Tables["CapCode3"].Rows[0]["Capcode_part1"])))
                    strCapID = Convert.ToString(dataset.Tables["CapCode3"].Rows[0]["Capcode_part1"]);
            }
            if (dataset.Tables["CapCode4"] != null)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dataset.Tables["CapCode4"].Rows[0]["Capcode_part1"])))
                    strCapID = Convert.ToString(dataset.Tables["CapCode4"].Rows[0]["Capcode_part1"]);
            }
            if (dataset.Tables["CapCode5"] != null)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dataset.Tables["CapCode5"].Rows[0]["Capcode_part1"])))
                    strCapID = Convert.ToString(dataset.Tables["CapCode5"].Rows[0]["Capcode_part1"]);
            }
            if (dataset.Tables["CapCode6"] != null)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dataset.Tables["CapCode6"].Rows[0]["Capcode_part1"])))
                    strCapID = Convert.ToString(dataset.Tables["CapCode6"].Rows[0]["Capcode_part1"]);
            }
            if (dataset.Tables["CapCode7"] != null)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dataset.Tables["CapCode7"].Rows[0]["Capcode_part1"])))
                    strCapID = Convert.ToString(dataset.Tables["CapCode7"].Rows[0]["Capcode_part1"]);
            }

            if (!string.IsNullOrEmpty(strCapID))
            {
                if (dataset.Tables["vehicle"] != null)
                {
                    string lblRegistration = Convert.ToString(dataset.Tables["vehicle"].Rows[0]["VRM_Curr"]);
                    string lblManufacturer = Convert.ToString(dataset.Tables["vehicle"].Rows[0]["DVLA_Make"]);
                    string lblModel = Convert.ToString(dataset.Tables["vehicle"].Rows[0]["DVLA_Model"]);
                    string lblModelYear = Convert.ToString(dataset.Tables["vehicle"].Rows[0]["DVLAYearOfManufacture"]);
                    string lblColour = Convert.ToString(dataset.Tables["vehicle"].Rows[0]["ColourCurrent"]);
                    string lblEngineSize = Convert.ToString(dataset.Tables["vehicle"].Rows[0]["EngineCapacity"]) + " cc";
                    string lblTransmission = Convert.ToString(dataset.Tables["vehicle"].Rows[0]["Transmission"]);
                    string lblRegistered = Convert.ToString(dataset.Tables["vehicle"].Rows[0]["DateFirstRegistered"]);

                    //get the car valuation
                    string strYear = Convert.ToDateTime(lblRegistered).Year.ToString();
                    string strMonth = Convert.ToDateTime(lblRegistered).Month.ToString();
                    string strCurrentMileage = Convert.ToString(Convert.ToInt32(txtMileage.Text) * 1000);

                    //lblError.Text = strCapID + " " + strYear + " " + strMonth + " " + strCurrentMileage;
                    DataTable dtResult = BAL_Valuation.GetValuationAdmin(strCapID, Convert.ToInt32(strYear), Convert.ToInt32(strMonth), strCurrentMileage, rbValuationType.SelectedValue.ToString());
                    gvValuation.DataSource = dtResult;
                    gvValuation.DataBind();


                    if (dtResult.Rows.Count > 0)
                    {
                        //strYear -> its a registration year so we can get the age by current year - strYear
                        int iVehicleAge = DateTime.Now.Year - Convert.ToInt32(strYear);
                        int iMileage = Convert.ToInt32(strCurrentMileage);
                        int iCapClean = Convert.ToInt32(dtResult.Rows[0]["uvt_average"]);

                        double newValuation = BAL_Rules.GetValuationBasedonRules(iCapClean);

                        log.Debug("Admin Valuation -> Old Valuation : " + Convert.ToString(dtResult.Rows[0]["uvt_average"]) + " New Valuation: " + newValuation.ToString());
                        lblCarValuation.Text = newValuation.ToString();

                        //lblCarValuation.Text = Convert.ToString(dtResult.Rows[0]["uvt_average"]);
                    }

                    btnBookanAppointment.Enabled = true;


                }
                else if (dataset.Tables["Details"] != null)
                {
                    lblError.Text = "Can't found the CAPID, Please enter correct number plate";
                }
            }
            else
            {
                lblError.Text = "Can't found the CAPID, Please try again";
            }
        }
    }

    protected void btnBookanAppointment_click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {

            string strCustomerName = txtCustomerName.Text.Trim();
            string phonenumber = txtPhone.Text.Trim();
            string emailaddress = txtEmail.Text.Trim();
            string zipcode = txtZipcode.Text.Trim();
            string carplate = txtRegistration.Text.Trim();
            string carValuation = lblCarValuation.Text.Trim();

            BAL_BookAppointment.UpdateAppointment("0", strCustomerName, phonenumber, emailaddress, zipcode, ddlChoosedate.SelectedItem.Text.ToString(), ddlAvailabletimeslot.SelectedItem.Text.ToString(), "0", carplate, carValuation, int.Parse(ddlBranchName.SelectedItem.Value));
            try { Utilities.RemoveFollowup(txtEmail.Text.Trim().ToLower()); }
            catch (Exception ex)
            {
            }

            lblError.Text = "Appointment booking succesfully";

        }
    }

    protected void ddlChoosedate_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAvailabletimeslot.Items.Clear();

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
                        current = current.AddMinutes(30);
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
                        //string strFromValue = string.Empty;

                        //if (drBlock["OP"].ToString().ToLower() == "Booked".ToLower())
                        //{
                        //    strFromValue = strFrom[0].Trim() + " :00 " + strFrom[2].Trim();
                        //}
                        //else
                        //{
                        //    strFromValue = strFrom[0].Trim() + " :00 " + strFrom[1].Trim();
                        //}

                        //Response.Write("<br>" + item.Text.ToLower() + "----" + strFromValue.ToLower());

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
                                    strBookedTime += "," + (i > 12 ? i - 12 : i).ToString() + ":30 " + dAMPM;
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


                        /*partial*/
                    }
                }
                //Response.Write(ddlAvailabletimeslot.Items.Count.ToString());

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
                }
            }

        }
    }
}
