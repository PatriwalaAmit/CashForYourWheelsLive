<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminPanel.master" AutoEventWireup="true"
    Inherits="Admin_blockappointments" CodeBehind="blockappointments.aspx.cs" %>

<%@ Register Src="~/UserControls/ProgressBar.ascx" TagName="ProgressBar" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/UserSiteMap.ascx" TagName="UserSiteMap" TagPrefix="uc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKEd" %>
<%@ Register Assembly="CustomPagingGridView" Namespace="CustomPagingGridView" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%" class="Table_Border_Black">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" style="height: 25px" class="Table_Bck1">
                    <tr>
                        <td class="table_td_left">
                            <asp:Label ID="Label1" runat="server" Text="Block Appointment Management" CssClass="Table_Title_Label_White"></asp:Label>
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
    <table cellpadding="0" cellspacing="0" width="100%" class="">
        <tr>
            <td class="table_td_left" colspan="2">
                <asp:Label ID="Label7" runat="server" Text="Block Appointment Management" CssClass="Link_Label_Bold"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="table_td_left" colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td class="table_td_left" colspan="2">
                <table class="Table_Border_Black" cellspacing="0" cellpadding="0" width="100%">
                    <tbody>
                        <tr>
                            <th scope="colgroup">
                                <asp:Label ID="Label4" runat="server" CssClass="label_blackbold10" Text="Add Block days"></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <td class="table_td_left">
                                <table cellspacing="10" cellpadding="0" width="100%" class="">
                                    <tbody>
                                        <tr>
                                            <td class="table_td_left">
                                                <asp:Label ID="Label2" runat="server" CssClass="label" Text="Date :"></asp:Label>
                                            </td>
                                            <td class="table_td_left">
                                                <ajaxToolkit:CalendarExtender ID="appblockdate" TargetControlID="txtblockcal" runat="server"
                                                    Format="dd/MM/yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                                <asp:TextBox ID="txtblockcal" runat="server" CssClass="textbox">
                                                </asp:TextBox>&nbsp;<span class="red">*</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table_td_left">
                                                <asp:Label ID="Label3" runat="server" CssClass="label" Text="Time :"></asp:Label>
                                            </td>
                                            <td class="table_td_left">
                                                <asp:Label ID="Label5" runat="server" CssClass="label" Text="From :"></asp:Label>
                                                &nbsp;
                                                <asp:DropDownList ID="ddlFrom" runat="server">
                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlFromAMPM" runat="server">
                                                    <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                </asp:DropDownList>
                                                &nbsp;
                                                <asp:Label ID="Label6" runat="server" CssClass="label" Text="To :"></asp:Label>
                                                &nbsp;
                                                <asp:DropDownList ID="ddlTo" runat="server">
                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlToAMPM" runat="server">
                                                    <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                </asp:DropDownList>
                                                &nbsp;<span class="red">*</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table_td_left">
                                                <asp:Label ID="Label8" runat="server" CssClass="label" Text="Description  :"></asp:Label>
                                            </td>
                                            <td class="table_td_left">
                                                <asp:TextBox ID="txtDescription" runat="server" CssClass="textbox" Width="300px">
                                                </asp:TextBox>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table_td_left">
                                                <asp:Label ID="Label9" runat="server" CssClass="label" Text="Branch Name :"></asp:Label>
                                            </td>
                                            <td class="table_td_left">
                                               <asp:DropDownList ID="ddlBranchName" runat="server" AutoPostBack="true"></asp:DropDownList>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td class="table_td_center" colspan="2">
                                                <asp:Button ID="imgbtn_Insert" OnClick="imgbtn_Insert_Click" runat="server" ValidationGroup="AddCategory"
                                                    CausesValidation="true" OnClientClick="return CheckParent();" Text="Save" CssClass="button1" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td class="table_td_left">
                <asp:Label ID="lblsearch2" runat="server" CssClass="label_blackbold10" Text="Block Days"></asp:Label>
            </td>
            <td class="table_td_right">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="table_td_left" colspan="2">
                <cc1:CustomePagingGrid ID="gvAdminList" runat="server" Width="100%" CssClass="gridview"
                    AllowPaging="False" AutoGenerateColumns="False" PageSize="20" OnRowCreated="gvAdminList_RowCreated"
                    DataKeyNames="appblockid" AllowSorting="True" OnSorting="gvAdminList_Sorting"
                    EnableViewState="true" OnRowCommand="gvAdminList_RowCommand">
                    <PagerSettings PreviousPageText="Prev" LastPageText="Last" FirstPageText="First"
                        NextPageText="Next" Mode="NextPreviousFirstLast" Position="TopAndBottom"></PagerSettings>
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkBxHeader" onclick="javascript:HeaderClick(this);" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="cbRows" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="6%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="appblockdate" HeaderText="Block Date" SortExpression="appblockdate">
                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="BranchName" HeaderText="Branch" SortExpression="BranchName">
                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="appblockfrom" HeaderText="From Time" SortExpression="appblockfrom">
                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="appblockto" HeaderText="To Time" SortExpression="appblockto">
                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="appblcokdesc" HeaderText="Description" SortExpression="appblcokdesc">
                            <ItemStyle Width="20%"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Image ID="imgStatus" runat="server" ImageUrl='<%# setImage4Status(Eval("status")) %>' />
                            </ItemTemplate>
                            <ItemStyle Width="7%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                    Text="Update"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                    Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemStyle Width="7%"></ItemStyle>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="ViewDetails"
                                    CommandArgument='<%# Bind("appblockid") %>' Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AdminId" Visible="false">
                            <HeaderTemplate>
                                <asp:Label ID="lblId" runat="server" Text="Status"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblGetId" runat="server" Text='<%# Bind("appblockid") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        No Data Found
                    </EmptyDataTemplate>
                    <PagerStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                </cc1:CustomePagingGrid>
            </td>
        </tr>
        <tr>
            <td class="table_td_left">
                <asp:LinkButton ID="btnCheckAll" runat="server" CssClass="Link_Label_Bold" OnClientClick="return fnCheckAll();">Check All</asp:LinkButton>
                <asp:Label ID="lbl12" runat="server" Text="|"></asp:Label>
                <asp:LinkButton ID="btnClearAll" runat="server" CssClass="Link_Label_Bold" OnClientClick="return fnClearAll();">Clear All</asp:LinkButton>
            </td>
            <td class="table_td_left">
            </td>
        </tr>
        <tr>
            <td class="table_td_left">
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button1" OnClientClick="return CheckForCheckBox();"
                    OnClick="btnDelete_Click" />
                <asp:Button ID="btnActive" runat="server" Text="Active" CssClass="button1" OnClientClick="return CheckForCheckBox();"
                    OnClick="btnActive_Click" />
                <asp:Button ID="btnInActive" runat="server" Text="Inactive" CssClass="button1" OnClientClick="return CheckForCheckBox();"
                    OnClick="btnInActive_Click" />
            </td>
        </tr>
    </table>
    <script language="javascript" type="text/javascript">

        var TotalChkBx;
        var Counter;
        window.onload = function () {
            //Get total no. of CheckBoxes in side the GridView.
            TotalChkBx = parseInt('<%= this.gvAdminList.Rows.Count %>');
            //Get total no. of checked CheckBoxes in side the GridView.
            Counter = 0;
        }


        function HeaderClick(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl = document.getElementById('<%= this.gvAdminList.ClientID %>');
            var TargetChildControl = "cbRows";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;

            //Reset Counter
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }

        function ChildClick(CheckBox, HCheckBox) {
            //get target base & child control.
            var HeaderCheckBox = document.getElementById(HCheckBox);

            //Modifiy Counter;            
            if (CheckBox.checked && Counter < TotalChkBx)
                Counter++;
            else if (Counter > 0)
                Counter--;

            //Change state of the header CheckBox.
            if (Counter < TotalChkBx)
                HeaderCheckBox.checked = false;
            else if (Counter == TotalChkBx)
                HeaderCheckBox.checked = true;
        }
        function CheckForCheckBox() {
            var TargetBaseControl = document.getElementById('<%= this.gvAdminList.ClientID %>');
            var TargetChildControl = "cbRows";
            var count = 0;


            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.               
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].checked == true)
                    count += 1;
            }
            if (count == 0) {
                alert("Select Atleast One Record");
                return false;
            }
            //Reset Counter
            return true;
        }
        function fnCheckAll() {
            //Get target base & child control.
            var TargetBaseControl = document.getElementById('<%= this.gvAdminList.ClientID %>');
            var TargetChildControl = "cbRows";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.               
            for (var n = 0; n < Inputs.length; ++n) {
                Inputs[n].checked = true;
            }
            //Reset Counter
            return false;
        }
        function fnClearAll() {
            //Get target base & child control.
            var TargetBaseControl = document.getElementById('<%= this.gvAdminList.ClientID %>');
            var TargetChildControl = "cbRows";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.

            for (var n = 0; n < Inputs.length; ++n) {
                Inputs[n].checked = false;
            }
            //Reset Counter
            return false;
        }
        function CheckParent() {
            if (document.getElementById('<%= this.txtblockcal.ClientID %>').value == '') {
                document.getElementById('<%= this.txtblockcal.ClientID %>').style.backgroundColor = 'lemonchiffon';
                alert('Please select the date');
                return false;
            }
        }
    </script>
    <asp:Label ID="lblMode" runat="server" Text="" Visible="false"></asp:Label>
</asp:Content>
