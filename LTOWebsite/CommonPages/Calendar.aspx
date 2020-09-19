<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Calendar.aspx.vb" Inherits="Calendar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calendar</title>
<base target="_self"/>
    <meta http-equiv="Pragma" content="No-cache" />
    <script src="http://code.jquery.com/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#Button2").click(function (e) {
                window.returnValue = $("#Label1").text();
                window.self.close();
            });

        })
  
</script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
      <asp:calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" 
          BorderColor="#FFCC66" 
          Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="173px" 
            Width="240px" BorderWidth="1px" DayNameFormat="Shortest" 
            ShowGridLines="True" >
          <DayHeaderStyle Font-Bold="True" Height="1px" BackColor="#FFCC66" />
          <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC"   />
          <OtherMonthDayStyle ForeColor="#CC9966" />
          <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
          <SelectorStyle BackColor="#FFCC66" />
          <TitleStyle BackColor="#FFCC66" Font-Bold="True" Font-Size="9pt" 
              ForeColor="#FFFFCC" />
          <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
      </asp:calendar> 
       
       
          <input runat="server"  id="Button2" type="button" value="OK" style="background-color:#FFCC66; height:22px; width:40px; color:Blue;"  />
      <asp:Label ID="Label1" runat="server" Width="195px" TabIndex="-2" 
          BackColor="#FFCC66" ForeColor="Blue"></asp:Label>
    </div>
    </form>
</body>
</html>
