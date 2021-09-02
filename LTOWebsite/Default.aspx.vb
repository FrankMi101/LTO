''Imports TCDSB.Student
Imports AppOperate
Imports ClassLibrary
Partial Class _Default
    Inherits System.Web.UI.Page

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
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Dim appID = Page.Request.QueryString("appid")

            If Not (appID = Nothing Or appID = "undefined") Then
                WorkingProfile.ApplicationType = appID
            Else
                appID = WorkingProfile.ApplicationType
            End If

            GetUserTrackinfo()

            '  **************This is change by HR request at 2014/08/19  Roster can access LTO and POP 3rd round position
            '  If WorkingProfile.UserRole = "Roster" Then WorkingProfile.ApplicationType = "LTO"
            ' ********************************************************************************************************************
            SetEnvironment()
            AssebliningListMenubyUserRole() ' BuildingMenuByRole()
            LoadDefaultPage()
        End If
    End Sub
    Private Sub SetEnvironment()
        Try
            Dim appID As String = WorkingProfile.ApplicationType

            Dim _applName As String = WebConfigValue.AppName ' ..getValuebyKey("ApplicationName")
            Me.PageTitle.Text = IIf(appID = "LTO", "LTO Assignments", "Permanent Open Position")

            Dim browser As System.Web.HttpBrowserCapabilities = Request.Browser
            Dim browser_type As String = HttpContext.Current.Request.Browser.Type
            Dim browser_version As String = HttpContext.Current.Request.Browser.Version
            HiddenFieldBrowserVersion.Value = browser.MajorVersion + browser.MinorVersion
            ' WorkingProfile.UserCPNum = UserTrack.TrackInfo(HttpContext.Current.User.Identity.Name, "CPNum")
            '   getAppSupportInfo()
            ' hfUserRole.Value = WorkingProfile.UserRole
        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadDefaultPage()
        Dim goDefaultList As String = "LTOHRStaffs/LoadingHR.aspx?pID=W"
        Dim cpNum As String = WorkingProfile.UserCPNum
        Session("mytheme") = "Theme1"
        Try
            Select Case WorkingProfile.UserRole
                Case "LTOTeacher", "TOTL", "Roster", "New", "Pending"
                    goDefaultList = "LTOTeachers/LoadingT.aspx?pID=3&CPNum=" + cpNum
                Case "Hired"
                    goDefaultList = "LTOTeachers/LoadingT.aspx?pID=4&CPNum=" + cpNum
                Case "Principal", "Support2", "Support"
                    goDefaultList = "LTOPrincipals/LoadingP.aspx?pID=5"
                Case "HRStaff", "Superintendent", "HRStaff4"
                    goDefaultList = "LTOHRStaffs/LoadingHR.aspx?pID=W"
                Case "Admin"
                    goDefaultList = "LTOHRStaffs/LoadingHR.aspx?pID=W"
                Case Else
                    goDefaultList = "LTOTeachers/LoadingNonQ.aspx"
                    Me.Menu1.Visible = False
            End Select
            Me.mainTop.Attributes.Add("src", goDefaultList)
        Catch ex As Exception
            Me.mainTop.Attributes.Add("src", goDefaultList)
        End Try

    End Sub

    Private Sub SetMyListAttribut(myli As HtmlGenericControl, myItem As HtmlAnchor, myText As String, myLink As String, myVisable As Boolean)
        myItem.Visible = myVisable
        myItem.HRef = myLink
        myItem.InnerText = myText
        myli.Visible = myVisable
    End Sub
    Private Sub SetMyListAttribut(myli As HtmlGenericControl, myItem As HtmlAnchor, myText As String, myLink As String, myVisable As Boolean, ByVal myCount As String, mydiv As HtmlGenericControl)
        myItem.Visible = myVisable
        myItem.HRef = myLink
        myItem.InnerText = myText
        myli.Visible = myVisable
        mydiv.InnerText = "(" + myCount + ")"
    End Sub
    Private Sub AssebliningListMenubyUserRole()
        Dim Path As String = "LTOHRStaffs/LoadingHR.aspx"
        Try
            Select Case WorkingProfile.UserRole
                Case "LTOTeacher", "TOTL", "Roster", "New", "Pending"
                    Path = "LTOTeachers/LoadingT.aspx"
                    SetMyListAttribut(Me.li_Menu0, Me.Menu0, "", "", False)
                    SetMyListAttribut(Me.li_Menu1, Me.Menu1, "Available Open Position", Path + "?pID=3", True)
                    SetMyListAttribut(Me.li_Menu2, Me.Menu2, "My Applied Position", Path + "?pID=4", True)
                    SetMyListAttribut(Me.li_Menu3, Me.Menu3, "My Contact Information", Path + "?pID=5", True)
                    SetMyListAttribut(Me.li_Menu4, Me.Menu4, "", "", False)
                    SetMyListAttribut(Me.li_Menu5, Me.Menu5, "", "", False)
                    SetMyListAttribut(Me.li_Menu6, Me.Menu6, "", "", False)
                    '   SetMyListAttribut(Me.li_Menu7, Me.Menu7, "", "", False)
                    Me.li_Menu1.Attributes.Add("class", "menu1SelectedItem")
                Case "Hired"
                    Path = "LTOTeachers/LoadingT.aspx"
                    SetMyListAttribut(Me.li_Menu0, Me.Menu0, "", "", False)
                    SetMyListAttribut(Me.li_Menu1, Me.Menu1, "Available Open Position", Path + "?pID=3", True)
                    SetMyListAttribut(Me.li_Menu2, Me.Menu2, "My Applied Position", Path + "?pID=4", True)
                    SetMyListAttribut(Me.li_Menu3, Me.Menu3, "My Contact Information", Path + "?pID=5", True)
                    SetMyListAttribut(Me.li_Menu4, Me.Menu4, "", "", False)
                    SetMyListAttribut(Me.li_Menu5, Me.Menu5, "", "", False)
                    SetMyListAttribut(Me.li_Menu6, Me.Menu6, "", "", False)
                    '  SetMyListAttribut(Me.li_Menu7, Me.Menu7, "", "", False)
                    Me.li_Menu2.Attributes.Add("class", "menu1SelectedItem")

                Case "Principal", "Support2", "Support"

                    Path = "LTOPrincipals/LoadingP.aspx"
                    SetMyListAttribut(Me.li_Menu0, Me.Menu0, "", "", False)
                    SetMyListAttribut(Me.li_Menu1, Me.Menu1, "Request Posting List", Path & "?pID=4", True)
                    SetMyListAttribut(Me.li_Menu2, Me.Menu2, "Posted LTO Position List", Path & "?pID=5", True)
                    SetMyListAttribut(Me.li_Menu3, Me.Menu3, "Available Interview Teacher List", Path & "?pID=1", False)
                    SetMyListAttribut(Me.li_Menu4, Me.Menu4, "", "", False)
                    SetMyListAttribut(Me.li_Menu5, Me.Menu5, "", "", False)
                    SetMyListAttribut(Me.li_Menu6, Me.Menu6, "", "", False)
                    '      SetMyListAttribut(Me.li_Menu7, Me.Menu7, "", "", False)
                    Me.li_Menu2.Attributes.Add("class", "menu1SelectedItem")

                Case "HRStaff4"
                    Dim confirmNo As String = UserTrack.WorkingTask(WorkingProfile.UserID, WorkingProfile.ApplicationType, WorkingProfile.SchoolYear, "Confirm")
                    SetMyListAttribut(Me.li_Menu0, Me.Menu0, "", "", False)
                    SetMyListAttribut(Me.li_Menu1, Me.Menu1, "Add and Publish LTO Position", Path & "?pID=1", True)
                    SetMyListAttribut(Me.li_Menu2, Me.Menu2, "", "", False)
                    SetMyListAttribut(Me.li_Menu3, Me.Menu3, "", "", False)
                    SetMyListAttribut(Me.li_Menu4, Me.Menu4, "Confirm the Hire", Path & "?pID=8", True, confirmNo, Me.li_Menu4_c)
                    SetMyListAttribut(Me.li_Menu5, Me.Menu5, "Hired Teacher List", Path & "?pID=9", True)
                    SetMyListAttribut(Me.li_Menu6, Me.Menu6, "LTO/Roster Teacher List", Path & "?pID=y", True)
                    Me.li_Menu1.Attributes.Add("class", "menu1SelectedItem")
                Case "HRStaff", "Superintendent"
                    Dim requestNo As String = UserTrack.WorkingTask(WorkingProfile.UserID, WorkingProfile.ApplicationType, WorkingProfile.SchoolYear, "Request")
                    Dim confirmNo As String = UserTrack.WorkingTask(WorkingProfile.UserID, WorkingProfile.ApplicationType, WorkingProfile.SchoolYear, "Confirm")

                    SetMyListAttribut(Me.li_Menu0, Me.Menu0, "Request from Form100/School", Path & "?pID=0", True, requestNo, Me.li_Menu0_c)
                    SetMyListAttribut(Me.li_Menu1, Me.Menu1, "Add and Publish LTO Position", Path & "?pID=1", True)
                    SetMyListAttribut(Me.li_Menu2, Me.Menu2, "Select Interview Candidate", Path & "?pID=4", True)
                    SetMyListAttribut(Me.li_Menu3, Me.Menu3, "Principal Interview List", Path & "?pID=7", True)
                    SetMyListAttribut(Me.li_Menu4, Me.Menu4, "Confirm the Hire", Path & "?pID=8", True, confirmNo, Me.li_Menu4_c)
                    SetMyListAttribut(Me.li_Menu5, Me.Menu5, "Hired Teacher List", Path & "?pID=9", True)
                    SetMyListAttribut(Me.li_Menu6, Me.Menu6, "", "", False)
                    '  SetMyListAttribut(Me.li_Menu6, Me.Menu6, "Posting Summary", Path & "?pID=X", True)
                    Me.li_Menu1.Attributes.Add("class", "menu1SelectedItem")

                Case "Admin"
                    Dim requestNo As String = UserTrack.WorkingTask(WorkingProfile.UserID, WorkingProfile.ApplicationType, WorkingProfile.SchoolYear, "Request")
                    Dim confirmNo As String = UserTrack.WorkingTask(WorkingProfile.UserID, WorkingProfile.ApplicationType, WorkingProfile.SchoolYear, "Confirm")

                    SetMyListAttribut(Me.li_Menu0, Me.Menu0, "Request from Form100/School", Path & "?pID=0", True, requestNo, Me.li_Menu0_c)
                    SetMyListAttribut(Me.li_Menu1, Me.Menu1, "Add and Publish LTO Position", Path & "?pID=1", True)
                    SetMyListAttribut(Me.li_Menu2, Me.Menu2, "Select Interview Candidate", Path & "?pID=4", True)
                    SetMyListAttribut(Me.li_Menu3, Me.Menu3, "Principal Interview List", Path & "?pID=7", True)
                    SetMyListAttribut(Me.li_Menu4, Me.Menu4, "Confirm the Hire", Path & "?pID=8", True, confirmNo, Me.li_Menu4_c)
                    SetMyListAttribut(Me.li_Menu5, Me.Menu5, "Hired Teacher List", Path & "?pID=9", True)
                    If WorkingProfile.UserID = "mif1" Then
                        SetMyListAttribut(Me.li_Menu6, Me.Menu6, "Posting Summary", Path & "?pID=X", True)
                    Else
                        SetMyListAttribut(Me.li_Menu6, Me.Menu6, "Posting Summary", Path & "?pID=X", False)
                    End If
                    Me.li_Menu1.Attributes.Add("class", "menu1SelectedItem")
                Case Else
                    Path = "LTOTeachers/LoadingT.aspx"
                    SetMyListAttribut(Me.li_Menu0, Me.Menu0, "", "", False)
                    SetMyListAttribut(Me.li_Menu1, Me.Menu1, "Available Open Position", Path + "?pID=3", True)
                    SetMyListAttribut(Me.li_Menu2, Me.Menu2, "", "", False)
                    SetMyListAttribut(Me.li_Menu3, Me.Menu3, "", "", False)
                    SetMyListAttribut(Me.li_Menu4, Me.Menu4, "", "", False)
                    SetMyListAttribut(Me.li_Menu5, Me.Menu5, "", "", False)
                    SetMyListAttribut(Me.li_Menu6, Me.Menu6, "", "", False)
                    '   SetMyListAttribut(Me.li_Menu7, Me.Menu7, "", "", False)
                    Me.li_Menu1.Attributes.Add("class", "menu1SelectedItem")
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetUserTrackinfo()
        Try
            Dim _UserID = HttpContext.Current.User.Identity.Name
            Session("UserID") = _UserID

            Dim userParameter = UserTrack.UserLastWorkingParameter(_UserID)(0)

            WorkingProfile.SchoolCode = userParameter.SchoolCode
            WorkingProfile.SchoolName = userParameter.SchoolName
            WorkingProfile.SchoolYear = userParameter.SchoolYear
            WorkingProfile.SchoolYearCurrent = userParameter.cSchoolYear
            WorkingProfile.UserName = userParameter.UserName
            WorkingProfile.UserPosition = userParameter.UserPosition
            WorkingProfile.ApplicationType = userParameter.PositionType
            WorkingProfile.UserCPNum = userParameter.CPNum
            hfCPNum.Value = userParameter.CPNum
            hfUserRole.Value = WorkingProfile.UserRole
        Catch ex As Exception
            ' ShowMsg.Exception(ex, Me.Page, "get User Tracking information ")
        End Try

    End Sub
    'Private Sub getAppSupportInfo()
    '    Try
    '        Me.hfShowSupportInformation.Value = CommonTCDSB.SystemTextEdit.AppsSupportInfoShow(WorkingProfile.UserID, CommonTCDSB.Webconfig.applicationName, WorkingProfile.UserRole)

    '        If hfShowSupportInformation.Value = "Yes" Then
    '            Dim DS_info As DataSet = CommonTCDSB.SystemTextEdit.AppsSupportInfo(WorkingProfile.UserID, CommonTCDSB.Webconfig.applicationName, WorkingProfile.UserRole)
    '            Me.lblApplicationName.Text = DS_info.Tables(0).Rows(0).Item(1)
    '            Me.lblBrowser.Text = DS_info.Tables(0).Rows(0).Item(2)
    '            Me.lblOwner.Text = DS_info.Tables(0).Rows(0).Item(3)
    '            Me.lblSupportBusiness.Text = DS_info.Tables(0).Rows(0).Item(4)
    '            Me.lblSupportBusinessTel.Text = DS_info.Tables(0).Rows(0).Item(5)
    '            Me.lblSupportBusinessEmail.Text = DS_info.Tables(0).Rows(0).Item(6)
    '            Me.lblAssistant.Text = DS_info.Tables(0).Rows(0).Item(7) + " " + DS_info.Tables(0).Rows(0).Item(8)
    '            Me.lblSupportProgramer.Text = DS_info.Tables(0).Rows(0).Item(9)
    '            Me.lblSupportProgramerTel.Text = DS_info.Tables(0).Rows(0).Item(10)
    '            Me.lblSupportProgramerEmail.Text = DS_info.Tables(0).Rows(0).Item(11)
    '            Me.lblComments.Text = DS_info.Tables(0).Rows(0).Item(12)
    '            Me.lblAppsUsers.Text = DS_info.Tables(0).Rows(0).Item(13)

    '        End If


    '    Catch ex As Exception

    '    End Try

    'End Sub
End Class

