
Partial Class EXCELDocument_Loading
    Inherits System.Web.UI.Page


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then

            Me.Page.Response.Expires = 0


            Dim _UserID As String = HttpContext.Current.User.Identity.Name



            Dim ReportName As String = GetQueryStrValue("rID")
            Dim Schoolyear As String = GetQueryStrValue("yID")
            Dim PositionID As String = GetQueryStrValue("pID")
            Dim AppType As String = GetQueryStrValue("AppType")
            Dim Panel As String = GetQueryStrValue("Panel")
            Dim OpenClose As String = GetQueryStrValue("OpenClose")
            Dim SearchBy As String = GetQueryStrValue("SearchBy")
            Dim SearchValue1 As String = GetQueryStrValue("SearchValue1")
            Dim SearchValue2 As String = GetQueryStrValue("SearchValue2")
            Dim CPNum As String = GetQueryStrValue("CPNum")
            Dim IncludeAll As String = GetQueryStrValue("IncludeAll")
            Dim th4Round As String = GetQueryStrValue("th4Round")

            Dim ReportLink As String = "EXCELDocument_Print.aspx?repName=" + ReportName + "&schoolYear=" + Schoolyear + "&AppType=" + AppType + "&Panel=" + Panel + "&OpenClose=" + OpenClose + "&SearchBy=" + SearchBy + "&SearchValue1=" + SearchValue1 + "&SearchValue2=" + SearchValue2 + "&IncludeAll=" + IncludeAll + "&pID=" + PositionID + "&th4Round=" + th4Round
            Me.PageURL.HRef = ReportLink

        End If
    End Sub
    Private Function GetQueryStrValue(ByVal key As String) As String
        Try

            Dim rVal As String = Page.Request.QueryString(key)  'BasePage.GetValueFromQS(Page, key)
            If rVal = "undefined" Then rVal = " "
            Return rVal

        Catch ex As Exception
            Return " "
        End Try
    End Function
End Class

