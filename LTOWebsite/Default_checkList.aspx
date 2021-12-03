<%@ Page Language="vb" AutoEventWireup="false" Inherits="Default_checkList"
    CodeFile="Default_checkList.aspx.vb" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Avaiable LTO /POP Position List</title>
    <link href="../Styles/BubbleHelp.css" rel="stylesheet" />
    <link href="./Styles/ListPage.css" rel="stylesheet" type="text/css" />

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

        #PopUpDIV {
            z-index: 100;
            position: absolute;
            top: 0;
            left: 0;
            background: #56c0e9;
            opacity: 0.6;
            filter: alpha(opacity=60);
            height: 99%;
            width: 99%;
        }

        #DetailDIV {
            z-index: 999;
            overflow: hidden;
            border: outset 2px purple;
            width: 100%;
            height: 100%;
        }

        #DetailFrame {
            border: 0px solid red;
            width: 100%;
            height: 100%;
        }

        #GridView1 tbody tr th {
            border-right: 1px white solid;
        }

        #GridView3 tbody tr th {
            border-right: 1px white solid;
        }

       .commentsHR {
            Z-INDEX: 10;
            position: absolute;

        }
        .boardPending {
            border: 2px #ff6a00 solid;
        }
         .boardColor {
            border: 2px #0094ff solid;
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
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table class="TableFont1B">
                                    <tr>

                                        <td style="display: none">Type:
                                 
                                            <asp:DropDownList ID="ddlappType" runat="server" Width="80px" AutoPostBack="True" Height="20px">
                                                <asp:ListItem Value="">All</asp:ListItem>
                                                <asp:ListItem>Roster</asp:ListItem>
                                                <asp:ListItem>LTOTeacher</asp:ListItem>
                                            </asp:DropDownList>



                                        </td>
                                        <td>Search by:
                                                
                                            <asp:DropDownList ID="ddlSearchType" runat="server" Width="100px" Height="20px" SkinID="ddlSmall">
                                                <asp:ListItem>SurName</asp:ListItem>
                                                <asp:ListItem>CPNum</asp:ListItem>

                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtSearchTeacher" runat="server" Width="160px"></asp:TextBox>
                                            <asp:Button ID="btnSearch" runat="server" Text="Go" CssClass="GoButton" />

                                        </td>
                                        <td style="width: 50%">
                                            <a id="A1" runat="server" href='#' style="text-decoration: none; color: Gray">Loading.....</a>
                                        </td>
                                       
                                        <td style="width: 10%">

                                            <a id="aLTOTeacherList" runat="server" href='https://webapp.tcdsb.org/WebDocuments/Documents/LTO/Long Term Occasional Teachers List.pdf' target="_blank">LTO Teacher List</a>
                                        </td> 
                                        <td style="width: 10%">

                                            <a id="PendingComments" runat="server" href="javascript:openHRPeningList()" >HR Pending Comments</a>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>

            </table>

            <div>LTO / Roster List </div>

            <div id="DivRoot" align="left">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div style="overflow: hidden;" id="DivHeaderRow">
                            <table id="GridView2" style="border: 1px ridge gray; width: 100%; height: 100%; background-color: white;">
                            </table>
                        </div>
                        <div style="overflow: scroll; height: 250px" onscroll="OnScrollDiv(this)" id="DivMainContent">
                            <asp:GridView ID="GridView1" runat="server" Height="100%" Width="100%"
                                GridLines="Both" AutoGenerateColumns="False" BackColor="White" ShowHeader="true" ShowHeaderWhenEmpty="true"
                                EmptyDataText="The search person is not in LTO/Roster list" EmptyDataRowStyle-CssClass="emptyData"
                                BorderColor="gray" BorderStyle="Ridge">
                                <Columns>
                                    <asp:BoundField DataField="myKey" ReadOnly="True" Visible="False" />
                                    <asp:BoundField DataField="RowNo" HeaderText="No." ItemStyle-CssClass="ApplyAction">
                                        <ItemStyle Width="50px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link1" runat="server" Text='<%# Bind("LTOAction") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Apply">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link2" runat="server" Text='<%# Bind("ApplySign") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" Wrap="False" />
                                    </asp:TemplateField>


                                    <asp:BoundField DataField="UserID" HeaderText="UserID">
                                        <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CPNum" HeaderText="CPNum">
                                        <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OTType" HeaderText="Type">
                                        <ItemStyle Width="100px" />
                                    </asp:BoundField>

                                    <%--    <asp:BoundField DataField="TeacherName" HeaderText="Name">
                                        <ItemStyle Width="150px" />
                                    </asp:BoundField>--%>

                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link3" runat="server" Text='<%# Bind("TeacherName") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                           <ItemStyle Width="150px" />
                                    </asp:TemplateField>


                                    <asp:BoundField DataField="DateOfHire" HeaderText="Date of Hire">
                                        <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="Ranking" HeaderText="Ranking">
                                        <ItemStyle Width="80px" />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="Lots" HeaderText="Lots">
                                        <ItemStyle Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UploadDate" HeaderText="Upload Date">
                                        <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Qualification" HeaderText="Qualification">
                                        <ItemStyle Width="40%" />
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div>
                TCDSB Staff List
           
            </div>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <div style="overflow: hidden;" id="DivHeaderRow3">
                        <table id="GridView4" style="border: 1px ridge gray; width: 100%; height: 100%; background-color: white;">
                        </table>
                    </div>
                    <div style="overflow: scroll; height: 250px; width: 100%" onscroll="OnScrollDiv(this)" id="DivMainContent3">
                        <asp:GridView ID="GridView3" runat="server" Height="100%" Width="98%"
                            GridLines="Both" AutoGenerateColumns="False" BackColor="White" ShowHeader="true" ShowHeaderWhenEmpty="true"
                            EmptyDataText="The search person is not in LTO/Roster list" EmptyDataRowStyle-CssClass="emptyData"
                            BorderColor="gray" BorderStyle="Ridge">
                            <Columns>
                                <asp:BoundField DataField="myKey" ReadOnly="True" Visible="False" />
                                <asp:BoundField DataField="RowNo" HeaderText="No." ItemStyle-CssClass="ApplyAction">
                                    <ItemStyle Width="50px" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Apply">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="Link1" runat="server" Text='<%# Bind("LTOAction") %>'>  </asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" Wrap="False" />
                                </asp:TemplateField>


                                <asp:BoundField DataField="UserID" HeaderText="UserID">
                                    <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CPNum" HeaderText="CPNum">
                                    <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OTType" HeaderText="Type">
                                    <ItemStyle Width="100px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="TeacherName" HeaderText="Name">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DateOfHire" HeaderText="Date of Hire">
                                    <ItemStyle Width="100px" />
                                </asp:BoundField>
                                   <asp:BoundField DataField="Ranking" HeaderText="Ranking">
                                        <ItemStyle Width="80px" />
                                    </asp:BoundField>
                                  <asp:BoundField DataField="Lots" HeaderText="Lots">
                                        <ItemStyle Width="50px" />
                                    </asp:BoundField>
                                <asp:BoundField DataField="UploadDate" HeaderText="Upload Date">
                                    <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Qualification" HeaderText="Qualification">
                                    <ItemStyle Width="40%" />
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div id="PopUpDIV" class="bubble hide"></div>
        <div id="DetailDIV" class="bubble hide" style="width: 99%;">
            <div style="height: 22px; margin-top: -2px;">
                <table style="vertical-align: top;">
                    <tr style="background-color: deepskyblue;">

                        <td style="width: 95%; text-align: center">
                            <div id="popPagetitle" runat="server" style="font-size: medium">Detail Edit Page  </div>
                        </td>
                        <td>
                            <asp:HiddenField ID="hdChildFormAction" runat="server" Value="NoAction" />
                            <asp:HiddenField ID="hfInvokePageFrom" runat="server" Value="" />
                            <asp:HiddenField ID="hfUserRole" runat="server" Value="" />
                            <asp:HiddenField ID="hfSchoolYear" runat="server" Value="" />
                        </td>
                        <td style="width: 50px; text-align: right">
                            <a id="CloseMeLink" runat="server" href="#" class="CloseMe">
                                <img style="height: 20px; width: 20px;" src="images/Close1.bmp" alt="" title="Close Me" />
                            </a>
                        </td>
                    </tr>
                </table>

            </div>

            <iframe id="DetailiFrame22" runat="server" name="DetailiFrame22" scrolling="auto" seamless="seamless" height="100%" width="100%"
                src="#"></iframe>

            <div id="BottomClose" style="height: 22px; background-color: deepskyblue; text-align: right">
                <a id="CloseMeLink2" runat="server" href="#" class="CloseMe">
                    <img style="height: 20px; width: 20px;" src="images/Close1.bmp" alt="" title="Close Me" />
                </a>
            </div>
        </div>

        <div id="CommentsDIV" class="commentsHR hide boardPending" style="width: 100%;">
            <iframe id="CommentsiFrame" runat="server" name="CommentsiFrame" scrolling="no" seamless="seamless" style="height: 100%; width: 100%; border: 0px blue solid"
                src="#"></iframe>

        </div>

    </form>
</body>
</html>


<script src="Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>



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

      //  parent.document.Script.DeCueerntMenu();

        $(".CloseMe").click(function () {
            $("#PopUpDIV").fadeToggle("fast");
            $("#DetailDIV").fadeToggle("fast");
        });

    });


