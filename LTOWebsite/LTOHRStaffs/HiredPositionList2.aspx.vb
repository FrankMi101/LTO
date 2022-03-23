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

    'Private Function GetDataset(ByVal goDataBase As Boolean) As DataSet
    '    Dim ds As DataSet

    '    Try
    '        If (Session("currentDataSet") Is Nothing) Or (goDataBase) Then


    '            Dim _Role As String = WorkingProfile.UserRole
    '            Dim _schoolyear As String = Me.ddlSchoolYear.SelectedValue

    '            Dim _searchby As String = Me.ddlSearchby.SelectedValue
    '            Dim _searchValue As String = getSeracherValue() 'Me.ddlSearchbyValue.SelectedValue
    '            Dim _searchValue2 As String = getSeracherDate2()
    '            WorkingProfile.SearchBy = _searchby
    '            WorkingProfile.SearchByValue = _searchValue
    '            WorkingProfile.SearchByValue2 = _searchValue2


    '            ds = New DataSet
    '            Dim _User As String = HttpContext.Current.User.Identity.Name


    '            Dim _pageSource As String = Session("PageSource")
    '            Dim _appType As String = Me.ddlappType.SelectedValue
    '            Dim _Panel As String = Me.ddlPanel.SelectedValue

    '            Dim round4th As String = IIf(Me.cb4Th.Checked, "1", "0")

    '            ds = PositionList.BoardHiredPositionListSearch2(_User, _schoolyear, _appType, _Panel, _searchby, _searchValue, _searchValue2, round4th)

    '            ds.Tables(0).TableName = "Position List"
    '            'Dim key0(0) As DataColumn
    '            'key0(0) = ds.Tables(0).Columns("myKey")
    '            'ds.Tables(0).PrimaryKey = key0
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


    'Protected Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
    '    ExportTOEXCEL("Hired List ")
    'End Sub
    'Private Sub ExportTOEXCEL(ByVal _title As String)
    '    Dim _schoolyear As String = Me.ddlSchoolYear.SelectedValue
    '    Dim _Searby As String = Me.ddlSearchby.SelectedItem.Text
    '    Dim _SearchbyValue As String = getSeracherValue()
    '    Dim _positionType As String = Me.ddlappType.SelectedValue
    '    Dim round4th As String = IIf(Me.cb4Th.Checked, "1", "0")

    '    Dim DS As DataSet = PositionListReport.HiredPositionList(_schoolyear, _positionType, _Searby, _SearchbyValue, round4th)



    '    ' Dim template_file_name As String = "NTIP_Teacher_List.xlsx"
    '    ' Dim workbook As Infragistics.Documents.Excel.Workbook = New Infragistics.Documents.Excel.Workbook()
    '    ' workbook = Infragistics.Documents.Excel.Workbook.Load(template_file_name)
    '    ' workbook.Worksheets(0).. .Add("Student List")
    '    '     workbook.Worksheets.Add("Sheet2")


    '    Try
    '        Dim file_name As String = _schoolyear + " " + _SearchbyValue + " Hired Position List"
    '        If round4th = "1" Then file_name = file_name + "( 4th Round )"
    '        Dim template_file_name As String = Server.MapPath("..") + "\Template\Template_Position_Hired.xlsx"
    '        Dim workbook As Infragistics.Documents.Excel.Workbook = Infragistics.Documents.Excel.Workbook.Load(template_file_name)

    '        'workbook.Worksheets(0).Columns(0).Width = 6000
    '        'workbook.Worksheets(0).Columns(1).Width = 3500
    '        'workbook.Worksheets(0).Columns(2).Width = 1500
    '        'workbook.Worksheets(0).Columns(3).Width = 1500
    '        'workbook.Worksheets(0).Columns(4).Width = 10000
    '        'workbook.Worksheets(0).Columns(5).Width = 3000

    '        workbook.Worksheets(0).MergedCellsRegions.Add(0, 0, 0, 15)
    '        workbook.Worksheets(0).Rows(0).Cells(0).Value = file_name
    '        workbook.Worksheets(0).Rows(0).Cells(0).CellFormat.Font.Bold = Infragistics.Documents.Excel.ExcelDefaultableBoolean.True
    '        workbook.Worksheets(0).Rows(0).Cells(0).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
    '        workbook.Worksheets(0).Rows(0).Cells(0).CellFormat.Font.Height = 400  '.Bold = Infragistics.Documents.Excel.ExcelDefaultableBoolean.True

    '        workbook.Worksheets(0).MergedCellsRegions.Add(1, 0, 1, 15)
    '        workbook.Worksheets(0).Rows(1).Cells(0).Value = " ( " + DateFC.YMD(Now()) + ") "
    '        workbook.Worksheets(0).Rows(1).Cells(0).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
    '        workbook.Worksheets(0).Rows(1).Cells(0).CellFormat.Font.Height = 350  '.Bold =

    '        'workbook.Worksheets(0).Rows(2).Cells(0).Value = "Student Name"
    '        'workbook.Worksheets(0).Rows(2).Cells(1).Value = "Student #"
    '        'workbook.Worksheets(0).Rows(2).Cells(2).Value = "F/M"
    '        'workbook.Worksheets(0).Rows(2).Cells(3).Value = "Gr."
    '        'workbook.Worksheets(0).Rows(2).Cells(4).Value = "Placement"
    '        'workbook.Worksheets(0).Rows(2).Cells(5).Value = "Complete"
    '        'workbook.Worksheets(0).Rows(2).CellFormat.Font.Bold = Infragistics.Documents.Excel.ExcelDefaultableBoolean.True
    '        'workbook.Worksheets(0).Rows(2).CellFormat.Font.Height = 250

    '        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
    '            For j As Integer = 0 To ds.Tables(0).Columns.Count - 1
    '                workbook.Worksheets(0).Rows(3 + i).Cells(j).Value = ds.Tables(0).Rows(i)(j)
    '            Next
    '        Next


    '        ' print options
    '        workbook.Worksheets(0).PrintOptions.CenterHorizontally = True
    '        workbook.Worksheets(0).PrintOptions.CenterVertically = True
    '        workbook.Worksheets(0).PrintOptions.Orientation = Infragistics.Documents.Excel.Orientation.Landscape

    '        ' Modify the margins of each page of the worksheet
    '        workbook.Worksheets(0).PrintOptions.BottomMargin = 1
    '        workbook.Worksheets(0).PrintOptions.TopMargin = 1
    '        workbook.Worksheets(0).PrintOptions.LeftMargin = 1
    '        workbook.Worksheets(0).PrintOptions.RightMargin = 1
    '        workbook.Worksheets(0).PrintOptions.HeaderMargin = 0.5
    '        workbook.Worksheets(0).PrintOptions.FooterMargin = 0.5

    '        ' Show the current date centered at the top of each page
    '        workbook.Worksheets(0).PrintOptions.Header = "&C&D"

    '        ' Show "Page <page number> of <number of pages>" on the bottom right of each page
    '        workbook.Worksheets(0).PrintOptions.Footer = "&RPage &P of &N"

    '        ' Print gridlines and row and column headers on each page
    '        workbook.Worksheets(0).PrintOptions.PrintRowAndColumnHeaders = True
    '        workbook.Worksheets(0).PrintOptions.PrintGridlines = True

    '        ' Print cell notes at the end of the worksheet
    '        workbook.Worksheets(0).PrintOptions.PrintNotes = Infragistics.Documents.Excel.PrintNotes.PrintAtEndOfSheet

    '        ' Print all cell errors as "#N/A"
    '        workbook.Worksheets(0).PrintOptions.PrintErrors = Infragistics.Documents.Excel.PrintErrors.PrintAsNA

    '        ' Print in black and white and in draft quality
    '        workbook.Worksheets(0).PrintOptions.PrintInBlackAndWhite = True
    '        workbook.Worksheets(0).PrintOptions.DraftQuality = True

    '        ' The worksheet's pages will be numbered starting with 4
    '        workbook.Worksheets(0).PrintOptions.PageNumbering = Infragistics.Documents.Excel.PageNumbering.UseStartPageNumber
    '        workbook.Worksheets(0).PrintOptions.StartPageNumber = 4

    '        ' Make sure the printed worksheet with a max of 2 pages wide by 10 pages tall.
    '        ' If it needs more space, shrink the content to fit.
    '        workbook.Worksheets(0).PrintOptions.ScalingType = Infragistics.Documents.Excel.ScalingType.FitToPages
    '        workbook.Worksheets(0).PrintOptions.MaxPagesHorizontally = 2
    '        workbook.Worksheets(0).PrintOptions.MaxPagesVertically = 10

    '        ' The pages should printed across then down from the worksheet
    '        workbook.Worksheets(0).PrintOptions.PageOrder = Infragistics.Documents.Excel.PageOrder.OverThenDown

    '        ' The pages should be printed on legal size paper
    '        workbook.Worksheets(0).PrintOptions.PaperSize = Infragistics.Documents.Excel.PaperSize.Legal
    '        '-------------------------------------------------------------------------

    '        ' output to client side
    '        Dim stream As New System.IO.MemoryStream

    '        workbook.Save(stream)

    '        Response.Clear()
    '        '   Response.AddHeader("Content-Disposition", "attachment; filename=SPREADSHEET.XLS")
    '        Response.AddHeader("Content-Disposition", "attachment; filename= " + file_name + ".xlsx")
    '        Response.ContentType = "application/octet-stream"
    '        stream.WriteTo(Response.OutputStream)
    '        Response.Flush()
    '        Response.Close()
    '        Response.End()
    '    Catch ex As Exception

    '        Dim message As String = ex.Message
    '    End Try


    'End Sub




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

    'Protected Sub WebDataGrid1_DataBinding(sender As Object, e As EventArgs) Handles WebDataGrid1.DataBinding

    '    'Dim grid As WebDataGrid = TryCast(sender, WebDataGrid)
    '    'grid.Columns.FromKey("Teacher_Name").
    '    'grid.ScrollTop = 0
    '    'Dim currentPage As Integer = grid.Behaviors.Paging.PageIndex



    'End Sub

    'Protected Sub WebDataGrid1_InitializeRow(sender As Object, e As RowEventArgs) Handles WebDataGrid1.InitializeRow
    '    Dim SC As String = "Substituted-Teacher:"
    '    Dim CellText As String = e.Row.Items(8).Text

    '    If CellText.IndexOf(SC) <> "-1" Then
    '        e.Row.Items(8).CssClass = "SubstituedCell"
    '    End If


    'End Sub
End Class
