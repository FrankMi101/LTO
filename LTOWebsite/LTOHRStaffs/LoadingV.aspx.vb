'Imports TCDSB.Student
Partial Class LoadingV
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.Page.Response.Expires = 0
            Dim pID As String = Page.Request.QueryString("pID") 
            Select Case pID
                Case "0"
                    Me.PageURL.HRef = "ApplicatVerification_0.aspx"
                Case "1"
                    Me.PageURL.HRef = "ApplicatVerification_1.aspx"
                Case "2"
                    Me.PageURL.HRef = "ApplicatVerification_2.aspx"
                Case "3"
                    Me.PageURL.HRef = "ApplicatVerification_3.aspx"
                Case "4"
                    Me.PageURL.HRef = "ApplicatVerification_4.aspx"

                Case Else
                    Me.PageURL.HRef = "ApplicatVerification_0.aspx"
            End Select


        End If
    End Sub
End Class
