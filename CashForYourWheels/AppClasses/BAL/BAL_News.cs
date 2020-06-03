using System;
using System.Data;
using System.Data.Common;


/// <summary>
/// Summary description for BAL_News
/// </summary>
public class BAL_News
{
    public BAL_News()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Get Records
    public static string GetTotalNewsCount()
    {
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "GetTotalNewsCount";
        return gda.ExecuteScalar(comm);
    }

    public static DataTable GetNewsEventsList(string Title)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "News_Select";

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@Title";
        param2.Value = Title;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);


        // return the result table
        return gda.ExecuteSelectCommand(comm); ;
    }

    public static DataTable GetNewsEventsListForNewsId(int NewsId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetNewsByNewsId";

        //creat param
        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@NewsId";
        param2.Value = NewsId;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        // return the result table
        return gda.ExecuteSelectCommand(comm); ;
    }

    public static DataTable GetNewsEventsList(int Page, out int howManyPages, int VSPagerSize)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetNews";

        //
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@PageNumber";
        param1.Value = Page;
        param1.DbType = DbType.Int32;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@HowMany";
        param2.Direction = ParameterDirection.Output;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@DataPerPage";
        param3.Value = VSPagerSize;
        param3.DbType = DbType.Int32;
        comm.Parameters.Add(param3);


        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        howManyPages = (int)Math.Ceiling((decimal)(Convert.ToInt32(comm.Parameters["@HowMany"].Value)) / VSPagerSize);
        return table;
    }

    public static DataTable GetNewsDetails(string Title, int PageIndex, int PageSize, out int TotalCount)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "News_Select";

        //
        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@Title";
        param2.Value = Title;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param0 = comm.CreateParameter();
        param0.ParameterName = "@PageIndex";
        param0.Value = PageIndex;
        param0.DbType = DbType.Int32;
        comm.Parameters.Add(param0);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@PageSize";
        param3.Value = PageSize;
        param3.DbType = DbType.Int32;
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

    public static DataTable GetNewsListInfo(int PageIndex, int PageSize, string OrderBy, string Title, string NewsDate, out int TotalCount)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetNewsList";

        //create param
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
        param3.ParameterName = "@Title";
        param3.Value = Title;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);

        DbParameter param0 = comm.CreateParameter();
        param0.ParameterName = "@OrderBy";
        param0.Value = OrderBy;
        param0.DbType = DbType.String;
        comm.Parameters.Add(param0);

        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@NewsDate";
        param4.Value = NewsDate;
        param4.DbType = DbType.String;
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

    #endregion

    #region Delete News\Events
    public static bool DeleteNews(string NewsId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "DeleteNews";

        //creat param
        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@NewsId";
        param2.Value = NewsId;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion

    #region Active deactive news list
    //ActivateNews
    public static bool ActivateNews(string NewsId, bool IsActive)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "ActivateNews";

        //creat param
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@NewsId";
        param1.Value = NewsId;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@IsActive";
        param2.Value = IsActive;
        param2.DbType = DbType.Boolean;
        comm.Parameters.Add(param2);

        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion

    #region Insert Records
    public static bool InsertNews(string Title, string Desc, string Link, DateTime NewsDate)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "InsertNews";

        //creat param
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@Title";
        param1.Value = Title;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@Desc";
        param2.Value = Desc;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@Link";
        param3.Value = Link;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@NewsDate";
        param5.Value = NewsDate;
        param5.DbType = DbType.DateTime;
        comm.Parameters.Add(param5);

        // return the result
        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion

    #region Update Records
    public static bool UpdateNews(string Title, string Desc, string Link, DateTime NewsDate, int NewsId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "UpdateNews";

        //creat param
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@Title";
        param1.Value = Title;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@Desc";
        param2.Value = Desc;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@Link";
        param3.Value = Link;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@NewsDate";
        param5.Value = NewsDate;
        param5.DbType = DbType.DateTime;
        comm.Parameters.Add(param5);

        DbParameter param6 = comm.CreateParameter();
        param6.ParameterName = "@NewsId";
        param6.Value = NewsId;
        param6.DbType = DbType.Int32;
        comm.Parameters.Add(param6);

        // return the result
        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion

    #region Check Validation
    public static bool CheckForNews(string Title, int NewsId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "CheckForNews";

        //creat param
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@Title";
        param1.Value = Title;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@NewsId";
        param2.Value = NewsId;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@Flag";
        param3.Direction = ParameterDirection.Output;
        param3.DbType = DbType.Boolean;
        comm.Parameters.Add(param3);

        gda.ExecuteNonQuery(comm);
        return Convert.ToBoolean(comm.Parameters["@Flag"].Value);
    }
    #endregion
}
