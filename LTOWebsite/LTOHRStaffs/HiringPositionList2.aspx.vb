'Imports System.Data
'Imports System.Data.SqlClient
Imports AppOperate
Imports ClassLibrary
'Imports TCDSB.Student

Partial Class HiringPositionList2
    Inherits System.Web.UI.Page
    Dim JsonFile As String = Server.MapPath("..\Content\appList.json")
    Dim DataAccessFile As String = ""  'Server.MapPath("..\Content\DataAccess.json")
    Dim cPage As String = "PositionHiring"
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then

            Session("currentDataSet") = Nothing

            Me.HiddenFieldUserRole.Value = WorkingProfile.UserRole
            Dim UserID As String = HttpContext.Current.User.Identity.Name

            WorkingProfile.ApplicationType = WorkingProfile.checkAppTypebyUserID(UserID, WorkingProfile.ApplicationType)
            BindDDLList()

            '      Modify by Frank at 2017/08/29 open for POP Position
            'If WorkingProfile.ApplicationType = "LTO" Then
            'Else
            '    Me.cb4Th.Visible = False
            'End If
            Me.cb4Th.Visible = True

            Dim Staff_4thRound As String = WebConfigValue.getValuebyKey("User_4thRound")
            If Staff_4thRound.IndexOf(UserID) = -1 Then
                ' If UserID = CommonTCDSB.Webconfig.getValuebyKey("User_4thRound") Then
                Me.cb4Th.Checked = Session("4ThRound")
            Else
                Me.cb4Th.Checked = True
            End If
            BindDDLList()
            ' Me.WebDataGrid1.Behaviors.EditingCore.BatchUpdating = True
            BindGridData(True)
        End If

    End Sub
    Private Sub BindDDLList()
        Dim _UserID As String = HttpContext.Current.User.Identity.Name
        Dim _Role As String = WorkingProfile.UserRole
        Dim _SchoolYear As String = WorkingProfile.SchoolYear


        Dim _schoolcode As String = WorkingProfile.SchoolCode

        Try
            If WorkingProfile.UserRole = "Admin" Or WorkingProfile.UserRole = "HRStaff" Then
                Me.ddlappType.Visible = True
            Else
                Me.ddlappType.Visible = False
            End If


            AssemblingList.SetValue(Me.ddlappType, WorkingProfile.ApplicationType)

            Dim parameter As New List2Item()
            With parameter
                .Operate = "SchoolYearbySchool"
                .Para0 = _schoolcode
                .Para1 = WorkingProfile.ApplicationType
            End With

            AssemblingList.SetLists("", Me.ddlSchoolYear, "SchoolYearbySchool", parameter, WorkingProfile.SchoolYear)



            AssemblingList.SetValue(Me.ddlSearchby, WorkingProfile.SearchBy)
            ddlSearchby_SelectedIndexChanged(Me.Page, System.EventArgs.Empty)


            'If Not WorkingProfile.SearchByValue = Nothing Then

            '    If WorkingProfile.SearchByValue = "All" Then
            '        WorkingProfile.SearchBy = "School"
            '        WorkingProfile.SearchByValue = "0000"
            '    End If

            '    'AssemblingList.SetLists(JsonFile, ddlSearchby, "Searchby", parameter)


            '    AssemblingList.SetValue(Me.ddlSearchby, WorkingProfile.SearchBy)

            '    ddlSearchby_SelectedIndexChanged(Me.Page, System.EventArgs.Empty)
            '    AssemblingList.SetValue(Me.ddlSearchbyValue, WorkingProfile.SearchByValue)

            'End If


        Catch ex As Exception

        End Try

    End Sub
    Private Function getDataSource() As List(Of PositionListConfirm)
        Dim searchby As String = Me.ddlSearchby.SelectedValue
        Dim searchValue1 As String = getSeracherValue() 'Me.ddlSearchbyValue.SelectedValue

        WorkingProfile.SearchBy = searchby
        WorkingProfile.SearchByValue = searchValue1
        '  WorkingProfile.SearchByValue2 = searchValue2
        Dim operate As String = IIf(Me.cb4Th.Checked, "4thRound", "Retrieve")

        Dim parameters = CommonParameter.GetParameters(operate, User.Identity.Name, Me.ddlSchoolYear.SelectedValue, Me.ddlappType.SelectedValue, searchby, searchValue1)
        If User.Identity.Name = "mif" Then
            Dim SP As String = ConfirmHireExe.SPName("Positions") ' CommonListExecute(Of PositionListConfirm).ObjSP("PositionListConfirm")
            Me.lblSuperArea.ToolTip = SP

        End If

        Dim sList = ConfirmHireExe.Positions(parameters) ' CommonListExecute.ConfirmPositions(parameters) '  PostingPublishExe.Positions(parameters) ' .PostingPositions(parameters)

        Return sList
    End Function
    'Private Sub clearUltraWebGrid()

    '    Me.UltraWebGrid1.DataSource = Nothing
    '    Me.UltraWebGrid1.DataBind()
    '    Me.UltraWebGrid1.Dispose()

    'End Sub
    Private Sub BindGridData(ByVal goDatabase As Boolean)
        Try

            Me.GridView1.DataSource = getDataSource()
            Me.GridView1.DataBind()

        Catch ex As Exception
            ShowMessage.Exception(ex, Me.Page, "Bind data action")
        End Try
    End Sub
    'Private Function GetDataset(ByVal goDataBase As Boolean) As DataSet
    '    Dim ds As DataSet

    '    Try
    '        If (Session("currentDataSet") Is Nothing) Or (goDataBase) Then


    '            Dim _Role As String = WorkingProfile.UserRole
    '            Dim _schoolyear As String = Me.ddlSchoolYear.SelectedValue

    '            Dim _searchby As String = Me.ddlSearchby.SelectedValue
    '            Dim _searchbyValue As String = getSeracherValue() ' Me.ddlSearchbyValue.SelectedValue
    '            WorkingProfile.SearchBy = _searchby
    '            WorkingProfile.SearchByValue = _searchbyValue
    '            '  Dim _searchText As String = Me.txtSearchBox.Text
    '            ds = New DataSet
    '            Dim _User As String = HttpContext.Current.User.Identity.Name


    '            Dim _pageSource As String = Session("PageSource")
    '            Dim _appType As String = Me.ddlappType.SelectedValue
    '            Dim round4th As String = IIf(Me.cb4Th.Checked, "1", "0")

    '            ds = PositionList.BoardHiringPositionListSearch(_User, _schoolyear, _appType, _searchby, _searchbyValue, round4th)

    '            ds.Tables(0).TableName = "Position List"
    '            Dim key0(0) As DataColumn
    '            key0(0) = ds.Tables(0).Columns("myKey")
    '            ds.Tables(0).PrimaryKey = key0
    '            Session("currentDataSet") = ds
    '        Else
    '            ds = Session("currentDataSet")
    '        End If
    '        Return ds
    '    Catch ex As Exception
    '        CommonTCDSB.ShowMsg.Exception(ex, Me.Page, "Retrieve data action")
    '        Return Nothing
    '    End Try

    'End Function

    Private Function getSeracherValue() As String
        Dim searchby As String = Me.ddlSearchby.SelectedValue
        Dim searchbyValue As String = ""
        Select Case searchby
            Case "Area", "School", "Panel", "Level"
                searchbyValue = Me.ddlSearchbyValue.SelectedValue
            Case Else
                searchbyValue = Me.txtSearchBox.Text

        End Select
        Return searchbyValue
    End Function


    Protected Sub ddlSchoolYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSchoolYear.SelectedIndexChanged
        WorkingProfile.SchoolYear = Me.ddlSchoolYear.SelectedValue
        '  BindGridData(True)
    End Sub
    Protected Sub ddlappType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlappType.SelectedIndexChanged
        WorkingProfile.ApplicationType = Me.ddlappType.SelectedValue
        '   BindGridData(True)
    End Sub

    Protected Sub ddlSearchby_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSearchby.SelectedIndexChanged

        Dim searchby As String = Me.ddlSearchby.SelectedValue
        Dim _UserID As String = HttpContext.Current.User.Identity.Name
        Dim _schoolYear As String = Me.ddlSchoolYear.SelectedValue
        Me.ddlSearchbyValue.Visible = True
        Me.txtSearchBox.Visible = False

        Dim parameter As New List2Item()
        parameter.Para0 = _schoolYear

        Select Case searchby

            Case "Area", "PostingCycle", "PostingState", "Panel"
                AssemblingList.SetLists(JsonFile, ddlSearchbyValue, searchby, parameter)
            Case "School", "Level", "PendingConfirm", "PositionStatus", "State"
                AssemblingList.SetLists("", ddlSearchbyValue, searchby, parameter)

            Case Else
                Me.ddlSearchbyValue.Visible = False
                Me.ddlSearchbyValue.ClearSelection()
                Me.txtSearchBox.Text = SearchbyOtherInitial(searchby)
                Me.txtSearchBox.Visible = True
        End Select

    End Sub
    Private Function SearchbyOtherInitial(ByVal searchby As String) As String
        Dim rVal As String = ""
        If searchby = "PostingNum" Then
            Dim yearSTR As String = Now().Year
            If Left(WorkingProfile.SearchByValue, 5) = yearSTR + "-" Then
                rVal = WorkingProfile.SearchByValue
            Else
                rVal = yearSTR + "-"
            End If
        End If
        Return rVal
    End Function


    Protected Sub ddlSearchbyValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSearchbyValue.SelectedIndexChanged
        Me.txtSearchBox.Text = ""
        ' BindGridData(True)
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        BindGridData(True)
    End Sub


    Protected Sub cb4Th_CheckedChanged(sender As Object, e As EventArgs) Handles cb4Th.CheckedChanged
        Session("4ThRound") = Me.cb4Th.Checked
    End Sub
End Class

