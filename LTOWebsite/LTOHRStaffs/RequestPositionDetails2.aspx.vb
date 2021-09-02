'Imports System.Data

'Imports System.IO

Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services
Imports AppOperate
Imports ClassLibrary



Partial Class RequestPositionDetails2
    Inherits System.Web.UI.Page
    Dim _jsonFile As String = Server.MapPath("..\Content\eMailTemplate.json")
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



            If Page.Request.QueryString("Action") = "Substituted" Or Page.Request.QueryString("Action") = "RePost" Then
                btnRepublish.Visible = False
                btnReNotice.Visible = True
            Else
                btnRepublish.Visible = True
                btnReNotice.Visible = False
            End If
            If Page.Request.QueryString("Action") = "GoTo" Then
                btnRepublish.Visible = False
                btnReNotice.Visible = False
            End If

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
                Me.ddlTeacherReplaced.Visible = False
                Me.ddlReason.Visible = False
            End If
            ddlType.Enabled = False

            If WorkingProfile.LoginRole = "Admin" Then chbCancel.Visible = True
        End If


    End Sub
    Private Sub AssiblingPage(ByVal schoolyear As String, ByVal schoolcode As String, ByVal positionId As String)
        hfAppType.Value = WorkingProfile.ApplicationType

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
        AssemblingList.SetLists("", Me.ddlTeacherReplaced, "SchoolTeacherList", parameter)
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
    Private Function GetDataSource(ByVal schoolyear As String, ByVal positionId As String) As PositionPublish

        'Dim parameter As New ParametersForPosition()
        'With parameter
        '    .SchoolYear = schoolyear
        '    .PositionID = positionID
        'End With

        ' ***  this is no interface
        'Dim position1 As New List(Of PositionPosting)
        'position1 = PositionPublished.PositionByID(parameter)

        ' ********** this using interface    this part has been move to AppOperate Business layer    *******************************************************
        '  Dim repository As IPositionRepository(Of PositionPosting, Integer) = Factory.Get(Of PositionPublished)
        '  Dim position1 As IList(Of PositionPosting) = repository.GetPosition(parameter)      ' Dim position1 As IList(Of PositionPosting) = repository.GetPosition(positionID)

        ' ****** using Summary interface
        '  Dim position As New List(Of PositionPosting)
        Dim userid As String = HttpContext.Current.User.Identity.Name
        Me.hfSchoolyear.Value = schoolyear

        Dim parameter = CommonParameter.GetParameters(schoolyear, positionId)
        '  Dim SP As String = CommonOperationExcute(Of PositionPublish).ObjSP("PositionPublish", "Retrieve")

        Dim position = PublishPositionExe.Position(parameter)(0)

        '  Dim SP As String = CommonExcute.SPNameAndParameters(DataAccesssFile, cPage, "Position") '  CommonExcute.SPNameAndParameters(SPFile, cPage, "Position")
        If User.Identity.Name = "mif" Then
            'Dim SP1 As String = CommonExcute.SPNameAndParameters(DataAccesssFile, cPage, "Update")
            'Dim SP2 As String = CommonExcute.SPNameAndParameters(DataAccesssFile, cPage, "Cancel")
            'Dim SP3 As String = CommonExcute.SPNameAndParameters(DataAccesssFile, cPage, "RePosting")
            'Dim SP4 As String = CommonExcute.SPNameAndParameters(DataAccesssFile, cPage, "Delete")

            Me.lblPostingNumber.ToolTip = PublishPositionExe.SpName("Position")
            Me.btnSave.ToolTip = PublishPositionExe.SpName("Update")
            Me.btnUnpublish.ToolTip = PublishPositionExe.SpName("Cancel")
            Me.btnRepublish.ToolTip = PublishPositionExe.SpName("RePosting")
            Me.btndelete.ToolTip = PublishPositionExe.SpName("Delete")
            Me.MultipleSchoolimg.Attributes.Add("title", MultipleSchoolsExe.SPName("MultipleSchools"))

        End If

        ' Dim position = CommonListExecute(Of PositionPublish).GeneralPositions(SP, parameter)(0) '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)
        ' Dim position = CommonExcute(Of PositionPublish).GeneralList(SP, parameter)(0) '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)

        ' Dim position = CommonListExecute.PublishPosition(parameter)(0) '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)
        Return position

    End Function
    Protected Sub BindSelectedPositionData(ByVal schoolyear As String, ByVal positionId As String)
        Try
            Me.btnUnpublish.Enabled = True
            Me.btndelete.Enabled = True


            Dim position = GetDataSource(schoolyear, positionId) '  SinglePosition.PositionByID(parameter)



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
                AssembleListItem.SetValue(rblFTE, "00")
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
            Dim posting As Integer = BasePage.getMyValue(position.PostingCycle)
            Me.hfApplicant.Value = BasePage.getMyValue(position.Applicant)
            AssemblingList.SetValue(Me.ddlPostingCycle, CType(posting + 1, String))

            Me.lblPostRound.Value = posting


            AssemblingList.SetValue(ddlTeacherReplaced, BasePage.getMyValue(position.ReplaceTeacherID))
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
                Me.btnUnpublish.Enabled = False
                Me.btnRepublish.Enabled = False
                Me.btndelete.Enabled = False
                btnRepublish.ToolTip = position.HiredInformation
                btnSave.ToolTip = position.HiredInformation
            Else
                If Left(Me.lblPostedState.Text, 6) = "Cancel" Then
                    Me.btnUnpublish.Enabled = False
                    Me.btnSave.Enabled = False
                    Me.btnRepublish.Enabled = False

                    btnRepublish.ToolTip = position.HiredInformation
                End If
                'If Me.dateStart.Value = "" Then Me.dateStart.Value = Now.Date()
                'If Me.datePublish.Value = "" Then Me.datePublish.Value = Now.Date()
            End If
            If position.PositionState = "Close" Then
                Me.btnUnpublish.Enabled = False
                Me.btnRepublish.Enabled = False
                Me.btndelete.Enabled = False
                Me.btnSave.Enabled = False
                If WorkingProfile.UserRole = "Admin" Then
                    Me.btnSave.Enabled = True
                    If User.Identity.Name = "mif" Then
                        Me.btnUnpublish.Enabled = True
                        Me.btnRepublish.Enabled = True
                        Me.btndelete.Enabled = True
                    End If

                End If
            End If

            If position.CanRecover = "Yes" Then
                btnUnpublish.Visible = False
                btnRecover.Visible = True
                btndelete.Visible = False
            End If

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
        Me.btndelete.Enabled = False
        Me.btnEmail.Enabled = False
        Me.btnReNotice.Enabled = False
        Me.btnRepublish.Enabled = False
        Me.btnUnpublish.Enabled = False
        Dim filterAction As String = Page.Request.QueryString("FilerAction")
        If filterAction = "PendingConfirm" Then
            SetControlReadonly(True)
        Else
            SetControlReadonly(False)
        End If

        If Me.lblPostedState.Text = "New Posting" Then
            Me.btndelete.Enabled = True
            Me.btnEmail.Enabled = True
            Me.btnReNotice.Enabled = True
            Me.btnRepublish.Enabled = True
            Me.btnUnpublish.Enabled = True
        End If

    End Sub
    Private Function ConvertFte(ByVal value As Object) As String
        Dim fte As Integer = value * 100
        'Dim fte As String = ().ToString()
        Return fte.ToString()
    End Function

    Private Sub SetStartandEndDate()

        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        Dim positionType = WorkingProfile.ApplicationType
        DefaultDate.SetDate(schoolyear, positionType, Me.dateStart, Me.dateEnd, Me.datePublish, Me.dateApplyStart, Me.dateDeadline, hfSchoolyearStartDate, hfSchoolyearEndDate)

        'Me.hfSchoolyearStartDate.Value = Me.dateStart.Value
        'Me.hfSchoolyearEndDate.Value = Me.dateEnd.Value


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
        Me.btnUnpublish.Enabled = False
        Me.btndelete.Enabled = False
        '  Me.btnEmail.Enabled = False
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
            Dim position1 As New PositionPublish()
            With position1
                .Operate = action
                .UserID = User.Identity.Name
                .SchoolYear = schoolyear
                .SchoolCode = Me.ddlSchool.SelectedValue
                .PositionID = ds
                .PositionType = hfAppType.Value
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
                .ReplaceTeacherID = ddlTeacherReplaced.SelectedValue
                .ReplaceTeacher = ddlTeacherReplaced.SelectedItem.Text
                .ReplaceReason = ddlReason.SelectedValue
                .OtherReason = ddlReason.SelectedItem.Text
                .Owner = Me.ddlHRStaff.SelectedValue
                .PrincipalID = ddlPrincipal.SelectedValue

            End With

            '   Dim SP As String = CommonExcute.SPNameAndParameters(DataAccesssFile, cPage, action)

            Dim result As String = PublishPositionExe.Update(position1) ' CommonExcute(Of PositionPublish).GeneralValue(SP, position1)
            ' Dim _result As String = CommonOperationExcute(Of PositionPublish).CommonOperation(position1, SP, action)
            ' _result = CommonOperationExcute.PublishOperation(position1, action) ' .PostingPublishExe.SavePosting(position1, IDs) '   PositionPublished.SavePosition(position1)
            If Not (result = "Successfully" Or result = "Failed") Then
                Me.hfIDs.Value = result
                ds = result
                result = "Successfully"
                '  SaveQualification(IDs, "Initial")

                '  BindSelectedPositionData(schoolyear, IDs)

            End If
            CreatSaveMessage1(result, "Save Position")
            BindSelectedPositionData(schoolyear, Me.hfIDs.Value)

        Catch ex As Exception
            CreatSaveMessage1("Falied", "Save Position")
        End Try


        ' *** This code for Application Insight ************************************************************ 

        '  Dim mysel As New SelectedObject
        ' mysel.CPNum = schoolcode
        ' mysel.PositionID = IDs


        'Dim PositionApply As New Dictionary(Of String, Object)
        'PositionApply.Add("Schoolcode", mysel.CPNum)
        'PositionApply.Add("PositionID", mysel.PositionID)
        'PositionApply.Add("Owner", userid)
        'Dim Server_name As String = System.Net.Dns.GetHostName()


        ' ServerAnalytics.CurrentRequest.LogEvent(Server_name + "/" + "Add New Position/", PositionApply)
        '******************************************************************************************************


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

        Dim result As String = PublishPositionExe.Recover(recoverPosition)
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
            Dim cancelPosting = New PositionPublish() 'ObjClassFactory.GetParametersObj() '  ParametersForOperation()

            With cancelPosting
                .Operate = action
                .UserID = User.Identity.Name
                .SchoolYear = schoolyear
                .PositionID = Me.hfIDs.Value
                .Comments = Me.TextPostedComment.Text
                .SchoolCode = Me.ddlSchool.SelectedValue
                .PositionType = Me.hfAppType.Value

            End With
            ' Dim SP As String = CommonExcute.SPNameAndParameters(DataAccesssFile, cPage, action)
            Dim result As String = PublishPositionExe.Cancel(cancelPosting) '   CommonExcute(Of PositionPublish).GeneralValue(SP, cancelPosting)
            '  Dim _result As String = CommonOperationExcute(Of PositionPublish).CommonOperation(cancelPosting, SP, action)  '  PostingPublishExe.CancelPosting(cancelPosting, Me.hfIDs.Value)
            '  Dim _result As String = CommonOperationExcute.PublishOperation(cancelPosting, action)  '  PostingPublishExe.CancelPosting(cancelPosting, Me.hfIDs.Value)
            CheckApplicantsSendNotification("CancelA")
            SendRepostingNotificationToPrincipal("CancelP")

            If chbCancel.Checked Then
                cancelPosting.Operate = "CancelAndRecoverPre"
                '  _result = CommonOperationExcute(Of PositionPublish).CommonOperation(cancelPosting, SP, action)   '  PostingPublishExe.CancelPosting(cancelPosting, Me.hfIDs.Value)
                result = PublishPositionExe.Cancel(cancelPosting)  'CommonExcute(Of PositionPublish).GeneralValue(SP, cancelPosting)
            End If

            CreatSaveMessage(result, "Cancel Posting")

        Catch ex As Exception
            CreatSaveMessage("Faield", "Cancel Posting")
        End Try
        ' BindSelectedPositionData(schoolyear, Me.hfIDs.Value)
    End Sub
    'Protected Sub BtnUnpublish_Click(sender As Object, e As EventArgs) Handles btnUnpublish.Click
    'End Sub
    Protected Sub Btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Try
            Me.HiddenFieldAction.Value = "Yes"
            Dim action As String = "Delete" 'Me.HiddenFieldApply.Value
            Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
            Dim deletePosting As New PositionPublish ' ObjClassFactory.GetParametersObj() ParametersForOperation()
            With deletePosting
                .Operate = action
                .UserID = User.Identity.Name
                .SchoolYear = schoolyear
                .PositionID = Me.hfIDs.Value
                .Comments = Me.TextPostedComment.Text
                .SchoolCode = Me.ddlSchool.SelectedValue
                .PositionType = Me.hfAppType.Value
            End With
            ' Dim SP As String = CommonExcute.SPNameAndParameters(DataAccesssFile, cPage, action)
            Dim result As String = PublishPositionExe.Delete(deletePosting) '  CommonExcute(Of PositionPublish).GeneralValue(SP, deletePosting)
            '  Dim _result As String = CommonOperationExcute(Of PositionPublish).CommonOperation(deletePosting, SP, action)  '  PostingPublishExe.CancelPosting(cancelPosting, Me.hfIDs.Value)
            '  Dim _result As String = CommonOperationExcute.PublishOperation(deletePosting, action)  ' ' PostingPublishExe.CancelPosting(deletePosting, Me.hfIDs.Value)
            Me.btnUnpublish.Enabled = False
            Me.btndelete.Enabled = False
            CreatSaveMessage(result, "Delete Position")
        Catch ex As Exception
            CreatSaveMessage("Failed", "Delete Position")
        End Try
    End Sub
    Protected Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        Try
            Dim action As String = "RePosting"
            Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
            Dim userid As String = HttpContext.Current.User.Identity.Name
            Dim ds As String = Me.hfIDs.Value
            Dim postingNum As String = Me.TextPostingNumber.Text
            Dim takeApplicant As String = IIf(Me.CheckBoxgetApplicant.Checked, "Yes", "No")
            Dim postingCycle As String = Me.ddlPostingCycle.SelectedValue

            Me.lblPostRound.Value = postingCycle
            Dim rePosting As New PositionPublish() ' ParametersForOperation()
            With rePosting
                .Operate = action
                .UserID = User.Identity.Name
                .SchoolYear = schoolyear
                .PositionID = Me.hfIDs.Value
                .PostingCycle = postingCycle
                .TakeApplicant = takeApplicant
                .SchoolCode = Me.ddlSchool.SelectedValue
                .PositionType = Me.hfAppType.Value
                .PostingNumber = postingNum
            End With

            ' Dim SP As String = CommonExcute.SPNameAndParameters("", cPage, action)
            '  Dim _result As String = CommonOperationExcute(Of PositionPublish).CommonOperation(rePosting, SP, action)  '  PostingPublishExe.CancelPosting(cancelPosting, Me.hfIDs.Value)
            Dim result As String = PublishPositionExe.RePosting(rePosting) ' CommonExcute(Of PositionPublish).GeneralValue(SP, rePosting)
            '    Dim _result As String = CommonOperationExcute.PublishOperation(rePosting, action)  ' PostingPublishExe.RePosting(rePosting, Me.hfIDs.Value)

            If Not (result = "Successfully" Or result = "Failed") Then
                ds = result
                result = "Successfully"
                Dim postingNoticeBegin As String = WebConfigValue.getValuebyKey("PostingNoticeBegin")
                If postingCycle > postingNoticeBegin Then
                    Me.hfIDs.Value = ds
                    SendRepostingNotificationToPrincipal("Repost")
                End If
                '  no need rebind, page close after reposting   BindSelectedPositionData(schoolyear, ds)
                Me.btnRepublish.Enabled = False
            End If

            CreatSaveMessage(result, "Re-posting")
        Catch ex As Exception
            CreatSaveMessage("Failed", "Re-posting")
        End Try



    End Sub

    Protected Sub BtnReNotice_Click(sender As Object, e As EventArgs) Handles btnReNotice.Click
        Try
            SendRepostingNotificationToPrincipal("Posting")
            Dim result As String = "Successfully"
            CreatSaveMessage(result, "Sent repost hired Position email notice to Principal")

        Catch ex As Exception
            ShowMessage.Exception(ex, Me.Page, "Bind data action")
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
        Me.ddlTeacherReplaced.ClearSelection()
        Me.ddlPositionlevel.ClearSelection()
        Dim parameter As New List2Item()

        With parameter
            .Para0 = WorkingProfile.SchoolYear
            .Para1 = schoolcode
        End With
        AssemblingList.SetLists("", Me.ddlTeacherReplaced, "SchoolTeacherList", parameter)
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
            Dim sAction As String = action
            If action = "Repost" And Me.lblPostRound.Value > 1 Then
                sAction = action & Me.lblPostRound.Value
            End If

            Dim myEmailTemple = EmailNotification.EmailSubjectAndTemple(_jsonFile, WorkingProfile.ApplicationType, sAction)
            Dim mSubject As String = Replace(myEmailTemple.Subject, "PositionTitle", Me.TextPositionTitle.Text) ' EmailNotification.Subject(JsonFile, WorkingProfile.ApplicationType, "Posting")
            Dim mTemplateFile = myEmailTemple.Template '  EmailNotification.Template(JsonFile, WorkingProfile.ApplicationType, "Posting")


            '  Dim mSubject As String = EmailNotification.Subject(JsonFile, WorkingProfile.ApplicationType, action)
            '  Dim mTemplateFile = EmailNotification.Template(JsonFile, WorkingProfile.ApplicationType, action)

            Dim parameter As New ParametersForCandidate()
            With parameter
                .Operate = "Cancel"
                .SchoolYear = Page.Request.QueryString("SchoolYear")
                .PositionID = Me.hfIDs.Value
            End With

            '  Dim applicantNoticelist As New List(Of ApplicantList)

            Dim applicantNoticelist = PublishPositionExe.NoticeApplicants(parameter) ' CommonListExecute.ApplicantsNoticeList(parameter)  ' Applicant.ApplicantsNoticebyID(parameter)
            Dim mForm As String = WebConfigValue.getValuebyKey("eMailSender")
            For Each item In applicantNoticelist
                Dim teacherName As String = item.TeacherName
                ' Dim Phone As String = item.PhoneNumber
                Dim mTo As String = item.MailTo
                Dim mCc As String = item.MailCC
                ' Dim HiredDate As String = item.MailCC
                '  Dim ApplyDate As String = item.ApplyDate
                'Dim _schoolname As String = ddlSchool.SelectedItem.Text
                'Dim _Positiontitle As String = Me.TextPositionTitle.Text
                SmtpMailCall("Applicant", action, mTo, mCc, mForm, teacherName, mSubject, mTemplateFile)

            Next

        Catch ex As Exception

        End Try


    End Sub

    Protected Sub BtnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        Try
            '   SMTPMailCall("Principal", "RePost", _PrincipalID, _mTO, _mCC, _mForm, _PositionTitle, _PrincipalName, _schoolname)
            SendRepostingNotificationToPrincipal("Posting")


            ' PositionList.PendingConfirmListSave(_User, _schoolyear, _PositionID)
            Dim result As String = "Successfully" ' PositionDetails.NoticeToPrincipal(userid, schoolyear, _PositionID, DateNotice, principalID)

            CreatSaveMessage(result, "Sent reminder email notice to Principal")

        Catch ex As Exception
            ShowMessage.Exception(ex, Me.Page, "Bind data action")
        End Try
    End Sub

    Private Function GetEmailToList() As String
        Dim emailToList As String = ""

        emailToList = EmailNotification.UserProfileByID("TCDSBeMailAddress", hfPrincipalID.Value) '      Me.hfPrincipalID.Value + "@TCDSB.ORG"
        emailToList += EmailNotification.GetMultipleSchoolEmail(hfSchoolyear.Value, ddlSchool.SelectedValue, Me.hfIDs.Value)
        'PositionDetails.NoticeToActingPrincipal(Me.hfSchoolyear.Value, Me.hfSchoolCode.Value, Me.hfPositionID.Value)

        Return emailToList
    End Function

    Private Sub SendRepostingNotificationToPrincipal(ByVal action As String)

        Try
            Dim principalName As String = ddlPrincipal.SelectedItem.Text
            '  Dim _mTO As String = EmailNotification.UserProfileByID("TCDSBeMailAddress", hfPrincipalID.Value)
            Dim mTo As String = GetEmailToList()
            Dim mForm As String = EmailNotification.CheckFromMail(Me.ddlType.SelectedValue)

            Dim mCc As String = WebConfigValue.getValuebyKey("eMailCC")
            mCc = EmailNotification.CheckCCMailOwner(mCc, Me.hfPositionOwner.Value, User.Identity.Name)
            mCc = EmailNotification.CheckCCMail(mCc, "Principal", "Posting", hfAppType.Value, Me.ddlPostingCycle.SelectedValue, Me.TextPositionTitle.Text, ddlSchool.SelectedValue)


            ' **** LTO posting will send two email notification. 
            ' **** first notificaiton to school principal and HR staff
            ' **** Second email to union people. cc to Mary  email body with out teacher's information.
            ' **** POP posting only send one email notification to Principal  cc to HR staff anf union people
            Dim sAction As String = action
            If action = "Repost" And Me.lblPostRound.Value > 1 Then
                sAction = action & Me.lblPostRound.Value
            End If

            Dim myEmailTemple = EmailNotification.EmailSubjectAndTemple(_jsonFile, WorkingProfile.ApplicationType, sAction)
            Dim mSubject As String = Replace(myEmailTemple.Subject, "PositionTitle", Me.TextPositionTitle.Text) ' EmailNotification.Subject(JsonFile, WorkingProfile.ApplicationType, "Posting")
            Dim mTemplateFile = myEmailTemple.Template '  EmailNotification.Template(JsonFile, WorkingProfile.ApplicationType, "Posting")


            If Me.chbNoticeToPrincipal.Checked Then
                SmtpMailCall("Staff", action, mTo, mCc, mForm, principalName, mSubject, mTemplateFile)

            End If


            If Me.hfAppType.Value = "LTO" And Me.chbNoticeToUnion.Checked Then
                Dim unioneMail As String = EmailNotification.UnionEmail(ddlSchool.SelectedValue, Me.hfAppType.Value)
                If Not unioneMail = "" Then
                    mCc = WebConfigValue.getValuebyKey("eMail_UnionA")
                    mTo = unioneMail
                    SmtpMailCall("Union", action, mTo, mCc, mForm, principalName, mSubject, mTemplateFile)
                End If
            End If


        Catch ex As Exception

        End Try


    End Sub


    Private Sub SmtpMailCall(ByVal who As String, ByVal eMailAction As String, ByVal mTo As String, ByVal mCc As String, ByVal mFrom As String, ByVal teacherName As String, ByVal mSubject As String, ByVal mTemplateFile As String)
        Dim aditionInfo As String = ""
        'Dim _mSubject As String = "Cancel Posted Position " + Me.TextPositionTitle.Text + " Notification"
        'If eMailAction = "Cancel" Then _mSubject = "Cancel Posted Position " + Me.TextPositionTitle.Text + " Notification"
        'If eMailAction = "CancelP" Then _mSubject = "Cancel Posted Position " + Me.TextPositionTitle.Text + " Notification"
        'If eMailAction = "Remind" Then _mSubject = "Reminder to complete LTO/POP Position hiring process"
        'If eMailAction = "Repost" Then _mSubject = "Position Reposting Notification"
        'If eMailAction = "Posting" Then _mSubject = "New LTO/POP Position Posting Notification"


        Try
            Dim eMailFile As String = GetEmailfileHtml(who, eMailAction, teacherName, mTemplateFile)

            Dim mBcc As String = WebConfigValue.getValuebyKey("eMailBCC")
            Dim publicFolder As String = WebConfigValue.getValuebyKey("LTOadminFolder")
            If Not who = "Applicant" Then
                mBcc = mBcc + publicFolder
            End If

            Dim myEmail As New EmailNotice2()
            With myEmail
                .UserID = User.Identity.Name
                .SchoolYear = hfSchoolyear.Value
                .SchoolCode = ddlSchool.SelectedValue
                .PositionType = hfAppType.Value
                .PositionID = hfIDs.Value
                .PositionTitle = Me.TextPositionTitle.Text
                .PostingNum = Me.TextPostingNumber.Text
                .NoticePrincipal = teacherName
                .NoticeFor = who
                .EmailType = eMailAction
                .EmailTo = mTo
                .EmailCC = mCc
                .EmailBcc = mBcc
                .EmailFrom = mFrom
                .EmailSubject = mSubject
                .EmailBody = eMailFile
                .EmailFormat = "HTML"
                .Attachment1 = ""
                .Attachment2 = ""
                .Attachment3 = ""
            End With


            Dim logId As String = EmailNotification.SaveEmailNotice(myEmail)
            Dim result = EmailNotification.SendEmail(myEmail)

        Catch ex As Exception

            Throw New Exception("Mail send failed")
        End Try
    End Sub
    Private Function GetEmailfileHtml(ByVal who As String, ByVal eMailAction As String, ByVal teacherName As String, ByVal eMailTemplate As String) As String

        '  Dim myHTML As String = "" 'Server.MapPath(".") + "\TPA_Notification.htm"
        Dim jsonFileHRstaff As String = Server.MapPath("..\Content\HRStaff.json")
        Dim contact As String = WebConfigValue.HRContact(jsonFileHRstaff, Me.hfPositionOwner.Value).Extention


        Dim sDate As DateTime = Now()
        Dim datetime As String = sDate.ToString


        Dim myHtml As String = Server.MapPath("..") + "\Template\" + eMailTemplate
        Dim eMailFile As String = EmailNotification.EmailHTMLBody(myHtml)

        Try

            Dim title As String = TextPositionTitle.Text
            Dim startDate As String = dateStart.Value
            Dim endDate As String = dateEnd.Value
            Dim level As String = ddlPositionlevel.SelectedItem.Text
            If title = "" Then title = hfTitle.Value
            If startDate = "" Then startDate = hfStartDate.Value
            If endDate = "" Then endDate = hfEndDate.Value
            If level = "" Then level = hfPositionLevel.Value
            eMailFile = Replace(eMailFile, "[TeacherNameSTR]", teacherName)
            eMailFile = Replace(eMailFile, "[PostingNumberSTR]", Me.TextPostingNumber.Text)
            eMailFile = Replace(eMailFile, "[PrincipalNameSTR]", teacherName)
            eMailFile = Replace(eMailFile, "[DateTimeSTR]", datetime)
            eMailFile = Replace(eMailFile, "[SchoolNameSTR]", Me.ddlSchool.SelectedItem.Text)
            eMailFile = Replace(eMailFile, "[PositionTitleSTR]", title)
            eMailFile = Replace(eMailFile, "[PositionDescriptionSTR]", Me.TextPositionDescription.Text)
            eMailFile = Replace(eMailFile, "[QualificationSTR]", lblQualification.Value + " / " + level) ' Me.TextQualification.Text)
            eMailFile = Replace(eMailFile, "[PositionStartDateSTR]", startDate)
            eMailFile = Replace(eMailFile, "[PositionEndDateSTR]", endDate)
            eMailFile = Replace(eMailFile, "[BTCSTR]", GetFte()) ' Me.TextPositionFTE.Text)
            eMailFile = Replace(eMailFile, "[PositionTypeSTR]", Me.hfAppType.Value)
            eMailFile = Replace(eMailFile, "[PostingCycleSTR]", Me.lblPostRound.Value)
            eMailFile = Replace(eMailFile, "[PositionOwnerSTR]", contact)


            eMailFile = Replace(eMailFile, "[timeTable]", ViewState("timeTable"))
            eMailFile = Replace(eMailFile, "[multiSchool]", ViewState("multiSchool"))

            Dim Round4ContactStatement = ""
            If lblPostRound.Value = "4" Then Round4ContactStatement = WebConfigValue.getValuebyKey("Round4ContactStatement")


            eMailFile = Replace(eMailFile, "[Round4ContactStatement]", Round4ContactStatement)

            If who = "Union" Then
                eMailFile = Replace(eMailFile, "[TeacherBeReplacedSTR]", "")
                eMailFile = Replace(eMailFile, "[PIDSTR]", "")
                eMailFile = Replace(eMailFile, "[CancelCommentsSTR]", "")

            Else
                eMailFile = Replace(eMailFile, "[TeacherBeReplacedSTR]", Me.ddlTeacherReplaced.SelectedItem.Text)
                eMailFile = Replace(eMailFile, "[PIDSTR]", Me.ddlTeacherReplaced.SelectedItem.Value)
                eMailFile = Replace(eMailFile, "[CancelCommentsSTR]", Me.TextPostedComment.Text)

            End If


        Catch ex As Exception
            eMailFile = ""
        End Try
        Return eMailFile


    End Function

    Private Sub DDLHRStaff_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlHRStaff.SelectedIndexChanged
        Me.hfPositionOwner.Value = ddlHRStaff.SelectedValue
    End Sub



End Class
