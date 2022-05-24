<%@ Page Language="VB" Async="true" AutoEventWireup="false" CodeFile="RequestDetails2.aspx.vb" Inherits="RequestDetails2" EnableTheming="true" %>


<!DOCTYPE html>

<html>
<head runat="server">
    <title>Add New open Position</title>
    <base target="_self" />
    <meta http-equiv="Pragma" content="No-cache" />

    <link href="../Styles/DetailsPage.css" rel="stylesheet" type="text/css" />
    <link href="../JQuery-UI/jquery-ui.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/TablesFrame4.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/BubbleHelp.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/autoCompleteDDL.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/angular.min.js"></script>
    <style type="text/css">
        body, table {
            width: 100%;
            margin: 0;
        }

        #btnSave1 {
            display: none;
        }

        .Required-Field-Control {
            border: 2px dotted red;
        }
    </style>

    <%--    <link href="../Styles/AngualJS.css" rel="stylesheet" />--%>
    <script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="../JQuery-UI/jquery-ui-1.11.4.min.js" type="text/javascript"></script>
    <script src="../Scripts/CommonDOM.js" type="text/javascript"></script>
    <%-- <script src="../Scripts/autoCompleteDDL.js" type="text/javascript"></script>--%>

    <script type="text/javascript">
        function CallShowMessage(action, message) {
            window.alert(action + " " + message);
        }
        function CallBackReloadParent(action, message) {
            try {
                window.alert(action + " " + message);
                $("#hdChildFormAction", parent.document).val(action);

                //$("#ApplicantDetailDIV", parent.document).fadeToggle("slow");
                //window.parent.frames["ApplicantList"].document.location.reload();
                $("#PopUpDIV", parent.document).fadeToggle("fast");
                $("#PositionDetailDIV", parent.document).fadeToggle("slow");
                window.parent.frames["mainTop"].document.location.reload();
                // top.opener.location.reload(true);
            }
            catch (e) {
            }



        }
    </script>

