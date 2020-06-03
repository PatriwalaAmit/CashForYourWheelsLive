<%@ Page Language="C#" MasterPageFile="~/Master/AdminPanel2.master" AutoEventWireup="true" Inherits="Admin_AddEditNews" Title="Manage News" Codebehind="AddEditNews.aspx.cs" %>

<%@ Register Src="../UserControls/ProgressBar.ascx" TagName="ProgressBar" TagPrefix="uc2" %>
<%@ Register Src="../UserControls/UserSiteMap.ascx" TagName="UserSiteMap" TagPrefix="uc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKEd" %>
<%@ Register Assembly="CustomPagingGridView" Namespace="CustomPagingGridView" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%" class="Table_Border_Black">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" class="Table_Bck1" style="height: 25px">
                    <tr>
                        <td class="table_td_left">
                            <asp:Label ID="Labelqwq1" runat="server" Text="Manage News/Events" CssClass="Table_Title_Label_White">
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
    <table cellspacing="0" cellpadding="0" width="100%">
        <tbody>
            <tr>
                <td class="table_td_left">
                    <asp:Label ID="Label3" runat="server" CssClass="label_blackbold10" Text="News/Events List"></asp:Label>
                </td>
                <td class="table_td_right">
                    <asp:ImageButton ID="btnAddNew" OnClick="btnAddNew_Click" runat="server" CssClass="table_td_right"
                        ImageUrl="~/Images/icon-add.png"></asp:ImageButton>
                    <asp:LinkButton ID="lnkbntNew" OnClick="lnkbntNew_Click" runat="server" CssClass="Link_Label_Bold"
                        Text="Add Coupon"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr />
                </td>
            </tr>
            <tr>
                <td class="table_td_left" colspan="2">
                    <table cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td class="table_td_left" width="25%">
                                <cc1:CustomePagingGrid ID="gvCategory" runat="server" CssClass="gridview" OnRowCommand="gvCategory_RowCommand"
                                    AutoGenerateColumns="False" OnPageIndexChanging="gvCategory_PageIndexChanging"
                                    AllowPaging="True" PageSize="10" Width="95%">
                                    <PagerSettings PreviousPageText="Prev" LastPageText="Last" FirstPageText="First"
                                        NextPageText="Next" Mode="NextPreviousFirstLast" Position="Bottom"></PagerSettings>
                                    <EmptyDataTemplate>
                                        No Data Found.
                                    </EmptyDataTemplate>
                                    <PagerStyle ForeColor="Maroon" HorizontalAlign="Right"></PagerStyle>
                                    <Columns>
                                        <asp:TemplateField HeaderText="NewsId" Visible="False">
                                            <edititemtemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NewsId") %>'></asp:TextBox>
                                </edititemtemplate>
                                            <itemtemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("NewsId") %>'></asp:Label>
                                </itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Title">
                                            <edititemtemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                                </edititemtemplate>
                                            <itemtemplate>
                                    <asp:LinkButton ID="lblCatName121" runat="server" Text='<%# Bind("Title") %>' CommandName="CheckDetail"
                                        CommandArgument='<%# Bind("NewsId") %>'></asp:LinkButton>
                                </itemtemplate>
                                            <itemstyle width="100%" />
                                        </asp:TemplateField>
                                    </Columns>
                                </cc1:CustomePagingGrid>
                            </td>
                            <td class="table_td_left">
                                <table cellspacing="0" cellpadding="0" width="100%">
                                    <tr>
                                        <td class="table_td_right">
                                            <fieldset>
                                                <legend>Search News/Events</legend>&nbsp;
                                                <asp:TextBox ID="txtSearchValue" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                                                <asp:Button ID="btnSearch" runat="server" CssClass="button1" Text="Go" OnClientClick="return fnCheckSearch();"
                                                    OnClick="btnSearch_Click" Width="50px" />
                                                <asp:Button ID="btnSearchAll" runat="server" CssClass="button1" Text="Show All" OnClick="btnSearchAll_Click"
                                                    Width="60px" />
                                            </fieldset>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="table_td_left">
                                            <fieldset>
                                                <legend>Manage News/Events</legend>
                                                <table id="TABLE1" cellspacing="0" cellpadding="0" width="100%">
                                                    <tbody>
                                                        <tr>
                                                            <td class="table_td_left">
                                                                <asp:Label ID="Label4" runat="server" CssClass="label_blackbold10" Text="Add News"></asp:Label>
                                                            </td>
                                                            <td align="right" class="Itemfonts1">
                                                                (<span class="red">*</span>) Required Fields &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="table_td_left" colspan="2">
                                                                <table cellspacing="10" cellpadding="0" width="100%">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td class="table_td_left">
                                                                                <asp:Label ID="lblparent" runat="server" CssClass="label" Text="Title"></asp:Label>
                                                                            </td>
                                                                            <td class="table_td_left">
                                                                                <asp:TextBox ID="txtTitle" runat="server" CssClass="textbox" ValidationGroup="AddCategory">
                                                                                </asp:TextBox>&nbsp;<span class="red">*</span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="table_td_left">
                                                                                <asp:Label ID="lblDesc" runat="server" CssClass="label" Text="Description :"></asp:Label>
                                                                            </td>
                                                                            <td colspan="4">
                                                                                <FCKEd:FCKeditor ID="txtDesc" runat="server" Width="100%" ToolbarSet="Basic">
                                                                                </FCKEd:FCKeditor>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="table_td_left">
                                                                                <asp:Label ID="Label2" runat="server" CssClass="label" Text="Link:"></asp:Label>
                                                                            </td>
                                                                            <td class="table_td_left">
                                                                                <asp:TextBox ID="txtLink" runat="server" CssClass="textbox" ValidationGroup="AddCategory"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="CheckAtSave"
                                                                                    ControlToValidate="txtLink" Display="None" ErrorMessage="Enter Proper Link e.g. http://www.Avileax.com"
                                                                                    ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"></asp:RegularExpressionValidator>
                                                                                <AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="Server"
                                                                                    HighlightCssClass="validatorCalloutHighlight" TargetControlID="RegularExpressionValidator1">
                                                                                </AjaxToolKit:ValidatorCalloutExtender>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="table_td_left" style="width: 289px">
                                                                                <asp:Label ID="Label9" runat="server" CssClass="label" Text="News Date:"></asp:Label>
                                                                            </td>
                                                                            <td class="table_td_left">
                                                                                <asp:TextBox ID="txtNewsDate" runat="server" CssClass="textbox" Width="70px" MaxLength="20"
                                                                                    ValidationGroup="AddCategory"></asp:TextBox>
                                                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calbtn.gif"></asp:ImageButton>
                                                                            </td>
                                                                            <td class="table_td_left">
                                                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtNewsDate"
                                                                                    PopupButtonID="ImageButton1">
                                                                                </AjaxToolKit:CalendarExtender>
                                                                                <AjaxToolKit:FilteredTextBoxExtender ID="check23" runat="server" TargetControlID="txtNewsDate"
                                                                                    FilterType="Numbers,Custom" ValidChars="/">
                                                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Start Date Must Be > than Today Date"
                                                                                    ControlToValidate="txtNewsDate" Operator="GreaterThanEqual" Type="Date" Width="100%"
                                                                                    Display="None" ValidationGroup="AddCategory"></asp:CompareValidator>
                                                                                <AjaxToolKit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="Server"
                                                                                    HighlightCssClass="validatorCalloutHighlight" TargetControlID="CompareValidator1">
                                                                                </AjaxToolKit:ValidatorCalloutExtender>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="table_td_center" colspan="4">
                                                                                <%--<asp:ImageButton ID="imgbtn_Insert" OnClick="imgbtn_Insert_Click" runat="server"
                                                                                    ImageUrl="~/Images/save_orange.gif" OnClientClick="return CheckValue();" ValidationGroup="AddCategory"
                                                                                    CausesValidation="true"></asp:ImageButton>--%>
                                                                                <asp:button ID="imgbtn_Insert" OnClick="imgbtn_Insert_Click" runat="server" Text="Save"
                                                                                    CssClass="button1" OnClientClick="return CheckValue();" ValidationGroup="AddCategory"
                                                                                    CausesValidation="true" />
                                                                                <asp:Button ID="btnback" OnClick="btnback_Click" runat="server" CssClass="button1"
                                                                                    Text="Back"></asp:Button>
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
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    <%--    </contenttemplate>
    </asp:UpdatePanel>--%>
    <asp:Label ID="lblMode" runat="server" Text="" Visible="false"></asp:Label>
    <uc2:ProgressBar ID="ProgressBar1" runat="server"></uc2:ProgressBar>

    <script language="javascript" type="text/javascript">
    function CheckValue()
    {
        var msg='';
        if(document.getElementById('<%= this.txtTitle.ClientID %>').value=='')
        {
            msg=msg+'\n'+'Enter Title.';
            document.getElementById('<%= this.txtTitle.ClientID %>').style.backgroundColor='lemonchiffon';
        }
        if(document.getElementById('<%= this.txtNewsDate.ClientID %>').value=='')
        {
            msg=msg+'\n'+'Enter News Date.';
            document.getElementById('<%= this.txtNewsDate.ClientID %>').style.backgroundColor='lemonchiffon';
        }        
        if(msg!='')
        {
            alert('Enter Requiered field'+msg);
            return false;
        }
    }
    
    function fnCheckSearch()
    {
        if(document.getElementById('<%= this.txtSearchValue.ClientID %>').value=='')
        {
            return false;
        }
    }
    
    function fnDisable()
    {  
    }
    </script>

</asp:Content>
