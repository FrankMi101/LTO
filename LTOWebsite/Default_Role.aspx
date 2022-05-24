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
    <meta http-equiv="Pragma" content="no-cache" />

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
<body>
    <form id="Form1" method="post" runat="server">
        <table id="Table3" style="height: 600px; width: 100%" cellspacing="0" cellpadding="0"
            border="0" class="TableFont1B">
            <tr height="100%">
                <td valign="middle" nowrap align="center">
                    <table id="Table8" style="width: 450px; height: 200px" bordercolor="#6699ff" cellspacing="0"
                        cellpadding="0" align="center" border="0">
                        <tr>
                            <td align="center">
                                <asp:Panel ID="Panel1" runat="server" Width="350px" Height="200px" GroupingText=" Login As">
                                    <table id="LoginAs" runat="server" cellspacing="0" cellpadding="0" border="0" style="font-size: small; font-family: Arial">
                                        <tr>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>

                                            <td>
                                                <asp:RadioButtonList ID="rblRole" runat="server" AutoPostBack="true">
                                                    <asp:ListItem>Roster</asp:ListItem>
                                                   <%-- <asp:ListItem>LTOTeacher</asp:ListItem>--%>
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
        <div>
            <table border='1'>
                <tr>
                    <td>Teacher Name</td>
                    <td>Phone Number</td>
                    <td>Email</td>
                    <td>Hired Date</td>
                    <td>Applied Date</td>
                    <td>Selected</td>
                    <td>Open Date</td>
                    <td>Close Date</td>
                </tr>
                <tr>
                    <td>Quinonez, Christopher</td>
                    <td>6472250927</td>
                    <td>Christopher.Quinonez@tcdsb.org</td>
                    <td>2012/09/01</td>
                    <td>2021-08-24</td>
                    <td>Yes </td>
                    <td>2021/08/24 </td>
                    <td>2021/08/26 </td>
                </tr>
                <tr>
                    <td>Savoia, Cassandra</td>
                    <td>6479952277</td>
                    <td>Cassandra.Savoia@tcdsb.org</td>
                    <td>2017/01/09</td>
                    <td>2021-08-25</td>
                    <td>Yes </td>
                    <td>2021/08/24 </td>
                    <td>2021/08/26 </td>
                </tr>
                <tr>
                    <td>Naccarato, Amanda</td>
                    <td>6478287421</td>
                    <td>Amanda.Naccarato03@tcdsb.org</td>
                    <td>2017/02/17</td>
                    <td>2021-08-24</td>
                    <td>Yes </td>
                    <td>2021/08/24 </td>
                    <td>2021/08/26 </td>
                </tr>
                <tr>
                    <td>Leyland, Heidi</td>
                    <td>6478811990</td>
                    <td>Heidi.Leyland@tcdsb.org</td>
                    <td>2017/09/01</td>
                    <td>2021-08-24</td>
                    <td>Yes </td>
                    <td>2021/08/24 </td>
                    <td>2021/08/26 </td>
                </tr>
                <tr>
                    <td>Fucile, Marcella</td>
                    <td>647-234-4368</td>
                    <td>Marcella.Fucile@tcdsb.org</td>
                    <td>2017/09/25</td>
                    <td>2021-08-24</td>
                    <td>Yes </td>
                    <td>2021/08/24 </td>
                    <td>2021/08/26 </td>
                </tr>
                <tr>
                    <td>DiCarlo, Stephen</td>
                    <td>(416)795-8233</td>
                    <td>Stephen.DiCarlo@tcdsb.org</td>
                    <td>2018/04/09</td>
                    <td>2021-08-24</td>
                    <td>Yes </td>
                    <td>2021/08/24 </td>
                    <td>2021/08/26 </td>
                </tr>
                <tr>
                    <td>Trevisan, Lucas</td>
                    <td>647 404-0935</td>
                    <td>Lucas.Trevisan@tcdsb.org</td>
                    <td>2018/04/09</td>
                    <td>2021-08-26</td>
                    <td>Yes </td>
                    <td>2021/08/24 </td>
                    <td>2021/08/26 </td>
                </tr>
                <tr>
                    <td>McGowan, Katherine</td>
                    <td>647-287-0316</td>
                    <td>Katherine.McGowan@tcdsb.org</td>
                    <td>2018/05/29</td>
                    <td>2021-08-24</td>
                    <td>Yes </td>
                    <td>2021/08/24 </td>
                    <td>2021/08/26 </td>
                </tr>
                <tr>
                    <td>Vescio, Stefania</td>
                    <td>4169027859</td>
                    <td>Stefania.Vescio@tcdsb.org</td>
                    <td>2013/06/03</td>
                    <td>2021-08-24</td>
                    <td>No </td>
                    <td>2021/08/24 </td>
                    <td>2021/08/26 </td>
                </tr>
                <tr>
                    <td>Galle, Nadia</td>
                    <td>4168052904</td>
                    <td>Nadia.Galle@tcdsb.org</td>
                    <td>2017/02/27</td>
                    <td>2021-08-24</td>
                    <td>No </td>
                    <td>2021/08/24 </td>
                    <td>2021/08/26 </td>
                </tr>
                <tr>
                    <td>Kelly, Michael</td>
                    <td>647-968-6873</td>
                    <td>Michael.Kelly@tcdsb.org</td>
                    <td>2017/09/01</td>
                    <td>2021-08-24</td>
                    <td>No </td>
                    <td>2021/08/24 </td>
                    <td>2021/08/26 </td>
                </tr>
                <tr>
                    <td>Norbert, Mitchelle</td>
                    <td>6479649729</td>
                    <td>Mitchelle.Norbert@tcdsb.org</td>
                    <td>2018/09/01</td>
                    <td>2021-08-24</td>
                    <td>No </td>
                    <td>2021/08/24 </td>
                    <td>2021/08/26 </td>
                </tr>
                <tr>
                    <td>Grittani, Andrea</td>
                    <td>4169480073</td>
                    <td>Andrea.Grittani@tcdsb.org</td>
                    <td>2018/09/17</td>
                    <td>2021-08-26</td>
                    <td>No </td>
                    <td>2021/08/24 </td>
                    <td>2021/08/26 </td>
                </tr>
                <tr>
                    <td>Lentini, Vanessa</td>
                    <td>647-454-4101</td>
                    <td>Vanessa.Lentini@tcdsb.org</td>
                    <td>2018/10/25</td>
                    <td>2021-08-25</td>
                    <td>No </td>
                    <td>2021/08/24 </td>
                    <td>2021/08/26 </td>
                </tr>
                <tr>
                    <td>Caranci, Stephanie</td>
                    <td>14167060054</td>
                    <td>Stephanie.Caranci@tcdsb.org</td>
                    <td>2018/11/07</td>
                    <td>2021-08-25</td>
                    <td>No </td>
                    <td>2021/08/24 </td>
                    <td>2021/08/26 </td>
                </tr>
                <tr>
                    <td>Ottner, Kirsten</td>
                    <td>6472960379</td>
                    <td>Kirsten.Ottner@tcdsb.org</td>
                    <td>2018/12/14</td>
                    <td>2021-08-24</td>
                    <td>No </td>
                    <td>2021/08/24 </td>
                    <td>2021/08/26 </td>
                </tr>
                <tr>
                    <td>D`Egidio, Jessica</td>
                    <td>6476293659</td>
                    <td>jessica.degidio@tcdsb.org</td>
                    <td>2019/01/21</td>
                    <td>2021-08-25</td>
                    <td>No </td>
                    <td>2021/08/24 </td>
                    <td>2021/08/26 </td>
                </tr>
                <tr>
                    <td>Cheng, Han-Yu</td>
                    <td>4168892893</td>
                    <td>Holly.Cheng@tcdsb.org</td>
                    <td>2019/10/28</td>
                    <td>2021-08-24</td>
                    <td>No </td>
                    <td>2021/08/24 </td>
                    <td>2021/08/26 </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
