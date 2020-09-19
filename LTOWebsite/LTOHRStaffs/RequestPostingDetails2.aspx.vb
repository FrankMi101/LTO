'Imports System.Data
'Imports System.Data.SqlClient
Imports System.IO

'Imports Microsoft.ApplicationInsights.Telemetry.Services
'Imports System.Threading.Tasks
'Imports System.Net.Http

Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services
Imports AppOperate
Imports ClassLibrary


Partial Class RequestPostingDetails2
    Inherits System.Web.UI.Page
    Dim JsonFile As String = Server.MapPath("..\Content\eMailTemplate.json")
    Dim SPFile As String = SPSource.SPFile() '  WebConfigValue.SPFile()  ' Server.MapPath("..\Content\DataAccess.json")
    Dim cPage As String = "Approve"
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
            Dim schoolcode As String = Page.Request.QueryString("SchoolCode")
            If schoolcode = Nothing Or schoolcode = "undefiend" Then
                schoolcode = WorkingProfile.SchoolCode
            Else
                WorkingProfile.SchoolCode = schoolcode
            End If


            Me.ddlPositionlevel.SelectedIndex = 1
            Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
            Dim requestID As String = Page.Request.QueryString("RequestID")
            Dim requestStatus As String = Page.Request.QueryString("RequestStatus")


            AssiblingPage()
            BindPageData()

            setControlReadonly(True)

            If requestStatus = "Duplicate" Then
                Me.btnReject.Visible = True

            End If
        End If
    End Sub
    Private Sub AssiblingPage()

        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        Dim schoolcode As String = Page.Request.QueryString("SchoolCode")
        Dim positionID As String = Page.Request.QueryString("RequestID")
        WorkingProfile.SchoolYear = schoolyear
        WorkingProfile.SchoolCode = schoolcode

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
        AssemblingList.SetListSchool(Me.ddlschoolcode, Me.ddlSchool, "SchoolList", parameter, schoolcode)
        parameter.Para0 = schoolyear
        parameter.Para1 = schoolcode
        parameter.Para3 = positionID
        'AssembleListItem.SetLists(ddlType, "ApplicationType", parameter)
        'AssembleListItem.SetLists(ddlHRStaff, "HRStaffPosting", parameter)
        'AssembleListItem.SetLists(ddlPositionlevel, "PositionLevel", parameter)
        'AssembleListItem.SetLists(Me.rblFTE, "FTEList", parameter)
        'AssembleListItem.SetLists(ddlTeacherReplaced, "SchoolTeacherListR", parameter)

        AssemblingList.SetLists("", Me.ddlHRStaff, "HRStaffPosting", parameter)
        AssemblingList.SetLists("", Me.ddlPositionlevel, "PositionLevel", parameter)
        AssemblingList.SetLists("", Me.ddlType, "ApplicationType", parameter, WorkingProfile.ApplicationType)
        AssemblingList.SetLists("", Me.cblQualification, "Qualification_RequestP", parameter)
        AssemblingList.SetLists("", Me.rblFTE, "FTEList", parameter)
        AssemblingList.SetLists("", Me.ddlTeacherReplaced, "SchoolTeacherList", parameter)
        AssemblingList.SetLists("", Me.cblQualification, "Qualification_RequestP", parameter)


    End Sub


    Private Function getDataSource() As PositionApprove
        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        Dim positionID As String = Page.Request.QueryString("RequestID")
        Dim parameter = CommonParameter.GetParameters(schoolyear, positionID)
        hfSchoolyear.Value = schoolyear
        '   Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "Position") ' CommonListExecute(Of PositionApprove).ObjSP("PositionApprove")

        If User.Identity.Name = "mif" Then
            Me.lblPostingNumber.ToolTip = PostingPositionExe.SPName("Position")
            Me.btnSave.ToolTip = PostingPositionExe.SPName("Save") ' CommonExcute.SPNameAndParameters(SPFile, cPage, "Save")
            Me.btnRequest.ToolTip = PostingPositionExe.SPName("Posting") ' CommonExcute.SPNameAndParameters(SPFile, cPage, "Posting")
            Me.btnReject.ToolTip = PostingPositionExe.SPName("Reject")  'CommonExcute.SPNameAndParameters(SPFile, cPage, "Reject")
        End If


        Return PostingPositionExe.Position(parameter)(0) ' CommonExcute(Of PositionApprove).GeneralList(SP, parameter)(0) '  CommonListExecute.ApprovePosition(parameter)(0) ' PostingApproveRequestExe.Position(parameter)  ' position = SinglePosition.ApprovePosition(parameter)

    End Function
    Private Sub BindPageData()
        Try
            Dim position = getDataSource()
            Me.hfIDs.Value = BasePage.getMyValue(position.PositionID)
            Me.TextRequestID.Text = BasePage.getMyValue(position.PositionID)
            Me.TextStatus.Text = BasePage.getMyValue(position.PositionState)
            Me.TextPositionTitle.Text = BasePage.getMyValue(position.PositionTitle)
            Me.TextDescription.Text = BasePage.getMyValue(position.Description)
            Me.dateStart.Value = BasePage.getMyValue(position.StartDate)
            Me.dateEnd.Value = BasePage.getMyValue(position.EndDate)
            Me.dateRequest.Value = BasePage.getMyValue(position.RequestDate)
            Me.TextRequestSource.Text = BasePage.getMyValue(position.RequestSource)
            Me.lblPrinciaplName.Text = BasePage.getMyValue(position.PrincipalName)
            Me.lblSuperintendent.Text = BasePage.getMyValue(position.Superintendent)
            Me.lblQualification.Text = BasePage.getMyValue(position.Qualification)
            Me.hfQualificationCode.Value = BasePage.getMyValue(position.QualificationCode)
            Dim timeTable As String = BasePage.getMyValue(position.TimeTable)
            Dim multiSchool As String = BasePage.getMyValue(position.MultipleSchool)
            Me.TextTeacherPersonID.Text = BasePage.getMyValue(position.ReplaceTeacherID)
            AssemblingList.SetValue(ddlHRStaff, BasePage.getMyValue(position.Owner))
            AssemblingList.SetValue(ddlType, BasePage.getMyValue(position.PositionType))
            AssemblingList.SetValue(ddlFTEPanel, BasePage.getMyValue(position.FTEPanel))
            AssemblingList.SetValue(rblFTE, ConvertFTE(BasePage.getMyValue(position.FTE)))
            If rblFTE.SelectedValue = "" Then
                Me.TextFTE.Text = ConvertFTE(BasePage.getMyValue(position.FTE))
                AssemblingList.SetValue(rblFTE, "00")
            End If
            AssemblingList.SetValue(ddlPositionlevel, BasePage.getMyValue(position.PositionLevel))
            AssemblingList.SetValueMultiple(cblQualification, BasePage.getMyValue(position.QualificationCode))
            AssemblingList.SetValue(ddlTeacherReplaced, BasePage.getMyValue(position.ReplaceTeacherID))
            ' AssembleListItem.SetValue(rblReason, BasePage.getMyValue(position.ReplaceReason))


            Me.TextOtherReason.Text = BasePage.getMyValue(position.OtherReason)
            hfPrincipalID.Value = BasePage.getMyValue(position.PrincipalID)
            hfRequestUserID.Value = BasePage.getMyValue(position.RequestUser)
            Me.hfAppType.Value = BasePage.getMyValue(position.PositionType)
            Me.txtPostingComments.Text = BasePage.getMyValue(position.Comments)

            Me.LabelWA.Text = BasePage.getMyValue(position.WorkPlaceAccommodation)
            Me.LabelWAFTE.Text = BasePage.getMyValue(position.WorkPlaceFTE)


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

            If Me.TextStatus.Text = "Pending" Then
                Me.btnRequest.Enabled = True
            Else
                Me.btnRequest.Enabled = False
            End If

            setStartandEndDate()

        Catch ex As Exception

        End Try
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
    Private Sub setStartandEndDate()

        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        Dim positionType = WorkingProfile.ApplicationType
        DefaultDate.SetDate(schoolyear, positionType, Me.dateStart, Me.dateEnd, Me.datePublish, Me.dateApplyStart, Me.dateDeadline)

        Me.hfSchoolyearStartDate.Value = Me.dateStart.Value
        Me.hfSchoolyearEndDate.Value = Me.dateEnd.Value


    End Sub

    Private Sub setControlReadonly(ByVal mylock As Boolean)

        Me.btnEmail.Visible = mylock
        ' Me.dateStart.Disabled = mylock
        ' Me.dateEnd.Disabled = mylock

        Me.ddlSchool.Enabled = Not mylock
        Me.ddlschoolcode.Enabled = Not mylock
        Me.TextPositionTitle.Enabled = Not mylock
        Me.ddlTeacherReplaced.Enabled = Not mylock
        Me.cblQualification.Enabled = Not mylock

        ' Me.ddlPositionlevel.Enabled = Not mylock
    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveRequestData()
    End Sub
    Private Sub SaveRequestData()
        Dim action As String = "Save" 'Me.HiddenFieldApply.Value

        Dim userid As String = HttpContext.Current.User.Identity.Name
        Dim IDs As String = Me.TextRequestID.Text
        If IDs = "0" Then action = "Insert"
        Try
            Dim parameter As New PositionApprove()
            With parameter
                .Operate = action
                .UserID = User.Identity.Name
                .SchoolYear = WorkingProfile.SchoolYear
                .SchoolCode = Me.ddlSchool.SelectedValue
                .PositionID = Me.hfIDs.Value
                .Comments = txtPostingComments.Text
                .Description = TextDescription.Text
                .FTE = getFTE()
                .FTEPanel = ddlFTEPanel.SelectedValue
                .StartDate = DateFC.YMD2(dateStart.Value.ToString())
                .EndDate = DateFC.YMD2(dateEnd.Value.ToString())
                .Owner = ddlHRStaff.SelectedValue
                '.DatePublish = DateFC.YMD2(Me.datePublish.Value.ToString())
                '.DateApplyOpen = DateFC.YMD2(Me.dateApplyStart.Value.ToString())
                '.DateApplyClose = DateFC.YMD2(Me.dateDeadline.Value.ToString())
                .PositionLevel = ddlPositionlevel.SelectedValue
                .QualificationCode = hfQualificationCode.Value
                .Qualification = lblQualification.Text
                .ReplaceTeacherID = ddlTeacherReplaced.SelectedValue
            End With

            ' Only save the request inforamtion to tcdsb_LTO_Position_Requests table
            '  Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, action)

            Dim _result As String = PostingPositionExe.Save(parameter) ' .Request() '  CommonExcute(Of PositionApprove).GeneralValue(SP, parameter) ' CommonOperationExcute.ApproveOperation(Parameters, action) '   PostingApproveRequestExe.SavePosting(saverequest, Me.hfIDs.Value)

            CreatSaveMessage(_result, "Save Request")
        Catch ex As Exception
            CreatSaveMessage("Failed", "Save Request")
        End Try



        ' *** This code for Application Insight ************************************************************ 

        '   Dim mysel As New SelectedObject
        '   mysel.CPNum = schoolcode
        '    mysel.PositionID = IDs

    End Sub

    Protected Sub btnSave1_Click(sender As Object, e As EventArgs) Handles btnSave1.Click

        Dim schoolyear As String = WorkingProfile.SchoolYear
        Dim IDs As String = Me.hfIDs.Value
        ' BindSelectedPositionData(schoolyear, IDs)
    End Sub



    Protected Sub btnRequest_Click(sender As Object, e As EventArgs) Handles btnRequest.Click

        Try
            Dim schoolyear As String = hfSchoolyear.Value

            Dim action As String = "Posting"
            Dim posting As New PositionApprove()
            With posting
                .Operate = action
                .UserID = User.Identity.Name
                .SchoolYear = schoolyear
                .SchoolCode = Me.ddlSchool.SelectedValue
                .PositionID = Me.hfIDs.Value
                .Comments = txtPostingComments.Text
                .StartDate = DateFC.YMD2(Me.dateStart.Value.ToString())
                .EndDate = DateFC.YMD2(Me.dateEnd.Value.ToString())
                .DatePublish = DateFC.YMD2(Me.datePublish.Value.ToString())
                .DateApplyOpen = DateFC.YMD2(Me.dateApplyStart.Value.ToString())
                .DateApplyClose = DateFC.YMD2(Me.dateDeadline.Value.ToString())
                .CPNum = ddlTeacherReplaced.SelectedValue
                .RequestSource = Me.TextRequestSource.Text
            End With
            ' will create a new record in Postiion_Published table  and get PositionID as result
            '   Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, action)

            Dim result As String = PostingPositionExe.Posting(posting) ' CommonExcute(Of PositionApprove).GeneralValue(SP, posting) ' 

            '  Dim result As String = CommonOperationExcute.ApproveOperation(posting, action) '  PostingApproveRequestExe.PostingRequest(posting, Me.hfIDs.Value)

            If Not (result = "Successfully" Or result = "Failed") Then
                hfIDs.Value = result
                posting.PositionID = result
                posting.Operate = "PostingNumber"
                '  SP = CommonExcute.SPNameAndParameters(SPFile, cPage, "PostingNumber")
                hfPostingNumber.Value = PostingPositionExe.PostingNumber(posting) ' CommonExcute(Of PositionApprove).GeneralValue(SP, posting) '  CommonOperationExcute.ApproveOperation(posting, "Property") ' PostingApproveRequestExe.PostingNumber(result) ' DateFC.CurrentYearString() + result.ToString() '
                result = "Successfully"
                '  BindSelectedPositionData(schoolyear, IDs)
                Me.btnRequest.Enabled = False
                SendPostingNotificationToPrincipal(action, Me.TextRequestID.Text, hfIDs.Value, schoolyear, "1")
            End If


            Me.btndelete.Enabled = False
            CreatSaveMessage(result, "Posting Request")
        Catch ex As Exception
            CreatSaveMessage("Failed", "Posting Request")
        End Try


        'If datepublish = DateFC.YMD(Date.Now) Then
        '    '  checkMultiSchoolPostingNotification(IDs, RequestID, schoolyear, userid)
        '    SendPostingNotificationToPrincipal(IDs, hfIDs.Value, schoolyear, "1")
        'End If


    End Sub

    Private Sub CreatSaveMessage(ByVal strMessage As String, ByVal action As String)
        Try

            Dim strScript As String = "CallBackReloadParent(" + """" + action + """,""" + strMessage + """);"
            ' Dim strScript As String = "CallShowMessage(" + """" + action + """,""" + strMessage + """);"
            '  ***  No Ajax
            ClientScript.RegisterStartupScript(GetType(String), "actionMessage", strScript, True)
            '  *** AJAX Save Message
            ' ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType, "save_script", strScript.ToString(), True)
        Catch ex As Exception

        End Try

    End Sub

    Private Function getEmailToList() As String
        Dim EmailToList As String = ""


        EmailToList = EmailNotification.UserProfileByID("TCDSBeMailAddress", hfPrincipalID.Value)
        EmailToList += EmailNotification.GetMultipleSchoolEmail(hfSchoolyear.Value, ddlSchool.SelectedValue, Me.hfIDs.Value)
        'PositionDetails.NoticeToActingPrincipal(Me.hfSchoolyear.Value, Me.hfSchoolCode.Value, Me.hfPositionID.Value)

        Return EmailToList
    End Function
    Private Sub SendPostingNotificationToPrincipal(ByVal action As String, ByVal requestIDs As String, ByVal positionID As String, ByVal schoolyear As String, ByVal postingCycle As String)

        Dim userid As String = HttpContext.Current.User.Identity.Name
        Try

            Dim _mTo As String = getEmailToList()
            Dim _mForm As String = WebConfigValue.getValuebyKey("eMailSender")
            Dim _mCC As String = WebConfigValue.getValuebyKey("eMailCC")
            _mCC = EmailNotification.CheckCCMailOwner(_mCC, Me.ddlHRStaff.SelectedValue, User.Identity.Name)
            _mCC = EmailNotification.CheckCCMail(_mCC, "Principal", "Posting", hfAppType.Value, "1", Me.TextPositionTitle.Text, ddlSchool.SelectedValue)

            ' **** LTO posting will send two email notification. 
            ' **** first notificaiton to school principal and HR staff
            ' **** Second email to union people. cc to Mary  email body without teacher's information.
            ' **** POP posting only send one email notification to Principal  cc to HR staff and union people

            Dim myEmailTemple = EmailNotification.EmailSubjectAndTemple(JsonFile, Me.hfAppType.Value, action)
            Dim mSubject As String = Replace(myEmailTemple.Subject, "PositionTitle", Me.TextPositionTitle.Text) ' EmailNotification.Subject(JsonFile, WorkingProfile.ApplicationType, "Posting")
            Dim mTemplateFile = myEmailTemple.Template '  EmailNotification.Template(JsonFile, WorkingProfile.ApplicationType, "Posting")


            If Me.chbNoticeToPrincipal.Checked Then
                SMTPMailCall("Staff", action, _mTo, _mCC, _mForm, mSubject, mTemplateFile)
            End If

            If Me.hfAppType.Value = "LTO" And Me.chbNoticeToUnion.Checked Then
                Dim unioneMail As String = EmailNotification.UnionEmail(ddlSchool.SelectedValue, Me.hfAppType.Value)

                If Not unioneMail = "" Then
                    _mCC = WebConfigValue.getValuebyKey("eMail_UnionA")
                    _mTo = unioneMail
                    If Not action = "Reject" Then
                        SMTPMailCall("Union", action, _mTo, _mCC, _mForm, mSubject, mTemplateFile)
                    End If
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub
    'Private Function CheckAddCCMail(ByVal mCC As String, ByVal checkStr As String) As String
    '    Dim addM As String
    '    addM = WebConfigValue.getValuebyKey(checkStr)
    '    If mCC.IndexOf(addM) < 0 Then
    '        Return ";" + addM
    '    Else
    '        Return ""
    '    End If
    'End Function
    'Private Function getMultiplePrincipalDataSource(ByVal schoolyear As String, ByVal positionID As String) As List(Of MultipleSchoolEmail)
    '    Dim parameter As New ParametersForPosition()
    '    With parameter
    '        .SchoolYear = schoolyear
    '        .PositionID = positionID
    '    End With
    '    '   Dim position As New List(Of PositionApprove)

    '    Dim position = PostingApproveRequestExe.MultipleSchoolPrinciapls(parameter)  ' position = SinglePosition.ApprovePosition(parameter)
    '    Return position
    'End Function


    'Private Sub checkMultiSchoolPostingNotificationNew(ByVal positionID As String, ByVal RequestID As String, ByVal schoolyear As String, ByVal UserId As String)

    '    Dim schoolPrincipals = getMultiplePrincipalDataSource(schoolyear, positionID) '  SinglePosition.PositionByID(parameter)


    '    Dim ds As DataSet = PositionDetails.NoticeToPrincipal(UserId, schoolyear, positionID, RequestID)
    '    Dim _mForm As String = WebConfigValue.getValuebyKey("eMailSender")

    '    Dim row As DataRow
    '    Dim x As Integer = 0
    '    Try
    '        For Each row In position
    '            Dim _Positiontitle As String = row.Item(3)
    '            Dim principalID As String = row.Item(4)
    '            Dim principalName As String = row.Item(5)
    '            Dim _mTo As String = principalID + "@tcdsb.org"
    '            Dim SchoolName As String = row.Item(11)
    '            Dim publishDate As String = row.Item(7)
    '            Dim _FTE As String = row.Item(12)
    '            Dim _mCC As String = row.Item(13) + "@tcdsb.org"
    '            Dim Description As String = row.Item(10)
    '            Dim replaceteacher As String = row.Item(14)
    '            Dim reason As String = row.Item(15)
    '            SMTPMailCall("Staff", "Posting", _mTo, _mCC, _mForm, replaceteacher, _Positiontitle, principalName, SchoolName, reason, _FTE)

    '        Next

    '    Catch ex As Exception

    '    End Try


    'End Sub

    Protected Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        Try
            Dim _mTo As String = getEmailToList()
            Dim _mForm As String = WebConfigValue.getValuebyKey("eMailSender")
            Dim _mCC As String = WebConfigValue.getValuebyKey("eMailCC")
            _mCC = EmailNotification.CheckCCMailOwner(_mCC, Me.ddlHRStaff.SelectedValue, User.Identity.Name)
            _mCC = EmailNotification.CheckCCMail(_mCC, "Principal", "Posting", hfAppType.Value, "1", Me.TextPositionTitle.Text, ddlSchool.SelectedValue)

            Dim myEmailTemple = EmailNotification.EmailSubjectAndTemple(JsonFile, WorkingProfile.ApplicationType, "Posting")

            '  Dim mSubject As String = myEmailTemple.Subject '  EmailNotification.Subject(JsonFile, WorkingProfile.ApplicationType, "Posting")
            Dim mSubject As String = Replace(myEmailTemple.Subject, "PositionTitle", Me.TextPositionTitle.Text)
            Dim mTemplateFile = myEmailTemple.Template '  EmailNotification.Template(JsonFile, WorkingProfile.ApplicationType, "Posting")

            SMTPMailCall("Principal", "Posting", _mTo, _mCC, _mForm, mSubject, mTemplateFile)
        Catch ex As Exception
            ShowMessage.Exception(ex, Me.Page, "Bind data action")
        End Try
    End Sub

    Private Sub SMTPMailCall(ByVal _who As String, ByVal eMailAction As String, ByVal _mTO As String, ByVal _mCC As String, ByVal _mFrom As String, ByVal mSubject As String, ByVal mTemplateFile As String)
        Dim _AditionInfo As String = ""
        'Dim _mSubject As String = "Posted Position From Form 100 " + Me.TextPositionTitle.Text + " Notification"
        'If eMailAction = "Cancel" Then _mSubject = "Cancel Posted Position " + Me.TextPositionTitle.Text + " Notification"
        'If eMailAction = "Remind" Then _mSubject = "Reminder to complete LTO/POP Position hiring process"
        'If eMailAction = "Repost" Then _mSubject = "Position Reposting Notification"
        'If eMailAction = "Request" Then _mSubject = "Position posting Notification"
        'If eMailAction = "Posting" Then _mSubject = "New LTO/POP Position posting Notification"
        'If eMailAction = "Reject" Then _mSubject = "Reject Request Posting Notification"
        Try
            Dim _mBcc As String = WebConfigValue.getValuebyKey("eMailBCC")
            Dim eMailFile As String = getEmailfileHTML(_who, eMailAction, mTemplateFile)

            Dim publicFolder As String = WebConfigValue.getValuebyKey("LTOadminFolder")
            _mBcc = _mBcc + publicFolder

            Dim myEmail As New EmailNotice2()
            With myEmail
                .UserID = User.Identity.Name
                .SchoolYear = hfSchoolyear.Value
                .SchoolCode = ddlSchool.SelectedValue
                .PositionType = Me.hfAppType.Value
                .PositionID = hfIDs.Value
                .PositionTitle = Me.TextPositionTitle.Text
                .PostingNum = hfPostingNumber.Value
                .NoticePrincipal = Me.lblPrinciaplName.Text
                .NoticeFor = _who
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
    Private Function getEmailfileHTML(ByVal _who As String, ByVal eMailAction As String, ByVal mTemplateFile As String) As String

        '  Dim myHTML As String = "" 'Server.MapPath(".") + "\TPA_Notification.htm"
        Dim JsonFileHRstaff As String = Server.MapPath("..\Content\HRStaff.json")
        Dim contact As String = WebConfigValue.HRContact(JsonFileHRstaff, Me.ddlHRStaff.SelectedItem.Value).Extention
        Dim sDate As DateTime = Now()
        Dim _Datetime As String = sDate.ToString
        'Dim _eMailTemplate As String = "\Template\PostingNotification_Reposting.htm"
        'If eMailAction = "Cancel" Then _eMailTemplate = "\Template\PostingNotification_Cancel.htm"
        'If eMailAction = "Remind" Then _eMailTemplate = "\Template\ReminderPrincipalToConfirmLTO.htm"
        'If eMailAction = "Repost" Then _eMailTemplate = "\Template\PostingNotification_Reposting.htm"
        'If eMailAction = "Request" Then _eMailTemplate = "\Template\PostingNotification_RequestNew.htm"
        'If eMailAction = "Posting" Then _eMailTemplate = "\Template\PostingNotification.htm"
        'If eMailAction = "Reject" Then _eMailTemplate = "\Template\PostingNotification_Reject.htm"
        Dim myHTML As String = Server.MapPath("..") + "\Template\" + mTemplateFile
        Dim eMailFile As String = EmailNotification.EmailHTMLBody(myHTML)


        Try


            eMailFile = Replace(eMailFile, "[BTCSTR]", getFTE2() + "%")
            eMailFile = Replace(eMailFile, "[QualificationRequiredSTR]", getQualifications())
            eMailFile = Replace(eMailFile, "[PrincipalNameSTR]", Me.lblPrinciaplName.Text)
            eMailFile = Replace(eMailFile, "[DateTimeSTR]", _Datetime)
            eMailFile = Replace(eMailFile, "[SchoolNameSTR]", Me.ddlSchool.SelectedItem.Text)
            eMailFile = Replace(eMailFile, "[PositionTitleSTR]", Me.TextPositionTitle.Text)
            eMailFile = Replace(eMailFile, "[PositionDescriptionSTR]", Me.TextDescription.Text)
            eMailFile = Replace(eMailFile, "[PositionStartDateSTR]", Me.dateStart.Value)
            eMailFile = Replace(eMailFile, "[PositionEndDateSTR]", Me.dateEnd.Value)
            eMailFile = Replace(eMailFile, "[RejectReasonSTR]", Me.txtPostingComments.Text)
            eMailFile = Replace(eMailFile, "[PositionTypeSTR]", Me.hfAppType.Value)
            eMailFile = Replace(eMailFile, "[PositionOwnerSTR]", contact)
            Dim postingnum As String = hfPostingNumber.Value
            If eMailAction = "Reject" Then postingnum = Me.TextRequestID.Text
            eMailFile = Replace(eMailFile, "[PostingNumberSTR]", postingnum)
            eMailFile = Replace(eMailFile, "[PostingCycleSTR]", "1")


            eMailFile = Replace(eMailFile, "[timeTable]", ViewState("timeTable"))
            eMailFile = Replace(eMailFile, "[multiSchool]", ViewState("multiSchool"))

            If _who = "Union" Then
                eMailFile = Replace(eMailFile, "[TeacherBeReplacedSTR]", "")
                eMailFile = Replace(eMailFile, "[PIDSTR]", "")

            Else
                eMailFile = Replace(eMailFile, "[TeacherBeReplacedSTR]", Me.ddlTeacherReplaced.SelectedItem.Text)
                eMailFile = Replace(eMailFile, "[PIDSTR]", Me.ddlTeacherReplaced.SelectedItem.Value)

            End If


        Catch ex As Exception
            eMailFile = ""
        End Try
        Return eMailFile


    End Function
    Private Function getQualifications() As String

        Dim Qual As String = Me.lblQualification.Text
        'Dim item As ListItem
        'For Each item In Me.cblQualification.Items
        '    If item.Selected Then
        '        Qual = Qual + item.Text + ";"
        '    End If
        'Next

        Return Qual
    End Function
    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        Dim action As String = "Reject" 'Me.HiddenFieldApply.Value
        Dim schoolyear As String = WorkingProfile.SchoolYear
        Dim userid As String = HttpContext.Current.User.Identity.Name
        Dim IDs As String = Me.TextRequestID.Text
        Dim schoolcode As String = Me.ddlSchool.SelectedValue
        Dim RequestID As String = Me.TextRequestID.Text

        Dim parameter As New PositionApprove()
        With parameter
            .Operate = action
            .UserID = User.Identity.Name
            .SchoolYear = schoolyear
            .PositionID = Me.hfIDs.Value
            .Comments = txtPostingComments.Text
            .RequestSource = Me.TextRequestSource.Text
            .SchoolCode = schoolcode
        End With

        '   Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, action)

        Dim result As String = PostingPositionExe.Reject(parameter)  ' CommonExcute(Of PositionApprove).GeneralValue(SP, parameter) '

        '     Dim _result As String = CommonOperationExcute.ApproveOperation(rejectPosting, action) '  PostingApproveRequestExe.RejectRequest(rejectPosting, Me.hfIDs.Value)


        SendPostingNotificationToPrincipal(action, IDs, hfIDs.Value, schoolyear, "1")

        CreatSaveMessage(result, "Reject Request")
    End Sub

End Class
