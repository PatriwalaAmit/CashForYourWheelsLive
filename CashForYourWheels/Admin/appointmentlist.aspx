<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminPanel.master" AutoEventWireup="true" Inherits="Admin_appointmentlist" Codebehind="appointmentlist.aspx.cs" %>

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
                            <asp:Label ID="Label1" runat="server" Text="Appointment Management" CssClass="Table_Title_Label_White">
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
                <asp:Label ID="Label7" runat="server" Text="Appointment Management" CssClass="Link_Label_Bold">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td class="table_td_left" colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td class="table_td_left">
                <asp:Label ID="lblsearch2" runat="server" CssClass="label_blackbold10" Text="Appointment List"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlBranchName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBranchName_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="table_td_right">&nbsp;</td>
        </tr>
        <tr>
            <td class="table_td_left" colspan="2">
                <cc1:CustomePagingGrid ID="gvAdminList" runat="server" Width="100%" CssClass="gridview"
                    AllowPaging="true" AutoGenerateColumns="False" PageSize="50"
                    DataKeyNames="AppointmentId" AllowSorting="false" EnableViewState="true" OnSelectedIndexChanged="gvAdminList_SelectedIndexChanged" OnRowDataBound="gvAdminList_RowDataBound" OnRowDeleting="gvAdminList_RowDeleting" OnRowCommand="gvAdminList_RowCommand">
                    <PagerSettings PreviousPageText="Prev" LastPageText="Last" FirstPageText="First"
                        NextPageText="Next" Mode="NextPreviousFirstLast" Position="TopAndBottom"></PagerSettings>
                    <Columns>
                        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" SortExpression="CustomerName">
                            <ItemStyle Width="18%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CarPlate" HeaderText="Car Plate">
                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CustomerPhoneNumber" HeaderText="Phone" SortExpression="CustomerPhoneNumber">
                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CustomerEmailAddress" HeaderText="Email" SortExpression="CustomerEmailAddress">
                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CustomerZipcode" HeaderText="Zipcode" SortExpression="CustomerZipcode">
                            <ItemStyle Width="7%"></ItemStyle>
                        </asp:BoundField>
                        <%--   <asp:BoundField DataField="AppointmentDate" HeaderText="Date of Appointment" SortExpression="AppointmentDate">
                            <ItemStyle Width="18%"></ItemStyle>
                        </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Date of Appointment" ShowHeader="true">
                            <ItemStyle Width="18%"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblAppointmentDate" runat="server" Text='<%# formatdate(Eval("AppointmentDate")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="AppointmentTime" HeaderText="Time" SortExpression="AppointmentTime">
                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                            <ItemStyle Width="5%"></ItemStyle>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="Select"
                                    Text="Edit"></asp:LinkButton>
			        <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                    Text="Delete" CommandArgument='<%# Eval("AppointmentId") %>' OnClientClick="return confirm('Are you sure you want to delete this record ?'); "></asp:LinkButton>
                                <asp:HiddenField ID="hdnId" Value='<%# Eval("AppointmentId") %>' runat="server" />

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

    <asp:Panel ID="pnlPopup" runat="server" Style="border-color: Gray;" CssClass="modalPopup"
        Width="50%">
        <asp:Button Style="display: none" ID="btnShowPopup" runat="server"></asp:Button>
        <asp:Label Style="display: none" ID="lblMainId" runat="server"></asp:Label>
        <AjaxToolKit:ModalPopupExtender ID="mdlPopup" runat="server" TargetControlID="btnShowPopup"
            PopupControlID="pnlPopup" CancelControlID="btnClosePop" DropShadow="false" BackgroundCssClass="modalBackground">
        </AjaxToolKit:ModalPopupExtender>

        <fieldset>
            <legend>Appointment Information</legend>
            <table id="TABLE35" class="table" cellspacing="0" cellpadding="0" width="100%">
                <tbody>
                    <tr>
                        <td>Choose Your Date</td>
                        <td>
                            <asp:DropDownList ID="ddlChoosedate" runat="server" CssClass="dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlChoosedate_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator InitialValue="-1" ID="Req_ID" Display="Dynamic" runat="server" ControlToValidate="ddlChoosedate"
                                Text="*" ErrorMessage="Please select"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Available Time Slots:</td>
                        <td>
                            <asp:DropDownList ID="ddlAvailabletimeslot" runat="server"></asp:DropDownList><asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ControlToValidate="ddlAvailabletimeslot"
                                Text="* Please select" ErrorMessage="Please select"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:LinkButton ID="btnSave" runat="server" Text="Save" OnClick="BtnSave_Click" CausesValidation="true"
                                ForeColor="White" Font-Bold="true" />
                            &nbsp;&nbsp;
            <asp:LinkButton ID="btnClosePop" runat="server" Text="Close" CausesValidation="false"
                ForeColor="White" Font-Bold="true" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMessage" Font-Size="Larger" ForeColor="Green" runat="server" EnableViewState="false"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
        </fieldset>
    </asp:Panel>

    <asp:Label ID="lblMode" runat="server" Text="" Visible="false"></asp:Label>
    <asp:HiddenField ID="hdnAppointmentId" runat="server" />

</asp:Content>

