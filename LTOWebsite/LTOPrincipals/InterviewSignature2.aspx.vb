'Imports System.Data
'Imports System.Data.SqlClient
'Imports System.IO
'Imports TCDSB.Student
Imports System.Web.Configuration
Imports System.Drawing
Imports AppOperate
Imports ClassLibrary

Partial Class InterviewSignature2
    Inherits System.Web.UI.Page
    Dim cPage As String = "Interview"
    Dim SPFile As String = SPSource.SPFile() '  WebConfigValue.SPFile() 
    Dim JsonFile As String = Server.MapPath("..\Content\eMailTemplate.json")
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
            BindData()
        End If
    End Sub

    Private Sub BindData()
        Try
            Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
            Dim cpnum As String = Page.Request.QueryString("ApplyUserID")
            Dim positionID As String = Page.Request.QueryString("PositionID")

            Dim parameter As InterviewerTeam = New InterviewerTeam()
            With parameter
                .SchoolYear = schoolyear
                .PositionID = positionID
                .CPNum = cpnum
            End With
            Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "Signatures")
            Dim signature = CommonExcute(Of InterviewerTeam).GeneralList(SP, parameter)(0)
            '  Dim InterviewS As String = Page.Request.QueryString("interviewS")
            Me.hfPositionID.Value = positionID
            Me.hfUserCPNum.Value = cpnum
            Me.hfSchoolyear.Value = schoolyear

            hfUserIDP0.Value = signature.CandidateID
            hfUserIDP1.Value = signature.Member1ID
            hfUserIDP2.Value = signature.Member2ID
            hfUserIDP3.Value = signature.Member3ID
            LabelName.Text = signature.CandidateName
            LabelCandidateName.Text = signature.CandidateName
            If hfUserIDP2.Value = "" Then
                LabelSignOffP2.Enabled = False
            End If
            If hfUserIDP3.Value = "" Then
                LabelSignOffP3.Enabled = False
                SignOffRow3.Visible = False
            End If
            LabelSignatureP0.Text = signature.CandidateName
            LabelSignatureP1.Text = signature.InterviewName1
            LabelSignatureP2.Text = signature.InterviewName2
            LabelSignatureP3.Text = signature.InterviewName3
            If LabelSignatureP0.Text = " " Then
                LabelSignatureP0.Text = hfUserIDP0.Value
                hfSignOffP0.Value = "none"
            End If
            If LabelSignatureP1.Text = " " Then
                LabelSignatureP1.Text = hfUserIDP1.Value
                hfSignOffP1.Value = "none"
            End If
            If LabelSignatureP2.Text = " " Then
                LabelSignatureP2.Text = hfUserIDP2.Value
                hfSignOffP2.Value = "none"
            End If
            If LabelSignatureP3.Text = " " Then
                LabelSignatureP3.Text = hfUserIDP3.Value
                hfSignOffP3.Value = "none"
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        errorlabel.Text = ""
        Try
            If WebConfigurationManager.AppSettings("AuthenticateMethod") = "NameOnly" Then
                CheckTestUser()
            Else

                If UserSecurity.Authenticate(txtDomain.Text, txtUsername.Text, txtPassword.Text) Then '  Common.LDAP_Authentication.Authenticate(txtDomain.Text, txtUsername.Text, txtPassword.Text) Then
                    CreateAuthTicket()
                Else
                    ' CheckTestUser() '"Authentication did not succeed. Check user name and password.")
                    errorlabel.ForeColor = Drawing.Color.Red
                    errorlabel.Text = "Check the password."

                End If

            End If
        Catch ex As Exception
            'Dim sdk As String = ex.Message
            ' CheckTestUser() '"Authentication did not succeed. Check user name and password.")
        End Try
    End Sub
    Private Sub CheckTestUser()
        CreateAuthTicket()
    End Sub
    Private Sub CreateAuthTicket()
        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        Dim cpnum As String = Page.Request.QueryString("ApplyUserID")
        Dim positionID As String = Page.Request.QueryString("PositionID")
        Dim userid As String = HttpContext.Current.User.Identity.Name
        Dim _signatureID As String = hfSignOfffUserID.Value '  txtUsername.Text
        Dim signoffNo As String = hfSignOffNo.Value
        Dim _signature As String = ""
        If signoffNo = "LabelSignOffP0" Then
            _signature = "Candidate"
        Else
            _signature = "Interview" + Replace(signoffNo, "LabelSignOffP", "")
        End If

        Dim parameter As InterviewerTeam = New InterviewerTeam()
        With parameter
            .SchoolYear = schoolyear
            .PositionID = positionID
            .CPNum = cpnum
            .Signature = _signature
            .SignatureID = _signatureID
        End With
        Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "SignatureName")
        Dim signatureName = CommonExcute(Of InterviewerTeam).GeneralValue(SP, parameter)


        '  Dim signatureName = PositionDetails.InterviewSignature(userid, cpnum, schoolyear, positionID, _signature, _signatureID)

        If signoffNo = "LabelSignOffP0" Then
            LabelSignatureP0.Text = signatureName
            hfSignOffP0.Value = "block"
        ElseIf signoffNo = "LabelSignOffP1" Then
            LabelSignatureP1.Text = signatureName
            hfSignOffP1.Value = "block"
        ElseIf signoffNo = "LabelSignOffP2" Then
            LabelSignatureP2.Text = signatureName
            hfSignOffP2.Value = "block"
        Else
            LabelSignatureP3.Text = signatureName
            hfSignOffP3.Value = "block"
        End If


    End Sub
End Class

