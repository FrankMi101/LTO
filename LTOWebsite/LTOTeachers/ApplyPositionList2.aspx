<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ApplyPositionList2.aspx.vb" Inherits="ApplyPositionList2" EnableTheming="true" %>

<%@ Register Src="../uc/comment/SearchPosition.ascx" TagName="SearchPosition" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Avaiable LTO /POP Position List</title>
    <link href="../Styles/BubbleHelp.css" rel="stylesheet" />
    <link href="../JQuery-UI/jquery-ui.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/ListPage.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/autoCompleteDDL.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        body {
            height: 100%;
            width: 99.9%;
            margin:1px;
        }

        div {
            font-family: Arial;
            font-size: small;
        }

        .auto-style1 {
            height: 10%;
        }

        /*
        .WDG {
            height: 100%;
            width: 100%;
        }*/

        #PopUpDIVNo {
            z-index: 100;
            position: absolute;
            top: 0;
            left: 0;
            background: #56c0e9;
            height: 100%;
            width: 100%;
            visibility: hidden;
            filter: alpha(opacity=60);
            -moz-opacity: 0.6;
            -khtml-opacity: 0.6;
            opacity: 0.6;
        }

        .emptyData {
            font-size: xx-large;
            text-align: center;
            color: blue;
        }

        .EditPosiitonID {
            display: none;
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
        <div style="width: 100%;">
            <asp:ScriptManager runat="server">
            </asp:ScriptManager>

            <table id="Table3" border="0" class="TableFont1" style="width: 100%;">

                <tr id="PublishRow" runat="server">
                    <td>
                        <table class="TableFont1B">
                            <tr>
                                <td style="width: 25%;">

                                    <asp:HiddenField ID="SearchType" Value="All" runat="server" />
                                    <asp:HiddenField ID="SearchForListValue1" Value="" runat="server" />
                                    <asp:HiddenField ID="SearchForListValue2" Value="" runat="server" />
                                    <uc1:SearchPosition ID="SearchPosition1" runat="server" />

                                </td>

                                <td>
                                    <asp:Button ID="btnSearch" runat="server" Text="Go" CssClass="GoButton" />
                                </td>
                                <td style="width: 5%">

                                    <asp:DropDownList ID="ddlappType" runat="server" Width="55px" Visible="true" AutoPostBack="True" Height="20px">
                                        <asp:ListItem>LTO</asp:ListItem>
                                        <asp:ListItem>POP</asp:ListItem>
                                    </asp:DropDownList>


                                </td>
                                <td>
                                    <a id="A1" runat="server" visible="false" href='#' style="text-decoration: none; color: Gray">Loading.....</a>
                                    <a id="aLTOTeacherList" runat="server" href='https://webapp.tcdsb.org/WebDocuments/Documents/LTO/Long Term Occasional Teachers List.pdf' target="_blank">LTO Teacher List</a>

                                </td>
                                <td style="width: 30%; text-align: center; text-wrap: avoid">
                                    <div id="ApplicantForDeveloper" runat="server" visible="false">
                                        <div class="ui-widget">
                                            <asp:Label ID="lblSchoolyear" Text="Search Teacher:" runat="server"> </asp:Label>
                                            <select id="combobox" runat="server" style="width: 200px; background-color: lightgoldenrodyellow"
                                                ng-model="myText">
                                                <option value="">Select Teacher...</option>

                                            </select>
                                        </div>
                                        <asp:HiddenField ID="hfAutoCompletSelectedID" runat="server" Value="" />
                                        <asp:HiddenField ID="hfAutoCompletSelectedName" runat="server" Value="" />
                                        <asp:HiddenField ID="hfQualification" runat="server" Value="All" />
                                    </div>
                                </td>
                                <td>
                                    <asp:Button ID="btApplicant" runat="server" Text="Go" CssClass="GoButton" Visible="false" />

                                </td>
                                

                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="color: Red; font-size: x-small">

                            <asp:Label runat="server" ID="remaind22" Text="* Click on the Apply button to apply the Position. Move mouse on the No. column, you can see the details message"> </asp:Label>
                            <asp:HiddenField ID="hfCurrrentAvailableOpenPosition" runat="server" />
                        </div>
                    </td>
                </tr>
            </table>



            <div id="DivRoot">
                 <div style="overflow: hidden;" id="DivHeaderRow">
                        <table id="GridView2" tabindex="999" style="border: 1px ridge gray; background-color: white;" rules="all" cellspacing="1" cellpadding="1">
                        </table>
                    </div>

                 <div style="overflow: scroll; width: 100%; height: 100%" onscroll="OnScrollDiv(this)" id="DivMainContent">
                    <asp:GridView ID="GridView1" runat="server" Height="100%" Width="100%"
                        GridLines="Both" AutoGenerateColumns="False" BackColor="White" ShowHeader="true" ShowHeaderWhenEmpty="true"
                        EmptyDataText="No available Position posted" EmptyDataRowStyle-CssClass="emptyData"
                        BorderColor="gray" BorderStyle="Ridge">
                        <Columns>
                            <asp:BoundField DataField="myKey" ReadOnly="True" Visible="False" />
                            <asp:BoundField DataField="SchoolYear" ReadOnly="True" Visible="False" />
                            <asp:BoundField DataField="SchoolCode" ReadOnly="True" Visible="False" />
                            <asp:BoundField DataField="RowNo" HeaderText="No." ItemStyle-CssClass="ApplyAction">
                                <ItemStyle Width="2%" />
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="Apply">
                                <ItemTemplate>
                                    <asp:HyperLink ID="Link2" runat="server" Text='<%# Bind("ActionSign") %>'>  </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Width="2%" Wrap="False" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Upload Documents">
                                <ItemTemplate>
                                    <asp:HyperLink ID="Link22" runat="server" Text='<%# Bind("UploadFile") %>'>  </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Width="2%" Wrap="False" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Map">
                                <ItemTemplate>
                                    <asp:HyperLink ID="Link3" runat="server" Text='<%# Bind("SchoolMap") %>'>  </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Width="2%" Wrap="False" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="DateApplyStart" HeaderText="Posting Open">
                                <ItemStyle Width="4%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DateDeadline" HeaderText="Posting Close">
                                <ItemStyle Width="4%" />
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="Days to Close">
                                <ItemTemplate>
                                    <asp:HyperLink ID="Link5" runat="server" Text='<%# Bind("DaystoEndImg") %>'>  </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>

                            <asp:BoundField DataField="SchoolArea" HeaderText="School Area">
                                <ItemStyle Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SchoolName" HeaderText="School">
                                <ItemStyle Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PositionTitle" HeaderText="Position Title" ItemStyle-CssClass="EditTitle">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PositionLevel" HeaderText="Division Required">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Qualification" HeaderText="Qualification" ControlStyle-CssClass="QualificationP" ItemStyle-CssClass="QualificationP">
                                <ItemStyle Width="11%" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Description" HeaderText="Position Description">
                                <ItemStyle Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FTE" HeaderText="FTE">
                                <ItemStyle Width="2%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FTEPanel" HeaderText="AM/PM">
                                <ItemStyle Width="2%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PostingCycle" HeaderText="Posting Round">
                                <ItemStyle Width="3%" HorizontalAlign="center" />
                            </asp:BoundField>

                            <asp:BoundField DataField="StartDate" HeaderText="Start Date">
                                <ItemStyle Width="4%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EndDate" HeaderText="End Date">
                                <ItemStyle Width="4%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="StartTime" HeaderText="Start Time">
                                <ItemStyle Width="4%" />
                            </asp:BoundField>

                            <asp:BoundField DataField="PositionID" ReadOnly="True" ItemStyle-CssClass="EditPosiitonID" />

                        </Columns>

                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <HeaderStyle BackColor="cornflowerblue" ForeColor="white" Height="25px" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#594B9C" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#33276A" />
                    </asp:GridView>

                </div>


            </div>



            <div style="color: Red; font-size: x-small">
            </div>

        </div>


        <div id="PopUpDIVNo">
            No available open Position, Please visit site later.

        </div>
        <div id="QualificationDIV" class="bubble hide" style="width: 99%;">
            Position Title: 
            <asp:Label runat="server" ID="LabelTitle" Text="" Font-Bold="true"> </asp:Label>
            <iframe id="QualificationiFrame" runat="server" name="QualificationiFrame" scrolling="no" seamless="seamless" style="height: 95%; width: 100%; border: 0px blue solid"
                src="ApplyPositionNotQualS.aspx"></iframe>

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
                    src=""></iframe>

            </div>


        </div>
    </form>
</body>
</html>


<script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
<script src="../JQuery-UI/jquery-ui-1.11.4.min.js" type="text/javascript"></script>


<script src="../Scripts/GridViewLayout.js" type="text/javascript"></script>

<script src="../Scripts/autoCompleteDDL.js" type="text/javascript"></script>

<script type="text/javascript">
    var IE = document.all ? true : false
    document.onmousemove = getMousepoints;
    var mousex = 0;
    var mousey = 0;
    function getMousepoints() {
        mousex = event.clientX + document.body.scrollLeft;
        mousey = event.clientY + document.body.scrollTop;
        return true;
    }

    $(document).ready(function () {
        var openPositionCount = $("#hfCurrrentAvailableOpenPosition").val();
        var vHeight = window.innerHeight - 100;
        MakeStaticHeader("GridView1", vHeight, 1500, 25, false, "DivHeaderRow", "GridView2", "DivMainContent");
        //  MakeStaticHeader(gridId, height, width, headerHeight, isFooter, headerRow, headerView, mainContent)

        if (openPositionCount == 0) {
            var goPage = "NoOpenPositionAvailable.aspx";
            window.document.location.href = goPage;
        }

        $('td.QualificationP').click(function (event) {
            eventCell = $(this);

            var cellValue = $(this).closest('tr').find('td.QualificationP').text();

            $("#hfQualification").val(cellValue);
            $("#txtSearchBox").val(cellValue);
            $("#btApplicant").click();

        });

        $('td.ApplyAction').mouseenter(function (event) {
            eventCell = $(this);
            // var cellValue = $(this).closest('tr').find('td.QualificationP').text();
            var positionID = $(this).closest('tr').find('td.EditPosiitonID').text();
            var title = $(this).closest('tr').find('td.EditTitle').text();
            $("#LabelTitle").text(title + " - " + positionID);
            var cpnum = $("#ddlApplicant").val();
            //  window.alert(cellValue + " - "  + positionID + " - " + cpnum);

            var xTop = mousey; // event.currentTarget.offsetTop;
            if (xTop > 350) { xTop = mousey - 250 }
            var xLeft = event.currentTarget.offsetLeft + 70;

            openApplicantQualification(cpnum, positionID, xTop, xLeft, 250, 600);
        });

        $('td.ApplyAction').mouseout(function (event) {
            $("#QualificationDIV").fadeToggle("fast");
        });
        $("#CloseMeLink").click(function (e) {

            $("#ResumeCoverLetterDIV").fadeToggle("fast");
            location.reload();
        });
    })

    function openApplicantQualification(cpnum, positionID, vTop, vLeft, vHeight, vWidth) {
        var applicant = $("#hfAutoCompletSelectedName").val();
        var goPage = "ApplyPositionNotQualS2.aspx?CPNum=" + cpnum + "&PositionID=" + positionID + "&Applicant=" + applicant;
        $("#QualificationiFrame").attr('src', goPage);
        $("#QualificationDIV").css({
            top: vTop,
            left: vLeft,
            height: vHeight,
            width: vWidth
        })
        $("#QualificationDIV").fadeToggle("fast");
    }

</script>


<script type="text/javascript" id="igClientScript1">

    function openApplyLate(schoolyear, schoolcode, positionID, CPNum, ApplyStartDate) {
        window.alert("Posting opens " + ApplyStartDate + ". Please try again later.");
    }
    function openApply(schoolyear, schoolcode, positionID, CPNum) {
        var goPage = "Loading2.aspx?pID=LTOTeachers/ApplyPosition2.aspx&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID + "&ApplyUserID=" + CPNum; //+ "&SchoolName=" + schoolname;
        openDetailPage(630, 800, goPage, "Apply Open Position");
    }
    function openApplyNotQualified(schoolyear, schoolcode, positionID, CPNum) {
        window.alert("You do not currently hold the qualifications for this position.");
        //  var goPage = "Loading2.aspx?pID=LTOTeachers/ApplyPositionNotQual.aspx&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID + "&ApplyUserID=" + CPNum; //+ "&SchoolName=" + schoolname;
        //  openDetailPage(550, 720, goPage, "Not Qualified Open Position");
    }
    function openLocationMap(schoolcode, schoolname) {
        var goPage = "Loading2.aspx?pID=LTOTeachers/LocationMap.aspx&SchoolCode=" + schoolcode
        openDetailPage(560, 650, goPage, schoolname + " Location");
    }
    function openDetailPage(vHeight, vWidth, goPage, pTitle) {

        try {
            var vLeft = (screen.width / 2) - (vWidth / 2) - 100;
            var vTop = (screen.height / 2) - (vHeight / 2) - 100;
            $("#PositionDetailFrame", parent.document).attr('src', goPage);
            $("#PositionDetailFrame", parent.document).attr('scrolling', "no");

            $("#popPagetitle", parent.document).text(pTitle);
            $("#hfInvokePageFrom", parent.document).val("LTOTeachers/ApplyPositionList2.aspx");
            $("#PositionDetailDIV", parent.document).css({
                top: vTop,
                left: vLeft,
                height: vHeight,
                width: vWidth
            });
            //   PopUpDIV2();
            $("#PopUpDIV", parent.document).fadeToggle("fast");
            $("#PositionDetailDIV", parent.document).fadeToggle("fast");
        }

        catch (e) { }
    }
    function openResumeCoverLetter(type, schoolYear, ids, cpNum, positionID, grantView) {
        var goPage = "FileShow.aspx?Type=" + type + "&IDs=" + ids + "&CPNum=" + cpNum + "&PositionID=" + positionID + "&SchoolYear=" + schoolYear;
        window.open(goPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,width=700 height=500, top=50, left=50");

    }
    function openFileUpload(type, schoolyear, cpnum, positionID) {
        var vTop = 200;
        var vLeft = 100;
        var vHeight = 200;
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

<script>
    function pageLoad(sender, args) {
        AutoCompleteComboBox();
        $(".custom-combobox-input").focus();
        // $("#combobox").focus();

    }
</script>
