<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_WC_appointment" Codebehind="WC_appointment.ascx.cs" %>

<table cellpadding="0px" cellspacing="0px" width="100%">
    <tr>
        <td>
            <asp:Panel ID="Panel2" runat="server" CssClass="collapsePanelHeader" Height="30px">
                <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                    <div style="float: left; font-family: Verdana">
                        Appointment
                    </div>
                    <div style="float: right; vertical-align: middle;">
                        <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/Admin/Images/expand_blue.jpg" AlternateText="(Show Details...)" />
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
                            <asp:HyperLink ID="HyperLink7" runat="server" Text="Branch Location" CssClass="label_blackLink"
                                NavigateUrl="~/Admin/location.aspx" />
                        </td>
                    </tr>
                    <tr>
                        <td class="table_td_right">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Admin/Images/bullet.gif" />
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink1" runat="server" Text="Branch Timing" CssClass="label_blackLink"
                                NavigateUrl="~/Admin/branchtime.aspx" />
                        </td>                       
                    </tr>
                    <tr>
                        <td class="table_td_right">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Admin/Images/bullet.gif" />
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink2" runat="server" Text="Manage Appointment" CssClass="label_blackLink"
                                NavigateUrl="~/Admin/appointmentlist.aspx" />
                        </td>                       
                    </tr>
                    
                     <tr>
                        <td class="table_td_right">
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Admin/Images/bullet.gif" />
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink3" runat="server" Text="Block Appointment" CssClass="label_blackLink"
                                NavigateUrl="~/Admin/blockappointments.aspx" />
                        </td>                       
                    </tr>
                </table>
            </asp:Panel>
            <AjaxToolKit:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="false" ImageControlID="Image1"
                ExpandedImage="~/Admin/Images/collapse_blue.jpg" CollapsedImage="~/Admin/Images/expand_blue.jpg"
                SuppressPostBack="true" />
        </td>
    </tr>
</table>
