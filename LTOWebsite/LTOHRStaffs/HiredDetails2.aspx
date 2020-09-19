<%@ Page Language="VB" AutoEventWireup="false" CodeFile="HiredDetails2.aspx.vb" Inherits="HiredDetails2" EnableTheming="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HR Confirm for Hire </title>
    <base target="_self" />
    <meta http-equiv="Pragma" content="No-cache" />
    <link href="../Styles/DetailsPage.css" rel="stylesheet" type="text/css" />
    <link href="../JQuery-UI/jquery-ui.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        body {
            height: 100%;
            width: 99%;
        }

        .noWrap {
            text-wrap: avoid;
            width: 110px;
        }
    </style>
    <script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        function CallBackReloadParent(action, strMessage) {
            try {
                if (action != "") {
                    window.alert(action + " " + strMessage);
                    $("#hdChildFormAction", parent.document).val(action);
                    $("#PopUpDIV", parent.document).fadeToggle("fast");
                    $("#PositionDetailDIV", parent.document).fadeToggle("fast");
                    window.parent.frames["mainTop"].document.location.reload();
                }
                else {
                    $("#PopUpDIV", parent.document).fadeToggle("fast");
                    $("#PositionDetailDIV", parent.document).fadeToggle("fast");
                }
            }
            catch (e) {
                var s = e.message;
            }

        }


    </script>

