<%@ Page Language="VB" Async="true" AutoEventWireup="false" CodeFile="PostingSummaryDetailsSub.aspx.vb" Inherits="PostingSummaryDetailsSub" EnableTheming="true" %>


<!DOCTYPE html>

<html>
<head runat="server">
    <title>Add New open Position</title>
    <base target="_self" />
    <meta http-equiv="Pragma" content="No-cache" />


    <link href="../Styles/BubbleHelp.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/DetailsPage.css" rel="stylesheet" type="text/css" />
    <link href="../JQuery-UI/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="../JQuery-UI/jquery-ui-1.11.4.min.js" type="text/javascript"></script>

    <style>
        body {
            width: 99.5%;
        }

        #LTOMultipleSchool {
            position: relative;
            float: left;
        }

        #MultipleSchool {
            width: 100%;
            height: 100%;
        }

        .ListCategory {
            display: block;
            width: 100%;
            background-color: dodgerblue;
            font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
            font-size: large;
            font-weight: 600;
            color: white;
        }
         table tbody tr:nth-child(odd) {
            background-color: aliceblue;
        }

        .editcell {
       font-size:small;
             }
 
         .EditCPNum {
         display: none;
        }
      

        #GridView_Applicant td, th {
            border: 1px solid #e1d9d9;
        }

        #GridView_Interview td, th {
            border: 1px solid #e1d9d9;
        }      

        .loading {
            font-size: large;
        }
    </style>
    <script type="text/javascript">
        function ShowSaveMessage(action, message) {
            try {
                window.alert(action + " " + message);
            }
            catch (e) {
            }
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="ListCategory">Position Posting status </div>

        <div id="PositionPosting" runat="server">
            <table>
                <tr>
                    <td>Posting Number: </td>

                    <td style="text-wrap: none; overflow-wrap: normal">

                        <asp:TextBox ID="textPostingNumber" runat="server"   Height="20px" Width="85px" ReadOnly="true"></asp:TextBox>

                    </td>
                    <td></td>
                    <td style="text-align: right;">Link ID</td>
                    <td  >
                        <asp:TextBox ID="TextLinkPositionID" runat="server"  Height="20px" Width="85px" ReadOnly="true"  ></asp:TextBox>
                    </td>
                    <td  >Postion ID</td>
                    <td colspan="2">      <asp:TextBox ID="TextPositionID" runat="server"   Height="20px" Width="85px" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <a id="A1" runat="server" href="javascript:openPrintPage(90,180,'PostSummary_AllRound')"  >
                            <img height="15px" width="19px" src="../images/print.bmp" alt="print applicant list" title="Print applicant list" style="border-width: 1px; border-color: Purple;" />
                        </a>
                    </td>
                </tr>
                <tr>

                    <td>Assignment Start Date:</td>

                    <td style="text-wrap: none; overflow-wrap: normal">

                        <input runat="server" type="text" id="dateStart" size="9" readonly />
                    </td>
                    <td style="width: 15px"></td>
                    <td style="text-align: right;">Publish Date:</td>
                    <td style="text-wrap: none; overflow-wrap: normal">
                        <input runat="server" type="text" id="datePublish" size="9" readonly />
                    </td>
                    <td>Notice Principal Date:</td>
                    <td>
                         <input runat="server" type="text" id="dateNotice" size="9" readonly style="width:150px"  />
                    </td>
                </tr>
                <tr>

                    <td class="midtitle">Assignment &nbsp;End Date:</td>
                    <td>

                        <input runat="server" type="text" id="dateEnd" size="9" readonly />

                    </td>
                    <td style="width: 15px"></td>

                    <td class="midtitle">Deadline to Apply:</td>
                    <td>

                        <input runat="server" type="text" id="dateDeadline" size="9" readonly />
                    </td>

                    <td>Notice Principal:</td>
                    <td> <asp:TextBox ID="TextPrincipal" runat="server"  Height="20px" Width="150px" ReadOnly="true"></asp:TextBox> </td>

                </tr>
            </table>
        </div>
        <div class="ListCategory">Applicant List
             <a id="openApplicantList" runat="server" href="javascript:openPrintPage(90,180,'PostSummary_Applicant')"  >
                            <img height="15px" width="19px" src="../images/print.bmp" alt="print applicant list" title="Print applicant list" style="border-width: 1px; border-color: Purple;" />
                        </a>

        </div>
        <div id="ApplicantList" runat="server" style="height:220px; overflow:auto; "  >
            <asp:GridView ID="GridView_Applicant" runat="server" CellPadding="1" Height="100%" Width="100%" GridLines="Both" AutoGenerateColumns="False" BackColor="White" BorderColor="gray" BorderStyle="Ridge" BorderWidth="1px" CellSpacing="1" EmptyDataText="No Applicants in selected position" EmptyDataRowStyle-CssClass="emptyData" ShowHeaderWhenEmpty="true">
                <Columns>

                    <asp:BoundField DataField="SchoolYear" ReadOnly="True" Visible="False" />
                    <asp:BoundField DataField="PositionID" ReadOnly="True" Visible="False" />

                    <asp:BoundField DataField="RowNo" HeaderText="No.">
                        <ItemStyle Width="40px" />
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Interview Selected">
                            <ItemTemplate>
                                <asp:HyperLink ID="Link1" runat="server" Text='<%# Bind("ActionSign") %>' CssClass="mySelect">  </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="50px" Wrap="False" />
                        </asp:TemplateField>


                    <asp:BoundField DataField="OCTNumber" ReadOnly="True"  HeaderText="OCT Number" >
                        <ItemStyle Width="80px" />
                    </asp:BoundField>
                      <asp:BoundField DataField="CPNum" ReadOnly="True" HeaderText="Person ID" >
                        <ItemStyle Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TeacherName" ReadOnly="True"  HeaderText="Teacher Name" >
                        <ItemStyle Width="120px" />
                    </asp:BoundField>
                   
                    <asp:BoundField DataField="ApplyDate" HeaderText="Applied Date">
                        <ItemStyle Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="HiredDate" HeaderText="Hired Date">
                        <ItemStyle Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="OCTQualification" HeaderText="Teacher Qualifications">
                        <ItemStyle Width="30%" />
                    </asp:BoundField>     
                     <asp:BoundField DataField="TeacherComments" HeaderText="Applicant Comments">
                        <ItemStyle Width="25%" />
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
        <div class="ListCategory">Interview / Recommend / Confirm hire List
                         <a id="openInterviewlist" runat="server" href="javascript:openPrintPage(90,180,'PostSummary_Interview')"  >
                            <img height="15px" width="19px" src="../images/print.bmp" alt="print interview list" title="Print interview list" style="border-width: 1px; border-color: Purple;" />
                        </a>

        </div>
        <div id="InterviewList" runat="server" style="height:220px; overflow:auto;">
            <asp:GridView ID="GridView_Interview" runat="server" CellPadding="1" Height="100%" Width="100%" GridLines="Both" AutoGenerateColumns="False" BackColor="White" BorderColor="gray" BorderStyle="Ridge" BorderWidth="1px" CellSpacing="1" EmptyDataText="No interview candidate has been selected" EmptyDataRowStyle-CssClass="emptyData" ShowHeaderWhenEmpty="true">
                <Columns>

                     <asp:BoundField DataField="School_Year" ReadOnly="True" Visible="False" />
                    <asp:BoundField DataField="Position_ID" ReadOnly="True" Visible="False" />

                    <asp:BoundField DataField="Row#" HeaderText="No.">
                        <ItemStyle Width="40px" />
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Hired">
                            <ItemTemplate>
                                <asp:HyperLink ID="Link1" runat="server" Text='<%# Bind("Acceptance") %>' CssClass="mySelect">  </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="50px" Wrap="False" />
                        </asp:TemplateField>

                    <asp:BoundField DataField="OCT_Number" ReadOnly="True" HeaderText="OCT Number"  >
                        <ItemStyle Width="80px" />
                    </asp:BoundField>
                      <asp:BoundField DataField="Apply_UserID" ReadOnly="True"  HeaderText="Person ID"   >
                        <ItemStyle Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Teacher_Name" ReadOnly="True" HeaderText="Applicant Name"  >
                        <ItemStyle Width="120px" />
                    </asp:BoundField>
                   
                    <asp:BoundField DataField="Apply_Date" HeaderText="Applied Date">
                        <ItemStyle Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Hired_Date" HeaderText="Hired Date">
                        <ItemStyle Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Qualification" HeaderText="Teacher Qualifications">
                        <ItemStyle Width="25%" />
                    </asp:BoundField>     
                    <asp:BoundField DataField="Recomendation" HeaderText="Interview Recommendation">
                        <ItemStyle Width="10%" />
                    </asp:BoundField>          
                    
                     <asp:BoundField DataField="Interview_Date" HeaderText="Interview Date">
                        <ItemStyle Width="80px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="Result" HeaderText="Interview Result">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="Effective_Date" HeaderText="Effective Date">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NewHired_Date" HeaderText="Hire Date">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                      <asp:BoundField DataField="Hire_comments" HeaderText="Hired Comments">
                        <ItemStyle Width="10%" />
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
  <div class="ListCategory">Email Notification
                   <a id="openEmailNotice" runat="server" href="javascript:openPrintPage(90,180,'PostSummary_Email')"  >
                            <img height="15px" width="19px" src="../images/print.bmp" alt="print email notification" title="Print email notification" style="border-width: 1px; border-color: Purple;" />
                        </a>

  </div>
        <div id="Div1" runat="server" style="height:150px; overflow:auto;">
            <asp:GridView ID="GridView_eMail" runat="server" CellPadding="1" Height="100%" Width="100%" GridLines="Both" AutoGenerateColumns="False" BackColor="White" BorderColor="gray" BorderStyle="Ridge" BorderWidth="1px" CellSpacing="1" EmptyDataText="No interview candidate has been selected" EmptyDataRowStyle-CssClass="emptyData" ShowHeaderWhenEmpty="true">
                <Columns>

                     <asp:BoundField DataField="School_Year" ReadOnly="True" Visible="False" />
                    <asp:BoundField DataField="IDs" ReadOnly="True" Visible="False" />

                    
                     <asp:TemplateField HeaderText="eMail">
                            <ItemTemplate>
                                <asp:HyperLink ID="Link1" runat="server" Text='<%# Bind("EmailSign") %>' CssClass="mySelect">  </asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="50px" Wrap="False" />
                        </asp:TemplateField>

                    <asp:BoundField DataField="Email_Type" ReadOnly="True" HeaderText="Type"  >
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                   <asp:BoundField DataField="Email_To" ReadOnly="True" HeaderText="Mail To"  >
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="Email_CC" ReadOnly="True" HeaderText="Mail CC"  >
                        <ItemStyle Width="100px" />
                    </asp:BoundField>  
                    <asp:BoundField DataField="Email_Subject" ReadOnly="True" HeaderText="Subject"  >
                        <ItemStyle Width="30%" />
                    </asp:BoundField>
                   
                    <asp:BoundField DataField="Date_EmailNotice" HeaderText="Notice Date">
                        <ItemStyle Width="80px" />
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
   

    </form>

</body>
</html>
 

<script src="../Scripts/TabMenu.js" type="text/javascript"></script>

 <script   type="text/javascript">

     function openPrintPage(height, width, rID) {
         var schoolyear = querystring('yID');
         var positionID = querystring('pID');
         var postingCycle = querystring('cID');    
         var postingNum = $("#textPostingNumber").val();
        
         var goPage = "../PDFLoading/PDFDocument_Loading.aspx?rID=" + rID + "&yID=" + schoolyear + "&pID=" + positionID + "&pNo=" + postingNum + "&cID=" + postingCycle;

         window.open(goPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,width=600 height=700, top=5, left=5");
       //  return false;
     }
     function querystring(key) {
         var re = new RegExp('(?:\\?|&)' + key + '=(.*?)(?=&|$)', 'gi');
         var r = [], m;
         while ((m = re.exec(document.location.search)) != null) r.push(m[1]);
         return r;
     }
      
 </script>
 