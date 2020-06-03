<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_TitleStrip" Codebehind="TitleStrip.ascx.cs" %>
<table cellspacing="3px" align="right" border="0">
    <tr>
        <td>
            <asp:Image ID="img1" runat="server" ImageUrl="~/Images/icon-member-login.gif" />
            <asp:LinkButton ID="HLHome" ToolTip="Member Login" runat="server" Text="Member Login"
                CssClass="Link_Label_Header" OnClick="HLHome_Click"></asp:LinkButton>
        </td>
        <td>
            <asp:Label ID="Label1" runat="server" Text="|" CssClass="label"></asp:Label>
        </td>
        <td>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/icon-register.gif" />
            <asp:LinkButton ID="HyperLink1" ToolTip="Register" runat="server" Text="Register"
                CssClass="Link_Label_Header" OnClick="HyperLink1_Click"></asp:LinkButton>
        </td>
        <td>
            <asp:Label ID="Label2" runat="server" Text="|" CssClass="label"></asp:Label>
        </td>
        <td>
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/wishlist-icos.gif" />
            <%--<asp:HyperLink ID="HyperLink2" runat="server" Text="Wish List" CssClass="Link_Label_Header"
                NavigateUrl="~/User/WishList.aspx" />--%>
            <asp:LinkButton ID="btnWishList" ToolTip="Wish List" runat="server" Text="Wish List"
                CssClass="Link_Label_Header" OnClick="btnWishList_Click"></asp:LinkButton>
        </td>
        <td>
            <asp:Label ID="Label3" runat="server" Text="|" CssClass="label"></asp:Label>
        </td>
        <td>
            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/icon-shopping-cart.gif" />
            <%--<asp:HyperLink ID="HyperLink3" runat="server" Text="Shopping Cart" CssClass="Link_Label_Header"
                NavigateUrl="~/User/ShoppingCart.aspx" />--%>
            <asp:LinkButton ID="btnShoppingCart" ToolTip="Shopping Cart" runat="server" Text="Shopping Cart"
                CssClass="Link_Label_Header" OnClick="btnShoppingCart_Click"></asp:LinkButton>
        </td>
        <td>
            <asp:Label ID="Label4" runat="server" Text="|" CssClass="label"></asp:Label>
        </td>
        <td>
            <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/icon-checkout.gif" />
            <%--<asp:HyperLink ID="HyperLink4" runat="server" Text="Checkout" CssClass="Link_Label_Header"
                NavigateUrl="~/User/Checkout.aspx" />--%>
            <asp:LinkButton ID="LinkButton1" ToolTip="Checkout" runat="server" Text="Checkout"
                CssClass="Link_Label_Header" OnClick="LinkButton1_Click"></asp:LinkButton>
        </td>
        <td>
            <asp:Label ID="Label5" runat="server" Text="|" CssClass="label"></asp:Label>
        </td>
        <td>
            <%--  <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/icon-checkout.gif" />--%>
            <%--<asp:HyperLink ID="HyperLink4" runat="server" Text="Checkout" CssClass="Link_Label_Header"
                NavigateUrl="~/User/Checkout.aspx" />--%>
            <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/icon_sitemap.gif" />
            <asp:LinkButton ID="lnksitemap" ToolTip="Site Map" runat="server" Text="Sitemap"
                CssClass="Link_Label_Header" OnClick="lnksitemap_Click"></asp:LinkButton>
        </td>
    </tr>
</table>
