'Imports System.Data
'Imports System.Data.SqlClient
Imports System.IO
Imports AppOperate
Imports ClassLibrary
'Imports TCDSB.Student

Partial Class HiringDetails2
    Inherits System.Web.UI.Page
    Dim JsonFile As String = Server.MapPath("..\Content\eMailTemplate.json")
    Dim jsonFileHRstaff As String = Server.MapPath("..\Content\HRStaff.json")

    Dim cPage As String = "PositionHiring"
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
            setStartandEndDate()
            LoadMyData()

        End If
    End Sub
    Private Sub setStartandEndDate()
        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        Dim parameter As New LimitDate()
        With parameter
            .Operate = "GetDefault"
            .PositionType = WorkingProfile.ApplicationType
            .SchoolYear = schoolyear
        End With
        Dim myDate As New List(Of LimitDate)

        myDate = CommonListExecute.LimitedDate(parameter) ' PostingPublishExe.LimitedDate(parameter) ' PositionPublished.LimitedDate(parameter)

        Me.hfSchoolyearStartDate.Value = myDate(0).StartDate
        Me.hfSchoolyearEndDate.Value = myDate(0).EndDate

    End Sub
    Private Sub LoadMyData()
        Try


            Dim position = getDataSource() '  SinglePosition.PositionByID(parameter)


            Dim userid As String = HttpContext.Current.User.Identity.Name
            Me.lblPostingNum.Text = BasePage.getMyValue(position.PostingNumber)
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

            Me.TextComments.Text = BasePage.getMyValue(position.Comments)
            Me.TextApplicantQulification.Text = BasePage.getMyValue(position.ApplicantQualification)
            Me.TextAppraisal.InnerHtml = BasePage.getMyValue(position.Appraisal)
            Me.TextHiredcomments.Text = BasePage.getMyValue(position.HiredComments)
            Me.dateInterview.Text = BasePage.getMyValue(position.DateInterview)
            Me.chbHiring.Checked = IIf(BasePage.getMyValue(position.ConfirmHired) = "1", True, False)
            Me.hfPrincipalID.Value = BasePage.getMyValue(position.PrincipalID)
            Me.hfPrincipalNameTo.Value = BasePage.getMyValue(position.PrincipalName)
            Me.hfPositionType.Value = BasePage.getMyValue(position.PositionType)
            Me.hfConfirmUser.Value = BasePage.getMyValue(position.Owner)
            Me.lblPositionOwner.Text = BasePage.getMyValue(position.OwnerName)

            Me.HiredMessage.Text = BasePage.getMyValue(position.HiredPosition)
            Me.lblHiredFTE.Text = BasePage.getMyValue(position.HiredPositionFTE)
            Me.lblPositionFTE.Text = BasePage.getMyValue(position.FTE)



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

            Me.lblEndDate.Text = BasePage.getMyValue(position.EndDate)
            Me.lblReasonReplacement.Text = BasePage.getMyValue(position.ReplaceReason)
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


            Dim thisDate As Date = Now()
            Dim thisMonth As Integer
            thisMonth = Month(thisDate)

            If thisMonth = 6 Then
                chbNextYear.Visible = True

            End If
            Me.chbSignatureSignOff.Enabled = False
            If BasePage.getMyValue(position.SignOffResult) = "Sign Off Complete" Then
                Me.chbSignatureSignOff.Checked = True
                Me.chbSignatureSignOff.Text = "Interviewer and Candidate have signed off on H.M. 40 Document"
            Else
                Me.chbSignatureSignOff.Checked = False
                Me.chbSignatureSignOff.Text = "Interviewer and Candidate have not signed off on H.M. 40 Document"
            End If

            If Me.btnSaveHired.Enabled = True Then
                If Not Me.chbSignatureSignOff.Checked Then
                    Me.btnSaveHired.Enabled = False
                End If
            End If


        Catch ex As Exception
            Dim errorText As String = ex.Message
        End Try

    End Sub

    Private Function getDataSource() As PositionHire


        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        Dim cpnum As String = Page.Request.QueryString("ApplyUserID")
        Dim positionID As String = Page.Request.QueryString("PositionID")
        Me.hfPositionID.Value = positionID
        Me.hfUserCPNum.Value = cpnum
        Me.hfSchoolyear.Value = schoolyear



        If User.Identity.Name = "mif" Then
            ' Dim SP As String = CommonListExecute(Of PositionHire).ObjSP("PositionHire")
            '  Dim SP1 As String = CommonOperationExcute(Of ParametersForOperationHire).ObjSP("ParametersForOperationHire", "ConfirmHire")
            Me.lblPostingNum.ToolTip = ConfirmHireExe.SPName("Positions")
            Me.btnSaveHired.ToolTip = ConfirmHireExe.SPName("Confirm")
        End If
        Dim parameter = CommonParameter.GetParameters(schoolyear, positionID, cpnum)

        Dim position = ConfirmHireExe.Position(parameter)(0)  ' rimHireExe.  CommonListExecute.HirePosition(parameter)(0) '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)
        Return position

    End Function

    Protected Sub btnSaveHired_Click(sender As Object, e As EventArgs) Handles btnSaveHired.Click
        Me.HiddenFieldAction.Value = "Yes"

        Dim action As String = "ConfirmHire"
        '   If Me.btnSaveHired.Text = "Revoke Confirm Hire" Then action = "Revoke Confirm Hire"
        Try


            Dim dateConfirm As String = AppOperate.DateFC.YMD2(Me.dateInterview.Text)
            Dim dateEffective As String = AppOperate.DateFC.YMD2(Me.dateEffective.Value)
            Dim dateEnd As String = AppOperate.DateFC.YMD2(Me.lblEndDate.Text)



            Dim hire As New ParametersForOperationHire()
            With hire
                .Operate = action
                .UserID = User.Identity.Name
                .SchoolYear = Page.Request.QueryString("SchoolYear")
                .PositionType = hfPositionType1.Value
                .PositionID = Page.Request.QueryString("PositionID")
                .CPNum = Page.Request.QueryString("ApplyUserID")
                .Comments = TextComments.Text
                .DateConfirm = dateConfirm
                .DateEffective = dateEffective
                .DateEnd = dateEnd
                .Acceptance = IIf(Me.chbHiring.Checked, "0", "1")
                .PrincipalEmail = IIf(Me.chbNoticeToPrincipal.Checked, "1", "0")
                .OfficerEmail = IIf(Me.chbNoticeToUnion.Checked, "1", "0")
                .PayStatus = Me.ddlPayStatus.SelectedValue
                .Action = action
            End With
            Dim result As String = ""
            Try
                ' result = PostingHireExe.ConfirmHire(hire, Me.hfIDs.Value)

                result = ConfirmHireExe.Confirm(hire) '  CommonOperationExcute.HiringOperation(hire, action)  '  PostingPublishExe.CancelPosting(cancelPosting, Me.hfIDs.Value)


            Catch ex As Exception

            End Try
            If result = "Successfully" Then
                SendConfimeEmailNotification(action)
                'If Me.chbHiredNoticeToPrincipal.Checked Or Me.chbHiredNoticeToOfficer.Checked Then
                '    '' ** no emaill notification required for Principal to HR 
                'End If
            End If
            CreateSaveMessage(result, "Confirm Hire")
        Catch ex As Exception
            CreateSaveMessage("Failed", action)
        End Try

    End Sub
    Private Sub CreateSaveMessage(ByVal strMessage As String, ByVal action As String)
        Try

            Dim strScript As String = " CallBackReloadParent(" + "'" + action + "','" + strMessage + "');"


            '   window.alert(action + " this position is " + resutl);
            '  ***  No Ajax
            ClientScript.RegisterStartupScript(GetType(String), "_savemessagescript", strScript, True)

            '  *** AJAX Save Message
            '   ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType, "save_script", strScript.ToString(), True)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub SendConfimeEmailNotification(ByVal action As String)
        Try
            Dim HRContact = DataTools.GetHRContact(jsonFileHRstaff, GetOwner())

            Dim position = CurrentPosition()
            Dim email = New EmailNotification(position)

            Dim myEmail As New EmailNotice2()

            If Me.chbNoticeToPrincipal.Checked Then
                myEmail = email.GetEmailNotice(JsonFile, action, "Principal", User.Identity.Name)
                myEmail.EmailBody = GetEmailBody("Principal", action, myEmail.EmailBody, HRContact)
                email.SMTPMailCall("Principal", myEmail)
            End If

            If Me.chbNoticeToUnion.Checked Then
                myEmail = email.GetEmailNotice(JsonFile, action, "Union", User.Identity.Name)
                myEmail.EmailBody = GetEmailBody("Union", action, myEmail.EmailBody, HRContact)
                email.SMTPMailCall("Union", myEmail)
            End If

        Catch ex As Exception
            CreateSaveMessage("Failed", "Send Email notification")
        End Try

    End Sub
    'Private Function getEmailToList() As String
    '    Dim EmailToList As String = ""
    '    If Me.chbNoticeToPrincipal.Checked Then
    '        EmailToList = EmailNotification.UserProfileByID("TCDSBeMailAddress", hfPrincipalID.Value)
    '        EmailToList += EmailNotification.GetMultipleSchoolEmail(hfSchoolyear.Value, hfSchoolCode.Value, Me.hfPositionID.Value)
    '        'PositionDetails.NoticeToActingPrincipal(Me.hfSchoolyear.Value, Me.hfSchoolCode.Value, Me.hfPositionID.Value)
    '    End If

    '    Return EmailToList
    'End Function
    'Private Function GetCCList() As String
    '    Dim title As String = Me.TextPositionTitle.Text
    '    Dim panel As String = DataTools.SchoolPanel(hfSchoolCode.Value)
    '    Dim appType As String = Me.hfPositionType.Value
    '    Dim owner As String = lblPositionOwner.Text

    '    Dim _mCC As String = WebConfigValue.getValuebyKey("eMailCC")
    '    _mCC = EmailNotification.CheckCCMailOwner(_mCC, owner, User.Identity.Name)
    '    _mCC = EmailNotification.CheckCCMail(_mCC, "Principal", "ConfirmHire", appType, lblPostingCycle.Text, title, panel)
    '    Return _mCC
    'End Function
    'Private Function getUnionNoticeHRFollower() As String
    '    Dim owner As String = lblPositionOwner.Text
    '    Dim followUnion As String = WebConfigValue.getValuebyKey("eMail_Union_Follow")
    '    If followUnion = "Owner" Then Return EmailNotification.CheckCCMailOwner("", owner, User.Identity.Name)
    '    Return followUnion
    'End Function

    Private Sub sendCongratulateEmailNotification()
        Dim recommendation As String = Me.TextHiredcomments.Text
        Dim dateinterview As String = AppOperate.DateFC.YMD(Me.dateInterview.Text)
        Dim _teacherName As String = Me.TextName.Text
        Dim _principalName As String = Me.hfPrincipalName.Value
        Dim _schoolname As String = Me.hfSchoolname.Value
        Dim _Positiontitle As String = Me.TextPositionTitle.Text
    End Sub

    'Private Sub SMTPMailCall(ByVal who As String, ByVal myEmail As EmailNotice2)

    '    Try
    '        Dim emailNotice = New EmailNotification()

    '        'If String.IsNullOrEmpty(myEmail.EmailCC) Then
    '        '    myEmail.EmailCC = User.Identity.Name + "@tcdsb.org"
    '        'End If
    '        Dim logId As String = emailNotice.SaveEmailNotice(myEmail)
    '        Dim result = emailNotice.SendEmail(myEmail)
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Function GetEmailBody(ByVal _who As String, ByVal action As String, ByVal bodayTemplate As String, ByVal HRContact As Contact) As String

        Dim contact As String = HRContact.Extention
        Dim name As String = HRContact.Name

        ' Dim sDate As DateTime = Now()
        Dim _Datetime As String = DateFC.YMDHMS(Now())

        'Dim appType As String = Me.hfPositionType.Value
        'Dim myEmailTemple = EmailNotification.EmailSubjectAndTemple(JsonFile, appType, action)
        Dim myHtml As String = Server.MapPath("..") + "\Template\" + bodayTemplate
        Dim eMailFile As String = EmailNotification.EmailHTMLBody(myHtml)

        Dim cpnum As String = IIf(_who = "Union", "", "(" + Me.lblTeacherPersonID.Text + ")")

        Try
            eMailFile = Replace(eMailFile, "{{PostingNumberSTR}}", Me.lblPostingNum.Text)
            eMailFile = Replace(eMailFile, "{{TeacherNameSTR}}", Me.TextName.Text)
            eMailFile = Replace(eMailFile, "{{TeacherCPNumSTR}}", cpnum)
            eMailFile = Replace(eMailFile, "{{TeacherOTPrnrSTR}}", Me.lblTeacherOTPrnr.Text)
            eMailFile = Replace(eMailFile, "{{PrincipalNameSTR}}", Me.hfPrincipalName.Value)
            eMailFile = Replace(eMailFile, "{{DateTimeSTR}}", _Datetime)
            eMailFile = Replace(eMailFile, "{{BTCSTR}}", Me.lblPositionFTE.Text)
            eMailFile = Replace(eMailFile, "{{PositionTitleSTR}}", TextPositionTitle.Text)
            eMailFile = Replace(eMailFile, "{{PositionStartDateSTR}}", Me.dateEffective.Value)
            eMailFile = Replace(eMailFile, "{{PositionEndDateSTR}}", Me.lblEndDate.Text)
            eMailFile = Replace(eMailFile, "{{ConfirmPersonSTR}}", name)
            eMailFile = Replace(eMailFile, "{{RevokeReasonSTR}}", Me.TextHiredcomments.Text)
            eMailFile = Replace(eMailFile, "{{PositionSchoolSTR}}", Me.TextSchool.Text)
            eMailFile = Replace(eMailFile, "{{RevokedDate}}", _Datetime)
            eMailFile = Replace(eMailFile, "{{PositionOwnerSTR}}", contact)
            eMailFile = Replace(eMailFile, "{{PostingCycleSTR}}", "") ' Me.lblPostingCycle.Text)
            eMailFile = Replace(eMailFile, "{{QualificationSTR}}", Me.TextPostionLevel.Text + " / " + Me.TextQualification.Text)

            Dim weeklySchedule As String = IIf(Len(ViewState("timeTable")) > 10, "Weekly Schedule:", " ")
            eMailFile = Replace(eMailFile, "{{WeeklyScheduleSTR}}", weeklySchedule)


            eMailFile = Replace(eMailFile, "{{timeTable}}", ViewState("timeTable"))
            eMailFile = Replace(eMailFile, "{{multiSchool}}", ViewState("multiSchool"))

            Dim absentSection As String = ""

            If Me.hfPositionType.Value = "POP" Then
                eMailFile = Replace(eMailFile, "{{PositionTypeSTR}}", Me.hfPositionType.Value)
                eMailFile = Replace(eMailFile, "{{PositionTypeSTR2}}", getFullNameOfType())
                eMailFile = Replace(eMailFile, "{{PositionDescriptionSTR}}", TextDescription.Text)
                eMailFile = Replace(eMailFile, "{{PositionPostedSTR}}", datePosted.Text)
                eMailFile = Replace(eMailFile, "{{FormReminderLine}}", getForm(Me.TextName.Text))
            Else
                absentSection = GetAbsentSection()
            End If
            eMailFile = Replace(eMailFile, "{{AbsentTeacherSection}}", absentSection)


        Catch ex As Exception
            eMailFile = ""
        End Try
        Return eMailFile

    End Function
    Private Function GetAbsentSection() As String
        Dim absentSection As String = ""

        Dim payStatus As String = ""
        If ddlPayStatus.SelectedValue <> "9" Then payStatus = ddlPayStatus.SelectedItem.Text

        absentSection = " <table border = '1' style='width:700px'> <tr> "
        absentSection += "<td style='text-align:left;'>Absent Teacher:</td><td> " + Me.lblTeacherBeReplaced.Text + " </td>"
        absentSection += "<td  style='text-align:right;'>Position Number: </td> <td> " + Me.hfPositionNumber.Value + "</td> "
        absentSection += "<td  style='text-align:right;'>PID: </td> <td> " + Me.lblTeacherBeReplacedPersonID.Text + "</td></tr>"

        absentSection += "<tr><td> Reason for leave: </td> <td colspan='5'>" + Me.lblReasonReplacement.Text + "</td></tr>"
        absentSection += "<tr><td> Employee Status: </td> <td colspan='5'>" + payStatus + "</td></tr>"
        absentSection += " </table>"

        Return absentSection
    End Function
    Private Function getFullNameOfType() As String
        Dim type As String = Me.hfPositionType.Value
        Dim typeTitle As String = "Long Term Occasional Assignment"
        If type = "POP" Then typeTitle = "Permanent Open Position"
        Return typeTitle
    End Function
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
        Page.Response.Redirect("RequestPositionDetails2.aspx?SchoolYear=" & schoolyear & "&PositionID=" & positionID & "&Action=Goto")
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
            .Operate = "RePostHired"
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
    Private Function GetOwner() As String
        Dim schoolcode As String = hfSchoolCode.Value
        Dim appType As String = hfPositionType.Value
        Dim owner As String = Me.hfConfirmUser.Value
        Return DataTools.GetPositionOwner(owner, schoolcode, appType)
    End Function
    Protected Sub hfSchoolyear_ValueChanged(sender As Object, e As EventArgs) Handles hfSchoolyear.ValueChanged

    End Sub
    Private Function CurrentPosition() As PositionPublish

        Dim position = New PositionPublish()
        With position
            .UserID = User.Identity.Name
            .SchoolYear = Page.Request.QueryString("SchoolYear")
            .SchoolCode = hfSchoolCode.Value
            .PostingNumber = Me.lblPostingNum.Text
            .PositionID = hfPositionID.Value
            .PositionType = hfPositionType.Value
            .PositionTitle = Me.TextPositionTitle.Text
            .PositionLevel = Me.TextPostionLevel.Text
            .Qualification = Me.TextQualification.Text
            .QualificationCode = ""
            .Description = Me.TextDescription.Text
            .FTE = Me.lblPositionFTE.Text
            .FTEPanel = ""
            .StartDate = DateFC.YMD2(Me.dateEffective.Value)
            .EndDate = DateFC.YMD2(Me.lblEndDate.Text)
            .DatePublish = ""
            .DateApplyOpen = ""
            .DateApplyClose = ""
            .Comments = Me.TextPostingComments.Text
            .ReplaceTeacherID = Me.lblTeacherPersonID.Text
            .ReplaceTeacher = Me.TextName.Text
            .ReplaceReason = ""
            .OtherReason = ""
            .Owner = Me.hfConfirmUser.Value
            .PostingCycle = Me.lblPostingCycle.Text
            .PrincipalID = hfPrincipalID.Value
            .PrincipalName = Me.hfPrincipalName.Value
        End With
        Return position
    End Function
End Class

