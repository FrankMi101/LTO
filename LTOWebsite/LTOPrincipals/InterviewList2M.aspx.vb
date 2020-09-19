'Imports System.Data
'Imports System.Data.SqlClient
Imports AppOperate
Imports ClassLibrary
'Imports TCDSB.Student

Partial Class InterviewList2M
    Inherits System.Web.UI.Page

    Dim RequestSchool As String
    Dim myRequestPosting As New PositionRequesting
    Dim _schoolyear As String
    Dim _schoolcode As String
    Dim _PositionID As String
    Dim _appType As String
    Dim _status As String
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
            HiddenFieldDevice.Value = Session("Device")
            BindDDL()
            ' Me.WebDataGrid1.Behaviors.EditingCore.BatchUpdating = True
            BindGridData(True)
        End If

    End Sub
    Private Sub BindDDL()

        Dim _UserID As String = HttpContext.Current.User.Identity.Name
        Dim _Role As String = WorkingProfile.UserRole
        Dim _SchoolYear As String = WorkingProfile.SchoolYear
        Dim _Schoolcode As String = WorkingProfile.SchoolCode

        Dim parameter As New List2Item()
        With parameter
            .Operate = "InterviewProcess"
            .Para0 = _SchoolYear
            .Para1 = _appType
        End With
        AssembleListItem.SetLists(Me.cellEditInterviewOutCome, "InterviewProcess", parameter, _SchoolYear)


        CheckRequestSchool()
    End Sub
    Private Sub CheckRequestSchool()
        Dim parameter = CommonParameter.GetParameters(_schoolyear, _PositionID)
        Dim position As PositionInfo = CommonListExecute.PublishPositionInfo(parameter)(0) '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)

        RequestSchool = position.SchoolName  ' RequestingPostExe.RequestPositionAttribute(myRequestPosting, _PositionID)
        'Me.lblPostingNumber.Text = position.PostingNumber '  RequestingPostExe.RequestPositionAttribute(myRequestPosting, _PositionID)
        'Me.lblState.Text = position.PostingState '  RequestingPostExe.RequestPositionAttribute(myRequestPosting, _PositionID)
        'Me.lblQualification.Text = " Level: " + position.PositionLevel + " Qual: " + position.Qualification    '   'RequestingPostExe.RequestPositionAttribute(myRequestPosting, _PositionID)
        Me.lblPositionTitle.Text = position.PositionType + " Position: " + position.PositionTitle + " " + position.PostingCycle + " Desc: " + position.Description


        If Not Left(RequestSchool, 4) = _schoolcode Then
            Me.MessageToPrincipal.InnerText = "Only " + RequestSchool + "'s principal implements an interview process!"
            hfRequestSchool.Value = "Yes"
        Else
            hfRequestSchool.Value = "No"
        End If
    End Sub

    Private Sub BindGridData(ByVal goDatabase As Boolean)
        Try
            Me.GridView1.DataSource = getDataSource() ' ds.Tables(0)
            GridView1.DataBind()

        Catch ex As Exception
            ' CommonTCDSB.ShowMsg.Exception(ex, Me.Page, "Bind data action")
        End Try
    End Sub
    Private Function getDataSource() As List(Of CandidateList)

        Dim parameter = CommonParameter.GetParameters(_schoolyear, _PositionID)

        Dim sList = CommonListExecute.InterviewCandidates(parameter) '  PostingPublishExe.Positions(parameters) ' .PostingPositions(parameters)
        Return sList
    End Function
    'Private Sub setPositionTitle(ByVal schoolyear As String, ByVal schoolcode As String, ByVal positionID As String, ByVal _apptype As String)
    '    Try

    '        Dim userid As String = HttpContext.Current.User.Identity.Name
    '        Dim ds As DataSet = PositionDetails.RequestNewPositionbyID(userid, schoolyear, positionID)
    '        Dim pTitle As String = BasePage.getMyValue(ds.Tables(0).Rows(0).Item(2))
    '        Dim pID As String = CType(BasePage.getMyValue(ds.Tables(0).Rows(0).Item(1)), String)
    '        Dim pDes As String = BasePage.getMyValue(ds.Tables(0).Rows(0).Item(4))
    '        Dim pCycle As String = Left(BasePage.getMyValue(ds.Tables(0).Rows(0).Item(19)), 3) + " round Posting."
    '        Me.lblPositionTitle.Text = _apptype + " Position: " + pTitle + " (" + pID + " ). " + pCycle + " Description:" + pDes

    '        Dim RequestSchool = PositionDetails.RequestSchool(schoolyear, schoolcode, positionID)

    '        If Not Left(RequestSchool, 4) = schoolcode Then
    '            Me.MessageToPrincipal.InnerText = "Only " + RequestSchool + "'s principal implements an interview process!"
    '        End If

    '    Catch ex As Exception
    '        Dim pp = ex.Message
    '    End Try

    'End Sub

End Class
