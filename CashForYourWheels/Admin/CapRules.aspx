<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminPanel.master" AutoEventWireup="true"
    CodeBehind="CapRules.aspx.cs" Inherits="CashForYourWheels.Admin.CapRules" %>

<%@ Register Src="~/UserControls/UserSiteMap.ascx" TagName="UserSiteMap" TagPrefix="uc1" %>
<%@ Register Assembly="CustomPagingGridView" Namespace="CustomPagingGridView" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .CapText {
            width: 180px;
            text-align: right;
            vertical-align: top;
            border-bottom: 2px solid #CCCCCC;
            color: #000000;
            font-family: 'Helvetica',arial;
            font-size: 14px;
            font-weight: normal;
            line-height: 21px;
            padding: 15px 15px 15px 0;
            font-weight: bold;
        }

        .CapDataTD {
            text-align: left;
            vertical-align: top;
            border-bottom: 2px solid #CCCCCC;
            color: #000000;
            font-family: 'Helvetica',arial;
            font-size: 14px;
            font-weight: normal;
            line-height: 21px;
            padding: 15px 15px 15px 0;
        }

        .capRules table td select {
            background: none repeat scroll 0 0 #FFFFFF;
            border: 1px solid #C2C2C2;
            border-radius: 3px 3px 3px 3px;
            height: 25px;
            line-height: 25px;
            padding: 3px;
            width: 226px;
        }

        .capRules table td input {
            background: none repeat scroll 0 0 #FFFFFF;
            border: 1px solid #C2C2C2;
            border-radius: 3px 3px 3px 3px;
            <%--height: 23px;
            --%> padding: 0 6px;
            <%--width: 212px;
            --%>
        }

        .condition {
            background-color: #c7c7c7;
        }

        .txt {
            height: 23px;
        }

        .button1 {
            background: #c9061d !important;
            color: #fff;
        }
    </style>
    <div class="capRules">
        <table cellpadding="0" cellspacing="0" width="100%" class="Table_Border_Black">
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" width="100%" style="height: 25px" class="Table_Bck1">
                        <tr>
                            <td class="table_td_left">
                                <asp:Label ID="Label1" runat="server" Text="Cap Rules" CssClass="Table_Title_Label_White">
                                </asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 30px" class="table_td_left">
                    <uc1:UserSiteMap ID="UserSiteMap2" runat="server" />
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" width="100%" class="">
            <tr>
                <td class="table_td_left" colspan="2">
                    <asp:Label ID="Label7" runat="server" Text="CAP Rules" CssClass="Link_Label_Bold">
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td class="table_td_left" colspan="2">
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <table class="Table_Border_Black" cellspacing="0" cellpadding="0" width="100%">
                        <tbody>
                            <tr>
                                <td class="CapText">
                                    Rule Name :
                                </td>
                                <td class="CapDataTD">
                                    <asp:TextBox ID="txtRuleName" runat="server" Width="250px" CssClass="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <%--<tr>
                                <td class="CapText">Age of vehicle :
                                </td>
                                <td class="CapDataTD">From:
                                    <asp:DropDownList ID="ddlAgeFrom" runat="server">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                    </asp:DropDownList>
                                    To:
                                    <asp:DropDownList ID="ddlAgeTo" runat="server">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="condition">
                                <td class="CapText">Apply the next condition :
                                </td>
                                <td class="CapDataTD">
                                    <asp:DropDownList ID="ddlNCAge" runat="server">
                                        <asp:ListItem>None</asp:ListItem>
                                        <asp:ListItem>AND</asp:ListItem>
                                        <asp:ListItem>OR</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="CapText">Mileage of vehicle :
                                </td>
                                <td class="CapDataTD">From:
                                    <asp:DropDownList ID="ddlMileageFrom" runat="server">
                                        <asp:ListItem Value="1000">1000</asp:ListItem>
                                        <asp:ListItem Value="2000">2000</asp:ListItem>
                                        <asp:ListItem Value="3000">3000</asp:ListItem>
                                        <asp:ListItem Value="4000">4000</asp:ListItem>
                                        <asp:ListItem Value="5000">5000</asp:ListItem>
                                        <asp:ListItem Value="6000">6000</asp:ListItem>
                                        <asp:ListItem Value="7000">7000</asp:ListItem>
                                        <asp:ListItem Value="8000">8000</asp:ListItem>
                                        <asp:ListItem Value="9000">9000</asp:ListItem>
                                        <asp:ListItem Value="10000">10,000</asp:ListItem>
                                        <asp:ListItem Value="11000">11,000</asp:ListItem>
                                        <asp:ListItem Value="12000">12,000</asp:ListItem>
                                    </asp:DropDownList>
                                    To:
                                    <asp:DropDownList ID="ddlMileageTo" runat="server">
                                        <asp:ListItem Value="1000">1000</asp:ListItem>
                                        <asp:ListItem Value="2000">2000</asp:ListItem>
                                        <asp:ListItem Value="3000">3000</asp:ListItem>
                                        <asp:ListItem Value="4000">4000</asp:ListItem>
                                        <asp:ListItem Value="5000">5000</asp:ListItem>
                                        <asp:ListItem Value="6000">6000</asp:ListItem>
                                        <asp:ListItem Value="7000">7000</asp:ListItem>
                                        <asp:ListItem Value="8000">8000</asp:ListItem>
                                        <asp:ListItem Value="9000">9000</asp:ListItem>
                                        <asp:ListItem Value="10000">10,000</asp:ListItem>
                                        <asp:ListItem Value="11000">11,000</asp:ListItem>
                                        <asp:ListItem Value="12000">12,000</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="condition">
                                <td class="CapText">Apply the next condition :
                                </td>
                                <td class="CapDataTD">
                                    <asp:DropDownList ID="ddlNCMileage" runat="server">
                                        <asp:ListItem>None</asp:ListItem>
                                        <asp:ListItem>AND</asp:ListItem>
                                        <asp:ListItem>OR</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="CapText">Vehicle Body Type :
                                </td>
                                <td class="CapDataTD">
                                    <asp:CheckBoxList runat="server" ID="chklstVehicleType">
                                        <asp:ListItem>Saloon</asp:ListItem>
                                        <asp:ListItem>Coupe</asp:ListItem>
                                        <asp:ListItem>MPV</asp:ListItem>
                                        <asp:ListItem>SUV</asp:ListItem>
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr class="condition">
                                <td class="CapText">Apply the next condition :
                                </td>
                                <td class="CapDataTD">
                                    <asp:DropDownList ID="ddlNCBodyType" runat="server">
                                        <asp:ListItem>None</asp:ListItem>
                                        <asp:ListItem>AND</asp:ListItem>
                                        <asp:ListItem>OR</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="CapText">Fuel Type :
                                </td>
                                <td class="CapDataTD">
                                    <asp:CheckBoxList ID="chklstFuelType" runat="server">
                                        <asp:ListItem>Diesel</asp:ListItem>
                                        <asp:ListItem>Petrol</asp:ListItem>
                                        <asp:ListItem>Hybrid</asp:ListItem>
                                        <asp:ListItem>Electric</asp:ListItem>
                                        <asp:ListItem>Hybrid/Diesel Electric</asp:ListItem>
                                        <asp:ListItem>Hybrid Petrol Electric</asp:ListItem>
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr class="condition">
                                <td class="CapText">Apply the next condition :
                                </td>
                                <td class="CapDataTD">
                                    <asp:DropDownList ID="ddlNCFuelType" runat="server">
                                        <asp:ListItem>None</asp:ListItem>
                                        <asp:ListItem>AND</asp:ListItem>
                                        <asp:ListItem>OR</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="CapText">Engine Size :
                                </td>
                                <td class="CapDataTD">From:
                                    <asp:DropDownList ID="ddlEngineSizeFrom" runat="server">
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>1000</asp:ListItem>
                                        <asp:ListItem>5000</asp:ListItem>
                                        <asp:ListItem>7000</asp:ListItem>
                                        <asp:ListItem>9000</asp:ListItem>
                                        <asp:ListItem Value="10000">10,000</asp:ListItem>
                                        <asp:ListItem Value="11000">11,000</asp:ListItem>
                                        <asp:ListItem Value="12000">12,000</asp:ListItem>
                                        <asp:ListItem Value="13000">13,000</asp:ListItem>
                                        <asp:ListItem Value="14000">14,000</asp:ListItem>
                                        <asp:ListItem Value="15000">15,000</asp:ListItem>
                                    </asp:DropDownList>
                                    To:
                                    <asp:DropDownList ID="ddlEngineSizeTo" runat="server">
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>1000</asp:ListItem>
                                        <asp:ListItem>5000</asp:ListItem>
                                        <asp:ListItem>7000</asp:ListItem>
                                        <asp:ListItem>9000</asp:ListItem>
                                        <asp:ListItem Value="10000">10,000</asp:ListItem>
                                        <asp:ListItem Value="11000">11,000</asp:ListItem>
                                        <asp:ListItem Value="12000">12,000</asp:ListItem>
                                        <asp:ListItem Value="13000">13,000</asp:ListItem>
                                        <asp:ListItem Value="14000">14,000</asp:ListItem>
                                        <asp:ListItem Value="15000">15,000</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="condition">
                                <td class="CapText">Apply the next condition :
                                </td>
                                <td class="CapDataTD">
                                    <asp:DropDownList ID="ddlNCEngineSize" runat="server">
                                        <asp:ListItem>None</asp:ListItem>
                                        <asp:ListItem>AND</asp:ListItem>
                                        <asp:ListItem>OR</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="CapText">Gearbox :
                                </td>
                                <td class="CapDataTD">
                                    <asp:DropDownList ID="ddlGearbox" runat="server">
                                        <asp:ListItem>Automatic</asp:ListItem>
                                        <asp:ListItem>Manual Drivetrain - Four Wheel Drive</asp:ListItem>
                                        <asp:ListItem>Manual Drivetrain - 2 wheel drive Doors</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="condition">
                                <td class="CapText">Apply the next condition :
                                </td>
                                <td class="CapDataTD">
                                    <asp:DropDownList ID="ddlNCGearbox" runat="server">
                                        <asp:ListItem>None</asp:ListItem>
                                        <asp:ListItem>AND</asp:ListItem>
                                        <asp:ListItem>OR</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="CapText">Doors :
                                </td>
                                <td class="CapDataTD">
                                    <asp:DropDownList ID="ddlDoors" runat="server">
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>--%>
                            <tr>
                                <td class="CapText">
                                    Cap Clean (£):
                                </td>
                                <td class="CapDataTD">
                                    From:
                                    <asp:TextBox ID="txtCAPValueFrom" runat="server"></asp:TextBox>
                                    To:
                                    <asp:TextBox ID="txtCAPValueTo" runat="server"></asp:TextBox>
                                    <br />
                                    <br />
                                    Want to Pay:
                                    <asp:DropDownList ID="ddlWantToPay" runat="server" Width="100px">
                                        <asp:ListItem>Over</asp:ListItem>
                                        <asp:ListItem>Under</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;
                                    <asp:DropDownList ID="ddlIsInPercentage" runat="server" Width="100px">
                                        <asp:ListItem Value="false">£</asp:ListItem>
                                        <asp:ListItem Value="true">%</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;
                                    <asp:TextBox ID="txtPayout" runat="server" CssClass="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="CapText">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="button1">
                                    </asp:Button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td class="table_td_left">
                                <asp:Label ID="lblsearch2" runat="server" CssClass="label_blackbold10" Text="CAP Rules List"></asp:Label>
                            </td>
                            <td class="table_td_right">
                                <asp:Label ID="lable123" runat="server" CssClass="label" Text="Content Per Page:"></asp:Label>
                                <asp:DropDownList ID="ddlPerpage" runat="server" CssClass="" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlPerpage_SelectedIndexChanged">
                                    <asp:ListItem>Default</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="table_td_left">
                    <cc1:CustomePagingGrid ID="gvRulesList" runat="server" Width="100%" CssClass="gridview"
                        AllowPaging="True" AutoGenerateColumns="False" PageSize="10" OnRowCreated="gvRulesList_RowCreated"
                        DataKeyNames="RuleId" AllowSorting="True" OnSorting="gvRulesList_Sorting" EnableViewState="true"
                        OnRowCommand="gvRulesList_RowCommand" OnPageIndexChanging="gvRulesList_PageIndexChanging">
                        <PagerSettings PreviousPageText="Prev" LastPageText="Last" FirstPageText="First"
                            NextPageText="Next" Mode="NextPreviousFirstLast" Position="TopAndBottom"></PagerSettings>
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkBxHeader" onclick="javascript:HeaderClick(this);" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbRows" runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="6%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="RuleName" HeaderText="Rule Name" SortExpression="RuleName">
                                <ItemStyle Width="20%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="CAPCleanFrom" HeaderText="CAP Clean From" SortExpression="CAPCleanFrom">
                                <ItemStyle Width="20%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="CAPCleanTo" HeaderText="CAP Clean To" SortExpression="CAPCleanTo">
                                <ItemStyle Width="20%"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lblheaderRuleDescription" runat="server" Text="Rule Description"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblRuleDescription" runat="server" Text='<%# setRuleDescription(
                                                                                                Eval("WantToPay"),
                                                                                                Eval("IsInPercentage"),Eval("Payout")
                                                                                                ) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Image ID="imgStatus" runat="server" ImageUrl='<%# setImage4Status(Eval("IsActive")) %>' />
                                </ItemTemplate>
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                        Text="Update"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemStyle Width="7%"></ItemStyle>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="ViewDetails"
                                        CommandArgument='<%# Bind("RuleId") %>' Text="Edit"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AdminId" Visible="false">
                                <HeaderTemplate>
                                    <asp:Label ID="lblId" runat="server" Text="Status"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGetId" runat="server" Text='<%# Bind("RuleId") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            No Data Found
                        </EmptyDataTemplate>
                        <PagerStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                    </cc1:CustomePagingGrid>
                </td>
            </tr>
            <tr style="display: none">
                <td class="table_td_left">
                    <asp:LinkButton ID="btnCheckAll" runat="server" CssClass="Link_Label_Bold" OnClientClick="return fnCheckAll();">Check All</asp:LinkButton>
                    <asp:Label ID="lbl12" runat="server" Text="|"></asp:Label>
                    <asp:LinkButton ID="btnClearAll" runat="server" CssClass="Link_Label_Bold" OnClientClick="return fnClearAll();">Clear All</asp:LinkButton>
                </td>
                <td class="table_td_left">
                </td>
            </tr>
            <tr>
                <td class="table_td_left">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button1" OnClientClick="return CheckForCheckBox();"
                        OnClick="btnDelete_Click" />
                    <asp:Button ID="btnActive" runat="server" Text="Active" CssClass="button1" OnClientClick="return CheckForCheckBox();"
                        OnClick="btnActive_Click" />
                    <asp:Button ID="btnInActive" runat="server" Text="Inactive" CssClass="button1" OnClientClick="return CheckForCheckBox();"
                        OnClick="btnInActive_Click" />
                </td>
            </tr>
        </table>
    </div>
    <script language="javascript" type="text/javascript">

        var TotalChkBx;
        var Counter;
        window.onload = function () {
            //Get total no. of CheckBoxes in side the GridView.
            TotalChkBx = parseInt('<%= this.gvRulesList.Rows.Count %>');
            //Get total no. of checked CheckBoxes in side the GridView.
            Counter = 0;
        }


        function HeaderClick(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl = document.getElementById('<%= this.gvRulesList.ClientID %>');
            var TargetChildControl = "cbRows";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;

            //Reset Counter
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }

        function ChildClick(CheckBox, HCheckBox) {
            //get target base & child control.
            var HeaderCheckBox = document.getElementById(HCheckBox);

            //Modifiy Counter;            
            if (CheckBox.checked && Counter < TotalChkBx)
                Counter++;
            else if (Counter > 0)
                Counter--;

            //Change state of the header CheckBox.
            if (Counter < TotalChkBx)
                HeaderCheckBox.checked = false;
            else if (Counter == TotalChkBx)
                HeaderCheckBox.checked = true;
        }
        function CheckForCheckBox() {
            var TargetBaseControl = document.getElementById('<%= this.gvRulesList.ClientID %>');
            var TargetChildControl = "cbRows";
            var count = 0;


            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.               
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].checked == true)
                    count += 1;
            }
            if (count == 0) {
                alert("Select Atleast One Record");
                return false;
            }
            //Reset Counter
            return true;
        }
        function fnCheckAll() {
            //Get target base & child control.
            var TargetBaseControl = document.getElementById('<%= this.gvRulesList.ClientID %>');
            var TargetChildControl = "cbRows";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.               
            for (var n = 0; n < Inputs.length; ++n) {
                Inputs[n].checked = true;
            }
            //Reset Counter
            return false;
        }
        function fnClearAll() {
            //Get target base & child control.
            var TargetBaseControl = document.getElementById('<%= this.gvRulesList.ClientID %>');
            var TargetChildControl = "cbRows";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.

            for (var n = 0; n < Inputs.length; ++n) {
                Inputs[n].checked = false;
            }
            //Reset Counter
            return false;
        }
        function CheckParent() {
            if (document.getElementById('<%= this.txtRuleName.ClientID %>').value == '') {
                document.getElementById('<%= this.txtRuleName.ClientID %>').style.backgroundColor = 'lemonchiffon';
                alert('Enter Rule Name');
                return false;
            }
        }
    </script>
    <asp:Label ID="lblMode" runat="server" Text="" Visible="false"></asp:Label>
</asp:Content>
