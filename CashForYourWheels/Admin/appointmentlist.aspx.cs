using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_appointmentlist : BasePage
{
    #region page events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = BAL_location.GetCMSByCMSId(0);
            ddlBranchName.DataSource = dt;
            ddlBranchName.DataValueField = dt.Columns["LocationId"].ToString();
            ddlBranchName.DataTextField = dt.Columns["LocationName"].ToString();
            ddlBranchName.DataBind();

            if (Session["AccountDetail"] == null)
            {
                Response.Redirect("~/AdminLogin.aspx");
            }
            else
            {
                FillGrid();
            }
        }
    }

    #endregion

    #region GetRecords

    private void FillGrid()
    {
        gvAdminList.DataSource = null;
        DataTable table = BAL_BookAppointment.GetAppointment("0", "0", "0", int.Parse(ddlBranchName.SelectedItem.Value));
        gvAdminList.DataSource = table;
        gvAdminList.DataBind();
    }


    protected void ddlBranchName_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }

    protected void gvAdminList_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdnAppointmentId.Value = ((HiddenField)gvAdminList.Rows[gvAdminList.SelectedIndex].FindControl("hdnId")).Value;

        this.mdlPopup.Show();
        string strBranchinformation = ddlBranchName.SelectedItem.Text;
        // date selection
        ddlChoosedate.Items.Add(new ListItem("Please select date", "-1"));
        //

        DataTable dtBrachtiming = BAL_branchtime.GetTiming(ddlBranchName.SelectedItem.Value);
        ViewState["LocationData"] = dtBrachtiming;

        ddlAvailabletimeslot.Items.Clear();
        ddlChoosedate.Items.Clear();
        //ddlChoosedate.Items.Add(new ListItem("Please select time", "-1"));

        DataTable dtApDate = new DataTable();
        dtApDate.Columns.Add("ApDate", Type.GetType("System.DateTime"));


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
                    if (currentdate.Date.DayOfWeek.ToString().ToLower() == strDay.ToLower())
                    {
                        DataRow drAp = dtApDate.NewRow();
                        drAp["ApDate"] = currentdate.ToShortDateString();
                        dtApDate.Rows.Add(drAp);
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

    protected void ddlChoosedate_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAvailabletimeslot.Items.Clear();

        if (ddlChoosedate.SelectedIndex != -1)
        {
            DataTable dt = (DataTable)ViewState["LocationData"];
            foreach (DataRow dr in dt.Rows)
            {
                string strDay = dr["WorkingDay"].ToString();
                //Response.Write("<br>" + ddlChoosedate.SelectedValue.ToString().ToLower() + " " + strDay.ToLower());
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
        }

        this.mdlPopup.Show();
    }

    #endregion

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string strAppointmentId = hdnAppointmentId.Value;
        string strCustomerName = "";
        string phonenumber = "";
        string emailaddress = "0";
        string zipcode = "";
        string carplate = "";

        BAL_BookAppointment.UpdateAppointment(strAppointmentId, strCustomerName, phonenumber, emailaddress, zipcode, ddlChoosedate.SelectedItem.Text.ToString(), ddlAvailabletimeslot.SelectedItem.Text.ToString(), "0", carplate,"0", 0);

        lblMessage.Text = "Appointment Updated";

        FillGrid();

        this.mdlPopup.Show();

    }

    public string formatdate(object strDate)
    {
        return Convert.ToDateTime(strDate).ToLongDateString();
    }

    protected void gvAdminList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    LinkButton l = (LinkButton)e.Row.FindControl("lnkDelete");
        //    l.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete this record ?');");
        //}
    }

    protected void gvAdminList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int categoryID = (int)gvAdminList.DataKeys[e.RowIndex].Value;
        //DeleteRecordByID(categoryID);
    }

    protected void gvAdminList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            // get the categoryID of the clicked row
            int categoryID = Convert.ToInt32(e.CommandArgument);
            // Delete the record           
            //BAL_BookAppointment.UpdateAppointment(categoryID.ToString(), "", "", "", "", "", "", "1", "delete", "");  
            BAL_BookAppointment.UpdateAppointment(categoryID.ToString(), "1", "1", "1", "1", "1/1/1900", "1 PM", "1", "delete", "", 0);
            //FillGrid();
            Response.Redirect("appointmentlist.aspx");
        }
    }
}