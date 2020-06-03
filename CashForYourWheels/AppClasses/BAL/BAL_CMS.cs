using System;
using System.Data;
using System.Data.Common;


/// <summary>
/// Summary description for BAL_CMS
/// </summary>
public class BAL_CMS
{
    public BAL_CMS()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Get Records
    public static string GetTotalCMSCount()
    {
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "GetTotalCMSCount";

        return gda.ExecuteScalar(comm); ;
    }

    public static DataTable GetCMSByCMSId(int CMSId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetCMSListByCMSId";

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@CMSId";
        param2.Value = CMSId;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);


        // return the result table
        return gda.ExecuteSelectCommand(comm); ;
    }

    public static string GetDetailsByLinkName(string LinkName)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetDetailsByLinkName";

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@LinkName";
        param2.Value = LinkName;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);


        // return the result table
        return gda.ExecuteScalar(comm); ;
    }

    public static DataTable GetCMSInfo(int PageIndex, int PageSize, string OrderBy, out int TotalCount)
    {
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "GetCMSList";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@PageIndex";
        param1.Value = PageIndex;
        param1.DbType = DbType.Int32;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@PageSize";
        param2.Value = PageSize;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@OrderBy";
        param3.Value = OrderBy;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);

        DbParameter param7 = comm.CreateParameter();
        param7.ParameterName = "@TotalCount";
        param7.Direction = ParameterDirection.Output;
        param7.DbType = DbType.Int32;
        comm.Parameters.Add(param7);

        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        TotalCount = Convert.ToInt32(comm.Parameters["@TotalCount"].Value);
        return table;
    }
    #endregion

    #region Insert Records
    public static bool InsertCMS(string LinkName, string Desc)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "InsertCMS";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@LinkName";
        param1.Value = LinkName;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@Desc";
        param2.Value = Desc;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion

    #region Update Records
    public static bool UpdateCMS(string LinkName, string Desc, int CMSId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "UpdateCMS";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@LinkName";
        param1.Value = LinkName;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@Desc";
        param2.Value = Desc;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@CMSId";
        param3.Value = CMSId;
        param3.DbType = DbType.Int32;
        comm.Parameters.Add(param3);

        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }

    public static bool ActivateRecords(string CMSId, bool IsActive)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "ActivateCMS";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@CMSId";
        param1.Value = CMSId;
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

    #region Delete Records
    public static bool DeleteRecords(string CMSId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "DeleteCMS";

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@CMSId";
        param2.Value = CMSId;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion

}
