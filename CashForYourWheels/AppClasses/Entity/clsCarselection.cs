using System;
using System.Collections.Generic;

using System.Web;
using System.Data;

/// <summary>
/// Summary description for clsCarselection
/// </summary>
public class clsCarselection
{
    private string _type;
    public string type { get { return _type; } set { _type = value; } }
   
    

    private string _ModelVariant;
    public string ModelVariant { get { return _ModelVariant; } set { _ModelVariant = value; } }

    private string _Derivative;
    public string Derivative { get { return _Derivative; } set { _Derivative = value; } }

    private string _VehicleDetails;
    public string VehicleDetails { get { return _VehicleDetails; } set { _VehicleDetails = value; } }

    private string _Metallic;
    public string Metallic { get { return _Metallic; } set { _Metallic = value; } }

    private string _CarPlate;
    public string CarPlate { get { return _CarPlate; } set { _CarPlate = value; } }
    /* Carselection 1*/
    private string _CapId;
    public string CapId { get { return _CapId; } set { _CapId = value; } }

    private string _Registration;
    public string Registration { get { return _Registration; } set { _Registration = value; } }

    private string _Manufacturer;
    public string Manufacturer { get { return _Manufacturer; } set { _Manufacturer = value; } }

    private string _Model;
    public string Model { get { return _Model; } set { _Model = value; } }

    private string _ModelYear;
    public string ModelYear { get { return _ModelYear; } set { _ModelYear = value; } }

    private string _Colour;
    public string Colour { get { return _Colour; } set { _Colour = value; } }

    private string _Transmission;
    public string Transmission { get { return _Transmission; } set { _Transmission = value; } }

    private string _EngineSize;
    public string EngineSize { get { return _EngineSize; } set { _EngineSize = value; } }

    private string _FirstRegister;
    public string FirstRegister { get { return _FirstRegister; } set { _FirstRegister = value; } }
        
    /* Carselection 2*/
    public string _cs2_CurrentMileage;
    public string cs2_CurrentMileage { get { return _cs2_CurrentMileage; } set { _cs2_CurrentMileage = value; } }

    private string _cs2_CarImport;
    public string cs2_CarImport { get { return _cs2_CarImport; } set { _cs2_CarImport = value; } }

    private string _cs2_PRegistration;
    public string cs2_PRegistration { get { return _cs2_PRegistration; } set { _cs2_PRegistration = value; } }

    private string _cs2_Insurance;
    public string cs2_Insurance { get { return _cs2_Insurance; } set { _cs2_Insurance = value; } }

    private string _cs2_POwners;
    public string cs2_POwners { get { return _cs2_POwners; } set { _cs2_POwners = value; } }

    private string _cs2_SHistory;
    public string cs2_SHistory { get { return _cs2_SHistory; } set { _cs2_SHistory = value; } }

    private string _cs2_MOT;
    public string cs2_MOT { get { return _cs2_MOT; } set { _cs2_MOT = value; } }

    private string _cs2_VCondition;
    public string cs2_VCondition { get { return _cs2_VCondition; } set { _cs2_VCondition = value; } }

    private string _cs2_V5;
    public string cs2_V5 { get { return _cs2_V5; } set { _cs2_V5 = value; } }

    private string _cs2_OFinance;
    public string cs2_OFinance { get { return _cs2_OFinance; } set { _cs2_OFinance = value; } }

    /*Carselection 3*/
    private DataTable _cs3_BodyWork;
    public DataTable cs3_BodyWork { get { return _cs3_BodyWork; } set { _cs3_BodyWork = value; } }

    private string _cs3_mechanicalcondition;
    public string cs3_mechanicalcondition { get { return _cs3_mechanicalcondition; } set { _cs3_mechanicalcondition = value; } }

    private string _cs3_InteriorCondition;
    public string cs3_InteriorCondition { get { return _cs3_InteriorCondition; } set { _cs3_InteriorCondition = value; } }

    private bool _isVan;
    public bool IsVan { get { return _isVan; } set { _isVan = value; } }

    public clsCarselection()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}
