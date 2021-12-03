<%@ Page Language="VB" AutoEventWireup="false" CodeFile="OpenPositionList2.aspx.vb" Inherits="OpenPositionList2" %>


<%--<%@ Register assembly="Infragistics4.Web.v16.2, Version=16.2.20162.1023, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.GridControls" tagprefix="ig" %>--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
     <link href="../Styles/ListPage.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        body {
            height: 100%;
            width: 100%;
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
    </style>
    <style type="text/css" id="Infragistics WebdataGrid">
        .ListHeader {
            height: 50px;
        }

        .auto-style2 {
            width: 16px;
            height: 16px;
        }

        .auto-style4 {
            width: 19px;
            height: 18px;
        }

        .RowDisable {
            background-color: gray;
        }

        .highlightBoard {
            border: 2px #ff6a00 solid;
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
            <table id="Table3" border="0" class="TableFont1" style="text-align: left; height: 100%;">
                <tr id="SuperAreaRow" runat="server">
                    <td>

                        <asp:Label ID="lblSchoolyear" runat="server" Text="School Year: "></asp:Label>
                        <asp:DropDownList ID="ddlSchoolYear" runat="server" Width="100px" Visible="true" AutoPostBack="True" SkinID="ddlSmall"
                            Enabled="true">
                        </asp:DropDownList>
                        <asp:Label ID="lblSuper" runat="server" Text="School: "></asp:Label>
                        <asp:DropDownList ID="ddlschoolcode" runat="server" CssClass="editcell Edit-Content-Control" SkinID="ddlSmall" Width="60px" AutoPostBack="true"></asp:DropDownList>
                        <asp:DropDownList ID="ddlSchool" runat="server" Width="400px" SkinID="ddlSmall" CssClass="editcell Edit-Content-Control" AutoPostBack="true"></asp:DropDownList>
                        Filter by:<asp:DropDownList ID="ddlProgress" runat="server" Width="150px" SkinID="ddlSmall" CssClass="editcell Edit-Content-Control" AutoPostBack="true"></asp:DropDownList>
                        <a id="ProcessHelp" runat="server" href="javascript:openHelpProcess()">
                            <img alt="Help process" class="auto-style4" src="../images/HelpS.bmp" />
                        </a>


                    </td>
                    <td style="font-size: x-small; display: none">
                        <a id="openAnswerA" runat="server" href="javascript:openPrintPage(90,180)">
                            <img src="../images/print.bmp" alt="" title="Print Posting List" style="border-width: 1px; border-color: Purple;" />
                        </a>
                    </td>
                    <td></td>
                    <td style="font-size: x-small">

                        <asp:HiddenField ID="HiddenFieldUserRole" runat="server" />
                         <asp:HiddenField ID="HiddenFieldDevice" runat="server" />
                    </td>
                    <td style="width: 30%">
                        <a id="A1" runat="server" href='https://webapp.tcdsb.org/WebDocuments/Documents/LTO/HM40.pdf' target="_blank">H.M.40</a> &nbsp;&nbsp;&nbsp;&nbsp;
                        <a id="A3" runat="server" href='https://webapp.tcdsb.org/WebDocuments/Documents/LTO/HM31.pdf' target="_blank">H.M.31</a>&nbsp;&nbsp;&nbsp;&nbsp;
                        <a id="A2" runat="server" href='https://webapp.tcdsb.org/WebDocuments/Documents/LTO/Long Term Occasional Teachers List.pdf' target="_blank">LTO Teacher List</a>
                        <%--<a href="../Template/Long%20Term%20Occasional%20Teachers%20List.pdf">../TemplateXLS/Long Term Occasional Teachers List.pdf</a>--%>
                    </td>
                </tr>

            </table>
        </div>
        <%--<div class="DataContentTile" >School Open Position List </div>--%>
        <div>


            <asp:GridView ID="GridView1" runat="server" CellPadding="1" Height="100%" Width="100%" GridLines="Both" AutoGenerateColumns="False" BackColor="White" BorderColor="gray" BorderStyle="Ridge" BorderWidth="1px" CellSpacing="1" EmptyDataText="No Position posted " EmptyDataRowStyle-CssClass="emptyData" ShowHeaderWhenEmpty="true">
                <Columns>

                    <asp:BoundField DataField="School_Year" ReadOnly="True" Visible="False" />
                    <asp:BoundField DataField="School_Code" ReadOnly="True" Visible="False" />
                    <asp:BoundField DataField="appType" ReadOnly="True" Visible="False" />
                    <asp:BoundField DataField="PositionID" ReadOnly="True" Visible="False" />

                    <asp:BoundField DataField="PostingNumber" HeaderText="Posting Number">
                        <ItemStyle Width="3%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Select Position">
                        <ItemTemplate>
                            <asp:HyperLink ID="Link1" runat="server" Text='<%# Bind("ActionSign") %>'>  </asp:HyperLink>
                        </ItemTemplate>
                        <ItemStyle Width="3%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Interview Progress">
                        <ItemTemplate>
                            <asp:HyperLink ID="Link2" runat="server" Text='<%# Bind("InterviewProgress") %>'>  </asp:HyperLink>
                        </ItemTemplate>
                        <ItemStyle Width="3%" />
                    </asp:TemplateField>



                    <asp:BoundField DataField="DatePublish" HeaderText="Published Date">
                        <ItemStyle Width="4%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="StartDate" HeaderText="Start Date">
                        <ItemStyle Width="4%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="EndDate" HeaderText="End Date">
                        <ItemStyle Width="4%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PositionState" HeaderText="Open Status">
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ReplaceTeacher" HeaderText="Teacher being Replaced">
                        <ItemStyle Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="HiredTeacher" HeaderText="Hired Teacher">
                        <ItemStyle Width="10%" />
                    </asp:BoundField>
                   
                    <asp:BoundField DataField="PositionTitle" HeaderText="Position Title">
                        <ItemStyle Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PositionLevel" HeaderText="Division Required">
                        <ItemStyle Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Qualification" HeaderText="Subject Area Qualification ">
                        <ItemStyle Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="Position Description">
                        <ItemStyle Width="11%" />
                    </asp:BoundField>
                     <asp:BoundField DataField="FTE" HeaderText="BTC">
                        <ItemStyle Width="2%" HorizontalAlign="center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FTEPanel" HeaderText="AM/PM">
                        <ItemStyle Width="2%" HorizontalAlign="center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PostingCycle" HeaderText="Round">
                        <ItemStyle Width="2%" HorizontalAlign="center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RequestSchool" HeaderText="Request by">
                        <ItemStyle Width="3%" HorizontalAlign="center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Interview Team"  >
                        <ItemTemplate>
                            <asp:HyperLink ID="Link4" runat="server" Text='<%# Bind("Team") %>'>  </asp:HyperLink>
                        </ItemTemplate>
                        <ItemStyle Width="2%" Wrap="False" />
                    </asp:TemplateField>  

                    <asp:TemplateField HeaderText="Step">
                        <ItemTemplate>
                            <asp:HyperLink ID="Link3" runat="server" Text='<%# Bind("CurrentStep") %>'>  </asp:HyperLink>
                        </ItemTemplate>
                        <ItemStyle Width="2%" Wrap="False" />
                    </asp:TemplateField>

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


        <%--  <iframe id="InterView5List" runat="server" name="InterView5List" class="iFrameContent"
            frameborder="0" src="#" scrolling="no"></iframe>--%>
    </form>
</body>
</html>



<script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
<script src="../Scripts/PopUpDIVLeft.js" type="text/javascript"></script>

<script type="text/javascript" id="igClientScript1">
    var currentTR;
    function pageLoad(sender, args) {

        $(document).ready(function () {
            //$('#GridView1 tr').mouseenter(function (event) {
            //    if (currentTR != undefined)
            //    { currentTR.removeClass("highlightBoard"); }
            //    currentTR = $(this)
            //    //  $(this).addClass("highlightBoard");
            //    currentTR.addClass("highlightBoard");
            //});


        });
    }


    function openDetailPage(vHeight, vWidth, goPage, pTitle) {
        $(document).ready(function () {
            try {
                var vLeft = (screen.width / 2) - (vWidth / 2) - 50;
                var vTop = (screen.height / 2) - (vHeight / 2) - 100;
                if ($("#HiddenFieldDevice").val() == "Mobile") {
                    vTop = 1;
                    vLeft = 1;
                  
                }

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
    function openInterviewList(schoolyear, schoolcode, positionID, appType, status) {
        var schoolname = $("#ddlSchool option:selected").text();
        switch (status) {
            case "InterviewTeam":
                var goPage = "Loading2.aspx?pID=LTOPrincipals/InterviewTeam.aspx" + "&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID + "&SchoolName=" + schoolname;
                $("#iFrameDIV", parent.document).css("heigh", "99%");
                if ($("#HiddenFieldDevice").val() == "Mobile")
                { openDetailPage(500, 480, goPage, "Select Interview Member"); }
                else
                { openDetailPage(350, 550, goPage, "Select Interview Member"); }
                break;

          //  case "MoreInterview":
                //var goPage = "Loading2.aspx?pID=LTOPrincipals/NoticeToHRStaff.aspx" + "&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID + "&SchoolName=" + schoolname;
                //if ($("#HiddenFieldDevice").val() == "Mobile")
                //{  openDetailPage(550, 480, goPage, "Request more interview Canadidate");  }
                //else
                //{  openDetailPage(550, 700, goPage, "Request more interview Canadidate");  }

            //    break;
            //case "Done":
            //    var goPage = "LoadingP.aspx?pID=2&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID + "&SchoolName=" + schoolname + "&appType=" + appType
            //    location.href = goPage;
            //    break;
            //case "Interview":
            //    var goPage = "LoadingP.aspx?pID=2&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID + "&SchoolName=" + schoolname + "&appType=" + appType
            //    location.href = goPage;
            //    break;
            //case "RecommendHire":
            //    var goPage = "LoadingP.aspx?pID=2&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID + "&SchoolName=" + schoolname + "&appType=" + appType
            //    location.href = goPage;
            //    break;
            default:
                var goPage = "LoadingP.aspx?pID=2&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID + "&SchoolName=" + schoolname + "&appType=" + appType + "&Status=" + status
                location.href = goPage;
                break;
        }

    }
    function openHelpProcess() {
        openDetailPage(500, 550, "Loading2.aspx?pID=LTOPrincipals/PrincipalProcess.aspx", "School Principal Interview and Recommend for Hire Process")
    }
</script>
