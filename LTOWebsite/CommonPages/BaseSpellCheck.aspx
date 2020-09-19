<%@ Page Language="vb" AutoEventWireup="false" Inherits=" BaseSpellCheck"
    CodeFile="BaseSpellCheck.aspx.vb" %>

<%@ Register Assembly="Keyoti.RapidSpellWeb.ASP.NETv2" Namespace="Keyoti.RapidSpell"
    TagPrefix="RapidSpellWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head runat="server">
    <title>Spelling Check Page</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <base target="_self" />
    <meta http-equiv="Pragma" content="No-cache" />
    <script type="text/javascript">
        function ReturnMyText(myText) {


            window.returnValue = myText;
            window.self.close();

        }
        function Close() {
            window.close();
        }

        function getSpellText() {

            var strFormName = document.getElementById("hfFormID").value;
            var strCtrlName = document.getElementById("hfControlID").value;
            var paranetTextbox = window.dialogArguments.document.getElementById(strCtrlName);
            var myText = document.getElementById("txtMyText");
            myText.value = paranetTextbox.value;
        }
    </script>
    <style type="text/css">
        body
        {
            margin: 1 1 1 1;
        }
    </style>
</head>
<body onload="javascript:getSpellText();">
    <form id="Form19" method="post" runat="server">
    <table id="Table5"  class="TableFont1" 
        cellspacing="0" cellpadding="0" align="left" border="0">
        <tr height="95">
           <td class="FrameTopLeft">
            </td>
            <td class="FrameTopMiddle">
                <table id="Table7" cellspacing="0" cellpadding="0" width="100%" align="left" border="0">
                    <tr height="24">
                        <td valign="middle" nowrap align="left" width="100%">
                            <em><strong>Spelling Check Page</strong></em>
                            
                             <%--<a id="ImgLink" href="http://stream.tcdsb.org/academicit/tpa/TPAalp.wmv"
                                target="_blank" runat="server">
                                <img id="Img2" title="View video instructions for this screen" height="18" alt=""
                                    src="../images/TVideo.bmp" width="58" border="0" name="ImgTeacherM" runat="server"></a>
                            <asp:Label ID="labelHelpFile" runat="server" ForeColor="Blue" Font-Names="Arial"
                                Font-Size="X-Small" Visible="False">HF</asp:Label>--%>
                        </td>
                    </tr>
                    <tr style="height:38px">
                        <td valign="top" nowrap align="left" width="100%">
                            <table id="Table1" cellspacing="0" cellpadding="0" width="100%" align="right" border="0">
                                <tr>
                                    <td nowrap align="left" width="50%">
                                        <font face="Arial Black" color="#cbdce6" size="4">Welcome To Spelling Check</font>
                                    </td>
                                    <td nowrap align="left" width="50%">
                                        <asp:HiddenField ID="hfFormID" runat="server" />
                                        <asp:HiddenField ID="hfControlID" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" nowrap align="right" width="100%">
                            <table style="height: 8px" cellspacing="0" cellpadding="0" width="100%" align="left">
                                <tr>
                                    <td style="width: 162px">
                                        <asp:Label ID="Label1" runat="server" Font-Size="Small" Font-Names="Arial" ForeColor="Black"
                                            Width="416px" BackColor="Transparent" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td style="width: 123px">
                                        <RapidSpellWeb:RapidSpellWebLauncher ID="Rapidspellweblauncher1" runat="server" ForeColor="Black"
                                            BackColor="Transparent" Width="78px" Validator="True" AutoLaunchWhenTextInvalid="True"
                                            ButtonImageMouseOut="../images/spell.bmp" PopUpWindowName="IEP Spell Check" Height="16px"
                                            ConsiderationRange="1" WindowY="150" WindowX="150" WindowWidth="420" WindowHeight="380"
                                            TextComponentName="txtMyText" RapidSpellWebPage="BaseSpellKeyoti.aspx" LicenseKey="OkEoT2IrRUBFL0xETUxINWttck1LOFlRYT8sRUZGSkY="
                                            SSLFriendly="True" IgnoreXML="True" IncludeUserDictionaryInSuggestions="True"
                                            EnableViewState="False" Modal="True">
                                            <Button BorderWidth="" BorderColor="" ForeColor="" BackColor="" Height="" ImageMouseOut="../images/spell.bmp"
                                                Width="" CssClass="" Value="Check Spelling" BorderStyle="NotSet" type="button"
                                                ID="ctl00" runat="server" TabIndex="0"></Button>
                                        </RapidSpellWeb:RapidSpellWebLauncher>
                                    </td>
                                    <td>
                                        <input id="btnCopy" title="return to Edit Box" style="width: 152px; height: 24px;
                                            background-color: gainsboro" onclick="javascript:ReturnMyText(txtMyText.value);"
                                            type="button" value="Return to Edit Box" runat="server" name="btnCopy">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
              <td class="FrameTopRight">
            </td>
        </tr>
        <tr height="100%">
            <td class="FrameBodyLeft">
            </td>
            <td class="FrameBodyMiddle" align="left" valign="top">
                <textarea id="txtMyText" style="width: 100%; height: 100%; background-color: transparent; border-left-style:none" 
                    rows="25" cols="80" runat="server" name="txtMyText"></textarea>
            </td>
            <td class="FrameBodyRight">
            </td>
        </tr>
        <tr style="height: 13px;">
            <td class="FrameBottomLeft">
            </td>
            <td class="FrameBottomMiddle">
            </td>
            <td class="FrameBottomRight">
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
