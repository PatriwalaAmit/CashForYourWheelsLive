using System;
using System.Data;
using System.Data.Common;

/// <summary>
/// Summary description for BAL_Customer
/// </summary>
public class BAL_Customer
{
    public BAL_Customer()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Get Records
    public static DataTable GetCustomerListForCustomer(int CustomerId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetCustomerListForCustomer";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@CustomerId";
        param1.Value = CustomerId;
        param1.DbType = DbType.Int32;
        comm.Parameters.Add(param1);

        // return the result table
        return gda.ExecuteSelectCommand(comm); ;
    }

    public static DataTable GetCustomerList(string FirstName, string LastName, string EmailId, int PageIndex, int PageSize, out int TotalCount)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "CustomerList_Select";

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
        param3.ParameterName = "@EmailId";
        param3.Value = EmailId;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);

        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@PageIndex";
        param4.Value = PageIndex;
        param4.DbType = DbType.Int32;
        comm.Parameters.Add(param4);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@PageSize";
        param5.Value = PageSize;
        param5.DbType = DbType.Int32;
        comm.Parameters.Add(param5);

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

    public static DataTable GetCustomerList()
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetCustomerForExport";

        // return the result table
        return gda.ExecuteSelectCommand(comm); ;
    }

    public static string GetTotalCustomerCount()
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetTotalCustomerCount";

        // return the result table
        return gda.ExecuteScalar(comm); ;
    }

    public static DataTable GetCustomerDetails(int PageIndex, int PageSize, string OrderBy, string FirstName, string LastName, string Email,
        string CountryId, string StateId, string ZipCode, out int TotalCount)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetCustomerList";

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
        param4.ParameterName = "@FirstName";
        param4.Value = FirstName;
        param4.DbType = DbType.String;
        comm.Parameters.Add(param4);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@LastName";
        param5.Value = LastName;
        param5.DbType = DbType.String;
        comm.Parameters.Add(param5);

        DbParameter param6 = comm.CreateParameter();
        param6.ParameterName = "@Email";
        param6.Value = Email;
        param6.DbType = DbType.String;
        comm.Parameters.Add(param6);

        DbParameter param7 = comm.CreateParameter();
        param7.ParameterName = "@CountryId";
        param7.Value = CountryId;
        param7.DbType = DbType.String;
        comm.Parameters.Add(param7);

        DbParameter param8 = comm.CreateParameter();
        param8.ParameterName = "@StateId";
        param8.Value = StateId;
        param8.DbType = DbType.String;
        comm.Parameters.Add(param8);

        DbParameter param9 = comm.CreateParameter();
        param9.ParameterName = "@ZipCode";
        param9.Value = ZipCode;
        param9.DbType = DbType.String;
        comm.Parameters.Add(param9);

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

    #endregion

    #region Insert records
    public static bool InsertCustomer(
        string FirstName, 
        string LastName, 
        char Sex, 
        string EmailId, 
        string Password,
        string BusinessName,
        string BAddress1, 
        string BAddress2, 
        string BCountryName, 
        string BStateName, 
        string BCityName, 
        string BZip, 
        string BPhone,
        string BFax,
        string BContactPerson,
        bool EmailVerification    
        )
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "Customer_Insert";

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
        param0.ParameterName = "@Sex";
        param0.Value = Sex;
        param0.DbType = DbType.String;
        comm.Parameters.Add(param0);

        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@EmailId";
        param4.Value = EmailId;
        param4.DbType = DbType.String;
        comm.Parameters.Add(param4);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@Password";
        param5.Value = Password;
        param5.DbType = DbType.String;
        comm.Parameters.Add(param5);

        DbParameter param8 = comm.CreateParameter();
        param8.ParameterName = "@BAddress1";
        param8.Value = BAddress1;
        param8.DbType = DbType.String;
        comm.Parameters.Add(param8);

        DbParameter param9 = comm.CreateParameter();
        param9.ParameterName = "@BAddress2";
        param9.Value = BAddress2;
        param9.DbType = DbType.String;
        comm.Parameters.Add(param9);

        DbParameter param10 = comm.CreateParameter();
        param10.ParameterName = "@BCountryName";
        param10.Value = BCountryName;
        param10.DbType = DbType.String;
        comm.Parameters.Add(param10);

        DbParameter param11 = comm.CreateParameter();
        param11.ParameterName = "@BStateName";
        param11.Value = BStateName;
        param11.DbType = DbType.String;
        comm.Parameters.Add(param11);

        DbParameter param12 = comm.CreateParameter();
        param12.ParameterName = "@BCityName";
        param12.Value = BCityName;
        param12.DbType = DbType.String;
        comm.Parameters.Add(param12);

        DbParameter param13 = comm.CreateParameter();
        param13.ParameterName = "@BZip";
        param13.Value = BZip;
        param13.DbType = DbType.String;
        comm.Parameters.Add(param13);

        DbParameter param14 = comm.CreateParameter();
        param14.ParameterName = "@BPhone";
        param14.Value = BPhone;
        param14.DbType = DbType.String;
        comm.Parameters.Add(param14);

        DbParameter param15 = comm.CreateParameter();
        param15.ParameterName = "@BusinessName";
        param15.Value = BusinessName;
        param15.DbType = DbType.String;
        comm.Parameters.Add(param15);

        DbParameter param16 = comm.CreateParameter();
        param16.ParameterName = "@BContactPerson";
        param16.Value = BContactPerson;
        param16.DbType = DbType.String;
        comm.Parameters.Add(param16);

        DbParameter param17 = comm.CreateParameter();
        param17.ParameterName = "@EmailVerification";
        param17.Value = EmailVerification;
        param17.DbType = DbType.String;
        comm.Parameters.Add(param17);

        DbParameter param18 = comm.CreateParameter();
        param18.ParameterName = "@BFax";
        param18.Value = BFax;
        param18.DbType = DbType.String;
        comm.Parameters.Add(param18);

        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }


    #endregion

    #region Update Customer
    public static bool UpdateCustomer(  string FirstName, 
        string LastName, 
        char Sex, 
        string EmailId, 
        string Password,
        string BusinessName,
        string BAddress1, 
        string BAddress2, 
        string BCountryName, 
        string BStateName, 
        string BCityName, 
        string BZip, 
        string BPhone,
        string BFax,
        string BContactPerson, int CustomerId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "Customer_Update";

        // create a new parameter
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
        param0.ParameterName = "@Sex";
        param0.Value = Sex;
        param0.DbType = DbType.String;
        comm.Parameters.Add(param0);

        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@EmailId";
        param4.Value = EmailId;
        param4.DbType = DbType.String;
        comm.Parameters.Add(param4);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@Password";
        param5.Value = Password;
        param5.DbType = DbType.String;
        comm.Parameters.Add(param5);

        DbParameter param8 = comm.CreateParameter();
        param8.ParameterName = "@BAddress1";
        param8.Value = BAddress1;
        param8.DbType = DbType.String;
        comm.Parameters.Add(param8);

        DbParameter param9 = comm.CreateParameter();
        param9.ParameterName = "@BAddress2";
        param9.Value = BAddress2;
        param9.DbType = DbType.String;
        comm.Parameters.Add(param9);

        DbParameter param10 = comm.CreateParameter();
        param10.ParameterName = "@BCountryName";
        param10.Value = BCountryName;
        param10.DbType = DbType.String;
        comm.Parameters.Add(param10);

        DbParameter param11 = comm.CreateParameter();
        param11.ParameterName = "@BStateName";
        param11.Value = BStateName;
        param11.DbType = DbType.String;
        comm.Parameters.Add(param11);

        DbParameter param12 = comm.CreateParameter();
        param12.ParameterName = "@BCityName";
        param12.Value = BCityName;
        param12.DbType = DbType.String;
        comm.Parameters.Add(param12);

        DbParameter param13 = comm.CreateParameter();
        param13.ParameterName = "@BZip";
        param13.Value = BZip;
        param13.DbType = DbType.String;
        comm.Parameters.Add(param13);

        DbParameter param14 = comm.CreateParameter();
        param14.ParameterName = "@BPhone";
        param14.Value = BPhone;
        param14.DbType = DbType.String;
        comm.Parameters.Add(param14);

        DbParameter param15 = comm.CreateParameter();
        param15.ParameterName = "@BusinessName";
        param15.Value = BusinessName;
        param15.DbType = DbType.String;
        comm.Parameters.Add(param15);

        DbParameter param16 = comm.CreateParameter();
        param16.ParameterName = "@BContactPerson";
        param16.Value = BContactPerson;
        param16.DbType = DbType.String;
        comm.Parameters.Add(param16);


        DbParameter param17 = comm.CreateParameter();
        param17.ParameterName = "@CustomerId";
        param17.Value = CustomerId;
        param17.DbType = DbType.String;
        comm.Parameters.Add(param17);

        DbParameter param18 = comm.CreateParameter();
        param18.ParameterName = "@BFax";
        param18.Value = BFax;
        param18.DbType = DbType.String;
        comm.Parameters.Add(param18);

        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion

    #region Delete Customer
    public static bool DeleteCustomerList(string CustomerId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "Customer_Delete";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@CustomerId";
        param1.Value = CustomerId;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        // return the result table
        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion

    #region Activete/Deactivate Customer
    public static bool ActivateCustomerList(string CustomerId, bool IsActivate)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "Customer_Activate";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@CustomerId";
        param1.Value = CustomerId;
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
    #endregion


    #region Check for Customer
    #region Check for User exist or not
    public static bool CheckForCustomer(string EmailId, int CustomerId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "CheckForCustomer";

        // create a new parameter
        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@EmailId";
        param2.Value = EmailId;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@CustomerId";
        param1.Value = CustomerId;
        param1.DbType = DbType.Int32;
        comm.Parameters.Add(param1);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@Flag";
        param3.Direction = ParameterDirection.Output;
        param3.DbType = DbType.Boolean;
        comm.Parameters.Add(param3);

        gda.ExecuteNonQuery(comm);
        return Convert.ToBoolean(comm.Parameters["@Flag"].Value);
    }
    #endregion
    #endregion

    public static bool CheckCustomerEmail(string EmailAddress)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "ssp_CustomerEmail";

        // create a new parameter
        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@email";
        param2.Value = EmailAddress;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@ret";
        param3.Direction = ParameterDirection.Output;
        param3.DbType = DbType.Boolean;
        comm.Parameters.Add(param3);

        gda.ExecuteNonQuery(comm);
        return Convert.ToBoolean(comm.Parameters["@ret"].Value);
       
    }


    public static int ResetUserPassword(string EmailAddress,string Password)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "usp_CustomerPasswordUsingEmailAddress";

        // create a new parameter
        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@email";
        param2.Value = EmailAddress;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@password";
        param3.Value = Password;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);
               
        return gda.ExecuteNonQuery(comm);;

    }


}
