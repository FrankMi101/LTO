  

    Partial Class LoadingDocument
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



        Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
            If Not Page.IsPostBack Then

                Me.Page.Response.Expires = 0

                Dim dID As String = Page.Request.QueryString("dID")

                Dim myPage As String = "http://webs05.tcdsb.org/WebDocuments/Documents/BIP2/" + dID

                Me.LoadPage.HRef = myPage
                '  Page.Response.Redirect(myPage)

            End If
        End Sub
    End Class