</script>


<script type="text/javascript" id="igClientScript1">


    function openPositionList(Schoolyear, CPNum) {
        var goPage = "Loading2.aspx?pID=LTOTeachers/ApplyPositionList.aspx&SchoolYear=" + Schoolyear + "&ApplyUserID=" + CPNum;
        openDetailPage(10, 600, 1200, goPage, "Apply Open Position", "LTOTeachers/ApplyPositionList.aspx");
    }

    function openCheckLTOAction(schoolYear, schoolCode, source, CPNum, LTOStatus) {
        var goPage = "Loading2.aspx?pID=LTOTeachers/NewUserProfile.aspx&SchoolYear=" + schoolYear + "&SchoolCode=" + schoolCode + "&ApplyUserID=" + CPNum + "&Source=" + source + "&LTOStatus=" + LTOStatus;
        openDetailPage(100, 450, 710, goPage, "LTO Teacher Profile ", "LTOTeachers/LTOProfile.aspx");

    }
    function openDetailPage(vLeft, vHeight, vWidth, goPage, pTitle, invokeP) {
        $(document).ready(function () {
            try {
                var divP = "";
                // var vLeft = 10 ;
                if (vHeight > 550) { divP = '95%'; }
                else { divP = '92%'; }
                //  $("#iFrameDIV").css({ height: divP })
                var vTop = 10; // (screen.height / 2) - (vHeight / 2) - 100;
                $("#DetailiFrame22").attr('src', goPage);
                $("#popPagetitle").text(pTitle);
                //  $("#hfInvokePageFrom").val(invokeP);
                $("#DetailDIV").css({
                    top: vTop,
                    left: vLeft,
                    height: vHeight,
                    width: vWidth
                })
                //   PopUpDIV2();
                $("#PopUpDIV").fadeToggle("fast");
                $("#DetailDIV").fadeToggle("fast");


            }

            catch (e) { }

        });

    }

    function closeHRComments(commentsCount) {
        if (commentsCount < 1000) {
          $("#CommentsDIV").fadeToggle("fast");
        }
    }
    function openHRPeningList() {
        var sYear = $("#hfSchoolYear").val();
        var pPage = "PDFLoading/PDFDocument_Loading.aspx?rID=HRPendingComments&yID=" + sYear ;
        window.open(pPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes");	      
    }
    function openHRComments(schoolyear, cpnum, pending) {
        var goPage = "LTOHRStaffs/HRPendingComments.aspx?SchoolYear=" + schoolyear + "&CPNum=" + cpnum;
        
        var xTop = mousey + 20;
        xTop = 70; 
        var xLeft = mousex + 20;

        if (pending === "Pending")
            $("#CommentsDIV").removeClass("boardColor").addClass("boardPending");
        else
            $("#CommentsDIV").removeClass("boardPending").addClass("boardColor");

        $("#CommentsiFrame").attr('src', goPage);
        $("#CommentsDIV").css({
            top: xTop,
            left: xLeft,
            height: 300,
            width: 500
        });
        $("#CommentsDIV").fadeToggle("fast");
    }

</script> 
