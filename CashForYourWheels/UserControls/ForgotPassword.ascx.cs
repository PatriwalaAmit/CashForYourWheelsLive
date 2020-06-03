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

public partial class UserControls_ForgotPassword : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlQuestion.Items.Insert(0, new ListItem("Select Question", "-1"));
        }
        txtAnswer.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + btnSubmit.UniqueID + "').click();return false;}} else {return true}; ");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }
}
