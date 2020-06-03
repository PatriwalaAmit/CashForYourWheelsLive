<%@ Page Title="FAQ" Language="C#" MasterPageFile="~/Master/CarPageMaster.master" AutoEventWireup="true" Inherits="faq" Codebehind="faq.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpCarWebsite1" Runat="Server">
     <div class="innerpages">
        <%= BAL_CMS.GetDetailsByLinkName("faq")%>
    </div>
</asp:Content>

