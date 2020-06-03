<%@ Page Language="C#" MasterPageFile="~/Master/CarPageMaster.master" AutoEventWireup="true" Inherits="Car_Selection_2" Title="Vehicle Details" Codebehind="Car-Selection-2.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpCarWebsite1" runat="Server">
    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePageMethods="false" EnablePartialRendering="true"
        EnableScriptGlobalization="false" EnableScriptLocalization="true" AsyncPostBackTimeout="360000" />
    <div class="your-car">
        <h2>Vehicle Details<span>A few simple steps<img alt="" src="images/step2.png"></span></h2>

        <div class="car-detail vehicle-details">
            <table border="0" cellspacing="0" cellpadding="0">
                <tbody>
                    <tr id="trMileage">
                        <th align="right" width="350px" valign="top">What is the mileage on your vehicle?</th>
                        <th align="left" width="232px" valign="middle">
                            <input type="text" id="txtMileage" runat="server" onblur="Check();" style="width:60px;text-align:right;" maxlength="3"/><span style="line-height: 24px;font-size: 15px;">,000</span>
<br /> <small> (To the nearest 1000 miles) </small>
                        </th>
                        <th align="left" valign="middle"><a class="tooltip" href="#">
                            <img alt="" src="images/details.png"><span class="classic">Please enter current approximate mileage of your car, e.g. 10000,12000.</span></a>

                            <%-- <asp:RequiredFieldValidator ID="rfvMileage" runat="server" Display="Dynamic" Text="Please enter"
                                ControlToValidate="txtMileage" ValidationGroup="addselection"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvMileage" runat="server" ControlToValidate="txtMileage" Type="Integer"
                                Operator="DataTypeCheck" ErrorMessage="Value must be a numeric!" Display="Dynamic" ValidationGroup="addselection" />
                            <asp:RegularExpressionValidator ID="revMileage"
                                runat="server" Display="dynamic"
                                ControlToValidate="txtMileage"
                                ValidationExpression="^([\S\s]{0,7})$"
                                ErrorMessage="Please enter maxium 1,000,000" ValidationGroup="addselection">
                            </asp:RegularExpressionValidator>  --%>

  <asp:RequiredFieldValidator ID="rfvMileage" runat="server" Display="Dynamic"
                                ControlToValidate="txtMileage" ValidationGroup="addselection"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvMileage" runat="server" ControlToValidate="txtMileage" Type="Integer"
                                Operator="DataTypeCheck" Display="Dynamic" ValidationGroup="addselection" />
                                <asp:RangeValidator ID="rvMileage" runat="server" Display="Dynamic" ControlToValidate="txtMileage" Type="Integer" MinimumValue="1" MaximumValue="200" ValidationGroup="addselection" />
                            <asp:RegularExpressionValidator ID="revMileage"
                                runat="server" Display="dynamic" ControlToValidate="txtMileage" ValidationExpression="^([\S\s]{0,3})$"
                                ValidationGroup="addselection">
                            </asp:RegularExpressionValidator>
                            
                              <script type="text/javascript">

				 function Check()
                                {
                                    if (document.getElementById('<%= txtMileage.ClientID%>').value == '') {
                                        document.getElementById("trMileage").style.backgroundColor = "#ffcccc";
                                    }
                                    else {
                                        if (parseFloat(document.getElementById('<%= txtMileage.ClientID%>').value) == NaN)
                                        {
                                            document.getElementById("trMileage").style.backgroundColor = "#ffcccc";
                                        }
else
{
document.getElementById("trMileage").style.backgroundColor = "#fff";
}
                                    }

                                }

 				 function CheckCapt() {
                                    if (document.getElementById('<%= txtCaptcha.ClientID%>').value == '') {
                                        document.getElementById("trCaptch").style.backgroundColor = "#ffcccc";
                                    }
else
{
document.getElementById("trCaptch").style.backgroundColor = "#fff";
}
                                }

                                function WebForm_OnSubmit() {
                                    if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                                        var vInfo = true;
                                        for (var i in Page_Validators) {
                                            try {
                                                var control = document.getElementById(Page_Validators[i].controltovalidate);
                                                if (!Page_Validators[i].isvalid) {
                                                    if (control.id == "<%= txtMileage.ClientID%>") {
                                                        document.getElementById("trMileage").style.backgroundColor = "#ffcccc";
                                                        vInfo = false;
                                                    }
                                                    else if (control.id == "<%= txtCaptcha.ClientID%>") {
                                                        document.getElementById("trCaptch").style.backgroundColor = "#ffcccc";
                                                        vInfo = false;
                                                    }
                                                }
                                            } catch (e) { }
                                        }
                                        if (!vInfo) {
                                            document.getElementById('<%= rfvMileage.ClientID %>').innerHTML = "Please enter";
                                            document.getElementById('<%= cvMileage.ClientID %>').innerHTML = "Value must be a numeric!";
                                            document.getElementById('<%= revMileage.ClientID %>').innerHTML = "Please enter maxium 1,000,000";
                                            document.getElementById('<%= rvMileage.ClientID %>').innerHTML = "If your mileage is over 200,000 miles please call us for a valuation";
                                            document.getElementById('<%= RequiredFieldValidator1.ClientID %>').innerHTML = "Please enter the code shown in the image above";
return false;
                                        }

                                    }
                                    return true;
                                }
                            </script>
                                                       
                        </th>
                    </tr>
                    <tr>
                        <td align="right" valign="middle">When is the road tax due? </td>
                        <td align="left" valign="middle">
                            <asp:DropDownList runat="server" ID="ddlRoadTax">
                                <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                <asp:ListItem Text="1-3 Months" Value="1-3 Months"></asp:ListItem>
                                <asp:ListItem Text="4-6 Months" Value="4-6 Months"></asp:ListItem>
                                <asp:ListItem Text="Over 6 Months" Value="Over 6 Months"></asp:ListItem>
                                <asp:ListItem Text="Tax has expired" Value="Tax has expired"></asp:ListItem>
                                <asp:ListItem Text="No road tax required" Value="No road tax required"></asp:ListItem>
                            </asp:DropDownList>

                            <%--<asp:RadioButtonList ID="rbInsurance" runat="server" RepeatDirection="Vertical">
                                <asp:ListItem Text="1-3 Months" Value="1-3 Months"></asp:ListItem>
                                <asp:ListItem Text="4-6 Months" Value="4-6 Months"></asp:ListItem>
                                <asp:ListItem Text="Over 6 Months" Value="Over 6 Months"></asp:ListItem>
                                <asp:ListItem Text="Tax has expired" Value="Tax has expired"></asp:ListItem>
                                <asp:ListItem Text="No road tax required" Value="No road tax required"></asp:ListItem>

                            </asp:RadioButtonList>--%>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rbInsurance"
                                ErrorMessage="Please select" ValidationGroup="addselection"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="left" valign="middle"><a class="tooltip" href="#">
                            <img alt="" src="images/details.png"><span class="classic">please check your tax disc and select the option which applies to your vehicle</span></a></td>
                    </tr>
                    <%-- <tr>
                        <td align="right" valign="middle">How many previous owners has your car had?<br>
                        </td>
                        <td align="left" valign="middle">
                            <asp:RadioButtonList ID="rbPersonalOwner" runat="server">
                                <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                <asp:ListItem Text="Don't know" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="rfvPersonalOwner" runat="server" ControlToValidate="rbPersonalOwner"
                                ErrorMessage="Please select" ValidationGroup="addselection"></asp:RequiredFieldValidator>
                        </td>
                        <td align="left" valign="middle"><a class="tooltip" href="#">
                            <img alt="" src="images/details.png"><span class="classic">Please select the previous owner of your car, from the selection.<br>
                                <br>
                                If the previous owner is not listed, please email your local branch using our branch locator.</span></a></td>
                    </tr>--%>
                    <tr runat="server" visible="false">
                        <td align="right" valign="middle">What service history do you have?</td>
                        <td align="left" valign="middle">
                            <asp:RadioButtonList ID="rbServiceHistory" runat="server">
                                <asp:ListItem Text="Full Service History" Value="FullServiceHistory"></asp:ListItem>
                                <asp:ListItem Text="Part Service History" Value="PartServiceHistory"></asp:ListItem>
                                <asp:ListItem Text="First Service Not Due" Value="FirstServiceNotDue"></asp:ListItem>
                                <asp:ListItem Text="No Service History" Value="NoServiceHistory"></asp:ListItem>
                            </asp:RadioButtonList>
                            <%-- <asp:RequiredFieldValidator ID="rfvServiceHistory" runat="server" ControlToValidate="rbServiceHistory"
                                ErrorMessage="Please select" ValidationGroup="addselection"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="left" valign="middle"><a class="tooltip" href="#">
                            <img alt="" src="images/details.png"><span class="classic"> 	
