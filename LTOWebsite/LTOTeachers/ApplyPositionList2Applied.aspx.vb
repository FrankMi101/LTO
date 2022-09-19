'Imports System.Data
'Imports System.Data.SqlClient
Imports AppOperate
Imports ClassLibrary
Partial Class ApplyPositionList2Applied
    Inherits System.Web.UI.Page
    Dim SPFile As String = SPSource.SPFile() '  WebConfigValue.SPFile() 
    Dim cPage As String = "Applying"
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
            Session("ParentPage") = "AppliedPositionList"
            Session("currentDataSet") = Nothing
            Dim _sID As String = Page.Request.QueryString("sID")
            If _sID <> Nothing Then Session("SchoolCode") = _sID
            ' Me.HiddenFieldUserRole.Value = WorkingProfile.UserRole

            Dim roleShow As String = WorkingProfile.UserRole
            '  roleShow = roleShow.Replace("Director", "Associate Director")
            If WorkingProfile.UserRole = "Roster" Then Me.aLTOTeacherList.Visible = False

            '  Me.SuperAreaRow.Visible = False

            If Not Page.Request.QueryString("CPNum") = Nothing Then
                WorkingProfile.UserCPNum = Page.Request.QueryString("CPNum")
            End If
            If User.Identity.Name = "mif" Then
                Me.ddlappType.Visible = True
            Else
                Me.ddlappType.Visible = False
            End If

            BindDDLList()
            BindGridData()
        End If

    End Sub
    Private Sub BindDDLList()

        Try
            AssemblingList.SetValue(Me.ddlappType, WorkingProfile.ApplicationType)

            If WorkingProfile.LoginRole = "Admin" Then
                Me.btApplicant.Visible = True
                Me.ddlappType.Visible = True
                Me.ApplicantForDeveloper.Visible = True
                Dim objQualification As String = Me.hfQualification.Value
                Dim parameter As New List2Item()
                With parameter
                    .Operate = "Applicant"
                    .Para0 = WorkingProfile.SchoolYear
                    .Para1 = ""
                    .Para2 = WorkingProfile.UserRole
                    .Para3 = "%"
                End With
                AssemblingList.SetListsObj("", Me.combobox, "Applicant", parameter)
                '  AssemblingList.SetObjValue(Me.combobox, WorkingProfile.UserCPNum)
                SearchForListValue1.Value = WorkingProfile.UserCPNum

            Else
                Me.btApplicant.Visible = False
                Me.ddlappType.Visible = False
                Me.ApplicantForDeveloper.Visible = False
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BindGridData()
        Try
            Me.GridView1.DataSource = getDataSource()
            GridView1.DataBind()

        Catch ex As Exception
            ShowMessage.Exception(ex, Me.Page, "Bind data action")
        End Try
    End Sub
    Private Function getDataSource() As List(Of PositionListApplied)
        Dim searchby As String = SearchType.Value
        Dim searchValue1 As String = SearchForListValue1.Value 'Me.ddlSearchbyValue.SelectedValue
        Dim CPNum As String = WorkingProfile.UserCPNum
        Dim parameters = CommonParameter.GetParameters("Get", User.Identity.Name, WorkingProfile.SchoolYear, Me.ddlappType.SelectedValue, searchby, searchValue1, WorkingProfile.UserRole, CPNum)
        Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "PositionsApplied")
        If User.Identity.Name = "mif" Then
            Me.btnSearch.ToolTip = SP
        End If
        Dim sList = ApplyProcessExe.AppliedPositions(parameters) ' CommonExcute(Of PositionListApplied).GeneralList(SP, parameters) '   CommonListExecute.AllPositionList(Of PositionListApplied)(parameters) '  PostingPublishExe.Positions(parameters) ' .PostingPositions(parameters)
        Me.hfCurrrentAvailableOpenPosition.Value = sList.Count
        Return sList
    End Function

    Protected Sub btnSearch_Click(sender As Object, e As System.EventArgs) Handles btnSearch.Click
        BindGridData()
    End Sub

    Protected Sub btApplicant_Click(sender As Object, e As EventArgs) Handles btApplicant.Click
        WorkingProfile.UserCPNum = HiddenFieldTeacherCPNum.Value
        BindGridData()

        '    setupApplicatList()
    End Sub

    Private Sub combobox_ServerChange(sender As Object, e As EventArgs) Handles combobox.ServerChange
        Dim index As Integer = combobox.SelectedIndex
        WorkingProfile.UserCPNum = combobox.Items(index).Value
        HiddenFieldTeacherCPNum.Value = combobox.Items(index).Value
    End Sub
End Class

