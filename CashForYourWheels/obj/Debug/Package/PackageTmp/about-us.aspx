<%@ Page Language="C#" MasterPageFile="~/Master/CarPageMaster.master" AutoEventWireup="true" Inherits="about_us" Title="About Us" Codebehind="about-us.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpCarWebsite1" runat="Server">
    <div style="margin-top: 20px" class="tabs-container">
        <div class="left-bg">
        </div>
        <div id="inner_content" style="padding-top: 10px">
            <%= BAL_CMS.GetDetailsByLinkName("About Us") %>
        </div>
        <div class="right-bg">
        </div>
    </div>
</asp:Content>
