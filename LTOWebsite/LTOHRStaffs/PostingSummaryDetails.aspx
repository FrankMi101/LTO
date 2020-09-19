<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PostingSummaryDetails.aspx.vb" Inherits="PostingSummaryDetails" EnableTheming="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Select for interview   </title>
    <base target="_self" />
    <meta http-equiv="Pragma" content="No-cache" />
    <style type="text/css">
        body {
            height: 800px;
            width: 100%;
        }

        td {
            font-size: x-small;
        }

        #myContentPageH { /* iFrame style for Content Page*/
            height: 800px;
            width: 1150px;
            border: 1px solid Orange; /*  #699BC9;*/
            margin-left: -6px;
        }

        .Title {
            font-family: Arial, sans-serif;
            font-size: small;
            font-weight:600;
          
        }
        span {
         font-weight:500;
        }
    </style>
    <link href="../Styles/TabMenu.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div style="background-image: url(../images/message_body_m.bmp)">
            <div class="Title">
                <table  style="border:1px solid grey" >
                    <tr>
                        <td>Posting Number:</td>
                        <td>
                             <input runat="server" type="text" id="LabelPostingNumber" size="9"  readonly style=" width:80px " />
                            </td>
                        <td>Position Title:</td>
                        <td>
                           
                            <input runat="server" type="text" id="LabelTitle" size="9"  readonly style=" width:260px " />
                        </td>
                        <td>Position School:</td>
                        <td>
                            
                             <input runat="server" type="text" id="LabelSchool" size="9"  readonly style=" width:300px " />
                        </td>
                        <td>Teacher be replaced:</td>
                        <td>
                            <input runat="server" type="text" id="LabelReplace" size="9"  readonly style=" width:150px " />
                           
                        </td>
                    </tr>

                    <tr>
                        <td>Position FTE: </td>
                        <td>
                           
                            <input runat="server" type="text" id="LabelFTE" size="9"  readonly style=" width:80px " />
                        </td>
                        <td>Position Grade:</td>
                        <td>
                            <input runat="server" type="text" id="LabelLevel" size="9"  readonly style=" width:260px " />
                            </td>
                        <td>Qualification:</td>
                        <td>
                            <input runat="server" type="text" id="LabelQualification" size="9"  readonly style=" width:300px " />
                             </td>
                        <td>Description:</td>
                        <td>
                            <input runat="server" type="text" id="LabelDescription" size="9"  readonly style=" width:150px " />
                            </td>

                    </tr>
                </table>



            </div>

            <div id="myMenuDIV" runat="server" class="Horizontal_Tab">
                <ul>
                    <li id="menu_PR1" runat="server"><a id="PR1" class="aLinkTabHS" runat="server" href="LoadingV.aspx?pID=1"
                        target="myContentPageH" style="min-width: 155px;">Round 1  </a></li>
                    <li id="menu_PR2" runat="server"><a id="PR2" class="aLinkTabH" runat="server" href="LoadingV.aspx?pID=2"
                        target="myContentPageH" style="min-width: 155px;">Round 2  </a></li>
                    <li id="menu_PR3" runat="server"><a id="PR3" class="aLinkTabH" runat="server" href="LoadingV.aspx?pID=3"
                        target="myContentPageH" style="min-width: 155px;">Round 3   </a></li>
                    <li id="menu_PR4" runat="server"><a id="PR4" class="aLinkTabH" runat="server" href="LoadingV.aspx?pID=4"
                        target="myContentPageH" style="min-width: 155px;">Round 4 </a></li>

                </ul>
                 
                                <a id="openApplicantList" runat="server" href="javascript:openPrintPage(90,180,'PostSummary_All')"  >
                            <img height="15px" width="19px" src="../images/print.bmp" alt="print All posting summary" title="print All posting summary" style="border-width: 1px; border-color: Purple;" />
                        </a>

             
            </div>
            <div class="PageContent">
                <iframe id="myContentPageH" runat="server" name="myContentPageH"  scrolling ="no"  onscroll="auto" src="LoadingV.aspx?pID=1"></iframe>
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

    
    function openPrintPage(height, width, rID) {
        var schoolyear = querystring('SchoolYear');
        var positionID = querystring('PositionID');
        var postingNum = $("#LabelPostingNumber").val();
        var goPage = "../PDFLoading/PDFDocument_Loading.aspx?rID=" +rID + "&yID=" + schoolyear + "&pID=" + positionID + "&pNo=" + postingNum + "&cID=0";

        window.open(goPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,width=550 height=700, top=10, left=10");
      //  return false;
     } 
    function querystring(key) {
        var re = new RegExp('(?:\\?|&)' + key + '=(.*?)(?=&|$)', 'gi');
        var r = [], m;
        while ((m = re.exec(document.location.search)) != null) r.push(m[1]);
        return r;
    }

</script>
