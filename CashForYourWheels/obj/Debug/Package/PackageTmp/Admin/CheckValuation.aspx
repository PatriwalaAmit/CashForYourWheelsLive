<%@ Page Language="C#" MasterPageFile="~/Master/AdminPanel.master" AutoEventWireup="true" Inherits="Admin_CheckValuation" Title="Check Valuation" Codebehind="CheckValuation.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .lable
        {
            width: 250px;
            text-align: right;
        }
        .textcontrol
        {
            text-align: left;
        }
        .vehicle-details table td
        {
            border-bottom: 2px solid #CCCCCC;
            color: #000000;
            font-family: 'Helvetica' ,arial;
            font-size: 16px;
            font-weight: normal;
            line-height: 21px;
            padding: 15px 15px 15px 0;
        }
        .vehicle-details table td input
        {
            background: none repeat scroll 0 0 #FFFFFF;
            border: 1px solid #C2C2C2;
            border-radius: 3px 3px 3px 3px;
            height: 23px;
            padding: 0 6px;
            width: 212px;
        }
        .vehicle-details table td select
        {
            background: none repeat scroll 0 0 #FFFFFF;
            border: 1px solid #C2C2C2;
            border-radius: 3px 3px 3px 3px;
            height: 25px;
            line-height: 25px;
            padding: 3px;
            width: 226px;
        }
    </style>
    <asp:HiddenField ID="hdnId" runat="server" />
    <div class="vehicle-details">
        <table cellpadding="0" cellspacing="0" width="100%" class="Table_Border_Black">
            <tr>
                <td>
                    Select the Valuation Type
                </td>
                <td>
                <asp:RadioButtonList ID="rbValuationType" runat="server">
                <asp:ListItem Text="Avg" Value="avg"></asp:ListItem>
                <asp:ListItem Text="Clean" Value="clean"></asp:ListItem>
                </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="lable">
                    Enter Your Car Plate:
                </td>
                <td class="textcontrol">
                    <asp:TextBox ID="txtRegistration" runat="server" ValidationGroup="v1"></asp:TextBox>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="rfvValuation" runat="server" ControlToValidate="txtRegistration"
                        ErrorMessage="*" ValidationGroup="v1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="lable">
                    What is the mileage on your car?
                </td>
                <td class="textcontrol">
                    <asp:TextBox ID="txtMileage" runat="server" ValidationGroup="v1"></asp:TextBox>,000
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMileage"
                        ErrorMessage="*" ValidationGroup="v1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" Text="Get Valuation" OnClick="btnSubmit_Click"
                        ValidationGroup="v1" />
                </td>
            </tr>
            <tr>
                <td class="lable">
                    Your Car Valuation Is
                </td>
                <td class="textcontrol">
                    <asp:Label ID="lblCarValuation" runat="server" Font-Size="Larger" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblError" runat="server" Font-Size="Larger" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvValuation" runat="server" Visible="false">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="lable">
                    Branch Name
                </td>
                <td class="textcontrol">
                    <asp:DropDownList ID="ddlBranchName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBranchName_SelectedIndexChange"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="lable">
                    Customer Name
                </td>
                <td class="textcontrol">
                    <asp:TextBox ID="txtCustomerName" runat="server" ValidationGroup="v2">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCustomerName" runat="server" ValidationGroup="v2"
                        ErrorMessage="*" ControlToValidate="txtCustomerName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="lable">
                    Customer Phone
                </td>
                <td class="textcontrol">
                    <asp:TextBox ID="txtPhone" runat="server" ValidationGroup="v2">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="v2"
                        ErrorMessage="*" ControlToValidate="txtPhone"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="lable">
                    Customer Email
                </td>
                <td class="textcontrol">
                    <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="v2">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="v2"
                        ErrorMessage="*" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="lable">
                    Post Code
                </td>
                <td class="textcontrol">
                    <asp:TextBox ID="txtZipcode" runat="server" ValidationGroup="v2">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="v2"
                        ErrorMessage="*" ControlToValidate="txtZipcode"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="lable">
                    Appointment Date
                </td>
                <td class="textcontrol">
                    <asp:DropDownList ID="ddlChoosedate" runat="server" CssClass="dropdown" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlChoosedate_SelectedIndexChanged" ValidationGroup="v2">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator InitialValue="-1" ID="Req_ID" Display="Dynamic" runat="server"
                        ControlToValidate="ddlChoosedate" Text="*" ErrorMessage="Please select" ValidationGroup="v2"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="lable">
                    Appointment Time
                </td>
                <td class="textcontrol">
                    <span runat="server" id="spanBooked" visible="false">Booked</span>
                    <asp:DropDownList ID="ddlAvailabletimeslot" runat="server" ValidationGroup="v2">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator5" Display="Dynamic"
                        runat="server" ControlToValidate="ddlAvailabletimeslot" Text="* Please select"
                        ErrorMessage="Please select" ValidationGroup="v2"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnBookanAppointment" Text="Book an Appointment" runat="server" OnClick="btnBookanAppointment_click"
                        Enabled="false" ValidationGroup="v2" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
