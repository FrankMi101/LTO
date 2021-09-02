<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RequestList2.aspx.vb" Inherits="RequestList2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../Styles/BubbleHelp.css" rel="stylesheet" />
        <link href="../Styles/ListPage.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        body {
            height: 100%;
            width: 100%;
        }

        .auto-style1 {
            height: 50px;
        }

        table {
            height: 100%;
            width: 100%;
        }

        .WDG {
            height: 100%;
            width: 100%;
        }

        .DataContentTile {
            font-family: Arial;
            font-size: small;
            font-weight: 300;
            color: blue;
            /*display:none ;*/
        }

        .iFrameContent {
            position: absolute;
            width: 100%;
            height: 450px;
            border: 1px dotted;
            border-color: blue;
            margin: -1px;
            padding: 0px;
        }

        table tbody tr:nth-child(odd) {
            background-color: aliceblue;
        }

        .emptyData {
            font-size: xx-large;
            text-align: center;
            color: blue;
        }

        #GridView1 th {
            border: 1px solid #e1d9d9;
        }

        #GridView1 td {
            border: 1px solid #e1d9d9;
        }

        .RequestButton {
            width: 100%;
            height: 19px;
            color: red;
            font-size: small;
            margin-top: -5px;
            padding-top:-2px;
        }
        .messageBox {
         border:2px solid #ff9966;
         background-color:bisque;
         width:350px;
        }
    </style>
   <%-- <style type="text/css" id="Infragistics WebdataGrid">
        .ListHeader {
            height: 50px;
        }

        .RowDisable {
            background-color: gray;
        }
    </style>--%>

