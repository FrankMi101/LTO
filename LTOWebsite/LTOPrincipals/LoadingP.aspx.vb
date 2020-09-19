'Imports TCDSB.Student
Partial Class LoadingP
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.Page.Response.Expires = 0
            Dim pID As String = Page.Request.QueryString("pID")
            Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
            Dim schoolcode As String = Page.Request.QueryString("SchoolCode")
            Dim positionID As String = Page.Request.QueryString("PositionID")
            Dim schoolname As String = Page.Request.QueryString("SchoolName")
            Dim appType As String = Page.Request.QueryString("appType")
            Dim interviewS As String = Page.Request.QueryString("interviewS")
            Dim applyuserID As String = Page.Request.QueryString("ApplyUserID")
            Dim teacherName As String = Page.Request.QueryString("TeacherName")
            Dim status As String = Page.Request.QueryString("Status")
            Select Case pID
                Case "1"
                    Me.PageURL.HRef = "RecommendPositionList.aspx"
                Case "2"
                    Me.PageURL.HRef = "InterviewList2.aspx?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&SchoolName=" + schoolname + "&PositionID=" + positionID + "&appType=" + appType + "&interviewS=" + interviewS + "&Status=" + status
                Case "3"
                    Me.PageURL.HRef = "InterviewDetails2.aspx?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&SchoolName=" + schoolname + "&PositionID=" + positionID + "&interviewS=" + interviewS
                Case "7"
                    Me.PageURL.HRef = "InterviewDetails2.aspx?SchoolYear=" + schoolyear + "&ApplyUserID=" + applyuserID + "&PositionID=" + positionID + "&TeacherName=" + teacherName + "&InterViewS=" + interviewS
                Case "4"
                    Me.PageURL.HRef = "RequestList2.aspx"   '"RequestPostingList.aspx"' ?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&SchoolName=" + schoolname
                Case "5"
                    Me.PageURL.HRef = "OpenPositionList2.aspx"    ' "OpenPositionList.aspx"

                Case "6"
                    Me.PageURL.HRef = "RequestDetails.aspx?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&SchoolName=" + schoolname + "&PositionID=" + positionID
                Case "BaseHelp.aspx"
                    Me.PageURL.HRef = "../CommonPages/BaseHelp.aspx&cID=Interview&iID=PrincipalDetail"

                Case "8"
                    Me.PageURL.HRef = "InterviewList2M.aspx?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&SchoolName=" + schoolname + "&PositionID=" + positionID + "&appType=" + appType + "&interviewS=" + interviewS
                Case "9"
                    Me.PageURL.HRef = "InterviewSignatureM.aspx?SchoolYear=" + schoolyear + "&PositionID=" + positionID + "&SchoolCode=" + schoolcode + "&ApplyUserID=" + applyuserID + "&SchoolName=" + schoolname

                Case "InterviewTeam"
                    Me.PageURL.HRef = "InterviewTeam.aspx?SchoolYear=" + schoolyear + "&PositionID=" + positionID + "&SchoolCode=" + schoolcode + "&SchoolName=" + schoolname

                Case Else
                    Me.PageURL.HRef = "PrincipalProcess.aspx"
            End Select


        End If
    End Sub
End Class
