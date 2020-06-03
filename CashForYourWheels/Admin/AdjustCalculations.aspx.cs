using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Xml;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using log4net;

public partial class Admin_AdjustCalculations : BasePage//System.Web.UI.Page
{
   private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

   protected void Page_Load(object sender, EventArgs e)
   {
       lblSaved.Visible = false;

       if (!IsPostBack)
       {
           int resourceID = 0;
           string valXml = string.Empty;

           using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
           using (SqlCommand sqlCmd = new SqlCommand())
           {
               sqlCmd.CommandText = "SELECT id, resourceData FROM tcw_Resources WHERE resourceName='ValAdjustment'";
               sqlCmd.CommandType = CommandType.Text;
               sqlCmd.Connection = sqlConn;

               sqlConn.Open();
               SqlDataReader reader = sqlCmd.ExecuteReader();
               while (reader.Read())
               {
                   resourceID = reader.GetInt32(0);
                   valXml = reader.GetString(1);
               }
               sqlConn.Close();
           }

           XmlDocument xmlDoc = new XmlDocument();
           xmlDoc.LoadXml(valXml);

           ddlType.SelectedValue = xmlDoc.SelectSingleNode("ValResource/ValType").InnerText;
           txtPounds.Text = xmlDoc.SelectSingleNode("ValResource/PoundsMarkup").InnerText;
           txtPercent.Text = xmlDoc.SelectSingleNode("ValResource/PercentMarkup").InnerText;
           ddlVan.SelectedValue = xmlDoc.SelectSingleNode("ValResource/VanValType").InnerText;
           txtVanPounds.Text = xmlDoc.SelectSingleNode("ValResource/VanPounds").InnerText;
           txtVanPercent.Text = xmlDoc.SelectSingleNode("ValResource/VanPercent").InnerText;
       }
   }

   protected void btnSave_Click(object sender, EventArgs e)
   {
       string xmlResource = string.Empty;

       if (txtPounds.Text.Length == 0)
           txtPounds.Text = "0";
       if (txtPercent.Text.Length == 0)
           txtPercent.Text = "0";
       if (txtVanPercent.Text.Length == 0)
           txtVanPercent.Text = "0";
       if (txtVanPounds.Text.Length == 0)
           txtVanPounds.Text = "0";

       xmlResource += "<ValResource><ValType>" + ddlType.SelectedValue + "</ValType>";
       xmlResource += "<PoundsMarkup>" + txtPounds.Text + "</PoundsMarkup>";
       xmlResource += "<PercentMarkup>" + txtPercent.Text + "</PercentMarkup>";
       xmlResource += "<VanValType>" + ddlVan.SelectedValue + "</VanValType>";
       xmlResource += "<VanPounds>" + txtVanPounds.Text + "</VanPounds>";
       xmlResource += "<VanPercent>" + txtVanPercent.Text + "</VanPercent></ValResource>";

       log.Debug("XmlValue: " + xmlResource);

       using(SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
       using (SqlCommand sqlCmd = new SqlCommand())
       {
           sqlCmd.CommandText = "usp_UpdateResource";
           sqlCmd.CommandType = CommandType.StoredProcedure;
           sqlCmd.Connection = sqlConn;

           sqlCmd.Parameters.Add("@resource_id", SqlDbType.Int).Value = 1;
           sqlCmd.Parameters.Add("@resourceData", SqlDbType.Xml).Value = xmlResource;

           try
           {
               sqlConn.Open();
               sqlCmd.ExecuteNonQuery();
               sqlConn.Close();
           }
           catch (Exception ex)
           {
               log.Error("Error In Save", ex);
           }
       }

       lblSaved.Visible = true;
   }
}
