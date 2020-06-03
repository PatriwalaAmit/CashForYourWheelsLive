using System;
using System.Data;
using System.Data.Common;


/// <summary>
/// Summary description for BAL_MailList
/// </summary>
/// 
public class BAL_MailList
{
    public BAL_MailList()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    #region Get Records
    public static DataTable GetMailListByMailId(int MailId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetMailListByMailId";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@MailId";
        param1.Value = MailId;
        param1.DbType = DbType.Int32;
        comm.Parameters.Add(param1);

        // return the result table
        return gda.ExecuteSelectCommand(comm);
    }

    public static string GetTotalMailCount()
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        comm.CommandText = "GetTotalMailCount";

        return gda.ExecuteScalar(comm);
    }

    public static DataTable GetMailInfoDetails(int PageIndex, int PageSize, string OrderBy, string SenderName, string SenderEmail, string ReceiverName,
        string ReceiverEmail, string SendDate,out int TotalCount)
    {
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetMailList";

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
        param4.ParameterName = "@SenderName";
        param4.Value = SenderName;
        param4.DbType = DbType.String;
        comm.Parameters.Add(param4);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@SenderEmail";
        param5.Value = SenderEmail;
        param5.DbType = DbType.String;
        comm.Parameters.Add(param5);

        DbParameter param6 = comm.CreateParameter();
        param6.ParameterName = "@ReceiverName";
        param6.Value = ReceiverName;
        param6.DbType = DbType.String;
        comm.Parameters.Add(param6);

        DbParameter param7 = comm.CreateParameter();
        param7.ParameterName = "@ReceiverEmail";
        param7.Value = ReceiverEmail;
        param7.DbType = DbType.String;
        comm.Parameters.Add(param7);

        DbParameter param8 = comm.CreateParameter();
        param8.ParameterName = "@SendDate";
        param8.Value = SendDate;
        param8.DbType = DbType.String;
        comm.Parameters.Add(param8);

        DbParameter param9 = comm.CreateParameter();
        param9.ParameterName = "@TotalCount";
        param9.Direction = ParameterDirection.Output;
        param9.DbType = DbType.Int32;
        comm.Parameters.Add(param9);

        // return the result table
        DataTable table= gda.ExecuteSelectCommand(comm);
        TotalCount = Convert.ToInt32(comm.Parameters["@TotalCount"].Value);
        return table;
    }
    #endregion

    #region Delete Records
    public static bool DeleteMailList(string MailId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "DeleteMailList";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@MailId";
        param1.Value = MailId;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        // return the result
        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion

    #region Insert Records
    public static bool InsertMailList(string SenderName, string SenderEmail, string ReceiverName, string ReceiverEmail, string Message)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "InsertMailList";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@SenderName";
        param1.Value = SenderName;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@SenderEmail";
        param2.Value = SenderEmail;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@ReceiverName";
        param3.Value = ReceiverName;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);

        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@ReceiverEmail";
        param4.Value = ReceiverEmail;
        param4.DbType = DbType.String;
        comm.Parameters.Add(param4);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@Message";
        param5.Value = Message;
        param5.DbType = DbType.String;
        comm.Parameters.Add(param5);

        // return the result
        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion
}
