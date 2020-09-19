
Imports AppOperate
Imports ClassLibrary

Partial Class LTOTeachers_FileShow
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.Page.Response.Expires = 0
            Dim type As String = Page.Request.QueryString("Type")
            Dim IDs As String = Page.Request.QueryString("IDs")
            Dim CPNum As String = Page.Request.QueryString("CPNum")
            Dim positionID As String = Page.Request.QueryString("PositionID")
            Dim schoolYear As String = Page.Request.QueryString("SchoolYear")
            If CPNum = "" Then CPNum = WorkingProfile.UserCPNum
            If positionID = "" Then positionID = "0000"
            Dim parameter As ResumeCoverLetter = New ResumeCoverLetter()
            With parameter
                .Operate = type
                .UserID = User.Identity.Name
                .CPNum = CPNum
                .PositionID = positionID
            End With
            Try
                Dim result As List(Of ResumeCoverLetter) = ApplicantAttribute.ResumeCoverLetterList(parameter)

                Dim fileType As String = result(0).FileType
                Dim fileName As String = result(0).FileName
                Dim fileContent As Byte() = result(0).FileContent
                ReportRenderC.RenderReport(fileName, fileType, fileContent)

            Catch ex As Exception

            End Try
        End If
    End Sub

End Class
