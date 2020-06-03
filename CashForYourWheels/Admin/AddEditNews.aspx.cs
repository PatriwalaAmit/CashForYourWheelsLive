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

public partial class Admin_AddEditNews : BasePage //System.Web.UI.Page
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

    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        CompareValidator1.ValueToCompare = DateTime.Today.ToString("MM/dd/yyyy");
        //txtDesc.BasePath = ConfigurationManager.AppSettings["FCKBasePath"].ToString();
        txtDesc.BasePath = AppConfig.FCKBasePath;
        if (!IsPostBack)
        {
            if (Session["AccountDetail"] != null)
            {
                SetDeafultPageSize();
                //gvCategory.VirtualItemCount = Convert.ToInt32(BAL_News.GetTotalNewsCount());

                //set the gridview initial pageindex into viewstate
                gvIndex = gvCategory.PageIndex;
                FillGrid();
                string str = Convert.ToString(CommonShared.DecryptQueryString("id", Request.QueryString["data"]));
                if (!string.IsNullOrEmpty(str))
                {
                    lblMode.Text = str;
                    Label4.Text = "Edit News/Events";
                    GetRecords();
                }
                else
                {
                    Label4.Text = "Add News/Events";
                    lblMode.Text = "0";
                }
            }
            else
            {
                Response.Redirect("~/AdminLogin.aspx");
            }
        }
    }

    private void SetDeafultPageSize()
    {
        gvCategory.PageSize = this.DefaultAdminPageSize;
    }
    #endregion

    #region Other Methods
    private void GetRecords()
    {
        DataTable table = BAL_News.GetNewsEventsListForNewsId(Convert.ToInt32(lblMode.Text));
        if (table != null && table.Rows.Count > 0)
        {
            txtTitle.Text = Convert.ToString(table.Rows[0]["Title"]);
            txtDesc.Value = Convert.ToString(table.Rows[0]["Description"]);
            txtLink.Text = Convert.ToString(table.Rows[0]["NewsLink"]);
            txtNewsDate.Text = Convert.ToString(table.Rows[0]["NewsDate"]);
        }
    }

    // fill the grid view    
    private void FillGrid()
    {
        int TotalCount;
        gvCategory.PageIndex = gvIndex;
        DataTable table = BAL_News.GetNewsDetails(string.Empty, gvCategory.PageIndex, gvCategory.PageSize, out TotalCount);
        gvCategory.VirtualItemCount = TotalCount;
        gvCategory.DataSource = table;
        gvCategory.DataBind();
    }

    private void FillGrid(string Title)
    {
        int TotalCount;
        gvCategory.PageIndex = gvIndex;
        DataTable table = BAL_News.GetNewsDetails(Title, gvCategory.PageIndex, gvCategory.PageSize, out TotalCount);
        gvCategory.VirtualItemCount = TotalCount;
        gvCategory.DataSource = table;
        gvCategory.DataBind();
    }


    //check user input
    private bool ValidateInput()
    {
        bool flag = false;
        string ErrorMsg = string.Empty;
        if (string.IsNullOrEmpty(txtTitle.Text))
        {
            ErrorMsg = ErrorMsg + "\nPlease Enter Title";
            flag = true;
        }
        if (string.IsNullOrEmpty(txtNewsDate.Text))
        {
            ErrorMsg = ErrorMsg + "\nPlease Enter End Date";
            flag = true;
        }
        if (flag == true)
        {
            ShowMessage("Enter Required Field\n" + ErrorMsg);
            return true;
        }
        else
        {
            return false;
        }
    }

    // display message box
    private void ShowMessage(string msg)
    {
        DisplayAlertMessage.CreateMessageAlert(this, msg, "alertKey");
    }

    //clear the inputs
    private void ClearInput()
    {
        txtTitle.Text = string.Empty;
        txtDesc.Value = string.Empty;
        txtLink.Text = string.Empty;
        txtNewsDate.Text = string.Empty;
    }

    // after insert or update the records
    private void InsertUpdateRecords(bool flag, bool IsUpdate)
    {
        if (flag == true)
        {
            //Successfully 
            if (IsUpdate == false)
            {
                ShowMessage("Record Inserted Successfully");
            }
            else
            {
                ShowMessage("Record Updated Successfully");
            }

            //ClearInput
            ClearInput();

            FillGrid();
        }
        else
        {
            //Error in 
            ShowMessage("Error in Inserting Record. Please Try Again");
        }
    }

    #endregion

    #region Button Click Event
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewsList.aspx");
    }

    protected void imgbtn_Insert_Click(object sender, EventArgs e)
    {
        if (ValidateInput() == false)
        {
            Page.Validate("AddCategory");
            if (Page.IsValid == true)
            {
                txtTitle.Text = Server.HtmlEncode(txtTitle.Text);
                txtLink.Text = Server.HtmlEncode(txtLink.Text);
                txtNewsDate.Text = Server.HtmlEncode(txtNewsDate.Text);

                if (BAL_News.CheckForNews(txtTitle.Text, Convert.ToInt32(lblMode.Text)) == false)
                {
                    if (!string.IsNullOrEmpty(lblMode.Text) && lblMode.Text != "0")
                    {
                        //update the records
                        InsertUpdateRecords(BAL_News.UpdateNews(txtTitle.Text, txtDesc.Value, txtLink.Text, Convert.ToDateTime(txtNewsDate.Text), Convert.ToInt32(lblMode.Text)), true);
                    }
                    else
                    {
                        //insert the records
                        InsertUpdateRecords(BAL_News.InsertNews(txtTitle.Text, txtDesc.Value, txtLink.Text, Convert.ToDateTime(txtNewsDate.Text)), false);
                    }
                }
                else
                {
                    ShowMessage("Title is already inserted!");
                }
            }
            else
            {
                ShowMessage("Some Required Field Missing");
            }
        }
    }

    #endregion

    #region Grid view events
    protected void gvCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCategory.PageIndex = e.NewPageIndex;
        gvIndex = e.NewPageIndex;
        FillGrid();
    }

    protected void gvCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "CheckDetail")
        {
            lblMode.Text = Convert.ToString(e.CommandArgument);
            Label4.Text = "Edit News/Events";
            ClearInput();
            GetRecords();
        }
    }
    #endregion

    #region Button Click==For Add new category
    protected void btnAddNew_Click(object sender, ImageClickEventArgs e)
    {
        AddNewCategory();
    }

    protected void lnkbntNew_Click(object sender, EventArgs e)
    {
        AddNewCategory();
    }
    #endregion

    #region Methods==For Add new category
    private void AddNewCategory()
    {
        Label4.Text = "Add News/Events";
        lblMode.Text = "0";
        ClearInput();
    }
    #endregion

    #region Button click events==for search
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        FillGrid();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillGrid(Server.HtmlEncode(txtSearchValue.Text));
    }
    #endregion
}
