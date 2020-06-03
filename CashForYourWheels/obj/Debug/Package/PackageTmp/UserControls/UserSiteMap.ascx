<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_UserSiteMap" Codebehind="UserSiteMap.ascx.cs" %>
<table cellpadding="5px" cellspacing="0px" width="100%">
    <tr>
        <td colspan="2" style="height: 19px; padding-top: 5px; padding-bottom: 10px;">
            <asp:Label ID="lblSiteMapLabel" runat="server" Text="You are Here :" CssClass="label_black"></asp:Label>
            <asp:SiteMapPath ID="SiteMapPath1" runat="server" PathSeparator=">>" Font-Names="verdana,arial">
                <PathSeparatorStyle Font-Bold="False" Font-Size="Smaller" ForeColor="Purple" />
                <CurrentNodeStyle ForeColor="#F77E16" Font-Size="11px" />
                <NodeStyle ForeColor="#2475C2" Font-Size="11px" />
                <RootNodeStyle ForeColor="#2475C2" Font-Size="11px" />
            </asp:SiteMapPath>
        </td>
    </tr>
</table>
