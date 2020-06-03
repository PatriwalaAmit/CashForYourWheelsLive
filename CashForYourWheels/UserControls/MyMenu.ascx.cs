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

public partial class UserControls_MyMenu : System.Web.UI.UserControl
{
    #region Property    
    public enum _PositionStyle
    {
        Horizontal,
        Vertical
    }
    private _PositionStyle PositionStyle;

    /// <summary>
    /// define position of menu
    /// </summary>
    public _PositionStyle Direction
    {
        get { return PositionStyle; }
        set { PositionStyle = value; }
    }

    
    public DataTable _MyTable;

    /// <summary>
    /// Datatable to bind Menu from database
    /// Datatable must contain Column MenuId,Text,Description and NavigationURL
    /// </summary>
    public DataTable MyTable
    {
        get { return _MyTable; }
        set { _MyTable = value; }
    }

    #endregion



    #region Page events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Menu1.Orientation = (Orientation)PositionStyle;
            DefineRelation(MyTable);
        }
    }
    #endregion


    #region Menu binding events
    private void DefineRelation(DataTable table)
    {
        DataSet ds = new DataSet();

        ds.Tables.Add(table);
        ds.DataSetName = "Menus";
        ds.Tables[0].TableName = "Menu";
        DataRelation relation = new DataRelation("ParentChild", ds.Tables["Menu"].Columns["MenuID"], ds.Tables["Menu"].Columns["ParentID"], false);

        relation.Nested = true;
        ds.Relations.Add(relation);

        xmlDataSource.Data = ds.GetXml();
    }
    #endregion
}
