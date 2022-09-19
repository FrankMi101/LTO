'Imports System.Data
'Imports System.Data.SqlClient
Imports AppOperate
Imports ClassLibrary
' Imports TCDSB.Student
Partial Class HiredPositionList2
    Inherits System.Web.UI.Page
    Dim JsonFile As String = Server.MapPath("..\Content\appList.json")
    ' Dim JsonFile As String = Server.MapPath("..\Content\eMailTemplate.json")
    Dim DataAccessFile As String = ""  'Server.MapPath("..\Content\DataAccess.json")
    Dim cPage As String = "PositionHired"
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

            Dim Staff_4thRound As String = WebConfigValue.getValuebyKey("User_4thRound")
            If Staff_4thRound.IndexOf(UserID) = -1 Then
                ' If UserID = CommonTCDSB.Webconfig.getValuebyKey("User_4thRound") Then
                Me.cb4Th.Checked = Session("4ThRound")
            Else
                Me.cb4Th.Checked = True

            End If


            'Me.ddlSearchbyValue.ClearSelection()
            'Me.ddlSearchbyValue.Items.Clear()
            'Me.txtSearchBox.Text = ""
            'WorkingProfile.SearchByValue = ""


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

        Try
            If WorkingProfile.UserRole = "Admin" Or WorkingProfile.UserRole = "HRStaff" Or WorkingProfile.UserRole = "HRStaff4" Then
                Me.ddlappType.Visible = True
            Else
                Me.ddlappType.Visible = False
            End If
            Dim parameter As New List2Item()
            With parameter
                .Operate = "SchoolYearbySchool"
                .Para0 = _schoolcode
                .Para1 = _schoolcode
            End With
            AssemblingList.SetLists("", Me.ddlSchoolYear, "SchoolYearbySchool", parameter, WorkingProfile.SchoolYear)

            AssemblingList.SetValue(Me.ddlappType, WorkingProfile.ApplicationType)
            AssemblingList.SetValue(Me.ddlPanel, WorkingProfile.Panel)

            AssemblingList.SetLists(JsonFile, ddlSearchby, "Searchby", parameter)

            If Not WorkingProfile.SearchByValue = Nothing Then

                AssemblingList.SetValue(Me.ddlSearchby, WorkingProfile.SearchBy)


                ddlSearchby_SelectedIndexChanged(Me.Page, System.EventArgs.Empty)

                AssemblingList.SetValue(Me.ddlSearchbyValue, WorkingProfile.SearchByValue)
                '  BindGridData(True)

            End If


        Catch ex As Exception

        End Try

    End Sub
    Private Sub BindGridData(ByVal goDatabase As Boolean)
        Try
            Me.GridView1.DataSource = getDataSource()
            Me.GridView1.DataBind()


        Catch ex As Exception
            ShowMessage.Exception(ex, Me.Page, "Bind data action")
        End Try
    End Sub
    Private Function getDataSource() As List(Of PositionListHired)
        Dim searchby As String = Me.ddlSearchby.SelectedValue
        Dim searchValue1 As String = getSeracherValue() 'Me.ddlSearchbyValue.SelectedValue
        Dim searchValue2 As String = getSeracherDate2()
        WorkingProfile.SearchBy = searchby
        WorkingProfile.SearchByValue = searchValue1
        WorkingProfile.SearchByValue2 = searchValue2
        Dim Round4 As String = IIf(Me.cb4Th.Checked, "1", "0")


        Dim parameters = CommonParameter.GetParameters("Page", User.Identity.Name, Me.ddlSchoolYear.SelectedValue, Me.ddlappType.SelectedValue, Me.ddlPanel.SelectedValue, Round4, searchby, searchValue1, searchValue2)
        '    Dim SP As String = CommonExcute.SPNameAndParameters(DataAccessFile, cPage, "Positions") '  CommonListExecute(Of PositionListHired).ObjSP("PositionListHired")

        If User.Identity.Name = "mif" Then
            Me.lblSuperArea.ToolTip = HiredPositionExe.SPName("Positions")
        End If

        Dim sList = HiredPositionExe.Positions(parameters) ' CommonExcute(Of PositionListHired).GeneralList(SP, parameters) ' CommonListExecute.HiredPositions(parameters) '  PostingPublishExe.Positions(parameters) ' .PostingPositions(parameters)
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
            Case "Area", "School", "Panel", "Level", "PostingState", "PendingConfirm", "PostingCycle", "PositionStatus"
                searchbyValue = ""
            Case "PublishDate", "PositionStartDate", "PositionEndDate", "DeadlineDate"
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
    Protected Sub ddlPanel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPanel.SelectedIndexChanged
        WorkingProfile.Panel = Me.ddlPanel.SelectedValue
        ' BindGridData(True)
    End Sub
    Protected Sub ddlSearchby_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSearchby.SelectedIndexChanged

        Dim searchby As String = Me.ddlSearchby.SelectedValue
        Dim _UserID As String = HttpContext.Current.User.Identity.Name
        Dim _schoolYear As String = Me.ddlSchoolYear.SelectedValue
        Me.ddlSearchbyValue.Visible = True
        Me.txtSearchBox.Visible = False
        Me.ddlSearchbyValue.Visible = True
        Me.txtSearchBox.Visible = False
        Me.datepicker.Visible = False
        Me.datepicker2.Visible = False
        Me.DateTo.Visible = False
        Me.PanelDIV.Visible = True
        Dim parameter As New List2Item()
        Select Case searchby

            Case "School"
                Me.PanelDIV.Visible = True
                AssemblingList.SetLists("", Me.ddlSearchbyValue, searchby, parameter)  ' SetupList.ListDDLSearch(Me.ddlSearchbyValue, searchby, _UserID, _schoolYear)
            Case "Area", "PostingCycle", "PostingState", "Panel"
                AssemblingList.SetLists(JsonFile, ddlSearchbyValue, searchby, parameter)

            Case "PendingConfirm", "PositionStatus"
                AssemblingList.SetLists("", Me.ddlSearchbyValue, searchby, parameter)

            Case "PublishDate", "PositionStartDate", "PositionEndDate", "DeadlineDate"
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
        If searchby = "PostingNum" Then
            Dim yearSTR As String = Now().Year.ToString()
            If Left(WorkingProfile.SearchByValue, 5) = yearSTR + "-" Then
                Me.txtSearchBox.Text = WorkingProfile.SearchByValue
            Else
                Me.txtSearchBox.Text = yearSTR + "-"
            End If
        End If

    End Sub


    Protected Sub ddlSearchbyValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSearchbyValue.SelectedIndexChanged
        Me.txtSearchBox.Text = ""
        '  BindGridData(True)
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        BindGridData(True)
    End Sub


    Protected Sub cb4Th_CheckedChanged(sender As Object, e As EventArgs) Handles cb4Th.CheckedChanged
        Session("4ThRound") = Me.cb4Th.Checked
    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        'If (e.Row.RowType = DataControlRowType.DataRow) Then

        '    If (e.Row.RowIndex = 0) Then
        '        e.Row.Style.Add("height", "70px")
        '    End If

        'End If


    End Sub

End Class
