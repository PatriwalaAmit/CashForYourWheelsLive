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
/// Summary description for AppConfig
/// </summary>
public class AppConfig
{
    #region Variable Declarations

    public static string SiteUrl = Convert.ToString(ConfigurationManager.AppSettings["SiteURL"]);
    public static string PageMessage = Convert.ToString(ConfigurationManager.AppSettings["Message"]);
    public static string Attachments = Convert.ToString(ConfigurationManager.AppSettings["Attachments"]);
    public static string FCKBasePath = Convert.ToString(ConfigurationManager.AppSettings["FCKBasePath"]);
    public static string CheckNameRegEx = Convert.ToString(ConfigurationManager.AppSettings["CheckNameRegEx"]);

    #endregion

    #region Constucotr
    public AppConfig()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion


}
