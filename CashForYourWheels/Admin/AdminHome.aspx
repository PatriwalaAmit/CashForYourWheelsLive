<%@ Page Language="C#" MasterPageFile="~/Master/AdminPanel.master" AutoEventWireup="true" Inherits="AdminHome" Title="Admin Panel" Codebehind="AdminHome.aspx.cs" %>

<%@ Register Src="../UserControls/UserSiteMap.ascx" TagName="UserSiteMap" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%" class="Table_Border_Black">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" class="Table_Bck1" style="height: 25px">
                    <tr>
                        <td class="table_td_left">
                            <asp:Label ID="Label1" runat="server" Text="Admin Home" CssClass="Table_Title_Label_White"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 30px" class="table_td_left">
                <uc1:UserSiteMap ID="UserSiteMap1" runat="server" />
            </td>
        </tr>
    </table>
    <br />
    <table cellpadding="0" cellspacing="0" width="100%" class="Table_Border_Black">
        <tr>
            <td style="height: 300px">
            </td>
        </tr>
    </table>
</asp:Content>
