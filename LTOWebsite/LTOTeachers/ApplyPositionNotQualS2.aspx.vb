'Imports System.Data
''Imports System.Data.SqlClient
'Imports System.IO
Imports AppOperate
Imports ClassLibrary
'Imports Microsoft.ApplicationInsights.Telemetry.Services



Partial Class ApplyPositionNotQualS2
    Inherits System.Web.UI.Page
    Dim SPFile As String = SPSource.SPFile() '  WebConfigValue.SPFile() 
    Dim cPage As String = "Applying"

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Page.Response.Expires = 0
            BindPosition()

        End If

    End Sub
    Private Function GetQualificationCheckResult() As PositionQualificationCheck

        Dim cpnum As String = Page.Request.QueryString("CPNum")

        If (cpnum = Nothing Or cpnum = "undefined") Then cpnum = WorkingProfile.UserCPNum
        LabelApplicant.Text = Page.Request.QueryString("Applicant") + " (" + cpnum + ")"
        Dim paraForPosition As New ParametersForPosition


        paraForPosition.SchoolYear = WorkingProfile.SchoolYear
        paraForPosition.PositionID = Page.Request.QueryString("PositionID")
        paraForPosition.CPNum = cpnum

        Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "QualificationCheck")

        Dim Qual = ApplyProcessExe.QualficationCheck(paraForPosition)(0) ' CommonExcute(Of PositionQualificationCheck).GeneralList(SP, paraForPosition)(0) '   CommonListExecute.AllPositionList(Of PositionQualificationCheck)(paraForPosition)(0)
        Return Qual

    End Function
    Private Sub BindPosition()

        Try

            Dim QualificationCheck = GetQualificationCheckResult()

            LabelApplicant.Text = LabelApplicant.Text + getMyValue(QualificationCheck.CurrentAssignment)

            Me.TextPostionQualification.Text = getMyValue(QualificationCheck.Qualification)


            Me.TextPostionLevel.Text = BasePage.getMyValue(QualificationCheck.PositionLevel)

            Me.TextApplicantQualfication.Text = getMyValue(QualificationCheck.OCTQualification)

            Me.NotMatchQual.Text = getMyValue(QualificationCheck.NonQualification)

            If WorkingProfile.UserRole = "Roster" Then
                If Len(Me.NotMatchQual.Text) > 5 Then
                    If Me.NotMatchQual.Text = "OT Roster" Then
                        RosterRole.Visible = True
                    Else
                        notQualified.Visible = True
                    End If
                End If
            Else
                If Len(NotMatchQual.Text) > 5 Then
                    notQualified.Visible = True
                Else
                    notQualified.Visible = False
                End If
            End If


        Catch ex As Exception
            Dim em As String = ex.Message

        End Try
    End Sub
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



End Class