</head>
<body>
    <form id="form1" runat="server" ng-app="" name="myForm">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <%--  <asp:ServiceReference Path="~/WebServices/GetDeadLineDate.svc" />--%>
                <asp:ServiceReference Path="~/WebServices/WebService.asmx" />
            </Services>
        </asp:ScriptManager>
        <div>

            <table>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>Position Type:</td>
                    <td>
                        <asp:DropDownList ID="ddlType" runat="server" Width="100%" CssClass="editArea" Enabled="false" AutoPostBack="true"></asp:DropDownList>
                    </td>

                    <td colspan="6">Status: 
                        <asp:TextBox ID="TextStatus" runat="server" BackColor="Transparent" CssClass="editcellLock" Width="80px"></asp:TextBox>
                        To HR Staff 
                        <asp:DropDownList ID="ddlHRStaff" runat="server" CssClass="editArea Edit-Content-Control" Width="100px"></asp:DropDownList>
                        <asp:Label ID="lblRequestID" runat="server"> Request ID:  </asp:Label>
                        <asp:TextBox ID="TextRequestID" runat="server" CssClass="editcellLock" Width="50px" ReadOnly="true"></asp:TextBox>
                        <asp:TextBox ID="lblRequestSource" runat="server" ReadOnly="true" Width="50px" CssClass="editcellLock"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>School:</td>

                    <td colspan="7">
                        <asp:DropDownList ID="ddlschoolcode" runat="server" Width="80px" Height="20px" CssClass="editcellLock" Enabled="false"></asp:DropDownList>

                        <asp:DropDownList ID="ddlSchool" TabIndex="11" runat="server" Width="80%" Height="20px" CssClass="editcellLock" Enabled="false"></asp:DropDownList><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_lblTeacherName" runat="server" ControlToValidate="lblTeacherName" ErrorMessage="*" Font-Size="small" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_hfAutoCompletSelectedID" runat="server" ControlToValidate="hfAutoCompletSelectedID" ErrorMessage="* Must have the Teacher being replaced that select from the school or TCDSB teacher list" Font-Size="small" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="lblTeacherName">
                            Teacher being
                            <br />
                            Replaced:
                        </label>

                    </td>
                    <td>


                        <%--<asp:Label ID="lblTeacherName" runat="server" Text=""> </asp:Label>--%>
                        <input id="lblTeacherName" runat="server" value="" autocomplete="off" style="height: 17px; width: 120px" class="inputFiled editArea Edit-Content-Control" required />

                        <%-- <div id="comboboxDIV" runat="server">
                            <asp:DropDownList ID="ddlTeacherReplaced" TabIndex="13" runat="server" Width="120px" CssClass="editArea" Visible="false"></asp:DropDownList>
                            <select id="combobox" runat="server" title="type teacher name" style="width: 120px; background-color: lightgoldenrodyellow" class="editArea"
                                ng-model="myText">
                                <option value="">Select Teacher...</option>
                            </select>
                        </div>--%>

                    </td>
                    <td style="text-align: right">

                        <input runat="server" id="hfAutoCompletSelectedID" style="width: 100px; background-color: whitesmoke" type="text" readonly="readonly" class="editcellLock" placeholder="teacher ID" title="  " />

                    </td>
                    <td style="text-align: right;">
                        <label for="ddlReason">Reason for Leave: </label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_ddlReason" runat="server" ControlToValidate="ddlReason" ErrorMessage="*" Font-Size="small" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                    <td colspan="4">
                        <asp:DropDownList ID="ddlReason" TabIndex="13" runat="server" Width="200px" Height="20px" CssClass="editCell Edit-Content-Control" required></asp:DropDownList>
                        <asp:RadioButtonList ID="rblReason" runat="server" RepeatDirection="Horizontal" Visible="false">
                            <asp:ListItem>Personal</asp:ListItem>
                            <asp:ListItem>Medical</asp:ListItem>
                            <asp:ListItem Value="Maternity">Maternity/Parental</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:RadioButtonList>

                    </td>
                </tr>
                <tr>
                    <td>Assignment:</td>

                    <td colspan="4">
                        <label for="dateStart">Start Date:  </label>

                        <input runat="server" type="text" id="dateStart" size="9" name="dateStart" placeholder="start date" class="inputFiled editArea Edit-Content-Control" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_dateStart" runat="server" ControlToValidate="dateStart" ErrorMessage="*" Font-Size="Large" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                        <label for="dateEnd">End Date::  </label>

                        <input runat="server" type="text" id="dateEnd" size="9" name="dateEnd" placeholder="end date" class="inputFiled editArea Edit-Content-Control" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_dateEnd" runat="server" ControlToValidate="dateEnd" ErrorMessage="*" Font-Size="Large" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                    <td colspan="3" style="text-align: right">
                        <input runat="server" id="TextOtherReason" type="text" name="OtherReason" class="inputFiled Edit-Content-Control" readonly="readonly" placeholder="Reason for Other Leave" style="width: 99%" visible="false" />

                    </td>

                </tr>

                <tr class="editArea">
                    <td>
                        <label for="TextPositionTitle">Position Title:</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextPositionTitle" ErrorMessage="*" Font-Size="small" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                    <td colspan="7">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_TextPositionTitle" runat="server" ControlToValidate="TextPositionTitle" ErrorMessage="* Must provide a Position Title" Font-Size="small" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>

                        <input runat="server" id="TextPositionTitle" type="text" name="title" class="inputFiled editArea Edit-Content-Control" placeholder="Posting Position Title" style="width: 99%" required />


                    </td>
                </tr>
                <tr class="editArea">
                    <td colspan="8" style="color: #cc0033; font-size: 1rem">
                        <b>Please Select Grade, Subject Area and Specific Qualfication you are looking for   </b>

                </tr>
                <tr class="editArea">
                    <td colspan="8">
                        <table>
                            <tr>
                                <td>
                                    <label for="ddlPositionlevel">Division Required:</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_ddlPositionlevel" runat="server" ControlToValidate="ddlPositionlevel" ErrorMessage="*" Font-Size="small" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td style="width: 230px">
                                    <asp:DropDownList ID="ddlPositionlevel" runat="server" CssClass="editcell Edit-Content-Control" required>
                                        <asp:ListItem Value="BC013E">Intermediate</asp:ListItem>
                                        <asp:ListItem Value="BC014E">Senior</asp:ListItem>
                                        <asp:ListItem Value="BC003E">Intermediate and Senior</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td>
                                    <asp:DropDownList ID="ddlFTEPanel" runat="server" CssClass="editcell Edit-Content-Control">
                                        <asp:ListItem Selected="true">Full</asp:ListItem>
                                        <asp:ListItem>PartTime</asp:ListItem>
                                        <asp:ListItem>AM</asp:ListItem>
                                        <asp:ListItem>PM</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td>
                                    <label for="rblFTE">BTC(%)   </label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_rblFTE" runat="server" ControlToValidate="rblFTE" ErrorMessage="*" Font-Size="small" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td style="width: 300px">
                                    <asp:RadioButtonList ID="rblFTE" runat="server" RepeatDirection="Horizontal" Width="100%" CssClass="editcell Edit-Content-Control" required>
                                        <asp:ListItem Value="100">100%</asp:ListItem>
                                        <asp:ListItem Value="67">67%</asp:ListItem>
                                        <asp:ListItem Value="50">50%</asp:ListItem>
                                        <asp:ListItem Value="33">33%</asp:ListItem>
                                        <asp:ListItem Value="25">25%</asp:ListItem>
                                        <asp:ListItem Value="00">XX%</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td id="FTECell" runat="server">
                                    <asp:TextBox ID="TextFTE" runat="server" Width="30px" CssClass="editcell Edit-Content-Control"></asp:TextBox>%

                                </td>
                            </tr>
                        </table>
                    </td>

                </tr>
                <tr>
                    <td>
                        <label for="cblQualification">Qualification Summary </label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_lblQualification" runat="server" ControlToValidate="lblQualification" ErrorMessage="*" Font-Size="small" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                    <td colspan="7">
                        <b>
                            <input id="lblQualification" runat="server" name="lblQualification" type="text" readonly="readonly" style="width: 99%; border: 0;" class="editcellLock" />
                        </b>
                    </td>
                </tr>

                <tr class="editArea">

                    <td colspan="8">

                        <div style="overflow: auto; width: 99%; height: 200px">
                            <asp:CheckBoxList ID="cblQualification" runat="server" RepeatColumns="4" RepeatDirection="Vertical">
                                <asp:ListItem>item1</asp:ListItem>
                                <asp:ListItem>item2</asp:ListItem>
                                <asp:ListItem>item3</asp:ListItem>
                                <asp:ListItem>item4</asp:ListItem>
                                <asp:ListItem>item5</asp:ListItem>
                                <asp:ListItem>item6</asp:ListItem>
                                <asp:ListItem>item7</asp:ListItem>
                                <asp:ListItem>item8</asp:ListItem>

                            </asp:CheckBoxList>

                        </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="7">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true" DisplayMode="SingleParagraph" ForeColor="red" Font-Size="Small" HeaderText="Must Entry Fields" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="TextDescription">
                            Description of<br />
                            Assignment
                        </label>
                    </td>
                    <td colspan="7">
                        <asp:TextBox ID="TextDescription" TabIndex="14" runat="server" Height="40px" TextMode="MultiLine" Width="99%" CssClass="editArea Edit-Content-Control"></asp:TextBox>
                        <div id="F100TimeTable" runat="Server"></div>
                        <div id="F100MultipleSchool" runat="Server"></div>
                    </td>
                </tr>


                <tr>
                    <td>
                        <label for="TextComments">
                            Comments on 
                            <br />
                            Request;</label>

                    </td>
                    <td colspan="7">
                        <asp:TextBox ID="TextComments" TabIndex="15" runat="server" Height="30px" TextMode="MultiLine" Width="99%" CssClass="editArea Edit-Content-Control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Princiapl Name:</td>
                    <td colspan="7">(Contact)<asp:Label ID="lblPrinciaplName" runat="server" Text="Label"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp; 
                    Superintendent Name 

                   
                        <asp:Label ID="lblSuperintendent" runat="server" Text="Label"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp; 
                   Request Date:
                 
                        <input runat="server" type="text" id="dateRequest" size="10" class="editcellLock" />
                        &nbsp;&nbsp;&nbsp;&nbsp; 
                     Posted Date:
                 
                        <input runat="server" type="text" id="datePosted" size="10" class="editcellLock" />




                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="7" style="text-align: center;">

                        <asp:Button ID="btnSave" runat="server" TabIndex="111" Text="Save to Request Posting" />

                        <asp:Button ID="btnRequest" runat="server" TabIndex="112" Text="Request Posting" Width="175px" Visible="false" Enabled="false" />


                        <asp:Button ID="btndelete" runat="server" TabIndex="1113" Text="Delete Request" Width="150px" />

                        <asp:Button ID="btnEmail" runat="server" TabIndex="115" Text="Send Email" Width="100px" Visible="false" />
                        <asp:Button ID="btnSave1" runat="server" TabIndex="116" Text="" Height="0px" Width="0px" />

                    </td>

                </tr>
            </table>

        </div>
        <asp:HiddenField ID="hfIDs" runat="server" Value="0" />
        <asp:HiddenField ID="hfUserID" runat="server" Value="" />
        <asp:HiddenField ID="hfPrincipalID" runat="server" Value="" />
        <asp:HiddenField ID="hfSchoolyear" runat="server" Value="" />
        <asp:HiddenField ID="hfQualificationsCode" runat="server" Value="" />
        <asp:HiddenField ID="hfQualifications" runat="server" Value="" />
        <asp:HiddenField ID="hfSchoolyearStartDate" runat="server" Value="2016-08-20" />
        <asp:HiddenField ID="hfSchoolyearEndDate" runat="server" Value="2017-06-30" />

        <asp:HiddenField ID="hfAutoCompletSelectedName" runat="server" Value="" />
        <asp:HiddenField ID="hfFormChange" runat="server" Value="No" />





    </form>
    <%--  <script src="../Scripts/angular.min.js"></script>
    <script src="../Scripts/app.js"></script>--%>

    <div id="BubbleHelpDIV" class="bubble hide" style="overflow: hidden; border: none; text-align: left; vertical-align: top; padding: 0px">
        <table>
            <tr style="height: 100%">
                <td style="width: 100%; height: 100%; vertical-align: top; text-align: left">
                    <iframe id="iframeHelpText" name="iframeHelpText" frameborder="0" src=""
                        scrolling="no" runat="server" style="font-size: small; font-family: Arial; table-layout: auto; width: 100%; height: 300px;"
                        allowtransparency="true" atomicselection="true"></iframe>
                </td>
            </tr>
        </table>
    </div>
