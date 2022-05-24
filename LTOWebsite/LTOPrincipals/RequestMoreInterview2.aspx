<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RequestMoreInterview2.aspx.vb" Inherits="RequestMoreInterview2"  EnableTheming="true"  %>

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
        }

        .editcell {
            background-color: #ffffcc;
            font-family: Arial;
            font-size: small;
        }

        td {
            font-size: 12px;
            font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif;
        }

        input {
            font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif;
            font-size: 12px;
        }

        textarea {
            font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif;
            font-size: 12px;
        }

        #interviewCandidate td {
            border: 1px solid #f9f8f2;
        }
    </style>


    <script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            $(window).unload(function () {
                //   var myaction = document.getElementById("HiddenFieldAction").value;
                window.returnValue = $("#HiddenFieldAction").val();
            });
            $("#btnCancel").click(function (e) {
                {
                    CallParentPostBack("", "", "")
                    return false;
                }
            });

            //$("#btnApply").click(function (e) {
            //    {
            //        CallParentPostBack("", "", "")
            //        return true;
            //    }
            //});

        });

        function CallParentPostBack(action, positionTitle, strMessage) {

            try {
                $("#hdChildFormAction", parent.document).val(action);
                if (action == "") {
                }
                else {
                    window.alert(action + " " + strMessage);
                }
                $("#PopUpDIV", parent.document).fadeToggle("fast");
                $("#PositionDetailDIV", parent.document).fadeToggle("fast");
                //   window.parent.frames["mainTop"].document.location.reload();

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
                    <td>Posting Number:</td>
                    <td style="text-align:left">
                        <asp:HiddenField ID="TextPositionID" runat="server" />
                        <asp:TextBox ID="TextPostingNum" runat="server" BackColor="Transparent" width="70px" ></asp:TextBox>
                        <asp:TextBox ID="TextType" runat="server" BackColor="Transparent"   Width="25px"  ></asp:TextBox>

                    </td>
                    <td class="midtitle">
                        
                        Status:</td>
                    <td>
                        <asp:TextBox ID="TextStatus" runat="server" BackColor="Transparent" Height="18px" Width="50px"  ></asp:TextBox>

                    </td>
                    <td class="midtitle">School Area:</td>
                    <td colspan="2">
                        <asp:TextBox ID="TextArea" runat="server" BackColor="Transparent" Height="20px" Width="120px" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextOwner" runat="server" BackColor="Transparent" Height="16px" Width="50px"  ></asp:TextBox></td>

                </tr>

                <tr>
                    <td>School:</td>
                    <td colspan="7">
                        <asp:TextBox ID="TextSchool" runat="server" Height="20px" Width="100%" BackColor="Transparent"></asp:TextBox>

                    </td>
                </tr>

                <tr>
                    <td>HR Staff:</td>
                    <td colspan="2">
                        <asp:TextBox ID="textHRSTaffName" runat="server" Height="20px" Width="150px" BackColor="Transparent" ReadOnly="true"></asp:TextBox>

                    </td>
                    <td colspan="3">Request more interview candidate:</td>
                    <td>
                        <asp:TextBox ID="TextCandidateCount" runat="server" Height="20px" Width="50px" Text="0" BackColor="#ffffcc"></asp:TextBox>

                    </td>
                    <td>
                        <asp:Label ID="lblFTE" runat="server" Height="20px" Width="60px" BackColor="Transparent" Text=" "></asp:Label>
                        <asp:Label ID="lblFTEPanel" runat="server" Height="20px" Width="60px" BackColor="Transparent" Text=" "></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>Position Title</td>
                    <td colspan="7">
                        <asp:TextBox ID="TextPositionTitle" runat="server" Height="20px" Width="100%" BackColor="Transparent"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Mandatory Qualification:</td>
                    <td colspan="7">
                        <asp:TextBox ID="TextPostionLevel" runat="server" Height="20px" Width="100%" BackColor="Transparent"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Minimum Qualification</td>
                    <td colspan="7">
                        <asp:TextBox ID="TextPostionQualification" runat="server" Height="40px" TextMode="MultiLine" Width="100%" BackColor="Transparent"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Position Description</td>
                    <td colspan="7">
                        <asp:TextBox ID="TextPositionDescription" runat="server" Height="40px" TextMode="MultiLine" Width="100%" BackColor="Transparent"></asp:TextBox>
                        <div id="F100TimeTable" runat="Server"></div>
                        <div id="F100MultipleSchool" runat="Server"></div>

                    </td>
                </tr>
                <tr>
                    <td>Posting Comments</td>
                    <td colspan="7">
                        <asp:TextBox ID="TextPostingComments" runat="server" Height="40px" TextMode="MultiLine" Width="100%" BackColor="Transparent"></asp:TextBox></td>
                </tr>
                
                <tr>
                    <td>Teacher being Replaced:
               
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="TextTeacherReplaced" TabIndex="14" runat="server" Height="20px" Width="99%" BackColor="Transparent"></asp:TextBox>

                    </td>
                    <td class="noWrap">Person ID</td>
                    <td>
                        <asp:TextBox ID="TextTeacherPersonID" TabIndex="14" runat="server" Height="20px" Width="100px" BackColor="Transparent"></asp:TextBox>
                    </td>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>Deadline to Apply:</td>
                    <td>
                        <asp:TextBox ID="TextApplyEndDate" runat="server" BackColor="Transparent" Width="80px"></asp:TextBox> </td>

                    <td class="midtitle">StartDate:</td>
                    <td>
                        <asp:TextBox ID="TextStartDate" runat="server" BackColor="Transparent" Width="80px"></asp:TextBox>

                    </td>
                    <td class="midtitle">
                        <asp:Label ID="LabelApplyDate" runat="server" Text="End Date:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextEndDate" runat="server" BackColor="Transparent" Width="80px"></asp:TextBox>
                    </td>
                    <td class="midtitle">
                        <asp:Label ID="Label1" runat="server" Text="Posting:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextPostingCycle" runat="server" BackColor="Transparent" Width="60px"></asp:TextBox>
                    </td>
                </tr>


                <tr>
                    <td>Interview Candidates</td>
                    <td colspan="7">
                        <div id="interviewCandidate" runat="server" style="height: 150px; width: 100%; color: blue; overflow: auto; display: block;"></div>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="7">
                        <asp:Label ID="LabelNeedInterview" runat="server" Text=" candidate needs to interview" ForeColor="Red" Font-Size="x-Small"></asp:Label>
                    </td>
                </tr>
                <tr>

                    <td colspan="8" style="text-align: center;">

                        <asp:Button ID="btnApply" runat="server" Text="Email to HR Staff" />
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                          <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                        <asp:HiddenField ID="hfPositionType" runat="server" />
                        <asp:HiddenField ID="hfUserName" runat="server" />
                        <asp:HiddenField ID="hfPrincipalID" runat="server" />

                    </td>

                </tr>
            </table>
        </div>
    </form>
</body>
</html>



