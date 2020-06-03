<%@ Page Language="C#" MasterPageFile="~/Master/CarPageMaster.master" AutoEventWireup="true" Inherits="yourvaluation" Title="Your valuation" Codebehind="yourvaluation.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpCarWebsite1" runat="Server">
    <%--<link rel="stylesheet" type="text/css" href="css/printstyle.css" />--%>

    <div class="your-car">
        <h2>Your valuation is complete</h2>
        <div class="valuation">
            <h3>Congratulations!</h3>
            <p>
                Based on the details you have provided we’d be happy to pay the following for <b><%= Convert.ToString(Session["CarRegNumber"]) %></b>.
If you’re happy with this valuation then <b><a href="~/book_an_appointment.aspx" runat="server">book an appointment</a></b>
            </p>
            <div class="valuation-details">
                <div class="bg">
                    <img src="images/valuation-logo.png" class="valuation-logo" alt="" />
                    <div class="left">
                        <ul>
                            <li>
                                <%= Convert.ToString(Session["CustomerName"]) %></li>
                            <li>
                                <%= new NumberToWords().ToVerbal(Convert.ToDouble(Session["Valuation"].ToString())) %> Pounds Only</li>
                        </ul>
                        VALUATION REFERENCE 
                        <input style="width: 121px; background: none; border: none; border-bottom: 1px solid #000; font-weight: bold"
                            type="text" value="HAK3544212142" title="" readonly="readonly" />
                    </div>
                    <div class="right">
                        <div class="date">Date&nbsp;&nbsp;<span><%= System.DateTime.Today.Day.ToString() %>/<%= System.DateTime.Today.Month.ToString() %>/<%= System.DateTime.Today.Year.ToString() %></span></div>
                        <div class="price"><span>£&nbsp;<%= Convert.ToString(Session["Valuation"]) %></span></div>
                    </div>
                </div>
            </div>
            <p class="terms">*A valuation is subject to an inspection please see our <a href="terms_and_conditions.aspx" target="_blank">Terms & Conditions</a></p>
            <div class="clear">
                <a class="print-valuation" runat="server" onclick="javascript:window.print();return false;" href="#"></a><a href="~/book_an_appointment.aspx" runat="server" class="book-appointment"></a>
            </div>
        </div>
    </div><img height="1" width="1" style="border-style:none;" alt="" src="//www.googleadservices.com/pagead/conversion/1001292085/?label=1lEWCN3pg3MQtYK63QM&amp;guid=ON&amp;script=0"/>
</asp:Content>
