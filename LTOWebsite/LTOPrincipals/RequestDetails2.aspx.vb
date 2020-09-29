
'Imports Microsoft.ApplicationInsights.Telemetry.Services
'Imports System.Threading.Tasks
'Imports System.Net.Http

Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services

'Imports TCDSB.Student
Imports ClassLibrary
Imports AppOperate

Partial Class RequestDetails2
    Inherits System.Web.UI.Page
    Dim myRequestPosting As New PositionRequesting
    Dim JsonFile As String = Server.MapPath("..\Content\eMailTemplate.json")
    Dim cPage As String = "Request"
    Dim SPFile As String = SPSource.SPFile()
    Protected Sub Page_Error(sender As Object, e As EventArgs) Handles Me.Error
        Dim ex As Exception = Server.GetLastError()
        Dim ss As String = sender.ToString()

    End Sub
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
            Me.btnRequest.Enabled = False

            AssiblingPage()
            BindPageData()
            CheckActions()
            setPageVaildationControl()

        End If
    End Sub
    Private Sub AssiblingPage()


        RequiredFieldValidator2.Enabled = False
        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        Dim schoolcode As String = Page.Request.QueryString("SchoolCode")
        Dim positionID As String = Page.Request.QueryString("PositionID")
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
        AssemblingList.SetListSchool(ddlschoolcode, Me.ddlSchool, "SchoolList", parameter, schoolcode)
        With parameter
            .Para0 = schoolyear
            .Para1 = schoolcode
            .Para3 = positionID
        End With
        ' AssembleListItem.SetLists(ddlTeacherReplaced, "SchoolTeacherList", parameter)
        AssemblingList.SetLists("", ddlType, "ApplicationType", parameter, WorkingProfile.ApplicationType)
        AssemblingList.SetLists("", ddlHRStaff, "HRStaffPosting", parameter)
        AssemblingList.SetLists("", ddlPositionlevel, "PositionLevel", parameter)
        AssemblingList.SetLists("", ddlReason, "LeaveReasonP", parameter)
        AssemblingList.SetLists("", cblQualification, "Qualification_RequestP", parameter)
        AssemblingList.SetLists("", rblFTE, "FTEList", parameter)


        '  parameter.Operate = "SchoolTeacherListR"
        '  AssembleListItem.SetObjLists(Me.combobox, parameter)

    End Sub
    Private Sub setStartandEndDate()

        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        Dim positionType = WorkingProfile.ApplicationType
        DefaultDate.SetDate(schoolyear, positionType, Me.dateStart, Me.dateEnd)

        Me.hfSchoolyearStartDate.Value = Me.dateStart.Value
        Me.hfSchoolyearEndDate.Value = Me.dateEnd.Value


    End Sub
    Private Sub setPageVaildationControl()
        If WorkingProfile.ApplicationType = "POP" Then
            '  for POP position no need to check the replace teacher
            RequiredFieldValidator5.Enabled = False
            RequiredFieldValidator6.Enabled = False
        End If
    End Sub
    Private Sub BindPageData()
        Try
            Dim position = GetRequestPostingDataSource()

            Me.hfIDs.Value = BasePage.getMyValue(position.PositionID)
            Me.TextRequestID.Text = BasePage.getMyValue(position.PositionID)
            Me.TextStatus.Text = BasePage.getMyValue(position.RequestStatus)
            Me.TextPositionTitle.Value = BasePage.getMyValue(position.PositionTitle)
            Me.TextDescription.Text = BasePage.getMyValue(position.Description)
            Me.dateStart.Value = BasePage.getMyValue(position.StartDate)
            Me.dateEnd.Value = BasePage.getMyValue(position.EndDate)
            Me.dateRequest.Value = BasePage.getMyValue(position.RequestDate)
            Me.datePosted.Value = BasePage.getMyValue(position.DatePublish)
            Me.lblRequestSource.Text = BasePage.getMyValue(position.RequestSource)
            Me.lblPrinciaplName.Text = BasePage.getMyValue(position.PrincipalName)
            Me.lblSuperintendent.Text = BasePage.getMyValue(position.Superintendent)
            Me.lblQualification.Value = BasePage.getMyValue(position.Qualification)
            Me.hfQualificationsCode.Value = BasePage.getMyValue(position.QualificationCode)
            Me.hfAutoCompletSelectedID.Value = BasePage.getMyValue(position.ReplaceTeacherID)
            AssemblingList.SetValue(ddlHRStaff, BasePage.getMyValue(position.Owner))
            AssemblingList.SetValue(ddlType, BasePage.getMyValue(position.PositionType))
            AssemblingList.SetValue(ddlFTEPanel, BasePage.getMyValue(position.FTEPanel))
            AssemblingList.SetValue(ddlReason, BasePage.getMyValue(position.ReplaceReason))
            If Not BasePage.getMyValue(position.FTE) = 0 Then
                AssemblingList.SetValue(rblFTE, ConvertFTE(BasePage.getMyValue(position.FTE)))
                If rblFTE.SelectedValue = "" Then
                    Me.TextFTE.Text = ConvertFTE(BasePage.getMyValue(position.FTE))
                    AssemblingList.SetValue(rblFTE, "00")
                End If
            End If

            AssemblingList.SetValue(ddlPositionlevel, BasePage.getMyValue(position.PositionLevel))
            '  AssembleListItem.SetValue(ddlTeacherReplaced, BasePage.getMyValue(position.ReplaceTeacherID))
            AssemblingList.SetValue(rblReason, BasePage.getMyValue(position.ReplaceReason))
            '  Me.TextOtherReason.Value = BasePage.getMyValue(position.OtherReason)
            AssemblingList.SetValueMultiple(cblQualification, BasePage.getMyValue(position.QualificationCode))
            hfAutoCompletSelectedID.Value = position.ReplaceTeacherID
            hfAutoCompletSelectedName.Value = position.ReplaceTeacher

            lblTeacherName.Value = position.ReplaceTeacher
            hfPrincipalID.Value = BasePage.getMyValue(position.PrincipalID)
            Me.TextComments.Text = BasePage.getMyValue(position.Comments)
            Dim timeTable As String = BasePage.getMyValue(position.TimeTable)
            Dim multiSchool As String = BasePage.getMyValue(position.MultipleSchool)
            If timeTable = "" Then
                Me.F100TimeTable.Visible = False
                Me.F100MultipleSchool.Visible = False
            Else
                Me.F100TimeTable.InnerHtml = timeTable
                Me.F100MultipleSchool.InnerHtml = multiSchool
                Me.TextDescription.Style.Add("height", "25px")
            End If
            setStartandEndDate()

            '   AssembleListItem.SetObjValue(combobox, BasePage.getMyValue(position.ReplaceTeacherID))

        Catch ex As Exception

        End Try
    End Sub

    Private Function GetRequestPostingDataSource() As PositionRequesting
        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        Dim schoolcode As String = Page.Request.QueryString("SchoolCode")
        Dim positionID As String = Page.Request.QueryString("PositionID")
        Dim SP As String = CommonListExecute(Of PositionRequesting).ObjSP("PositionRequesting")

        ' PositionID will nover be a 0. request new action will create a new record in database. when create new request add necessary value in SP
        If positionID = "0000" Then   ' there is no 
            myRequestPosting.RequestStatus = "Initial"
            myRequestPosting.RequestSource = "Principal"
            myRequestPosting.SchoolYear = schoolyear
            myRequestPosting.SchoolCode = schoolcode
            myRequestPosting.PositionID = 0
            myRequestPosting.Owner = getHRUser()
            myRequestPosting.PositionType = ddlType.SelectedValue
            Dim myDate As New List(Of LimitDate)
            myDate = DefaultDate.DateSource(schoolyear, ddlType.SelectedValue)
            myRequestPosting.StartDate = myDate(0).StartDate
            If ddlType.SelectedValue = "LTO" Then
                myRequestPosting.EndDate = myDate(0).StartDate = myDate(0).EndDate
            End If
        Else
            Dim parameter = CommonParameter.GetParameters(schoolyear, positionID)
            ' SP = CommonExcute.SPNameAndParameters(SPFile, cPage, "Position")
            '  myRequestPosting = CommonListExecute.RequestPosition(parameter)(0) ' PostingApproveRequestExe.Position(parameter)  ' position = SinglePosition.ApprovePosition(parameter)
            '   myRequestPosting = CommonExcute(Of PositionRequesting).GeneralList(SP, parameter)(0)  ' CommonListExecute.AllPositionList(Of PositionRequesting)(parameter)(0)
            myRequestPosting = RequestPostingExe.Position(parameter)(0) ' CommonExcute(Of PositionRequesting).GeneralList(SP, parameter)(0)  ' CommonListExecute.AllPositionList(Of PositionRequesting)(parameter)(0)
        End If

        If User.Identity.Name = "mif" Then
            Dim SP1 As String = RequestPostingExe.SPName("Position") ' CommonExcute.SPNameAndParameters(SPFile, cPage, "Update") ' CommonOperationExcute(Of PositionRequesting).ObjSP("PositionRequesting", "Update")
            Me.lblRequestID.ToolTip = SP
            Me.btnSave.ToolTip = SP1

        End If
        Return myRequestPosting

    End Function
    Private Sub CheckActions()
        ' all request status set up action to disable. 
        Me.btndelete.Enabled = False
        ' Me.btnRequest.Enabled = False
        Me.btnSave.Enabled = False
        Me.btnEmail.Enabled = False
        If Me.lblRequestSource.Text = "Principal" Then

            If Me.TextStatus.Text = "Initial" Or Me.TextStatus.Text = "Reject" Then
                'Me.btnRequest.Enabled = True
                Me.btnSave.Enabled = True
                Me.btndelete.Enabled = True
                btnEmail.Enabled = True
            ElseIf Me.TextStatus.Text = "Pending" Then
                ' Me.btnRequest.Enabled = False
                '  Me.btnRequest.Text = "Call Back"
                Me.btnEmail.Enabled = True
                Me.btnSave.Enabled = True
                Me.btnSave.Text = "Save"
            Else
                Me.btnEmail.Enabled = False
                Me.btnSave.Enabled = False

            End If

        End If
    End Sub
    Private Sub setControlReadonly(ByVal mylock As Boolean)

        Me.btnEmail.Visible = mylock
        Me.dateStart.Disabled = mylock
        Me.dateEnd.Disabled = mylock

        Me.ddlSchool.Enabled = Not mylock
        Me.ddlschoolcode.Enabled = Not mylock
        Me.TextPositionTitle.Disabled = mylock
        '  Me.TextPositionTitle.Enabled = Not mylock
        'Me.TextTeacherReplaced.Enabled = Not mylock
        ' Me.ddlTeacherReplaced.Enabled = Not mylock
        Me.ddlPositionlevel.Enabled = Not mylock
    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        SaveRequestData()
        '  UpdateDatabase(Action, "Submit " + Action)
        btnEmail_Click(sender, e)


    End Sub
    'Private Function getQualifications() As String
    '    Dim Qual As String = ""
    '    Dim item As ListItem
    '    For Each item In Me.cblQualification.Items
    '        If item.Selected Then
    '            Qual = Qual + item.Text + ";"
    '        End If
    '    Next

    '    Return Qual
    'End Function
    Private Sub SaveRequestData()
        Dim action As String = "Update" 'Me.HiddenFieldApply.Value

        Dim IDs As String = Me.TextRequestID.Text
        '  Dim replID As String = hfReplaceTeacherID.Value
        ' Dim repName As String = hfReplaceTeacherName.Value
        hfAutoCompletSelectedName.Value = lblTeacherName.Value

        If IDs = "0" Then action = "Insert"
        '  Dim saveRequest As New PositionRequesting()
        Try
            With myRequestPosting
                .Operate = action
                .UserID = HttpContext.Current.User.Identity.Name
                .SchoolYear = WorkingProfile.SchoolYear
                .SchoolCode = Me.ddlSchool.SelectedValue
                .PositionID = Me.hfIDs.Value
                .Comments = Me.TextComments.Text
                .PositionType = ddlType.SelectedValue
                .PositionTitle = Me.TextPositionTitle.Value
                .PositionLevel = ddlPositionlevel.SelectedValue
                .Qualification = lblQualification.Value '  getQualifications() ' hfQualifications.Value ' TextQualification.Text
                .QualificationCode = hfQualificationsCode.Value
                .Description = TextDescription.Text
                .FTE = getFTE()
                .FTEPanel = ddlFTEPanel.SelectedValue
                .StartDate = DateFC.YMD2(Me.dateStart.Value)
                .EndDate = DateFC.YMD2(Me.dateEnd.Value)
                .ReplaceTeacher = lblTeacherName.Value  ' hfAutoCompletSelectedName.Value ' ddlTeacherReplaced.SelectedItem.Text
                .ReplaceTeacherID = hfAutoCompletSelectedID.Value ' TextTeacherReplacedID.Text '  ddlTeacherReplaced.SelectedValue

                .ReplaceReason = ddlReason.SelectedValue ' Me.rblReason.SelectedValue ' .TextReasonReplacement.Text
                .OtherReason = ddlReason.SelectedItem.Text
                .Owner = Me.ddlHRStaff.SelectedValue

            End With
            '  Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, action)
            ' Only save the request inforamtion to tcdsb_LTO_Position_Requests table
            ' Dim _result As String = CommonExcute(Of PositionRequesting).GeneralValue(SP, myRequestPosting) ' CommonOperationExcute.RequestOperation(myRequestPosting, action) ' RequestingPostExe.SaveRequest(myRequestPosting, Me.hfIDs.Value)
            Dim _result As String = RequestPostingExe.Update(myRequestPosting) ' CommonExcute(Of PositionRequesting).GeneralValue(SP, myRequestPosting)
            CreatSaveMessage(_result, "Save Request")
        Catch ex As Exception
            CreatSaveMessage("Failed", "Save Request")
        End Try

        ' *** This code for Application Insight ************************************************************ 

        '  Dim mysel As New SelectedObject
        '  mysel.CPNum = schoolcode
        '  mysel.PositionID = IDs

    End Sub

    Private Function ConvertFTE(ByVal value As Object) As String
        Dim fte As Integer = value * 100
        'Dim fte As String = ().ToString()
        Return fte.ToString()
    End Function
    Private Function getFTE() As String
        Dim sVal = Me.rblFTE.SelectedValue
        If sVal = "00" Then
            sVal = Me.TextFTE.Text
        End If
        Dim fte As String = (sVal / 100).ToString()
        Return fte
    End Function
    Private Function getFTE2() As String
        Dim sVal = Me.rblFTE.SelectedValue
        If sVal = "00" Then
            sVal = Me.TextFTE.Text
        End If
        Return sVal
    End Function

    Protected Sub btnSave1_Click(sender As Object, e As EventArgs) Handles btnSave1.Click

        Dim schoolyear As String = WorkingProfile.SchoolYear
        Dim IDs As String = Me.hfIDs.Value
        '  BindSelectedPositionData(schoolyear, IDs)
    End Sub


    Protected Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        UpdateDatabase("Delete", "Delete Request")
    End Sub
    Protected Sub btnRequest_Click(sender As Object, e As EventArgs) Handles btnRequest.Click

        Dim action As String = btnRequest.Text
        UpdateDatabase(action, "Submit " + action)
        btnEmail_Click(sender, e)
        'If Me.btnRequest.Text = "Request Posting" Then
        '    Me.btnRequest.Text = "Call Back"
        'Else
        '    Me.btnRequest.Text = "Request Posting"
        'End If
        'BindPageData()
    End Sub
    Private Sub UpdateDatabase(ByVal action As String, ByVal showAction As String)

        Me.btndelete.Enabled = False

        '   Dim saveRequest As New PositionRequesting()
        Try
            With myRequestPosting
                .Operate = action
                .UserID = HttpContext.Current.User.Identity.Name
                .SchoolYear = WorkingProfile.SchoolYear
                .SchoolCode = Me.ddlSchool.SelectedValue
                .PositionID = Me.TextRequestID.Text
            End With

            '  Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, action)
            ' Only save the request inforamtion to tcdsb_LTO_Position_Requests table
            Dim _result As String = RequestPostingExe.Operation(action, myRequestPosting) '  CommonExcute(Of PositionRequesting).GeneralValue(SP, myRequestPosting) ' CommonOperationExcute.RequestOperation(myRequestPosting, action) ' RequestingPostExe.PostRequest(myRequestPosting, Me.hfIDs.Value)

            CreatSaveMessage(_result, showAction)
        Catch ex As Exception
            CreatSaveMessage("Failed", showAction)
        End Try


    End Sub

    Private Sub CreatSaveMessage(ByVal strMessage As String, ByVal action As String)
        Try
            Dim strScript As String = "CallBackReloadParent(" + """" + action + """,""" + strMessage + """);"
            If action = "Delete Request" Then
                strScript = "CallBackReloadParent(" + """" + action + """,""" + strMessage + """);"
            End If
            ' 
            '  ***  No Ajax
            ClientScript.RegisterStartupScript(GetType(String), "actionMessage", strScript, True)
            '  *** AJAX Save Message
            ' ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType, "save_script", strScript.ToString(), True)
        Catch ex As Exception

        End Try

    End Sub


    'Protected Sub ddlSchool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSchool.SelectedIndexChanged
    '    ListInitial.DDL(Me.ddlschoolcode, ddlSchool.SelectedValue)
    'End Sub

    'Protected Sub ddlschoolcode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlschoolcode.SelectedIndexChanged
    '    ListInitial.DDL(Me.ddlSchool, ddlschoolcode.SelectedValue)
    'End Sub
    Protected Sub ddlType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlType.SelectedIndexChanged
        Dim appType As String = sender.SelectedValue
        setHRStaff()
    End Sub
    Private Sub setHRStaff()
        Dim appType As String = Me.ddlType.SelectedValue
        If appType = "LTO" Then
            RequiredFieldValidator2.Enabled = True
        Else
            RequiredFieldValidator2.Enabled = False
        End If
        AssembleListItem.SetValue(Me.ddlHRStaff, getHRUser())

    End Sub
    Private Function getHRUser() As String
        Dim appType As String = Me.ddlType.SelectedValue
        Dim hrUser As String = WebConfigValue.getValuebyKey("HRUser_LTO_Default")
        If Not appType = "LTO" Then
            If Left(WorkingProfile.SchoolCode, 2) = "05" Then
                hrUser = WebConfigValue.getValuebyKey("HRUser_POP_S_Default")
            Else
                hrUser = WebConfigValue.getValuebyKey("HRUser_POP_E_Default")
            End If
        End If
        Return hrUser
    End Function




    Protected Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        Try
            Dim _mForm As String = WebConfigValue.getValuebyKey("eMailSender")
            Dim _mTO As String = Me.ddlHRStaff.SelectedValue + "@TCDSB.ORG"
            Dim _mCC As String = User.Identity.Name + "@TCDSB.ORG"
            Dim action = "Request"
            'If Me.btnRequest.Text = "Call Back" Then action = "CallBack"


            Dim mEmailTemplate = EmailNotification.EmailSubjectAndTemple(JsonFile, WorkingProfile.ApplicationType, action)
            Dim mSubject As String = Replace(mEmailTemplate.Subject, "PositionTitle", Me.TextPositionTitle.Value) ' EmailNotification.Subject(JsonFile, WorkingProfile.ApplicationType, "Posting")
            Dim mBody = mEmailTemplate.Template '  EmailNotification.Template(JsonFile, WorkingProfile.ApplicationType, "Posting")



            SMTPMailCall(action, _mTO, _mCC, _mForm, mSubject, mBody)
        Catch ex As Exception
            CreateSaveMessage("Failed", "Send Email notification")
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

    Private Sub SMTPMailCall(ByVal eMailAction As String, ByVal _mTO As String, ByVal _mCC As String, ByVal _mFrom As String, ByVal mSubject As String, ByVal mTemplateFile As String)
        Dim _AditionInfo As String = ""
        'Dim _mSubject As String = "Cancel Posted Position " + Me.TextPositionTitle.Value + " Notification"
        'If eMailAction = "Cancel" Then _mSubject = "Cancel Posted Position " + Me.TextPositionTitle.Value + " Notification"
        'If eMailAction = "Remind" Then _mSubject = "Reminder to complete LTO/POP Position hiring process"
        'If eMailAction = "Repost" Then _mSubject = "Position Reposting Notification"
        'If eMailAction = "Request" Then _mSubject = "Request New posting Position Notification"
        'If eMailAction = "CallBack" Then _mSubject = "Notificaiton of Call Back Request New posting"
        Try
            Dim _mBcc As String = WebConfigValue.getValuebyKey("eMailBCC")
            Dim eMailFile As String = getEmailfileHTML(mTemplateFile)


            Dim myEmail As New EmailNotice2()
            With myEmail
                .UserID = User.Identity.Name
                .SchoolYear = hfSchoolyear.Value
                .SchoolCode = ddlSchool.SelectedValue
                .PositionType = WorkingProfile.ApplicationType
                .PositionID = hfIDs.Value
                .PositionTitle = Me.TextPositionTitle.Value ' Me.TextPositionTitle.Text
                .PostingNum = Me.TextRequestID.Text
                .NoticePrincipal = Me.lblPrinciaplName.Text
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



            Dim LogID As String = EmailNotification.SaveEmailNotice(myEmail)
            Dim result = EmailNotification.SendEmail(myEmail) ' User.Identity.Name, _mTO, _mCC, _mBcc, _mFrom, _mSubject, eMailFile, "HTML")

        Catch ex As Exception

        End Try
    End Sub
    Private Function getEmailfileHTML(ByVal mBodyTemplate As String) As String


        Dim sDate As DateTime = Now()
        Dim _Datetime As String = sDate.ToString
        'Dim _eMailTemplate As String = "\Template\PostingNotification_Reposting.htm"
        'If eMailAction = "Cancel" Then _eMailTemplate = "\Template\PostingNotification_Cancel.htm"
        'If eMailAction = "Request" Then _eMailTemplate = "\Template\PostingNotification_RequestNew.htm"
        'If eMailAction = "CallBack" Then _eMailTemplate = "\Template\PostingNotification_RequestCallBack.htm"
        'If eMailAction = "Remind" Then _eMailTemplate = "\Template\ReminderPrincipalToConfirmLTO.htm"
        'If eMailAction = "Repost" Then _eMailTemplate = "\Template\PostingNotification_Reposting.htm"


        Dim myHTML As String = Server.MapPath("..") + "\Template\" + mBodyTemplate
        Dim eMailFile As String = EmailNotification.EmailHTMLBody(myHTML)


        Try


            eMailFile = Replace(eMailFile, "[RequestNumberSTR]", Me.TextRequestID.Text)
            eMailFile = Replace(eMailFile, "[HRStaffNameSTR]", Me.ddlHRStaff.SelectedItem.Text)
            eMailFile = Replace(eMailFile, "[TeacherbeingReplacedSTR]", hfAutoCompletSelectedName.Value) '  Me.ddlTeacherReplaced.SelectedItem.Text)
            eMailFile = Replace(eMailFile, "[ReasonforReplacementSTR]", Me.ddlReason.SelectedItem.Text) '  Me.rblReason.SelectedItem.Text) ' .TextReasonReplacement.Text)
            eMailFile = Replace(eMailFile, "[GradeRequiredSTR]", ddlPositionlevel.SelectedItem.Text) ' Me.TextQualification.Text)
            eMailFile = Replace(eMailFile, "[QualificationRequiredSTR]", lblQualification.Value)  ' Me.TextQualification.Text)
            eMailFile = Replace(eMailFile, "[PrincipalNameSTR]", Me.lblPrinciaplName.Text)
            eMailFile = Replace(eMailFile, "[DateTimeSTR]", _Datetime)
            eMailFile = Replace(eMailFile, "[SchoolNameSTR]", Me.ddlSchool.SelectedItem.Text)
            eMailFile = Replace(eMailFile, "[PositionTitleSTR]", Me.TextPositionTitle.Value)
            eMailFile = Replace(eMailFile, "[PositionDescriptionSTR]", Me.TextDescription.Text)
            eMailFile = Replace(eMailFile, "[PositionDateSTR]", " Start Date:" + Me.dateStart.Value + ",   End Date:" + Me.dateEnd.Value)
            eMailFile = Replace(eMailFile, "[AssignmentStartDateSTR]", Me.dateStart.Value)
            eMailFile = Replace(eMailFile, "[AssignmentEndDateSTR]", Me.dateEnd.Value)
            eMailFile = Replace(eMailFile, "[BTCSTR]", getFTE2() + "%")


        Catch ex As Exception
            eMailFile = ""
        End Try
        Return eMailFile


    End Function

End Class
