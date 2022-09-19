'Imports System.Data

'Imports System.IO

Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services
Imports AppOperate
Imports ClassLibrary
Imports System.Threading.Tasks

Partial Class RequestPositionDetails2
    Inherits System.Web.UI.Page
    Dim jsonFile As String = Server.MapPath("..\Content\eMailTemplate.json")
    Dim jsonFileHRstaff As String = Server.MapPath("..\Content\HRStaff.json")

    ' Dim DataAccesssFile As String = "" ' Server.MapPath("..\Content\DataAccess.json")
    '  Dim SPFile2 As String = Server.MapPath("..\Content\DataAccessSP.json")
    Dim _cPage As String = "Publish"


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
            Me.Page.Response.Expires = 0

            CheckButtonAction()


            Dim schoolYear As String = Page.Request.QueryString("SchoolYear")
            Dim positionId As String = Page.Request.QueryString("PositionID")
            Dim schoolCode As String = Page.Request.QueryString("SchoolCode")

            If schoolCode = Nothing Or schoolCode = "undefiend" Then
                schoolCode = WorkingProfile.SchoolCode
            Else
                WorkingProfile.SchoolCode = schoolCode
            End If
            AssiblingPage(schoolYear, schoolCode, positionId)

            If positionId = "0000" Then
                AddNewPosition()
                Me.ddlPositionlevel.SelectedIndex = 1
            Else
                BindSelectedPositionData(schoolYear, positionId)

            End If


            If WorkingProfile.ApplicationType = "POP" Then
                RowofTeacherBeingReplaced.Visible = False
                'Me.ddlTeacherReplaced.Visible = False
                '  Me.ddlReason.Visible = False
            End If
            ddlType.Enabled = False

            If WorkingProfile.LoginRole = "Admin" Then chbCancel.Visible = True
        End If

    End Sub
    Private Sub CheckButtonAction()
        btnEmail.Enabled = False
        btnCancel.Visible = False
        btnPosting.Visible = False
        btnRepublish.Visible = False

        Dim action As String = Page.Request.QueryString("Action")
        If action = "NewPosting" Then
            btnPosting.Visible = True
            btnPosting.Enabled = False

        Else
            btnEmail.Enabled = True
            btnCancel.Visible = True
            btnRepublish.Visible = True
        End If

    End Sub
    Private Sub AssiblingPage(ByVal schoolyear As String, ByVal schoolcode As String, ByVal positionId As String)
        hfAppType.Value = WorkingProfile.ApplicationType
        hfUserRole.Value = WorkingProfile.UserRole
        hfSchoolyear.Value = schoolyear
        hfUserID.Value = WorkingProfile.UserID
        Dim parameter As New List2Item()
        With parameter
            .Operate = "Schoolist"
            .Para0 = WorkingProfile.UserID
            .Para1 = WorkingProfile.UserRole
            .Para2 = WorkingProfile.ApplicationType
            .Para3 = schoolyear
        End With
        ' AssembleListItem.SetLists2(ddlschoolcode, Me.ddlSchool, parameter, schoolcode)
        AssemblingList.SetListSchool(ddlschoolcode, Me.ddlSchool, "SchoolList", parameter, schoolcode)

        With parameter
            .Para0 = schoolyear
            .Para1 = schoolcode
            .Para3 = positionId
        End With
        AssemblingList.SetLists("", Me.ddlHRStaff, "HRStaffPosting", parameter)
        AssemblingList.SetLists("", Me.ddlPositionlevel, "PositionLevel", parameter)
        AssemblingList.SetLists("", Me.ddlReason, "LeaveReason", parameter)
        AssemblingList.SetLists("", Me.ddlPrincipal, "SchoolPrincipal", parameter)
        AssemblingList.SetLists("", Me.ddlType, "ApplicationType", parameter, WorkingProfile.ApplicationType)
        AssemblingList.SetLists("", Me.cblQualification, "Qualification_RequestP", parameter)
        AssemblingList.SetLists("", Me.rblFTE, "FTEList", parameter)
        ' AssemblingList.SetLists("", Me.ddlPostingCycle, "PostingCycle", parameter)
        ' AssemblingList.SetLists("", Me.ddlTeacherReplaced, "SchoolTeacherList", parameter)
        Dim divHeight As String = "80px"
        If Me.cblQualification.Items.Count > 15 Then divHeight = "200px"
        cblQualficationDIV.Style.Add("height", divHeight)
        'AssembleListItem.SetLists(Me.ddlHRStaff, "HRStaffPosting", parameter)
        'AssembleListItem.SetLists(Me.ddlPositionlevel, "PositionLevel", parameter)
        'AssembleListItem.SetLists(Me.ddlReason, "LeaveReason", parameter)
        'AssembleListItem.SetLists(Me.ddlPrincipal, "SchoolPrincipal", parameter)
        'AssembleListItem.SetLists(Me.ddlType, "ApplicationType", parameter, WorkingProfile.ApplicationType)
        'AssembleListItem.SetLists(Me.cblQualification, "Qualification_RequestP", parameter)
        'AssembleListItem.SetLists(Me.rblFTE, "FTEList", parameter)
        'AssembleListItem.SetLists(Me.ddlTeacherReplaced, "SchoolTeacherList", parameter)

    End Sub
    '   Private   Function GetDataSource(ByVal schoolyear As String, ByVal positionId As String) As  PositionPublish 
    Private Async Function GetDataSource(ByVal schoolyear As String, ByVal positionId As String) As Task(Of PositionPublish)

        Dim userid As String = HttpContext.Current.User.Identity.Name
        Me.hfSchoolyear.Value = schoolyear

        Dim para = CommonParameter.GetParameters(schoolyear, positionId)
        '  Dim para = New With {.SchoolYear = schoolyear, .PositionID = positionId}

        ' Dim position = PublishPositionExe(Of PositionPublish).Position(para)(0)

        '  Dim SP As String = CommonExcute.SPNameAndParameters(DataAccesssFile, cPage, "Position") '  CommonExcute.SPNameAndParameters(SPFile, cPage, "Position")
        If User.Identity.Name = "mif" Then

            Me.lblPostingNumber.ToolTip = PublishPositionExe(Of String).SpName("Position")
            Me.btnSave.ToolTip = PublishPositionExe(Of String).SpName("Update")
            Me.btnCancel.ToolTip = PublishPositionExe(Of String).SpName("Cancel")
            Me.btnRepublish.ToolTip = PublishPositionExe(Of String).SpName("RePosting")
            Me.MultipleSchoolimg.Attributes.Add("title", MultipleSchoolsExe.SPName("MultipleSchools"))

        End If

        ' Dim position = Await PublishPositionExeAsync(Of PositionPublish).Position(para)
        ' Return Await position
        Return Await PublishPositionExeAsync(Of PositionPublish).Position(para)

    End Function
    Protected Async Sub BindSelectedPositionData(ByVal schoolyear As String, ByVal positionId As String)
        Try

            Dim position = Await GetDataSource(schoolyear, positionId) '  SinglePosition.PositionByID(parameter)

            Me.hfIDs.Value = BasePage.getMyValue(position.PositionID)
            Me.TextPostingNumber.Text = BasePage.getMyValue(position.PostingNumber)
            Me.TextPositionTitle.Text = BasePage.getMyValue(position.PositionTitle)

            'Me.TextQualification.Text = BasePage.getMyValue(position.Qualification)
            Me.hfQualificationsCode.Value = BasePage.getMyValue(position.QualificationCode)
            Me.lblQualification.Value = BasePage.getMyValue(position.Qualification)
            AssemblingList.SetValueMultiple(cblQualification, BasePage.getMyValue(position.QualificationCode))

            Me.TextPositionDescription.Text = BasePage.getMyValue(position.Description)

            AssemblingList.SetValue(Me.ddlFTEPanel, position.FTEPanel)
            AssemblingList.SetValue(rblFTE, ConvertFte(BasePage.getMyValue(position.FTE)))
            If rblFTE.SelectedValue = "" Then
                Me.TextFTE.Text = ConvertFte(BasePage.getMyValue(position.FTE))
                AssemblingList.SetValue(rblFTE, "00")
            End If
            Me.dateStart.Value = BasePage.getMyValue(position.StartDate)
            Me.dateEnd.Value = BasePage.getMyValue(position.EndDate)
            Me.datePublish.Value = BasePage.getMyValue(position.DatePublish)
            Me.dateApplyStart.Value = BasePage.getMyValue(position.DateApplyOpen)
            Me.dateDeadline.Value = BasePage.getMyValue(position.DateApplyClose)

            Me.TextSource.Text = BasePage.getMyValue(position.RequestSource)
            Me.TextStatus.Text = BasePage.getMyValue(position.PostingState)

            AssemblingList.SetValue(Me.ddlHRStaff, position.Owner)
            Dim schoolcode As String = BasePage.getMyValue(position.SchoolCode)

            AssemblingList.SetValue(Me.ddlSchool, schoolcode)
            AssemblingList.SetValue(Me.ddlschoolcode, schoolcode)

            Dim postionLevel As String = BasePage.getMyValue(position.PositionLevel)
            AssemblingList.SetValue(Me.ddlPositionlevel, postionLevel)
            Me.TextPostedComment.Text = BasePage.getMyValue(position.Comments)
            Me.TextLinkPositionID.Text = BasePage.getMyValue(position.LinkPositionID)
            Me.lblPostedState.Text = BasePage.getMyValue(position.PostingState)
            Me.lblPostedCycle.Text = BasePage.getMyValue(position.PostingRound)

            Me.lblNoticeDate.Value = BasePage.getMyValue(position.DateNotice)
            Me.lblRemainderDate.Value = BasePage.getMyValue(position.DateRemaider)
            Me.lblPostRound.Value = BasePage.getMyValue(position.PostingCycle)
            Me.hfApplicant.Value = BasePage.getMyValue(position.Applicant)

            ' ***************** 2nd and 3rd Round posting no long needs *******************************
            'Dim posting As Integer = BasePage.getMyValue(position.PostingCycle)
            'AssemblingList.SetValue(Me.ddlPostingCycle, CType(posting + 1, String))

            AssemblingList.SetValue(Me.ddlPostingCycle, CType(4, String))
            '********************************************************************************

            ' ********** Replace replaceteacherid dropdown list with lable *************************
            ' AssemblingList.SetValue(ddlTeacherReplaced, BasePage.getMyValue(position.ReplaceTeacherID))
            hfAutoCompletSelectedID.Value = position.ReplaceTeacherID
            lblTeacherName.Value = position.ReplaceTeacher
            '*************************************************************************

            AssemblingList.SetValue(ddlReason, BasePage.getMyValue(position.ReplaceReason))
            AssemblingList.SetValue(ddlPrincipal, BasePage.getMyValue(position.PrincipalID))
            Me.hfPositionOwner.Value = BasePage.getMyValue(position.Owner)
            Me.hfPrincipalID.Value = BasePage.getMyValue(position.PrincipalID)
            Me.hfAppType.Value = BasePage.getMyValue(position.PositionType)
            Me.hfPositionLevel.Value = Me.ddlPositionlevel.SelectedItem.Text
            hfTitle.Value = position.PositionTitle
            hfStartDate.Value = position.StartDate
            hfEndDate.Value = position.EndDate
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


            If Not position.HiredInformation = "No" Then
                Me.btnCancel.Enabled = False
                Me.btnRepublish.Enabled = False
                btnRepublish.ToolTip = position.HiredInformation
                btnSave.ToolTip = position.HiredInformation
            Else
                If Left(Me.lblPostedState.Text, 6) = "Cancel" Then
                    Me.btnCancel.Enabled = False
                    Me.btnSave.Enabled = False
                    Me.btnRepublish.Enabled = False

                    btnRepublish.ToolTip = position.HiredInformation
                End If

            End If
            If position.PositionState = "Close" Then
                Me.btnCancel.Enabled = False
                Me.btnRepublish.Enabled = False
                Me.btnSave.Enabled = False
                If hfUserRole.Value = "Admin" Then
                    Me.btnSave.Enabled = True
                    If User.Identity.Name = "mif" Then
                        Me.btnCancel.Enabled = True
                        Me.btnRepublish.Enabled = True
                    End If

                End If
            End If

            If position.CanRecover = "Yes" Then
                btnCancel.Visible = False
                btnRecover.Visible = True
            End If
            '   WorkingProfile.ApplicationType = Me.hfAppType.Value
            SetStartandEndDate()
            '  CheeckAction()
        Catch ex As Exception
            Dim exm As String = ex.Message
        End Try

    End Sub
    Private Sub CheckControlReadonly()
        If Not (Me.TextSource.Text = "LTOPOP" And Me.TextStatus.Text = "New Posting") Then

        End If
    End Sub
    Private Sub CheeckAction()
        Me.btnSave.Enabled = False
        Me.btnEmail.Enabled = False
        Me.btnRepublish.Enabled = False
        Me.btnCancel.Enabled = False
        Dim filterAction As String = Page.Request.QueryString("FilerAction")
        If filterAction = "PendingConfirm" Then
            SetControlReadonly(True)
        Else
            SetControlReadonly(False)
        End If

        If Me.lblPostedState.Text = "New Posting" Then
            Me.btnEmail.Enabled = True
            Me.btnRepublish.Enabled = True
            Me.btnCancel.Enabled = True
        End If

    End Sub
    Private Function ConvertFte(ByVal value As Object) As String
        Dim fte As Integer = value * 100
        'Dim fte As String = ().ToString()
        Return fte.ToString()
    End Function

    Private Sub SetStartandEndDate()
        Try
            Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
            Dim positionType = hfAppType.Value
            DefaultDate.SetDate(schoolyear, positionType, Me.dateStart, Me.dateEnd, Me.datePublish, Me.dateApplyStart, Me.dateDeadline, hfSchoolyearStartDate, hfSchoolyearEndDate)

        Catch ex As Exception

        End Try



    End Sub
    Private Sub SetControlReadonly(ByVal mylock As Boolean)
        Me.RemainderMessageRow.Visible = mylock
        '  Me.btnEmail.Visible = mylock
        Me.dateStart.Disabled = mylock
        Me.dateEnd.Disabled = mylock
        Me.datePublish.Disabled = mylock
        Me.dateDeadline.Disabled = mylock
        Me.ddlSchool.Enabled = Not mylock
        Me.ddlschoolcode.Enabled = Not mylock
        Me.cblQualification.Enabled = Not mylock
        Me.TextPostedComment.Enabled = Not mylock
        Me.TextPositionTitle.Enabled = Not mylock
        Me.ddlPositionlevel.Enabled = Not mylock
        Me.TextPositionDescription.Enabled = Not mylock
    End Sub
    Protected Sub AddNewPosition()
        Me.ddlSchool.ClearSelection()
        Me.ddlschoolcode.ClearSelection()
        Me.btnCancel.Enabled = False
        Me.btnRepublish.Enabled = False
        Me.RemainderMessageRow.Visible = False
        SetStartandEndDate()
        Dim schoolcode As String = Page.Request.QueryString("SchoolCode")
        AssemblingList.SetValue(Me.ddlSchool, schoolcode)
        AssemblingList.SetValue(Me.ddlschoolcode, schoolcode)
    End Sub

    Protected Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim ds As Int16
        ds = Me.hfIDs.Value
        Dim action As String = "Update"
        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        '  If IDs = "0" Then action = "Insert"
        Try
            '   Dim position1 As New PositionPublish()
            Dim position1 = New With
            {
                .Operate = action,
                .UserID = User.Identity.Name,
                .SchoolYear = schoolyear,
                .SchoolCode = Me.ddlSchool.SelectedValue,
                .PositionID = ds,
                .PositionType = hfAppType.Value,
                .PositionTitle = Me.TextPositionTitle.Text,
                .PositionLevel = ddlPositionlevel.SelectedValue,
                .Qualification = Me.lblQualification.Value,
                .QualificationCode = Me.hfQualificationsCode.Value,
                .Description = Me.TextPositionDescription.Text,
                .FTE = GetFte(),
                .FTEPanel = Me.ddlFTEPanel.SelectedValue,
                .StartDate = DateFC.YMD2(Me.dateStart.Value),
                .EndDate = DateFC.YMD2(Me.dateEnd.Value),
                .DatePublish = DateFC.YMD2(Me.datePublish.Value),
                .DateApplyOpen = DateFC.YMD2(Me.dateApplyStart.Value),
                .DateApplyClose = DateFC.YMD2(Me.dateDeadline.Value),
                .Comments = Me.TextPostedComment.Text,
                .ReplaceTeacherID = hfAutoCompletSelectedID.Value,
                .ReplaceTeacher = lblTeacherName.Value,
                .ReplaceReason = ddlReason.SelectedValue,
                .OtherReason = ddlReason.SelectedItem.Text,
                .Owner = Me.ddlHRStaff.SelectedValue,
                .PrincipalID = ddlPrincipal.SelectedValue
           }

            Dim result As String = PublishPositionExe(Of String).Update(position1)

            Dim noticed As String = Me.lblNoticeDate.Value


            If Not (result = "Successfully" Or result = "Failed") Then
                Me.hfIDs.Value = result
                ds = result
                result = "Successfully"
            End If
            If Me.lblNoticeDate.Value = "" Then
                SendPostingNotification("Posting")
            End If

            CreatSaveMessage1(result, "Save Position")
            BindSelectedPositionData(schoolyear, Me.hfIDs.Value)

            ' btnPosting.Enabled = True
            btnPosting.Visible = False
            btnRepublish.Visible = True

        Catch ex As Exception
            CreatSaveMessage1("Falied", "Save Position")
        End Try

    End Sub
    Private Function GetQualifications() As String
        Dim qual As String = ""
        Dim item As ListItem
        For Each item In Me.cblQualification.Items
            If item.Selected Then
                qual = qual + item.Text + ";"
            End If
        Next

        Return qual
    End Function
    Private Function GetFte() As String
        Dim sVal = Me.rblFTE.SelectedValue
        If sVal = "00" Then
            sVal = Me.TextFTE.Text
        End If
        Dim fte As String = (sVal / 100).ToString()
        If fte = "1" Then fte = "1.00"
        Return fte
    End Function
    Protected Sub BtnSave1_Click(sender As Object, e As EventArgs) Handles btnSave1.Click
        Me.HiddenFieldAction.Value = "Yes"
        Dim schoolyear As String = WorkingProfile.SchoolYear
        Dim ds As String = Me.hfIDs.Value
        ' BindSelectedPositionData(schoolyear, IDs)
    End Sub
    Protected Sub btnRecover_Click(sender As Object, e As EventArgs) Handles btnRecover.Click
        Dim schoolYear As String = Page.Request.QueryString("SchoolYear")
        Dim recoverPosition = New With {Key .UserID = User.Identity.Name,
                                  Key .SchoolYear = schoolYear,
                                  Key .PostingNum = Me.TextPostingNumber.Text,
                                  Key .PositionID = Me.hfIDs.Value
                                  }

        Dim result As String = PublishPositionExe(Of String).Recover(recoverPosition)
        CreatSaveMessage(result, "Recover a Posting")


    End Sub

    Private Sub ButtonGoCancel_Click(sender As Object, e As EventArgs) Handles ButtonGoCancel.Click
        CancellProcess()
    End Sub
    Private Sub CancellProcess()
        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        Dim postingCycle As String = Me.lblPostedCycle.Text
        Dim postingNumber As String = TextPostingNumber.Text


        Dim action As String = "Cancel"
        Try
            Me.HiddenFieldAction.Value = "Yes"

            Dim cancelPosting = New PositionPublish()
            With cancelPosting
                .Operate = action
                .UserID = User.Identity.Name
                .SchoolYear = schoolyear
                .PositionID = Me.hfIDs.Value
                .Comments = Me.TextPostedComment.Text
                .SchoolCode = Me.ddlSchool.SelectedValue
                .PositionType = Me.hfAppType.Value
            End With

            Dim result As String = PublishPositionExe(Of String).Cancel(cancelPosting)
            CheckApplicantsSendNotification("CancelA")
            SendPostingNotification("CancelP")

            If chbCancel.Checked Then
                cancelPosting.Operate = "CancelAndRecoverPre"
                result = PublishPositionExe(Of String).Cancel(cancelPosting)
            End If

            CreatSaveMessage(result, "Cancel Posting")

        Catch ex As Exception
            CreatSaveMessage("Faield", "Cancel Posting")
        End Try
        ' BindSelectedPositionData(schoolyear, Me.hfIDs.Value)
    End Sub
    Protected Sub btnPosting_Click(sender As Object, e As EventArgs) Handles btnPosting.Click
        Try
            SendPostingNotification("Posting")
            CreatSaveMessage("Successfully", "Position posting and Sent Notification email to Principal")

        Catch ex As Exception
            ShowMessage.Exception(ex, Me.Page, "Bind data action")
        End Try
    End Sub
    Protected Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        Try
            '  Re poring process
            Dim action As String = "RePosting"
            Dim ds As String = Me.hfIDs.Value
            Dim postingCycle As String = Me.ddlPostingCycle.SelectedValue

            Me.lblPostRound.Value = postingCycle

            Dim rePosting As New PositionPublish()
            With rePosting
                .Operate = "RePosting"
                .UserID = User.Identity.Name
                .SchoolYear = Page.Request.QueryString("SchoolYear")
                .PositionID = Me.hfIDs.Value
                .PostingCycle = postingCycle
                .TakeApplicant = IIf(Me.CheckBoxgetApplicant.Checked, "Yes", "No")
                .SchoolCode = Me.ddlSchool.SelectedValue
                .PositionType = Me.hfAppType.Value
                .PostingNumber = Me.TextPostingNumber.Text
            End With


            Dim result As String = PublishPositionExe(Of String).RePosting(rePosting) ' CommonExcute(Of PositionPublish).GeneralValue(SP, rePosting)

            If Not (result = "Successfully" Or result = "Failed") Then
                ds = result
                result = "Successfully"
                Dim postingNoticeBegin As String = WebConfigValue.getValuebyKey("PostingNoticeBegin")
                If postingCycle > postingNoticeBegin Then
                    Me.hfIDs.Value = ds
                    SendPostingNotification("Repost")
                End If
                '  no need rebind, page close after reposting   BindSelectedPositionData(schoolyear, ds)
                Me.btnRepublish.Enabled = False
            End If

            CreatSaveMessage(result, "Re-posting")
        Catch ex As Exception
            CreatSaveMessage("Failed", "Re-posting")
        End Try



    End Sub


    Private Sub CreatSaveMessage1(ByVal strMessage As String, ByVal action As String)
        Try

            Dim strScript As String = "ShowSaveMessage(" + """" + action + """,""" + strMessage + """);"
            '  ***  No Ajax
            ClientScript.RegisterStartupScript(GetType(String), "actionMessage", strScript, True)
            '  *** AJAX Save Message
            ' ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType, "save_script", strScript.ToString(), True)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub CreatSaveMessage(ByVal strMessage As String, ByVal action As String)
        Try

            Dim strScript As String = "CallBackReloadParent(" + """" + action + """,""" + strMessage + """);"
            '  ***  No Ajax
            ClientScript.RegisterStartupScript(GetType(String), "actionMessage", strScript, True)
            '  *** AJAX Save Message
            ' ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType, "save_script", strScript.ToString(), True)
        Catch ex As Exception

        End Try

    End Sub


    Protected Sub DDLSchool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSchool.SelectedIndexChanged
        GetSchoolTeacherList(ddlSchool.SelectedValue)
    End Sub

    Protected Sub DDLschoolcode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlschoolcode.SelectedIndexChanged
        GetSchoolTeacherList(ddlschoolcode.SelectedValue)
    End Sub

    Private Sub GetSchoolTeacherList(ByVal schoolcode As String)

        AssemblingList.SetValue(ddlschoolcode, schoolcode)
        AssemblingList.SetValue(ddlSchool, schoolcode)

        '   Me.ddlTeacherReplaced.ClearSelection()

        Me.ddlPositionlevel.ClearSelection()
        Dim parameter As New List2Item()

        With parameter
            .Para0 = WorkingProfile.SchoolYear
            .Para1 = schoolcode
        End With

        '   AssemblingList.SetLists("", Me.ddlTeacherReplaced, "SchoolTeacherList", parameter)

        AssemblingList.SetLists("", Me.ddlPositionlevel, "PositionLevel", parameter)

        Dim parameter1 As New ParametersForOperation()
        With parameter1
            .Operate = "SchoolPrincipalID"
            .UserID = WorkingProfile.UserID
            .SchoolYear = WorkingProfile.SchoolYear
            .SchoolCode = schoolcode
            .PositionID = Me.hfIDs.Value
            .PositionType = hfAppType.Value
        End With


        Dim principalId As String = CommonOperationExcute.GeneralInforamtion(parameter1, "SchoolPrincipalID")

        AssemblingList.SetLists("", Me.ddlPrincipal, "SchoolPrincipal", parameter, principalId)


    End Sub

    Private Sub CheckApplicantsSendNotification(ByVal action As String)

        Try

            Dim position = CurrentPosition()
            Dim email = New EmailNotification(position)
            Dim userId As String = User.Identity.Name

            Dim HRContact = DataTools.GetHRContact(jsonFileHRstaff, GetOwner())

            Dim myEmail As New EmailNotice2()
            myEmail = email.GetEmailNotice(jsonFile, action, "Applicant", userId)

            Dim parameter As New ParametersForCandidate()
            With parameter
                .Operate = "Cancel"
                .SchoolYear = Page.Request.QueryString("SchoolYear")
                .PositionID = Me.hfIDs.Value
            End With

            Dim applicantNoticelist = PublishPositionExe(Of ApplicantNotice).NoticeApplicants(parameter)
            For Each item In applicantNoticelist
                Dim teacherName As String = item.TeacherName
                With myEmail
                    .EmailTo = item.MailTo
                    .EmailCC = ""
                    .EmailBody = GetEmailBody("Applicant", teacherName, action, myEmail.EmailBody, HRContact)
                End With

                email.SMTPMailCall("Applicant", myEmail)
            Next

        Catch ex As Exception

        End Try


    End Sub

    Protected Sub BtnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        Try
            '   SMTPMailCall("Principal", "RePost", _PrincipalID, _mTO, _mCC, _mForm, _PositionTitle, _PrincipalName, _schoolname)
            SendPostingNotification("Posting")


            ' PositionList.PendingConfirmListSave(_User, _schoolyear, _PositionID)
            Dim result As String = "Successfully" ' PositionDetails.NoticeToPrincipal(userid, schoolyear, _PositionID, DateNotice, principalID)

            CreatSaveMessage(result, "Sent reminder email notice to Principal")

        Catch ex As Exception
            ShowMessage.Exception(ex, Me.Page, "Bind data action")
        End Try
    End Sub

    'Private Function GetEmailToList() As String
    '    Dim emailToList As String = ""

    '    emailToList = EmailNotification.UserProfileByID("TCDSBeMailAddress", hfPrincipalID.Value) '      Me.hfPrincipalID.Value + "@TCDSB.ORG"
    '    emailToList += EmailNotification.GetMultipleSchoolEmail(hfSchoolyear.Value, ddlSchool.SelectedValue, Me.hfIDs.Value)

    '    Return emailToList
    'End Function
    'Private Function GetCCList(ByVal action As String) As String
    '    '  Dim position = CurrentPosition()
    '    Dim title As String = Me.TextPositionTitle.Text
    '    Dim panel As String = DataTools.SchoolPanel(Me.ddlSchool.SelectedValue)
    '    Dim appType As String = hfAppType.Value
    '    Dim owner As String = Me.hfPositionOwner.Value
    '    Dim postingCycle As String = Me.lblPostRound.Value

    '    Dim _mCC As String = WebConfigValue.getValuebyKey("eMailCC")
    '    _mCC = EmailNotification.CheckCCMailOwner(_mCC, owner, User.Identity.Name)
    '    _mCC = EmailNotification.CheckCCMail(_mCC, "Principal", action, appType, postingCycle, title, panel)
    '    Return _mCC
    'End Function
    'Private Function GetUnionNoticeHRFollower() As String
    '    Dim owner As String = Me.hfPositionOwner.Value
    '    Dim followUnion As String = WebConfigValue.getValuebyKey("eMail_Union_Follow")
    '    If followUnion = "Owner" Then Return EmailNotification.CheckCCMailOwner("", owner, User.Identity.Name)
    '    Return followUnion
    'End Function
    Private Sub SendPostingNotification(ByVal action As String)
        Try
            Dim HRContact = DataTools.GetHRContact(jsonFileHRstaff, GetOwner())
            Dim position = CurrentPosition()
            Dim email = New EmailNotification(position)

            Dim principalName As String = Me.ddlPrincipal.SelectedItem.Text
            Dim userId As String = User.Identity.Name

            Dim myEmail As New EmailNotice2()

            If Me.chbNoticeToPrincipal.Checked Then
                myEmail = email.GetEmailNotice(jsonFile, action, "Principal", userId)
                myEmail.EmailBody = GetEmailBody("Principal", principalName, action, myEmail.EmailBody, HRContact)
                email.SMTPMailCall("Principal", myEmail)
            End If

            If Me.chbNoticeToUnion.Checked Then
                myEmail = email.GetEmailNotice(jsonFile, action, "Union", userId)
                email.SMTPMailCall("Union", myEmail)
            End If
        Catch ex As Exception
            CreatSaveMessage("Failed", "Send Email notification")
        End Try

    End Sub

    Private Function GetHRContact() As Contact
        Dim jsonFileHRstaff As String = Server.MapPath("..\Content\HRStaff.json")
        Dim contact = WebConfigValue.HRContact(jsonFileHRstaff, GetOwner())
        Return contact
    End Function
    Private Function GetOwner() As String
        Return DataTools.GetPositionOwner(Me.hfPositionOwner.Value, Me.ddlSchool.SelectedValue, Me.hfAppType.Value)
    End Function
    Private Function GetEmailBody(ByVal toWho As String, ByVal ToName As String, ByVal action As String, ByVal bodyFile As String, ByVal HRContact As Contact) As String


        Dim contact As String = HRContact.Extention
        Dim name As String = HRContact.Name

        ' Dim sDate As DateTime = Now()
        Dim datetime As String = DateFC.YMDHMS(Now())
        '
        ' Dim appType As String = hfAppType.Value
        'Dim myEmailTemple = EmailNotification.EmailSubjectAndTemple(jsonFile, appType, action)
        Dim eMailbodyFile As String = Server.MapPath("..") + "\Template\" + bodyFile
        Dim eMailFile As String = EmailNotification.EmailHTMLBody(eMailbodyFile)

        Try

            Dim startDate As String = dateStart.Value
            Dim endDate As String = dateEnd.Value
            If startDate = "" Then startDate = hfStartDate.Value
            If endDate = "" Then endDate = hfEndDate.Value

            Dim openDate As String = Me.dateApplyStart.Value
            Dim closeDate As String = Me.dateDeadline.Value
            Dim publishDate As String = Me.datePublish.Value

            Dim title As String = TextPositionTitle.Text
            Dim level As String = ddlPositionlevel.SelectedItem.Text
            If title = "" Then title = hfTitle.Value
            If level = "" Then level = hfPositionLevel.Value

            eMailFile = Replace(eMailFile, "[TeacherNameSTR]", ToName)
            eMailFile = Replace(eMailFile, "[PostingNumberSTR]", Me.TextPostingNumber.Text)
            eMailFile = Replace(eMailFile, "[PrincipalNameSTR]", ToName)
            eMailFile = Replace(eMailFile, "[DateTimeSTR]", datetime)
            eMailFile = Replace(eMailFile, "[SchoolNameSTR]", Me.ddlSchool.SelectedItem.Text)
            eMailFile = Replace(eMailFile, "[PositionTitleSTR]", title)
            eMailFile = Replace(eMailFile, "[PositionLevelSTR]", level)
            eMailFile = Replace(eMailFile, "[PositionDescriptionSTR]", Me.TextPositionDescription.Text)
            eMailFile = Replace(eMailFile, "[QualificationSTR]", lblQualification.Value + "  / " + level) ' Me.TextQualification.Text)
            eMailFile = Replace(eMailFile, "[PositionStartDateSTR]", startDate)
            eMailFile = Replace(eMailFile, "[PositionEndDateSTR]", endDate)
            eMailFile = Replace(eMailFile, "[PostingOpenDateSTR]", openDate)
            eMailFile = Replace(eMailFile, "[PostingCloseDateSTR]", closeDate)
            eMailFile = Replace(eMailFile, "[PostingPublishDateSTR]", publishDate)

            eMailFile = Replace(eMailFile, "[BTCSTR]", GetFte()) ' Me.TextPositionFTE.Text)
            eMailFile = Replace(eMailFile, "[PositionTypeSTR]", Me.hfAppType.Value)
            eMailFile = Replace(eMailFile, "[PostingCycleSTR]", "") 'Me.lblPostRound.Value)
            eMailFile = Replace(eMailFile, "[PositionOwnerSTR]", contact)


            eMailFile = Replace(eMailFile, "[timeTable]", ViewState("timeTable"))
            eMailFile = Replace(eMailFile, "[multiSchool]", ViewState("multiSchool"))

            Dim Round4ContactStatement = ""
            If lblPostRound.Value = "4" Then Round4ContactStatement = WebConfigValue.getValuebyKey("Round4ContactStatement")


            eMailFile = Replace(eMailFile, "[Round4ContactStatement]", Round4ContactStatement)

            Dim cancelComments As String = IIf(toWho = "Union", "", Me.TextPostedComment.Text)
            eMailFile = Replace(eMailFile, "[CancelCommentsSTR]", cancelComments)


            eMailFile = Replace(eMailFile, "[TeacherBeReplacedSTR]", lblTeacherName.Value) ' Me.ddlTeacherReplaced.SelectedItem.Text)
            eMailFile = Replace(eMailFile, "[PIDSTR]", hfAutoCompletSelectedID.Value) ' Me.ddlTeacherReplaced.SelectedItem.Value)

            Dim CanadidateList As String = ""
            If action = "Repost" And Me.CheckBoxgetApplicant.Checked Then
                CanadidateList = GetTeacherList("InterviewCandidate")
            End If

            eMailFile = Replace(eMailFile, "[InterviewCandidateListSTR]", CanadidateList)

        Catch ex As Exception
            eMailFile = ""
        End Try
        Return eMailFile


    End Function

    Private Sub DDLHRStaff_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlHRStaff.SelectedIndexChanged
        Me.hfPositionOwner.Value = ddlHRStaff.SelectedValue
    End Sub

    Private Function CurrentPosition() As PositionPublish

        Dim position = New PositionPublish()
        With position
            .UserID = User.Identity.Name
            .SchoolYear = hfSchoolyear.Value
            .SchoolCode = Me.ddlSchool.SelectedValue
            .PositionID = hfIDs.Value
            .PositionType = hfAppType.Value
            .PostingNumber = Me.TextPostingNumber.Text
            .PositionTitle = Me.TextPositionTitle.Text
            .PositionLevel = ddlPositionlevel.SelectedValue
            .Qualification = Me.lblQualification.Value
            .QualificationCode = Me.hfQualificationsCode.Value
            .Description = Me.TextPositionDescription.Text
            .FTE = GetFte()
            .FTEPanel = Me.ddlFTEPanel.SelectedValue
            .StartDate = DateFC.YMD2(Me.dateStart.Value)
            .EndDate = DateFC.YMD2(Me.dateEnd.Value)
            .DatePublish = DateFC.YMD2(Me.datePublish.Value)
            .DateApplyOpen = DateFC.YMD2(Me.dateApplyStart.Value)
            .DateApplyClose = DateFC.YMD2(Me.dateDeadline.Value)
            .Comments = Me.TextPostedComment.Text
            .ReplaceTeacherID = hfAutoCompletSelectedID.Value
            .ReplaceTeacher = lblTeacherName.Value
            .ReplaceReason = ddlReason.SelectedValue
            .OtherReason = ddlReason.SelectedItem.Text
            .Owner = Me.ddlHRStaff.SelectedValue
            .PostingCycle = Me.lblPostRound.Value
            .PrincipalID = ddlPrincipal.SelectedValue
            .PrincipalName = ddlPrincipal.SelectedItem.Text
        End With

        Return position
    End Function
    Private Function GetTeacherList(ByVal action As String) As String
        Try
            Dim schoolyear As String = hfSchoolyear.Value
            Dim positionID As String = Page.Request.QueryString("PositionID")
            Dim appType As String = hfAppType.Value

            Return SelectCandidateExe.GetCandidateListTable(action, schoolyear, positionID, appType)

        Catch ex As Exception
            Return ""
        End Try
    End Function

End Class
