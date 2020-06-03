using System;
using System.Data.Common;
using System.Data;

/// <summary>
/// Summary description for BAL_DVR
/// </summary>
public class BAL_DVR
{
    public BAL_DVR()
    {

    }

    #region Get Admin List
    //public static string GetTotalDVRCount()
    //{
    //    // get a configured DbCommand object
    //    GenericDataAccess gda = new GenericDataAccess();

    //    DbCommand comm = gda.CreateCommand();

    //    // set the stored procedure name
    //    comm.CommandText = "GetTotalAdminCount";

    //    // return the result table
    //    return gda.ExecuteScalar(comm); ;
    //}


    //public static DataTable GetDVRList(
    //    string UserName, 
    //    string Email, 
    //    int PageIndex, 
    //    int PageSize, 
    //    out int TotalCount)
    //{
    //    // get a configured DbCommand object
    //    GenericDataAccess gda = new GenericDataAccess();

    //    DbCommand comm = gda.CreateCommand();

    //    // set the stored procedure name
    //    comm.CommandText = "GetAdminList_Select";

    //    // create a new parameter
    //    DbParameter param1 = comm.CreateParameter();
    //    param1.ParameterName = "@UserName";
    //    param1.Value = UserName;
    //    param1.DbType = DbType.String;
    //    comm.Parameters.Add(param1);

    //    // create a new parameter
    //    DbParameter param2 = comm.CreateParameter();
    //    param2.ParameterName = "@Email";
    //    param2.Value = Email;
    //    param2.DbType = DbType.String;
    //    comm.Parameters.Add(param2);

    //    DbParameter param3 = comm.CreateParameter();
    //    param3.ParameterName = "@PageIndex";
    //    param3.Value = PageIndex;
    //    param3.DbType = DbType.Int32;
    //    comm.Parameters.Add(param3);

    //    // create a new parameter
    //    DbParameter param4 = comm.CreateParameter();
    //    param4.ParameterName = "@PageSize";
    //    param4.Value = PageSize;
    //    param4.DbType = DbType.Int32;
    //    comm.Parameters.Add(param4);

    //    DbParameter param7 = comm.CreateParameter();
    //    param7.ParameterName = "@TotalCount";
    //    param7.Direction = ParameterDirection.Output;
    //    param7.DbType = DbType.Int32;
    //    comm.Parameters.Add(param7);

    //    // return the result table
    //    DataTable table = gda.ExecuteSelectCommand(comm);
    //    TotalCount = Convert.ToInt32(comm.Parameters["@TotalCount"].Value);
    //    return table;
    //}

    /// <summary>
    /// Get AdminList Details For Admin
    /// </summary>
    /// <param name="AdminId">Check Detail Of Admin Id</param>
    /// <returns>Return Admin Details</returns>
    public static DataTable GetDVRList(int IpPortInfoId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "GetIpPortInfoList_ByIpPortInfoId";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@IpPortInfoId";
        param.Value = IpPortInfoId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // return the result table
        return gda.ExecuteSelectCommand(comm); ;
    }

