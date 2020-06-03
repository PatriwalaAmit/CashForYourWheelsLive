using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for DisplayAlertMessage
/// </summary>
public class DisplayAlertMessage
{
	public DisplayAlertMessage()
	{
		
	}

    public static void CreateMessageAlert(System.Web.UI.Page senderPage,string alertMsg, string alertKey)
    {
        ScriptManager.RegisterStartupScript(senderPage, senderPage.GetType(), alertKey, "alert('" + alertMsg + "');",true);        
    }
}
