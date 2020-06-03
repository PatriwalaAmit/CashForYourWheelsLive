<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_SiteMap" Codebehind="SiteMap.ascx.cs" %>
<table cellpadding="0" cellspacing="0px" width="100%">
    <tr>
        <td style="height: 19px">
            <asp:Label ID="lblSiteMapLabel" runat="server" Text="You are Here :"></asp:Label>
            <asp:SiteMapPath ID="SiteMapPath1" runat="server" PathSeparator=">>" Font-Names="verdana,arial" ParentLevelsDisplayed="-1">
                <PathSeparatorStyle Font-Bold="False" Font-Size="Smaller" ForeColor="Purple" />
                <CurrentNodeStyle ForeColor="#F77E16" Font-Size="11px" />
                <NodeStyle ForeColor="#2475C2" Font-Size="11px" />
                <RootNodeStyle ForeColor="#2475C2" Font-Size="11px" />
            </asp:SiteMapPath>
        </td>
    </tr>
</table>
