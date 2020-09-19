<%@ Page Language="vb" AutoEventWireup="false" Inherits="Loading"
    CodeFile="Loading.aspx.vb" %>


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
        /*.waitingArea {
            display:flex;
            align-items:center;
            justify-content:center;
        }
        .waitingImage {
            width:200px;
            height:200px;
        }*/
    </style>
</head>
<body>
    <div class="waitingArea">
            <img src="images/please_wait.gif" alt="Loading" />

            <a id="PageURL" runat="server" href='#' target="_self" style="text-decoration: none; color: Silver">Loading......</a>

     
    </div>
    <script type="text/javascript">
        var myHref = document.getElementById("PageURL").getAttribute("href");
        window.location.href = myHref;
    </script>

</body>
</html>

<%--<script src="Scripts/jQuery/jquery-1.11.2.min.js"  type="text/javascript"></script> 
<script type="text/javascript">
    $(document).ready(function () {
        var myHref = $("#PageURL").attr("href");
        window.location.href = myHref;
    })
 </script>--%>