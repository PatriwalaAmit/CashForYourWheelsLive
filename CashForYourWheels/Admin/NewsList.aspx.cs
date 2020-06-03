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

public partial class Admin_NewsList : BasePage  // System.Web.UI.Page
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
            if (Session["AccountDetail"] != null)
            {
                SetDeafultPageSize();
                FillDropDown();
                //gvAdminList.VirtualItemCount = Convert.ToInt32(BAL_News.GetTotalNewsCount());

                //set the grid view initial pageindex into viewstate
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

    #region Button Click events
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string str = UpdateDetails();
        if (!string.IsNullOrEmpty(str))
        {
            if (BAL_News.DeleteNews(str))
            {
                ShowMessage("Record Inactiveted Succefully.");
                FillGrid();
            }
            else
            {
                ShowMessage("Error in record updatation.");
            }
        }
    }

    protected void btnActive_Click(object sender, EventArgs e)
    {
        string str = UpdateDetails();
        if (!string.IsNullOrEmpty(str))
        {
            if (BAL_News.ActivateNews(str, true))
            {
                ShowMessage("Record Activeted Succefully.");
                FillGrid();
            }
            else
            {
                ShowMessage("Error in record updatation.");
            }
        }
    }

    protected void btnInActive_Click(object sender, EventArgs e)
    {
        string str = UpdateDetails();
        if (!string.IsNullOrEmpty(str))
        {
            if (BAL_News.ActivateNews(str, false))
            {
                ShowMessage("Record Inactiveted Succefully.");
                FillGrid();
            }
            else
            {
                ShowMessage("Error in record updatation.");
            }
        }
    }

    protected void lnkbtnAddAdmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/AddEditNews.aspx");
    }

    protected void imgbtn_AddAdmin_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Admin/AddEditNews.aspx");
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        Hashtable h1 = new Hashtable();

        h1.Add("id", lblMainId.Text);
        Response.Redirect("~/Admin/AddEditNews.aspx?data=" + CommonShared.EncryptQueryString(h1));
    }
    #endregion

    #region Other Methods
    /// <summary>
    /// Get AdminId for update
    /// </summary>
    /// <returns>return AdminId</returns>
    private string UpdateDetails()
    {
        string _strId = string.Empty;
        for (int i = 0; i < gvAdminList.Rows.Count; i++)
        {
            if (((CheckBox)gvAdminList.Rows[i].FindControl("cbRows")).Checked == true)
            {
                _strId = _strId + "," + ((Label)gvAdminList.Rows[i].FindControl("lblGetId")).Text;
            }
        }
        return _strId.Substring(1);
    }

    /// <summary>
    /// Display Result Message
    /// </summary>
    /// <param name="msg">Message to display</param>
    private void ShowMessage(string msg)
    {
        DisplayAlertMessage.CreateMessageAlert(this, msg, "alertKey");
    }

    /// <summary>
    /// Get Admin Details
    /// </summary>
    /// <param name="p">For Getting For Admin</param>
    private void FillRecords(int Id)
    {
        DataTable table = BAL_News.GetNewsEventsListForNewsId(Id);
        dvDetails.DataSource = table;
        dvDetails.DataBind();
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

    protected void gvAdminList_Sorting(object sender, GridViewSortEventArgs e)
    {
        GridViewClass.GVSort(sender, e);
        FillGrid();
    }

    protected void gvAdminList_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Visible = true;

        //force databinding
        FillRecords(Convert.ToInt32(((Label)gvAdminList.Rows[gvAdminList.SelectedIndex].FindControl("lblGetId")).Text));
        lblMainId.Text = ((Label)gvAdminList.Rows[gvAdminList.SelectedIndex].FindControl("lblGetId")).Text;
        //  update the contents in the detail panel
        this.updPnlCategoryDetail.Update();
        //  show the modal popup
        this.mdlPopup.Show();

        //Call fillgrid to fetch grid's data
        FillGrid();
    }

    protected void gvAdminList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAdminList.PageIndex = e.NewPageIndex;
        gvIndex = e.NewPageIndex;
        FillGrid();
    }
    #endregion

    #region Hide Disp methds
    private void HideDispControl()
    {
        if (gvAdminList.Rows.Count > 0)
        {
            btnCheckAll.Visible = true;
            btnClearAll.Visible = true;
            btnDelete.Visible = true;
            btnActive.Visible = true;
            btnInActive.Visible = true;
            lbl12.Visible = true;
        }
        else
        {
            btnCheckAll.Visible = false;
            btnClearAll.Visible = false;
            btnDelete.Visible = false;
            btnActive.Visible = false;
            btnInActive.Visible = false;
            lbl12.Visible = false;
        }
    }
    #endregion

    #region Fill Grid Info
    private void FillGrid()
    {
        int TotalCount;
        gvAdminList.PageIndex = gvIndex;
        DataTable table = BAL_News.GetNewsListInfo(gvAdminList.PageIndex, gvAdminList.PageSize, gvAdminList.OrderBy, string.Empty, string.Empty, out TotalCount);
        gvAdminList.VirtualItemCount = TotalCount;
        gvAdminList.DataSource = table;
        gvAdminList.DataBind();
        HideDispControl();
    }

    private void FillGrid(string Title, string NewsDate)
    {
        int TotalCount;
        gvAdminList.PageIndex = gvIndex;
        DataTable table = BAL_News.GetNewsListInfo(gvAdminList.PageIndex, gvAdminList.PageSize, gvAdminList.OrderBy, Title, NewsDate, out TotalCount);
        gvAdminList.VirtualItemCount = TotalCount;
        gvAdminList.DataSource = table;
        gvAdminList.DataBind();
        HideDispControl();
    }
    #endregion

    #region Button click events == for search
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string str = Server.HtmlEncode(Convert.ToString(newsdate.Value));
        pnlSearch.Attributes.Add("style", "visibility:visible");
        pnlSearch.Attributes.Add("style", "display:block");
        FillGrid(Server.HtmlEncode(Convert.ToString(txtpnlTitle.Text)), Server.HtmlEncode(Convert.ToString(newsdate.Value)));
    }

    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        pnlSearch.Attributes.Add("style", "visibility:hidden");
        pnlSearch.Attributes.Add("style", "display:none");
        FillGrid();
    }
    #endregion

    #region Drop down list events
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        int _size = 0;
        if (ddlPage.SelectedIndex <= 0)
        {
            _size = this.DefaultAdminPageSize;
        }
        else
        {
            _size = Convert.ToInt32(ddlPage.SelectedValue);
        }
        gvAdminList.PageSize = _size;
        FillGrid();
    }

    private void FillDropDown()
    {
        DataTable table = BAL_Paging.SelectPagingInfo();
        ddlPage.DataSource = table;
        ddlPage.DataTextField = table.Columns["PageSize"].ToString();
        ddlPage.DataValueField = table.Columns["PageSize"].ToString();
        ddlPage.DataBind();

        ddlPage.Items.Insert(0, new ListItem("Default", "-1"));

    }
    #endregion
}
