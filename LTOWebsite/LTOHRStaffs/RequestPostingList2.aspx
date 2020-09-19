<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RequestPostingList2.aspx.vb" Inherits="RequestPostingList2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/ListPage.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body {
            height: 100%;
            width: 100%;
            margin:0px;
        }

        .auto-style1 {
            height: 50px;
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

        .LabelButton {
            border: 2px ridge aliceblue;
            height: 20px;
            background-color: gainsboro;
            text-align: center;
            font-family: Arial, sans-serif;
        }
 
        .ListHeader {
            height: 30px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager runat="server">
        </asp:ScriptManager>
        <div style="display: inline; width: 90%">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
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
                        <asp:ListItem Value="RequestState">Request State</asp:ListItem>
                        <asp:ListItem Value="RequestFrom">Request from</asp:ListItem>
                    </asp:DropDownList>

                    <asp:DropDownList ID="ddlSearchbyValue" runat="server" Width="150px" SkinID="ddlSmall" Visible="true" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtSearchBox" runat="server" Width="150px" Visible="false"></asp:TextBox>

                    <input runat="server" visible="false" type="text" id="datepicker" size="10" />
                    <asp:Label ID="DateTo" runat="server" Text="To"></asp:Label>
                    <input runat="server" visible="false" type="text" id="datepicker2" size="10" />
                    <%--<ig:WebDatePicker ID="searchdate" runat="server" Visible="false" Height="20px" Width="100px" DisplayModeFormat="yyyy/MM/dd" EditModeFormat="yyyy/MM/dd" MaxValue="2020-12-31" MinValue="2013-01-01"></ig:WebDatePicker>--%>
                    <div id="PanelDIV" runat="server" style="display: inline;">
                        IN 
             <asp:DropDownList ID="ddlPanel" runat="server" Width="90px" SkinID="ddlSmall" AutoPostBack="True">
                 <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
                 <asp:ListItem Value="02">Elementary</asp:ListItem>
                 <asp:ListItem Value="05">Secondary</asp:ListItem>
             </asp:DropDownList>

                    </div>
                    <asp:Button ID="btnSearch" runat="server" Text="Go" />
                    <asp:Label ID="Labelemail" runat="server" Text="Label" Visible="false"></asp:Label>
                    <asp:CheckBox ID="CheckBoxReject" runat="server" Text="Rejected Posting Request" AutoPostBack="true" Visible="false" />
                    <asp:HiddenField ID="HiddenFieldUserRole" runat="server" />
                    <asp:Button ID="btnQualificationSetup" runat="server" Text="Qualification Setup" Font-Size="Small" Width="200px" Visible="false" />

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <%--<div class="DataContentTile" >School Open Position List </div>--%>
        <div>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>


                    <asp:GridView ID="GridView1" runat="server" CellPadding="1" Height="100%" Width="100%" GridLines="Both" AutoGenerateColumns="False" BackColor="White" BorderColor="gray" BorderStyle="Ridge" BorderWidth="1px" CellSpacing="1" EmptyDataText="No Request Position to post" EmptyDataRowStyle-CssClass="emptyData" ShowHeaderWhenEmpty="true">
                        <Columns>

                            <asp:BoundField DataField="myKey" ReadOnly="True" Visible="False" />
                            <asp:BoundField DataField="School_Year" ReadOnly="True" Visible="False" />
                            <asp:BoundField DataField="School_Code" ReadOnly="True" Visible="False" />
                            <asp:BoundField DataField="PositionID" ReadOnly="True" Visible="False" />
                            <asp:BoundField DataField="RowNo" HeaderText="No.">
                                <ItemStyle Width="2%" />
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="Current Status">
                                <ItemTemplate>
                                    <asp:HyperLink ID="Link2" runat="server" Text='<%# Bind("ActionSign") %>'>  </asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle Width="2%" Wrap="False" />
                            </asp:TemplateField>

                            <asp:BoundField DataField="PositionType" HeaderText="AppType">
                                <ItemStyle Width="3%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CurrentStep" HeaderText="Status">
                                <ItemStyle Width="3%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="StartDate" HeaderText="Assignment Start Date">
                                <ItemStyle Width="4%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EndDate" HeaderText="Assignment End Date">
                                <ItemStyle Width="4%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SchoolName" HeaderText="School Name">
                                <ItemStyle Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PositionTitle" HeaderText="Position Title">
                                <ItemStyle Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ReplaceTeacher" HeaderText="Teacher being Replaced">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>

                            <asp:BoundField DataField="ReplaceReason" HeaderText="Reason for Replacement">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>

                            <asp:BoundField DataField="PositionLevel" HeaderText="Qualification Level">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Qualification" HeaderText="Subject Area Qualification">
                                <ItemStyle Width="10%" HorizontalAlign="center" />
                            </asp:BoundField>


                            <asp:BoundField DataField="Description" HeaderText="Position Decription">
                                <ItemStyle Width="10%" HorizontalAlign="center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FTE" HeaderText="FTE">
                                <ItemStyle Width="2%" HorizontalAlign="center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FTEPanel" HeaderText="AM/PM">
                                <ItemStyle Width="3%" HorizontalAlign="center" />
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

                </ContentTemplate>
            </asp:UpdatePanel>

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
    function ReLoadPage(chageContent) {
        if (chageContent == "Yes") {
            $("#btnSearch").click();
        }
    }

    function openPosting(schoolyear, schoolcode, requestID, requestStatus) {
        var goPage = "Loading2.aspx?pID=LTOHRStaffs/RequestPostingDetails2.aspx" + "&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + requestID + "&RequestStatus=" + requestStatus;

        if ($("#HiddenFieldUserRole").val() != "Superintendent") {
            openDetailPage(500, 770, goPage, "Edit request for Posting")
        }
    }

    function openDetailPage(vHeight, vWidth, goPage, pTitle) {
        $(document).ready(function () {
            try {
                var vLeft = (screen.width / 2) - (vWidth / 2) - 100;
                var vTop = (screen.height / 2) - (vHeight / 2) - 50;
                $("#PositionDetailFrame", parent.document).attr('src', goPage);
                $("#popPagetitle", parent.document).text(pTitle);
                $("#hfInvokePageFrom", parent.document).val("LTOHRStaffs/RequestPostingList.aspx");
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
    $(document).ready(function () {
        try {

            $("#CloseMeLink").click(function (e) {
                CloseMe();
            });

            $("#datepicker").datepicker(
                {
                    dateFormat: 'yy-mm-dd',
                    showOn: "button",
                    buttonImage: "../images/calendar.gif",
                    buttonImageOnly: true,
                    changeMonth: true,
                    changeYear: true
                });
            $("#datepicker2").datepicker(
                {
                    dateFormat: 'yy-mm-dd',
                    showOn: "button",
                    buttonImage: "../images/calendar.gif",
                    buttonImageOnly: true,
                    changeMonth: true,
                    changeYear: true
                });

        }
        catch (e) { }
    });

    function pageLoad(sender, args) {

        $("#btnQualificationSetup").click(function (e) {
            var goPage = "Loading2.aspx?pID=LTOHRStaffs/QualificationMatchList.aspx";
            openDetailPage(700, 900, goPage, "Edit Qualification Match List")
        });

    }


</script>
