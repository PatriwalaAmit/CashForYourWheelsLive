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

public partial class UserControls_ChangePassword : System.Web.UI.UserControl
{
    #region Page events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CustomerSessions"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                CustomerSessions cs = (CustomerSessions)Session["CustomerSessions"];
                lblCustomerId.Text = Convert.ToString(cs.CustomerId);
                lblPassword.Text = cs.Password;
            }
        }
    }
    #endregion

    #region Button Click events
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //change the user password if password match
        if (lblPassword.Text == CommonShared.EnryptString(txtOldPassword.Text.Trim()))
        {
            if (BAL_Registration.ChangeCustomerPassword(CommonShared.EnryptString(txtOldPassword.Text.Trim()), CommonShared.EnryptString(txtNewPassword.Text.Trim()), Convert.ToInt32(lblCustomerId.Text)) == true)
            {
                DataTable table = BAL_Registration.GetRecordsForUser(Convert.ToInt32(lblCustomerId.Text));
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
                        cs.Address1 = Convert.ToString(table.Rows[0]["BAddress1"]);
                        cs.Address2 = Convert.ToString(table.Rows[0]["BAddress2"]);
                        cs.City = Convert.ToString(table.Rows[0]["BCityName"]);
                        cs.State = Convert.ToString(table.Rows[0]["BStateName"]);
                        cs.Country = Convert.ToString(table.Rows[0]["BCountryName"]);
                        cs.ZipCode = Convert.ToString(table.Rows[0]["BZip"]);
                        cs.PhoneNo = Convert.ToString(table.Rows[0]["BPhone"]);
                        cs.BusinessName = Convert.ToString(table.Rows[0]["BusinessName"]);
                        cs.ZipCode = Convert.ToString(table.Rows[0]["BZip"]);
                        cs.BFax = Convert.ToString(table.Rows[0]["BFax"]);
                        cs.BContactPerson = Convert.ToString(table.Rows[0]["BContactPerson"]);
                        //store object into session
                        Session["CustomerSessions"] = cs;

                        //store object into session
                        Session["CustomerSessions"] = cs;
                        Response.Redirect("~/User/Members.aspx");
                    }
                }
            }
            else
            {
                Label5.Visible = true;
                Label5.Text = "Error in password changed.Please try again";
            }
        }
        else
        {
            Label5.Visible = true;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //redirct to members profile home page
        Response.Redirect("~/User/Members.aspx");
    }
    #endregion
}
