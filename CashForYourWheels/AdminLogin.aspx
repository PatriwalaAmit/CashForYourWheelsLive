<%@ Page Language="C#" AutoEventWireup="true" Inherits="AdminLogin" Codebehind="AdminLogin.aspx.cs" %>

<%@ Register Src="UserControls/MemberLogin.ascx" TagName="MemberLogin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <link href="Admin/Css/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body class="Table_Bck2">
    <form id="form1" runat="server">
       <AjaxToolKit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
        <table cellpadding="0px" cellspacing="0px" width="100%">
            <tr>
                <td class="TitleScrip" style="text-align: Left; height: 35px">
                    <asp:Label ID="Label1" runat="server" Text="Welcome Admin" CssClass="Table_Title_Label_White"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 500px; vertical-align: middle; text-align: -moz-center;">
                    <uc1:MemberLogin ID="MemberLogin1" runat="server" UserType="1"></uc1:MemberLogin>
                </td>
            </tr>
            <tr>
                <td class="FooterScrip">
                    <asp:Label ID="Label3" runat="server" Text="All Rights Reserved : @Company" CssClass="Table_Title_Label_White"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Powered By  SOLUTIONS" CssClass="Table_Title_Label_OffWhite"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
