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
/// Summary description for GridViewClass
/// </summary>
public class GridViewClass
{
    static bool IsUp = false;
	public GridViewClass()
	{
		
	}

    // This is used to flip the sorting arrow up/down
    // Base Css class is 'sort', the Ascending Css Class is 'up' and Descending is 'down'
    public static void GVSort(object sender, GridViewSortEventArgs e)
    { 
        // call on sort and sets the sorted field to the proper Css Class, while setting all others to the base class
        string BASE = "sort";
        string UP = "up";
        string DOWN = "down";
        GridView g = (GridView)sender;
        for (int i = 0; i < g.Columns.Count; i++)
        {
            //var c = g.Columns[i];
            g.Columns[i].HeaderStyle.CssClass = g.Columns[i].HeaderStyle.CssClass.Replace(UP, BASE).Replace(DOWN, BASE);
            if (g.Columns[i].SortExpression.Equals(e.SortExpression))
            {
                if (e.SortDirection.Equals(System.Web.UI.WebControls.SortDirection.Ascending))
                {
                    if (IsUp == false)
                    {
                        g.Columns[i].HeaderStyle.CssClass = UP;
                        IsUp = true;
                    }
                    else
                    {
                        g.Columns[i].HeaderStyle.CssClass = DOWN;
                        IsUp = false;
                    }
                    
                }
                else
                {
                    if (IsUp == true)
                    {
                        g.Columns[i].HeaderStyle.CssClass = UP;
                        IsUp = false;
                    }
                    else
                    {
                        g.Columns[i].HeaderStyle.CssClass = DOWN;
                        IsUp = true;
                    }
                }             
            }
        }
    } 
}
