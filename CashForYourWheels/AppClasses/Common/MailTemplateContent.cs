using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Common;

/// <summary>
/// Summary description for MailTemplateContent
/// </summary>
public class MailTemplateContent
{
	public MailTemplateContent()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public enum MailTemplateType
    {
        MailContentRegister,
        MailContentRequesttouseProperty,
        MailContentForgetPassword,
        forgotpassword,
        HomePageScroll,
        HomePageText
    }

    private MailTemplateType _MailTemplateFormat;

    public MailTemplateType MailTemplateFormat
    {
        get { return _MailTemplateFormat; }
        set { _MailTemplateFormat = value; }
    }
	

    /// <summary>
    /// 
    /// </summary>
    /// <param name="MailTemplate">Mail Template Name</param>
    /// <returns></returns>
    public string GetMailContent()
    {
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        comm.CommandType = CommandType.Text;
        // set the stored procedure name
        comm.CommandText = "select Description from CMS where LinkName='" + Convert.ToString(MailTemplateFormat)+ "'";
        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return Convert.ToString(table.Rows[0]["Description"]);       
    }
}
