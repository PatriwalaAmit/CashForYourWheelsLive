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

public partial class UserControls_BottomStrip : System.Web.UI.UserControl
{
    #region Page events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnTelltofrnd.Attributes.Add("onclick", "javascript:window.open('TellAFriend.aspx','TellAFriend','width=600,height=600,scrollbars=yes,top=1'); return false;");
        }
    }
    #endregion

    #region Link Button Click
    protected void HLHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }

    protected void btnAboutUs_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/User/AboutUs.aspx");
    }

    protected void btnFAQ_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/User/FAQ.aspx");
    }

    protected void btnTelltofrnd_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Email.aspx");
    }

    protected void btnprivacypolicy_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/User/PrivacyPolicy.aspx");
    }

    protected void btnContact_Click(object sender, EventArgs e)
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

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/User/Sitemap.aspx");
    }
    #endregion


    

}
