using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class GetCarImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userdata"] != null)
        {
            int width = 320;
            int height = 240;
            string sql = "select ima_image from NVDImage where NVDImage.ima_imageid = (select top(1) my_imageid from NVDModelYear where my_id = " + Convert.ToString(((clsCarselection)Session["userdata"]).CapId) + ")";            
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["cncapsql"].ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, sqlConn);
            sqlConn.Open();
            byte[] imageblob = (byte[])cmd.ExecuteScalar();
            sqlConn.Close();
            if (imageblob != null)
            {
                MemoryStream imgStream = new MemoryStream(imageblob);
                Bitmap bmp = new Bitmap(imgStream);
                Bitmap thumb = new Bitmap(width, height);
                // Create memory GDI resample image via DrawImage & Add some CAP text
                Graphics grap = Graphics.FromImage(thumb);
                grap.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);
                grap.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                grap.DrawImage(bmp, new Rectangle(0, 0, width, height),
                0, 0, 1024, 768,
                GraphicsUnit.Pixel, null);
                // Set content type & write it out
                Response.ContentType = "image/jpeg";
                thumb.Save(Response.OutputStream, ImageFormat.Jpeg);
                // Force Cleanup now
                bmp.Dispose();
                thumb.Dispose();
            }
        }
    }
}
