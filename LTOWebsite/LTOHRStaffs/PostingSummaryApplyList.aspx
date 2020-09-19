<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PostingSummaryApplyList.aspx.vb" Inherits="PostingSummaryApplyList" EnableTheming="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Avaiable LTO /POP Position List</title>
    <link href="../Styles/BubbleHelp.css" rel="stylesheet" />
    <link href="../Styles/ListPage.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        body {
            height: 100%;
            width: 100%;
        }

        div {
            font-family: Arial;
            font-size: small;
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

        .highlightBoard {
            border: 2px blue solid;
        }

        .defaultBoard {
            border: 0px blue solid;
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
                <tr id="SuperAreaRow" runat="server">
                    <td>
                        <asp:Label ID="lblSuperArea" runat="server" Text="School Area: "></asp:Label>

                        <asp:Label ID="Label3" runat="server" Text="School Year: "></asp:Label>


                    </td>
                    <td style="font-size: x-small">
                        <a id="openAnswerA" runat="server" href="javascript:openPrintPage(90,180)">
                            <img src="../images/print.bmp" alt="" title="Print SLIP One Page Summary" style="border-width: 1px; border-color: Purple;" />
                        </a>
                    </td>
                    <td></td>
                    <td style="font-size: x-small">

                        <asp:HiddenField ID="HiddenFieldUserRole" runat="server" />

                    </td>
                </tr>
                <tr id="PublishRow" runat="server">
                    <td colspan="4">
                        <table class="TableFont1B">
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlSchoolYear" runat="server" Width="100px" AutoPostBack="True" SkinID="ddlSmall"
                                        Enabled="true">
                                    </asp:DropDownList>
                                </td>

                                <td style="text-align: left; width: 100px;">

                                    <asp:DropDownList ID="ddlschoolcode" runat="server" Width="10px" Visible="false"></asp:DropDownList>

                                    <asp:TextBox ID="txtSearchBox" runat="server" Width="200px" Visible="true"></asp:TextBox>
                                </td>
                                <td style="width: 5%">
                                    <%-- <asp:Button ID="btnSearch" runat="server" Text="Go"  CssClass="GoButton" />--%>
                                </td>
                                <td style="width: 10%">

                                    <asp:DropDownList ID="ddlappType" runat="server" Width="70px" Visible="true" AutoPostBack="True" Height="20px">
                                        <asp:ListItem>POP</asp:ListItem>
                                        <asp:ListItem>LTO</asp:ListItem>
                                    </asp:DropDownList>


                                </td>
                                <td style="width: 3%">
                                    <a id="A1" runat="server" href='#' style="text-decoration: none; color: Gray">Loading.....</a>
                                </td>
                                <td style="width: 50%; text-align: left; text-wrap: avoid">
                                    <div id="ApplicantForDeveloper" runat="server" visible="false">
                                        Search by SurName:
                                        <asp:TextBox ID="txtSearchTeacher" runat="server" Width="100px"></asp:TextBox>
                                        <asp:Button ID="btApplicant" runat="server" Text="Go" CssClass="GoButton" />
                                        <asp:DropDownList ID="ddlApplicant" runat="server" Width="200px" Height="23px" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                </td>
                                <td></td>
                                <td style="width: 10%">

                                    <a id="aLTOTeacherList" runat="server" href='https://webapp.tcdsb.org/WebDocuments/Documents/LTO/Long Term Occasional Teachers List.pdf' target="_blank">LTO Teacher List</a>
                                    <%--<a href="../Template/Long%20Term%20Occasional%20Teachers%20List.pdf">../TemplateXLS/Long Term Occasional Teachers List.pdf</a>--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

            </table>

            <div id="TeacherOCT" runat="server" style="width: 100%; height: 100%; " >
                <asp:TextBox ID="TextTeacherOCT" runat="server" Height="100%" TextMode="MultiLine" Width="100%" ForeColor="blue" BackColor="Transparent" ReadOnly="true"></asp:TextBox>


            </div>

            <div id="DivRoot" align="left">
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
                            <asp:BoundField DataField="School_Year" ReadOnly="True" Visible="False" />
                            <asp:BoundField DataField="School_Code" ReadOnly="True" Visible="False" />
                            <asp:BoundField DataField="RowNo" HeaderText="No." ItemStyle-CssClass="ApplyAction">
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Posting_Num" HeaderText="Posting Number">
                                <ItemStyle Width="60px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Apply">
                                <ItemTemplate>
                                    <asp:HyperLink ID="Link2" runat="server" Text='<%# Bind("ApplySign") %>'>  </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Width="50px" Wrap="False" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="AppliedDate" HeaderText="Applied Date">
                                <ItemStyle Width="70px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Interview Select">
                                <ItemTemplate>
                                    <asp:HyperLink ID="Link3" runat="server" Text='<%# Bind("InterviewSign") %>'>  </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Width="50px" Wrap="False" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Result" HeaderText="Interview Outcome">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Hired Recommend">
                                <ItemTemplate>
                                    <asp:HyperLink ID="Link4" runat="server" Text='<%# Bind("HiredSign") %>'>  </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Width="50px" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Map">
                                <ItemTemplate>
                                    <asp:HyperLink ID="Link3" runat="server" Text='<%# Bind("LocationMap") %>'>  </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Width="50px" Wrap="False" />
                            </asp:TemplateField>
                             

                            <asp:BoundField DataField="ApplyEndDate" HeaderText="Dead Line to Apply">
                                <ItemStyle Width="70px" />
                            </asp:BoundField>


                            <%--  <asp:BoundField DataField="School_Area" HeaderText="School Area">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="School_Name" HeaderText="School">
                                <ItemStyle Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PositionTitle" HeaderText="Position Title" ItemStyle-CssClass="EditTitle">
                                <ItemStyle Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PositionLevel" HeaderText="Mandatory Qualification">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>

                            <asp:BoundField DataField="PositionQualification" HeaderText="Minimum Qualification" ControlStyle-CssClass="QualificationP" ItemStyle-CssClass="QualificationP">
                                <ItemStyle Width="12%" />
                            </asp:BoundField>

                            <asp:BoundField DataField="PositionDescription" HeaderText="Position Description">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PostingCycle" HeaderText="Posting Round">
                                <ItemStyle Width="80" HorizontalAlign="center" />
                            </asp:BoundField>

                            <asp:BoundField DataField="SchoolStartDate" HeaderText="Start Date">
                                <ItemStyle Width="90px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SchoolEndDate" HeaderText="End Date">
                                <ItemStyle Width="90px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SchoolStartTime" HeaderText="Start Time">
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

    </form>
</body>
</html>


<script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>


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

    var currentTR;
    $(document).ready(function () {
        var openPositionCount = $("#hfCurrrentAvailableOpenPosition").val();


        $('td.QualificationP').click(function (event) {
            eventCell = $(this);

            var cellValue = $(this).closest('tr').find('td.QualificationP').text();

            $("#hfQualification").val(cellValue);
            $("#txtSearchBox").val(cellValue);
            $("#btApplicant").click();

        });
        $('#GridView1 tr').mouseenter(function (event) {
            if (currentTR != undefined)
            { currentTR.removeClass("highlightBoard"); }
            currentTR = $(this)

            currentTR.addClass("highlightBoard");

        });
        //$('#GridView1 tr').mouseleave(function (event) {
        //    eventCell = $(this);

        //    $(this).removeClass("highlightBoard");
        //    // .removeClass( "myClass noClass" ).addClass( "yourClass" );
        //});

        $('td.ApplyAction').mouseenter(function (event) {
            eventCell = $(this);
            // var cellValue = $(this).closest('tr').find('td.QualificationP').text();
            var positionID = $(this).closest('tr').find('td.EditPosiitonID').text();
            var title = $(this).closest('tr').find('td.EditTitle').text();
            var cpnum = $("#ddlApplicant").val();
            $("#LabelTitle").text(title + " - " + positionID + " - " + cpnum);
           
            var xTop = mousey; // event.currentTarget.offsetTop;
            if (xTop > 250)
            { xTop = mousey - 250 }
            var xLeft = event.currentTarget.offsetLeft + 100;

            openApplicantQualification(cpnum, positionID, xTop, xLeft, 250, 600);
        });

        $('td.ApplyAction').mouseout(function (event) {
            $("#QualificationDIV").fadeToggle("fast");
        });
        MakeStaticHeader("GridView1", 600, 1200, 30, false)
    })

    function openApplicantQualification(cpnum, positionID, vTop, vLeft, vHeight, vWidth) {
        var goPage = "../LTOTeachers/ApplyPositionNotQualS.aspx?CPNum=" + cpnum + "&PositionID=" + positionID;
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


    function openApply(schoolyear, schoolcode, positionID, CPNum) {
        var goPage = "Loading2.aspx?pID=LTOTeachers/ApplyPosition.aspx&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID + "&ApplyUserID=" + CPNum; //+ "&SchoolName=" + schoolname;
        openDetailPage(600, 720, goPage, "Apply Open Position");
    }
    function openApplyNotQualified(schoolyear, schoolcode, positionID, CPNum) {
        var goPage = "Loading2.aspx?pID=LTOTeachers/ApplyPositionNotQual.aspx&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID + "&ApplyUserID=" + CPNum; //+ "&SchoolName=" + schoolname;
        openDetailPage(550, 720, goPage, "Not Qualified Open Position");
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
                $("#hfInvokePageFrom", parent.document).val("LTOTeachers/ApplyPositionList.aspx");
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


</script>

<script type="text/javascript">
    function MakeStaticHeader(gridId, height, width, headerHeight, isFooter) {
        var tbl = document.getElementById(gridId);
        if (tbl) {
            var DivHR = document.getElementById('DivHeaderRow');
            var DivHeader = document.getElementById('GridView2');
            var DivMC = document.getElementById('DivMainContent');
            //   var DivFR = document.getElementById('DivFooterRow');

            //*** Set divheaderRow Properties ****
            DivHR.style.height = headerHeight + 'px';
            DivHR.style.width = (parseInt(width) - 16) + 'px';
            DivHR.style.position = 'relative';
            DivHR.style.top = '0px';
            DivHR.style.zIndex = '10';
            DivHR.style.verticalAlign = 'top';

            //*** Set divMainContent Properties ****
            DivMC.style.width = width + 'px';
            DivMC.style.height = height + 'px';
            DivMC.style.position = 'relative';
            DivMC.style.top = -headerHeight + 'px';
            DivMC.style.zIndex = '1';


            //****Copy Header in divHeaderRow****
            //   DivHR.appendChild(tbl.cloneNode(true));

            DivHeader.appendChild(tbl.rows['0'].cloneNode(true));
            DivHeader.appendChild(tbl.rows['1'].cloneNode(true));

        }
    }


    function OnScrollDiv(Scrollablediv) {
        document.getElementById('DivHeaderRow').scrollLeft = Scrollablediv.scrollLeft;
    }


</script>
