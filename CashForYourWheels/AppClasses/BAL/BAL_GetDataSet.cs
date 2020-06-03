using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.Common;

/// <summary>
/// Summary description for BAL_GetDataSet
/// </summary>
public class BAL_GetDataSet
{
    public BAL_GetDataSet()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public static DataTable GetResult(String Query)
    {
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        DataTable dt = new DataTable();
        SqlDataAdapter Adp = new SqlDataAdapter(Query, comm.Connection.ConnectionString);
        Adp.Fill(dt);
        return dt;
    }

    public static DataSet GetResultSet(String Query)
    {
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        DataSet ds = new DataSet();
        SqlDataAdapter Adp = new SqlDataAdapter(Query, comm.Connection.ConnectionString);
        Adp.Fill(ds);
        return ds;

    }

    public static DataTable GetSearch(string Value)
    {
        return GetResult("select *,cast(ProductId as  varchar(10))+','+ ProductName as ProductIdName from Products where DeleteStatus=0 AND Active=1 AND productname like '%" + Value + "%'");
    }

    public static DataSet Getcategory()
    {
        return GetResultSet("select CategoryId,CategoryName from Category where deletestatus=0 AND Active=1 order by categoryname");
    }

    public static DataSet GetRelatedProduct(int ProductId, int CategoryId)
    {
        return GetResultSet("select top 1  *,cast(ProductId as  varchar(10))+','+ ProductName as ProductIdName from products where deletestatus=0 AND Active=1 AND productid!=" + ProductId + " AND categoryId=" + CategoryId + "");
    }

    public static DataSet GetShippingGroup()
    {
        return GetResultSet("select * from ShippingGroup where  Active=1 AND deletestatus=0");
    }

    public static DataTable GetShippingType(string GroupName)
    {
        return GetResult("select * from ShippingInfo where ShippingGroupId='" + GroupName + "' AND Active=1 AND deletestatus=0");
    }

    public static DataTable GetBestProducts()
    {
        return GetResult("select top(3) Products.ProductId,Products.CategoryId,Products.ProductName,Products.ImagePath ,cast(Products.ProductId as varchar(50))+','+products.ProductName as ProductIdName from Products inner join BestFeature on BestFeature.ProductId=Products.ProductId where active=1 and BestFeature.DeleteStatus=0 ");
    }

    public static DataTable GetParentCat()
    {
        return GetResult("select CategoryId ,CategoryName from category where deletestatus=0 AND Active=1 AND ParentId=0 order by CategoryName");
    }
    public static DataTable GetChildCat(string ParentId)
    {
        return GetResult("select CategoryId ,CategoryName from category where deletestatus=0 AND Active=1 AND ParentId='" + ParentId + "' order by CategoryName");
    }
    public static DataTable GetChildProducts(string CatId)
    {
        return GetResult("select productid,productname from products where deletestatus=0 AND Active=1 AND categoryid=" + CatId);
    }


    public static DataTable GetAdvanceSearch(string Value)
    {
        string[] Searchtext = Value.Split(',');
        int lenght = Searchtext.Length;


        if (Searchtext[5] == "Search All Fields")
        {
            if (Searchtext[1] == "All Categories")
            {

                //if (Searchtext[2] != null && Searchtext[2] != "" && Searchtext[3] != null && Searchtext[3] != "")
                if (!string.IsNullOrEmpty(Searchtext[2]) && !string.IsNullOrEmpty(Searchtext[3]))
                {
                    return GetResult("select ProductId,CategoryId,ProductName,DefaultPrice,ImagePath,cast(ProductId as  varchar(10))+','+ ProductName as ProductIdName from Products where  DeleteStatus=0 AND Active=1 AND productname like '%" + Searchtext[0] + "%' AND (DefaultPrice between " + Searchtext[2] + " AND " + Searchtext[3] + " OR DefaultPrice between " + Searchtext[3] + " AND " + Searchtext[2] + ") order by " + Searchtext[4] + " ");
                }
                else
                {
                    return GetResult("select ProductId,CategoryId,ProductName,DefaultPrice,ImagePath,cast(ProductId as  varchar(10))+','+ ProductName as ProductIdName from Products where  DeleteStatus=0 AND Active=1 AND productname like '%" + Searchtext[0] + "%' order by " + Searchtext[4] + "");
                }
            }
            else if (Searchtext[1] != "All Categories")
            {
                //if (Searchtext[2] != null && Searchtext[2] != "" && Searchtext[3] != null && Searchtext[3] != "")
                if (!string.IsNullOrEmpty(Searchtext[2]) && !string.IsNullOrEmpty(Searchtext[3]))
                {
                    return GetResult("select ProductId,CategoryId,ProductName,DefaultPrice,ImagePath,cast(ProductId as  varchar(10))+','+ ProductName as ProductIdName from Products where categoryid=" + Searchtext[1] + " and DeleteStatus=0 AND Active=1 AND productname like '%" + Searchtext[0] + "%'AND (DefaultPrice between " + Searchtext[2] + " AND " + Searchtext[3] + " OR DefaultPrice between " + Searchtext[3] + " AND " + Searchtext[2] + ") order by " + Searchtext[4] + " ");
                }
                else
                {
                    return GetResult("select ProductId,CategoryId,ProductName,DefaultPrice,ImagePath,cast(ProductId as  varchar(10))+','+ ProductName as ProductIdName from Products where categoryid=" + Searchtext[1] + " and DeleteStatus=0 AND Active=1 AND productname like '%" + Searchtext[0] + "%' order by " + Searchtext[4] + "");
                }

            }
            else
            {
                return GetResult("select ProductId,CategoryId,ProductName,DefaultPrice,ImagePath,cast(ProductId as  varchar(10))+','+ ProductName as ProductIdName from Products where DeleteStatus=0 AND Active=1 ");
            }
        }
        else
        {
            return GetResult("select ProductId,CategoryId,ProductName,DefaultPrice,ImagePath,cast(ProductId as  varchar(10))+','+ ProductName as ProductIdName from Products where DeleteStatus=0  AND Active=1 AND productname like '%" + Searchtext[0] + "%' ");
        }
    }

    public static DataTable GetRelatedProductInfo(int ProductId, int CategoryId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetRelatedProduct";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@ProductId";
        param1.Value = ProductId;
        param1.DbType = DbType.Int32;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@CategoryId";
        param2.Value = CategoryId;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        // return the result table
        return gda.ExecuteSelectCommand(comm);
    }
}