</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div style="background-image: url(../images/message_body_m.bmp)">

            <table style="width: 100%">
                <tr>
                    <td>Teacher Name:
 
                    </td>
                    <td>
                        <asp:TextBox ID="TextName" runat="server" BackColor="Transparent" Width="120px"></asp:TextBox>

                    </td>
                    <td class="noWrap">Posted Date: </td>
                    <td>
                        <asp:Label ID="datePosted" ReadOnly="true" runat="server" Width="100px"></asp:Label>
                    </td>
                    <td class="noWrap">Interview Date: </td>
                    <td>
                        <asp:Label ID="dateInterview" ReadOnly="true" runat="server" Width="100px"></asp:Label>
                    </td>
                    <td class="noWrap">Hire Date:</td>
                    <td>
                        <%-- <asp:TextBox ID="TextHireDate" runat="server" BackColor="Transparent" Height="23px" Width="100px"></asp:TextBox>--%>
                        <asp:Label ID="dateHire" ReadOnly="true" runat="server" Width="100px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Posting Number </td>
                    <td>
                        <asp:Label ID="lblPostingNum" runat="server" Text="2017-00"></asp:Label>
                        <asp:Label ID="lblPositionOwner" runat="server" Text=""></asp:Label>


                    </td>
                    <td class="noWrap">Person ID</td>
                    <td>
                        <asp:Label ID="lblTeacherPersonID" runat="server" Text="teacher person id"></asp:Label>
                    </td>
                    <td class="noWrap">OT PRNR.</td>
                    <td>
                        <asp:Label ID="lblTeacherOTPrnr" runat="server" Text="OT Prnr"></asp:Label>
                    </td>
                    <td class="noWrap">OCT No.</td>
                    <td>
                        <asp:Label ID="lblTeacherOCT" runat="server" Text="OCT Number"></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td colspan="8">
                        <hr />
                    </td>
                </tr>


                <tr>
                    <td style="width: 15%">Position Title:</td>
                    <td colspan="7" style="width: 85%">
                        <asp:TextBox ID="TextPositionTitle" runat="server" Height="20px" Width="70%" BackColor="Transparent"></asp:TextBox>
                        FTE
                        <asp:Label ID="lblPositionFTE" runat="server" Height="20px" Width="30px" BackColor="Transparent"></asp:Label>
                        <asp:Label ID="lblFTEPanel" runat="server" Height="20px" Width="50px" BackColor="Transparent"></asp:Label>
                        <asp:Label ID="lblPostingCycle" runat="server" Height="20px" Width="70px" BackColor="Transparent"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>Mandatory Qualification:</td>
                    <td colspan="7">
                        <asp:TextBox ID="TextPostionLevel" runat="server" Height="20px" Width="100%" BackColor="Transparent"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Position School:</td>
                    <td colspan="7">
                        <asp:TextBox ID="TextSchool" runat="server" BackColor="Transparent" Height="20px" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Minimum Qualification:</td>
                    <td colspan="7">
                        <asp:TextBox ID="TextQualification" runat="server" BackColor="Transparent" TextMode="MultiLine" Height="40px" Width="100%"></asp:TextBox>


                    </td>
                </tr>

                <tr class="PositionDescription">
                    <td>Position Description:</td>
                    <td colspan="7">
                        <asp:TextBox ID="TextDescription" runat="server" BackColor="Transparent" TextMode="MultiLine" Height="40px" Width="100%"></asp:TextBox>

                        <div id="F100TimeTable" runat="Server"></div>
                        <div id="F100MultipleSchool" runat="Server"></div>
                    </td>
                </tr>
                <tr>
                    <td>Posting Comments:</td>
                    <td colspan="7">
                        <asp:TextBox ID="TextPostingComments" runat="server" BackColor="Transparent" TextMode="MultiLine" Height="40px" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Applicant Comments:<br />
                    </td>

                    <td colspan="7">
                        <asp:TextBox ID="TextComments" runat="server" BackColor="Transparent" TextMode="MultiLine" Height="40px" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Applicant Qualification </td>
                    <td colspan="7">
                        <asp:TextBox ID="TextApplicantQulification" runat="server" Height="40px" TextMode="MultiLine" Width="100%" BackColor="Transparent"></asp:TextBox></td>
                </tr>
                <tr id="HiredRow1" runat="server">
                    <td>Applicant LTO Appraisal:
                                        
                    </td>
                    <td colspan="7">
                        <%-- <asp:TextBox ID="TextAppraisals" runat="server" Height="50px" TextMode="MultiLine" Width="500px" BackColor="Transparent"></asp:TextBox>--%>
                        <div id="TextAppraisal" runat="server" style="overflow: auto; display: block; width: 100%; height: 50px; background-color: transparent; border-style: inset; border-width: thin">
                        </div>

                    </td>
                </tr>
                <tr id="HiredRow2" runat="server">
                    <td>Principal Comments </td>
                    <td colspan="7">
                        <asp:TextBox ID="TextPrincipalComments" runat="server" Height="40px" TextMode="MultiLine" Width="100%" BackColor="Transparent"></asp:TextBox></td>
                </tr>
                <tr id="HiredRow3" runat="server">
                    <td>Hire / Re post / Substitute
                        <br />
                        HR
                        Comments </td>
                    <td colspan="7">
                        <asp:TextBox ID="TextHiredcomments" runat="server" Height="30px" TextMode="MultiLine" Width="100%" BackColor="#ffffcc"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="8">
                        <hr />
                    </td>
                </tr>

                <tr>
                    <td>Teacher be Replaced </td>
                    <td colspan="3">
                        <asp:Label ID="lblTeacherBeReplaced" runat="server" Text="teacher name"></asp:Label>
                    </td>
                    <td class="noWrap">Person ID</td>
                    <td colspan="2">
                        <asp:Label ID="lblTeacherBeReplacedPersonID" runat="server" Text="person id"></asp:Label>
                    </td>
                    <td class="noWrap">
                        <asp:Label ID="lblRound" runat="server" Text="1 "> </asp:Label>
                        Round
                    </td>




                </tr>

                <tr>
                    <td>Reason for leave
               
                    </td>
                    <td colspan="3">
                        <asp:Label ID="lblReasonReplacement" TabIndex="14" runat="server" Height="22px" Width="99%"></asp:Label>

                    </td>
                    <td class="noWrap">Pay Status:</td>
                    <td colspan="3">
                        <asp:DropDownList ID="ddlPayStatus" TabIndex="11" runat="server" Width="120px" Height="20px" CssClass="editcell" Enabled="false">
                            <asp:ListItem Value="9"><-- select --> </asp:ListItem>
                            <asp:ListItem Value="1">Leave with Pay</asp:ListItem>
                            <asp:ListItem Value="0">Leave without Pay</asp:ListItem>
                            <asp:ListItem Value="2">Active Absent Employee</asp:ListItem>

                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="HiredRow4" runat="server">


                    <td>Confirm Hire 
                       
                    </td>

                    <td>
                        <asp:CheckBox ID="chbHiring" runat="server" Enabled="false" />
                    </td>
                    <td class="noWrap">Date of Effective </td>
                    <td>
                        <input runat="server" type="text" id="dateEffective" size="9" disabled="true" />

                    </td>
                    <td>Date of End</td>
                    <td>
                       <%-- <asp:Label ID="lblEndDate" runat="server" Text="endDate"></asp:Label>--%>
                         <input runat="server" type="text" id="lblEndDate" size="9" disabled="true" />
                    </td>
                    <td colspan="2" style="text-align: left">


                        <asp:CheckBox ID="chbNoticeToPrincipal" runat="server" Text="Email to Principal" Checked="true" />
                        <br />
                        <asp:CheckBox ID="chbNoticeToUnion" runat="server" Text="Email to Union" Checked="true" />
                    </td>
                </tr>
                <tr>
                    <td>H.M.40 Sign Off</td>

                    <td id="signOffChb" runat="server" colspan="7" style="font-size: small; color: red;">
                        <asp:CheckBox ID="chbSignatureSignOff" runat="server" Visible="false" Text="Interviewer and Candidate Sign Off Status on H.M. 40 Document" /></td>
                </tr>
                <tr>
                    <td colspan="8" style="text-align: center;">
                        <asp:CheckBox ID="chbNextYear" runat="server" Text="Push to Next Year" ForeColor="Red" AutoPostBack="true" Visible="false" />
                        &nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnSaveHired" runat="server" Text="Confirm Hire" Width="160px" />
                        &nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnRepost" runat="server" Visible="false" Text="Re-post New" Width="100px" title="Write Re Post comments before click on the button" />
                        &nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnSubstitute" runat="server" Visible="false" Text="Re-post" Width="100px" title="Write Subetitute comments before click on the button" />
                        &nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnGoTo" runat="server" Visible="false" Text="Go to Position" Width="100px" title="Write Replacement comments before click on the button" />
                        &nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnEmail" runat="server" Text="Send Confirm Hire email" Width="180px" />
                    </td>
                </tr>

                <tr id="HiredMessageRow" runat="server" visible="false">
                    <td>
                        <img id="HiredAlert" runat="server" src="../images/alert.gif" visible="false" />


                    </td>
                    <td colspan="7">

                        <asp:Label ID="HiredMessage" runat="server" Text="Label" ForeColor="Red" Width="440px" Visible="false"></asp:Label>
                        FTE
                        <asp:Label ID="lblHiredFTE" runat="server" Text="Label" ForeColor="Red" Width="30px" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

        <asp:HiddenField ID="HiddenFieldAction" runat="server" Value="No" />
        <asp:HiddenField ID="hfUserCPNum" runat="server" />
        <asp:HiddenField ID="hfSchoolyear" runat="server" />
        <asp:HiddenField ID="hfSchoolCode" runat="server" />
        <asp:HiddenField ID="hfSchoolname" runat="server" />
        <asp:HiddenField ID="hfIDs" runat="server" />
        <asp:HiddenField ID="hfPositionID" runat="server" />
        <asp:HiddenField ID="hfPrincipalName" runat="server" />
        <asp:HiddenField ID="hfPrincipalID" runat="server" />
        <asp:HiddenField ID="hfPrincipalNameTo" runat="server" />
        <asp:HiddenField ID="hfPositionType" runat="server" />
        <asp:HiddenField ID="hfPositionNumber" runat="server" />
        <asp:HiddenField ID="hfConfirmUser" runat="server" />
        <asp:HiddenField ID="hfPositionType1" runat="server" />
        <asp:HiddenField ID="hfPositionTypeHired" runat="server" />
        <asp:HiddenField ID="hfHiredStatus" runat="server" />
        <asp:HiddenField ID="hfPostcycle" runat="server" />
        <asp:HiddenField ID="hfSchoolyearStartDate" runat="server" Value="2016-10-02" />
        <asp:HiddenField ID="hfSchoolyearEndDate" runat="server" Value="2017-05-26" />



    </form>
