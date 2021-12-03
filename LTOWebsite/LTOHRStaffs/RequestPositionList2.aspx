<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RequestPositionList2.aspx.vb" Inherits="RequestPositionList2"
    EnableTheming="true" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Request open Position List</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-Store,no-Cache" />
    <link href="../Styles/ListPage.css" rel="stylesheet" type="text/css" />
    <link href="../JQuery-UI/jquery-ui.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        body {
            height: 100%;
            width: 100%;
            margin:0px;
        }

        div {
            font-family: Arial;
            font-size: small;
        }
 


        .WDG {
            height: 100%;
            width: 99.9%;
        }

        .DataContentTile {
            font-family: Arial;
            font-size: small;
            font-weight: 300;
            color: blue;
        }

        .SubstituedCell {
            color: red;
            text-decoration: underline;
        }


        .highlightBoard {
            border: 2px blue solid;
        }

        .defaultBoard {
            border: 0px blue solid;
        }



        .emptyData {
            font-size: xx-large;
            text-align: center;
            color: blue;
        }

        .FixedHeader {
            position: absolute;
            font-weight: bold;
            width: 100%;
            display: block;
        }


        /*table tbody tr:nth-child(odd) {
            background-color: lightyellow;
        }*/
    </style>
    <style type="text/css" id="Grid view">
        .ListHeader {
            height: 20px;
        }

        #ui-datepicker-div, #ui-datepicker2-div {
            /*padding-top:5px;*/
            z-index: 900;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
            <Services>
                <asp:ServiceReference Path="~/WebServices/WebService.asmx" />
            </Services>
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <div style="display: inline;">

                                <asp:Label ID="Label3" runat="server" Text="School Year: " Visible="false"></asp:Label>
                                <asp:DropDownList ID="ddlSchoolYear" runat="server" Width="85px" SkinID="ddlSmall" AutoPostBack="True" 
                                    Enabled="true">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlappType" runat="server" Width="55px" Visible="true" SkinID="ddlSmall" AutoPostBack="True" >
                                    <asp:ListItem>POP</asp:ListItem>
                                    <asp:ListItem>LTO</asp:ListItem>
                                    <asp:ListItem>COP</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="lblSuperArea" runat="server" Text="Search by"></asp:Label>
                                <asp:DropDownList ID="ddlSearchby" runat="server" Width="120px" SkinID="ddlSmall" Visible="true" AutoPostBack="True" >
                                    <%--  <asp:ListItem Selected="True">All</asp:ListItem>
                                  <asp:ListItem>Area</asp:ListItem>
                                    <asp:ListItem>School</asp:ListItem>
                                    <asp:ListItem>Title</asp:ListItem>
                                    <asp:ListItem>Level</asp:ListItem>
                                    <asp:ListItem Value="PostingNum">Posting Number</asp:ListItem>
                                    <asp:ListItem Value="PostingState">Posting State</asp:ListItem>
                                    <asp:ListItem Value="PostingCycle">Posting Cycle</asp:ListItem>
                                    <asp:ListItem Value="PublishDate">Publish Date</asp:ListItem>
                                    <asp:ListItem Value="DeadlineDate">Deadline Date</asp:ListItem>
                                    <asp:ListItem Value="OpenDate">Posting Open Date</asp:ListItem>
                                    <asp:ListItem Value="CloseDate">Posting Close Date</asp:ListItem>
                                    <asp:ListItem Value="PositionStartDate">Position Start Date</asp:ListItem>
                                    <asp:ListItem Value="PositionEndDate">Position End Date</asp:ListItem>
                                    <asp:ListItem Value="PositionStatus">Position Status</asp:ListItem>
                                    <asp:ListItem Value="PendingConfirm">Pending Confirm</asp:ListItem>
                                    <asp:ListItem>Applicants </asp:ListItem>--%>
                                </asp:DropDownList>

                                <asp:DropDownList ID="ddlSearchbyValue" runat="server" Width="150px" SkinID="ddlSmall" Visible="true" AutoPostBack="False"  >
                                </asp:DropDownList>
                                <asp:TextBox ID="txtSearchBox" runat="server" Width="150px" Visible="false"  ></asp:TextBox>

                                <input runat="server" visible="false" type="text" id="datepicker" size="10" />
                                <asp:Label ID="DateTo" runat="server" Text="To"></asp:Label>
                                <input runat="server" visible="false" type="text" id="datepicker2" size="10" />
                                <%-- <div id="PanelDIV" runat="server" style="display: inline;">
                                    IN 
                    
                                    <asp:DropDownList ID="ddlPanel" runat="server" Width="90px" SkinID="ddlSmall" AutoPostBack="True">
                                        <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
                                        <asp:ListItem Value="02">Elementary</asp:ListItem>
                                        <asp:ListItem Value="05">Secondary</asp:ListItem>
                                    </asp:DropDownList>
                                </div>--%>
                                <asp:DropDownList ID="ddlOpenClose" runat="server" Width="60px" SkinID="ddlSmall" AutoPostBack="False"  >
                                    <asp:ListItem>All</asp:ListItem>
                                    <asp:ListItem Selected="True">Open</asp:ListItem>
                                    <asp:ListItem>Close</asp:ListItem>
                                </asp:DropDownList>

                                <asp:Button ID="btnSearch" runat="server" Text="Go" />
                                <asp:CheckBox ID="cb4Th" runat="server" Text="4th Round" />
                                <asp:Label ID="Labelemail" runat="server" Text="       "></asp:Label>
                                <asp:Button ID="btnNewOpen" runat="server" Text="Add New Open Position" Width="160px" />





                                <asp:HiddenField ID="HiddenFieldUserRole" runat="server" />
                            </div>
                        </td>
                        <td>
                            <div class="loading">

                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <img src="../images/indicator.gif" alt="" />
                                        <b>Searching.....</b>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>

                            </div>
                        </td>
                        <td>
                            <div style="display: inline">
                                <img src="../images/excel.bmp" />
                                <asp:LinkButton ID="btnExcel" runat="server">Export the List to EXCEL </asp:LinkButton>

                                <a visible="false" id="emailRemind" runat="server" href="javascript:openRemindPrincipalEmail()">
                                    <img src="../images/emailTo.png" alt="" title="Reminder the Principal to complete Hiring Process by eMail" style="border-width: 1px; border-color: Purple;" />
                                    Send Reminder email to Principal
                                </a>
                                <asp:HiddenField ID="hfSchoolCode" runat="server" />
                                <asp:HiddenField ID="hfUserID" runat="server" />
                            </div>
                        </td>
                    </tr>
                    <tr><td colspan="3">
                         <asp:Label runat="server" ID="Label1" Font-Size="X-Small" ForeColor="red" Text="* Click on the Edit button to open position details"> </asp:Label>

                        </td></tr>
                </table>

            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>


                <div id="DivRoot" >
                    <div style="overflow: hidden;width:100% " id="DivHeaderRow">
                        <table id="GridView2" tabindex="999" style="border: 1px ridge gray; background-color: white;" rules="all" cellspacing="1" cellpadding="1">
                        </table>
                    </div>

                     <div style="overflow: scroll; width: 100%; height: 100%" onscroll="OnScrollDiv(this)" id="DivMainContent">

                        <asp:GridView ID="GridView1" runat="server" CellPadding="1" Height="100%" Width="100%"
                            GridLines="Both" AutoGenerateColumns="False" BackColor="White" ShowHeader="true" ShowHeaderWhenEmpty="true"
                            EmptyDataText="No posting position" EmptyDataRowStyle-CssClass="emptyData"
                            BorderColor="gray" BorderStyle="Ridge" BorderWidth="1px" CellSpacing="1">
                            <Columns>


                                <asp:BoundField DataField="SchoolYear" ReadOnly="True" Visible="False" />
                                <asp:BoundField DataField="SchoolCode" ReadOnly="True" Visible="False" />
                                <asp:BoundField DataField="PositionID" ReadOnly="True" Visible="False" />
                                <asp:BoundField DataField="RowNo" HeaderText="No.">
                                    <ItemStyle Width="2%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PostingNumber" HeaderText="Posting Number">
                                    <ItemStyle Width="2%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Step">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="Link1" runat="server" Text='<%# Bind("CurrentStep") %>'>  </asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Width="2%" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="Link2" runat="server" Text='<%# Bind("ActionSign") %>'>  </asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Width="2%" Wrap="False" />
                                </asp:TemplateField>

                                <asp:BoundField DataField="PositionState" HeaderText="Open Status">
                                    <ItemStyle Width="2%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DatePublish" HeaderText="Publish Date">
                                    <ItemStyle Width="4%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DateApplyOpen" HeaderText="Posting Open">
                                    <ItemStyle Width="4%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DateApplyClose" HeaderText="Posting Close">
                                    <ItemStyle Width="4%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SchoolArea" HeaderText="School Area">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SchoolName" HeaderText="School">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PositionTitle" HeaderText="Position Title ">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ReplaceTeacher" HeaderText="Teacher being Replaced">
                                    <ItemStyle Width="8%" Wrap="true" />

                                </asp:BoundField>
                                <asp:BoundField DataField="FTE" HeaderText="FTE">
                                    <ItemStyle Width="2%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FTEPanel" HeaderText="AM/PM">
                                    <ItemStyle Width="2%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="PositionLevel" HeaderText="Division Required">
                                    <ItemStyle Width="8%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Qualification" HeaderText="Minimum Qualification ">
                                    <ItemStyle Width="9%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Description" HeaderText="Position Description">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Comments" HeaderText="HR Notes">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="PostingCycle" HeaderText="Posting Round">
                                    <ItemStyle Width="2%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RequestSource" HeaderText="Source">
                                    <ItemStyle Width="2%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SubstituedSign" HeaderText="" Visible="False" ItemStyle-CssClass="SubstituedCell">
                                    <ItemStyle Width="" />
                                </asp:BoundField>

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
   
 
            </ContentTemplate>
        </asp:UpdatePanel>

        <%--        <div style="color: Red; font-size: x-small">
            <asp:Label runat="server" ID="remaind22" Text="* Click on the Edit button to open position details"> </asp:Label>
        </div>
        --%>
    </form>
