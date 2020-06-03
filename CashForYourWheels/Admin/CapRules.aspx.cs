using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CashForYourWheels.Admin
{
    public partial class CapRules : BasePage
    {
        #region Variable and Property declartions

        /// <summary>
        /// Get Or set GridView Pageindex
        /// </summary>
        public int gvIndex
        {
            get
            {
                if (ViewState["gvIndex"] == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(ViewState["gvIndex"]);
                }
            }
            set
            {
                ViewState["gvIndex"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["AccountDetail"] != null)
                {
                    SetDeafultPageSize();
                    FillDropDown();
                    //set the gridview initial pageindex into viewstate
                    gvIndex = gvRulesList.PageIndex;
                    FillGrid();
                }
                else
                {
                    Response.Redirect("~/AdminLogin.aspx");
                }
            }
        }

        private void FillDropDown()
        {
            DataTable table = BAL_Paging.SelectPagingInfo();
            ddlPerpage.DataSource = table;
            ddlPerpage.DataTextField = table.Columns["PageSize"].ToString();
            ddlPerpage.DataValueField = table.Columns["PageSize"].ToString();
            ddlPerpage.DataBind();
            ddlPerpage.Items.Insert(0, new ListItem("Default", "-1"));

            //ddlAgeFrom.Items.Clear();
            //ddlAgeTo.Items.Clear();
            //for (int i = 1; i < 50; i++)
            //{
            //    ddlAgeFrom.Items.Add(new ListItem(i.ToString(), i.ToString()));
            //    ddlAgeTo.Items.Add(new ListItem(i.ToString(), i.ToString()));
            //}

            //ddlMileageFrom.Items.Clear();
            //ddlMileageTo.Items.Clear();
            //for (int i = 0; i < 100000; i += 5000)
            //{
            //    ddlMileageFrom.Items.Add(new ListItem(i.ToString(), i.ToString()));
            //    ddlMileageTo.Items.Add(new ListItem(i.ToString(), i.ToString()));
            //}
        }

        private void SetDeafultPageSize()
        {
            gvRulesList.PageSize = this.DefaultAdminPageSize;
        }

        #region Drop Down List
        protected void ddlPerpage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _size = 0;
            if (ddlPerpage.SelectedIndex <= 0)
            {
                _size = this.DefaultAdminPageSize;
            }
            else
            {
                _size = Convert.ToInt32(ddlPerpage.SelectedValue);
            }
            gvRulesList.PageSize = _size;
            FillGrid();
        }
        #endregion

        private void FillGrid()
        {
            int TotalCount = 0;
            gvRulesList.PageIndex = gvIndex;
            DataTable table = BAL_Rules.GetRules(gvRulesList.PageIndex, gvRulesList.PageSize, gvRulesList.OrderBy, out TotalCount);
            gvRulesList.VirtualItemCount = TotalCount;
            gvRulesList.DataSource = table;
            gvRulesList.DataBind();
            if (gvRulesList.Rows.Count > 0)
            {
                lblsearch2.Visible = true;
                ddlPerpage.Visible = true;
                lable123.Visible = true;
            }
            else
            {
                lblsearch2.Visible = false;
                ddlPerpage.Visible = false;
                lable123.Visible = false;
            }
        }

        #region --> GridView Events <--
        protected void gvRulesList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
            {
                CheckBox chkBxSelect = (CheckBox)e.Row.Cells[1].FindControl("cbRows");
                CheckBox chkBxHeader = (CheckBox)this.gvRulesList.HeaderRow.FindControl("chkBxHeader");
                chkBxSelect.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chkBxHeader.ClientID);
            }
        }

        //protected string setRuleDescription(object AgeFrom, object AgeTo, object NAge, object MileageFrom, object MileageTo, object NCMileage, object VehicleType, object NCBodyType,
        //    object FuelType, object NCFuelType, object EngineSizeFrom, object EngineSizeTo, object NCEngineSize,
        //    object GearBox, object NCGearBox, object Doors, object CapCleanFrom, object CapCleanTo, object WantToPay, object IsInPercentage, object Payout)

        //{
        //    return "Age From: <b> " + Convert.ToString(AgeFrom) + "</b> To:<b>" + Convert.ToString(AgeTo) + "</b> <hr> Condition: <b>" + Convert.ToString(NAge) + "</b>" +
        //           " Mileage From: <b> " + Convert.ToString(MileageFrom) + "</b> To:<b>" + Convert.ToString(MileageTo) + "</b>  <hr> Condition: <b>" + Convert.ToString(NCMileage) + "</b>" +
        //           " Vehicle Body Type: <b> " + Convert.ToString(VehicleType) + "</b> <hr> Condition: <b>" + Convert.ToString(NCBodyType) + "</b>" +
        //           " Fuel Type: <b> " + Convert.ToString(FuelType) + "</b> <hr> Condition: <b>" + Convert.ToString(NCFuelType) + "</b>" +
        //           " Engine Size From: <b> " + Convert.ToString(EngineSizeFrom) + "</b> To:<b>" + Convert.ToString(EngineSizeTo) + "</b> <hr> Condition: <b>" + Convert.ToString(NCEngineSize) + "</b>" +
        //           " GearBox: <b> " + Convert.ToString(GearBox) + "</b> <hr> Condition: <b>" + Convert.ToString(NCGearBox) + "</b>" +
        //           " Door: <b> " + Convert.ToInt32(Doors) + "</b>" +
        //           "<hr> CAP Clean From: <b> " + Convert.ToString(CapCleanFrom) + "</b> To:<b>" + Convert.ToString(CapCleanTo) + "</b>" +
        //           "<hr> Want To Pay: " + Convert.ToString(WantToPay) + " " + Convert.ToString(Convert.ToBoolean(IsInPercentage) ? "%" : "£") + " " + Payout;
        //}

        protected string setRuleDescription(object WantToPay, object IsInPercentage, object Payout)
        {
            return "Want To Pay: " + Convert.ToString(WantToPay) + " " + Convert.ToString(Convert.ToBoolean(IsInPercentage) ? "%" : "£") + " " + Payout;
        }

        protected string setImage4Status(object strArg)
        {
            bool status = Convert.ToBoolean(strArg);
            if (status == true)
            {
                return "~/Admin/Images/ico-active.gif";
            }
            else
            {
                return "~/Admin/Images/ico-inactive.gif";
            }
        }

        protected void gvRulesList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRulesList.PageIndex = e.NewPageIndex;
            gvIndex = e.NewPageIndex;
            FillGrid();
        }

        protected void gvRulesList_Sorting(object sender, GridViewSortEventArgs e)
        {
            GridViewClass.GVSort(sender, e);
            FillGrid();
        }

        private void GetRecords(int Id)
        {
            DataTable table = BAL_Rules.GetRuleById(Id);
            {
                txtRuleName.Text = Convert.ToString(table.Rows[0]["RuleName"]);

                //ddlAgeFrom.SelectedValue = Convert.ToString(table.Rows[0]["AgeFrom"]);
                //ddlAgeTo.SelectedValue = Convert.ToString(table.Rows[0]["AgeTo"]);
                //ddlNCAge.SelectedValue = Convert.ToString(table.Rows[0]["NCAge"]);

                //ddlMileageFrom.SelectedValue = Convert.ToString(table.Rows[0]["MileageFrom"]);
                //ddlMileageTo.SelectedValue = Convert.ToString(table.Rows[0]["MileageTo"]);
                //ddlNCMileage.SelectedValue = Convert.ToString(table.Rows[0]["NCMileage"]);


                //SetSelectedVehicleType(Convert.ToString(table.Rows[0]["VehicleType"]));
                //ddlNCBodyType.SelectedValue = Convert.ToString(table.Rows[0]["NCBodyType"]);

                //SetFuelType(Convert.ToString(table.Rows[0]["FuelType"]));
                //ddlNCFuelType.SelectedValue = Convert.ToString(table.Rows[0]["NCFuelType"]);


                //ddlEngineSizeFrom.SelectedValue = Convert.ToString(table.Rows[0]["EngineSizeFrom"]);
                //ddlEngineSizeTo.SelectedValue = Convert.ToString(table.Rows[0]["EngineSizeTo"]);
                //ddlNCEngineSize.SelectedValue = Convert.ToString(table.Rows[0]["NCEngineSize"]);


                //ddlGearbox.SelectedValue = Convert.ToString(table.Rows[0]["Gearbox"]);
                //ddlNCGearbox.SelectedValue = Convert.ToString(table.Rows[0]["NCGearbox"]);

                //ddlDoors.SelectedValue = Convert.ToString(table.Rows[0]["NCGearbox"]);

                txtCAPValueFrom.Text = Convert.ToString(table.Rows[0]["CAPCleanFrom"]);
                txtCAPValueTo.Text = Convert.ToString(table.Rows[0]["CAPCleanTo"]);

                ddlWantToPay.SelectedValue = Convert.ToString(table.Rows[0]["WantToPay"]);

                ddlIsInPercentage.SelectedValue = Convert.ToString(table.Rows[0]["IsInPercentage"]).ToLower();


                txtPayout.Text = Convert.ToString(table.Rows[0]["Payout"]);
            }
        }

        protected void gvRulesList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                GetRecords(Convert.ToInt32(e.CommandArgument));
                lblMode.Text = Convert.ToString(e.CommandArgument);
            }
        }
        #endregion

        #region Button Click events
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (BAL_Rules.DeleteRecords(ReturnIds()) == true)
            {
                ShowMessage("Record Deleted Successfully.");
                FillGrid();
            }
            else
            {
                ShowMessage("Error in record deletion.");
            }
        }

        protected void btnActive_Click(object sender, EventArgs e)
        {
            if (BAL_Rules.ActivateRecords(ReturnIds(), true) == true)
            {
                ShowMessage("Record Activated succefully");
                FillGrid();
            }
            else
            {
                ShowMessage("Error in record activation.");
            }
        }

        protected void btnInActive_Click(object sender, EventArgs e)
        {
            if (BAL_Rules.ActivateRecords(ReturnIds(), false) == true)
            {
                ShowMessage("Record Deactivated succefully");
                FillGrid();
            }
            else
            {
                ShowMessage("Error in record deactivation.");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == false)
            {
                //Page.Validate("AddCategory");
                if (Page.IsValid == true)
                {
                    //txtLink.Text = Server.HtmlEncode(txtLink.Text);
                    clsRulesProps obj = setInput();

                    if (!string.IsNullOrEmpty(lblMode.Text))
                    {
                        obj.IsActive = true;
                        obj.DeletedStatus = false;
                        obj.RuleId = Convert.ToInt32(lblMode.Text);
                        if (BAL_Rules.UpdateRules(obj) == true)
                        {
                            ShowMessage("Record Updated Susseccfully.");
                            FillGrid();
                            ClearInput();
                            lblMode.Text = string.Empty;
                        }
                        else
                        {
                            ShowMessage("Error in record updation.");
                        }
                    }
                    else
                    {
                        obj.IsActive = true;
                        obj.DeletedStatus = false;
                        if (BAL_Rules.InsertRules(obj, isUpdate: false) == true)
                        {
                            ShowMessage("Record Inserted Susseccfully.");
                            FillGrid();
                            ClearInput();
                        }
                        else
                        {
                            ShowMessage("Error in record insertion.");
                        }
                    }
                }
                else
                {
                    ShowMessage("Some Required Field Missing");
                }
            }
        }
        #endregion

        private void ShowMessage(string msg)
        {
            DisplayAlertMessage.CreateMessageAlert(this, msg, "alertKey");
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtRuleName.Text))
            {
                ShowMessage("Enter Rule Name");
                return true;
            }
            else
            { return false; }
        }
        private void ClearInput()
        {
            txtRuleName.Text = string.Empty;
            txtCAPValueFrom.Text = string.Empty;
            txtCAPValueTo.Text = string.Empty;
            txtPayout.Text = string.Empty;
        }

        public string GetSelectedVehicleType()
        {
            string data = string.Empty;

            //foreach (ListItem item in chklstVehicleType.Items)
            //{
            //    if (item.Selected)
            //    {
            //        data += item.Text + ",";
            //    }
            //}
            return data;
        }

        public void SetSelectedVehicleType(string strData)
        {
            //foreach (string s in strData.Split(','))
            //{
            //    foreach (ListItem item in chklstVehicleType.Items)
            //    {
            //        if (item.Text == s)
            //        {
            //            item.Selected = true;
            //            break;
            //        }
            //    }
            //}
        }

        public string GetSFuelType()
        {
            string data = string.Empty;

            //foreach (ListItem item in chklstFuelType.Items)
            //{
            //    if (item.Selected)
            //    {
            //        data += item.Text + ",";
            //    }
            //}
            return data;
        }

        public void SetFuelType(string strData)
        {
            //foreach (string s in strData.Split(','))
            //{
            //    foreach (ListItem item in chklstFuelType.Items)
            //    {
            //        if (item.Text == s)
            //        {
            //            item.Selected = true;
            //            break;
            //        }
            //    }
            //}
        }

        private clsRulesProps setInput()
        {
            clsRulesProps obj = new clsRulesProps();
            obj.RuleName = txtRuleName.Text;
            //obj.AgeFrom = Convert.ToInt32(ddlAgeFrom.SelectedItem.Text);
            //obj.AgeTo = Convert.ToInt32(ddlAgeTo.SelectedItem.Text);
            //obj.NCAge = ddlNCAge.SelectedItem.Text;
            //obj.MileageFrom = Convert.ToInt32(ddlMileageFrom.SelectedItem.Value);
            //obj.MileageTo = Convert.ToInt32(ddlMileageTo.SelectedItem.Value);
            //obj.NCMileage = ddlNCMileage.SelectedItem.Text;
            //obj.VehicleType = GetSelectedVehicleType();
            //obj.NCBodyType = ddlNCBodyType.SelectedItem.Text;
            //obj.FuelType = GetSFuelType();
            //obj.NCFuelType = ddlNCFuelType.SelectedItem.Text;
            //obj.EngineSizeFrom = Convert.ToInt32(ddlEngineSizeFrom.SelectedItem.Value);
            //obj.EngineSizeTo = Convert.ToInt32(ddlEngineSizeTo.SelectedItem.Value);
            //obj.NCEngineSize = ddlNCEngineSize.SelectedItem.Text;
            //obj.Gearbox = ddlGearbox.SelectedItem.Text;
            //obj.NCGearbox = ddlNCGearbox.SelectedItem.Text;
            //obj.Doors = Convert.ToInt32(ddlDoors.SelectedItem.Text);
            obj.CAPCleanFrom = Convert.ToDecimal(txtCAPValueFrom.Text);
            obj.CAPCleanTo = Convert.ToDecimal(txtCAPValueTo.Text);
            obj.WantToPay = ddlWantToPay.SelectedItem.Text;
            obj.IsInPercentage = ddlIsInPercentage.SelectedItem.Text == "%" ? true : false;
            obj.Payout = txtPayout.Text;
            return obj;
        }


        private string ReturnIds()
        {
            string str = string.Empty;
            if (gvRulesList != null && gvRulesList.Rows.Count > 0)
            {
                for (int i = 0; i < gvRulesList.Rows.Count; i++)
                {
                    if (((CheckBox)gvRulesList.Rows[i].FindControl("cbRows")).Checked == true)
                    {
                        str = str + "," + Convert.ToString(((Label)gvRulesList.Rows[i].FindControl("lblGetId")).Text);
                    }
                }
            }
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            else
            {
                return str.Substring(1);
            }
        }
    }
}