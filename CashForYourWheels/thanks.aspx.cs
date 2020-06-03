using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class thanks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["VehicleType"].ToString() == "MB")
            imgMBLM.ImageUrl = "images/motorbike.jpg";
        else if (Session["VehicleType"].ToString() == "LV")
          imgMBLM.ImageUrl = "images/motorhome.jpg";

        Session["userdata"] = null;
    }
}
