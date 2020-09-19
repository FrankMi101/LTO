  
    Partial Class LoadingNonQ
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            If Not Page.IsPostBack Then

                Me.Page.Response.Expires = 0
                '  Dim _goPage As String = Page.Request.QueryString("goPage")


            End If
        End Sub
    End Class
