using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_blockappointments : BasePage
{
    #region page events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["AccountDetail"] != null)
            {
                FillGrid(1);

                //get the brach information
                DataTable dt = BAL_location.GetCMSByCMSId(-10);
                ddlBranchName.DataSource = dt;
                ddlBranchName.DataValueField = dt.Columns["LocationId"].ToString();
                ddlBranchName.DataTextField = dt.Columns["LocationName"].ToString();
                ddlBranchName.DataBind();

                ddlBranchName.Items.Insert(0, new ListItem("All","0"));
                chkIsClosed.Checked = false;
            }
            else
            {
                Response.Redirect("~/AdminLogin.aspx");
            }
        }
    }

    private void SetDeafultPageSize()
    {
        gvAdminList.PageSize = this.DefaultAdminPageSize;
    }
    #endregion

    #region GetRecords

    private void GetRecords(int Id, int locationID)
    {
        DataTable table = BALBlockedAppointments.SelectBlockAppointment("selectbyid", Id, locationID);
        {
            txtblockcal.Text = Convert.ToString(table.Rows[0]["appblockdate"]);
            txtDescription.Text = Convert.ToString(table.Rows[0]["appblcokdesc"]);
           
            string[] strFrom = Convert.ToString(table.Rows[0]["appblockfrom"]).Split(' ');

            ddlFrom.SelectedValue = strFrom[0].Split(':')[0];
            ddlFromAMPM.SelectedValue = strFrom[1];
            
            string[] strTo = Convert.ToString(table.Rows[0]["appblockto"]).Split(' ');
            
            ddlTo.SelectedValue = strTo[0].Split(':')[0];
            ddlToAMPM.SelectedValue = strTo[1];
            //txtZone.Text = Convert.ToString(table.Rows[0]["ZoneName"]);
            ddlBranchName.SelectedValue = Convert.ToString(table.Rows[0]["branchId"]);

            chkIsClosed.Checked = Convert.ToBoolean(table.Rows[0]["IsClosed"]);
        }
    }

    private void FillGrid(int locationID)
    {
        DataTable table = BALBlockedAppointments.SelectBlockAppointment("selectall", 0, locationID);
        gvAdminList.DataSource = table;
        gvAdminList.DataBind();
        if (gvAdminList.Rows.Count > 0)
        {
            lblsearch2.Visible = true;
        }
        else
        {
            lblsearch2.Visible = false;
        }
    }
    #endregion

    #region --> GridView Events <--
    protected void gvAdminList_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
        {
            CheckBox chkBxSelect = (CheckBox)e.Row.Cells[1].FindControl("cbRows");
            CheckBox chkBxHeader = (CheckBox)this.gvAdminList.HeaderRow.FindControl("chkBxHeader");
            chkBxSelect.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chkBxHeader.ClientID);
        }
    }

    protected string setImage4Status(object strArg)
    {
        int status = Convert.ToInt32(strArg);
        if (status == 0)
        {
            return "~/Admin/Images/ico-active.gif";
        }
        else
        {
            return "~/Admin/Images/ico-inactive.gif";
        }
    }

    protected void gvAdminList_Sorting(object sender, GridViewSortEventArgs e)
    {
        GridViewClass.GVSort(sender, e);
        FillGrid(1);
    }

    protected void gvAdminList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewDetails")
        {
            GetRecords(Convert.ToInt32(e.CommandArgument), 1);
            lblMode.Text = Convert.ToString(e.CommandArgument);
        }
    }
    #endregion

    #region Button Click events
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (BALBlockedAppointments.InsertUpdateBlockAppointment("delete", "0", "1/1/1900", "0", "0", "", ReturnIds(), -1, 1, chkIsClosed.Checked) == true)
        {
            ShowMessage("Record Deleted Successfully.");
            FillGrid(1);
        }
        else
        {
            ShowMessage("Error in record deletion.");
        }
    }

    protected void btnActive_Click(object sender, EventArgs e)
    {
        if (BALBlockedAppointments.InsertUpdateBlockAppointment("active", "0", "1/1/1900", "0", "0", "", ReturnIds(), -1, 1,chkIsClosed.Checked) == true)
        {
            ShowMessage("Record Activated succefully");
            FillGrid(1);
        }
        else
        {
            ShowMessage("Error in record activation.");
        }
    }

    protected void btnInActive_Click(object sender, EventArgs e)
    {
        if (BALBlockedAppointments.InsertUpdateBlockAppointment("inactive", "0", "1/1/1900", "0", "0", "", ReturnIds(), -1, 1,chkIsClosed.Checked) == true)        
        {
            ShowMessage("Record Deactivated succefully");
            FillGrid(1);
        }
        else
        {
            ShowMessage("Error in record deactivation.");
        }
    }

    protected void imgbtn_Insert_Click(object sender, EventArgs e)
    {
        if (ValidateInput() == false)
        {
            Page.Validate("AddCategory");
            if (Page.IsValid == true)
            {
                string strDate = txtblockcal.Text;
                string strFromTime = ddlFrom.SelectedValue.ToString() + ":00 " + ddlFromAMPM.SelectedValue.ToString();
                string strToTime = ddlTo.SelectedValue.ToString() + ":00 " + ddlToAMPM.SelectedValue.ToString();
                string strDescription = txtDescription.Text;
                int iBranchName = Convert.ToInt32(ddlBranchName.SelectedValue);

                if (string.IsNullOrEmpty(lblMode.Text))
                {
                    lblMode.Text = "0";
                    if (BALBlockedAppointments.InsertUpdateBlockAppointment("insert", lblMode.Text, strDate, strFromTime, strToTime, strDescription, ReturnIds(), 0, iBranchName,chkIsClosed.Checked) == true)
                    {
                        ShowMessage("Record Insert Susseccfully.");
                        FillGrid(1);
                        ClearInput();
                    }
                    else
                    {
                        ShowMessage("Error in record updation.");
                    }
                    lblMode.Text = string.Empty;
                }
                else
                {
                    if (BALBlockedAppointments.InsertUpdateBlockAppointment("update", lblMode.Text, strDate, strFromTime, strToTime, strDescription, ReturnIds(), 0, iBranchName,chkIsClosed.Checked) == true)
                    {
                        ShowMessage("Record Updated Susseccfully.");
                        FillGrid(1);
                        ClearInput();
                    }
                    else
                    {
                        ShowMessage("Error in record insertion.");
                    }
                    lblMode.Text = string.Empty;
                }
            }
            else
            {
                ShowMessage("Some Required Field Missing");
            }
        }
    }
    #endregion

    #region Other Methods
    private bool ValidateInput()
    {
        if (string.IsNullOrEmpty(txtblockcal.Text))
        {
            ShowMessage("Please select the Date");
            return true;
        }
        else
        { return false; }
    }

    private void ClearInput()
    {
        txtblockcal.Text = string.Empty;        

        ddlFrom.SelectedValue = "1";

        ddlTo.SelectedValue = "1";

        txtDescription.Text =string.Empty;

        ddlBranchName.SelectedValue = "0";

        chkIsClosed.Checked = false;
    }

    private void ShowMessage(string msg)
    {
        DisplayAlertMessage.CreateMessageAlert(this, msg, "alertKey");
    }

    private string ReturnIds()
    {
        string str = string.Empty;
        if (gvAdminList != null && gvAdminList.Rows.Count > 0)
        {
            for (int i = 0; i < gvAdminList.Rows.Count; i++)
            {
                if (((CheckBox)gvAdminList.Rows[i].FindControl("cbRows")).Checked == true)
                {
                    str = str + "," + Convert.ToString(((Label)gvAdminList.Rows[i].FindControl("lblGetId")).Text);
                }
            }
        }
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }
        else
        {
            return str.Substring(1);
        }
    }
    #endregion
}