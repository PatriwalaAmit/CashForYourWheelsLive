<%@ Page Title="" Language="C#" MasterPageFile="~/Master/CarPageMaster.master" AutoEventWireup="true" Inherits="terms_and_conditions" Codebehind="terms_and_conditions.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpCarWebsite1" Runat="Server">
        <div class="innerpages">
        <%= BAL_CMS.GetDetailsByLinkName("TC-Page")%>
    </div>
</asp:Content>

