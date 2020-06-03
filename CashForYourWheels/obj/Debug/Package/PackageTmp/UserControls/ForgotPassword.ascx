<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="UserControls_ForgotPassword" Codebehind="ForgotPassword.ascx.cs" %>
<asp:Panel ID="Panel1" runat="server" Width="100%" CssClass="tableborder">
    <table width="100%" cellspacing="1" cellpadding="3" border="0" align="center" class="tableborder">
        <tbody>
            <tr class="gridview">
                <th scope="col" style="width: 100%; height: 24px;" colspan="2">
                    <asp:Image ID="mainimage" runat="server" ImageUrl="~/Images/menuicon.gif" />&nbsp;
                    &nbsp;
                    <asp:Label ID="lblsearch2" runat="server" Text="Forgot Password ? " CssClass="label_blackbold10"></asp:Label>
                </th>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <span style="font-weight: bold;" class="error" id="ctl00_CPH1_lblError" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="color: Red; display: none;" id="ctl00_CPH1_vsummary">
                    </div>
                </td>
            </tr>
            <tr>
                <td width="30%" align="right" class="simpletext">
                    Email Address :</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="CheckAtSave" CssClass="textbox"></asp:TextBox><asp:RequiredFieldValidator
                        ID="CheckEmail" runat="server" ValidationGroup="CheckAtSave" ErrorMessage="<b>Required Field Missing</b><br />Email Address is required."
                        Display="None" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator><AjaxToolKit:ValidatorCalloutExtender
                            ID="ValidatorCalloutExtender1" runat="Server" HighlightCssClass="validatorCalloutHighlight"
                            TargetControlID="CheckEmail">
                        </AjaxToolKit:ValidatorCalloutExtender>
                    <asp:RegularExpressionValidator ID="CheckForEmailAdd" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="<b>Required Field Missing</b><br />Email Address is not proper."
                        Display="None" ValidationGroup="CheckAtSave" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><AjaxToolKit:ValidatorCalloutExtender
                            ID="ValidatorCalloutExtender2" runat="Server" HighlightCssClass="validatorCalloutHighlight"
                            TargetControlID="CheckForEmailAdd">
                        </AjaxToolKit:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td align="right" class="simpletext">
                    Question :</td>
                <td>
                    <asp:DropDownList ID="ddlQuestion" runat="server" CssClass="combobox_auto" TabIndex="7"
                        ValidationGroup="CheckAtSave">
                        <asp:ListItem>What is your father's middle name?</asp:ListItem>
                        <asp:ListItem>What was the name of your first school?</asp:ListItem>
                        <asp:ListItem>Who was your childhood hero?</asp:ListItem>
                        <asp:ListItem>What is your favorite pastime?</asp:ListItem>
                        <asp:ListItem>What is your all-time favorite sports team?</asp:ListItem>
                        <asp:ListItem>What was your high school mascot?</asp:ListItem>
                        <asp:ListItem>What make was your first car or bike?</asp:ListItem>
                        <asp:ListItem>Where did you first meet your spouse?</asp:ListItem>
                        <asp:ListItem>What is your pet's name?</asp:ListItem>
                    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ValidationGroup="CheckAtSave" ErrorMessage="<b>Required Field Missing</b><br />Question is required."
                        Display="None" ControlToValidate="ddlQuestion">*</asp:RequiredFieldValidator><AjaxToolKit:ValidatorCalloutExtender
                            ID="ValidatorCalloutExtender3" runat="Server" HighlightCssClass="validatorCalloutHighlight"
                            TargetControlID="RequiredFieldValidator1">
                        </AjaxToolKit:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td align="right" class="simpletext">
                    Answer :</td>
                <td>
                    <asp:TextBox ID="txtAnswer" runat="server" ValidationGroup="CheckAtSave" CssClass="textbox"></asp:TextBox><asp:RequiredFieldValidator
                        ID="CheckAnswer" runat="server" ControlToValidate="txtAnswer" ErrorMessage="<b>Required Field Missing</b><br />Answer is required."
                        Display="None" ValidationGroup="CheckAtSave">
                    </asp:RequiredFieldValidator><AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender8"
                        runat="Server" HighlightCssClass="validatorCalloutHighlight" TargetControlID="CheckAnswer">
                    </AjaxToolKit:ValidatorCalloutExtender>
                    <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                        TargetControlID="txtAnswer" FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers">
                    </AjaxToolKit:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td style="height: 30px;">
                    &nbsp;
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button1" ValidationGroup="CheckAtSave"
                        OnClick="btnSubmit_Click" OnClientClick="return fnCheckValue();" />
                    <input type="reset" id="btnreset" value="Cancel" onclick="fnHide()" class="button1" /></td>
            </tr>
        </tbody>
    </table>
</asp:Panel>

<script language="javascript" type="text/javascript">
    function fnHide()
    {
        document.getElementById('<%= this.Panel1.ClientID %>').style.visibility='hidden';
        document.getElementById('<%= this.Panel1.ClientID %>').style.display='block';
    }
    function fnCheckValue()
    {
        var msg='';
        if(document.getElementById('<%= this.txtEmail.ClientID %>').value=='')
        {
            msg=msg+'\n'+'-Email is required';
            document.getElementById('<%= this.txtEmail.ClientID %>').style.backgroundColor='lemonchiffon';
        }
        var IndexValue1 = document.getElementById('<%= this.ddlQuestion.ClientID %>').selectedIndex;
        if(IndexValue1<=0)
        {
            msg=msg+'\n'+'-Question is required';
            document.getElementById('<%= this.ddlQuestion.ClientID %>').style.backgroundColor='lemonchiffon';
        }
        if(document.getElementById('<%= this.txtAnswer.ClientID %>').value=='')
        {
            msg=msg+'\n'+'-Answer is required';
            document.getElementById('<%= this.txtAnswer.ClientID %>').style.backgroundColor='lemonchiffon';
        }
        if(msg!='')
        {
            var err='Enter Required value(s).' + '\n' +msg;
            alert(msg);
            return false;
        }
    }
</script>

