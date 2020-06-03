using System;
using System.Data;
using System.Data.Common;

/// <summary>
/// Summary description for BAL_Supplier
/// </summary>
public class BAL_Supplier
{
    public BAL_Supplier()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Select Recors
    public static string GetTotalSupplierCount()
    {
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        comm.CommandText = "GetTotalSupplierCount";

        return gda.ExecuteScalar(comm);
    }

    public static DataTable GetSupplier_PopUp(int SupplierId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "Supplier_Select_Popup";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@SupplierId";
        param1.Value = SupplierId;
        param1.DbType = DbType.Int32;
        comm.Parameters.Add(param1);

        // return the result table

        return gda.ExecuteSelectCommand(comm);
    }

    public static DataTable GetSupplier(string Account, string FirstName, string Email, int PageIndex, int PageSize, out int TotalCount)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "Supplier_Select";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@Account";
        param1.Value = Account;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@FirstName";
        param2.Value = FirstName;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@Email";
        param3.Value = Email;
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

    public static DataTable GetSupplier_City(int StateId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "Supplier_Select_City";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@StateId";
        param.Value = StateId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // return the result table
        return gda.ExecuteSelectCommand(comm);
    }

    public static DataTable GetSupplier_State(int CountryId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "Supplier_Select_State";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CountryID";
        param.Value = CountryId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // return the result table
        return gda.ExecuteSelectCommand(comm);

    }

    public static DataTable GetSupplier_Country()
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "Supplier_Select_Country";

