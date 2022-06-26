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
        Dim divHeight As String = "80px"
        If Me.cblQualification.Items.Count > 15 Then divHeight = "200px"
        cblQualficationDIV.Style.Add("height", divHeight)
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
            Me.lblQualification.Value = BasePage.getMyValue(position.Qualification)
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
            Throw New Exception(ex.Message)
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
        '  Me.cblQualification.Enabled = Not mylock

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
                .Qualification = lblQualification.Value
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
                .QualificationCode = hfQualificationCode.Value
                .Qualification = lblQualification.Value

                .FTE = getFTE()
                .FTEPanel = ddlFTEPanel.SelectedValue
                .Owner = ddlHRStaff.SelectedValue
                .PositionLevel = ddlPositionlevel.SelectedValue
                .ReplaceTeacherID = ddlTeacherReplaced.SelectedValue

            End With

            Dim result As String = PostingPositionExe.Posting(posting)  ' 

            If Not (result = "Successfully" Or result = "Failed") Then
                hfIDs.Value = result
                posting.PositionID = result
                posting.Operate = "PostingNumber"
                hfPostingNumber.Value = PostingPositionExe.PostingNumber(posting)
                result = "Successfully"
                Me.btnRequest.Enabled = False
                SendPostingNotification(action)
            End If


            Me.btndelete.Enabled = False
            CreatSaveMessage(result, "Posting Request")
        Catch ex As Exception
            CreatSaveMessage("Failed", "Posting Request")
        End Try

    End Sub

    Protected Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        Dim schoolyear As String = hfSchoolyear.Value
        SendPostingNotification("Posting")

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

    Private Sub SendPostingNotification(ByVal action As String)
        Try

            Dim position = CurrentPosition()
            Dim email = New PostingNotification(position)

            Dim userId As String = User.Identity.Name

            Dim myEmail As New EmailNotice2()

            If Me.chbNoticeToPrincipal.Checked Then
                myEmail = email.GetEmailNotice(JsonFile, action, "Principal", userId)
                myEmail.EmailBody = GetEmailBody("Principal", action, myEmail.EmailBody)
                SMTPMailCall("Principal", myEmail)
            End If

            If Me.chbNoticeToUnion.Checked Then
                myEmail = email.GetEmailNotice(JsonFile, action, "Union", userId)
                myEmail.EmailBody = GetEmailBody("Union", action, myEmail.EmailBody)
                SMTPMailCall("Union", myEmail)
            End If
        Catch ex As Exception
            CreatSaveMessage("Failed", "Send Email notification")
        End Try

    End Sub

    Private Sub SMTPMailCall(ByVal _who As String, ByVal myEmail As EmailNotice2)
        Dim _AditionInfo As String = ""

        Try
            Dim LogID As String = EmailNotification.SaveEmailNotice(myEmail)
            Dim result = EmailNotification.SendEmail(myEmail)

        Catch ex As Exception

        End Try
    End Sub
    Private Function GetHRContact() As Contact
        Dim jsonFileHRstaff As String = Server.MapPath("..\Content\HRStaff.json")
        Dim contact = WebConfigValue.HRContact(jsonFileHRstaff, GetOwner())
        Return contact
    End Function
    Private Function GetEmailBody(ByVal _who As String, ByVal action As String, ByVal bodyTemplate As String) As String

        Dim HRContact = GetHRContact()
        Dim contact As String = HRContact.Extention

        Dim sDate As DateTime = Now()
        Dim _Datetime As String = sDate.ToString
        Dim publishDate As String = Me.datePublish.Value
        Dim openDate As String = Me.dateApplyStart.Value
        Dim closeDate As String = Me.dateDeadline.Value
        Dim level As String = ddlPositionlevel.SelectedItem.Text

        'Dim appType As String = hfAppType.Value
        'Dim myEmailTemple = EmailNotification.EmailSubjectAndTemple(JsonFile, appType, action)
        Dim myHtml As String = Server.MapPath("..") + "\Template\" + bodyTemplate
        Dim eMailFile As String = EmailNotification.EmailHTMLBody(myHtml)


        Try


            eMailFile = Replace(eMailFile, "[BTCSTR]", getFTE2() + "%")
            eMailFile = Replace(eMailFile, "[QualificationRequiredSTR]", lblQualification.Value)
            eMailFile = Replace(eMailFile, "[QualificationSTR]", lblQualification.Value) ' Me.TextQualification.Text)
            eMailFile = Replace(eMailFile, "[PositionLevelSTR]", level) ' Me.TextQualification.Text)

            eMailFile = Replace(eMailFile, "[PrincipalNameSTR]", Me.lblPrinciaplName.Text)
            eMailFile = Replace(eMailFile, "[DateTimeSTR]", _Datetime)
            eMailFile = Replace(eMailFile, "[SchoolNameSTR]", Me.ddlSchool.SelectedItem.Text)
            eMailFile = Replace(eMailFile, "[PositionTitleSTR]", Me.TextPositionTitle.Text)
            eMailFile = Replace(eMailFile, "[PositionDescriptionSTR]", Me.TextDescription.Text)
            eMailFile = Replace(eMailFile, "[PositionStartDateSTR]", Me.dateStart.Value)
            eMailFile = Replace(eMailFile, "[PositionEndDateSTR]", Me.dateEnd.Value)
            eMailFile = Replace(eMailFile, "[RejectReasonSTR]", Me.txtPostingComments.Text)
            eMailFile = Replace(eMailFile, "[PostingOpenDateSTR]", openDate)
            eMailFile = Replace(eMailFile, "[PostingCloseDateSTR]", closeDate)
            eMailFile = Replace(eMailFile, "[PostingPublishDateSTR]", publishDate)



            eMailFile = Replace(eMailFile, "[PositionTypeSTR]", Me.hfAppType.Value)
            eMailFile = Replace(eMailFile, "[PositionOwnerSTR]", contact)
            Dim postingnum As String = hfPostingNumber.Value

            If action = "Reject" Then postingnum = Me.TextRequestID.Text

            eMailFile = Replace(eMailFile, "[PostingNumberSTR]", postingnum)
            eMailFile = Replace(eMailFile, "[PostingCycleSTR]", "")

            eMailFile = Replace(eMailFile, "[timeTable]", ViewState("timeTable"))
            eMailFile = Replace(eMailFile, "[multiSchool]", ViewState("multiSchool"))

            eMailFile = Replace(eMailFile, "[TeacherBeReplacedSTR]", Me.ddlTeacherReplaced.SelectedItem.Text)
            eMailFile = Replace(eMailFile, "[PIDSTR]", Me.ddlTeacherReplaced.SelectedItem.Value)

        Catch ex As Exception
            eMailFile = ""
        End Try
        Return eMailFile


    End Function
    Private Function getQualifications() As String

        Dim Qual As String = Me.lblQualification.Value

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

        Dim result As String = PostingPositionExe.Reject(parameter)

        SendPostingNotification(action)

        CreatSaveMessage(result, "Reject Request")
    End Sub
    Private Function GetOwner() As String
        Return DataTools.GetPositionOwner(ddlHRStaff.SelectedValue, Me.ddlSchool.SelectedValue, Me.hfAppType.Value)
    End Function
    Private Function CurrentPosition() As PositionPublish

        Dim position = New PositionPublish()
        With position
            .UserID = User.Identity.Name
            .SchoolYear = hfSchoolyear.Value
            .SchoolCode = Me.ddlSchool.SelectedValue
            .PositionID = hfIDs.Value
            .PositionType = hfAppType.Value
            .PositionTitle = Me.TextPositionTitle.Text
            .PositionLevel = ddlPositionlevel.SelectedValue
            .Qualification = Me.lblQualification.Value
            .QualificationCode = Me.hfQualificationCode.Value
            .Description = Me.TextDescription.Text
            .FTE = getFTE()
            .FTEPanel = Me.ddlFTEPanel.SelectedValue
            .StartDate = DateFC.YMD2(Me.dateStart.Value)
            .EndDate = DateFC.YMD2(Me.dateEnd.Value)
            .DatePublish = DateFC.YMD2(Me.datePublish.Value)
            .DateApplyOpen = DateFC.YMD2(Me.dateApplyStart.Value)
            .DateApplyClose = DateFC.YMD2(Me.dateDeadline.Value)
            .Comments = Me.txtPostingComments.Text
            .ReplaceTeacherID = ddlTeacherReplaced.SelectedValue
            .ReplaceTeacher = ddlTeacherReplaced.SelectedItem.Text
            .ReplaceReason = Me.TextOtherReason.Text
            .OtherReason = Me.TextOtherReason.Text
            .Owner = Me.ddlHRStaff.SelectedValue
            .PostingCycle = "1"
            .PrincipalID = hfPrincipalID.Value
            .PrincipalName = Me.lblPrinciaplName.Text
        End With

        Return position
    End Function
End Class
