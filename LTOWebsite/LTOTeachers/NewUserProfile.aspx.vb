'Imports System.Data
'Imports System.Data.SqlClient
Imports System.IO
Imports AppOperate
Imports ClassLibrary

Partial Class NewUserProfile
    Inherits System.Web.UI.Page

    'Private Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
    '    If Not Session("mytheme") Is Nothing Then
    '        Me.Theme = Session("mytheme")

    '    End If
    'End Sub
    '' ### setup Page StylesheetTheme
    'Public Overrides Property StyleSheetTheme() As String
    '    Get
    '        Return Session("mytheme")
    '    End Get
    '    Set(ByVal value As String)
    '    End Set
    'End Property
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Page.Response.Expires = 0
            Dim userid As String = HttpContext.Current.User.Identity.Name
            Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
            Dim Source As String = Page.Request.QueryString("Source")
            Dim Status As String = Page.Request.QueryString("LTOStatus")
            btnAction2.Visible = True
            Select Case Status
                Case "New"
                    btnAction.Text = "Add Staff To Roster List"
                    btnAction2.Text = "Add Staff To LTO List"
                    RowCommentsInfo.Visible = False
                    RowComments.Visible = False
                    btnSaveRanking.Visible = False
                Case "Roster"
                    btnAction.Text = "Move Staff From Roster To LTOTeacher"
                    btnAction2.Text = "Remove Staff From Roster List"
                    btnSave.Text = "Pending"
                Case "LTOTeacher"
                    btnAction.Text = "Move Staff From LTO to POP"
                    btnAction2.Text = "Remove Staff From LTO Teacher List"
                    btnSave.Text = "Pending"
                Case "Pending"
                    btnAction.Text = "Remove Pending Status"
                    btnAction2.Text = "Remove Staff From LTO Teacher List"
                  '  btnSave.Text = "Unpending"
                Case "POP"
                    btnAction.Text = "Remove Staff From LTO Teacher List"
                    btnAction2.Text = "Move Staff From POP To LTO"

                Case Else
                    btnAction.Text = "Remove Staff From LTO Teacher List"
                    btnAction2.Visible = False
            End Select

            LoadMyData()

        End If
    End Sub
    Private Sub LoadMyData()
        Try

            Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
            Dim cpnum As String = Page.Request.QueryString("CPNum")
            '   ?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&CPNum=" + applyuserID + "&Source=" + Page.Request.QueryString("Source") + "&LTOStatus=" + Page.Request.QueryString("LTOStatus")

            Me.hfUserCPNum.Value = cpnum
            Me.hfSchoolyear.Value = schoolyear

            Dim product1 = New With {.Name = "paperclips", .Price = 1.29}
            Dim parameter = New With
                {.CPNum = Page.Request.QueryString("CPNum"),
                .Source = Page.Request.QueryString("Source")
            }

            '   ManageNewStaffs.GetProfilePage(Page, parameter)
            '   ManageNewStaffs.AssembleProfilePage(Page, "Get", userid, cpnum)

            'Dim ds As DataSet = Applicant.NewUserProfile("Retrieve", userid, cpnum, schoolyear)
            Dim staff = LTOStaffManageExe.Staff(parameter)(0)

            Me.LabelTeacherName.Text = BasePage.getMyValue(staff.TeacherName)
            Me.LabelCPNum.Text = cpnum
            Me.DateOfHire.Value = BasePage.getMyValue(staff.DateOfHire)
            Me.TextRanking.Text = BasePage.getMyValue(staff.Ranking)
            Me.TextLots.Text = BasePage.getMyValue(staff.Lots)
            Me.LabelSchoolName.Text = BasePage.getMyValue(staff.SchoolName)
            Me.LabelOCTQualification.Text = BasePage.getMyValue(staff.Qualification)
            Me.LabelCurrentStatus.Text = BasePage.getMyValue(staff.OTType)
            '  Me.hfSchoolCode.Value = BasePage.getMyValue(staff.)
            Me.TextHRComments.Text = HttpContext.Current.Server.HtmlDecode(BasePage.getMyValue(staff.Comments))
            If LabelTeacherName.Text = "" Then
                btnAction.Enabled = False
                btnAction2.Enabled = False
            End If
            checkCommentsHistory()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CreateSaveMessage(ByVal result As String, ByVal action1 As String)
        Try


            Dim name As String = LabelTeacherName.Text
            action1 = action1.Replace("Staff", name)
            '  Dim strScript As String = "window.alert('" + action2 + " " + result + "');"
            Dim strScript As String = "CallBackReloadParent('" + action1 + "','" + result + "');"
            ' CallBackReloadParent(Action1, strMessage)

            '   window.alert(action + " this position is " + resutl);
            '  ***  No Ajax
            '  ClientScript.RegisterStartupScript(GetType(String), "_savemessagescript", strScript, True)

            '  *** AJAX Save Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType, "save_script", strScript.ToString(), True)
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub BtnAction_Click(sender As Object, e As EventArgs) Handles btnAction.Click
        '    Dim result = Applicant.NewUserProfile("Retrieve", userid, cpnum, schoolyear, Action)
        ' Staff Parameter = New Staff { Operate = operate, userid = userid, cpnum = cpnum, Action = Action };
        Dim parameter = GetSaveParameters(Me.btnAction.Text) ' As New ClassLibrary.Staff()
        'With parameter
        '    .Operate = "Save"
        '    .UserID = User.Identity.Name
        '    .CPNum = Page.Request.QueryString("CPNum")
        '    .Action = Me.btnAction.Text
        'End With

        Dim result = LTOStaffManageExe.Save(parameter) ' ManageNewStaffs.SaveProfile(parameter)
        '  Dim result = ManageNewStaffs.SaveProfile("Save", userid, cpnum, Action)

        CreateSaveMessage(result, btnAction.Text)
    End Sub
    Protected Sub BtnAction2_Click(sender As Object, e As EventArgs) Handles btnAction2.Click
        Dim parameter = GetSaveParameters(Me.btnAction2.Text) ' As New ClassLibrary.Staff()

        Dim result = LTOStaffManageExe.Save(parameter) ' ManageNewStaffs.SaveProfile(parameter)
        '  Dim result = ManageNewStaffs.SaveProfile("Save", userid, cpnum, Action)

        CreateSaveMessage(result, btnAction2.Text)
    End Sub
    Protected Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim parameter = GetSaveParameters(Me.btnSave.Text) '  As New ClassLibrary.Staff()

        Dim result = LTOStaffManageExe.Save(parameter) ' ManageNewStaffs.SaveProfile(parameter)
        '  Dim result = ManageNewStaffs.SaveProfile("Save", userid, cpnum, Action)

        CreateSaveMessage(result, btnSave.Text)
    End Sub

    Private Function GetSaveParameters(ByVal action As String) As ClassLibrary.HRComments
        Dim parameter As New ClassLibrary.HRComments
        With parameter
            .Operate = "Save"
            .UserID = User.Identity.Name
            .CPNum = Page.Request.QueryString("CPNum")
            .Action = action
            .Comments = HttpContext.Current.Server.HtmlEncode(TextHRComments.Text)
            .IDs = hfCommentsIDs.Value
            .CommentsDate = LabelCommentDate.Text
            .Ranking = Me.TextRanking.Text
            .DateOfHire = DateFC.YMD(Me.DateOfHire.Value, "/")
            .Lots = Me.TextLots.Text
        End With
        Return parameter
    End Function

    Protected Sub ImageButtonPrevious_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonPrevious.Click
        Dim index As Integer
        If Me.Labelcurrent.Text > 1 Then
            index = Me.Labelcurrent.Text - 1
            Me.Labelcurrent.Text = Me.Labelcurrent.Text - 1
            GetCommentsData(index - 1)
        End If
    End Sub
    Protected Sub ImageButtonNext_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonNext.Click
        Dim index As Integer

        If Me.Labelcurrent.Text < Me.Labelrecords.Text Then

            index = Me.Labelcurrent.Text + 1
            Me.Labelcurrent.Text = Me.Labelcurrent.Text + 1
            GetCommentsData(index - 1)

        End If
    End Sub
    Private Sub GetComments()
        Dim para As New ClassLibrary.HRComments()
        With para
            .Action = "Get"
            .UserID = User.Identity.Name
            .CPNum = Page.Request.QueryString("CPNum")
        End With

        '   Dim para = New With {Key .Action = "Get", Key .UserID = User.Identity.Name, Key .CPNum = Page.Request.QueryString("CPNum")}
        Dim comments As List(Of HRComments) = LTOStaffManageExe.CommentsList(para)
        Dim commentsCount As Integer = comments.Count
        Session("CommentsList") = comments
        Session("CommentsCount") = commentsCount

        ' Return comments
    End Sub
    Private Sub checkCommentsHistory()



        GetComments()
        IntialCommentsBy(0, 0)

        Try
            '  comments = LTOStaffManageExe.CommentsList(parameter)
            ' Dim comments = GetComments()
            Dim commentsCount As Integer = Session("CommentsCount")

            If commentsCount > 0 Then
                Dim lastIndex As Integer = commentsCount - 1
                Me.Labelrecords.Text = commentsCount
                Me.Labelcurrent.Text = commentsCount
                GetCommentsData(lastIndex)
            End If

        Catch ex As Exception
            Dim ss = ex.Message
        End Try
    End Sub

    Private Sub GetCommentsData(ByVal index As Integer)
        Try
            Dim comments As List(Of HRComments) = Session("CommentsList")
            Dim comment As HRComments = comments(index)

            hfCommentsIDs.Value = comment.IDs
            Me.LabelCommentBy.Text = comment.CommentsBy
            Me.LabelCommentDate.Text = comment.CommentsDate
            Me.TextHRComments.Text = HttpContext.Current.Server.HtmlDecode(comment.Comments)
        Catch ex As Exception
            Dim sm = ex.Message

        End Try

    End Sub
    Private Sub IntialCommentsBy(ByVal current As Integer, ByVal record As Integer)
        hfCommentsIDs.Value = 0
        Me.LabelCommentBy.Text = HttpContext.Current.User.Identity.Name
        Me.LabelCommentDate.Text = DateFC.YMD(Date.Now())
        Me.TextHRComments.Text = ""
        Me.Labelrecords.Text = current
        Me.Labelcurrent.Text = record

    End Sub
    Protected Sub AddComment_Click(sender As Object, e As EventArgs) Handles AddComment.Click
        GetComments()
        Dim goNumber As Integer = Session("CommentsCount") + 1

        IntialCommentsBy(goNumber, goNumber)
    End Sub
    Protected Sub btnSaveRanking_Click(sender As Object, e As EventArgs) Handles btnSaveRanking.Click
        Dim parameter = New With {
            .Operate = "Save",
            .UserID = User.Identity.Name,
            .CPNum = Page.Request.QueryString("CPNum"),
            .DateOfHire = DateFC.YMD(Me.DateOfHire.Value, "/"),
            .Ranking = Me.TextRanking.Text,
            .Lots = Me.TextLots.Text
        }

        Dim result = LTOStaffManageExe.SaveRanking(parameter) ' ManageNewStaffs.SaveProfile(parameter)
        '  Dim result = ManageNewStaffs.SaveProfile("Save", userid, cpnum, Action)

        CreateSaveMessage(result, "Area Change Save")
        LoadMyData()
    End Sub
End Class

