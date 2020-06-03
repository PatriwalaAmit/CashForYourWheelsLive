<%@ Page Language="C#" MasterPageFile="~/Master/CarPageMaster.master" AutoEventWireup="true" Inherits="contact_us" Title="Contact Us" Codebehind="contact-us.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpCarWebsite1" runat="Server">

    <div class="innerpages">
        <%= BAL_CMS.GetDetailsByLinkName("Contact Us") %>
        <script type="text/javascript">
            function WebForm_OnSubmit() {
                if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                    for (var i in Page_Validators) {
                        try {
                            var control = document.getElementById(Page_Validators[i].controltovalidate);
                            if (!Page_Validators[i].isvalid) {

                                if (control.id == "<%= txtName.ClientID%>") {
                                    document.getElementById("divName").style.backgroundColor = "#ffcccc";
                                }

                                if (control.id == "<%= txtenquiry.ClientID%>") {
                                    document.getElementById("divEnquiry").style.backgroundColor = "#ffcccc";
                                }

                                if (control.id == "<%= txtPhoneNumber.ClientID%>") {
                                    document.getElementById("divPhoneNumber").style.backgroundColor = "#ffcccc";
                                }

                                if (control.id == "<%= txtEmailAddress.ClientID%>") {
                                    document.getElementById("divEmailAddress").style.backgroundColor = "#ffcccc";
                                }                               
                            }
                        } catch (e) { }
                    }
                    return false;
                }
                return true;
            }
        </script>
        <div class="enquiry">
            <h2>Send us a message</h2>
            <h3>To get in touch with us, please complete the form below</h3>
            <div id="divName">
                <div class="enquiryr">
                    Name:
                </div>
                <div class="enquiryl">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>

                    <a class="contacttooltip" href="#">
                        <img alt="" src="images/details.png"><span class="classic">Please enter your name</span>
                    </a>

                    <asp:RequiredFieldValidator ID="rfvtxtName" runat="server" Text="Please enter your Name"
                        ControlToValidate="txtName" ValidationGroup="sec4" Display="Dynamic" CssClass="contact-error"></asp:RequiredFieldValidator>
                </div>
                <div class="clear">
                </div>
            </div>
            <div id="divEnquiry">
                <div class="enquiryr">
                    Enquiry:
                </div>
                <div class="enquiryl">
                    <textarea runat="server" id="txtenquiry" />

                    <a class="contacttooltip" href="#">
                        <img alt="" src="images/details.png"><span class="classic">Please enter your enquiry</span>
                    </a>

                    <asp:RequiredFieldValidator ID="rfvtxtEnquiry" runat="server" Text="Please enter your enquiry"
                        ControlToValidate="txtenquiry" ValidationGroup="sec4" Display="Dynamic" CssClass="contact-error"></asp:RequiredFieldValidator>
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
                        <img alt="" src="images/details.png"><span class="classic">Please enter your telephone number, preferably your mobile. Please enter numbers only and no spaces. For example 01656712345 or 07967123456.</span>
                    </a>

                    <asp:RegularExpressionValidator ID="revPhonenumber" runat="server" ControlToValidate="txtPhoneNumber"
                        ErrorMessage="Please enter your telephone number. Numbers only with no spaces." ValidationExpression="[\d]{2,3}[\d]{7,8}"
                        ValidationGroup="sec4" Display="Dynamic" CssClass="contact-error" EnableClientScript="false"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" Text="Please enter your telephone number. Numbers only with no spaces."
                        ControlToValidate="txtPhoneNumber" ValidationGroup="sec4" Display="Dynamic" CssClass="contact-error"></asp:RequiredFieldValidator>
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
                        <img alt="" src="images/details.png"><span class="classic">Please enter a valid email address, such as text@text.co.uk</span>
                    </a>

                    <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ControlToValidate="txtEmailAddress"
                        ErrorMessage="Please enter a valid email address, such as text@text.co.uk" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ValidationGroup="sec4" Display="Dynamic" CssClass="contact-error" EnableClientScript="false"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvEmailAddress" runat="server" Text="Please enter a valid email address, such as text@text.co.uk"
                        Display="Dynamic" ControlToValidate="txtEmailAddress" ValidationGroup="sec4" CssClass="contact-error"></asp:RequiredFieldValidator>
                </div>
                <div class="clear">
                </div>
            </div>
            <div>
                <div class="enquiryr">
                </div>
                <div>
                    <asp:Button ID="btnSubmit" type="button" runat="server" class="enquirybutton" ValidationGroup="sec4"
                        OnClick="btnSumit_click" />
                    <br />
                    <asp:Label ID="lblMessage" runat="server" EnableViewState="false" CssClass="thankyoumessage"></asp:Label>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
    </div>

    </div>
      
</div>
      
</div>
      
</div>
      
</div>
      
</div>
      
</div>
      
</div>
      
</div>
      
</div>
      
</div>
      
</asp:Content>
