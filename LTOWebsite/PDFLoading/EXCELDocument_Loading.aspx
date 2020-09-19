<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EXCELDocument_Loading.aspx.vb" Inherits="EXCELDocument_Loading" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body
       {height:100%;
        width: 100%;
           
           }
      table
      { height: 100%;
        width: 100%;
        vertical-align: middle;
        text-align:center;
          }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table id="Table1" style="height:100%; width:100%"  
            border="0"   >
         
            <tr  style=" height:100%; ">
                <td style=" height:100%; width:100%; font-size: medium ;
            font-family: Arial;">
                    <img src="../images/please_wait.gif" alt="Loading" />
                    
                    <a id="PageURL" runat="server" href='#'>Loading......</a> 
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