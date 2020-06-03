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

public partial class Master_AdminPanel2 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AccountDetail"] == null)
        {
            Response.Redirect("~/AdminLogin.aspx");
        }
    }


    protected void HLLogout_Click(object sender, EventArgs e)
    {
        Session["AccountDetail"] = null;
        Session.Remove("AccountDetail");
        Session.Clear();
        Session.Abandon();
        Response.Redirect("~/AdminLogin.aspx");        
    }
    
}
