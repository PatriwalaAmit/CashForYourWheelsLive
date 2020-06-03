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

public partial class Admin_AddEditAdmin : BasePage //System.Web.UI.Page
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

    #region Page Events
    protected void Page_Load(object sender, EventArgs e)
    {
        ChekcNamefirst.ValidationExpression = AppConfig.CheckNameRegEx;
        checklastnameforreg.ValidationExpression = AppConfig.CheckNameRegEx;

        if (!IsPostBack)
        {
            if (Session["AccountDetail"] != null)
            {
                SetDeafultPageSize();
                //gvAdminList.VirtualItemCount = Convert.ToInt32(BAL_AdminList.GetTotalAdminCount());

                // set the gridview initial pageindex into viewstate
                gvIndex = gvAdminList.PageIndex;
                FillGrid(string.Empty, string.Empty);
                string str = Convert.ToString(CommonShared.DecryptQueryString("id", Request.QueryString["data"]));
                if (!string.IsNullOrEmpty(str))
                {
                    lblMode.Text = str;
                    Label4.Text = "Edit Admin";
                    GetRecords();
                }
                else
                {
                    Label4.Text = "Add Admin";
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
        gvAdminList.PageSize = this.DefaultAdminPageSize;
    }
    #endregion

    #region Button Click Events
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/AdminList.aspx");
    }

    protected void lnkbntNew_Click(object sender, EventArgs e)
    {
        Label4.Text = "Add Admin";
        lblMode.Text = "0";
        ClearInput();
    }

    protected void btnAddNew_Click(object sender, ImageClickEventArgs e)
    {
        Label4.Text = "Add Admin";
        lblMode.Text = "0";
        ClearInput();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidationInput() == false)
        {
            Page.Validate("CheckAtSave");
            if (Page.IsValid == true)
            {
                txtFirstName.Text = Server.HtmlEncode(txtFirstName.Text);
                txtLastName.Text = Server.HtmlEncode(txtLastName.Text);
                txtEmail.Text = Server.HtmlEncode(txtEmail.Text);
                txtPassword.Text = Server.HtmlEncode(txtPassword.Text);
                txtPhn.Text = Server.HtmlEncode(txtPhn.Text);

                if (BAL_AdminList.CheckAdminExist(txtEmail.Text.Trim(), Convert.ToInt32(lblMode.Text)) == false)
                {
                    string _Sex = string.Empty;
                    if (Convert.ToString(rdoSex.SelectedItem.Text).ToUpper() == "MALE")
                    {
                        _Sex = "M";
                    }
                    else
                    {
                        _Sex = "F";
                    }
                    if (!string.IsNullOrEmpty(lblMode.Text) && lblMode.Text != "0")
                    {
                        //update records
                        InsertUpdateRecords(BAL_AdminList.UpdateAdminList(txtFirstName.Text, txtLastName.Text, _Sex, txtEmail.Text, txtPassword.Text, txtPhn.Text, Convert.ToInt32(lblMode.Text)), true);
                    }
                    else
                    {
                        //insert
                        InsertUpdateRecords(BAL_AdminList.InsertAdminList(txtFirstName.Text, txtLastName.Text, _Sex, txtEmail.Text, txtPassword.Text, txtPhn.Text), true);
                    }
                }
                else
                {
                    ShowMessage("Admin with this email is already inserted!");
                }
            }
            else
            {
                ShowMessage("Some Required Field Missing");
            }
        }
    }

    #endregion

    #region Other methods
    /// <summary>
    /// Display Result Message
    /// </summary>
    /// <param name="msg">Message to display</param>
    private void ShowMessage(string msg)
    {
        DisplayAlertMessage.CreateMessageAlert(this, msg, "alertKey");
    }

    /// <summary>
    /// Check for User input is valid or not
    /// </summary>
    /// <returns>return true if user input is invalid</returns>
    private bool ValidationInput()
    {
        bool flag = false;
        string str = string.Empty;
        if (string.IsNullOrEmpty(txtFirstName.Text))
        {
            str = str + "Please enter First Name";
            flag = true;
        }
        if (string.IsNullOrEmpty(txtLastName.Text))
        {
            str = str + "\nPlease enter Last Name";
            flag = true;
        }
        if (string.IsNullOrEmpty(txtEmail.Text))
        {
            str = str + "\nPlease enter Email Address(UID)";
            flag = true;
        }
        if (string.IsNullOrEmpty(txtPassword.Text))
        {
            str = str + "\nPlease enter Password";
            flag = true;
        }
        if (string.IsNullOrEmpty(txtConfirmPassword.Text))
        {
            str = str + "\nPlease enter Confirm Password";
            flag = true;
        }
        if (string.IsNullOrEmpty(txtPhn.Text))
        {
            str = str + "\nPlease enter Phone Number";
            flag = true;
        }
        if (flag == true)
        {
            ShowMessage(str);
            return true;
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// Fetch the records and fill the grid
    /// </summary>
    private void FillGrid(string UserName, string Email)
    {
        UserName = Server.HtmlDecode(UserName);
        Email = Server.HtmlDecode(Email);
        int TotalCount;
        gvAdminList.PageIndex = gvIndex;
        DataTable table = BAL_AdminList.GetAdminList(UserName, Email, gvAdminList.PageIndex, gvAdminList.PageSize, out TotalCount);
        gvAdminList.VirtualItemCount = TotalCount;
        gvAdminList.DataSource = table;
        gvAdminList.DataBind();
        HideDispGridCol();
    }

    /// <summary>
    /// Hide Display Grid Columns
    /// </summary>
    private void HideDispGridCol()
    {
        if (ddlList.SelectedItem.Text == "UserName")
        {
            gvAdminList.Columns[1].Visible = true;
            gvAdminList.Columns[2].Visible = false;
        }
        else
        {
            gvAdminList.Columns[1].Visible = false;
            gvAdminList.Columns[2].Visible = true;
        }
    }

    /// <summary>
    /// Clear the input data
    /// </summary>
    private void ClearInput()
    {
        txtFirstName.Text = string.Empty;
        txtLastName.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtPassword.Text = string.Empty;
        txtConfirmPassword.Text = string.Empty;
        txtPhn.Text = string.Empty;
        txtPassword.Attributes.Add("value", string.Empty);
        txtConfirmPassword.Attributes.Add("value", string.Empty);
    }

    /// <summary>
    /// Get Records For Edit/Update
    /// </summary>
    private void GetRecords()
    {
        DataTable table = BAL_AdminList.GetAdminList(Convert.ToInt32(lblMode.Text));
        if (table != null && table.Rows.Count > 0)
        {
            txtFirstName.Text = Convert.ToString(table.Rows[0]["FirstName"]);
            txtLastName.Text = Convert.ToString(table.Rows[0]["LastName"]);
            txtEmail.Text = Convert.ToString(table.Rows[0]["Email"]);
            txtPhn.Text = Convert.ToString(table.Rows[0]["Mobile"]);

            // make password field to hidden means insert star into password textbox
            table.Rows[0]["Password"] = Convert.ToString(table.Rows[0]["Password"]);
            string strPass = string.Empty;
            for (int i = 0; i < Convert.ToString(table.Rows[0]["Password"]).Length; i++)
            {
                strPass = strPass + "*";
            }
            if (!string.IsNullOrEmpty(strPass))
            {
                table.Rows[0]["Password"] = strPass;
                txtPassword.Attributes.Add("value", Convert.ToString(table.Rows[0]["Password"]));
                txtConfirmPassword.Attributes.Add("value", Convert.ToString(table.Rows[0]["Password"]));
            }
            //txtPassword.Text = Convert.ToString(table.Rows[0]["Password"]);
            //txtConfirmPassword.Text = Convert.ToString(table.Rows[0]["Password"]);


        }
    }

    /// <summary>
    /// Get Search value 
    /// </summary>
    /// <returns>return search value</returns>
    private string GetProductSearchName()
    {
        if (string.IsNullOrEmpty(txtSearch.Text))
        {
            return string.Empty;
        }
        else
        {
            return Server.HtmlEncode(Convert.ToString(txtSearch.Text).Trim());
        }
    }

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
            FillGrid(string.Empty, string.Empty);
        }
        else
        {
            //Error in 
            ShowMessage("Error in Inserting Record. Please Try Again");
        }
    }
    #endregion

    #region Grid View Events
    protected void gvAdminList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "CheckDetail")
        {
            lblMode.Text = Convert.ToString(e.CommandArgument);
            Label4.Text = "Edit Admin";
            ClearInput();
            GetRecords();
        }
    }

    protected void gvAdminList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (e.NewPageIndex < 0)
        {
            gvAdminList.PageIndex = 0;
            gvIndex = 0;
        }
        else
        {
            gvAdminList.PageIndex = e.NewPageIndex;
            gvIndex = e.NewPageIndex;
        }
        FillGrid(string.Empty, string.Empty);
    }
    #endregion

    #region Drop down List events
    protected void ddlList_SelectedIndexChanged(object sender, EventArgs e)
    {
        HideDispGridCol();
    }
    #endregion

    #region Button Click Event==For Search
    protected void btnGo_Click(object sender, EventArgs e)
    {
        string _UserName = string.Empty, _Email = string.Empty;
        if (Convert.ToString(ddlList.SelectedItem.Text) == "UserName")
        {
            _UserName = string.Empty;
            _Email = GetProductSearchName();
        }
        else
        {
            _UserName = GetProductSearchName();
            _Email = string.Empty;
        }
        FillGrid(_UserName, _Email);
    }

    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        FillGrid(string.Empty, string.Empty);
    }
    #endregion
}
