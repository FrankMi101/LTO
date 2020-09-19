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
            End If
            '  **************This is change by HR request at 2014/08/19  Roster can access LTO and POP 3rd round position
            '  If WorkingProfile.UserRole = "Roster" Then WorkingProfile.ApplicationType = "LTO"
            ' ********************************************************************************************************************
            GetUserTrackinfo()



            Dim _applName As String = WebConfigValue.AppName ' ..getValuebyKey("ApplicationName")
            Me.PageTitle.Text = IIf(appID = "LTO", "LTO Assignments", "Permanent Open Position")

            Dim browser As System.Web.HttpBrowserCapabilities = Request.Browser
            Dim browser_type As String = HttpContext.Current.Request.Browser.Type
            Dim browser_version As String = HttpContext.Current.Request.Browser.Version
            HiddenFieldBrowserVersion.Value = browser.MajorVersion + browser.MinorVersion
            WorkingProfile.UserCPNum = UserTrack.TrackInfo(HttpContext.Current.User.Identity.Name, "CPNum")
            '   getAppSupportInfo()
            hfUserRole.Value = WorkingProfile.UserRole
            '***********  getUserTrackinfo()
            Dim goDefaultList As String = ""
            Session("mytheme") = "Theme1"
            '   Me.Menu11.Visible = False
            Select Case WorkingProfile.UserRole
                Case "LTOTeacher", "TOTL", "Roster", "New", "Pending"
                    AssebliningListMenu() ' BuildingMenuByRole()
                    goDefaultList = "LTOTeachers/LoadingT.aspx?pID=3"
                Case "Hired"
                    AssebliningListMenu() ' BuildingMenuByRole()
                    goDefaultList = "LTOTeachers/LoadingT.aspx?pID=4"
                Case "Principal", "Support2", "Support"
                    AssebliningListMenu() 'BuildingMenuByRole()
                    goDefaultList = "LTOPrincipals/LoadingP.aspx?pID=5"
                Case "HRStaff", "Superintendent", "HRStaff4"
                    AssebliningListMenu() ' BuildingMenuByRole()
                    goDefaultList = "LTOHRStaffs/LoadingHR.aspx?pID=W"
                Case "Admin"
                    AssebliningListMenu() ' BuildingMenuByRole()
                    goDefaultList = "LTOHRStaffs/LoadingHR.aspx?pID=W"
                Case Else
                    goDefaultList = "LTOTeachers/LoadingNonQ.aspx"
                    Me.Menu1.Visible = False
            End Select
            Me.mainTop.Attributes.Add("src", goDefaultList)
        End If


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
    Private Sub AssebliningListMenu()
        Dim Path As String = "LTOHRStaffs/LoadingHR.aspx"

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
                SetMyListAttribut(Me.li_Menu2, Me.Menu2, "Posted Open Position List", Path & "?pID=5", True)
                SetMyListAttribut(Me.li_Menu3, Me.Menu3, "Available Interview Teacher List", Path & "?pID=1", False)
                SetMyListAttribut(Me.li_Menu4, Me.Menu4, "", "", False)
                SetMyListAttribut(Me.li_Menu5, Me.Menu5, "", "", False)
                SetMyListAttribut(Me.li_Menu6, Me.Menu6, "", "", False)
                '      SetMyListAttribut(Me.li_Menu7, Me.Menu7, "", "", False)
                Me.li_Menu2.Attributes.Add("class", "menu1SelectedItem")

            Case "HRStaff4"
                Dim confirmNo As String = UserTrack.WorkingTask(WorkingProfile.UserID, WorkingProfile.ApplicationType, WorkingProfile.SchoolYear, "Confirm")
                SetMyListAttribut(Me.li_Menu0, Me.Menu0, "", "", False)
                SetMyListAttribut(Me.li_Menu1, Me.Menu1, "Add and Publish Open Position", Path & "?pID=1", True)
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
                SetMyListAttribut(Me.li_Menu1, Me.Menu1, "Add and Publish Open Position", Path & "?pID=1", True)
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
                SetMyListAttribut(Me.li_Menu1, Me.Menu1, "Add and Publish Open Position", Path & "?pID=1", True)
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

        End Select

    End Sub
    Private Sub BuildingMenuByRole()
        ' Menu2.Visible = False
        'Select Case WorkingProfile.UserRole
        '    Case "LTOTeacher", "TOTL"
        '        Me.Menu11.Items(0).Text = "Available Open Postion"
        '        Me.Menu11.Items(0).NavigateUrl = "LTOTeachers/Loading.aspx?pID=3"

        '        Me.Menu11.Items(1).Text = "My Applied Position"
        '        Me.Menu11.Items(1).NavigateUrl = "LTOTeachers/Loading.aspx?pID=4"
        '        Me.Menu11.Items(2).Text = "New Open Position"
        '        Me.Menu11.Items(2).NavigateUrl = "LTOTeachers/Loading.aspx?pID=5"


        '        '      Me.Menu11.Items(1).Visible = False
        '        Me.Menu11.Items(2).Visible = False
        '        Me.Menu11.Items(3).Visible = False
        '        Me.Menu11.Items(4).Visible = False
        '        Me.Menu11.Items(0).Selected = True

        '        '  Me.Menu11.Visible = False

        '    Case "Principal", "Support2", "Support"
        '        ' Me.Menu11.Items.Clear()
        '        Me.Menu11.Items(0).Text = "Available Interview Teacher List "
        '        Me.Menu11.Items(0).NavigateUrl = "LTOPrincipals/Loading.aspx?pID=1"
        '        Me.Menu11.Items(1).Text = "Request New Open Position"
        '        Me.Menu11.Items(1).NavigateUrl = "LTOPrincipals/Loading.aspx?pID=2"
        '        Me.Menu11.Items(1).Visible = False
        '        Me.Menu11.Items(2).Visible = False
        '        Me.Menu11.Items(3).Visible = False
        '        Me.Menu11.Items(4).Visible = False
        '        Me.Menu11.Items(0).Selected = True
        '    Case "HRStaff"

        '        Me.Menu11.Items(0).Text = "Add and Publish Open Position"
        '        Me.Menu11.Items(0).NavigateUrl = "LTOHRStaffs/Loading.aspx?pID=1"
        '        Me.Menu11.Items(1).Text = "Select Interview Candidate"
        '        Me.Menu11.Items(1).NavigateUrl = "LTOHRStaffs/Loading.aspx?pID=4"
        '        Me.Menu11.Items(2).Text = "Principal Interview List"
        '        Me.Menu11.Items(2).NavigateUrl = "LTOHRStaffs/Loading.aspx?pID=7"
        '        Me.Menu11.Items(3).Text = "Confirm the Hire"
        '        Me.Menu11.Items(3).NavigateUrl = "LTOHRStaffs/Loading.aspx?pID=8"
        '        Me.Menu11.Items(4).Text = "Hired Teacher List"
        '        Me.Menu11.Items(4).NavigateUrl = "LTOHRStaffs/Loading.aspx?pID=9"
        '        '   Me.Menu11.Items(0).Selected = True
        '        '   Me.Menu11.Items(0).Selected = True
        '    Case "Admin"
        '        Me.Menu11.Items(0).Text = "Add and Publish Open Position"
        '        Me.Menu11.Items(0).NavigateUrl = "LTOHRStaffs/Loading.aspx?pID=1"
        '        Me.Menu11.Items(1).Text = "Select Interview Candidate"
        '        Me.Menu11.Items(1).NavigateUrl = "LTOHRStaffs/Loading.aspx?pID=4"
        '        Me.Menu11.Items(2).Text = "Principal Interview List"
        '        Me.Menu11.Items(2).NavigateUrl = "LTOHRStaffs/Loading.aspx?pID=7"
        '        Me.Menu11.Items(3).Text = "Confirm the Hire"
        '        Me.Menu11.Items(3).NavigateUrl = "LTOHRStaffs/Loading.aspx?pID=8"
        '        Me.Menu11.Items(4).Text = "Hired Teacher List"
        '        Me.Menu11.Items(4).NavigateUrl = "LTOHRStaffs/Loading.aspx?pID=9"
        '    Case Else

        'End Select
    End Sub
    Private Sub HRMenu()
        'Me.Menu11.Items(0).Text = "Select Interview Candidate "
        'Me.Menu11.Items(0).NavigateUrl = "LTOHRStaffs/Loading.aspx?pID=1"
        'Me.Menu11.Items(2).Text = "Add and Publish open Position"
        'Me.Menu11.Items(2).NavigateUrl = "LTOHRStaffs/Loading.aspx?pID=4"


        'Dim myMenu3 As Web.UI.WebControls.MenuItem = New Web.UI.WebControls.MenuItem
        'myMenu3.Text = " | "
        'Me.Menu2.Items.Add(myMenu3)
        'Dim myMenu4 As Web.UI.WebControls.MenuItem = New Web.UI.WebControls.MenuItem
        'myMenu4.Value = "RHL"
        'myMenu4.Text = "Confirm the hire"
        'myMenu4.NavigateUrl = "LTOHRStaffs/Loading.aspx?pID=7"
        'myMenu4.Target = "mainTop"
        'Me.Menu2.Items.Add(myMenu4)
        'Dim myMenu5 As Web.UI.WebControls.MenuItem = New Web.UI.WebControls.MenuItem
        'myMenu5.Text = " | "
        'Me.Menu2.Items.Add(myMenu5)
        'Dim myMenu6 As Web.UI.WebControls.MenuItem = New Web.UI.WebControls.MenuItem
        'myMenu6.Value = "HL"
        'myMenu6.Text = "Hire Teacher List"
        'myMenu6.NavigateUrl = "LTOHRStaffs/Loading.aspx?pID=8"
        'myMenu6.Target = "mainTop"
        'Me.Menu2.Items.Add(myMenu6)
        '   Me.Menu11.Items(0).Selected = True
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


            'Dim DS As DataSet = UserTrack.UserLastWorkingParameter(_UserID)
            'Dim row As DataRow
            'For Each row In DS.Tables(0).Rows

            '    WorkingProfile.SchoolCode = row.Item(0)
            '    WorkingProfile.SchoolName = row.Item(1)
            '    WorkingProfile.SchoolYear = row.Item(2)
            '    WorkingProfile.SchoolYearCurrent = row.Item(3)
            '    WorkingProfile.UserName = row.Item(5)
            '    WorkingProfile.UserPosition = row.Item(6)
            '    WorkingProfile.ApplicationType = row.Item(7)
            '    '    WorkingProfile.ViewCycle = row.Item(12)
            '    '     WorkingProfile.GoalAreaID = row.Item(13)

            'Next
            '   WorkingProfile.SchoolArea = DashBoard.Get_SchoolArea(WorkingProfile.SchoolCode)
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

