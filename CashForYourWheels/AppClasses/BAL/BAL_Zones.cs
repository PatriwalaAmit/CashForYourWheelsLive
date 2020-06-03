using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.Common;

/// <summary>
/// Summary description for BAL_Zones
/// </summary>
public static class BAL_Zones
{
    public static Boolean VisitorTracking(string ipAddress)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "sp_twc_tracking";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@ipaddress";
        param1.Value = ipAddress;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@ret";
        param5.DbType = DbType.Int32;
        param5.Direction = ParameterDirection.Output;
        comm.Parameters.Add(param5);

        DataTable dt = gda.ExecuteSelectCommand(comm);

        if (dt.Rows.Count > 0)
        {
            int result = 0;

            foreach (DataRow dr in dt.Rows)
            {
                result = Convert.ToInt32(dr["result"]);
            }

            if (result > 0)
                return true;
            else
                return false;
        }
        else
        {
            return false;
        }
    }

    public static Boolean InsertUpdateZones(string operationtype, string zoneid, string zonename, string status)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "pcw_zones";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@operationtype";
        param1.Value = operationtype;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@zoneid";
        param2.Value = zoneid;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@zonename";
        param3.Value = zonename;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);

        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@status";
        param4.Value = status;
        param4.DbType = DbType.Int32;
        comm.Parameters.Add(param4);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@ret";
        param5.DbType = DbType.Int32;
        param5.Direction = ParameterDirection.Output;
        comm.Parameters.Add(param5);

        // return the result table
        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }

    public static Boolean DeleteZones(string operationtype, string zonesid)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "pcw_zones";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@operationtype";
        param1.Value = operationtype;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@zonesid";
        param2.Value = zonesid;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@ret";
        param5.DbType = DbType.Int32;
        param5.Direction = ParameterDirection.Output;
        comm.Parameters.Add(param5);

        // return the result table
        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }

    public static DataTable SelectZones(string optype, int zoneid)
    {
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "pcw_zones";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@operationtype";
        param.Value = optype;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@zoneId";
        param.Value = zoneid;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ret";
        param.DbType = DbType.Int32;
        param.Direction = ParameterDirection.Output;
        comm.Parameters.Add(param);

        // return the result table
        return gda.ExecuteSelectCommand(comm);
    }
}
