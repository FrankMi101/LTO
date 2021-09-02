<%@ Page Language="VB" AutoEventWireup="false" CodeFile="InterviewDetails2.aspx.vb" Inherits="InterviewDetails2" EnableTheming="true" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Principal Interview </title>
    <base target="_self" />
    <meta http-equiv="Pragma" content="No-cache" />
    <style type="text/css">
        html, body {
            height: 99%;
            width: 99%;
        }

        input {
            font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif;
            font-size: 12px;
        }

        textarea {
            font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif;
            font-size: 12px;
        }

        .Itemtitle {
            text-wrap: none;
            font-size: 12px;
        }

        #PopUpDIV1 tr td {
            border-width: 0px;
            border-style: solid;
            border-color: blue;
        }

        .textboxF {
            font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif;
            font-size: 12px;
            border:1px solid #808080;
        }

        #formTable {
            width: 99%;
        }
    </style>
    <script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>

    <script type="text/javascript">


        function CallBackReloadParent(action, strMessage) {

            try {
                $("#hdChildFormAction", parent.document).val(action);
                if (action == "" || action == "Update Apply Info") {
                    $("#PopUpDIV", parent.document).fadeToggle("fast");
                    $("#PositionDetailDIV", parent.document).fadeToggle("fast");
                }
                else {
                    window.alert(action + " " + strMessage);
                    $("#PopUpDIV", parent.document).fadeToggle("fast");
                    $("#PositionDetailDIV", parent.document).fadeToggle("fast");
                    window.parent.frames["mainTop"].document.location.reload();
                }
            }
            catch (e) {
                var s = e.message;
            }
        }

        /*

          if (action != "") {
             window.alert(action + " " + strMessage  ); 
         }
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
                     window.alert("Your Browser does not support iFrame Call !")
                 }

             }

         }
         */


    </script>

