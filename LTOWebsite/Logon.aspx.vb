Imports System.Web.Configuration
Imports System.Web.Security
Imports System.Drawing
'Imports TCDSB.Student
Imports AppOperate
Imports System.Security.Principal

Partial Class Logon
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            Session("mytheme") = "Theme1"
            ' Dim _applID As String = System.Configuration.ConfigurationManager.AppSettings("Application")

            Dim cuse As String = HttpContext.Current.User.Identity.Name
            Dim cauth As String = HttpContext.Current.User.Identity.AuthenticationType
            Dim isauth As String = HttpContext.Current.User.Identity.IsAuthenticated

            '   Session("ApplicationTypeSessionValue") = Nothing
            Dim appSou = Page.Request.QueryString("appsou")
            If appSou = Nothing Then appSou = "out"
            Dim userid As String = Page.Request.QueryString("userid")
            'Dim userid As String = "mif"
            ' Dim encUserId = TcdsbSymetricEncryption.GetSsoQueryString("mif")
            'Dim qs As String = encUserId.Substring(7)
            Dim testing As String = WebConfigurationManager.AppSettings("AuthenticateMethod")

            userid = UserSymetricEncryption.GetValidatedSsoFromQueryString(userid, testing)

            If (userid = Nothing Or userid = String.Empty Or userid = "undefined" Or appSou = "out") Then  'get UserID 
                Dim sName As String = Server.MachineName
                Me.txtUsername.Focus()
                ' SetFocus1(txtUsername)

                ' ********* only works on VS. it does not work on Server ******************************** 
                'Dim windowsCurrent = WindowsIdentity.GetCurrent()
                'If windowsCurrent.IsAuthenticated Then
                '*******************************************************************************************
            Else
                Me.txtUsername.Text = userid
                Me.txtPassword.Focus()
            End If
            Me.LabelHost.Text = System.Net.Dns.GetHostName()
            Dim cDB As String = System.Configuration.ConfigurationManager.ConnectionStrings("currentDB").ToString

            ' Dim _train As String = System.Configuration.ConfigurationManager.AppSettings("ApplicationVersion") '  System.Web.Configuration.WebConfigurationManager.AppSettings("IEPVersion")
            If Not cDB = "Production" Then
                Me.LabelTraining.Visible = True
                Me.LabelTraining.Text = cDB
            End If
            ' SetFocus(txtUsername)
            Session("IsMobile") = IsMobile()
        End If
    End Sub

    Private Sub SetFocus1(ByVal ctrl As System.Web.UI.Control)
        Dim s As String = "<SCRIPT language='javascript'>document.getElementById('" & ctrl.ID & "').focus() </SCRIPT>"
        ClientScript.RegisterStartupScript(GetType(String), "focus", s)
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        If AuthenticationMethod() = "NameOnly" Then
            CheckTestUser("Verified")
        Else
            Try
                Dim auth = UserSecurity.AuthenticateResult(txtDomain.Text, txtUsername.Text, txtPassword.Text)
                If auth = "true" Then '  LoginIdentify.Authenticate(txtDomain.Text, txtUsername.Text, txtPassword.Text) Then '  Common.LDAP_Authentication.Authenticate(txtDomain.Text, txtUsername.Text, txtPassword.Text) Then
                    CheckAppRole()
                Else
                    CheckTestUser(auth) '"Authentication did not succeed. Check user name and password.")
                End If
            Catch ex As Exception
                Dim excep = ex.Message
                CheckTestUser(excep) '"Authentication did not succeed. Check user name and password.")
            End Try
        End If

    End Sub
    Private Function AuthenticationMethod() As String
        Dim authMethod As String = WebConfigurationManager.AppSettings("AuthenticateMethod")
        Dim sName As String = System.Net.Dns.GetHostName()
        If authMethod = "NameOnly" Then
            If IsProdutionServer(sName) Then authMethod = "NameOnlyFalse"
        Else
            If sName = "0811N0009MC7LC2" And Me.txtUsername.Text = "mif" Then authMethod = "NameOnly"
        End If
        Return authMethod
    End Function
    Private Function IsProdutionServer(ByVal sName As String) As Boolean
        Dim appServers As String = WebConfigurationManager.AppSettings("AppServers")
        If appServers.IndexOf(sName) > -1 Then Return True
        Return False
    End Function
    Private Sub CheckTestUser(ByVal verifyResult As String)
        If verifyResult = "Verified" Then
            CheckAppRole()
        Else
            errorlabel.ForeColor = Drawing.Color.Red
            errorlabel.Text = verifyResult ' WebConfigurationManager.AppSettings("LoginMessage")
        End If
    End Sub
    Private Sub CheckAppRole()
        Try
            Dim userRole As String = UserSecurity.UserRole(txtUsername.Text) ' CommonTCDSB.UserSecurity.TestUserRole(Me.txtUsername.Text)
            If userRole = "SAP Profile" Then
                errorlabel.ForeColor = Drawing.Color.Red
                errorlabel.Text = WebConfigurationManager.AppSettings("NotAuthorize")  ' "Your SAP Profile is not quailified the LTO position!"

            ElseIf userRole = "Other" Then
                errorlabel.ForeColor = Drawing.Color.Red
                errorlabel.Text = WebConfigurationManager.AppSettings("SorryNoP") '"Authentication did not succeed. Check user name and password."
            Else
                CreateAuthTicket(userRole)
            End If
        Catch ex As Exception
            errorlabel.ForeColor = Drawing.Color.Red
            errorlabel.Text = "Database Operation Failed - " + ex.Message
        End Try

    End Sub
    Private Sub CreateAuthTicket(ByVal _role As String)
        Try

            WorkingProfile.UserID = Me.txtUsername.Text
            WorkingProfile.UserRole = _role
            WorkingProfile.LoginRole = _role
            WorkingProfile.LoginStatues("Login") = "OnLine"
            WorkingProfile.SchoolCode = Nothing
            WorkingProfile.SchoolName = Nothing
            Dim iscookiepersistent As Boolean = chkPersist.Checked
            Dim appID As String = Page.Request.QueryString("appid")
            Dim userid As String = Page.Request.QueryString("userid")



            If appID = Nothing Or appID = "undefined" Then
                Session("ApplicationEntry") = "NotSP"
                'Else
                '    Session("ApplicationTypeSessionValue") = CommonTCDSB.UserTrack. TrackInfo(WorkingProfile.UserID, "ApplicationType")
            Else
                WorkingProfile.ApplicationType = appID
            End If

            ' WorkingProfile.ApplicationType = "POP"

            Dim authTicket As FormsAuthenticationTicket = New FormsAuthenticationTicket(1, txtUsername.Text, DateTime.Now, DateTime.Now.AddMinutes(60), iscookiepersistent, "")

            Dim encryptedticket As String = FormsAuthentication.Encrypt(authTicket)

            Dim authCookie As HttpCookie = New HttpCookie(FormsAuthentication.FormsCookieName, encryptedticket)

            If iscookiepersistent Then
                authCookie.Expires = authTicket.Expiration
            End If

            authCookie.HttpOnly = True
            Response.Cookies.Add(authCookie)

            Session("ScreenResolution") = Request.Form("txtResolution")

            Dim id As System.Security.Principal.GenericIdentity = New System.Security.Principal.GenericIdentity(authTicket.Name, "LdapAuthentication")

            Dim principal As System.Security.Principal.GenericPrincipal = New System.Security.Principal.GenericPrincipal(id, Nothing)

            Context.User = principal
            saveEnvrionment(_role)
            LogFile(Me.txtUsername.Text, txtPassword.Text, "Login")
            Response.Redirect(FormsAuthentication.GetRedirectUrl(txtUsername.Text, False), False)

        Catch ex As Exception
            Dim sm = ex.StackTrace

        End Try
    End Sub
    Private Sub LogFile(ByVal _userID As String, ByVal _password As String, ByVal _result As String)
        Dim ip_address, session_id, browser_type, browser_version, screen_resolution As String
        Dim machine_name As String
        Dim transaction_time As DateTime
        'user_id = HttpContext.Current.User.Identity.Name.ToString
        ip_address = HttpContext.Current.Request.UserHostAddress.ToString
        If ip_address Is Nothing Then
            ip_address = String.Empty
        End If

        transaction_time = DateTime.Now.ToString
        screen_resolution = Session("ScreenResolution")
        session_id = Session.SessionID.ToString

        If session_id Is Nothing Then
            session_id = String.Empty
        End If
        If ip_address = "127.0.0.1" Then
            machine_name = "localhost"
        Else
            Try
                '  machine_name = System.Net.Dns.GetHostByAddress(ip_address).HostName.ToString.Substring(0, System.Net.Dns.GetHostByAddress(ip_address).HostName.ToString.IndexOf("."))
                machine_name = System.Net.Dns.GetHostName() ' (ip_address) '  .GetHostByAddress(ip_address).HostName.ToString.Substring(0, System.Net.Dns.GetHostByAddress(ip_address).HostName.ToString.IndexOf("."))
            Catch ex As Exception
                machine_name = " "
            End Try
        End If

        browser_type = HttpContext.Current.Request.Browser.Type

        browser_version = HttpContext.Current.Request.Browser.Version
        '   CommonTCDSB.UserTrack. LogTraffic(_result, "1", ip_address, _userID, "SLIP", transaction_time, browser_type, browser_version, screen_resolution, "", "", machine_name)



    End Sub
    Private Sub saveEnvrionment(ByVal _Role As String)
        Try

            Dim ServerID As String = Request.ServerVariables("LOCAL_ADDR")
            Dim ServerName As String = Server.MachineName
            Dim ScreenSize As String = Request.Form("txtResolution")
            Dim machine_name As String = Server.MachineName
            Dim browser_type As String = HttpContext.Current.Request.Browser.Type
            Dim browser_version As String = HttpContext.Current.Request.Browser.Version

            '   LoginIdentify.LoginParameter(txtUsername.Text, ServerName, ScreenSize, _Role, WorkingProfile.SchoolYearCurrent, "OnLine", browser_type)

            UserTrack.ActionTrack(txtUsername.Text, ServerName, ScreenSize, _Role, WorkingProfile.SchoolYearCurrent, "OnLine", browser_type)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Not Session("mytheme") Is Nothing Then
            Me.Theme = Session("mytheme")

        End If
    End Sub
    ' ### setup Page StylesheetTheme
    Public Overrides Property StyleSheetTheme() As String
        Get
            Return Session("mytheme")
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Function IsMobile() As Boolean

        Dim myBrowserCaps As System.Web.HttpBrowserCapabilities = HttpContext.Current.Request.Browser
        If Request.Browser.IsMobileDevice Then
            Session("Device") = "Mobile"
            Return True
        Else
            Session("Device") = "PC"
            Return False
        End If

    End Function
    'Dim RegexMobile As Regex = New Regex("(iemobile|iphone|ipod|android|nokia|sonyericsson|blackberry|samsung|sec-|windows ce|motorola|mot-|up.b|midp-)", RegexOptions.IgnoreCase|RegexOptions.Compiled)
    'Private Function checkIsMobuile() As String

    '    Dim Context = New HttpContext.Current
    '    If Not Context = Nothing Then
    '        Dim request = Context.Request
    '        If request.Browser.IsMobileDevice Then
    '            Return "Mobile"
    '        Else
    '            If IsNothing(request.UserAgent) And RegexMobile.IsMatch(request.UserAgent) Then
    '                Return "Mobile"
    '            End If
    '        End If

    '    End If
    '    Return "PC"
    'End Function

End Class

