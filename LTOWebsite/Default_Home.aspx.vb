Imports System.Web
'Imports TCDSB.Student
Imports AppOperate
Imports ClassLibrary

Partial Class Default_Home
    Inherits System.Web.UI.Page
    Dim _UserID As String = HttpContext.Current.User.Identity.Name




#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub


    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        'Put user code to initialize the page here
        If Not Me.Page.IsPostBack Then
            Try
                ' If _UserID = "mif" Then Me.btnAlter.Visible = True
                '  getUserTrackinfo()
                setupLastValue()

                '  Me.SaveB.Attributes.Add("onmouseover", "javascript:setFont(SaveB,'ButtonMouseOver')")
                ' Me.SaveB.Attributes.Add("onmouseout", "javascript:setFont(SaveB,'ButtonNormal')")
            Catch ex As Exception


            End Try

        End If
    End Sub

    Private Sub setupLastValue()
        Try
            'Me.ImgTeacherM.Visible = False

            Dim _Role As String = WorkingProfile.UserRole
            Dim _schoolyear As String = WorkingProfile.SchoolYear
            Dim _schoolcode As String = WorkingProfile.SchoolCode
            Dim parameter As New List2Item()
            With parameter
                .Operate = "SchoolYearbySchool"
                .Para0 = _schoolcode
                .Para1 = WorkingProfile.ApplicationType
            End With


            AssemblingList.SetLists("", Me.ddlSchoolYear, "SchoolYearbySchool", parameter, _schoolyear)



            '  If Not _schoolyear = Nothing Then ListInitial.DDL(Me.ddlSchoolYear, _schoolyear)

            Dim _SuperArea As String = WorkingProfile.SuperArea
            If _SuperArea = "" Then _SuperArea = _schoolcode

            parameter.Operate = "Schoolist"
            parameter.Para0 = _UserID
            parameter.Para1 = _Role
            parameter.Para2 = ""
            parameter.Para3 = WorkingProfile.SchoolYear

            AssemblingList.SetListSchool(ddlSchoolCode, Me.ddlSchools, "SchoolList", parameter)


            '  SetupList.SchoolListDDL(Me.ddlSchools, Me.ddlSchoolCode, "Schoolist", _UserID, _Role, _SuperArea, _schoolyear)



            Try
                If Not (_schoolcode = Nothing Or _schoolcode = "****") Then
                    AssemblingList.SetValue(Me.ddlSchools, _schoolcode)
                    AssemblingList.SetValue(Me.ddlSchoolCode, _schoolcode)
                    WorkingProfile.SchoolName = Me.ddlSchools.SelectedItem.Text
                End If
            Catch ex As Exception

            End Try


            If _Role = "Principal" Or _Role = "LTOTeacher" Then
                Me.ddlSchools.Enabled = False
                Me.ddlSchoolCode.Enabled = False
                ''If Me.ddlSchoolCode.Items.Count > 1 Then Me.ddlSchoolCode.Enabled = True
                ''If Me.ddlSchools.Items.Count > 1 Then Me.ddlSchools.Enabled = True

                If Me.ddlSchools.Items.Count > 1 Then Me.ddlSchools.Enabled = True

            Else
                Me.ddlSchools.Enabled = True
                Me.ddlSchoolCode.Enabled = True
            End If
            'SetupList.ListDDL(Me.ddlGoalArea, "GoalArea", _schoolyear, _schoolcode, _PublishCycle)
            'Try
            '    ListInitial.DDL(Me.ddlGoalArea, WorkingProfile.GoalAreaID)

            'Catch ex As Exception

            'End Try


        Catch ex As Exception
            Dim shw As String = ex.Message
        End Try
    End Sub




    Private Sub ddlSchoolYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlSchoolYear.SelectedIndexChanged
        If ddlSchoolYear.SelectedValue = WorkingProfile.SchoolYear Then Exit Sub
        WorkingProfile.SchoolYear = Me.ddlSchoolYear.SelectedValue
    End Sub


    Private Sub ddlSchoolCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSchoolCode.SelectedIndexChanged
        ' If ddlSchoolCode.SelectedValue = Session("SchoolCode") Then Exit Sub
        AssemblingList.SetValue(Me.ddlSchools, Me.ddlSchoolCode.SelectedValue)
        SchoolChange()
    End Sub
    Private Sub ddlSchools_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlSchools.SelectedIndexChanged
        ' If ddlSchools.SelectedValue = Session("SchoolCode") Then Exit Sub
        AssemblingList.SetValue(Me.ddlSchoolCode, Me.ddlSchools.SelectedValue)
        SchoolChange()
    End Sub
    Private Sub SchoolChange()
        WorkingProfile.SchoolCode = Me.ddlSchools.SelectedValue
        WorkingProfile.SchoolName = Me.ddlSchools.SelectedItem.Text
    End Sub
    Protected Sub SaveB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveB.Click
        ' Page.Response.Redirect("Default.aspx")
        callpostback()
    End Sub
    Private Sub callpostback()

        Dim strScript As String = "<script language=JavaScript>CallParentPostBack()</script>"
        ClientScript.RegisterStartupScript(GetType(String), "callPost", strScript)

    End Sub


    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error
        Try
            Dim ex As Exception = Server.GetLastError()
            Session("Error") = ex.Message
            Session("sTrace") = ex.StackTrace
            Session("Source") = ex.Source
            Session("WorkPage") = "User Profile Page"
        Catch ex As Exception

        End Try

    End Sub


    'Private Sub getUserTrackinfo()
    '    Try
    '        Dim _UserID = HttpContext.Current.User.Identity.Name
    '        Dim DS As DataSet = UserProfileT.getMyLastValue(_UserID)
    '        Dim row As DataRow
    '        For Each row In ds.Tables(0).Rows
    '            Session("SchoolCode") = row.Item(0)
    '            Session("SchoolName") = row.Item(1)
    '            Session("SchoolYear") = row.Item(2)
    '            Session("cSchoolYear") = row.Item(3)
    '            Session("TeacherID") = row.Item(4)
    '            Session("SessionID") = row.Item(5)
    '            If Session("UserArea") = Nothing Then Session("UserArea") = row.Item(6)
    '            Session("UserName") = row.Item(7)
    '            Session("UserPosition") = row.Item(8)
    '            Session("UserScope") = row.Item(8)
    '            Session("WorkPreSchool") = row.Item(9)
    '            Session("TeacherGender") = row.Item(10)
    '        Next

    '    Catch ex As Exception
    '        CommonTCDSB.ShowMsg .Exception(ex, Me.Page, "get User Tracking information ")
    '    End Try

    'End Sub



End Class
