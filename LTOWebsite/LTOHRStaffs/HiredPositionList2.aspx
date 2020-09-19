<%@ Page Language="VB" AutoEventWireup="false" CodeFile="HiredPositionList2.aspx.vb" Inherits="HiredPositionList2"
    EnableTheming="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hiring Position TeacherList</title>
    <link href="../Styles/ListPage.css" rel="stylesheet" type="text/css" />
    <link href="../JQuery-UI/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="../JQuery-UI/Themes/jquery-ui.css" rel="stylesheet" type="text/css" />


    <style type="text/css">
        body {
            height:100%;
            width: 100%;
            margin:1px;
        }

        .auto-style1 {
            height: 350px;
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
            table-layout: auto;
            display: block;
            height: 99%;
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

        .FixedHeader {
            position: absolute;
            font-weight: bold;
            width: 100%;
            display: block;
        }
  
        .ListHeader {
            height: 20px;
        }
    </style>



</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
        </asp:ScriptManager>
        <div>
            <table id="Table3" border="0" class="TableFont1" style="text-align: left;">
                <tr id="SuperAreaRow" runat="server">
                    <td style="width: 80%">

                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td >
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
                                                <asp:ListItem Selected="True">All</asp:ListItem>
                                                <asp:ListItem>Area</asp:ListItem>
                                                <asp:ListItem>School</asp:ListItem>
                                                <asp:ListItem>Title</asp:ListItem>
                                                <asp:ListItem>Level</asp:ListItem>
                                                <asp:ListItem>LastName</asp:ListItem>
                                                <asp:ListItem>PublishDate</asp:ListItem>
                                                <asp:ListItem>DeadlineDate</asp:ListItem>
                                                <asp:ListItem>PositionStartDate</asp:ListItem>
                                                <asp:ListItem>PositionEndDate</asp:ListItem>
                                                <asp:ListItem>PostingCycle</asp:ListItem>
                                                <asp:ListItem Value="PostingNum">Posting Number</asp:ListItem>
                                             


                                            </asp:DropDownList>

                                            <asp:DropDownList ID="ddlSearchbyValue" runat="server" Width="200px" SkinID="ddlSmall" Visible="true" AutoPostBack="True">
                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtSearchBox" runat="server" Width="200px" Visible="false"></asp:TextBox>

                                            <input runat="server" visible="false" type="text" id="datepicker" size="10" />
                                            <asp:Label ID="DateTo" runat="server" Text="To"></asp:Label>
                                            <input runat="server" visible="false" type="text" id="datepicker2" size="10" />

                                            <div id="PanelDIV" runat="server" style="display: inline;">
                                                IN 
                                     <asp:DropDownList ID="ddlPanel" runat="server" Width="100px" SkinID="ddlSmall" AutoPostBack="True">
                                         <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
                                         <asp:ListItem Value="02">Elementary</asp:ListItem>
                                         <asp:ListItem Value="05">Secondary</asp:ListItem>
                                     </asp:DropDownList>
                                            </div>
                                            <asp:Button ID="btnSearch" runat="server" Text="Go" />
                                            <asp:CheckBox ID="cb4Th" runat="server" Text="4th Round" />
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

                                    </tr>
                                </table>



                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="font-size: x-small; width: 150px;">
                        <a id="openAnswerA" runat="server" href="javascript:openPrintPage(90,180)" visible="false">
                            <img src="../images/print.bmp" alt="" title="Print SLIP One Page Summary" style="border-width: 1px; border-color: Purple;" />

                        </a>
                        <img src="../images/excel.bmp" />
                        <asp:LinkButton ID="btnExcel" runat="server">Export  to EXCEL </asp:LinkButton>

                    </td>
                    <td style="font-size: x-small; width: 150px;">
                        <a id="emailNotice" runat="server" href="javascript:openEmailOfficer()">
                            <img src="../images/emailTo.png" alt="" title="Email Hired Position List to Officer" style="border-width: 1px; border-color: Purple;" />
                            Notice Officer
                        </a>

                    </td>
                    <td style="font-size: x-small">

                        <asp:HiddenField ID="HiddenFieldUserRole" runat="server" />
                    </td>
                </tr>
                  <tr><td colspan="4">
                         <asp:Label runat="server" ID="Label1" Font-Size="X-Small" ForeColor="red" Text="* Click on the Hired button to open position details"> </asp:Label>

                        </td></tr>
            </table>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="DivRoot" >
                    <div style="overflow: hidden;" id="DivHeaderRow">
                        <table id="GridView2" style=" border: 1px ridge gray; width: 100%; height: 100%; background-color: white;" rules="all" cellspacing="1" cellpadding="1">
                        </table>
                    </div>

                    
                    <div style="overflow: scroll; width: 100%; height: 100%" onscroll="OnScrollDiv(this)" id="DivMainContent">
                        <asp:GridView ID="GridView1" runat="server" CellPadding="1" Height="100%" Width="100%"
                            GridLines="Both" AutoGenerateColumns="False" BackColor="White" ShowHeader="true" ShowHeaderWhenEmpty="true"
                            EmptyDataText="No hired position to show" EmptyDataRowStyle-CssClass="emptyData"
                            BorderColor="gray" BorderStyle="Ridge" BorderWidth="1px" CellSpacing="1">
                            <Columns>

                                <asp:BoundField DataField="SchoolYear" ReadOnly="True" Visible="False" />
                                <asp:BoundField DataField="SchoolCode" ReadOnly="True" Visible="False" />
                                <asp:BoundField DataField="PositionID" ReadOnly="True" Visible="False" />
                                <asp:BoundField DataField="RowNo" HeaderText="No.">
                                    <ItemStyle Width="2%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PostingNumber" HeaderText="Posting Number">
                                    <ItemStyle Width="4%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Hired">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="Link2" runat="server" Text='<%# Bind("ViewDetail") %>'>  </asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Width="2%" Wrap="False" />
                                </asp:TemplateField>

                                <asp:BoundField DataField="DateApplied" HeaderText="Applied Date">
                                    <ItemStyle Width="4%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DateInterview" HeaderText="Interview Date">
                                    <ItemStyle Width="4%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DateHired" HeaderText="Hired Date">
                                    <ItemStyle Width="4%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TeacherName" HeaderText="Teacher Name">
                                    <ItemStyle Width="6%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SchoolName" HeaderText="School">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="SchoolArea" HeaderText="School Area">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PositionTitle" HeaderText="Position Title">
                                    <ItemStyle Width="7%" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="FTE" HeaderText="FTE">
                                    <ItemStyle Width="2%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FTEPanel" HeaderText="AM/PM">
                                    <ItemStyle Width="2%" />
                                </asp:BoundField>
                                   <asp:BoundField DataField="ReplaceTeacher" HeaderText="Teacher being Replaced">
                                    <ItemStyle Width="6%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PositionLevel" HeaderText="Mandatory Qualification">
                                    <ItemStyle Width="7%" />
                                </asp:BoundField>
                              
                                <asp:BoundField DataField="Qualification" HeaderText="Minimum Qualification ">
                                    <ItemStyle Width="7%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Description" HeaderText="Position Description">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="ApplicantQualification" HeaderText="Qualification">
                                    <ItemStyle Width="20%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="PostingCycle" HeaderText="Round">
                                    <ItemStyle Width="2%" HorizontalAlign="center" />
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

                    <%--  <div id="DivFooterRow" style="overflow: hidden">
            </div>--%>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <%--   <ig:WebExcelExporter ID="WebExcelExporter1" runat="server">
        </ig:WebExcelExporter>--%>
    </form>
</body>
</html>


<script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
<script src="../JQuery-UI/jquery-ui-1.11.4.min.js" type="text/javascript"></script>
<script src="../Scripts/PopUpDIVLeft.js" type="text/javascript"></script>
<script src="../Scripts/GridViewLayout.js" type="text/javascript"></script>


<script type="text/javascript" id="igClientScript1">

    function openPositionDetail(schoolyear, schoolcode, postedCycle, positionType, positionID, CPNum, tName) {
        var Parameter = "&SchoolYear=" + schoolyear + "&ApplyUserID=" + CPNum + "&PositionID=" + positionID + "&TeacherName=" + tName;
        var goPage = "Loading2.aspx?pID=LTOHRStaffs/HiredDetails2.aspx" + Parameter
        var xHeight = "500";
        var xWidth = "750";
        var pTitle = " Hired Position Detail Page";
        //if (postedCycle == "4") {
        //    pTitle = "Hired Position Detail Page ( 4th round )";
        //    xHeight = "500";
        //    xWidth = "600";
        //    goPage = "Loading2.aspx?pID=LTOHRStaffs/HiredDetails4th.aspx" + Parameter;
        //}


        if ($("#HiddenFieldUserRole").val() != "Superintendent") {
            openDetailPage(xHeight, xWidth, goPage, pTitle);
        }


    }
    function openEmailOfficer() {
        var goPage = "LTOHRStaffs/NoticeToOfficerForHired.aspx";
        openDetailPage(500, 800, goPage, "Send Hired Position List Notification To Officer")
    }


    function openLTOAppraisal(schoolyear, schoolcode, SessionID, TeacherID) {
        var printPage = "../PDFLoading/PDFDocument_Loading.aspx?rID=InterviewPackage" + "&yID=" + schoolyear + "&CPNum=" + TeacherID + "&pID=" + SessionID;
        var popup1 = window.open(printPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=800,height=600,top=0,left=0");
    }


    $(document).ready(function () {
        try {
            LoadDatePicker();
            $("#CloseMe").click(function (e) {
                openDetailPage(1, 1, "", "");
            });


            $("#btnExcel").click(function (e) {
                var schoolyear = $("#ddlSchoolYear").val();
                var appType = $("#ddlappType").val();
                var panel = "00";
                var openClose = "All";
                var searchby = $("#ddlSearchby").val();
                var searchValue1 = $("#ddlSearchbyValue").val();
                var searchValue2 = $("#txtSearchBox").val();

                var includeAll = "0";  // 4th round
                if ($("#cb4Th").attr('checked'))
                { includeAll = "1"; }


                if (searchby == "Title") {
                    searchValue1 = $("#txtSearchBox").val();
                    searchValue2 = "";
                }
                if (searchby == "PublishDate" || searchby == "DeadlineDate" || searchby == "PositionStartDate" || searchby == "PositionEndDate") {
                    searchValue1 = $("#datepicker").val();
                    searchValue2 = $("#datepicker2").val();
                }
                var goPage = "../PDFLoading/EXCELDocument_Loading.aspx?rID=PositionList_Hired&yID=" + schoolyear + "&AppType=" + appType + "&Panel=" + panel + "&OpenClose=" + openClose + "&SearchBy=" + searchby + "&SearchValue1=" + searchValue1 + "&SearchValue2=" + searchValue2 + "&includeAll=" + includeAll;

                window.open(goPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,width=450 height=300, top=10, left=10");
                return false;
            });

        }
        catch (e) { }



    });
    function openDetailPage(vHeight, vWidth, goPage, pTitle) {
        $(document).ready(function () {
            try {
                var vLeft = (screen.width / 2) - (vWidth / 2) - 30;
                var vTop = (screen.height / 2) - (vHeight / 2) - 50;
                $("#PositionDetailFrame", parent.document).attr('src', goPage);
                $("#popPagetitle", parent.document).text(pTitle);
                $("#hfInvokePageFrom", parent.document).val("LTOHRStaffs/HiredPositionList2.aspx");
                $("#PositionDetailDIV", parent.document).css({
                    top: vTop,
                    left: vLeft,
                    height: vHeight,
                    width: vWidth
                })
                //   PopUpDIV2();        PopUpDIV1();
                $("#PopUpDIV", parent.document).fadeToggle("fast");
                $("#PositionDetailDIV", parent.document).fadeToggle("fast");
            }

            catch (e) { }

        });

    }
</script>
<script type="text/javascript">
    function pageLoad(sender, args) {

        $(document).ready(function () {

            LoadDatePicker();
          //  MakeStaticHeader("GridView1", 600, 1500, 30, false);
            var vHeight = window.innerHeight - 100;
            MakeStaticHeader("GridView1", vHeight, 1500, 25, false, "DivHeaderRow", "GridView2", "DivMainContent");
        });

    }

    function LoadDatePicker() {
        $("#datepicker").datepicker(
         {
             dateFormat: 'yy-mm-dd',
             showOn: "button",
             buttonImage: "../images/calendar.gif",
             buttonImageOnly: true,
             changeMonth: true,
             changeYear: true,
             beforeShow: function () {
                 setTimeout(function () {
                     $('#ui-datepicker-div').css('z-index', 998);
                 }, 0);
             }
         });


        $("#datepicker2").datepicker(
          {
              dateFormat: 'yy-mm-dd',
              showOn: "button",
              buttonImage: "../images/calendar.gif",
              buttonImageOnly: true,
              changeMonth: true,
              changeYear: true,
              beforeShow: function () {
                  setTimeout(function () {
                      $('#ui-datepicker-div').css('z-index', 998);
                  }, 0);
              }
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
            DivMC.style.width = '100%';// width + 'px';
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

            if (isFooter) {
                var tblfr = tbl.cloneNode(true);
                tblfr.removeChild(tblfr.getElementsByTagName('tbody')[0]);
                var tblBody = document.createElement('tbody');
                tblfr.style.width = '100%';
                tblfr.cellSpacing = "0";
                tblfr.border = "0px";
                tblfr.rules = "none";
                //*****In the case of Footer Row *******
                tblBody.appendChild(tbl.rows[tbl.rows.length - 1]);
                tblfr.appendChild(tblBody);
                DivFR.appendChild(tblfr);
            }
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
                window.alert(myHeaderStyle);
            });
            return false;
        })




    }

    function OnScrollDiv(Scrollablediv) {
        document.getElementById('DivHeaderRow').scrollLeft = Scrollablediv.scrollLeft;
        //   document.getElementById('DivFooterRow').scrollLeft = Scrollablediv.scrollLeft;
    }


</script>--%>


