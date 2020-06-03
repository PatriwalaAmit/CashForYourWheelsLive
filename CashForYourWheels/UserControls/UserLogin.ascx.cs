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

public partial class UserControls_UserLogin : System.Web.UI.UserControl
{
    #region Varaible declaration
    // Delegate declaration
    public delegate void OnButtonClick(string strValue);

    // Event declaration
    public event OnButtonClick btnHandler;
    #endregion


    #region Property
    private string _CallForgotPassword;
    public string CallForgotPassword
    {
        set
        {
            _CallForgotPassword = value;
        }
        get
        {
            return _CallForgotPassword;
        }

    }

    private string _ProductDetails;
    public string ProductDetails
    {
        set
        {
            _ProductDetails = value;
        }
        get
        {
            return _ProductDetails;
        }
    }
    #endregion

    #region page events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CustomerSessions"] == null)
            {
                LinkButton1.Attributes.Add("onclick", CallForgotPassword);


                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();
                if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["login"])))
                {
                    lblCheckOut.Text = Convert.ToString(Request.QueryString["login"]);
                    btnLogin.Text = "Login With Existing Account";
                    btnWithoutlogin.Visible = true;
                    btnWithoutlogin.Text = "Place Order Without Account";
                }
                else
                {
                    btnLogin.Text = "Login";
                    btnWithoutlogin.Visible = false;
                    lblCheckOut.Text = "";
                }
                txtPassword.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + btnLogin.UniqueID + "').click();return false;}} else {return true}; ");
            }
            else
            {
                if (string.IsNullOrEmpty(ProductDetails))
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }
    }
    #endregion

    #region button click
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text))
        {
            DataTable table = BAL_UserLogin.Login_Verify(Convert.ToString(txtUsername.Text), CommonShared.EnryptString(Convert.ToString(txtPassword.Text)));
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    CustomerSessions cs = new CustomerSessions();

                    cs.CustomerId = Convert.ToInt32(table.Rows[0]["CustomerId"]);
                    cs.FirstName = Convert.ToString(table.Rows[0]["FirstName"]);
                    cs.LastName = Convert.ToString(table.Rows[0]["LastName"]);
                    cs.Sex = char.Parse(Convert.ToString(table.Rows[0]["Sex"]));
                    cs.Email = Convert.ToString(table.Rows[0]["EmailId"]);
                    cs.Password = Convert.ToString(table.Rows[0]["Password"]);
                    cs.Address1 = Convert.ToString(table.Rows[0]["Address1"]);
                    cs.Address2 = Convert.ToString(table.Rows[0]["Address2"]);
                    cs.CityId = Convert.ToInt32(table.Rows[0]["CityId"]);
                    cs.City = Convert.ToString(table.Rows[0]["City"]);
                    cs.StateId = Convert.ToInt32(table.Rows[0]["StateId"]);
                    cs.State = Convert.ToString(table.Rows[0]["State"]);
                    cs.CountryId = Convert.ToInt32(table.Rows[0]["CountryId"]);
                    cs.Country = Convert.ToString(table.Rows[0]["Country"]);
                    cs.ZipCode = Convert.ToString(table.Rows[0]["ZipCode"]);
                    cs.PhoneNo = Convert.ToString(table.Rows[0]["PhoneNo"]);


                    //store object into session
                    Session["CustomerSessions"] = cs;

                    if (string.IsNullOrEmpty(ProductDetails))
                    {
                        if (string.IsNullOrEmpty(lblCheckOut.Text))
                        {
                            Response.Redirect("~/User/Members.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/User/Checkout.aspx");
                        }
                    }
                    else
                    {
                        if (btnHandler != null)
                            btnHandler("ProductDetails");
                    }
                }
                else
                {
                    lblLoginError.Text = "Invalid UserName or Password";
                    txtPassword.Text = "";
                    txtUsername.Text = "";
                }
            }
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Registration.aspx");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }

    protected void btnWithoutlogin_Click(object sender, EventArgs e)
    {
        Session["IsCustomerWithoutLogin"] = true;
        Response.Redirect("~/User/Checkout.aspx?yes=yes");
    }
    #endregion

}
