<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NoticeToPrincipal2.aspx.vb" Inherits="NoticeToPrincipal2" EnableTheming="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Apply Position</title>
    <base target="_self" />
    <meta http-equiv="Pragma" content="No-cache" />
    <link href="../Styles/DetailsPage.css" rel="stylesheet" type="text/css" />
    <link href="../JQuery-UI/jquery-ui.css" rel="stylesheet" type="text/css" />
 
    <link href="../Styles/TablesFrame4.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/BubbleHelp.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/angular.min.js"></script>

    <style type="text/css">
        body {
            height: 99%;
            width: 99%;
        }

        td {
            font-size: small;
        }

        .hiddenMe {
            display: none;
        }

   /*     .editcell {
            background-color: #ffffcc;
            font-family: Arial;
            font-size: small;
        }
*/
        .auto-style1 {
            width: 35px;
            height: 30px;
        }

        .Required-Field-Control {
            border: 2px dotted red;
        }


        #interviewCandidate td {
            border: 1px solid #f9f8f2;
        }

        #F100TimeTable td, #F100MultipleSchool td {
            border: 1px solid #f9f8f2;
        }

        #F100TimeTable table, #F100MultipleSchool table {
            width: 100%
        }
    </style>

    <script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="../JQuery-UI/jquery-ui-1.11.4.min.js" type="text/javascript"></script>
     <script src="../Scripts/CommonDOM.js" type="text/javascript"></script>

    <script type="text/javascript">
        function CallBackReloadParent(action, message) {
            try {
                window.alert(action + " " + message + "!");

                $("#hdChildFormAction", parent.document).val(action);
                $("#PopUpDIV", parent.document).fadeToggle("fast");
                $("#PositionDetailDIV", parent.document).fadeToggle("slow");
                window.parent.frames["mainTop"].document.location.reload();

            }
            catch (e) {
                var s = e.message;
            }


        }

    </script>
