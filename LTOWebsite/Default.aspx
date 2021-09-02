<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" EnableTheming="true" %>

<%@ Register Src="uc/comment/appheader.ascx" TagName="header1" TagPrefix="uc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title id="PageTitle" runat="server">LTO Home</title>
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-Store,no-Cache" />

    <script src="Scripts/GetMousePosition.js"></script>

    <link href="Styles/BubbleHelp.css" rel="stylesheet" type="text/css" />
    <link href="Styles/DefaultPage.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #li_Menu0_c, #li_Menu4_c {
            display: inline;
            color: purple;
            font-weight: 500;
        }
        /*#navlist {
        display: inline-block ;
        }*/
        #PositionDetailFrame {
            width:100%; 
        }
       
        .AppHeader {
            width:100%;
            height:75px;
            margin:0px;
        }
       
        #Menu0, #Menu1, #Menu2, #Menu3, #Menu4, #Menu5, #Menu6, #li_Menu0_c, #li_Menu4_c {
        font-size:14px;
        }
      
    </style>

    <%--  <script type="text/javascript">
      var appInsights = window.appInsights || function (config) {
          function r(config) { t[config] = function () { var i = arguments; t.queue.push(function () { t[config].apply(t, i) }) } } var t = { config: config }, u = document, e = window, o = "script", s = u.createElement(o), i, f; for (s.src = config.url || "//az416426.vo.msecnd.net/scripts/a/ai.0.js", u.getElementsByTagName(o)[0].parentNode.appendChild(s), t.cookie = u.cookie, t.queue = [], i = ["Event", "Exception", "Metric", "PageView", "Trace"]; i.length;) r("track" + i.pop()); return r("setAuthenticatedUserContext"), r("clearAuthenticatedUserContext"), config.disableExceptionTracking || (i = "onerror", r("_" + i), f = e[i], e[i] = function (config, r, u, e, o) { var s = f && f(config, r, u, e, o); return s !== !0 && t["_" + i](config, r, u, e, o), s }), t
      }({
          instrumentationKey: "e29264b3-c405-47ea-9099-9b2311cee1ef"
      });

      window.appInsights = appInsights;
      appInsights.trackPageView();
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <header class ="AppHeader">
                <uc1:header1 ID="header1" runat="server" />

        </header>

        <nav style="height: 25px; width: 100%; text-wrap: avoid;">
            <div id="topnav" style="width: 100%; height: 25px; background-image: url(images/BlueExplorer.GIF); border: 0 none; padding: 1px 0px 1px 0px;">
                <ul id="navlist">
                    <li id="li_Menu0" runat="server"><a href="#" id="Menu0" runat="server" target="mainTop">Request Post </a>
                        <div id="li_Menu0_c" runat="server"></div>
                    </li>
                    <li id="li_Menu1" runat="server"><a href="#" id="Menu1" runat="server" target="mainTop">New Position </a>

                    </li>
                    <li id="li_Menu2" runat="server"><a href="#" id="Menu2" runat="server" target="mainTop">Select Interview </a>

                    </li>
                    <li id="li_Menu3" runat="server"><a href="#" id="Menu3" runat="server" target="mainTop">Principal Interview </a>

                    </li>
                    <li id="li_Menu4" runat="server"><a href="#" id="Menu4" runat="server" target="mainTop">Confirm hire  </a>
                        <div id="li_Menu4_c" runat="server"></div>
                    </li>
                    <li id="li_Menu5" runat="server"><a href="#" id="Menu5" runat="server" target="mainTop">Applicant Verification </a>

                    </li>
                    <li id="li_Menu6" runat="server"><a href="#" id="Menu6" runat="server" target="mainTop">Posting Summary </a>

                    </li>

                </ul>

            </div>
        </nav>
        <iframe id="mainTop" runat="server" name="mainTop" class="iFrameContent" seamless="seamless"  
             src="Default_Home.aspx"></iframe>

         <asp:HiddenField ID="HiddenFieldBrowserVersion" runat="server" />



        <div id="PopUpDIV" class="bubble hide"></div>
        <div id="PositionDetailDIV" class="bubble hide" style="width: 100%;">
            <div style="height: 22px; margin-top: -2px; background-color: deepskyblue; width:100%;">
                  
                  
                <table style="vertical-align: top;">
                    <tr style="">
                        <td style="width: 100%; text-align: center">
                          <div id="popPagetitle" runat="server" style="font-size: medium">Position Detail Edit Page  </div>
                   
                        </td>
                        <td>
                               <asp:HiddenField ID="hdChildFormAction" runat="server" Value="NoAction" />
                            <asp:HiddenField ID="hfInvokePageFrom" runat="server" Value="" />
                            <asp:HiddenField ID="hfUserRole" runat="server" Value="" />
                             <asp:HiddenField ID="hfCPNum" runat="server" Value="" />
                              <asp:HiddenField ID="hfUserID" runat="server" Value="" />
                        </td>
                        <td style=" text-align: right">
                            <a id="CloseMeLink" runat="server" href="#" style=" text-align:right;">
                    <img style="height: 20px; width: 20px;" src="images/Close1.bmp" alt="" title="Close Me" />
                </a></td>
                    </tr>
                </table>

            </div>
            <div id="iFrameDIV" style="height: 93%; width: 100%; ">
                <iframe id="PositionDetailFrame" runat="server" name="PositionDetailiFrame" scrolling="auto" seamless="seamless"   
                    src=""></iframe>
            </div>
            <div id="BottomClose" style="height: 22px; background-color: deepskyblue; text-align: right">
                <a id="CloseMeLink2" runat="server" href="#">
                    <img style="height: 20px; width: 20px;" src="images/Close1.bmp" alt="" title="Close Me" />
                </a>
            </div>
        </div>
    </form>
