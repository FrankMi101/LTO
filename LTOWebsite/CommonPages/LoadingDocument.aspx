<%@ Page Language="vb" AutoEventWireup="false" Inherits=" LoadingDocument"
    CodeFile="LoadingDocument.aspx.vb" %>

 <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head id="IEPHead">
    <title>School Learning Improvement Plan</title>
   
    
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE"/>
    <meta content="JavaScript" name="vs_defaultClientScript"/>
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
    <meta http-equiv="Pragma" content="No-cache"/>
    <base target="_self"></base>
    

 <%-- <script   type="text/javascript">
   function openPDF()
   { var pPDF  = document.getElementById("printPDF");
     pPDF.click();
   }
  </script>
--%>
     
</head>
<body bottommargin="1" leftmargin="1" rightmargin="1" topmargin="1"  >
    <form id="Form1" method="post" runat="server">
        <table id="Table1" height="100%" cellspacing="0" cellpadding="0" width="100%" align="left"
            border="0" background="../images/message_body_m.bmp" style="font-size:  medium ; font-family: Arial;">
            <tr height="10">
                <td valign="middle" align ="center" width="100%" style="height: 10px">    
                       <img height="35px" width="35px" src="../images/please_wait.gif" /> 
                        <a id="LoadPage" runat="server" href='' target="_self" >Loading ......</a> <br />
                    <%--<a id="printPDF" runat="server" href=''>Page Loading, Please Wait ......</a>--%> 

                </td>
            </tr>
            
        </table>
         <script   type="text/javascript">
                   var LoadingPage  = document.getElementById("LoadPage");
                  LoadingPage.click();
        </script>
    </form>
</body>
</html>
