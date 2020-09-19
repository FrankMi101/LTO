
Partial Class Calendar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
         BasePage.SetDateTimeCulture()
        If Not Page.IsPostBack Then

            Me.Calendar1.SelectedDate = Now()
            Me.Label1.Text = Me.Calendar1.SelectedDate
        End If
        Me.Button2.Focus()

    End Sub


    Protected Sub Calendar1_SelectionChanged(sender As Object, e As System.EventArgs) Handles Calendar1.SelectionChanged
        Me.Label1.Text = Me.Calendar1.SelectedDate
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

End Class
