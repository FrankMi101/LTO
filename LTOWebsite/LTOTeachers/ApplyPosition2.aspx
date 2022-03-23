<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ApplyPosition2.aspx.vb" Inherits="ApplyPosition2" Debug="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Apply Position</title>
    <base target="_self" />
    <meta http-equiv="Pragma" content="No-cache" />
    <link href="../Styles/DetailsPage.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        body {
            height: 100%;
            width: 100%;
            margin:2px;
        }

        td {
            font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif;
            font-size: 12px;
        }

        img {
            margin-bottom: -5px;
        }

        #LabelUploadFile > a {
            margin-left:10px;
            font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif;
         /*   border: 1px solid #bbb9b9;*/
            font-style: normal;
            font-size: 13px;
         /*   background-color: transparent  ;*/
            height: 25px;
            padding-right: 20px;
            padding-top: 3px;
            padding-bottom: 2px;
          /*  border-radius: 7px;*/
        }

        #btnRow input:hover {
            cursor: pointer;
            text-decoration: underline;
            color: blue;
        }

        
        #ResumePrompt {
            font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif;
            font-size: 12px;
        }

        .highlightButton {
            font-weight: 600;
            color: green;
        }

        .readonlytext {
            border: 1px solid #808080
        }
    </style>
    <link href="../Styles/DetailsPage.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        function CallReloadParent(action, positionTitle, strMessage) {
            try {

                $("#hdChildFormAction", parent.document).val(action);

                if (action == "" || action == "Update Apply Info") {
                    $("#PopUpDIV", parent.document).fadeToggle("fast");
                    $("#PositionDetailDIV", parent.document).fadeToggle("fast");
                }
                else {
                    window.alert(action + " " + positionTitle + " position is " + strMessage + ", and a confirmation email has been sent to you. ");
                    $("#PopUpDIV", parent.document).fadeToggle("fast");
                    $("#PositionDetailDIV", parent.document).fadeToggle("fast");
                    //  window.parent.document.location.reload();
                    // window.parent.frames["mainTop"].document.location.reload();
                    $("#mainTop", parent.parent.document).attr('src', "LTOTeachers/ApplyPositionList2.aspx");
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
        <div style="background-image: url(../images/message_body_m.bmp)">
            <div style="width: 99%; border-color: skyblue; border-width: 1px; border-style: outset">


                <div style="font-family: Arial; font-size: small; color: darkred">
                    <b>Barrier-Free Recruitment and Selection  </b>
                </div>
                <div style="font-family: Arial; font-size: small; color: darkred;">
                    The TCDSB is committed to creating an inclusive, barrier-free recruitment and selection process.  
                  Please inform the Human Resources department, at the time of your application, 
                  of any requirement for accommodation in order for us to assess all candidates in a 
                  fair and equitable manner. Documentation to support the accommodation may be requested 
                  as required prior to the implementation of the accommodation measures. 

                </div>
            </div>
            <table style="font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif; font-size: small; height: 100%; width: 99%; border: 0px solid red">

                <tr>
                    <td>
                        <asp:Label ID="lblPostingNumber" runat="server">Posting Number: </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextPositionID" runat="server" BackColor="Transparent" Width="80px" CssClass="readonlytext"></asp:TextBox>


                    </td>
                    <td class="midtitle">Status:</td>
                    <td>
                        <asp:TextBox ID="TextStatus" runat="server" BackColor="Transparent" Height="18px" Width="60px" CssClass="readonlytext"></asp:TextBox>

                    </td>
                    <td class="midtitle">School Area:</td>
                    <td>
                        <asp:TextBox ID="TextArea" runat="server" BackColor="Transparent" Height="20px" Width="120px" CssClass="readonlytext"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>School:</td>
                    <td colspan="5">
                        <asp:TextBox ID="TextSchool" runat="server" Height="20px" Width="100%" BackColor="Transparent" CssClass="readonlytext"></asp:TextBox>

                        <%--  <img src="../images/map.png" height="25px" width="25px" />--%>

                    </td>
                </tr>
                <tr>
                    <td>Address:</td>
                    <td colspan="5">
                        <asp:TextBox ID="TextAddress" runat="server" Height="20px" Width="100%" BackColor="Transparent" CssClass="readonlytext"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>School Principal:</td>
                    <td>
                        <asp:TextBox ID="textPrincipal" runat="server" Height="20px" Width="100px" BackColor="Transparent" CssClass="readonlytext"></asp:TextBox></td>
                    <td class="midtitle" style="width: 120px;">Phone Number:</td>
                    <td>
                        <asp:TextBox ID="textPhonenumber" runat="server" Height="20px" Width="100px" BackColor="Transparent" CssClass="readonlytext"></asp:TextBox>
                    </td>
                    <td class="midtitle">Start Time:</td>
                    <td>
                        <asp:TextBox ID="TextStartTime" runat="server" Height="20px" Width="70px" BackColor="Transparent" CssClass="readonlytext"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Position Title</td>
                    <td colspan="5">
                        <asp:TextBox ID="TextPositionTitle" runat="server" Height="20px" Width="65%" BackColor="Transparent" CssClass="readonlytext"></asp:TextBox>
                        Panel:
                        <asp:TextBox ID="TextPanel" runat="server" Height="20px" Width="60px" BackColor="Transparent" CssClass="readonlytext"></asp:TextBox>
                        FTE:
                        <asp:TextBox ID="TextFTE" runat="server" Height="20px" Width="50px" BackColor="Transparent" CssClass="readonlytext"></asp:TextBox>
                    </td>
                </tr>
                <tr style="border: 2px solid darkcyan;">
                    <td colspan="6" style="width: 100%; font-size: 1.3em; background-color: darkcyan; color: yellow; text-align: center;">Position Required Qualification  </td>
                </tr>
                <tr>
                    <td colspan="6" style="border: 2px solid darkcyan;">

                        <table style="width: 99.3%;">

                            <tr>
                                <td>Mandatory Qualification:

                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="TextPostionLevel" runat="server" Height="20px" Width="100%" BackColor="Transparent" CssClass="readonlytext"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td style="width: 44%">Minimum Qualification</td>
                                <td style="width: 44%">OCT Qualification</td>
                            </tr>
                            <tr>
                                <td>Division and Qualification:
                                </td>
                                <td>
                                    <asp:TextBox ID="TextPostionQualification" runat="server" Height="80px" TextMode="MultiLine" Width="100%" BackColor="Transparent" ReadOnly="true" CssClass="readonlytext"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextApplicantQualfication" runat="server" Height="80px" TextMode="MultiLine" Width="100%" BackColor="Transparent" ReadOnly="true" CssClass="readonlytext"></asp:TextBox>
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>


                <tr id="OnBehalfRom" runat="server" visible="false">
                    <td>Applicant: </td>
                    <td colspan="5">
                        <div id="OnBehalf" style="width: 100%;">

                            <asp:DropDownList ID="ddlApplicant" runat="server" Width="200px" Height="25px"></asp:DropDownList>
                            <asp:Button ID="btnApplyOnBehalf" runat="server" Text="Apply" />
                            <asp:Label ID="LabelApplicant" runat="server" Text=""></asp:Label>
                        </div>
                    </td>

                </tr>
                <tr>
                    <td>Position Description:
                          
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="TextPositionDescription" runat="server" Height="45px" TextMode="MultiLine" Width="100%" BackColor="Transparent" ReadOnly="true"></asp:TextBox>
                        <div id="F100TimeTable" runat="Server"></div>
                        <div id="F100MultipleSchool" runat="Server"></div>
                    </td>
                </tr>


                <tr>
                    <td>Deadline to Apply:</td>
                    <td colspan="5">
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="TextApplyEndDate" runat="server" BackColor="Transparent" Width="70px" CssClass="readonlytext"></asp:TextBox>
                                </td>
                                <td class="midtitle" style="width: 90px;">Start Date:</td>
                                <td>
                                    <asp:TextBox ID="TextStartDate" runat="server" BackColor="Transparent" Width="70px" CssClass="readonlytext"></asp:TextBox></td>
                                <td class="midtitle" style="width: 90px;">End Date:</td>
                                <td>
                                    <asp:TextBox ID="TextEndDate" runat="server" BackColor="Transparent" Width="70px" CssClass="readonlytext"></asp:TextBox></td>
                                <td class="midtitle" style="width: 90px;">
                                    <asp:Label ID="LabelApplyDate" runat="server" Text="Apply Date:"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="TextApplyDate" runat="server" BackColor="Transparent" Width="70px" CssClass="readonlytext"></asp:TextBox></td>
                                <td class="midtitle" style="width: 120px;">Posting Round: </td>
                                <td>
                                    <asp:TextBox ID="TextPostingCycle" runat="server" BackColor="Transparent" Width="50px" CssClass="readonlytext"></asp:TextBox>
                                </td>
                            </tr>

                        </table>
                    </td>

                </tr>

                <tr>
                    <td>Comments:</td>
                    <td colspan="5">
                        <asp:TextBox ID="TextComemnts" runat="server" Height="40px" TextMode="MultiLine" Width="100%" BackColor="#ffffcc" CssClass="readonlytext Edit-Content-Control"></asp:TextBox></td>
                </tr>
                <tr style="border: 2px solid darkgrey;">
                    <td colspan="6">
                        <table style ="width:100%">
                            <tr>
                                <td style=" text-wrap: avoid">Home Phone:</td>
                                <td>
                                    <asp:TextBox ID="TextHomePhone" runat="server" BackColor="#ffffcc" Width="100px" CssClass="readonlytext Edit-Content-Control"></asp:TextBox></td>
                                <td style=" text-wrap: avoid" class="midtitle">Cell Phone:</td>
                                <td>
                                    <asp:TextBox ID="TextCellPhone" runat="server" BackColor="#ffffcc" Width="100px" CssClass="readonlytext Edit-Content-Control"></asp:TextBox>
                                </td>
                                <td style="text-align: right">Email:</td>
                                <td style=" text-wrap: avoid" >
                                    <asp:TextBox ID="TexteMail" runat="server"   Width="200px" ReadOnly="true" CssClass="readonlytext"></asp:TextBox>
                                    @tcdsb.org
                                </td>
                               
                                <td style="width:10%">
                                 <asp:Button ID="btnUpdate" runat="server" Text="Update Contact Info" CssClass="cursorDefault action-button" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: center;">
                        <asp:HiddenField ID="HiddenFieldApply" runat="server" />
                        <asp:HiddenField ID="hfTeacherName" runat="server" />
                        <asp:HiddenField ID="hfPositionType" runat="server" />

                        <asp:HiddenField ID="hfPositionID" runat="server" />
                        <asp:HiddenField ID="HiddenFieldAction" runat="server" Value="No" />
                        <asp:HiddenField ID="hfSchoolyear" runat="server" />
                        <asp:HiddenField ID="hfCPNum" runat="server" />
                        <asp:HiddenField ID="hfFTEPosition" runat="server" />
                        <asp:HiddenField ID="hfFTECurrent" runat="server" />
                        <asp:HiddenField ID="hfQualificationCheck" runat="server" />
                        <asp:HiddenField ID="hfPostedDate" runat="server" />
                        <asp:HiddenField ID="hfPostingcomments" runat="server" />
                        <asp:HiddenField ID="hfPostingcycle" runat="server" />
                        <asp:HiddenField ID="hfResumeTitle" runat="server" />
                        <asp:HiddenField ID="hfUsingMostRecentResume" runat="server" />
                    </td>
                </tr>
                <%--  <tr id="updateinformationRow" runat="server">
                    <td colspan="6">
                        <asp:CheckBox ID="CheckBox1" runat="server" Visible="false" ForeColor="Red" Text="Update your contact information to all your applied positions" AutoPostBack="true" /></td>
                </tr>--%>
                <tr>

                    <td colspan="6" style="text-align: center;" id="btnRow">



                        <asp:Button ID="btnApply" runat="server" Text="Apply Position"  CssClass="action-button"  />
                         
                        <asp:Label ID="LabelNotQualifyRoster" runat="server" Text="Roster only allow to apply 3rd Round Posting" ForeColor="Red" Font-Bold="true" Visible="false"></asp:Label>
                        <asp:Label ID="LabelNotQualify" runat="server" Text="Only qualified applicant can apply this position" ForeColor="Red" Font-Bold="true" Visible="false"></asp:Label>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="100"  CssClass="action-button" />

                        <a id="onBehalfApply" runat="server" visible="false"  class="action-button"  >Apply on Behalf </a>
                       &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="LabelUploadFile" runat="server" Text="Label" CssClass="action-button"  Height="22px"></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td colspan="6"></td>
                </tr>
            </table>
        </div>
        <div id="InActiveMessage" style="visibility: hidden; position: absolute; left: 140px; top: 200px; width: 400px; height: 150px; background-color: skyblue; color: red; border: solid; border-color: blue; border-width: thin">
            <div style="text-align: right; font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif">
                <asp:Label ID="Label1" runat="server" Text="X" Font-Size="Medium" ToolTip="Close this Message"></asp:Label>

            </div>
            <div>

                <b>Attention: Occasional Teacher </b>
                <br />
                According to our records, your employee status is currently on a leave of absence. 
               <%-- and therefore your are currently not eligible to apply. -- remove at 2021-8-27 Request by Mary  --%>

                <asp:Label ID="LabelMessageStatus1" Font-Bold="true" runat="server" Visible="false"></asp:Label>

                Please reach out to your HR Contact for more information or to reactivate your file
                <a href="anna.arona@tcdsb.org">anna.arona@tcdsb.org </a>or Mary Bertolo at <a href="mary.bertolo@tcdsb.org">mary.bertolo@tcdsb.org</a>

                <br />
                <br />

            </div>
        </div>
        <div id="PopUpDIVAttentionMessage" style="visibility: hidden; position: absolute; left: 140px; top: 200px; width: 480px; height: 220px; background-color: skyblue; color: red; border: solid; border-color: blue; border-width: thin">
            <div style="text-align: right; font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif">
                <asp:Label ID="lblMessage" runat="server" Text="X" Font-Size="Medium" ToolTip="Close this Message"></asp:Label>

            </div>
            <div>

                <b>Attention: Occasional Teacher </b>
                <br />
                According to our records, your current employee status does not allow you to apply to this assignment as it will exceed your full time allocation.  
                 <asp:Label ID="LabelMessageStatus2" Font-Bold="true" runat="server" Visible="false"></asp:Label>.  
                Please reach out to your HR Contact for more information.
                <a href="anna.arona@tcdsb.org">anna.arona@tcdsb.org </a>or Mary Bertolo at <a href="mary.bertolo@tcdsb.org">mary.bertolo@tcdsb.org</a>

                <br />
                <br />

                <table style="border-style: solid; border-width: 1px; width: 100%;">
                    <tr>
                        <td colspan="4" style="text-align: center;">
                            <h5>Current Assignment </h5>
                        </td>
                    </tr>
                    <tr>
                        <td>School:</td>
                        <td colspan="3">
                            <asp:Label ID="LabelcurrentAssignmentSchool" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Assignment:</td>
                        <td colspan="2">
                            <asp:Label ID="LabelcurrentAssignment" runat="server" Text=""></asp:Label></td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblCurrentFTE" runat="server" Text="">     </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%;">Start Date:</td>
                        <td style="width: 40%;">
                            <asp:Label ID="LabelCurrentAssignmentStartDate" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="width: 25%; text-align: right;">End Date:</td>
                        <td style="width: 15%;">
                            <asp:Label ID="LabelCurrentAssignmentEndDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>

            </div>
        </div>

        <div id="ResumeCoverLetterDIV" class="bubble hide" style="width: 99%; background-color:aliceblue ">
            <div style="height: 22px; margin-top: -2px; background-color: deepskyblue; width: 100%;">
                <table style="vertical-align: top;">
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <div id="popPagetitle" runat="server" style="font-size: medium">Upload Resume and Cover Letter </div>
                        </td>
                        <td>
                            <asp:HiddenField ID="hdChildFormAction" runat="server" Value="NoAction" />
                            <asp:HiddenField ID="hfInvokePageFrom" runat="server" Value="" />
                            <asp:HiddenField ID="hfUserRole" runat="server" Value="" />
                            <asp:HiddenField ID="hfStatus" runat="server" Value="" />
                        </td>
                        <td style="text-align: right">
                            <a id="CloseMeLink" runat="server" href="#" style="text-align: right;">
                                <img style="height: 20px; width: 20px;" src="../images/Close1.bmp" alt="" title="Close Me" />
                            </a></td>
                    </tr>
                </table>
            </div>
            <div style="height: 350px">
                <iframe id="ResumeCoverLetteriFrame" runat="server" name="ResumeCoverLetteriFrame" scrolling="no" seamless="seamless" style="height: 95%; width: 100%; border: 0px blue solid"
                    src=""></iframe>
            </div>
        </div>
        <div id="ResumePrompt" class="bubble hide" style="height: 200px; width: 99%; font-family: Arial; font-size: 14px; background-color:aliceblue">
            You have not submitted a Resume and Cover Letter for this Position yet.
            <br />
            <br />
            Please select to continue. 

                  <asp:RadioButtonList ID="rblResumeChose" runat="server" Font-Size="Small">
                      <asp:ListItem Value="1">Continue Apply without the Resume and Cover Letter</asp:ListItem>
                      <asp:ListItem Value="2">Go to upload the Resume and Cover Letter</asp:ListItem>
                      <asp:ListItem Value="3">Using my most recent upload Resume and Cover Letter</asp:ListItem>
                  </asp:RadioButtonList>
            <br />
            <div style="width: 100%; text-align: center">
                <input id="btnContinue" type="button" value="Continue" />
            </div>

        </div>


    </form>
</body>
</html>



<script type="text/jscript">
    var parameter = {
        "SchoolYear": $("#hfSchoolyear").val(),
        "CPNum": $("#hfCPNum").val(),
        "PositionID": $("#hfPositionID").val()
    };
    $(document).ready(function () {

        $("#hdChildFormAction", parent.document).val("NoAction");
        $("#btnContinue").prop('disabled', true);
        if ($("#hfPositionType").val() == "LTO" && $("#btnApply").val() == "Apply Position") {
            if ($("#hfStatus").val() != "Active") {
                if ($("#hfStatus").val() == "FTE Exceed") {
                    CheckCurrentAssignment();
                }
                else
                    POPMessage("InActiveMessage");
            }
        }
        $("#rblResumeChose input").click(function (e) {
            $("#btnContinue").prop('disabled', false);
            $("#btnContinue").addClass("highlightButton");
        });


        $("#btnApply").click(function (e) {
            var resumeTitle = $("#hfResumeTitle").val();
            var btnName = $("#btnApply").val();
            var mostRecent = $("#hfUsingMostRecentResume").val();
            if (resumeTitle == "" && btnName == "Apply Position" && mostRecent == "No") {

                openChosePromptWindow();
                return false;
                //var result = confirm("You do not submit a Resume and Cover Letter!" + "\n\r" + "Do you want to continue to apply for this position without submit Resume and Cover Letter?\n");

                //if (result) {
                //    $("#hdChildFormAction", parent.document).val("NoAction");
                //    return true;
                //}
                //else
                //    return false;
            }

            $("#hdChildFormAction", parent.document).val("NoAction");

        });


        $("#ddlApplicant").click(function (e) {

            $("#TextHomePhone").val("");

            $("#TextCellPhone").val("");

            $("#TexteMail").val("");
            $("#hdChildFormAction", parent.document).val("NoAction");

        });
        $("#onBehalfApply").click(function (e) {
            $("#OnBehalf").fadeToggle("slow");

        });

        $("#btnCancel").click(function (e) {
            try {
                CallReloadParent("", "", "");
                return false;
            }
            catch (e) {

            }
        });

        $("#lblMessage").click(function (e) {
            if ($("#hfPositionType").val() == "LTO" && $("#btnApply").val() == "Apply Position") {
                POPMessage("PopUpDIVAttentionMessage");
            }
        });

        $("#CloseMeLink").click(function (e) {

            $("#ResumeCoverLetterDIV").fadeToggle("fast");
            location.reload();
        })

        $("#btnContinue").click(function (e) {
            try {
                var chose = $("input:radio[name=rblResumeChose]:checked").val(); //  $("#rblResumeChose").val();

                switch (chose) {
                    case "1":
                        $("#hfUsingMostRecentResume").val("Continue");
                        $("#btnApply").click();
                        break;
                    case "2":
                        openFileUpload("", parameter.SchoolYear, parameter.CPNum, parameter.PositionID);
                        break;
                    case "3":
                        $("#hfUsingMostRecentResume").val("Yes");
                        $("#btnApply").click();
                        break;
                    default:
                        return true;
                }
                $("#ResumePrompt").fadeToggle("fast");
            } catch (e) {

            }

        })

        $("#rblResumeChose input").click(function (e) {
            try {
                var ev = window.event;
                var targetItem = ev.srcElement.id;
                var myItem = $("#" + targetItem);
                var selectedCode = myItem.val();

            } catch (e) {
            }

        });

        $(window).unload(function () {
            //   var myaction = document.getElementById("HiddenFieldAction").value;

            //try {
            //    window.returnValue = $("#HiddenFieldAction").val();

            //}
            //catch (e)
            //{ }

        });
    });


    function POPMessage(messageContent) {

        el = document.getElementById(messageContent);// "PopUpDIVAttentionMessage");

        el.style.visibility = (el.style.visibility == "visible") ? "hidden" : "visible";
        DisableAction = '0';
    }

    function CheckCurrentAssignment() {

        var ApplyPosition = {
            StartDate: $("#TextStartDate").val(),
            EndDate: $("#TextEndDate").val(),
            FTE: $("#hfFTEPosition").val()
        };
        //    var rPosition = getApplicatCurrentAssignmentStatus(ApplyPosition);

        var CurrentPosition =
        {
            StartDate: $("#LabelCurrentAssignmentStartDate").text(),
            EndDate: $("#LabelCurrentAssignmentEndDate").text(),
            FTE: $("#hfFTECurrent").val()
        };

        if (CurrentPosition.EndDate > ApplyPosition.StartDate) {
            var cFTE = parseFloat(CurrentPosition.FTE) + parseFloat(ApplyPosition.FTE);
            var aFTE = 1.0;
            if (cFTE > aFTE) {
                POPMessage("PopUpDIVAttentionMessage");
            }

        }


    }
    function openFileUpload(type, schoolyear, cpnum, positionID) {
        var vTop = 200;
        var vLeft = 100;
        var vHeight = 200;
        var vWidth = 600;
        var goPage = "FileUpload.aspx?CPNum=" + cpnum + "&PositionID=" + positionID;
        $("#ResumeCoverLetteriFrame").attr('src', goPage);
        $("#ResumeCoverLetterDIV").css({
            top: vTop,
            left: vLeft,
            height: vHeight,
            width: vWidth
        })
        $("#ResumeCoverLetterDIV").fadeToggle("fast");
    }

    function openChosePromptWindow() {

        var vTop = 300;
        var vLeft = 100;
        var vHeight = 180;
        var vWidth = 400;
        $("#ResumePrompt").css({
            top: vTop,
            left: vLeft,
            height: vHeight,
            width: vWidth
        })
        $("#ResumePrompt").fadeToggle("fast");
    }
    // Client Web API call
    /*
    function getApplicatCurrentAssignmentStatusWithAPI(applyP) {

        var CurrentPosition =
            {
                StartDate: "",
                EndDate: ""
            }

        var schoolyear = $("#hfSchoolyear").val();
        var cpnum = "00004167";// $("#hfCPNum").val();
        var servername = "http://webservice.tcdsb.org";
        var api = "/LTOapi/api/SAPLTO";
        var parameter = "?type=AllSAP&schoolyear=" + schoolyear + "&cpnum=" + cpnum;
        var httpLink = servername + api + parameter;
        jQuery.support.cors = true;
        $.ajax({
            url: httpLink,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                CurrentPosition.StartDate = data[0].StartDate;
                CurrentPosition.EndDate = data[0].EndDate;
                $("#LabelCurrentAssignmentStartDate").val(CurrentPosition.StartDate);
                $("#LabelCurrentAssignmentEndDate").val(CurrentPosition.EndDate);
                POPMessage();
            },
            error: function (ex) {
                alert(ex);
            }
        });
    }

    */
</script>
