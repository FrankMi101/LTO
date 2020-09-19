<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LoadingV.aspx.vb" Inherits="LoadingV" %>


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
                    <img src="../images/please_wait.gif" alt="Loading"  />

                    <a id="PageURL" runat="server" href='#' target="_self" style="text-decoration: none; color: Silver">Loading......</a>
                </td>

                
            </tr>
        </table>
    </form>
</body>
</html>

<script src="../Scripts/jQuery/jquery-1.11.2.min.js"  type="text/javascript"></script> 
<script type="text/javascript">
    $(document).ready(function () {
        var myHref = $("#PageURL").attr("href");
        window.location.href = myHref;
    })
 </script>