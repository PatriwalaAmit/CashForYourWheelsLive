using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;

/// <summary>
/// Summary description for BAL_BookAppointment
/// </summary>
public class BAL_BookAppointment
{
	public BAL_BookAppointment()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static DataTable GetAppointment(string strCarPlate, string strZipCode, string strEmail, int locationID)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "getAppointmentlist";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@carplate";
        param1.Value = strCarPlate;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@zipcode";
        param1.Value = strZipCode;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@emailaddress";
        param1.Value = strEmail;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@location";
        param1.Value = locationID;
        param1.DbType = DbType.Int16;
        comm.Parameters.Add(param1);
             
        // return the result table
        return gda.ExecuteSelectCommand(comm); 
    }

    public static bool UpdateAppointment(string appointmentid, string customername,string customerphonenumber,string customeremailaddress,string customerzipcode,string appdate,string apptime,string status,string CarPlate,string CarValuation, int locationID)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "UpdateApointment";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@AppointmentId";
        param1.Value = appointmentid;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);
        
        param1 = comm.CreateParameter();
        param1.ParameterName = "@CustomerName";
        param1.Value = customername;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@CustomerPhoneNumber";
        param1.Value = customerphonenumber;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@CustomerEmailAddress";
        param1.Value = customeremailaddress;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@CustomerZipCode";
        param1.Value = customerzipcode;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@AppointmentDate";
        param1.Value = appdate;
        param1.DbType = DbType.DateTime;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@AppointmentTime";
        param1.Value = apptime;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@CarPlate";
        param1.Value = CarPlate;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@status";
        param1.Value = status;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@CarValuation";
        param1.Value = CarValuation;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@locationID";
        param1.Value = locationID;
        param1.DbType = DbType.Int16;
        comm.Parameters.Add(param1);
        
        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;        
    }
}