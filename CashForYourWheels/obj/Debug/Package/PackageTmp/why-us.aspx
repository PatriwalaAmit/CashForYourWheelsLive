<%@ Page Language="C#" MasterPageFile="~/Master/CarPageMaster.master" AutoEventWireup="true" Inherits="why_us" Title="Why us?" Codebehind="why-us.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpCarWebsite1" Runat="Server">
<div class="contents">
      <div class="top-content"></div>
        <div class="contents-in">
            <%= BAL_CMS.GetDetailsByLinkName("Why Us") %>
        </div>
    </div>
</asp:Content>

