<%@ Page Title="" Language="C#" MasterPageFile="~/Master/CarPageMaster.master" AutoEventWireup="true"
    CodeBehind="car-sourcing.aspx.cs" Inherits="CashForYourWheels.car_sourcing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpCarWebsite1" runat="server">
    <div class="innerpages">
        <script type="text/javascript">
            function CheckCapt() {
                if (document.getElementById('<%= txtCaptcha.ClientID%>').value == '') {
                    document.getElementById("trCaptch").style.backgroundColor = "#ffcccc";
                }
                else {
                    document.getElementById("trCaptch").style.backgroundColor = "#fff";
                }
            }

            function WebForm_OnSubmit() {
                if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                    for (var i in Page_Validators) {
                        try {
                            var control = document.getElementById(Page_Validators[i].controltovalidate);
                            if (!Page_Validators[i].isvalid) {

                                if (control.id == "<%= txtFullName.ClientID%>") {
                                    document.getElementById("divName").style.backgroundColor = "#ffcccc";
                                }

                                if (control.id == "<%= txtCarDetails.ClientID%>") {
                                    document.getElementById("divEnquiry").style.backgroundColor = "#ffcccc";
                                }

                                if (control.id == "<%= txtPhoneNumber.ClientID%>") {
                                    document.getElementById("divPhoneNumber").style.backgroundColor = "#ffcccc";
                                }

                                if (control.id == "<%= txtPostCode.ClientID%>") {
                                    document.getElementById("divPostCode").style.backgroundColor = "#ffcccc";
                                }

                                if (control.id == "<%= txtEmailAddress.ClientID%>") {
                                    document.getElementById("divEmailAddress").style.backgroundColor = "#ffcccc";
                                }

                                if (document.getElementById('<%= txtCaptcha.ClientID%>').value == '') {
                                    document.getElementById("trCaptch").style.backgroundColor = "#ffcccc";
                                }
                                else {
                                    document.getElementById("trCaptch").style.backgroundColor = "#fff";
                                }
                            }
                        } catch (e) { }
                    }
                    return false;
                }
                return true;
            }
        </script>
        <div class="car-sourcing-left" style="width: 45%; float: left;">
            <%= BAL_CMS.GetDetailsByLinkName("car-sourcing") %>
        </div>
        <div class="car-sourcing-right">
            <div class="car-sourcing">
                <h2>
                    Send us a message</h2>
                <h3>
                    To get in touch with us, please complete the form below</h3>
                <h3 style="background: #c9061d; color: #fff; line-height: 24px;">
                    <asp:Label ID="lblMessage" runat="server" EnableViewState="false" CssClass="thankyoumessage"></asp:Label></h3>
                <div id="divName">
                    <div class="enquiryr">
                        Full Name:
                    </div>
                    <div class="enquiryl">
                        <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
                        <a class="contacttooltip" href="#">
                            <img alt="" src="images/details.png"><span class="classic">Please enter your full name</span>
                        </a>
                        <asp:RequiredFieldValidator ID="rfvtxtName" runat="server" Text="Please enter your full name"
                            ControlToValidate="txtFullName" ValidationGroup="sec4" Display="Dynamic" CssClass="contact-error"></asp:RequiredFieldValidator>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div id="divPostCode">
                    <div class="enquiryr">
                        Post Code:
                    </div>
                    <div class="enquiryl">
                        <asp:TextBox ID="txtPostCode" runat="server"></asp:TextBox>
                        <a class="contacttooltip" href="#">
                            <img alt="" src="images/details.png"><span class="classic">Please enter your Post Code</span>
                        </a>
                        <asp:RequiredFieldValidator ID="tfvPostCode" runat="server" Text="Please enter your Post Code"
                            ControlToValidate="txtPostCode" ValidationGroup="sec4" Display="Dynamic" CssClass="contact-error"></asp:RequiredFieldValidator>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div id="divPhoneNumber">
                    <div class="enquiryr">
                        Phone Number:
                    </div>
                    <div class="enquiryl">
                        <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                        <a class="contacttooltip" href="#">
                            <img alt="" src="images/details.png"><span class="classic">Please enter your telephone
                                number, preferably your mobile. Please enter numbers only and no spaces. For example
                                01656712345 or 07967123456.</span> </a>
                        <asp:RegularExpressionValidator ID="revPhonenumber" runat="server" ControlToValidate="txtPhoneNumber"
                            ErrorMessage="Please enter your valid phone number" ValidationExpression="[\d]{2,3}[\d]{7,8}"
                            ValidationGroup="sec4" Display="Dynamic" CssClass="contact-error" EnableClientScript="false"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" Text="*" ControlToValidate="txtPhoneNumber"
                            ValidationGroup="sec4" Display="Dynamic" CssClass="contact-error"></asp:RequiredFieldValidator>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div id="divEmailAddress">
                    <div class="enquiryr">
                        Email Address :
                    </div>
                    <div class="enquiryl">
                        <asp:TextBox ID="txtEmailAddress" runat="server"></asp:TextBox>
                        <a class="contacttooltip" href="#">
                            <img alt="" src="images/details.png"><span class="classic">Please enter a valid email
                                address, such as text@text.co.uk</span> </a>
                        <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ControlToValidate="txtEmailAddress"
                            ErrorMessage="Please enter a valid email address" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ValidationGroup="sec4" Display="Dynamic" CssClass="contact-error" EnableClientScript="false"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvEmailAddress" runat="server" Text="*" Display="Dynamic"
                            ControlToValidate="txtEmailAddress" ValidationGroup="sec4" CssClass="contact-error"></asp:RequiredFieldValidator>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div id="divEnquiry">
                    <div class="enquiryr">
                        Car Details:
                        <br />
                        <span style="font-size: 12px;">(E.g. Make, Model,
                            <br />
                            Spec., Mileage etc.) </span>
                    </div>
                    <div class="enquiryl">
                        <textarea runat="server" id="txtCarDetails" rows="5" cols="50" />
                        <a class="contacttooltip" href="#">
                            <img alt="" src="images/details.png"><span class="classic">Please enter your Car Details
                                E.g. Car Model, Make, Spec., Mileage </span></a>
                        <asp:RequiredFieldValidator ID="rfvtxtEnquiry" runat="server" Text="Please enter your Car Details"
                            ControlToValidate="txtCarDetails" ValidationGroup="sec4" Display="Dynamic" CssClass="contact-error"></asp:RequiredFieldValidator>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div id="divBudget">
                    <div class="enquiryr" style="width: 400px;">
                        Approximate maximum budget per month: (if Financing)
                    </div>
                    <div style="clear: both">
                    </div>
                    <div class="enquiryr">
                        &nbsp;</div>
                    <div class="enquiryl">
                        <asp:TextBox ID="txtBudget" runat="server"></asp:TextBox>
                        <span><a class="contacttooltip" href="#">
                            <img alt="" src="images/details.png"><span class="classic">Please enter your approximate
                                maximum budget per month.</span> </a></span>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div id="divFinance">
                    <div class="enquiryr" style="width: 350px;">
                        Deposit (We do £0 Deposit Finance if Preferred):
                    </div>
                    <div style="clear: both">
                    </div>
                    <div class="enquiryr">
                        &nbsp;</div>
                    <div class="enquiryl">
                        <asp:TextBox ID="txtFinance" runat="server"></asp:TextBox>
                        <a class="contacttooltip" href="#">
                            <img alt="" src="images/details.png"><span class="classic">Please enter your Deposit.</span>
                        </a>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div id="trCaptch" style="height: 100px">
                    <div class="enquiryr">
                        Type the code
                        <br />
                        from the image
                    </div>
                    <div class="enquiryl">
                        <asp:TextBox ID="txtCaptcha" runat="server" onblur="CheckCapt();"></asp:TextBox>
                        <br />
                        <div style="float: left;">
                            <img id="Img1" src="~/getcaptchaimage.aspx" style="border: 1px black" runat="server" />
                            <br />
                            <asp:Label ID="lblCaptchMessage" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label>
                        </div>
                        <a class="tooltip" href="#">
                            <img alt="" src="images/details.png"><span class="classic">Please enter the code shown
                                in the image above</span></a>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                            ControlToValidate="txtCaptcha" ValidationGroup="sec4" CssClass="contact-error"></asp:RequiredFieldValidator>
                        <br />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div>
                    <div class="enquiryr">
                    </div>
                    <div>
                        <asp:LinkButton runat="server" CssClass="button" ValidationGroup="sec4" OnClick="btnSubmit_click"></asp:LinkButton>
                        <br />
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div> </div> </div> </div> </div> </div> </div> </div> </div> </div> </div> </div>
    </div> </div> </div>
</asp:Content>
