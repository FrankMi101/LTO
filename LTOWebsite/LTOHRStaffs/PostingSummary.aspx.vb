'Imports System.Data
'Imports System.Data.SqlClient
Imports AppOperate
Imports ClassLibrary
'Imports TCDSB.Student
Partial Class PostingSummary
    Inherits System.Web.UI.Page
    Dim JsonFile As String = Server.MapPath("..\Content\appList.json")
    Dim SPFile As String = SPSource.SPFile() '  WebConfigValue.SPFile()  ' Server.MapPath("..\Content\DataAccess.json")
    Dim cPage As String = "Summary"
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
    Public RanValue As String
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then

            Session("currentDataSet") = Nothing
            Dim _sID As String = Page.Request.QueryString("sID")
            If _sID <> Nothing Then Session("SchoolCode") = _sID
            Me.HiddenFieldUserRole.Value = WorkingProfile.UserRole
            Me.hfSchoolCode.Value = WorkingProfile.SchoolCode
            Dim roleShow As String = WorkingProfile.UserRole
            roleShow = roleShow.Replace("Director", "Associate Director")
            If WorkingProfile.UserRole = "Admin" Then roleShow = "Superintendent"
            Dim UserID As String = HttpContext.Current.User.Identity.Name

            WorkingProfile.ApplicationType = WorkingProfile.checkAppTypebyUserID(UserID, WorkingProfile.ApplicationType)

            Me.PanelDIV.Visible = True
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
        Dim parameter As New List2Item()
        With parameter
            .Operate = "SchoolYearbySchool"
            .Para0 = _schoolcode
            .Para1 = WorkingProfile.ApplicationType
        End With

        Try


            AssemblingList.SetLists("", Me.ddlSchoolYear, "SchoolYearbySchool", parameter, _SchoolYear)

            AssemblingList.SetValue(Me.ddlappType, WorkingProfile.ApplicationType)
            AssemblingList.SetValue(Me.ddlPanel, WorkingProfile.Panel)
            If WorkingProfile.UserRole = "Admin" Or WorkingProfile.UserRole = "HRStaff" Then
                Me.ddlappType.Visible = True
            Else
                Me.ddlappType.Visible = False
            End If

            If Not WorkingProfile.SearchByValue = Nothing Then

                AssemblingList.SetLists(JsonFile, ddlSearchby, "Searchby", parameter)
                '  AssembleListItem.SetListsFromJson(ddlSearchby, "Searchby", JsonFile)
                '  AssembleListItem.SetListsFromJson(ddlSearchby, "Searchby", JsonFile, New myJsonLists().SearchBy)
                AssemblingList.SetValue(Me.ddlSearchby, WorkingProfile.SearchBy)
                ddlSearchby_SelectedIndexChanged(Me.Page, System.EventArgs.Empty)
                AssemblingList.SetValue(Me.ddlSearchbyValue, WorkingProfile.SearchByValue)
            End If

        Catch ex As Exception

        End Try

    End Sub
    Protected Sub ddlSearchby_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSearchby.SelectedIndexChanged

        Dim searchby As String = Me.ddlSearchby.SelectedValue
        Dim _UserID As String = HttpContext.Current.User.Identity.Name
        Dim _schoolYear As String = Me.ddlSchoolYear.SelectedValue

        Me.ddlSearchbyValue.Visible = True
        Me.txtSearchBox.Visible = False
        Me.datepicker.Visible = False
        Me.datepicker2.Visible = False
        Me.DateTo.Visible = False
        Me.PanelDIV.Visible = True

        Dim parameter As New List2Item()
        parameter.Para0 = _schoolYear
        Select Case searchby
            Case "Area", "PostingCycle", "PostingState", "Panel"
                AssemblingList.SetLists(JsonFile, ddlSearchbyValue, searchby, Parameter)
            Case "School", "Level", "PendingConfirm", "PositionStatus"
                AssemblingList.SetLists("", Me.ddlSearchbyValue, searchby, Parameter)
            Case "PublishDate", "PositionStartDate", "PositionEndDate", "DeadlineDate", "OpenDate", "CloseDate"
                Me.ddlSearchbyValue.Visible = False
                Me.datepicker.Visible = True
                If IsDate(WorkingProfile.SearchByValue) Then
                    Me.datepicker.Value = WorkingProfile.SearchByValue
                Else
                    Me.datepicker.Value = DateFC.YMD2(Now())
                End If



                Me.datepicker2.Visible = True
                Me.datepicker2.Value = WorkingProfile.SearchByValue2
                Me.DateTo.Visible = True

            Case "All"
                Me.ddlSearchbyValue.ClearSelection()
                Me.ddlSearchbyValue.Items.Clear()
                Me.txtSearchBox.Text = ""
                '   If Not sender.id = "__Page" Then BindGridData(True)
            Case Else
                Me.ddlSearchbyValue.Visible = False
                Me.ddlSearchbyValue.ClearSelection()
                Me.txtSearchBox.Text = WorkingProfile.SearchByValue

                Me.txtSearchBox.Visible = True
                '    Me.searchdate.Visible = False
        End Select


    End Sub
    Private Sub BindGridData(ByVal goDatabase As Boolean)
        Try
            Me.GridView1.DataSource = getDataSource()
            Me.GridView1.DataBind()


        Catch ex As Exception
            Dim em = ex.Message
        End Try
    End Sub

    Private Function getDataSource() As List(Of PositionListPublish)
        Dim searchby As String = Me.ddlSearchby.SelectedValue
        Dim searchValue1 As String = getSeracherValue() 'Me.ddlSearchbyValue.SelectedValue
        Dim searchValue2 As String = getSeracherDate2()
        WorkingProfile.SearchBy = searchby
        WorkingProfile.SearchByValue = searchValue1
        WorkingProfile.SearchByValue2 = searchValue2

        'End With

        '  Dim postingpositions As New List(Of PositionListPosting)
        Dim parameters = CommonParameter.GetParameters("Page", User.Identity.Name, Me.ddlSchoolYear.SelectedValue, Me.ddlappType.SelectedValue, "00", Me.ddlOpenClose.SelectedValue, searchby, searchValue1, searchValue2)

        '   Dim SP As String = CommonListExecute(Of PositionListPublish).ObjSP("PositionListPublish")
        '  Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "Positions") '  CommonExcute.SPNameAndParameters(SPFile, cPage, "Position")

        If User.Identity.Name = "mif" Then
            Me.ddlSchoolYear.ToolTip = PostingSummaryExe.SPName("Positions")
        End If
        Dim sList = PostingSummaryExe.Positions(parameters) ' CommonExcute(Of PositionListPublish).GeneralList(SP, parameters)
        Return sList
    End Function

    Private Function getSeracherValue() As String
        Dim searchby As String = Me.ddlSearchby.SelectedValue
        Dim searchbyValue As String = ""
        Select Case searchby
            Case "Area", "School", "Panel", "Level", "PostingState", "PendingConfirm", "PostingCycle", "PositionStatus"
                searchbyValue = Me.ddlSearchbyValue.SelectedValue
            Case "PublishDate", "PositionStartDate", "PositionEndDate", "DeadlineDate"
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
            Case "PublishDate", "PositionStartDate", "PositionEndDate", "DeadlineDate"
                searchbyValue = Me.datepicker2.Value
            Case Else
                searchbyValue = ""
        End Select
        Return searchbyValue
    End Function


    Protected Sub ddlSchoolYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSchoolYear.SelectedIndexChanged
        WorkingProfile.SchoolYear = Me.ddlSchoolYear.SelectedValue
        ' BindGridData(True)
    End Sub
    Protected Sub ddlappType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlappType.SelectedIndexChanged
        WorkingProfile.ApplicationType = Me.ddlappType.SelectedValue
        '  BindGridData(True)
    End Sub

    Protected Sub ddlPanel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPanel.SelectedIndexChanged
        WorkingProfile.Panel = Me.ddlPanel.SelectedValue

    End Sub


    Protected Sub ddlSearchbyValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSearchbyValue.SelectedIndexChanged
        Me.txtSearchBox.Text = ""
        '   Me.searchdate.Value = ""
        '    BindGridData(True)
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        BindGridData(True)
        ' ********************* get Test Email Acount ******************
        '  getNewAccount("NewNumber")
        '  Me.Labelemail.Text = getNewAccount("Email")
        ' **************************************************************

    End Sub




    Public Function getNewAccount(ByVal type As String) As String
        Dim returnValue As String = ""
        Select Case type
            Case "LastName"
                returnValue = "Test_" + RanValue
            Case "FirstName"
                returnValue = "LTO" + RanValue
            Case "Email"
                returnValue = "LTO_" + RanValue + "." + "Test_" + RanValue + "@TCDSB.ORG"
            Case Else '"New Random number"
                Randomize()
                ' Generate random value between 1 and 999. 
                Dim Ran_value As Integer = 1000 + CInt(Int((999 * Rnd()) + 1))
                RanValue = CStr(Ran_value)
        End Select

        Return returnValue
    End Function


End Class

