<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_ProgressBar1" Codebehind="ProgressBar1.ascx.cs" %>
<%--progress bar--%>

<asp:UpdateProgress ID="UpdateProgress1" runat="server"  >
    <ProgressTemplate>
        <div class="Background_4_Loading1">            
            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/loading0.gif" />            
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>

<AjaxToolKit:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
    TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
    HorizontalOffset="0">
</AjaxToolKit:AlwaysVisibleControlExtender>




