'Imports System.Data
'Imports System.Data.SqlClient
Imports AppOperate
Imports ClassLibrary
'Imports TCDSB.Student
Partial Class ApplicantList2
    Inherits System.Web.UI.Page
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
            Page.Response.Expires = 0
            Session("currentDataSet") = Nothing
            Dim _sID As String = Page.Request.QueryString("sID")
            Dim _IncludeAll As String = Page.Request.QueryString("includAll")
            '  If _IncludeAll = "1" Then Me.checkboxAll.Checked = True
            Me.HiddenFieldUserRole.Value = WorkingProfile.UserRole
            BindGridData(True)

        End If

    End Sub


    Private Sub BindGridData(ByVal goDatabase As Boolean)
        Try
            '  Dim ds As DataSet
            '  ds = GetDataset(goDatabase)
            Me.GridView1.DataSource = getDataSource() ' ds.Tables(0)
            GridView1.DataBind()

        Catch ex As Exception
            ShowMessage.Exception(ex, Me.Page, "Bind data action")
        End Try
    End Sub
    Private Function getDataSource() As List(Of ApplicantListSelect)

        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        Dim positionId As String = Page.Request.QueryString("PositionID")
        Dim operate = IIf(Me.checkboxAll.Checked, "IncludeAll", "SelectedInterview")
        Me.HiddenFieldPositionID.Value = positionId
        Me.HiddenFieldSchoolYear.Value = schoolyear

        Me.HiddenFieldHired.Value = Page.Request.QueryString("PostedState")


        Dim parameter As New ParametersForOperation()
        With parameter
            .Operate = operate
            .SchoolYear = schoolyear
            .PositionID = positionId
            .UserID = User.Identity.Name
        End With

        Me.labelSelected.Text = SelectCandidateExe.SelectedForInterview(parameter) ' CommonOperationExcute.SelectedInterviewCandidate(parameter, "SelectedInterview")

        Dim parameters = CommonParameter.GetParameters3(operate, schoolyear, positionId)
        If User.Identity.Name = "mif" Then
            ' Dim SP As String = CommonListExecute(Of ApplicantListSelect).ObjSP("ApplicantListSelect")
            Me.labelSelected.ToolTip = SelectCandidateExe.SPName("Applicants")
        End If

        Dim sList = SelectCandidateExe.Applicants(parameter) ' CommonListExecute.ApplicantListSelect(parameters) '  PostingPublishExe.Positions(parameters) ' .PostingPositions(parameters)
        Return sList
    End Function

    Protected Sub checkboxAll_CheckedChanged(sender As Object, e As EventArgs) Handles checkboxAll.CheckedChanged
        BindGridData(True)
    End Sub



End Class
