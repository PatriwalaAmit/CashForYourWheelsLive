<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminPanel.master" AutoEventWireup="true" Inherits="Admin_branchtime" Codebehind="branchtime.aspx.cs" %>

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
                            <asp:Label ID="Label1" runat="server" Text="Branch Timing" CssClass="Table_Title_Label_White">
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

    <table cellpadding="0" cellspacing="0" width="100%" class="">
        <tr>
            <td class="table_td_left" colspan="2">
                <asp:Label ID="Label7" runat="server" Text="Branch Timing Management" CssClass="Link_Label_Bold">
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
                            <th scope="colgroup"></th>
                        </tr>
                        <tr>
                            <td class="table_td_left">
                                <table cellspacing="10" cellpadding="0" width="100%" class="">
                                    <tbody>
                                        <tr>
                                            <td class="table_td_left">
                                                <asp:Label ID="Label2" runat="server" CssClass="label" Text="Location Name:"></asp:Label>
                                            </td>
                                            <td class="table_td_left">
                                                <asp:DropDownList ID="ddlBranchName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBranchName_SelectedIndexChange"></asp:DropDownList>
                                                &nbsp;<span class="red">*</span>&nbsp;&nbsp;<asp:CheckBox ID="chkBranchClosed" Text="Is Branch Closed?" runat="server" Checked="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table_td_left">
                                                Monday
                                            </td>
                                            <td class="table_td_left" style="vertical-align:top">
                                                FROM : 
                                                <asp:DropDownList ID="ddlMondayFrom" runat="server">
                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="1:30" Value="1:30"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="2:30" Value="2:30"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="3:30" Value="3:30"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="4:30" Value="4:30"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="5:30" Value="5:30"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="6:30" Value="6:30"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="7:30" Value="7:30"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="8:30" Value="8:30"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                    <asp:ListItem Text="9:30" Value="9:30"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="10:30" Value="10:30"></asp:ListItem>
                                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                    <asp:ListItem Text="11:30" Value="11:30"></asp:ListItem>
                                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                    <asp:ListItem Text="12:30" Value="12:30"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlMondayFromAMPM" runat="server">
                                                    <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                </asp:DropDownList>

                                                TO : 
                                                <asp:DropDownList ID="ddlMondayTo" runat="server">
                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="1:30" Value="1:30"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="2:30" Value="2:30"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="3:30" Value="3:30"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="4:30" Value="4:30"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="5:30" Value="5:30"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="6:30" Value="6:30"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="7:30" Value="7:30"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="8:30" Value="8:30"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                    <asp:ListItem Text="9:30" Value="9:30"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="10:30" Value="10:30"></asp:ListItem>
                                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                    <asp:ListItem Text="11:30" Value="11:30"></asp:ListItem>
                                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                    <asp:ListItem Text="12:30" Value="12:30"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlMondayToAMPM" runat="server">
                                                    <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                            <tr>
                                            <td class="table_td_left">
                                                Tuesday
                                            </td>
                                            <td class="table_td_left" style="vertical-align:top">
                                                FROM : 
                                                <asp:DropDownList ID="ddlTuesdayFrom" runat="server">
                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="1:30" Value="1:30"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="2:30" Value="2:30"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="3:30" Value="3:30"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="4:30" Value="4:30"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="5:30" Value="5:30"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="6:30" Value="6:30"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="7:30" Value="7:30"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="8:30" Value="8:30"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                    <asp:ListItem Text="9:30" Value="9:30"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="10:30" Value="10:30"></asp:ListItem>
                                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                    <asp:ListItem Text="11:30" Value="11:30"></asp:ListItem>
                                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                    <asp:ListItem Text="12:30" Value="12:30"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlTuesdayFromAMPM" runat="server">
                                                    <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                </asp:DropDownList>

                                                TO : 
                                                <asp:DropDownList ID="ddlTuesdayTo" runat="server">
                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="1:30" Value="1:30"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="2:30" Value="2:30"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="3:30" Value="3:30"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="4:30" Value="4:30"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="5:30" Value="5:30"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="6:30" Value="6:30"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="7:30" Value="7:30"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="8:30" Value="8:30"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                    <asp:ListItem Text="9:30" Value="9:30"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="10:30" Value="10:30"></asp:ListItem>
                                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                    <asp:ListItem Text="11:30" Value="11:30"></asp:ListItem>
                                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                    <asp:ListItem Text="12:30" Value="12:30"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlTuesdayToAMPM" runat="server">
                                                    <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="table_td_left">
                                                Wednesday
                                            </td>
                                            <td class="table_td_left" style="vertical-align:top">
                                                FROM : 
                                                <asp:DropDownList ID="ddlWednesdayFrom" runat="server">
                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="1:30" Value="1:30"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="2:30" Value="2:30"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="3:30" Value="3:30"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="4:30" Value="4:30"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="5:30" Value="5:30"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="6:30" Value="6:30"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="7:30" Value="7:30"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="8:30" Value="8:30"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                    <asp:ListItem Text="9:30" Value="9:30"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="10:30" Value="10:30"></asp:ListItem>
                                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                    <asp:ListItem Text="11:30" Value="11:30"></asp:ListItem>
                                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                    <asp:ListItem Text="12:30" Value="12:30"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlWednesdayFromAMPM" runat="server">
                                                    <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                </asp:DropDownList>

                                                TO : 
                                                <asp:DropDownList ID="ddlWednesdayTo" runat="server">
                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="1:30" Value="1:30"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="2:30" Value="2:30"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="3:30" Value="3:30"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="4:30" Value="4:30"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="5:30" Value="5:30"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="6:30" Value="6:30"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="7:30" Value="7:30"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="8:30" Value="8:30"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                    <asp:ListItem Text="9:30" Value="9:30"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="10:30" Value="10:30"></asp:ListItem>
                                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                    <asp:ListItem Text="11:30" Value="11:30"></asp:ListItem>
                                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                    <asp:ListItem Text="12:30" Value="12:30"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlWednesdayToAMPM" runat="server">
                                                    <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table_td_left">
                                                Thursday
                                            </td>
                                            <td class="table_td_left" style="vertical-align:top">
                                                FROM : 
                                                <asp:DropDownList ID="ddlThursdayFrom" runat="server">
                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="1:30" Value="1:30"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="2:30" Value="2:30"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="3:30" Value="3:30"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="4:30" Value="4:30"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="5:30" Value="5:30"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="6:30" Value="6:30"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="7:30" Value="7:30"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="8:30" Value="8:30"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                    <asp:ListItem Text="9:30" Value="9:30"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="10:30" Value="10:30"></asp:ListItem>
                                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                    <asp:ListItem Text="11:30" Value="11:30"></asp:ListItem>
                                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                    <asp:ListItem Text="12:30" Value="12:30"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlThursdayFromAMPM" runat="server">
                                                    <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                </asp:DropDownList>

                                                TO : 
                                                <asp:DropDownList ID="ddlThursdayTo" runat="server">
                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="1:30" Value="1:30"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="2:30" Value="2:30"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="3:30" Value="3:30"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="4:30" Value="4:30"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="5:30" Value="5:30"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="6:30" Value="6:30"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="7:30" Value="7:30"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="8:30" Value="8:30"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                    <asp:ListItem Text="9:30" Value="9:30"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="10:30" Value="10:30"></asp:ListItem>
                                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                    <asp:ListItem Text="11:30" Value="11:30"></asp:ListItem>
                                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                    <asp:ListItem Text="12:30" Value="12:30"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlThursdayToAMPM" runat="server">
                                                    <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="table_td_left">
                                                Friday
                                            </td>
                                            <td class="table_td_left" style="vertical-align:top">
                                                FROM : 
                                                <asp:DropDownList ID="ddlFridayFrom" runat="server">
                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="1:30" Value="1:30"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="2:30" Value="2:30"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="3:30" Value="3:30"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="4:30" Value="4:30"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="5:30" Value="5:30"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="6:30" Value="6:30"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="7:30" Value="7:30"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="8:30" Value="8:30"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                    <asp:ListItem Text="9:30" Value="9:30"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="10:30" Value="10:30"></asp:ListItem>
                                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                    <asp:ListItem Text="11:30" Value="11:30"></asp:ListItem>
                                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                    <asp:ListItem Text="12:30" Value="12:30"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlFridayFromAMPM" runat="server">
                                                    <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                </asp:DropDownList>

                                                TO : 
                                                <asp:DropDownList ID="ddlFridayTo" runat="server">
                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="1:30" Value="1:30"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="2:30" Value="2:30"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="3:30" Value="3:30"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="4:30" Value="4:30"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="5:30" Value="5:30"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="6:30" Value="6:30"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="7:30" Value="7:30"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="8:30" Value="8:30"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                    <asp:ListItem Text="9:30" Value="9:30"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="10:30" Value="10:30"></asp:ListItem>
                                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                    <asp:ListItem Text="11:30" Value="11:30"></asp:ListItem>
                                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                    <asp:ListItem Text="12:30" Value="12:30"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlFridayToAMPM" runat="server">
                                                    <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="table_td_left">
                                                Saturday
                                            </td>
                                            <td class="table_td_left" style="vertical-align:top">
                                                FROM : 
                                                <asp:DropDownList ID="ddlSaturdayFrom" runat="server">
                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="1:30" Value="1:30"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="2:30" Value="2:30"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="3:30" Value="3:30"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="4:30" Value="4:30"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="5:30" Value="5:30"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="6:30" Value="6:30"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="7:30" Value="7:30"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="8:30" Value="8:30"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                    <asp:ListItem Text="9:30" Value="9:30"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="10:30" Value="10:30"></asp:ListItem>
                                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                    <asp:ListItem Text="11:30" Value="11:30"></asp:ListItem>
                                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                    <asp:ListItem Text="12:30" Value="12:30"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlSaturdayFromAMPM" runat="server">
                                                    <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                </asp:DropDownList>

                                                TO : 
                                                <asp:DropDownList ID="ddlSaturdayTo" runat="server">
                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="1:30" Value="1:30"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="2:30" Value="2:30"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="3:30" Value="3:30"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="4:30" Value="4:30"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="5:30" Value="5:30"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="6:30" Value="6:30"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="7:30" Value="7:30"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="8:30" Value="8:30"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                    <asp:ListItem Text="9:30" Value="9:30"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="10:30" Value="10:30"></asp:ListItem>
                                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                    <asp:ListItem Text="11:30" Value="11:30"></asp:ListItem>
                                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                    <asp:ListItem Text="12:30" Value="12:30"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlSaturdayToAMPM" runat="server">
                                                    <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="table_td_left">
                                                Sunday
                                            </td>
                                            <td class="table_td_left" style="vertical-align:top">
                                                FROM : 
                                                <asp:DropDownList ID="ddlSundayFrom" runat="server">
                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="1:30" Value="1:30"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="2:30" Value="2:30"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="3:30" Value="3:30"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="4:30" Value="4:30"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="5:30" Value="5:30"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="6:30" Value="6:30"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="7:30" Value="7:30"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="8:30" Value="8:30"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                    <asp:ListItem Text="9:30" Value="9:30"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="10:30" Value="10:30"></asp:ListItem>
                                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                    <asp:ListItem Text="11:30" Value="11:30"></asp:ListItem>
                                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                    <asp:ListItem Text="12:30" Value="12:30"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlSundayFromAMPM" runat="server">
                                                    <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                </asp:DropDownList>

                                                TO : 
                                                <asp:DropDownList ID="ddlSundayTo" runat="server">
                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="1:30" Value="1:30"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="2:30" Value="2:30"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="3:30" Value="3:30"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="4:30" Value="4:30"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="5:30" Value="5:30"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="6:30" Value="6:30"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="7:30" Value="7:30"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="8:30" Value="8:30"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                    <asp:ListItem Text="9:30" Value="9:30"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="10:30" Value="10:30"></asp:ListItem>
                                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                    <asp:ListItem Text="11:30" Value="11:30"></asp:ListItem>
                                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                    <asp:ListItem Text="12:30" Value="12:30"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlSundayToAMPM" runat="server">
                                                    <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>                                                                                                             
                                        <tr>
                                            <td class="table_td_center" colspan="2">
                                                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label>
                                                <br />
                                                <asp:Button ID="imgbtn_Insert" OnClick="imgbtn_Insert_Click" runat="server" ValidationGroup="addrecord"
                                                    CausesValidation="true" Text="Save" CssClass="button1" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>

    </table>

</asp:Content>

