'Imports TCDSB.Student
Partial Class LoadingSub
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.Page.Response.Expires = 0
            Dim schoolyear As String = GetValueFromQS("schoolyear") ' Page.Request.QueryString("schoolyear")
            Dim positionID As String = GetValueFromQS("PositionID") ' Page.Request.QueryString("PositionID")
            Dim cycleID As String = GetValueFromQS("Cycle") ' Page.Request.QueryString("Cycle")
            Me.PageURL.HRef = "PostingSummaryDetailsSub.aspx?pID=" + positionID + "&yID=" + schoolyear + "&cID=" + cycleID

        End If
    End Sub
    Private Function GetValueFromQS(ByVal key As String) As String
        Return BasePage.GetValueFromQS(Page, key)
    End Function
End Class
