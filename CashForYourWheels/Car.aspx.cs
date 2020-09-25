using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using CashForYourWheels.CarwebService;
using log4net;

public partial class Car : System.Web.UI.Page
{
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public string CarRegNumber
    {
        get
        {
            return Convert.ToString(ViewState["carregnumber"]);
        }
        set
        {
            ViewState["carregnumber"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ((LinkButton)Page.Master.FindControl("aValueMyCar")).CssClass = "active";

        trError.Visible = false;
        if (!IsPostBack)
        {
            /*check the seesion if page is comes from the 2 page */
            if (Session["userdata"] == null)
            {                
                /* get the data using CARWEB service */
                CarweBVRRWebService obj = new CarweBVRRWebService();
                CarRegNumber = Convert.ToString(Request.QueryString["carnumber"]);//"J67VWC";           
               

                if (!string.IsNullOrEmpty(CarRegNumber))
                    CarRegNumber = CarRegNumber.Replace(" ", "").Trim();

                log.Error("Getting Car plate data ->" + CarRegNumber);

                /*Load data from CarWeb*/
                string strURL = "https://www1.carwebuk.com/CarweBVRRB2Bproxy/carwebvrrwebservice.asmx?op=strB2BGetVehicleByVRM";
                string strUsername = "Cashforyourwheels";
                string strPassword = "44448666";
                string strClientRef = "test";
                string strClientDescription = "test";
                string str1Key = "cf45ht67";
                string strVRM = CarRegNumber;
                string strVersion = "0.31.1";
                System.Xml.XmlNode xmlCarWeb = obj.strB2BGetVehicleByVRM(strUsername, strPassword, strClientRef, strClientDescription, str1Key, strVRM, strVersion);
                XmlTextReader xtr = new XmlTextReader(xmlCarWeb.OuterXml, XmlNodeType.Element, null);
                DataSet dataset = new DataSet();
                dataset.ReadXml(xtr);
                if (dataset != null)
                {
                    string strCapID = string.Empty;
                    if (dataset.Tables["CapCodes"] != null)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dataset.Tables["CapCodes"].Rows[0]["Capcodes_ID"])))
                            strCapID = Convert.ToString(dataset.Tables["CapCodes"].Rows[0]["Capcodes_ID"]);
                    }
                    if (dataset.Tables["CapCode1"] != null && !string.IsNullOrEmpty(strCapID))
                    {
                        log.Debug("CapCode1 present");
                        if (!string.IsNullOrEmpty(Convert.ToString(dataset.Tables["CapCode1"].Rows[0]["Capcode_part1"])))
                            strCapID = Convert.ToString(dataset.Tables["CapCode1"].Rows[0]["Capcode_part1"]);
                    }
/*
                    if (dataset.Tables["CapCode2"] != null && !string.IsNullOrEmpty(strCapID))
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dataset.Tables["CapCode2"].Rows[0]["Capcode_part1"])))
                            strCapID = Convert.ToString(dataset.Tables["CapCode2"].Rows[0]["Capcode_part1"]);
                    }
                    if (dataset.Tables["CapCode3"] != null && !string.IsNullOrEmpty(strCapID))
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dataset.Tables["CapCode3"].Rows[0]["Capcode_part1"])))
                            strCapID = Convert.ToString(dataset.Tables["CapCode3"].Rows[0]["Capcode_part1"]);
                    }
                    if (dataset.Tables["CapCode4"] != null && !string.IsNullOrEmpty(strCapID))
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dataset.Tables["CapCode4"].Rows[0]["Capcode_part1"])))
                            strCapID = Convert.ToString(dataset.Tables["CapCode4"].Rows[0]["Capcode_part1"]);
                    }
                    if (dataset.Tables["CapCode5"] != null && !string.IsNullOrEmpty(strCapID))
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dataset.Tables["CapCode5"].Rows[0]["Capcode_part1"])))
                            strCapID = Convert.ToString(dataset.Tables["CapCode5"].Rows[0]["Capcode_part1"]);
                    }
                    if (dataset.Tables["CapCode6"] != null && !string.IsNullOrEmpty(strCapID))
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dataset.Tables["CapCode6"].Rows[0]["Capcode_part1"])))
                            strCapID = Convert.ToString(dataset.Tables["CapCode6"].Rows[0]["Capcode_part1"]);
                    }
                    if (dataset.Tables["CapCode7"] != null && !string.IsNullOrEmpty(strCapID))
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dataset.Tables["CapCode7"].Rows[0]["Capcode_part1"])))
                            strCapID = Convert.ToString(dataset.Tables["CapCode7"].Rows[0]["Capcode_part1"]);
                    }
*/
                    log.Debug("Value of strcap: " + strCapID.ToString());
                    bool isVan = false;

                    if (dataset.Tables.Count > 0)
                    {
                        if (dataset.Tables["Vehicle"] != null)
                        {
                            if (dataset.Tables["Vehicle"].Rows.Count > 0)
                            {
                                string strVehicleCode = dataset.Tables["Vehicle"].Rows[0]["VehicleCategoryCode"].ToString();

                                if (strVehicleCode.StartsWith("A") || strVehicleCode.StartsWith("B"))
                                { }
                                else if (strVehicleCode.StartsWith("D") || strVehicleCode.StartsWith("C"))
                                {
                                    isVan = true;
                                }
                                else
                                {
                                    Session["userdata"] = null;
                                    Response.Redirect("~/index.aspx?error=data");
                                }
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(strCapID))
                    {
                        if (strCapID != "0")
                        {
                            /*Response.Write(strCapID);*/
                            clsCarselection objcls = new clsCarselection();
                            objcls.CapId = strCapID;
                            objcls.CarPlate = CarRegNumber;
                            objcls.type = string.Empty;
                            objcls.IsVan = isVan;
                            Session["userdata"] = objcls;
                            if (objcls.IsVan == false)
                                imgCarPhoto.Src = "~/getcarimage.aspx";
                            else
                            {
                                imgCarPhoto.Visible = false;
                                lblImageVan.Visible = true;
                                // Change CSS of linkbutton
                                hlCarButton.CssClass = "my-van";
                            }
                            //src="~/images/car.png"
                        }
                        else
                        {
                            Session["userdata"] = null;
                            Response.Redirect("~/index.aspx?error=data");
                        }
                    }
                    else
                    {
                        Session["userdata"] = null;
                        Response.Redirect("~/index.aspx?error=data");
                    }

                    if (dataset.Tables["vehicle"] != null)
                    {
                        // lblRegistration.Text = Convert.ToString(dataset.Tables["vehicle"].Rows[0]["VRM_Curr"]);
                        lblManufacturer.Text = Convert.ToString(dataset.Tables["vehicle"].Rows[0]["DVLA_Make"]);
                        lblModel.Text = Convert.ToString(dataset.Tables["vehicle"].Rows[0]["DVLA_Model"]);
                        lblModelYear.Text = Convert.ToString(dataset.Tables["vehicle"].Rows[0]["DVLAYearOfManufacture"]);
                        lblColour.Text = Convert.ToString(dataset.Tables["vehicle"].Rows[0]["ColourCurrent"]);
                        lblEngineSize.Text = Convert.ToString(dataset.Tables["vehicle"].Rows[0]["EngineCapacity"]) + " cc";
                        lblTransmission.Text = Convert.ToString(dataset.Tables["vehicle"].Rows[0]["Transmission"]);
                        lblRegistered.Text = Convert.ToString(dataset.Tables["vehicle"].Rows[0]["DateFirstRegistered"]);

                        if (Session["userdata"] != null)
                        {
                            //((clsCarselection)Session["userdata"]).Registration = lblRegistration.Text;
                            ((clsCarselection)Session["userdata"]).Manufacturer = lblManufacturer.Text;
                            ((clsCarselection)Session["userdata"]).Model = lblModel.Text;
                            ((clsCarselection)Session["userdata"]).ModelYear = lblModelYear.Text;
                            ((clsCarselection)Session["userdata"]).Colour = lblColour.Text;
                            ((clsCarselection)Session["userdata"]).EngineSize = lblEngineSize.Text;
                            ((clsCarselection)Session["userdata"]).Transmission = lblTransmission.Text;
                            ((clsCarselection)Session["userdata"]).FirstRegister = lblRegistered.Text;
                            ((clsCarselection)Session["userdata"]).NoOfDoors = Convert.ToString(dataset.Tables["vehicle"].Rows[0]["NumberOfDoors"]);
                            ((clsCarselection)Session["userdata"]).BodyStyle = Convert.ToString(dataset.Tables["vehicle"].Rows[0]["BodyStyleDescription"]);
                        }
                    }
                    else if (dataset.Tables["Details"] != null)
                    {
                        trError.Visible = true;
                        lblError.Text = Convert.ToString(dataset.Tables["Details"].Rows[0]["ErrorCode"]) + " : " + Convert.ToString(dataset.Tables["Details"].Rows[0]["ErrorDescription"]);
                        ShowMessage("please insert the correct plate");
                    }
                }

                /* Load data from CarWeb Completed */

                /* call the database for images*/
            }
            else
            {
                CarRegNumber = ((clsCarselection)Session["userdata"]).Registration;
                lblManufacturer.Text = ((clsCarselection)Session["userdata"]).Manufacturer;
                lblModel.Text = ((clsCarselection)Session["userdata"]).Model;
                lblModelYear.Text = ((clsCarselection)Session["userdata"]).ModelYear;
                lblColour.Text = ((clsCarselection)Session["userdata"]).Colour;
                lblEngineSize.Text = ((clsCarselection)Session["userdata"]).EngineSize;
                lblTransmission.Text = ((clsCarselection)Session["userdata"]).Transmission;
                lblRegistered.Text = ((clsCarselection)Session["userdata"]).FirstRegister;
            }
        }
    }

    private void ShowMessage(string msg)
    {
        DisplayAlertMessage.CreateMessageAlert(this, msg, "alertKey");
    }
    protected void hlCarButton_Click(object sender, EventArgs e)
    {
        if (Session["userdata"] == null)
        {
            ShowMessage("Sorry can not find proper data..");
        }
        else
        {
            Response.Redirect("~/Car-Selection-2.aspx");
        }
    }
}
