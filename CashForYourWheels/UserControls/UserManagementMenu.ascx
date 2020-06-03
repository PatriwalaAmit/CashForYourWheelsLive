<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="UserControls_UserManagementMenu" Codebehind="UserManagementMenu.ascx.cs" %>
<table cellpadding="0px" cellspacing="0px" width="100%">
    <tr>
        <td>
            <asp:Panel ID="Panel2" runat="server" CssClass="collapsePanelHeader" Height="30px">
                <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                    <div style="float: left; font-family: Verdana">
                        Admin User</div>
                    <div style="float: right; vertical-align: middle;">
                        <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/Admin/Images/expand_blue.jpg" AlternateText="(Show Details...)" />
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel1" runat="server" CssClass="collapsePanel" Height="0">
                <table cellpadding="0px" cellspacing="2px" width="97%">
                    <tr>
                        <td class="table_td_right" width="10%">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Admin/Images/bullet.gif" />
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink2" runat="server" Text="Admin List" CssClass="label_blackLink"
                                NavigateUrl="~/Admin/AdminList.aspx" />
                        </td>
                    </tr>                    
                </table>
            </asp:Panel>
            <AjaxToolKit:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
                ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="false" ImageControlID="Image1"
                ExpandedImage="~/Admin/images/collapse_blue.jpg" CollapsedImage="~/Admin/images/expand_blue.jpg"
                SuppressPostBack="true" />
        </td>
    </tr>
</table>
