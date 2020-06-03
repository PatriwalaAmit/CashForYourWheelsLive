<%@ Page Language="C#" MasterPageFile="~/Master/CarPageMaster.master" AutoEventWireup="true" Inherits="news" Title="News" Codebehind="news.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpCarWebsite1" runat="Server">
  <div class="innerpages">
     <%= BAL_CMS.GetDetailsByLinkName("News")%>
  </div>
</asp:Content>
