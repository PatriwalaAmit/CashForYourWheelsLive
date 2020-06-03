<%@ Page Language="C#" MasterPageFile="~/Master/AdminPanel.master" AutoEventWireup="true" Inherits="Admin_UserManagement_AdminList" Title="User Management - Admin List" Codebehind="AdminList.aspx.cs" %>

<%--<%@ Register Src="~/UserControls/ProgressBar.ascx" TagName="ProgressBar" TagPrefix="uc2" %>--%>
<%@ Register Src="~/UserControls/UserSiteMap.ascx" TagName="UserSiteMap" TagPrefix="uc1" %>
<%@ Register Assembly="CustomPagingGridView" Namespace="CustomPagingGridView" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%" class="Table_Border_Black">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" style="height: 25px" class="Table_Bck1">
                    <tr>
                        <td class="table_td_left">
                            <asp:Label ID="Label1" runat="server" Text="Admin List" CssClass="Table_Title_Label_White">
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
    <table cellspacing="5" cellpadding="0" width="100%">
        <tbody>
            <tr>
                <td class="table_td_left">
                    <asp:Label ID="Label3" runat="server" CssClass="label_blackbold10" Text="Manage Admin"></asp:Label>
                </td>
                <td class="table_td_right">
                    <asp:ImageButton ID="imgbtn_AddAdmin" OnClick="imgbtn_AddAdmin_Click" runat="server"
                        ImageUrl="~/Admin/Images/icon-add.png"></asp:ImageButton>
                    <asp:LinkButton ID="lnkbtnAddAdmin" OnClick="lnkbtnAddAdmin_Click" runat="server"
                        CssClass="Link_Label_Bold">Add Admin</asp:LinkButton>
                    <asp:ImageButton ID="imgbtn_Search" runat="server" ImageUrl="~/Admin/Images/searchicon.png"
                        OnClientClick="return fnShowSearch();"></asp:ImageButton>
                    <asp:LinkButton ID="lnkbtn_Search" runat="server" CssClass="Link_Label_Bold" OnClientClick="return fnShowSearch();">Search</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr />
                </td>
            </tr>
            <tr>
                <td class="table_td_center" colspan="2">
                    <asp:Panel Style="display: none; visibility: hidden" ID="pnlSearch" runat="server"
                        Width="100%">
                        <fieldset id="fldSearch">
                            <legend>Search Admin
                                <asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/Images/icon-close.gif"
                                    OnClientClick="return fnHideSearch();" />
                            </legend>
                            <table cellpadding="5px" cellspacing="0">
                                <tr>
                                    <td class="table_td_left">
                                        <asp:Label ID="lblpnlSearch" runat="server" Text="First Name:" CssClass="lable"></asp:Label>
                                    </td>
                                    <td class="table_td_left">
                                        <asp:TextBox ID="txtpnlFirstName" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td class="table_td_left">
                                        <asp:Label ID="Label14" runat="server" Text="Last Name:" CssClass="lable"></asp:Label>
                                    </td>
                                    <td class="table_td_left">
                                        <asp:TextBox ID="txtpnlLastName" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td class="table_td_left">
                                        <asp:Label ID="Label15" runat="server" Text="Email Address:" CssClass="lable"></asp:Label>
                                    </td>
                                    <td class="table_td_left">
                                        <asp:TextBox ID="txtpnlEmail" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="table_td_center" colspan="6">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                                            CssClass="button1" />
                                        <asp:Button ID="btnShowAll" runat="server" Text="Show All" OnClick="btnShowAll_Click"
                                            CssClass="button1" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="table_td_right" colspan="2">
                    <asp:Label ID="lblPerPage" runat="server" CssClass="label_blackbold10" Text="Admin Per Page: "></asp:Label>
                    &nbsp;
                    <asp:DropDownList ID="ddlPage" runat="server" CssClass="combobox_auto" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlPage_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="table_td_left" colspan="2">
                    <cc1:CustomePagingGrid ID="gvAdminList" runat="server" CssClass="gridview" Width="100%"
                        OnPageIndexChanging="gvAdminList_PageIndexChanging" OnSelectedIndexChanged="gvAdminList_SelectedIndexChanged"
                        EnableViewState="true" OnSorting="gvAdminList_Sorting" AllowSorting="True" DataKeyNames="UserID"
                        OnRowCreated="gvAdminList_RowCreated" AutoGenerateColumns="False" AllowPaging="True">
                        <PagerSettings PreviousPageText="Prev" Position="TopAndBottom" Mode="NextPreviousFirstLast"
                            LastPageText="Last" FirstPageText="First" NextPageText="Next"></PagerSettings>
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkBxHeader" onclick="javascript:HeaderClick(this);" runat="server" />
                                </HeaderTemplate>
                                <ItemStyle Width="5%"></ItemStyle>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbRows" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="FirstName" SortExpression="FirstName" HeaderText="FirstName">
                                <ItemStyle Width="20%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="LastName" SortExpression="LastName" HeaderText="LastName">
                                <ItemStyle Width="20%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Email" SortExpression="Email" HeaderText="Email (UID)">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle Width="5%"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Image ID="imgStatus" runat="server" ImageUrl='<%# setImage4Status(Eval("Status")) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                        Text="Update"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemStyle Width="5%"></ItemStyle>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="Select"
                                        Text="Edit"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False" HeaderText="AdminId">
                                <HeaderTemplate>
                                    <asp:Label ID="lblId" runat="server" Text="Status"></asp:Label>
                                </HeaderTemplate>
                                <ItemStyle Width="5%"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblGetId" runat="server" Text='<%# Bind("UserID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            No Data Found
                        </EmptyDataTemplate>
                        <PagerStyle HorizontalAlign="Right" VerticalAlign="Middle"></PagerStyle>
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
                <td class="table_td_left">
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
    <asp:Panel ID="pnlPopup" runat="server" Style="border-color: Gray;" CssClass="modalPopup"
        Width="50%">
        <asp:Button Style="display: none" ID="btnShowPopup" runat="server"></asp:Button>
        <asp:Label Style="display: none" ID="lblMainId" runat="server"></asp:Label>
        <AjaxToolKit:ModalPopupExtender ID="mdlPopup" runat="server" TargetControlID="btnShowPopup"
            PopupControlID="pnlPopup" CancelControlID="btnClosePop" DropShadow="false" BackgroundCssClass="modalBackground">
        </AjaxToolKit:ModalPopupExtender>
        <asp:DataList ID="dvDetails" runat="server" CssClass="gridview" Width="100%" CellPadding="0"
            CellSpacing="0">
            <ItemTemplate>
                <fieldset>
                    <legend>Admin List</legend>
                    <table id="TABLE35" class="table" cellspacing="0" cellpadding="0" width="100%">
                        <tbody>
                            <tr>
                                <td class="table_td_left">
                                    <asp:Label ID="Label9" runat="server" CssClass="label_blackbold10" Text="First Name : "></asp:Label>
                                </td>
                                <td class="table_td_left">
                                    <asp:Label ID="Label10" runat="server" CssClass="label_blackbold10" Text='<%# Eval("FirstName") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="table_td_left">
                                    <asp:Label ID="Label2" runat="server" CssClass="label_blackbold10" Text="Last Name : "></asp:Label>
                                </td>
                                <td class="table_td_left">
                                    <asp:Label ID="Label4" runat="server" CssClass="label_blackbold10" Text='<%# Eval("LastName") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="table_td_left">
                                    <asp:Label ID="Label5" runat="server" CssClass="label_blackbold10" Text="Email Address(UId) : "></asp:Label>
                                </td>
                                <td class="table_td_left">
                                    <asp:Label ID="Label6" runat="server" CssClass="label_blackbold10" Text='<%# Eval("Email") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="table_td_left">
                                    <asp:Label ID="Label7" runat="server" CssClass="label_blackbold10" Text="Password : "></asp:Label>
                                </td>
                                <td class="table_td_left">
                                    <asp:Label ID="Label8" runat="server" CssClass="label_blackbold10" Text='<%# Eval("Password") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="table_td_left">
                                    <asp:Label ID="Label3" runat="server" CssClass="label_blackbold10" Text="Phone No. : "></asp:Label>
                                </td>
                                <td class="table_td_left">
                                    <asp:Label ID="Label13" runat="server" CssClass="label_blackbold10" Text='<%# Eval("Mobile") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="table_td_left">
                                    <asp:Label ID="Label11" runat="server" CssClass="label_blackbold10" Text="UserId : "
                                        Visible="false"></asp:Label>
                                </td>
                                <td class="table_td_left">
                                    <asp:Label ID="Label12" runat="server" CssClass="label_blackbold10" Text='<%# Eval("UserId") %>'
                                        Visible="False"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </fieldset>
            </ItemTemplate>
        </asp:DataList>
        <div class="FooterScrip">
            <asp:LinkButton ID="btnSave" runat="server" Text="Edit" OnClick="BtnSave_Click" CausesValidation="true"
                ForeColor="White" Font-Bold="true" />
            &nbsp;&nbsp;
            <asp:LinkButton ID="btnClosePop" runat="server" Text="Close" CausesValidation="false"
                ForeColor="White" Font-Bold="true" />
        </div>
    </asp:Panel>
