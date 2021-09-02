Imports AppOperate
Partial Class OCTSite
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            If Not Page.IsPostBack Then

                Me.Page.Response.Expires = 0
            Dim OCTNum As String = Page.Request.QueryString("OCTNum")
            Dim OCTSite = WebConfigValue.getValuebyKey("OCTSite")
            Me.PageURL.HRef = OCTSite + OCTNum '  "http://www.oct.ca/findateacher/memberinfo?memberid=" + OCTNum


        End If
        End Sub
    End Class
