<%@ Page Language="vb" AutoEventWireup="false" Inherits="Default_Role"
    CodeFile="Default_Role.aspx.vb" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>default Parameter</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <meta http-equiv="Pragma" content="no-cache"/>

   <%-- <script src="./myScript/PopUpWindows.js" type="text/javascript">  </script>--%>
    <script src="Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function CallParentPostBack() {

            $(document).ready(function () {

                window.parent.document.location.reload();

                //try {
                //    parent.document.Script.callPostBack();
                //}
                //catch (e) {
                //    try {
                //        window.opener.callPostBack();
                //    }
                //    catch (e) {
                //        try {
                //            parent.callPostBack();
                //      }
                //        catch (e) { 
                //         window.alert("Your Browser does not support iFrame Call !")
                //       }

                //    }

                //}


            });
        }
 



        function CallParentPostBack2() {
            try {
               parent.document.Script.callPostBack();
             //   parent.document.callPostBack();
            }
            catch (e) { }  
            
        }
    </script>
    <link href="Styles/Tables.css" rel="stylesheet" type="text/css" />
   
</head>
<body  >
    <form id="Form1" method="post" runat="server">
    <table id="Table3" style="height:600px; width: 100%" cellspacing="0" cellpadding="0"
        border="0" class="TableFont1B">
        <tr height="100%">
            <td valign="middle" nowrap align="center">
                <table id="Table8" style="width: 450px; height: 200px" bordercolor="#6699ff" cellspacing="0"
                    cellpadding="0" align="center" border="0">
                    <tr>
                        <td align="center">
                            <asp:Panel ID="Panel1" runat="server" Width="350px" Height="200px" GroupingText=" Login As">
                                <table id="LoginAs" runat="server" cellspacing="0" cellpadding="0" border="0" style="font-size: small;
                                    font-family: Arial">
                                    <tr><td></td><td></td></tr>
                                    <tr>
                                        
                                        <td  >
                                            <asp:RadioButtonList ID="rblRole" runat="server" AutoPostBack="true">
                                                <asp:ListItem>Roster</asp:ListItem>
                                                <asp:ListItem>LTOTeacher</asp:ListItem>
                                                <asp:ListItem>Principal</asp:ListItem>
                                                <asp:ListItem>HRStaff</asp:ListItem>
                                                <asp:ListItem>HRStaff4</asp:ListItem>
                                                <asp:ListItem>Admin</asp:ListItem>
                                                <asp:ListItem>Superintendent</asp:ListItem>
                                                <asp:ListItem>New</asp:ListItem>                                               
                                                <asp:ListItem>Other</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="UserRoleID" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
