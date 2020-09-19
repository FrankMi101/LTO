Imports System.Web

'Imports System.Data.SqlClient

'Imports System.Data
Imports AppOperate
Imports ClassLibrary

Partial Class Default_checkList
    Inherits System.Web.UI.Page
    Dim _UserID As String = HttpContext.Current.User.Identity.Name
    Protected WithEvents TD1 As System.Web.UI.HtmlControls.HtmlTableCell


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
                ddlSearchType.SelectedIndex = 0

            Catch ex As Exception


            End Try

        End If
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As System.EventArgs) Handles btnSearch.Click
        BindGridData(True, WorkingProfile.UserCPNum)
    End Sub
    Private Sub BindGridData(ByVal goDatabase As Boolean, ByVal CPNum As String)
        Try
            Dim searchType = ddlSearchType.SelectedValue
            Dim searchValue = txtSearchTeacher.Text
            Dim parameter As New Staff()
            With parameter
                .UserID = User.Identity.Name
                .SearchBy = searchType
                .SearchValue = searchValue
            End With
            ' Staff parameter = New Staff { SearchType = searchType, searchValue = searchValue };

            '  ManageNewStaffs.StaffsGridView(GridView1, parameter)
            '  ManageNewStaffs.StaffsGridView(GridView3, parameter, "TCDSB")
            '  ManageNewStaffs.StaffsGridView(GridView1, User.Identity.Name, searchType, searchValue)
            '  ManageNewStaffs.StaffsGridView(GridView3, User.Identity.Name, searchType, searchValue, "TCDSB")
            'Dim ds As DataSet
            'ds = GetDataset(goDatabase, CPNum)
            Me.GridView1.DataSource = LTOStaffManageExe.LTOStaffs(parameter)
            GridView1.DataBind()
            Me.GridView3.DataSource = LTOStaffManageExe.TCDSBStaffs(parameter)
            GridView3.DataBind()


        Catch ex As Exception
            ' CommonTCDSB.ShowMsg.Exception(ex, Me.Page, "Bind data action")
            Dim exm As String = ex.Message
        End Try
    End Sub
    'Private Function GetDataset(ByVal goDataBase As Boolean, ByVal CPNum As String) As DataSet
    '    Dim ds As DataSet
    '    Try
    '        If (Session("currentDataSet") Is Nothing) Or (goDataBase) Then

    '            Dim _signOff As String = ""


    '            Dim _Role As String = WorkingProfile.UserRole

    '            ds = New DataSet
    '            Dim _User As String = HttpContext.Current.User.Identity.Name
    '            '  Dim _CPNum As String = WorkingProfile.UserCPNum
    '            Dim _searchby As String = Me.ddlSearchType.SelectedValue
    '            Dim _searchText As String = Me.txtSearchTeacher.Text
    '            Dim _schoolyear As String = WorkingProfile.SchoolYear
    '            ds = Applicant.ListSearchByName(_searchby, _searchText)

    '            ds.Tables(0).TableName = "Positon List"
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

    Private Sub ddlappType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlappType.SelectedIndexChanged
        BindGridData(True, WorkingProfile.UserCPNum)
    End Sub
End Class

