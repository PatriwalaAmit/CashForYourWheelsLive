using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;

/// <summary>
/// Summary description for BALBlockedAppointments
/// </summary>
public static class BALBlockedAppointments
{
    public static Boolean InsertUpdateBlockAppointment(string operationtype, string blockid, string blcokdate, string fromtime, string totime, string reason, string appblocksid, int status, int locationID, Boolean IsClosed)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "pcw_appblock";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@operationtype";
        param1.Value = operationtype;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@locationid";
        param1.Value = locationID;
        param1.DbType = DbType.Int16;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@appblockid";
        param2.Value = blockid;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        param2 = comm.CreateParameter();
        param2.ParameterName = "@appblockdate";
        param2.Value = blcokdate;
        param2.DbType = DbType.DateTime;
        comm.Parameters.Add(param2);

        param2 = comm.CreateParameter();
        param2.ParameterName = "@appblockfrom";
        param2.Value = fromtime;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        param2 = comm.CreateParameter();
        param2.ParameterName = "@appblockto";
        param2.Value = totime;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        param2 = comm.CreateParameter();
        param2.ParameterName = "@appblcokdesc";
        param2.Value = reason;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@appblocksid";
        param4.Value = appblocksid;
        param4.DbType = DbType.String;
        comm.Parameters.Add(param4);

        param4 = comm.CreateParameter();
        param4.ParameterName = "@status";
        param4.Value = status;
        param4.DbType = DbType.Int32;
        comm.Parameters.Add(param4);

        DbParameter param6 = comm.CreateParameter();
        param6.ParameterName = "@isclosed";
        param6.Value = IsClosed;
        param6.DbType = DbType.Boolean;
        comm.Parameters.Add(param6);

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

    public static DataTable SelectBlockAppointment(string optype, int blockid, int locationID)
    {
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "pcw_appblock";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@operationtype";
        param.Value = optype;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@appblockid";
        param.Value = blockid;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@locationid";
        param.Value = locationID;
        param.DbType = DbType.Int16;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ret";
        param.DbType = DbType.Int32;
        param.Direction = ParameterDirection.Output;
        comm.Parameters.Add(param);

        // return the result table
        return gda.ExecuteSelectCommand(comm);
    }

    public static DataTable SelectWebVisitor(string emailAddress, string carPlate)
    {
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "GetWebVisitor";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@EmailAddress";
        param.Value = emailAddress;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CarPlate";
        param.Value = carPlate;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);       

        // return the result table
        return gda.ExecuteSelectCommand(comm);
    }

    public static int DeleteWebVisitor(int WebVisitorId)
    {
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "DeleteWebVisitor";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@WebVisitorId";
        param.Value = WebVisitorId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // return the result table
        return gda.ExecuteNonQuery(comm);
    }
}