</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/WebServices/WebService.asmx" />
            </Services>
        </asp:ScriptManager>
        <div>
            <table id="Table3" border="0" class="TableFont1" style="text-align: left; height: 100%;">
                <tr id="SuperAreaRow" runat="server">
                    <td>

                        <asp:Label ID="lblSchoolyear" runat="server" Text="School Year: "></asp:Label>


                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchoolYear" runat="server" Width="100px" Visible="true" AutoPostBack="True" SkinID="ddlSmall"
                            Enabled="true">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="lblSuper" runat="server" Text="School: "></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlschoolcode" runat="server" CssClass="editcell" SkinID="ddlSmall" Width="60px" AutoPostBack="true"></asp:DropDownList></td>

                    <td>
                        <asp:DropDownList ID="ddlSchool" runat="server" Width="400px" SkinID="ddlSmall" CssClass="editcell" AutoPostBack="true"></asp:DropDownList>

                    </td>
                    <td>
                        <asp:Button ID="btnNewOpen" runat="server"  CssClass ="RequestButton" Text  ="Request a New Posting for " Width="100%"  Height="20px"   Font-Size="small" ForeColor="red" />

                    </td>
                    <td>
                        <asp:DropDownList ID="ddlappType" runat="server" Visible="true" SkinID="ddlSmall" AutoPostBack="True" ForeColor="Red" Width="150px"  Height="20px" Enabled="false">
                            <asp:ListItem Value="LTO">LTO Assignment</asp:ListItem>
                            <asp:ListItem Value="POP">Permanent Open Position</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="font-size: x-small">
                        <a id="openAnswerA" runat="server" href="javascript:openPrintPage(90,180)">
                            <img src="../images/print.bmp" alt="" title="Print SLIP One Page Summary" style="border-width: 1px; border-color: Purple;" />
                        </a>
                    </td>
                    <td></td>

                    <td style="width: 15%">
                        <asp:HiddenField ID="hfUserID" runat="server" />
                    </td>
                </tr>

            </table>
        </div>
        <%--<div class="DataContentTile" >School Open Position List </div>--%>
        <div>

            <asp:GridView ID="GridView1" runat="server" CellPadding="1" Height="100%" Width="100%" GridLines="Both" AutoGenerateColumns="False" BackColor="White" BorderColor="gray" BorderStyle="Ridge" BorderWidth="1px" CellSpacing="1" EmptyDataText="No posting position request yet." EmptyDataRowStyle-CssClass="emptyData" ShowHeaderWhenEmpty="true">
                <Columns>

                    <asp:BoundField DataField="myKey" ReadOnly="True" Visible="False" />
                    <asp:BoundField DataField="School_Year" ReadOnly="True" Visible="False" />
                    <asp:BoundField DataField="School_Code" ReadOnly="True" Visible="False" />
                    <asp:BoundField DataField="PositionID" ReadOnly="True" Visible="False" />


                    <asp:TemplateField HeaderText="Current Status">
                        <ItemTemplate>
                            <asp:HyperLink ID="Link2" runat="server" Text='<%# Bind("ActionSign") %>'>  </asp:HyperLink>
                        </ItemTemplate>
                        <ItemStyle Width="3%" Wrap="False" />
                    </asp:TemplateField>

                    <asp:BoundField DataField="PositionType" HeaderText="AppType">
                        <ItemStyle Width="3%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RequestSource" HeaderText="Source">
                        <ItemStyle Width="3%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RequestStatus" HeaderText="Status">
                        <ItemStyle Width="3%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="StartDate" HeaderText="Assignment Start Date">
                        <ItemStyle Width="4%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="EndDate" HeaderText="Assignment End Date">
                        <ItemStyle Width="4%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SchoolName" HeaderText="School Name">
                        <ItemStyle Width="12%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PositionTitle" HeaderText="Position Title">
                        <ItemStyle Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PositionLevel" HeaderText="Division Required">
                        <ItemStyle Width="8%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Qualification" HeaderText="Subject Area Qualification">
                        <ItemStyle Width="10%" HorizontalAlign="center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ReplaceTeacher" HeaderText="Teacher being Replaced">
                        <ItemStyle Width="8%" />
                    </asp:BoundField>

                    <asp:BoundField DataField="ReplaceReason" HeaderText="Reason for Replacement">
                        <ItemStyle Width="8%" />
                    </asp:BoundField>


                    <asp:BoundField DataField="Description" HeaderText="Position Decription">
                        <ItemStyle Width="10%" HorizontalAlign="center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Comments" HeaderText="Request Comments">
                        <ItemStyle Width="8%" HorizontalAlign="center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FTE" HeaderText="BTC">
                        <ItemStyle Width="3%" HorizontalAlign="center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FTEPanel" HeaderText="AM/PM">
                        <ItemStyle Width="3%" HorizontalAlign="center" />
                    </asp:BoundField>

                </Columns>

                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="cornflowerblue" ForeColor="white" Height="25px" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <%--  <RowStyle BackColor="#DEDFDE" ForeColor="Black" />--%>
                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#594B9C" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#33276A" />
            </asp:GridView>
        </div>
        <div style="color: Red; font-size: x-small">
            <asp:Label runat="server" ID="remaind22" Text="* Click on the select Position button to see interview candidate list"> </asp:Label>
        </div>

        <div id ="SecondaryMessage"  class="bubble hide messageBox">
             <b>  Secondary School Principal:</b> <br /><br />
             When requesting an LTO, please ensure you select one of the two options: <br />
             <ul>
               <%--  <li>TAP LTO posting</li>--%>
                 <li>LTO posting - replacing a permanent teacher on leave of absence </li>
             </ul>
            
        </div>
  
         <div id ="ElementaryMessage"  class="bubble hide messageBox">
             <b>Elementary School Principal:  </b> <br /><br />
             <%-- From this site, you may only request a LTO for a TAP position here. <br /><br />--%>
              For an LTO posting replacing a permanent teacher on leave of absence, please go to the F100, 
              select LTO Request, select Teacher and follow the prompts. 
              
        </div>
    </form>
</body>
</html>


<script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
<script src="../Scripts/PopUpDIVLeft.js" type="text/javascript"></script>