        // return the result table
        return gda.ExecuteSelectCommand(comm);
    }

    public static DataTable GetSupplierListInfo(int PageIndex, int PageSize, string OrderBy, string CompanyName,
        string AccountNo, string FirstName, string LastName, out int TotalCount)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetSupplier";

        // create a new parameter
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
        param3.DbType = DbType.String ;
        comm.Parameters.Add(param3);

        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@CompanyName";
        param4.Value = CompanyName;
        param4.DbType = DbType.String;
        comm.Parameters.Add(param4);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@AccountNo";
        param5.Value = AccountNo;
        param5.DbType = DbType.String;
        comm.Parameters.Add(param5);

        DbParameter param6 = comm.CreateParameter();
        param6.ParameterName = "@FirstName";
        param6.Value = FirstName;
        param6.DbType = DbType.String;
        comm.Parameters.Add(param6);

        DbParameter param7 = comm.CreateParameter();
        param7.ParameterName = "@LastName";
        param7.Value = LastName;
        param7.DbType = DbType.String;
        comm.Parameters.Add(param7);

        DbParameter param8 = comm.CreateParameter();
        param8.ParameterName = "@TotalCount";
        param8.Direction = ParameterDirection.Output;
        param8.DbType = DbType.Int32;
        comm.Parameters.Add(param8);

        // return the result table
        DataTable table = gda.ExecuteSelectCommand(comm);
        TotalCount = Convert.ToInt32(comm.Parameters["@TotalCount"].Value);
        return table;
    }

    #endregion

    #region Update Records
    public static bool ActivateSupplier(string SupplierId, bool IsActive)
    {
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        //set sp name
        comm.CommandText = "Supplier_ActivateDeActivate";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@SupplierId";
        param1.Value = SupplierId;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@IsActive";
        param2.Value = IsActive;
        param2.DbType = DbType.Boolean;
        comm.Parameters.Add(param2);

        if (gda.ExecuteNonQuery(comm) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool UpdateSupplier(string CompanyName, string Title, string FirstName, string LastName, decimal PhoneNo, decimal Fax,
    string Email, string WebSite, string PaymentTerms, string BussinessAdd1,
    string BussinessAdd2, int BussinessCity, int BussinessAState,
        int BussinessCountry, string BussinessZip, string OtherAdd1, string OtherAdd2,
    int OtherCity, int OtherAState, int OtherCountry, string OtherZip, int SupplierId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "Supplier_Update";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@CompanyName";
        param1.Value = CompanyName;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@Title";
        param2.Value = Title;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@FirstName";
        param3.Value = FirstName;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);

        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@LastName";
        param4.Value = LastName;
        param4.DbType = DbType.String;
        comm.Parameters.Add(param4);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@PhoneNo";
        param5.Value = PhoneNo;
        param5.DbType = DbType.Decimal;
        comm.Parameters.Add(param5);

        DbParameter param6 = comm.CreateParameter();
        param6.ParameterName = "@Fax";
        param6.Value = Fax;
        param6.DbType = DbType.Decimal;
        comm.Parameters.Add(param6);

        DbParameter param7 = comm.CreateParameter();
        param7.ParameterName = "@Email";
        param7.Value = Email;
        param7.DbType = DbType.String;
        comm.Parameters.Add(param7);

        DbParameter param8 = comm.CreateParameter();
        param8.ParameterName = "@WebSite";
        param8.Value = WebSite;
        param8.DbType = DbType.String;
        comm.Parameters.Add(param8);

        DbParameter param9 = comm.CreateParameter();
        param9.ParameterName = "@PaymentTerms";
        param9.Value = PaymentTerms;
        param9.DbType = DbType.String;
        comm.Parameters.Add(param9);

        DbParameter param10 = comm.CreateParameter();
        param10.ParameterName = "@BussinessAdd1";
        param10.Value = BussinessAdd1;
        param10.DbType = DbType.String;
        comm.Parameters.Add(param10);

        DbParameter param11 = comm.CreateParameter();
        param11.ParameterName = "@BussinessAdd2";
        param11.Value = BussinessAdd2;
        param11.DbType = DbType.String;
        comm.Parameters.Add(param11);

        DbParameter param12 = comm.CreateParameter();
        param12.ParameterName = "@BussinessCity";
        param12.Value = BussinessCity;
        param12.DbType = DbType.Int32;
        comm.Parameters.Add(param12);

        DbParameter param13 = comm.CreateParameter();
        param13.ParameterName = "@BussinessState";
        param13.Value = BussinessAState;
        param13.DbType = DbType.Int32;
        comm.Parameters.Add(param13);

        DbParameter param14 = comm.CreateParameter();
        param14.ParameterName = "@BussinessCountry";
        param14.Value = BussinessCountry;
        param14.DbType = DbType.Int32;
        comm.Parameters.Add(param14);

        DbParameter param15 = comm.CreateParameter();
        param15.ParameterName = "@BussinessZip";
        param15.Value = BussinessZip;
        param15.DbType = DbType.String;
        comm.Parameters.Add(param15);

        DbParameter param16 = comm.CreateParameter();
        param16.ParameterName = "@OtherAdd1";
        param16.Value = OtherAdd1;
        param16.DbType = DbType.String;
        comm.Parameters.Add(param16);

        DbParameter param17 = comm.CreateParameter();
        param17.ParameterName = "@OtherAdd2";
        param17.Value = OtherAdd2;
        param17.DbType = DbType.String;
        comm.Parameters.Add(param17);

        DbParameter param18 = comm.CreateParameter();
        param18.ParameterName = "@OtherCity";
        param18.Value = OtherCity;
        param18.DbType = DbType.Int32;
        comm.Parameters.Add(param18);

        DbParameter param19 = comm.CreateParameter();
        param19.ParameterName = "@OtherState";
        param19.Value = OtherAState;
        param19.DbType = DbType.Int32;
        comm.Parameters.Add(param19);

        DbParameter param20 = comm.CreateParameter();
        param20.ParameterName = "@OtherCountry";
        param20.Value = OtherCountry;
        param20.DbType = DbType.Int32;
        comm.Parameters.Add(param20);

        DbParameter param21 = comm.CreateParameter();
        param21.ParameterName = "@OtherZip";
        param21.Value = OtherZip;
        param21.DbType = DbType.String;
        comm.Parameters.Add(param21);

        DbParameter param22 = comm.CreateParameter();
        param22.ParameterName = "@SupplierId";
        param22.Value = SupplierId;
        param22.DbType = DbType.Int32;
        comm.Parameters.Add(param22);

        int retval = gda.ExecuteNonQuery(comm);

        if (retval > 0)
            return true;
        else
            return false;
    }


    #endregion

    #region Delete Records
    public static bool DeleteSupplier(string SupplierId)
    {
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        //set sp name
        comm.CommandText = "Supplier_Delete";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@SupplierId";
        param1.Value = SupplierId;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        if (gda.ExecuteNonQuery(comm) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region Insert Records
    public static bool InsertSupplier(string CompanyName, string Title, string FirstName, string LastName, decimal PhoneNo, decimal Fax,
        string Email, string WebSite, string PaymentTerms, string BussinessAdd1,
        string BussinessAdd2, int BussinessCity, int BussinessAState,
            int BussinessCountry, string BussinessZip, string OtherAdd1, string OtherAdd2,
        int OtherCity, int OtherAState, int OtherCountry, string OtherZip)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "Supplier_Insert";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@CompanyName";
        param1.Value = CompanyName;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@Title";
        param2.Value = Title;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@FirstName";
        param3.Value = FirstName;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);

        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@LastName";
        param4.Value = LastName;
        param4.DbType = DbType.String;
        comm.Parameters.Add(param4);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@PhoneNo";
        param5.Value = PhoneNo;
        param5.DbType = DbType.Decimal;
        comm.Parameters.Add(param5);

        DbParameter param6 = comm.CreateParameter();
        param6.ParameterName = "@Fax";
        param6.Value = Fax;
        param6.DbType = DbType.Decimal;
        comm.Parameters.Add(param6);

        DbParameter param7 = comm.CreateParameter();
        param7.ParameterName = "@Email";
        param7.Value = Email;
        param7.DbType = DbType.String;
        comm.Parameters.Add(param7);

        DbParameter param8 = comm.CreateParameter();
        param8.ParameterName = "@WebSite";
        param8.Value = WebSite;
        param8.DbType = DbType.String;
        comm.Parameters.Add(param8);

        DbParameter param9 = comm.CreateParameter();
        param9.ParameterName = "@PaymentTerms";
        param9.Value = PaymentTerms;
        param9.DbType = DbType.String;
        comm.Parameters.Add(param9);

        DbParameter param10 = comm.CreateParameter();
        param10.ParameterName = "@BussinessAdd1";
        param10.Value = BussinessAdd1;
        param10.DbType = DbType.String;
        comm.Parameters.Add(param10);

        DbParameter param11 = comm.CreateParameter();
        param11.ParameterName = "@BussinessAdd2";
        param11.Value = BussinessAdd2;
        param11.DbType = DbType.String;
        comm.Parameters.Add(param11);

        DbParameter param12 = comm.CreateParameter();
        param12.ParameterName = "@BussinessCity";
        param12.Value = BussinessCity;
        param12.DbType = DbType.Int32;
        comm.Parameters.Add(param12);

        DbParameter param13 = comm.CreateParameter();
        param13.ParameterName = "@BussinessState";
        param13.Value = BussinessAState;
        param13.DbType = DbType.Int32;
        comm.Parameters.Add(param13);

        DbParameter param14 = comm.CreateParameter();
        param14.ParameterName = "@BussinessCountry";
        param14.Value = BussinessCountry;
        param14.DbType = DbType.Int32;
        comm.Parameters.Add(param14);

        DbParameter param15 = comm.CreateParameter();
        param15.ParameterName = "@BussinessZip";
        param15.Value = BussinessZip;
        param15.DbType = DbType.String;
        comm.Parameters.Add(param15);

        DbParameter param16 = comm.CreateParameter();
        param16.ParameterName = "@OtherAdd1";
        param16.Value = OtherAdd1;
        param16.DbType = DbType.String;
        comm.Parameters.Add(param16);

        DbParameter param17 = comm.CreateParameter();
        param17.ParameterName = "@OtherAdd2";
        param17.Value = OtherAdd2;
        param17.DbType = DbType.String;
        comm.Parameters.Add(param17);

        DbParameter param18 = comm.CreateParameter();
        param18.ParameterName = "@OtherCity";
        param18.Value = OtherCity;
        param18.DbType = DbType.Int32;
        comm.Parameters.Add(param18);

        DbParameter param19 = comm.CreateParameter();
        param19.ParameterName = "@OtherState";
        param19.Value = OtherAState;
        param19.DbType = DbType.Int32;
        comm.Parameters.Add(param19);

        DbParameter param20 = comm.CreateParameter();
        param20.ParameterName = "@OtherCountry";
        param20.Value = OtherCountry;
        param20.DbType = DbType.Int32;
        comm.Parameters.Add(param20);

        DbParameter param21 = comm.CreateParameter();
        param21.ParameterName = "@OtherZip";
        param21.Value = OtherZip;
        param21.DbType = DbType.String;
        comm.Parameters.Add(param21);

        int retval = gda.ExecuteNonQuery(comm);

        if (retval > 0)
            return true;
        else
            return false;
    }


    #endregion

    #region Check for Validation
    public static bool CheckForSupplier(string EmailId,int SupplierId)
    {
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        //set sp name
        comm.CommandText = "CheckForSupplier";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@EmailId";
        param1.Value = EmailId;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@SupplierId";
        param3.Value = SupplierId;
        param3.DbType = DbType.Int32;
        comm.Parameters.Add(param3);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@Flag";
        param2.Direction = ParameterDirection.Output;
        param2.DbType = DbType.Boolean;
        comm.Parameters.Add(param2);

        gda.ExecuteNonQuery(comm);
        return Convert.ToBoolean(comm.Parameters["@Flag"].Value);
    }
    #endregion
}
