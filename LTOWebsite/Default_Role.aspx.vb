Imports System.Web

'Imports TCDSB.Student
Partial Class Default_Role
        Inherits System.Web.UI.Page
        Dim _UserID As String = HttpContext.Current.User.Identity.Name
        Protected WithEvents TD1 As System.Web.UI.HtmlControls.HtmlTableCell


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
        If Not Me.Page.IsPostBack Then
            Try
                ' If _UserID = "mif" Then Me.btnAlter.Visible = True
                '  getUserTrackinfo()
                '  setupLastValue()
                checkLoginUser()


            Catch ex As Exception


            End Try

        End If
    End Sub

    Private Sub checkLoginUser()
            Try
                Me.rblRole.Items.FindByValue(WorkingProfile.UserRole).Selected = True
            Catch ex As Exception

            End Try
        End Sub
        

        Protected Sub rblRole_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblRole.SelectedIndexChanged
            WorkingProfile.UserRole = Me.rblRole.SelectedValue
            Me.UserRoleID.Value = Me.rblRole.SelectedValue
            callPostback()
        End Sub
        Private Sub callpostback()

            Dim strScript As String = "CallParentPostBack()"
            ClientScript.RegisterStartupScript(GetType(String), "callPost11", strScript, True)
            '  Dim strScript As String = "<script> CallParentPostBack()</script>"
            '   ClientScript.RegisterStartupScript(GetType(String), "callPost", strScript)
        End Sub
    End Class
         
 