'Imports System.Data
'Imports System.Data.SqlClient
'Imports System.IO
Imports AppOperate
Imports ClassLibrary
'Imports Microsoft.ApplicationInsights.Telemetry.Services
'Imports TCDSB.Student


Partial Class ApplyPosition2
    Inherits System.Web.UI.Page
    Dim SPFile As String = SPSource.SPFile() '  WebConfigValue.SPFile() 
    Dim cPage As String = "Applying"
    Dim paraForApply As New ParametersForApply
    '  Dim paraForPosition As New ParametersForPosition

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
    Private Sub ApplyPosition2_Error(sender As Object, e As EventArgs) Handles Me.[Error]
        Dim me1 As String = ""
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Page.Response.Expires = 0
            paraForApply.SchoolYear = Page.Request.QueryString("SchoolYear")
            paraForApply.PositionID = Page.Request.QueryString("PositionID")
            paraForApply.CPNum = Page.Request.QueryString("CPNum")
            If paraForApply.CPNum = Nothing Then paraForApply.CPNum = WorkingProfile.UserCPNum
            hfUsingMostRecentResume.Value = "No"
            BindPosition()
            If WorkingProfile.UserID = "mif" Then
                Me.OnBehalfRom.Visible = True
                Dim parameter As New List2Item()
                With parameter
                    .Operate = "Applicant"
                    .Para0 = WorkingProfile.SchoolYear
                    .Para1 = ""
                    .Para2 = WorkingProfile.UserRole
                    .Para3 = "%"
                End With
                '  AssembleListItem.SetLists(Me.ddlApplicant, "Applicant", parameter, Page.Request.QueryString("CPNum"))
                AssemblingList.SetLists("", Me.ddlApplicant, "Applicant", parameter, paraForApply.CPNum)
            End If

            '  Dim parameter1 = New With {Key .SchoolYear = WorkingProfile.SchoolYear, .Type = "Status", .ID = paraForApply.CPNum}

            '  hfStatus.Value = ApplicantAttribute.OTType(parameter1)
            If hfStatus.Value = "LeavePending" Then
                LabelMessageStatus1.Text = hfStatus.Value
                LabelMessageStatus2.Text = hfStatus.Value
                btnApply.Enabled = False
            End If
        End If

    End Sub
    Private Sub BindPosition()

        Try
            Dim position = GetApplyForPosition()

            Me.TextPositionID.Text = getMyValue(position.PostingNumber)
            Me.hfSchoolyear.Value = paraForApply.SchoolYear
            hfCPNum.Value = paraForApply.CPNum
            hfPositionID.Value = paraForApply.PositionID

            Dim _Role As String = WorkingProfile.UserRole

            Me.TextPositionTitle.Text = getMyValue(position.PositionTitle)
            Me.TextStatus.Text = getMyValue(position.PositionState)
            Me.TextPositionDescription.Text = getMyValue(position.Description)
            Me.TextPostionQualification.Text = getMyValue(position.Qualification)
            Me.TextArea.Text = getMyValue(position.SchoolArea)

            Me.TextApplyEndDate.Text = getMyValue(position.DateApplyClose)
            Me.TextStartDate.Text = getMyValue(position.StartDate)
            Me.TextEndDate.Text = getMyValue(position.EndDate)
            Me.TextSchool.Text = getMyValue(position.SchoolName)
            Me.textPrincipal.Text = getMyValue(position.PrincipalName)
            Me.TextAddress.Text = getMyValue(position.SchoolAddress)
            Me.textPhonenumber.Text = getMyValue(position.SChoolPhone)
            Me.TextStartTime.Text = getMyValue(position.StartTime)

            Me.TextApplyDate.Text = getMyValue(position.ApplyDate)
            Me.HiddenFieldApply.Value = getMyValue(position.ApplyAction)
            Me.TextFTE.Text = getMyValue(position.FTE)
            Me.TextPanel.Text = getMyValue(position.FTEPanel)
            Me.TextComemnts.Text = getMyValue(position.Comments)
            Me.TextHomePhone.Text = getMyValue(position.HomePhone)
            Me.TextCellPhone.Text = getMyValue(position.CellPhone)
            Me.TexteMail.Text = getMyValue(position.Email)
            Me.hfTeacherName.Value = getMyValue(position.TeacherName)
            Me.LabelApplicant.Text = getMyValue(position.TeacherName) + " (" + paraForApply.CPNum + ")"
            Me.TextPostionLevel.Text = BasePage.getMyValue(position.PositionLevel)
            Me.hfPositionType.Value = BasePage.getMyValue(position.PositionType)
            Me.LabelcurrentAssignmentSchool.Text = BasePage.getMyValue(position.CurrentSchool)

            Me.LabelcurrentAssignment.Text = BasePage.getMyValue(position.CurrentAssignment)

            Me.LabelCurrentAssignmentStartDate.Text = BasePage.getMyValue(position.CurrentStartDate)
            Me.LabelCurrentAssignmentEndDate.Text = BasePage.getMyValue(position.CurrentEndDate)
            Me.lblCurrentFTE.Text = "FTE: " + CType(BasePage.getMyValue(position.CurrentFTE), String)
            Me.hfFTEPosition.Value = BasePage.getMyValue(position.FTE)
            Me.hfFTECurrent.Value = BasePage.getMyValue(position.CurrentFTE)
            Me.TextPostingCycle.Text = BasePage.getMyValue(position.PostingCycle)
            Me.TextApplicantQualfication.Text = getMyValue(position.OCTQualification)
            Me.hfQualificationCheck.Value = getMyValue(position.QualCheck)
            Me.hfPostedDate.Value = getMyValue(position.DatePublish)
            Me.hfPostingcycle.Value = getMyValue(position.PostingCycleName)
            Me.hfPostingcomments.Value = getMyValue(position.Comments)
            Me.hfResumeTitle.Value = getMyValue(position.ResumeTitle)
            Me.LabelUploadFile.Text = getMyValue(position.UploadFile)
            hfStatus.Value = BasePage.getMyValue(position.CanApply)

            'ViewState("timeTable") = BasePage.getMyValue(position.TimeTable)
            'ViewState("multiSchool") = BasePage.getMyValue(position.MultipleSchool)
            'If ViewState("timeTable") = "" Then
            '    Me.F100TimeTable.Visible = False
            '    Me.F100MultipleSchool.Visible = False
            'Else
            '    Me.F100TimeTable.InnerHtml = ViewState("timeTable")
            '    Me.F100MultipleSchool.InnerHtml = ViewState("multiSchool")
            '    Me.TextPositionDescription.Style.Add("height", "25px")
            'End If



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




            ' Me.btnUpdate.Visible = False
            ' Me.CheckBox1.Visible = False
            Me.LabelApplyDate.Visible = False
            Me.TextApplyDate.Visible = False '   Me.ApplyedDate.Visible = False


            ' ********************* No Need change the Roster *************************************************************************
            Me.btnApply.Enabled = True
            Me.LabelNotQualifyRoster.Visible = False

            'If _Role = "Roster" Then
            '    Me.btnApply.Enabled = False
            '    Me.LabelNotQualifyRoster.Visible = True
            '    If Me.TextPostingCycle.Text = "3" Then
            '        Me.btnApply.Enabled = True
            '        Me.LabelNotQualifyRoster.Visible = False
            '    End If
            'Else
            '    Me.btnApply.Enabled = True
            'End If
            ' *****************************************************************************************************
            If Me.HiddenFieldApply.Value = "Applied" Then
                Me.btnApply.Text = "Rescind Application"
                Me.HiddenFieldApply.Value = "Cancel"
                Me.btnUpdate.Visible = True
                '    Me.CheckBox1.Visible = True
                Me.LabelApplyDate.Visible = True
                Me.TextApplyDate.Visible = True
                '  Me.ApplyedDate.Visible = True
                ' Me.ApplyedDate.InnerHtml = Me.ApplyedDate.InnerHtml + getMyValue(position(15))
            ElseIf Me.HiddenFieldApply.Value = "Cancel" Then
                '  Me.btnApply.Text = "Cancel Applied"
                Me.LabelApplyDate.Visible = True
                Me.LabelApplyDate.Text = "Canceled date:"
                Me.TextApplyDate.Visible = True
                Me.HiddenFieldApply.Value = "Applied"
            Else
                Me.HiddenFieldApply.Value = "Applied"
            End If

            If WorkingProfile.UserRole = "TOTL" Then
                Me.btnApply.Enabled = False
            Else
                Dim TodayDate As DateTime = Date.Now
                If TodayDate > Me.TextApplyEndDate.Text Then
                    Me.btnApply.Enabled = False
                End If
            End If
            Me.LabelNotQualify.Visible = False


        Catch ex As Exception
            Dim em As String = ex.Message

        End Try
    End Sub
    Private Function GetApplyForPosition() As PositionApplying

        '  Dim parameter = CommonParameter.GetParameters(paraForPosition.SchoolYear, paraForPosition.PositionID, paraForPosition.CPNum)
        '   Dim SP As String = CommonListExecute(Of PositionApplying).ObjSP("PositionApplying")
        '  Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "Position") ' CommonListExecute(Of PositionApplying).ObjSP("PositionApplying")

        If User.Identity.Name = "mif" Then
            '  Dim SP1 As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "Applied") '  CommonOperationExcute(Of ParametersForApply).ObjSP("ParameterForApply", "Applied")
            Me.lblPostingNumber.ToolTip = ApplyProcessExe.SPName("Position")
            Me.btnApply.ToolTip = ApplyProcessExe.SPName("Applied")

        End If

        Dim position = ApplyProcessExe.Position(paraForApply)(0) '  CommonExcute(Of PositionApplying).GeneralList(SP, paraForApply)(0) '   CommonListExecute.AllPositionList(Of PositionApplying)(paraForPosition)(0)
        Return position

    End Function
    Private Function checkApplybyFTE(ByVal cFTE As String, ByVal cSdate As String, ByVal cEdate As String, ByVal pFTE As String, ByVal pSdate As String, ByVal pEdate As String) As String
        Dim rVal As String = "Yes"
        Dim FTE1 As Decimal = 0
        Dim FTE2 As Decimal = 0
        Dim pType As String = Me.hfPositionType.Value

        If pType = "LTO" Then
            Try
                FTE1 = System.Convert.ToDecimal(cFTE)
            Catch
                FTE1 = 0
            End Try
            Try
                FTE2 = System.Convert.ToDecimal(pFTE)
            Catch
                FTE2 = 0
            End Try

            If pSdate < cEdate Then
                If FTE1 + FTE2 > 1.0 Then
                    rVal = "No"
                End If
            End If
        End If
        Return "Yes" ' rVal      -- no need check the assignment start date and FTE in Serverside, Client Javascript will check
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




    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Me.HiddenFieldAction.Value = "Yes"
        Dim action As String = "Update Apply Info"
        ' If Me.CheckBox1.Checked Then action = "Update Contact Info"

        Dim parameter As New ApplicantContact()
        With parameter
            .Operate = "Update"
            .CPNum = WorkingProfile.UserCPNum
            .HomePhone = Me.TextHomePhone.Text
            .CellPhone = Me.TextCellPhone.Text
            .Email = BasePage.EmailCheck(Me.TexteMail.Text)
            .PositionID = Page.Request.QueryString("PositionID")
        End With
        '   Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "ContactInfo")
        Dim result = ApplyProcessExe.UpdateContact(parameter) '  CommonExcute(Of ApplicantContact).GeneralValue(SP, parameter) '  CommonOperationExcute.ApplicantContactUpdate(parameter, "ContactInfo")
        '   CreatSaveMessage(result, action)
    End Sub

    Private Sub CreatSaveMessage(ByVal strMessage As String, ByVal action As String)
        Try
            Dim positionTitle As String = Me.TextPositionTitle.Text
            Dim _fun As String = " CallReloadParent(" + "'" + action + "','" + positionTitle + "','" + strMessage + "')"
            ClientScript.RegisterStartupScript(GetType(String), "_script", _fun, True)



            '  *** AJAX Save Message
            '  ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType, "save_script", strScript.ToString(), True)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub sendemailNotification(ByVal action As String, ByVal teacherName As String, ByVal mTo As String)

        ' Dim mTo As String = mTo 'EmailNotification.UserProfileByID("TCDSBeMailAddress", HttpContext.Current.User.Identity.Name)
        ' Dim _mCC As String = ""
        ' Dim appType As String = Me.hfPositionType.Value
        ' Dim _mFrom As String = email.FromUser(appType)
        '    SMTPMailCall(action, teacherName, mTo, "", _mFrom)


        Dim position = CurrentPosition()
        Dim userId As String = User.Identity.Name
        Dim email = New PostingNotification(position)


        Dim JsonFile As String = Server.MapPath("..\Content\eMailTemplate.json")

        Dim myEmail As New EmailNotice2()

        myEmail = email.GetEmailNotice(JsonFile, action, "Applicant", userId)
        myEmail.EmailTo = mTo
        myEmail.EmailBody = GetEmailBody(action, teacherName, myEmail.EmailBody)

        SMTPMailCall("Applicant", myEmail)


    End Sub

    Private Sub SMTPMailCall(ByVal action As String, ByVal myEmail As EmailNotice2)
        Try

            Dim LogID As String = EmailNotification.SaveEmailNotice(myEmail)
            Dim result = EmailNotification.SendEmail(myEmail)

        Catch ex As Exception

        End Try
    End Sub
    'Private Sub SMTPMailCall(ByVal action As String, ByVal teacherName As String, ByVal _mTO As String, ByVal _mCC As String, ByVal _mFrom As String)


    '    Try
    '        Dim JsonFile As String = Server.MapPath("..\Content\eMailTemplate.json")
    '        Dim myEmailTemple = EmailNotification.EmailSubjectAndTemple(JsonFile, WorkingProfile.ApplicationType, action)
    '        Dim mSubject As String = Replace(myEmailTemple.Subject, "PositionTitle", Me.TextPositionTitle.Text + " " + Me.btnApply.Text)


    '        Dim eMailBody As String = GetEmailBody(action, teacherName)

    '        Dim mBcc As String = WebConfigValue.getValuebyKey("eMailBCC")
    '        Dim publicFolder As String = WebConfigValue.getValuebyKey("LTOadminFolder")

    '        mBcc = mBcc + publicFolder


    '        Dim myEmail As New EmailNotice2()
    '        With myEmail
    '            .UserID = User.Identity.Name
    '            .SchoolYear = paraForApply.SchoolYear
    '            .SchoolCode = Page.Request.QueryString("SchoolCode")
    '            .PositionType = Me.hfPositionType.Value
    '            .PositionID = paraForApply.PositionID
    '            .PositionTitle = Me.TextPositionTitle.Text
    '            .PostingNum = Me.TextPositionID.Text
    '            .NoticePrincipal = teacherName
    '            .NoticeFor = "Teacher"
    '            .EmailType = action
    '            .EmailTo = _mTO
    '            .EmailCC = _mCC
    '            .EmailBcc = mBcc
    '            .EmailFrom = _mFrom
    '            .EmailSubject = mSubject
    '            .EmailBody = eMailBody
    '            .EmailFormat = "HTML"
    '            .Attachment1 = ""
    '            .Attachment2 = ""
    '            .Attachment3 = ""
    '        End With

    '        Dim LogID As String = EmailNotification.SaveEmailNotice(myEmail)
    '        Dim result = EmailNotification.SendEmail(myEmail)

    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Function GetEmailBody(ByVal action As String, ByVal teacherName As String, ByVal bodyTemplate As String) As String



        Dim sDate As DateTime = Now()
        Dim _Datetime As String = sDate.ToString

        'Dim appType As String = Me.hfPositionType.Value
        'Dim JsonFile As String = Server.MapPath("..\Content\eMailTemplate.json")
        'Dim myEmailTemple = EmailNotification.EmailSubjectAndTemple(JsonFile, appType, action)
        Dim myHtml As String = Server.MapPath("..") + "\Template\" + bodyTemplate
        Dim eMailFile As String = EmailNotification.EmailHTMLBody(myHtml)

        Dim startDateStr As String = " Start date:" + Me.TextStartDate.Text
        Dim endDateStr As String = ",   End date:" + Me.TextEndDate.Text
        Dim discription As String = Me.TextPostionLevel.Text + ", " + Me.TextPostionQualification.Text + ", " + Me.TextPositionDescription.Text
        If Me.hfPositionType.Value = "POP" Then endDateStr = ""

        Try
            eMailFile = Replace(eMailFile, "[PostingNumberSTR]", Me.TextPositionID.Text)
            eMailFile = Replace(eMailFile, "[PostingRoundSTR]", "") 'Me.TextPostingCycle.Text)
            eMailFile = Replace(eMailFile, "[TeacherNameSTR]", teacherName)
            eMailFile = Replace(eMailFile, "[PrincipalNameSTR]", Me.textPrincipal.Text)
            eMailFile = Replace(eMailFile, "[DateTimeSTR]", _Datetime)
            eMailFile = Replace(eMailFile, "[SchoolNameSTR]", Me.TextSchool.Text)
            eMailFile = Replace(eMailFile, "[PositionTitleSTR]", Me.TextPositionTitle.Text)
            eMailFile = Replace(eMailFile, "[PositionDateSTR]", startDateStr + endDateStr)
            eMailFile = Replace(eMailFile, "[PositionDescriptionSTR]", discription) ' + ";  (" + Me.hfPostingcycle.Value + " posting) ")
            eMailFile = Replace(eMailFile, "[BTCSTR]", GetFte()) ' Me.TextPositionFTE.Text)

            eMailFile = Replace(eMailFile, "[timeTable]", ViewState("timeTable"))
            eMailFile = Replace(eMailFile, "[multiSchool]", ViewState("multiSchool"))


        Catch ex As Exception
            eMailFile = ""
        End Try
        Return eMailFile

    End Function
    Private Function GetFte() As String
        Dim sVal = Me.TextFTE.Text
        Dim fte As String = sVal.ToString() '  (sVal / 100).ToString()
        If fte = "1" Then fte = "1.00"
        Return fte
    End Function
    Private Sub ddlApplicant_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlApplicant.SelectedIndexChanged


        Dim action As String = Me.HiddenFieldApply.Value
        With paraForApply
            .Operate = "OCTQualification"
            .Comments = Me.TextComemnts.Text
            .SchoolYear = Page.Request.QueryString("SchoolYear")
            .CPNum = ddlApplicant.SelectedValue ' Page.Request.QueryString("CPNum")
            .PositionID = Page.Request.QueryString("PositionID")
            .UserID = User.Identity.Name
            .Action = Me.HiddenFieldApply.Value
        End With
        Dim result = ApplyProcessExe.OCTQualfication(paraForApply) '   CommonOperationExcute.ApplyingOperation(paraForApply, "OCTQualification")
        Me.TextApplicantQualfication.Text = result

        If Left(result, 3) = "Yes" Then
            Me.btnApplyOnBehalf.Enabled = True
        Else
            Me.btnApplyOnBehalf.Enabled = False
        End If
    End Sub
    Private Sub btnApplyOnBehalf_Click(sender As Object, e As EventArgs) Handles btnApplyOnBehalf.Click
        Me.HiddenFieldAction.Value = "Yes"
        Dim action As String = "Applied"
        With paraForApply
            .Operate = "AppliedOnBehalf"
            .Comments = Me.TextComemnts.Text
            .SchoolYear = Page.Request.QueryString("SchoolYear")
            .CPNum = Me.ddlApplicant.SelectedValue
            .PositionID = Page.Request.QueryString("PositionID")
            .UserID = User.Identity.Name
            .Action = action
        End With
        ' Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, action)
        ' Dim result = CommonExcute(Of ParametersForApply).GeneralValue(SP, paraForApply) '

        Dim mTo = ApplyProcessExe.Appied(paraForApply) '  CommonExcute(Of ParametersForApply).GeneralValue(SP, paraForApply) ' CommonOperationExcute.ApplyingOperation(paraForApply, action)

        sendemailNotification(action, ddlApplicant.SelectedItem.Text, mTo)

        CreatSaveMessage(mTo, action)


    End Sub

    Protected Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        Try
            Me.HiddenFieldAction.Value = "Yes"
            Dim action As String = Me.HiddenFieldApply.Value
            With paraForApply
                .Operate = action
                .Action = action
                .Comments = Me.TextComemnts.Text
                .SchoolYear = Page.Request.QueryString("SchoolYear")
                .CPNum = Page.Request.QueryString("CPNum")
                .PositionID = Page.Request.QueryString("PositionID")
                .UserID = User.Identity.Name
                .Document = Me.hfUsingMostRecentResume.Value
            End With
            '  Dim usingMostRecent As String = Me.hfUsingMostRecentResume.Value
            '  Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, action)
            Dim result = ApplyProcessExe.Appied(paraForApply) ' CommonExcute(Of ParametersForApply).GeneralValue(SP, paraForApply) '  CommonOperationExcute.ApplyingOperation(paraForApply, action)
            If result = "Successfully" Then
                Dim mTo As String = Me.TexteMail.Text
                sendemailNotification(action, hfTeacherName.Value, mTo) ' User.Identity.Name + "@tcdsb.org")
                CreatSaveMessage(result, action)

            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Function CurrentPosition() As PositionPublish

        Dim position = New PositionPublish()
        With position
            .UserID = User.Identity.Name
            .SchoolYear = hfSchoolyear.Value
            .SchoolCode = Page.Request.QueryString("SchoolCode")
            .PositionID = paraForApply.PositionID
            .PositionType = Me.hfPositionType.Value
            .PostingNumber = Me.TextPositionID.Text
            .PositionTitle = Me.TextPositionTitle.Text
            .PositionLevel = Me.TextPostionLevel.Text
            .Qualification = Me.TextPostionQualification.Text
            .QualificationCode = ""
            .Description = Me.TextPositionDescription.Text
            .FTE = GetFte()
            .FTEPanel = ""
            .StartDate = DateFC.YMD2(Me.TextStartDate.Text)
            .EndDate = DateFC.YMD2(Me.TextEndDate.Text)
            .Comments = Me.TextComemnts.Text
            .PostingCycle = Me.TextPostingCycle.Text
            .PrincipalName = Me.textPrincipal.Text
        End With

        Return position
    End Function

End Class

