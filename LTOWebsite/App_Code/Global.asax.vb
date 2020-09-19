Imports System.Web
Imports System.Web.SessionState
Imports System.Security
Imports System.Security.Principal
Imports System.Web.Security
Imports System.Configuration
Imports System.Text
Imports Microsoft.Win32
Imports AppOperate
'Imports Microsoft.ApplicationInsights.Telemetry.Services
'Imports TCDSB.Student

Public Class [Global]
    Inherits System.Web.HttpApplication
    Public Shared ldapPath As String
    Public Shared domain As String
    Public Shared ReportPath As String
    Public Shared AppPath As String
    Public Shared Report_Card_URl As String
    Public Shared Version As String
    Public Shared Appflag As String




#Region " Component Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
        Dim cDB As String = System.Configuration.ConfigurationManager.ConnectionStrings("currentDB").ToString
        ' SetupData.myDBConStr = System.Configuration.ConfigurationManager.ConnectionStrings(cDB).ToString
        '  SetupData.myApplication = System.Configuration.ConfigurationManager.AppSettings("Application")
        Application("ApplVersion") = cDB
        BasePage.SetDateTimeCulture()
        Application("UsersOnline") = 0
        SetUpSPSource2()
    End Sub
    'Sub SetUpSPSource()
    '    ' ************************Setup Data source SP and parameters source*************************************************
    '    '     <add key="SPFile" value="Content\DataAccess.json"/>
    '    Dim spfile = WebConfigValue.SPFile
    '    If spfile = "" Then
    '        SPSource.SetSPFile("")
    '    Else
    '        spfile = Server.MapPath(spfile)
    '        SPSource.SetSPFile(spfile)
    '    End If

    'End Sub
    Sub SetUpSPSource2()
        ' ************************Setup Data source SP and parameters source*************************************************
        '     <add key="SPFile" value="Content\DataAccess.json"/>
        Dim spfile = WebConfigValue.SPFile
        If Not spfile = "" Then
            spfile = Server.MapPath(spfile)
        End If
        SPSource.SPFile = spfile
    End Sub
    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
        Application.Lock()
        Application("UsersOnline") = CInt(Application("UsersOnline")) + 1
        Application.UnLock()
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request   
        Try
            ' ServerAnalytics.BeginRequest()
            '  ServerAnalytics.CurrentRequest.LogEvent(Request.Url.AbsolutePath)
        Catch ex As Exception

        End Try

    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        Dim cookieName As String = FormsAuthentication.FormsCookieName

        Dim authCookie As HttpCookie = Context.Request.Cookies(cookieName)

        If authCookie Is Nothing Then
            Return
        End If

        Dim authTicket As FormsAuthenticationTicket = Nothing

        Try
            authTicket = FormsAuthentication.Decrypt(authCookie.Value)
        Catch ex As Exception
            Return
        End Try

        If authTicket Is Nothing Then
            'cookie failed to decrypt
            Return
        End If



    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
        Dim ex As Exception = Server.GetLastError()


        ' emailtoMe(ex)
        Context.ClearError() ' Server.ClearError()


    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
        ' Context.ClearError()
        'Dim ePage As String = "SessionTimeout.htm"
        'Response.Redirect(ePage) '  Server.Transfer("error.aspx")
        Application.Lock()
        Application("UsersOnline") = CInt(Application("UsersOnline")) - 1
        Application.UnLock()
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class

