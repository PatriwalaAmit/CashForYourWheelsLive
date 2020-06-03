using System;
using System.Data;
using System.Data.Common;


/// <summary>
/// Summary description for BAL_Registration
/// </summary>
public class BAL_Registration
{
    public BAL_Registration()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static bool EmailVerification(string EmailId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "usp_CustomerEmailVerification";

        // create a new parameter
        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@Email";
        param2.Value = EmailId;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@Flag";
        param3.Direction = ParameterDirection.Output;
        param3.DbType = DbType.Boolean;
        comm.Parameters.Add(param3);

        gda.ExecuteNonQuery(comm);
        return Convert.ToBoolean(comm.Parameters["@Flag"].Value);

    }


    #region Check for User exist or not
    public static bool CheckForUserRegistration(string EmailId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "CheckUserForRegistration";

        // create a new parameter
        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@EmailId";
        param2.Value = EmailId;
        param2.DbType = DbType.String;
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

    #region Insert UserInfo
    public static bool InsertUserInfo(       
        string FirstName, 
        string LastName, 
        string Sex, 
        string EmailId, 
        string Password,
        string BusinessName,
        string Address1, 
        string Address2, 
        string CountryId, 
        string StateId, 
        string CityId, 
        string ZipCode, 
        string PhoneNo,
        string Fax,
        string ContactPerson,
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

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@Sex";
        param3.Value = Sex;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);

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

        DbParameter param6 = comm.CreateParameter();
        param6.ParameterName = "@BusinessName";
        param6.Value = BusinessName;
        param6.DbType = DbType.String;
        comm.Parameters.Add(param6);      

        DbParameter param8 = comm.CreateParameter();
        param8.ParameterName = "@BAddress1";
        param8.Value = Address1;
        param8.DbType = DbType.String;
        comm.Parameters.Add(param8);

        DbParameter param9 = comm.CreateParameter();
        param9.ParameterName = "@BAddress2";
        param9.Value = Address2;
        param9.DbType = DbType.String;
        comm.Parameters.Add(param9);

        DbParameter param10 = comm.CreateParameter();
        param10.ParameterName = "@BCountryName";
        param10.Value = CountryId;
        param10.DbType = DbType.String;
        comm.Parameters.Add(param10);

        DbParameter param11 = comm.CreateParameter();
        param11.ParameterName = "@BStateName";
        param11.Value = StateId;
        param11.DbType = DbType.String;
        comm.Parameters.Add(param11);

        DbParameter param12 = comm.CreateParameter();
        param12.ParameterName = "@BCityName";
        param12.Value = CityId;
        param12.DbType = DbType.String;
        comm.Parameters.Add(param12);

        DbParameter param13 = comm.CreateParameter();
        param13.ParameterName = "@BZip";
        param13.Value = ZipCode;
        param13.DbType = DbType.String;
        comm.Parameters.Add(param13);

        DbParameter param14 = comm.CreateParameter();
        param14.ParameterName = "@BPhone";
        param14.Value = PhoneNo;
        param14.DbType = DbType.String;
        comm.Parameters.Add(param14);

        DbParameter param15 = comm.CreateParameter();
        param15.ParameterName = "@BFax";
        param15.Value = Fax;
        param15.DbType = DbType.String;
        comm.Parameters.Add(param15);

        DbParameter param16 = comm.CreateParameter();
        param16.ParameterName = "@BContactPerson";
        param16.Value = ContactPerson;
        param16.DbType = DbType.String;
        comm.Parameters.Add(param16);

        DbParameter param17 = comm.CreateParameter();
        param17.ParameterName = "@EmailVerification";
        param17.Value = EmailVerification;
        param17.DbType = DbType.Boolean;
        comm.Parameters.Add(param17);

        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion

    #region Get Records
    public static DataTable GetRecordsForUser(int CustomerId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetCustomerListByCustomerId";

        // create a new parameter
        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@CustomerId";
        param2.Value = CustomerId;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);

        //return datatable
        return gda.ExecuteSelectCommand(comm);
    }
    #endregion

    #region Update records
    public static bool UpdateUserInfo(string FirstName, 
        string LastName, 
        string Sex, 
        string EmailId,         
        string BusinessName,
        string Address1, 
        string Address2, 
        string CountryId, 
        string StateId, 
        string CityId, 
        string ZipCode, 
        string PhoneNo,
        string Fax,
        string ContactPerson, int CustomerId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "Customer_Update";

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
        param4.ParameterName = "@EmailId";
        param4.Value = EmailId;
        param4.DbType = DbType.String;
        comm.Parameters.Add(param4);

        DbParameter param6 = comm.CreateParameter();
        param6.ParameterName = "@BusinessName";
        param6.Value = BusinessName;
        param6.DbType = DbType.String;
        comm.Parameters.Add(param6);

        DbParameter param8 = comm.CreateParameter();
        param8.ParameterName = "@BAddress1";
        param8.Value = Address1;
        param8.DbType = DbType.String;
        comm.Parameters.Add(param8);

        DbParameter param9 = comm.CreateParameter();
        param9.ParameterName = "@BAddress2";
        param9.Value = Address2;
        param9.DbType = DbType.String;
        comm.Parameters.Add(param9);

        DbParameter param10 = comm.CreateParameter();
        param10.ParameterName = "@BCountryName";
        param10.Value = CountryId;
        param10.DbType = DbType.String;
        comm.Parameters.Add(param10);

        DbParameter param11 = comm.CreateParameter();
        param11.ParameterName = "@BStateName";
        param11.Value = StateId;
        param11.DbType = DbType.String;
        comm.Parameters.Add(param11);

        DbParameter param12 = comm.CreateParameter();
        param12.ParameterName = "@BCityName";
        param12.Value = CityId;
        param12.DbType = DbType.String;
        comm.Parameters.Add(param12);

        DbParameter param13 = comm.CreateParameter();
        param13.ParameterName = "@BZip";
        param13.Value = ZipCode;
        param13.DbType = DbType.String;
        comm.Parameters.Add(param13);

        DbParameter param14 = comm.CreateParameter();
        param14.ParameterName = "@BPhone";
        param14.Value = PhoneNo;
        param14.DbType = DbType.String;
        comm.Parameters.Add(param14);

        DbParameter param15 = comm.CreateParameter();
        param15.ParameterName = "@BFax";
        param15.Value = Fax;
        param15.DbType = DbType.String;
        comm.Parameters.Add(param15);

        DbParameter param16 = comm.CreateParameter();
        param16.ParameterName = "@BContactPerson";
        param16.Value = ContactPerson;
        param16.DbType = DbType.String;
        comm.Parameters.Add(param16);        

        DbParameter param18 = comm.CreateParameter();
        param18.ParameterName = "@CustomerId";
        param18.Value = CustomerId;
        param18.DbType = DbType.Int32;
        comm.Parameters.Add(param18);

        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion

    #region Chenge Customer password
    public static bool ChangeCustomerPassword(string OldPassword, string NewPassword, int CustomerId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "ChangeCustomerPassword";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@OldPassword";
        param1.Value = OldPassword;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@NewPassword";
        param2.Value = NewPassword;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@CustomerId";
        param3.Value = CustomerId;
        param3.DbType = DbType.Int32;
        comm.Parameters.Add(param3);

        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion
}
