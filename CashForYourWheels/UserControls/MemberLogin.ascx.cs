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

public partial class UserControls_MemberLogin : System.Web.UI.UserControl
{
    #region Property Declaration

    private int _UserType;
    public int UserType
    {
        get { return _UserType; }
        set { _UserType = value; }
    }

    #endregion Property Declaration

    #region Page Event's

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUsername.Focus();
        }
    }

    #endregion Page Event's

    #region Control's Event
    protected void imgbtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        lblLoginError.Text = string.Empty;

        if (!string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text))
        {
            string Email, Password;
            Email = txtUsername.Text;
            Password = txtPassword.Text;
            DataTable dt = BAL_Login.Login_Verify(Email, Password, "login", UserType);
            if (dt != null)
            {
                if (dt.Rows.Count == 1)
                {
                    UserSession us = new UserSession();
                    us.UserID = Convert.ToInt32(dt.Rows[0]["UserID"].ToString());
                    us.UserTypeID = Convert.ToInt32(dt.Rows[0]["UserTypeID"].ToString());
                    us.Email = dt.Rows[0]["Email"].ToString();
                    us.Password = dt.Rows[0]["Password"].ToString();
                    us.FirstName = dt.Rows[0]["FirstName"].ToString();
                    us.LastName = dt.Rows[0]["LastName"].ToString();

                    //store object into session
                    Session["AccountDetail"] = us;

                    if (us.UserTypeID == 1) // Admin Users
                    {
                        Response.Redirect("~/Admin/AdminHome.aspx");
                    }
                }
                else
                {
                    lblLoginError.Text = "Invalid UserName or Password";
                }
            }
            else
            {
                lblLoginError.Text = "Invalid UserName or Password";
            }
        }
    }

    #endregion Control's Event
}
