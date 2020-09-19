<%@ Page Language="vb" AutoEventWireup="false" Inherits="LoadingAppsInfo"
    CodeFile="LoadingAppsInfo.aspx.vb" %>
     
<html>
<head id="IEPHead">
    <title>School Learning Improvement Plan Loading </title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE"/>
    <meta content="JavaScript" name="vs_defaultClientScript"/>
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
</head>
<body  >
    <form id="Form1" method="post" runat="server">
        <table id="Table1"  border="0"  >
         
            <tr  style="height:100%"  >
                <td valign="middle" align="center" width="100%"   style="font-size: small  ;      font-family: Arial;">
                    <img src="./images/please_wait.gif"  alt = ""/>
                    
                    <a id="PageURL" runat="server" href='#'>Loading ......</a>
                </td>
            </tr>
        </table>
    
    </form>
</body>
</html>                                                     
<script src="Scripts/jQuery/jquery-1.11.2.min.js"  type="text/javascript"></script> 
<script type="text/javascript">
    $(document).ready(function () {
        var myHref = $("#PageURL").attr("href");
        window.location.href = myHref;
    })
 </script>