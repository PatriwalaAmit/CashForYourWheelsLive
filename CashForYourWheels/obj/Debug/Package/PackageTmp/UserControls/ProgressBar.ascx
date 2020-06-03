<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_ProgressBar" Codebehind="ProgressBar.ascx.cs" %>
<%--progress bar--%>
<asp:UpdateProgress ID="UpdateProgress1" runat="server">
    <ProgressTemplate>
        <div class="Background_4_Loading">
            <br />
            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Progressbar.gif" />
            <asp:Label ID="lblProgressBar" runat="server" Text="Loading........" CssClass="Table_Title_Label_White">
            </asp:Label>
            <br />
            <br />
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<AjaxToolKit:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
    TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
    HorizontalOffset="0">
</AjaxToolKit:AlwaysVisibleControlExtender>
