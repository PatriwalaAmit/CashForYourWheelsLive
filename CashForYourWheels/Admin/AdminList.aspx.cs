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

public partial class Admin_UserManagement_AdminList : BasePage //System.Web.UI.Page
{
    #region Variable and Property declartions
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

    #region Button Click events
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string str = UpdateDetails();
        if (!string.IsNullOrEmpty(str))
        {
            if (BAL_AdminList.DeleteAdminList(str))
            {
                ShowMessage("Record Deleted Succefully.");
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
            if (BAL_AdminList.UpdateStatusForAdmin(str, true))
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
            if (BAL_AdminList.UpdateStatusForAdmin(str, false))
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
        Response.Redirect("~/Admin/AddEditAdmin.aspx");
    }

    protected void imgbtn_AddAdmin_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Admin/AddEditAdmin.aspx");
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        Hashtable h1 = new Hashtable();

        h1.Add("id", lblMainId.Text);
        Response.Redirect("~/Admin/AddEditAdmin.aspx?data=" + CommonShared.EncryptQueryString(h1));
    }


    #endregion

    #region Other Methods
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

    private void ShowMessage(string msg)
    {
        DisplayAlertMessage.CreateMessageAlert(this, msg, "alertKey");
    }

    private void FillRecords(int Id)
    {
        DataTable table = BAL_AdminList.GetAdminList(Id);
        if (table.Rows.Count > 0)
        {
            table.Rows[0]["Password"] = Convert.ToString(table.Rows[0]["Password"]);
            string strPass = string.Empty;
            for (int i = 0; i < Convert.ToString(table.Rows[0]["Password"]).Length; i++)
            {
                strPass = strPass + "*";
            }
            if (!string.IsNullOrEmpty(strPass))
            {
                table.Rows[0]["Password"] = strPass;
            }
            dvDetails.DataSource = table;
            dvDetails.DataBind();
        }
        else
        {
            dvDetails.DataSource = table;
            dvDetails.DataBind();
        }
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
        FillGrid(Convert.ToString(txtpnlFirstName.Text), Convert.ToString(txtpnlLastName.Text), Convert.ToString(txtpnlEmail.Text));
    }

    protected void gvAdminList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAdminList.PageIndex = e.NewPageIndex;
        gvIndex = e.NewPageIndex;
        FillGrid();
    }

    protected void gvAdminList_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Visible = true;

        //force databinding
        FillRecords(Convert.ToInt32(((Label)gvAdminList.Rows[gvAdminList.SelectedIndex].FindControl("lblGetId")).Text));
        lblMainId.Text = ((Label)gvAdminList.Rows[gvAdminList.SelectedIndex].FindControl("lblGetId")).Text;
        //  update the contents in the detail panel
       // this.updPnlCategoryDetail.Update();
        //  show the modal popup
        this.mdlPopup.Show();

        //call the grid view fill grid to get the grid's data
        FillGrid();
    }
    #endregion

    #region Button Search Click Events
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        pnlSearch.Attributes.Add("style", "visibility:visible");
        pnlSearch.Attributes.Add("style", "display:block");
        FillGrid(Server.HtmlEncode(Convert.ToString(txtpnlFirstName.Text)), Server.HtmlEncode(Convert.ToString(txtpnlLastName.Text)), Server.HtmlEncode(Convert.ToString(txtpnlEmail.Text)));
    }

    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        pnlSearch.Attributes.Add("style", "visibility:hidden");
        pnlSearch.Attributes.Add("style", "display:none");
        FillGrid();
    }
    #endregion

    #region Fill Grid Methods
    private void FillGrid()
    {
        int TotalCount;
        gvAdminList.PageIndex = gvIndex;
        DataTable table = BAL_AdminList.GetAdminDetails(string.Empty, string.Empty, string.Empty, gvAdminList.PageIndex, gvAdminList.PageSize, gvAdminList.OrderBy, out TotalCount, "getadminlist",1,0);
        gvAdminList.VirtualItemCount = TotalCount;
        gvAdminList.DataSource = table;
        gvAdminList.DataBind();
        DispHideControls();
    }

    private void FillGrid(string FirstName, string LastName, string Email)
    {
        int TotalCount;
        gvAdminList.PageIndex = gvIndex;
        DataTable table = BAL_AdminList.GetAdminDetails(FirstName, LastName, Email, gvAdminList.PageIndex, gvAdminList.PageSize, gvAdminList.OrderBy, out TotalCount, "getadminlist",1,0);
        gvAdminList.VirtualItemCount = TotalCount;
        gvAdminList.DataSource = table;
        gvAdminList.DataBind();
        DispHideControls();
    }

    private void DispHideControls()
    {
        if (gvAdminList.Rows.Count > 0)
        {
            btnCheckAll.Visible = true;
            btnClearAll.Visible = true;
            btnDelete.Visible = true;
            btnActive.Visible = true;
            btnInActive.Visible = true;
            lblSep.Visible = true;
            //imgbtn_Search.Visible = true;
            //lnkbtn_Search.Visible = true;
        }
        else
        {
            btnCheckAll.Visible = false;
            btnClearAll.Visible = false;
            btnDelete.Visible = false;
            btnActive.Visible = false;
            btnInActive.Visible = false;
            lblSep.Visible = false;
            //imgbtn_Search.Visible = false;
            //lnkbtn_Search.Visible = false;
        }
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
    #endregion
}
