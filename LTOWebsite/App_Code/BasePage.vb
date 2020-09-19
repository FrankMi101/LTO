Imports System.ComponentModel
Imports AppOperate

Public Class BasePage
    Inherits System.Web.UI.Page
    Public Shared Sub SetDateTimeCulture()
        ' The WebDateChooser gets it's format from the current thread's culture object.  
        ' The code is added to have the editting of the DateChooser control be in 
        ' yyyy-MM-dd format
        Dim ci As New System.Globalization.CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.LCID)
        ci.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"

        ci.DateTimeFormat.DateSeparator = "-"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci

    End Sub

    ' Public Shared LoggingTraffic As String = System.Configuration.ConfigurationSettings.AppSettings("TrafficLog")

#Region "Traffic Log"
    Public Shared Sub PageTrafficLog(ByVal type As String, ByRef userid As String, ByVal screen_resolution As String) ''type  'PL -- Page Load, PU -- Page Unload
        Dim page_name, ip_address, session_id, browser_type, browser_version As String
        Dim machine_name As String
        Dim transaction_time As DateTime
        Dim support_js, support_cookie As Boolean

        ' If LoggingTraffic = 1 Then  ''Allow Log Traffic

        page_name = HttpContext.Current.Request.Path.ToString
        If page_name Is Nothing Then
            page_name = String.Empty
        End If

        'user_id = HttpContext.Current.User.Identity.Name.ToString
        ip_address = HttpContext.Current.Request.UserHostAddress.ToString

        If ip_address Is Nothing Then
            ip_address = String.Empty
        End If

        transaction_time = DateTime.Now.ToString

        session_id = HttpContext.Current.Session.SessionID.ToString

        If session_id Is Nothing Then
            session_id = String.Empty
        End If

        'screen_resolution = TCDSBSessionInfo.ScreenResolution

        'If TCDSBSessionInfo.ScreenResolution Is Nothing Then
        'screen_resolution = ""
        'Else
        'screen_resolution = TCDSBSessionInfo.ScreenResolution
        'End If

        If ip_address = "127.0.0.1" Then
            machine_name = "localhost"
        Else
            Try
                '    machine_name = System.Net.Dns.GetHostByAddress(ip_address).HostName.ToString.Substring(0, System.Net.Dns.GetHostByAddress(ip_address).HostName.ToString.IndexOf("."))
                machine_name = System.Net.Dns.GetHostEntry(ip_address).HostName.ToString.Substring(0, System.Net.Dns.GetHostEntry(ip_address).HostName.ToString.IndexOf("."))
            Catch ex As Exception
                machine_name = " "
                ''machine_name = System.Net.Dns.GetHostByAddress(ip_address).HostName.ToString
            End Try
        End If

        browser_type = HttpContext.Current.Request.Browser.Type

        browser_version = HttpContext.Current.Request.Browser.Version

        support_js = HttpContext.Current.Request.Browser.EcmaScriptVersion.ToString() '  .JavaScript 
        support_cookie = HttpContext.Current.Request.Browser.Cookies


        If browser_type Is Nothing Then
            browser_type = String.Empty
        End If

        If browser_version Is Nothing Then
            browser_version = String.Empty
        End If

        Dim mytbl As New Hashtable
        mytbl.Add("@Type", type)
        mytbl.Add("@session_id", session_id)
        mytbl.Add("@IP_address", ip_address)
        mytbl.Add("@user_id", userid)
        mytbl.Add("@page_name", page_name)
        mytbl.Add("@transaction_time", transaction_time)
        mytbl.Add("@browser_type", browser_type)
        mytbl.Add("@browser_version", browser_version)
        mytbl.Add("@screen_resolution", screen_resolution)
        mytbl.Add("@support_jscript", support_js)
        mytbl.Add("@support_cookie", support_cookie)
        mytbl.Add("@machine_name", machine_name)
        Dim support_js1 As String = IIf(support_js, "1", "0")
        Dim support_cookie1 As String = IIf(support_cookie, "1", "0")

        '  CommonTCDSB.UserTrack. LogTraffic(type, session_id, ip_address, userid, page_name, transaction_time, browser_type, browser_version, screen_resolution, support_js1, support_cookie1, machine_name)

        'Dim Report_Cards As Report_Cards.Report_Card
        'Report_Cards = New Report_Cards.Report_Card

        'Report_Cards.LogTraffic(type, session_id, ip_address, userid, page_name, transaction_time, browser_type, browser_version, screen_resolution, support_js, support_cookie, machine_name)

        ' End If

    End Sub


#End Region




    'Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    PageTrafficLog("PL")
    'End Sub
    Public Shared Function getMyValue(ByVal _value As Object) As Object
        Try
            If _value = Nothing Then

            End If
            Return _value
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Shared Function getMyValueC(ByVal _value As Object) As Object
        Try
            If _value = Nothing Or _value = "" Then
                _value = 0
            End If
            Return _value
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function SchoolPanel(ByVal schoolcode As String) As String
        Try
            Dim elementaryPanel As String = WebConfigValue.getValuebyKey("ElementaryPanel")

            If elementaryPanel.IndexOf(Left(schoolcode, 2)) = -1 Then
                Return "S"
            Else
                Return "E"
            End If
        Catch ex As Exception
            Return "E"
        End Try
    End Function
End Class

