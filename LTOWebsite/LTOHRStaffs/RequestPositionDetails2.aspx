<%@ Page Language="VB" Async="true" AutoEventWireup="false" CodeFile="RequestPositionDetails2.aspx.vb" Inherits="RequestPositionDetails2" EnableTheming="true" %>


<!DOCTYPE html>

<html>
<head runat="server">
    <title>Add New open Position</title>
    <base target="_self" />
    <meta http-equiv="Pragma" content="No-cache" />
    <link href="../Styles/BubbleHelp.css" rel="stylesheet" type="text/css" />
    <link href="../JQuery-UI/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/DetailsPage.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="../JQuery-UI/jquery-ui-1.11.4.min.js" type="text/javascript"></script>
    <%--    <script src="../Scripts/angular.min.js" type="text/javascript"></script>--%>
    <script src="../Scripts/CommonDOM.js" type="text/javascript"></script>

    <%--    <link href="../Content/bootstrap.css" rel="stylesheet" type="text/css" />
   <script src="../Scripts/bootstrap.js" type="text/javascript"></script>
    <script src="../Scripts/bootbox.js" type="text/javascript"></script>--%>


    <style>
        body {
            width: 98%;
        }

        .ReadOnlyCell {
        }

        .Required-Field-Control {
            border: 2px dotted red;
        }

        #LTOMultipleSchool {
            position: relative;
            float: left;
        }

        #MultipleSchool {
            width: 100%;
            height: 100%;
        }

        #formTable {
            width: 100%;
        }

            #formTable tr {
                border: 0px solid #808080;
            }

        #TextPositionFTE.ng-invalid {
            background-color: red;
        }

        .InvalidCell {
            border: 2px solid red;
        }

        #btnSave1 {
            display: none;
        }

        #CancelDIV {
            font-family: Arial;
            font-size: small;
            display: none;
            position: absolute;
            left: 0;
            top: 0;
            background: url(../images/BlueDIVList.png);
            border: 3px outset skyblue;
        }
    </style>
    <script type="text/javascript">
        function ShowSaveMessage(action, message) {
            try {
                window.alert(action + " " + message);
                //  bootbox.alert(action + " " + message);
            }
            catch (e) {
            }
        }
        function CallBackReloadParent(action, message) {
            try {
                window.alert(action + " " + message);
                $("#hdChildFormAction", parent.document).val(action);
                window.parent.frames["mainTop"].document.location.reload();
                $("#PopUpDIV", parent.document).fadeToggle("fast");
                $("#PositionDetailDIV", parent.document).fadeToggle("fast");
                // top.opener.location.reload(true);
            }
            catch (e) {
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <%--<asp:ServiceReference Path="~/WebServices/GetDeadLineDate.svc" />--%>
                <%--<asp:ServiceReference Path="~/WebServices/WebServiceDeadline.asmx" />--%>
                <asp:ServiceReference Path="~/WebServices/WebService.asmx" />
            </Services>
        </asp:ScriptManager>
        <div>
            <table id="formTable">
                <tr>
                    <td>Position Type:</td>
                    <td>
                        <asp:DropDownList ID="ddlType" runat="server" Width="120px" CssClass="editcellLock" AutoPostBack="true"></asp:DropDownList>

                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 110px;">
                        <asp:Label ID="lblPostingNumber" runat="server" Text="Posting Number:"> </asp:Label>

                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="TextPostingNumber" runat="server" CssClass="editcell Edit-Content-Control" Width="80px" ReadOnly="true"></asp:TextBox>
                        <asp:TextBox ID="TextLinkPositionID" runat="server" Width="50px" ReadOnly="true" ForeColor="WhiteSmoke"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                    Status: 
                        <asp:TextBox ID="TextStatus" runat="server" BackColor="Transparent" Width="70px" CssClass="editcellLock"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp; Request Source: 
                        <asp:TextBox ID="TextSource" runat="server" BackColor="Transparent" Width="60px" CssClass="editcellLock"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp; Position Owner: 
                           <asp:DropDownList ID="ddlHRStaff" runat="server" Width="120px" CssClass="editcell Edit-Content-Control"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>School:  </td>
                    <td colspan="5">
                        <asp:DropDownList ID="ddlschoolcode" runat="server" Width="50px" Height="20px" CssClass="editcell Edit-Content-Control" AutoPostBack="true"></asp:DropDownList>
                        <asp:DropDownList ID="ddlSchool" TabIndex="11" runat="server" Width="68%" Height="20px" CssClass="editcell Edit-Content-Control" AutoPostBack="true"></asp:DropDownList>
                        <asp:DropDownList ID="ddlPrincipal" TabIndex="12" runat="server" Width="131px" Height="20px" CssClass="editcell Edit-Content-Control" AutoPostBack="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_ddlPrincipal" runat="server" ControlToValidate="ddlPrincipal" ErrorMessage="*" Font-Size="x-Large" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                </tr>
                <tr>
                    <td>Position Title:
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_TextPositionTitle" runat="server" ControlToValidate="TextPositionTitle" ErrorMessage="*" Font-Size="x-Large" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>


                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="TextPositionTitle" TabIndex="12" runat="server" Width="96%" TextMode="MultiLine" CssClass="editcell editArea Edit-Content-Control"></asp:TextBox>

                    </td>
                </tr>
                <tr class="editArea">
                    <td colspan="6">
                        <b>Selected Grade, Subject Area and Specific Qualfication on the position</b>
                </tr>
                <tr class="editArea">
                    <td colspan="6">
                        <table>
                            <tr>
                                <td>Division Required    </td>
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
                <tr>
                    <td>Subject Summary:
                         <asp:HiddenField ID="hfQualificationsCode" runat="server" Value="" />

                    </td>
                    <td colspan="5">
                        <b>
                            <input id="lblQualification" runat="server" name="lblQualification" type="text" readonly="readonly" style="width: 99%" class="editcellLock" />
                        </b>
                    </td>
                </tr>

                <tr class="editArea">

                    <td colspan="6">

                        <div id="cblQualficationDIV" runat="server" style="overflow: auto; width: 100%; height: 50px">
                            <asp:CheckBoxList ID="cblQualification" runat="server" RepeatColumns="4" RepeatDirection="Vertical" CssClass="editcell Edit-Content-Control" Width="100%">
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
                    <td>Position Description
                        <br />
                        <img runat="server" id="MultipleSchoolimg" height="22" width="35" alt="qualification" title="Click on to setup Multiple Locations" src="../images/schoolhouse.png" />
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="TextPositionDescription" TabIndex="141" runat="server" Height="30px" TextMode="MultiLine" Width="99%" CssClass="editcell Edit-Content-Control"></asp:TextBox>

                        <div id="F100TimeTable" runat="Server"></div>
                        <div id="F100MultipleSchool" runat="Server"></div>
                        <div id="LTOMultipleSchool" runat="Server" style="display: none;">
                            <iframe id="MultipleSchool" runat="server" name="MultipleSchool" seamless="seamless" scrolling="no"
                                src="RequestPositionDetails_MultipleSchool.aspx"></iframe>
                        </div>

                    </td>
                </tr>

                <tr>
                    <td>Teacher being Replaced:
               
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlTeacherReplaced" TabIndex="13" runat="server" Width="100%" CssClass="editcell Edit-Content-Control"></asp:DropDownList>
                    </td>

                    <td colspan="3">Reason for Replacement 
                   <asp:DropDownList ID="ddlReason" TabIndex="13" runat="server" Width="60%" CssClass="editcell Edit-Content-Control"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>
                        <br />


                    </td>
                    <td colspan="5" class="DateCell">

                        <table style="width: 100%">

                            <tr>

                                <td class="midtitle">Assignment Start Date:</td>

                                <td style="text-wrap: none; overflow-wrap: normal">
                                    <input runat="server" type="text" id="dateStart" size="9" class="Edit-Content-Control" />
                                </td>
                                <td style="width: 15px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dateStart" ErrorMessage="*" Font-Size="x-Large" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td style="text-align: right;">Publish Date:</td>
                                <td style="text-wrap: none; overflow-wrap: normal">
                                    <input runat="server" type="text" id="datePublish" size="9" class="Edit-Content-Control" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="datePublish" ErrorMessage="*" Font-Size="x-Large" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>

                                <td class="midtitle">Assignment &nbsp;End Date:</td>
                                <td>
                                    <input runat="server" type="text" id="dateEnd" size="9" class="Edit-Content-Control" />
                                </td>
                                <td style="width: 15px"></td>

                                <td class="midtitle">
                                    <div>Date to Apply: </div>
                                </td>
                                <td>
                                    <input runat="server" type="text" id="dateApplyStart" size="9" class="Edit-Content-Control" />

                                </td>
                            </tr>
                            <tr>

                                <td colspan="2"></td>

                                <td></td>
                                <td class="midtitle">Deadline to Apply:</td>
                                <td>
                                    <input runat="server" type="text" id="dateDeadline" size="9" class="Edit-Content-Control" />
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>

                    <td colspan="6">

                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true" DisplayMode="SingleParagraph" ForeColor="red" Font-Size="Small" HeaderText="Must Entry Fields" />
                    </td>
                </tr>
                <tr>
                    <td>HR Post Comments
                        <br />
                        <asp:Label ID="lblPostedState" runat="server" Text="" ForeColor="red "> </asp:Label>
                        <br />
                        <asp:Label ID="lblPostedCycle" runat="server" Text="" ForeColor="red "> </asp:Label>
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="TextPostedComment" TabIndex="14" runat="server" Height="40px" TextMode="MultiLine" Width="99%" CssClass="editcell Edit-Content-Control"></asp:TextBox></td>
                </tr>
                <tr id="RemainderMessageRow" runat="server" style="color: red;">
                    <td></td>
                    <td colspan="5" style="font-size: xx-small">Notice Principal Date:
                        <input runat="server" type="text" id="lblNoticeDate" size="8" readonly="readonly" class="Edit-Content-Control-Readonly" />


                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  Last Reminder Date:
                         <input runat="server" type="text" id="lblRemainderDate" size="8" readonly="readonly" class="Edit-Content-Control-Readonly" />
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Round 
                        <input runat="server" type="text" id="lblPostRound" size="8" readonly="readonly" style="width:20px;" class="Edit-Content-Control-Readonly" />
                        Posting 

                    </td>
                </tr>
                <tr>

                    <td colspan="6" style="text-align: center;">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 80%">

                                    <asp:Button ID="btnSave" runat="server" TabIndex="111" Text="Save & Submit" Width="100px" />

                                    <asp:Button ID="btnUnpublish" runat="server" TabIndex="112" Text="Cancel Posting" Width="104px" />

                                    <asp:Button ID="btnRepublish" runat="server" TabIndex="113" Text="Re-Posting" Width="80px" />

                                    <asp:Button ID="btnReNotice" runat="server" TabIndex="113" Text="Re-Notice" Width="80px" />

                                    <asp:Button ID="btndelete" runat="server" TabIndex="114" Text="Delete Position" Width="100px" />

                                    <asp:Button ID="btnEmail" runat="server" TabIndex="105" Text="Send Email" Width="100px" />

                                    <asp:Button ID="btnRecover" runat="server" TabIndex="115" Text="Recover" Width="100px" Visible="false" />

                                    <asp:Button ID="btnSave1" runat="server" TabIndex="116" Text="" Height="0px" Width="1px" />
                                </td>
                                <td style="text-align: left;">
                                    <asp:CheckBox ID="chbNoticeToPrincipal" runat="server" Text="Email to Principal" Checked="true" /><br />
                                    <asp:CheckBox ID="chbNoticeToUnion" runat="server" Text="Email to Union" Checked="true" />
                                </td>
                            </tr>
                        </table>



                    </td>

                </tr>
            </table>
        </div>
        <asp:HiddenField ID="hfUserID" runat="server" Value="" />
        <asp:HiddenField ID="hfIDs" runat="server" Value="0" />
        <asp:HiddenField ID="hfSchoolyear" runat="server" Value="" />
        <asp:HiddenField ID="hfApplicant" runat="server" Value="" />
        <asp:HiddenField ID="HiddenFieldAction" runat="server" Value="No" />
        <asp:HiddenField ID="hfAppType" runat="server" Value="" />
        <asp:HiddenField ID="hfSchoolyearStartDate" runat="server" Value="2017-08-16" />
        <asp:HiddenField ID="hfSchoolyearEndDate" runat="server" Value="2018-06-30" />
        <asp:HiddenField ID="hfPositionOwner" runat="server" Value="" />
        <asp:HiddenField ID="hfPrincipalID" runat="server" Value="" />
        <asp:HiddenField ID="hfTitle" runat="server" Value="" />
        <asp:HiddenField ID="hfStartDate" runat="server" Value="" />
        <asp:HiddenField ID="hfEndDate" runat="server" Value="" />
        <asp:HiddenField ID="hfPositionLevel" runat="server" Value="" />
        <asp:HiddenField ID="hfPostingCycle" runat="server" Value="" />


        <div id="RepostingDIV" style="background-color: aliceblue">
            <div style="text-align: center;">

                <br />
                Are you sure,
                <br />
                you want to re posting  this position ?
                  <br />
                <br />
                <br />
                Posting as:<asp:DropDownList ID="ddlPostingCycle" runat="server">
               <asp:ListItem Value="1">1st Posting</asp:ListItem>
    <%--            <asp:ListItem Value="2">2nd Posting</asp:ListItem>
                    <asp:ListItem Value="3">3rd Posting</asp:ListItem> 
                    <asp:ListItem Value="4" >4th Posting</asp:ListItem> Remove 2nd and 4rd 2022-03-07 Request from HR --%>
                     <asp:ListItem Value="4" Selected="true">Re Posting</asp:ListItem>
               </asp:DropDownList>
                <br />
                <br />
            </div>
            <div style="text-align: center">
                <asp:CheckBox ID="CheckBoxgetApplicant" runat="server" Text="Auto bring Applicants to new posting" />
                <br />
                <br />
                <br />

            </div>
            <div style="text-align: center">
                <asp:Button ID="ButtonOK" runat="server" Text="OK" />
                &nbsp; &nbsp; &nbsp; &nbsp;
                 <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" />
            </div>
        </div>
        <div id="CancelDIV">
            <div style="text-align: center">

                <h2 style="height: 30px; margin-bottom: -5px;">Cancel posting</h2>


                <div style="color: red;">
                    You must provide cancel comments before you can cancel a posting.
                </div>

                <div style="text-align: left; margin-top: 15px;">
                    Cancel Comments:  
                </div>
                <asp:TextBox ID="cancelComments" runat="server" Width="98%" TextMode="MultiLine" CssClass="editcell Edit-Content-Control" Font-Size="Small" Height="150px"></asp:TextBox>
                <div style="text-align: left; margin-top: 5px;">
                    <asp:CheckBox ID="chbCancel" runat="server" Visible="false" Checked="false" Text="Cancel and Recover Previous posting" ForeColor="red" />
                </div>

                <div style="text-align: center; margin-top: 10px;">
                    <asp:Button ID="ButtonGoCancel" runat="server" Text="Save& Submit" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButtonExitCancel" runat="server" Text="Cancel" />
                </div>
            </div>
        </div>
    </form>

</body>
</html>



<script type="text/javascript">
    var actionControl;
    var OperatePage =
    {
        OpenPage: function () { openPageForNewPosting(); },
        LockPage: function () { LockPageWhenPostingComplete(); },
        UpdateQual: function (QualCode, checkValue) { UpdateQualificationSelected(QualCode, checkValue); },
    };
    function openPageForNewPosting() { }

    function LockPageWhenPostingComplete() {
        DOMaction.Button($("#btndelete"), true);
        DOMaction.DropDownList($("#ddlType"), true);
    }
    function UpdateQualificationSelected(QualCode, checkedvalue) {
        var qual = {
            "Operate": "Request",
            "UserID": $("#hfUserID").val(),
            "SchoolYear": $("#hfSchoolyear").val(),
            "SchoolCode": $("#ddlschoolcode").val(),
            "PositionID": $("#TextRequestID").val(),
            "SourceID": "Request",
            "QualificationID": QualCode,
            "Selected": checkedvalue
        }
        var code = DOMaction.CheckBoxListValue($('#cblQualification'), "Code");
        var name = DOMaction.CheckBoxListValue($('#cblQualification'), "Name");
        $('#lblQualification').val(name);
        $('#hfQualificationsCode').val(code);

    }


    function pageLoad(sender, args) {
        $(document).ready(function () {
            $('#TextQualification').attr('readonly', true);
            $('#CancelDIV').hide();
            $('#FTECell').hide();

            if ($('#TextFTE').val() != '') {
                $('#FTECell').show();
            }
            if ($("#hfIDs").val() == "0") {
                $("#TextReasonReplacement").removeClass("editcellLock").addClass("editcell");

            }
            InitialDatePickerControl();
            InitialPageControls();

            $('#datePublish').change(function () {
                try {
                    //   $('#dateDeadline').val('2013-12-03');
                    // $('#btnSave1').click();
                    actionControl = "PublishDate";
                    var publishdate = $("#datePublish").val();
                    var schoolyear = $("#hfSchoolyear").val();
                    var positiontype = $("#ddlType").val();
                    $("#dateApplyStart").val(publishdate);

                    // *************** works on developer Computer this is WCF Web services ******************
                    // var newDate = new LTOPositionDeadLine.GetDeadLineDate;
                    //  newDate.myDate(schoolyear, publishdate, onSuccess, onFailure);

                    // ****************************************************************************************

                    //***************  Web service Call ******************************************************

                    var deadlinedate = WebService.DeadLineDate(schoolyear, publishdate, onSuccess, onFailure);

                    //*******************************************************************************************

                    //************** Web api call ****************************
                    // GetDeadLineDateFromWebAPI(publishdate, schoolyear);
                    // GetDeadLineDateWebAPICall(schoolyear, publishdate, positiontype)
                    //********************************************************
                }
                catch (e) {
                    window.alert(e.message);
                }
            });
            $('#dateApplyStart').change(function () {
                try {
                    actionControl = "ApplyDate";
                    var publishdate = $("#dateApplyStart").val();
                    var schoolyear = $("#hfSchoolyear").val();
                    var deadlinedate = WebService.DeadLineDate(schoolyear, publishdate, onSuccess, onFailure);
                }
                catch (e) {
                    window.alert(e.message);
                }
            });

            $("#btnRequest").click(function (e) {
                $("#hdChildFormAction", parent.document).val("ChangeAction");
            });
            $("#btnSave").click(function (e) {
                $("#hdChildFormAction", parent.document).val("ChangeAction");
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

            $("#btnRepublish").click(function (e) {
                $("#hdChildFormAction", parent.document).val("ChangeAction");
                try {
                    $("#RepostingDIV").css({
                        top: 200, //mouse_y + 10,
                        left: 200, // mouse_x - (vWidth + 15),
                        height: 200,
                        width: 300

                    })

                    $("#RepostingDIV").fadeToggle("slow");
                    return false;
                }
                catch (e) {
                    return false;
                }

            });
            $("#btndelete").mouseover(function (e) {

                if ($("#TextPositionTitle").val() === "") {
                    $("#TextPositionTitle").val("Position Title");
                }


            });
            $("#btndelete").click(function (e) {
                var applicant = $("#hfApplicant").val();
                if (applicant > 0) {
                    bootbox.alert("There are  " + applicant + " applicants applied this postion. Please Cancel Posting !!!  ");
                    return false;
                } else {
                    var result = confirm("Are you sure, you want to Delete this posting ?");
                    if (result) {
                        $("#HiddenFieldAction").val("Yes");
                        return true;
                    } else
                        return false;


                    //bootbox.confirm("Are you sure, you want delete this Position ?",function(result) {
                    //        if (result) {
                    //            $("#HiddenFieldAction").val("Yes");
                    //            return true;
                    //        } else {
                    //            return false;
                    //        }
                    //    });
                }
            });

            $(window).unload(function () {
                //   var myaction = document.getElementById("HiddenFieldAction").value;
                window.returnValue = $("#HiddenFieldAction").val();

            });

            $("#MultipleSchoolimg").click(function (e) {
                openMultipleSchoolSetup1();

            });


            $("#btnUnpublish").click(function (e) {
                try {

                    $("#CancelDIV").css({
                        top: 200, //mouse_y + 10,
                        left: 150, // mouse_x - (vWidth + 15),
                        height: 300,
                        width: 500

                    })

                    $("#CancelDIV").fadeToggle("slow");
                    return false;
                } catch (e) {
                }
            });
            $("#ButtonExitCancel").click(function (e) {
                $("#CancelDIV").hide();
                return false;
            })
            $("#ButtonGoCancel").click(function (e) {
                var cancelcomment = $("#cancelComments").val();
                if (cancelcomment.length < 5) {
                    alert("Please provide cancel comments!")
                    return false;
                }
                else {

                    var result = confirm("Are you sure, you want to Cancel this posting ?");
                    if (result) {
                        $("#HiddenFieldAction", parent.document).val("Yes");
                        var comments = $("#cancelComments").val(); // $("#TextPostedComment").val() + "\n" + $("#cancelComments").val();
                        $("#TextPostedComment").val(comments);
                        $("#hdChildFormAction", parent.document).val("ChangeAction");
                        return true;
                    } else
                        return false;
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
        
        });
    }
    function onSuccess(result) {
        if (result == "Invalid Date") {

            window.alert(result);
            if (actionControl == "PublishDate") { $('#datePublish').addClass("InvalidCell"); }
            $("#dateDeadline").addClass("InvalidCell");
            $("#dateApplyStart").addClass("InvalidCell");
            $("#dateDeadline").val(result);
        }
        else {
            if (actionControl == "PublishDate") { $('#datePublish').removeClass("InvalidCell"); }
            $("#dateApplyStart").removeClass("InvalidCell");
            $("#dateDeadline").removeClass("InvalidCell");
            $("#dateDeadline").val(result);
        }

    }
    function onFailure(result) {
        window.alert(result);
    }
    function openMultipleSchoolSetup1() {
        var sCode = $('#ddlSchool').val(); //      $("#ddlSchool option:selected").val();
        var pId = $("#TextPositionID").val();
        var iDs = $("#hfIDs").val();
        var pTitle = $("#TextPositionTitle").val();


        if ($("#F100MultipleSchool").css("display") == "none") {
            $("#F100MultipleSchool").show();
        }
        else {
            $("#F100MultipleSchool").hide();
        }
        if ($("#LTOMultipleSchool").css("display") == "none") {
            $("#LTOMultipleSchool").css({
                height: 130,
                width: 610
            });

            var goPage = "RequestPositionDetails_MultipleSchool.aspx?pID=" + pId + "&IDS=" + iDs + "&sCode=" + sCode + "&pTitle=" + pTitle + "&sourceID=Posting";
            $("#MultipleSchool").attr('src', goPage);
            $("#LTOMultipleSchool").show();

            // $("#LTOMultipleSchool").fadeToggle("fast");
        }
        else {
            $("#LTOMultipleSchool").hide();
        }

    }
    function checkRequiredFields() {
        DOMaction.Validation("RequiredFieldValidator_TextPositionTitle", "TextPositionTitle");
        DOMaction.Validation("RequiredFieldValidator_ddlPrincipal", "ddlPrincipal");
        DOMaction.Validation("RequiredFieldValidator_rblFTE", "rblFTE");
        DOMaction.Validation("RequiredFieldValidator_ddlPositionlevel", "ddlPositionlevel");
        DOMaction.Validation("RequiredFieldValidator_lblQualification", "cblQualification");
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

    function right(str, chr) {
        return str.slice(-(chr));
    }
    function left(str, chr) {
        return str.slice(0, chr);
    }
    function InitialPageControls() {
        var lockStatus = "Noticed, Hired, Recommend,Re Posting";

        var source = $("#TextSource").val();
        var status = $("#TextStatus").val();



        if (status == "New Posting") {
            OperatePage.OpenPage();
        }
        else {
            OperatePage.LockPage();

            //if (source == "LTOPOP" && status == "New Posting") {
            //    OperatePage.OpenPage();
            //}
            //else {
            //    OperatePage.LockPage();
            //}
        }

    }
    function InitialDatePickerControl() {
        var value = new Date().toDateString;
        var minD = new Date($("#hfSchoolyearStartDate").val());
        var maxD = new Date($("#hfSchoolyearEndDate").val());

        // alert(minD);
        // alert(maxD);
        JDatePicker.Initial($("#dateStart"), minD, maxD, value);
        JDatePicker.Initial($("#dateEnd"), minD, maxD);

        JDatePicker.Initial($("#datePublish"));
        JDatePicker.Initial($("#dateApplyStart"));
        JDatePicker.Initial($("#dateDeadline"));
    }



    //function GetDeadLineDateFromWebService(_datepublish) {
    //     var _deadlinedate = "";
    //     var mypublishDate = { 'datepublish': _datepublish };
    //     var toPassParameter = JSON.stringify(mypublishDate);
    //     $.ajax({
    //         type: 'POST',
    //         contentType: "application/json; charset=utf-8",
    //         dataType: "json",
    //         url: "WebServiceDeadline.asmx/GetDeadLineDate",
    //         data: toPassParameter,
    //         success: function (data) {
    //             _deadlinedate = data.d;
    //         }
    //     });
    //     return _deadlinedate;
    // }

    //function GetDeadLineDateFromWebAPI(publishdate, schoolyear) {
    //    var servername = "https://webservice.tcdsb.org";
    //    var api = "/LTOapi/api/PositionApplyDeadLineDate";
    //    var parameter = "?userid=mif&schoolyear=" + schoolyear + "&publishdate=" + publishdate;
    //    var httpLink = servername + api + parameter;
    //    jQuery.support.cors = true;
    //    $.ajax({
    //        url: httpLink,
    //        type: 'GET',
    //        dataType: 'json',
    //        success: function (data) {
    //            var deadlinedate = data[0].ApplyDate;
    //            $("#dateDeadline").val(deadlinedate);
    //        },
    //        error: function (ex) {
    //            window.alert("Error");
    //        }
    //    });
    //}
    function GetDeadLineDateWebAPICall( schoolyear,publishdate,positionType) {
        try {
            var para = {
                Operate: $("#hfAction").val(),
                UserID: $("#hfUserID").val(), 
            };
            var uri = "DeadLine";
            var qStr = "/" + schoolyear + "/" + publishdate + "/" + positionType;

            var data = WebAPICall.GetDataPassQstr(uri, qStr);

           // var deadlinedate = data[0].ApplyDate;
            $("#dateDeadline").val(data[0].ApplyDate);
            $("#dateApplyStart").removeClass("InvalidCell");
            $("#dateDeadline").removeClass("InvalidCell");
          //  $("#dateDeadline").val(result);
 
        }
        catch (e) {
            alert(para.Operate + " Submit click something going wrong");
        }
    }

</script>


