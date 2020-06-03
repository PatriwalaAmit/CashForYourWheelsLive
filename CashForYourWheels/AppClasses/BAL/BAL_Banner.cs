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
/// Summary description for BAL_Banner
/// </summary>
public class BAL_Banner
{
	public BAL_Banner()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static bool UpdateBanner(int BannerId,string BannerName,string BannerImage)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "usp_Banners";

        //creat param
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@BannerId";
        param1.Value = BannerId;
        param1.DbType = DbType.Int32;
        comm.Parameters.Add(param1);

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@BannerName";
        param2.Value = BannerName;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@BannerImage";
        param3.Value = BannerImage;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);              

        // return the result
        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }

    public static DataTable GetBanner()
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();
        DbCommand comm = gda.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "ssp_Banners";            
        // return the result table
        return gda.ExecuteSelectCommand(comm); ;
    }

}
