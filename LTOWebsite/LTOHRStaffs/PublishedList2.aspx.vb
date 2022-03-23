'Imports System.Data
'Imports System.Data.SqlClient
Imports AppOperate
Imports ClassLibrary
'Imports TCDSB.Student

Partial Class PublishedList2
    Inherits System.Web.UI.Page
    Dim JsonFile As String = Server.MapPath("..\Content\appList.json")
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            '  Session("currentDataSet") = Nothing

            Session("PageSource") = Page.Request.QueryString("sID")
            Me.HiddenFieldUserRole.Value = WorkingProfile.UserRole
            If Session("PageSource") = "InterviewCandidate" Then
                Me.HiddenFieldPageSource.Value = "0"
            Else
                Me.HiddenFieldPageSource.Value = "1"
            End If

            Dim roleShow As String = WorkingProfile.UserRole
            roleShow = roleShow.Replace("Director", "Associate Director")
            If WorkingProfile.UserRole = "Admin" Then roleShow = "Superintendent"
            Dim UserID As String = HttpContext.Current.User.Identity.Name
            WorkingProfile.ApplicationType = WorkingProfile.checkAppTypebyUserID(UserID, WorkingProfile.ApplicationType)
            BindDDLList()
            '  Me.PanelDIV.Visible = True
        End If

    End Sub

    Private Sub BindDDLList()
        Dim _UserID As String = HttpContext.Current.User.Identity.Name
        Dim _Role As String = WorkingProfile.UserRole
        Dim _SchoolYear As String = WorkingProfile.SchoolYear
        Dim _schoolcode As String = WorkingProfile.SchoolCode

        Try

            AssemblingList.SetValue(Me.ddlappType, WorkingProfile.ApplicationType)
            '  AssemblingList.SetValue(Me.ddlPanel, WorkingProfile.Panel)

            Dim parameter As New List2Item()
            With parameter
                .Operate = "SchoolYearbySchool"
                .Para0 = _schoolcode
                .Para1 = WorkingProfile.ApplicationType
            End With
            AssemblingList.SetLists("", Me.ddlSchoolYear, "SchoolYearbySchool", parameter, WorkingProfile.SchoolYear)

            If Not WorkingProfile.SearchByValue = Nothing Then

                If WorkingProfile.SearchByValue = "All" Then
                    WorkingProfile.SearchBy = "School"
                    WorkingProfile.SearchByValue = "0000"
                End If
                ' AssembleListItem.SetListsFromJson(ddlSearchby, "Searchby", JsonFile)
                AssemblingList.SetLists(JsonFile, Me.ddlSearchby, "Searchby", parameter, WorkingProfile.SearchBy)
                ddlSearchby_SelectedIndexChanged(Me.Page, System.EventArgs.Empty)
                AssemblingList.SetValue(Me.ddlSearchbyValue, WorkingProfile.SearchByValue)

            End If

            If Me.ddlSearchby.SelectedValue = "DeadlineDate" Then

            End If

            BindGridData(True)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BindGridData(ByVal goDatabase As Boolean)
        Try
            ' Dim ds As DataSet
            '  ds = GetDataset(goDatabase)
            Me.GridView1.DataSource = getDataSource() ' ds.Tables(0)
            GridView1.DataBind()

        Catch ex As Exception
            ' CommonTCDSB.ShowMsg.Exception(ex, Me.Page, "Bind data action")
            ShowMessage.Exception(ex, Me.Page, "Bind data action")
        End Try
    End Sub

    Private Function getDataSource() As List(Of PositionListPublished)
        Dim searchby As String = Me.ddlSearchby.SelectedValue
        Dim searchValue1 As String = getSeracherValue() 'Me.ddlSearchbyValue.SelectedValue
        Dim searchValue2 As String = getSeracherDate2()
        WorkingProfile.SearchBy = searchby
        WorkingProfile.SearchByValue = searchValue1
        WorkingProfile.SearchByValue2 = searchValue2
        Dim status As String = IIf(Me.CheckBox1.Checked, "Yes", "No")
        Dim operate As String = IIf(Me.cb4Th.Checked, "4ThRound", Session("PageSource"))
        Dim openstate As String = ddlOpenClose.SelectedValue

        Dim parameters = CommonParameter.GetParameters(operate, User.Identity.Name, Me.ddlSchoolYear.SelectedValue, Me.ddlappType.SelectedValue, openstate, status, searchby, searchValue1, searchValue2)
        If User.Identity.Name = "mif" Then
            '   Dim SP As String = CommonListExecute(Of PositionListPublished).ObjSP("PositionListPublished")
            Me.lblSuperArea.ToolTip = SelectCandidateExe.SPName("Position")
        End If

        Dim sList = SelectCandidateExe.Positions(parameters) ' CommonListExecute.PublishedPositions(parameters) '  PostingPublishExe.Positions(parameters) ' .PostingPositions(parameters)
        Return sList
    End Function


    Private Function getSeracherValue() As String
        Dim searchby As String = Me.ddlSearchby.SelectedValue
        Dim searchbyValue As String = ""
        Select Case searchby
            Case "Area", "School", "Panel", "Level", "PostingState", "PendingConfirm", "PostingCycle"
                searchbyValue = Me.ddlSearchbyValue.SelectedValue
            Case "PublishDate", "PositionStartDate", "PositionEndDate", "DeadlineDate", "OpenDate", "CloseDate"
                searchbyValue = Me.datepicker.Value
            Case Else
                searchbyValue = Me.txtSearchBox.Text

        End Select
        Return searchbyValue
    End Function
    Private Function getSeracherDate2() As String
        Dim searchby As String = Me.ddlSearchby.SelectedValue
        Dim searchbyValue As String = ""
        Select Case searchby
            Case "PublishDate", "PositionStartDate", "PositionEndDate", "DeadlineDate", "OpenDate", "CloseDate"
                searchbyValue = Me.datepicker2.Value
            Case Else
                searchbyValue = ""
        End Select
        Return searchbyValue
    End Function


    Protected Sub ddlSchoolYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSchoolYear.SelectedIndexChanged
        WorkingProfile.SchoolYear = Me.ddlSchoolYear.SelectedValue
        '  BindGridData(True)
    End Sub
    Protected Sub ddlappType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlappType.SelectedIndexChanged
        WorkingProfile.ApplicationType = Me.ddlappType.SelectedValue
        '  BindGridData(True)
    End Sub
    'Protected Sub ddlPanel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPanel.SelectedIndexChanged
    '    WorkingProfile.Panel = Me.ddlPanel.SelectedValue
    '    ' BindGridData(True)
    'End Sub
    Protected Sub ddlSearchby_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSearchby.SelectedIndexChanged

        Dim searchby As String = Me.ddlSearchby.SelectedValue
        Dim _UserID As String = HttpContext.Current.User.Identity.Name
        Dim _schoolYear As String = Me.ddlSchoolYear.SelectedValue

        Me.ddlSearchbyValue.Visible = True
        Me.txtSearchBox.Visible = False
        Me.datepicker.Visible = False
        Me.datepicker2.Visible = False
        Me.DateTo.Visible = False
        Dim parameter As New List2Item()
        With parameter
            .Operate = searchby
            .Para0 = _UserID
            .Para1 = _schoolYear
        End With
        '  Me.PanelDIV.Visible = True
        Select Case searchby
            Case "School", "Level", "State", "PendingConfirm"
                AssemblingList.SetLists("", Me.ddlSearchbyValue, searchby, parameter)  ' SetupList.ListDDLSearch(Me.ddlSearchbyValue, searchby, _UserID, _schoolYear)
            Case "Area", "PostingCycle", "PostingState", "Panel"
                AssemblingList.SetLists(JsonFile, ddlSearchbyValue, searchby, parameter)
            Case "PublishDate", "PositionStartDate", "PositionEndDate", "DeadlineDate", "OpenDate", "CloseDate"
                SearchbyDateInitial()
            Case Else
                Me.ddlSearchbyValue.Visible = False
                Me.ddlSearchbyValue.ClearSelection()
                Me.txtSearchBox.Text = SearchbyOtherInitial(searchby)
                Me.txtSearchBox.Visible = True
                '    Me.searchdate.Visible = False
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
    Private Sub SearchbyDateInitial()
        Try
            Me.ddlSearchbyValue.Visible = False
            Me.datepicker.Visible = True
            If IsDate(WorkingProfile.SearchByValue) Then
                Me.datepicker.Value = WorkingProfile.SearchByValue
            Else
                Me.datepicker.Value = DateFC.YMD(Now(), "")
            End If

            Me.datepicker2.Visible = True
            If IsDate(WorkingProfile.SearchByValue2) Then
                Me.datepicker2.Value = WorkingProfile.SearchByValue2
            Else
                Me.datepicker2.Value = DateFC.YMD(Now(), "")
            End If

            Me.DateTo.Visible = True

            If DateFC.YMD(Me.datepicker2.Value) < DateFC.YMD(Me.datepicker.Value) Then
                Me.datepicker2.Value = Me.datepicker.Value
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddlSearchbyValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSearchbyValue.SelectedIndexChanged
        Me.txtSearchBox.Text = ""
        '  BindGridData(True)
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        BindGridData(True)
    End Sub



End Class

