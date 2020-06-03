<%@ Page Title="Appointment Confirmation" Language="C#" MasterPageFile="~/Master/CarPageMaster.master" AutoEventWireup="true" Inherits="appointment_confirmation" Codebehind="appointment_confirmation.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpCarWebsite1" runat="Server">
    <div class="your-car">
<h2>Congratulations!</h2>
        <div class="valuation">
            
            <p>
                Your appointment has now been arranged for <%= Convert.ToString(Session["apptime"]) %> on the <%= Convert.ToString(Session["appdate"]) %> at our <%= Convert.ToString(Session["branchname"]) %> branch
              <br />
                You should receive an email shortly confirming your valuation and appointment details. If you have any questions then please do not hesitate to call the branch
            </p>
        </div>
    </div>
    <img height="1" width="1" style="border-style:none;" alt="" src="//www.googleadservices.com/pagead/conversion/1001292085/?value=1.00&amp;label=X6R-CPuZ7QMQtYK63QM&amp;guid=ON&amp;script=0"/>
</asp:Content>

