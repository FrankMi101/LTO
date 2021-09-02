'Imports System.Data
'Imports System.Data.SqlClient
Imports System.IO
Imports AppOperate
Imports ClassLibrary
'Imports Microsoft.ApplicationInsights.Telemetry.Services

'Imports TCDSB.Student

Partial Class ApplyProfile
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
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Page.Response.Expires = 0

            BindContactInfo()

        End If

    End Sub
    Private Sub BindContactInfo()
        Try

            Dim applicant As ApplicantContact = GetApplicantContactInfo()

            Me.TextHomePhone.Text = getMyValue(applicant.HomePhone)
            Me.TextCellPhone.Text = getMyValue(applicant.CellPhone)
            Me.TexteMail.Text = getMyValue(applicant.Email)
            Me.TextPostionQualification.Text = getMyValue(applicant.OCTQualification)
            Me.LabelUploadFile.Text = getMyValue(applicant.UploadFile)

        Catch ex As Exception

        End Try
    End Sub
    Private Function GetApplicantContactInfo() As ApplicantContact

        Dim parameter As New ApplicantContact()
        With parameter
            .Operate = "Get"
            .CPNum = WorkingProfile.UserCPNum
        End With
        ' Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "ContactInfo")
        Dim info = ApplyProcessExe.ContactInfo(parameter)(0) ' CommonExcute(Of ApplicantContact).GeneralList(SP, parameter)(0) '    CommonListExecute.ApplicantContactProfile(parameter)(0)
        ' Dim interview2 = CommonListExecute(Of PositionInterview).GeneralPosition(parameter)(0)

        Return info

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



    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click


        Dim parameter As New ApplicantContact()
        With parameter
            .Operate = "Update"
            .CPNum = WorkingProfile.UserCPNum
            .HomePhone = Me.TextHomePhone.Text
            .CellPhone = Me.TextCellPhone.Text
            .Email = BasePage.EmailCheck(Me.TexteMail.Text)
        End With
        '  Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "ContactInfo")
        Dim result = ApplyProcessExe.UpdateContact(parameter) ' CommonExcute(Of ApplicantContact).GeneralValue(SP, parameter) '  CommonOperationExcute.ApplicantContactUpdate(parameter, "ContactInfo")

        'Dim schoolyear As String = WorkingProfile.SchoolYear
        'Dim userid As String = HttpContext.Current.User.Identity.Name
        'Dim cpnum As String = WorkingProfile.UserCPNum
        'Dim _comments As String = Me.TextPostionQualification.Text
        'Dim _homephone As String =
        'Dim _cellphone As String = Me.TextCellPhone.Text
        'Dim _email As String = Me.TexteMail.Text
        'LoginIdentify.ApplicantProfileSave(userid, cpnum, schoolyear, _homephone, _cellphone, _email, _comments)



    End Sub

    Private Sub CreatSaveMessage(ByVal strMessage As String, ByVal action As String)
        Try
            Dim positionTitle As String = ""
            '  action = Me.btnApply.Text ' "Cancel" Then action = "Withdraw "
            Dim strScript As String = "window.alert(" + """" + action + " " + positionTitle + " position is " + strMessage + ", and a confirmation email has been sent to you. " + """);"

            '   window.alert(action + " this position is " + resutl);
            '  ***  No Ajax
            ClientScript.RegisterStartupScript(GetType(String), "_savemessagescript", strScript, True)

            '  *** AJAX Save Message
            '  ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType, "save_script", strScript.ToString(), True)

        Catch ex As Exception

        End Try

    End Sub

End Class

