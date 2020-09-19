<%@ Page Language="vb" AutoEventWireup="false" Inherits="Default_Home"  CodeFile="Default_Home.aspx.vb" %>

<!DOCTYPE >
<html>

<head runat="server">
    <title>default Parameter</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <meta http-equiv="Pragma" content="no-cache"/>
    <link href="Styles/Tables.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="Scripts/ButtonBehaour.js" type="text/javascript"></script>
    
    <script type="text/javascript">

        function openGoalWorkingPage() {
            var myPage = "SmartGoal_00.aspx";
            window.open(myPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=1000 height=800, top=5, left=1");

        }

        function updateMenuLink(_oldLink, _newLink) {
        }
        function CallParentPostBack() {
           
            $(document).ready(function () {
                try {
                    parent.document.Script.callPostBack();
                }
                catch (e) {
                    try {
                        window.opener.callPostBack();
                    }
                    catch (e) {
                        try {
                            parent.callPostBack();
                        }
                        catch (e) {
                            window.alert("Your Browser does not support iFrame Call !")
                        }

                    }

                }


            });
        }
    </script>

    
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <table style="width: 100%; height: 100%">
        <tr style="height: 30%">
            <td>
            </td>
        </tr>
        <tr style="height: 40%">
            <td valign="middle" align="center">
                <table id="Table3" style="height: 5%; width: 5%; vertical-align: middle;" cellspacing="0"
                    cellpadding="0"    border="1" class="TableFont1B">
                    <tr>
                        <td>
                            <img src="./images/tcdsblogo.gif" class="style1" height="180">
                        </td>
                        <td>
                            <asp:Panel runat="server" Width="450px" Height="200px" GroupingText="">
                                <table id="Table2" style="width: 450px; height: 80px" cellspacing="0" cellpadding="0"
                                    align="left" border="0">
                                    <tr style="height:30px">
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 25px" nowrap="nowrap" >
                                            <font face="Arial" size="2">
                                                <asp:Label ID="Label3" runat="server" Width="72px" BackColor="Transparent">School Year</asp:Label></font>
                                        </td>
                                        <td style="width: 323px; height: 25px">
                                            <asp:DropDownList ID="ddlSchoolYear" runat="server" Height="30px" Width="120px" BackColor="Transparent"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 69px; height: 24px">
                                            <font face="Arial" size="2">School</font>
                                        </td>
                                        <td style="width: 323px; height: 24px">
                                            <table id="Table9" cellspacing="0" cellpadding="0" width="100%" align="left" border="0">
                                                <tr>
                                                    <td nowrap>
                                                        <asp:DropDownList ID="ddlSchoolCode" runat="server" Height="30px" Width="56px" Enabled="False"
                                                            AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td nowrap>
                                                        <asp:DropDownList ID="ddlSchools" runat="server" Height="30px" Width="300px" Enabled="False"
                                                            AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                    <tr style="height: 30px">
                                        <td align="center" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="width: 300px" colspan="2">
                                            <asp:Button ID="SaveB" runat="server" Text="Save " Width="100px" CssClass="ButtonNormal"
                                                Height="22px" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height: 30%">
            <td>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
