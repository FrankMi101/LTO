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

'Imports TCDSB.Student
Imports AppOperate
Imports ClassLibrary


Partial Class PostingSummaryDetailsSub
    Inherits System.Web.UI.Page
    Dim DataAccesssFile As String = "" ' Server.MapPath("..\Content\DataAccess.json")
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
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Page.Response.Expires = 0
            Dim pID As String = Page.Request.QueryString("pID")
            Dim yID As String = Page.Request.QueryString("yID")
            Dim cID As String = Page.Request.QueryString("cID")
            BindSelectedPositionData(pID, yID, cID)
        End If
    End Sub


    Protected Sub BindSelectedPositionData(ByVal positionID As String, ByVal schoolyear As String, ByVal cycle As String)
        Dim userid As String = HttpContext.Current.User.Identity.Name
        Try
            Dim parameter = CommonParameter.GetParameters(schoolyear, positionID)
            ' Dim SP As String = CommonExcute.SPNameAndParameters("Publish", "Position")
            ' Dim position =   CommonExcute(Of PositionPublish).GeneralList(SP, parameter)(0)
            Dim position = PublishPositionExe.Position(parameter)(0) ' CommonExcute(Of PositionPublish).GeneralList(SP, parameter)(0)

            ' Dim ds As DataSet = PositionDetails.PositionSummarybyID(userid, schoolyear, positionID, cycle)
            Me.textPostingNumber.Text = position.PostingNumber '  ds.Tables(0).Rows(0).Item(1)
            Me.TextLinkPositionID.Text = position.PositionID ' ds.Tables(0).Rows(0).Item(10)
            Me.dateStart.Value = position.StartDate ' ds.Tables(0).Rows(0).Item(5)
            Me.dateEnd.Value = position.EndDate '  ds.Tables(0).Rows(0).Item(6)
            Me.datePublish.Value = position.DatePublish ' ds.Tables(0).Rows(0).Item(3)
            Me.dateDeadline.Value = position.DateApplyClose '  ds.Tables(0).Rows(0).Item(4)
            Me.dateNotice.Value = position.DateNotice ' ds.Tables(0).Rows(0).Item(7)
            Me.TextPrincipal.Text = position.PrincipalName ' ds.Tables(0).Rows(0).Item(8)
            Me.TextPositionID.Text = position.PositionID
        Catch ex As Exception

        End Try
        Try
            Dim parameter = CommonParameter.GetParameters(schoolyear, positionID)
            'Dim SP As String = CommonExcute.SPNameAndParameters(cPage, "ApplicantApplied")

            'Dim applicants = CommonExcute(Of ApplicantList).GeneralList(SP, parameter)

            'Me.GridView_Applicant.DataSource = applicants
            'GridView_Applicant.DataBind()


            'SP = CommonExcute.SPNameAndParameters(cPage, "ApplicantInterview")
            'Dim interviews = CommonExcute(Of PositionInterview).GeneralList(SP, parameter)

            'Me.GridView_Interview.DataSource = interviews
            'GridView_Interview.DataBind()

            'SP = CommonExcute.SPNameAndParameters(cPage, "ApplicantEmail")
            'Dim emails = CommonExcute(Of PositionPublish).GeneralList(SP, parameter)

            'Me.GridView_eMail.DataSource = emails
            'GridView_eMail.DataBind()

            'Me.GridView_RecommendHire.DataSource = ds1.Tables(2)
            'GridView_RecommendHire.DataBind()

            Me.GridView_Applicant.DataSource = PostingSummaryExe.ApplicantApplied(parameter)
            GridView_Applicant.DataBind()

            Me.GridView_Interview.DataSource = PostingSummaryExe.ApplicantInterview(parameter)
            GridView_Interview.DataBind()

            Me.GridView_eMail.DataSource = PostingSummaryExe.ApplicantEmail(parameter)
            GridView_eMail.DataBind()

        Catch ex As Exception

        End Try




    End Sub


End Class
