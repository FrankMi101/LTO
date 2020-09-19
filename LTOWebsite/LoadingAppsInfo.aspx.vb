
'Imports TCDSB.Student
Imports AppOperate
Partial Class LoadingAppsInfo
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then

            Me.Page.Response.Expires = 0

            Dim aID As String = Page.Request.QueryString("aID")
            Dim AppsID As String = WebConfigValue.AppName
            Dim UserID As String = WorkingProfile.UserID
            Dim RoleID As String = WorkingProfile.UserRole
            Dim goPage As String = WebConfigValue.getValuebyKey("AppsInfoLink") ' "http://webt01.tcdsb.org/Qa/AppsInfo/Default.aspx"

            If aID = "Edit" Then
                goPage = goPage + "?AppsID=" + AppsID + "&UserID=" + UserID + "&RoleID=" + RoleID + "&aID=Edit"
            Else
                goPage = goPage + "?AppsID=" + AppsID + "&UserID=" + UserID + "&RoleID=" + RoleID
            End If


            Me.PageURL.HRef = goPage




        End If
    End Sub

End Class
 