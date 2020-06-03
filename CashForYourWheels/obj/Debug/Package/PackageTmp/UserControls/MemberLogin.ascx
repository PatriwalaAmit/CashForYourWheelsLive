<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_MemberLogin" Codebehind="MemberLogin.ascx.cs" %>
<table cellpadding="0" cellspacing="10px" width="330px">
    <tr>
        <td class="table_td_center">
            <asp:Label ID="Label4" runat="server" Text="Admin Login" CssClass="Table_Title_Label_Black20"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="Panel1" runat="server" Width="100%" CssClass="Table_Bck3">
                <table cellpadding="0" cellspacing="10">
                    <tr>
                        <td class="table_td_left">
                            <asp:Label ID="Label5" runat="server" Text="Email" CssClass="Table_Title_Label_Login"></asp:Label><br />
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="textboxLogin"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="table_td_left">
                            <asp:Label ID="Label6" runat="server" Text="Password" CssClass="Table_Title_Label_Login"></asp:Label><br />
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="textboxLogin" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="table_td_right">
                            <asp:ImageButton ID="imgbtnLogin" runat="server" ImageUrl="~/Admin/Images/login.gif" OnClientClick="return ValidateInput();"
                                OnClick="imgbtnLogin_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="table_td_right">
                            <asp:Label ID="lblLoginError" runat="server" Text="" CssClass="ErrorLabel_10"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <AjaxToolKit:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="Panel1"
                Radius="12" Corners="All" />
        </td>
    </tr>
</table>

<script type="text/javascript" language="javascript">
    function ValidateInput()
    {
        var txtUsername = document.getElementById('<%=txtUsername.ClientID %>');
        var txtPassword = document.getElementById('<%=txtPassword.ClientID %>');
        
        if((txtUsername.value == "") || (txtPassword.value == ""))
        {
            alert("Missing : Username OR Password !!!!!");
            return false;
        }        
        return true;
    } 
    window.history.forward(1);  
</script>

