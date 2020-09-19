<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LoadingP.aspx.vb" Inherits="LoadingP" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Loading Page</title>
    <style>
        div {
            height: 100%;
            width: 100%;
            text-align: center;
            margin: 0 auto;
            padding-top: 20%;
        }
    </style>
</head>
<body>
    <div>
        <img src="../images/please_wait.gif" alt="Loading" />

        <a id="PageURL" runat="server" href='#' target="_self" style="text-decoration: none; color: Silver">Loading......</a>

    </div>

    <script type="text/javascript">
        var myHref = document.getElementById("PageURL").getAttribute("href");
        window.location.href = myHref;
    </script>

</body>
</html>
