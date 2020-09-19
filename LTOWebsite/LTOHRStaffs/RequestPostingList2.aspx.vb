'Imports System.Data
'Imports System.Data.SqlClient

Imports AppOperate
Imports ClassLibrary

Partial Class RequestPostingList2
    Inherits System.Web.UI.Page
     Dim SPFile As String = SPSource.SPFile() '  WebConfigValue.SPFile()  ' Server.MapPath("..\Content\DataAccess.json")
    Dim cPage As String = "Approve"
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Session("currentDataSet") = Nothing
            Dim _sID As String = Page.Request.QueryString("sID")
            If _sID <> Nothing Then Session("SchoolCode") = _sID

            Dim roleShow As String = WorkingProfile.UserRole
            Me.PanelDIV.Visible = True
            Me.HiddenFieldUserRole.Value = WorkingProfile.UserRole
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
        If _UserID = "mif" Then Me.btnQualificationSetup.Visible = True

        Try
            AssemblingList.SetValue(Me.ddlappType, WorkingProfile.ApplicationType)
            AssemblingList.SetValue(Me.ddlPanel, WorkingProfile.Panel)

            Dim parameter As New List2Item()
            With parameter
                .Operate = "SchoolYearbySchool"
                .Para0 = _schoolcode
                .Para1 = WorkingProfile.ApplicationType
            End With
            AssemblingList.SetLists("", Me.ddlSchoolYear, "SchoolYearbySchool", parameter, WorkingProfile.SchoolYear)


            If WorkingProfile.UserRole = "Admin" Or WorkingProfile.UserRole = "HRStaff" Then
                Me.ddlappType.Visible = True
            Else
                Me.ddlappType.Visible = False
            End If

            If Not WorkingProfile.SearchByValue = Nothing Then

                AssemblingList.SetValue(Me.ddlSearchby, WorkingProfile.SearchBy)
                ' ListInitial.DDL(Me.ddlSearchby, WorkingProfile.SearchBy)

                ddlSearchby_SelectedIndexChanged(Me.Page, System.EventArgs.Empty)
                AssemblingList.SetValue(Me.ddlSearchbyValue, WorkingProfile.SearchByValue)

                '  BindGridData(True)

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
            Case "School", "Panel"
                Me.PanelDIV.Visible = False
                AssemblingList.SetLists("", Me.ddlSearchbyValue, searchby, parameter)
            Case "Area", "Level", "RequestState", "RequestFrom"
                AssemblingList.SetLists("", Me.ddlSearchbyValue, searchby, parameter)
            Case "All"
                Me.ddlSearchbyValue.ClearSelection()
                Me.ddlSearchbyValue.Items.Clear()
                Me.txtSearchBox.Text = ""
                '  If Not sender.id = "__Page" Then BindGridData(True)

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
            GridView1.DataBind()

        Catch ex As Exception
            ShowMessage.Exception(ex, Me.Page, "Bind data action")
        End Try
    End Sub
    Private Function getDataSource() As List(Of PositionListApprove)
        Dim searchby As String = Me.ddlSearchby.SelectedValue
        Dim searchValue1 As String = getSeracherValue() 'Me.ddlSearchbyValue.SelectedValue
        Dim searchValue2 As String = getSeracherDate2()
        WorkingProfile.SearchBy = searchby
        WorkingProfile.SearchByValue = searchValue1
        WorkingProfile.SearchByValue2 = searchValue2


        Dim parameters = CommonParameter.GetParameters("Page", User.Identity.Name, Me.ddlSchoolYear.SelectedValue, Me.ddlappType.SelectedValue, Me.ddlPanel.SelectedValue, "Open", searchby, searchValue1, searchValue2)

        '  Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "Positions")
        If User.Identity.Name = "mif" Then Me.lblSuperArea.ToolTip = PostingPositionExe.SPName("Positions")

        '  Dim sList = CommonExcute(Of PositionListApprove).GeneralList(SP, parameters) '   CommonListExecute.ApprovePositions(parameters) ' PostingApproveRequestExe.Positions(parameters) '  ListPosition.ApproveList(parameters) ' .PostingPositions(parameters)
        Dim sList = PostingPositionExe.Positions(parameters) ' mmonExcute(Of PositionListApprove).GeneralList(SP, parameters) '   CommonListExecute.ApprovePositions(parameters) ' PostingApproveRequestExe.Positions(parameters) '  ListPosition.ApproveList(parameters) ' .PostingPositions(parameters)

        Return sList
    End Function
    Private Function getSeracherValue() As String
        Dim searchby As String = Me.ddlSearchby.SelectedValue
        Dim searchbyValue As String = ""
        Select Case searchby
            Case "Area", "School", "Panel", "Level", "RequestState", "RequestFrom"
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
    Protected Sub ddlappType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlappType.SelectedIndexChanged
        WorkingProfile.ApplicationType = Me.ddlappType.SelectedValue
        ' BindGridData(True)
    End Sub

    Protected Sub ddlPanel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPanel.SelectedIndexChanged
        WorkingProfile.Panel = Me.ddlPanel.SelectedValue
        BindGridData(True)
    End Sub


    Protected Sub ddlSearchbyValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSearchbyValue.SelectedIndexChanged
        Me.txtSearchBox.Text = ""
        '   Me.searchdate.Value = ""
        ' BindGridData(True)
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        BindGridData(True)
        ' ********************* get Test Email Acount ******************
        '  getNewAccount("NewNumber")
        '  Me.Labelemail.Text = getNewAccount("Email")
        ' **************************************************************

    End Sub
    Protected Sub ddlSchoolYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSchoolYear.SelectedIndexChanged
        WorkingProfile.SchoolYear = Me.ddlSchoolYear.SelectedValue
        ' BindGridData(True)
    End Sub
    Protected Sub CheckBoxReject_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxReject.CheckedChanged
        BindGridData(True)
    End Sub
End Class

