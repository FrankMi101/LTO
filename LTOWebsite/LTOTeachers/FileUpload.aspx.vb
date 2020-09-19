
Imports System.Drawing
Imports System.IO
Imports AppOperate
Imports ClassLibrary
Imports Color = System.Drawing.Color

Partial Class FileUpload
    Inherits System.Web.UI.Page
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            Page.Response.Expires = 0
            CheckHaveResumeandCoverLetter()
        End If

    End Sub
    Private Sub CheckHaveResumeandCoverLetter()

        Dim result As String = ""

        Try
            Dim CPNum As String = Page.Request.QueryString("CPNum")
            If CPNum = "" Then CPNum = WorkingProfile.UserCPNum
            Dim positionID As String = Page.Request.QueryString("PositionID")
            If positionID = "" Then positionID = "0000"

            HiddenFieldCPNum.Value = CPNum
            HiddenFieldPositionID.Value = positionID

            Dim parameter As ResumeCoverLetter = New ResumeCoverLetter()
            With parameter
                .Operate = "Resume"
                .UserID = User.Identity.Name
                .CPNum = CPNum
                .PositionID = positionID
            End With
            LabelResumeName.Text = ApplicantAttribute.ResumeCoverLetterName(parameter)

            parameter.Operate = "CoverLetter"
            LabelLetterName.Text = ApplicantAttribute.ResumeCoverLetterName(parameter)
            RowResumeActionSetup()
            RowLetterActionSetup()




        Catch ex As Exception

        End Try
    End Sub
    Private Sub RowResumeActionSetup()
        If LabelResumeName.Text = "" Then
            LabelResumeName.Visible = False
            RowResumeAction.Visible = False
            FileUpload1.Visible = True
            ButtonUploadResume.Visible = True
        Else
            LabelResumeName.Visible = True
            RowResumeAction.Visible = True
            FileUpload1.Visible = False
            ButtonUploadResume.Visible = False
        End If
    End Sub
    Private Sub RowLetterActionSetup()
        If LabelLetterName.Text = "" Then
            LabelLetterName.Visible = False
            RowLetterAction.Visible = False
            FileUpload2.Visible = True
            ButtonUploadLetter.Visible = True
        Else
            LabelLetterName.Visible = True
            RowLetterAction.Visible = True
            FileUpload2.Visible = False
            ButtonUploadLetter.Visible = False
        End If
    End Sub

    'Private Sub BtnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpload.Click
    '    If IsNothing(FileUpload1.PostedFile) Then lblMSG.Text = "Select one file to upload" : Exit Sub
    '    If FileUpload1.PostedFile.ContentLength = 0 Then lblMSG.Text = "Cannot upload zero length file" : Exit Sub
    '    UpLoadFileToDatabase("Resume", FileUpload1)
    '    UpLoadFileToDatabase("CoverLetter", FileUpload2)
    'End Sub
    'Private Sub UpLoadFileToServer()
    '    Dim FullName As String
    '    Dim FileName As String
    '    Dim sSplit() As String
    '    Try
    '        FullName = FileUpload1.PostedFile.FileName
    '        sSplit = FullName.Split("\")
    '        FileName = sSplit(UBound(sSplit))
    '        'FileName = FullName.Substring(FullName.LastIndexOf("\") + 1, Len(FullName) - FullName.LastIndexOf("\") - 1)

    '        If AttachmentID = "0" Then lblMSG.Text = "Attach File Process Failed " : Exit Sub
    '        Session("NewAttachmentID") = AttachmentID

    '        Dim _user As String = HttpContext.Current.User.Identity.Name
    '        '  TPA3.Attachment.UpLoadFileData.updateObjectTab(_user, MessID, AttachmentID)
    '        lblMSG.ForeColor = Color.Blue
    '        lblMSG.Text = "Upload file successful."

    '    Catch ex As Exception
    '        lblMSG.ForeColor = Color.Red
    '        lblMSG.Text = "Upload file failed."
    '    End Try
    'End Sub
    'Private Function UpLoadFileTOWebServer(ByVal Filename As String) As String
    '    Dim destination, myFolder As String
    '    Try
    '        '  destination = Server.MapPath(ConfigurationSettings.AppSettings("AttachmentFolder"))
    '        destination = Server.MapPath(ConfigurationManager.AppSettings("AttachmentFolder"))
    '        myFolder = Dir(destination, vbDirectory)   ' Retrieve the first entry.
    '        If myFolder = "" Then   ' The folder is not there & to be created
    '            MkDir(destination)       'Folder created
    '        End If
    '        If Left(FileUpload1.PostedFile.ContentType, 5).ToUpper = "IMAGE" Then
    '            If File.Exists(destination + Filename) Then
    '                lblMSG.ForeColor = Color.Red
    '                lblMSG.Text = "Logo exists, can not upload again."
    '                Exit Function
    '            End If
    '        End If
    '        ' ** upload the file to Web server
    '        FileUpload1.PostedFile.SaveAs(destination + "\" + Filename)
    '        Dim aFileType As String = FileUpload1.PostedFile.ContentType

    '        ' ** update the attachment information to database
    '        Dim title, descriptions, contentType As String
    '        contentType = FileUpload1.PostedFile.ContentType
    '        title = "Title"
    '        descriptions = "description"
    '        Dim _user As String = HttpContext.Current.User.Identity.Name
    '        Dim _aCatalog As String = Session("aCatalog")
    '        AttachmentID = Attachment.UpLoadFileData.getAttachmentID(_user, "Insert", AttachmentID, title, Filename, _aCatalog, descriptions, "WebServer", "", aFileType) ' AttachmentsDC.UpdateAttachment(0, String.Empty, title, descriptions, FileName, contentType, String.Empty, context.User.Identity.Name, "Add")
    '        Return AttachmentID
    '    Catch ex As Exception
    '        Return 0
    '    End Try
    'End Function
    Private Function UpLoadFileToDatabase(ByVal type As String, ByRef fileUpdate As Object) As String

        Dim result As String = ""

        Try
            'If Not fileUpdate.FileName = "" Then 
            If Not fileUpdate.Value() = "" Then
                Dim CPNum As String = Page.Request.QueryString("CPNum")
                If CPNum = "" Then CPNum = WorkingProfile.UserCPNum
                Dim positionID As String = Page.Request.QueryString("PositionID")
                If positionID = "" Then positionID = "0000"
                ' Dim aFileNames() As String = FileUpload1.PostedFile.FileName.Split("\")

                Dim fileType As String = fileUpdate.PostedFile.ContentType
                '  Dim fileName As String = fileUpdate.FileName ' aFileNames(aFileNames.GetLength(0) - 1)
                ' Dim fileContent As Byte() = FileOperation.ReadFully(fileUpdate.FileContent())
                ' ***********  HTML input type ="File" ********
                Dim fileName As String = fileUpdate.Value()
                Dim fileContent As Byte() = FileOperation.ReadFully(fileUpdate.PostedFile.InputStream)
                '  Dim fileContent As Byte() = My.Computer.FileSystem.ReadAllBytes(fileName)
                '*************************************************



                Dim parameter As ResumeCoverLetter = New ResumeCoverLetter()
                With parameter
                    .Operate = type
                    .UserID = User.Identity.Name
                    .CPNum = CPNum
                    .PositionID = positionID
                    .SchoolYear = WorkingProfile.SchoolYear
                    .GrantView = IIf(CheckBoxGrantView.Checked, "X", "")

                    .FileContent = fileContent
                    .FileName = fileName
                    .FileType = fileType
                End With
                result = ApplicantAttribute.ResumeCoverLetterSave(parameter)

                If result = "Successfully" Then
                    result = fileName
                End If
            End If

            Return result
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Protected Sub CheckBoxGrantView_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxGrantView.CheckedChanged

        Dim CPNum As String = Page.Request.QueryString("CPNum")
        If CPNum = "" Then CPNum = WorkingProfile.UserCPNum
        Dim positionID As String = Page.Request.QueryString("PositionID")
        If positionID = "" Then positionID = "0000"
        Dim parameter As ResumeCoverLetter = New ResumeCoverLetter()

        With parameter
            .Operate = "Resume"
            .UserID = User.Identity.Name
            .CPNum = CPNum
            .PositionID = positionID
            .SchoolYear = WorkingProfile.SchoolYear
            .GrantView = IIf(CheckBoxGrantView.Checked, "X", "")
        End With
        Dim result As String = ApplicantAttribute.ResumeCoverLetterPermission(parameter)
    End Sub
    Protected Sub ButtonUploadResume_Click(sender As Object, e As EventArgs) Handles ButtonUploadResume.Click

        If IsNothing(FileUpload1.PostedFile) Then lblMSG.Text = "Select one file to upload" : Exit Sub
        If FileUpload1.PostedFile.ContentLength = 0 Then lblMSG.Text = "Cannot upload zero length file" : Exit Sub
        LabelResumeName.Text = UpLoadFileToDatabase("Resume", FileUpload1)
        RowResumeActionSetup()
        If Not FileUpload2.Value = "" Then ' If Not FileUpload2.Value = "" Then
            LabelLetterName.Text = UpLoadFileToDatabase("CoverLetter", FileUpload2)
            RowLetterActionSetup()
        End If
    End Sub
    Protected Sub ButtonUploadLetter_Click(sender As Object, e As EventArgs) Handles ButtonUploadLetter.Click
        If IsNothing(FileUpload2.PostedFile) Then lblMSG.Text = "Select one file to upload" : Exit Sub
        If FileUpload2.PostedFile.ContentLength = 0 Then lblMSG.Text = "Cannot upload zero length file" : Exit Sub

        LabelLetterName.Text = UpLoadFileToDatabase("CoverLetter", FileUpload2)
        RowLetterActionSetup()
        If Not FileUpload1.Value = "" Then
            LabelResumeName.Text = UpLoadFileToDatabase("Resume", FileUpload1)
            RowResumeActionSetup()
        End If
    End Sub
    Protected Sub ButtonRemoveResume_Click(sender As Object, e As EventArgs) Handles ButtonRemoveResume.Click

        LabelResumeName.Text = RemoveFileToDatabase("Resume")
        RowResumeActionSetup()

    End Sub
    Protected Sub ButtonRemoveLetter_Click(sender As Object, e As EventArgs) Handles ButtonRemoveLetter.Click

        LabelLetterName.Text = RemoveFileToDatabase("CoverLetter")
        RowLetterActionSetup()
    End Sub
    Private Function RemoveFileToDatabase(ByVal type As String) As String

        Dim result As String = ""

        Try
            Dim CPNum As String = Page.Request.QueryString("CPNum")
            If CPNum = "" Then CPNum = WorkingProfile.UserCPNum
            Dim positionID As String = Page.Request.QueryString("PositionID")
            If positionID = "" Then positionID = "0000"

            Dim parameter As ResumeCoverLetter = New ResumeCoverLetter()
            With parameter
                .Operate = type
                .UserID = User.Identity.Name
                .CPNum = CPNum
                .PositionID = positionID
                .SchoolYear = WorkingProfile.SchoolYear
            End With
            result = ApplicantAttribute.ResumeCoverLetterRemove(parameter)
            Me.HiddenFieldResumeID.Value = result
            If result = "Successfully" Then
                result = ""
            End If

            Return result
        Catch ex As Exception
            Return "Failed"
        End Try
    End Function
End Class
