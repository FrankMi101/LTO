<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Javascript_Event_Example.aspx.vb" Inherits="PDFLoading_Javascript_Event_Example" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" language="javascript">
        function handleEvent(oEvent) {
            var oText = document.getElementById("EnentName");
            oText.value += "\n" + oe.type;

        }
        function mouseDown(nsEvent) {
            var theEvent = ns ? ns : windows.event;
            var locstring = "X= " + theEvent.screenX + " Y = " + theEvent.screenY;
            alert(locString);
        }
        document.onmousedown = mouseDown;

        function startTime() {
            var today = new Date();
            var h = today.getHours();
            var m = today.getMinutes();
            var s = today.getSeconds();
            m = checkTime(m);
            s = checkTime(s);
            document.getElementById("txt").innerHTML = h + ":" + m + ":" + s;
            t = setTimeout('startTime()', 500);
        }
        function checkTime(i) {
            if (i < 10)
            { i = "0" + i; }
            return i;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
         <div id ="EventHandle1" style="width:200px; height:200px; background-color:Blue; color:White; font-size:x-large; font-family:Arial; vertical-align:bottom; text-align:center;   "
             onmouseover = "handleEvent(event)"
             onmouseout = "handleEvent(event)"
             onmousedown="handleEvent(event)"
             onmouseup="handleEvent(event)"
             onclick ="handleEvent(event)"
             ondblclick="handleEvent(event)"
         >
            my Event Area
          </div>

          <p>  <textarea id ="EnentName" rows="20" cols="30"> 
          
          </textarea> 
          </p>
    </div>
    </form>
</body>
</html>
