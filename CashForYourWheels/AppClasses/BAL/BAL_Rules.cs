using System;
using System.Data;
using System.Data.Common;


/// <summary>
/// Summary description for BAL_CMS
/// </summary>
public class BAL_Rules
{
    public BAL_Rules()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Get Records
    public static string GetTotalRulesCount()
    {
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "GetTotalRulesCount";

        return gda.ExecuteScalar(comm); ;
    }

    public static DataTable GetRuleById(int RuleId)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "GetRulesById";

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@RuldId";
        param2.Value = RuleId;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);


        // return the result table
        return gda.ExecuteSelectCommand(comm); ;
    }

    public static DataTable GetRules(int PageIndex, int PageSize, string OrderBy, out int TotalCount)
    {
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();
        comm.CommandText = "GetRulesList";

        //parameter is not implemented 

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

    #region Insert Records
    public static bool InsertRules(clsRulesProps objRules, bool isUpdate = false)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        if (isUpdate)
        {
            // set the stored procedure name
            comm.CommandText = "UpdateRules";

            DbParameter pRuleId = comm.CreateParameter();
            pRuleId.ParameterName = "@RuleId";
            pRuleId.Value = objRules.RuleId;
            pRuleId.DbType = DbType.Int32;
            comm.Parameters.Add(pRuleId);
        }
        else
        {
            // set the stored procedure name
            comm.CommandText = "InsertRules";
        }

        DbParameter pRuleName = comm.CreateParameter();
        pRuleName.ParameterName = "@RuleName";
        pRuleName.Value = objRules.RuleName;
        pRuleName.DbType = DbType.String;
        comm.Parameters.Add(pRuleName);

        //DbParameter pAgeFrom = comm.CreateParameter();
        //pAgeFrom.ParameterName = "@AgeFrom";
        //pAgeFrom.Value = objRules.AgeFrom;
        //pAgeFrom.DbType = DbType.Int32;
        //comm.Parameters.Add(pAgeFrom);

        //DbParameter pAgeTo = comm.CreateParameter();
        //pAgeTo.ParameterName = "@AgeTo";
        //pAgeTo.Value = objRules.AgeTo;
        //pAgeTo.DbType = DbType.Int32;
        //comm.Parameters.Add(pAgeTo);

        //DbParameter pNCAge = comm.CreateParameter();
        //pNCAge.ParameterName = "@NCAge";
        //pNCAge.Value = objRules.NCAge;
        //pNCAge.DbType = DbType.String;
        //comm.Parameters.Add(pNCAge);

        //DbParameter pMileageFrom = comm.CreateParameter();
        //pMileageFrom.ParameterName = "@MileageFrom";
        //pMileageFrom.Value = objRules.MileageFrom;
        //pMileageFrom.DbType = DbType.Int32;
        //comm.Parameters.Add(pMileageFrom);

        //DbParameter pMileageTo = comm.CreateParameter();
        //pMileageTo.ParameterName = "@MileageTo";
        //pMileageTo.Value = objRules.MileageTo;
        //pMileageTo.DbType = DbType.Int32;
        //comm.Parameters.Add(pMileageTo);

        //DbParameter pNCMileage = comm.CreateParameter();
        //pNCMileage.ParameterName = "@NCMileage";
        //pNCMileage.Value = objRules.NCMileage;
        //pNCMileage.DbType = DbType.String;
        //comm.Parameters.Add(pNCMileage);

        //DbParameter pVehicleType = comm.CreateParameter();
        //pVehicleType.ParameterName = "@VehicleType";
        //pVehicleType.Value = objRules.VehicleType;
        //pVehicleType.DbType = DbType.String;
        //comm.Parameters.Add(pVehicleType);

        //DbParameter pNCBodyType = comm.CreateParameter();
        //pNCBodyType.ParameterName = "@NCBodyType";
        //pNCBodyType.Value = objRules.NCBodyType;
        //pNCBodyType.DbType = DbType.String;
        //comm.Parameters.Add(pNCBodyType);

        //DbParameter pFuelType = comm.CreateParameter();
        //pFuelType.ParameterName = "@FuelType";
        //pFuelType.Value = objRules.FuelType;
        //pFuelType.DbType = DbType.String;
        //comm.Parameters.Add(pFuelType);

        //DbParameter pNCFuelType = comm.CreateParameter();
        //pNCFuelType.ParameterName = "@NCFuelType";
        //pNCFuelType.Value = objRules.NCFuelType;
        //pNCFuelType.DbType = DbType.String;
        //comm.Parameters.Add(pNCFuelType);


        //DbParameter pEngineSizeFrom = comm.CreateParameter();
        //pEngineSizeFrom.ParameterName = "@EngineSizeFrom";
        //pEngineSizeFrom.Value = objRules.EngineSizeFrom;
        //pEngineSizeFrom.DbType = DbType.Int32;
        //comm.Parameters.Add(pEngineSizeFrom);

        //DbParameter pEngineSizeTo = comm.CreateParameter();
        //pEngineSizeTo.ParameterName = "@EngineSizeTo";
        //pEngineSizeTo.Value = objRules.EngineSizeTo;
        //pEngineSizeTo.DbType = DbType.Int32;
        //comm.Parameters.Add(pEngineSizeTo);

        //DbParameter pNCEngineSize = comm.CreateParameter();
        //pNCEngineSize.ParameterName = "@NCEngineSize";
        //pNCEngineSize.Value = objRules.NCEngineSize;
        //pNCEngineSize.DbType = DbType.String;
        //comm.Parameters.Add(pNCEngineSize);

        //DbParameter pGearbox = comm.CreateParameter();
        //pGearbox.ParameterName = "@Gearbox";
        //pGearbox.Value = objRules.Gearbox;
        //pGearbox.DbType = DbType.String;
        //comm.Parameters.Add(pGearbox);

        //DbParameter pNCGearbox = comm.CreateParameter();
        //pNCGearbox.ParameterName = "@NCGearbox";
        //pNCGearbox.Value = objRules.NCGearbox;
        //pNCGearbox.DbType = DbType.String;
        //comm.Parameters.Add(pNCGearbox);

        //DbParameter pDoors = comm.CreateParameter();
        //pDoors.ParameterName = "@Doors";
        //pDoors.Value = objRules.Doors;
        //pDoors.DbType = DbType.Int32;
        //comm.Parameters.Add(pDoors);

        DbParameter pCAPCleanFrom = comm.CreateParameter();
        pCAPCleanFrom.ParameterName = "@CAPCleanFrom";
        pCAPCleanFrom.Value = objRules.CAPCleanFrom;
        pCAPCleanFrom.DbType = DbType.Decimal;
        comm.Parameters.Add(pCAPCleanFrom);

        DbParameter pCAPCleanTo = comm.CreateParameter();
        pCAPCleanTo.ParameterName = "@CAPCleanTo";
        pCAPCleanTo.Value = objRules.CAPCleanTo;
        pCAPCleanTo.DbType = DbType.Decimal;
        comm.Parameters.Add(pCAPCleanTo);

        DbParameter pWantToPay = comm.CreateParameter();
        pWantToPay.ParameterName = "@WantToPay";
        pWantToPay.Value = objRules.WantToPay;
        pWantToPay.DbType = DbType.String;
        comm.Parameters.Add(pWantToPay);

        DbParameter pIsInPercentage = comm.CreateParameter();
        pIsInPercentage.ParameterName = "@IsInPercentage";
        pIsInPercentage.Value = objRules.IsInPercentage;
        pIsInPercentage.DbType = DbType.Boolean;
        comm.Parameters.Add(pIsInPercentage);

        DbParameter pPayout = comm.CreateParameter();
        pPayout.ParameterName = "@Payout";
        pPayout.Value = objRules.Payout;
        pPayout.DbType = DbType.String;
        comm.Parameters.Add(pPayout);

        DbParameter pIsActive = comm.CreateParameter();
        pIsActive.ParameterName = "@IsActive";
        pIsActive.Value = objRules.IsActive;
        pIsActive.DbType = DbType.Boolean;
        comm.Parameters.Add(pIsActive);

        DbParameter pDeletedStatus = comm.CreateParameter();
        pDeletedStatus.ParameterName = "@DeletedStatus";
        pDeletedStatus.Value = objRules.DeletedStatus;
        pDeletedStatus.DbType = DbType.Boolean;
        comm.Parameters.Add(pDeletedStatus);


        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion

    #region Update Records
    public static bool UpdateRules(clsRulesProps objRules)
    {
        return InsertRules(objRules, true);
    }

    public static bool ActivateRecords(string RulesId, bool IsActive)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "ActivateRules";

        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@RulesId";
        param1.Value = RulesId;
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

    #region Delete Records
    public static bool DeleteRecords(string RuleIds)
    {
        // get a configured DbCommand object
        GenericDataAccess gda = new GenericDataAccess();

        DbCommand comm = gda.CreateCommand();

        // set the stored procedure name
        comm.CommandText = "DeleteRules";

        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@RulesId";
        param2.Value = RuleIds;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);

        if (gda.ExecuteNonQuery(comm) > 0)
            return true;
        else
            return false;
    }
    #endregion

    //public static decimal GetValuationBasedonRules(int iVehicleAge, int iMileage, int iCapClean)
    //{
    //    int TotalCount = 0;
    //    DataTable dtCAPUpdates = BAL_Rules.GetRules(0, 0, "0", out TotalCount);
    //    decimal newValuation = 0;

    //    foreach (DataRow iRow in dtCAPUpdates.Rows)
    //    {
    //        int iAgeFrom = Convert.ToInt32(iRow["AgeFrom"]);
    //        int iAgeTo = Convert.ToInt32(iRow["AgeTo"]);
    //        string NCAge = Convert.ToString(iRow["NCAge"]);

    //        int iMileageFrom = Convert.ToInt32(iRow["MileageFrom"]);
    //        int iMileageTo = Convert.ToInt32(iRow["MileageTo"]);
    //        string NCMileage = Convert.ToString(iRow["NCMileage"]);

    //        int iCAPCleanFrom = Convert.ToInt32(iRow["CAPCleanFrom"]);
    //        int iCAPCleanTo = Convert.ToInt32(iRow["CAPCleanTo"]);

    //        if (iAgeFrom <= iVehicleAge && iAgeTo >= iVehicleAge)
    //        {
    //            if (iMileageFrom <= iMileage && iMileageTo >= iMileage)
    //            {
    //                if (iCAPCleanFrom <= iCapClean && iCAPCleanTo >= iCapClean)
    //                {
    //                    bool isPercentage = Convert.ToBoolean(iRow["IsInPercentage"]);
    //                    bool isPlus = Convert.ToString(iRow["WantToPay"]) == "Over" ? true : false;
    //                    decimal iPayout = Convert.ToDecimal(iRow["Payout"]);
    //                    if (isPercentage)
    //                    {
    //                        if (isPlus)
    //                            newValuation = iCapClean + (iCapClean) * (iPayout / 100);
    //                        else
    //                            newValuation = iCapClean - (iCapClean) * (iPayout / 100);
    //                    }
    //                    else
    //                    {
    //                        if (isPlus)
    //                            newValuation = iCapClean + iPayout;
    //                        else
    //                            newValuation = iCapClean - iPayout;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    return newValuation;
    //}

    public static double GetValuationBasedonRules(double iCapClean)
    {
        int TotalCount = 0;
        DataTable dtCAPUpdates = BAL_Rules.GetRules(0, 0, "0", out TotalCount);
        double newValuation = iCapClean;

        foreach (DataRow iRow in dtCAPUpdates.Rows)
        {
            int iCAPCleanFrom = Convert.ToInt32(iRow["CAPCleanFrom"]);
            int iCAPCleanTo = Convert.ToInt32(iRow["CAPCleanTo"]);

            if (iCAPCleanFrom <= iCapClean && iCAPCleanTo >= iCapClean)
            {
                bool isPercentage = Convert.ToBoolean(iRow["IsInPercentage"]);
                bool isPlus = Convert.ToString(iRow["WantToPay"]) == "Over" ? true : false;
                double iPayout = Convert.ToDouble(iRow["Payout"]);
                if (isPercentage)
                {
                    if (isPlus)
                        return newValuation = iCapClean + (iCapClean) * (iPayout / 100);
                    else
                        return newValuation = iCapClean - (iCapClean) * (iPayout / 100);
                }
                else
                {
                    if (isPlus)
                        return newValuation = iCapClean + iPayout;
                    else
                        return newValuation = iCapClean - iPayout;
                }
            }
        }
        return newValuation;
    }

    public static string RoundingValues(double adjAverage)
    {
        if (adjAverage <= 1000)
            return ((double)Math.Round(((double)adjAverage) / 10, 0, MidpointRounding.AwayFromZero) * 10).ToString();
        else if (adjAverage <= 10000)
            return ((double)Math.Round(((double)adjAverage) / 25, 0, MidpointRounding.AwayFromZero) * 25).ToString();
        else if (adjAverage <= 30000)
            return ((double)Math.Round(((double)adjAverage) / 50, 0, MidpointRounding.AwayFromZero) * 50).ToString();
        else if (adjAverage > 30000)
            return ((double)Math.Round(((double)adjAverage) / 100, 0, MidpointRounding.AwayFromZero) * 100).ToString();
        return adjAverage.ToString();
    }
}
