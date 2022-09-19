<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ApplyPositionNotQualS2.aspx.vb" Inherits="ApplyPositionNotQualS2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Apply Position</title>
    <base target="_self" />
    <meta http-equiv="Pragma" content="No-cache" />
    <style type="text/css">
        body {
            height: 300px;
            width: 600px;
        }

        td {
            font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif;
            font-size: 12px;
        }

        .NotQualified {
            font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
            font-size: small;
            color: orangered;
            font-weight: 700;
        }

        #NotQual {
            height: 80px;
            width: 99%;
        }
    </style>
    <link href="../Styles/DetailsPage.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">

        <table style="font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif; font-size: small; height: 100%; width: 99%; border: 0px solid red">
            <tr>
                <td colspan="3">
                    <asp:Label ID="LabelApplicant" runat="server" Text="Label"></asp:Label>
                    <div id="notQualified" runat="server" visible="false" class="NotQualified">You are unable to apply for this position as you do not currently hold the required qualifications based on your OCT.</div>
                    <div id="RosterRole" runat="server" visible="false" class="NotQualified">You are currently in Roster role that not qualified for Round 1 & 2 posting position.</div>
                </td>
            </tr>

            <tr>
                <td>Grade Level:</td>
                <td colspan="2">
                    <asp:TextBox ID="TextPostionLevel" runat="server" Height="20px" Width="100%" BackColor="Transparent"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:10%">Context</td>
                <td style="width:35%">Minimum Qualification</td>
                <td style="width:55%">OCT Qualification</td>
            </tr>
            <tr>
                <td>Qualification <br /> Request:</td>
                <td>
                    <asp:TextBox ID="TextPostionQualification" runat="server" Height="100px" TextMode="MultiLine" Width="99%" BackColor="Transparent" ReadOnly="true"></asp:TextBox></td>
                <td rowspan="2">
                    <asp:TextBox ID="TextApplicantQualfication" runat="server" Height="200px" TextMode="MultiLine" Width="100%" BackColor="Transparent" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Qualification  <br />  Not Match:</td>
                <td>
                    <asp:TextBox ID="NotMatchQual" class="NotQualified" runat="server" Height="90px" TextMode="MultiLine" Width="99%" BackColor="Transparent" ReadOnly="true"></asp:TextBox></td>
              
            </tr>


        </table>

    </form>
</body>
</html>
 
 