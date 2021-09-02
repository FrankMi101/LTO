'Imports System.Data
'Imports System.Data.SqlClient
Imports System.IO
Imports AppOperate
Imports ClassLibrary
'Imports TCDSB.Student

Partial Class HiredDetails2
    Inherits System.Web.UI.Page
    Dim JsonFile As String = Server.MapPath("..\Content\eMailTemplate.json")
    Dim DataAccessFile As String = ""  'Server.MapPath("..\Content\DataAccess.json")
    Dim cPage As String = "PositionHired"
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
        If Not Page.IsPostBack Then
            Page.Response.Expires = 0
            Dim userid As String = HttpContext.Current.User.Identity.Name
            Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
            '  setStartandEndDate()
            LoadMyData()

        End If
    End Sub
    'Private Sub setStartandEndDate()
    '    Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
    '    Dim parameter As New LimitDate()
    '    With parameter
    '        .Operate = "GetDefault"
    '        .PositionType = WorkingProfile.ApplicationType
    '        .SchoolYear = schoolyear
    '    End With
    '    Dim myDate As New List(Of LimitDate)

    '    myDate = CommonListExecute.LimitedDate(parameter) ' PostingPublishExe.LimitedDate(parameter) ' PositionPublished.LimitedDate(parameter)

    '    Me.hfSchoolyearStartDate.Value = myDate(0).StartDate
    '    Me.hfSchoolyearEndDate.Value = myDate(0).EndDate

    'End Sub
    Private Sub LoadMyData()
        Try

            Me.btnSaveHired.Text = "Revoke Confirm Hire"
            Me.btnSaveHired.ForeColor = Drawing.Color.Red


            Dim position = getDataSource() '  SinglePosition.PositionByID(parameter)


            Dim userid As String = HttpContext.Current.User.Identity.Name
            Me.lblPostingNum.Text = BasePage.getMyValue(position.PostingNumber) ' PositionDetails.PostingNumber(userid, schoolyear, positionID)

            '   Me.TextPositionID.Text = positionID
            'Me.TextSchool.Text = WorkingProfile.SchoolName
            '  Dim ds As DataSet = PositionDetails.HiringCandidateProfile(userid, cpnum, schoolyear, positionID)
            Me.hfIDs.Value = BasePage.getMyValue(position.PositionID)
            Me.TextName.Text = BasePage.getMyValue(position.TeacherName) ' TeacherName
            Me.dateHire.Text = BasePage.getMyValue(position.DateHired)
            Me.hfSchoolname.Value = BasePage.getMyValue(position.SchoolName)
            Me.TextSchool.Text = BasePage.getMyValue(position.SchoolName)
            Me.hfPrincipalName.Value = BasePage.getMyValue(position.PrincipalName)

            Me.TextPositionTitle.Text = BasePage.getMyValue(position.PositionTitle)
            Me.TextPostionLevel.Text = BasePage.getMyValue(position.PositionLevel)
            Me.TextQualification.Text = BasePage.getMyValue(position.Qualification)
            Me.TextDescription.Text = BasePage.getMyValue(position.Description)

            hfPostcycle.Value = BasePage.getMyValue(position.PostingCycle)
            Me.TextPostingComments.Text = BasePage.getMyValue(position.PostingComments)
            Me.datePosted.Text = BasePage.getMyValue(position.DatePublish)
            Me.lblPostingCycle.Text = BasePage.getMyValue(position.RoundName)
            Me.lblFTEPanel.Text = BasePage.getMyValue(position.FTEPanel)
            Me.TextComments.Text = BasePage.getMyValue(position.Comments)
            Me.TextApplicantQulification.Text = BasePage.getMyValue(position.ApplicantQualification)
            Me.TextAppraisal.InnerHtml = BasePage.getMyValue(position.Appraisal)
            Me.TextHiredcomments.Text = BasePage.getMyValue(position.HiredComments)
            Me.dateInterview.Text = BasePage.getMyValue(position.DateInterview)
            Me.chbHiring.Checked = IIf(BasePage.getMyValue(position.ConfirmHired) = "1", True, False)
            Me.hfPrincipalID.Value = BasePage.getMyValue(position.PrincipalID)
            Me.hfPrincipalNameTo.Value = BasePage.getMyValue(position.PrincipalName)
            Me.hfPositionType.Value = BasePage.getMyValue(position.PositionType)
            Me.hfConfirmUser.Value = BasePage.getMyValue(position.OwnerName)

            Me.HiredMessage.Text = BasePage.getMyValue(position.HiredPosition)
            Me.lblHiredFTE.Text = BasePage.getMyValue(position.HiredPositionFTE)
            Me.lblPositionFTE.Text = BasePage.getMyValue(position.FTE)
            Me.lblRound.Text = BasePage.getMyValue(position.PostingCycle)


            Me.hfPositionType1.Value = BasePage.getMyValue(position.PositionType)
            Me.hfPositionTypeHired.Value = BasePage.getMyValue(position.HiredPositionType)
            Me.hfHiredStatus.Value = BasePage.getMyValue(position.HiredStatus)
            Me.dateEffective.Value = BasePage.getMyValue(position.DateEffective)
            Me.hfSchoolCode.Value = BasePage.getMyValue(position.SchoolCode)
            Me.TextPrincipalComments.Text = BasePage.getMyValue(position.Recommendation)

            Me.lblTeacherBeReplacedPersonID.Text = BasePage.getMyValue(position.ReplaceTeacherID)
            Me.lblTeacherBeReplaced.Text = BasePage.getMyValue(position.ReplaceTeacher)

            Me.lblTeacherPersonID.Text = BasePage.getMyValue(position.TeacherCPNum)
            Me.lblTeacherOTPrnr.Text = BasePage.getMyValue(position.TeacherPernrNo)
            Me.lblTeacherOCT.Text = BasePage.getMyValue(position.TeacherOCTNo)

            Me.lblEndDate.Value = BasePage.getMyValue(position.EndDate)
            Me.lblReasonReplacement.Text = BasePage.getMyValue(position.ReplaceReason)
            Me.lblPositionOwner.Text = BasePage.getMyValue(position.Owner)
            AssemblingList.SetValue(Me.ddlPayStatus, BasePage.getMyValue(position.PayState))
            hfPositionNumber.Value = BasePage.getMyValue(position.PositionNumber)
            ViewState("timeTable") = BasePage.getMyValue(position.TimeTable)
            ViewState("multiSchool") = BasePage.getMyValue(position.MultipleSchool)
            If ViewState("timeTable") = "" Then
                Me.F100TimeTable.Visible = False
                Me.F100MultipleSchool.Visible = False
            Else
                Me.F100TimeTable.InnerHtml = ViewState("timeTable")
                Me.F100MultipleSchool.InnerHtml = ViewState("multiSchool")
                Me.TextDescription.Style.Add("height", "25px")
            End If


            If Me.HiredMessage.Text <> "" Then
                '  HiredMessageRow.Visible = True
                Me.HiredMessage.Visible = True
                Me.HiredAlert.Visible = True
                Me.lblHiredFTE.Visible = True
            End If
            'If chbHiring.Checked Then
            '    Me.btnSaveHired.Text = "Revoke Confirm Hire"
            'Else
            '    Me.btnSaveHired.Text = "Confirm Hire"
            'End If

            'If Me.btnSaveHired.Text = "Revoke Confirm Hire" Then
            '    Me.btnSaveHired.ForeColor = Drawing.Color.Red
            'Else
            '    Me.btnSaveHired.ForeColor = Drawing.Color.Black
            'End If

            Dim thisDate As Date = Now()
            Dim thisMonth As Integer
            thisMonth = Month(thisDate)

            If thisMonth = 6 Then
                chbNextYear.Visible = True
            End If
            ' Me.chbSignatureSignOff.Enabled = False
            'If BasePage.getMyValue(position.SignOffResult) = "Sign Off Complete" Then
            '    Me.chbSignatureSignOff.Checked = True
            '    Me.chbSignatureSignOff.Text = "Interviewer and Candidate have signed off on H.M. 40 Document"
            'Else
            '    Me.chbSignatureSignOff.Checked = False
            '    Me.chbSignatureSignOff.Text = "Interviewer and Candidate have not signed off on H.M. 40 Document"
            'End If

            'If Me.btnSaveHired.Enabled = True Then
            '    If Not Me.chbSignatureSignOff.Checked Then
            '        Me.btnSaveHired.Enabled = False
            '    End If
            'End If


        Catch ex As Exception

        End Try

    End Sub

    Private Function getDataSource() As PositionHired

        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        Dim cpnum As String = Page.Request.QueryString("ApplyUserID")
        Dim positionID As String = Page.Request.QueryString("PositionID")
        Me.hfPositionID.Value = positionID
        Me.hfUserCPNum.Value = cpnum
        Me.hfSchoolyear.Value = schoolyear


        Dim parameter = CommonParameter.GetParameters(schoolyear, positionID, cpnum)
        Dim SP As String = CommonExcute.SPNameAndParameters(DataAccessFile, cPage, "Position") ' CommonListExecute(Of PositionHired).ObjSP("PositionHired")

        If User.Identity.Name = "mif" Then
            Dim SP1 As String = CommonExcute.SPNameAndParameters(DataAccessFile, cPage, "Revoke") ' CommonOperationExcute(Of PositionHired).ObjSP("PositionHired", "Revoke")
            Me.lblPostingNum.ToolTip = HiredPositionExe.SPName("Position")
            Me.btnSaveHired.ToolTip = HiredPositionExe.SPName("Revoke")
        End If

        Dim position = HiredPositionExe.Position(parameter)(0)  'CommonExcute(Of PositionHired).GeneralList(SP, parameter)(0)

        '  Dim position = CommonExcute(Of PositionHired).GeneralList(cPage, "Position", parameter)(0) ' CommonListExecute.HiredPosition(parameter)(0) '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)
        Return position

    End Function

    Protected Sub btnSaveHired_Click(sender As Object, e As EventArgs) Handles btnSaveHired.Click
        Me.HiddenFieldAction.Value = "Yes"

        Dim action As String = "Revoke"

        Dim dateConfirm As String = AppOperate.DateFC.YMD2(Me.dateInterview.Text)
        Dim dateEffective As String = AppOperate.DateFC.YMD2(Me.dateEffective.Value)
        Dim dateEnd As String = AppOperate.DateFC.YMD2(Me.lblEndDate.Value)
        Try
            Dim hire As New PositionHired()
            With hire
                .Operate = action
                .UserID = User.Identity.Name
                .SchoolYear = Page.Request.QueryString("SchoolYear")
                .PositionType = hfPositionType1.Value
                .PositionID = Page.Request.QueryString("PositionID")
                .CPNum = Page.Request.QueryString("ApplyUserID")
                .Comments = TextComments.Text
            End With
            ' will create a new record in Postiion_Published table  and get PositionID as result
            ' Dim SP As String = CommonExcute.SPNameAndParameters(DataAccessFile, cPage, action)
            Dim result As String = HiredPositionExe.Revoke(hire) ' CommonExcute(Of PositionHired).GeneralValue(SP, hire) '   CommonOperationExcute.HiredOperation(hire, action) '            result = PostingHireExe.RevokeHire(hire, Me.hfIDs.Value)

            If result = "Successfully" Then
                SendConfimeEmailNotification(action)
            End If
            CreatSaveMessage(result, "Revoke Confirm Hire")
        Catch ex As Exception
            CreatSaveMessage("Failed", "Revoke Confirm Hire")
        End Try
    End Sub


    Private Function getForm(ByVal _teachername As String) As String
        Dim vForm As String = ""
        If Left(Me.hfSchoolCode.Value, 2) = "05" Then
            vForm = "A reminder to please add <span style='text-decoration: underline; font-weight: bolder'>" + _teachername + "</span> on your Form 107"
        End If
        Return vForm
    End Function
    Protected Sub btnGoTo_Click(sender As Object, e As EventArgs) Handles btnGoTo.Click
        Dim comments As String = Me.TextHiredcomments.Text
        Dim positionID As String = Me.hfPositionID.Value
        Dim cpnum As String = Me.hfUserCPNum.Value
        Dim schoolyear As String = Me.hfSchoolyear.Value
        Page.Response.Redirect("RequestPositionDetails.aspx?SchoolYear=" & schoolyear & "&PositionID=" & positionID & "&Action=Goto")
    End Sub
    Protected Sub btnRepost_Click(sender As Object, e As EventArgs) Handles btnRepost.Click
        Dim comments As String = Me.TextHiredcomments.Text
        Dim positionID As String = Me.hfPositionID.Value
        Dim cpnum As String = Me.hfUserCPNum.Value
        Dim schoolyear As String = Me.hfSchoolyear.Value
        Dim IDs As String = Me.hfIDs.Value

        Dim newPositionID As Integer
        Dim postingCycle As String = "1"
        Dim action As String = "RePostHired"
        If Me.chbNextYear.Checked Then
            schoolyear = DateFC.SchoolYearNext("", schoolyear)
            action = "PushToNext"
        End If

        Dim reposting As New ParametersForOperationHire()
        With reposting
            .Operate = action
            .UserID = User.Identity.Name
            .SchoolYear = schoolyear
            .PositionID = Page.Request.QueryString("PositionID")
            .CPNum = Page.Request.QueryString("ApplyUserID")
            .Comments = TextComments.Text
            .Action = action
            .PostingCycle = postingCycle
        End With
        ' will create a new record in Postiion_Published table  and get PositionID as result
        Dim result As String = PostingHireExe.ConfirmHire(reposting, Me.hfIDs.Value)

        '    Dim _result As String = PositionDetails.RePostingHiredPositionAndGetID(action, userid, schoolyear, positionID, cpnum, comments)

        If Not (result = "Successfully" Or result = "Failed") Then
            newPositionID = result
            result = "Successfully"
            '   SendRepostingNotificationToPrincipal(positionID, schoolyear, IDs, postingCycle)
        End If

        CreatSaveMessage(result, "Re-post Hired Position")

        Page.Response.Redirect("RequestPositionDetails2.aspx?SchoolYear=" & schoolyear & "&PositionID=" & newPositionID & "&Action=RePost")
    End Sub
    Protected Sub btnSubstitute_Click(sender As Object, e As EventArgs) Handles btnSubstitute.Click
        Dim comments As String = Me.TextHiredcomments.Text
        Dim positionID As String = Me.hfPositionID.Value
        Dim cpnum As String = Me.hfUserCPNum.Value
        Dim schoolyear As String = Me.hfSchoolyear.Value
        Dim IDs As String = Me.hfIDs.Value
        Dim userid As String = HttpContext.Current.User.Identity.Name
        Dim newPositionID As Integer
        Dim takeApplicant As String = "No"
        Dim postingCycle As String = "1"

        Dim reposting As New ParametersForOperationHire()
        With reposting
            .Operate = "Substituted"
            .UserID = User.Identity.Name
            .SchoolYear = schoolyear
            .PositionID = Page.Request.QueryString("PositionID")
            .CPNum = Page.Request.QueryString("ApplyUserID")
            .Comments = TextComments.Text
            .Action = "Substituted"
            .PostingCycle = postingCycle
        End With
        ' will create a new record in Postiion_Published table  and get PositionID as result
        Dim _result As String = PostingHireExe.ConfirmHire(reposting, Me.hfIDs.Value)

        '
        '  Dim _result As String = PositionDetails.RePostingHiredPositionAndGetID("Substituted", userid, schoolyear, positionID, cpnum, comments)

        If Not (_result = "Successfully" Or _result = "Failed") Then
            newPositionID = _result
            _result = "Successfully"
            '   SendRepostingNotificationToPrincipal(positionID, schoolyear, IDs, postingCycle)
        End If

        CreatSaveMessage(_result, "Substituted Hired Position")

        Page.Response.Redirect("RequestPositionDetails2.aspx?SchoolYear=" & schoolyear & "&PositionID=" & newPositionID & "&Action=Substituted")
    End Sub
    Private Sub CreatSaveMessage(ByVal strMessage As String, ByVal action As String)
        Try

            Dim strScript As String = "alter(" + """" + action + """,""" + strMessage + """);"
            '  ***  No Ajax
            ClientScript.RegisterStartupScript(GetType(String), "actionMessage", strScript, True)
            '  *** AJAX Save Message
            ' ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType, "save_script", strScript.ToString(), True)
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub chbNextYear_CheckedChanged(sender As Object, e As EventArgs) Handles chbNextYear.CheckedChanged
        If Me.chbNextYear.Checked Then
            Me.btnSubstitute.Enabled = False
            Me.btnGoTo.Enabled = False
            Me.btnSaveHired.Enabled = False
        Else
            Me.btnSubstitute.Enabled = True
            Me.btnGoTo.Enabled = True
            Me.btnSaveHired.Enabled = True
        End If
    End Sub

    Protected Sub BtnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        SendConfimeEmailNotification("ConfirmHire")
    End Sub
    Private Function GetCCList() As String
        Dim _mCC As String = WebConfigValue.getValuebyKey("eMailCC")
        _mCC = EmailNotification.CheckCCMail(_mCC, "Principal", "ConfirmHire", Me.hfPositionType.Value, lblPostingCycle.Text, Me.TextPositionTitle.Text, hfSchoolCode.Value)
        _mCC = EmailNotification.CheckCCMailOwner(_mCC, lblPositionOwner.Text, User.Identity.Name)
        Return _mCC
    End Function
    Private Sub SendConfimeEmailNotification(ByVal action As String)
        Try
            Dim myEmail As New EmailBase()

            Dim myEmailTemple = EmailNotification.EmailSubjectAndTemple(JsonFile, WorkingProfile.ApplicationType, action)
            '  Dim _mTo As String = getEmailToList()
            '  Dim _mFrom As String = EmailNotification.CheckFromMail(Me.hfPositionType.Value) ' WebConfigValue.getValuebyKey("eMailSender") ' EmailNotification.UserProfileByID("TCDSBeMailAddress", HttpContext.Current.User.Identity.Name) ' _mForm '
            '  Dim mSubject As String = Replace(myEmailTemple.Subject, "PositionTitle", Me.TextPositionTitle.Text) ' EmailNotification.Subject(JsonFile, WorkingProfile.ApplicationType, "Posting")
            '  Dim mSubject As String = EmailNotification.CheckMailSubject(Me.hfPositionType.Value, Me.hfSchoolCode.Value, myEmailTemple.Subject, Me.TextPositionTitle.Text)  ' Replace(myEmailTemple.Subject, "PositionTitle", Me.TextPositionTitle.Text) ' EmailNotification.Subject(JsonFile, WorkingProfile.ApplicationType, "Posting")
            '  Dim mTemplateFile = myEmailTemple.Template '  EmailNotification.Template(JsonFile, WorkingProfile.ApplicationType, "Posting")

            With myEmail
                .EmailTo = getEmailToList()
                .EmailCC = GetCCList()
                .EmailFrom = EmailNotification.CheckFromMail(Me.hfPositionType.Value)
                .EmailSubject = EmailNotification.CheckMailSubject(Me.hfPositionType.Value, Me.hfSchoolCode.Value, myEmailTemple.Subject, Me.TextPositionTitle.Text)
                .EmailBody = myEmailTemple.Template
            End With
            If Me.chbNoticeToPrincipal.Checked Then
                SMTPMailCall("Staff", action, myEmail)
            End If
            If Me.hfPositionType1.Value = "LTO" And Me.chbNoticeToUnion.Checked Then
                Dim unioneMail As String = EmailNotification.UnionEmail(hfSchoolCode.Value, hfPositionType.Value)
                If Not unioneMail = "" Then
                    myEmail.EmailCC = WebConfigValue.getValuebyKey("eMail_UnionA")
                    myEmail.EmailTo = unioneMail
                    SMTPMailCall("Union", action, myEmail)
                End If
            End If

        Catch ex As Exception

        End Try


    End Sub
    Private Function getEmailToList() As String
        Dim EmailToList As String = ""
        If Me.chbNoticeToPrincipal.Checked Then
            EmailToList = EmailNotification.UserProfileByID("TCDSBeMailAddress", hfPrincipalID.Value)
            EmailToList += EmailNotification.GetMultipleSchoolEmail(hfSchoolyear.Value, hfSchoolCode.Value, Me.hfPositionID.Value)
            'PositionDetails.NoticeToActingPrincipal(Me.hfSchoolyear.Value, Me.hfSchoolCode.Value, Me.hfPositionID.Value)
        End If
        'If Me.chbHiredNoticeToOfficer.Checked Then
        '    '  Dim officerID As String = PositionDetails.getOfficerProfile("UserID", "School", Me.hfSchoolCode.Value)
        '    Dim officerID As String = EmailNotification.OfficeUserProfile("UserID", "School", Me.hfSchoolCode.Value)

        '    EmailToList = EmailToList + ";" + officerID + "@TCDSB.ORG"
        'End If
        Return EmailToList
    End Function

    Private Sub SMTPMailCall(ByVal who As String, ByVal action As String, ByVal emailBase As EmailBase)
        Dim _AditionInfo As String = ""
        emailBase.EmailBcc = WebConfigValue.getValuebyKey("LTOadminFolder")
        Try

            ' If who = "Union" Then _mTO = CommonTCDSB.Webconfig.getValuebyKey("eMail_Union")
            Dim eMailFile As String = getEmailfileHTML(who, emailBase.EmailBody)


            Dim myEmail As New EmailNotice2()
            With myEmail
                .UserID = User.Identity.Name
                .SchoolYear = Me.hfSchoolyear.Value
                .SchoolCode = Me.hfSchoolCode.Value
                .PositionType = Me.hfPositionType.Value
                .PositionID = Me.hfPositionID.Value
                .PositionTitle = Me.TextPositionTitle.Text
                .PostingNum = Me.lblPostingNum.Text
                .NoticePrincipal = Me.hfPrincipalName.Value
                .NoticeFor = who
                .EmailType = action
                .EmailTo = emailBase.EmailTo
                .EmailCC = emailBase.EmailCC
                .EmailBcc = emailBase.EmailBcc
                .EmailFrom = emailBase.EmailFrom
                .EmailSubject = emailBase.EmailSubject
                .EmailBody = eMailFile
                .EmailFormat = "HTML"
                .Attachment1 = ""
                .Attachment2 = ""
                .Attachment3 = ""
            End With

            If who = "Staff" Then
                Dim LogID As String = EmailNotification.SaveEmailNotice(myEmail)
            End If
            'PositionDetails.SaveConfirmHire_eMailLog(userID, appType, schoolyear, schoolcode, positionID, positionTitle, postingNum, toPrincipal, mailType, _mTO, _mCC, _mFrom, _mSubject, eMailFile)
            Dim result = EmailNotification.SendEmail(myEmail) ' User.Identity.Name, _mTO, _mCC, _mBcc, _mFrom, _mSubject, eMailFile, "HTML")
        Catch ex As Exception

        End Try
    End Sub


    Private Function getEmailfileHTML(ByVal _who As String, ByVal bodyTemplate As String) As String

        Dim JsonFileHRstaff As String = Server.MapPath("..\Content\HRStaff.json")
        Dim contact As String = WebConfigValue.HRContact(JsonFileHRstaff, Me.lblPositionOwner.Text).Extention


        Dim sDate As DateTime = Now()
        Dim _Datetime As String = sDate.ToString

        Dim myHTML As String = Server.MapPath("..") + "\Template\" + bodyTemplate
        Dim eMailFile As String = EmailNotification.EmailHTMLBody(myHTML)

        Try

            eMailFile = Replace(eMailFile, "{{PostingNumberSTR}}", Me.lblPostingNum.Text)
            eMailFile = Replace(eMailFile, "{{TeacherNameSTR}}", Me.TextName.Text)
            eMailFile = Replace(eMailFile, "{{TeacherCPNumSTR}}", Me.lblTeacherPersonID.Text)
            eMailFile = Replace(eMailFile, "{{TeacherOTPrnrSTR}}", Me.lblTeacherOTPrnr.Text)
            eMailFile = Replace(eMailFile, "{{PrincipalNameSTR}}", Me.hfPrincipalName.Value)
            eMailFile = Replace(eMailFile, "{{DateTimeSTR}}", _Datetime)
            eMailFile = Replace(eMailFile, "{{BTCSTR}}", Me.lblPositionFTE.Text)
            eMailFile = Replace(eMailFile, "{{PositionTitleSTR}}", TextPositionTitle.Text)
            eMailFile = Replace(eMailFile, "{{PositionStartDateSTR}}", Me.dateEffective.Value)
            eMailFile = Replace(eMailFile, "{{PositionEndDateSTR}}", Me.lblEndDate.Value)
            eMailFile = Replace(eMailFile, "{{ConfirmPersonSTR}}", Me.hfConfirmUser.Value)
            eMailFile = Replace(eMailFile, "{{RevokeReasonSTR}}", Me.TextHiredcomments.Text)
            eMailFile = Replace(eMailFile, "{{PositionSchoolSTR}}", Me.TextSchool.Text)
            eMailFile = Replace(eMailFile, "{{RevokedDate}}", _Datetime)
            eMailFile = Replace(eMailFile, "{{PositionOwnerSTR}}", contact)
            eMailFile = Replace(eMailFile, "{{PostingCycleSTR}}", Me.lblPostingCycle.Text)
            eMailFile = Replace(eMailFile, "{{QualificationSTR}}", Me.TextQualification.Text)

            If Len(ViewState("timeTable")) > 10 Then
                eMailFile = Replace(eMailFile, "{{WeeklyScheduleSTR}}", "Weekly Schedule:")
            Else
                eMailFile = Replace(eMailFile, "{{WeeklyScheduleSTR}}", " ")
            End If

            eMailFile = Replace(eMailFile, "{{timeTable}}", ViewState("timeTable"))
            eMailFile = Replace(eMailFile, "{{multiSchool}}", ViewState("multiSchool"))


            If Me.hfPositionType.Value = "POP" Then
                eMailFile = Replace(eMailFile, "{{PositionTypeSTR}}", Me.hfPositionType.Value)
                eMailFile = Replace(eMailFile, "{{PositionTypeSTR2}}", Me.hfPositionType.Value)
                eMailFile = Replace(eMailFile, "{{PositionDescriptionSTR}}", TextDescription.Text)
                eMailFile = Replace(eMailFile, "{{PositionPostedSTR}}", datePosted.Text)
                eMailFile = Replace(eMailFile, "{{FormReminderLine}}", getForm(Me.TextName.Text))

            Else

                Dim absentSection As String = ""

                Dim payStatus As String = ""
                If ddlPayStatus.SelectedValue <> "9" Then payStatus = ddlPayStatus.SelectedItem.Text

                If _who = "Staff" Then
                    absentSection = " <table border = '1' style='width:700px'> <tr> "
                    absentSection += "<td style='text-align:left;'>Absent Teacher:</td><td> " + Me.lblTeacherBeReplaced.Text + " </td>"
                    absentSection += "<td  style='text-align:right;'>Position Number: </td> <td> " + Me.hfPositionNumber.Value + "</td> "
                    absentSection += "<td  style='text-align:right;'>PID: </td> <td> " + Me.lblTeacherBeReplacedPersonID.Text + "</td></tr>"
                    absentSection += "<tr><td> Reason for leave: </td> <td colspan='5'>" + Me.lblReasonReplacement.Text + "</td></tr>"
                    absentSection += "<tr><td> Employee Status: </td> <td colspan='5'>" + payStatus + "</td></tr> </table>"
                End If
                eMailFile = Replace(eMailFile, "{{AbsentTeacherSection}}", absentSection)

            End If


        Catch ex As Exception
            eMailFile = ""
        End Try
        Return eMailFile

    End Function
End Class

