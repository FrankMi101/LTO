<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PublishedList2.aspx.vb" Inherits="PublishedList2"
    EnableTheming="true" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Position Publsh List</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <link href="../Styles/ListPage.css" rel="stylesheet" type="text/css" />

    <link href="../JQuery-UI/Themes/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../JQuery-UI/jquery-ui.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        body {
            height: 100%;
            width: 100%;
            margin: auto;
        }

        div {
            font-family: Arial;
            font-size: small;
        }


        .WDG {
            height: 100%;
            width: 99.9%;
        }



        .iFrameContent {
            position: absolute;
            width: 100%;
            height: 300px;
            border: 0px dotted;
            border-color: blue;
            table-layout: auto;
            display: block;
            margin: 0px;
            padding: 0px;
        }

        .DataContentTile {
            font-family: Arial;
            font-size: small;
            font-weight: 300;
            color: blue;
            table-layout: auto;
            display: block;
            height: 99.9%;
        }



        .SubstituedCell {
            color: red;
            text-decoration: underline;
        }

        .emptyData {
            font-size: xx-large;
            text-align: center;
            color: blue;
        }


        .EditCPNum, .myDateS, .myDateE {
            display: none;
        }

        .FixedHeader {
            position: absolute;
            font-weight: bold;
            width: 100%;
            display: block;
        }

        .highlightBoard {
            border: 2px #ff6a00 solid;
            /*background-color:dodgerblue;*/
        }

        .defaultBoard {
            border: 0px #ff6a00 solid;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager runat="server">
        </asp:ScriptManager>
        <div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Label ID="Label3" runat="server" Text="School Year: " Visible="false"></asp:Label>
                    <asp:DropDownList ID="ddlSchoolYear" runat="server" Width="100px" SkinID="ddlSmall" AutoPostBack="True"
                        Enabled="true">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlappType" runat="server" Width="55px" Visible="true" SkinID="ddlSmall" AutoPostBack="True">
                        <asp:ListItem>POP</asp:ListItem>
                        <asp:ListItem>LTO</asp:ListItem>
                        <asp:ListItem>COP</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lblSuperArea" runat="server" Text="Search by"></asp:Label>
                    <asp:DropDownList ID="ddlSearchby" runat="server" Width="130px" SkinID="ddlSmall" Visible="true" AutoPostBack="True">
                    </asp:DropDownList>

                    <asp:DropDownList ID="ddlSearchbyValue" runat="server" Width="200px" SkinID="ddlSmall" Visible="true" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtSearchBox" runat="server" Width="200px" Visible="false"></asp:TextBox>

                    <input runat="server" visible="false" type="text" id="datepicker" size="10" />
                    <asp:Label ID="DateTo" runat="server" Text="To"></asp:Label>
                    <input runat="server" visible="false" type="text" id="datepicker2" size="10" />


                    <%-- <div id="PanelDIV" runat="server" style="display: inline;">
                        IN
                        <asp:DropDownList ID="ddlPanel" runat="server" Width="100px" SkinID="ddlSmall" AutoPostBack="True">
                            <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
                            <asp:ListItem Value="02">Elementary</asp:ListItem>
                            <asp:ListItem Value="05">Secondary</asp:ListItem>
                        </asp:DropDownList>
                    </div>--%>
                    <asp:DropDownList ID="ddlOpenClose" runat="server" Width="60px" SkinID="ddlSmall" AutoPostBack="True">
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem Selected="True">Open</asp:ListItem>
                        <asp:ListItem>Close</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnSearch" runat="server" Text="Go" />
                    <asp:CheckBox ID="cb4Th" runat="server" Text="4th Round" />
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Not sent Email Position" />
                    <img src="../images/excel.bmp" />
                    <asp:LinkButton ID="btnExcel" runat="server" Width="170px">Export the List to EXCEL </asp:LinkButton>

                    <a id="A2" runat="server" href='https://webapp.tcdsb.org/WebDocuments/Documents/LTO/Long Term Occasional Teachers List.pdf' target="_blank">LTO Teacher List</a>
                    <asp:HiddenField ID="HiddenFieldUserRole" runat="server" />
                    <asp:HiddenField ID="HiddenFieldPageSource" runat="server" />

                    <div id="Div1" runat="server" style="display: inline;">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <img src="../images/indicator.gif" alt="" />
                                <b>Searching.....</b>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                    <div style="color: Red; font-size: x-small">
                        <asp:Label runat="server" ID="remaind22" Text="* Click on the Select button to see interview candidate list "> </asp:Label>
                        <asp:Label runat="server" ID="Label1" Text="" Visible="false"> </asp:Label>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div id="DivRoot" style="width: 100%; height: 230px;">
                        <div style="overflow: hidden;" id="DivHeaderRow">
                            <table id="GridView2" style="border: 1px ridge gray; width: 100%; height: 100%; background-color: white;" rules="all" cellspacing="1" cellpadding="1" borderwidth="1px">
                            </table>
                        </div>

                        <div style="overflow: scroll; width: 100%; height: 100%" onscroll="OnScrollDiv(this)" id="DivMainContent">
                            <asp:GridView ID="GridView1" runat="server" CellPadding="1" Height="100%" Width="100%" GridLines="Both" AutoGenerateColumns="False" BackColor="White" BorderColor="gray" BorderStyle="Ridge" BorderWidth="1px" CellSpacing="1" EmptyDataText="No Applicants in selected position" EmptyDataRowStyle-CssClass="emptyData" ShowHeaderWhenEmpty="true">
                                <Columns>

                                    <asp:BoundField DataField="myKey" ReadOnly="True" Visible="False" />
                                    <asp:BoundField DataField="SchoolYear" ReadOnly="True" Visible="False" />
                                    <asp:BoundField DataField="SchoolCode" ReadOnly="True" Visible="False" />
                                    <asp:BoundField DataField="PositionID" ReadOnly="True" Visible="False" />


                                    <asp:BoundField DataField="RowNo" HeaderText="No." ItemStyle-CssClass="myRowNo">
                                        <ItemStyle Width="2%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PostingNumber" HeaderText="Posting Number">
                                        <ItemStyle Width="3%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Step">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link1" runat="server" Text='<%# Bind("CurrentStep") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="2%" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Selecte" ItemStyle-CssClass="mySelect">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link1" runat="server" Text='<%# Bind("ActionSign") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="2%" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email Notice" ItemStyle-CssClass="myEmail">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link2" runat="server" Text='<%# Bind("EmailSign") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="2%" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ApplicantCount" HeaderText="Applicant Count">
                                        <ItemStyle Width="3%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DateApplyClose" HeaderText="Posting Close">
                                        <ItemStyle Width="4%" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Days to Close">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link3" runat="server" Text='<%# Bind("DaystoEndImg") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="4%" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="DatePublish" HeaderText="Published Date">
                                        <ItemStyle Width="4%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PositionState" HeaderText="Open Status">
                                        <ItemStyle Width="3%" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="SchoolArea" HeaderText="Area">
                                        <ItemStyle Width="4%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SchoolName" HeaderText="School" ItemStyle-CssClass="mySchool">
                                        <ItemStyle Width="8%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PositionTitle" HeaderText="Position Title" ItemStyle-CssClass="myTitle">
                                        <ItemStyle Width="8%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PositionLevel" HeaderText="Division Required">
                                        <ItemStyle Width="8%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Qualification" HeaderText="Minimum Qualification ">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Description" HeaderText="Position Description" ItemStyle-CssClass="myDescription">
                                        <ItemStyle Width="12%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Comments" HeaderText="HR Notes">
                                        <ItemStyle Width="13%" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="FTE" HeaderText="FTE">
                                        <ItemStyle Width="2%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FTEPanel" HeaderText="AM/PM">
                                        <ItemStyle Width="2%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PostingCycle" HeaderText="Cycle">
                                        <ItemStyle Width="2%" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link4" runat="server" Text='<%# Bind("EditPosition") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="2%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="StartDate" ReadOnly="True" ItemStyle-CssClass="myDateS" />
                                    <asp:BoundField DataField="EndDate" ReadOnly="True" ItemStyle-CssClass="myDateE" />
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

        </div>

        <div style="height: 100%;">
            <asp:Label runat="server" class="DataContentTile" ID="SelectedPosition" Text="All Applicant List Applied the Position "> </asp:Label>
        </div>
        <div>
            <iframe id="ApplicantList" runat="server" name="ApplicantList" class="iFrameContent" scrolling="no" seamless="seamless"></iframe>
        </div>


    </form>
</body>
</html>


<script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
<script src="../JQuery-UI/jquery-ui-1.11.4.min.js" type="text/javascript"></script>
<script src="../Scripts/CommonDOM.js" type="text/javascript"></script>

<script src="../Scripts/GridViewLayout.js" type="text/javascript"></script>



<script type="text/javascript" id="igClientScript1">
    var RowChange = "Allow";
    var schoolname;
    var PositionTitle;
    var StartDate;
    var EndDate;
    var emailCell;
    var currentTR;
    var rowNo = 0;
    var newRowNo = 0;
    var qualification;
    function pageLoad(sender, args) {

        $(document).ready(function () {
            MakeStaticHeader("GridView1", 200, 1500, 25, false, "DivHeaderRow", "GridView2", "DivMainContent");
            LoadDatePicker();

            $('td.mySelect').click(function (event) {

                schoolname = $(this).closest('tr').find('td.mySchool').text();
                PositionTitle = $(this).closest('tr').find('td.myTitle').text();
                StartDate = $(this).closest('tr').find('td.myDateS').text();
                EndDate = $(this).closest('tr').find('td.myDateE').text();
                emailCell = $(this).closest('tr').find('td.myEmail');
                Description = $(this).closest('tr').find('td.myDescription').text();
                //  myImg = $(this).closest('tr').find('a.myEmail');
                rowNo = $(this).closest('tr').find('td.myRowNo').text();

                //  $("#Label1").text("rowNo.=" + rowNo + " new Row No.=" + newRowNo);
                RowChange = "NotAllow";
            });
            $("#btnExcel").click(function (e) {
                var schoolyear = $("#ddlSchoolYear").val();
                var appType = $("#ddlappType").val();
                var panel = $("#ddlPanel").val();
                var openClose = "All";
                var searchby = $("#ddlSearchby").val();
                var searchValue1 = $("#ddlSearchbyValue").val();
                var searchValue2 = $("#txtSearchBox").val();

                if (searchby == "Title") {
                    searchValue1 = $("#txtSearchBox").val();
                    searchValue2 = "";
                }
                if (searchby == "PublishDate" || searchby == "DeadlineDate" || searchby == "PositionStartDate" || searchby == "PositionEndDate") {
                    searchValue1 = $("#datepicker").val();
                    searchValue2 = $("#datepicker2").val();
                }
                var goPage = "../PDFLoading/EXCELDocument_Loading.aspx?rID=PositionList_Interview&yID=" + schoolyear + "&AppType=" + appType + "&Panel=" + panel + "&OpenClose=" + openClose + "&SearchBy=" + searchby + "&SearchValue1=" + searchValue1 + "&SearchValue2=" + searchValue2;

                window.open(goPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,width=450 height=300, top=10, left=10");
                return false;
            });
            $('#GridView1 tr').mouseenter(function (event) {
                newRowNo = $(this).closest('tr').find('td.myRowNo').text();
                //  $("#Label1").text("rowNo.=" + rowNo + " new Row No.=" + newRowNo);
                if (rowNo == 0) {
                    if (currentTR != undefined) { currentTR.removeClass("highlightBoard"); }
                    currentTR = $(this);

                    currentTR.addClass("highlightBoard");
                }
                else {
                    if (newRowNo < rowNo) // (RowChange == "Allow")
                    {
                        if (currentTR != undefined) { currentTR.removeClass("highlightBoard"); }
                        currentTR = $(this);

                        currentTR.addClass("highlightBoard");
                        rowNo = 0;
                    }
                    //      RowNo = newRowNo;
                }

            });
            $('#ApplicantList').mouseenter(function (event) {
                RowChange = "Allow"
                rowNo = 0;
            });
        });

    }

    function LoadDatePicker() {
        JDatePicker.InitialL($("#datepicker"));
        JDatePicker.InitialL($("#datepicker2"));
    }

    function IECompatibility() {
        var agentStr = navigator.userAgent;
        this.IsIE = false;
        this.IsOn = undefined;  //defined only if IE
        this.Version = undefined;
        this.Compatible = undefined;

        if (agentStr.indexOf("compatible") > -1) {
            this.IsIE = true;
            this.IsOn = true;
            this.Compatible = true;
        }
        else {
            this.Compatible = false;
        }

    }
    function changeEmailCellSign() {

        var signCellHTML = emailCell.html(); // ._element.innerHTML;


        var signCellNew = "";
        var iec = new IECompatibility();
        if (iec.Compatible) {
            if (signCellHTML.indexOf("width=0 height=0") == -1) {
            }
            else {
                signCellNew = signCellHTML.replace("width=0 height=0", "width=24 height=20");
                emailCell.html(signCellNew);
            }
        }
        else {
            if (signCellHTML.indexOf("width=\"0\" height=\"0\"") == -1) {
            }
            else {
                signCellNew = signCellHTML.replace("width=\"0\" height=\"0\"", "width=\"24\" height=\"20\"");
                emailCell.html(signCellNew);
            }
        }

    }


    function openApplicantList(schoolyear, schoolcode, positionID, postedState) {


        var goPage = "LoadingHR.aspx?pID=2&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID + "&PostedState=" + postedState + "&SchoolName=" + schoolname;
        if (schoolcode.substr(0, 2) != "05") {
            PositionTitle = PositionTitle + " (" + Description.substr(0, 30) + ")";
        }
        $("#SelectedPosition").text("All Applicant List Applied the " + PositionTitle + " (From " + StartDate + " to " + EndDate + ")" + " of " + schoolname);
        window.frames.ApplicantList.location.href = goPage;
    }
    function openEmailNotice(schoolyear, schoolcode, positionID) {

        //   var goPage = "Loading2.aspx?pID=LTOHRStaffs/NoticeToPrincipal.aspx&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID + "&SchoolName=" + schoolname;
        var goPage = "Loading2.aspx?pID=LTOHRStaffs/NoticeToPrincipal2.aspx&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID + "&SchoolName=" + schoolname;

        if ($("#HiddenFieldUserRole").val() != "Superintendent") {
            openDetailPage(520, 750, goPage, "Notice Principal Top 5 Interview selected");
        }
    }
    function openEditPosition(schoolyear, schoolcode, positionID) {
        //  var goPage = "Loading2.aspx?pID=LTOHRStaffs/RequestPositionDetails.aspx&SchoolYear=" + schoolyear + "&PositionID=" + positionID;
        var goPage = "Loading2.aspx?pID=LTOHRStaffs/RequestPositionDetails2.aspx&SchoolYear=" + schoolyear + "&PositionID=" + positionID;

        if ($("#HiddenFieldUserRole").val() != "Superintendent") {
            openDetailPage(500, 800, goPage, "Position Detail Edit Page");
        }
    }

    function openDetailPage(vHeight, vWidth, goPage, pTitle) {
        var vLeft = (screen.width / 2) - (vWidth / 2) - 100;
        var vTop = (screen.height / 2) - (vHeight / 2) - 50;
        $(document).ready(function () {
            try {
                $("#PositionDetailFrame", parent.document).attr('src', goPage);
                $("#popPagetitle", parent.document).text(pTitle);
                $("#hfInvokePageFrom", parent.document).val("LTOHRStaffs/PublishedList2.aspx");
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
            DivHR.style.width = '99%'; // (parseInt(width) - 16) + 'px';
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

            //  DivHR.appendChild(tableH );
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

    function oldDateInitial() {
        //$("#datepicker").datepicker(
        //      {
        //          dateFormat: 'yy-mm-dd',
        //          showOn: "button",
        //          buttonImage: "../images/calendar.gif",
        //          buttonImageOnly: true,
        //          changeMonth: true,
        //          changeYear: true,
        //          beforeShow: function () {
        //              setTimeout(function () {
        //                  $('#ui-datepicker-div').css('z-index', 998);
        //              }, 0);
        //          }
        //      });
        //$("#datepicker2").datepicker(
        //  {
        //      dateFormat: 'yy-mm-dd',
        //      showOn: "button",
        //      buttonImage: "../images/calendar.gif",
        //      buttonImageOnly: true,
        //      changeMonth: true,
        //      changeYear: true,
        //      beforeShow: function () {
        //          setTimeout(function () {
        //              $('#ui-datepicker-div').css('z-index', 998);
        //          }, 0);
        //      }
        //  });
    }

</script>--%>
