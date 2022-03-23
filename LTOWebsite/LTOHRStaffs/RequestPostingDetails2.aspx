<%@ Page Language="VB" Async="true" AutoEventWireup="false" CodeFile="RequestPostingDetails2.aspx.vb" Inherits="RequestPostingDetails2" EnableTheming="true" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New open Position</title>
    <base target="_self" />
    <meta http-equiv="Pragma" content="No-cache" />
    <style type="text/css">
        body {
            width: 98%;
        }

        .positionDescription {
            border: 1px solid #0094ff;
        }

        .hideMe {
            display: none;
        }
    </style>
    <link href="../Styles/DetailsPage.css" rel="stylesheet" type="text/css" />
    <link href="../JQuery-UI/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="../JQuery-UI/jquery-ui-1.11.4.min.js" type="text/javascript"></script>
    <script src="../Scripts/CommonDOM.js" type="text/javascript"></script>
    <%--    <script src="../Scripts/bootstrap.js" type="text/javascript"></script>
    <script src="../Scripts/bootbox.js" type="text/javascript"></script>--%>



    <script type="text/javascript">
        function CallShowMessage(action, message) {
            window.alert(action + " " + message);
            // bootbox.alert(action + " " + message);
        }
        function CallBackReloadParent(action, message) {
            try {
                window.alert(action + " " + message);
                // bootbox.alert(action + " " + message);
                $("#hdChildFormAction", parent.document).val(action);

                if (action === "Posting Request" && message === "Successfully") {
                    //$("#ApplicantDetailDIV", parent.document).fadeToggle("slow");
                    //window.parent.frames["ApplicantList"].document.location.reload();
                    $("#PopUpDIV", parent.document).fadeToggle("fast");
                    $("#PositionDetailDIV", parent.document).fadeToggle("slow");
                    window.parent.frames["mainTop"].document.location.reload();
                    // top.opener.location.reload(true);
                }
            }
            catch (e) {
            }



        }
    </script>

