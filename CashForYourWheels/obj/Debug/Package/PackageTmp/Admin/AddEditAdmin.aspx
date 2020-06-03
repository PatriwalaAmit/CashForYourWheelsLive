<%@ Page Language="C#" MasterPageFile="~/Master/AdminPanel2.master" AutoEventWireup="true" Inherits="Admin_AddEditAdmin" Title="Manage AdminList" Codebehind="AddEditAdmin.aspx.cs" %>

<%@ Register Assembly="CustomPagingGridView" Namespace="CustomPagingGridView" TagPrefix="cc1" %>
<%--<%@ Register Src="../UserControls/ProgressBar.ascx" TagName="ProgressBar" TagPrefix="uc2" %>--%>
<%@ Register Src="../UserControls/UserSiteMap.ascx" TagName="UserSiteMap" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%" class="Table_Border_Black">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" class="Table_Bck1" style="height: 25px">
                    <tr>
                        <td class="table_td_left">
                            <asp:Label ID="Labelqwq1" runat="server" Text="Manage Admin" CssClass="Table_Title_Label_White">
                            </asp:Label>
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
    <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <contenttemplate>--%>
    <table class="" cellspacing="0" cellpadding="0" width="100%">
        <tbody>
            <tr>
                <td class="table_td_left">
                    <asp:Label ID="Label3" runat="server" CssClass="label_blackbold10" Text="Admin List"></asp:Label>
                </td>
                <td class="table_td_right">
                    <asp:ImageButton ID="btnAddNew" runat="server" ImageUrl="~/Admin/Images/icon-add.png" OnClick="btnAddNew_Click"
                        CssClass="table_td_right" />
                    <asp:LinkButton ID="lnkbntNew" runat="server" CssClass="Link_Label_Bold" OnClick="lnkbntNew_Click"
                        Text="Add Admin"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td colspan="10">
                    <hr />
                </td>
            </tr>
            <tr>
                <td class="table_td_left" style="width: 25%;">
                    <table class="" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td class="table_td_left" width="25%">
                                <cc1:CustomePagingGrid ID="gvAdminList" runat="server" CssClass="gridview" Width="80%"
                                    AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="gvAdminList_PageIndexChanging"
                                    OnRowCommand="gvAdminList_RowCommand" PageSize="10">
                                    <PagerSettings PreviousPageText="Prev" LastPageText="Last" FirstPageText="First"
                                        NextPageText="Next" Mode="NextPreviousFirstLast" Position="Bottom"></PagerSettings>
                                    <EmptyDataTemplate>
                                        No Data Found.
                                    </EmptyDataTemplate>
                                    <PagerStyle ForeColor="Maroon" HorizontalAlign="Right"></PagerStyle>
                                    <Columns>
                                        <asp:TemplateField HeaderText="UserId" Visible="False">
                                            <edititemtemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("UserId") %>'></asp:TextBox>
                                </edititemtemplate>
                                            <itemtemplate>
                                    <asp:Label ID="lblUserId" runat="server" Text='<%# Bind("UserId") %>'></asp:Label>
                                </itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="User Name">
                                            <edititemtemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                                </edititemtemplate>
                                            <itemtemplate>
                                    <asp:LinkButton ID="lblCatName1" runat="server" Text='<%# Bind("UserName") %>' CommandName="CheckDetail"
                                        CommandArgument='<%# Bind("UserId") %>'></asp:LinkButton>
                                </itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email Id">
                                            <edititemtemplate>
                                    <asp:TextBox ID="TextBoxsdsa2" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                </edititemtemplate>
                                            <itemtemplate>
                                    <asp:LinkButton ID="lblCatName" runat="server" Text='<%# Bind("Email") %>' CommandName="CheckDetail"
                                        CommandArgument='<%# Bind("UserId") %>'></asp:LinkButton>
                                </itemtemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </cc1:CustomePagingGrid>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="table_td_left">
                    <table class="" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td class="table_td_right">
                            </td>
                            <td class="table_td_right">
                                <fieldset>
                                    <legend>Search Admin</legend>
                                    <asp:Label ID="lblList" runat="server" Text="List Admin By"></asp:Label>
                                    <asp:DropDownList ID="ddlList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlList_SelectedIndexChanged">
                                        <asp:ListItem>UserName</asp:ListItem>
                                        <asp:ListItem>Email Address</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtSearch" runat="server" CssClass="textbox" Width="10%"></asp:TextBox>
                                    <asp:Button ID="btnGo" runat="server" CssClass="button1" Text="Go" OnClick="btnGo_Click" />
                                    <asp:Button ID="btnShowAll" runat="server" CssClass="button1" Text="Show All" OnClick="btnShowAll_Click" />
                                </fieldset>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_td_left" colspan="4">
                                <fieldset>
                                    <legend>Manage Admin</legend>
                                    <table cellspacing="0" cellpadding="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="table_td_left">
                                                    <asp:Label ID="Label4" runat="server" CssClass="label_blackbold10" Text="Add Admin"></asp:Label>
                                                </td>
                                                <td align="right" class="Itemfonts1">
                                                    (<span class="red">*</span>) Required Fields &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="table_td_left" width="55%" colspan="2">
                                                    <table cellspacing="0" cellpadding="0" width="100%">
                                                        <%--class="Table_Border_Black"--%>
                                                        <tbody>
                                                            <tr>
                                                                <td class="table_td_left">
                                                                    <asp:Label ID="lblFirstName" runat="server" Text="First Name:" CssClass="label"></asp:Label>
                                                                </td>
                                                                <td class="table_td_left">
                                                                    <asp:TextBox ID="txtFirstName" runat="server" ValidationGroup="CheckAtSave" CssClass="textbox"
                                                                        TabIndex="1"></asp:TextBox>&nbsp;<span class="red">*</span>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="CheckFirstName" runat="server" ControlToValidate="txtFirstName"
                                                                        ErrorMessage="<b>Required Field Missing</b><br />A First Name is required." Display="None"
                                                                        ValidationGroup="CheckAtSave">
                                                                    </asp:RequiredFieldValidator>
                                                                    <AjaxToolKit:ValidatorCalloutExtender ID="NReqE" runat="Server" HighlightCssClass="validatorCalloutHighlight"
                                                                        TargetControlID="CheckFirstName">
                                                                    </AjaxToolKit:ValidatorCalloutExtender>
                                                                    <%--<AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                        TargetControlID="txtFirstName" FilterType="Custom, LowercaseLetters,UppercaseLetters "
                                                        ValidChars=" ">
                                                    </AjaxToolKit:FilteredTextBoxExtender>--%>
                                                                    <asp:RegularExpressionValidator ID="ChekcNamefirst" runat="server" ControlToValidate="txtFirstName"
                                                                        ErrorMessage="Enter Proper First Name<br />" Display="None" ValidationGroup="CheckAtSave">
                                                                    </asp:RegularExpressionValidator>
                                                                    <AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="Server"
                                                                        HighlightCssClass="validatorCalloutHighlight" TargetControlID="ChekcNamefirst">
                                                                    </AjaxToolKit:ValidatorCalloutExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="table_td_left">
                                                                    <asp:Label ID="lblLastName" runat="server" Text="Last Name:" CssClass="label"></asp:Label>
                                                                </td>
                                                                <td class="table_td_left">
                                                                    <asp:TextBox ID="txtLastName" runat="server" ValidationGroup="CheckAtSave" CssClass="textbox"
                                                                        TabIndex="2"></asp:TextBox>&nbsp;<span class="red">*</span>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="CheckLastName" runat="server" ControlToValidate="txtLastName"
                                                                        ErrorMessage="<b>Required Field Missing</b><br />Last Name is required." Display="None"
                                                                        ValidationGroup="CheckAtSave">
                                                                    </asp:RequiredFieldValidator>
                                                                    <AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="Server"
                                                                        HighlightCssClass="validatorCalloutHighlight" TargetControlID="CheckLastName">
                                                                    </AjaxToolKit:ValidatorCalloutExtender>
                                                                    <%--<AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                        TargetControlID="txtLastName" FilterType="Custom, LowercaseLetters,UppercaseLetters ">
                                                    </AjaxToolKit:FilteredTextBoxExtender>--%>
                                                                    <asp:RegularExpressionValidator ID="checklastnameforreg" runat="server" ControlToValidate="txtLastName"
                                                                        ErrorMessage="Enter Proper Last Name<br />" Display="None" ValidationGroup="CheckAtSave">
                                                                    </asp:RegularExpressionValidator>
                                                                    <AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="Server"
                                                                        HighlightCssClass="validatorCalloutHighlight" TargetControlID="checklastnameforreg">
                                                                    </AjaxToolKit:ValidatorCalloutExtender>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" visible="false">
                                                                <td class="table_td_left">
                                                                    <asp:Label ID="lblSex" runat="server" Text="Sex:" CssClass="label"></asp:Label>
                                                                </td>
                                                                <td class="table_td_left">
                                                                    <asp:RadioButtonList ID="rdoSex" runat="server" RepeatDirection="Horizontal" TabIndex="3">
                                                                        <asp:ListItem Text="Male" Value="Male" Selected="True"></asp:ListItem>
                                                                        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td class="table_td_left">
                                                                    <asp:RequiredFieldValidator ID="CheckSex" runat="server" ControlToValidate="rdoSex"
                                                                        ErrorMessage="<b>Required Field Missing</b><br />User's Sex is required." Display="None"
                                                                        ValidationGroup="CheckAtSave">
                                                                    </asp:RequiredFieldValidator>
                                                                    <AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="Server"
                                                                        HighlightCssClass="validatesex" TargetControlID="CheckSex">
                                                                    </AjaxToolKit:ValidatorCalloutExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="table_td_left">
                                                                    <asp:Label ID="lblEmail" runat="server" Text="Email Address(UID):" CssClass="label"></asp:Label>
                                                                </td>
                                                                <td class="table_td_left">
                                                                    <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="CheckAtSave" CssClass="textbox"
                                                                        TabIndex="4"></asp:TextBox>&nbsp;<span class="red">*</span>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="CheckEmail" runat="server" ControlToValidate="txtEmail"
                                                                        ErrorMessage="<b>Required Field Missing</b><br />Email Address is required."
                                                                        Display="None" ValidationGroup="CheckAtSave">
                                                                    </asp:RequiredFieldValidator>
                                                                    <AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="Server"
                                                                        HighlightCssClass="validatorCalloutHighlight" TargetControlID="CheckEmail">
                                                                    </AjaxToolKit:ValidatorCalloutExtender>
                                                                    <asp:RegularExpressionValidator ID="CheckEmailId" runat="server" ControlToValidate="txtEmail"
                                                                        ErrorMessage="Enter proper email address" Display="None" ValidationGroup="CheckAtSave"
                                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                    <AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="Server"
                                                                        HighlightCssClass="validatorCalloutHighlight" TargetControlID="CheckEmailId">
                                                                    </AjaxToolKit:ValidatorCalloutExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="table_td_left">
                                                                    <asp:Label ID="lblPassword" runat="server" Text="Password:" CssClass="label"></asp:Label>
                                                                </td>
                                                                <td class="table_td_left">
                                                                    <asp:TextBox ID="txtPassword" runat="server" ValidationGroup="CheckAtSave" CssClass="textbox"
                                                                        TabIndex="5" TextMode="Password"></asp:TextBox>&nbsp;<span class="red">*</span>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="CheckPassword" runat="server" ControlToValidate="txtPassword"
                                                                        ErrorMessage="<b>Required Field Missing</b><br />Password is required." Display="None"
                                                                        ValidationGroup="CheckAtSave">
                                                                    </asp:RequiredFieldValidator>
                                                                    <AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="Server"
                                                                        HighlightCssClass="validatorCalloutHighlight" TargetControlID="CheckPassword">
                                                                    </AjaxToolKit:ValidatorCalloutExtender>
                                                                    <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                                        TargetControlID="txtPassword" FilterType="Custom, LowercaseLetters,UppercaseLetters,Numbers"
                                                                        ValidChars="@_*">
                                                                    </AjaxToolKit:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="table_td_left">
                                                                    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:" CssClass="label"></asp:Label>
                                                                </td>
                                                                <td class="table_td_left">
                                                                    <asp:TextBox ID="txtConfirmPassword" runat="server" ValidationGroup="CheckAtSave"
                                                                        CssClass="textbox" TabIndex="6" TextMode="Password"></asp:TextBox>&nbsp;<span class="red">*</span>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="CheckConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                                                                        ErrorMessage="<b>Required Field Missing</b><br />Confirm Password is required."
                                                                        Display="None" ValidationGroup="CheckAtSave">
                                                                    </asp:RequiredFieldValidator>
                                                                    <AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="Server"
                                                                        HighlightCssClass="validatorCalloutHighlight" TargetControlID="CheckConfirmPassword">
                                                                    </AjaxToolKit:ValidatorCalloutExtender>
                                                                    <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                                        TargetControlID="txtConfirmPassword" FilterType="Custom, LowercaseLetters,UppercaseLetters,Numbers"
                                                                        ValidChars="@_*">
                                                                    </AjaxToolKit:FilteredTextBoxExtender>
                                                                    <asp:CompareValidator ID="ComparePassword" ControlToValidate="txtConfirmPassword"
                                                                        ControlToCompare="txtPassword" ErrorMessage="Password Not matched" runat="server"
                                                                        Display="None"></asp:CompareValidator>
                                                                    <AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="Server"
                                                                        HighlightCssClass="validatorCalloutHighlight" TargetControlID="ComparePassword">
                                                                    </AjaxToolKit:ValidatorCalloutExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="table_td_left">
                                                                    <asp:Label ID="lblPhn" runat="server" Text="Phone Number:" CssClass="label"></asp:Label>
                                                                </td>
                                                                <td class="table_td_left">
                                                                    <asp:TextBox ID="txtPhn" runat="server" ValidationGroup="CheckAtSave" CssClass="textbox"
                                                                        TabIndex="15"></asp:TextBox>&nbsp;<span class="red">*</span>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="CheckPhn" runat="server" ControlToValidate="txtPhn"
                                                                        ErrorMessage="<b>Required Field Missing</b><br />Phone Number is required." Display="None"
                                                                        ValidationGroup="CheckAtSave">
                                                                    </asp:RequiredFieldValidator>
                                                                    <AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" runat="Server"
                                                                        HighlightCssClass="validatorCalloutHighlight" TargetControlID="CheckPhn">
                                                                    </AjaxToolKit:ValidatorCalloutExtender>
                                                                    <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                                                        TargetControlID="txtPhn" FilterType="Numbers">
                                                                    </AjaxToolKit:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" align="center" style="height: 22px">
                                                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="CheckAtSave"
                                                                        TabIndex="16" OnClientClick="return CheckForValue();" CssClass="button1" />
                                                                    <asp:Button ID="btnback" runat="server" Text="Back" CssClass="button1" OnClick="btnback_Click" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    <%--    </contenttemplate>
    </asp:UpdatePanel>--%>
    <asp:Label ID="lblMode" runat="server" Text="" Visible="false"></asp:Label>
   <%-- <uc2:ProgressBar ID="ProgressBar1" runat="server"></uc2:ProgressBar>--%>

    <script language="javascript" type="text/javascript">
    function CheckForValue()
    {
        var msg='';

        if(document.getElementById('<%= this.txtFirstName.ClientID %>').value=='')
        {
            msg=msg+'\n'+'-First Name is required';
            document.getElementById('<%= this.txtFirstName.ClientID %>').style.backgroundColor='lemonchiffon';
        }
        if(document.getElementById('<%= this.txtLastName.ClientID %>').value=='')
        {
            msg=msg+'\n'+'-Last Name is required';
            document.getElementById('<%= this.txtLastName.ClientID %>').style.backgroundColor='lemonchiffon';
        }
        if(document.getElementById('<%= this.txtEmail.ClientID %>').value=='')
        {
            msg=msg+'\n'+'-Email Address is required';
            document.getElementById('<%= this.txtEmail.ClientID %>').style.backgroundColor='lemonchiffon';
        }
        if(document.getElementById('<%= this.txtPassword.ClientID %>').value=='')
        {
            msg=msg+'\n'+'-Password is required';
            document.getElementById('<%= this.txtPassword.ClientID %>').style.backgroundColor='lemonchiffon';
        }
        if(document.getElementById('<%= this.txtConfirmPassword.ClientID %>').value=='')
        {
            msg=msg+'\n'+'-Confirm Password is required';
            document.getElementById('<%= this.txtConfirmPassword.ClientID %>').style.backgroundColor='lemonchiffon';
        }        
        if(document.getElementById('<%= this.txtPhn.ClientID %>').value=='')
        {
            msg=msg+'\n'+'-Phone Number is required';
            document.getElementById('<%= this.txtPhn.ClientID %>').style.backgroundColor='lemonchiffon';
        }

            if(msg!='')
            {
                var err='';
                alert('Please enter required field'+msg);
                return false;
            }
        }
    </script>

</asp:Content>