Please select the service history of your vehicle, from the selection.<br>
                                <br>
                                If the service history is not listed, please email your local branch using our branch locator.</span></a></td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle">Do you have the V5 document for the vehicle?</td>
                        <td align="left" valign="middle">
                            <asp:RadioButtonList ID="rbMOT" runat="server" RepeatDirection="Horizontal"  CssClass="step-2-radio">
                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:RadioButtonList>

                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rbMOT"
                                ErrorMessage="Please select" ValidationGroup="addselection"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="left" valign="middle"><a class="tooltip" href="#">
                            <img alt="" src="images/details.png"><span class="classic">This document  is also known as the log book. </span></a></td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle">Is the V5 in your name?</td>
                        <td align="left" valign="middle">
                            <asp:RadioButtonList ID="rbV5" runat="server" RepeatDirection="Horizontal" CssClass="step-2-radio">
                                <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                                <asp:ListItem Text="No" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rbV5"
                                ErrorMessage="Please select" ValidationGroup="addselection"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="left" valign="middle"><a class="tooltip" href="#">
                            <img alt="" src="images/details.png"><span class="classic">When you look at the top of the V5 document does it state your name as the current keeper?</span></a></td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle">Is there any outstanding finance<br>
                            left?</td>
                        <td align="left" valign="middle">
                            <asp:RadioButtonList ID="rbOutstandingfinance" runat="server" RepeatDirection="Horizontal" CssClass="step-2-radio">
                                <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                                <asp:ListItem Text="No" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>
                            <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rbOutstandingfinance"
                                ErrorMessage="Please select" ValidationGroup="addselection"></asp:RequiredFieldValidator>--%>

                        </td>
                        <td align="left" valign="middle"><a class="tooltip" href="#">
                            <img alt="" src="images/details.png"><span class="classic">If you took out a finance agreement in order to purchase the vehicle, is there any outstanding monies to pay, to the finance company,  to end your agreement</span></a></td>
                    </tr>
                    <tr id="trCaptch">
                        <td align="right" >Type the code from the image</td>
                        <td class="code">
                            <img src="~/getcaptchaimage.aspx" style="border: 1px black" runat="server" />
                            <br />
                            <asp:TextBox ID="txtCaptcha" runat="server" Style=" margin-top: 10px;padding: 5px;width: 188px;"  onblur="CheckCapt();"></asp:TextBox>

                        </td>
                        <td>
                            <a class="tooltip" href="#">
                                <img alt="" src="images/details.png"><span class="classic">Please enter the code shown in the image above</span></a>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" 
                                ControlToValidate="txtCaptcha" ValidationGroup="addselection"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="lblCaptchMessage" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td colspan="3">
                    <center> <asp:Label ID="lblMessage" runat="server" ForeColor="White" CssClass="classic" EnableViewState="false" Visible="false">Please give us a call on 01656649697 and we will squeeze you in. </asp:Label></center>
                    </td></tr>
                </tbody>
            </table>

            <%--<input class="button" type="button" name="" runat="server" ID="LinkButton1" onclick="btnNext_Click" validationgroup="stage2" />--%>
          <%--  <asp:Label ID="lblMessage" runat="server" ForeColor="Red" EnableViewState="false" Visible="false">Please give us a call on 01656649697 and we will squeeze you in. </asp:Label>--%>
            <asp:LinkButton runat="server" ID="btnNext" OnClick="btnNext_Click" CssClass="button" ValidationGroup="addselection" />


            <%--<asp:ImageButton CssClass="button" runat="server" Width="254px" ID="btnfinal" />--%>
            <%--  <asp:LinkButton CssClass="preview" ID="btnPrevious1" runat="server" OnClick="btnPrevious_Click"></asp:LinkButton>
            <asp:LinkButton ID="LinkButton1" CssClass="button" OnClick="btnNext_Click" runat="server" ValidationGroup="stage2"> </asp:LinkButton>--%>

            <div class="clear"></div>
        </div>

    </div>
</asp:Content>