</body>

</html>



<script type="text/javascript">
    var requestStatus = $("#TextStatus").val();
    var requestSource = $("#lblRequestSource").val();
    var OperatePage =
    {
        OpenPage: function () { OpenPageForEntry(); },
        LockPage: function () { LockPageWhenPostingRequested(); },
        UpdateQual: function (QualCode, checkValue) { UpdateQualificationSelected(QualCode, checkValue); },
        RequestBtn: function () { CheckRequestButton(); }
    };
    function OpenPageForEntry() {
        DOMaction.Button($("#btnRequest"), false);
        DOMaction.Button($("#btnSave"), false);
    }
    function LockPageWhenPostingRequested() {

        DOMaction.DatePicker($("#dateStart"), true);
        DOMaction.DatePicker($("#dateEnd"), true);
        DOMaction.InputText($("#TextOtherReason"), true);
        DOMaction.InputText($("#TextPositionTitle"), true);
        DOMaction.InputText($("#lblQualificaiton"), true);
        DOMaction.Button($("#btnSave"), true);
        DOMaction.Button($("#btndelete"), true);
        DOMaction.DropDownList($("#ddlType"), true);
        DOMaction.DropDownList($("#ddlPositionLevel"), true);
        DOMaction.DropDownList($("#ddlPanel"), true);
        DOMaction.DropDownList($("#ddlHRStaff"), true);
        DOMaction.DropDownList($("#ddlTeacherReplaced"), true);
        DOMaction.DropDownList($("#ddlReason"), true);
        DOMaction.InputText($("#hfAutoCompletSelectedID"), true);

        DOMaction.CheckBoxList($('#cblQualification'), true);
        //  DOMaction.RadioButtonList($('#rblReason'), true);
        DOMaction.RadioButtonList($('#rblFTE'), true);

        //   $("#TextPositionTitle").prop("readonly", true);
        //   $("#ddlTeacherReplaced").prop("disabled", true);
        //$('#cblQualification').find('input:checkbox').each(function () {
        //    this.disabled = true
        //});
        //$('#rblFTE').find('input:radio').each(function () {
        //    this.disabled = true
        //});

    }
    function UpdateQualificationSelected(qualCode, checkedValue) {
        var qual = {
            Operate: "Request",
            UserID: $("#hfUserID").val(),
            SchoolYear: $("#hfSchoolyear").val(),
            SchoolCode: $("#ddlschoolcode").val(),
            PositionID: $("#TextRequestID").val(),
            SourceID: "Request",
            QualificationID: qualCode,
            Selected: checkedValue
        }
        // ************ no need use web service call   **************************
        //WebService.SaveSelectedQualification("Request", requestID, schoolyear, schoolcode, QualCode, onSuccessQual, onFailureQual);
        //WebService.SaveSelectedQualification(qual, onSuccessQual, onFailureQual);

        var code = DOMaction.CheckBoxListValue($('#cblQualification'), "Code")
        var name = DOMaction.CheckBoxListValue($('#cblQualification'), "Name")
        $('#lblQualification').val(name)
        $('#hfQualificationsCode').val(code)
    }
    function CheckRequestButton() {
        if (EnableRequestButtonCondition()) {
            DOMaction.Button($("#btnSave"), false);
            DOMaction.Button($("#btndelete"), false);
        }
    }
    function EnableRequestButtonCondition() {
        if ($("#TextPositionTitle").val() == "") return false;
        if ($("#ddlHRStaff").val() == "") return false;
        if ($('#hfQualificationsCode').val() == "") return false;
        if (DOMaction.RadioButtonListValue($('#rblFTE'), 'Text') == "") return false;
        if (requestStatus == "Initial" || requestStatus === "Reject") return false;
        return true;
    }
    function pageLoad(sender, args) {

        $(document).ready(function () {
            InitialDatePickerControl();

            $('#FTECell').hide();
            if ($('#TextFTE').val() != '') {
                $('#FTECell').show();
            }

            //alert("source = " + requestSource  +  " State = " + requestStatus); 
            if (requestSource == "Principal") {
                if (requestStatus == "Initial" || requestStatus == "Reject" || requestStatus == "Pending") {
                    OperatePage.OpenPage();
                    OperatePage.RequestBtn();
                    // if ($("#TextPositionTitle").val() != "") DOMaction.Button($("#btnRequest"), false);
                }
                else { OperatePage.LockPage(); }
            }
            else { OperatePage.LockPage(); }

            if (requestStatus == "Posted") {
                alert("The Position has been posted. Changes won't save !!! ");
            }

            $("#lblTeacherName").click(function (ev) {
                var ev = window.event;
                var vTop = $('#lblTeacherName').offset().top - 10;  // ev.clientY - 20;
                var vLeft = $('#lblTeacherName').offset().left - 10;  //ev.clientX - 190; var vTop = $('#ddlQualification').offset().top - 20;  // ev.clientY - 20;

                ShowSelectTeacherList(vTop, vLeft, "Click");
            });

            $("#lblTeacherName").keyup(function (e) {
                var ev = window.event;
                var vTop = $('#lblTeacherName').offset().top - 10;  // ev.clientY - 20;
                var vLeft = $('#lblTeacherName').offset().left - 10;  //ev.clientX - 190; var vTop = $('#ddlQualification').offset().top - 20;  // ev.clientY - 20;

                ShowSelectTeacherList(vTop, vLeft, "Keyup");
            });

            $("#TextPositionTitle").keyup(function (e) {
                OperatePage.RequestBtn();
            });
            $("#TextPositionTitle").focus(function (e) {
                HideSelectTeacherList();
            });
            $("#ddlReason").focus(function (e) {
                HideSelectTeacherList();
            });


            $("#btnRequest").click(function (e) {
                $("#hdChildFormAction", parent.document).val("ChangeAction");
            });
            $("#btnSave").click(function (e) {
                checkRequiredFields();
                DOMaction.Button($("#btnRequest"), false);
                $("#hdChildFormAction", parent.document).val("ChangeAction");

            });
            $("#ButtonCancel").click(function (e) {
                $("#RepostingDIV").fadeToggle("slow");
                return false;
            });

            $("#btndelete").click(function (e) {

                $("#HiddenFieldAction").val("Yes");

                var applicant = $("#hfApplicant").val();
                $("#hdChildFormAction", parent.document).val("ChangeAction");

                var result = confirm("Are you sure, you want delete this Position ?");
                if (result) {
                    return true;
                }
                else {
                    return false;
                }
            });

            $("#rblReason input").click(function (e) {
                try {
                    var ev = window.event;
                    var targetItem = ev.srcElement.id;
                    var myItem = $("#" + targetItem);
                    var selectedCode = myItem.val();
                    if (selectedCode == "Other") {
                        DOMaction.InputText($("#TextOtherReason"), false);
                    }
                    else {
                        DOMaction.InputText($("#TextOtherReason"), true);
                    }
                }
                catch (e) { }
            })
            $("#rblFTE input").click(function (e) {
                try {
                    var ev = window.event;
                    var targetItem = ev.srcElement.id;
                    var myItem = $("#" + targetItem);
                    var selectedCode = myItem.val();
                    if (selectedCode == "00") {
                        $('#FTECell').show();
                    }
                    else {
                        $('#FTECell').hide();
                    }
                }
                catch (e) { }
            })
            $("#cblQualification input").click(function (e) {
                try {
                    var ev = window.event;
                    var targetItem = ev.srcElement.id;
                    var myItem = $("#" + targetItem);
                    var QualCode = myItem.val();
                    //Qualification = myItem.closest("td").find("label").html();
                    var checkedvalue = myItem[0].checked;
                    OperatePage.UpdateQual(QualCode, checkedvalue);
                    OperatePage.RequestBtn();
                }
                catch (ex) {
                    alert(ex);
                }
            })

            $("#btnUnpublish").click(function (e) {
                var result = confirm("Are you sure, you want to Cancel this posting ?");
                if (result) {
                    $("#hdChildFormAction", parent.document).val("ChangeAction");
                    $("#HiddenFieldAction", parent.document).val("Yes");
                    return true;
                }
                else
                    return false;
            });

            $('#ddlTeacherReplaced').change(function () {
                try {

                    var personID = $('#ddlTeacherReplaced').val();
                    $("#TextTeacherReplacedID").val(personID);
                }
                catch (e) {
                    window.alert(e.message);
                }
            });
            $("#hfAutoCompletSelectedID").change(function () {
                var cpnum = $("#hfAutoCompletSelectedID").val();
                var checkCpnum = {
                    "Operate": "Request",
                    "UserID": $("#hfUserID").val(),
                    "SchoolYear": $("#hfSchoolyear").val(),
                    "SchoolCode": $("#ddlschoolcode").val(),
                    "PositionID": $("#TextRequestID").val(),
                    "CPNum": cpnum
                }

                $("#TextTeacherReplacedID").val(cpnum);
                WebService.GetTeacherNamebyCPnum(checkCpnum, onSuccessTeacherName, onFailure);
            });
        })
    }

    $(window).unload(function () {
        //   var myaction = document.getElementById("HiddenFieldAction").value;
        window.returnValue = $("#HiddenFieldAction").val();
    });
    function checkRequiredFields() {
        DOMaction.Validation("RequiredFieldValidator_TextPositionTitle", "TextPositionTitle");
        DOMaction.Validation("RequiredFieldValidator_lblTeacherName", "lblTeacherName");
        DOMaction.Validation("RequiredFieldValidator_ddlReason", "ddlReason");
        DOMaction.Validation("RequiredFieldValidator_rblFTE", "rblFTE");
        DOMaction.Validation("RequiredFieldValidator_ddlPositionlevel", "ddlPositionlevel");
        DOMaction.Validation("RequiredFieldValidator_lblQualification", "cblQualification");
    }
  
    function onSuccess(result) {

        $("#dateDeadline").val(result);
        //  window.alert(result);
    }
    function onSuccessTeacherName(result) {
        alert(result);
        var cpnum = $("#hfAutoCompletSelectedID").val();
        //$("#combobox").val(cpnum);
        //$('#combobox').val(cpnum).attr("selected", "selected");
        $("#hfAutoCompletSelectedName").val(result);

        // $('#combobox').append('<option value="' + cpnum + '" selected="selected">' + result + '</option>');
        $("#lblTeacherName").text(result);
        $("#nameDIV").show();
        $("#comboboxDIV").hide();
        // $("#combobox").append(
        //     $('<option></option>').val(cpnum).html(result)); //.selected("selected"));
        // $('#combobox').val(cpnum).attr("selected", "selected");
        // $("#combobox").val(cpnum);
        //  $('#combobox').append(new Option(result, cpnum, true, true));
    }
    function onFailure(result) {
        var rDate = $("#datePublish").val();
        $("#dateDeadline").val(rDate);
        //  window.alert(Message + result.get_message());

    }


    function GetDeadLineDateFromWebService(_datepublish) {

        var _deadlinedate = "";
        var mypublishDate = { 'datepublish': _datepublish };
        var toPassParameter = JSON.stringify(mypublishDate);
        $.ajax({
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "WebServiceDeadline.asmx/GetDeadLineDate",
            data: toPassParameter,
            success: function (data) {
                _deadlinedate = data.d;

            }
        });
        return _deadlinedate;
    }

    function GetDeadLineDateFromWebAPI(publishdate, schoolyear) {

        var servername = "http://webservice.tcdsb.org";
        var api = "/LTOapi/api/PositionApplyDeadLineDate";
        var parameter = "?userid=mif&schoolyear=" + schoolyear + "&publishdate=" + publishdate;
        var httpLink = servername + api + parameter;
        jQuery.support.cors = true;
        $.ajax({
            url: httpLink,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                var deadlinedate = data[0].ApplyDate;
                $("#dateDeadline").val(deadlinedate);
            },
            error: function (ex) {
                //   alert(ex.error);
            }
        });
    }

    function onSuccessQual(result) {
        // window.alert(result);
        // if (result) {
        //    var cQual = $("#TextQualification").val();
        //    if (cQual.indexOf(Qualification) == -1) {
        //        cQual += Qualification + ";";
        //    }
        //    else
        //        cQual = cQual.replace(Qualification + ";", '');

        //    $("#TextQualification").val(cQual); // $("#TextQualification",opener.document)

        // }
    }
    function onFailureQual(result) {

        window.alert(result);

    }
    function InitialDatePickerControl() {
        var value = new Date().toDateString;
        var minD = new Date($("#hfSchoolyearStartDate").val());
        var maxD = new Date($("#hfSchoolyearEndDate").val());

        JDatePicker.Initial($("#dateStart"), minD, maxD, value);
        JDatePicker.Initial($("#dateEnd"), minD, maxD);
    }
    function CallParentPostBack(action, positionTitle, strMessage) {

        try {
            parent.document.Script.CloseMe(action);
        }
        catch (e) {
            try {
                window.opener.CloseMe(action);
            }
            catch (e) {
                try {
                    parent.CloseMe(action);
                }
                catch (e) {
                    window.alert("Your Browser does not support Auto Refreash Parent Screen, Please refresh manual !")
                }

            }

        }
    }

    function ShowSelectTeacherList(vTop, vLeft, action) {
        var searchValue = $("#lblTeacherName").val();
        var goPage = "RequestTeachers.aspx?SearchVal=" + searchValue;
        var vHeight = 300;
        var vWidth = 350;

        $("#iframeHelpText").attr('src', goPage);

        $("#BubbleHelpDIV").css({
            top: vTop + 32,
            left: vLeft + 8,
            height: vHeight,
            width: vWidth,
            board: 0
        })
        if (action == "Click") { $("#BubbleHelpDIV").fadeToggle("fast"); }
    }
    function HideSelectTeacherList() {
        $("#BubbleHelpDIV").hide();
    }

</script>

<%--<script>
    function pageLoad(sender, args) {
        AutoCompleteComboBox();
        $(".custom-combobox-input").focus();
        // $("#combobox").focus();
    }

</script>--%>
