'Imports System.Data
'Imports System.Data.SqlClient
Imports System.IO

'Imports Microsoft.ApplicationInsights.Telemetry.Services
'Imports System.Threading.Tasks
'Imports System.Net.Http

Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services
Imports ClassLibrary
Imports AppOperate
'Imports TCDSB.Student


Partial Class RequestPositionDetails_MultipleSchool
    Inherits System.Web.UI.Page
     Dim SPFile As String = SPSource.SPFile() '  WebConfigValue.SPFile() 
    Dim cPage As String = "Publish"
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
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Page.Response.Expires = 0
            Dim _title As String = Page.Request.QueryString("pTitle")
            Dim _schoolcode As String = Page.Request.QueryString("sCode")
            Dim _PositionID As String = Page.Request.QueryString("IDS")
            Dim _source As String = Page.Request.QueryString("sourceID")
            Dim _IDS As String = Page.Request.QueryString("IDS")

            Dim parameter As New List2Item()
            With parameter
                .Operate = "SchoolistBrief"
                .Para0 = WorkingProfile.UserID
                .Para1 = WorkingProfile.UserRole
                .Para2 = WorkingProfile.ApplicationType
                .Para3 = WorkingProfile.SchoolYear
            End With



            AssemblingList.SetLists("", Me.ddlSchool1, "SchoolistBrief", parameter)
            AssemblingList.SetLists("", Me.ddlSchool2, "SchoolistBrief", parameter)
            AssemblingList.SetLists("", Me.ddlSchool3, "SchoolistBrief", parameter)
            AssemblingList.SetLists("", Me.ddlSchool4, "SchoolistBrief", parameter)
            AssemblingList.SetLists("", Me.ddlSchool5, "SchoolistBrief", parameter)

            BindSelectedPositionData(_PositionID, _title, _schoolcode)
        End If
    End Sub
    Protected Sub BindSelectedPositionData(ByVal positionID As String, ByVal pTitle As String, ByVal schoolcode As String)
        Try
            Dim userid As String = HttpContext.Current.User.Identity.Name

            Dim parameter = New MultipleSchool
            With parameter
                .PositionID = positionID
                .SchoolYear = WorkingProfile.SchoolYear
            End With


            If User.Identity.Name = "mif" Then
                Dim SP As String = MultipleSchoolsExe.SPName("Update") ' CommonExcute.SPNameAndParameters(SPFile, cPage, "MultipleSchool") '  CommonExcute.SPNameAndParameters(SPFile, cPage, "Position")
                Me.btnSave.ToolTip = SP
            End If

            ' Dim position = CommonListExecute(Of PositionPublish).GeneralPositions(SP, parameter)(0) '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)
            '  Dim schools = CommonExcute(Of MultipleSchool).GeneralList(SP, parameter)  '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)
            Dim schools = MultipleSchoolsExe.MultipleSchools(parameter) ' CommonExcute(Of MultipleSchool).GeneralList(SP, parameter)  '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)

            If schools.Count = 0 Then
                AssemblingList.SetValue(Me.ddlSchool1, schoolcode)

                Me.txtAssignment1.Text = pTitle
                Me.txtFTE1.Text = 0.5
            Else
                Dim x As Integer = 1
                For Each school In schools
                    Dim myID As HiddenField = FindControl("hfID" + x.ToString())
                    Dim mySchool As DropDownList = FindControl("ddlSchool" + x.ToString())
                    Dim myTitle As TextBox = FindControl("txtAssignment" + x.ToString())
                    Dim myFTE As TextBox = FindControl("txtFTE" + x.ToString())
                    myID.Value = school.IDs
                    AssemblingList.SetValue(mySchool, school.SchoolCode)

                    myTitle.Text = school.PositionTitle
                    myFTE.Text = school.FTE
                    x += 1
                Next

            End If

        Catch ex As Exception
            Dim mes As String = ex.Message
        End Try

    End Sub

    Private Sub CreatSaveMessage(ByVal strMessage As String, ByVal action As String)
        Try

            Dim strScript As String = "CallBackReloadParent(" + """" + action + """,""" + strMessage + """);"
            '  ***  No Ajax
            ClientScript.RegisterStartupScript(GetType(String), "actionMessage", strScript, True)
            '  *** AJAX Save Message
            ' ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType, "save_script", strScript.ToString(), True)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ddlSchool1.SelectedValue = "0000" Then SaveDataToDataBase(Me.hfID1.Value, Me.ddlSchool1.SelectedValue, Me.txtAssignment1.Text, Me.txtFTE1.Text)
        If Not ddlSchool2.SelectedValue = "0000" Then SaveDataToDataBase(Me.hfID2.Value, Me.ddlSchool2.SelectedValue, Me.txtAssignment2.Text, Me.txtFTE2.Text)
        If Not ddlSchool3.SelectedValue = "0000" Then SaveDataToDataBase(Me.hfID3.Value, Me.ddlSchool3.SelectedValue, Me.txtAssignment3.Text, Me.txtFTE3.Text)
        If Not ddlSchool4.SelectedValue = "0000" Then SaveDataToDataBase(Me.hfID4.Value, Me.ddlSchool4.SelectedValue, Me.txtAssignment4.Text, Me.txtFTE4.Text)
        If Not ddlSchool5.SelectedValue = "0000" Then SaveDataToDataBase(Me.hfID5.Value, Me.ddlSchool5.SelectedValue, Me.txtAssignment5.Text, Me.txtFTE5.Text)

    End Sub
    Private Sub SaveDataToDataBase(ByVal IDs As String, ByVal pSchool As String, ByVal pTitle As String, ByVal pFTE As String)
        Dim _PositionID As String = Page.Request.QueryString("IDS") ' Page.Request.QueryString("pID")


        Dim parameter = New MultipleSchool
        With parameter
            .PositionID = Page.Request.QueryString("IDS")
            .SchoolYear = WorkingProfile.SchoolYear
            .SchoolCode = pSchool
            .IDs = IDs
            .PositionTitle = pTitle
            .FTE = pFTE
            .Description = ""
        End With



        ' Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "MultipleSchool") '  CommonExcute.SPNameAndParameters(SPFile, cPage, "Position")

        ' Dim position = CommonListExecute(Of PositionPublish).GeneralPositions(SP, parameter)(0) '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)
        Dim result = MultipleSchoolsExe.Update(parameter) '  CommonExcute(Of MultipleSchool).GeneralValue(SP, parameter)  '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)

    End Sub
End Class
