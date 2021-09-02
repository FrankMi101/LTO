<%@ Page Language="VB" AutoEventWireup="false" CodeFile="HiringPositionList2.aspx.vb" Inherits="HiringPositionList2"
    EnableTheming="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hiring Position TeacherList</title>
    <link href="../Styles/ListPage.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        body {
            height: 100%;
            width: 99.8%;
        }

        .auto-style1 {
            height: 350px;
        }



        .WDG {
            height: 100%;
            width: 100%;
        }

        .emptyData {
            font-size: xx-large;
            text-align: center;
            color: blue;
        }

        .DataContentTile {
            font-family: Arial;
            font-size: small;
            font-weight: 300;
            color: blue;
        }

        .ListHeader {
            height: 20px;
        }
    </style>


</head>
<body style="width: 99%">
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
        </asp:ScriptManager>
        <div>

            <table id="Table3" border="0" class="TableFont1" style="text-align: left; width: 90%;">
                <tr id="SuperAreaRow" runat="server">
                    <td style="width: 70%">
                        <asp:Label ID="Label3" runat="server" Text="School Year: " Visible="false"></asp:Label>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlSchoolYear" runat="server" Width="100px" SkinID="ddlSmall" AutoPostBack="True"
                                    Enabled="true">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlappType" runat="server" Width="55px" Visible="true" SkinID="ddlSmall" AutoPostBack="True">
                                    <asp:ListItem>POP</asp:ListItem>
                                    <asp:ListItem>LTO</asp:ListItem>
                                    <asp:ListItem>COP</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="lblSuperArea" runat="server" Text="Search by"></asp:Label>
                                <asp:DropDownList ID="ddlSearchby" runat="server" Width="100px" SkinID="ddlSmall" Visible="true" AutoPostBack="True">
                                    <asp:ListItem Selected="True">All</asp:ListItem>
                                    <asp:ListItem>Area</asp:ListItem>
                                    <asp:ListItem>Panel</asp:ListItem>
                                    <asp:ListItem>School</asp:ListItem>
                                    <asp:ListItem>Title</asp:ListItem>
                                    <asp:ListItem>Level</asp:ListItem>
                                    <asp:ListItem>lastName</asp:ListItem>
                                    <asp:ListItem>PostingNum</asp:ListItem>
                                </asp:DropDownList>

                                <asp:DropDownList ID="ddlSearchbyValue" runat="server" Width="200px" SkinID="ddlSmall" Visible="true" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtSearchBox" runat="server" Width="200px" Visible="false"></asp:TextBox>



                                <asp:Button ID="btnSearch" runat="server" Text="Go" />
                                <asp:CheckBox ID="cb4Th" runat="server" Text="4th Round" />

                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>

                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <img src="../images/indicator.gif" alt="" />
                                        <b>Searching.....</b>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="font-size: x-small">
                        <div style="display: none;">
                            <a id="openAnswerA" runat="server" href="javascript:openPrintPage(90,180)">
                                <img src="../images/print.bmp" alt="" title="Print SLIP One Page Summary" style="border-width: 1px; border-color: Purple;" />
                            </a>
                        </div>
                    </td>
                    <td></td>
                    <td style="font-size: x-small">

                        <asp:HiddenField ID="HiddenFieldUserRole" runat="server" />
                    </td>
                </tr>

            </table>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>


                <asp:GridView ID="GridView1" runat="server" CellPadding="1" Height="100%" Width="100%" GridLines="Both" AutoGenerateColumns="False" BackColor="White" BorderColor="gray" BorderStyle="Ridge" BorderWidth="1px" CellSpacing="1" EmptyDataText="No recommend for hire position to confirm" EmptyDataRowStyle-CssClass="emptyData" ShowHeaderWhenEmpty="true">
                    <Columns>

                        <asp:BoundField DataField="myKey" ReadOnly="True" Visible="False" />
                        <asp:BoundField DataField="School_Year" ReadOnly="True" Visible="False" />
                        <asp:BoundField DataField="Apply_UserID" ReadOnly="True" Visible="False" />
                        <asp:BoundField DataField="PositionID" ReadOnly="True" Visible="False" />

                        <asp:BoundField DataField="RowNo" HeaderText="No.">
                            <ItemStyle Width="2%" />
                        </asp:BoundField>

                        <asp:BoundField DataField="PostingNumber" HeaderText="Posting Number">
                            <ItemStyle Width="3%" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Confirm Hire">
                            <ItemTemplate>
                                <asp:HyperLink ID="Link2" runat="server" Text='<%# Bind("ActionSign") %>'>  </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="3%" Wrap="False" />
                        </asp:TemplateField>

                        <asp:BoundField DataField="DateInterview" HeaderText="Applied Date">
                            <ItemStyle Width="3%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TeacherName" HeaderText="Teacher Name">
                            <ItemStyle Width="6%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PostingCycle" HeaderText="Round">
                            <ItemStyle Width="2%" HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PositionTitle" HeaderText="Position Title">
                            <ItemStyle Width="7%" />
                        </asp:BoundField>

                        <asp:BoundField DataField="SchoolName" HeaderText="School">
                            <ItemStyle Width="10%" />
                        </asp:BoundField>

                        <asp:BoundField DataField="SchoolArea" HeaderText="School Area">
                            <ItemStyle Width="4%" />
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
                        <asp:BoundField DataField="PositionLevel" HeaderText="Division Required">
                            <ItemStyle Width="8%" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Qualification" HeaderText="Minimum Qualification ">
                            <ItemStyle Width="8%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Description" HeaderText="Position Description">
                            <ItemStyle Width="8%" />
                        </asp:BoundField>

                        <asp:BoundField DataField="ApplicantQualification" HeaderText="OCT Qualification">
                            <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Comments" HeaderText="HR Notes">
                            <ItemStyle Width="8%" />
                        </asp:BoundField>
                       
                        <asp:TemplateField HeaderText="Appraisals">
                            <ItemTemplate>
                                <asp:HyperLink ID="Link3" runat="server" Text='<%# Bind("Appraisal") %>'>  </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="8%" Wrap="true" />
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

            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>



