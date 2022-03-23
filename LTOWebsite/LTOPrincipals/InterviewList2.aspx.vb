'Imports System.Data
'Imports System.Data.SqlClient
Imports AppOperate
Imports ClassLibrary
'Imports TCDSB.Student

Partial Class InterviewList2
    Inherits System.Web.UI.Page
    Dim RequestSchool As String
    Dim myRequestPosting As New PositionRequesting
    Dim _schoolyear As String
    Dim _schoolcode As String
    Dim _PositionID As String
    Dim _appType As String
    Dim _status As String

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
            _schoolyear = Page.Request.QueryString("SchoolYear")
            _schoolcode = Page.Request.QueryString("SchoolCode")
            _PositionID = Page.Request.QueryString("PositionID")
            _appType = Page.Request.QueryString("appType")
            _status = Page.Request.QueryString("Status")
            hfSchoolYear.Value = _schoolyear
            hfSchoolCode.Value = _schoolcode
            hfPositionID.Value = _PositionID
            hfSchoolName.Value = WorkingProfile.SchoolName
            Dim _statuse As String = Page.Request.QueryString("Status")
            Session("currentDataSet") = Nothing
            HiddenFieldDevice.Value = Session("Device")
            BindDDL()
            ' Me.WebDataGrid1.Behaviors.EditingCore.BatchUpdating = True
            BindGridData()
            '  setPositionTitle()
            If _statuse = "MoreInterview" Then RequestMoreInterviewArea.Visible = True
        End If

    End Sub
    Private Sub BindDDL()

        hfUserID.Value = HttpContext.Current.User.Identity.Name
        Dim parameter As New List2Item()
        With parameter
            .Operate = "InterviewProcess"
            .Para0 = _schoolyear
            .Para1 = _appType
        End With
        AssemblingList.SetLists("", Me.cellEditInterviewOutCome, "InterviewProcess", parameter, _schoolyear)

        '  SetupList.ListDDL(Me.cellEditInterviewOutCome, "InterviewProcess", _SchoolYear)
        CheckRequestSchool()
        If Not _status = "Done" Then '  Not (_status = "Hired" Or _status = "Recommend" Or _status = "End") Then
            CheckInterviewCount()
        End If



    End Sub
    Private Sub CheckRequestSchool()

        Dim parameter = CommonParameter.GetParameters(_schoolyear, _PositionID)
        ' Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, "Publish", "PositionInfo")
        Dim positionInfo As PositionInfo = PublishPositionExe(Of PositionInfo).PositionInfo(parameter)(0) '  CommonExcute(Of PositionInfo).GeneralList(SP, parameter)(0) ' CommonListExecute.PublishPositionInfo(parameter)(0) '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)

        RequestSchool = positionInfo.SchoolName  ' RequestingPostExe.RequestPositionAttribute(myRequestPosting, _PositionID)
        Me.lblPostingNumber.Text = positionInfo.PostingNumber '  RequestingPostExe.RequestPositionAttribute(myRequestPosting, _PositionID)
        Me.lblState.Text = positionInfo.PostingState '  RequestingPostExe.RequestPositionAttribute(myRequestPosting, _PositionID)
        Me.lblPositionTitle.Text = positionInfo.PositionType + " Position: " + positionInfo.PositionTitle + " " + positionInfo.PostingCycle + " Desc: " + positionInfo.Description
        Me.lblQualification.Text = " Level: " + positionInfo.PositionLevel + " Qual: " + positionInfo.Qualification    '   'RequestingPostExe.RequestPositionAttribute(myRequestPosting, _PositionID)
        Me.lblStartDate.Text = positionInfo.StartDate
        Me.lblEndDate.Text = positionInfo.EndDate

        If Not Left(RequestSchool, 4) = _schoolcode Then
            Me.MessageToPrincipal.InnerText = "Only " + RequestSchool + "'s principal implements an interview process!"
            hfRequestSchool.Value = "Yes"
        Else
            hfRequestSchool.Value = "No"
        End If

    End Sub
    Private Sub CheckInterviewCount()


        Dim interviewParameter As New InterviewResult()
        With interviewParameter
            .Operate = "InterviewCount"
            .UserID = HttpContext.Current.User.Identity.Name
            .SchoolYear = _schoolyear
            .PositionID = _PositionID
        End With
        '  Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "InterviewCount")
        Dim interviewCount = InterviewProcessExe.InterviewCount(interviewParameter) ' CommonExcute(Of InterviewResult).GeneralValue(SP, interviewParameter) '   CommonOperationExcute.InterviewOperation(interviewParameter, "InterviewCount") ' PostingInterviewExc.CheckInterviewCount(interviewParameter, _positionID) ', sitionDetails.InterviewCandidateCount(userid, cpnum, _schoolyear, _positionID)

        If interviewCount = "0" Then
            RequestMoreInterviewArea.Visible = True
        Else
            RequestMoreInterviewArea.Visible = False
        End If

    End Sub
    Private Sub BindGridData()
        Try
            '  Dim ds As DataSet
            '  ds = GetDataset(goDatabase)
            Me.GridView1.DataSource = getDataSource() ' ds.Tables(0)
            GridView1.DataBind()

        Catch ex As Exception
            ' CommonTCDSB.ShowMsg.Exception(ex, Me.Page, "Bind data action")
        End Try
    End Sub
    Private Function getDataSource() As List(Of CandidateList)
        Dim parameter = CommonParameter.GetParameters(_schoolyear, _PositionID)
        '   Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "Candidates") ' CommonListExecute(Of CandidateList).ObjSP("CandidateList")
        If User.Identity.Name = "mif" Then
            Me.lblPostingNum.ToolTip = InterviewProcessExe.SpName("Candidates")
        End If

        Dim sList = InterviewProcessExe.Candidates(parameter) '  CommonExcute(Of CandidateList).GeneralList(SP, parameter) '  CommonListExecute.InterviewCandidates(parameter) '  PostingPublishExe.Positions(parameters) ' .PostingPositions(parameters)
        Return sList
    End Function

End Class
