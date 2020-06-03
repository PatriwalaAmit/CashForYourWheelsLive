using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class clsRulesProps
{
    private int _RuleId;
    public int RuleId { get { return _RuleId; } set { _RuleId = value; } }
    private string _RuleName;
    public string RuleName { get { return _RuleName; } set { _RuleName = value; } }

    private int _AgeFrom;
    public int AgeFrom { get { return _AgeFrom; } set { _AgeFrom = value; } }

    private int _AgeTo;
    public int AgeTo { get { return _AgeTo; } set { _AgeTo = value; } }

    private string _NCAge;
    public string NCAge { get { return _NCAge; } set { _NCAge = value; } }

    private int _MileageFrom;
    public int MileageFrom { get { return _MileageFrom; } set { _MileageFrom = value; } }

    private int _MileageTo;
    public int MileageTo { get { return _MileageTo; } set { _MileageTo = value; } }

    private string _NCMileage;
    public string NCMileage { get { return _NCMileage; } set { _NCMileage = value; } }

    private string _VehicleType;
    public string VehicleType { get { return _VehicleType; } set { _VehicleType = value; } }

    private string _NCBodyType;
    public string NCBodyType { get { return _NCBodyType; } set { _NCBodyType = value; } }

    private string _FuelType;
    public string FuelType { get { return _FuelType; } set { _FuelType = value; } }

    private string _NCFuelType;
    public string NCFuelType { get { return _NCFuelType; } set { _NCFuelType = value; } }

    private int _EngineSizeFrom;
    public int EngineSizeFrom { get { return _EngineSizeFrom; } set { _EngineSizeFrom = value; } }

    private int _EngineSizeTo;
    public int EngineSizeTo { get { return _EngineSizeTo; } set { _EngineSizeTo = value; } }

    private string _NCEngineSize;
    public string NCEngineSize { get { return _NCEngineSize; } set { _NCEngineSize = value; } }

    private string _Gearbox;
    public string Gearbox { get { return _Gearbox; } set { _Gearbox = value; } }

    private string _NCGearbox;
    public string NCGearbox { get { return _NCGearbox; } set { _NCGearbox = value; } }

    private int _Doors;
    public int Doors { get { return _Doors; } set { _Doors = value; } }

    private decimal _CAPCleanFrom;
    public decimal CAPCleanFrom { get { return _CAPCleanFrom; } set { _CAPCleanFrom = value; } }

    private decimal _CAPCleanTo;
    public decimal CAPCleanTo { get { return _CAPCleanTo; } set { _CAPCleanTo = value; } }

    private string _WantToPay;
    public string WantToPay { get { return _WantToPay; } set { _WantToPay = value; } }

    private bool _IsInPercentage;
    public bool IsInPercentage { get { return _IsInPercentage; } set { _IsInPercentage = value; } }

    private string _Payout;
    public string Payout { get { return _Payout; } set { _Payout = value; } }

    private bool _IsActive;
    public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }

    private bool _DeletedStatus;
    public bool DeletedStatus { get { return _DeletedStatus; } set { _DeletedStatus = value; } }
}