</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div style="background-image: url(../images/message_body_m.bmp)">

            <table id="formTable">
                <tr>
                    <td style ="width:15%"> </td>
                    <td style ="width:15%"> </td>
                    <td style ="width:15%"> </td>
                    <td style ="width:10%"> </td>

                    <td style ="width:15%"> </td>
                    <td style ="width:10%"> </td>
                    <td style ="width:10%"> </td>
                    <td style ="width:10%"> </td>
                </tr>
                <tr>
                    <td   class="Itemtitle">Teacher Name:
 
                    </td>
                    <td >
                        <asp:TextBox ID="TextName" runat="server" BackColor="Transparent"  CssClass="textboxF"></asp:TextBox>
                    </td>
                    
                    <td  colspan ="6" > Posted Date:  <asp:TextBox ID="TextPostedDate" runat="server" BackColor="Transparent" Width="80px"  CssClass="textboxF"></asp:TextBox>
                     Hire Date: 
                     
                        <asp:TextBox ID="TextHireDate" runat="server" BackColor="Transparent" Width="80px"  CssClass="textboxF"></asp:TextBox>
                     
                        <asp:Label ID="lblPositionStatus" runat="server" Text="Label"></asp:Label>
                        <asp:Label ID="lblPostingCycle" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="Itemtitle">Position Title:</td>
                    <td colspan="7">
                        <asp:TextBox ID="TextPositionTitle" runat="server" Width="450px" BackColor="Transparent"  CssClass="textboxF"></asp:TextBox>

                      <asp:Label ID ="lblPostingNumber" runat="server">  Posting Number </asp:Label>
                         <asp:TextBox ID="txtPostingNumber" runat="server" Width="70px" BackColor="Transparent"  CssClass="textboxF"></asp:TextBox>

                    </td>
                </tr>

                <tr>
                    <td class="Itemtitle">Grade:</td>
                    <td colspan="3" >
                        <asp:TextBox ID="TextPostionLevel" runat="server" BackColor="Transparent"  CssClass="textboxF"></asp:TextBox>

                     BTC:
                        <asp:Label ID="lblPositionFTE" runat="server" Width="30px" BackColor="Transparent"></asp:Label>
                        <asp:Label ID="lblFTEPanel" runat="server" Width="50px" BackColor="Transparent"></asp:Label>
                    </td>
                    <td colspan="4">
                        <asp:RadioButtonList ID="rblFTE" runat="server" RepeatDirection="Horizontal" Width="400px" Enabled="false">
                            <asp:ListItem Value="100" Selected="true">100%</asp:ListItem>
                            <asp:ListItem Value="67">67%</asp:ListItem>
                            <asp:ListItem Value="50">50%</asp:ListItem>
                            <asp:ListItem Value="33">33%</asp:ListItem>
                            <asp:ListItem Value="25">25%</asp:ListItem>

                        </asp:RadioButtonList>
                    </td>
                </tr>

                <tr>
                    <td class="Itemtitle">Summary Qualification:</td>
                    <td colspan="7">
                        <asp:TextBox ID="TextQualification" runat="server" BackColor="Transparent" TextMode="MultiLine" Height="40px" Width="99%" CssClass="textboxF"></asp:TextBox>


                    </td>
                </tr>
                <tr>
                    <td class="Itemtitle">Position Description:</td>
                    <td colspan="7">
                        <asp:TextBox ID="TextDescription" runat="server" BackColor="Transparent" TextMode="MultiLine" Height="40px" Width="99%" CssClass="textboxF"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Itemtitle">Posting Comments:</td>
                    <td colspan="7">
                        <asp:TextBox ID="TextPostingComments" runat="server" BackColor="Transparent" TextMode="MultiLine" Height="40px" Width="99%" CssClass="textboxF"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Itemtitle">Applicant Comments:<br />
                        <%--    <img alt="comments" title="Print Comments" class="auto-style1" src="../images/attachment.png" />--%></td>

                    <td colspan="7">
                        <asp:TextBox ID="TextComments" runat="server" BackColor="Transparent" TextMode="MultiLine" Height="40px" Width="99%" CssClass="textboxF"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Itemtitle">Applicant Qualification: </td>
                    <td colspan="7">
                        <asp:TextBox ID="TextApplicantQulification" runat="server" Height="40px" TextMode="MultiLine" Width="99%" BackColor="Transparent" CssClass="textboxF"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="Itemtitle">Applicant LTO Appraisal:
                                        
                    </td>
                    <td colspan="7">
                        <%--<asp:TextBox ID="TextAppraisals" runat="server" Height="60px" TextMode="MultiLine" Width="500px" BackColor="Transparent"></asp:TextBox>--%>

                        <div id="TextAppraisals" runat="server" style="font-size: xx-small; overflow: auto; display: block; width: 99.7%; height: 50px; background-color: transparent; border-style: inset; border-width: thin">
                        </div>

                    </td>
                </tr>
                <tr>
                    <td class="Itemtitle">Hiring Recommendation
                        <br />
                        / Interview Comments : 
                    </td>
                    <td colspan="7">
                        <asp:TextBox ID="TextRecomendation" runat="server" Height="40px" TextMode="MultiLine" Width="99%" BackColor="#ffffcc" CssClass="textboxF"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">Assignment Start Date:  <asp:Label ID="LabelAssignStartDate" runat="server" Text=" "></asp:Label></td>
                     <td colspan="2" >End Date:  <asp:Label ID="LabelAssignEndDate" runat="server" Text=" "></asp:Label></td>
                    <td></td>
                    <td></td>
                     <td></td>
                    
                </tr>
                <tr>


                    <td></td>

                    <td>
                        <asp:CheckBox ID="chbHiring" runat="server" Text=" " Width="120px" AutoPostBack="true" Visible="false" />

                    </td>
                     

                    
                    <td colspan="3"><b>Interview Date:</b>
                        <input runat="server" type="text" id="dateInterview" size="9" />
                    </td>
                    <td colspan="3">

                        <a id="interviewPackage" runat="server" title="Print Interview Package, Include LTO Appraisals">
                            <img alt="Interview Package" title="Print Interview Package, Include LTO Appraisals" src="../images/attachment.png" />
                            Interview Package
                        </a>
                        
                    </td>

                </tr>
                <tr>
                    <td style="text-align: right"><b>Interview Outcome:</b>   </td>

                    <td>
                        <table>
                            <tr>
                                <td>

                                    <asp:DropDownList ID="ddlAction" runat="server" Width="130px" BackColor="#ffffcc" AutoPostBack="false"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlAction" ErrorMessage="Must select Interview Outcome. " Font-Size="x-Large" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </td>

                            </tr>
                        </table>
                    </td>
                     
                    <td colspan="3"> <b> <asp:Label ID="LabelStartDate" runat="server" Text=" LTO start date:"></asp:Label></b>
                        <input runat="server" type="text" id="dateEffective" size="9" />
                        <%--                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dateEffective" ErrorMessage="Must input Start Date. " Font-Size="x-Large" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                    </td>
                    <td colspan="3">
                        <img id="helpPrincipal" runat="server" src="../images/HelpS.bmp" title="click to Help" />
                           &nbsp; &nbsp;  
                         <div id="LabelResume" runat="server"  style="display:inline"></div>
                      
                         <div id="LabelCoverLetter" runat="server"  style="display:inline"></div>
                    </td>
                </tr>
                <tr>
                    <td>H.M.40 Sign Off</td>

                    <td id="signOffChb" runat="server" colspan="7" style="font-size: small; color: red;">
                        <asp:CheckBox ID="chbSignatureSignOff" runat="server" AutoPostBack="true" Text="Interviewer and Candidate Sign Off Status on H.M. 40 Document" />
                        &nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" Text="Please Signoff all Candidate" ForeColor="Red" Font-Size="Small" Visible="false"></asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" />
                    </td>
                    <td colspan="2">

                        <asp:Label ID="lblInterviewCount" runat="server" Text="0" ForeColor="Red" Font-Size="Small"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Label1" runat="server" Text=" candidate needs to interview" ForeColor="Red" Font-Size="Small"></asp:Label>
                        <br />
                        <asp:Label ID="lblSignatureCount" runat="server" Text="0" ForeColor="Red" Font-Size="Small"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Label4" runat="server" Text=" interview needs to Signoff" ForeColor="Red" Font-Size="Small"></asp:Label>
                    </td>
                    <td colspan="3">
                        <div id="RecommendForHireDIV">
                            <asp:Button ID="btnSaveRecommendation" runat="server" Text="Recommend for Hire" Width="200px" Enabled="false" ToolTip="You must interview all candidate first and then chose one for recommend for Hire. " />
                        </div>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" />

                    </td>
                </tr>
                <tr id="HiredMessageRow" runat="server" visible="false">
                    <td style="text-align: right;">
                        <img id="HiredAlert" runat="server" src="../images/alert.gif" visible="false"/>
                    </td>
                    <td colspan="7">

                        <asp:Label ID="HiredMessage" runat="server" Text="Label" ForeColor="Red" Width="99%" Visible="false"></asp:Label>

                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="SingleParagraph" ForeColor="red" />

        </div>

        <asp:HiddenField ID="HiddenFieldAction" runat="server" Value="No" />
        <asp:HiddenField ID="hfUserCPNum" runat="server" />
        <asp:HiddenField ID="hfSchoolyear" runat="server" />
        <asp:HiddenField ID="hfSchoolname" runat="server" />
        <asp:HiddenField ID="hfIDs" runat="server" />
        <asp:HiddenField ID="hfPositionID" runat="server" />
        <asp:HiddenField ID="hfPrincipalName" runat="server" />
        <asp:HiddenField ID="hfPositionType" runat="server" />
        <asp:HiddenField ID="hfPositionTypeHired" runat="server" />
        <asp:HiddenField ID="hfHiredStatus" runat="server" />
        <asp:HiddenField ID="hfHiringtatus" runat="server" />
        <asp:HiddenField ID="hfTeacherUserID" runat="server" />
        <asp:HiddenField ID="hfHROwnerUserID" runat="server" />
        <asp:HiddenField ID="hfDatePublish" runat="server" />
        <asp:HiddenField ID="hfnewPositionStartDate" runat="server" />
        <asp:HiddenField ID="hfPositionHireStage" runat="server" />

        <div id="PopUpDIV3" style="visibility: hidden; position: absolute; left: 0px; top: 0px; width: 99%; height: 490px;">
            <img id="ImgHelp" runat="server" src="../images/InstructiontoPrincipal.png" height="487" />
        </div>
        <div id="PopUpDIV1" style="visibility: hidden; position: absolute; left: 120px; top: 150px; width: 450px; height: 250px; background-color: skyblue;">
            <table border="1" style="border-width: 2px; border-style: ridge; border-color: blue; width: 100%; height: 100%">
                <tr style="border-width: 1px; border-style: solid; border-color: blue;">
                    <td style="width: 85px;"></td>
                    <td><b>Current Position</b></td>
                    <td><b>Hired Position</b></td>
                </tr>
                <tr>
                    <td><b>Title </b></td>
                    <td>
                        <asp:Label ID="LabelPositionTitleC" runat="server" Text=""></asp:Label></td>
                    <td>
                        <asp:Label ID="LabelPositionTitleH" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td><b>School </b></td>
                    <td>
                        <asp:Label ID="LabelPositionSchoolC" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LabelPositionSchoolH" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td><b>Start date</b></td>
                    <td>
                        <asp:Label ID="LabelPositionStartDateC" runat="server" Text=""></asp:Label></td>
                    <td>
                        <asp:Label ID="LabelPositionStartDateH" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td><b>End date</b> </td>
                    <td>
                        <asp:Label ID="LabelPositionEndDateC" runat="server" Text=""></asp:Label></td>
                    <td>
                        <asp:Label ID="LabelPositionEndDateH" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td><b>Position FTE</b></td>
                    <td>
                        <asp:Label ID="LabelPositionFTEC" runat="server" Text=""></asp:Label></td>
                    <td>
                        <asp:Label ID="LabelPositionFTEH" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td><b>Position Type </b></td>
                    <td>
                        <asp:Label ID="LabelPositionTypeC" runat="server" Text=""></asp:Label></td>
                    <td>
                        <asp:Label ID="LabelPositionTypeH" runat="server" Text=""></asp:Label></td>
                </tr>
            </table>
        </div>
        <div id="PopUpDIV4" style="visibility: hidden; font-family: Arial; font-size: small; color: red; border: 2px solid blue; position: absolute; left: 114px; top: 150px; width: 580px; height: 270px; background-color: skyblue;">
            You have indicated that this applicant is Unsuccessful interview!
            <br />
            Please provide detailed notes as to why the candidate is Unsuccessful before we can proceed.  
            <br />
            Unsuccessful comments:
              <asp:TextBox ID="txtComments" runat="server" Height="190px" TextMode="MultiLine" Width="570px" BackColor="#ffffcc" CssClass="textboxF"></asp:TextBox>

        </div>
        <div id="PopUpHelp" style="display: none; background-color: papayawhip; position: absolute; border: 2px solid blue; font-family: Arial; font-size: medium; color: red;">
            In order to complete the Recommend for Hire
              <ul>

                  <li>Select an Interview Outcome and click on
                      <br />
                      Save button.</li>
                  <li>Complete all candidate Interview Outcome.</li>
                  <li>Recommend for Hire button will enable once all candidate's Interview Outcome inputed.</li>
                  <li>Must input the 
                       <asp:Label ID="LabelAppType" runat="server" Text="LTO/POP"></asp:Label>
                      Start Date when you make the recommend for Hire.</li>
                  <li>Click on the Recommend for Hire button.</li>
              </ul>
        </div>
    </form>
