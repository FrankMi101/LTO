<%@ Page Language="VB" AutoEventWireup="false" CodeFile="InterviewList2M.aspx.vb" Inherits="InterviewList2M" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="Pragma" content="No-cache" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Styles/BubbleHelp.css" rel="stylesheet" type="text/css" />
    <link href="../JQuery-UI/jquery-ui.css" rel="stylesheet" type="text/css" />


    <style type="text/css">
        .ListHeader {
            height: 20px;
            /*font-family: verdana;
           font-size: 12px;
           font-weight:normal;
           text-align:left;
           color: #333333;*/
        }

        .lbl {
            font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif;
            font-size: 12px;
            display: inline;
        }

        .EditCPNum {
            display: none;
        }

        .hideEelement {
            display: none;
        }

        #cellEditDiv {
            border: 0px solid transparent;
            position: absolute;
            display: none;
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
    </style>
    <script type="text/javascript">
        var appInsights = window.appInsights || function (config) {
            function r(config) { t[config] = function () { var i = arguments; t.queue.push(function () { t[config].apply(t, i) }) } } var t = { config: config }, u = document, e = window, o = "script", s = u.createElement(o), i, f; for (s.src = config.url || "//az416426.vo.msecnd.net/scripts/a/ai.0.js", u.getElementsByTagName(o)[0].parentNode.appendChild(s), t.cookie = u.cookie, t.queue = [], i = ["Event", "Exception", "Metric", "PageView", "Trace"]; i.length;) r("track" + i.pop()); return r("setAuthenticatedUserContext"), r("clearAuthenticatedUserContext"), config.disableExceptionTracking || (i = "onerror", r("_" + i), f = e[i], e[i] = function (config, r, u, e, o) { var s = f && f(config, r, u, e, o); return s !== !0 && t["_" + i](config, r, u, e, o), s }), t
        }({
            instrumentationKey: "e29264b3-c405-47ea-9099-9b2311cee1ef"
        });

        window.appInsights = appInsights;
        appInsights.trackPageView();
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td style="width: 50%;">
                        <asp:Label runat="server" CssClass="lbl" ID="lblPositionTitle" Text=""> </asp:Label></td>
                    <td style="width: 20%;">&nbsp;
                    </td>
                    <td style="width: 20%;"><a id="A1" runat="server" href='https://webapp.tcdsb.org/WebDocuments/Documents/LTO/HM40.pdf' target="_blank">H.M.40</a> &nbsp;&nbsp;&nbsp;&nbsp;
                        <a id="A3" runat="server" href='https://webapp.tcdsb.org/WebDocuments/Documents/LTO/HM31.pdf' target="_blank">H.M.31</a>&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td style="width: 10%;">
                        <asp:HiddenField ID="hfPositionID" runat="server" />
                        <asp:HiddenField ID="hfSchoolyear" runat="server" />
                        <asp:HiddenField ID="hfUserID" runat="server" />
                        <asp:HiddenField ID="HiddenFieldDevice" runat="server" />
                    </td>
                </tr>
            </table>


        </div>
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                <Services>
                    <%--<asp:ServiceReference Path="~/WebServices/GetDeadLineDate.svc" />--%>
                    <asp:ServiceReference Path="~/WebServices/WebService.asmx" />
                </Services>
            </asp:ScriptManager>

            <div>

                <asp:GridView ID="GridView1" runat="server" CellPadding="1" Height="100%" Width="100%" GridLines="Both" AutoGenerateColumns="False" BackColor="White" BorderColor="gray" BorderStyle="Ridge" BorderWidth="1px" CellSpacing="1" EmptyDataText="No interview candidate has been selected" EmptyDataRowStyle-CssClass="emptyData" ShowHeaderWhenEmpty="true">
                    <Columns>

                        <asp:BoundField DataField="myKey" ReadOnly="True" Visible="False" />
                        <asp:BoundField DataField="School_Year" ReadOnly="True" Visible="False" />

                        <asp:BoundField DataField="Position_ID" ReadOnly="True" Visible="False" />
                        <asp:BoundField DataField="OCT_Number" ReadOnly="True" Visible="False" />
                        <asp:BoundField DataField="RequestInterview" ReadOnly="True" Visible="False" />

                        <asp:TemplateField HeaderText="Sign off">
                            <ItemTemplate>
                                <asp:HyperLink ID="Link7" runat="server" Text='<%# Bind("SignatureT") %>'>  </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="80px" Wrap="False" />
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Interview Selected">
                            <ItemTemplate>
                                <asp:HyperLink ID="Link1" runat="server" Text='<%# Bind("Acceptance") %>'>  </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="80px" Wrap="False" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="OCT">
                            <ItemTemplate>
                                <asp:HyperLink ID="Link2" runat="server" Text='<%# Bind("OCT") %>'>  </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="80px" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Teacher Name">
                            <ItemTemplate>
                                <asp:HyperLink ID="Link3" runat="server" Text='<%# Bind("Teacher_Name") %>'>  </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="10%" Wrap="False" />
                        </asp:TemplateField>

                        <asp:BoundField DataField="Hired_Date" HeaderText="Hired Date">
                            <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Interview_Date" HeaderText="Interview Date" ItemStyle-CssClass="EditDate">
                            <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Interview_Outcome" HeaderText="Interview Outcome" ItemStyle-CssClass="EditOutCome">
                            <ItemStyle Width="10%" />
                        </asp:BoundField>


                        <asp:TemplateField HeaderText="Recommend for Hire">
                            <ItemTemplate>
                                <asp:HyperLink ID="Link4" runat="server" Text='<%# Bind("Hiring") %>'>  </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="70px" Wrap="False" />
                        </asp:TemplateField>

                        <asp:BoundField DataField="Recomendation" HeaderText="Hire Recomendation" ItemStyle-CssClass="EditRecomendation">
                            <ItemStyle Width="12%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Qualification" HeaderText="Teacher Qualification" Visible="false">
                            <ItemStyle Width="25%" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Teacher LTO Appraisals" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ID="Link5" runat="server" Text='<%# Bind("Appraisal") %>'>  </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="20%" Wrap="False" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Teacher Comments" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ID="Link6" runat="server" Text='<%# Bind("Comments") %>'>  </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="10%" Wrap="False" />
                        </asp:TemplateField>

                        <asp:BoundField DataField="Apply_UserID" ReadOnly="True" ItemStyle-CssClass="EditCPNum">
                            <ItemStyle Width="0px" />
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
            <div id="MessageToPrincipal" runat="server" style="color: Red; font-size: small">
                * Principal must interview all candidate before making recommand for hire.
             
            </div>
            <div style="color: Red; font-size: small">
                ** Click on the Interview selected button to view applicant details information 
            </div>
            <div id="cellEditDiv" runat="server">
                <input id="cellEditInterviewDate" runat="server" type="text" size="9" style="display: none;" />
                <asp:DropDownList ID="cellEditInterviewOutCome" runat="server" CssClass="hideEelement"></asp:DropDownList>
                <textarea id="cellEditInterviewComments" cols="20" rows="8" style="display: none; width: 100%; height: 100%;"></textarea>
            </div>
            <asp:HiddenField ID="hfRequestSchool" runat="server" />
        </div>

        <div id="PopUpDIV2" class="bubble hide"></div>
        <div id="PositionDetailDIV2" class="bubble hide" style="width: 99%;">
            <div style="height: 22px; margin-top: -2px;">
                <table style="vertical-align: top;">
                    <tr style="background-color: deepskyblue;">

                        <td style="width: 95%; text-align: center">
                            <div id="popPagetitle" runat="server" style="font-size: medium">Position Detail Edit Page  </div>
                        </td>
                        <td>
                            <asp:HiddenField ID="hdChildFormAction" runat="server" Value="NoAction" />
                            <asp:HiddenField ID="hfInvokePageFrom" runat="server" Value="" />
                        </td>
                        <td style="width: 50px; text-align: right">
                            <a id="CloseMeLinkM" runat="server" href="#">
                                <img style="height: 20px; width: 20px;" src="../images/Close1.bmp" alt="" title="Close Me" />
                            </a>
                        </td>
                    </tr>
                </table>

            </div>
            <div id="iFrameDIV2" style="height: 92%; width: 100%;">
                <iframe id="PositionDetailFrame2" runat="server" name="PositionDetailiFrame" scrolling="auto" seamless="seamless"
                    src="#"></iframe>
            </div>
            <div id="BottomClose2" style="height: 22px; background-color: deepskyblue; text-align: right">
                <a id="CloseMeLinkM2" runat="server" href="#">
                    <img style="height: 20px; width: 20px;" src="../images/Close1.bmp" alt="" title="Close Me" />
                </a>
            </div>
        </div>

    </form>
