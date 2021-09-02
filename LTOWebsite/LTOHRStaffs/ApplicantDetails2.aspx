<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ApplicantDetails2.aspx.vb" Inherits="ApplicantDetails2" EnableTheming="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Select for interview   </title>
    <base target="_self" />
    <meta http-equiv="Pragma" content="No-cache" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <link href="../Styles/DetailsPage.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        body {
            height: 100%;
            width: 99%;
        }

        td {
            font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
            font-size: x-small;
        }
        .midtitle {
            text-wrap:avoid;
        }
    </style>

  
    <script type="text/jscript">

        function CallBackReloadParent(action, message) {
            try {
                window.alert(message);
                $("#hdChildFormAction", parent.parent.document).val(action);
                $("#PopUpDIV", parent.parent.document).fadeToggle("fast");
                $("#PositionDetailDIV", parent.parent.document).fadeToggle("slow");
                window.parent.frames["mainTop"].frames["ApplicantList"].document.location.reload();

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

            <table>
                <tr>
                    <td> <asp:Label ID ="lblPostingNumber" runat="server" Text ="Posting Number:">   </asp:Label>  </td>
                    <td>
                        <asp:TextBox ID="TextPositionID" runat="server" BackColor="Transparent" Width="100px" CssClass="editcellLock"></asp:TextBox>


                    </td>
                    <td class="midtitle">Status:</td>
                    <td>
                        <asp:TextBox ID="TextStatus" runat="server" BackColor="Transparent" Height="18px" Width="60px" CssClass="editcellLock"></asp:TextBox>
                    </td>
                    <td class="midtitle">School Area:</td>
                    <td>
                        <asp:TextBox ID="TextArea" runat="server" BackColor="Transparent" Height="20px" Width="120px" CssClass="editcellLock"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>School:</td>
                    <td colspan="5">

                        <asp:TextBox ID="TextSchool" runat="server" Height="20px" Width="99%" BackColor="Transparent" CssClass="editcellLock"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>Teacher Name:</td>
                    <td colspan="2">
                        <asp:TextBox ID="TextTeacherName" runat="server" Height="20px" Width="200px" BackColor="Transparent" Font-Bold="true" CssClass="editcellLock"></asp:TextBox>

                        &nbsp;</td>
                    <td class="midtitle" colspan="2">Apply
                         
                        Date: </td>

                    <td>
                        <asp:TextBox ID="TextApplyDate" runat="server" BackColor="Transparent" Width="99%" CssClass="editcellLock"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Date of Hired:</td>
                    <td>
                        <asp:TextBox ID="TextHiredDate" runat="server" Height="20px" Width="100px" BackColor="Transparent" CssClass="editcellLock"></asp:TextBox>

                    </td>
                    <td class="midtitle">LTO Years/ Months: </td>
                    <td>
                        <asp:TextBox ID="TextLTOYears" runat="server" Height="20px" Width="100px" BackColor="Transparent" CssClass="editcellLock"></asp:TextBox>
                    </td>
                    <td class="midtitle">OT Days:</td>
                    <td>
                        <asp:TextBox ID="TextLTODays" runat="server" Height="20px" Width="99%" BackColor="Transparent" CssClass="editcellLock"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Position Title</td>
                    <td colspan="5">
                        <asp:TextBox ID="TextPositionTitle" runat="server" Height="20px" Width="99%" BackColor="Transparent" CssClass="editcellLock"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Teacher Qualification</td>
                    <td colspan="5">
                        <div id="TextQualification" runat="server" style="width: 99%; height: 60px; background-color: transparent; border-style: inset; border-width: thin">
                        </div>

                    </td>
                </tr>
                <tr>
                    <td>Teacher Appraisal:</td>
                    <td colspan="5">
                        <div id="TextAppraisal" runat="server" style="overflow: auto; display: block; width: 99%; height: 60px; background-color: transparent; border-style: inset; border-width: thin">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>Teacher Comments:</td>
                    <td colspan="5">
                        <div id="TextComments" runat="server" style="overflow: auto; display: block; width: 99%; height: 60px; background-color: transparent; border-style: inset; border-width: thin">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>Other Position Applied:</td>
                    <td colspan="5">
                        <div id="TextOtherPositionApply" runat="server" style="overflow: auto; display: block; width: 99%; height: 60px; background-color: transparent; border-style: inset; border-width: thin">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>Interview Candidate Selected:</td>
                    <td colspan="5">
                        <div id="TextInterviewSelected" runat="server" style="overflow: auto; display: block; width: 99%; height: 60px; background-color: transparent; border-style: inset; border-width: thin">
                        </div>
                    </td>
                </tr>
                <tr id="HiredMessageRow" runat="server" visible="false">
                    <td align="right">
                        <img id="HiredAlert" runat="server" src="../images/alert.gif" visible="false" /></td>
                    <td colspan="5">

                        <asp:Label ID="HiredMessage" runat="server" Text="Label" ForeColor="Red" Width="100%" Visible="false"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td style="color: red; font-weight: 400;">Acceptance for interview:</td>
                    <td colspan="2">
                        <asp:CheckBox ID="chbInterview" runat="server" Enabled="false" />

                    </td>
                    <td style="text-align: right;">Resume Attached</td>

                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:HiddenField ID="HiddenFieldApply" runat="server" />
                        <br />
                    </td>
                </tr>
                <tr>

                    <td colspan="6" style="text-align: center;">

                        <asp:Button ID="btnApply" runat="server" Text="Select for Interview" /><asp:HiddenField ID="HiddenFieldAction" runat="server" Value="No" />
                    </td>

                </tr>
            </table>
        </div>
        <div id="PopUpDIVAttentionMessage" style="visibility: hidden; position: absolute; left: 140px; top: 200px; width: 400px; height: 250px; background-color: skyblue; color: red; border: solid; border-color: blue; border-width: thin">
            <div style="text-align: right; font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif">
                <asp:Label ID="lblMessage" runat="server" Text="X" Font-Size="Medium" ToolTip="Close this Message"></asp:Label>

            </div>
            <div>
                According to our records, the teacher that you are selecting is currently in an LTO and is not eligible to apply for this assignment.  
               
                <br />
                <br />

                <table style="border-style: solid; border-width: 1px; width: 100%;">
                    <tr>
                        <td colspan="4" style="text-align: center;">
                            <b>Current Assignment </b>
                        </td>
                    </tr>
                    <tr>
                        <td>School:</td>
                        <td colspan="3">
                            <asp:Label ID="LabelcurrentAssignmentSchool" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Assignment:</td>
                        <td colspan="3">
                            <asp:Label ID="LabelcurrentAssignment" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Start Date:</td>
                        <td>
                            <asp:Label ID="LabelCurrentAssignmentStartDate" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hfPositionStartDate" runat="server" />
                        </td>
                        <td>End Date:</td>
                        <td>
                            <asp:Label ID="LabelCurrentAssignmentEndDate" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hfPositionEndDate" runat="server" />
                            <asp:HiddenField ID="hfPositionType" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center;">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center;">
                            <b>Select for Interview Position </b>
                        </td>
                    </tr>
                    <tr>
                        <td>School:</td>
                        <td colspan="3">
                            <asp:Label ID="LabelApplySchool" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Assignment:</td>
                        <td colspan="3">
                            <asp:Label ID="LabelApplyAssignment" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Start Date:</td>
                        <td>
                            <asp:Label ID="LabelApplyAssignmentStartDate" runat="server" Text=""></asp:Label>

                        </td>
                        <td>End Date:</td>
                        <td>
                            <asp:Label ID="LabelApplyAssignmentEndDate" runat="server" Text=""></asp:Label>

                        </td>
                    </tr>
                </table>


            </div>
        </div>
    </form>
</body>
</html>


<script type="text/jscript">

    $(document).ready(function () {
        $(window).unload(function () {
            window.returnValue = $("#HiddenFieldAction").val();
        });

        $("#btnApply").click(function (e) {
            $("#hdChildFormAction", parent.document).val("ChangeAction");
        });
        

        if ($("#hfPositionType").val() == "LTO" && $("#btnApply").val() == "Select for Interview") {
            CheckCurrentAssignment();
        }
        $("#lblMessage").click(function (e) {
            if ($("#hfPositionType").val() == "LTO" && $("#btnApply").val() == "Select for Interview") {
                POPMessage();
            }
        });


    });
    function POPMessage() {
        el = document.getElementById("PopUpDIVAttentionMessage");
        el.style.visibility = (el.style.visibility == "visible") ? "hidden" : "visible";
        DisableAction = '0';
    }

    function CheckCurrentAssignment() {

        var ApplyPosition = {
            StartDate: $("#hfPositionStartDate").val(),
            EndDate: $("#hfPositionEndDate").val()
        };
        var CurrentPosition =
          {
              StartDate: $("#LabelCurrentAssignmentStartDate").text(),
              EndDate: $("#LabelCurrentAssignmentEndDate").text(),
              Assignment: $("#LabelcurrentAssignment").text()
          };

        if (CurrentPosition.Assignment != "") {
            if (CurrentPosition.EndDate > ApplyPosition.StartDate) {
                POPMessage();
            }
        }



    }

    function openLTOAppraisal(schoolyear, schoolcode, SessionID, TeacherID) {
        var printPage = "../PDFLoading/PDFDocument_Loading.aspx?rID=InterviewPackage" + "&yID=" + schoolyear + "&CPNum=" + TeacherID + "&pID=" + SessionID;
        var popup1 = window.open(printPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=800,height=600,top=0,left=0");
    }


</script>
