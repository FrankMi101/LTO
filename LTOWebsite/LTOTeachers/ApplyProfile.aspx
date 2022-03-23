<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ApplyProfile.aspx.vb" Inherits="ApplyProfile" %>

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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-image: url(../images/message_body_m.bmp)">

            <table style="font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif; font-size: small; height: 100%">
                <tr>
                    <td></td>
                    <td>My Profile</td>
                </tr>
                <tr>
                    <td>Qualification:</td>
                    <td>
                        <asp:TextBox ID="TextPostionQualification" runat="server" Height="120px" TextMode="MultiLine" Width="500px" BackColor="Transparent" ReadOnly="true"></asp:TextBox></td>
                </tr>

                <tr>
                    <td style="width: 135px; text-align: right; text-wrap: avoid">Email:</td>
                    <td>
                        <asp:TextBox ID="TexteMail" runat="server"   ReadOnly="true" Width="300px"></asp:TextBox>
                        @tcdsb.org
                    </td>
                </tr>
                <tr>
                    <td style="width: 135px; text-align: right; text-wrap: avoid">Home Phone Number:</td>
                    <td>
                        <asp:TextBox ID="TextHomePhone" runat="server" BackColor="#ffffcc" Width="120px"></asp:TextBox>

                    </td>


                </tr>

                <tr>
                    <td style="width: 130px; text-align: right">Cell Phone Number:
                    <td>
                        <asp:TextBox ID="TextCellPhone" runat="server" BackColor="#ffffcc" Width="120px"></asp:TextBox>

                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        
                             <asp:Label ID="LabelUploadFile" runat="server" Visible="false" Text="Label"></asp:Label>
                        &nbsp;</td>
                </tr>

                <tr>

                    <td colspan="6" style="text-align: center;">

                        <asp:Button ID="btnSave" runat="server" Text="Save" />
                        <a id="LabelUploadFileA" runat="server" visible="false" href="#">Upload Resume and Cover Letter

                        </a>
                   

                    </td>

                </tr>

            </table>
        </div>
        <div id="PopUpDIV1" style="visibility: hidden; position: absolute; left: 140px; top: 200px; width: 400px; height: 200px; background-color: skyblue; color: red; border: solid; border-color: blue; border-width: thin">
            <div style="text-align: right; font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif">
                <asp:Label ID="lblMessage" runat="server" Text="X" Font-Size="Medium" ToolTip="Close this Message"></asp:Label>

            </div>

        </div>
        <div id="ResumeCoverLetterDIV" class="bubble hide" style="width: 99%;">

            <div style="height: 22px; margin-top: -2px; background-color: deepskyblue; width: 100%;">


                <table style="vertical-align: top;">
                    <tr style="">
                        <td style="width: 100%; text-align: center">
                            <div id="popPagetitle" runat="server" style="font-size: medium">Upload Resume and Cover Letter </div>

                        </td>
                        <td>
                            <asp:HiddenField ID="hdChildFormAction" runat="server" Value="NoAction" />
                            <asp:HiddenField ID="hfInvokePageFrom" runat="server" Value="" />
                            <asp:HiddenField ID="hfUserRole" runat="server" Value="" />
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
                    src="#"></iframe>

            </div>


        </div>
    </form>
</body>
</html>


<script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>

<script type="text/jscript">
    $(document).ready(function () {
        if ($("#hfPositionType").val() == "LTO" || $("#btnApply").val() == "Apply Position") {
            POPMessage();
        }
        $("#lblMessage").click(function (e) {
            if ($("#hfPositionType").val() == "LTO" || $("#btnApply").val() == "Apply Position") {
                POPMessage();
            }
        });

        $("#LabelUploadFileA").click(function (e) {

            OpenFileUpload("", "", 10, 300, 400, 600);
        })
        $("#CloseMeLink").click(function (e) {

            $("#ResumeCoverLetterDIV").fadeToggle("fast");
        })

        $(window).unload(function () {
            //   var myaction = document.getElementById("HiddenFieldAction").value;
            window.returnValue = $("#HiddenFieldAction").val();
        });
    });

    function POPMessage() {
        el = document.getElementById("PopUpDIV1");
        el.style.visibility = (el.style.visibility == "visible") ? "hidden" : "visible";
        DisableAction = '0';
    }

    function OpenFileUploadbyClick(cpnum, positionID, vTop, vLeft, vHeight, vWidth) {

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
    function openFileUpload(type, schoolyear, cpnum, positionID) {
        var vTop = 100;
        var vLeft = 100;
        var vHeight = 300;
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
</script>
