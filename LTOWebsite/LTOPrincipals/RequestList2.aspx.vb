'Imports System.Data
'Imports System.Data.SqlClient
Imports AppOperate
Imports ClassLibrary
'Imports TCDSB.Student

Partial Class RequestList2
    Inherits System.Web.UI.Page
    'Private Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
    '    If Not Session("mytheme") Is Nothing Then
    '        Me.Theme = Session("mytheme")

    '    End If
    'End Sub
    '' ### setup Page StylesheetTheme
    'Public Overrides Property StyleSheetTheme() As String
    '    Get
    '        Return Session("mytheme")
    '    End Get
    '    Set(ByVal value As String)
    '    End Set
    'End Property
    Dim cPage As String = "Request"
    Dim SPFile As String = SPSource.SPFile() '  WebConfigValue.SPFile() 
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then

            Session("currentDataSet") = Nothing
            Dim _sID As String = Page.Request.QueryString("sID")
            If _sID <> Nothing Then Session("SchoolCode") = _sID

            Dim roleShow As String = WorkingProfile.UserRole
            hfUserID.Value = HttpContext.Current.User.Identity.Name
            WorkingProfile.ApplicationType = "LTO"
            If User.Identity.Name = "mif" Then
                Me.ddlappType.Enabled = True
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
        If WorkingProfile.SearchBy = "School" Then
            WorkingProfile.SchoolCode = WorkingProfile.SearchByValue
        End If
        Dim _Schoolcode As String = WorkingProfile.SchoolCode
        Try

            Dim parameter As New List2Item()
            With parameter
                .Operate = "SchoolYearbySchool"
                .Para0 = _Schoolcode
                .Para1 = WorkingProfile.ApplicationType
            End With
            AssemblingList.SetLists("", Me.ddlSchoolYear, "SchoolYearbySchool", parameter, WorkingProfile.SchoolYear)
            parameter.Operate = "Schoolist"
            parameter.Para0 = _UserID
            parameter.Para1 = _Role
            parameter.Para2 = _Schoolcode
            parameter.Para3 = WorkingProfile.SchoolYear

            AssembleListItem.SetLists2(ddlschoolcode, Me.ddlSchool, parameter, _Schoolcode)

            'If WorkingProfile.UserRole = "Admin" Or WorkingProfile.UserRole = "HRStaff" Then
            '    Me.ddlSchool.Enabled = True
            '    Me.ddlschoolcode.Enabled = True

            'Else
            '    Me.ddlSchool.Enabled = False
            '    Me.ddlschoolcode.Enabled = False
            'End If
            If Me.ddlSchool.Items.Count > 1 Then
                Me.ddlSchool.Enabled = True
                Me.ddlschoolcode.Enabled = True
            End If
            setAppType(_Schoolcode)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub setAppType(ByVal _schoolCode As String)
        Dim _Role As String = WorkingProfile.UserRole
        Dim _SchoolYear As String = WorkingProfile.SchoolYear
        Dim parameter As New List2Item()
        With parameter
            .Operate = "RequestAppType"
            .Para0 = HttpContext.Current.User.Identity.Name
            .Para1 = _Role
            .Para2 = _schoolCode
            .Para3 = WorkingProfile.SchoolYear
        End With
        AssemblingList.SetLists("", ddlappType, "RequestAppType", parameter)
        If Mid(_schoolCode, 1, 2) = "05" Then
            AssembleListItem.SetValue(ddlappType, WorkingProfile.ApplicationType)
        Else
            AssembleListItem.SetValue(ddlappType, "TAP")
        End If
    End Sub
    Private Sub BindGridData(ByVal goDatabase As Boolean)
        Try
            Me.GridView1.DataSource = getDataSource()
            Me.GridView1.DataBind()


        Catch ex As Exception
            ShowMessage.Exception(ex, Me.Page, "Bind data action")
        End Try
    End Sub
    Private Function getDataSource() As List(Of PositionListRequesting)

        Dim parameters = CommonParameter.GetParameters("Request", User.Identity.Name, Me.ddlSchoolYear.SelectedValue, Me.ddlschoolcode.SelectedValue)
        If User.Identity.Name = "mif" Then
            Me.lblSchoolyear.ToolTip = RequestPostingExe.SPName("Positions")
        End If

        '  Dim sList = CommonListExecute.RequestPositions(parameters) '  PostingPublishExe.Positions(parameters) ' .PostingPositions(parameters)
        ' Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "Positions") '  CommonListExecute(Of PositionListRequesting).ObjSP("PositionListRequesting")
        'Dim sList = CommonExcute(Of PositionListRequesting).GeneralList(SP, parameters) '  CommonListExecute(Of PositionListRequesting).GeneralPositions(parameters)
        'Return sList

        Return RequestPostingExe.Positions(parameters)
    End Function


    Protected Sub ddlSchool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSchool.SelectedIndexChanged
        AssembleListItem.SetValue(Me.ddlschoolcode, Me.ddlSchool.SelectedValue)
        ChangeSchool()
    End Sub

    Protected Sub ddlschoolcode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlschoolcode.SelectedIndexChanged
        AssembleListItem.SetValue(Me.ddlSchool, Me.ddlschoolcode.SelectedValue)
        ChangeSchool()
    End Sub
    Private Sub ChangeSchool()
        WorkingProfile.SchoolCode = Me.ddlschoolcode.SelectedValue
        WorkingProfile.SearchByValue = Me.ddlschoolcode.SelectedValue
        WorkingProfile.SchoolName = Me.ddlSchool.SelectedItem.Text
        setAppType(WorkingProfile.SchoolCode)
        BindGridData(True)

    End Sub

    Protected Sub ddlSchoolYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSchoolYear.SelectedIndexChanged
        WorkingProfile.SchoolYear = Me.ddlSchoolYear.SelectedValue
        BindGridData(True)
    End Sub

    Private Sub ddlappType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlappType.SelectedIndexChanged
        If ddlappType.SelectedValue = "TPA" Then
            WorkingProfile.ApplicationType = "LTO"
        Else
            WorkingProfile.ApplicationType = ddlappType.SelectedValue
        End If
    End Sub


    'Private Sub WebDataGrid12_InitializeRow(sender As Object, e As RowEventArgs) Handles WebDataGrid12.InitializeRow
    '    If Not e.Row.Items.FindItemByKey("PostingRequest").Value = WorkingProfile.SchoolCode Then
    '        e.Row.Attributes.Add("CssClass", "RowDisable")
    '    End If
    'End Sub

End Class

