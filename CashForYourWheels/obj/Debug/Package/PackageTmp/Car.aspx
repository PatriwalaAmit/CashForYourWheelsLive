<%@ Page Language="C#" MasterPageFile="~/Master/CarPageMaster.master" AutoEventWireup="true" Inherits="Car" Title="Car Selection" Codebehind="Car.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpCarWebsite1" runat="Server">
    <div class="your-car">
        <h2>Your Vehicle - <%= Convert.ToString(Session["CarRegNumber"]) %><span>A few simple steps
            <img alt="" src="images/step1.png" />
        </span></h2>

        <div class="car-detail">
            <div class="photo">
                <img runat="server" id="imgCarPhoto" runat="server" src="" alt="" /><br />
                <label id="lblImageVan" visible="false" runat="server">Image Not Available<br /><br /></label>
                <i>The vehicle image shown is for illustrative purposes only</i>
            </div>
            <div class="main-detail">
                <ul>
                    <li><span>Manufacturer</span><b><asp:Label ID="lblManufacturer" runat="server" Text="VAUXHALL"></asp:Label></b></li>
                    <li><span>Model</span><b>
                        <asp:Label ID="lblModel" Text="ASTRA DIESEL ESTATE 1.7 CDTi 16V ecoFLEX Life [110] 5dr [AC]"
                            runat="server"></asp:Label></b></li>
                    <li><span>Year</span><b><asp:Label ID="lblModelYear" runat="server" Text="(2008 - 2010 Model)"></asp:Label></b></li>
                    <li><span>Colour</span><b><asp:Label ID="lblColour" runat="server" Text="Silver"></asp:Label></b></li>
                    <li><span>Transmission</span><b><asp:Label ID="lblTransmission" runat="server" Text="Manual"></asp:Label></b></li>
                    <li><span>Engine Size</span><b><asp:Label ID="lblEngineSize" runat="server" Text="0cc"></asp:Label></b></li>
                    <li><span>First Registered</span><b>
                        <asp:Label ID="lblRegistered" runat="server" Text="14/12/2010"></asp:Label></b></li>
                </ul>
                <div class="clear">

                    <asp:LinkButton ID="hlCarButton" runat="server" CssClass="my-car" OnClick="hlCarButton_Click"></asp:LinkButton>

                    <a class="left" href="~/findmycar.aspx" runat="server">Not sure this is yours?<br>
                        Click here</a>
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

</asp:Content>
