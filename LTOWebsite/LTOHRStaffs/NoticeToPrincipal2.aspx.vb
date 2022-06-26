'Imports System.Data
'Imports System.Data.SqlClient
Imports System.IO
Imports AppOperate
Imports ClassLibrary

Partial Class NoticeToPrincipal2
    Inherits System.Web.UI.Page
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
            Page.Response.Expires = 0
            BindDDLList()
            bindData()
        End If
    End Sub


    Private Function getDataSource(Of T)() As T
        Dim userid As String = HttpContext.Current.User.Identity.Name
        Dim schoolcode As String = Page.Request.QueryString("SchoolCode")

        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        Dim positionID As String = Page.Request.QueryString("PositionID")

        Dim parameter = CommonParameter.GetParameters(schoolyear, positionID)
        If User.Identity.Name = "mif" Then
            '  Dim SP As String = CommonListExecute(Of PositionPublish).ObjSP("PositionPublish")
            Me.lblPostingNumber.ToolTip = PublishPositionExe(Of String).SpName("Position")
        End If

        Dim position = PublishPositionExe(Of T).Position(parameter)(0)  '  CommonListExecute.PublishPosition(parameter)(0) '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)
        Return position

    End Function

    Private Sub bindData()
        Try
            Dim position = getDataSource(Of PositionListPublish)() ' getDataSource() '  SinglePosition.PositionByID(parameter)

            Me.TextPositionID.Text = position.PositionID

            Me.TextPositionTitle.Text = getMyValue(position.PositionTitle)
            Me.TextStatus.Text = getMyValue(position.PositionState)
            Me.TextPositionDescription.Text = getMyValue(position.Description)
            Me.TextPostionQualification.Text = getMyValue(position.Qualification)
            Me.TextArea.Text = getMyValue(position.SchoolArea)
            Me.TextSchool.Text = getMyValue(position.SchoolName)  ' Page.Request.QueryString("SchoolName")

            Me.TextApplyEndDate.Text = getMyValue(position.DateApplyClose)
            Me.TextStartDate.Text = getMyValue(position.StartDate)
            Me.lblFTE.Text = getMyValue(position.FTE)
            Me.lblFTEPanel.Text = getMyValue(position.FTEPanel)
            Me.TextEndDate.Text = getMyValue(position.EndDate)
            Me.textPrincipal.Text = getMyValue(position.PrincipalName)

            Dim _postionLevel As String = BasePage.getMyValue(position.PositionLevel)
            AssemblingList.SetValue(Me.ddlPositionlevel, _postionLevel)
            Me.hfPositionType.Value = getMyValue(position.PositionType)
            '  ListInitial.DDL(Me.ddlSchoolPrincipal, getMyValue(position.PrincipalID))
            Me.TextType.Text = getMyValue(position.PositionType)
            Me.TextOwner.Text = getMyValue(position.Owner)
            Me.TextPostedDate.Text = getMyValue(position.DatePublish)
            Me.lblPostingCycle.Text = getMyValue(position.PostingCycle)
            Me.TextPostingcomments.Text = getMyValue(position.Comments)
            Me.TextTeacherReplaced.Text = getMyValue(position.ReplaceTeacher)
            Me.TextTeacherPersonID.Text = getMyValue(position.ReplaceTeacherID)
            Me.TextPostingNum.Text = getMyValue(position.PostingNumber)
            AssemblingList.SetValue(Me.ddlSchoolPrincipal, getMyValue(position.PrincipalID))
            hfPrincipalID.Value = getMyValue(position.PrincipalID)
            hfSchoolCode.Value = getMyValue(position.SchoolCode)
            hfPositionType.Value = getMyValue(position.PositionType)
            hfPositionID.Value = getMyValue(position.PositionID)

            ViewState("timeTable") = BasePage.getMyValue(position.TimeTable)
            ViewState("multiSchool") = BasePage.getMyValue(position.MultipleSchool)

            If ViewState("timeTable") = "" Then
                Me.F100TimeTable.Visible = False
            Else
                Me.F100TimeTable.InnerHtml = ViewState("timeTable")
                Me.TextPositionDescription.Style.Add("height", "25px")
            End If

            If ViewState("multiSchool") = "" Then
                Me.F100MultipleSchool.Visible = False
            Else
                Me.F100MultipleSchool.InnerHtml = ViewState("multiSchool")
                Me.TextPositionDescription.Style.Add("height", "25px")
            End If

            Me.interviewCandidate.InnerHtml = GetTeacherList("InterviewCandidate")
            Me.Applicantslist.InnerHtml = GetTeacherList("ApplicantsList")


        Catch ex As Exception

        End Try
    End Sub

    Private Sub BindDDLList()

        Try
            Dim parameter As New List2Item()
            With parameter
                .Operate = "SchoolPrincipal"
                .Para0 = Page.Request.QueryString("SchoolYear")
                .Para1 = Page.Request.QueryString("SchoolCode")
            End With
            AssemblingList.SetLists("", Me.ddlSchoolPrincipal, "SchoolPrincipal", parameter)
            AssemblingList.SetLists("", Me.ddlPositionlevel, "PositionLevel", parameter)

        Catch ex As Exception

        End Try

    End Sub
    'Private Function GetTeacherList(ByVal action As String) As String
    '    Try


    '        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
    '        Dim positionID As String = Page.Request.QueryString("PositionID")
    '        Dim userid As String = HttpContext.Current.User.Identity.Name


    '        Dim parameter As New PositionPublish()
    '        With parameter
    '            .Operate = action
    '            .SchoolYear = schoolyear
    '            .PositionID = positionID
    '            .PositionType = Me.hfPositionType.Value
    '        End With

    '        If User.Identity.Name = "mif" Then
    '            '   Dim SP As String = CommonListExecute(Of CandidateListNotice).ObjSP("CandidateListNotice")
    '            Me.lblInterviewCandidates.ToolTip = SelectCandidateExe.SPName("NoticeCandidates")
    '        End If
    '        Dim teacherList As List(Of CandidateListNotice) = SelectCandidateExe.NoticeCandidates(parameter) ' SelectCandidateExe.NoticeCandidates(parameter) ' CommonListExecute.NoticeInterviewCandidate(parameter) '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)
    '        Dim mySTR As String = ""
    '        Dim interviewSelectColumn As String = ""
    '        '  Dim ds As DataSet = PositionDetails.NoticeToPrincipal(userid, schoolyear, positionID)

    '        If IsNothing(teacherList) AndAlso teacherList.Count = 0 Then
    '            mySTR = "<H3> No selected interview candidate yet ! </H3> "
    '        Else
    '            Dim x As Integer = 0
    '            interviewSelectColumn = IIf(action = "ApplicantsList", "<td>Selected</td>", "")

    '            mySTR = "<table border='1' ><tr><td>Teacher Name</td><td>Phone Number</td> <td>Email</td><td>Hired Date</td><td>Applied Date</td>" + interviewSelectColumn + "</tr>"

    '            Try
    '                For Each item In teacherList
    '                    Dim sName As String = item.TeacherName
    '                    Dim Phone As String = item.CellPhone
    '                    Dim Email As String = item.Email
    '                    Dim HiredDate As String = item.HiredDate
    '                    Dim ApplyDate As String = item.ApplyDate
    '                    Dim selected As String = item.InterViewSelected
    '                    Dim OpenDate As String = item.DateApplyOpen
    '                    Dim CloseDate As String = item.DateApplyClose
    '                    interviewSelectColumn = IIf(action = "ApplicantsList", "<td>" + selected + " </td>", "")
    '                    Dim rStr As String = "<tr><td>" + sName + "</td><td>" + Phone + "</td> <td>" + Email + "</td><td>" + HiredDate + "</td><td>" + ApplyDate + "</td>" + interviewSelectColumn + "</tr>"
    '                    mySTR = mySTR + rStr

    '                Next
    '                mySTR = mySTR + "</table>"

    '            Catch ex As Exception
    '                Return ""
    '            End Try
    '        End If

    '        Return mySTR
    '    Catch ex As Exception
    '        Return "Failed"
    '    End Try
    'End Function
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


        Dim interviewNotice As New InterviewNotice()
        With interviewNotice
            .Operate = "Notice Update" ' "Send Notice ToPrincipal"
            .UserID = User.Identity.Name
            .SchoolYear = Page.Request.QueryString("SchoolYear")
            .PositionID = Me.TextPositionID.Text
            .NoticeDate = AppOperate.DateFC.YMD(Now())
            .PrincipalID = Me.ddlSchoolPrincipal.SelectedValue
            .Comments = Me.TextComments.Text
        End With
        Dim result As String = SelectCandidateExe.NoticeUpdate(interviewNotice) ' CommonOperationExcute.InterviewNotice(interviewNotice, "Send Notice ToPrincipal")
        CreatSaveMessage(result, "Sent interview list email notice To Principal")
        SendinterviewNotification("Notice")
    End Sub
    Private Sub CreatSaveMessage(ByVal strMessage As String, ByVal action As String)
        Try
            ' Dim strScript As String = "window.alert(" + """" + action + " " + strMessage + """);"

            Dim strScript As String = "CallBackReloadParent(" + """" + action + """,""" + strMessage + """);"


            '   window.alert(action + " this position Is " + resutl);
            '  ***  No Ajax
            ClientScript.RegisterStartupScript(GetType(String), "_savemessagescript", strScript, True)

            '  *** AJAX Save Message
            '  ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType, "save_script", strScript.ToString(), True)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub SendinterviewNotification(ByVal action As String)
        Try


            Dim position = CurrentPosition()
            Dim email = New PostingNotification(position)

            Dim userId As String = User.Identity.Name

            Dim myEmail As New EmailNotice2()
            myEmail.EmailType = "Interview Candidate"

            If Me.chbNoticeToPrincipal.Checked Then
                myEmail = email.GetEmailNotice(JsonFile, action, "Principal", userId)
                myEmail.Attachment1 = Server.MapPath("..") + "\Template\HM40.pdf"
                myEmail.Attachment2 = Server.MapPath("..") + "\Template\HM31.pdf"
                myEmail.EmailBody = GetEmailBody("Principal", action, myEmail.EmailBody)

                SMTPMailCall("Principal", myEmail)
            End If

            If Me.chbNoticeToUnion.Checked Then

                myEmail = email.GetEmailNotice(JsonFile, action, "Union", userId)
                myEmail.Attachment1 = Server.MapPath("..") + "\Template\HM40.pdf"
                myEmail.Attachment2 = Server.MapPath("..") + "\Template\HM31.pdf"
                myEmail.EmailBody = GetEmailBody("Union", action, myEmail.EmailBody)

                SMTPMailCall("Union", myEmail)
            End If
        Catch ex As Exception
            CreatSaveMessage("Failed", "Send Email notification")
        End Try

    End Sub
    Private Sub SMTPMailCall(ByVal _who As String, ByVal myEmail As EmailNotice2)
        Try

            Dim LogID As String = EmailNotification.SaveEmailNotice(myEmail)
            Dim result = EmailNotification.SendEmail(myEmail)
        Catch ex As Exception
            Throw New Exception("Mail send failed")
        End Try
    End Sub
    Private Function GetHRContact() As Contact
        Dim jsonFileHRstaff As String = Server.MapPath("..\Content\HRStaff.json")
        Dim contact = WebConfigValue.HRContact(jsonFileHRstaff, GetOwner())
        Return contact
    End Function
    Private Function GetEmailBody(ByVal _who As String, ByVal action As String, ByVal bodyTemplate As String) As String

        Dim HRContact = GetHRContact()
        Dim contact As String = HRContact.Extention

        Dim sDate As DateTime = Now()
        Dim _Datetime As String = sDate.ToString
        Dim appType As String = hfPositionType.Value

        'Dim myEmailTemple = EmailNotification.EmailSubjectAndTemple(JsonFile, appType, action)
        'Dim subject As String = myEmailTemple.Subject
        Dim myHTML As String = Server.MapPath("..") + "\Template\" + bodyTemplate
        Dim eMailFile As String = EmailNotification.EmailHTMLBody(myHTML)

        Try

            eMailFile = Replace(eMailFile, "[PostingNumberSTR]", Me.TextPostingNum.Text)
            eMailFile = Replace(eMailFile, "[DateTimeSTR]", _Datetime)
            eMailFile = Replace(eMailFile, "[SchoolNameSTR]", TextSchool.Text)
            eMailFile = Replace(eMailFile, "[PositionTitleSTR]", TextPositionTitle.Text)
            eMailFile = Replace(eMailFile, "[PositionStartDateSTR]", TextStartDate.Text)
            eMailFile = Replace(eMailFile, "[PositionEndDateSTR]", Me.TextEndDate.Text)
            eMailFile = Replace(eMailFile, "[PositionPostedSTR]", Me.TextPostedDate.Text + " (" + Me.lblPostingCycle.Text + ")")
            eMailFile = Replace(eMailFile, "[BTCSTR]", Me.lblFTE.Text)
            eMailFile = Replace(eMailFile, "[PositionDescriptionSTR]", Me.TextPositionDescription.Text)
            eMailFile = Replace(eMailFile, "[PositionOwnerSTR]", contact)
            eMailFile = Replace(eMailFile, "[PostingCycleSTR]", "") ' Me.lblPostingCycle.Text)
            eMailFile = Replace(eMailFile, "[timeTable]", ViewState("timeTable"))
            eMailFile = Replace(eMailFile, "[multiSchool]", ViewState("multiSchool"))

            Dim TeacherbeReplaceSection As String = ""
            Dim HRComments As String = ""
            Dim GreetingPrinciapl As String = ""
            Dim hrefLink As String = ""
            Dim PostingOpenDate As String = ""
            Dim PostingCloseDate As String = ""
            Dim CanadidateList As String = ""

            If _who = "Principal" Then
                GreetingPrinciapl = "Dear " + ddlSchoolPrincipal.SelectedItem.Text + " :"
                CanadidateList = Me.interviewCandidate.InnerHtml

            Else
                CanadidateList = Me.Applicantslist.InnerHtml
                PostingOpenDate = "* Posting Open Date:" + Me.TextPostedDate.Text
                PostingCloseDate = "* Posting Close Date:" + Me.TextApplyEndDate.Text
            End If

            If appType = "LTO" Then
                TeacherbeReplaceSection = " <tr> <td>Teacher be replaced:</td><td> " + Me.TextTeacherReplaced.Text + " </td>"
                TeacherbeReplaceSection += "<td  style='text-align:right;'>PID: </td> <td> " + Me.TextTeacherPersonID.Text + "</td></tr>"
            End If

            eMailFile = Replace(eMailFile, "[PostingOpenDateSTR]", PostingOpenDate)
            eMailFile = Replace(eMailFile, "[PostingCloseDateSTR]", PostingCloseDate)
            eMailFile = Replace(eMailFile, "[PrincipalNameSTR]", GreetingPrinciapl)
            eMailFile = Replace(eMailFile, "[HRCommentsSTR]", HRComments)
            eMailFile = Replace(eMailFile, "[TeacherBeReplacedSTR]", TeacherbeReplaceSection)
            eMailFile = Replace(eMailFile, "[InterviewCandidateListSTR]", CanadidateList)
            eMailFile = Replace(eMailFile, "[appicationLinkSTR]", hrefLink)

        Catch ex As Exception
            eMailFile = ""
        End Try
        Return eMailFile

    End Function
    Private Function GetTeacherList(ByVal action As String) As String
        Try
            Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
            Dim positionID As String = hfPositionID.Value
            Dim appType As String = hfPositionType.Value

            Return SelectCandidateExe.GetCandidateListTable(action, schoolyear, positionID, appType)

        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private Function GetLink() As String
        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        Dim schoolcode As String = Page.Request.QueryString("SchoolCode")
        Dim positionID As String = Page.Request.QueryString("PositionID")
        Dim appType As String = TextType.Text
        Dim schoolName As String = Replace(TextSchool.Text, "'", "`")
        Dim mobileSite As String = WebConfigValue.getValuebyKey("MobileSiteGo")
        Return "<a href='" + mobileSite + "?pID=InterviewTeam&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID + "&appType=" + appType + "&SchoolName=" + schoolName + "'>" + "Setup Interview team for this job interview" + "</a>"

    End Function

    Private Function GetOwner() As String
        Dim schoolcode As String = Page.Request.QueryString("SchoolCode")
        Dim appType As String = hfPositionType.Value
        Dim owner As String = Me.TextOwner.Text
        Return DataTools.GetPositionOwner(owner, schoolcode, appType)
    End Function
    Private Function CurrentPosition() As PositionPublish

        Dim position = New PositionPublish()
        With position
            .UserID = User.Identity.Name
            .SchoolYear = Page.Request.QueryString("SchoolYear")
            .SchoolCode = hfSchoolCode.Value
            .PostingNumber = Me.TextPostingNum.Text
            .PositionID = hfPositionID.Value
            .PositionType = hfPositionType.Value
            .PositionTitle = Me.TextPositionTitle.Text
            .PositionLevel = ddlPositionlevel.SelectedValue
            .Qualification = ""
            .QualificationCode = ""
            .Description = Me.TextPositionDescription.Text
            .FTE = Me.lblFTE.Text
            .FTEPanel = ""
            .StartDate = DateFC.YMD2(TextStartDate.Text)
            .EndDate = DateFC.YMD2(TextEndDate.Text)
            .DatePublish = DateFC.YMD2(Me.TextPostedDate.Text)
            .DateApplyOpen = DateFC.YMD2(Me.TextPostedDate.Text)
            .DateApplyClose = DateFC.YMD2(Me.TextApplyEndDate.Text)
            .Comments = Me.TextPostingcomments.Text
            .ReplaceTeacherID = Me.TextTeacherPersonID.Text
            .ReplaceTeacher = Me.TextTeacherReplaced.Text
            .ReplaceReason = ""
            .OtherReason = ""
            .Owner = Me.TextOwner.Text
            .PostingCycle = Me.lblPostingCycle.Text
            .PrincipalID = hfPrincipalID.Value
            .PrincipalName = Me.textPrincipal.Text
        End With
        Return position
    End Function

End Class

