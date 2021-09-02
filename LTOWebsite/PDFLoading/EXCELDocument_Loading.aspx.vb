
Partial Class EXCELDocument_Loading
    Inherits System.Web.UI.Page


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then

            Me.Page.Response.Expires = 0


            Dim _UserID As String = HttpContext.Current.User.Identity.Name



            Dim ReportName As String = Page.Request.QueryString("rID")
            Dim Schoolyear As String = Page.Request.QueryString("yID")
            Dim PositionID As String = Page.Request.QueryString("pID")
            Dim AppType As String = Page.Request.QueryString("AppType")
            Dim Panel As String = Page.Request.QueryString("Panel")
            Dim OpenClose As String = Page.Request.QueryString("OpenClose")
            Dim SearchBy As String = Page.Request.QueryString("SearchBy")
            Dim SearchValue1 As String = Page.Request.QueryString("SearchValue1")
            Dim SearchValue2 As String = Page.Request.QueryString("SearchValue2")
            Dim CPNum As String = Page.Request.QueryString("CPNum")
            Dim IncludeAll As String = Page.Request.QueryString("IncludeAll")
            Dim th4Round As String = Page.Request.QueryString("th4Round")

            Dim ReportLink As String = "EXCELDocument_Print.aspx?repName=" + ReportName + "&schoolYear=" + Schoolyear + "&AppType=" + AppType + "&Panel=" + Panel + "&OpenClose=" + OpenClose + "&SearchBy=" + SearchBy + "&SearchValue1=" + SearchValue1 + "&SearchValue2=" + SearchValue2 + "&IncludeAll=" + IncludeAll + "&pID=" + PositionID + "&th4Round=" + th4Round
            Me.PageURL.HRef = ReportLink

        End If
    End Sub
End Class

