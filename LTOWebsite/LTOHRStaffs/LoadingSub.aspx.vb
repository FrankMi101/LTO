'Imports TCDSB.Student
Partial Class LoadingSub
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.Page.Response.Expires = 0
            Dim schoolyear As String = Page.Request.QueryString("schoolyear")
            Dim positionID As String = Page.Request.QueryString("PositionID")
            Dim cycleID As String = Page.Request.QueryString("Cycle")
            Me.PageURL.HRef = "PostingSummaryDetailsSub.aspx?pID=" + positionID + "&yID=" + schoolyear + "&cID=" + cycleID

        End If
    End Sub
End Class
