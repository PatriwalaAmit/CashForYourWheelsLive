<%@ Page Title="" Language="C#" MasterPageFile="~/Master/CarPageMaster.master" AutoEventWireup="true" Inherits="FindMyCar" Codebehind="FindMyCar.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpCarWebsite1" runat="Server">

    <div class="your-car">
        <h2>Find Your Car <span>A few simple steps
            <img alt="" src="images/step1.png" />
        </span></h2>
        <div class="car-detail vehicle-details">
 <script language="javascript" type="text/javascript">
                function Check() {
                    var status = true;

                    if (document.getElementById('<%= ddlManufacturer.ClientID%>').value == '0') {
                        document.getElementById('<%= trManufacturer.ClientID %>').style.backgroundColor = "#ffcccc";
                        status = false;
                    }

                    if (document.getElementById('<%= ddlModel.ClientID%>').value == '0') {
                        document.getElementById('<%= trModel.ClientID %>').style.backgroundColor = "#ffcccc";
                        status = false;
                    }

                    if (document.getElementById('<%= ddlModelVariant.ClientID%>').value == '0') {
                        document.getElementById('<%= trModelVariant.ClientID %>').style.backgroundColor = "#ffcccc";
                        status = false;
                    }

                    if (document.getElementById('<%= ddlDerivative.ClientID%>').value == '0') {
                        document.getElementById('<%= trDerivative.ClientID %>').style.backgroundColor = "#ffcccc";
                        status = false;
                    }

                    if (document.getElementById('<%= ddlRegistrationYear.ClientID%>').value == '0') {
                        document.getElementById('<%= trRegistrationYear.ClientID %>').style.backgroundColor = "#ffcccc";
                        status = false;
                    }

                    if (document.getElementById('<%= ddlColour.ClientID%>').value == '0') {
                        document.getElementById('<%= trColor.ClientID %>').style.backgroundColor = "#ffcccc";
                        status = false;
                    }                                     
                    return status;                   
                }
            </script>
            <table cellpadding="0px" cellspacing="0px" border="0px" style="margin: 0px auto;"
                width="500px">
                <tr id="trManufacturer" runat="server">
                    <th align="right" valign="middle" style="width: 40%">
                        <b>Manufacturer :</b>
                    </th>
                    <th align="left" valign="middle">
                        <asp:DropDownList ID="ddlManufacturer" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlManufacturer_SelectedIndexChanged"
                            ValidationGroup="findmycar">
                        </asp:DropDownList>

                    </th>
                    <th align="left" valign="middle"><a class="tooltip" href="#">
                        <img alt="" src="images/details.png"><span class="classic">please select manufacturer from the list</span></a>
                        &nbsp;
                            <asp:RequiredFieldValidator ID="rfvManufacturer" InitialValue="0" ControlToValidate="ddlManufacturer" runat="server" ValidationGroup="findmycar" ErrorMessage="please select manufacturer from the list" EnableClientScript="false" Display="Static" />
                    </th>
                </tr>                
                <tr id="trModel" runat="server">
                    <th align="right" valign="middle" style="width: 40%">
                        <b>Model :</b>
                    </th>
                    <th align="left" valign="middle">
                        <asp:DropDownList ID="ddlModel" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged"
                            ValidationGroup="findmycar">
                        </asp:DropDownList>

                    </th>
                    <th align="left" valign="middle"><a class="tooltip" href="#">
                        <img alt="" src="images/details.png"><span class="classic">please select model from the list</span></a>&nbsp;<asp:RequiredFieldValidator ID="rfvModel" InitialValue="0"
                            ControlToValidate="ddlModel" runat="server" ValidationGroup="findmycar" EnableClientScript="false" ErrorMessage="please select model from the list" /></th>
                </tr>                
                <tr id="trModelVariant" runat="server">
                    <th align="right" valign="middle" style="width: 40%">
                        <b>Model Variant :</b>
                    </th>
                    <th align="left" valign="middle">
                        <asp:DropDownList ID="ddlModelVariant" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlModelVariant_SelectedIndexChanged"
                            ValidationGroup="findmycar">
                        </asp:DropDownList>

                    </th>
                    <th align="left" valign="middle"><a class="tooltip" href="#">
                        <img alt="" src="images/details.png"><span class="classic">please select model variant from the list</span></a>&nbsp;
                        <asp:RequiredFieldValidator ID="rfvModelVariant" InitialValue="0" ControlToValidate="ddlModelVariant" runat="server" ValidationGroup="findmycar" EnableClientScript="false" ErrorMessage="please select model variant from the list" /></th>
                </tr>               
                <tr id="trDerivative" runat="server">
                    <th align="right" valign="middle" style="width: 40%">
                        <b>Derivative :</b>
                    </th>
                    <th align="left" valign="middle">
                        <asp:DropDownList ID="ddlDerivative" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDerivative_SelectedIndexChanged"
                            ValidationGroup="findmycar">
                        </asp:DropDownList>

                    </th>
                    <th align="left" valign="middle"><a class="tooltip" href="#">
                        <img alt="" src="images/details.png"><span class="classic">please select derivative from the list</span></a>
                        &nbsp;<asp:RequiredFieldValidator ID="rfvDerivative" InitialValue="0"
                            ControlToValidate="ddlDerivative" runat="server" ValidationGroup="findmycar" EnableClientScript="false" ErrorMessage="please select derivative from the list" />

                    </th>
                </tr>

                <tr id="trRegistrationYear" runat="server">
                    <th align="right" valign="middle" style="width: 40%">
                        <b>Select Registration Year </b>
                    </th>
                    <th align="left" valign="middle">
                        <asp:DropDownList ID="ddlRegistrationYear" runat="server" AutoPostBack="true" ValidationGroup="findmycar" OnSelectedIndexChanged="ddlRegistrationYear_SelectedIndexChanged">
                        </asp:DropDownList>

                    </th>
                    <th align="left" valign="middle"><a class="tooltip" href="#">
                        <img alt="" src="images/details.png"><span class="classic">please select registration year from the list</span>
                                                     </a>&nbsp;<asp:RequiredFieldValidator ID="rfvRegistrationYear" ErrorMessage="please select registration year from the list" InitialValue="0"
                            ControlToValidate="ddlRegistrationYear" runat="server" ValidationGroup="findmycar" EnableClientScript="false"  /></th>
                </tr>
                <tr id="trVehicleDetails" runat="server">
                    <th align="right" valign="middle" style="width: 40%">
                        <b>Vehicle Details :</b>
                    </th>
                    <th align="left" valign="middle">
                        <asp:Label ID="lblVehicleDetails" runat="server"></asp:Label>
                    </th>
                    <th align="left" valign="middle"><a class="tooltip" href="#">
                        <img alt="" src="images/details.png"><span class="classic">It will display your vehicle details</span></a></th>
                </tr>
                <tr id="trColor" runat="server">
                    <th align="right" valign="middle" style="width: 40%">
                        <b>Colour :</b>
                    </th>
                    <th align="left" valign="middle">
                        <asp:DropDownList ID="ddlColour" runat="server" ValidationGroup="findmycar" OnSelectedIndexChanged="ddlColour_SelectedIndexChanged1" AutoPostBack="true">
                            <asp:ListItem Value="0" Text="Please Select Colour"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Black"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Blue"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Brown"></asp:ListItem>
                            <asp:ListItem Value="4" Text="Cream"></asp:ListItem>
                            <asp:ListItem Value="5" Text="Gold"></asp:ListItem>
                            <asp:ListItem Value="6" Text="Green"></asp:ListItem>
                            <asp:ListItem Value="7" Text="Grey"></asp:ListItem>
                            <asp:ListItem Value="8" Text="Maroon"></asp:ListItem>
                            <asp:ListItem Value="9" Text="Orange"></asp:ListItem>
                            <asp:ListItem Value="10" Text="Pearl"></asp:ListItem>
                            <asp:ListItem Value="11" Text="Purple"></asp:ListItem>
                            <asp:ListItem Value="12" Text="Red"></asp:ListItem>
                            <asp:ListItem Value="13" Text="Silver"></asp:ListItem>
                            <asp:ListItem Value="14" Text="Teal"></asp:ListItem>
                            <asp:ListItem Value="15" Text="White"></asp:ListItem>
                            <asp:ListItem Value="16" Text="Yellow"></asp:ListItem>
                            <asp:ListItem Value="17" Text="Other"></asp:ListItem>
                        </asp:DropDownList>

                    </th>
                    <th align="left" valign="middle"><a class="tooltip" href="#">
                        <img alt="" src="images/details.png"><span class="classic">please select colour from the list</span></a>&nbsp;
                            <asp:RequiredFieldValidator ID="rfvColour" ErrorMessage="please select colour from the list" InitialValue="0"
                                ControlToValidate="ddlColour" runat="server" ValidationGroup="findmycar" EnableClientScript="false" /></th>
                </tr>
                <tr id="trMetalicPaint" runat="server">
                    <th align="right" valign="middle" style="width: 40%">
                        <b>Metallic Paint :</b>
                    </th>
                    <th align="left" valign="middle">
                        <asp:DropDownList ID="ddlMetalicPaint" runat="server" OnSelectedIndexChanged="ddlMetalicPaint_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="Yes"></asp:ListItem>
                            <asp:ListItem Value="1" Text="No"></asp:ListItem>
                        </asp:DropDownList>
                    </th>
                    <th align="left" valign="middle"><a class="tooltip" href="#">
                        <img alt="" src="images/details.png"><span class="classic">please select metalic paint option from the list</span></a></th>
                </tr>

            </table>
            <asp:LinkButton ID="imgSubmit" runat="server" OnClick="imgSubmit_Click" ValidationGroup="findmycar"
                CssClass="button" />
        </div>
    </div>
</asp:Content>
	