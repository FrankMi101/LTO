'Imports System.Data
'Imports System.Data.SqlClient

'Imports TCDSB.Student
Imports AppOperate
Imports ClassLibrary
Partial Class PostingSummaryApplyList
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Session("currentDataSet") = Nothing
            Dim _sID As String = Page.Request.QueryString("sID")
            If _sID <> Nothing Then Session("SchoolCode") = _sID
            Me.HiddenFieldUserRole.Value = WorkingProfile.UserRole

            Dim roleShow As String = WorkingProfile.UserRole
            '  roleShow = roleShow.Replace("Director", "Associate Director")


            Me.SuperAreaRow.Visible = False

            BindDDLList()
            ' Me.WebDataGrid1.Behaviors.EditingCore.BatchUpdating = True
            BindGridData(True, WorkingProfile.UserCPNum)
        End If

    End Sub
    Private Sub BindDDLList()
        Dim _UserID As String = HttpContext.Current.User.Identity.Name
        Dim _Role As String = WorkingProfile.UserRole
        Dim _SchoolYear As String = WorkingProfile.SchoolYear

        Dim _schoolcode As String = WorkingProfile.SchoolCode

        Try

            AssemblingList.SetValue(Me.ddlappType, WorkingProfile.ApplicationType)

            If WorkingProfile.LoginRole = "Admin" Then

                Dim parameter As New List2Item()
                With parameter
                    .Operate = "Applicant"
                    .Para0 = WorkingProfile.SchoolYear
                    .Para1 = ""
                    .Para2 = WorkingProfile.UserRole
                    .Para3 = "%"
                End With
                ' AssembleListItem.SetObjLists(Me.combobox, parameter)

                AssemblingList.SetLists("", Me.ddlSchoolYear, "SchoolYearbySchool", parameter, _SchoolYear)
                Me.ddlappType.Visible = True
                Me.ApplicantForDeveloper.Visible = True
                Me.ddlApplicant.Visible = True
                AssemblingList.SetLists("", Me.ddlApplicant, "Applicant", parameter)

            Else
                Me.btApplicant.Visible = False
                Me.ddlappType.Visible = False
                Me.ApplicantForDeveloper.Visible = False
            End If



        Catch ex As Exception

        End Try

    End Sub
    Private Function getDataSource() As List(Of PositionListApplied)

        Dim parameters As ParametersForPositionList = New ParametersForPositionList() ' =  CommonParameter.GetParameters("Page", User.Identity.Name, Me.ddlSchoolYear.SelectedValue, Me.ddlappType.SelectedValue, "00", Me.ddlOpenClose.SelectedValue, searchby, searchValue1, searchValue2)
        With parameters
            .CPNum = ""
            .SchoolYear = ""
            .PositionType = ""
            .UserID = User.Identity.Name
        End With
        '   Dim SP As String = CommonListExecute(Of PositionListPublish).ObjSP("PositionListPublish")
        ' Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "AppliedHistory") '  CommonExcute.SPNameAndParameters(SPFile, cPage, "Position")

        If User.Identity.Name = "mif" Then
            Me.ddlSchoolYear.ToolTip = PostingSummaryExe.SPName("ApplicantApplied")
        End If
        Dim sList = PostingSummaryExe.AppliedPositions(parameters) '  CommonExcute(Of PositionListApplied).GeneralList(SP, parameters)
        Return sList
    End Function
    Private Sub BindGridData(ByVal goDatabase As Boolean, ByVal CPNum As String)
        Try

            Me.GridView1.DataSource = getDataSource()
            Me.GridView1.DataBind()
            BindApplicantOCT(CPNum)

        Catch ex As Exception
            '  CommonTCDSB.ShowMsg.Exception(ex, Me.Page, "Bind data action")
        End Try
    End Sub
    Private Sub BindApplicantOCT(ByVal CPNum As String)
        Dim paramaters = CommonParameter.ParametersForProfile("", User.Identity.Name, WorkingProfile.SchoolYear, "Qualification", CPNum)
        ' Dim SP = CommonExcute.SPNameAndParameters(SPFile, "General", "Profile")
        ' Dim result = CommonExcute(Of Profile).GeneralValue(SP, paramaters)
        Me.TextTeacherOCT.Text = CommonExcute(Of Profile).ProfileValue(paramaters)
    End Sub



    Protected Sub ddlappType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlappType.SelectedIndexChanged
        WorkingProfile.ApplicationType = Me.ddlappType.SelectedValue
        BindGridData(True, ddlApplicant.SelectedValue)
    End Sub

    Private Sub ddlApplicant_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlApplicant.SelectedIndexChanged
        BindGridData(True, ddlApplicant.SelectedValue)
    End Sub
    Protected Sub btApplicant_Click(sender As Object, e As EventArgs) Handles btApplicant.Click
        Dim objQualification As String = ""
        Dim searchName As String = Me.txtSearchTeacher.Text
        Dim index As Integer = objQualification.IndexOf(";")
        Dim goQualificartion As String = ""
        If index > 0 Then
            goQualificartion = Replace(Left(objQualification, index), """", "")
        End If
        ' SetupList.ListDDL(Me.ddlApplicant, "Applicant", WorkingProfile.SchoolYear, goQualificartion, WorkingProfile.UserRole, searchName)
        Dim parameter As New List2Item()
        With parameter
            .Operate = "Applicant"
            .Para0 = WorkingProfile.SchoolYear
            .Para1 = ""
            .Para2 = WorkingProfile.UserRole
            .Para3 = searchName
        End With
        AssemblingList.SetLists("", Me.ddlApplicant, "Applicant", Parameter)
    End Sub
End Class

