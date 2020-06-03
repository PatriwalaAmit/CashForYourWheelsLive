<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_UserLogin" Codebehind="UserLogin.ascx.cs" %>
<table width="100%" cellspacing="1" cellpadding="3" border="0" align="center" class="tableborder">
    <tbody>
        <tr>
            <td align="right" class="simpletext" width="30%">
            </td>
            <td>
                <asp:Label ID="lblLoginError" runat="server" Text="" CssClass="ErrorLabel_10"></asp:Label></td>
        </tr>
        <tr>
            <td width="30%" align="right" class="simpletext">
                Email Address :
            </td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="textbox" ValidationGroup="CheckAtLogin"
                    TabIndex="1"></asp:TextBox><asp:RequiredFieldValidator ID="CheckEmail" runat="server"
                        ValidationGroup="CheckAtLogin" ErrorMessage="<b>Required Field Missing</b><br />Email Address is required."
                        Display="None" ControlToValidate="txtUsername">*</asp:RequiredFieldValidator><AjaxToolKit:ValidatorCalloutExtender
                            ID="ValidatorCalloutExtender1" runat="Server" HighlightCssClass="validatorCalloutHighlight"
                            TargetControlID="CheckEmail">
                        </AjaxToolKit:ValidatorCalloutExtender>
                <asp:RegularExpressionValidator ID="CheckForEmailAdd" runat="server" ControlToValidate="txtUsername"
                    ErrorMessage="<b>Required Field Missing</b><br />Email Address is not proper."
                    Display="None" ValidationGroup="CheckAtLogin" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><AjaxToolKit:ValidatorCalloutExtender
                        ID="ValidatorCalloutExtender2" runat="Server" HighlightCssClass="validatorCalloutHighlight"
                        TargetControlID="CheckForEmailAdd">
                    </AjaxToolKit:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td align="right" class="simpletext">
                Password :
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox" TextMode="Password"
                    ValidationGroup="CheckAtLogin" TabIndex="2"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ValidationGroup="CheckAtLogin" ErrorMessage="<b>Required Field Missing</b><br />Password is required."
                        Display="None" ControlToValidate="txtPassword">*</asp:RequiredFieldValidator><AjaxToolKit:ValidatorCalloutExtender
                            ID="ValidatorCalloutExtender3" runat="Server" HighlightCssClass="validatorCalloutHighlight"
                            TargetControlID="RequiredFieldValidator1">
                        </AjaxToolKit:ValidatorCalloutExtender>
                <AjaxToolKit:FilteredTextBoxExtender ID="checkpass" runat="server" FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers"
                    ValidChars="@_" TargetControlID="txtPassword">
                </AjaxToolKit:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td colspan="2">
                <div id="ctl00_CPH1_UpdatePanel1">
                    &nbsp;<asp:Button ID="btnLogin" runat="server" Text="Login With Existing Account"
                        CssClass="button1" OnClick="btnLogin_Click" ValidationGroup="CheckAtLogin" OnClientClick="return fnCheckLogin();"
                        TabIndex="3" />&nbsp;
                    <asp:Button ID="btnWithoutlogin" runat="server" Text="Place Order Without Account"
                        CssClass="button1" OnClick="btnWithoutlogin_Click" TabIndex="4" Width="200px" /></div>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="2" valign="top">
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td valign="top" colspan="2" class="simpletext">
                Don't Have an Account ? - <span>
                    <asp:LinkButton ID="btnNew" runat="server" Text="Sign Up Now" CssClass="Link_Label_Bold"
                        Font-Underline="true" OnClick="btnNew_Click"></asp:LinkButton></span></td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td style="height: 25px;" colspan="2" class="simpletext">
                Forgot Password ?
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Click Here" CssClass="Link_Label_Bold"
                    Font-Underline="true" OnClick="LinkButton1_Click" OnClientClick="return fnDisplay();"></asp:LinkButton></td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="2" style="height: 25px">
                <asp:Label ID="lblCheckOut" runat="server" Visible="false"></asp:Label></td>
        </tr>
    </tbody>
</table>

<script language="javascript" type="text/javascript">
    function fnCheckLogin()
    {
        var msg='';
        if(document.getElementById('<%= this.txtUsername.ClientID %>').value=='')
        {
            msg=msg+'\n'+'-Email is required';
            document.getElementById('<%= this.txtUsername.ClientID %>').style.backgroundColor='lemonchiffon';
        }
        if(document.getElementById('<%= this.txtPassword.ClientID %>').value=='')
        {
            msg=msg+'\n'+'-Password is required';
            document.getElementById('<%= this.txtPassword.ClientID %>').style.backgroundColor='lemonchiffon';
        }
        if(msg!='')
        {
            var err='Enter Required value(s).' + '\n' +msg;
            alert(msg);
            return false;
        }
    }
</script>

