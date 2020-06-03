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

public partial class UserControls_CommonMenu : System.Web.UI.UserControl
{
    #region Page events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnTelltofrnd.Attributes.Add("onclick", "javascript:window.open('TellAFriend.aspx','TellAFriend','width=700,height=500,scrollbars=yes,top=1'); return false;");
        }
    }
    #endregion

    #region Link Button Click
    protected void btnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
    protected void btnAboutus_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/User/AboutUs.aspx");
    }
    protected void btnService_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/User/Services.aspx");
    }
    protected void btnTelltofrnd_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Email.aspx");
    }
    protected void btnFAQ_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/User/FAQ.aspx");
    }
    protected void btnContactUs_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/User/Contact.aspx");
    }

    protected void btnTrackOrder_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/User/TrackOrder.aspx");
    }

    protected void btnOrderHistory_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/User/OrderHistory.aspx");
    }
    #endregion

    
}
