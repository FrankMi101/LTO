<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Logon.aspx.vb" Inherits="Logon" %>

<%@ Register Src="uc/comment/headerLogo.ascx" TagName="header1" TagPrefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>log on Page</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-Store,no-Cache" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />

    <script type="text/jscript"  >
        function getResolution() {
            try {
                var screenWidth = screen.width;
                var screenHeight = screen.height;
                var elem = document.forms[0].elements['txtResolution'];
                elem.value = screenWidth + "x" + screenHeight;

            }
            catch (err) {

            }
        }
    </script>
    <%-- <script type="text/javascript">
         var appInsights = window.appInsights || function (config) {
             function r(config) { t[config] = function () { var i = arguments; t.queue.push(function () { t[config].apply(t, i) }) } } var t = { config: config }, u = document, e = window, o = "script", s = u.createElement(o), i, f; for (s.src = config.url || "//az416426.vo.msecnd.net/scripts/a/ai.0.js", u.getElementsByTagName(o)[0].parentNode.appendChild(s), t.cookie = u.cookie, t.queue = [], i = ["Event", "Exception", "Metric", "PageView", "Trace"]; i.length;) r("track" + i.pop()); return r("setAuthenticatedUserContext"), r("clearAuthenticatedUserContext"), config.disableExceptionTracking || (i = "onerror", r("_" + i), f = e[i], e[i] = function (config, r, u, e, o) { var s = f && f(config, r, u, e, o); return s !== !0 && t["_" + i](config, r, u, e, o), s }), t
         }({
             instrumentationKey: "e29264b3-c405-47ea-9099-9b2311cee1ef"
         });

         window.appInsights = appInsights;
         appInsights.trackPageView();
    </script>--%>

    <style type="text/css">
        body
        {
            margin: 0;
            padding: 0;
            font-family: verdana, arial, sans-serif;
        }
        form
        {
            height: 100%;
            margin: 0;
            padding: 0;
        }
        table
        {
            height: 100%;
        }
    </style>
    <style type="text/css">
        .style1
        {
            width: 186px;
            height: 152px;
        }
        .TextStrengthWeak
        {
            background-color: red;
            color: White;
            font-weight: bold;
            padding: 2px 3px 2px 3px;
        }
        .TextStrengthMedium
        {
            background-color: Yellow;
            font-weight: bold;
            padding: 2px 3px 2px 3px;
        }
        .TextStrengthStrong
        {
            background-color: green;
            color: White;
            font-weight: bold;
            padding: 2px 3px 2px 3px;
        }
    </style>
</head>
<body  onload="javascript:getResolution();">
    <form id="Form1" method="post" runat="server">
   
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table id="Table7" cellspacing="0" cellpadding="0" align="center" width="100%" border="0"
        runat="server">
         <tr>
                <td >
                    <uc1:header1 ID="header11" runat="server" />
                </td>
            </tr>
       
        <tr style="height: 25px;">
            <td valign="middle" width="100%" align="center" style="background-image: url(images/BlueExplorer36.GIF)">
                <asp:Label ID="LabelTraining" runat="server" Font-Names="Arial" Font-Size="Medium"
                    ForeColor="Brown" Text="Training Version" Visible="False" Width="150px"></asp:Label>
                    <asp:Label ID="LabelHost" runat="server" ForeColor= "White"  >Host:</asp:Label>

            </td>
        </tr>
       
        <tr  >
            <td valign="middle" align="center" >
                <table id="Table6" cellspacing="0" cellpadding="0" width="100%" border="0" height="600">
                   <%-- <tr><td>
                        <asp:TextBox ID="TextBox1" runat="server" Width="100%"> </asp:TextBox>
                        </td></tr>--%>
                    <tr>
                        <td align="center">
                            <table id="Table1" style="width: 400px; height: 350px" cellspacing="1" cellpadding="1"
                                align="center" border="0">
                                <tr>
                                    <td valign="middle" align="right" valign="top" style="width: 50%; ">
                                   <img id="Image9" src="images/tcdsblogo.png" alt="TCDSB Logo" border="0" style="width: 180px; height: 180px" />
     
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                    </td>
                                    <td valign="middle" align="left" style="width: 50%">
                                        <table id="Table2" cellspacing="1" cellpadding="1" align="left" border="0" style="width: 199px;
                                            height: 165px; font-size: x-small">
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server">Domain:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDomain" runat="server" Width="124px">CEC</asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server">Username:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUsername" runat="server" Width="124px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server">Password:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPassword" runat="server" Width="124px" TextMode="Password"  AutoComplete="Disabled"  AutoCompleteType="Disabled" ></asp:TextBox>
                                                
                                                    <ajaxtoolkit:PasswordStrength ID="PasswordStrength3" runat="server" TargetControlID="txtPassword"
                                                        DisplayPosition="BelowLeft" StrengthIndicatorType="Text" PrefixText="How secure is your password? "
                                                        PreferredPasswordLength="12" TextStrengthDescriptions="Weak;Medium;Strong" TextStrengthDescriptionStyles="TextStrengthWeak; TextStrengthMedium; TextStrengthStrong"
                                                        MinimumNumericCharacters="2" MinimumSymbolCharacters="2" RequiresUpperAndLowerCaseCharacters="true"
                                                        HelpHandleCssClass="TextIndicator_txtPassword_Handle" HelpHandlePosition="BelowRight" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2" style="height: 26px">
                                                    <asp:CheckBox ID="chkPersist" runat="server" Text="Persist Cookie" Visible="False">
                                                    </asp:CheckBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2">
                                                    <p align="center">
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnLogin" runat="server" Text="Login" Width="101px" BackColor="#E0E0E0" >
                                                        </asp:Button></p>
                                                    <input type="hidden" name='txtResolution' id="txtResolution" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2">
                                                    <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="XX-Small" Text="The initial login to the application may take up to 30 seconds."
                                                        Width="300"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 8px">
                            <asp:Label ID="errorlabel" runat="server" Font-Bold="true" Font-Size="Small"  ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td  style="color: #C00000; font-size: x-small;" align="center" >
                            <br />
                            <p style="text-align:center; width:60%">
  Access to this network and the information on it are lawfully available only for
                            approved purposes by employees of Toronto Catholic District School Board and other
                            users authorized by TCDSB. If you are not an employee of TCDSB or an authorized
                            user, do not attempt to log on. Other than where prohibited by law and subject to
                            legal requirements, TCDSB reserves the right to review any information in any form
                            on this network at any time.
                            </p>
                          
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <br />
                <br />
                <br />
                <span style="font-size: 9pt; font-family: Arial">Best viewed in 1024x768 screen resolution.<br />
                </span><font style="font-weight: normal; font-size: 9pt; color: blue; font-family: Arial">
                    Copyright 2009-2013 Toronto Catholic District School Board, All Rights Reserved.</font>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
