<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FileUpload.aspx.vb" Inherits="FileUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        td {
            font-family: Arial, sans-serif;
            font-size: small;
        }

        .ViewButton {
            border: 2px outset #e8e6e6;
            width: 100px;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">

        <table>
            <tr>
                <td style="width:13%;"> </td>
                <td style ="width:62%; "></td>
                <td style ="width:25%; "</td>

            </tr>
            <tr>
                <td> </td>
                <td></td>
                <td></td>

            </tr>

            <tr>
                <td>Resume</td>
                <td>
                    <asp:TextBox ID="LabelResumeName" runat="server" ReadOnly="True" Width="100%" Visible="false"></asp:TextBox>
                    <%--<asp:FileUpload ID="FileUpload1" runat="server" ToolTip=" Click to chose Resume file" />--%>
                     <input id="FileUpload1" type="file" runat="server" accept=".pdf,.doc,.docx,.txt" />
                </td>

                <td>
                    <asp:Button ID="ButtonUploadResume" runat="server" Text="Upload" />
                    <div id="RowResumeAction" runat="server">
                        <%--<a id="VerifyResume" href="#" class="ViewButton">View</a>--%>
                        <asp:Button ID="ButtonViewResume" runat="server" Text="Review" />
                        <asp:Button ID="ButtonRemoveResume" runat="server" Text="Remove" />
                    </div>


                    <asp:HiddenField ID="HiddenFieldResumeID" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;
                    <br />
                </td>
            </tr>
            <tr>
                <td>Cover Letter</td>
                <td>

                    <asp:TextBox ID="LabelLetterName" runat="server" ReadOnly="True" Visible="false" Width="100%"></asp:TextBox>
                    <%--<asp:FileUpload ID="FileUpload2" runat="server" ToolTip=" Click to chose Cover Letter file" />--%>
                    <input id="FileUpload2" type="file" runat="server" accept=".pdf,.doc,.docx,.txt" />
                </td>

                <td>
                    <asp:Button ID="ButtonUploadLetter" runat="server" Text="Upload" />
                    <div id="RowLetterAction" runat="server">
                        <%-- <a id="VerifyLetter" href="#" class="ViewButton">View</a>--%>
                        <asp:Button ID="ButtonReviewLetter" runat="server" Text="Review" />
                        <asp:Button ID="ButtonRemoveLetter" runat="server" Text="Remove" />
                    </div>

                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;

                    <asp:Label ID="lblMSG" runat="server" Text="Please chose a file" ForeColor="red" Visible="false"></asp:Label>
                    <asp:HiddenField ID="HiddenFieldLetterID" runat="server" />
                    <asp:HiddenField ID="HiddenFieldCPNum" runat="server" />
                    <asp:HiddenField ID="HiddenFieldPositionID" runat="server" />
                </td>
            </tr>

            <tr>
                <td colspan="3" style="color: red">By using the LTO Platform for the purpose of applying for available long term assignments, 
                    you agree that the Toronto Catholic District School Board may use information that you 
                    include with your on line application to be reviewed and evaluated for available long 
                    term assignments you have applied for. This information will be shared with those that will 
                    be evaluating(e.g. Principal, HR Hire Staff) your application for the various assignments you apply for. 
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <br />
                    <asp:CheckBox ID="CheckBoxGrantView" runat="server" Checked="true" AutoPostBack="true" Visible="false" Text="Grant View Permission to Principal and HR Hire Staff" />
                    <br />

                </td>
            </tr>
            <tr>
                <td></td>
                <td>

                    <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" Visible="false" />

                </td>
                <td></td>
                <td></td>
            </tr>
        </table>
    </form>
</body>
</html>


<script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>

<script type="text/jscript">
    var fileType = "pdf,doc,docx,txt";
    $(document).ready(function () {
        if ($("#hfPositionType").val() == "LTO" || $("#btnApply").val() == "Apply Position") {
            POPMessage();
        }
        $("#lblMessage").click(function (e) {
            if ($("#hfPositionType").val() == "LTO" || $("#btnApply").val() == "Apply Position") {
                POPMessage();
            }
        });

        $("#ButtonViewResume").click(function (e) {
            var id = $("#HiddenFieldLetterID").val()
            openResumeCoverLetter("Resume", id);
            return false;
        });
        $("#ButtonReviewLetter").click(function (e) {
            var id = $("#HiddenFieldResumeID").val()
            openResumeCoverLetter("CoverLetter", id);
            return false;
        });
        $("#ButtonUploadResume").click(function (e) {
            var fileName = $("#FileUpload1").val();
            

            if (fileName == "") {
                window.alert("Please chose a file to upload!");
                return false;
            }
            var ext = getExtension(fileName).toLowerCase(); 
            if (fileType.indexOf(ext) == -1) {
                alert("System Only allow follow file type " + fileType + " to upload!");
                return false;
            }

        });
        $("#ButtonUploadLetter").click(function (e) {
            var fileName = $("#FileUpload2").val();
       

            if (fileName == "") {
                window.alert("Please chose a file to upload!");
                return false;
            }
            var ext = getExtension(fileName).toLowerCase();
            if (fileType.indexOf(ext) == -1) {
                alert("System Only allow follow file type " + fileType + " to upload!");
                return false;
            }


        });


    })

    function getExtension(filename) {
        var parts = filename.split('.');
        return parts[parts.length - 1];
    }

  




    function openResumeCoverLetter(type, id) {
        var cpnum = $("#HiddenFieldCPNum").val();
        var positionID = $("#HiddenFieldPositionID").val();
        var goPage = "FileShow.aspx?Type=" + type + "&IDs=" + id + "&CPNum=" + cpnum + "&PositionID=" + positionID;
        window.open(goPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,width=1000 height=650, top=50, left=50");

    }
</script>
