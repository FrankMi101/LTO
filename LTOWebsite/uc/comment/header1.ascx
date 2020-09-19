<%@ Control Language="vb" AutoEventWireup="false" Inherits="header1" CodeFile="header1.ascx.vb" %>
<style type="text/css">
    A:link {
        text-decoration: none;
        color: purple;
    }

    A:visited {
        text-decoration: none;
        color: #333399;
    }

    A:active {
        text-decoration: none;
        color: #333399;
    }

    A:hover {
        text-decoration: underline;
        color: purple;
    }

    .LinkCell {
        display: inline-block;
        width: 450px;
        height: 18px;
        text-align: right;
        vertical-align: top;
        background-image: url(images/BlueExplorer.gif);
        text-wrap: avoid;
        padding-top: 4px;
        margin:0px;
        margin-left: -5px;
    }

    ul, li {
        margin-left: 2px;
        padding-left: 2px;
 
     }

    a:link, a:visited {
        text-decoration: none;
    }

    a:hover {
        text-decoration: underline;
    }

    li a {
        text-decoration: none;
        color: Blue;
        font-family: Arial, helvetica, Verdana, Sans-Serif;
    }

    ul {
        list-style-type: none;
        display: inline;
    }

    li {
        display: inline;
        position: relative;
        padding: 2px;
    }

    #navlistLink li {
        display: inline;
        list-style-type: none;
        padding-right: 10px;
    }

    #navlistLink {
        width: 100%;
    }

    ul li:hover {
        border: 1px solid blue;
        background-image: url(images/OrangeExplorer.gif);
    }

    .table0 {
        width: 100%;
        text-align: left;
        margin: 0px 0px 0px 0px;
    }

    .NormalTitle {
        height: 20px;
        text-align: right;
        color: #cc0033;
        font-size: large;
    }

    .PTitle {
        height: 20px;
        text-align: right;
        color: #cc0033;
        font-size: medium;
    }
</style>
<table class="table0" border="0">
    <tr style="height: 80px;">
        <td style="width: 145px; vertical-align: top; text-align: left">
            <img id="Image3" src="images/tcdsblogo.gif" alt="TCDSB Logo" border="0" style="width: 160px; height: 75px" />
        </td>
        <td style="width: 99%; vertical-align: top">
            <table class="table0" style="margin:0px;">
                <tr>
                    <td style="  vertical-align: middle; text-align: center">
                        <asp:Label ID="LabelTrain" runat="server" Visible="False"
                            Font-Size="Large" ForeColor="#00C000"> Training</asp:Label>
                        <asp:HiddenField ID="hfLoginRole" runat="server" />
                    </td>
                    <td style="width: 45%; text-align: right;vertical-align:top;  margin:0px">
                        <table cellspacing="0" cellpadding="0" align="right" width="500px"
                            border="0" id="TableVersion" runat="server">
                            <tr>
                                <td style=""></td>
                                <%--<td style="text-align: right; vertical-align: top; width: 35px;">
                                    <img height="22" src="images/curve2.bmp" width="40" alt="" />
                                </td>--%>
                                <td class="LinkCell" >

                                    <ul id="navlistLink" style="width: 450px; text-align: right; vertical-align:top">
                                        <li><img height="22" src="images/curve2.bmp" width="40" alt="" /></li>
                                        <li><a href="#" id="A1" runat="server">Link Web Sites: </a></li>
                                        <li><a href="https://www.tcdsb.org" id="TopMenu1" runat="server" target="_blank">TCDSB </a>

                                        </li>
                                        <li><a href="https://intranet.tcdsb.org" id="TopMenu2" runat="server" target="_blank">Intranet </a>

                                        </li>
                                        <li><a href="http://owa.tcdsb.org" id="TopMenu3" runat="server" target="_blank">Web Mail </a>

                                        </li>
                                        <li><a href="~/logout.aspx" id="TopMenu4" runat="server" target="_self">Log out </a>

                                        </li>

                                    </ul>
                                </td>
                            </tr>
                            <tr>
                                <td id="TitilCell" runat="server" colspan="3" class="NormalTitle">
                                    <asp:Label ID="lblApplication" runat="server" Text="LTO/POP Open Positions"></asp:Label>
                                    (<a id="appLink" runat="server" href="~/Default.aspx">LTO/POP</a>)                                  
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="3">
                                    <asp:Label ID="lblTCDSB" runat="server" Text="TCDSB " ForeColor="#CC0033" ToolTip="Show Application Support"></asp:Label>
                                    <asp:Label ID="lblVersion" runat="server" SkinID="AppVersion" Text=" (Version 4.2.2 )" ToolTip="Edit Application Support"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr >
                    <td colspan="2" style="text-align: center; vertical-align: top; margin:0px; padding:0px;">
                        <asp:Label ID="Label1" Height="20px" runat="server" BackColor="Transparent" Width="95%"
                            Font-Size="X-Small" Font-Names="Arial" ForeColor="purple"> </asp:Label>
                    </td>
                </tr>
            </table>

        </td>
    </tr>

</table>

