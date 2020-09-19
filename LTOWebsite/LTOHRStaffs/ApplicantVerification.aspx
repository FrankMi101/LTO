<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ApplicantVerification.aspx.vb" Inherits="ApplicantVerification" EnableTheming="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Select for interview   </title>
    <base target="_self" />
    <meta http-equiv="Pragma" content="No-cache" />
    <style type="text/css">
        body {
            height: 1000px;
            width: 100%;
        }

        td {
            font-size: x-small;
        }

        #myContentPageH { /* iFrame style for Content Page*/
            height: 600px;
            width: 1000px;
            border: 1px solid Orange; /*  #699BC9;*/
            margin-left: -6px;
        }
    </style>
    <link href="../Styles/TabMenu.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div style="background-image: url(../images/message_body_m.bmp)">
            <div style="table-layout: auto ">
                Search by Last Name:
                <asp:TextBox ID="searchLastName" runat="server" BackColor="Transparent" Width="100px"></asp:TextBox>

                First Name:
                <asp:TextBox ID="searchFirstName" runat="server" BackColor="Transparent" Width="100px"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" /><asp:HiddenField ID="HiddenFieldAction" runat="server" Value="No" />


            </div>
            <div id="SearchList" runat="server" style="overflow: auto; height: 50px; width: 100%;">
                <table style="width:1000px; border:solid 1px blue" border="1">
                    <tr>
                        <td style=" width:50%">LTO Profile</td>
                        <td style=" width:50%" >SAP Profile</td>
                    </tr>
                    <tr>
                        <td><div id="LTOProfile" runat="server"></div></td>
                        <td><div id="SAPProfile" runat="server"></div></td>
                    </tr>
                </table>
            </div>
            <div id="myMenuDIV" runat="server" class="Horizontal_Tab">
                 <ul>
                    <li><a id="AV0" class="aLinkTabHS" runat="server" href="LoadingV.aspx?pID=0"
                        target="myContentPageH" style="min-width: 155px;">LTO/SAP Profile  </a></li>
                    <li><a id="AV1" class="aLinkTabH" runat="server" href="LoadingV.aspx?pID=1"
                        target="myContentPageH" style="min-width: 155px;">Applicant Applied Position  </a></li>
                    <li><a id="AV2" class="aLinkTabH" runat="server" href="LoadingV.aspx?pID=2"
                        target="myContentPageH" style="min-width: 155px;">Selected Interview Candidate   </a></li>
                    <li><a id="AV3" class="aLinkTabH" runat="server" href="LoadingV.aspx?pID=3"
                        target="myContentPageH" style="min-width: 155px;">Recommend for Hored </a></li>
                    <li><a id="AV4" class="aLinkTabH" runat="server" href="LoadingV.aspx?pID=4"
                        target="myContentPageH" style="min-width: 155px;">Applicant Profile </a></li>
                </ul>
            </div>
            <div class="PageContent">
                <iframe id="myContentPageH" runat="server" name="myContentPageH" src="LoadingV.aspx?pID=0"></iframe>
            </div>


            <asp:HiddenField ID="hfPreaLinkID" runat="server" Value="AV1" />
            <asp:HiddenField ID="hfPreTitle" runat="server" />
            </div>
    </form>
</body>
</html>

<script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
<script src="../Scripts/TabMenu.js" type="text/javascript"></script>
<script type="text/jscript">
    var preTitle = $("#hfPreTitle").val();
    var preaLinkID = $("#hfPreaLinkID").val();

    $(document).ready(function () {

        $(window).unload(function () {
            //   var myaction = document.getElementById("HiddenFieldAction").value;
            window.returnValue = $("#HiddenFieldAction").val();
        });

        //$("#btnApply").click(function (e) {
        //    var actionsTitle = $(this).attr('value');
        //    var result = confirm("Are you sure, you want to " + actionsTitle + " ?");
        //    if (result) {
        //        $("#HiddenFieldAction").val("Yes");
        //        return true;
        //    }
        //    else
        //        return false;
        //})

        if ($("#hfPositionType").val() == "LTO" && $("#btnApply").val() == "Select for Interview") {
            CheckCurrentAssignment(); // POPMessage();
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



</script>
