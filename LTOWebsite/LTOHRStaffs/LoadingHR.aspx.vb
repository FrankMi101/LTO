'Imports TCDSB.Student
Partial Class LoadingHR
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.Page.Response.Expires = 0
            Dim pID As String = GetValueFromQS("pID") ' Page.Request.QueryString("pID")
            Dim schoolyear As String = GetValueFromQS("SchoolYear")  ' Page.Request.QueryString("SchoolYear")
            Dim schoolcode As String = GetValueFromQS("SchoolCode")  'Page.Request.QueryString("SchoolCode")
            Dim positionID As String = GetValueFromQS("PositionID")  'Page.Request.QueryString("PositionID")
            Dim schoolname As String = GetValueFromQS("SchoolName")  'Page.Request.QueryString("SchoolName")
            Dim postedState As String = GetValueFromQS("PostedState")  'Page.Request.QueryString("PostedState")
            Dim includall As String = GetValueFromQS("includAll")  'Page.Request.QueryString("includAll")

            Select Case pID
                Case "W"
                    Me.PageURL.HRef = "Welcome.html"'  WelcomePage.aspx"
                Case "0"
                    Me.PageURL.HRef = "RequestPostingList2.aspx"
                Case "1"
                    Me.PageURL.HRef = "RequestPositionList2.aspx" ' "PositionList_Request.aspx" '
                Case "2"
                    Me.PageURL.HRef = "ApplicantList2.aspx?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&SchoolName=" + schoolname + "&PositionID=" + positionID + "&PostedState=" + postedState + "&includAll=" + includall
                Case "3"
                    Dim ApplyUserID As String = Page.Request.QueryString("ApplyUserID")
                    Dim TeacherName As String = Page.Request.QueryString("TeacherName")
                    Dim goPage As String = "ApplicantDetails.aspx?SchoolYear=" + schoolyear + "&ApplyUserID=" + ApplyUserID + "&TeacherName=" + TeacherName + "&PositionID=" + positionID
                    Page.Response.Redirect(goPage)
                Case "4"
                    Me.PageURL.HRef = "PublishedList2.aspx?sID=InterviewApplicant" '"PublishedList.aspx?sID=InterviewApplicant"
                Case "5"
                    Me.PageURL.HRef = "RequestPositionDetails.aspx?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&SchoolName=" + schoolname + "&PositionID=" + positionID
                Case "6"
                    Me.PageURL.HRef = "RequestPositionDetails.aspx?SchoolYear=" + "0000" + "&SchoolCode=" + "0000" + "&SchoolName=" + "" + "&PositionID=" + "0000"
                Case "7"
                    Me.PageURL.HRef = "PublishedList2.aspx?sID=InterviewCandidate"
                Case "8"
                    Me.PageURL.HRef = "HiringPositionList2.aspx"  '   "HiringPositionList.aspx"
                Case "9"
                    Me.PageURL.HRef = "HiredPositionList2.aspx"    '"HiredPositionList.aspx"
                Case "V"
                    Me.PageURL.HRef = "ApplicantVerification.aspx"
                Case "X"
                    Me.PageURL.HRef = "PostingSummary.aspx"
                Case Else
                    Me.PageURL.HRef = "PublishedList2.aspx"
            End Select


        End If
    End Sub
    Private Function GetValueFromQS(ByVal key As String) As String
        Return BasePage.GetValueFromQS(Page, key)
    End Function
End Class
