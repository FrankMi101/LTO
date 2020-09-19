'Imports System.Data
Imports AppOperate
Imports ClassLibrary
'Imports System.Data.SqlClient
'Imports Microsoft.ApplicationInsights.Telemetry.Services
'Imports TCDSB.Student

Partial Class ApplicantDetails2
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
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Page.Response.Expires = 0

            BindSelectedApplicat()

        End If

    End Sub
    Private Sub BindSelectedApplicat()
        Try

            Dim applicant = getDataSource()

            Me.TextPositionID.Text = applicant.PositionID

            Me.TextTeacherName.Text = getMyValue(applicant.TeacherName)
            Me.TextStatus.Text = getMyValue(applicant.PositionState)
            Me.TextPositionTitle.Text = getMyValue(applicant.PositionTitle)
            Me.TextSchool.Text = getMyValue(applicant.SchoolName)
            Me.TextArea.Text = getMyValue(applicant.SchoolArea)

            Me.TextApplyDate.Text = getMyValue(applicant.ApplyDate)
            Me.TextHiredDate.Text = getMyValue(applicant.HiredDate)
            Me.TextLTOYears.Text = getMyValue(applicant.LTOYears)
            Me.TextLTODays.Text = getMyValue(applicant.SupplyDays)

            Me.TextQualification.InnerHtml = getMyValue(applicant.QualificationBasic) + vbCrLf + getMyValue(applicant.QualificationDegree) + vbCrLf + getMyValue(applicant.QualificationEducation)
            Me.TextAppraisal.InnerHtml = getMyValue(applicant.Appraisal)
            Me.TextOtherPositionApply.InnerHtml = getMyValue(applicant.MultipleApply)
            Me.TextInterviewSelected.InnerHtml = getMyValue(applicant.InterviewSelected)
            Me.TextComments.InnerHtml = getMyValue(applicant.ApplyComments)

            Me.HiredMessage.Text = getMyValue(applicant.HiredPosition)


            Me.hfPositionType.Value = BasePage.getMyValue(applicant.PositionType)

            Me.LabelcurrentAssignmentSchool.Text = BasePage.getMyValue(applicant.CurrentSchool)
            Me.LabelcurrentAssignment.Text = BasePage.getMyValue(applicant.CurrentAssignment)
            Me.LabelCurrentAssignmentStartDate.Text = BasePage.getMyValue(applicant.CurrentStartDate)
            Me.LabelCurrentAssignmentEndDate.Text = BasePage.getMyValue(applicant.CurrentEndDate)

            Me.hfPositionStartDate.Value = BasePage.getMyValue(applicant.StartDate)
            Me.hfPositionEndDate.Value = BasePage.getMyValue(applicant.EndDate)


            Me.LabelApplySchool.Text = BasePage.getMyValue(applicant.SchoolName)
            Me.LabelApplyAssignment.Text = BasePage.getMyValue(applicant.PositionTitle)
            Me.LabelApplyAssignmentStartDate.Text = BasePage.getMyValue(applicant.StartDate)
            Me.LabelApplyAssignmentEndDate.Text = BasePage.getMyValue(applicant.EndDate)



            If Me.HiredMessage.Text <> "" Then
                Me.HiredMessageRow.Visible = True
                Me.HiredMessage.Visible = True
                Me.HiredAlert.Visible = True
            End If

            If getMyValue(applicant.Acceptance) = "1" Then
                Me.chbInterview.Checked = True
                Me.btnApply.Text = "Unselect for interview"
            Else
                Me.chbInterview.Checked = False
                Me.btnApply.Text = "Select for Interview"
            End If

            If Page.Request.QueryString("pID") > 6 Then
                Me.btnApply.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function getDataSource() As ApplicantInterview
        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        Dim cpnum As String = Page.Request.QueryString("ApplyUserID")
        Dim TeacherName As String = Page.Request.QueryString("TeacherName")
        Dim positionID As String = Page.Request.QueryString("PositionID")
        WorkingProfile.UserCPNum = cpnum

        Dim userid As String = User.Identity.Name

        Dim parameter = CommonParameter.GetParameters(schoolyear, positionID, cpnum)

        If User.Identity.Name = "mif" Then
            '  Dim SP As String = CommonListExecute(Of ApplicantInterview).ObjSP("ApplicantInterview")
            '  Dim SP1 As String = CommonOperationExcute(Of ApplicantInterview).ObjSP("ParametersForOperation", "SelectForInterview")
            Me.lblPostingNumber.ToolTip = SelectCandidateExe.SPName("Applicant")
            Me.btnApply.ToolTip = SelectCandidateExe.SPName("Save")
        End If
        Dim applicant = SelectCandidateExe.Applicant(parameter) ' CommonListExecute.ApplicantInterviewProfile(parameter)(0) '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)
        Return applicant(0)

    End Function

    Private Function getMyValue(ByVal _value As Object) As Object
        Try
            If _value = Nothing Then

            End If
            Return _value
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private Function getMyValueC(ByVal _value As Object) As Object
        Try
            If _value = Nothing Or _value = "" Then
                _value = 0
            End If
            Return _value
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Protected Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        Me.HiddenFieldAction.Value = Me.btnApply.Text

        Dim operation = ObjClassFactory.GetParametersObj() ' ObjClassFactory.GetParametersObj(Of ParametersForOperation)() 
        With operation
            .Operate = "SelectForInterview"
            .UserID = User.Identity.Name
            .SchoolYear = Page.Request.QueryString("SchoolYear")
            .PositionID = Me.TextPositionID.Text
            .CPNum = Page.Request.QueryString("ApplyUserID")
            .Action = IIf(Me.chbInterview.Checked, "0", "1")
        End With

        Dim _result As String = SelectCandidateExe.Save(operation) ' CommonOperationExcute.SelectedForInterviewCandidate(operation, "SelectForInterview") ' PositionDetails.AcceptanceInterview(userid, schoolyear, positionID, cpnum, action)

        Dim message As String = IIf(Me.chbInterview.Checked, "Unselect", "Select")
        CreateSaveMessage(_result, message)


        'Dim mysel As New SelectedObject
        'mysel.CPNum = cpnum
        'mysel.PositionID = positionID


        'Dim PositionApply As New Dictionary(Of String, Object)
        'PositionApply.Add("ApplicantID", mysel.CPNum)
        'PositionApply.Add("PositionID", mysel.PositionID)
        'PositionApply.Add("Owner", userid)
        'Dim Server_name As String = System.Net.Dns.GetHostName()


        '  ServerAnalytics.CurrentRequest.LogEvent(Server_name + "/" + "Select Interview Candidator/", PositionApply)




    End Sub
    Private Sub CreateSaveMessage(ByVal strMessage As String, ByVal action As String)
        Try
            Dim postiontitle As String = Me.TextPositionTitle.Text
            Dim teahername As String = Me.TextTeacherName.Text
            '  Dim strScript As String = "window.alert(" + """" + action + " " + teahername + " for the " + postiontitle + " interview " + strMessage + """);"
            Dim strScript As String = "CallBackReloadParent(" + """" + action + """,""" + teahername + " for the " + postiontitle + " interview " + strMessage + """);"


            '   window.alert(action + " this position is " + resutl);
            '  ***  No Ajax
            ClientScript.RegisterStartupScript(GetType(String), "_savemessagescript", strScript, True)

            '  *** AJAX Save Message
            '  ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType, "save_script", strScript.ToString(), True)
        Catch ex As Exception

        End Try

    End Sub


End Class

