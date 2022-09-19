Imports AppOperate
Imports ClassLibrary
'Imports TCDSB.Student
Partial Class RequestMoreInterview2
    Inherits System.Web.UI.Page
    Dim schoolyear As String
    Dim schoolcode As String
    Dim schoolname As String
    Dim positionID As String
    Dim myRequestPosting As New PositionRequesting()
    Dim interviewParameter As New InterviewResult()
    Dim JsonFile As String = Server.MapPath("..\Content\eMailTemplate.json")
    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Not Session("mytheme") Is Nothing Then
            Me.Theme = Session("mytheme")
        End If
    End Sub
    ' ### setup Page StylesheetTheme
    Public Overrides Property StyleSheetTheme() As String
        Get
            Return Session("mytheme")
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        schoolyear = Page.Request.QueryString("SchoolYear")
        schoolcode = Page.Request.QueryString("SchoolCode")
        schoolname = Page.Request.QueryString("SchoolName")
        positionID = Page.Request.QueryString("PositionID")
        If Not Page.IsPostBack Then
            Page.Response.Expires = 0


            bindData()
        End If
    End Sub

    Private Function getDataSource() As PositionPublish
        Dim userid As String = HttpContext.Current.User.Identity.Name

        Dim parameter = CommonParameter.GetParameters(schoolyear, positionID)
        Dim position = PublishPositionExe(Of PositionPublish).Position(parameter)(0) '  CommonListExecute.PublishPosition(parameter)(0) '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)
        Return position

    End Function
    Private Sub bindData()
        Try

            Dim position = getDataSource() '  SinglePosition.PositionByID(parameter)

            Me.TextPositionID.Value = positionID
            Me.TextSchool.Text = schoolname
            '   Dim ds As DataSet = PositionDetails.DetailbyIDForHRStaffNotice(userid, schoolyear, positionID)
            Me.TextPositionTitle.Text = getMyValue(position.PositionTitle)
            Me.TextStatus.Text = getMyValue(position.PositionState)
            Me.TextPositionDescription.Text = getMyValue(position.Description)
            Me.TextPostionQualification.Text = getMyValue(position.Qualification)
            Me.TextArea.Text = getMyValue(position.SchoolArea)

            Me.TextPostingNum.Text = getMyValue(position.PostingNumber)

            Me.TextApplyEndDate.Text = getMyValue(position.DateApplyClose)
            Me.TextStartDate.Text = getMyValue(position.StartDate)
            Me.TextEndDate.Text = getMyValue(position.EndDate)
            Me.lblFTE.Text = getMyValue(position.FTE)
            Me.lblFTEPanel.Text = getMyValue(position.FTEPanel)

            Me.textHRSTaffName.Text = getMyValue(position.Owner)

            Me.TextPostionLevel.Text = BasePage.getMyValue(position.PositionLevel)
            Me.hfPositionType.Value = getMyValue(position.PositionType)
            Me.TextCandidateCount.Text = getMyValue(position.RequestCount)

            Me.TextType.Text = getMyValue(position.PositionType)
            Me.TextOwner.Text = getMyValue(position.Owner)
            Me.hfUserName.Value = getMyValue(position.Owner)
            Me.TextPostingCycle.Text = getMyValue(position.PostingCycle)
            Me.TextPostingComments.Text = getMyValue(position.Comments)
            Me.TextTeacherReplaced.Text = getMyValue(position.ReplaceTeacher)
            Me.TextTeacherPersonID.Text = getMyValue(position.OtherReason)
            Me.hfPrincipalID.Value = position.PrincipalID


            ViewState("timeTable") = BasePage.getMyValue(position.TimeTable)
            ViewState("multiSchool") = BasePage.getMyValue(position.MultipleSchool)
            If ViewState("timeTable") = "" Then
                Me.F100TimeTable.Visible = False
            Else
                Me.F100TimeTable.InnerHtml = ViewState("timeTable")
                Me.TextPositionDescription.Style.Add("height", "25px")
            End If

            If ViewState("multiSchool") = "" Then
                Me.F100MultipleSchool.Visible = False
            Else
                Me.F100MultipleSchool.InnerHtml = ViewState("multiSchool")
                Me.TextPositionDescription.Style.Add("height", "25px")
            End If



            Dim teacherList As String = getTeacherList()
            Me.interviewCandidate.InnerHtml = teacherList
            CheckRequestSchool()
        Catch ex As Exception
            Dim em As String = ex.StackTrace
        End Try
    End Sub
    Private Sub CheckRequestSchool()
        '  Dim RequestSchool = PositionDetails.RequestSchool(schoolyear, schoolcode, positionID)

        With myRequestPosting
            .Operate = "RequestSchool"
            .UserID = HttpContext.Current.User.Identity.Name
            .SchoolYear = schoolyear
            .SchoolCode = schoolcode
            .PositionID = positionID



        End With

        Dim RequestSchool = RequestPostingExe.RequestSchool(myRequestPosting) 'InterviewProcessExe.CommonOperationExcute.RequestOperation(myRequestPosting, "RequestSchool") ' RequestingPostExe.RequestPositionAttribute(myRequestPosting, _positionID)



        'Dim parameter = CommonParameter.GetParameters(schoolyear, positionID)
        'Dim position As PositionInfo = CommonListExecute.PublishPositionInfo(parameter)(0) '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)
        'Dim RequestSchool As String = position.SchoolName

        If schoolcode = Left(RequestSchool, 4) Then
            LabelNeedInterview.Visible = False

            With interviewParameter
                .Operate = "InterviewCount"
                .UserID = HttpContext.Current.User.Identity.Name
                .SchoolYear = schoolyear
                .PositionID = positionID
            End With

            Dim needInterviewCount = InterviewProcessExe.InterviewCount(interviewParameter) '   CommonOperationExcute.InterviewOperation(interviewParameter, "InterviewCount") ' PostingInterviewExc.CheckInterviewCount(interviewParameter, _positionID) ', sitionDetails.InterviewCandidateCount(userid, cpnum, _schoolyear, _positionID)

            If Not needInterviewCount = "0" Then
                btnApply.Enabled = False
                LabelNeedInterview.Visible = True
                LabelNeedInterview.Text = needInterviewCount + " " + LabelNeedInterview.Text
            End If



        Else
            btnApply.Enabled = False
            btnCancel.Enabled = True
            TextCandidateCount.Enabled = False

            LabelNeedInterview.Visible = False
            Label1.Text = "Position Posting Request by " + RequestSchool
        End If



    End Sub

    Private Function getTeacherList() As String
        'Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        'Dim positionID As String = Page.Request.QueryString("PositionID")
        'Dim userid As String = HttpContext.Current.User.Identity.Name

        'Dim ds As DataSet = PositionDetails.NoticeToHRStaffForMoreInterviewCandidate(userid, schoolyear, positionID)

        '  Dim parameter = CommonParameter.GetParameters(schoolyear, positionID)



        Dim parameter As New PositionPublish()
        With parameter
            .Operate = "MoreInterviewCandidate"
            .SchoolYear = schoolyear
            .PositionID = positionID
            .PositionType = Me.hfPositionType.Value
        End With


        Dim teacherList As List(Of CandidateListNotice) = SelectCandidateExe.NoticeCandidates(parameter) ' SelectCandidateExe.NoticeCandidates(parameter) ' CommonListExecute.NoticeInterviewCandidate(parameter) '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)



        Dim mySTR As String = ""
        If IsNothing(teacherList) AndAlso teacherList.Count = 0 Then
            mySTR = "<H3> No selected interview candidate yet ! </H3> "
        Else
            mySTR = "<table border='1' ><tr><td>Teacher Name</td><td>Phone Number</td> <td>Email</td><td>Hired Date</td><td>Outcome</td></tr>"
            Try
                For Each item In teacherList
                    Dim sName As String = item.TeacherName
                    Dim Phone As String = item.CellPhone
                    Dim Email As String = item.Email
                    Dim HiredDate As String = item.HiredDate
                    Dim OutCome As String = item.OutCome
                    Dim rStr As String = "<tr><td>" + sName + "</td><td>" + Phone + "</td> <td>" + Email + "</td><td>" + HiredDate + "</td><td>" + OutCome + "</td></tr>"
                    mySTR = mySTR + rStr
                Next
                mySTR = mySTR + "</table>"

            Catch ex As Exception
                Return ""
            End Try
        End If

        Return mySTR
    End Function
    Private Function getMyValue(ByVal _value As Object) As Object
        Try
            If _value = Nothing Then

            End If
            Return _value
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private Function getMyValueC(ByVal _value As Object) As Object
        Try
            If _value = Nothing Or _value = "" Then
                _value = 0
            End If
            Return _value
        Catch ex As Exception
            Return 0
        End Try
    End Function



    Protected Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click

        Dim action As String = "MoreInterview"
        Dim parameter As New InterviewNotice()
        With parameter
            .Operate = "Request More Interview"
            .SchoolYear = schoolyear
            .PositionID = positionID
            .UserID = User.Identity.Name
            .RequestCount = Me.TextCandidateCount.Text
            .PrincipalID = Me.hfPrincipalID.Value
        End With
        Dim _result As String = InterviewProcessExe.RequestMoreInterview(parameter) '  CommonOperationExcute.InterviewNotice(pamameter, "Request More Interview") ' PositionDetails.NoticeToHRStaffForMoreInterviewCandidate(userid, schoolyear, positionID, CountAskFor)
        CreatSaveMessage(_result, "Sent request more interview candidate email to HR staff")
        sendemailNotification(action)
    End Sub
    Private Sub CreatSaveMessage(ByVal strMessage As String, ByVal action As String)
        Try
            Dim positionTitle As String = Me.TextPositionTitle.Text
            '  action = Me.btnApply.Text ' "Cancel" Then action = "Withdraw "
            '  Dim strScript As String = "window.alert(" + """" + action + " " + positionTitle + " position is " + strMessage + ", and a confirmation email has been sent to you. " + """);"
            Dim _fun As String = "CallParentPostBack(" + "'" + action + "','" + positionTitle + "','" + strMessage + "')"
            '  CloseMeandBack(action, positionTitle, strMessage)
            '   window.alert(action + " this position is " + resutl);
            '  ***  No Ajax
            Dim strScript As String = "<script  type='text/jscript'> " & _fun & "  </script> "
            ClientScript.RegisterStartupScript(GetType(String), "_script", strScript)



        Catch ex As Exception

        End Try

    End Sub
    Private Sub sendemailNotification(ByVal action As String)



        Dim userID As String = User.Identity.Name
        Dim position = CurrentPosition()
        Dim email = New EmailNotification(position)

        Dim myEmail As New EmailNotice2()

        myEmail = email.GetEmailNotice(JsonFile, action, "Staff", userID)
        myEmail.EmailBody = GetEmailBody(action, myEmail.EmailBody)
        email.SMTPMailCall("Staff", myEmail)

    End Sub

    'Private Sub SMTPMailCall(ByVal who As String, ByVal myEmail As EmailNotice2)

    '    Try

    '        Dim emailNotice = New EmailNotification()

    '        Dim logId As String = emailNotice.SaveEmailNotice(myEmail)
    '        Dim result = emailNotice.SendEmail(myEmail)

    '    Catch ex As Exception

    '    End Try

    'End Sub
    Private Function GetEmailBody(ByVal _who As String, ByVal _mBodyTemplateFile As String) As String



        ' Dim sDate As DateTime = Now()
        Dim _Datetime As String = DateFC.YMDHMS(Now())
        Dim schoolcode As String = Page.Request.QueryString("SchoolCode")

        Dim _interviewCount As String = Me.TextCandidateCount.Text

        Dim myHTML As String = Server.MapPath("..") + "\Template\" + _mBodyTemplateFile
        Dim eMailFile As String = EmailNotification.EmailHTMLBody(myHTML)

        Try

            eMailFile = Replace(eMailFile, "[PostingNumberSTR]", Me.TextPostingNum.Text)
            eMailFile = Replace(eMailFile, "[HRStaffNameSTR]", Me.textHRSTaffName.Text)
            eMailFile = Replace(eMailFile, "[UserNameSTR]", WorkingProfile.UserName)
            eMailFile = Replace(eMailFile, "[InterviewCountSTR]", _interviewCount)
            eMailFile = Replace(eMailFile, "[DateTimeSTR]", _Datetime)
            eMailFile = Replace(eMailFile, "[SchoolNameSTR]", WorkingProfile.SchoolName)
            eMailFile = Replace(eMailFile, "[PositionTitleSTR]", TextPositionTitle.Text)
            eMailFile = Replace(eMailFile, "[PositionStartDateSTR]", Me.TextStartDate.Text)
            eMailFile = Replace(eMailFile, "[PositionEndDateSTR]", Me.TextEndDate.Text)
            eMailFile = Replace(eMailFile, "[TeacherBeReplacedSTR]", Me.TextTeacherReplaced.Text)
            eMailFile = Replace(eMailFile, "[PIDSTR]", Me.TextTeacherPersonID.Text)
            eMailFile = Replace(eMailFile, "[BTCSTR]", Me.lblFTE.Text)
            eMailFile = Replace(eMailFile, "[PostingCycleSTR]", Me.TextPostingCycle.Text)

            eMailFile = Replace(eMailFile, "[timeTable]", ViewState("timeTable"))
            eMailFile = Replace(eMailFile, "[multiSchool]", ViewState("multiSchool"))

            If Me.TextPostingComments.Text = "" Then
                eMailFile = Replace(eMailFile, "[PositionDescriptionSTR]", Me.TextPositionDescription.Text + "  (" + Me.TextPostingCycle.Text + " posting)")
            Else

                eMailFile = Replace(eMailFile, "[PositionDescriptionSTR]", Me.TextPositionDescription.Text + " ; " + Me.TextPostingComments.Text + "  (" + Me.TextPostingCycle.Text + " posting)")
            End If

            Dim interviewNotsuitable As String = "" ' PositionDetails.NoticeToHRStaffInterviewNotSuitable(schoolyear, schoolcode, PositionID)



            eMailFile = Replace(eMailFile, "[NotSuitableSelectedSTR]", interviewNotsuitable)


            eMailFile = Replace(eMailFile, "[InterviewCandidateListSTR]", Me.interviewCandidate.InnerHtml)


        Catch ex As Exception
            eMailFile = ""
        End Try
        Return eMailFile

    End Function
    Private Function CurrentPosition() As PositionPublish

        Dim position = New PositionPublish()
        With position
            .UserID = User.Identity.Name
            .SchoolYear = schoolyear
            .DatePublish = ""
            .DateApplyOpen = ""
            .DateApplyClose = ""
            .PositionID = positionID
            .PositionTitle = TextPositionTitle.Text
            .Owner = Me.TextOwner.Text
            .PositionType = Me.hfPositionType.Value
            .PostingCycle = Me.TextPostingCycle.Text

        End With

        Return position
    End Function

End Class
