<%@ Page Language="C#" MasterPageFile="~/Master/CarPageMaster.master" AutoEventWireup="true" Inherits="Car_Selection_3" Title="Contact Information" Codebehind="Car-Selection-3.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpCarWebsite1" runat="Server">
    <asp:ScriptManager runat="server" ID="scriptManager" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/tab.css" type="text/css" media="print, projection, screen">

    <script src="js/jquery.js" type="text/javascript"></script>

    <script src="js/jquery_002.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function() {

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
            $(function() {
                $('.bubbleInfo').each(function() {
                    var distance = 10;
                    var time = 250;
                    var hideDelay = 500;

                    var hideDelayTimer = null;

                    var beingShown = false;
                    var shown = false;
                    var trigger = $('.trigger', this);
                    var info = $('.popup', this).css('opacity', 0);


                    $([trigger.get(0), info.get(0)]).mouseover(function() {
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
                            }, time, 'swing', function() {
                                beingShown = false;
                                shown = true;
                            });
                        }

                        return false;
                    }).mouseout(function() {
                        if (hideDelayTimer) clearTimeout(hideDelayTimer);
                        hideDelayTimer = setTimeout(function() {
                            hideDelayTimer = null;
                            info.animate({
                                top: '-=' + distance + 'px',
                                opacity: 0
                            }, time, 'swing', function() {
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

        function fnFirstName()
        {
            if(document.getElementById("<%= txtFirstName.ClientID%>").value =='')
            {
                document.getElementById("trFirstName").style.backgroundColor = "#ffcccc";
            }
else 
{
 document.getElementById("trFirstName").style.backgroundColor = "#fff";
}
        }

        function fnPhoneNumber()
        {
            if(document.getElementById("<%= txtPhoneNumber.ClientID%>").value =='')
            {
                document.getElementById("trPhonenumber").style.backgroundColor = "#ffcccc";
            }
else
{
   document.getElementById("trPhonenumber").style.backgroundColor = "#fff";
}
        }

        function fnEmailAddress()
        {
            if(document.getElementById("<%= txtEmailAddress.ClientID%>").value =='')
            {
                document.getElementById("tremailaddress").style.backgroundColor = "#ffcccc";
            }
            else{
                if(!validateEmail(document.getElementById("<%= txtEmailAddress.ClientID%>").value))
                {
                    document.getElementById("tremailaddress").style.backgroundColor = "#ffcccc";
                }
else
{
document.getElementById("tremailaddress").style.backgroundColor = "#fff";
}
            }
        }

        function fnLastName()
        {
            if(document.getElementById("<%= txtLastName.ClientID%>").value =='')
            {
                document.getElementById("trlastname").style.backgroundColor = "#ffcccc";
            }
else
{
document.getElementById("trlastname").style.backgroundColor = "#fff";
}
        }

        function fnPostCode()
        {
            if(document.getElementById("<%= txtPostcode.ClientID%>").value =='')
            {
                document.getElementById("trpostcode").style.backgroundColor = "#ffcccc";
            }
else
{
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
                            if (control.id == "<%= txtFirstName.ClientID%>") {
                                document.getElementById("trFirstName").style.backgroundColor = "#ffcccc";
                                vInfo = false;
                            }
                            if (control.id == "<%= txtPhoneNumber.ClientID%>") {
                                document.getElementById("trPhonenumber").style.backgroundColor = "#ffcccc";
                                vInfo = false;
                            }
                            if (control.id == "<%= txtEmailAddress.ClientID%>") {
                                document.getElementById("tremailaddress").style.backgroundColor = "#ffcccc";
                                vInfo = false;
                            }
                            if (control.id == "<%= txtPostcode.ClientID%>") {
                                document.getElementById("trpostcode").style.backgroundColor = "#ffcccc";
                                vInfo = false;
                            }
                            if (control.id == "<%= txtLastName.ClientID%>") {
                                document.getElementById("trlastname").style.backgroundColor = "#ffcccc";
                                vInfo = false;
                            }     
                            if (control.id == "<%= txtPostcode.ClientID%>") {
                                document.getElementById("trpostcode").style.backgroundColor = "#ffcccc";
                                vInfo = false;
                            }     
                        }                                                
                    } catch (e) { }
                    
                }

if (!vInfo) {
                        document.getElementById('<%= rfvFirstName.ClientID %>').innerHTML = "Please enter your first name";
                        document.getElementById('<%= rfvLastName.ClientID %>').innerHTML = "Please enter your last name";
                        document.getElementById('<%= revPhoneNumber.ClientID %>').innerHTML = "Please enter your telephone number. Numbers only with no spaces.";
                        document.getElementById('<%= rfvPhoneNumber.ClientID %>').innerHTML = "Please enter your telephone number. Numbers only with no spaces.";
                        document.getElementById('<%= revEmailAddress.ClientID %>').innerHTML = "Please enter a valid email address, such as text@text.co.uk";
                        document.getElementById('<%= rfvEmailAddress.ClientID %>').innerHTML = "Please enter a valid email address, such as text@text.co.uk";
                        document.getElementById('<%= rfvPostCode.ClientID %>').innerHTML = "Please enter the post code of your address.";
                        

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
            Contact Information<span>A few simple steps
                <img alt="" src="~/images/step3.png" runat="server" />
            </span>
        </h2>
        <asp:UpdatePanel ID="pnlData" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
            <ContentTemplate>
                <div style="margin: 0 auto">
                    <div class="car-detail vehicle-details">
                        <table class="step2" width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <th width="283px" align="right" valign="middle">
                                    <b>Title :</b>
                                </th>
                                <th width="232px" align="left" valign="middle">
                                    <%-- <select class="small ClickTaleSensitive" id="ddlSaluation" runat="server">
                                <option value=""></option>
                                <option value="Mr">Mr</option>
                                <option value="Mrs">Mrs</option>
                                <option value="Miss">Miss</option>
                                <option value="Ms">Ms</option>
                            </select>--%>
                                    <asp:DropDownList CssClass="small ClickTaleSensitive" ID="ddlSaluation" runat="server">
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
                                        <span class="classic">Please select your title from the drop-down list or leave blank
                                            if you prefer.</span> </a>
                                </th>
                            </tr>
                            <tr id="trFirstName">
                                <th width="283px" align="right" valign="middle">
                                    <b>First Name :</b>
                                </th>
                                <th width="232px" align="left" valign="middle">
                                    <asp:TextBox ID="txtFirstName" runat="server" onblur="fnFirstName();"></asp:TextBox>
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
                                    <b>Last Name :</b>
                                </th>
                                <th width="232px" align="left" valign="middle">
                                    <asp:TextBox ID="txtLastName" runat="server" onblur="fnLastName();"></asp:TextBox>
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
                                    <b>Phone Number :</b>
                                </th>
                                <th width="232px" align="left" valign="middle">
                                    <asp:TextBox ID="txtPhoneNumber" runat="server" onblur="fnPhoneNumber();"></asp:TextBox>
                                </th>
                                <th align="left" valign="middle">
                                    <a href="#" class="tooltip">
                                        <img src="images/details.png" alt="" />
                                        <span class="classic">Please enter your telephone number, preferably your mobile. Please
                                            enter numbers only and no spaces. For example 01656712345 or 07967123456</span>
                                    </a>
                                    <asp:RegularExpressionValidator ID="revPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber"
                                        SetFocusOnError="True" ValidationExpression="[\d]{2,3}[\d]{9,10}" ValidationGroup="sec4"
                                        Display="Dynamic"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber"
                                        ValidationGroup="sec4" Display="Dynamic"></asp:RequiredFieldValidator>
                                </th>
                            </tr>
                            <tr id="tremailaddress">
                                <th width="283px" align="right" valign="middle">
                                    <b>Email Address :</b>
                                </th>
                                <th width="232px" align="left" valign="middle">
                                    <asp:TextBox ID="txtEmailAddress" runat="server" onblur="fnEmailAddress();"></asp:TextBox>
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
                                    <b>Postcode :</b>
                                </th>
                                <th width="232px" align="left" valign="middle">
                                    <asp:TextBox ID="txtPostcode" runat="server" onblur="fnPostCode();"></asp:TextBox>
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
                        </table>
                        <p>
                            <small>We have made some assumptions when valuing your vehicle
                                <asp:LinkButton runat="server" ID="btnassumption" OnClick="btnassumption_Click" CausesValidation="false">click here to view . </asp:LinkButton><%= BAL_CMS.GetDetailsByLinkName("contact-terms")%>
                                <br />
                                <asp:LinkButton runat="server" ID="btnTC" OnClick="btnTC_click" CausesValidation="false">To read the full terms and conditions please click here </asp:LinkButton></small>
                            <br />
                            <small>
                                <input id="chkAgree" type="checkbox" runat="server" checked="checked" /><i>I am happy
                                    to receive this information</i>
                                <asp:Label ID="lblMsg" runat="server" CssClass="red" EnableViewState="false"></asp:Label>
                            </small>
                        </p>
                        <p>
                            <asp:LinkButton ID="ImageButton1" runat="server" OnClick="btnGetValuation_Click" ValidationGroup="sec4" CssClass="button" />
                        </p>
                    </div>
                </div>
                </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:Panel ID="pnlPopup" runat="server" Style="border-color: Gray;" CssClass="modalPopup"
        Width="50%">
        <asp:Button Style="display: none" ID="btnShowPopup" runat="server"></asp:Button>
        <asp:Label Style="display: none" ID="lblMainId" runat="server"></asp:Label>
        <AjaxToolKit:ModalPopupExtender ID="mdlPopup" runat="server" TargetControlID="btnShowPopup"
            PopupControlID="pnlPopup" CancelControlID="btnClosePop" DropShadow="false" BackgroundCssClass="modalBackground">
        </AjaxToolKit:ModalPopupExtender>
        <fieldset>
            <legend>Assumptions made:</legend>
            <ul class="contact-term">
                <li>The vehicle has a maximum of one previous owner.</li>
                <li>The vehicle has full service history.</li>
                <li>The vehicle has the owner’s manual.</li>
                <li>In our view, the vehicle is in very good condition for it's age and all parts are
                    present.</li>
                <li>The vehicle isn't an import.</li>
                <li>The vehicle has never been subject to an insurance write off.</li>
                <li>The vehicle has never been used for private hire, driving tuition, as a police vehicle
                    or for rental purposes.</li>
                <li>The vehicle has both sets of keys.</li>
                <li>The vehicle has no internal, external or mechanical damage.</li>
                <li>The vehicle doesn't have a personalised registration.</li>
                <li>The vehicle has over 1 month left on its MOT.</li>
                <li>The vehicle starts and the engine runs.</li>
            </ul>
        </fieldset>
        <div class="FooterScrip">
            <center>
                <asp:LinkButton ID="btnClosePop" runat="server" Text="Close" CausesValidation="false" /></center>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlTC" runat="server" Style="border-color: Gray;" CssClass="modalPopup"
        Width="50%">
        <asp:Button Style="display: none" ID="btnTCShowPopup" runat="server"></asp:Button>
        <asp:Label Style="display: none" ID="Label1" runat="server"></asp:Label>
        <AjaxToolKit:ModalPopupExtender ID="mpTC" runat="server" TargetControlID="btnTCShowPopup"
            PopupControlID="pnlTC" CancelControlID="btnTCClose" DropShadow="false" BackgroundCssClass="modalBackground">
        </AjaxToolKit:ModalPopupExtender>
        <fieldset>
            <legend>Terms & Conditions:</legend>
            <ul class="contact-term">
                <li>We can alter or withdraw our offer at any time without reason</li>
                <li>If the vehicle, in our view, is not as described we can adjust the valuation accordingly.</li>
                <li>We will buy cars and vans that have remaining finance on them. But we will require the clearance/settlement
                    letter from the finance company.</li>
                <li>If Cash For Your Wheels pays off your finance and the accepted offer for your vehicle
                    doesn't cover it. You agree to pay CashForYourWheels the difference</li>
                <li>We will require the documents relating to the vehicle i.e the log book and MOT slips.
                    If we feel that the documents are not enough to prove ownership we will withdraw
                    our offer</li>
                <li>The quote you will receive is not an offer to purchase but a guide valuation for
                    your vehicle. Only an inspection by one of our buyers of your vehicle and it&rsquo;s
                    documents enable us to give you an offer to purchase</li>
                <li>Proof of ID will be required (e.g. driving licence) to prevent fraud. This information
                    will be passed on to the law enforcement authorities in the event that the car is
                    stolen or involved in any other criminal activities.</li>
                <li>The online price quoted is subject to the assumptions that we have made about the
                    car.(see these during valuation)</li>
                <li>All vehicles will be H.P.I, NMR and VOSA checked once the valuation has been agreed
                    by both parties.</li>
                <li>We reserve the right to alter the terms and conditions at any time.</li>
                <li>We do not charge any admin fees. Your payment is made by either Cheque or Faster Payment bank transfer (same day into your bank account).</li>
            </ul>
        </fieldset>
        <div class="FooterScrip">
            <center>
                <asp:LinkButton ID="btnTCClose" runat="server" Text="Close" CausesValidation="false" /></center>
        </div>
    </asp:Panel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" runat="server" Style="border-color: Gray; filter: alpha(opacity=50);
                opacity: 0.50; width: 100%; height: 100%; z-index: 10;">
                <asp:Image ID="Image1" ImageUrl="~/images/loading.gif" AlternateText="Processing"
                    runat="server" />
                    <p style="color:Black;font-size:medium;">We are retrieving your valuation, please wait a moment...</p>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <AjaxToolKit:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
        PopupControlID="UpdateProgress" BackgroundCssClass="modalBackground">
    </AjaxToolKit:ModalPopupExtender>
</asp:Content>
