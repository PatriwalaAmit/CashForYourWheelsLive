using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class FindMyCar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userdata"] != null)
            {
                //if (!string.IsNullOrEmpty(((clsCarselection)Session["userdata"]).type))
                {
                    Manufacturer();
                    ddlManufacturer.Text = ((clsCarselection)Session["userdata"]).Manufacturer;
                }
            }
            else
            {
                Manufacturer();
            }
        }
    }

    private void Manufacturer()
    {
        string sql = "select * from CapMan";
        ddlManufacturer.DataSource = GetDataTable(sql);
        ddlManufacturer.DataTextField = "cman_name";
        ddlManufacturer.DataValueField = "cman_code";
        ddlManufacturer.DataBind();
        ddlManufacturer.Items.Insert(0, new ListItem("Select Manufacturer", "0"));

        ddlModel.Items.Clear();
        ddlModelVariant.Items.Clear();
        ddlDerivative.Items.Clear();
    }

    private void Model()
    {
        if (ddlManufacturer.SelectedValue != "0")
        {
            string sql = "select distinct Substring(cmod_name,1,CHARINDEX(' ',cmod_name)) as CapModel from CapMod where cmod_mancode = " + ddlManufacturer.SelectedValue + " order by CapModel asc";
            ddlModel.DataSource = GetDataTable(sql);
            ddlModel.DataValueField = "capmodel";
            ddlModel.DataTextField = "capmodel";
            ddlModel.DataBind();
            ddlModel.Items.Insert(0, new ListItem("Select Model", "0"));

            ddlModelVariant.Items.Clear();
            ddlDerivative.Items.Clear();
        }
    }

    private void ModelVariant()
    {
        if (ddlManufacturer.SelectedValue != "0" && ddlModel.SelectedValue != "0")
        {
            string sql = "select distinct cmod_name from CapMod where cmod_rancode in (select distinct cmod_rancode from CapMod where cmod_mancode =" + ddlManufacturer.SelectedValue + " and Substring(cmod_name,1,CHARINDEX(' ',cmod_name)) ='" + ddlModel.SelectedValue + "')";
            ddlModelVariant.DataSource = GetDataTable(sql);
            ddlModelVariant.DataValueField = "cmod_name";
            ddlModelVariant.DataTextField = "cmod_name";
            ddlModelVariant.DataBind();
            ddlModelVariant.Items.Insert(0, new ListItem("Select Model Variant", "0"));

            ddlDerivative.Items.Clear();
        }
    }

    private void derivative()
    {
        if (ddlManufacturer.SelectedValue != "0" && ddlModel.SelectedValue != "0")
        {
            string sql = "select distinct cder_name from CapDer where cder_mancode=" + ddlManufacturer.SelectedValue + "and cder_rancode in (select distinct cmod_rancode from CapMod where cmod_mancode =" + ddlManufacturer.SelectedValue + " and Substring(cmod_name,1,CHARINDEX(' ',cmod_name)) ='" + ddlModel.SelectedValue + "')";
            ddlDerivative.DataSource = GetDataTable(sql);
            ddlDerivative.DataValueField = "cder_name";
            ddlDerivative.DataTextField = "cder_name";
            ddlDerivative.DataBind();
            ddlDerivative.Items.Insert(0, new ListItem("Select Derivative", "0"));
        }
    }

    private DataTable GetDataTable(string sql)
    {
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cncapsql"].ConnectionString);
        SqlDataAdapter adp = new SqlDataAdapter(sql, sqlConn);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        return dt;
    }

    protected void ddlManufacturer_SelectedIndexChanged(object sender, EventArgs e)
    {
       if (ddlManufacturer.SelectedItem.Value.ToString() == "0")
        {
            trManufacturer.BgColor ="#ffcccc";
            ddlModel.Items.Clear();
        }
        else
        {
            trManufacturer.BgColor = "#fff";
            Model();
        }
    }
    protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlModel.SelectedItem.Value.ToString() == "0")
        {
            trModel.BgColor = "#ffcccc";
            ddlModelVariant.Items.Clear();
        }
        else
        {
            trModel.BgColor = "#fff";
            ModelVariant();
        }
    }
    protected void ddlModelVariant_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlModelVariant.SelectedItem.Value.ToString() == "0")
        {
            trModelVariant.BgColor = "#ffcccc";
            ddlDerivative.Items.Clear();
        }
        else
        {
            trModelVariant.BgColor = "#fff";
            derivative();
        }
    }

    private void RegistrationYear()
    {
        string strManufacturer = ddlManufacturer.SelectedItem.Text;
        string strManufacturerValue = ddlManufacturer.SelectedItem.Value;
        string strModel = ddlModel.SelectedItem.Text;
        string strModelVariant = ddlModelVariant.SelectedItem.Text;
        string strDerivative = ddlDerivative.SelectedItem.Text;
        string strVehicleDetails = lblVehicleDetails.Text;

        string strsql = "select CONVERT(varchar(max),CVehicle_ModIntroduced) + ' - ' + CONVERT(varchar(max),CVehicle_ModDiscontinued) as Years from CAPVehicles where CVehicle_ManTextCode = " + strManufacturerValue + " and CVehicle_ModTextCode in(select convert(varchar(max),cmod_code) from CapMod where cmod_mancode =" + strManufacturerValue + " and Substring(cmod_name,1,CHARINDEX(' ',cmod_name)) ='" + strModel + "') and CVehicle_ModText='" + strModelVariant + "' and CVehicle_DerText ='" + strDerivative + "'";
        DataTable dt = GetDataTable(strsql);
        ddlRegistrationYear.DataSource = dt;
        ddlRegistrationYear.DataValueField = "Years";
        ddlRegistrationYear.DataTextField = "Years";
        ddlRegistrationYear.DataBind();

        ddlRegistrationYear.Items.Insert(0, new ListItem("Select Registration Year", "0"));
    }

    protected void ddlDerivative_SelectedIndexChanged(object sender, EventArgs e)
    {
	if (ddlDerivative.SelectedItem.Value.ToString() == "0")
        {
            trDerivative.BgColor = "#ffcccc";           
        }
        else
        {
            trDerivative.BgColor = "#fff"; 
        }

        if (ddlManufacturer.SelectedValue != "0" && ddlDerivative.SelectedValue != "0")
        {
            string sql = "select * from CapDer where cder_mancode=" + ddlManufacturer.SelectedValue + " and cder_name='" + ddlDerivative.SelectedValue + "'";
            DataTable dt = GetDataTable(sql);

            string str = Convert.ToString(dt.Rows[0]["cder_capcode"]) + Convert.ToString(dt.Rows[0]["cder_fueltype"]);
            lblVehicleDetails.Text = str;

            RegistrationYear();
        }

    }
    protected void ddlColour_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlMetalicPaint_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void imgSubmit_Click(object sender, EventArgs e)
    { 	
        if (Page.IsValid)
        {
            string strManufacturer = ddlManufacturer.SelectedItem.Text;
            string strManufacturerValue = ddlManufacturer.SelectedItem.Value;
            string strModel = ddlModel.SelectedItem.Text;
            string strModelVariant = ddlModelVariant.SelectedItem.Text;
            string strDerivative = ddlDerivative.SelectedItem.Text;
            string strVehicleDetails = lblVehicleDetails.Text;
            string strColour = ddlColour.SelectedItem.Text;
            string strMetallic = ddlMetalicPaint.SelectedItem.Text;


            string strsql = "select * from CAPVehicles where CVehicle_ManTextCode = " + strManufacturerValue + " and CVehicle_ModTextCode in(select convert(varchar(max),cmod_code) from CapMod where cmod_mancode =" + strManufacturerValue + " and Substring(cmod_name,1,CHARINDEX(' ',cmod_name)) ='" + strModel + "') and CVehicle_ModText='" + strModelVariant + "' and CVehicle_DerText ='" + strDerivative + "'";
            DataTable dt = GetDataTable(strsql);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    clsCarselection objcls = new clsCarselection();
                    objcls.type = "findmycar";
                    objcls.Manufacturer = strManufacturer;
                    objcls.Model = strModel;
                    objcls.ModelVariant = strModelVariant;
                    objcls.Derivative = strDerivative;
                    objcls.VehicleDetails = strVehicleDetails;
                    objcls.Colour = strColour;
                    Session["userdata"] = objcls;
                    Response.Redirect("~/car-selection-2.aspx");
                }
                else
                {
                    ShowMessage("Can not find your car!!");
                }
            }
            else
            {
                ShowMessage("Can not find your car!!");
            }

            //clsCarselection objcls = new clsCarselection();
            //objcls.type = "findmycar";
            //objcls.Manufacturer = strManufacturer;
            //objcls.Model = strModel;
            //objcls.ModelVariant = strModelVariant;
            //objcls.Derivative = strDerivative;
            //objcls.VehicleDetails = strVehicleDetails;
            //objcls.Colour = strColour;
            //Session["userdata"] = objcls;
        }
        ClientScript.RegisterStartupScript(this.GetType(), "ValidationCheck", "<script language='javascript'> Check(); </script>");
    }

    private void ShowMessage(string msg)
    {
        DisplayAlertMessage.CreateMessageAlert(this, msg, "alertKey");
    }

    
    protected void ddlRegistrationYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRegistrationYear.SelectedItem.Value.ToString() == "0")
        {
            trRegistrationYear.BgColor = "#ffcccc";
        }
        else
        {
            trRegistrationYear.BgColor = "#fff";
        }
    }

    protected void ddlColour_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddlColour.SelectedItem.Value.ToString() == "0")
        {
            trColor.BgColor = "#ffcccc";
        }
        else
        {
            trColor.BgColor = "#fff";
        }
    }
}