</body>
</html>

<script type="text/jscript" src="Scripts/jQuery/jquery-1.11.2.min.js"></script>
<script src="Scripts/PopUpDIVLeft.js" type="text/javascript"></script>


<script type="text/javascript">
    var pMenu;
    $(document).ready(function () {
        try {

            pMenu = "li_Menu1";
            if ($("#hfUserRole").val() == "Principal") {
                pMenu = "li_Menu2";
            }

            $("li").click(function (event) {
                var menuID = event.target.id;
                if (menuID.length == 5) {
                    menuID = "li_" + menuID;
                }
                setupCurrentMenu(menuID)


            });

            $("#CloseMeLink").click(function (e) {
                $("#PopUpDIV").fadeToggle("fast");
                $("#PositionDetailDIV").fadeToggle("fast");
                RefershInvokePage();
            });

            $("#CloseMeLink2").click(function (e) {
                $("#PopUpDIV").fadeToggle("fast");
                $("#PositionDetailDIV").fadeToggle("fast");
                //  parent.ReLoadPage("Yes");
                RefershInvokePage();
            });


        }
        catch (e)
        { }

    })
    function RefershInvokePage() {
        var ChildPageAction = $("#hdChildFormAction").val();
       
        if (ChildPageAction == "NoAction") {
            // window.alert(ChildPageAction);
        }
        else {
           // alert ($("#hfInvokePageFrom").val())
            var refreshPage = $("#hfInvokePageFrom").val();
            if (refreshPage == "LTOHRStaffs/ApplicantList2.aspx") {
               window.frames.frames.ApplicantList.location.href = refreshPage;
               //   window.frames.mainTop.location.reload();

                //  window.parent.frames["mainTop"].frames["ApplicantList"].document.location.reload();

            }
            else {
                //  window.frames.mainTop.location.href = refreshPage;
                window.frames.mainTop.location.reload(); //  .href = refreshPage;
            }
        }
    }
    function setupCurrentMenu(cMenu) {
        try {
            $("#" + pMenu).removeClass("menu1SelectedItem").addClass("menu1");
        }
        catch (e)
        { }
        try {
            $("#" + cMenu).removeClass("menu1").addClass("menu1SelectedItem");
        }
        catch (e)
        { }
        //  window.alert("P=" + pMenu + "; C=" + cMenu);
        pMenu = cMenu;
    }
    function DeCueerntMenu() {
        try {
          //  alert("call p");
            $("#" + pMenu).removeClass("menu1SelectedItem").addClass("menu1");
           pMenu = "";
       }
        catch (e)
        { }

    }
    function getBrowser() {
        if (navigator.userAgent.indexOf("MSIE") > 0) {
            return "IE";
        }
        else { return "Other"; }
    }

    function getIEVersion()
        // Returns the version of Internet Explorer or a -1 for other browsers.
    {
        var rv = -1;
        if (navigator.appName == 'Microsoft Internet Explorer') {
            var ua = navigator.userAgent;
            var re = new RegExp("MSIE ([0-9]{1,}[\.0-9]{0,})");
            if (re.exec(ua) != null)
                rv = parseFloat(RegExp.$1);
        }
        return rv;
    }

    function getIEVersion2() {

        return $("#HiddenFieldBrowserVersion").val();

    }


    function callPostBack() {
        try {
            location.reload("Default.aspx");
        }
        catch (e) { }
    }

    function openSupportInformation(vLoading, vH) {

        $("#IframeSupport").attr("src", vLoading);
        $("#SupportInfoDIV").css({
            top: mouse_y + 10,
            left: mouse_x - 420,
            height: vH,
            width: 400
        });
        $("#SupportInfoDIV").fadeToggle("fast");
    }

</script>

