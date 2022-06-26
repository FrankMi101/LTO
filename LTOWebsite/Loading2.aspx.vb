'Imports TCDSB.Student
Imports AppOperate

Partial Class Loading2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.Page.Response.Expires = 0

            Dim pID As String = GetValueFromQS("pID") ' Page.Request.QueryString("pID")
            Dim schoolyear As String = GetValueFromQS("SchoolYear")  ' Page.Request.QueryString("SchoolYear")
            Dim schoolcode As String = GetValueFromQS("SchoolCode")  'Page.Request.QueryString("SchoolCode")
            Dim positionID As String = GetValueFromQS("PositionID")  'Page.Request.QueryString("PositionID")
            Dim schoolname As String = GetValueFromQS("SchoolName")  'Page.Request.QueryString("SchoolName")
            Dim appType As String = GetValueFromQS("appType")  'Page.Request.QueryString("appType")
            Dim interviewS As String = GetValueFromQS("interviewS")  'Page.Request.QueryString("interviewS")
            Dim applyuserID As String = GetValueFromQS("ApplyUserID")  'Page.Request.QueryString("ApplyUserID")
            Dim teacherName As String = GetValueFromQS("TeacherName")  'Page.Request.QueryString("TeacherName")
            Dim status As String = GetValueFromQS("Status")  'Page.Request.QueryString("Status")
            Dim includall As String = GetValueFromQS("includAll") ' Page.Request.QueryString("includAll")
            Dim requestStatus As String = GetValueFromQS("RequestStatus") '  Page.Request.QueryString("RequestStatus")
            Dim source As String = GetValueFromQS("Source") '  Page.Request.QueryString("Source")
            Dim LTOstatus As String = GetValueFromQS("LTOStatus") '  Page.Request.QueryString("LTOStatus")
            Dim action As String = GetValueFromQS("Action") '  Page.Request.QueryString("LTOStatus")


            Try
                If WebConfigValue.getValuebyKey("SiteClose") = "All" Then
                    pID = "Close"
                End If
                If WebConfigValue.getValuebyKey("SiteClose") = "Principal" Then
                    pID = "CloseP"
                End If


                Select Case pID
                    Case "LTOHRStaffs/RequestPositionDetails.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID
                    Case "LTOHRStaffs/RequestPositionDetails2.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID + "&Action=" + action
                    Case "LTOHRStaffs/RequestPostingDetails.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&RequestID=" + positionID + "&TeacherName=" + teacherName + "&RequestStatus=" + requestStatus
                    Case "LTOHRStaffs/RequestPostingDetails2.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&RequestID=" + positionID + "&TeacherName=" + teacherName + "&RequestStatus=" + requestStatus
                    Case "ReminderToPrincipal.aspx"
                        Me.PageURL.HRef = pID
                    Case "LTOHRStaffs/PostingProcessSteps.aspx"
                        Me.PageURL.HRef = pID
                    Case "LTOHRStaffs/ApplicantDetails.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&ApplyUserID=" + applyuserID + "&PositionID=" + positionID + "&TeacherName=" + teacherName
                    Case "LTOHRStaffs/ApplicantDetails2.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&ApplyUserID=" + applyuserID + "&PositionID=" + positionID + "&TeacherName=" + teacherName
                    Case "LTOHRStaffs/NoticeToPrincipal.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&Schoolcode=" + schoolcode + "&PositionID=" + positionID + "&SchoolName=" + schoolName
                    Case "LTOHRStaffs/NoticeToPrincipal2.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&Schoolcode=" + schoolcode + "&PositionID=" + positionID + "&SchoolName=" + schoolName

                    Case "LTOHRStaffs/HiringDetails.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&ApplyUserID=" + applyuserID + "&PositionID=" + positionID + "&TeacherName=" + teacherName
                    Case "LTOHRStaffs/HiringDetails2.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&ApplyUserID=" + applyuserID + "&PositionID=" + positionID + "&TeacherName=" + teacherName
                    Case "LTOHRStaffs/HiringDetails4th.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&ApplyUserID=" + applyuserID + "&PositionID=" + positionID + "&TeacherName=" + teacherName
                    Case "LTOHRStaffs/HiringDetails4th2.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&ApplyUserID=" + applyuserID + "&PositionID=" + positionID + "&TeacherName=" + teacherName
                    Case "LTOHRStaffs/HiredDetails4th.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&ApplyUserID=" + applyuserID + "&PositionID=" + positionID + "&TeacherName=" + teacherName
                    Case "LTOHRStaffs/HiredDetails2.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&ApplyUserID=" + applyuserID + "&PositionID=" + positionID + "&TeacherName=" + teacherName
                    Case "LTOHRStaffs/NoticeToOfficerForHired.aspx"
                        Me.PageURL.HRef = pID
                    Case "LTOHRStaffs/QualificationMatchList.aspx"
                        Me.PageURL.HRef = pID
                    Case "LTOTeachers/LocationMap.aspx"
                        Me.PageURL.HRef = pID + "?SchoolCode=" + schoolcode
                    Case "LTOTeachers/ApplyPosition.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&PositionID=" + positionID + "&SchoolCode=" + schoolcode + "&CPNum=" + applyuserID
                    Case "LTOTeachers/ApplyPosition2.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&PositionID=" + positionID + "&SchoolCode=" + schoolcode + "&CPNum=" + applyuserID
                    Case "LTOTeachers/ApplyPositionList.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&PositionID=" + positionID + "&SchoolCode=" + schoolcode + "&CPNum=" + applyuserID
                    Case "LTOTeachers/ApplyPositionList2.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&PositionID=" + positionID + "&SchoolCode=" + schoolcode + "&CPNum=" + applyuserID
                    Case "LTOTeachers/NewUserProfile.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&CPNum=" + applyuserID + "&Source=" + source + "&LTOStatus=" + LTOstatus

                    Case "LTOTeachers/ApplyPositionNotQual.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&PositionID=" + positionID + "&SchoolCode=" + schoolcode + "&CPNum=" + applyuserID
                    Case "LTOPrincipals/NoticeToHRStaff.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&PositionID=" + positionID + "&SchoolCode=" + schoolcode + "&SchoolName=" + schoolName
                    Case "LTOPrincipals/RequestMoreInterview2.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&PositionID=" + positionID + "&SchoolCode=" + schoolcode + "&SchoolName=" + schoolName
                    Case "LTOPrincipals/InterviewDetails.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&ApplyUserID=" + applyuserID + "&PositionID=" + positionID + "&TeacherName=" + teacherName + "&InterViewS=" + interviewS
                    Case "LTOPrincipals/InterviewDetails2.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&ApplyUserID=" + applyuserID + "&PositionID=" + positionID + "&TeacherName=" + teacherName + "&InterViewS=" + interviewS

                    Case "LTOPrincipals/RequestDetails.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID + "&TeacherName=" + teacherName
                    Case "LTOPrincipals/RequestDetails2.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID
                    Case "LTOPrincipals/RequestPosting.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID
                    Case "LTOPrincipals/PrincipalProcess.aspx"
                        Me.PageURL.HRef = pID
                    Case "LTOPrincipals/InterviewTeam.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&PositionID=" + positionID + "&SchoolCode=" + schoolcode + "&SchoolName=" + schoolName
                    Case "LTOPrincipals/InterviewSignature.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&PositionID=" + positionID + "&SchoolCode=" + schoolcode + "&ApplyUserID=" + applyuserID + "&SchoolName=" + schoolName
                    Case "LTOHRStaffs/PostingSummaryDetails.aspx"
                        Me.PageURL.HRef = pID + "?SchoolYear=" + schoolyear + "&PositionID=" + positionID

                    Case "Close"
                        Me.PageURL.HRef = "LTOHRStaffs/SiteClose.aspx"

                    Case "CloseP"
                        Me.PageURL.HRef = "LTOPrincipals/SiteClose.aspx"
                    Case Else
                        Me.PageURL.HRef = "Loading.aspx"
                End Select

                Dim mypage As String = Me.PageURL.HRef

            Catch ex As Exception
                Dim m As String = ex.Message
            End Try
        End If
    End Sub
    Private Function GetValueFromQS(ByVal key As String) As String
        Return BasePage.GetValueFromQS(Page, key)
    End Function
End Class
