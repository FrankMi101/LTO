'Imports System.Data
'Imports System.Data.SqlClient
Imports AppOperate
Imports ClassLibrary
Partial Class ApplyPositionList2
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
            Session("ParentPage") = "AvailablePositionList"
            Session("currentDataSet") = Nothing
            Dim _sID As String = Page.Request.QueryString("sID")
            If _sID <> Nothing Then Session("SchoolCode") = _sID
            ' Me.HiddenFieldUserRole.Value = WorkingProfile.UserRole



            Dim roleShow As String = WorkingProfile.UserRole
            '  roleShow = roleShow.Replace("Director", "Associate Director")
            If WorkingProfile.UserRole = "Roster" Then Me.aLTOTeacherList.Visible = False

            '  Me.SuperAreaRow.Visible = False
            Dim CPNum As String = Page.Request.QueryString("CPNum")
            If Not CPNum = Nothing Then
                WorkingProfile.UserCPNum = CPNum
            Else
                CPNum = WorkingProfile.UserCPNum
            End If
            hfAutoCompletSelectedID.Value = CPNum

            If User.Identity.Name = "mif" Then
                Me.ddlappType.Visible = True
            Else
                Me.ddlappType.Visible = False
            End If
            Dim parameter = New With {Key .SchoolYear = WorkingProfile.SchoolYear, .Type = "Status", .ID = CPNum}

            Dim OTStatus = ApplicantAttribute.OTType(parameter)

            Dim appType As String = WorkingProfile.ApplicationType
            If OTStatus = "Pending" And appType.ToUpper() = "LTO" Then
                Page.Response.Redirect("LoadingPending.aspx")
            Else
                BindDDLList()
                BindGridData()
            End If
        End If
    End Sub
    Private Sub BindDDLList()

        Try
            AssembleListItem.SetValue(Me.ddlappType, WorkingProfile.ApplicationType)

            If WorkingProfile.LoginRole = "Admin" Then
                btApplicant.Visible = True
                Me.ddlappType.Visible = True
                Me.ApplicantForDeveloper.Visible = True
                ' Me.ddlApplicant.Visible = True
                Dim objQualification As String = Me.hfQualification.Value
                Dim parameter As New List2Item()
                With parameter
                    .Operate = "Applicant"
                    .Para0 = WorkingProfile.SchoolYear
                    .Para1 = ""
                    .Para2 = WorkingProfile.UserRole
                    .Para3 = "%"
                End With
                AssembleListItem.SetObjLists(Me.combobox, parameter)
            Else
                Me.ddlappType.Visible = False

                btApplicant.Visible = False
                Me.ApplicantForDeveloper.Visible = False
                '  Me.ddlApplicant.Visible = False
            End If


            '   AssembleListItem.SetValue(Me.ddlApplicant, WorkingProfile.UserCPNum)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BindGridData()
        Try
            'If WorkingProfile.UserRole = "Pending" Then Page.Response.Redirect("LoadingPending.aspx")
            '  Dim ds As DataSet
            '  ds = GetDataset(goDatabase, CPNum)
            Me.GridView1.DataSource = getDataSource()  ' ds.Tables(0)
            GridView1.DataBind()

        Catch ex As Exception
            ShowMessage.Exception(ex, Me.Page, "Bind data action")
        End Try
    End Sub
    Private Function getDataSource() As List(Of PositionListApplying)
        Dim searchby As String = SearchType.Value
        Dim searchValue1 As String = SearchForListValue1.Value 'Me.ddlSearchbyValue.SelectedValue
        Dim CPNum As String = hfAutoCompletSelectedID.Value
        Dim parameters = CommonParameter.GetParameters("Get", User.Identity.Name, WorkingProfile.SchoolYear, Me.ddlappType.SelectedValue, searchby, searchValue1, WorkingProfile.UserRole, CPNum)

        '  Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "Positions")  '  CommonListExecute(Of PositionListApplying).ObjSP("PositionListApplying")

        Dim sList = ApplyProcessExe.Positions(parameters) '   CommonExcute(Of PositionListApplying).GeneralList(SP, parameters) '  CommonListExecute.AllPositionList(Of PositionListApplying)(parameters) '  PostingPublishExe.Positions(parameters) ' .PostingPositions(parameters)
        Me.hfCurrrentAvailableOpenPosition.Value = sList.Count


        If User.Identity.Name = "mif" Then
            Me.lblSchoolyear.ToolTip = ApplyProcessExe.SPName("Positions")
        End If

        Return sList
    End Function



    Protected Sub btnSearch_Click(sender As Object, e As System.EventArgs) Handles btnSearch.Click
        BindGridData()
    End Sub

    Protected Sub ddlappType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlappType.SelectedIndexChanged
        WorkingProfile.ApplicationType = Me.ddlappType.SelectedValue
        BindGridData()
    End Sub


    'Private Sub ddlApplicant_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlApplicant.SelectedIndexChanged
    '    WorkingProfile.UserCPNum = ddlApplicant.SelectedValue
    'End Sub
    Protected Sub btApplicant_Click(sender As Object, e As EventArgs) Handles btApplicant.Click
        WorkingProfile.UserCPNum = hfAutoCompletSelectedID.Value

        Dim parameter = New With {Key .SchoolYear = WorkingProfile.SchoolYear, .Type = "Status", .ID = hfAutoCompletSelectedID.Value}
        Dim OTStatus = ApplicantAttribute.OTType(parameter)
        Dim appType As String = WorkingProfile.ApplicationType
        If OTStatus = "Pending" And appType.ToUpper() = "LTO" Then
            Page.Response.Redirect("LoadingPending.aspx")
        Else
            BindGridData()
        End If

        '    setupApplicatList()
    End Sub

End Class