</body>
</html>

<script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
<script src="../JQuery-UI/jquery-ui-1.11.4.min.js" type="text/javascript"></script>
<script src="../Scripts/CommonDOM.js" type="text/javascript"></script>

<script src="../Scripts/GridViewLayout.js" type="text/javascript"></script>

<%--<script type="text/javascript">
    var appInsights = window.appInsights || function (config) {
        function r(config) { t[config] = function () { var i = arguments; t.queue.push(function () { t[config].apply(t, i) }) } } var t = { config: config }, u = document, e = window, o = "script", s = u.createElement(o), i, f; for (s.src = config.url || "//az416426.vo.msecnd.net/scripts/a/ai.0.js", u.getElementsByTagName(o)[0].parentNode.appendChild(s), t.cookie = u.cookie, t.queue = [], i = ["Event", "Exception", "Metric", "PageView", "Trace"]; i.length;) r("track" + i.pop()); return r("setAuthenticatedUserContext"), r("clearAuthenticatedUserContext"), config.disableExceptionTracking || (i = "onerror", r("_" + i), f = e[i], e[i] = function (config, r, u, e, o) { var s = f && f(config, r, u, e, o); return s !== !0 && t["_" + i](config, r, u, e, o), s }), t
    }({
        instrumentationKey: "e29264b3-c405-47ea-9099-9b2311cee1ef"
    });

    window.appInsights = appInsights;
    appInsights.trackPageView();
