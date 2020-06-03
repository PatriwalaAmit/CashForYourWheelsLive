using System;
using System.Data;
using System.Data.Common;

/// <summary>
/// Summary description for BAL_Paging
/// </summary>
public class BAL_Paging
{
    public BAL_Paging()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Get Records
    public static DataTable GetPagingInfo(int PageIndex, int PageSize, string OrderBy, out int TotalCount)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetPagingInfo";

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@PageIndex";
        param2.Value = PageIndex;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@PageSize";
        param3.Value = PageSize;
        param3.DbType = DbType.Int32;
        comm.Parameters.Add(param3);

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@OrderBy";
        param1.Value = OrderBy;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@TotalCount";
        param4.Direction = ParameterDirection.Output;
        param4.DbType = DbType.Int32;
        comm.Parameters.Add(param4);

        DataTable table = gda.ExecuteSelectCommand(comm);
        TotalCount = Convert.ToInt32(comm.Parameters["@TotalCount"].Value);
        return table;
    }

    public static DataTable SelectPagingInfo()
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "SelectPagingInfo";

        return gda.ExecuteSelectCommand(comm);
    }

    public static DataTable GetPageInfo()
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetPageInfo";

        return gda.ExecuteSelectCommand(comm);
    }
    #endregion

    #region Insert and Update Records
    public static bool InsertUpdatePagingInfo(int PagingId, int PageSize)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "InsertUpdatePagingInfo";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@PagingId";
        param1.Value = PagingId;
        param1.DbType = DbType.Int32;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@PageSize";
        param2.Value = PageSize;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }

    public static bool UpdatePageInfo(int AdminPageSize, int FrontPageSize)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "UpdatePageInfo";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@AdminPageSize";
        param1.Value = AdminPageSize;
        param1.DbType = DbType.Int32;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@FrontPageSize";
        param2.Value = FrontPageSize;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion

    #region Delete,Active and Deactive Info
    public static bool DeletePagingInfo(string PagingId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "DeletePagingInfo";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@PagingId";
        param1.Value = PagingId;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }

    public static bool ActivatePagingInfo(string PagingId, bool IsActive)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "ActivatePagingInfo";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@PagingId";
        param1.Value = PagingId;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@IsActive";
        param2.Value = IsActive;
        param2.DbType = DbType.Boolean;
        comm.Parameters.Add(param2);

        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion
}