<script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
<script src="../Scripts/PopUpDIVLeft.js" type="text/javascript"></script>

<script type="text/javascript" id="igClientScript1">

    function openConfirm(schoolyear, positionID, applyuserID, postingCycle) {
        var Parameter = "&SchoolYear=" + schoolyear + "&ApplyUserID=" + applyuserID + "&PositionID=" + positionID; //+ "&TeacherName=" + teacherName;
        // var goPage = "Loading2.aspx?pID=LTOHRStaffs/HiringDetails.aspx" + Parameter
        var goPage = "Loading2.aspx?pID=LTOHRStaffs/HiringDetails2.aspx" + Parameter
        var xHeight = "500";
        var xWidth = "785";
        var pTitle = "Confirm for hiring";
        if (postingCycle == "4") {
            pTitle = "Confirm for hiring ( 4th round )";
            xHeight = "500";
            xWidth = "650";
            goPage = "Loading2.aspx?pID=LTOHRStaffs/HiringDetails4th2.aspx" + Parameter;
        }

        if ($("#HiddenFieldUserRole").val() != "Superintendent") {
            openDetailPage(xHeight, xWidth, goPage, pTitle);
        }


    }
    function openLTOAppraisal(schoolyear, schoolcode, SessionID, TeacherID) {
        var printPage = "../PDFLoading/PDFDocument_Loading.aspx?rID=InterviewPackage" + "&yID=" + schoolyear + "&CPNum=" + TeacherID + "&pID=" + SessionID;
        var popup1 = window.open(printPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=800,height=600,top=0,left=0");
    }

    function openDetailPage(vHeight, vWidth, goPage, pTitle) {
        $(document).ready(function () {
            try {
                var vLeft = (screen.width / 2) - (vWidth / 2) - 100;
                var vTop = (screen.height / 2) - (vHeight / 2) - 50;
                $("#PositionDetailFrame", parent.document).attr('src', goPage);
                $("#popPagetitle", parent.document).text(pTitle);
                $("#hfInvokePageFrom", parent.document).val("LTOHRStaffs/HiringPositionList2.aspx");
                $("#PositionDetailDIV", parent.document).css({
                    top: vTop,
                    left: vLeft,
                    height: vHeight,
                    width: vWidth
                })
                $("#PopUpDIV", parent.document).fadeToggle("fast");
                $("#PositionDetailDIV", parent.document).fadeToggle("fast");
            }

            catch (e) { }

        });

    }

</script>
