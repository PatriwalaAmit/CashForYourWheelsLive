<%@ Page Language="C#" MasterPageFile="~/Master/CarPageMaster.master" AutoEventWireup="true"
    Inherits="index" Title="Cash For Your Wheels" CodeBehind="index.aspx.cs" %>

<%-- Add content controls here --%>
<asp:Content ContentPlaceHolderID="cpCarWebsite1" runat="server">
    <script src="js/jquery-1.js" type="text/javascript"></script>
    <script src="js/jquery_002.js" type="text/javascript"></script>
    <script type="text/javascript">
        //<![CDATA[
        function WebForm_OnSubmit() {
            if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                document.getElementById("divCarRegNumber").style.backgroundColor = "#ffcccc";
                return false;
            }
            else {
                return true;
            }
        }
        //]]>
    </script>
    <script type="text/javascript">
        $(function () {

            $('#div-1').tabs({ fxFade: true, fxSpeed: 'slow' });

        });

        function ChangeTextValue(obj) {
            if (document.getElementById(obj).value == '') {
                document.getElementById(obj).value = "YOUR REG";
            }
            else if (document.getElementById(obj).value == 'YOUR REG') {
                document.getElementById(obj).value = '';
                document.getElementById('divCarRegNumber').style.background = "#ffcccc";
            }
        }

        function checkTextValue() {
            if (document.getElementById('<%= txtSellCarRegNumber.ClientID %>').value == 'YOUR REG') {
                document.getElementById('<%= txtSellCarRegNumber.ClientID %>').value = '';
                document.getElementById('divCarRegNumber').style.background = "#ffcccc";
            }
        }

        function numeralsOnly(obj, evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
            ((evt.which) ? evt.which : 0));
            if (((charCode >= '65') && (charCode <= '90')) || ((charCode >= '97') && (charCode <= '122')) || ((charCode >= '48') && (charCode <= '57')) || charCode == '8') {
                return true;
            }
            return false;
        }

        function uppercase(obj) {
            document.getElementById(obj.id).value = document.getElementById(obj.id).value.toUpperCase();
        }

        function getMsg() {
            //alert('There is a problem with the registration' + '\r\n' + 'for an instant valuation.');
            document.getElementById("divCarRegNumber").style.backgroundColor = "#ffcccc";
        }

    </script>
    <style>
        .covid19
        {
            font-size: 18px;
            padding: 10px;
            text-align: center;
            background: #fbff00;
            color: #000;
            margin-bottom: 10px;
            border-radius: 10px;
        }
            
        .blinking
        {
	        animation:blinkingText 10s infinite;
        }
        @keyframes blinkingText
        {
	        0%{color: #000;}
	        49%{color: #000;}
	        50%{color: #000;}
	        99%{color:transparent;}
	        100%{color: #000;}
        }
    </style>
    <div class="home-mid">
        <div class="covid19">
            <span class="blinking">Book an appointment online and you can take the car to your local branch and we will purchase your car contactless as in accordance with government guidelines.</span></div>
        <div class="step">
            <h2>
                Just a few simple steps...</h2>
            <ul>
                <li class="step-1">Enter your reg number in the box and<br>
                    we’ll ask you some simple questions<br>
                    about your car or van. </li>
                <li class="step-2">If you're happy with our valuation,<br>
                    then book an appointment at your<br>
                    local branch.</li>
                <li class="step-3">If you’re happy to proceed, we’ll take<br>
                    your vehicle off your hands and pay the
                    <br>
                    money into your bank account</li>
            </ul>
        </div>
        <div class="registration-box">
            <h2>
                Enter your registration for<br>
                an instant free valuation</h2>
            <div id="divCarRegNumber">
                <asp:TextBox ID="txtSellCarRegNumber" runat="server" Text="YOUR REG" onfocus="this.value='';"
                    onblur="ChangeTextValue(this.id);" onkeyup="uppercase(this);" onkeypress="return numeralsOnly(this,event)"
                    ValidationGroup="vc" MaxLength="8"> </asp:TextBox>
                <div style="font-size: 14px; margin: -10px 0px 0px 45px; padding-bottom: 10px;">
                    <asp:RequiredFieldValidator ID="rfvtxtSellCarRegNumber" ControlToValidate="txtSellCarRegNumber"
                        ErrorMessage="Please enter the correct registration number for your vehicle"
                        runat="server" ValidationGroup="vc" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <asp:Button ID="btnCarGo" runat="server" CssClass="button" OnClick="btnCarGo_Click"
                ValidationGroup="vc" OnClientClick="checkTextValue();" />
        </div>
    </div>
</asp:Content>
