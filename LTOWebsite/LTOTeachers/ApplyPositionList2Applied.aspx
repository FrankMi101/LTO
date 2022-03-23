<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ApplyPositionList2Applied.aspx.vb" Inherits="ApplyPositionList2Applied" EnableTheming="true" %>

<%@ Register Src="../uc/comment/SearchPosition.ascx" TagName="SearchPosition" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Avaiable LTO /POP Position List</title>
    <link href="../Styles/BubbleHelp.css" rel="stylesheet" />
    <link href="../JQuery-UI/jquery-ui.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/ListPage.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/autoCompleteDDL.css" rel="stylesheet" type="text/css" />
    <style>
       
    </style>
    <style type="text/css">
        body {
            height: 100%;
            width: 100%;
        }

        div {
            font-family: Arial;
            font-size: small;
        }

        .auto-style1 {
            height: 10%;
        }


        .WDG {
            height: 100%;
            width: 100%;
        }

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
        <div style="width: 100%">
            <asp:ScriptManager runat="server">
            </asp:ScriptManager>

            <table id="Table3" border="0" class="TableFont1" style="width: 100%;">

                <tr id="PublishRow" runat="server">
                    <td colspan="4">
                        <table class="TableFont1B">
                            <tr>
                                <td style="width: 30%;">

                                    <asp:HiddenField ID="SearchType" runat="server" />
                                    <asp:HiddenField ID="SearchForListValue1" runat="server" />
                                    <asp:HiddenField ID="SearchForListValue2" runat="server" />
                                    <uc1:SearchPosition ID="SearchPosition1" runat="server" />

                                </td>

                                <td>
                                    <asp:Button ID="btnSearch" runat="server" Text="Go" CssClass="GoButton" />
                                </td>
                                <td style="width: 5%">

                                    <asp:DropDownList ID="ddlappType" runat="server" Width="55px" Visible="true" SkinID="ddlSmall" AutoPostBack="True" Height="20px">
                                        <asp:ListItem>POP</asp:ListItem>
                                        <asp:ListItem>LTO</asp:ListItem>
                                    </asp:DropDownList>


                                </td>
                                <td>
                                    <a id="A1" runat="server" href='#' style="text-decoration: none; color: Gray">Loading.....</a>
                                </td>
                                <td style="width: 30%; text-align: center; text-wrap: avoid;">
                                    <div id="ApplicantForDeveloper" runat="server" visible="false">
                                        <div class="ui-widget">
                                            Search Teacher:
                                            <select id="combobox" runat="server" style="width: 250px; background-color: lightgoldenrodyellow" class="Search-Content-Control"
                                                ng-model="myText">
                                                <option value="">Select Teacher...</option>

                                            </select>
                                        </div>
                                        <asp:HiddenField ID="HiddenFieldTeacherName" runat="server" />
                                        <asp:HiddenField ID="HiddenFieldTeacherCPNum" runat="server" />
                                        <asp:HiddenField ID="hfQualification" runat="server" Value="All" />

                                        <%--                                        <asp:TextBox ID="txtSearchTeacher" runat="server" Width="60px" Visible="False"></asp:TextBox>--%>

                                        <%--<asp:DropDownList ID="ddlApplicant" runat="server" Width="150px" Height="23px" AutoPostBack="true" Visible="False"></asp:DropDownList>--%>
                                    </div>
                                </td>
                                <td>
                                    <asp:Button ID="btApplicant" runat="server" Text="Go" CssClass="GoButton" Visible="false"  />

                                </td>
                                <td style="width: 40%">

                                    <a id="aLTOTeacherList" visible="false" runat="server" href='https://webapp.tcdsb.org/WebDocuments/Documents/LTO/Long Term Occasional Teachers List.pdf' target="_blank">LTO Teacher List</a>
                                    <%--<a href="../Template/Long%20Term%20Occasional%20Teachers%20List.pdf">../TemplateXLS/Long Term Occasional Teachers List.pdf</a>--%>
                                </td>

                            </tr>
                        </table>
                    </td>
                </tr>

            </table>



            <div id="DivRoot">
                <div style="overflow: hidden;" id="DivHeaderRow">
                    <table id="GridView2" style="border: 1px ridge gray; width: 100%; height: 100%; background-color: white;">
                    </table>
                </div>

                <div style="overflow: scroll; height: 100%" onscroll="OnScrollDiv(this)" id="DivMainContent">
                    <asp:GridView ID="GridView1" runat="server" Height="100%" Width="100%"
                        GridLines="Both" AutoGenerateColumns="False" BackColor="White" ShowHeader="true" ShowHeaderWhenEmpty="true"
                        EmptyDataText="No available Position posted" EmptyDataRowStyle-CssClass="emptyData"
                        BorderColor="gray" BorderStyle="Ridge">
                        <Columns>
                            <asp:BoundField DataField="myKey" ReadOnly="True" Visible="False" />
                            <asp:BoundField DataField="SchoolYear" ReadOnly="True" Visible="False" />
                            <asp:BoundField DataField="SchoolCode" ReadOnly="True" Visible="False" />
                            <asp:BoundField DataField="RowNo" HeaderText="No." ItemStyle-CssClass="ApplyAction">
                                <ItemStyle Width="50px" />
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="Apply">
                                <ItemTemplate>
                                    <asp:HyperLink ID="Link2" runat="server" Text='<%# Bind("ActionSign") %>'>  </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Width="50px" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Resume">
                                <ItemTemplate>
                                    <asp:HyperLink ID="Link21" runat="server" Text='<%# Bind("UploadFile") %>'>  </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Width="50px" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Map">
                                <ItemTemplate>
                                    <asp:HyperLink ID="Link3" runat="server" Text='<%# Bind("SchoolMap") %>'>  </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Width="50px" Wrap="False" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="DateApplyStart" HeaderText="Posting Open">
                                <ItemStyle Width="70px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DateDeadline" HeaderText="Posting Close">
                                <ItemStyle Width="70px" />
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="Days to Close">
                                <ItemTemplate>
                                    <asp:HyperLink ID="Link5" runat="server" Text='<%# Bind("DaystoEndImg") %>'>  </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Width="60px" />
                            </asp:TemplateField>

                            <asp:BoundField DataField="SchoolArea" HeaderText="School Area">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SchoolName" HeaderText="School">
                                <ItemStyle Width="13%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PositionTitle" HeaderText="Position Title" ItemStyle-CssClass="EditTitle">
                                <ItemStyle Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PositionLevel" HeaderText="Division Required">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Qualification" HeaderText="Qualification" ControlStyle-CssClass="QualificationP" ItemStyle-CssClass="QualificationP">
                                <ItemStyle Width="12%" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Description" HeaderText="Position Description">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FTE" HeaderText="FTE">
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FTEPanel" HeaderText="AM/PM">
                                <ItemStyle Width="2%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PostingCycle" HeaderText="Posting Round">
                                <ItemStyle Width="80" HorizontalAlign="center" />
                            </asp:BoundField>

                            <asp:BoundField DataField="StartDate" HeaderText="Start Date">
                                <ItemStyle Width="90px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EndDate" HeaderText="End Date">
                                <ItemStyle Width="90px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="StartTime" HeaderText="Start Time">
                                <ItemStyle Width="60px" />
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
                <asp:Label runat="server" ID="remaind22" Text="* Click on the Apply button to apply the Position. Move mouse on the No. column, you can see the details message"> </asp:Label>
                <asp:HiddenField ID="hfCurrrentAvailableOpenPosition" runat="server" />
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


        $('td.QualificationP').click(function (event) {
            eventCell = $(this);

            var cellValue = $(this).closest('tr').find('td.QualificationP').text();

            $("#hfQualification").val(cellValue);
            $("#txtSearchBox").val(cellValue);
            $("#btApplicant").click();

        });
        $("#CloseMeLink").click(function (e) {

            $("#ResumeCoverLetterDIV").fadeToggle("fast");
              location.reload();
        });

        MakeStaticHeader("GridView1", 600, 1600, 30, false) 
    })