</script>--%>

<script type="text/javascript">


    var Publish = {
        "Operate": "Publish",
        "SchoolYear": $("#ddlSchoolYear").val(),
        "SchoolCode": $("#hfSchoolCode").val(),
        "PositionType": $("#ddlappType").val(),
        "PositionID": 0,
        "UserID": $("#hfUserID").val(),
        "DataSource": "DB"
    }

    var searchList = {
        "Operate": "General",
        "Para0": $("#ddlSchoolYear").val(),
        "Para1": $("#hfSchoolCode").val(),
        "Para2": $("#ddlappType").val(),
        "Para3": ""
    }


    function ReLoadPage(chageContent) {
        if (chageContent == "Yes") {
            $("#btnSearch").click();
        }
    }


    function openEditPosition(schoolyear, schoolcode, positionID) {
        // var goPage = "Loading2.aspx?pID=LTOHRStaffs/RequestPositionDetails.aspx&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID;
        var goPage = "Loading2.aspx?pID=LTOHRStaffs/RequestPositionDetails2.aspx&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID;

        if ($("#HiddenFieldUserRole").val() != "Superintendent") {
            openDetailPage(550, 790, goPage, "Position Detail Edit Page");
        }
    }
    function openSteps() {
        var goPage = "Loading2.aspx?pID=LTOHRStaffs/PostingProcessSteps.aspx"
        openDetailPage(300, 500, goPage, "Position Posting Steps");
    }
    function openRemindPrincipalEmail() {
        var goPage = "Loading2.aspx?pID=LTOHRStaffs/ReminderToPrincipal.aspx"
        openDetailPage(500, 600, goPage, "Send a Reminder Email to Principal");

    }
    var currentTR;
    function pageLoad(sender, args) {

        $(document).ready(function () {
            LoadDatePicker();
            var vHeight = window.innerHeight - 100;
            MakeStaticHeader("GridView1", vHeight, 1500, 25, false, "DivHeaderRow", "GridView2", "DivMainContent");
            $(window).resize(function () {
                MakeStaticHeader("GridView1", vHeight, 1500, 25, false, "DivHeaderRow", "GridView2", "DivMainContent");
            });

            $("#btnNewOpen").click(function (e) {
                Publish.SchoolYear = $("#ddlSchoolYear").val();
                Publish.SchoolCode = $('#hfSchoolCode').val();
                Publish.PositionType = $("#ddlappType").val();
                var searchby = $("#ddlSearchby").val();
                if (searchby == "School") {
                    Publish.Schoolcode = $("#ddlSearchbyValue").val();
                }


                WebService.CreateNewPublishRequest("New", Publish, onSuccess, onFailure);


                //  var goPage = "Loading2.aspx?pID=LTOHRStaffs/RequestPositionDetails2.aspx&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=0000";
                //  var goPage = "Loading2.aspx?pID=LTOHRStaffs/RequestPositionDetails.aspx&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=0000";
                //   openDetailPage(550, 650, goPage, "Add New Open Position")
                return false;
            });

            $("#CloseMeLink").click(function (e) {
                CloseMe();
            });
            $("#btnExcel").click(function (e) {
                var schoolyear = $("#ddlSchoolYear").val();
                var appType = $("#ddlappType").val();
                var panel = $("#ddlPanel").val();
                var openClose = $("#ddlOpenClose").val();
                var searchby = $("#ddlSearchby").val();
                var searchValue1 = $("#ddlSearchbyValue").val();
                var searchValue2 = $("#txtSearchBox").val();
                var th4Round = "0";
                if ($("#cb4Th").prop("checked")) {
                    th4Round = "1";
                }

                if (searchby == "Title") {
                    searchValue1 = $("#txtSearchBox").val();
                    searchValue2 = "";
                }
                if (searchby == "PublishDate" || searchby == "DeadlineDate" || searchby == "PositionStartDate" || searchby == "PositionEndDate") {
                    searchValue1 = $("#datepicker").val();
                    searchValue2 = $("#datepicker2").val();
                }
                var goPage = "../PDFLoading/EXCELDocument_Loading.aspx?rID=PositionList_Publish&yID=" + schoolyear + "&AppType=" + appType + "&Panel=" + panel + "&OpenClose=" + openClose + "&SearchBy=" + searchby + "&SearchValue1=" + searchValue1 + "&SearchValue2=" + searchValue2 + "&th4Round=" + th4Round;

                window.open(goPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,width=450 height=300, top=10, left=10");
                return false;
            });

            //$('#GridView1 tr').mouseenter(function (event) {
            //    if (currentTR != undefined) { currentTR.removeClass("highlightBoard"); }
            //    currentTR = $(this)
            //    //  $(this).addClass("highlightBoard");
            //    currentTR.addClass("highlightBoard");
            //});

            //$("#ddlSearchby").change(function (event) {

            //    var JsonDataSource = "Area,PostingCycle,PostingState,Panel";
            //    var ListDataSource = "Area,PostingCycle,PostingState,Panel,School,Level,PendingConfirm,PositionStatus";
            //    var DateDataSource = "PublishDate,PositionStartDate,PositionEndDate,DeadlineDate,OpenDate,CloseDate";
            //    var searchby = $("#ddlSearchby").val();
            //    searchList.Operate = searchby
            //    var dataSource = "DB"
            //    if (JsonDataSource.indexOf(searchby) >= 0) {
            //        Publish.DataSource = "Json";
            //    }
            //    var SearchType = "Text";
            //    if (DateDataSource.indexOf(searchby) >= 0) { SearchType = "Date"; }
            //    if (ListDataSource.indexOf(searchby) >= 0) { SearchType = "List"; }

            //    $("#txtSearchBox").hide();
            //    $("#ddlSearchbyValue").hide();
            //    $("#datepicker").hide();
            //    $("#datepicker2").hide();
            //    $("#DateTo").hide();
            //    switch (SearchType) {
            //        case "List":
            //            $("#ddlSearchbyValue").show();
            //            var searbyValueList = BuildSearchbyValueList_WSCall(dataSource);
            //            break;
            //        case "Date":

            //            $("#datepicker").show();
            //            $("#datepicker2").show();
            //            $("#DateTo").show();
            //            var cDate = new Date();
            //            $("#datepicker").val(cDate.Now);
            //            $("#datepicker2").val(cDate.Now);
            //            break;
            //        default:
            //            $("#txtSearchBox").show();

            //    }




            //   // var searbyValueList = BuildSearchbyValueList_WSCall(dataSource);
            //    //  var searbyValueList = BuildSearchbyValueList_APICall(); 
            //    //var searbyValueList = BuildSearchbyValueList_JsonCall();

            //});
        });

    }

    function onSuccess(result) {

        if (result) {
            Publish.PositionID = result
            var schoolyear = Publish.SchoolYear; // $("#ddlSchoolYear").val();
            var schoolcode = Publish.SchoolCode;  // $("#ddlschoolcode").val();
            var positionID = result;
            var goPage = "Loading2.aspx?pID=LTOHRStaffs/RequestPositionDetails2.aspx&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID;

            openDetailPage(550, 790, goPage, "Add new Publish Position")
        }
    }
    function onSuccess_SetSearchListValue(result) {
        var list = "";
        var myObj = result;
        // debugger;
        $("#ddlSearchbyValue").html("");
        for (x in myObj) {
            list += "<option value ='" + myObj[x].Value + "'>" + myObj[x].Name + "</option>";
        }
        $("#ddlSearchbyValue").html(list);
    }
    function BuildSearchbyValueList_APICall() {
        var servername = "https://webservice.tcdsb.org";
        var api = "/Webapi/LTO/api/DDLList";
        var parameters = "?operate=" + Publish.Operate + "&userID=mif&schoolYear=" + Publish.SchoolYear + "&schoolCode=" + Publish.SchoolCode + "&positionType=" + Publish.PositionType;
        var httpLink = servername + api + parameters;
        window.alert(httpLink);
        jQuery.support.cors = true;
        $.ajax({
            url: httpLink,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                onSuccess_SetSearchListValue(data);
            },
            error: function (ex) {
                window.alert(data);
            }
        });

    }
    function BuildSearchbyValueList_WSCall(dataSource) {
        var list = WebService.SearchbyValueList(dataSource, searchList, onSuccess_SetSearchListValue, onFailure);

    }
    function BuildSearchbyValueList_JsonCall(dataSource) {
        var list = WebService.SearchbyValueList(dataSource, searchList, onSuccess_SetSearchListValue, onFailure);

    }

    function onFailure(result) {
        window.alert("Publish Position failed !");
    }

    function LoadDatePicker() {
        JDatePicker.InitialL($("#datepicker"));
        JDatePicker.InitialL($("#datepicker2"));
    }

    function openDetailPage(vHeight, vWidth, goPage, pTitle) {
        $(document).ready(function () {
            try {
                var vLeft = (screen.width / 2) - (vWidth / 2) - 100;
                var vTop = (screen.height / 2) - (vHeight / 2) - 50;
                $("#PositionDetailFrame", parent.document).attr('src', goPage);
                $("#popPagetitle", parent.document).text(pTitle);
                $("#hfInvokePageFrom", parent.document).val("LTOHRStaffs/RequestPositionList.aspx");
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

<%--<script type="text/javascript">
    function MakeStaticHeader(gridId, height, width, headerHeight, isFooter) {
        var tbl = document.getElementById(gridId);
        if (tbl) {
            var DivHR = document.getElementById('DivHeaderRow');
            var DivHeader = document.getElementById('GridView2');
            var DivMC = document.getElementById('DivMainContent');
            //   var DivFR = document.getElementById('DivFooterRow');

            //*** Set divheaderRow Properties ****
            DivHR.style.height = headerHeight + 'px';
            DivHR.style.width = '99%';// (parseInt(width) - 16) + 'px';
            DivHR.style.position = 'relative';
            DivHR.style.top = '0px';
            DivHR.style.zIndex = '10';
            DivHR.style.verticalAlign = 'top';

            //*** Set divMainContent Properties ****
            DivMC.style.width = '100%'; // width + 'px';
            DivMC.style.height = height + 'px';
            DivMC.style.position = 'relative';
            DivMC.style.top = -headerHeight + 'px';
            DivMC.style.zIndex = '1';

            //*** Set divFooterRow Properties ****
            //DivFR.style.width = (parseInt(width) - 16) + 'px';
            //DivFR.style.position = 'relative';
            //DivFR.style.top = -headerHeight + 'px';
            //DivFR.style.verticalAlign = 'top';
            //DivFR.style.paddingtop = '2px';

            //if (isFooter) {
            //    var tblfr = tbl.cloneNode(true);
            //    tblfr.removeChild(tblfr.getElementsByTagName('tbody')[0]);
            //    var tblBody = document.createElement('tbody');
            //    tblfr.style.width = '100%';
            //    tblfr.cellSpacing = "0";
            //    tblfr.border = "0px";
            //    tblfr.rules = "none";
            //    //*****In the case of Footer Row *******
            //    tblBody.appendChild(tbl.rows[tbl.rows.length - 1]);
            //    tblfr.appendChild(tblBody);
            //    DivFR.appendChild(tblfr);
            //}
            //****Copy Header in divHeaderRow****
            //   DivHR.appendChild(tbl.cloneNode(true));

            //   DivHR.appendChild(tableH );
            DivHeader.appendChild(tbl.rows['0'].cloneNode(true));
            DivHeader.appendChild(tbl.rows['1'].cloneNode(true));
            //   DivHR.appendChild("</table>"  );
            //   div.insertAdjacentHTML('beforeend', str);

            //   addGridViewHeader();
        }
    }

    function addGridViewHeader() {
        var index = 0
        //  var $myHeader = $("#GridView1").clone(true);


        $('#GridView1 > tbody  > tr:not(:first)').each(function () {
            var t1 = $(this).text();
            $(this).find('td').each(function (i, el) {
                var myHeaderStyle = this.style.cssText;
                //  window.alert(myHeaderStyle);
            });
            return false;
        })




    }

    function OnScrollDiv(Scrollablediv) {
        document.getElementById('DivHeaderRow').scrollLeft = Scrollablediv.scrollLeft;
        //   document.getElementById('DivFooterRow').scrollLeft = Scrollablediv.scrollLeft;
    }


</script>--%>
