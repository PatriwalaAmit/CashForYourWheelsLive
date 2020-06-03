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
/// Summary description for BAL_UserLogin
/// </summary>
public class BAL_UserLogin
{
	public BAL_UserLogin()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static DataTable Login_Verify(string Email, string Password)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "UserLogin_Verify";

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


        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        return table;
    }
}
