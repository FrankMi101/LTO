'Imports System.Data
'Imports System.Data.SqlClient
'Imports TCDSB.Student
Imports AppOperate
Imports ClassLibrary

Partial Class ApplicantComments
    Inherits System.Web.UI.Page
    Dim DataAccesssFile As String = "" ' Server.MapPath("..\Content\DataAccess.json")
     Dim SPFile As String = SPSource.SPFile() '  WebConfigValue.SPFile()  'Server.MapPath("..\Content\DataAccessSP.json")
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
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try


                Me.Page.Response.Expires = 0
                Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
                Dim cpnum As String = Page.Request.QueryString("ApplyUserID")
                Dim positionID As String = Page.Request.QueryString("PositionID")
                WorkingProfile.UserCPNum = cpnum

                Dim action As String = "ApplicantComment"

                Dim parameter = New ParametersForOperation
                With parameter
                    .CPNum = Page.Request.QueryString("ApplyUserID")
                    .SchoolYear = Page.Request.QueryString("SchoolYear")
                    .PositionID = Page.Request.QueryString("PositionID")
                    .UserID = User.Identity.Name
                    .Operate = action
                End With

                Dim SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action)


                Me.TextComments.InnerHtml = CommonExcute(Of ParametersForOperation).GeneralValue(SP, parameter)


            Catch ex As Exception

            End Try


        End If

    End Sub



End Class
 