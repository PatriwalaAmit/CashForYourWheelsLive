using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Admin_GeneralSetting : BasePage //System.Web.UI.Page
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

    #region Page events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetPageSize();

            //set the gridview initial pageindex into view state
            gvIndex = gvPagingGrid.PageIndex;
            FillGrid();
            FillPageSize();
            lblMode.Text = "0";
        }
    }

    private void SetPageSize()
    {
        gvPagingGrid.PageSize = this.DefaultAdminPageSize;
    }
    #endregion

    #region Get Records
    private void FillGrid()
    {
        int TotalCount;
        gvPagingGrid.PageIndex = gvIndex;
        DataTable table = BAL_Paging.GetPagingInfo(gvPagingGrid.PageIndex, gvPagingGrid.PageSize, gvPagingGrid.OrderBy, out TotalCount);
        gvPagingGrid.VirtualItemCount = TotalCount;
        gvPagingGrid.DataSource = table;
        gvPagingGrid.DataBind();
        HideDispControl();
    }

    private void HideDispControl()
    {
        if (gvPagingGrid.Rows.Count > 0)
        {
            btnDelete.Visible = true;
            btnActive.Visible = true;
            btnInActive.Visible = true;
            btnCheckAll.Visible = true;
            btnClearAll.Visible = true;
            lblSep.Visible = true;
        }
        else
        {
            btnDelete.Visible = false;
            btnActive.Visible = false;
            btnInActive.Visible = false;
            btnCheckAll.Visible = false;
            btnClearAll.Visible = false;
            lblSep.Visible = false;
        }

    }

    private void FillPageSize()
    {
        DataTable table = BAL_Paging.GetPageInfo();
        if (table != null && table.Rows.Count > 0)
        {
            txtAdminPageSize.Text = Convert.ToString(table.Rows[0]["AdminPageSize"]);
            txtFrontPageSize.Text = Convert.ToString(table.Rows[0]["FrontPageSize"]);
        }
    }
    #endregion

    #region Grid View Events
    protected void gvPagingGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPagingGrid.PageIndex = e.NewPageIndex;
        gvIndex = e.NewPageIndex;
        FillGrid();
    }

    protected void gvPagingGrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        GridViewClass.GVSort(sender, e);
        FillGrid();
    }

    protected void gvPagingGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void gvPagingGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewDetails")
        {
            string[] str = Convert.ToString(e.CommandArgument).Split(',');
            lblMode.Text = str[0];
            txtPageSize.Text = str[1];
        }
    }

    protected void gvPagingGrid_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
        {
            CheckBox chkBxSelect = (CheckBox)e.Row.Cells[1].FindControl("cbRows");
            CheckBox chkBxHeader = (CheckBox)this.gvPagingGrid.HeaderRow.FindControl("chkBxHeader");

            chkBxSelect.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chkBxHeader.ClientID);
        }
    }

    protected string setImage4Status(object strArg)
    {
        bool status = Convert.ToBoolean(strArg);
        if (status == true)
        {
            return "~/Images/ico-active.gif";
        }
        else
        {
            return "~/Images/ico-inactive.gif";
        }
    }
    #endregion

    #region Button Click Events for Active Deactive And Delete
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string _strId = GetPagingId();
        if (!string.IsNullOrEmpty(_strId))
        {
            if (BAL_Paging.DeletePagingInfo(_strId.Substring(1)) == true)
            {
                ShowMessage("Record deleted successfully!");
                FillGrid();
            }
            else
            {
                ShowMessage("Error in record deletion!");
            }
        }
    }

    protected void btnActive_Click(object sender, EventArgs e)
    {
        string _strId = GetPagingId();
        if (!string.IsNullOrEmpty(_strId))
        {
            if (BAL_Paging.ActivatePagingInfo(_strId.Substring(1), true) == true)
            {
                ShowMessage("Record activated successfully!");
                FillGrid();
            }
            else
            {
                ShowMessage("Error in record activation!");
            }
        }
    }

    protected void btnInActive_Click(object sender, EventArgs e)
    {
        string _strId = GetPagingId();
        if (!string.IsNullOrEmpty(_strId))
        {
            if (BAL_Paging.ActivatePagingInfo(_strId.Substring(1), false) == true)
            {
                ShowMessage("Record activated successfully!");
                FillGrid();
            }
            else
            {
                ShowMessage("Error in record activation!");
            }
        }
    }
    #endregion

    #region Button Save Click
    protected void btnSave2_Click(object sender, EventArgs e)
    {
        Page.Validate("CheckPageSize");
        if (Page.IsValid == true)
        {
            if (CheckForPageSize(Convert.ToInt32(txtPageSize.Text)) == false)
            {
                if (BAL_Paging.InsertUpdatePagingInfo(Convert.ToInt32(lblMode.Text), Convert.ToInt32(txtPageSize.Text)) == true)
                {
                    if (Convert.ToInt32(lblMode.Text) != 0)
                    {
                        ShowMessage("Record updated successfully.");
                    }
                    else
                    {
                        ShowMessage("Record inserted successfully.");
                    }
                    FillGrid();
                    txtPageSize.Text = string.Empty;
                    lblMode.Text = "0";
                }
                else
                {
                    ShowMessage("Error in record insertion.");
                }
            }
            else
            {
                ShowMessage("Page Size is already inserted!");
            }
        }
    }

    protected void btnSave1_Click(object sender, EventArgs e)
    {
        Page.Validate("CheckForPageSize");
        if (Page.IsValid == true)
        {
            if(BAL_Paging.UpdatePageInfo(Convert.ToInt32(txtAdminPageSize.Text),Convert.ToInt32(txtFrontPageSize.Text))==true)
            {
                FillGrid();
                ShowMessage("Record inserted successfully!");
            }
            else
            {
                ShowMessage("Error in record insertion!");
            }
        }
    }
    #endregion

    #region Other methods
    private void ShowMessage(string msg)
    {
        DisplayAlertMessage.CreateMessageAlert(this, msg, "alertKey");
    }

    private string GetPagingId()
    {
        string str = string.Empty;
        if (gvPagingGrid != null && gvPagingGrid.Rows.Count > 0)
        {
            for (int i = 0; i < gvPagingGrid.Rows.Count; i++)
            {
                if (((CheckBox)gvPagingGrid.Rows[i].FindControl("cbRows")).Checked == true)
                {
                    str = str + "," + Convert.ToString(((Label)gvPagingGrid.Rows[i].FindControl("lblgetpagingid")).Text);
                }
            }
        }
        return str;
    }

    private bool CheckForPageSize(int PageSize)
    {
        bool flag = false;
        if (gvPagingGrid != null && gvPagingGrid.Rows.Count > 0)
        {
            for (int i = 0; i < gvPagingGrid.Rows.Count; i++)
            {
                string[] str = ((Label)gvPagingGrid.Rows[i].FindControl("lblgetPagingIdSize")).Text.Split(',');
                if (PageSize == Convert.ToInt32(str[1]))
                {
                    flag = true;
                    break;
                }
            }
        }
        return flag;
    }
    #endregion

}
