<%@ Page Language="C#" MasterPageFile="~/Master/CarPageMaster.master" AutoEventWireup="true" Inherits="branchlocator" Title="Branch Locator" Codebehind="branchlocator.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpCarWebsite1" runat="Server">
    <div class="innerpages">
        <%= BAL_CMS.GetDetailsByLinkName("BranchLocator")%>
    </div>
</asp:Content>
