'Imports System.Data
'Imports System.Data.SqlClient
'Imports System.IO
'Imports TCDSB.Student
Imports ClassLibrary
Imports AppOperate

Partial Class InterviewTeam
    Inherits System.Web.UI.Page
    Dim cPage As String = "Interview"
    Dim DataAccessFile As String = ""
    Dim JsonFile As String = Server.MapPath("..\Content\eMailTemplate.json")
    Dim position As PositionPublish
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


            BindDDL()
            BindData()
        End If
    End Sub
    Private Sub BindDDL()


        Dim parameter As New List2Item()
        With parameter
            .Operate = "InterviewPrincipal"
            .Para0 = WorkingProfile.SchoolYear
            .Para1 = WorkingProfile.SchoolCode
        End With

        AssemblingList.SetLists3(Me.ddlInterview1, Me.ddlInterview2, Me.ddlInterview3, parameter)

    End Sub
    Private Sub BindData()
        Try
            Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
            Dim positionID As String = Page.Request.QueryString("PositionID")
            Dim schoolCode As String = Page.Request.QueryString("SchoolCode")

            GetPosition()

            LabelSchool.Text = WorkingProfile.SchoolName
            LabelPositionTitle.Text = position.PositionTitle
            LabelReplaceTeacher.Text = position.ReplaceTeacher
            LabelPostingNumber.Text = position.PostingNumber
            LabelStart.Text = position.StartDate
            LabelEnd.Text = position.EndDate
            '  Dim InterviewS As String = Page.Request.QueryString("interviewS")
            Me.hfPositionID.Value = positionID
            Me.hfSchoolyear.Value = schoolyear
            Dim userid As String = User.Identity.Name

            Dim SPteam As String = CommonExcute.SPNameAndParameters(DataAccessFile, cPage, "TeamMembers")
            Dim para = New With
            {
            .Operate = "Page",
            .UserID = User.Identity.Name,
            .SchoolYear = schoolyear,
            .PositionID = positionID
            }
            Dim team = CommonExcute(Of InterviewerTeam).GeneralList(SPteam, para)(0)


            hfUserIDP1.Value = team.Member1ID
            AssemblingList.SetValue(ddlInterview1, team.Member1ID)

            hfUserIDP2.Value = team.Member2ID

            If hfUserIDP2.Value = "" Then
                btnRemoveP2.Enabled = False
            Else
                AssemblingList.SetValue(ddlInterview2, team.Member2ID)
                btnRemoveP2.Enabled = True
            End If

            hfUserIDP3.Value = team.Member3ID
            If hfUserIDP3.Value = "" Then
                btnRemoveP3.Enabled = False
            Else
                btnRemoveP3.Enabled = True
                AssemblingList.SetValue(ddlInterview3, team.Member3ID)
            End If
            '    ListInitial.SelectOption(Me.combobox3, No3Interview)

        Catch ex As Exception
            Dim msm = ex.Message
        End Try
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

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        BindData()
    End Sub

    Private Sub combobox1_ServerChange(sender As Object, e As EventArgs) Handles combobox1.ServerChange
        '  Dim userid As String = combobox1.SelectedItem.ToString()
        SaveInterviewSelected(1, hfUserIDP1.Value, "Update")
    End Sub

    Private Sub combobox2_ServerChange(sender As Object, e As EventArgs) Handles combobox2.ServerChange
        SaveInterviewSelected(2, hfUserIDP2.Value, "Update")
    End Sub

    Private Sub combobox3_ServerChange(sender As Object, e As EventArgs) Handles combobox3.ServerChange
        SaveInterviewSelected(3, hfUserIDP3.Value, "Update")
    End Sub

    Protected Sub btnRemoveP2_Click(sender As Object, e As EventArgs) Handles btnRemoveP2.Click
        SaveInterviewSelected(2, hfUserIDP2.Value, "Remove")
        BindData()
    End Sub

    Private Sub btnRemoveP3_Click(sender As Object, e As EventArgs) Handles btnRemoveP3.Click
        SaveInterviewSelected(3, hfUserIDP3.Value, "Remove")
        BindData()
    End Sub

    Private Sub ddlInterview1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlInterview1.SelectedIndexChanged
        SaveInterviewSelected(1, sender.SelectedValue, "Update")
        BindData()
    End Sub

    Private Sub ddlInterview2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlInterview2.SelectedIndexChanged
        SaveInterviewSelected(2, sender.SelectedValue, "Update")
        BindData()
    End Sub

    Private Sub ddlInterview3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlInterview3.SelectedIndexChanged
        SaveInterviewSelected(3, sender.SelectedValue, "Update")
        BindData()
    End Sub

    Private Sub SaveInterviewSelected(ByVal sequence As Integer, ByVal interviewUserID As String, ByVal action As String)
        Dim _UserID As String = HttpContext.Current.User.Identity.Name
        Dim _Role As String = WorkingProfile.UserRole
        Dim _SchoolYear As String = WorkingProfile.SchoolYear
        Dim positionID = Me.hfPositionID.Value

        '  Dim parameter As InterviewerTeamMembers = New InterviewerTeamMembers() ' = CommonParameter.GetParameters(WorkingProfile.SchoolYear, Me.hfPositionID.Value,)
        'With Parameter
        '    .Operate = action
        '    .UserID = User.Identity.Name
        '    .SchoolYear = WorkingProfile.SchoolYear
        '    .PositionID = Me.hfPositionID.Value
        '    .Sequence = sequence
        '    .MemberID = interviewUserID
        'End With
        Dim Parameter = New With
            {
            .Operate = action,
            .UserID = User.Identity.Name,
            .SchoolYear = WorkingProfile.SchoolYear,
            .PositionID = positionID,
             .Sequence = sequence,
            .MemberID = interviewUserID
            }
        Dim SPteam As String = CommonExcute.SPNameAndParameters(DataAccessFile, cPage, "UpdateMember")
        Dim result = CommonExcute(Of InterviewerTeamMembers).GeneralValue(SPteam, Parameter)(0)

    End Sub

    Protected Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        '    Dim link As String = "LoadingP.aspx?pID=2&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID + "&SchoolName=" + schoolname + "&appType=" + appType
        If Not ddlInterview1.SelectedValue = "" Then
            sendEmailNoticeLink(ddlInterview1.SelectedValue, ddlInterview1.SelectedItem.Text)
        End If
        If Not ddlInterview2.SelectedValue = "" Then
            sendEmailNoticeLink(ddlInterview2.SelectedValue, ddlInterview2.SelectedItem.Text)
        End If
        If Not ddlInterview3.SelectedValue = "" Then
            sendEmailNoticeLink(ddlInterview3.SelectedValue, ddlInterview3.SelectedItem.Text)
        End If

    End Sub
    Private Sub sendEmailNoticeLink(ByVal ToUserID As String, ByVal TouserName As String)
        Dim action As String = "TeamMember"
        Dim _schoolname As String = LabelSchool.Text
        Dim _Positiontitle As String = LabelPositionTitle.Text
        Dim replaceteacher As String = LabelReplaceTeacher.Text
        Dim _principalName As String = TouserName

        Dim userID As String = User.Identity.Name
        Dim position = CurrentPosition()
        Dim email = New EmailNotification(position)

        Dim myEmail As New EmailNotice2()

        myEmail = email.GetEmailNotice(JsonFile, action, "Team", ToUserID)
        myEmail.EmailBody = GetEmailBody("Team", TouserName, myEmail.EmailBody)
        email.SMTPMailCall("Team", myEmail)


    End Sub
    'Private Sub SMTPMailCall(ByVal _who As String, ByVal myEmail As EmailNotice2)

    '    Try
    '        Dim emailNotice As New EmailNotification()
    '        Dim LogID As String = emailNotice.SaveEmailNotice(myEmail)
    '        Dim result = emailNotice.SendEmail(myEmail) ' User.Identity.Name, _mTO, _mCC, _mBcc, _mFrom, _mSubject, eMailFile, "HTML")

    '    Catch ex As Exception

    '    End Try
    'End Sub


    Private Function GetEmailBody(ByVal _who As String, ByVal toName As String, ByVal mTemplateFile As String) As String


        ' Dim sDate As DateTime = Now()
        Dim _Datetime As String = DateFC.YMDHMS(Now())
        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        Dim schoolcode As String = Page.Request.QueryString("SchoolCode")
        Dim positionID As String = Page.Request.QueryString("PositionID")
        Dim schoolname As String = LabelSchool.Text
        Dim appType As String = WorkingProfile.ApplicationType


        Dim myHTML As String = Server.MapPath("..") + "\Template\" + mTemplateFile

        Dim eMailFile As String = EmailNotification.EmailHTMLBody(myHTML)
        Try

            eMailFile = Replace(eMailFile, "[PostingNumberSTR]", Me.LabelPostingNumber.Text)
            eMailFile = Replace(eMailFile, "[PrincipalNameSTR]", toName)
            eMailFile = Replace(eMailFile, "[DateTimeSTR]", _Datetime)
            eMailFile = Replace(eMailFile, "[SchoolNameSTR]", schoolname)
            eMailFile = Replace(eMailFile, "[PositionTitleSTR]", LabelPositionTitle.Text)

            eMailFile = Replace(eMailFile, "[TeacherBeReplacedSTR]", LabelReplaceTeacher.Text)

            eMailFile = Replace(eMailFile, "[PositionDescriptionSTR]", "")
            Dim mobileSite As String = WebConfigValue.getValuebyKey("MobileSiteGo")

            Dim hrefLink As String = "<a href='" + mobileSite + "?pID=8&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID + "&appType=" + appType + "&SchoolName=" + schoolname + "'>" + "Sign Off on H.M. 40 Document" + "</a>"


            eMailFile = Replace(eMailFile, "[appicationLinkSTR]", hrefLink)



            Dim TeacherbeReplaceSection As String = ""

        Catch ex As Exception
            eMailFile = ""
        End Try
        Return eMailFile

    End Function

    Private Sub GetPosition()
        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        Dim positionID As String = Page.Request.QueryString("PositionID")
        Dim schoolCode As String = Page.Request.QueryString("SchoolCode")

        Dim parameter = CommonParameter.GetParameters(schoolyear, positionID)

        Dim SP As String = CommonExcute.SPNameAndParameters(DataAccessFile, "Publish", "Position")
        position = CommonExcute(Of PositionPublish).GeneralList(SP, parameter)(0)

        If User.Identity.Name = "mif" Then
            Me.LabelReplaceTeacher.ToolTip = SP
        End If


    End Sub
    Private Function CurrentPosition() As PositionPublish

        Dim position = New PositionPublish()
        With position
            .UserID = User.Identity.Name
            .SchoolYear = hfSchoolyear.Value
            .DatePublish = ""
            .DateApplyOpen = ""
            .DateApplyClose = ""
            .Comments = "Interview Team"

            .PostingCycle = ""

        End With

        Return position
    End Function
End Class

