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

public partial class Email : System.Web.UI.Page
{
    #region Page Events
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["Theme"] != null)
        {
            string str = Session["Theme"].ToString();
            Page.Theme = str;
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    #endregion

    #region Button Events
    protected void btnSendMail_Click(object sender, EventArgs e)
    {
        /*new development iBusiness*/
        //if (Utilities.SendMail(txtName.Text, txtEmail.Text, txtFName.Text, txtFEmail.Text, "", txtMsg.Text, "") == true)
        //{
        //    if (BAL_MailList.InsertMailList(txtName.Text.Trim(), txtEmail.Text.Trim(), txtFName.Text.Trim(), txtFEmail.Text.Trim(), txtMsg.Text) == true)
        //    {
        //        ShowMessage("Mail sent successfully.");
        //        CloseWindows();
        //    }
        //    else
        //    {
        //        ShowMessage("Error while sending mail.Please try again.");
        //    }
        //}
        //else
        //{
        //    ShowMessage("Error while sending mail.Please try again.");
        //}
    }
    #endregion

    #region Other methods
    private void ShowMessage(string msg)
    {
        DisplayAlertMessage.CreateMessageAlert(this, msg, "alertKey");
    }

    private void CloseWindows()
    {
        string strscript = "<script language=javascript>window.top.close();</script>";
        if (!ClientScript.IsStartupScriptRegistered("clientScript"))
        {
            this.ClientScript.RegisterStartupScript(GetType(), "clientScript", strscript);
        }
    }
    #endregion
}