</head>
<body style="width: 99%">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <%--<asp:ServiceReference Path="~/WebServices/GetDeadLineDate.svc" />--%>
                <asp:ServiceReference Path="~/WebServices/WebService.asmx" />
            </Services>
        </asp:ScriptManager>




        <table style="width: 100%;">
            <tr>
                <td style="width: 15%"></td>
                <td style="width: 15%"></td>
                <td style="width: 15%"></td>
                <td style="width: 15%"></td>
                <td style="width: 10%"></td>
                <td style="width: 10%"></td>
                <td style="width: 10%"></td>
                <td style="width: 10%"></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPostingNumber" runat="server" Text=" Request ID:"> </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextRequestID" runat="server" CssClass="editcellLock" Width="100px" ReadOnly="true"></asp:TextBox>
                </td>
                <td>Status:</td>
                <td>
                    <asp:TextBox ID="TextStatus" runat="server" BackColor="Transparent" Width="80px" CssClass="editcellLock"></asp:TextBox>
                </td>
                <td>Request From: </td>
                <td>

                    <asp:TextBox ID="TextRequestSource" runat="server" BackColor="Transparent" Width="80px" CssClass="editcellLock"></asp:TextBox>
                </td>
                <td>Request Date: </td>
                <td>
                    <input runat="server" type="text" id="dateRequest" size="10" class="editcellLock" />
                    <asp:TextBox ID="TextArea" runat="server" BackColor="Transparent" Width="100px" Visible="false"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>School:</td>
                <td colspan="7">
                    <asp:DropDownList ID="ddlschoolcode" runat="server" Width="60px" Height="20px" CssClass="editcellLock" Enabled="false"></asp:DropDownList>
                    <asp:DropDownList ID="ddlSchool" TabIndex="11" Width="90%" runat="server" Height="20px" CssClass="editcellLock"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Position Type:    
                </td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlType" runat="server" Width="99%" CssClass="editcellLock"></asp:DropDownList></td>
                <td class="noWrap">To HR Staff</td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlHRStaff" runat="server" Width="99%" CssClass="editcell Edit-Content-Control"></asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td>Teacher being Replaced:
               
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlTeacherReplaced" TabIndex="13" runat="server" CssClass="editcellLock" Width="90%"></asp:DropDownList>

                </td>
                <td colspan="2" style="text-align: right">Reason for Replacement</td>
                <td colspan="3">
                    <asp:TextBox ID="TextOtherReason" TabIndex="14" runat="server" Width="90%" CssClass="editcellLock"></asp:TextBox>
                    <asp:TextBox ID="TextTeacherPersonID" TabIndex="14" runat="server" Width="1px" CssClass="editcellLock"></asp:TextBox>

                </td>
            </tr>

            <tr>
                <td>Position Title:
                </td>
                <td colspan="7">
                    <asp:TextBox ID="TextPositionTitle" TabIndex="12" runat="server" Height="20px" Width="99%" CssClass="editcellLock"></asp:TextBox></td>
            </tr>
            <tr class="editArea">
                <td colspan="8">
                    <b>Selected Grade, Subject Area and Specific Qualfication Principal is looking for </b>
            </tr>
            <tr class="editArea">
                <td colspan="8">
                    <table>
                        <tr>
                            <td>Division Required   </td>
                            <td style="width: 230px">
                                <asp:DropDownList ID="ddlPositionlevel" runat="server" CssClass="editcell Edit-Content-Control">
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
                            <td>BTC(%)   </td>
                            <td style="width: 300px">
                                <asp:RadioButtonList ID="rblFTE" runat="server" RepeatDirection="Horizontal" Width="100%" CssClass="editcell Edit-Content-Control">
                                    <asp:ListItem Value="100" Selected="true">100%</asp:ListItem>
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

            <%--  <tr class="editArea">
                <td colspan="8">
                    <hr />
                </td>
            </tr>--%>
            <tr>
                <td>Qualification Summary

                </td>
                <td colspan="7">
                    <b>
                        <input id="lblQualification" runat="server" name="lblQualification" type="text" readonly="readonly" style="width: 98%" class="editcellLock" />
                    </b>
                    <asp:HiddenField ID="hfQualificationCode" runat="server" Value="" />

                </td>
            </tr>
            <tr class="editArea">

                <td colspan="8">

                    <div id="cblQualficationDIV" runat="server" style="overflow: auto; width: 100%; height: 50px">
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




            <tr class="positionDescription">
                <td>Description of<br />
                    Assignment</td>
                <td colspan="7">
                    <asp:TextBox ID="TextDescription" TabIndex="14" runat="server" Height="30px" TextMode="MultiLine" Width="99%" CssClass="editcell Edit-Content-Control"></asp:TextBox>
                    <div id="F100TimeTable" runat="Server"></div>
                    <div id="F100MultipleSchool" runat="Server"></div>
                </td>
            </tr>

            <tr>
                <td>Princiapl Name:
               
                </td>
                <td colspan="7">
                    <asp:Label ID="lblPrinciaplName" runat="server" Text="Label" Width="30%"></asp:Label>

                    Superintendent&#39;s Name 
                    <asp:Label ID="lblSuperintendent" runat="server" Text="Label" Width="30%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Workplace Accommodation:
               
                </td>
                <td colspan="6">
                    <asp:Label ID="LabelWA" runat="server" Text="Label" Width="99%" Height="30px" CssClass="editcellLock"></asp:Label>
                </td>
                <td>Workplace FTE: 
                   
                    <asp:Label ID="LabelWAFTE" runat="server" Text="Label" CssClass="editcellLock"></asp:Label>
                </td>
            </tr>

            <tr style="background-color: papayawhip;">
                <td>Posting Information:
                </td>
                <td colspan="7">

                    <table>

                        <tr>

                            <td>Assignment Start Date:</td>

                            <td style="text-wrap: none; overflow-wrap: normal">
                                <input runat="server" type="text" id="dateStart" size="9" class="Edit-Content-Control" />
                            </td>
                            <td style="width: 15px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dateStart" ErrorMessage="*" Font-Size="Large" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                            <td style="text-align: right;">Publish Date:</td>
                            <td style="text-wrap: none; overflow-wrap: normal">
                                <input runat="server" type="text" id="datePublish" size="9" class="Edit-Content-Control" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="datePublish" ErrorMessage="*" Font-Size="Large" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>

                            </td>
                        </tr>

                        <tr>

                            <td class="midtitle">Assignment &nbsp;End Date:</td>
                            <td>
                                <input runat="server" type="text" id="dateEnd" size="9" class="Edit-Content-Control" />

                            </td>
                            <td style="width: 15px"></td>

                            <td class="midtitle">
                                <div>Date to Apply:</div>
                                <td>
                                    <input runat="server" type="text" id="dateApplyStart" size="9" class="Edit-Content-Control" />
                                </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td class="midtitle">Deadline to Apply: </td>
                            <td>
                                <input runat="server" type="text" id="dateDeadline" size="9" class="Edit-Content-Control" /></td>
                        </tr>

                    </table>

                </td>
            </tr>
            <tr style="background-color: papayawhip;">
                <td>Posting Comments</td>
                <td colspan="7">
                    <asp:TextBox ID="txtPostingComments" runat="server" CssClass="editcellAllow Edit-Content-Control" Height="30px" Width="98%" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>

                <td colspan="6" style="text-align: center;">

                    <asp:Button ID="btnSave" runat="server" TabIndex="111" Text="Save" Width="80px" />
                    <asp:Button ID="btnRequest" runat="server" TabIndex="112" Text="Posting" Width="150px" CssClass="disabaledBTCn action-button " />
                    <asp:Button ID="btndelete" runat="server" TabIndex="1113" Text="Delete Request" Width="100px" Visible="false" />
                    <asp:Button ID="btnEmail" runat="server" TabIndex="115" Text="Send Email" Width="100px" Visible="false" />
                    <asp:Button ID="btnSave1" runat="server" TabIndex="116" Text="" Height="0px" Width="0px" BorderStyle="None" BorderWidth="0px"  />
                    <asp:Button ID="btnReject" runat="server" TabIndex="112" Text="Reject" Width="100px" />

                    <br />
                </td>
                <td colspan="2" style="text-align: left">


                    <asp:CheckBox ID="chbNoticeToPrincipal" runat="server" Text="Email to Principal" Checked="true" />
                    <br />
                    <asp:CheckBox ID="chbNoticeToUnion" runat="server" Text="Email to Union" Checked="true" />
                </td>

            </tr>
        </table>
        <asp:HiddenField ID="hfRequestUserID" runat="server" Value="" />
        <asp:HiddenField ID="hfPrincipalID" runat="server" Value="" />
        <asp:HiddenField ID="hfPostingNumber" runat="server" Value="" />
        <asp:HiddenField ID="hfIDs" runat="server" Value="0" />
        <asp:HiddenField ID="hfUserID" runat="server" Value="" />
        <asp:HiddenField ID="hfSchoolyear" runat="server" Value="" />
        <asp:HiddenField ID="hfSchoolyearStartDate" runat="server" Value="2016-08-20" />
        <asp:HiddenField ID="hfSchoolyearEndDate" runat="server" Value="2017-06-30" />
        <asp:HiddenField ID="hfAppType" runat="server" Value="" />

        <%--   <div id="QualificationCheckListDIV" style="display: none; background-color: papayawhip; position: absolute; border: 1px solid blue;">
            <asp:CheckBoxList ID="cblQualification" runat="server" CssClass="cblQual"></asp:CheckBoxList>
        </div>--%>
    </form>