</head>
<body>
    <form id="form1" runat="server" ng-app="" name="myForm">
        <div style="background-image: url(../images/message_body_m.bmp)">

            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblPostingNumber" runat="server" Text=" Posting Number:"> </asp:Label></td>
                    <td colspan="5">
                        <asp:TextBox ID="TextPostingNum" runat="server" BackColor="Transparent" Height="16px" Width="70px"></asp:TextBox>
                        <asp:TextBox ID="TextPositionID" runat="server" BackColor="Transparent" Height="16px" Width="0px" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="TextType" runat="server" BackColor="Transparent" Height="16px" Width="50px"></asp:TextBox>

                        Status:
                        <asp:TextBox ID="TextStatus" runat="server" BackColor="Transparent" Height="18px" Width="50px"></asp:TextBox>
                        <asp:TextBox ID="TextOwner" runat="server" BackColor="Transparent" Height="16px" Width="50px"></asp:TextBox>

                        School Area: 
                
                        <asp:TextBox ID="TextArea" runat="server" BackColor="Transparent" Height="20px" Width="100px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>School:</td>
                    <td colspan="5">
                        <asp:TextBox ID="TextSchool" runat="server" Height="20px" Width="100%" BackColor="Transparent"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_ddlSchoolPrincipal" runat="server" ControlToValidate="ddlSchoolPrincipal" ErrorMessage="* Must Select a School Principal" Font-Size="small" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>School Principal:</td>
                    <td colspan="5">
                        <asp:TextBox ID="textPrincipal" runat="server" Height="20px" Width="100px" BackColor="Transparent" Visible="false"></asp:TextBox>
                        <asp:DropDownList ID="ddlSchoolPrincipal" runat="server" Width ="150px"  CssClass="editcell Edit-Content-Control"></asp:DropDownList>
                        Posted Date:<asp:TextBox ID="TextPostedDate" runat="server" BackColor="Transparent" Width="80px"></asp:TextBox>
                        <asp:Label ID="lblPostingCycle" runat="server" Height="20px" Width="80px" BackColor="Transparent" Text=" "></asp:Label>
                        <asp:Label ID="lblFTE" runat="server" Height="20px" Width="50px" BackColor="Transparent" Text=" "></asp:Label>
                        <asp:Label ID="lblFTEPanel" runat="server" Height="20px" Width="50px" BackColor="Transparent" Text=" "></asp:Label>
                        <%--       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSchoolPrincipal" ErrorMessage="*principal" Font-Size="small" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                        --%>

                    </td>
                </tr>
                <tr>
                    <td>Position Title</td>
                    <td colspan="5">
                        <asp:TextBox ID="TextPositionTitle" runat="server" Height="20px" Width="100%" BackColor="Transparent"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Grade Leve:</td>
                    <td colspan="5">
                        <asp:DropDownList ID="ddlPositionlevel" runat="server" readyonly="true" BackColor="Transparent" CssClass="Edit-Content-Control">
                            <asp:ListItem Value="BC013E">Intermediate</asp:ListItem>
                            <asp:ListItem Value="BC014E">Senior</asp:ListItem>
                            <asp:ListItem Value="BC003E">Intermediate and Senior</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Qualification:  </td>
                    <td colspan="5">
                        <asp:TextBox ID="TextPostionQualification" runat="server" Height="30px" TextMode="MultiLine" Width="100%" BackColor="Transparent"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Position Description</td>
                    <td colspan="5">
                        <asp:TextBox ID="TextPositionDescription" runat="server" Height="50px" TextMode="MultiLine" Width="100%" BackColor="Transparent"></asp:TextBox>
                        <div id="F100TimeTable" runat="Server"></div>
                        <div id="F100MultipleSchool" runat="Server"></div>

                    </td>
                </tr>
                <tr>
                    <td>Posting Comments</td>
                    <td colspan="5">
                        <asp:TextBox ID="TextPostingcomments" runat="server" Height="30px" TextMode="MultiLine" Width="100%" BackColor="Transparent"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Teacher being Replaced:
               
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="TextTeacherReplaced" TabIndex="14" runat="server" Height="20px" Width="80%" BackColor="Transparent"></asp:TextBox>

                    </td>
                    <td class="noWrap">Person ID</td>
                    <td>
                        <asp:TextBox ID="TextTeacherPersonID" TabIndex="14" runat="server" Height="20px" Width="100px" BackColor="Transparent"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Deadline to Apply:</td>
                    <td>
                        <asp:TextBox ID="TextApplyEndDate" runat="server" BackColor="Transparent" Width="90px"></asp:TextBox></td>

                    <td class="midtitle">Start Date:</td>
                    <td>
                        <asp:TextBox ID="TextStartDate" runat="server" BackColor="Transparent" Width="90px"></asp:TextBox>

                    </td>
                    <td class="midtitle">
                        <asp:Label ID="LabelApplyDate" runat="server" Text="End Date:" Visible="true"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextEndDate" runat="server" BackColor="Transparent" Visible="true" Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Interview Candidate
                        <br />
                        HR Comments</td>
                    <td colspan="5">
                        <asp:TextBox ID="TextComments" runat="server" TextMode="MultiLine" Width="100%" Height="60px" CssClass="editcell Edit-Content-Control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <hr />
                    </td>
                </tr>

                <tr>
                    <td style="border: 1px solid #46aaf3">
                        <asp:Label ID="lblInterviewCandidates" runat="server" Text=" Interview Candidates"></asp:Label>
                    </td>
                    <td style="border: 1px solid #46aaf3" colspan="5">
                        <div id="interviewCandidate" runat="server" style="height: 100px; width: 100%; overflow: auto; display: block;"></div>
                    </td>
                </tr>

                <tr>

                    <td colspan="4" style="text-align: center;">

                        <asp:Button  ID="btnApply" runat="server" Text="Email to Principal" />
                        <asp:HiddenField ID="hfPositionType" runat="server" />
                        <asp:HiddenField ID="hfPositionID" runat="server" />
                        <asp:HiddenField ID="hfPrincipalID" runat="server" />
                        <asp:HiddenField ID="hfSchoolCode" runat="server" />
                    </td>
                    <td colspan="2" style="text-align: left">


                        <asp:CheckBox ID="chbNoticeToPrincipal" runat="server" Text="Email to Principal" Checked="true" />
                        <br />
                        <asp:CheckBox ID="chbNoticeToUnion" runat="server" Text="Email to Union" Checked="true" />
                    </td>

                </tr>
            </table>
        </div>

        <div id="dialog-message" title="Download complete" class="hiddenMe">
            <p>
                Your files have downloaded successfully into the My Downloads folder.
            </p>

        </div>

    </form>
</body>
</html>



<script type="text/javascript">
 
     $(document).ready(function () {
 
            $("#btnApply").click(function () {
                 checkRequiredFields();
            });

            $("#interviewCandidate").click(function () {
                showMe();
                return true;
            });

            $(window).unload(function () {
                //   var myaction = document.getElementById("HiddenFieldAction").value;
                window.returnValue = $("#HiddenFieldAction").val();
            });

        });
    function showMe() {
        $("#dialog-message").dialog({
            modal: true,
            buttons: {
                Ok: function () {
                    $(this).dialog("close");
                }
            }
        });
    }
    function checkRequiredFields() {
        DOMaction.Validation("RequiredFieldValidator_ddlSchoolPrincipal", "ddlSchoolPrincipal");
    }


</script>
