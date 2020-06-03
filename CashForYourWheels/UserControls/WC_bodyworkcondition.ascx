<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_WC_bodyworkcondition" Codebehind="WC_bodyworkcondition.ascx.cs" %>

<table cellpadding="0px" cellspacing="0px" width="100%">
    <tr>
        <td>
            <asp:Panel ID="Panel2" runat="server" CssClass="collapsePanelHeader" Height="30px">
                <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                    <div style="float: left; font-family: Verdana">
                        Bodywork Condition</div>
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
                            <asp:HyperLink ID="HyperLink7" runat="server" Text="Manage Zone" CssClass="label_blackLink"
                                NavigateUrl="~/admin/managezone.aspx" />
                        </td>
                    </tr>
                    <tr>
                        <td class="table_td_right">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Admin/Images/bullet.gif" />
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink1" runat="server" Text="Manage Zone Component" CssClass="label_blackLink"
                                NavigateUrl="~/admin/zonecomponent.aspx" />
                        </td>
                    </tr>
                    <tr>
                        <td class="table_td_right">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Admin/Images/bullet.gif" />
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink2" runat="server" Text="Manage Damage Info" CssClass="label_blackLink"
                                NavigateUrl="~/admin/damageinfo.aspx" />
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