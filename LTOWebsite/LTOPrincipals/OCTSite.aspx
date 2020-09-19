<%@ Page Language="VB" AutoEventWireup="false" CodeFile="OCTSite.aspx.vb" Inherits="OCTSite" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Loading Page</title>
    <style>
        table {
            height: 100%;
            width: 100%;
            text-align: center;
            vertical-align: middle;
            font-family: Arabic Typesetting;
            font-size: medium;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table id="Table1">
            <tr>
                <td>
                    <img src="../images/please_wait.gif" alt="Loading" />

                    <a id="PageURL" runat="server" href='#' target="_self" style="text-decoration: none; color: Silver">Loading......</a>
                </td>
            </tr>
        </table>

        <script type="text/javascript">
            var pURL = document.getElementById("PageURL");
            pURL.click();
        </script>
    </form>
</body>
</html>