    public static DataTable GetDVRList(int AssignUser,bool frontend)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "GetIpPortInfoList_ByUser";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserId";
        param.Value = AssignUser;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // return the result table
        return gda.ExecuteSelectCommand(comm); ;
    }

    public static DataTable GetDVRList(
        string DeviceName,
        string DeviceModel,
        string CustomerName,
        string AssignByUser,
        string BusinessName,
        int PageIndex, 
        int PageSize, 
        string OrderBy, 
        out int TotalCount)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetIpPortInfoList";

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
        param3.ParameterName = "@CustomerName";
        param3.Value = CustomerName;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);

        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@AssignByUser";
        param4.Value = AssignByUser;
        param4.DbType = DbType.String;
        comm.Parameters.Add(param4);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@BusinessName";
        param5.Value = BusinessName;
        param5.DbType = DbType.String;
        comm.Parameters.Add(param5);

        DbParameter param6 = comm.CreateParameter();
        param6.ParameterName = "@PageIndex";
        param6.Value = PageIndex;
        param6.DbType = DbType.Int32;
        comm.Parameters.Add(param6);

        DbParameter param7 = comm.CreateParameter();
        param7.ParameterName = "@PageSize";
        param7.Value = PageSize;
        param7.DbType = DbType.Int32;
        comm.Parameters.Add(param7);
                
        DbParameter param8 = comm.CreateParameter();
        param8.ParameterName = "@OrderBy";
        param8.Value = OrderBy;
        param8.DbType = DbType.String;
        comm.Parameters.Add(param8);
              
        DbParameter param9 = comm.CreateParameter();
        param9.ParameterName = "@TotalCount";
        param9.Direction = ParameterDirection.Output;
        param9.DbType = DbType.Int32;
        comm.Parameters.Add(param9);

        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        TotalCount = Convert.ToInt32(comm.Parameters["@TotalCount"].Value);
        return table;
    }
    #endregion

    #region Update Admin List
    public static bool UpdateStatusForDVR(string IpPortInfoId, bool IsActive)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "IpPortInfo_Activate";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@IpPortInfoId";
        param.Value = IpPortInfoId;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@IsActivate";
        param1.Value = IsActive;
        param1.DbType = DbType.Boolean;
        comm.Parameters.Add(param1);

        // return the result table
        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion

    #region Delete Admin List
    public static bool DeleteDVRList(string IpPortInfoId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "IpPortInfo_Delete";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@IpPortInfoId";
        param.Value = IpPortInfoId;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        // return the result table
        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion

    #region Insert Admint List
    public static bool InsertDVRList(
        int AssignToUserId,
        int CameraDVRLink,
        string IPNumber,
        string PortNumber,
        string HtmlLink,
        int AssignByUserId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "InsertIpPortInfo";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@AssignToUserId";
        param1.Value = AssignToUserId;
        param1.DbType = DbType.Int32;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@CameraDVRLink";
        param2.Value = CameraDVRLink;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@IPNumber";
        param3.Value = IPNumber;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);

        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@PortNumber";
        param4.Value = PortNumber;
        param4.DbType = DbType.String;
        comm.Parameters.Add(param4);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@HtmlLink";
        param5.Value = HtmlLink;
        param5.DbType = DbType.String;
        comm.Parameters.Add(param5);

        DbParameter param6 = comm.CreateParameter();
        param6.ParameterName = "@AssignByUserId";
        param6.Value = AssignByUserId;
        param6.DbType = DbType.Int32;
        comm.Parameters.Add(param6);

        // return the result table
        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }

    #endregion

    #region Update admin list
    public static bool UpdateDVRList(
        int AssignToUserId,
        int CameraDVRLink,
        string IPNumber,
        string PortNumber,
        string HtmlLink,
        int AssignByUserId,
        int IpPortInfoId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "UpdateIpPortInfo";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@AssignToUserId";
        param1.Value = AssignToUserId;
        param1.DbType = DbType.Int32;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@CameraDVRLink";
        param2.Value = CameraDVRLink;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@IPNumber";
        param3.Value = IPNumber;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);

        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@PortNumber";
        param4.Value = PortNumber;
        param4.DbType = DbType.String;
        comm.Parameters.Add(param4);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@HtmlLink";
        param5.Value = HtmlLink;
        param5.DbType = DbType.String;
        comm.Parameters.Add(param5);

        DbParameter param6 = comm.CreateParameter();
        param6.ParameterName = "@AssignByUserId";
        param6.Value = AssignByUserId;
        param6.DbType = DbType.Int32;
        comm.Parameters.Add(param6);

        DbParameter param7 = comm.CreateParameter();
        param7.ParameterName = "@IpPortInfoId";
        param7.Value = IpPortInfoId;
        param7.DbType = DbType.String;
        comm.Parameters.Add(param7);

        // return the result table
        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion

    #region Check validation
    public static bool CheckDVRExist(int AssignToUserId,
        int CameraDVRLink,
        string IPNumber,
        string PortNumber,
        string HtmlLink,
        int AssignByUserId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "CheckIpPortInfoExist";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@AssignToUserId";
        param1.Value = AssignToUserId;
        param1.DbType = DbType.Int32;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@CameraDVRLink";
        param2.Value = CameraDVRLink;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@IPNumber";
        param3.Value = IPNumber;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);

        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@PortNumber";
        param4.Value = PortNumber;
        param4.DbType = DbType.String;
        comm.Parameters.Add(param4);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@HtmlLink";
        param5.Value = HtmlLink;
        param5.DbType = DbType.String;
        comm.Parameters.Add(param5);

        DbParameter param6 = comm.CreateParameter();
        param6.ParameterName = "@AssignByUserId";
        param6.Value = AssignByUserId;
        param6.DbType = DbType.Int32;
        comm.Parameters.Add(param6);

        DbParameter param7 = comm.CreateParameter();
        param7.ParameterName = "@Flag";
        param7.Direction = ParameterDirection.Output;
        param7.DbType = DbType.Boolean;
        comm.Parameters.Add(param7);

        // return the result table
        int n = gda.ExecuteNonQuery(comm);
        return Convert.ToBoolean(comm.Parameters["@Flag"].Value);
    }
    #endregion

}
