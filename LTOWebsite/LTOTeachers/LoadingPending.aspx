<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LoadingPending.aspx.vb" Inherits="LoadingPending" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        table {
            height:100%;
            width: 100%;
            text-align: center;
            vertical-align: middle;
            font-family: Arabic Typesetting;
            font-size: medium;
            color:red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table id="Table1">
            <tr style="height:600px">
                <td>
                  
                 <h1  style=" color:red;" >
                     Your current status is Pending. <br /><br />
                     You are not currently eligible to apply to Long Term Assignments.  <br /> <br /> 
                     If you have any questions, please reach out to your HR Contact.
                    </h1>
                </td>
            </tr>
        </table>
 
    </form>
</body>
</html>
