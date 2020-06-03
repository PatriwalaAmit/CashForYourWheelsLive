<%@ Page Language="C#" MasterPageFile="~/Master/AdminPanel.master" AutoEventWireup="true" Inherits="Admin_AdjustCalculations" Title="Content Management" Codebehind="AdjustCalculations.aspx.cs" %>

<%@ Register Src="~/UserControls/ProgressBar.ascx" TagName="ProgressBar" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/UserSiteMap.ascx" TagName="UserSiteMap" TagPrefix="uc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKEd" %>
<%@ Register Assembly="CustomPagingGridView" Namespace="CustomPagingGridView" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%" class="Table_Border_Black">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" style="height: 25px" class="Table_Bck1">
                    <tr>
                        <td class="table_td_left">
                            <asp:Label ID="Label1" runat="server" Text="Adjust Calculations" CssClass="Table_Title_Label_White">
                            </asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 30px" class="table_td_left">
                <uc1:UserSiteMap ID="UserSiteMap2" runat="server" />
            </td>
        </tr>
    </table>
    <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <contenttemplate>--%>
    <table cellpadding="0" cellspacing="0" width="100%" class="">
        <tr>
            <td class="table_td_left" colspan="2">
                <asp:Label ID="Label7" runat="server" Text="Adjust Calculations" CssClass="Link_Label_Bold">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td class="table_td_left" colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td class="table_td_left" colspan="2">
                <table class="Table_Border_Black" cellspacing="0" cellpadding="0" width="100%">
                    <tbody>
                        <tr>
                            <th scope="colgroup" style="text-align: left; width: 334px;">
                                <span style="font-size: medium">Car Calculations</span><br /><br />
                                &nbsp;&nbsp;&nbsp;
                                Valuation Type:&nbsp;&nbsp;
                                <asp:DropDownList ID="ddlType" runat="server">
                                 <asp:ListItem Text="CAP Clean" Value="0" />
                                 <asp:ListItem Text="CAP Average" Value="1" />
                                 <asp:ListItem Text="CAP Below" Value="2" />
                                 <asp:ListItem Text="Avg of Clean Average" Value="3" />
                                </asp:DropDownList>
                                <br />
                                <br />
&nbsp;&nbsp; % Markup:
                                <asp:TextBox ID="txtPercent" runat="server" Width="46px"></asp:TextBox>
                                <br />
                                <br />
&nbsp;&nbsp;&nbsp; £ Markup:
                                <asp:TextBox ID="txtPounds" runat="server" Width="46px"></asp:TextBox>
                                <br />
                            </th>
                            <th scope="colgroup" style="text-align: left"><span style="font-size: medium">Van 
                                Calculations</span><br /><br />
                                &nbsp;&nbsp;&nbsp;
                                Valuation Type:&nbsp;&nbsp;
                                <asp:DropDownList ID="ddlVan" runat="server">
                                 <asp:ListItem Text="CAP Clean" Value="0" />
                                 <asp:ListItem Text="CAP Average" Value="1" />
                                 <asp:ListItem Text="CAP Below" Value="2" />
                                 <asp:ListItem Text="Avg of Clean Average" Value="3" />
                                </asp:DropDownList>
                                <br />
                                <br />
&nbsp;&nbsp; % Markup:
                                <asp:TextBox ID="txtVanPercent" runat="server" Width="46px"></asp:TextBox>
                                <br />
                                <br />
&nbsp;&nbsp;&nbsp; £ Markup:
                                <asp:TextBox ID="txtVanPounds" runat="server" Width="46px"></asp:TextBox>
                                <br />
                            </th>
                        </tr>
                        <tr>
                            <th scope="colgroup" style="text-align: left; width: 334px;">
                                <br />
                                <br />
                                <asp:Label ID="lblSaved" runat="server" Text="Label" Visible="false" style="color: #FF0000">Saved - values updated in database</asp:Label>
                            </th>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" CssClass="button1" 
                    OnClick="btnSave_Click" Text="Save" />
                <br />
            </td>
</tr>
    </table>
    <%--            </contenttemplate>
    </asp:UpdatePanel>--%>
    <asp:Label ID="lblMode" runat="server" Text="" Visible="false"></asp:Label>
    <br />
    <AjaxToolKit:FilteredTextBoxExtender ID="ftbMarkup" runat="server" TargetControlID="txtPercent" ValidChars="-" FilterType="Custom,Numbers"/>
    <AjaxToolKit:FilteredTextBoxExtender ID="ftbMarkup1" runat="server" TargetControlID="txtPounds" ValidChars="-" FilterType="Custom,Numbers"/>
    <AjaxToolKit:FilteredTextBoxExtender ID="ftbMarkup2" runat="server" TargetControlID="txtVanPounds" ValidChars="-" FilterType="Custom,Numbers"/>
    <AjaxToolKit:FilteredTextBoxExtender ID="ftbMarkup3" runat="server" TargetControlID="txtVanPercent" ValidChars="-" FilterType="Custom,Numbers"/>

</asp:Content>
