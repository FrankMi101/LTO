<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PostingSummary.aspx.vb" Inherits="PostingSummary"
    EnableTheming="true" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Request open Position List</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-Store,no-Cache" />
    <link href="../Styles/ListPage.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        body {
            height: 100%;
            width: 99.8%;
        }

        div {
            font-family: Arial;
            font-size: small;
        }

        .auto-style1 {
            height: 350px;
        }

     

        .WDG {
            height: 100%;
            width: 99%;
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

       

        .emptyData {
            font-size: xx-large;
            text-align: center;
            color: blue;
        }

        .FixedHeader {
            position: absolute;
            width: 100%;
        }
              .highlightBoard {
            border: 2px blue solid;
        }

        .defaultBoard {
            border: 0px blue solid;
        }
    
        /*div #AdjResultsDiv {
            width: 1080px;
            height: 500px;
            overflow: scroll;
            position: relative;
        }

       div #AdjResultsDiv th {
                top: expression(document.getElementById("AdjResultsDiv").scrollTop-2);
                left: expression(parentNode.parentNode.parentNode.parentNode.scrollLeft);
                position: relative;
                z-index: 20;
            }*/

        /*div #GridView1 {
            width: 1080px;
            height: 500px;
            overflow: scroll;
            position: relative;
        }

        div#GridView1 th {
            top: expression(document.getElementById("AdjResultsDiv").scrollTop-2);
            left: expression(parentNode.parentNode.parentNode.parentNode.scrollLeft);
            position: relative;
            z-index: 20;
        }*/
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td style="width:60%">
                            <div style="display: inline;">

                                <asp:Label ID="Label3" runat="server" Text="School Year: " Visible="false"></asp:Label>
                                <asp:DropDownList ID="ddlSchoolYear" runat="server" Width="85px" SkinID="ddlSmall" AutoPostBack="True"
                                    Enabled="true">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlappType" runat="server" Width="55px" Visible="true" SkinID="ddlSmall" AutoPostBack="True">
                                    <asp:ListItem>POP</asp:ListItem>
                                    <asp:ListItem>LTO</asp:ListItem>
                                    <asp:ListItem>COP</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="lblSuperArea" runat="server" Text="Search by"></asp:Label>
                                <asp:DropDownList ID="ddlSearchby" runat="server" Width="120px" SkinID="ddlSmall" Visible="true" AutoPostBack="True">
                                    <asp:ListItem Selected="True">All</asp:ListItem>
                                    <asp:ListItem>Area</asp:ListItem>
                                    <asp:ListItem>School</asp:ListItem>
                                    <asp:ListItem>Title</asp:ListItem>
                                    <asp:ListItem>Level</asp:ListItem>
                                    <asp:ListItem Value="PostingState">Posting State</asp:ListItem>
                                    <asp:ListItem Value="PostingCycle">Posting Cycle</asp:ListItem>
                                    <asp:ListItem Value="PublishDate">Publish Date</asp:ListItem>
                                    <asp:ListItem Value="DeadlineDate">Deadline Date</asp:ListItem>
                                    <asp:ListItem Value="PositionStartDate">Position Start Date</asp:ListItem>
                                    <asp:ListItem Value="PositionEndDate">Position End Date</asp:ListItem>
                                    <asp:ListItem Value="PositionStatus">Position Status</asp:ListItem>
                                    <asp:ListItem Value="PendingConfirm">Pending Confirm</asp:ListItem>
                                    <asp:ListItem>Applicants </asp:ListItem>
                                </asp:DropDownList>

                                <asp:DropDownList ID="ddlSearchbyValue" runat="server" Width="150px" SkinID="ddlSmall" Visible="true" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtSearchBox" runat="server" Width="150px" Visible="false"></asp:TextBox>

                                <input runat="server" visible="false" type="text" id="datepicker" size="10" />
                                <asp:Label ID="DateTo" runat="server" Text="To"></asp:Label>
                                <input runat="server" visible="false" type="text" id="datepicker2" size="10" />
                                <div id="PanelDIV" runat="server" style="display: inline;">
                                    IN 
                     <asp:DropDownList ID="ddlPanel" runat="server" Width="90px" SkinID="ddlSmall" AutoPostBack="False">
                         <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
                         <asp:ListItem Value="02">Elementary</asp:ListItem>
                         <asp:ListItem Value="05">Secondary</asp:ListItem>
                     </asp:DropDownList>
                                </div>
                                <asp:DropDownList ID="ddlOpenClose" runat="server" Width="60px" SkinID="ddlSmall" AutoPostBack="False">
                                    <asp:ListItem>All</asp:ListItem>
                                    <asp:ListItem Selected="True">Open</asp:ListItem>
                                    <asp:ListItem>Close</asp:ListItem>
                                </asp:DropDownList>

                                <asp:Button ID="btnSearch" runat="server" Text="Go" />
                                <asp:HiddenField ID="hfSchoolCode" runat="server" />

                                <asp:HiddenField ID="HiddenFieldUserRole" runat="server" />
                            </div>
                        </td>
                        <td>
                            <div style="font-size:large">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <img src="../images/indicator.gif" alt="" />
                                        <b>Searching.....</b>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </td>
                        <td style="width:20%; text-align:right"> 
                            <a href="PostingSummaryApplyList.aspx" target="_self">Check the Applicant Histroy </a>
                        </td>
                    </tr>
                </table>


            </ContentTemplate>
        </asp:UpdatePanel>


        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="DivRoot" align="left">
                    <div style="overflow: hidden;" id="DivHeaderRow">
                        <table id="GridView2" style="border: 1px ridge gray; width: 100%;  background-color: white;" rules="all" cellspacing="1" cellpadding="1">
                        </table>
                    </div>

                    <div style="overflow: scroll; height: 600px" onscroll="OnScrollDiv(this)" id="DivMainContent">
                        <asp:GridView ID="GridView1" runat="server" CellPadding="1" Height="100%" Width="100%"
                            GridLines="Both" AutoGenerateColumns="False" BackColor="White" BorderColor="gray" BorderStyle="Ridge"
                            ShowHeader="true" ShowHeaderWhenEmpty="true" EmptyDataText="No Posted Position to show" EmptyDataRowStyle-CssClass="emptyData"
                            BorderWidth="1px" CellSpacing="1">
                            <Columns>

                                <asp:BoundField DataField="School_Year" ReadOnly="True" Visible="False" />
                                <asp:BoundField DataField="School_Code" ReadOnly="True" Visible="False" />
                                <asp:BoundField DataField="PositionID" ReadOnly="True" Visible="False" />
                                 <asp:BoundField DataField="RowNo" HeaderText="No.">
                                        <ItemStyle Width="40px" />
                                    </asp:BoundField>

                                <asp:TemplateField HeaderText="View">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="Link2" runat="server" Text='<%# Bind("ActionSign") %>'>  </asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Width="25px" Wrap="False" />
                                </asp:TemplateField>

                                <asp:BoundField DataField="PositionState" HeaderText="Open Status">
                                    <ItemStyle Width="40px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PostingNumber" HeaderText="Posting Number">
                                    <ItemStyle Width="60px" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="PostingState" HeaderText="Post Status">
                                    <ItemStyle Width="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DatePublish" HeaderText="Publishe Date">
                                    <ItemStyle Width="60px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="SchoolArea" HeaderText="School Area">
                                    <ItemStyle Width="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SchoolName" HeaderText="School">
                                    <ItemStyle Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PositionTitle" HeaderText="Position Title ">
                                    <ItemStyle Width="17%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PositionLevel" HeaderText="Mandatory Qualification">
                                    <ItemStyle Width="12%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Qualification" HeaderText="Minimum Qualification">
                                    <ItemStyle Width="12%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Description" HeaderText="Position Description">
                                    <ItemStyle Width="155" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Posting Round">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="Link3" runat="server" Text='<%# Bind("PostingCycle") %>'>  </asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Width="6%" />
                                </asp:TemplateField>

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

        <div style="color: Red; font-size: x-small">
            <asp:Label runat="server" ID="remaind22" Text="* Click on the Edit button to open position details"> </asp:Label>
        </div>


    </form>
</body>
</html>

<script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
<script src="../JQuery-UI/jquery-ui-1.11.4.min.js" type="text/javascript"></script>
<link href="../JQuery-UI/jquery-ui.css" rel="stylesheet" type="text/css" />


<script type="text/javascript">


    function openRemindPrincipalEmail() {
        goPage = "Loading2.aspx?pID=LTOHRStaffs/ReminderToPrincipal.aspx"
        openDetailPage(500, 600, goPage, "Send a Reminder Email to Principal");

    }
    var currentTR;
    function pageLoad(sender, args) {

        $(document).ready(function () {
            $("#CloseMeLink").click(function (e) {
                CloseMe();
            });
            LoadDatePicker();
            MakeStaticHeader("GridView1", 600, 1500, 30, false);
            $('#GridView1 tr').mouseenter(function (event) {
                if (currentTR != undefined)
                { currentTR.removeClass("highlightBoard"); }
                currentTR = $(this)
                currentTR.addClass("highlightBoard");
            });
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


    function openDetailPage(vHeight, vWidth, goPage, pTitle) {
        $(document).ready(function () {
            try {
                var vLeft = 10; // (screen.width / 2) - (vWidth / 2) - 50;
                var vTop = 5; // (screen.height / 2) - (vHeight / 2) - 100;
                $("#PositionDetailFrame", parent.document).attr('src', goPage);
                $("#popPagetitle", parent.document).text(pTitle);
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
    function openPosition(schoolyear, pID) {
        window.alert(pID);
        var goPage = "Loading2.aspx?pID=LTOHRStaffs/PostingSummaryDetails.aspx&SchoolYear=" + schoolyear + "&PositionID=" + pID;
        openDetailPage(700, 1000, goPage, "Posting Summary");

    }
    function openPositionSummary(schoolyear, pID) {
      //  window.alert("Position Summary" + pID);
        var goPage = "Loading2.aspx?pID=LTOHRStaffs/PostingSummaryDetails.aspx&SchoolYear=" + schoolyear + "&PositionID=" + pID;
        openDetailPage(700, 1200, goPage, "Posting Summary");
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



            //****Copy Header in divHeaderRow****
            //   DivHR.appendChild(tbl.cloneNode(true));

            DivHeader.appendChild(tbl.rows['0'].cloneNode(true));
            DivHeader.appendChild(tbl.rows['1'].cloneNode(true));

        }
    }


    function OnScrollDiv(Scrollablediv) {
        document.getElementById('DivHeaderRow').scrollLeft = Scrollablediv.scrollLeft;
        //   document.getElementById('DivFooterRow').scrollLeft = Scrollablediv.scrollLeft;
    }


</script>
