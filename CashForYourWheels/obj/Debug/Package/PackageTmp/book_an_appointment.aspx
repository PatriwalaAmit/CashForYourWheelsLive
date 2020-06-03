<%@ Page Title="Book an Appointment" Language="C#" MasterPageFile="~/Master/CarPageMaster.master" AutoEventWireup="true" Inherits="book_an_appointment" Codebehind="book_an_appointment.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpCarWebsite1" runat="Server">
    <script type="text/javascript" language="javascript">
function DisableButton() {
    try {
        var retunboolean = true;
        var ele = document.getElementById('<%=hlCarButton.ClientID%>');
 
        if (ele != null && !ele.wasDisabled)
            retunboolean = true;
        else
            retunboolean = false;
 
        if (ele != null)
            ele.wasDisabled= true;
    }
    catch (err) {
        alert(err.description);
    }
 
    return retunboolean;
}
</script>
    <div class="your-car">
<h2>Book an appointment</h2>
        <div class="car-detail">
            <div class="photo">
                <img runat="server" id="imgCarPhoto" runat="server" src="" alt="" /><br />
                <i>The vehicle image shown is for illustrative purposes only</i>
            </div>
            <div class="book-appointment">
                <ul>
                    <li><span>Choose Your Nearest Branch:</span>
                        <asp:DropDownList ID="ddlChooseBranch" runat="server" CssClass="dropdown" 
                            AutoPostBack="True" 
                            OnSelectedIndexChanged="ddlChooseBranch_SelectedIndexChanged" Width="127px"></asp:DropDownList>
                        <asp:RequiredFieldValidator InitialValue="0" ID="Req_Branch" Display="Dynamic" runat="server" ControlToValidate="ddlChooseBranch"
                            Text="*" ErrorMessage="Please select" ValidationGroup="app"></asp:RequiredFieldValidator>
                        </li>
                    <li><span>Choose Your Date:</span><b>
                        <asp:DropDownList ID="ddlChoosedate" runat="server" CssClass="dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlChoosedate_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator InitialValue="-1" ID="Req_ID" Display="Dynamic" runat="server" ControlToValidate="ddlChoosedate"
                            Text="*" ErrorMessage="Please select" ValidationGroup="app"></asp:RequiredFieldValidator>
                    </b>
                    </li>
                    <li><span>Available Time Slots:</span>
<b>
<span runat="server" id="spanBooked" visible="false">Booked</span>
<asp:DropDownList ID="ddlAvailabletimeslot" runat="server"></asp:DropDownList><asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ControlToValidate="ddlAvailabletimeslot"
                        Text="* Please select" ErrorMessage="Please select" ValidationGroup="app"></asp:RequiredFieldValidator></b>
                    </li>
                </ul>
                <div class="clear">
                    <asp:LinkButton ID="hlCarButton" runat="server" onclientclick="return DisableButton();" CssClass="book-appointment" OnClick="hlCarButton_Click" ValidationGroup="app"></asp:LinkButton>
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <span style="color: rgb(0, 0, 0); font-size: medium; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 18px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">
                    <strong>
                    <br />
                    <br />
                    <span>If you cannot make any of the times available, please call us and we will squeeze you in.</span>
                </div>
            </div>
            <div class="clear"></div>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr runat="server" visible="false" id="trError">
                    <td width="35%" align="right" valign="middle" style="color: Red">
                        <b>Error :</b>
                    </td>
                    <td align="left" valign="middle" style="color: Red">
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</strong></span>
</asp:Content>

