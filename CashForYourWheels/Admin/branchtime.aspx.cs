using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_branchtime : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = BAL_location.GetCMSByCMSId(-10);
            ddlBranchName.DataSource = dt;
            ddlBranchName.DataValueField = dt.Columns["LocationId"].ToString();
            ddlBranchName.DataTextField = dt.Columns["LocationName"].ToString();            
            ddlBranchName.DataBind();

            //load the previous value in dropdown
            dt = BAL_branchtime.GetTiming(ddlBranchName.SelectedItem.Value);
            foreach (DataRow item in dt.Rows)
            {
                string[] strFrom = item["WorkingHoursFrom"].ToString().Split(' ');
                string[] strTo = item["WorkingHoursTo"].ToString().Split(' ');

                switch (item["WorkingDay"].ToString())
                {
                    case "Monday":
                        ddlMondayFrom.SelectedValue = strFrom[0];
                        ddlMondayFromAMPM.SelectedValue = strFrom[1];
                        ddlMondayTo.SelectedValue = strTo[0];
                        ddlMondayToAMPM.SelectedValue = strTo[1];
                        
                        break;
                    case "Tuesday":
                        ddlTuesdayFrom.SelectedValue = strFrom[0];
                        ddlTuesdayFromAMPM.SelectedValue = strFrom[1];
                        ddlTuesdayTo.SelectedValue = strTo[0];
                        ddlTuesdayToAMPM.SelectedValue = strTo[1];
                        chkBranchClosedTue.Checked = Convert.ToBoolean(item["IsClosed"]);
                        break;
                    case "Wednesday":
                        ddlWednesdayFrom.SelectedValue = strFrom[0];
                        ddlWednesdayFromAMPM.SelectedValue = strFrom[1];
                        ddlWednesdayTo.SelectedValue = strTo[0];
                        ddlWednesdayToAMPM.SelectedValue = strTo[1];
                        chkBranchClosedWed.Checked = Convert.ToBoolean(item["IsClosed"]);
                        break;
                    case "Thursday":
                        ddlThursdayFrom.SelectedValue = strFrom[0];
                        ddlThursdayFromAMPM.SelectedValue = strFrom[1];
                        ddlThursdayTo.SelectedValue = strTo[0];
                        ddlThursdayToAMPM.SelectedValue = strTo[1];
                        chkBranchClosedThu.Checked = Convert.ToBoolean(item["IsClosed"]);
                        break;
                    case "Friday":
                        ddlFridayFrom.SelectedValue = strFrom[0];
                        ddlFridayFromAMPM.SelectedValue = strFrom[1];
                        ddlFridayTo.SelectedValue = strTo[0];
                        ddlFridayToAMPM.SelectedValue = strTo[1];
                        chkBranchClosedFri.Checked = Convert.ToBoolean(item["IsClosed"]);
                        break;
                    case "Saturday":
                        ddlSaturdayFrom.SelectedValue = strFrom[0];
                        ddlSaturdayFromAMPM.SelectedValue = strFrom[1];
                        ddlSaturdayTo.SelectedValue = strTo[0];
                        ddlSaturdayToAMPM.SelectedValue = strTo[1];
                        chkBranchClosedSat.Checked = Convert.ToBoolean(item["IsClosed"]);
                        break;
                    case "Sunday":
                        ddlSundayFrom.SelectedValue = strFrom[0];
                        ddlSundayFromAMPM.SelectedValue = strFrom[1];
                        ddlSundayTo.SelectedValue = strTo[0];
                        ddlSundayToAMPM.SelectedValue = strTo[1];
                        chkBranchClosedSun.Checked = Convert.ToBoolean(item["IsClosed"]);
                        break;

                }
            }
        }
    }

    

    protected void imgbtn_Insert_Click(object sender, EventArgs e)
    {
        //BAL_branchtime.UpdateTiming();
        //monday
        BAL_branchtime.UpdateTiming(ddlBranchName.SelectedValue.ToString(),ddlMondayFrom.SelectedItem.Text + " "+ ddlMondayFromAMPM.SelectedItem.Text,ddlMondayTo.SelectedItem.Text + " "+ ddlMondayToAMPM.SelectedItem.Text,"Monday",chkBranchClosedMon.Checked);
        //tuesday
        BAL_branchtime.UpdateTiming(ddlBranchName.SelectedValue.ToString(), ddlTuesdayFrom.SelectedItem.Text + " " + ddlTuesdayFromAMPM.SelectedItem.Text, ddlTuesdayTo.SelectedItem.Text + " " + ddlTuesdayToAMPM.SelectedItem.Text, "Tuesday", chkBranchClosedTue.Checked);
        //wednesday
        BAL_branchtime.UpdateTiming(ddlBranchName.SelectedValue.ToString(), ddlWednesdayFrom.SelectedItem.Text + " " + ddlWednesdayFromAMPM.SelectedItem.Text, ddlWednesdayTo.SelectedItem.Text + " " + ddlWednesdayToAMPM.SelectedItem.Text, "Wednesday", chkBranchClosedWed.Checked);
        //thursday
        BAL_branchtime.UpdateTiming(ddlBranchName.SelectedValue.ToString(), ddlThursdayFrom.SelectedItem.Text + " " + ddlThursdayFromAMPM.SelectedItem.Text, ddlThursdayTo.SelectedItem.Text + " " + ddlThursdayToAMPM.SelectedItem.Text, "Thursday", chkBranchClosedThu.Checked);
        //friday
        BAL_branchtime.UpdateTiming(ddlBranchName.SelectedValue.ToString(), ddlFridayFrom.SelectedItem.Text + " " + ddlFridayFromAMPM.SelectedItem.Text, ddlFridayTo.SelectedItem.Text + " " + ddlFridayToAMPM.SelectedItem.Text, "Friday", chkBranchClosedFri.Checked);
        //sat
        BAL_branchtime.UpdateTiming(ddlBranchName.SelectedValue.ToString(), ddlSaturdayFrom.SelectedItem.Text + " " + ddlSaturdayFromAMPM.SelectedItem.Text, ddlSaturdayTo.SelectedItem.Text + " " + ddlSaturdayToAMPM.SelectedItem.Text, "Saturday", chkBranchClosedSat.Checked);
        //sun
        BAL_branchtime.UpdateTiming(ddlBranchName.SelectedValue.ToString(), ddlSundayFrom.SelectedItem.Text + " " + ddlSundayFromAMPM.SelectedItem.Text, ddlSundayTo.SelectedItem.Text + " " + ddlSundayToAMPM.SelectedItem.Text, "Sunday", chkBranchClosedSun.Checked);

        lblMessage.Text = "Record Updated successfully";

    }

    protected void ddlBranchName_SelectedIndexChange(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = BAL_branchtime.GetTiming(ddlBranchName.SelectedItem.Value);
        foreach (DataRow item in dt.Rows)
        {
            string[] strFrom = item["WorkingHoursFrom"].ToString().Split(' ');
            string[] strTo = item["WorkingHoursTo"].ToString().Split(' ');
            

            switch (item["WorkingDay"].ToString())
            {
                case "Monday":
                    ddlMondayFrom.SelectedValue = strFrom[0];
                    ddlMondayFromAMPM.SelectedValue = strFrom[1];
                    ddlMondayTo.SelectedValue = strTo[0];
                    ddlMondayToAMPM.SelectedValue = strTo[1];
                    chkBranchClosedMon.Checked = Convert.ToBoolean(item["IsClosed"]);
                    break;
                case "Tuesday":
                    ddlTuesdayFrom.SelectedValue = strFrom[0];
                    ddlTuesdayFromAMPM.SelectedValue = strFrom[1];
                    ddlTuesdayTo.SelectedValue = strTo[0];
                    ddlTuesdayToAMPM.SelectedValue = strTo[1];
                    chkBranchClosedTue.Checked = Convert.ToBoolean(item["IsClosed"]);
                    break;
                case "Wednesday":
                    ddlWednesdayFrom.SelectedValue = strFrom[0];
                    ddlWednesdayFromAMPM.SelectedValue = strFrom[1];
                    ddlWednesdayTo.SelectedValue = strTo[0];
                    ddlWednesdayToAMPM.SelectedValue = strTo[1];
                    chkBranchClosedWed.Checked = Convert.ToBoolean(item["IsClosed"]);
                    break;
                case "Thursday":
                    ddlThursdayFrom.SelectedValue = strFrom[0];
                    ddlThursdayFromAMPM.SelectedValue = strFrom[1];
                    ddlThursdayTo.SelectedValue = strTo[0];
                    ddlThursdayToAMPM.SelectedValue = strTo[1];
                    chkBranchClosedThu.Checked = Convert.ToBoolean(item["IsClosed"]);
                    break;
                case "Friday":
                    ddlFridayFrom.SelectedValue = strFrom[0];
                    ddlFridayFromAMPM.SelectedValue = strFrom[1];
                    ddlFridayTo.SelectedValue = strTo[0];
                    ddlFridayToAMPM.SelectedValue = strTo[1];
                    chkBranchClosedFri.Checked = Convert.ToBoolean(item["IsClosed"]);
                    break;
                case "Saturday":
                    ddlSaturdayFrom.SelectedValue = strFrom[0];
                    ddlSaturdayFromAMPM.SelectedValue = strFrom[1];
                    ddlSaturdayTo.SelectedValue = strTo[0];
                    ddlSaturdayToAMPM.SelectedValue = strTo[1];
                    chkBranchClosedSat.Checked = Convert.ToBoolean(item["IsClosed"]);
                    break;
                case "Sunday":
                    ddlSundayFrom.SelectedValue = strFrom[0];
                    ddlSundayFromAMPM.SelectedValue = strFrom[1];
                    ddlSundayTo.SelectedValue = strTo[0];
                    ddlSundayToAMPM.SelectedValue = strTo[1];
                    chkBranchClosedSun.Checked = Convert.ToBoolean(item["IsClosed"]);
                    break;

            }
        }
    }
}