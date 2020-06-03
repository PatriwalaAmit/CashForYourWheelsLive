using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.Common;

/// <summary>
/// Summary description for BAL_Whitelistips
/// </summary>
public class BAL_Whitelistips
{
    #region Get Records
    
    public static DataTable GetById(int CMSId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "GetWhiteIpListBylocationId";
        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@id";
        param2.Value = CMSId;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);
        return gda.ExecuteSelectCommand(comm); ;
    }
    
    public static DataTable GetCMSInfo(int PageIndex, int PageSize, string OrderBy, out int TotalCount)
    {
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "GetIPList";

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
    public static bool InsertCMS(string IpAddress)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "InsertWhitelistIPs";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@IPAddress";
        param1.Value = IpAddress;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);        

        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion

    #region Update Records
    public static bool UpdateCMS(int id,string IpAddress, string Status)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "UpdateWhitelistIps";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@Id";
        param1.Value = id;
        param1.DbType = DbType.Int32;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@IpAddress";
        param1.Value = IpAddress;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);      

        param1 = comm.CreateParameter();
        param1.ParameterName = "@status";
        param1.Value = Status;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }

    public static bool ActivateRecords(string Id, int IsActive)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "ActivateWhitelistIps";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@Id";
        param1.Value = Id;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@status";
        param2.Value = IsActive;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion

    #region Delete Records
    public static bool DeleteRecords(string LocationId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "DeleteWhitelistIps";

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@Id";
        param2.Value = LocationId;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }

    #endregion
}
