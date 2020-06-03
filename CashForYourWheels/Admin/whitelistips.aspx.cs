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

public partial class Admin_whitelistips : BasePage
{
    #region Variable and Property declartions

    /// <summary>
    /// Get Or set GridView Pageindex
    /// </summary>
    public int gvIndex
    {
        get
        {
            if (ViewState["gvIndex"] == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["gvIndex"]);
            }
        }
        set
        {
            ViewState["gvIndex"] = value;
        }
    }
    #endregion

    #region page events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["AccountDetail"] != null)
            {
                SetDeafultPageSize();
                FillDropDown();
                //set the gridview initial pageindex into viewstate
                gvIndex = gvAdminList.PageIndex;
                FillGrid();
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

    private void FillDropDown()
    {
        DataTable table = BAL_Paging.SelectPagingInfo();
        ddlPerpage.DataSource = table;
        ddlPerpage.DataTextField = table.Columns["PageSize"].ToString();
        ddlPerpage.DataValueField = table.Columns["PageSize"].ToString();
        ddlPerpage.DataBind();
        ddlPerpage.Items.Insert(0, new ListItem("Default", "-1"));

    }

    private void GetRecords(int Id)
    {
        DataTable table = BAL_Whitelistips.GetById(Id);
        {
            txtLocationName.Text = Convert.ToString(table.Rows[0]["IPAddress"]);           
        }
    }

    private void FillGrid()
    {
        int TotalCount;
        gvAdminList.PageIndex = gvIndex;
        DataTable table = BAL_Whitelistips.GetCMSInfo(gvAdminList.PageIndex, gvAdminList.PageSize, gvAdminList.OrderBy, out TotalCount);
        gvAdminList.VirtualItemCount = TotalCount;
        gvAdminList.DataSource = table;
        gvAdminList.DataBind();
        if (gvAdminList.Rows.Count > 0)
        {
            lblsearch2.Visible = true;
            ddlPerpage.Visible = true;
            lable123.Visible = true;
        }
        else
        {
            lblsearch2.Visible = false;
            ddlPerpage.Visible = false;
            lable123.Visible = false;
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

    protected void gvAdminList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAdminList.PageIndex = e.NewPageIndex;
        gvIndex = e.NewPageIndex;
        FillGrid();
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

    #region Drop Down List
    protected void ddlPerpage_SelectedIndexChanged(object sender, EventArgs e)
    {
        int _size = 0;
        if (ddlPerpage.SelectedIndex <= 0)
        {
            _size = this.DefaultAdminPageSize;
        }
        else
        {
            _size = Convert.ToInt32(ddlPerpage.SelectedValue);
        }
        gvAdminList.PageSize = _size;
        FillGrid();
    }
    #endregion

    #region Button Click events
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (BAL_Whitelistips.DeleteRecords(ReturnIds()) == true)
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
        if (BAL_Whitelistips.ActivateRecords(ReturnIds(), 0) == true)
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
        if (BAL_Whitelistips.ActivateRecords(ReturnIds(), 2) == true)
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
                txtLocationName.Text = Server.HtmlEncode(txtLocationName.Text);

                if (!string.IsNullOrEmpty(lblMode.Text))
                {
                    if (BAL_Whitelistips.UpdateCMS(Convert.ToInt32(lblMode.Text), txtLocationName.Text,"0") == true)
                    {
                        ShowMessage("Record Updated Susseccfully.");
                        FillGrid();
                        ClearInput();
                    }
                    else
                    {
                        ShowMessage("Error in record updation.");
                    }
                }
                else
                {
                    if (BAL_Whitelistips.InsertCMS(txtLocationName.Text) == true)
                    {
                        ShowMessage("Record Inserted Susseccfully.");
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
        if (string.IsNullOrEmpty(txtLocationName.Text))
        {
            ShowMessage("Enter IPAddress");
            return true;
        }
        else
        { return false; }
    }
    private void ClearInput()
    {
        txtLocationName.Text = string.Empty;      
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
