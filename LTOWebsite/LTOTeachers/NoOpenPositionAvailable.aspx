<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NoOpenPositionAvailable.aspx.vb" Inherits="NoOpenPositionAvailable" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Message Page</title>
    <style>
        table {
            height: 100%;
            width: 100%;
            text-align: center;
            vertical-align: middle;
            font-family: Arabic Typesetting;
            font-size: medium;
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table id="Table1">
            <tr style="height: 600px">
                <td>
                    <div id="MessageLTOPOP" runat="server" visible="false">
                        <h1 style="color: red;">There currently are no LTO/POP Open Positions available.</h1>
                        <br />
                        <br />
                        <h1 style="color: red;">Please visit later </h1>
                    </div>

                    <div id="MessagePOP" runat="server" visible="false">
                        <h1 style="color: red;">There currently are no Permanent Open Positions available for viewing.</h1>
                        <br />
                        <br />
                        <h1 style="color: red;">Please visit later </h1>
                    </div>
                    <div id="MessageLTO" runat="server" visible="false">
                        <h1 style="color: red;">There currently are no Long Term Occasional Assignments available for viewing.</h1>
                        <br />
                        <br />
                        <h1 style="color: red;">Please visit later </h1>
                    </div>
                    <div id="MessagePOP3" runat="server" visible="false">
                        <h1 style="color: red;">There are currently no Permanent Open Positions (3rd Posting ) available for viewing.</h1>
                        <br />
                        <br />
                        <h1 style="color: red;">Please visit the LTO/POP site regularly for any new postings available in Round 3 </h1>

                    </div>
                    <div id="MessageLTO3" runat="server" visible="false">
                        <h1 style="color: red;">There currently are no Long Term Occasional Assignments (3rd Posting ) available for viewing.</h1>
                        <br />
                        <br />
                        <h1 style="color: red;">Please visit later </h1>
                    </div>
                    <div id="MessageLTO4" runat="server" visible="false">
                        <h1 style="color: red;">There currently are no Long Term Occasional Assignments available for viewing.</h1>
                        <br />
                        <br />
                        <h1 style="color: red;">All LTO assignments for the <asp:Label ID="Labelschoolyear1" runat="server" Text="2020/2021"></asp:Label>  school year will be published on <asp:Label ID="LabelDate1" runat="server" Text="2020/2021"></asp:Label>. 
                            <br />
                            <br />
                            <br />
                           <%-- Please visit the LTO site again at that time.--%>
                        </h1>
                    </div>
                    <div id="MessagePOP4" runat="server" visible="false">
                        <h1 style="color: red;">There currently are no Permanent Open Positions available for viewing.</h1>
                        <br />
                        <br />
                        <h1 style="color: red;">Permanent Open Positions for the  <asp:Label ID="LabelSchoolyear2" runat="server" Text="2020/2021"></asp:Label>  school year will not be published until 
                            all permanent elementary & secondary teachers who have been declared surplus are secured a placement for September <asp:Label ID="Labelyear1" runat="server" Text="2020"></asp:Label> . 
                            <br />
                            <br />
                            <br />
                            Please visit the LTO site again at that time.
                        </h1>
                    </div>
                    <div id="MessagePOP5" runat="server" visible="false"  style="width: 700px; margin: auto; font-size:large">
                        
                        <br />
                        <br />
                        <br />
                        <br />
                        <h1 style="color: red;">
                            Please be advised that due the current coronavirus pandemic and the Ministry of Education’s
                            mandate as a precautionary measure to shutdown schools from March 23 to April 5, any new LTO
                            assignment will not be posted until schools re-open.
                        </h1>
                    
                    </div>
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