<script type="text/javascript" id="igClientScript1">
    var MessageBox = $("#ElementaryMessage");
    
    var request = {
         Operate : "Request",
         SchoolYear : $("#ddlSchoolYear").val(),
         SchoolCode : $("#ddlschoolcode").val(),
        PositionType: $("#ddlappType").val(),       
         PositionID : 0,
         UserID : $("#hfUserID").val()
    }
    function openPrintPage(pHeight, pWrith) {
        alert("Coming Soon");
    }
    function openPosting(schoolyear, schoolcode, positionID,requestSource) {
        // window.alert("ok");
        //if (requestSource === "Principal")
        //else
        //    var goPage = "Loading2.aspx?pID=LTOPrincipals/RequestDetails.aspx" + "&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID;
      //  var goPage = "Loading2.aspx?pID=LTOPrincipals/RequestPosting.aspx" + "&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID;
        var goPage = "Loading2.aspx?pID=LTOPrincipals/RequestDetails2.aspx" + "&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID;

        openDetailPage(550, 800, goPage, "Edit posting request")
    }

    function openDetailPage(vHeight, vWidth, goPage, pTitle) {
        $(document).ready(function () {
            try {
                var iWidth = (window.innerWidth > 0) ? window.innerWidth : screen.width;
                var iHeigh = (window.innerheigh > 0) ? window.innerheigh : screen.height;

                var vLeft = (iWidth / 2) - (vWidth / 2) - 50;
                var vTop = (screen.height / 2) - (vHeight / 2) - 40;
                $("#PositionDetailFrame", parent.document).attr('src', goPage);
                $("#popPagetitle", parent.document).text(pTitle);
                $("#hfInvokePageFrom", parent.document).val("LTOPrincipals/RequestList2.aspx");      //val("LTOPrincipals/RequestPostingList.aspx");
                $("#PositionDetailDIV", parent.document).css({
                    top: vTop,
                    left: vLeft,
                    height: vHeight,
                    width: vWidth
                })
                //   PopUpDIV2();
                $("#PopUpDIV", parent.document).fadeToggle("fast");
                $("#PositionDetailDIV", parent.document).fadeToggle("fast");
            }

            catch (e) { }

        });

    }
    $(document).ready(function () {
        try {

            $("#btnNewOpen").click(function (e) {
           
                request.Operate =  "Request";
                request.SchoolYear =  $("#ddlSchoolYear").val();
                request.SchoolCode = $("#ddlschoolcode").val();
                request.PositionType = $("#ddlappType").val();
                request.PositionID = 0;
                request.UserID =  $("#hfUserID").val()  ;
           
                //var schoolyear = $("#ddlSchoolYear").val();
               //  var schoolcode = $("#ddlschoolcode").val();
                //var positionType = $("#ddlappType").val();
               // var userID = $("#hfUserID").val();
                if (request.UserID === "mif1") {
                    var requestID = "0";
                  //  WebService.CreateNewPostingRequest("Request", schoolyear, schoolcode, positionType, requestID, onSuccess, onFailure);
                    WebService.CreateNewPostingRequest("Request", request, onSuccess, onFailure);
                }
                else {
                    var elementarypanle = "02,03,04";//""; // 
                    var shortCode = request.SchoolCode.slice(0, 2);
                 
                    if (elementarypanle.indexOf(shortCode) != -1) {
                        alert("Elementary school posting request through the Form 100 application!");            
                    }
                    else {
                        var requestID = "0";
                        //   WebService.CreateNewPostingRequest("Request", schoolyear, schoolcode, positionType, requestID, onSuccess, onFailure);
                        WebService.CreateNewPostingRequest("Request", request, onSuccess, onFailure);
                    }
                }
                return false;

            });

            $("#btnNewOpen").mouseenter(function (event) {

                var schoolCode = $("#ddlschoolcode").val();
               // alert(schoolCode.substring(0, 2));
                if (schoolCode.substring(0, 2) == '05' )
                    MessageBox = $("#SecondaryMessage");

                vTop = event.currentTarget.offsetTop;
                vLeft = event.currentTarget.offsetLeft; 

                MessageBox.css({
                    top: vTop + 35,
                    left: vLeft + 500,
                    height: 150,
                    width: 350
                });

                MessageBox.fadeToggle("fast");
            });
            $("#btnNewOpen").mouseleave(function (event) {             
                MessageBox.fadeToggle("fast");
            });

            $("#CloseMeLink").click(function (e) {
                CloseMe();
            });
            $("#datepicker").datepicker(
                {
                    dateFormat: 'yy-mm-dd',
                    showOn: "button",
                    buttonImage: "../images/calendar.gif",
                    buttonImageOnly: true,
                    changeMonth: true,
                    changeYear: true
                });
            $("#datepicker2").datepicker(
              {
                  dateFormat: 'yy-mm-dd',
                  showOn: "button",
                  buttonImage: "../images/calendar.gif",
                  buttonImageOnly: true,
                  changeMonth: true,
                  changeYear: true
              });

        }
        catch (e) { }
    });

    function onSuccess(result) {

        if (result) {
            request.PositionID = result
            var schoolyear = request.SchoolYear; // $("#ddlSchoolYear").val();
            var schoolcode = request.SchoolCode;  // $("#ddlschoolcode").val();
            var requestID = result;
           
           var goPage = "Loading2.aspx?pID=LTOPrincipals/RequestDetails2.aspx&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + requestID;
          //  var goPage = "Loading2.aspx?pID=LTOPrincipals/RequestPosting.aspx&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + requestID;

            openDetailPage(550, 800, goPage, "Add new posting request")
        }
    }
    function onFailure(result) {
        window.alert("Request posting failed !");
    }

</script>
