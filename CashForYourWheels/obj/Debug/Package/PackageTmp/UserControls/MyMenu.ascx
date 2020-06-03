<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_MyMenu" Codebehind="MyMenu.ascx.cs" %>
<table cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <div>
                <asp:Menu ID="Menu1" DataSourceID="xmlDataSource" runat="server" BackColor="#E7EBF6"
                    DynamicHorizontalOffset="2" Font-Names="Verdana" ForeColor="black" StaticSubMenuIndent="10px"
                    StaticDisplayLevels="1" DisappearAfter="-1" EnableTheming="true" CssClass="toolbar">
                    <DataBindings>
                        <asp:MenuItemBinding DataMember="MenuItem" NavigateUrlField="NavigateUrl" TextField="Text"
                            ToolTipField="ToolTip" />
                    </DataBindings>
                    <StaticSelectedStyle BackColor="#87CEFA" CssClass="toolbar" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" CssClass="toolbar" />
                    <DynamicMenuStyle BackColor="#4682B4" CssClass="toolbar" />
                    <DynamicSelectedStyle BackColor="#949494" CssClass="toolbar" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" CssClass="toolbar" />
                    <DynamicHoverStyle BackColor="#87CEFA" Font-Bold="False" ForeColor="White" CssClass="toolbar" />
                    <StaticHoverStyle BackColor="#87CEFA" Font-Bold="False" ForeColor="White" CssClass="toolbar" />
                </asp:Menu>
                <asp:XmlDataSource ID="xmlDataSource" TransformFile="~/TransformXSLT.xsl" XPath="MenuItems/MenuItem"
                    runat="server" />
            </div>
        </td>
    </tr>
</table>
