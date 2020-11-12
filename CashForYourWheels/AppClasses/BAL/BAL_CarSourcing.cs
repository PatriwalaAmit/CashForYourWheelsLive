using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;

public static class BAL_CarSourcing
{    
    public static Boolean InsertUpdateDeleteCarSourcing(string operationtype, int carsourcingid, string fullname, string postcode, 
                                                  string phonenumber, string email, string cardetails, string approxbudget, string deposit, Boolean isactive, Boolean deletestatus)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "pcw_carsourcing";

        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@operationtype";
        param1.Value = operationtype;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@carsourcingid";
        param1.Value = carsourcingid;
        param1.DbType = DbType.Int16;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@fullname";
        param1.Value = fullname;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@postcode";
        param1.Value = postcode;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@phonenumber";
        param1.Value = phonenumber;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@emailaddress";
        param1.Value = email;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@cardetails";
        param1.Value = cardetails;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@approxbudget";
        param1.Value = approxbudget;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@deposit";
        param1.Value = deposit;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@isactive";
        param1.Value = isactive;
        param1.DbType = DbType.Boolean;
        comm.Parameters.Add(param1);

        param1 = comm.CreateParameter();
        param1.ParameterName = "@deletestatus";
        param1.Value = deletestatus;
        param1.DbType = DbType.Boolean;
        comm.Parameters.Add(param1);

        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@ret";
        param5.DbType = DbType.Int32;
        param5.Direction = ParameterDirection.Output;
        comm.Parameters.Add(param5);

        // return the result table
        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }

    public static DataTable SelectCarSourcing(string operationtype, int carsourcingid)
    {
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "pcw_carsourcing";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@operationtype";
        param.Value = operationtype;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@carsourcingid";
        param.Value = carsourcingid;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);       

        param = comm.CreateParameter();
        param.ParameterName = "@ret";
        param.DbType = DbType.Int32;
        param.Direction = ParameterDirection.Output;
        comm.Parameters.Add(param);

        // return the result table
        return gda.ExecuteSelectCommand(comm);
    }

}
