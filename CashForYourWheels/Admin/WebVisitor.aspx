<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminPanel.master" AutoEventWireup="true"
    CodeBehind="WebVisitor.aspx.cs" Inherits="CashForYourWheels.Admin.WebVisitor" %>

<%@ Register Src="~/UserControls/ProgressBar.ascx" TagName="ProgressBar" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/UserSiteMap.ascx" TagName="UserSiteMap" TagPrefix="uc1" %>
<%@ Register Assembly="CustomPagingGridView" Namespace="CustomPagingGridView" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%" class="Table_Border_Black">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" style="height: 25px" class="Table_Bck1">
                    <tr>
                        <td class="table_td_left">
                            <asp:Label ID="Label1" runat="server" Text="Web Visitor Tracking" CssClass="Table_Title_Label_White">
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
    <table cellpadding="0" cellspacing="0" width="100%" class="">
        <tr>
            <td class="table_td_left" colspan="2">
                <asp:Label ID="Label7" runat="server" Text="Web Visitor Management" CssClass="Link_Label_Bold">
                </asp:Label>
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
                                <asp:Label ID="Label4" runat="server" CssClass="label_blackbold10" Text="Search Visitor"></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <td class="table_td_left">
                                <table cellspacing="10" cellpadding="0" width="100%" class="">
                                    <tbody>
                                        <tr>
                                            <td class="table_td_left">
                                                <asp:Label ID="Label2" runat="server" CssClass="label" Text="Email Address:"></asp:Label>
                                            </td>
                                            <td class="table_td_left">
                                                <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="textbox">
                                                </asp:TextBox>&nbsp;<span class="red">*</span>
                                                <%-- <asp:RequiredFieldValidator ID="rfvtxtEmailAddress" runat="server" Display="Dynamic" Text="Please enter" ControlToValidate="txtEmailAddress" ValidationGroup="addrecord"></asp:RequiredFieldValidator>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table_td_left">
                                                <asp:Label ID="lblCarPlate" runat="server" CssClass="label" Text="Car Plate:"></asp:Label>
                                            </td>
                                            <td class="table_td_left">
                                                <asp:TextBox ID="txtCarPlate" runat="server" CssClass="textbox">
                                                </asp:TextBox>&nbsp;<span class="red">*</span>
                                                <%--<asp:RequiredFieldValidator ID="rfvtxtCarPlate" runat="server" Display="Dynamic" Text="Please enter" ControlToValidate="txtCarPlate" ValidationGroup="addrecord"></asp:RequiredFieldValidator>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table_td_center" colspan="2">
                                                <asp:Button ID="btnwebvisitor" OnClick="webvisitor_search" runat="server" ValidationGroup="addrecord"
                                                    CausesValidation="true" Text="Search" CssClass="button1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
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
            <td class="table_td_left" colspan="2">
                <cc1:CustomePagingGrid ID="gvAdminList" runat="server" Width="100%" CssClass="gridview"
                    AllowPaging="True" AutoGenerateColumns="False" PageSize="10" OnRowCreated="gvAdminList_RowCreated"
                    DataKeyNames="Id" EnableViewState="true" OnRowCommand="gvAdminList_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="forename" HeaderText="First Name">
                            <ItemStyle Width="20%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="surname" HeaderText="Last Name">
                            <ItemStyle Width="20%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="emailaddress" HeaderText="Email Address">
                            <ItemStyle Width="20%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="registration" HeaderText="Plate">
                            <ItemStyle Width="20%"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="ViewDelete"
                                    CommandArgument='<%# Bind("Id") %>' Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        No Data Found
                    </EmptyDataTemplate>
                    <PagerStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                </cc1:CustomePagingGrid>
            </td>
        </tr>
    </table>
</asp:Content>
