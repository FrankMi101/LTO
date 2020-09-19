<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ApplicantComments.aspx.vb" Inherits="ApplicantComments" EnableTheming="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Select for interview   </title>
    <base target="_self" />
    <meta http-equiv="Pragma" content="No-cache" />
    <style type="text/css">
        body {
            height: 100%;
            width: 100%;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div style="background-image: url(../images/message_body_m.bmp)">

            <div id="TextComments" runat="server" style="overflow: auto; display: block; width: 100%; height: 450px; background-color: transparent; border-style: inset; border-width: thin">
            </div>

        </div>
    </form>
</body>
</html>
<script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
