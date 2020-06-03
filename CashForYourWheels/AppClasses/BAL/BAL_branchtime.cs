using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;

/// <summary>
/// Summary description for BAL_branchtime
/// </summary>
public class BAL_branchtime
{
	public BAL_branchtime()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static DataTable GetTiming(string locationid)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetWorkingHoursById";

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@LocationId";
        param2.Value = locationid;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);
        // return the result table
        return gda.ExecuteSelectCommand(comm); 
    }

    public static bool UpdateTiming(string LocationId,string WorkingHoursFrom,string WorkingHoursTo,string WorkingDay)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "UpdateWorkingHours";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@LocationId";
        param1.Value = LocationId;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@WorkingDay";
        param1.Value = WorkingDay;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@WorkingHoursFrom";
        param1.Value = WorkingHoursFrom;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@WorkingHoursTo";
        param1.Value = WorkingHoursTo;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@Status";
        param1.Value = 0;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);
                
        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
}