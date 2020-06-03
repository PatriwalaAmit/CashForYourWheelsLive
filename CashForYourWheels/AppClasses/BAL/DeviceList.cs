using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Common;

/// <summary>
/// Summary description for DeviceList
/// </summary>
public class DeviceList
{
	public DeviceList()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static DataTable GetDeviceList(string DeviceName, string DeviceModel, int PageIndex, int PageSize, out int TotalCount)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetDeviceList_Select";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@DeviceName";
        param1.Value = DeviceName;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        // create a new parameter
        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@DeviceModel";
        param2.Value = DeviceModel;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@PageIndex";
        param3.Value = PageIndex;
        param3.DbType = DbType.Int32;
        comm.Parameters.Add(param3);

        // create a new parameter
        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@PageSize";
        param4.Value = PageSize;
        param4.DbType = DbType.Int32;
        comm.Parameters.Add(param4);

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

    public static bool CheckDeviceExist(string DeviceName)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "CheckDeviceExist";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DeviceName";
        param.Value = DeviceName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@Flag";
        param1.Direction = ParameterDirection.Output;
        param1.DbType = DbType.Boolean;
        comm.Parameters.Add(param1);

        // return the result table
        int n = gda.ExecuteNonQuery(comm);
        return Convert.ToBoolean(comm.Parameters["@Flag"].Value);
    }

    public static bool InsertDeviceList(string DeviceName, string DeviceModel, string ImagePath)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "InsertDeviceList";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@DeviceName";
        param1.Value = DeviceName;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@DeviceModel";
        param2.Value = DeviceModel;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@pic";
        param3.Value = ImagePath;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);
             

        // return the result table
        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }


    public static bool UpdateDeviceList(string DeviceName, string DeviceModel, string Pic, int DeviceInfoId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "UpdateDeviceList";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@DeviceName";
        param1.Value = DeviceName;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@DeviceModel";
        param2.Value = DeviceModel;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@Pic";
        param3.Value = Pic;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);
     
        DbParameter param7 = comm.CreateParameter();
        param7.ParameterName = "@DeviceId";
        param7.Value = DeviceInfoId;
        param7.DbType = DbType.String;
        comm.Parameters.Add(param7);

        // return the result table
        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }

    public static DataTable GetDeviceList(int DeviceId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetDeviceList_ByDeviceId";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DeviceId";
        param.Value = DeviceId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // return the result table
        return gda.ExecuteSelectCommand(comm); ;
    }

    public static DataTable GetDeviceList(string DeviceName, string DeviceModel, int PageIndex, int PageSize, string OrderBy, out int TotalCount)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetDeviceList";

        //create param here
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

        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@DeviceName";
        param4.Value = DeviceName;
        param4.DbType = DbType.String;
        comm.Parameters.Add(param4);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@DeviceModel";
        param5.Value = DeviceModel;
        param5.DbType = DbType.String;
        comm.Parameters.Add(param5);
               
        DbParameter param11 = comm.CreateParameter();
        param11.ParameterName = "@TotalCount";
        param11.Direction = ParameterDirection.Output;
        param11.DbType = DbType.Int32;
        comm.Parameters.Add(param11);

        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        TotalCount = Convert.ToInt32(comm.Parameters["@TotalCount"].Value);
        return table;
    }

    public static bool ActivateDeviceList(string DeviceInfoId, bool IsActivate)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "Device_Activate";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@DeviceInfoId";
        param1.Value = DeviceInfoId;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@IsActivate";
        param2.Value = IsActivate;
        param2.DbType = DbType.Boolean;
        comm.Parameters.Add(param2);

        // return the result table
        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }

    public static bool DeleteDeviceList(string DeviceId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "Device_Delete";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@DeviceId";
        param1.Value = DeviceId;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        // return the result table
        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }

    public static DataTable GetDeviceList()
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetDeviceForExport";

        // return the result table
        return gda.ExecuteSelectCommand(comm); ;
    }


}
