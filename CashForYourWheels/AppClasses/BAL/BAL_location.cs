using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;

/// <summary>
/// Summary description for BAL_location
/// </summary>
public class BAL_location
{
	public BAL_location()
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
        comm.CommandText = "GetLocationListBylocationId";

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@locationid";
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
        comm.CommandText = "GetLocationList";

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
    public static bool InsertCMS(string LocationName, string LocationDetails, string PhoneNumber, string CellNumber, string EmailAddress, string Status)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "InsertLocation";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@LocationName";
        param1.Value = LocationName;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@LocationDetails";
        param1.Value = LocationDetails;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@Phonenumber";
        param1.Value = PhoneNumber;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@cellnumber";
        param1.Value = CellNumber;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@emailaddress";
        param1.Value = EmailAddress;
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
    #endregion

    #region Update Records
    public static bool UpdateCMS(int locationid, string LocationName, string LocationDetails, string PhoneNumber, string CellNumber, string EmailAddress, string Status)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "UpdateLocation";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@LocationId";
        param1.Value = locationid;
        param1.DbType = DbType.Int32;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@LocationName";
        param1.Value = LocationName;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@LocationDetails";
        param1.Value = LocationDetails;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@Phonenumber";
        param1.Value = PhoneNumber;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@cellnumber";
        param1.Value = CellNumber;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@emailaddress";
        param1.Value = EmailAddress;
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

    public static bool ActivateRecords(string LocationId, int IsActive)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "ActivateLocation";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@LocationId";
        param1.Value = LocationId;
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
        comm.CommandText = "DeleteLocation";

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@LocationId";
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