<%@ Page Language="C#" AutoEventWireup="true" Inherits="Email" Codebehind="Email.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tell To Friend</title>
    <link href="Css/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <%--<AjaxToolKit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />--%>
      
        <table cellpadding="0" cellspacing="0" width="100%" border="0">
            <tr>
                <td>
                    <table cellpadding="0px" cellspacing="0px" width="100%" >
                        <tr>
                            <td class="table_td_left">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo.gif" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
            <tr>
                <td class="table_td_left">
                  <%-- <asp:Label ID="lblMainProductName" runat="server" CssClass="Link_Label_Bold" Text="Tell Your Friend About This Product"></asp:Label>--%>
                  <h1>Tell A Friends</h1>
                    </td>
            </tr>
           
            <tr>
                <td align=center >
                    <table cellpadding="0" cellspacing="0" border="0" width="70%" style="margin-right:110px;" class="gridview">
                        <tr>
                            <td class="table_td_left" >
                                <asp:Label ID="lblName" runat="server" Text="Your Name :" CssClass="lblbold"></asp:Label>
                            </td>
                            <td class="table_td_left" style="width: 206px">
                                <asp:TextBox ID="txtName" runat="server" CssClass="textbox" ValidationGroup="CheckForMail"></asp:TextBox><asp:RequiredFieldValidator ID="CheckName" runat="server" ValidationGroup="CheckForMail"
                                    ErrorMessage="<b>Required Field Missing</b><br />Your Name is required." Display="None"
                                    ControlToValidate="txtName">*</asp:RequiredFieldValidator><AjaxToolKit:ValidatorCalloutExtender ID="NReqE" runat="Server" HighlightCssClass="validatorCalloutHighlight"
                                    TargetControlID="CheckName">
                                </AjaxToolKit:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_td_left">
                                <asp:Label ID="lblEmail" runat="server" Text="Your Email Address :" CssClass="lblbold"></asp:Label>
                            </td>
                            <td class="table_td_left" style="width: 206px">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" ValidationGroup="CheckForMail"></asp:TextBox><asp:RequiredFieldValidator ID="CheckEmail" runat="server" ValidationGroup="CheckForMail"
                                    ErrorMessage="<b>Required Field Missing</b><br />Your Email Address is required."
                                    Display="None" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator><AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="Server"
                                    HighlightCssClass="validatorCalloutHighlight" TargetControlID="CheckEmail">
                                </AjaxToolKit:ValidatorCalloutExtender>
                                <asp:RegularExpressionValidator ID="CheckForEmailAdd" runat="server" ControlToValidate="txtEmail"
                                    ErrorMessage="<b>Required Field Missing</b><br />Email Address is not proper."
                                    Display="None" ValidationGroup="CheckForMail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="Server"
                                    HighlightCssClass="validatorCalloutHighlight" TargetControlID="CheckForEmailAdd">
                                </AjaxToolKit:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_td_left">
                                <asp:Label ID="lblFName" runat="server" Text="Your Friend's Name :" CssClass="lblbold"></asp:Label>
                            </td>
                            <td class="table_td_left" style="width: 206px">
                                <asp:TextBox ID="txtFName" runat="server" CssClass="textbox" ValidationGroup="CheckForMail"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="CheckForMail"
                                    ErrorMessage="<b>Required Field Missing</b><br />Your Friend's Name is required."
                                    Display="None" ControlToValidate="txtFName">*</asp:RequiredFieldValidator><AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="Server"
                                    HighlightCssClass="validatorCalloutHighlight" TargetControlID="RequiredFieldValidator1">
                                </AjaxToolKit:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_td_left">
                                <asp:Label ID="lblFEMail" runat="server" Text="Your Friend's Email Address :" CssClass="lblbold"></asp:Label>
                            </td>
                            <td class="table_td_left" style="width: 206px">
                                <asp:TextBox ID="txtFEmail" runat="server" CssClass="textbox" ValidationGroup="CheckForMail"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="CheckForMail"
                                    ErrorMessage="<b>Required Field Missing</b><br />Your Friend's Email Address is required."
                                    Display="None" ControlToValidate="txtFEmail">*</asp:RequiredFieldValidator><AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="Server"
                                    HighlightCssClass="validatorCalloutHighlight" TargetControlID="RequiredFieldValidator2">
                                </AjaxToolKit:ValidatorCalloutExtender>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFEmail"
                                    ErrorMessage="<b>Required Field Missing</b><br />Email Address is not proper."
                                    Display="None" ValidationGroup="CheckForMail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="Server"
                                    HighlightCssClass="validatorCalloutHighlight" TargetControlID="RegularExpressionValidator1">
                                </AjaxToolKit:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_td_left">
                                <asp:Label ID="Label1" runat="server" Text="Your Message :" CssClass="lblbold"></asp:Label>
                            </td>
                            <td class="table_td_left" style="width: 206px">
                                <asp:TextBox ID="txtMsg" runat="server" CssClass="textbox" ValidationGroup="CheckForMail"
                                    TextMode="MultiLine"  Width="250px" Height="100px" Rows="2"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="CheckForMail"
                                    ErrorMessage="<b>Required Field Missing</b><br />Message is required." Display="None"
                                    ControlToValidate="txtMsg">*</asp:RequiredFieldValidator><AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="Server"
                                    HighlightCssClass="validatorCalloutHighlight" TargetControlID="RequiredFieldValidator3">
                                </AjaxToolKit:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td class="table_td_left" style="width: 206px">
                                <asp:Button ID="btnSendMail" runat="server" Text="Send Mail" ValidationGroup="CheckForMail"
                                    CssClass="button1" OnClick="btnSendMail_Click" />
                                <asp:Button ID="btnClose" runat="server" Text="Close" OnClientClick="return fnClose();"
                                    CssClass="button1" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="text-align: center; padding: 3px">
                  <br />
                    <asp:Label ID="Label3" runat="server" Text="All Rights Reserved : @Company" CssClass="BlueFont"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Powered By  SOLUTIONS" CssClass="BlueFont"></asp:Label>
                    <br />
                                   </td>
            </tr>
        </table>
        
        

        <script language="javascript" type="text/javascript">
            function fnClose()
            {
                window.close();
            }
        </script>

    </form>
</body>
</html>
