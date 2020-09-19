  

    Partial Class UserProfile
        Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblUserPosition As System.Web.UI.WebControls.Label
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not Page.IsPostBack Then
                Dim _userID As String = HttpContext.Current.User.Identity.Name
                Dim _UserName As String = WorkingProfile.UserName
                Me.lblUserName.Text = "  " & getGreeting() & " " & _UserName
                Me.lblDate.Text = WeekdayName(Weekday(Now())) & "   " & Year(Now()) & "-" & Month(Now()) & "-" & Day(Now())
                '  Dim _schoolyear As String = Session("SchoolYear")
                ' Dim _PersonID As String = Session("PersonID")
                '     Dim ds As DataSet = SES.IEP.CopyIEP.LastVersion(_schoolyear, _PersonID)
                '    Me.lblVersion.Text = "Last Version " & ds.Tables(0).Rows(0).Item(1)
                'Session("UserName") = _UserName

            End If
        End Sub
        Private Function getGreeting() As String
            Dim Greeting As String
            Dim cHour As Integer = Now.Hour
            If cHour < 12 Then
                Greeting = "Good Morning, "
            Else
                If cHour < 18 Then
                    Greeting = "Good Afternoon, "
                Else
                    Greeting = "Good Evening, "
                End If
            End If
            Return Greeting
        End Function
    End Class