</body>
</html>
<script type="text/javascript">

    var Qualification;
    var OperatePage = {
        LockPage: function () { LockPageWhenPostingRequested(); },
        UpdateQual: function (QualCode, checkValue) { UpdateQualificationSelected(QualCode, checkValue); },

    };

    function LockPageWhenPostingRequested() {



        DOMaction.InputText($("#TextOtherReason"), true);
        DOMaction.InputText($("#TextPositionTitle"), true);
        //DOMaction.Button($("#btnSave"), true)
        //DOMaction.Button($("#btndelete"), true)
        DOMaction.DropDownList($("#ddlType"), true)
        // DOMaction.DropDownList($("#ddlPositionLevel"), true)
        //DOMaction.DropDownList($("#ddlHRStaff"), true)
        DOMaction.DropDownList($("#ddlTeacherReplaced"), true)
        DOMaction.DropDownList($("#ddlReason"), true)

        // DOMaction.CheckBoxList($('#cblQualification'), true);
        // DOMaction.DropDownList($("#ddlPanel"), true)
        // DOMaction.RadioButtonList($('#rblFTE'), true);
        // DOMaction.DatePicker("#dateStart", true);
        // DOMaction.DatePicker("#dateEnd", true);
        DOMaction.Button("#btnRequest", true);
        //DOMaction.Button("#btnSave", true);
        DOMaction.Button("#btnReject", true);

    }

    $(document).ready(function () {
        InitialDatePickerControl();
        if ($("#TextStatus").val() != "Initial") OperatePage.LockPage();
        $('#FTECell').hide();
        if ($('#TextFTE').val() != '') {
            $('#FTECell').show();
        }
        $('#datePublish').change(function () {
            try {
                //   $('#dateDeadline').val('2013-12-03');
                // $('#btnSave1').click();
                var publishdate = $("#datePublish").val();
                var schoolyear = $("#hfSchoolyear").val();
                $("#dateApplyStart").val(publishdate);
                // *************** works on developer Computer this is WCF Web services ******************
                //var newDate = new LTOPositionDeadLine.GetDeadLineDate;
                // newDate.myDate(schoolyear, publishdate, onSuccess, onFailure);
                // ****************************************************************************************
                //***************  Web service Call ******************************************************
                var deadlinedate = WebService.DeadLineDate(schoolyear, publishdate, onSuccess, onFailure); //GetDeadLineDateFromWebService(publishdate);

                //*******************************************************************************************
                //************** Web api call ****************************
                // GetDeadLineDateFromWebAPI(publishdate, schoolyear);
                //********************************************
                //  $('#btnRequest').addClass("enabaledBTCn");

            }
            catch (e) {
                window.alert(e.message);
            }
        });
        $('#dateApplyStart').change(function () {
            try {
                var publishdate = $("#dateApplyStart").val();
                var schoolyear = $("#hfSchoolyear").val();
                var deadlinedate = WebService.DeadLineDate(schoolyear, publishdate, onSuccess, onFailure);
            }
            catch (e) {
                window.alert(e.message);
            }
        });

        function onSuccess(result) {
            $("#dateDeadline").val(result);
        }
        function onFailure(result) {
            var rDate = $("#datePublish").val();
            $("#dateDeadline").val(rDate);
        }

        $("#btnRequest").click(function (e) {
            $("#hdChildFormAction", parent.document).val("ChangeAction");
        });
        $("#btnSave").click(function (e) {
            $("#hdChildFormAction", parent.document).val("ChangeAction");
        });
        $("#btnReject").click(function (e) {

            $("#hdChildFormAction", parent.document).val("ChangeAction");

            bootbox.confirm("Are you sure, you want Reject this Position ?",
                function (result) {
                    if (result)
                        bootbox.alert(" you action was  " + result);
                    else
                        bootbox.alert(" you action was else  " + result);
                });

            return false;

        });
        $("#ButtonCancel").click(function (e) {
            $("#RepostingDIV").fadeToggle("slow");
            return false;
        });
        $("#rblFTE input").click(function (e) {
            try {
                var ev = window.event;
                var targetItem = ev.srcElement.id;
                var myItem = $("#" + targetItem);
                var selectedCode = myItem.val();
                if (selectedCode == "00") {
                    $('#FTECell').show();
                } else {
                    $('#FTECell').hide();
                }


            } catch (e) {
            }

        });
        $("#cblQualification input").click(function (e) {
            try {
                var ev = window.event;
                var targetItem = ev.srcElement.id;
                var myItem = $("#" + targetItem);
                var QualCode = myItem.val();
                //Qualification = myItem.closest("td").find("label").html();
                var checkedvalue = myItem[0].checked;
                OperatePage.UpdateQual(QualCode, checkedvalue);
            } catch (ex) {
                alert(ex);
            }

        });
        $("#btnRepublish").click(function (e) {

            try {
                $("#RepostingDIV").css({
                    top: 200, //mouse_y + 10,
                    left: 200, // mouse_x - (vWidth + 15),
                    height: 200,
                    width: 300

                })

                $("#RepostingDIV").fadeToggle("slow");
                return false;
            } catch (e) {
            }

        });


        $("#btndelete").click(function (e) {
            var applicant = $("#hfApplicant").val();
            var result = "";
            if (applicant > 0) {

                bootbox.alert("There are  " + applicant + " applicants applied this postion. Please Cancel Posting !!!  ");

                result = false;

            } else {
                result = confirm("Are you sure, you want delete this Position ?");

            }
            if (result) {
                // $("#HiddenFieldAction").val("Yes");
                return true;
            } else
                return false;
        });
        $(window).unload(function () {

        });

    });

    function InitialDatePickerControl() {
        var value = new Date().toDateString;
        var minD = new Date($("#hfSchoolyearStartDate").val());
        var maxD = new Date($("#hfSchoolyearEndDate").val());

        JDatePicker.Initial($("#dateStart"), minD, maxD, value);
        JDatePicker.Initial($("#dateEnd"), minD, maxD);

        JDatePicker.Initial($("#datePublish"));
        JDatePicker.Initial($("#dateApplyStart"));
        JDatePicker.Initial($("#dateDeadline"));
    }
    function UpdateQualificationSelected(QualCode, checkedvalue) {
        var code = DOMaction.CheckBoxListValue($('#cblQualification'), "Code");
        var name = DOMaction.CheckBoxListValue($('#cblQualification'), "Name");
        $('#lblQualification').val(name);
        $('#hfQualificationCode').val(code);
        //   alert($('#hfQualificationCode').val() + "  " + $('#lblQualification').val());


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
                    var message = "Your Browser does not support Auto Refreash Parent Screen, Please refresh manual !";
                    // window.alert(message);
                    bootbox.alert(message);
                }

            }

        }
    }
</script>


