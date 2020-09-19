
'Imports TCDSB.Student
Partial Class Loading
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
        If Not Page.IsPostBack Then

            Me.Page.Response.Expires = 0

            Dim pID As String = Page.Request.QueryString("pID")
            If pID = Nothing Then
                pID = "Default_Home.aspx" '"SmartGoal/SmartGoalTab.aspx" '"Default_Home.aspx"
            End If
            Me.PageURL.HRef = pID


        End If
    End Sub

End Class
 