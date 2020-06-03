<%@ Page Language="C#" MasterPageFile="~/Master/CarPageMaster.master" AutoEventWireup="true" Inherits="testimonials" Title="Testimonial" Codebehind="testimonials.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpCarWebsite1" runat="Server">
    <div class="innerpages">
        <%= BAL_CMS.GetDetailsByLinkName("Testimonials")%>
    </div>

</asp:Content>
