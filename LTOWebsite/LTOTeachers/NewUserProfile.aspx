<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NewUserProfile.aspx.vb" Inherits="NewUserProfile" EnableTheming="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HR Confirm for Hire </title>
    <base target="_self" />
    <meta http-equiv="Pragma" content="No-cache" />
    <link href="../Styles/DetailsPage.css" rel="stylesheet" type="text/css" />
    <link href="../JQuery-UI/jquery-ui.css" rel="stylesheet" type="text/css" />

    <link href="../Content/bootstrap.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body {
            height: 100%;
            width: 100%;
            font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
            font-size: 14px;
        }

        .noWrap {
            text-wrap: avoid;
            width: 110px;
        }

        td {
            vertical-align: top;
            border: 1px solid silver;
            height: 25px;
        }

        .myButton {
            color: white;
            background-color: dodgerblue;
            border: 1px solid blue;
            border-radius: 8px;
        }

        .ImageButton {
            margin-bottom: -5px;
        }

        .ui-datepicker-trigger {
            margin-top: -7px;
        }
    </style>
    <script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="../JQuery-UI/jquery-ui-1.11.4.min.js" type="text/javascript"></script>

    <script type="text/javascript">

        function CallBackReloadParent(action, strMessage) {
            try {
                if (action != "") {
                    window.alert(action + " " + strMessage);
                    //  $("#hdChildFormAction", parent.document).val(action);
                    $("#PopUpDIV", parent.document).fadeToggle("fast");
                    $("#DetailDIV", parent.document).fadeToggle("fast");
                    $("#btnSearch", parent.document).click();

                    // window.parent.frames["mainTop"].document.location.reload();
                }
                else {
                    $("#PopUpDIV", parent.document).fadeToggle("fast");
                    $("#DetailDIV", parent.document).fadeToggle("fast");
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
        <div>

            <table style="width: 700px">
                <tr>
                    <td style="width: 10%">Teacher Name:
 
                    </td>
                    <td style="width: 25%">
                        <asp:Label ID="LabelTeacherName" runat="server" BackColor="Transparent" Width="100%"></asp:Label>

                    </td>
                    <td style="width: 10%">CPNum: </td>
                    <td style="width: 25%">
                        <asp:Label ID="LabelCPNum" runat="server" Width="100%"></asp:Label>

                    </td>
                    <td style="width: 10%">Status:</td>
                    <td style="width: 20%">
                        <asp:Label ID="LabelCurrentStatus" runat="server" Width="100%"></asp:Label></td>

                </tr>
                <tr class="editcell">
                    <td>Hire Date:</td>
                    <td>
                        <input runat="server" type="text" id="DateOfHire" size="9" class="editcell" />
                    </td>
                    <td>Ranking:</td>
                    <td colspan="2">
                        <asp:TextBox ID="TextRanking" runat="server" Width="60px" CssClass="editcell Edit-Content-Control"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     Lots:
                        <asp:TextBox ID="TextLots" runat="server" Width="50px" CssClass="editcell Edit-Content-Control"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnSaveRanking" runat="server" Text="Area Change Save " CssClass="myButton" />
                    </td>

                </tr>
                <tr>
                    <td>School Name:</td>
                    <td colspan="5">
                        <asp:Label ID="LabelSchoolName" runat="server" Width="100%"></asp:Label></td>
                </tr>
                <tr>
                    <td>OCT Qualification:</td>
                    <td colspan="5">
                        <asp:TextBox ID="LabelOCTQualification" runat="server" Height="150px" Width="100%" BackColor="Transparent" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr id="RowCommentsInfo" runat="server">
                    <td></td>
                    <td colspan="5" style="vertical-align: bottom; background-color: papayawhip;">Comments User: 
                        <div style="display: inline; width: 80%;">
                            <asp:Label ID="LabelCommentBy" runat="server" Width="100"> </asp:Label>
                            Comment Date:
                        <asp:Label ID="LabelCommentDate" runat="server" Width="110px">  </asp:Label>
                        </div>
                        <div style="display: inline; width: 200px; text-align: right">
                            <asp:Button ID="AddComment" runat="server" Text="Add New" Width="80px" CssClass="myButton" />
                            <asp:ImageButton ID="ImageButtonPrevious" CssClass="ImageButton" runat="server" ImageUrl="../images/moveup.gif" ToolTip="Previous Comments" />
                            <asp:Label ID="Labelcurrent" runat="server" Width="20px">0</asp:Label>
                            of 
                         <asp:Label ID="Labelrecords" runat="server" Width="20px">0</asp:Label>
                            <asp:ImageButton ID="ImageButtonNext" CssClass="ImageButton" runat="server" ImageUrl="../images/movedown.gif" ToolTip="Next/New Comments" />

                        </div>



                    </td>
                </tr>
                <tr id="RowComments" runat="server">
                    <td>HR Comments on Pending Applicant:</td>
                    <td colspan="5">


                        <asp:TextBox ID="TextHRComments" runat="server" Height="120px" Width="100%" CssClass="editcell Edit-Content-Control" TextMode="MultiLine"></asp:TextBox>



                    </td>

                </tr>





                <tr>
                    <td></td>
                    <td colspan="5" style="text-align: center;">
                        <asp:Button ID="btnTSL" runat="server" Text="Remove form TSL"  CssClass="myButton" />
                        <asp:Button ID="btnSave" runat="server" Text="Save " Width="100px" CssClass="myButton" />
                        <asp:Button ID="btnAction" runat="server" Text="Add To LTO List"  CssClass="myButton" />
                        <asp:Button ID="btnAction2" runat="server" Text="Change State"   Visible="false" CssClass="myButton" />

                        <%-- <input id="btnSave" runat="server" value="Save "class="btn btn-primary" />
                        <input id="btnAction" runat="server" value="Add To LTO List" class="btn btn-primary" onclick="BtnAction_Click()" />
                        <input id="btnAction2" runat="server" value="Change State"  class="btn btn-primary"  onclick="" / />--%>

                    </td>
                </tr>

            </table>

        </div>

        <asp:HiddenField ID="HiddenFieldAction" runat="server" Value="No" />
        <asp:HiddenField ID="hfUserCPNum" runat="server" />
        <asp:HiddenField ID="hfSchoolyear" runat="server" />
        <asp:HiddenField ID="hfSchoolCode" runat="server" />
        <asp:HiddenField ID="hfSchoolname" runat="server" />
        <asp:HiddenField ID="hfHiredStatus" runat="server" />
        <asp:HiddenField ID="hfSchoolyearStartDate" runat="server" Value="2016-10-02" />
        <asp:HiddenField ID="hfSchoolyearEndDate" runat="server" Value="2017-05-26" />
        <asp:HiddenField ID="hfCommentsIDs" runat="server" />


    </form>
</body>
</html>
<script src="../Scripts/CommonDOM.js" type="text/javascript"></script>
<script type="text/jscript">
    $(document).ready(function () {
        try {
            InitialDatePickerControl();

            $("#btnSave").prop('disabled', true);
            if ($("#TextHRComments").val().length > 1) {
                $("#btnSave").prop('disabled', false);
            }
            if ($("#chbSignatureSignOff").prop('checked') === true) {
                $("#signOffChb").css("color", "green");
            }
        }
        catch (e) { }

        // var minD = new Date($("#hfSchoolyearStartDate").val());
        // var maxD = new Date($("#hfSchoolyearEndDate").val());


        // $("#dateEffective").datepicker(
        //     {
        //         dateFormat: 'yy-mm-dd',
        //         minDate: minD,
        //         maxDate: maxD,
        //         changeMonth: true,
        //         changeYear: true
        //     });
        //$("#DateOfHire").datepicker(
        //     {
        //         dateFormat: 'yy-mm-dd',
        //         minDate: minD,
        //         maxDate: maxD,
        //         changeMonth: true,
        //         changeYear: true
        //     });
        $(window).unload(function () {
            //   var myaction = document.getElementById("HiddenFieldAction").value;
            window.returnValue = $("#HiddenFieldAction").val();
        });


        $("#TextHRComments").keyup(function (e) {

            if ($("#TextHRComments").val().length > 1) {
                $("#btnSave").prop('disabled', false);
            }
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
    function InitialDatePickerControl() {
        var value = new Date().toDateString;
        //  var minD = new Date($("#hfSchoolyearStartDate").val());
        //  var maxD = new Date($("#hfSchoolyearEndDate").val());

        // JDatePicker.Initial($("#DateOfHire"), minD, maxD,value);
        //JDatePicker.Initial($("#dateEffective"), minD, maxD);

        JDatePicker.Initial($("#DateOfHire"));
        // JDatePicker.Initial($("#dateEffective")); 
    }
</script>
