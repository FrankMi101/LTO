<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ApplicatVerification_0.aspx.vb" Inherits="ApplicantVerification_0" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LTO Staff Hire Welocome</title>
    <style type="text/css" >

        div {
         height:100%;
         width:100%;
         text-align: center ;
         vertical-align:middle ;
         font-family:Arial ;
         color: darkred; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     
         <div id="SearchList" runat="server" style="overflow: auto; height: 250px; width: 100%;">
                <table style="width:1000px; border:solid 1px blue" border="1">
                    <tr>
                        <td style=" width:50%">LTO Profile</td>
                        <td style=" width:50%" >SAP Profile</td>
                    </tr>
                    <tr>
                        <td><div id="LTOProfile" runat="server"></div></td>
                        <td><div id="SAPProfile" runat="server"></div></td>
                    </tr>
                </table>
            </div>
   
    </form>
</body>
</html>
