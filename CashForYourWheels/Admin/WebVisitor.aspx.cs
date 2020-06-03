using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CashForYourWheels.Admin
{
    public partial class WebVisitor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
            
            }
        }

        protected void webvisitor_search(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCarPlate.Text) && string.IsNullOrEmpty(txtEmailAddress.Text))
            {
                lblError.Text = "Please enter Email Address or Plate!!";
                return;
            }
            else {
                lblError.Text = "";
            }

            GetRecords();
        }

        private void GetRecords()
        {
            DataTable dt = BALBlockedAppointments.SelectWebVisitor(txtEmailAddress.Text, txtCarPlate.Text);
            gvAdminList.DataSource = dt;
            gvAdminList.DataBind();
        }

        protected void gvAdminList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDelete")
            {

                int iResult = BALBlockedAppointments.DeleteWebVisitor(Convert.ToInt32(e.CommandArgument));

                lblError.Text = "Data Deleted Successfully!!";
                //lblMode.Text = Convert.ToString(e.CommandArgument);
                GetRecords();
            }
        }

        protected void gvAdminList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
            //{
            //    CheckBox chkBxSelect = (CheckBox)e.Row.Cells[1].FindControl("cbRows");
            //    CheckBox chkBxHeader = (CheckBox)this.gvAdminList.HeaderRow.FindControl("chkBxHeader");

            //    chkBxSelect.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chkBxHeader.ClientID);
            //}
        }
    }
}