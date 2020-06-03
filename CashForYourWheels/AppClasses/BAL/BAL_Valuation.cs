using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Web;
using System.Configuration;
using log4net;

/// <summary>
/// Summary description for BAL_Valuation
/// </summary>
public class BAL_Valuation
{
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public BAL_Valuation()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string GetValAdjustmentXML()
    {
        string valXml = string.Empty;

        try
        {
            using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandText = "SELECT id, resourceData FROM tcw_Resources WHERE resourceName='ValAdjustment'";
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlConn;

                sqlConn.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    valXml = reader.GetString(1);
                }
                sqlConn.Close();
            }
        }
        catch (Exception ex)
        {
            log.Error("Error in AdjXML", ex);
        }

        return valXml;
    }

    public static string GetValuation(string uvtid, int year, int month,string mileage,string session)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "valuation_process";

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@UVTID";
        param2.Value = uvtid;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        param2 = comm.CreateParameter();
        param2.ParameterName = "@Year";
        param2.Value = year;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        param2 = comm.CreateParameter();
        param2.ParameterName = "@Month";
        param2.Value = month;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        param2 = comm.CreateParameter();
        param2.ParameterName = "@Mileage";
        param2.Value = mileage;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);            

        // return the result table
        return gda.ExecuteScalar(comm);
    }

    public static DataTable GetValuation(string uvtid, int year, int month, string mileage)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "valuation_process";

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@UVTID";
        param2.Value = uvtid;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        param2 = comm.CreateParameter();
        param2.ParameterName = "@Year";
        param2.Value = year;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        param2 = comm.CreateParameter();
        param2.ParameterName = "@Month";
        param2.Value = month;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        param2 = comm.CreateParameter();
        param2.ParameterName = "@Mileage";
        param2.Value = mileage;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);        

        // return the result table
        return gda.ExecuteSelectCommand(comm);
    }

    public static DataTable GetValuationAdmin(string uvtid, int year, int month, string mileage, string ValuationType)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "valuation_process_admin";

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@UVTID";
        param2.Value = uvtid;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        param2 = comm.CreateParameter();
        param2.ParameterName = "@ValuationType";
        param2.Value = ValuationType;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        param2 = comm.CreateParameter();
        param2.ParameterName = "@Year";
        param2.Value = year;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        param2 = comm.CreateParameter();
        param2.ParameterName = "@Month";
        param2.Value = month;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        param2 = comm.CreateParameter();
        param2.ParameterName = "@Mileage";
        param2.Value = mileage;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        // return the result table
        return gda.ExecuteSelectCommand(comm);
    }
}