'Imports System.Data
'Imports System.Data.SqlClient
Imports AppOperate
Imports ClassLibrary
Imports GemBox.Spreadsheet
Imports Microsoft.Office.Interop
Partial Class RequestPositionList2
    Inherits System.Web.UI.Page
    Dim JsonFile As String = Server.MapPath("..\Content\appList.json")
     Dim SPFile As String = SPSource.SPFile() '  WebConfigValue.SPFile()  ' Server.MapPath("..\Content\DataAccess.json")
    Dim cPage As String = "Publish"

    Dim postingList As List(Of PositionListPublish) ' this works

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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        '  postingList = allDataSet()  ' this works
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
            hfUserID.Value = UserID
            WorkingProfile.ApplicationType = WorkingProfile.checkAppTypebyUserID(UserID, WorkingProfile.ApplicationType)

            '   Me.PanelDIV.Visible = True
            BindDDLList()
            ' Me.WebDataGrid1.Behaviors.EditingCore.BatchUpdating = True

            BindGridData(True)

            Dim sps As String = SPSource.SPFile

        End If

    End Sub
    Private Sub BindDDLList()
        Dim _UserID As String = HttpContext.Current.User.Identity.Name
        Dim _Role As String = WorkingProfile.UserRole
        Dim _SchoolYear As String = WorkingProfile.SchoolYear
        Dim _schoolcode As String = WorkingProfile.SchoolCode

        Try

            AssembleListItem.SetValue(Me.ddlappType, WorkingProfile.ApplicationType)
            '  AssembleListItem.SetValue(Me.ddlPanel, WorkingProfile.Panel)

            Dim parameter As New List2Item()
            With parameter
                .Operate = "SchoolYearbySchool"
                .Para0 = _schoolcode
                .Para1 = WorkingProfile.ApplicationType
            End With
            AssemblingList.SetLists("", Me.ddlSchoolYear, "SchoolYearbySchool", parameter, WorkingProfile.SchoolYear)


            If WorkingProfile.UserRole = "Admin" Or WorkingProfile.UserRole = "HRStaff" Then
                Me.ddlappType.Enabled = True
                btnNewOpen.Visible = True
            Else
                Me.ddlappType.Enabled = True
                btnNewOpen.Visible = False
            End If


            If Not WorkingProfile.SearchByValue = Nothing Then

                If WorkingProfile.SearchByValue = "All" Then
                    WorkingProfile.SearchBy = "School"
                    WorkingProfile.SearchByValue = "0000"
                End If

                AssemblingList.SetLists(JsonFile, ddlSearchby, "Searchby", parameter)
                '  AssembleListItem.SetListsFromJson(ddlSearchby, "Searchby", JsonFile)
                '  AssembleListItem.SetListsFromJson(ddlSearchby, "Searchby", JsonFile, New myJsonLists().SearchBy)
                AssemblingList.SetValue(Me.ddlSearchby, WorkingProfile.SearchBy)
                ddlSearchby_SelectedIndexChanged(Me.Page, System.EventArgs.Empty)
                AssemblingList.SetValue(Me.ddlSearchbyValue, WorkingProfile.SearchByValue)

            End If

        Catch ex As Exception
            Dim exm As String = ex.Message
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


        Dim parameter As New List2Item()
        parameter.Para0 = _schoolYear
        Select Case searchby

            Case "Area", "PostingCycle", "PostingState", "Panel"
                '  AssembleListItem.SetListsFromJson(ddlSearchbyValue, searchby, JsonFile)
                AssemblingList.SetLists(JsonFile, ddlSearchbyValue, searchby, parameter)
            Case "School", "Level", "PendingConfirm", "PositionStatus"
                ' AssembleListItem.SetSearchList(Me.ddlSearchbyValue, searchby, _UserID, _schoolYear)
                AssemblingList.SetLists("", Me.ddlSearchbyValue, searchby, parameter)
            Case "PublishDate", "PositionStartDate", "PositionEndDate", "DeadlineDate", "OpenDate", "CloseDate"
                Me.ddlSearchbyValue.Visible = False
                Me.datepicker.Visible = True
                If IsDate(WorkingProfile.SearchByValue) Then
                    Me.datepicker.Value = WorkingProfile.SearchByValue
                Else
                    Me.datepicker.Value = DateFC.YMD(Now(), "-")
                End If

                Me.datepicker2.Visible = True
                Me.datepicker2.Value = DateFC.YMD(WorkingProfile.SearchByValue2, "-")
                Me.DateTo.Visible = True



                If DateFC.YMD(Me.datepicker2.Value) < DateFC.YMD(Me.datepicker.Value) Then
                    Me.datepicker2.Value = Me.datepicker.Value
                End If


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
            Dim yearSTR As String = Now().Year
            If Left(WorkingProfile.SearchByValue, 4) = yearSTR Then
                Me.txtSearchBox.Text = WorkingProfile.SearchByValue
            Else
                Me.txtSearchBox.Text = yearSTR + "-"
            End If
        End If

    End Sub
    Private Sub BindGridData(ByVal goDatabase As Boolean)
        Try
            Me.GridView1.DataSource = getDataSourceNew() '.OfType(Of PositionListPublish)
            ' Me.GridView1.DataSource = getFilteredDataSetbyLinq() 'this function works
            Me.GridView1.DataBind()

        Catch ex As Exception
            ShowMessage.Exception(ex, Me.Page, "Bind data action")
        End Try
    End Sub

    Private Function getFilteredDataSetbyLinq() As List(Of PositionListPublish)
        Try
            Dim dataset As Object ' List(Of PositionListPublish) = New List(Of PositionListPublish)
            Dim searchValue1 As String = getSeracherValue() 'Me.ddlSearchbyValue.SelectedValue
            Dim searchValue2 As String = getSeracherDate2()
            Dim searchby As String = Me.ddlSearchby.SelectedValue

            Select Case searchby
                Case "All"
                    dataset = postingList
                Case "Area"
                    dataset = postingList.Where(Function(s) s.SchoolArea = searchValue1).ToList
                Case "School"
                    dataset = postingList.Where(Function(s) s.SchoolCode = searchValue1).ToList
                    'dataset = From s In postingList
                    '          Where (s.SchoolCode = searchValue1)
                    '          Select s
                Case "Panel"
                    dataset = postingList.Where(Function(s) Left(s.SchoolCode, 2) = Me.ddlSearchby.SelectedValue.ToString()).ToList 's.GenName.Contains(txtserach.Text))
                Case "Level"
                    dataset = postingList.Where(Function(s) s.PositionLevel = getSeracherValue()).ToList
                Case "PostingState"
                    dataset = postingList.Where(Function(s) s.PostingState = getSeracherValue()).ToList
                Case "PostingCycle"
                    dataset = postingList.Where(Function(s) s.PostingCycle = getSeracherValue()).ToList
                Case "PositionStatus"
                    dataset = postingList.Where(Function(s) s.PositionState = getSeracherValue()).ToList
                Case "PublishDate"
                    dataset = postingList.Where(Function(s) s.DatePublish >= searchValue1 And s.DatePublish <= searchValue2).ToList
                Case "DeadlineDate"
                    dataset = postingList.Where(Function(s) s.DateApplyClose >= searchValue1 And s.DateApplyClose <= searchValue2).ToList
                Case "OpenDate"
                    dataset = postingList.Where(Function(s) s.DateApplyOpen >= searchValue1 And s.DateApplyOpen <= searchValue2).ToList
                Case "CloseDate"
                    dataset = postingList.Where(Function(s) s.DateApplyClose >= searchValue1 And s.DateApplyClose <= searchValue2).ToList
                Case "Title"
                    dataset = postingList.Where(Function(s) s.PositionTitle.Contains(searchValue1)).ToList
                Case "PostingNum"

                    dataset = postingList.Where(Function(s) s.PostingNumber = searchValue1).ToList

                Case Else
                    dataset = postingList

            End Select
            Return dataset
        Catch ex As Exception
            Dim em As String = ex.Message
            Return postingList
        End Try

    End Function
    Private Function allDataSet() As List(Of PositionListPublish)
        Dim parameters = CommonParameter.GetParameters("Page", User.Identity.Name, WorkingProfile.SchoolYear, WorkingProfile.ApplicationType, "00", "Open", "All", "", "")
        Dim allList = PublishPositionExe.Positions(parameters)  ' CommonExcute(Of PositionListPublish).GeneralList(SP, parameters) '  PositionListPublish).GeneralList(SP, parameters)
        Return allList
    End Function
    Private Function getDataSourceNew() As List(Of PositionListPublish) ' 
        Dim searchby As String = Me.ddlSearchby.SelectedValue
        Dim searchValue1 As String = getSeracherValue() 'Me.ddlSearchbyValue.SelectedValue
        Dim searchValue2 As String = getSeracherDate2()
        WorkingProfile.SearchBy = searchby
        WorkingProfile.SearchByValue = searchValue1
        WorkingProfile.SearchByValue2 = searchValue2

        Dim parameters = CommonParameter.GetParameters("Page", User.Identity.Name, Me.ddlSchoolYear.SelectedValue, Me.ddlappType.SelectedValue, "00", Me.ddlOpenClose.SelectedValue, searchby, searchValue1, searchValue2)
        Dim sList = PublishPositionExe.Positions(parameters)  ' CommonExcute(Of PositionListPublish).GeneralList(SP, parameters) '  PositionListPublish).GeneralList(SP, parameters)

        If User.Identity.Name = "mif" Then
            Me.lblSuperArea.ToolTip = PublishPositionExe.SpName("Positions")
            Me.btnNewOpen.ToolTip = PublishPositionExe.SpName("New")
        End If
        Return sList
    End Function

    Private Function getDataSource() As List(Of PositionListPublish) ' 
        Dim searchby As String = Me.ddlSearchby.SelectedValue
        Dim searchValue1 As String = getSeracherValue() 'Me.ddlSearchbyValue.SelectedValue
        Dim searchValue2 As String = getSeracherDate2()
        WorkingProfile.SearchBy = searchby
        WorkingProfile.SearchByValue = searchValue1
        WorkingProfile.SearchByValue2 = searchValue2


        '  Dim parameters As New ParametersForPositionList()
        'With parameters
        '    .Operate = "Page"
        '    .UserID = User.Identity.Name
        '    .SchoolYear = Me.ddlSchoolYear.SelectedValue
        '    .PositionType = Me.ddlappType.SelectedValue
        '    .Panel = Me.ddlPanel.SelectedValue
        '    .Status = Me.ddlOpenClose.SelectedValue
        '    .SearchBy = searchby
        '    .SearchValue1 = searchValue1
        '    .SearchValue2 = searchValue2
        'End With

        '  Dim postingpositions As New List(Of PositionListPosting)
        Dim parameters = CommonParameter.GetParameters("Page", User.Identity.Name, Me.ddlSchoolYear.SelectedValue, Me.ddlappType.SelectedValue, "00", Me.ddlOpenClose.SelectedValue, searchby, searchValue1, searchValue2)

        '   Dim SP As String = CommonListExecute(Of PositionListPublish).ObjSP("PositionListPublish")
        Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "Positions") '  CommonExcute.SPNameAndParameters(SPFile, cPage, "Position")
        Dim sList = CommonExcute(Of PositionListPublish).GeneralList(SP, parameters) '  PositionListPublish).GeneralList(SP, parameters)

        If User.Identity.Name = "mif" Then
            Me.lblSuperArea.ToolTip = SP
        End If

        ' Dim newlist = PublishPositionExe.Positions(parameters)
        '  Dim sList = CommonListExecute(Of PositionListPublish).GeneralPositions(SP, parameters) '  PostingPublishExe.Positions(parameters) ' .PostingPositions(parameters)
        '  Dim sList = CommonListExecute.PublishPositions(parameters) '  PostingPublishExe.Positions(parameters) ' .PostingPositions(parameters)
        ' "dbo.tcdsb_LTO_PagePublish_Positions @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2"
        Return sList
    End Function
    Private Function getSeracherValue() As String
        Dim searchby As String = Me.ddlSearchby.SelectedValue
        Dim searchbyValue As String = ""
        Select Case searchby
            Case "Area", "School", "Panel", "Level", "PostingState", "PendingConfirm", "PostingCycle", "PositionStatus"
                searchbyValue = Me.ddlSearchbyValue.SelectedValue
            Case "PublishDate", "PositionStartDate", "PositionEndDate", "DeadlineDate", "OpenDate", "CloseDate"
                searchbyValue = DateFC.YMDStr(Me.datepicker.Value)
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
                searchbyValue = DateFC.YMDStr(Me.datepicker2.Value)
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

    'Protected Sub ddlPanel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPanel.SelectedIndexChanged
    '    WorkingProfile.Panel = Me.ddlPanel.SelectedValue
    '    BindGridData(True)
    'End Sub


    Protected Sub ddlSearchbyValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSearchbyValue.SelectedIndexChanged
        Me.txtSearchBox.Text = ""
        If ddlSearchby.SelectedValue = "School" Then
            WorkingProfile.SchoolCode = Me.ddlSearchbyValue.SelectedValue
            Me.hfSchoolCode.Value = WorkingProfile.SchoolCode
        End If

        '   Me.searchdate.Value = ""
        '    BindGridData(True)
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        BindGridData(True)
    End Sub
    Protected Sub ddlOpenClose_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlOpenClose.SelectedIndexChanged
        BindGridData(True)
    End Sub


    Protected Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        ' ExportToExcel()
    End Sub
    'Private Function getDataForExcel() As DataTable
    '    Dim searchby As String = Me.ddlSearchby.SelectedValue
    '    Dim searchValue1 As String = getSeracherValue() 'Me.ddlSearchbyValue.SelectedValue
    '    Dim searchValue2 As String = getSeracherDate2()
    '    WorkingProfile.SearchBy = searchby
    '    WorkingProfile.SearchByValue = searchValue1
    '    WorkingProfile.SearchByValue2 = searchValue2

    '    'Dim parameters As New ParametersForPositionList()
    '    'With parameters
    '    '    .Operate = "EXCEL"
    '    '    .UserID = User.Identity.Name
    '    '    .SchoolYear = Me.ddlSchoolYear.SelectedValue
    '    '    .PositionType = Me.ddlappType.SelectedValue
    '    '    .Panel = Me.ddlPanel.SelectedValue
    '    '    .Status = Me.ddlOpenClose.SelectedValue
    '    '    .SearchBy = searchby
    '    '    .SearchValue1 = searchValue1
    '    '    .SearchValue2 = searchValue2
    '    'End With

    '    '  Dim postingpositions As New List(Of PositionPosting)
    '    Dim parameters = CommonParameter.GetParameters("EXCEL", User.Identity.Name, Me.ddlSchoolYear.SelectedValue, Me.ddlappType.SelectedValue, "00", Me.ddlOpenClose.SelectedValue, searchby, searchValue1, searchValue2)

    '    Dim postingpositions = CommonListExecute.PublishPositions(parameters) '  PostingPublishExe.Positions(parameters)

    '    Dim DT As DataTable = DataTools.ListToDataTable(postingpositions)
    '    Return DT
    'End Function

    'Private Sub ExportToExcel()
    '    Dim file_name As String = Me.ddlSchoolYear.SelectedValue + " " + Me.ddlSearchby.SelectedItem.Text + " Posted Position List.xlsx"
    '    Dim strFileName As String = Server.MapPath("..") + "\Template\" + file_name
    '    If System.IO.File.Exists(strFileName) Then
    '        System.IO.File.Delete(strFileName)
    '        'If (MessageBox.Show("Do you want to replace from the existing file?", "Export to Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes) Then
    '        '    System.IO.File.Delete(strFileName)
    '        'Else
    '        '    Return
    '        'End If

    '    End If
    '    Dim _excel As New Excel.Application
    '    Dim wBook As Excel.Workbook
    '    Dim wSheet As Excel.Worksheet


    '    wBook = _excel.Workbooks.Add()
    '    wSheet = wBook.ActiveSheet()

    '    Try
    '        Dim dt As System.Data.DataTable = getDataForExcel()
    '        Dim dc As System.Data.DataColumn
    '        Dim dr As System.Data.DataRow
    '        Dim colIndex As Integer = 0
    '        Dim rowIndex As Integer = 0
    '        'If CheckBox1.Checked Then
    '        For Each dc In dt.Columns
    '            colIndex = colIndex + 1
    '            wSheet.Cells(2, colIndex) = dc.ColumnName
    '        Next
    '        'End If
    '        For Each dr In dt.Rows
    '            rowIndex = rowIndex + 1
    '            colIndex = 0
    '            For Each dc In dt.Columns
    '                colIndex = colIndex + 1
    '                wSheet.Cells(rowIndex + 2, colIndex) = dr(dc.ColumnName)
    '            Next
    '        Next
    '        wSheet.Columns.AutoFit()
    '        wBook.SaveAs(strFileName)

    '        ReleaseObject(wSheet)
    '        wBook.Close(False)
    '        ReleaseObject(wBook)
    '        _excel.Quit()
    '        ReleaseObject(_excel)


    '        GC.Collect()



    '        ' MessageBox.Show("File Export Successfully!")
    '    Catch ex As Exception
    '        Dim ss = ex.Message
    '    End Try

    'End Sub
    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
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

