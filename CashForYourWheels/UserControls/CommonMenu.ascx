<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_CommonMenu" Codebehind="CommonMenu.ascx.cs" %>
<table width="100%" class="Table_Bck3">
    <tr>
        <td class="Center">
            <asp:Image ID="img1" runat="server" ImageUrl="~/Images/square.gif" />
            <asp:LinkButton ID="btnHome" runat="server" CssClass="Link_Label_Bold" Text="Home"
                OnClick="btnHome_Click" ToolTip="Home"></asp:LinkButton>
        </td>
        <td>
            <asp:Label ID="Label1" runat="server" Text="|" CssClass="label"></asp:Label>
        </td>
        <td class="Center">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/square.gif" />
            <asp:LinkButton ID="btnAboutus" runat="server" CssClass="Link_Label_Bold" Text="About Us"
                OnClick="btnAboutus_Click" ToolTip="About Us"></asp:LinkButton>
        </td>
        <td>
            <asp:Label ID="Label6" runat="server" Text="|" CssClass="label"></asp:Label>
        </td>
        <td class="Center">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/square.gif" />
            <asp:LinkButton ID="btnTrackOrder" runat="server" CssClass="Link_Label_Bold" Text="Track Order"
                OnClick="btnTrackOrder_Click" ToolTip="Track Order"></asp:LinkButton>
        </td>
        <td>
            <asp:Label ID="Label7" runat="server" Text="|" CssClass="label"></asp:Label>
        </td>
        <td class="Center">
            <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/square.gif" />
            <asp:LinkButton ID="btnOrderHistory" runat="server" CssClass="Link_Label_Bold" Text="Order History"
                OnClick="btnOrderHistory_Click" ToolTip="Order History"></asp:LinkButton>
        </td>
        <td>
            <asp:Label ID="Label2" runat="server" Text="|" CssClass="label"></asp:Label>
        </td>
        <td class="Center">
            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/square.gif" />
            <asp:LinkButton ID="btnService" runat="server" CssClass="Link_Label_Bold" Text="Our Services"
                OnClick="btnService_Click" ToolTip="Our Services"></asp:LinkButton>
        </td>
        <td>
            <asp:Label ID="Label3" runat="server" Text="|" CssClass="label"></asp:Label>
        </td>
        <td class="Center">
            <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/square.gif" />
            <asp:LinkButton ID="btnTelltofrnd" runat="server" CssClass="Link_Label_Bold" Text="Tell a Friend"
                OnClick="btnTelltofrnd_Click" ToolTip="Tell a Friend"></asp:LinkButton>
        </td>
        <td>
            <asp:Label ID="Label4" runat="server" Text="|" CssClass="label"></asp:Label>
        </td>
        <td class="Center">
            <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/square.gif" />
            <asp:LinkButton ID="btnFAQ" runat="server" CssClass="Link_Label_Bold" Text="FAQs"
                OnClick="btnFAQ_Click" ToolTip="FAQs"></asp:LinkButton>
        </td>
        <td>
            <asp:Label ID="Label5" runat="server" Text="|" CssClass="label"></asp:Label>
        </td>
        <td class="Center">
            <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/square.gif" />
            <asp:LinkButton ID="btnContactUs" runat="server" CssClass="Link_Label_Bold" Text="Contact Us"
                OnClick="btnContactUs_Click" ToolTip="Contact Us"></asp:LinkButton>
        </td>
    </tr>
</table>