</body>
</html>


<%--  --%>
<script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
<script src="../JQuery-UI/jquery-ui-1.11.4.min.js" type="text/javascript"></script>

<script>
    var IE = document.all ? true : false
    document.onmousemove = getMousepoints; //deepak this is to identify mouse event 
    var mouse_x = 0;
    var mouse_y = 0;
    function getMousepoints() {
        mouse_x = event.clientX + document.body.scrollLeft //to get client window X axis 
        mouse_y = event.clientY + document.body.scrollTop//to get client window Y axis 
        return true;
    }
</script>

<script>
    var schoolyear;
    var applyuserID;
    var positionID;
    var myKey;
    var eventCell;
    $(document).ready(function () {
        try {
            schoolyear = $("#hfSchoolyear").val();
            myKey = $("#hfPositionID").val();
            $("#cellEditInterviewDate").datepicker();

            $('#cellEditInterviewOutCome').change(function () {
                var newValue = $('#cellEditInterviewOutCome').val();
                var newText = $("#cellEditInterviewOutCome option:selected").text();
                eventCell.closest('tr').find('td.EditOutCome').text(newText);
                saveCellValueToDatabase('Result_interview', newValue, schoolyear, applyuserID, myKey);
                $("#cellEditDiv").hide();
            });
            $('#cellEditInterviewDate').change(function () {
                var newValue = $('#cellEditInterviewDate').val();
                eventCell.closest('tr').find('td.EditDate').text(newValue);
                saveCellValueToDatabase('date_interview', newValue, schoolyear, applyuserID, myKey);
                $("#cellEditDiv").hide();
            });
            $('#cellEditInterviewComments').change(function () {
                var newValue = $('#cellEditInterviewComments').val();
                eventCell.closest('tr').find('td.EditRecomendation').text(newValue);
                saveCellValueToDatabase('recomendation', newValue, schoolyear, applyuserID, myKey);
                $("#cellEditDiv").hide();
            });

            $("#CloseMeLinkM").click(function (e) {
                $("#PopUpDIV2").fadeToggle("fast");
                $("#PositionDetailDIV2").fadeToggle("fast");

            });

            $("#CloseMeLinkM2").click(function (e) {
                $("#PopUpDIV2").fadeToggle("fast");
                $("#PositionDetailDIV2").fadeToggle("fast");

            });


            $('td.EditDate').click(function (event) {
                if ($("#hfUserID").val() == "mif") {
                    eventCell = $(this);
                    applyuserID = $(this).closest('tr').find('td.EditCPNum').text();
                    var key = "Interview_Date"
                    var cellValue = $(this).closest('tr').find('td.EditDate').text();

                    $("#cellEditInterviewDate").val(cellValue);
                    $("#cellEditInterviewDate").show();
                    var xTop = event.currentTarget.offsetTop;
                    var xLeft = event.currentTarget.offsetLeft;

                    openCellEdit(key, xTop, xLeft, 20, 100);
                    $("#cellEditInterviewDate").datepicker();
                    $("#cellEditInterviewDate").focus();
                }

            });
            $('td.EditOutCome').click(function (event) {
                if ($("#hfUserID").val() == "mif") {
                    eventCell = $(this);
                    applyuserID = $(this).closest('tr').find('td.EditCPNum').text();
                    var key = "Interview_Outcome"
                    var cellValue = $(this).closest('tr').find('td.EditOutCome').text();
                    $("#cellEditInterviewOutCome").val(cellValue);
                    $("#cellEditInterviewOutCome").show();

                    var xTop = event.currentTarget.offsetTop;
                    var xLeft = event.currentTarget.offsetLeft;

                    openCellEdit(key, xTop, xLeft, 20, 100);
                    $("#cellEditInterviewOutCome").click();

                }



            });
            $('td.EditRecomendation').click(function (event) {
                if ($("#hfUserID").val() == "mif") {
                    eventCell = $(this);
                    applyuserID = $(this).closest('tr').find('td.EditCPNum').text();
                    var key = "Recomendation"
                    var cellValue = $(this).closest('tr').find('td.EditRecomendation').text();

                    $("#cellEditInterviewComments").val(cellValue);
                    $("#cellEditInterviewComments").show();
                    var xTop = event.currentTarget.offsetTop;
                    var xLeft = event.currentTarget.offsetLeft;
                    var xHeight = event.currentTarget.offsetHeight;
                    var xWidth = event.currentTarget.offsetWidth;
                    openCellEdit(key, xTop, xLeft, xHeight, xWidth);
                    $("#cellEditInterviewComments").focus();
                }
            });

        }

        catch (e) { }

    });
    function saveCellValueToDatabase(filedName, cellValue, schoolyear, applyuserID, myKey) {
        try {
            // var newDate = new LTOPositionDeadLine.GetDeadLineDate;
            //   newDate.saveInterviewData(schoolyear, positionID, applyuserID, myKey, filedName, cellValue, onSuccess, onFailure);
            var wsData = WebService.saveInterviewData(schoolyear, myKey, applyuserID, myKey, filedName, cellValue);
        }
        catch (e) {
            window.alert(e.message);
        }
    }
    function onSuccess(result) {
        window.alert(result);
    }
    function onFailure(result) {
        window.alert(result);
    }