</body>
</html>

<script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
<script src="../JQuery-UI/jquery-ui-1.11.4.min.js" type="text/javascript"></script>

<script type="text/jscript">
    $(document).ready(function () {

        if ($("#chbSignatureSignOff").prop('checked') === true) {
            $("#signOffChb").css("color", "green");
        }

        var minD = new Date($("#hfSchoolyearStartDate").val());
        var maxD = new Date($("#hfSchoolyearEndDate").val());


        $("#dateEffective").datepicker(
            {
                dateFormat: 'yy-mm-dd',
                minDate: minD,
                maxDate: maxD,
                changeMonth: true,
                changeYear: true
            });
        $(window).unload(function () {
            //   var myaction = document.getElementById("HiddenFieldAction").value;
            window.returnValue = $("#HiddenFieldAction").val();
        });






        $("#btnSaveHired").click(function (e) {
            $("#hdChildFormAction", parent.document).val("ChangeAction");
            var actionsTitle = $(this).attr('value');
            var result = confirm("Are you sure, you want to " + actionsTitle + " ?");
            if (result) {
                $("#HiddenFieldAction").val("Yes");
                return true;
            }
            else
                return false;
        })

        $("#interviewPackage").click(function (e) {
            var yID = $("#hfSchoolyear").val();
            var cpnum = $("#hfUserCPNum").val();
            var pID = $("#hfPositionID").val();
            var printPage = "../PDFLoading/PDFDocument_Loading.aspx?rID=InterviewPackage" + "&yID=" + yID + "&CPNum=" + cpnum + "&pID=" + pID;
            var popup1 = window.open(printPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=800,height=600,top=0,left=0");

        });
    });

    function openLTOAppraisal(schoolyear, schoolcode, SessionID, TeacherID) {
        var printPage = "../PDFLoading/PDFDocument_Loading.aspx?rID=InterviewPackage" + "&yID=" + schoolyear + "&CPNum=" + TeacherID + "&pID=" + SessionID;
        var popup1 = window.open(printPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=800,height=600,top=0,left=0");
    }

</script>
