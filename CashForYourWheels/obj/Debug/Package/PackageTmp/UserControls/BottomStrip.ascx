<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_BottomStrip" Codebehind="BottomStrip.ascx.cs" %>
<table cellpadding="0px" cellspacing="0px" width="100%" class="FooterScrip" border="0">
    <tr>
        <td align="center">
            <table cellspacing="2px" cellpadding="0px" width="80%">
                <tr align="center">
                    <td>
                        <%--<asp:HyperLink ID="HLHome" runat="server" Text="Home" CssClass="Link_Label_Bold"
                            NavigateUrl="~/Default.aspx" />--%>
                        <asp:LinkButton ID="HLHome" ToolTip="Home" runat="server" Text="Home" CssClass="Link_Label_Bold"
                            OnClick="HLHome_Click"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="|" CssClass="label"></asp:Label>
                    </td>
                    <td>
                        <asp:LinkButton ID="btnAboutUs" ToolTip="About Us" runat="server" Text="About Us"
                            CssClass="Link_Label_Bold" OnClick="btnAboutUs_Click"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="|" CssClass="label"></asp:Label>
                    </td>
                    <td class="Center">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/square.gif" />
                        <asp:LinkButton ID="btnTrackOrder" runat="server" CssClass="Link_Label_Bold" Text="Track Order"
                            OnClick="btnTrackOrder_Click" ToolTip="Track Order"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="|" CssClass="label"></asp:Label>
                    </td>
                    <td class="Center">
                        <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/square.gif" />
                        <asp:LinkButton ID="btnOrderHistory" runat="server" CssClass="Link_Label_Bold" Text="Order History"
                            OnClick="btnOrderHistory_Click" ToolTip="Order History"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="|" CssClass="label"></asp:Label>
                    </td>
                    <td>
                        <%--<asp:HyperLink ID="HyperLink2" runat="server" Text="FAQs" CssClass="Link_Label_Bold"
                            NavigateUrl="~/User/FAQ.aspx" />--%>
                        <asp:LinkButton ID="btnFAQ" runat="server" ToolTip="FAQs" Text="FAQs" CssClass="Link_Label_Bold"
                            OnClick="btnFAQ_Click"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="|" CssClass="label"></asp:Label>
                    </td>
                    <td>
                        <%--<asp:HyperLink ID="HyperLink3" runat="server" Text="Tell a Friend" CssClass="Link_Label_Bold"
                            NavigateUrl="~/Email.aspx" />--%>
                        <asp:LinkButton ID="btnTelltofrnd" runat="server" ToolTip="Tell a Friend" Text="Tell a Friend"
                            CssClass="Link_Label_Bold" OnClick="btnTelltofrnd_Click"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="|" CssClass="label"></asp:Label>
                    </td>
                    <td>
                        <%--<asp:HyperLink ID="HyperLink4" runat="server" Text="Privacy Policy" CssClass="Link_Label_Bold"
                            NavigateUrl="~/User/PrivacyPolicy.aspx" />--%>
                        <asp:LinkButton ID="btnprivacypolicy" runat="server" ToolTip="Privacy Policy" Text="Privacy Policy"
                            CssClass="Link_Label_Bold" OnClick="btnprivacypolicy_Click"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="|" CssClass="label"></asp:Label>
                    </td>
                    <td>
                        <%--<asp:HyperLink ID="HyperLink5" runat="server" Text="Contact Us" CssClass="Link_Label_Bold"
                            NavigateUrl="~/User/Contact.aspx" />--%>
                        <asp:LinkButton ID="btnContact" runat="server" ToolTip="Contact Us" Text="Contact Us"
                            CssClass="Link_Label_Bold" OnClick="btnContact_Click"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="|" CssClass="label"></asp:Label>
                    </td>
                    <td>
                        <%--<asp:HyperLink ID="HyperLink5" runat="server" Text="Contact Us" CssClass="Link_Label_Bold"
                            NavigateUrl="~/User/Contact.aspx" />--%>
                        <asp:LinkButton ID="LinkButton1" runat="server" ToolTip="Site Map" Text="Site Map"
                            CssClass="Link_Label_Bold" OnClick="LinkButton1_Click"></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="text-align: center; padding: 3px">
            <asp:Label ID="Label3" runat="server" Text="All Rights Reserved : @Company" CssClass="Table_Title_Label_White"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Powered By  SOLUTIONS" CssClass="Table_Title_Label_OffWhite"></asp:Label>
        </td>
    </tr>
</table>