</script>

<script type="text/javascript" id="igClientScript1">


    function openInterview(schoolyear, schoolcode, positionID, applyuserID) {
        var goPage = "LoadingP.aspx?pID=7&SchoolYear=" + schoolyear + "&ApplyUserID=" + applyuserID + "&PositionID=" + positionID;
        vH = 640;
        vW = 480;
        $("#PositionDetailFrame2").css({
            height: vH,
            width: vW
        })

        openDetailPage(vH, vW, goPage, "Recommend for Hiring the Position")
    }
    function openSignature(schoolyear, schoolcode, positionID, applyuserID, name) {
        var goPage = "LoadingP.aspx?pID=9&SchoolYear=" + schoolyear + "&ApplyUserID=" + applyuserID + "&PositionID=" + positionID;
        vH = 640;
        vW = 480;
        $("#PositionDetailFrame2").css({
            height: vH,
            width: vW
        })
        openDetailPage(vH, vW, goPage, "Interview Sign Off on H.M. 40 Policy for " + name);
    }
    function openOCT(schoolyear, schoolcode, OCTNumber) {
        window.open("OCTSite.aspx?OCTNum=" + OCTNumber, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,width=950,height=750,top=5,left=5");
    }
    function openEdit() {
    }
    function openCellEdit(vKey, vTop, vLeft, vHeight, vWidth) {
        if ($("#HiddenFieldDevice").val() == "Mobile") {
            vTop = 1;
            vLeft = 1;
        }
        $("#cellEditDiv").css({
            top: vTop,
            left: vLeft,
            height: vHeight,
            width: vWidth
        })
        $("#cellEditDiv").show();// .fadeToggle("fast");
    }
    function openDetailPage(vHeight, vWidth, goPage, pTitle) {
        $(document).ready(function () {
            try {
                var vLeft = (screen.width / 2) - (vWidth / 2) - 50;
                var vTop = (screen.height / 2) - (vHeight / 2) - 100;

                vTop = 1;
                vLeft = 1;
                $("#PositionDetailFrame2").attr('src', goPage);
                $("#popPagetitle2").text(pTitle);
                $("#PositionDetailDIV2").css({
                    top: vTop,
                    left: vLeft,
                    height: vHeight,
                    width: vWidth
                })
                $("#PopUpDIV2").fadeToggle("fast");
                $("#PositionDetailDIV2").fadeToggle("fast");
            }

            catch (e) { }
        });
    }

    function openLTOAppraisal(schoolyear, schoolcode, SessionID, TeacherID) {
        var printPage = "../PDFLoading/PDFDocument_Loading.aspx?rID=InterviewPackage" + "&yID=" + schoolyear + "&CPNum=" + TeacherID + "&pID=" + SessionID;
        var popup1 = window.open(printPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=800,height=600,top=0,left=0");
    }
    function openComment(schoolyear, positionID, CPNum) {
        var printPage = "../LTOHRStaffs/ApplicantComments.aspx?SchoolYear=" + schoolyear + "&ApplyUserID=" + CPNum + "&PositionID=" + positionID;
        var w = 400;
        var h = 300;
        var left = (screen.width / 2) - (w / 2);
        var top = (screen.height / 2) - (h / 2);
        var popup1 = window.open(printPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=" + w + ",height=" + h + ",top=" + top + ",left=" + left);
    }

</script>
