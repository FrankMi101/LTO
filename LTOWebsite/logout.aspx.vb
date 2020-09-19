Imports System.web.Security
Imports TCDSB.Student
  

    Partial Class logout
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        'Put user code to initialize the page here
        WorkingProfile.LoginStatues("Logout") = "OffLine"
        'Session("currentDataSet") = Nothing
        'Session("UserRole") = Nothing
        'Session("SchoolCode") = Nothing
        'Session("LeftMenu") = Nothing
        'Session("Permission") = Nothing ' P.UserID
        'Session("SchoolCode") = Nothing
        'Session("SchoolName") = Nothing
        'Session("SchoolYear") = Nothing
        'Session("cSchoolYear") = Nothing
        'Session("TeacherID") = Nothing
        'Session("SessionID") = Nothing
        'Session("UserArea") = Nothing
        'Session("UserName") = Nothing
        'Session("UserPosition") = Nothing
        'Session("UserScope") = Nothing
        'Session("currentRBL") = Nothing
        'Session("selectedGroupID") = Nothing
        'Session("DomainID") = Nothing

        'Session("ApplicationTypeSessionValue") = Nothing
        'Session("CompetencyID") = Nothing
        'FormsAuthentication.SignOut()
        'Page.Application.Clear()
        'Application.Clear()
        'Me.Session.Clear()
        'Response.Redirect("default.aspx", False)  'Logon.aspx")

        FormsAuthentication.SignOut()
        Response.Redirect("default.aspx")
    End Sub

End Class
 