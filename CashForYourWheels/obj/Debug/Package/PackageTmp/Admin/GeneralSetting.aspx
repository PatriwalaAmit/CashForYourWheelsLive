<%@ Page Language="C#" MasterPageFile="~/Master/AdminPanel2.master" AutoEventWireup="true" Inherits="Admin_GeneralSetting" Title="General Setting" Codebehind="GeneralSetting.aspx.cs" %>

<%@ Register Src="~/UserControls/ProgressBar.ascx" TagName="ProgressBar" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/UserSiteMap.ascx" TagName="UserSiteMap" TagPrefix="uc1" %>
<%@ Register Assembly="CustomPagingGridView" Namespace="CustomPagingGridView" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%" class="Table_Border_Black">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" style="height: 25px" class="Table_Bck1">
                    <tr>
                        <td class="table_td_left">
                            <asp:Label ID="Label1" runat="server" Text="General Setting" CssClass="Table_Title_Label_White">
                            </asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 30px" class="table_td_left">
                <uc1:UserSiteMap ID="UserSiteMap2" runat="server" />
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <contenttemplate>
    <table cellspacing="0" cellpadding="0" width="100%">
        <tbody>
            <tr>
                <td class="table_td_left">
                    <fieldset>
                        <legend class="midheader">Admin Panel</legend>
                        <table cellspacing="1" cellpadding="2" border="0">
                            <tbody>
                                <tr>
                                    <td class="labelclass">
                                        <asp:Label ID="lbladminpage" runat="server" CssClass="label" Text="Page Size :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAdminPageSize" runat="server" CssClass="re-input" ValidationGroup="CheckForPageSize"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:RequiredFieldValidator ID="checkadminpagesize" runat="server" ValidationGroup="CheckForPageSize"
                                            Display="None" ErrorMessage="<b>Required Field Missing</b><br />Enter Page Size."
                                            ControlToValidate="txtAdminPageSize">
                                        </asp:RequiredFieldValidator>
                                        <AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="Server"
                                            TargetControlID="checkadminpagesize" HighlightCssClass="validatorCalloutHighlight">
                                        </AjaxToolKit:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </fieldset>
                </td>
                <td width="5">
                </td>
                <td class="table_td_left">
                    <fieldset>
                        <legend class="midheader">Front Side</legend>
                        <table cellspacing="1" cellpadding="2" border="0">
                            <tbody>
                                <tr>
                                    <td class="labelclass">
                                        <asp:Label ID="lblfrondpage" runat="server" CssClass="label" Text="Page Size :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFrontPageSize" runat="server" CssClass="re-input" ValidationGroup="CheckForPageSize"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:RequiredFieldValidator ID="checkfrontside" runat="server" ValidationGroup="CheckForPageSize"
                                            Display="None" ErrorMessage="<b>Required Field Missing</b><br />Enter Page Size."
                                            ControlToValidate="txtFrontPageSize">
                                        </asp:RequiredFieldValidator>
                                        <AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="Server"
                                            TargetControlID="checkfrontside" HighlightCssClass="validatorCalloutHighlight">
                                        </AjaxToolKit:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td class="table_td_center" colspan="3">
                    <asp:Button ID="btnSave1" runat="server" CssClass="button1" Text="Save" ValidationGroup="CheckForPageSize"
                        OnClick="btnSave1_Click"></asp:Button>
                </td>
            </tr>
            <tr>
                <td class="table_td_left" colspan="3">
                    <fieldset>
                        <legend class="midheader">Paging</legend>
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td class="table_td_left">
                                        <table cellspacing="1" cellpadding="3" border="0">
                                            <tbody>
                                                <tr>
                                                    <td class="table_td_left">
                                                        <asp:Label ID="lblPageSize" runat="server" CssClass="labelclass" Text="Page Size :"></asp:Label>
                                                    </td>
                                                    <td class="table_td_left">
                                                        <asp:TextBox ID="txtPageSize" runat="server" CssClass="re-input" ValidationGroup="CheckPageSize"></asp:TextBox>
                                                    </td>
                                                    <td class="table_td_left">
                                                        <asp:Button ID="btnSave2" OnClick="btnSave2_Click" runat="server" CssClass="button1"
                                                            Text="Save" ValidationGroup="CheckPageSize"></asp:Button>
                                                    </td>
                                                    <td class="table_td_left">
                                                        <asp:RequiredFieldValidator ID="checkpagesize" runat="server" ValidationGroup="CheckPageSize"
                                                            Display="None" ErrorMessage="<b>Required Field Missing</b><br />Enter Page Size."
                                                            ControlToValidate="txtPageSize">
                                                        </asp:RequiredFieldValidator>
                                                        <AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="Server"
                                                            TargetControlID="checkpagesize" HighlightCssClass="validatorCalloutHighlight">
                                                        </AjaxToolKit:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="table_td_left">
                                        <table cellspacing="0" cellpadding="0" width="96%" border="0">
                                            <tbody>
                                                <tr>
                                                    <td class="table_td_left">
                                                        <asp:Label ID="Paging" runat="server" CssClass="subheading" Text="Paging"></asp:Label>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="table_td_left">
                                                        <cc1:CustomePagingGrid ID="gvPagingGrid" runat="server" CssClass="gridview" OnRowCommand="gvPagingGrid_RowCommand"
                                                            Width="100%" OnSorting="gvPagingGrid_Sorting" OnRowCreated="gvPagingGrid_RowCreated"
                                                            OnPageIndexChanging="gvPagingGrid_PageIndexChanging" AutoGenerateColumns="false"
                                                            AllowPaging="true" PageSize="10">
                                                            <PagerSettings PreviousPageText="Prev" LastPageText="Last" FirstPageText="First"
                                                                NextPageText="Next" Mode="NextPreviousFirstLast" Position="TopAndBottom"></PagerSettings>
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="PagingId">
                                                                    <headertemplate>
                                                                        <asp:CheckBox ID="chkBxHeader" onclick="javascript:HeaderClick(this);" runat="server" />
                                                                    </headertemplate>
                                                                    <itemtemplate>
                                                                        <asp:CheckBox ID="cbRows" runat="server" />
                                                                    </itemtemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="PageSize" SortExpression="PageSize" HeaderText="Page Size">
                                                                    <itemstyle width="50%"></itemstyle>
                                                                </asp:BoundField>
                                                                <asp:TemplateField>
                                                                    <headertemplate>
                                                                        <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                                                                    </headertemplate>
                                                                    <itemtemplate>
                                                                        <asp:Image ID="imgStatus" runat="server" ImageUrl='<%# setImage4Status(Eval("Active")) %>' />
                                                                    </itemtemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Action">
                                                                    <edititemtemplate>
                                                                        <asp:TextBox ID="TextB43ox3" runat="server"></asp:TextBox>
                                                                    </edititemtemplate>
                                                                    <itemtemplate>
                                                                        <asp:ImageButton ID="btnViewDetails" runat="server" ImageUrl="~/Images/vieworderdetail.gif"
                                                                            CommandName="ViewDetails" CommandArgument='<%# Bind("PagingIdSize") %>' />
                                                                    </itemtemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField Visible="False" HeaderText="PagingId">
                                                                    <edititemtemplate>
                                                                        <asp:TextBox runat="server" Text='<%# Bind("PagingId") %>' ID="TextBox1"></asp:TextBox>
                                                                    </edititemtemplate>
                                                                    <itemtemplate>
                                                                        <asp:Label runat="server" Text='<%# Bind("PagingId") %>' ID="lblgetpagingid"></asp:Label>
                                                                    </itemtemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField Visible="False" HeaderText="PagingIdSize">
                                                                    <edititemtemplate>
                                                                        <asp:TextBox runat="server" Text='<%# Bind("PagingIdSize") %>' ID="TextBox1"></asp:TextBox>
                                                                    </edititemtemplate>
                                                                    <itemtemplate>
                                                                        <asp:Label runat="server" Text='<%# Bind("PagingIdSize") %>' ID="lblgetPagingIdSize"></asp:Label>
                                                                    </itemtemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <PagerStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                        </cc1:CustomePagingGrid>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="table_td_left">
                                                        <asp:LinkButton ID="btnCheckAll" runat="server" CssClass="Link_Label_Bold" OnClientClick="return fnCheckAll();">Check All</asp:LinkButton>
                                                        <asp:Label ID="lblSep" runat="server" Text="|"></asp:Label>
                                                        <asp:LinkButton ID="btnClearAll" runat="server" CssClass="Link_Label_Bold" OnClientClick="return fnClearAll();">Clear All</asp:LinkButton>
                                                    </td>
                                                    <td class="table_td_left">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 19px" class="table_td_left">
                                                        <asp:Button ID="btnDelete" OnClick="btnDelete_Click" runat="server" CssClass="button1"
                                                            Text="Delete" OnClientClick="return CheckForCheckBox();"></asp:Button>
                                                        <asp:Button ID="btnActive" OnClick="btnActive_Click" runat="server" CssClass="button1"
                                                            Text="Active" OnClientClick="return CheckForCheckBox();"></asp:Button>
                                                        <asp:Button ID="btnInActive" OnClick="btnInActive_Click" runat="server" CssClass="button1"
                                                            Text="Inactive" OnClientClick="return CheckForCheckBox();"></asp:Button>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </fieldset>
                    <br />
                </td>
            </tr>
        </tbody>
    </table>
    </contenttemplate>
    </asp:UpdatePanel>
    <asp:label ID="lblMode" runat="server" Visible="false"></asp:label>
    
    <uc2:ProgressBar ID="ProgressBar1" runat="server"></uc2:ProgressBar>

    <script language="javascript" type="text/javascript">    
        var TotalChkBx;
        var Counter;        
        window.onload = function()
        {
            //Get total no. of CheckBoxes in side the GridView.
            TotalChkBx = parseInt('<%= this.gvPagingGrid.Rows.Count %>');
            //Get total no. of checked CheckBoxes in side the GridView.
            Counter = 0;
        }
        
      
        function HeaderClick(CheckBox)
        {
           //Get target base & child control.
           var TargetBaseControl = document.getElementById('<%= this.gvPagingGrid.ClientID %>');
           var TargetChildControl = "cbRows";

           //Get all the control of the type INPUT in the base control.
           var Inputs = TargetBaseControl.getElementsByTagName("input");

           //Checked/Unchecked all the checkBoxes in side the GridView.
           for(var n = 0; n < Inputs.length; ++n)
              if(Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetChildControl,0) >= 0)
                 Inputs[n].checked = CheckBox.checked;

           //Reset Counter
           Counter = CheckBox.checked ? TotalChkBx : 0;
        }
        
        function ChildClick(CheckBox, HCheckBox)
        {
            //get target base & child control.
            var HeaderCheckBox = document.getElementById(HCheckBox);
                     
            //Modifiy Counter;            
            if(CheckBox.checked && Counter < TotalChkBx)
                Counter++;
            else if(Counter > 0) 
                Counter--;
                
            //Change state of the header CheckBox.
            if(Counter < TotalChkBx)
                HeaderCheckBox.checked = false;
            else if(Counter == TotalChkBx)
                HeaderCheckBox.checked = true;
        }
    
    
        function CheckForCheckBox()
        {               
            var TargetBaseControl = document.getElementById('<%= this.gvPagingGrid.ClientID %>');
            var TargetChildControl = "cbRows";
            var count=0;


            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");           

            //Checked/Unchecked all the checkBoxes in side the GridView.               
            for(var n = 0; n < Inputs.length; ++n)
            {
               if(Inputs[n].checked == true)
                    count += 1;
            }
            if(count == 0)
            {                    
            alert("Select Atleast One Record");
            return false;
            }
            //Reset Counter
            return true;
         }
         function fnCheckAll()
        {
            //Get target base & child control.
            var TargetBaseControl = document.getElementById('<%= this.gvPagingGrid.ClientID %>');
            var TargetChildControl = "cbRows";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.               
            for(var n = 0; n < Inputs.length; ++n)
            {                      
               Inputs[n].checked = true;                        
            }
            //Reset Counter
            return false;
         }
         function fnClearAll()
         {
            //Get target base & child control.
            var TargetBaseControl = document.getElementById('<%= this.gvPagingGrid.ClientID %>');
            var TargetChildControl = "cbRows";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.

            for(var n = 0; n < Inputs.length; ++n)
            {                      
               Inputs[n].checked = false;
            }
            //Reset Counter
            return false;
          }
    </script>

</asp:Content>
