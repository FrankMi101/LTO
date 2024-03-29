﻿'Imports System.Data
'Imports System.Data.SqlClient
Imports System.IO
Imports AppOperate
Imports ClassLibrary
'Imports TCDSB.Student

Partial Class HiringDetails4th2
    Inherits System.Web.UI.Page
    Dim JsonFile As String = Server.MapPath("..\Content\eMailTemplate.json")
    Dim jsonFileHRstaff As String = Server.MapPath("..\Content\HRStaff.json")

    Dim DataAccessFile As String = ""  'Server.MapPath("..\Content\DataAccess.json")
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
            Me.hfPositionID.Value = Page.Request.QueryString("PositionID")
            Me.hfUserCPNum.Value = Page.Request.QueryString("ApplyUserID")
            Me.hfSchoolyear.Value = Page.Request.QueryString("SchoolYear")

            ' SetupList.ListDDL(Me.ddlApplicant, "Applicant4ThRound", WorkingProfile.SchoolYear, "", WorkingProfile.UserRole, "%")

            '  Dim mylist As ListControl = CType(Me.combobox, ListControl)

            Dim parameter As New List2Item()
            With parameter
                .Operate = "Applicant4ThRound"
                .Para0 = WorkingProfile.SchoolYear
                .Para1 = ""
                .Para2 = WorkingProfile.UserRole
                .Para3 = "%"
            End With


            AssemblingList.SetListsOBj("", Me.combobox, "Applicant4ThRound", parameter)
            ' AssembleListItem.SetObjLists(Me.combobox, "Applicant4ThRound", User.Identity.Name, WorkingProfile.SchoolYear, "", WorkingProfile.UserRole, "%")
            '.ListDDL(Me.combobox, "Applicant4ThRound", WorkingProfile.SchoolYear, "", WorkingProfile.UserRole, "%")
            SetStartandEndDate()
            LoadMyData()

        End If
    End Sub

    Private Sub SetStartandEndDate()
        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        Dim parameter As New LimitDate()
        With parameter
            .Operate = "GetDefault"
            .PositionType = WorkingProfile.ApplicationType
            .SchoolYear = schoolyear
        End With
        Dim myDate As New List(Of LTODefalutDate)
        '  Dim SP As String = CommonExcute.SPNameAndParameters(DataAccessFile, "Publish", "DefaultDate")
        myDate = GeneralExe.DefaultDate(parameter) '  CommonExcute(Of LimitDate).GeneralList(SP, parameter) ' CommonListExecute.LimitedDate(parameter) ' PostingPublishExe.LimitedDate(parameter) ' PositionPublished.LimitedDate(parameter)
        Dim today As DateTime = DateTime.Today
        Me.hfSchoolyearStartDate.Value = myDate(0).BackDate ' .StartDate ' today.AddDays(-30) '
        Me.hfSchoolyearEndDate.Value = myDate(0).EndDate

    End Sub
    Private Function GetDataSource() As PositionHire4thRound
        Try
            Dim schoolyear As String = hfSchoolyear.Value
            Dim positionID As String = hfPositionID.Value
            Dim cpnum As String = hfUserCPNum.Value
            If User.Identity.Name = "mif" Then
                '  Dim SP As String = CommonListExecute(Of PositionHire4thRound).ObjSP("PositionHire4thRound")
                '  Dim SP1 As String = CommonOperationExcute(Of ParametersForOperationHire).ObjSP("ParametersForOperationHire", "ConfirmHire4th")
                Me.lblPostingNum.ToolTip = ConfirmHireExe.SPName("Position4th")
                Me.btnSaveHired.ToolTip = ConfirmHireExe.SPName("Confirm4th")
            End If

            Dim Parameter = CommonParameter.GetParameters(schoolyear, positionID, cpnum)
            Dim hiringPosition = ConfirmHireExe.Position4th(Parameter) '(0) ' CommonListExecute.HirePosition4thRound(parameter)(0) '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)

            Return hiringPosition(0)

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Private Sub LoadMyData()
        Try


            Dim userid As String = HttpContext.Current.User.Identity.Name

            Dim position = GetDataSource()  '  SinglePosition.PositionByID(parameter)

            Me.lblPostingNum.Text = position.PostingNumber
            Me.hfIDs.Value = BasePage.getMyValue(position.PositionID)

            Me.TextCPNum.Value = position.CPNum
            Me.dateHire.Value = BasePage.getMyValue(position.DateHired)
            Me.hfSchoolname.Value = BasePage.getMyValue(position.SchoolName)
            Me.TextSchool.Text = BasePage.getMyValue(position.SchoolName)

            Me.hfPrincipalName.Value = BasePage.getMyValue(position.PrincipalName)

            Me.TextPositionTitle.Text = BasePage.getMyValue(position.PositionTitle)
            Me.TextPostionLevel.Text = BasePage.getMyValue(position.PositionLevel)
            Me.TextQualification.Text = BasePage.getMyValue(position.Qualification)
            Me.TextDescription.Text = BasePage.getMyValue(position.Description)

            Me.TextHiredcomments.Text = BasePage.getMyValue(position.HiredComments)
            '         Me.dateEnd.Value = BasePage.getMyValue(position(14))
            '      Me.chbHiring.Checked = IIf(BasePage.getMyValue(position(20)) = "1", True, False)
            Me.hfPrincipalID.Value = BasePage.getMyValue(position.PrincipalID)
            Me.hfPrincipalNameTo.Value = BasePage.getMyValue(position.PrincipalName)

            Me.hfPositionType.Value = BasePage.getMyValue(position.PositionType)
            Me.hfConfirmUser.Value = BasePage.getMyValue(position.OwnerName)

            Me.HiredMessage.Text = BasePage.getMyValue(position.HiredPosition)
            Me.lblHiredFTE.Text = BasePage.getMyValue(position.HiredPositionFTE)
            Me.lblPositionFTE.Text = BasePage.getMyValue(position.FTE)



            Me.hfPositionType1.Value = BasePage.getMyValue(position.PositionType)
            Me.hfPositionTypeHired.Value = BasePage.getMyValue(position.HiredPositionType)
            Me.hfHiredStatus.Value = BasePage.getMyValue(position.HiredStatus)
            Me.dateEffective.Value = BasePage.getMyValue(position.DateEffective)
            Me.hfSchoolCode.Value = BasePage.getMyValue(position.SchoolCode)

            Me.lblPostingCycle.Text = BasePage.getMyValue(position.PostingCycle)
            Me.lblTeacherPersonID.Text = BasePage.getMyValue(position.TeacherCPNum)
            Me.lblTeacherOTPrnr.Text = BasePage.getMyValue(position.TeacherPernrNo)

            Me.dateEnd.Value = BasePage.getMyValue(position.EndDate)
            Me.dateHire.Value = Now()

            ' Me.lblTeacherOCT.Text = BasePage.getMyValue(position(37))
            Me.lblTeacherBeReplacedPersonID.Text = BasePage.getMyValue(position.ReplaceTeacherID)
            Me.lblTeacherBeReplaced.Text = BasePage.getMyValue(position.ReplaceTeacher)

            Me.lblReasonReplacement.Text = BasePage.getMyValue(position.ReplaceReason)
            Me.lblPositionOwner.Text = BasePage.getMyValue(position.Owner)
            'ListInitial.DDL(Me.ddlPayStatus, BasePage.getMyValue(position(43)))
            hfPositionNumber.Value = BasePage.getMyValue(position.PositionNumber)

            ViewState("timeTable") = BasePage.getMyValue(position.TimeTable)
            ViewState("multiSchool") = BasePage.getMyValue(position.MultipleSchool)

            If BasePage.getMyValue(position.TimeTable) = "" Then
                Me.F100TimeTable.Visible = False
                Me.F100MultipleSchool.Visible = False
            Else
                Me.F100TimeTable.InnerHtml = BasePage.getMyValue(position.TimeTable)
                Me.F100MultipleSchool.InnerHtml = BasePage.getMyValue(position.MultipleSchool)
                Me.TextDescription.Style.Add("height", "25px")
            End If

            If Not position.Applicants = "" Then
                Me.ApplicantsList.Visible = True
                Me.ApplicantsList.InnerHtml = BasePage.getMyValue(position.Applicants)
            End If

            If Me.hfPositionType1.Value = "LTO" Then
                LabelStartDate.Text = "LTO Start Date:"
            Else
                LabelStartDate.Text = "POP Start Date:"
            End If
            If Me.HiredMessage.Text <> "" Then
                '  HiredMessageRow.Visible = True
                Me.HiredMessage.Visible = True
                Me.HiredAlert.Visible = True
                Me.lblHiredFTE.Visible = True
            End If


            If Me.btnSaveHired.Text = "Revoke Confirm Hire" Then
                Me.btnSaveHired.ForeColor = Drawing.Color.Red
                Me.btnSave.Visible = True
            Else
                Me.btnSaveHired.ForeColor = Drawing.Color.Black
                Me.btnSave.Visible = False
            End If
            If hfPositionType1.Value = "POP" Then
                RequiredFieldValidator1.Enabled = False
                RequiredFieldValidator1.Visible = False
                RequiredFieldValidator1.EnableClientScript = False
                RequiredFieldValidator1.ControlToValidate = ""
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveChanges("Edit save")
    End Sub

    Protected Sub BtnSaveHired_Click(sender As Object, e As EventArgs) Handles btnSaveHired.Click
        Dim action As String = "ConfirmHire4th"
        '  If Me.btnSaveHired.Text = "Revoke Confirm Hire" Then action = "Revoke Confirm Hire"
        Dim cpnum As String = Me.TextCPNum.Value
        Dim parameter As Profile = CommonParameter.ParametersForProfile("", User.Identity.Name, hfSchoolyear.Value, "PernrNum", cpnum)
        Me.lblTeacherOTPrnr.Text = ConfirmHireExe.PernrNum(parameter)
        SaveChanges(action)
    End Sub
    Private Sub SaveChanges(ByVal action As String)

        Me.HiddenFieldAction.Value = "Yes"
        Dim tName As String = Me.HiddenFieldTeacherName.Value
        Dim cpnum As String = Me.TextCPNum.Value
        Dim hiredcomments As String = Me.TextHiredcomments.Text
        Dim schoolyear As String = hfSchoolyear.Value
        Dim positionID As String = hfPositionID.Value

        Dim dateEffective As String = DateFC.YMD2(Me.dateEffective.Value)
        Dim dateEnd As String = DateFC.YMD2(Me.dateEnd.Value)


        Dim dateHire As String = DateFC.YMD(Me.dateHire.Value, "/")
        Dim acceptHire As String = "1"
        'Dim eMailToOfficer As String = "0"
        Dim eMailToPrincipal As String = IIf(Me.chbNoticeToPrincipal.Checked, "1", "0")

        If CheckUserCPNumAndDate(User.Identity.Name, schoolyear, positionID, cpnum) = "Pass" Then

            Dim hire As New ParametersForOperationHire()
            With hire
                .Operate = "ConfirmHire"
                .UserID = User.Identity.Name
                .SchoolYear = schoolyear
                .PositionType = Me.hfPositionType.Value
                .PostingCycle = "4"
                .PositionID = positionID
                .CPNum = cpnum
                .Comments = TextHiredcomments.Text
                .DateConfirm = dateHire
                .DateEffective = dateEffective
                .DateEnd = dateEnd
                .Acceptance = "1"
                .PrincipalEmail = IIf(Me.chbNoticeToPrincipal.Checked, "1", "0")
                .OfficerEmail = IIf(Me.chbNoticeToUnion.Checked, "1", "0")
                .Action = action
                .TeacherName = tName
            End With

            ' will create a new record in Postiion_Published table  and get PositionID as result
            Dim result = ""
            Try
                '  result = PostingHireExe.ConfirmHire4thRound(hire, Me.hfIDs.Value)
                result = ConfirmHireExe.Confirm4th(hire) ' CommonOperationExcute.HiringOperation4th(hire, action)  '  PostingPublishExe.CancelPosting(cancelPosting, Me.hfIDs.Value)


                If Left(result, 2) = "NS" Then
                    Me.TextCPNum.Value = result
                    result = "Successfully"
                End If
            Catch ex As Exception

            End Try
            '  Dim result As String = PositionDetails.AcceptanceHire4ThRound(userid, schoolyear, positionID, cpnum, tName, hiredcomments, dateEnd, dateEffective, dateHire, acceptHire, eMailToPrincipal, action)
            If result = "Successfully" Then
                If Not action = "Edit save" Then
                    ' If Me.chbHiredNoticeToPrincipal.Checked Then
                    '' ** no emaill notification required for Principal to HR 
                    SendConfimeEmailNotification("ConfirmHire")
                    ' End If
                End If

            End If

            CreateSaveMessage(result, "Confirm Hire")
        Else
            CreateSaveMessage("Name verify failed. Can not Confirm hire.", action)
        End If

    End Sub
    Private Function CheckUserCPNumAndDate(ByVal userid As String, ByVal schoolyear As String, ByVal positionID As String, ByVal cpnum As String) As String
        Dim positionType As String = hfPositionType1.Value
        '       Dim parameter = CommonParameter.GetParameters(schoolyear, positionID, cpnum)

        Dim hire As New ParametersForOperationHire()
        With hire
            .Operate = "Confirm"
            .UserID = User.Identity.Name
            .SchoolYear = schoolyear
            .PositionType = Me.hfPositionType.Value
            .PositionID = positionID
            .CPNum = cpnum
        End With
        If Left(cpnum, 2) = "NS" Then
            Return "Pass"
        Else
            Dim hiredName = PostingHireExe.HiringTeacherName(hire) '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)

            ' Dim hiredName As String = PositionDetails.getNamebyCPNum(userid, schoolyear, positionID, cpnum)
            If hiredName = "" Then Return "Not"
            If Me.dateEffective.Value = "" Then Return "Not"
            If Me.dateEnd.Value = "" Then
                If positionType = "POP" Then
                    Return "Pass"
                Else
                    Return "Not"
                End If
            Else
                Return "Pass"
            End If
        End If


    End Function
    Private Sub CreateSaveMessage(ByVal strMessage As String, ByVal action As String)
        Try

            Dim strScript As String = "CallBackReloadParent(" + "'" + action + "','" + strMessage + "');"

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


    Private Sub SendCongratulateEmailNotification(ByVal action As String)


    End Sub


    'Private Sub SMTPMailCall(ByVal who As String, ByVal myEmail As EmailNotice2)
    '    Try
    '        Dim emailNotice = New EmailNotification()

    '        Dim logId As String = emailNotice.SaveEmailNotice(myEmail)
    '        Dim result = emailNotice.SendEmail(myEmail)

    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Function GetEmailBody(ByVal _who As String, ByVal action As String, ByVal bodyTemplate As String, ByVal HRContact As Contact) As String


        Dim contact As String = HRContact.Extention
        Dim name As String = HRContact.Name

        ' Dim sDate As DateTime = Now()
        Dim _Datetime As String = DateFC.YMDHMS(Now())
        Dim myHtml As String = Server.MapPath("..") + "\Template\" + bodyTemplate
        Dim eMailFile As String = EmailNotification.EmailHTMLBody(myHtml)

        Dim cpnum As String = IIf(_who = "Union", "", "(" + Me.TextCPNum.Value + ")")

        Try
            eMailFile = Replace(eMailFile, "{{PostingNumberSTR}}", Me.lblPostingNum.Text)
            eMailFile = Replace(eMailFile, "{{TeacherNameSTR}}", Me.HiddenFieldTeacherName.Value)
            eMailFile = Replace(eMailFile, "{{TeacherCPNumSTR}}", cpnum) ' Me.lblTeacherPersonID.Text)
            eMailFile = Replace(eMailFile, "{{TeacherOTPrnrSTR}}", Me.lblTeacherOTPrnr.Text)
            eMailFile = Replace(eMailFile, "{{PrincipalNameSTR}}", Me.hfPrincipalName.Value)
            eMailFile = Replace(eMailFile, "{{DateTimeSTR}}", _Datetime)
            eMailFile = Replace(eMailFile, "{{BTCSTR}}", Me.lblPositionFTE.Text)
            eMailFile = Replace(eMailFile, "{{PositionTitleSTR}}", Me.TextPositionTitle.Text)
            eMailFile = Replace(eMailFile, "{{PositionStartDateSTR}}", Me.dateEffective.Value)
            eMailFile = Replace(eMailFile, "{{PositionEndDateSTR}}", dateEnd.Value)
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

            If Me.hfPositionType.Value = "POP" Then
                eMailFile = Replace(eMailFile, "{{PositionTypeSTR}}", Me.hfPositionType.Value)
                eMailFile = Replace(eMailFile, "{{PositionTypeSTR2}}", Me.hfPositionType.Value)
                eMailFile = Replace(eMailFile, "{{PositionDescriptionSTR}}", TextDescription.Text)
                eMailFile = Replace(eMailFile, "{{PositionPostedSTR}}", "")
                eMailFile = Replace(eMailFile, "{{FormReminderLine}}", "") ' getForm(_teachername)) 
            Else

                Dim absentSection As String = ""

                Dim payStatus As String = ""
                '  If ddlPayStatus.SelectedValue <> "9" Then payStatus = ddlPayStatus.SelectedItem.Text
                absentSection = " <table border = '1' style='width:700px'> <tr> "
                absentSection += "<td style='text-align:left;'>Absent Teacher:</td><td> " + Me.lblTeacherBeReplaced.Text + " </td>"
                absentSection += "<td  style='text-align:right;'>Position Number: </td> <td> " + Me.hfPositionNumber.Value + "</td> "
                absentSection += "<td  style='text-align:right;'>PID: </td> <td> " + Me.lblTeacherBeReplacedPersonID.Text + "</td></tr>"
                If _who = "Staff" Then
                    absentSection += "<tr><td> Reason for leave: </td> <td colspan='5'>" + Me.lblReasonReplacement.Text + "</td></tr>"
                    absentSection += "<tr><td> Employee Status: </td> <td colspan='5'>" + payStatus + "</td></tr>"
                End If
                absentSection += "</table>"
                eMailFile = Replace(eMailFile, "{{AbsentTeacherSection}}", absentSection)


            End If

        Catch ex As Exception
            eMailFile = ""
        End Try
        Return eMailFile

    End Function

    Private Function GetForm(ByVal _teachername As String) As String
        Dim vForm As String = ""
        If Left(Me.hfSchoolCode.Value, 2) = "05" Then
            vForm = "A reminder to please add <span style='text-decoration: underline; font-weight: bolder'>" + _teachername + "</span> on your Form 107"
        End If
        Return vForm
    End Function
    Private Function GetOwner() As String
        Dim schoolcode As String = hfSchoolCode.Value
        Dim appType As String = hfPositionType.Value
        Dim owner As String = Me.lblPositionOwner.Text
        Return DataTools.GetPositionOwner(owner, schoolcode, appType)
    End Function
    Private Sub BtnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        Dim action As String = "ConfirmHire"
        'If Me.chbNoticeToPrincipal.Checked Then ' Or Me.chbHiredNoticeToOfficer.Checked Then
        'End If
        SendConfimeEmailNotification(action)
    End Sub
    Private Function CurrentPosition() As PositionPublish

        Dim position = New PositionPublish()
        With position
            .UserID = User.Identity.Name
            .SchoolYear = Page.Request.QueryString("SchoolYear")
            .SchoolCode = hfSchoolCode.Value
            .PositionID = hfPositionID.Value
            .PostingNumber = Me.lblPostingNum.Text
            .PositionType = hfPositionType.Value
            .PositionTitle = Me.TextPositionTitle.Text
            .PositionLevel = Me.TextPostionLevel.Text
            .Qualification = Me.TextQualification.Text
            .QualificationCode = ""
            .Description = Me.TextDescription.Text
            .FTE = Me.lblPositionFTE.Text
            .FTEPanel = ""
            .StartDate = DateFC.YMD2(Me.dateEffective.Value)
            .EndDate = DateFC.YMD2(dateEnd.Value)
            .DatePublish = ""
            .DateApplyOpen = ""
            .DateApplyClose = ""
            .Comments = ""
            .ReplaceTeacherID = Me.lblTeacherBeReplacedPersonID.Text
            .ReplaceTeacher = Me.lblTeacherBeReplaced.Text
            .ReplaceReason = Me.lblReasonReplacement.Text
            .OtherReason = ""
            .Owner = Me.lblPositionOwner.Text
            .PostingCycle = Me.lblPostingCycle.Text
            .PrincipalID = hfPrincipalID.Value
            .PrincipalName = Me.hfPrincipalName.Value
        End With
        Return position
    End Function
End Class