</body>
</html>

<script src="../JQuery-UI/jquery-ui-1.11.4.min.js" type="text/javascript"></script>
<link href="../JQuery-UI/jquery-ui.css" rel="stylesheet" type="text/css" />
<script src="../Scripts/CommonDOM.js" type="text/javascript"></script>

<script type="text/jscript">


    $(document).ready(function () {
        InitialDatePickerControl();
        if ($("#chbSignatureSignOff").prop('checked') === true) {
            $("#signOffChb").css("color", "green");
        }
        $(window).unload(function () {
            //   var myaction = document.getElementById("HiddenFieldAction").value;
            window.returnValue = $("#HiddenFieldAction").val();
        });

        $("#btnCancel").click(function (e) {
            try {
                CallBackReloadParent("", "", "")
                return false;
            }
            catch (e) {
            }
        });

        if ($("#lblPositionStatus").text() == "Hired") {
            window.alert("The Current Position hire process has completed");
        }
        if ($("#lblPositionStatus").text() == "End") {
            window.alert("The Current Position hiring process has been ended without hire. " + "\n\n" + "The Assignment Start Date was " +  $("#LabelPositionStartDateC").text() + ". The hiring process has ended one month late by the system automatically!" );
        }
        if ($("#hfHiringtatus").val() != "") {
            window.alert("The Candidate current Hiring Status is: " + "\n\n" + $("#hfHiringtatus").val());
        }
        $('#dateEffective_xx').change(function () {
            var effectiveDate = $("#dateEffective").val();
            var lastPositionEnddate = $("#LabelPositionEndDateH").text();
            try {
                if (effectiveDate > lastPositionEnddate) {
                    $('#chbHiring').removeAttr("disabled");
                }
                else {
                    $('#chbHiring').attr("disabled", true);
                }
            }
            catch (e) { $('#chbHiring').removeAttr("disabled"); }
        });

        $("#helpPrincipal").click(function (e) {
            var vTop = $('#helpPrincipal').offset().top - 230;  // ev.clientY - 20;
            var vLeft = $('#helpPrincipal').offset().left - 390;  //ev.clientX - 190;
            var vHeight = 200;
            var vWidth = 385;
            POPHelp(vTop, vLeft, vHeight, vWidth)
        });
        $("#ImgHelp").click(function (e) {
            POPHelp(vTop, vLeft, vHeight, vWidth)
        });

        $("#HiredAlert").mouseover(function () {
            // POPPositionHired();
        });
        $("#HiredAlert").mouseout(function () {
            // POPPositionHired();
        });
        $("#RecommendForHireDIV").mouseover(function () {
            var iCount = $("#lblInterviewCount").text();

            if (iCount !== "0") {
                window.alert("Please complete all interview candidate and then chose one for recommend for Hire.");
            }
        });
        $("#interviewPackage").click(function (e) {
            var yID = $("#hfSchoolyear").val();
            var cpnum = $("#hfUserCPNum").val();
            var pID = $("#hfPositionID").val();
            var printPage = "../PDFLoading/PDFDocument_Loading.aspx?rID=InterviewPackage" + "&yID=" + yID + "&CPNum=" + cpnum + "&pID=" + pID;
            var popup1 = window.open(printPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=800,height=600,top=0,left=0");

        });

        $("#btnSaveRecommendation").click(function (e) {
            var startdate = $("#dateEffective").val();
            if (startdate == "") {
                window.alert("Please input the Start Date !");
                e.preventDefault();
                return false;
            }
            else {
                $("#hdChildFormAction", parent.document).val("ChangeAction");
                var hireMsg = $("#HiredMessage").val();
                try {
                    if (hireMsg.length > 10) {
                        var result = confirm("The Candidate has accepted other offer. Do you want to continue?");
                        if (result) {
                            return true;
                        }
                        else {
                            e.preventDefault();
                            return false;
                        }
                    }
                }
                catch (ex) {
                }
            }
        });

        $('#ddlAction').change(function (e) {
            if ($('#ddlAction').val() == "5")          //5-'Not Suitable'
            {
                // window.alert("You have indicated that this applicant is unsuitable. " + "\n" + "Please Provide detailed notes as to why the candidate is unsuitable before we can proceed");
                POPUnsuitableComment();
            }

        });
    });
    function InitialDatePickerControl() {
        JDatePicker.Initial($("#dateInterview"));
        JDatePicker.Initial($("#dateEffective"));
    }

    function openLTOAppraisal(schoolyear, schoolcode, SessionID, TeacherID) {
        var printPage = "../PDFLoading/PDFDocument_Loading.aspx?rID=InterviewPackage" + "&yID=" + schoolyear + "&CPNum=" + TeacherID + "&pID=" + SessionID;
        var popup1 = window.open(printPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=800,height=600,top=0,left=0");
    }
    function POPHelp(vTop, vLeft, vHeight, vWidth) {
        $("#PopUpHelp").css({
            top: vTop,
            left: vLeft,
            height: vHeight,
            width: vWidth
        })
        $("#PopUpHelp").fadeToggle("fast");//.show();// 
    }
    function POPPositionHired() {
        el = document.getElementById("PopUpDIV1");
        el.style.visibility = (el.style.visibility == "visible") ? "hidden" : "visible";
        DisableAction = '0';
    }
    function POPUnsuitableComment() {
        el = document.getElementById("PopUpDIV4");
        el.style.visibility = (el.style.visibility == "visible") ? "hidden" : "visible";
        DisableAction = '0';
    }
     function openResumeCoverLetter(type, schoolYear, ids, cpNum, positionID, grantView) {
        if (grantView.toUpperCase() == "X") {
            var goPage = "../LTOTeachers/FileShow.aspx?Type=" + type + "&IDs=" + ids + "&CPNum=" + cpNum + "&PositionID=" + positionID + "&SchoolYear=" + schoolYear;
            window.open(goPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,width=700 height=500, top=50, left=50");
        }
        else
            window.alert("Teacher did not grant the view permission to admin staff.");
    }
  
</script>
