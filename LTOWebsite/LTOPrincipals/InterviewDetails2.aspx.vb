'Imports System.Data
'Imports System.Data.SqlClient
Imports System.IO
Imports AppOperate
Imports ClassLibrary
'Imports TCDSB.Student

Partial Class InterviewDetails2
    Inherits System.Web.UI.Page

    Dim RequestSchool As String
    Dim myRequestPosting As New PositionRequesting
    Dim interviewParameter As New InterviewResult()

    Dim _schoolyear As String
    Dim _schoolcode As String
    Dim _positionID As String
    Dim _appType As String
    Dim _cpnum As String
    Dim _InterViewS As String
    Dim cPage As String = "Interview"
    Dim SPFile As String = SPSource.SPFile() '  WebConfigValue.SPFile() 
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
        _schoolyear = Page.Request.QueryString("SchoolYear")
        _cpnum = Page.Request.QueryString("ApplyUserID")
        _positionID = Page.Request.QueryString("PositionID")
        _InterViewS = Page.Request.QueryString("InterViewS")
        _schoolcode = WorkingProfile.SchoolCode

        If Not Page.IsPostBack Then
            Me.Page.Response.Expires = 0
            Me.btnSaveRecommendation.Enabled = False

            BindDDL()
            BindData()
            checkPositionCompleteHireProcess()
            checkInterviewCandidateComplate()
            CheckAllCandidateSignatureComplate()
        End If
    End Sub
    Private Sub BindDDL()
        Dim parameter As New List2Item()
        With parameter
            .Operate = "InterviewProcess"
            .Para0 = WorkingProfile.SchoolYear
            .Para1 = WorkingProfile.SchoolCode
            .Para2 = WorkingProfile.ApplicationType
        End With
        AssemblingList.SetLists("", ddlAction, "InterviewProcess", parameter)
    End Sub
    Private Function GetInterviewDataSource() As PositionInterview
        _schoolcode = WorkingProfile.SchoolCode
        Me.hfPositionID.Value = _positionID
        Me.hfUserCPNum.Value = _cpnum
        Me.hfSchoolyear.Value = _schoolyear

        Dim parameter = CommonParameter.GetParameters(_schoolyear, _positionID, _cpnum)
        '   Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "Candidate") ' CommonListExecute(Of PositionInterview).ObjSP("PositionInterview")
        Dim interview = InterviewProcessExe.Candidate(parameter) '  CommonExcute(Of PositionInterview).GeneralList(SP, parameter)(0) ' CommonListExecute.InterviewCandidate(parameter)(0)
        ' Dim interview2 = CommonListExecute(Of PositionInterview).GeneralPosition(parameter)(0)

        If User.Identity.Name = "mif" Then
            '   Dim SP1 As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "Recommend") ' CommonOperationExcute(Of InterviewResult).ObjSP("InterviewResult", "Recommend")
            Me.lblPostingNumber.ToolTip = InterviewProcessExe.SpName("Candidate")
            Me.btnSave.ToolTip = InterviewProcessExe.SpName("Recommend")

        End If

        Return interview(0)

    End Function
    Private Sub BindData()
        Try
            ' Dim userid As String = HttpContext.Current.User.Identity.Name
            '  Dim InterviewS As String = Page.Request.QueryString("interviewS")

            Dim position = GetInterviewDataSource()


            Me.txtPostingNumber.Text = BasePage.getMyValue(position.PostingNumber)
            Me.hfIDs.Value = BasePage.getMyValue(position.ApplyID)
            Me.TextName.Text = BasePage.getMyValue(position.TeacherName) ' TeacherName
            Me.TextHireDate.Text = BasePage.getMyValue(position.DateHired)
            Me.hfSchoolname.Value = BasePage.getMyValue(position.SchoolName)
            Me.hfPrincipalName.Value = BasePage.getMyValue(position.PrincipalName)

            Me.TextPositionTitle.Text = BasePage.getMyValue(position.PositionTitle)
            Me.TextPostionLevel.Text = BasePage.getMyValue(position.PositionLevel)
            Me.TextDescription.Text = BasePage.getMyValue(position.Description)
            Me.TextComments.Text = BasePage.getMyValue(position.Comments)
            Me.TextQualification.Text = BasePage.getMyValue(position.Qualification)

            Me.TextApplicantQulification.Text = BasePage.getMyValue(position.OCTQualification)
            Me.TextAppraisals.InnerHtml = BasePage.getMyValue(position.Appraisal)
            Me.TextRecomendation.Text = BasePage.getMyValue(position.Recommendation)
            Me.dateInterview.Value = BasePage.getMyValue(position.InterviewDate)
            Me.chbHiring.Checked = IIf(BasePage.getMyValue(position.HiringStatus = "Recommend for Hiring on the Position"), True, False)
            AssemblingList.SetValue(ddlAction, BasePage.getMyValue(position.OutCome))

            Me.dateEffective.Value = BasePage.getMyValue(position.EffectiveDate)

            AssemblingList.SetValue(rblFTE, ConvertFTE(BasePage.getMyValue(position.FTE)))
            Me.lblPositionFTE.Text = BasePage.getMyValue(position.FTE)
            Me.lblFTEPanel.Text = BasePage.getMyValue(position.FTEPanel)
            Me.HiredMessage.Text = BasePage.getMyValue(position.CurrentPositionInfo)

            Me.hfHiredStatus.Value = BasePage.getMyValue(position.HiredStatus)
            Me.LabelAssignStartDate.Text = BasePage.getMyValue(position.StartDate)
            Me.LabelAssignEndDate.Text = BasePage.getMyValue(position.EndDate)
            Me.LabelPositionTitleC.Text = BasePage.getMyValue(position.PositionTitle)
            Me.LabelPositionSchoolC.Text = BasePage.getMyValue(position.SchoolName)
            Me.LabelPositionStartDateC.Text = BasePage.getMyValue(position.StartDate)
            Me.LabelPositionEndDateC.Text = BasePage.getMyValue(position.EndDate)
            Me.LabelPositionFTEC.Text = BasePage.getMyValue(position.FTE)
            Me.LabelPositionTypeC.Text = BasePage.getMyValue(position.PositionType)

            Me.LabelPositionTitleH.Text = BasePage.getMyValue(position.CurrentAssignment)
            Me.LabelPositionSchoolH.Text = BasePage.getMyValue(position.CurrentSchool)
            Me.LabelPositionStartDateH.Text = BasePage.getMyValue(position.CurrentStartDate)
            Me.LabelPositionEndDateH.Text = BasePage.getMyValue(position.CurrentEndDate)
            Me.LabelPositionFTEH.Text = BasePage.getMyValue(position.CurrentFTE)
            Me.LabelPositionTypeH.Text = BasePage.getMyValue(position.CurrentPositionType)

            Me.hfnewPositionStartDate.Value = BasePage.getMyValue(position.NewPositionStartDate)
            Me.hfTeacherUserID.Value = BasePage.getMyValue(position.CPNum)
            Me.hfHROwnerUserID.Value = BasePage.getMyValue(position.Owner)
            Me.hfHiringtatus.Value = BasePage.getMyValue(position.HiringStatus)
            Me.hfDatePublish.Value = BasePage.getMyValue(position.DatePublish)

            Me.TextPostedDate.Text = BasePage.getMyValue(position.DatePublish)
            Me.lblPostingCycle.Text = BasePage.getMyValue(position.PostingCycle)
            Me.TextPostingComments.Text = BasePage.getMyValue(position.PostedComments)
            Me.LabelStartDate.Text = Me.LabelPositionTypeC.Text + " Start Date:"

            If BasePage.getMyValue(position.SignOffResult) = "Sign Off Complete" Then
                Me.chbSignatureSignOff.Checked = True
                Me.chbSignatureSignOff.Text = "Interviewer and Candidate have signed off on H.M. 40 Document"
            Else
                Me.chbSignatureSignOff.Checked = False
                Me.chbSignatureSignOff.Text = "Interviewer and Candidate have not signed off on H.M. 40 Document"
            End If

            LabelAppType.Text = Me.LabelPositionTypeC.Text
            LabelResume.InnerHtml = position.Resume
            LabelCoverLetter.InnerHtml = position.CoverLetter

            If Me.HiredMessage.Text <> "" Then
                HiredMessageRow.Visible = True
                Me.HiredMessage.Visible = True
                Me.HiredAlert.Visible = True

            End If
            If Me.chbHiring.Checked Then
                Me.btnSaveRecommendation.Text = "Revoke Recommendation for Hire"
                Me.btnSaveRecommendation.Enabled = True
            Else
                Me.btnSaveRecommendation.Enabled = False

                ' checkRecommentbuttonbyEffectivedate()
            End If
            'If InterviewS = "Interview" Then
            '    Me.btnSaveRecommendation.Visible = False
            'Else
            '    Me.btnSaveRecommendation.Visible = True
            'End If

            CheckRequestSchool()

        Catch ex As Exception

        End Try
    End Sub
    Private Function ConvertFTE(ByVal value As Object) As String
        Dim fte As Integer = value * 100
        Return fte.ToString()
    End Function
    Private Sub CheckRequestSchool()
        With myRequestPosting
            .Operate = "RequestSchool"
            .UserID = HttpContext.Current.User.Identity.Name
            .SchoolYear = _schoolyear
            .SchoolCode = _schoolcode
            .PositionID = _positionID
        End With

        RequestSchool = RequestPostingExe.RequestSchool(myRequestPosting) ' .CommonOperationExcute.RequestOperation(myRequestPosting, "RequestSchool") ' RequestingPostExe.RequestPositionAttribute(myRequestPosting, _positionID)

        If Not _schoolcode = Left(RequestSchool, 4) Then
            btnSave.Enabled = False
            btnSaveRecommendation.Enabled = False
            chbHiring.Enabled = False
            ddlAction.Enabled = False
            Label1.Visible = True
            Label1.Text = "Only " + RequestSchool + " implements an interview process. "
            lblInterviewCount.Visible = False
            btnCancel.Enabled = False
        End If
    End Sub
    Private Sub checkRecommentbuttonbyEffectivedate()
        Me.btnSaveRecommendation.Enabled = False
        If Me.hfHiredStatus.Value = "Yes" Then
            Me.btnSaveRecommendation.Enabled = False
        Else
            Try
                If Me.LabelPositionTypeC.Text = "POP" Then
                    Me.chbHiring.Enabled = True
                    Me.btnSaveRecommendation.Enabled = True
                Else
                    If CType(Me.LabelPositionFTEC.Text, Decimal) + CType(Me.LabelPositionFTEH.Text, Decimal) > 1.0 Then
                        Dim newPositionStartDate As Date = CType(Me.hfnewPositionStartDate.Value, Date)
                        Dim effectiveDate As Date = CType(Me.dateEffective.Value, Date)
                        Dim previousPostionDateEnd As Date = CType(Me.LabelPositionEndDateH.Text, Date)

                        If (newPositionStartDate >= previousPostionDateEnd) Or (effectiveDate >= previousPostionDateEnd) Then

                            Me.chbHiring.Enabled = True
                            Me.btnSaveRecommendation.Enabled = True
                        Else
                            Me.chbHiring.Enabled = False
                        End If

                    Else
                        Me.chbHiring.Enabled = True
                        Me.btnSaveRecommendation.Enabled = True
                    End If
                End If

            Catch ex As Exception
                Dim em As String = ex.Message
            End Try


        End If
    End Sub
    Private Sub checkInterviewCandidateComplate()
        '  Dim InterviewS As String = Page.Request.QueryString("interviewS")

        '  Me.RequiredFieldValidator2.Enabled = False

        If Not (lblPositionStatus.Text = "Hired" Or lblPositionStatus.Text = "Recommend" Or lblPositionStatus.Text = "End") Then

            With interviewParameter
                .Operate = "InterviewCount"
                .UserID = HttpContext.Current.User.Identity.Name
                .SchoolYear = _schoolyear
                .PositionID = _positionID
            End With

            Me.lblInterviewCount.Text = InterviewProcessExe.InterviewCount(interviewParameter) '  CommonOperationExcute.InterviewOperation(interviewParameter, "InterviewCount") ' PostingInterviewExc.CheckInterviewCount(interviewParameter, _positionID) ', sitionDetails.InterviewCandidateCount(userid, cpnum, _schoolyear, _positionID)

            If Me.lblInterviewCount.Text = "0" Then
                If Me.ddlAction.SelectedItem.Text = "Interviewed" Then
                    Me.chbHiring.Enabled = True
                    Me.btnSaveRecommendation.Enabled = True
                    Me.chbHiring.Checked = True
                    '  Me.RequiredFieldValidator2.Enabled = True
                Else
                    Me.chbHiring.Enabled = False
                    Me.btnSaveRecommendation.Enabled = False

                End If
            Else
                Me.chbHiring.Enabled = False
                Me.btnSaveRecommendation.Enabled = False
            End If
        End If

        If Me.btnSaveRecommendation.Enabled = True Then
            If Not Me.chbSignatureSignOff.Checked Then
                Me.btnSaveRecommendation.Enabled = False
            End If
        End If

    End Sub
    Private Sub CheckAllCandidateSignatureComplate()
        interviewParameter.Operate = "SignOffCount"
        '  Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "SignOffCount")
        Dim remaindSignaturee As Integer = InterviewProcessExe.SignOffCount(interviewParameter) ' CommonExcute(Of InterviewResult).GeneralValue(SP, interviewParameter) ' CommonOperationExcute.InterviewOperation(interviewParameter, "SignOffCount")  ' PostingInterviewExc.CheckInterviewCount(interviewParameter, _positionID) ' PositionDetails.remaindSignOffCount(userid, cpnum, _schoolyear, _schoolcode, _positionID)
        Me.lblSignatureCount.Text = remaindSignaturee

        If Me.btnSaveRecommendation.Enabled = True Then
            If remaindSignaturee = "0" Then
                Me.btnSaveRecommendation.Enabled = True
                Label2.Visible = False
            Else
                Me.btnSaveRecommendation.Enabled = False
                Label2.Visible = True
            End If
        End If

    End Sub
    Private Sub checkPositionCompleteHireProcess()
        Try
            Dim action As String = "PositionHiringStatus"
            With interviewParameter
                .Operate = action
                .UserID = HttpContext.Current.User.Identity.Name
                .SchoolYear = _schoolyear
                .PositionID = _positionID
                .CPNum = _cpnum
            End With
            '   Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, action)
            lblPositionStatus.Text = InterviewProcessExe.PositionHiringStatus(interviewParameter) ' CommonOperationExcute.InterviewOperation(interviewParameter, "PositionHiringStatus")   '  PostingInterviewExc.CheckHiringProcessStatus(interviewParameter, _positionID) '  PositionDetails.InterviewCandidatePosition(UserID, cpnum, _schoolyear, _positionID)

            If lblPositionStatus.Text = "End" Or lblPositionStatus.Text = "Hired" Then
                btnSaveRecommendation.Enabled = False
                btnSave.Enabled = False
                chbHiring.Enabled = False
                ddlAction.Enabled = False
                dateInterview.Disabled = True
                dateEffective.Disabled = True
            ElseIf lblPositionStatus.Text = "Recommend" Then
                chbHiring.Enabled = False
                dateInterview.Disabled = True
                dateEffective.Disabled = True
            End If


        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSaveRecommendation_Click(sender As Object, e As EventArgs) Handles btnSaveRecommendation.Click
        Me.HiddenFieldAction.Value = "Yes"
        Dim acceptHiring As String = "1"
        If Me.btnSaveRecommendation.Text = "Revoke Recommendation for Hire" Then acceptHiring = "0"

        With interviewParameter
            .Operate = "Recommend"
            .Recommendation = Me.TextRecomendation.Text
            .InterviewDate = DateFC.YMD2(Me.dateInterview.Value)
            .EffectiveDate = DateFC.YMD2(Me.dateEffective.Value)
            .OutCome = Me.ddlAction.SelectedValue
            .Acceptance = acceptHiring
            .PositionID = _positionID
            .SchoolYear = _schoolyear
            .UserID = HttpContext.Current.User.Identity.Name
            .CPNum = _cpnum
        End With

        ' Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "Recommend")
        ' Dim _result As String = PostingInterviewExc.RecommendHire(interviewParameter, _positionID) '  PositionDetails.RecommandforHiring(userid, schoolyear, positionID, cpnum, recommendation, dateinterview, dateEffective, acceptHiring, interviewProcess)
        '  Dim _result As String = CommonExcute(Of InterviewResult).GeneralValue(SP, interviewParameter) ' CommonOperationExcute.InterviewOperation(interviewParameter, "Recommend")
        Dim _result As String = InterviewProcessExe.Recommend(interviewParameter)
        Dim message As String = Me.btnSaveRecommendation.Text ' IIf(Me.chbHiring.Checked, "Recommendation", "Revoke Recommendation")
        CreateSaveMessage(_result, message)
        '' ** no emaill notification required for Principal to HR 
        If WebConfigValue.getValuebyKey("PrincipalEmailNotice") = "Yes" Then
            Dim action As String = Left(Me.btnSaveRecommendation.Text, 9)
            sendemailNotification(action)
        End If


    End Sub
    Private Sub CreateSaveMessage(ByVal strMessage As String, ByVal action As String)
        Try
            '  action = Me.btnSaveRecommendation.Text
            '  Dim strScript As String = "window.alert(" + """" + action + " " + " " + strMessage + """);"
            Dim strScript As String = "CallBackReloadParent(" + "'" + action + "','" + strMessage + "')"


            '   window.alert(action + " this position is " + resutl);
            '  ***  No Ajax
            ClientScript.RegisterStartupScript(GetType(String), "_savemessagescript", strScript, True)

            '  *** AJAX Save Message
            '   ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType, "save_script", strScript.ToString(), True)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub sendemailNotification(ByVal action As String)
        Dim _mTo As String = Me.hfHROwnerUserID.Value + "@TCDSB.ORG"
        Dim _mCC As String = Me.hfTeacherUserID.Value + "@TCDSB.ORG"
        Dim _mFrom As String = EmailNotification.UserProfileByID("TCDSBeMailAddress", HttpContext.Current.User.Identity.Name)
        Dim JsonFile As String = Server.MapPath("..\Content\eMailTemplate.json")
        Dim mEmailTemplate = EmailNotification.EmailSubjectAndTemple(JsonFile, WorkingProfile.ApplicationType, action)
        Dim mSubject As String = mEmailTemplate.Subject  ' EmailNotification.Subject(JsonFile, WorkingProfile.ApplicationType, "Posting")
        Dim mBody = mEmailTemplate.Template '  EmailNotification.Template(JsonFile, WorkingProfile.ApplicationType, "Posting")


        SMTPMailCall(action, _mTo, _mCC, _mFrom, mSubject, mBody)
    End Sub

    Private Sub SMTPMailCall(ByVal eMailAction As String, ByVal _mTO As String, ByVal _mCC As String, ByVal _mFrom As String, ByVal mSubject As String, ByVal mBodyTemplate As String)
        Dim _AditionInfo As String = ""



        Dim _mBcc As String = WebConfigValue.getValuebyKey("eMailBCC")
        Try
            Dim eMailFile As String = getEmailfileHTML(eMailAction, mBodyTemplate)
            Dim myEmail As New EmailNotice2()
            With myEmail
                .UserID = User.Identity.Name
                .SchoolYear = hfSchoolyear.Value
                .SchoolCode = WorkingProfile.SchoolCode
                .PositionType = WorkingProfile.ApplicationType
                .PositionID = hfIDs.Value
                .PositionTitle = Me.TextPositionTitle.Text
                .PostingNum = Me.txtPostingNumber.Text
                .NoticePrincipal = Me.hfPrincipalName.Value
                .NoticeFor = "Staff"           ' ' _who
                .EmailType = eMailAction
                .EmailTo = _mTO
                .EmailCC = _mCC
                .EmailBcc = _mBcc
                .EmailFrom = _mFrom
                .EmailSubject = mSubject
                .EmailBody = eMailFile
                .EmailFormat = "HTML"
                .Attachment1 = ""
                .Attachment2 = ""
                .Attachment3 = ""
            End With

            EmailNotification.SendEmail(myEmail) '

            '  EmailNotification.SendMail(eMailFile, _mTO, _mCC, _mBcc, _mFrom, _mSubject, "HTML", "Interview List", WorkingProfile.UserRole, Me.hfPositionID.Value)

            ' Dim myAttchment As String = Server.MapPath(".") + "\EmailTemplate\Staff Assignment Information Form.pdf"
            ' EmailNotification.SendMail(eMailFile, _mTO, _mCC, _mBcc, _mFrom, _mSubject, "HTML", myAttchment)
        Catch ex As Exception

        End Try
    End Sub
    Private Function getEmailfileHTML(ByVal who As String, ByVal mBodyTemplate As String) As String



        Dim sDate As DateTime = Now()
        Dim _Datetime As String = sDate.ToString
        'If eMailAction = "Revoke" Then
        '    myHTML = Server.MapPath("..") + "\Template\ConfirmHiringNotificationRevoke.htm"
        'Else
        '    myHTML = Server.MapPath("..") + "\Template\ConfirmHiringNotification.htm"
        'End If

        Dim myHTML As String = Server.MapPath("..") + "\Template\" + mBodyTemplate
        Dim eMailFile As String = EmailNotification.EmailHTMLBody(myHTML)


        Try


            eMailFile = Replace(eMailFile, "[TeacherNameSTR]", Me.TextName.Text)
            eMailFile = Replace(eMailFile, "[PrincipalNameSTR]", Me.hfPrincipalName.Value)
            eMailFile = Replace(eMailFile, "[DateTimeSTR]", _Datetime)
            eMailFile = Replace(eMailFile, "[SchoolNameSTR]", Me.hfSchoolname.Value)
            eMailFile = Replace(eMailFile, "[PositionTitleSTR]", Me.TextPositionTitle.Text)


            If Me.TextPostingComments.Text = "" Then
                eMailFile = Replace(eMailFile, "[PositionDescriptionSTR]", Me.TextDescription.Text)
            Else
                eMailFile = Replace(eMailFile, "[PositionDescriptionSTR]", Me.TextDescription.Text + " ; " + Me.TextPostingComments.Text)
            End If

            eMailFile = Replace(eMailFile, "[PositionPostedSTR]", Me.TextPostedDate.Text + " (" + Me.lblPostingCycle.Text + ")")

        Catch ex As Exception
            eMailFile = ""
        End Try
        Return eMailFile

    End Function

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click


        With interviewParameter
            .Operate = "Update"
            .Recommendation = Me.TextRecomendation.Text
            .InterviewDate = DateFC.YMD2(Me.dateInterview.Value)
            .EffectiveDate = DateFC.YMD2(Me.dateEffective.Value)
            .OutCome = Me.ddlAction.SelectedValue
            .Acceptance = IIf(Me.chbHiring.Checked, "1", "0")
            .CPNum = _cpnum
            .PositionID = _positionID
            .SchoolYear = _schoolyear
            .UserID = HttpContext.Current.User.Identity.Name
        End With
        ' Dim _result As String = CommonOperationExcute(Of InterviewResult).CommonOperation(interviewParameter, "Update") '  .PostingInterviewExc.SaveInterview(interviewParameter, _positionID) '  PositionDetails.InterviewUpdate(userid, schoolyear, positionID, cpnum, recommendation, dateInterview, dateEffective, interviewProcess, acceptHiring)
        Dim _result As String = InterviewProcessExe.Update(interviewParameter) ' CommonOperationExcute.InterviewOperation(interviewParameter, "Update") '  .PostingInterviewExc.SaveInterview(interviewParameter, _positionID) '  PositionDetails.InterviewUpdate(userid, schoolyear, positionID, cpnum, recommendation, dateInterview, dateEffective, interviewProcess, acceptHiring)


        Dim message As String = "Save"
        If Me.lblInterviewCount.Text > 1 Then
            CreateSaveMessage(_result, message)
            ' Me.RequiredFieldValidator2.Enabled = False

        Else
            checkInterviewCandidateComplate()
        End If
    End Sub

    Protected Sub chbHiring_CheckedChanged(sender As Object, e As EventArgs) Handles chbHiring.CheckedChanged
        If chbHiring.Checked Then

            Me.btnSaveRecommendation.Enabled = True
            AssemblingList.SetValue(Me.ddlAction, "0")
            ' ListInitial.DDL(Me.ddlAction, "0")
        Else
            Me.btnSaveRecommendation.Enabled = False
        End If
    End Sub

    Private Sub ddlAction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAction.SelectedIndexChanged
        If Me.lblInterviewCount.Text = 1 Then
            Me.ddlAction.SelectedItem.Text = "Interviewed"
            Me.btnSaveRecommendation.Enabled = True
            '   Me.RequiredFieldValidator2.Enabled = True
            '  btnSave_Click(Me.btnSave, e)
        Else
            Me.btnSaveRecommendation.Enabled = False
        End If
    End Sub

    Private Sub chbSignatureSignOff_CheckedChanged(sender As Object, e As EventArgs) Handles chbSignatureSignOff.CheckedChanged

        With interviewParameter
            .Operate = "SignOffAction"
            .UserID = HttpContext.Current.User.Identity.Name
            .SchoolYear = _schoolyear
            .PositionID = _positionID
            .CPNum = _cpnum
        End With


        '   Dim _result As String = PostingInterviewExc.InterviewSignOffAction(interviewParameter, _positionID) '  PositionDetails.InterviewUpdateSignOff(userid, _schoolyear, _positionID, cpnum)
        Dim _result As String = CommonOperationExcute.InterviewOperation(interviewParameter, "SignOffAction") '  .PostingInterviewExc.SaveInterview(interviewParameter, _positionID) '  PositionDetails.InterviewUpdate(userid, schoolyear, positionID, cpnum, recommendation, dateInterview, dateEffective, interviewProcess, acceptHiring)

        Dim message As String = "Save"

        CreateSaveMessage(_result, message)


    End Sub
End Class

