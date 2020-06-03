using System;
using System.Data.Common;
using System.Data;

/// <summary>
/// Summary description for BAL_Login
/// </summary>
public class BAL_Login
{
	public BAL_Login()
	{
		
	}
    public static DataTable Login_Verify(string Email , string Password,string OperationType,int UserType)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "cw_UserDetails";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Email";
        param.Value = Email;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Password";
        param.Value = Password;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@OperationType";
        param.Value = OperationType;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@UserTypeId";
        param.Value = UserType;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
              
        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;
    }

    public static bool ChangePassword(int UserID, string Old, string New)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "ChangePassword";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = UserID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@OldPassword";
        param.Value = Old;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@NewPassword";
        param.Value = New;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        int retval = gda.ExecuteNonQuery(comm);

        if (retval > 0)
            return true;
        else
            return false;
    }
}
