<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ApplicantList2.aspx.vb" Inherits="ApplicantList2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="../Styles/ListPage.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body {
            height:100%;
            width: 100%;
            margin:0px;
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

        .EditCPNum {
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
        }

        .defaultBoard {
            border: 0px #ff6a00 solid;
        }

        .top5Row {
            /*background-color:lightgreen;*/
            border-bottom: 8px solid darkcyan;
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
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <%--<asp:ServiceReference Path="~/WebServices/GetDeadLineDate.svc" />--%>
                <asp:ServiceReference Path="~/WebServices/WebService.asmx" />
            </Services>
        </asp:ScriptManager>
        <div style="text-align: left; display: inline; font-family: Arial, sans-serif; font-size: 11px;">
            <asp:Label ID="labelSelected" runat="server" Text="Label" Width="65%"></asp:Label>
            <div style="display: inline">
                <asp:CheckBox ID="checkboxAll" runat="server" Text="Include all Applicants" Checked="true" AutoPostBack="true" />
                <img src="../images/excel.bmp" />
                <asp:LinkButton ID="btnExcel" runat="server">Export the List to EXCEL </asp:LinkButton>
                <asp:HiddenField ID="HiddenFieldUserRole" runat="server" />
                <asp:HiddenField ID="HiddenFieldSchoolYear" runat="server" />
                <asp:HiddenField ID="HiddenFieldPositionID" runat="server" />
                <asp:HiddenField ID="HiddenFieldHired" runat="server" />

            </div>
        </div>
        <div id="DivRoot"   style="width: 100%; height: 100%;">
            <div style="overflow: hidden;" id="DivHeaderRow">
                <table id="GridView2" style="border: 1px ridge gray; width: 100%; height:99%; background-color: white;" rules="all" cellspacing="1" cellpadding="1" borderwidth="1px">
                </table>
            </div>

            <div style="overflow: scroll; width: 99%; height: 100%" onscroll="OnScrollDiv(this)" id="DivMainContent">
                <asp:GridView ID="GridView1" runat="server" CellPadding="1" Height="100%" Width="100%" GridLines="Both" AutoGenerateColumns="False" BackColor="White" BorderColor="gray" BorderStyle="Ridge" BorderWidth="1px" CellSpacing="1" EmptyDataText="No Applicants in selected position" EmptyDataRowStyle-CssClass="emptyData" ShowHeaderWhenEmpty="true">
                    <Columns>

                        <asp:BoundField DataField="myKey" ReadOnly="True" Visible="False" />
                        <asp:BoundField DataField="SchoolYear" ReadOnly="True" Visible="False" />

                        <asp:BoundField DataField="PositionID" ReadOnly="True" Visible="False"  />
                        <asp:BoundField DataField="OCTNumber" ReadOnly="True" Visible="False" />

                        <asp:BoundField DataField="RowNo" HeaderText="No." ItemStyle-CssClass="myRowNo">
                            <ItemStyle Width="2%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Confirm selected">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbSelect" Checked='<%# Bind("SelectedC") %>' runat="server"   CssClass="myCheck"></asp:CheckBox>
                            </ItemTemplate>
                            <ItemStyle Width="2%" Wrap="False" />
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Interview Selected">
                            <ItemTemplate>
                                <asp:HyperLink ID="Link1" runat="server" Text='<%# Bind("Acceptance") %>' CssClass="mySelect">  </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="2%" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:HyperLink ID="Link2" runat="server" Text='<%# Bind("ActionSign") %>'>  </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="2%" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="OCT">
                            <ItemTemplate>
                                <asp:HyperLink ID="Link3" runat="server" Text='<%# Bind("OCTLink") %>'>  </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="2%" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Teacher Name">
                            <ItemTemplate>
                                <asp:HyperLink ID="Link4" runat="server" Text='<%# Bind("TeacherName") %>'>  </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" >
                            <ItemTemplate>
                                <asp:HyperLink ID="Link7" runat="server"  Text='<%# Bind("ApplicantType") %>'>  </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="2%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Outcome" HeaderText="Interview Outcome">
                            <ItemStyle Width="7%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ApplyDate" HeaderText="Applied Date">
                            <ItemStyle Width="4%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HiredDate" HeaderText="Hired Date">
                            <ItemStyle Width="4%" />
                        </asp:BoundField>
                           <asp:BoundField DataField="Ranking" HeaderText="Ranking">
                            <ItemStyle Width="2%" />
                        </asp:BoundField>
                           <asp:BoundField DataField="Lots" HeaderText="Lots">
                            <ItemStyle Width="2%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OCTQualification" HeaderText="Teacher Qualifications">
                            <ItemStyle Width="28%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Appraisals">
                            <ItemTemplate>
                                <asp:HyperLink ID="Link5" runat="server" Text='<%# Bind("Appraisal") %>'>  </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="21%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Applicant Comments">
                            <ItemTemplate>
                                <asp:HyperLink ID="Link6" runat="server" Text='<%# Bind("TeacherComments") %>'>  </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Noticed" HeaderText="Noticed" ReadOnly="True" ItemStyle-CssClass="myNoticed">
                            <ItemStyle Width="2%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CPNum" ReadOnly="True" ItemStyle-CssClass="EditCPNum">
                            <ItemStyle Width="0px" />
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
<%--            <div style="height: 70%"></div>--%>
        </div>
<%--        <div style="color: Red; font-size: x-small">
            <asp:Label runat="server" ID="remaind22" Text="* Click on the Teacher button to view applicant details information "> </asp:Label>

        </div>--%>
         <div id="CommentsDIV" class="commentsHR hide boardPending" style="width: 100%;">
            <iframe id="CommentsiFrame" runat="server" name="CommentsiFrame" scrolling="no" seamless="seamless" style="height: 100%; width: 100%; border: 0px blue solid"
                src="#"></iframe>

        </div>

    
    </form>
</body>
</html>

<script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
<script src="../Scripts/PopUpDIVLeft.js" type="text/javascript"></script>

<script src="../Scripts/GetMousePosition.js"></script>
<script src="../Scripts/GridViewLayout.js" type="text/javascript"></script>

<script src="ApplicantList2.js"></script>


<script type="text/javascript">


</script>

