'Imports System.Data
'Imports System.Data.SqlClient
Imports AppOperate
Imports ClassLibrary

Partial Class OpenPositionList2
    Inherits System.Web.UI.Page
    Dim cPage As String = "Interview"
    Dim SPFile As String = SPSource.SPFile() '  WebConfigValue.SPFile() 
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
            Dim _sID As String = Page.Request.QueryString("sID")
            If _sID <> Nothing Then Session("SchoolCode") = _sID
            Me.HiddenFieldUserRole.Value = WorkingProfile.UserRole

            Dim roleShow As String = WorkingProfile.UserRole
            HiddenFieldDevice.Value = Session("Device")

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
            AssemblingList.SetLists("", Me.ddlProgress, "InterviewProgress", parameter, WorkingProfile.SchoolYear)



            With parameter
                .Operate = "Schoolist"
                .Para0 = WorkingProfile.UserID
                .Para1 = WorkingProfile.UserRole
                .Para2 = WorkingProfile.ApplicationType
                .Para3 = WorkingProfile.SchoolYear
            End With
            ' AssembleListItem.SetLists2(ddlschoolcode, Me.ddlSchool, parameter, schoolcode)
            AssemblingList.SetListSchool(ddlschoolcode, Me.ddlSchool, "SchoolList", parameter, _Schoolcode)


            If WorkingProfile.UserRole = "Admin" Or WorkingProfile.UserRole = "HRStaff" Then
                Me.ddlSchool.Enabled = True
                Me.ddlschoolcode.Enabled = True
            Else
                Me.ddlSchool.Enabled = False
                Me.ddlschoolcode.Enabled = False
            End If

            If Me.ddlSchool.Items.Count > 1 Then
                Me.ddlSchool.Enabled = True
                Me.ddlschoolcode.Enabled = True
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub BindGridData(ByVal goDatabase As Boolean)
        Try
            Me.GridView1.DataSource = getDataSource()
            GridView1.DataBind()

        Catch ex As Exception
            ShowMessage.Exception(ex, Me.Page, "Bind data action")
        End Try
    End Sub
    Private Function getDataSource() As List(Of PositionListInterview)
        Dim schoolYear As String = Me.ddlSchoolYear.SelectedValue
        Dim schoolCode As String = ddlschoolcode.SelectedValue

        Dim parameters = CommonParameter.GetParametersSchool("OpenPosition", User.Identity.Name, Me.ddlSchoolYear.SelectedValue, Me.ddlschoolcode.SelectedValue, Me.ddlProgress.SelectedValue)
        ' Dim sList = CommonListExecute.SchoolOpenPositions(parameters) '  PostingPublishExe.Positions(parameters) ' .PostingPositions(parameters)
        ' Dim sList = CommonListExecute(Of PositionListInterview).GeneralPositions(parameters)

        '  Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "Positions") '  CommonListExecute(Of PositionListInterview).ObjSP("PositionListInterview")
        If User.Identity.Name = "mif" Then
            Me.lblSchoolyear.ToolTip = InterviewProcessExe.SpName("Positions")
        End If
        Dim sList = InterviewProcessExe.Positions(parameters) '  CommonExcute(Of PositionListInterview).GeneralList(SP, parameters) '  CommonListExecute.AllPositionList(Of PositionListInterview)(parameters)
        Return sList
    End Function


    Protected Sub ddlSchool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSchool.SelectedIndexChanged
        AssemblingList.SetValue(Me.ddlschoolcode, Me.ddlSchool.SelectedValue)
        schoolChange()
    End Sub

    Protected Sub ddlschoolcode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlschoolcode.SelectedIndexChanged
        AssemblingList.SetValue(Me.ddlSchool, Me.ddlschoolcode.SelectedValue)
        schoolChange()
    End Sub
    Private Sub schoolChange()
        WorkingProfile.SchoolCode = Me.ddlschoolcode.SelectedValue
        WorkingProfile.SchoolName = Me.ddlSchool.SelectedItem.Text
        BindGridData(True)

    End Sub
    Protected Sub ddlSchoolYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSchoolYear.SelectedIndexChanged
        WorkingProfile.SchoolYear = Me.ddlSchoolYear.SelectedValue
        BindGridData(True)
    End Sub

    Private Sub ddlProgress_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProgress.SelectedIndexChanged
        BindGridData(True)

    End Sub
End Class

