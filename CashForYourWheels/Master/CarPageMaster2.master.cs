using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Master_CarPageMaster2 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void aValueMyCar_Click(object sender, EventArgs e)
    {        
        Response.Redirect("~/index.aspx");
    }
    protected void aBranchLocator_Click(object sender, EventArgs e)
    {     
        Response.Redirect("~/branchlocator.aspx");
    }

    protected void aTestimonials_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/testimonials.aspx");
    }

    protected void aNews_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/news.aspx");
    }

    protected void aContactus_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/contact-us.aspx");
    }

}