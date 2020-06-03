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
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    /// <summary>
    /// 
    /// </summary>
    private int _DefaultAdminPageSize;
    public int DefaultAdminPageSize
    {
        get { return _DefaultAdminPageSize; }
        set { _DefaultAdminPageSize = value; }
    }

    private int _DefaultFrontPageSize;
    public int DefaultFrontPageSize
    {
        get { return _DefaultFrontPageSize; }
        set { _DefaultFrontPageSize = value; }
    }

    #region Default constructor
    public BasePage()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion


    #region page overidden events
    protected override void OnPreInit(EventArgs e)
    {
        if (Session["AccountDetail"] == null)
        {
            Response.Redirect("~/AdminLogin.aspx");
        }
        base.OnPreInit(e);
    }

    protected override void OnLoad(EventArgs e)
    {
        if (Session["AccountDetail"] == null)
        {
            Response.Redirect("~/AdminLogin.aspx");
        }
        else
        {
            DataTable table = BAL_Paging.GetPageInfo();
            if (table == null || table.Rows.Count <= 0)
            {
                this.DefaultAdminPageSize = 10;
                this.DefaultFrontPageSize = 10;
            }
            else
            {
                this.DefaultAdminPageSize = Convert.ToInt32(table.Rows[0]["AdminPageSize"]);
                this.DefaultFrontPageSize = Convert.ToInt32(table.Rows[0]["FrontPageSize"]);
            }
        }
        base.OnLoad(e);
        //this.ValidateRequest = false;        
    }
    #endregion
}