<%--    <uc2:ProgressBar ID="ProgressBar1" runat="server"></uc2:ProgressBar>--%>

    <script language="javascript" type="text/javascript">
       
        var TotalChkBx;
        var Counter;        
        window.onload = function()
        {
            //Get total no. of CheckBoxes in side the GridView.
            TotalChkBx = parseInt('<%= this.gvAdminList.Rows.Count %>');
            //Get total no. of checked CheckBoxes in side the GridView.
            Counter = 0;
        }
        
      
        function HeaderClick(CheckBox)
        {
           //Get target base & child control.
           var TargetBaseControl = document.getElementById('<%= this.gvAdminList.ClientID %>');
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

        function fnShowSearch()
        {
            document.getElementById('<%= this.pnlSearch.ClientID %>').style.visibility='visible';
            document.getElementById('<%= this.pnlSearch.ClientID %>').style.display='block';
            return false;                
        }
        function fnHideSearch()
        {
            document.getElementById('<%= this.pnlSearch.ClientID %>').style.visibility='hidden';
            document.getElementById('<%= this.pnlSearch.ClientID %>').style.display='none';
            return false;                
        } 
        
        function CheckForCheckBox()
        {               
            var TargetBaseControl = document.getElementById('<%= this.gvAdminList.ClientID %>');
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
            var TargetBaseControl = document.getElementById('<%= this.gvAdminList.ClientID %>');
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
            var TargetBaseControl = document.getElementById('<%= this.gvAdminList.ClientID %>');
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
