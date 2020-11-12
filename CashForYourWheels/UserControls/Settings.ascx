<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_Settings"
    CodeBehind="Settings.ascx.cs" %>
<table cellpadding="0px" cellspacing="0px" width="100%">
    <tr>
        <td>
            <asp:Panel ID="Panel2" runat="server" CssClass="collapsePanelHeader" Height="30px">
                <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                    <div style="float: left; font-family: Verdana">
                        Setting</div>
                    <div style="float: right; vertical-align: middle;">
                        <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/Admin/Images/expand_blue.jpg"
                            AlternateText="(Show Details...)" />
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel1" runat="server" CssClass="collapsePanel" Height="0">
                <table cellpadding="0px" cellspacing="2px" width="97%">
                    <tr>
                        <td class="table_td_right">
                            <asp:Image ID="Image8" runat="server" ImageUrl="~/Admin/Images/bullet.gif" />
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink7" runat="server" Text="Content Management" CssClass="label_blackLink"
                                NavigateUrl="~/Admin/CMS.aspx" />
                        </td>
                    </tr>
                    <tr>
                        <td class="table_td_right">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Admin/Images/bullet.gif" />
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink1" runat="server" Text="White List Ips" CssClass="label_blackLink"
                                NavigateUrl="~/Admin/whitelistips.aspx" />
                        </td>
                    </tr>
                    <tr>
                        <td class="table_td_right">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Admin/Images/bullet.gif" />
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink2" runat="server" Text="Book an Appointment" CssClass="label_blackLink"
                                NavigateUrl="~/Admin/CheckValuation.aspx" />
                        </td>
                    </tr>
                    <tr>
                        <td class="table_td_right">
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Admin/Images/bullet.gif" />
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink3" runat="server" Text="Adjust Calculations" CssClass="label_blackLink"
                                NavigateUrl="~/Admin/AdjustCalculations.aspx" />
                        </td>
                    </tr>
                    <tr>
                        <td class="table_td_right">
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Admin/Images/bullet.gif" />
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink4" runat="server" Text="Web Visitor" CssClass="label_blackLink"
                                NavigateUrl="~/Admin/WebVisitor.aspx" />
                        </td>
                    </tr>
                    <tr>
                        <td class="table_td_right">
                            <asp:Image ID="Image6" runat="server" ImageUrl="~/Admin/Images/bullet.gif" />
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink5" runat="server" Text="CAP Rules" CssClass="label_blackLink"
                                NavigateUrl="~/Admin/CapRules.aspx" />
                        </td>
                    </tr>
                    <tr>
                        <td class="table_td_right">
                            <asp:Image ID="Image7" runat="server" ImageUrl="~/Admin/Images/bullet.gif" />
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink6" runat="server" Text="Car Sourcing" CssClass="label_blackLink"
                                NavigateUrl="~/Admin/CarSourcing.aspx" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <ajaxToolkit:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="false" ImageControlID="Image1"
                ExpandedImage="~/Admin/images/collapse_blue.jpg" CollapsedImage="~/Admin/images/expand_blue.jpg"
                SuppressPostBack="true" />
        </td>
    </tr>
</table>
