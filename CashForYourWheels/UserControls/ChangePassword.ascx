<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="UserControls_ChangePassword" Codebehind="ChangePassword.ascx.cs" %>
 <link href="../Admin/CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
<table width="100%" cellspacing="1" cellpadding="3" border="0" align="center">
    <tbody>
      <%--  <tr class="gridview">
            <th style="width: 100%;" colspan="3">
                <img src="..\Images/menuicon.gif" alt="" />&nbsp; &nbsp;
                <asp:Label ID="lblsearch2" runat="server" Text="Change Password" CssClass="label_blackbold10"></asp:Label>
            </th>
        </tr>--%>
          <tr class="gridview">
            <th style="width: 100%; height: 24px;" colspan="2">
                <img src="../Images/menuicon.gif" alt="" />&nbsp; &nbsp;
                <asp:Label ID="lblsearch2" runat="server" Text="Change Password" CssClass="label_blackbold10"></asp:Label>
            </th>
        </tr>
        <tr>
            <td align="right" class="Itemfonts1" colspan="2">
                (<span class="red">*</span>) Required Fields &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <div>
                    <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*Old Password is not matched!Please enter proper password!"
                        Visible="False"></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td width="40%" align="right" class="simpletext">
                Old Password :
            </td>
            <td>
                <span class="red">
                    <asp:TextBox ID="txtOldPassword" runat="server" ValidationGroup="CheckAtSave" CssClass="textbox"
                        TabIndex="1" TextMode="Password"></asp:TextBox>&nbsp;<span class="red">*</span>
                    <asp:RequiredFieldValidator ID="CheckOldPassword" runat="server" ValidationGroup="CheckAtSave"
                        ErrorMessage="<b>Required Field Missing</b><br />Old Password is required." Display="None"
                        ControlToValidate="txtOldPassword">*</asp:RequiredFieldValidator><AjaxToolKit:ValidatorCalloutExtender
                            ID="ValidatorCalloutExtender1" runat="Server" HighlightCssClass="validatorCalloutHighlight"
                            TargetControlID="CheckOldPassword">
                        </AjaxToolKit:ValidatorCalloutExtender>
                </span>
            </td>
        </tr>
        <tr>
            <td width="40%" align="right" class="simpletext">
                New Password :</td>
            <td>
                <span class="red">
                    <asp:TextBox ID="txtNewPassword" runat="server" ValidationGroup="CheckAtSave" CssClass="textbox"
                        TabIndex="2" TextMode="Password">&nbsp;<span class="red">*</span>
                            
                    </asp:TextBox>&nbsp;<span class="red">*</span>
                    <asp:RequiredFieldValidator ID="CheckNewPassword" runat="server" ValidationGroup="CheckAtSave"
                        ErrorMessage="<b>Required Field Missing</b><br />New Password is required." Display="None"
                        ControlToValidate="txtNewPassword">*</asp:RequiredFieldValidator><AjaxToolKit:ValidatorCalloutExtender
                            ID="ValidatorCalloutExtender2" runat="Server" HighlightCssClass="validatorCalloutHighlight"
                            TargetControlID="CheckNewPassword">
                        </AjaxToolKit:ValidatorCalloutExtender>
                </span>
            </td>
        </tr>
        <tr>
            <td width="40%" align="right" class="simpletext">
                Confirm New Password :</td>
            <td>
                <span class="red">
                    <asp:TextBox ID="txtConfirmNewPass" runat="server" ValidationGroup="CheckAtSave"
                        CssClass="textbox" TabIndex="3" TextMode="Password"></asp:TextBox>&nbsp;<span class="red">*</span>
                        <asp:RequiredFieldValidator
                            ID="CheckConfirmNewPass" runat="server" ValidationGroup="CheckAtSave" ErrorMessage="<b>Required Field Missing</b><br />Confirm New Password is required."
                            Display="None" ControlToValidate="txtConfirmNewPass">*</asp:RequiredFieldValidator><AjaxToolKit:ValidatorCalloutExtender
                                ID="ValidatorCalloutExtender3" runat="Server" HighlightCssClass="validatorCalloutHighlight"
                                TargetControlID="CheckConfirmNewPass">
                            </AjaxToolKit:ValidatorCalloutExtender>
                    <asp:CompareValidator ID="ComparePass" runat="server" ValidationGroup="CheckAtSave"
                        ErrorMessage="<b>Required Field Missing</b><br />New Password and Confirm Password must be same."
                        Display="None" ControlToValidate="txtConfirmNewPass" ControlToCompare="txtNewPassword">*</asp:CompareValidator><AjaxToolKit:ValidatorCalloutExtender
                            ID="checkComparePass" runat="Server" HighlightCssClass="validatorCalloutHighlight"
                            TargetControlID="ComparePass">
                        </AjaxToolKit:ValidatorCalloutExtender>
                </span>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;</td>
            <td colspan="2">
                <div id="ctl00_CPH1_UpdatePanel1">
                    &nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Change Password" CssClass="button1"
                        ValidationGroup="CheckAtSave" OnClick="btnSubmit_Click" TabIndex="4" />&nbsp;<asp:Button
                            ID="btnCancel" runat="server" CssClass="button1" OnClick="btnCancel_Click" Text="Back"
                            TabIndex="5" /></div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCustomerId" runat="server" Visible="False"></asp:Label><asp:Label
                    ID="lblPassword" runat="server" Visible="False"></asp:Label></td>
            <td colspan="2">
            </td>
        </tr>
    </tbody>
</table>

<script language="javascript" type="text/javascript">
//    function fnCheckValue()
//    {
//        var msg='';
//        if(document.getElementById('<%= this.txtOldPassword.ClientID %>').value=='')
//        {
//            msg=msg+'\n'+'-Old Password is required';
//            document.getElementById('<%= this.txtOldPassword.ClientID %>').style.backgroundColor='lemonchiffon';
//        }
//        if(document.getElementById('<%= this.txtNewPassword.ClientID %>').value=='')
//        {
//            msg=msg+'\n'+'-New Password is required';
//            document.getElementById('<%= this.txtNewPassword.ClientID %>').style.backgroundColor='lemonchiffon';
//        }
//        if(document.getElementById('<%= this.txtConfirmNewPass.ClientID %>').value=='')
//        {
//            msg=msg+'\n'+'-Confirm New Password is required';
//            document.getElementById('<%= this.txtConfirmNewPass.ClientID %>').style.backgroundColor='lemonchiffon';
//        }
//        if(msg!='')
//        {
//            var err='Enter Required value(s).' + msg;
//            alert(msg);
//            return false;
//        }
//    }
</script>

