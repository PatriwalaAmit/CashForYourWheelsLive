using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class yourvaluation : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        ((LinkButton)Page.Master.FindControl("aValueMyCar")).CssClass = "active";

        if (Session["Valuation"] == null)
        {
            Response.Redirect("~/index.aspx");
        }
    }
}
