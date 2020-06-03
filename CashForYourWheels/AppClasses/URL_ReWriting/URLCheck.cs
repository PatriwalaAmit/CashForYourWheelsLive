using System;
using System.Data;
using System.Data.Common;

/// <summary>
/// Summary description for URLCheck
/// </summary>
public class URLCheck
{
    public URLCheck()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Check Category
    public static DataTable CheckForCategory(string CategoryName)
    {
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        //set sp name
        comm.CommandText = "CategoryForURL";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@CategoryName";
        param1.Value = CategoryName;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        return gda.ExecuteSelectCommand(comm);

    }
    #endregion


    #region Check Product
    public static DataTable CheckForProductList(string ProductName)
    {
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        //set sp name
        comm.CommandText = "ProductListForURL";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@ProductName";
        param1.Value = ProductName;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        return gda.ExecuteSelectCommand(comm);

    }
    #endregion
}