</script>


<script type="text/javascript" id="igClientScript1">

    function openApplyLate(schoolyear, schoolcode, positionID, CPNum, ApplyStartDate) {
        window.alert("Posting opens " + ApplyStartDate + ". Please try again later.");
    }
    function openApply(schoolyear, schoolcode, positionID, CPNum) {
        var goPage = "Loading2.aspx?pID=LTOTeachers/ApplyPosition2.aspx&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID + "&ApplyUserID=" + CPNum; //+ "&SchoolName=" + schoolname;
        openDetailPage(600, 720, goPage, "Apply Open Position");
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
        $(document).ready(function () {
            try {
                var vLeft = (screen.width / 2) - (vWidth / 2) - 100;
                var vTop = (screen.height / 2) - (vHeight / 2) - 100;
                $("#PositionDetailFrame", parent.document).attr('src', goPage);
                $("#popPagetitle", parent.document).text(pTitle);
                $("#hfInvokePageFrom", parent.document).val("LTOTeachers/ApplyPositionList2.aspx");
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
     function openResumeCoverLetter(type, schoolYear, ids, cpNum, positionID, grantView) {
        var goPage = "FileShow.aspx?Type=" + type + "&IDs=" + ids + "&CPNum=" + cpNum + "&PositionID=" + positionID + "&SchoolYear=" + schoolYear;
        window.open(goPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,width=700 height=500, top=50, left=50");

    }
    function openFileUpload(type, schoolyear, cpnum, positionID) {
        var vTop = 200;
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
 
 
<script>
    function pageLoad(sender, args) {
        AutoCompleteComboBox();
        $(".custom-combobox-input").focus();
    }
</script>