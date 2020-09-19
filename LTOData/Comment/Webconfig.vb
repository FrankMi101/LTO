Imports System.Web.Configuration
Imports System.Web.UI.Page
Namespace CommonTCDSB
    Public Class Webconfig
        '  Inherits System.Web.UI.Page
        ' Dim conStr As String = WebConfigurationManager.AppSettings("currentDB")
        Public Shared Function getDBbyKey(ByVal _Key As String) As String
            Return WebConfigurationManager.ConnectionStrings(_Key).ToString
        End Function
        Public Shared Function getValuebyKey(ByVal _Key As String) As String
            Return WebConfigurationManager.AppSettings(_Key)
        End Function
        Public Shared ReadOnly Property AttFolder() As String
            Get
                Return WebConfigurationManager.AppSettings("AttachmentFolder")
            End Get
        End Property
        Public Shared ReadOnly Property Datasource() As String
            Get
                Return WebConfigurationManager.AppSettings("Datasource")
            End Get
        End Property
        Public Shared ReadOnly Property getRWSPW() As String
            Get
                Return WebConfigurationManager.AppSettings("getReportingWebService")
            End Get
        End Property
        Public Shared ReadOnly Property getRWSUser() As String
            Get
                Return WebConfigurationManager.AppSettings("getReportingWebServiceUser")
            End Get
        End Property

        Public Shared ReadOnly Property RapidKey(ByVal _hostAddress As String) As String
            Get
                Dim _key As String
                If _hostAddress = "trilliumapp01" Then
                    _key = WebConfigurationManager.AppSettings("RapidKeyTA01")
                Else
                    _key = WebConfigurationManager.AppSettings("RapidKey")
                End If
                Return _key
            End Get
        End Property
        Public Shared ReadOnly Property applicationName() As String
            Get
                Return WebConfigurationManager.AppSettings("Application")
            End Get
        End Property
        Public Shared ReadOnly Property applicationNameS() As String
            Get
                Return WebConfigurationManager.AppSettings("ApplicationS")
            End Get
        End Property
        Public Shared ReadOnly Property defaultPage() As String
            Get
                Return WebConfigurationManager.AppSettings("defaultPage")
            End Get
        End Property
        Public Shared ReadOnly Property CurrentDB() As String
            Get
                Return WebConfigurationManager.AppSettings("currentDB")
            End Get
        End Property
        Public Shared ReadOnly Property dbConStr(ByVal _vConStr As String) As String
            Get
                Return WebConfigurationManager.AppSettings(_vConStr) ' "currentDB")
            End Get
        End Property
        Public Shared ReadOnly Property LDAPServer() As String
            Get
                Return WebConfigurationManager.AppSettings("LDAP")
            End Get
        End Property
        Public Shared ReadOnly Property ReportServer() As String
            Get
                Return WebConfigurationManager.AppSettings("ReportServer")
            End Get
        End Property
        Public Shared ReadOnly Property ReportPath() As String
            Get
                Dim _DB As String = getDBbyKey("currentDB")
                Return WebConfigurationManager.AppSettings("ReportPath") + _DB + "%2f"
            End Get
        End Property
        Public Shared ReadOnly Property ReportPathWS() As String
            Get
                Dim _DB As String = getDBbyKey("currentDB")

                Return WebConfigurationManager.AppSettings("ReportPathWS") + _DB + "/"
            End Get
        End Property
        Public Shared ReadOnly Property ReportPW() As String
            Get
                Return WebConfigurationManager.AppSettings("WebServiceWP")
            End Get
        End Property
        Public Shared ReadOnly Property ReportUser() As String
            Get
                Return WebConfigurationManager.AppSettings("WebServiceUser")
            End Get
        End Property
        Public Shared ReadOnly Property Reportsource() As String
            Get
                Return WebConfigurationManager.AppSettings("Reportsource")
            End Get
        End Property

        Public Shared ReadOnly Property ReportFormat() As String
            Get
                Return WebConfigurationManager.AppSettings("ReportFormat")
            End Get
        End Property
        Public Shared ReadOnly Property ReportName(ByVal _reportID As String) As String
            Get
                Return WebConfigurationManager.AppSettings(_reportID)
            End Get
        End Property
        Public Shared ReadOnly Property SMTPServer() As String
            Get
                Return WebConfigurationManager.AppSettings("SMTPServer")
            End Get
        End Property
        Public Shared ReadOnly Property eMailSender() As String
            Get
                Return WebConfigurationManager.AppSettings("eMailSender")
            End Get
        End Property
        Public Shared ReadOnly Property eMailSubject() As String
            Get
                Return WebConfigurationManager.AppSettings("eMailSubject")
            End Get
        End Property
        Public Shared ReadOnly Property eMailHeader() As String
            Get
                Return WebConfigurationManager.AppSettings("eMailHeader")
            End Get
        End Property
        Public Shared ReadOnly Property eMailFooter() As String
            Get
                Return WebConfigurationManager.AppSettings("eMailFooter")
            End Get
        End Property
        Public Shared ReadOnly Property eMailCC() As String
            Get
                Return WebConfigurationManager.AppSettings("eMailCC")
            End Get
        End Property
        Public Shared ReadOnly Property eMailTO() As String
            Get
                Return WebConfigurationManager.AppSettings("eMailTO")
            End Get
        End Property
        Public Shared ReadOnly Property GoogleKey() As String
            Get
                Return WebConfigurationManager.AppSettings("GoogleKey")
            End Get
        End Property
        Public Shared ReadOnly Property TeacherColor() As String
            Get
                Return WebConfigurationManager.AppSettings("TeacherColor")
            End Get
        End Property
        Public Shared ReadOnly Property PrincipalColor() As String
            Get
                Return WebConfigurationManager.AppSettings("PrincipalColor")
            End Get
        End Property
        Public Shared ReadOnly Property AdminColor() As String
            Get
                Return WebConfigurationManager.AppSettings("AdminColor")
            End Get
        End Property
        Public Shared ReadOnly Property eMailTemplate() As String
            Get
                Return WebConfigurationManager.AppSettings("eMailTemplate")
            End Get
        End Property
    End Class
End Namespace
