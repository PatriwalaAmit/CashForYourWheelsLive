using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class zonecomponent : BasePage
{
    #region page events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["AccountDetail"] != null)
            {
                Fillddl();
                FillGrid();
            }
            else
            {
                Response.Redirect("~/AdminLogin.aspx");
            }
        }
    }

    private void Fillddl()
    {
 	    DataTable dt= BAL_Zones.SelectZones("selectall",0);
        ddlZoneName.DataSource = dt;
        ddlZoneName.DataValueField = "ZoneID";
        ddlZoneName.DataTextField = "ZoneName";
        ddlZoneName.DataBind();
        ddlZoneName.Items.Insert(0,new ListItem("-- Select --","-1"));        
    }

    private void SetDeafultPageSize()
    {
        gvAdminList.PageSize = this.DefaultAdminPageSize;
    }
    #endregion

    #region GetRecords

    private void GetRecords(int Id)
    {
        DataTable table = BAL_Zonecomponents.SelectZonecomponent("selectbyid", Id);
        {
            txtZone.Text = Convert.ToString(table.Rows[0]["ZoneName"]);
        }
    }

    private void FillGrid()
    {
        DataTable table = BAL_Zonecomponents.SelectZonecomponent("selectall", 0);
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
        FillGrid();
    }

    protected void gvAdminList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewDetails")
        {
            GetRecords(Convert.ToInt32(e.CommandArgument));
            lblMode.Text = Convert.ToString(e.CommandArgument);
        }
    }
    #endregion



    #region Button Click events
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (BAL_Zonecomponents.DeleteZonecomponent("delete", ReturnIds()) == true)
        {
            ShowMessage("Record Deleted Successfully.");
            FillGrid();
        }
        else
        {
            ShowMessage("Error in record deletion.");
        }
    }

    protected void btnActive_Click(object sender, EventArgs e)
    {
        if (BAL_Zonecomponents.DeleteZonecomponent("active", ReturnIds()) == true)
        {
            ShowMessage("Record Activated succefully");
            FillGrid();
        }
        else
        {
            ShowMessage("Error in record activation.");
        }
    }

    protected void btnInActive_Click(object sender, EventArgs e)
    {
        if (BAL_Zonecomponents.DeleteZonecomponent("inactive", ReturnIds()) == true)
        {
            ShowMessage("Record Deactivated succefully");
            FillGrid();
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
                txtZone.Text = Server.HtmlEncode(txtZone.Text);

                if (string.IsNullOrEmpty(lblMode.Text))
                {
                    lblMode.Text = "0";
                    if (BAL_Zonecomponents.InsertUpdateZonecomponent("insert",lblMode.Text,ddlZoneName.SelectedValue, txtZone.Text, "0") == true)
                    {
                        ShowMessage("Record Insert Susseccfully.");
                        FillGrid();
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
                    if (BAL_Zonecomponents.InsertUpdateZonecomponent("update", lblMode.Text,ddlZoneName.SelectedValue, txtZone.Text, "0") == true)
                    {
                        ShowMessage("Record Updated Susseccfully.");
                        FillGrid();
                        ClearInput();
                    }
                    else
                    {
                        ShowMessage("Error in record insertion.");
                    }
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
        if (string.IsNullOrEmpty(txtZone.Text))
        {
            ShowMessage("Enter Zone Name");
            return true;
        }
        else if (ddlZoneName.SelectedValue == "-1")
        {
            ShowMessage("Select Zone Name");
            return true;
        }
        else
        { return false; }
    }
    private void ClearInput()
    {
        txtZone.Text = string.Empty;
        lblMode.Text = string.Empty;
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
