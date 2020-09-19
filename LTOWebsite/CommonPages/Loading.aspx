<%@ Page Language="vb" AutoEventWireup="false" Inherits=" Loading"
    CodeFile="Loading.aspx.vb" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head id="IEPHead">
    <title>Teacher Performance Appraisal - Loading...</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE"/>
    <meta content="JavaScript" name="vs_defaultClientScript"/>
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
</head>
<body bottommargin="1" leftmargin="1" rightmargin="1" topmargin="1">
    <form id="Form1" method="post" runat="server">
        <table id="Table1" height="100%" cellspacing="0" cellpadding="0" width="100%" align="left"
            border="0" background="../images/message_body_m.bmp" >
           <%-- <tr height="20px">
                <td height="20px" width="100%"  background="./images/BlueExplorer.gif">
               
                </td>
            </tr>--%>
            <tr height="100%">
                <td valign="middle" align="center" width="100%"   style="font-size: small  ;
            font-family: Arial;">
                    <img src="../images/please_wait.gif" />
                    
                    <a id="PageURL" runat="server" href='' target="_self">Loading ......</a>
                </td>
            </tr>
        </table>

      <%--  <script type="text/javascript">
                   var pURL  = document.getElementById("PageURL");
                  pURL.click();
                  window.close();    
        </script>--%>

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