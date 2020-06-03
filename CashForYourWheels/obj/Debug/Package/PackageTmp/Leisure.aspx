<%@ Page Language="C#" MasterPageFile="~/Master/CarPageMaster.master" AutoEventWireup="true"
    Inherits="Leisure" Title="Contact Information" CodeBehind="Leisure.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpCarWebsite1" runat="Server">
    <asp:ScriptManager runat="server" ID="scriptManager" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/tab.css" type="text/css" media="print, projection, screen">
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/jquery_002.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $('#div-1').tabs({ fxFade: true, fxSpeed: 'slow' });

        });
    </script>
    <script type="text/javascript">
        function ValidatePostcode(sender, args) {
            args.IsValid = (args.Value.match(/(GIR 0AA|[A-PR-UWYZ]([0-9]{1,2}|([A-HK-Y][0-9]|[A-HK-Y][0-9]([0-9]|[ABEHMNPRV-Y]))|[0-9][A-HJKS-UW]) [0-9][ABD-HJLNP-UW-Z]{2})/i) != null);
            return args.IsValid;
        }

    </script>
    <script type="text/javascript">
        <!--
        $(function () {
            $('.bubbleInfo').each(function () {
                var distance = 10;
                var time = 250;
                var hideDelay = 500;

                var hideDelayTimer = null;

                var beingShown = false;
                var shown = false;
                var trigger = $('.trigger', this);
                var info = $('.popup', this).css('opacity', 0);


                $([trigger.get(0), info.get(0)]).mouseover(function () {
                    if (hideDelayTimer) clearTimeout(hideDelayTimer);
                    if (beingShown || shown) {
                        // don't trigger the animation again
                        return;
                    } else {
                        // reset position of info box
                        beingShown = true;

                        info.css({
                            top: 26,
                            left: -33,
                            display: 'block'
                        }).animate({
                            top: '-=' + distance + 'px',
                            opacity: 1
                        }, time, 'swing', function () {
                            beingShown = false;
                            shown = true;
                        });
                    }

                    return false;
                }).mouseout(function () {
                    if (hideDelayTimer) clearTimeout(hideDelayTimer);
                    hideDelayTimer = setTimeout(function () {
                        hideDelayTimer = null;
                        info.animate({
                            top: '-=' + distance + 'px',
                            opacity: 0
                        }, time, 'swing', function () {
                            shown = false;
                            info.css('display', 'none');
                        });

                    }, hideDelay);

                    return false;
                });
            });
        });
    
        //-->

    </script>
    <script type="text/javascript">

        function fnRegistration() {
            if (document.getElementById("<%= txtRegistration.ClientID%>").value == '') {
                document.getElementById("trRegistration").style.backgroundColor = "#ffcccc";
            }
            else {
                document.getElementById("trRegistration").style.backgroundColor = "#fff";
            }
        }

        function fnVehicleType() {
            if (document.getElementById("<%= ddlVehicleType.ClientID%>").value == '') {
                document.getElementById("trVehicleType").style.backgroundColor = "#ffcccc";
            }
            else {
                document.getElementById("trVehicleType").style.backgroundColor = "#fff";
            }
        }

        function fnMakeModel() {
            if (document.getElementById("<%= txtMakeModel.ClientID%>").value == '') {
                document.getElementById("trMakeModel").style.backgroundColor = "#ffcccc";
            }
            else {
                document.getElementById("trMakeModel").style.backgroundColor = "#fff";
            }
        }

        function fnMileage() {
            if (document.getElementById("<%= txtMileage.ClientID%>").value == '') {
                document.getElementById("trMileage").style.backgroundColor = "#ffcccc";
            }
            else {
                document.getElementById("trMileage").style.backgroundColor = "#fff";
            }
        }

        function fnSaluation() {
            if (document.getElementById("<%= ddlSaluation.ClientID%>").value == '') {
                document.getElementById("trSaluation").style.backgroundColor = "#ffcccc";
            }
            else {
                document.getElementById("trSaluation").style.backgroundColor = "#fff";
            }
        }

        function fnFirstName() {
            if (document.getElementById("<%= txtFirstName.ClientID%>").value == '') {
                document.getElementById("trFirstName").style.backgroundColor = "#ffcccc";
            }
            else {
                document.getElementById("trFirstName").style.backgroundColor = "#fff";
            }
        }

        function fnPhoneNumber() {
            if (document.getElementById("<%= txtPhoneNumber.ClientID%>").value == '') {
                document.getElementById("trPhonenumber").style.backgroundColor = "#ffcccc";
            }
            else {
                document.getElementById("trPhonenumber").style.backgroundColor = "#fff";
            }
        }

        function fnEmailAddress() {
            if (document.getElementById("<%= txtEmailAddress.ClientID%>").value == '') {
                document.getElementById("tremailaddress").style.backgroundColor = "#ffcccc";
            }
            else {
                if (!validateEmail(document.getElementById("<%= txtEmailAddress.ClientID%>").value)) {
                    document.getElementById("tremailaddress").style.backgroundColor = "#ffcccc";
                }
                else {
                    document.getElementById("tremailaddress").style.backgroundColor = "#fff";
                }
            }
        }

        function fnLastName() {
            if (document.getElementById("<%= txtLastName.ClientID%>").value == '') {
                document.getElementById("trlastname").style.backgroundColor = "#ffcccc";
            }
            else {
                document.getElementById("trlastname").style.backgroundColor = "#fff";
            }
        }

        function fnPostCode() {
            if (document.getElementById("<%= txtPostcode.ClientID%>").value == '') {
                document.getElementById("trpostcode").style.backgroundColor = "#ffcccc";
            }
            else {
                document.getElementById("trpostcode").style.backgroundColor = "#fff";
            }
        }

        function validateEmail(email) {
            var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        }

        function WebForm_OnSubmit() {
            if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                var vInfo = true;
                for (var i in Page_Validators) {
                    try {
                        var control = document.getElementById(Page_Validators[i].controltovalidate);
                        if (!Page_Validators[i].isvalid) {

                            if (control.id == "<%= ddlSaluation.ClientID%>") {
                                document.getElementById("trSaluation").style.backgroundColor = "#ffcccc";
                                document.getElementById('<%= rfvSaluation.ClientID %>').innerHTML = "Please select your title from the drop-down list.";
                                vInfo = false;
                            }

                            if (control.id == "<%= txtMileage.ClientID%>") {
                                document.getElementById("trMileage").style.backgroundColor = "#ffcccc";
                                document.getElementById('<%= rfvMileage.ClientID %>').innerHTML = "Please enter the mileage.";
                                vInfo = false;
                            }

                            if (control.id == "<%= txtMakeModel.ClientID%>") {
                                document.getElementById("trMakeModel").style.backgroundColor = "#ffcccc";
                                document.getElementById('<%= rfvMakeModel.ClientID %>').innerHTML = "Please enter the make and model.";
                                vInfo = false;
                            }

                            if (control.id == "<%= ddlVehicleType.ClientID%>") {
                                document.getElementById("trVehicleType").style.backgroundColor = "#ffcccc";
                                document.getElementById('<%= rfvVehicleType.ClientID %>').innerHTML = "Please select your vehicle from the dropdown list.";
                                vInfo = false;
                            }

                            if (control.id == "<%= txtRegistration.ClientID%>") {
                                document.getElementById("trRegistration").style.backgroundColor = "#ffcccc";
                                document.getElementById('<%= rfvRegistration.ClientID %>').innerHTML = "Please enter the registration number of the vehicle.";
                                vInfo = false;
                            }

                            if (control.id == "<%= txtFirstName.ClientID%>") {
                                document.getElementById("trFirstName").style.backgroundColor = "#ffcccc";
                                document.getElementById('<%= rfvFirstName.ClientID %>').innerHTML = "Please enter your first name";
                                vInfo = false;
                            }

                            if (control.id == "<%= txtPhoneNumber.ClientID%>") {
                                document.getElementById("trPhonenumber").style.backgroundColor = "#ffcccc";
                                document.getElementById('<%= rfvPhoneNumber.ClientID %>').innerHTML = "Please enter your phone number";
                                vInfo = false;
                            }
                            if (control.id == "<%= txtEmailAddress.ClientID%>") {
                                document.getElementById("tremailaddress").style.backgroundColor = "#ffcccc";
                                document.getElementById('<%= rfvEmailAddress.ClientID %>').innerHTML = "Please enter a valid email address, such as text@text.co.uk";
                                vInfo = false;
                            }

                            if (control.id == "<%= txtLastName.ClientID%>") {
                                document.getElementById("trlastname").style.backgroundColor = "#ffcccc";
                                document.getElementById('<%= rfvLastName.ClientID %>').innerHTML = "Please enter your last name";
                                vInfo = false;
                            }
                            if (control.id == "<%= txtPostcode.ClientID%>") {
                                document.getElementById("trpostcode").style.backgroundColor = "#ffcccc";
                                document.getElementById('<%= rfvPostCode.ClientID %>').innerHTML = "Please enter the post code of your address.";
                                vInfo = false;
                            }
                        }
                    } catch (e) { }

                }

                if (!vInfo) {
                    //                    document.getElementById('<%= rfvFirstName.ClientID %>').innerHTML = "Please enter your first name";
                    //                    document.getElementById('<%= rfvLastName.ClientID %>').innerHTML = "Please enter your last name";
                    //                    document.getElementById('<%= revEmailAddress.ClientID %>').innerHTML = "Please enter a valid email address, such as text@text.co.uk";
                    //                    document.getElementById('<%= rfvEmailAddress.ClientID %>').innerHTML = "Please enter a valid email address, such as text@text.co.uk";
                    //                    document.getElementById('<%= rfvPostCode.ClientID %>').innerHTML = "Please enter the post code of your address.";
                    return false;
                }
                return false;
            }
            return true;
        }
    </script>
    <script type="text/javascript">

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
        prm.add_beginRequest(BeginRequestHandler);
        // Raised after an asynchronous postback is finished and control has been returned to the browser.
        prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            //Shows the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
            if (popup != null) {
                popup.show();
            }
        }

        function EndRequestHandler(sender, args) {
            //Hide the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
            if (popup != null) {
                popup.hide();
            }
        }
    </script>
    <div class="your-car">
        <h2>
            Sell My Leisure Vehicle</h2>
        <asp:UpdatePanel ID="pnlData" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
            <ContentTemplate>
                <div style="margin: 0 auto">
                    <div class="car-detail vehicle-details">
                        <table class="step2" width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr id="trRegistration">
                                <th width="283px" align="right" valign="middle">
                                    <b>Registration</b>
                                </th>
                                <th width="232px" align="left" valign="middle">
                                    <asp:TextBox ID="txtRegistration" MaxLength="7" runat="server" TabIndex="1" onblur="fnRegistration();"></asp:TextBox>
                                </th>
                                <th align="left" valign="middle">
                                    <a href="#" class="tooltip">
                                        <img src="images/details.png" alt="" />
                                        <span class="classic">Please enter the registration number of the vehicle.</span>
                                    </a>
                                    <asp:RequiredFieldValidator ID="rfvRegistration" runat="server" ControlToValidate="txtRegistration"
                                        Display="Dynamic" ValidationGroup="sec4"></asp:RequiredFieldValidator>
                                </th>
                            </tr>
                            <tr id="trVehicleType">
                                <th width="283px" align="right" valign="middle">
                                    <b>Vehicle Type </b>
                                </th>
                                <th width="232px" align="left" valign="middle">
                                    <asp:DropDownList CssClass="small ClickTaleSensitive" ID="ddlVehicleType" runat="server"
                                        TabIndex="2" onblur="fnVehicleType();">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Camper Van" Value="Camper Van">Camper Van</asp:ListItem>
                                        <asp:ListItem Text="Caravan" Value="Caravan">Caravan</asp:ListItem>
                                        <asp:ListItem Text="Motorhome" Value="Motorhome">Motorhome</asp:ListItem>
                                        <asp:ListItem Text="Self Conversion" Value="Self Conversion">Self Conversion</asp:ListItem>
                                    </asp:DropDownList>
                                </th>
                                <th align="left" valign="middle">
                                    <a href="#" class="tooltip">
                                        <img src="images/details.png" alt="" />
                                        <span class="classic">Please select your vehicle from the dropdown list.</span>
                                        <asp:RequiredFieldValidator ID="rfvVehicleType" runat="server" ControlToValidate="ddlVehicleType"
                                            Display="Dynamic" ValidationGroup="sec4"></asp:RequiredFieldValidator>
                                    </a>
                                </th>
                            </tr>
                            <tr id="trMakeModel">
                                <th width="283px" align="right" valign="middle">
                                    <b>Make &amp; Model </b>
                                </th>
                                <th width="232px" align="left" valign="middle">
                                    <asp:TextBox ID="txtMakeModel" runat="server" TabIndex="3" onblur="fnMakeModel();"></asp:TextBox>
                                </th>
                                <th align="left" valign="middle">
                                    <a href="#" class="tooltip">
                                        <img src="images/details.png" alt="" />
                                        <span class="classic">Please enter the make and model.</span> </a>
                                    <asp:RequiredFieldValidator ID="rfvMakeModel" runat="server" ControlToValidate="txtMakeModel"
                                        Display="Dynamic" ValidationGroup="sec4"></asp:RequiredFieldValidator>
                                </th>
                            </tr>
                            <tr id="trMileage">
                                <th width="283px" align="right" valign="middle">
                                    <b>Mileage </b>
                                </th>
                                <th width="232px" align="left" valign="middle">
                                    <asp:TextBox ID="txtMileage" MaxLength="6" runat="server" TabIndex="4" onblur="fnMileage();"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="ftb1" runat="server" FilterType="Numbers"
                                        TargetControlID="txtMileage" />
                                </th>
                                <th align="left" valign="middle">
                                    <a href="#" class="tooltip">
                                        <img src="images/details.png" alt="" />
                                        <span class="classic">Please enter the mileage.</span> </a>
                                    <asp:RequiredFieldValidator ID="rfvMileage" runat="server" ControlToValidate="txtMileage"
                                        Display="Dynamic" ValidationGroup="sec4"></asp:RequiredFieldValidator>
                                </th>
                            </tr>
                            <tr id="trSaluation">
                                <th width="283px" align="right" valign="middle">
                                    <b>Title </b>
                                </th>
                                <th width="232px" align="left" valign="middle">
                                    <%-- <select class="small ClickTaleSensitive" id="ddlSaluation" runat="server">
                                <option value=""></option>
                                <option value="Mr">Mr</option>
                                <option value="Mrs">Mrs</option>
                                <option value="Miss">Miss</option>
                                <option value="Ms">Ms</option>
                            </select>--%>
                                    <asp:DropDownList CssClass="small ClickTaleSensitive" ID="ddlSaluation" runat="server"
                                        TabIndex="5" onblur="fnSaluation();">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Mr" Value="Mr"> Mr</asp:ListItem>
                                        <asp:ListItem Text="Mrs" Value="Mrs">Mrs</asp:ListItem>
                                        <asp:ListItem Text="Miss" Value="Miss">Miss</asp:ListItem>
                                        <asp:ListItem Text="Ms" Value="Ms">Ms</asp:ListItem>
                                    </asp:DropDownList>
                                </th>
                                <th align="left" valign="middle">
                                    <a href="#" class="tooltip">
                                        <img src="images/details.png" alt="" />
                                        <span class="classic">Please select your title from the drop-down list.</span> </a>
                                    <asp:RequiredFieldValidator ID="rfvSaluation" runat="server" ControlToValidate="ddlSaluation"
                                        Display="Dynamic" ValidationGroup="sec4"></asp:RequiredFieldValidator>
                                </th>
                            </tr>
                            <tr id="trFirstName">
                                <th width="283px" align="right" valign="middle">
                                    <b>First Name </b>
                                </th>
                                <th width="232px" align="left" valign="middle">
                                    <asp:TextBox ID="txtFirstName" runat="server" onblur="fnFirstName();" TabIndex="6"></asp:TextBox>
                                </th>
                                <th align="left" valign="middle">
                                    <a href="#" class="tooltip">
                                        <img src="images/details.png" alt="" />
                                        <span class="classic">Please enter your first name.</span> </a>
                                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                                        Display="Dynamic" ValidationGroup="sec4"></asp:RequiredFieldValidator>
                                </th>
                            </tr>
                            <tr id="trlastname">
                                <th width="283px" align="right" valign="middle">
                                    <b>Last Name </b>
                                </th>
                                <th width="232px" align="left" valign="middle">
                                    <asp:TextBox ID="txtLastName" runat="server" onblur="fnLastName();" TabIndex="7"></asp:TextBox>
                                </th>
                                <th align="left" valign="middle">
                                    <a href="#" class="tooltip">
                                        <img src="images/details.png" alt="" />
                                        <span class="classic">Please enter your surname.</span> </a>
                                    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
                                        Display="Dynamic" ValidationGroup="sec4"></asp:RequiredFieldValidator>
                                </th>
                            </tr>
                            <tr id="trPhonenumber">
                                <th width="283px" align="right" valign="middle">
                                    <b>Phone Number </b>
                                </th>
                                <th width="232px" align="left" valign="middle">
                                    <asp:TextBox ID="txtPhoneNumber" runat="server" onblur="fnPhoneNumber();" TabIndex="8"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        FilterType="Numbers" TargetControlID="txtPhoneNumber" />
                                </th>
                                <th align="left" valign="middle">
                                    <a href="#" class="tooltip">
                                        <img src="images/details.png" alt="" />
                                        <span class="classic">Please enter your telephone number, preferably your mobile - we
                                            will call you on this number to discuss your vehicle and give you a final offer.
                                            Please enter numbers only and no spaces. For example 01656712345 or 07967123456</span>
                                    </a>
                                    <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber"
                                        ValidationGroup="sec4" Display="Dynamic"></asp:RequiredFieldValidator>
                                </th>
                            </tr>
                            <tr id="tremailaddress">
                                <th width="283px" align="right" valign="middle">
                                    <b>Email Address </b>
                                </th>
                                <th width="232px" align="left" valign="middle">
                                    <asp:TextBox ID="txtEmailAddress" runat="server" onblur="fnEmailAddress();" TabIndex="9"></asp:TextBox>
                                </th>
                                <th align="left" valign="middle">
                                    <a href="#" class="tooltip">
                                        <img src="images/details.png" alt="" />
                                        <span class="classic">Please enter your email address - we will use this address to
                                            send out your vehicle valuation by email.</span> </a>
                                    <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ControlToValidate="txtEmailAddress"
                                        SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="sec4" Display="Dynamic"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="rfvEmailAddress" runat="server" Display="Dynamic"
                                        ControlToValidate="txtEmailAddress" ValidationGroup="sec4"></asp:RequiredFieldValidator>
                                </th>
                            </tr>
                            <tr id="trpostcode">
                                <th width="283px" align="right" valign="middle">
                                    <b>Postcode </b>
                                </th>
                                <th width="232px" align="left" valign="middle">
                                    <asp:TextBox ID="txtPostcode" runat="server" onblur="fnPostCode();" TabIndex="10"></asp:TextBox>
                                </th>
                                <th align="left" valign="middle">
                                    <a href="#" class="tooltip">
                                        <img src="images/details.png" alt="" />
                                        <span class="classic">Please enter your full postcode so that we can ensure that you
                                            are directed to the nearest possible cashforyourwheels branch when you choose to
                                            sell your vehicle. e.g AA00 AAB</span> </a>
                                    <asp:RequiredFieldValidator ID="rfvPostCode" runat="server" ControlToValidate="txtPostcode"
                                        ValidationGroup="sec4" Display="Dynamic"></asp:RequiredFieldValidator>
                                </th>
                            </tr>
                            <tr id="tr1">
                                <th width="283px" align="right" valign="top">
                                    <b>Other Information About Vehicle</b>
                                </th>
                                <th width="232px" align="left" valign="middle">
                                    <asp:TextBox ID="txtOtherInfo" runat="server" placeholder="Specification, 4 Berth, White, Cooker, Fridge etc"
                                        Height="100px" TextMode="MultiLine" Width="208px" TabIndex="11"></asp:TextBox>
                                </th>
                                <th align="left" valign="middle">
                                    <a href="#" class="tooltip">
                                        <img src="images/details.png" alt="" />
                                        <span class="classic">Please enter any additional information about your vehicle like
                                            specification, damage or any issues etc</span> </a>
                                </th>
                            </tr>
                        </table>
                        <p>
                            <asp:LinkButton ID="ImageButton1" runat="server" OnClick="btnGetValuation_Click"
                                ValidationGroup="sec4" CssClass="button" TabIndex="12" />
                        </p>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:UpdateProgress ID="UpdateProgress" runat="server">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" runat="server" Style="border-color: Gray; filter: alpha(opacity=50);
                opacity: 0.50; width: 100%; height: 100%; z-index: 10;">
                <asp:Image ID="Image1" ImageUrl="~/images/loading.gif" AlternateText="Processing"
                    runat="server" />
                <p style="color: Black; font-size: medium;">
                    Processing information, please wait a moment...</p>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <ajaxToolkit:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
        PopupControlID="UpdateProgress" BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>
</asp:Content>
