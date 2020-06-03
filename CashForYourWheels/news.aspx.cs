using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class news : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((LinkButton)Page.Master.FindControl("aValueMyCar")).CssClass = "-active";
        ((LinkButton)Page.Master.FindControl("aBranchLocator")).CssClass = "-active";
        ((LinkButton)Page.Master.FindControl("aTestimonials")).CssClass = "-active";
        ((LinkButton)Page.Master.FindControl("aNews")).CssClass = "active";
        ((LinkButton)Page.Master.FindControl("aContact")).CssClass = "-active";  
    }
}
