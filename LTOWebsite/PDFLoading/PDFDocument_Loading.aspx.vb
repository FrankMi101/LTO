
Imports TCDSB.Student
Partial Class PDFDocument_Loading
    Inherits System.Web.UI.Page


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then

            Me.Page.Response.Expires = 0


            Dim _UserID As String = HttpContext.Current.User.Identity.Name
            '  Dim _Grade As String = Session("Grade")
            ' Dim ReportYear As String = DateFC.YearTOGO(Session("SchoolYear"), "Previous")
            'Try
            '    SES.IEP2.ReportCard.SQL03Parameter(_UserID, ReportYear, Session("SchoolCode"))
            '    '  SES.Security.UserTrack.SQL03Parameter(_UserID,Session("SchoolYear"), Session("SchoolCode"))
            'Catch ex As Exception

            'End Try




            Dim ReportName As String = Page.Request.QueryString("rID")
            Dim Schoolyear As String = Page.Request.QueryString("yID") ' "Question"
            Dim PositionID As String = Page.Request.QueryString("pID") ' "Question"
            Dim SessionID As String = Page.Request.QueryString("sID") ' "Question"
            Dim PostingNo As String = Page.Request.QueryString("pNo")
            Dim PostingCycle As String = Page.Request.QueryString("cID")
            Dim CPNum As String = Page.Request.QueryString("CPNum")


            Dim ReportLink As String = "PDFDocument_Print.aspx?repName=" + ReportName + "&schoolYear=" + Schoolyear + "&pID=" + PositionID + "&CPNum=" + CPNum + "&SessionID=" + SessionID + "&pNo=" + PostingNo + "&cID=" + PostingCycle
            Me.PageURL.HRef = ReportLink

        End If
    End Sub
End Class

