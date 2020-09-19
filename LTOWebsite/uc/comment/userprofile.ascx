<%@ Control Language="vb" AutoEventWireup="false" Inherits=" UserProfile" CodeFile="UserProfile.ascx.vb" %>
<%--<%@ Register Assembly="TimeUserCtrl" Namespace="TimeUserCtrl" TagPrefix="cc1" %>--%>

<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0"
	style="FONT-SIZE: x-small; COLOR: blue; FONT-FAMILY: Arial">
	<TR>
		<TD width="25%" valign="middle" noWrap align="left">
			<asp:label id="lblUserName" runat="server" Font-Names="Arial" Font-Size="X-Small" Width="100%"
				ForeColor="Blue">Label</asp:label>
		</TD>
		<TD width="2%" noWrap align="left">
		</TD>
		<td width="40%" valign="middle" noWrap align="left">
			<%--<cc1:TimeOutClock ID="TimeOutClock1" runat="server" AppName="SES2" CountDownLines="1"
                            Text="Please save your work in <CountDown> minutes"   ForeColor="Blue"
                            TimeOut_Minutes="30" TimeOut_Seconds="0" Font-Bold="False" Font-Size="X-Small" ShowWarning10="True" ShowWarning15="True" Font-Names="Arial" />--%>
		</td>
		<TD width="25%" noWrap align="right">
			<asp:label id="lblDate" runat="server" Font-Names="Arial" Font-Size="X-Small" ForeColor="Blue">date</asp:label>
		</TD>
	</TR>
	<TR>
		<TD vAlign="top" noWrap align="left">
			<asp:Label id="LabelPosition" Width="100%" runat="server" Visible="False">Label</asp:Label></TD>
		<TD noWrap align="left" ></TD>
		<TD vAlign="middle" noWrap align="left" ></TD>
		<TD noWrap align="right" ></TD>
	</TR>
</TABLE>
