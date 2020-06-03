using System;
using System.Data.Common;
using System.Data;

/// <summary>
/// Summary description for BAL_AdminList
/// </summary>
public class BAL_AdminList
{
    public BAL_AdminList()
    {

    }

    #region Get Admin List
    public static string GetTotalAdminCount()
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetTotalAdminCount";

        // return the result table
        return gda.ExecuteScalar(comm); ;
    }


    public static DataTable GetAdminList(string UserName, string Email, int PageIndex, int PageSize, out int TotalCount)
    {
        return GetAdminDetails(string.Empty, string.Empty, Email, PageIndex, PageSize, "", out TotalCount, "getadminlist", 1,0); ;
    }

    /// <summary>
    /// Get AdminList Details For Admin
    /// </summary>
    /// <param name="AdminId">Check Detail Of Admin Id</param>
    /// <returns>Return Admin Details</returns>
    public static DataTable GetAdminList(int AdminId)
    {
        int TotalCount =0;
        return GetAdminDetails("", "", "",0, 0, "", out TotalCount, "UserListById", 1, AdminId);
    }

    public static DataTable GetAdminDetails(string FirstName, string LastName, string Email, int PageIndex, int PageSize, string OrderBy, out int TotalCount,string operationtype,int UserTypeId,int UserId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "cw_UserDetails";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@FirstName";
        param1.Value = FirstName;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@LastName";
        param2.Value = LastName;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param0 = comm.CreateParameter();
        param0.ParameterName = "@Email";
        param0.Value = Email;
        param0.DbType = DbType.String;
        comm.Parameters.Add(param0);

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

        DbParameter param6 = comm.CreateParameter();
        param6.ParameterName = "@OrderBy";
        param6.Value = OrderBy;
        param6.DbType = DbType.String;
        comm.Parameters.Add(param6);

        DbParameter param7 = comm.CreateParameter();
        param7.ParameterName = "@TotalCount";
        param7.Direction = ParameterDirection.Output;
        param7.DbType = DbType.Int32;
        comm.Parameters.Add(param7);

        DbParameter param8 = comm.CreateParameter();
        param8.ParameterName = "@OperationType";
        param8.Value = operationtype;
        param8.DbType = DbType.String;
        comm.Parameters.Add(param8);

        DbParameter param9 = comm.CreateParameter();
        param9.ParameterName = "@UserTypeId";
        param9.Value = UserTypeId;
        param9.DbType = DbType.Int32;
        comm.Parameters.Add(param9);

        DbParameter param10 = comm.CreateParameter();
        param10.ParameterName = "@UserId";
        param10.Value = UserId;
        param10.DbType = DbType.Int32;
        comm.Parameters.Add(param10);

        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        TotalCount = Convert.ToInt32(comm.Parameters["@TotalCount"].Value == DBNull.Value ? 0 : comm.Parameters["@TotalCount"].Value);
        return table;
    }
    #endregion

    #region Update Admin List
    public static bool UpdateStatusForAdmin(string AdminId, bool IsActive)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "UpdateStatusForAdmin";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@AdminId";
        param.Value = AdminId;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@IsActive";
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
    public static bool DeleteAdminList(string AdminId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "DeleteAdminList";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@AdminId";
        param.Value = AdminId;
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
    public static bool InsertAdminList(string FirstName, string LastName, string Sex, string Email, string Password, string PhoneNo)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "InsertAdminList";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@FirstName";
        param1.Value = FirstName;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@LastName";
        param2.Value = LastName;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@Sex";
        param3.Value = Sex;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);

        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@Email";
        param4.Value = Email;
        param4.DbType = DbType.String;
        comm.Parameters.Add(param4);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@Password";
        param5.Value = Password;
        param5.DbType = DbType.String;
        comm.Parameters.Add(param5);

        DbParameter param6 = comm.CreateParameter();
        param6.ParameterName = "@PhoneNo";
        param6.Value = PhoneNo;
        param6.DbType = DbType.String;
        comm.Parameters.Add(param6);

        // return the result table
        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }

    #endregion

    #region Update admin list
    public static bool UpdateAdminList(string FirstName, string LastName, string Sex, string Email, string Password, string PhoneNo, int AdminId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "UpdateAdminList";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@FirstName";
        param1.Value = FirstName;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@LastName";
        param2.Value = LastName;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@Sex";
        param3.Value = Sex;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);

        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@Email";
        param4.Value = Email;
        param4.DbType = DbType.String;
        comm.Parameters.Add(param4);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@Password";
        param5.Value = Password;
        param5.DbType = DbType.String;
        comm.Parameters.Add(param5);

        DbParameter param6 = comm.CreateParameter();
        param6.ParameterName = "@PhoneNo";
        param6.Value = PhoneNo;
        param6.DbType = DbType.String;
        comm.Parameters.Add(param6);

        DbParameter param7 = comm.CreateParameter();
        param7.ParameterName = "@AdminId";
        param7.Value = AdminId;
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
    public static bool CheckAdminExist(string EmailId, int AdminId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "CheckAdminExist";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@EmailId";
        param.Value = EmailId;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@AdminId";
        param2.Value = AdminId;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@Flag";
        param1.Direction = ParameterDirection.Output;
        param1.DbType = DbType.Boolean;
        comm.Parameters.Add(param1);

        // return the result table
        int n = gda.ExecuteNonQuery(comm);
        return Convert.ToBoolean(comm.Parameters["@Flag"].Value);
    }
    #endregion

}
