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


    Private Function getDataSource() As PositionPublish
        Dim userid As String = HttpContext.Current.User.Identity.Name
        Dim schoolcode As String = Page.Request.QueryString("SchoolCode")

        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        Dim positionID As String = Page.Request.QueryString("PositionID")

        Dim parameter = CommonParameter.GetParameters(schoolyear, positionID)
        If User.Identity.Name = "mif" Then
            '  Dim SP As String = CommonListExecute(Of PositionPublish).ObjSP("PositionPublish")
            Me.lblPostingNumber.ToolTip = PublishPositionExe.SpName("Position")
        End If

        Dim position = PublishPositionExe.Position(parameter)(0)  '  CommonListExecute.PublishPosition(parameter)(0) '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)
        Return position

    End Function

    Private Sub bindData()
        Try
            Dim position = getDataSource() '  SinglePosition.PositionByID(parameter)

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
            AssembleListItem.SetValue(Me.ddlPositionlevel, _postionLevel)
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
            AssembleListItem.SetValue(Me.ddlSchoolPrincipal, getMyValue(position.PrincipalID))
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

            Dim teacherList As String = getTeacherList()
            Me.interviewCandidate.InnerHtml = teacherList


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
            AssembleListItem.SetLists(Me.ddlSchoolPrincipal, "SchoolPrincipal", parameter)
            AssembleListItem.SetLists(Me.ddlPositionlevel, "PositionLevel", parameter)

        Catch ex As Exception

        End Try

    End Sub
    Private Function getTeacherList() As String
        Try


            Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
            Dim positionID As String = Page.Request.QueryString("PositionID")
            Dim userid As String = HttpContext.Current.User.Identity.Name


            Dim parameter As New PositionPublish()
            With parameter
                .Operate = "InterviewCandidate"
                .SchoolYear = schoolyear
                .PositionID = positionID
                .PositionType = Me.hfPositionType.Value
            End With

            If User.Identity.Name = "mif" Then
                '   Dim SP As String = CommonListExecute(Of CandidateListNotice).ObjSP("CandidateListNotice")
                Me.lblInterviewCandidates.ToolTip = SelectCandidateExe.SPName("NoticeCandidates")
            End If
            Dim teacherList As List(Of CandidateListNotice) = SelectCandidateExe.NoticeCandidates(parameter) ' SelectCandidateExe.NoticeCandidates(parameter) ' CommonListExecute.NoticeInterviewCandidate(parameter) '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)
            Dim mySTR As String = ""

            '  Dim ds As DataSet = PositionDetails.NoticeToPrincipal(userid, schoolyear, positionID)

            If IsNothing(teacherList) AndAlso teacherList.Count = 0 Then
                mySTR = "<H3> No selected interview candidate yet ! </H3> "
            Else
                Dim x As Integer = 0
                mySTR = "<table border='1' ><tr><td>Teacher Name</td><td>Phone Number</td> <td>Email</td><td>Hired Date</td><td>Applied Date</td></tr>"
                Try
                    For Each item In teacherList
                        Dim sName As String = item.TeacherName
                        Dim Phone As String = item.CellPhone
                        Dim Email As String = item.Email
                        Dim HiredDate As String = item.HiredDate
                        Dim ApplyDate As String = item.ApplyDate
                        Dim rStr As String = "<tr><td>" + sName + "</td><td>" + Phone + "</td> <td>" + Email + "</td><td>" + HiredDate + "</td><td>" + ApplyDate + "</td></tr>"
                        mySTR = mySTR + rStr

                    Next
                    mySTR = mySTR + "</table>"

                Catch ex As Exception
                    Return ""
                End Try
            End If

            Return mySTR
        Catch ex As Exception
            Return "Failed"
        End Try
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


        'Dim positionID As String = Me.TextPositionID.Text
        'Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        'Dim userid As String = HttpContext.Current.User.Identity.Name
        'Dim DateNotice As String = AppOperate.DateFC.YMD(Now())
        'Dim principalID As String = Me.ddlSchoolPrincipal.SelectedValue
        'Dim _result As String = PositionDetails.NoticeToPrincipal(userid, schoolyear, positionID, DateNotice, principalID)

        Dim interviewNotice As New InterviewNotice()
        With interviewNotice
            .Operate = "Notice Update" ' "Send Notice ToPrincipal"
            .UserID = User.Identity.Name
            .SchoolYear = Page.Request.QueryString("SchoolYear")
            .PositionID = Me.TextPositionID.Text
            .NoticeDate = AppOperate.DateFC.YMD(Now())
            .PrincipalID = Me.ddlSchoolPrincipal.SelectedValue
        End With
        Dim result As String = SelectCandidateExe.NoticeUpdate(interviewNotice) ' CommonOperationExcute.InterviewNotice(interviewNotice, "Send Notice ToPrincipal")
        CreatSaveMessage(result, "Sent interview list email notice to Principal")
        sendemailNotification()
    End Sub
    Private Sub CreatSaveMessage(ByVal strMessage As String, ByVal action As String)
        Try
            ' Dim strScript As String = "window.alert(" + """" + action + " " + strMessage + """);"

            Dim strScript As String = "CallBackReloadParent(" + """" + action + """,""" + strMessage + """);"


            '   window.alert(action + " this position is " + resutl);
            '  ***  No Ajax
            ClientScript.RegisterStartupScript(GetType(String), "_savemessagescript", strScript, True)

            '  *** AJAX Save Message
            '  ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType, "save_script", strScript.ToString(), True)

        Catch ex As Exception

        End Try

    End Sub
    Private Function getEmailToList() As String
        Dim EmailToList As String = ""
        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")


        EmailToList = EmailNotification.UserProfileByID("TCDSBeMailAddress", hfPrincipalID.Value)
        EmailToList += EmailNotification.GetMultipleSchoolEmail(schoolyear, hfSchoolCode.Value, hfPositionID.Value)
        'PositionDetails.NoticeToActingPrincipal(Me.hfSchoolyear.Value, Me.hfSchoolCode.Value, Me.hfPositionID.Value)

        Return EmailToList
    End Function

    Private Sub sendemailNotification()
        Dim positiontitle As String = Me.TextPositionTitle.Text
        Dim appType = WorkingProfile.ApplicationType
        Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
        Dim schoolcode As String = Page.Request.QueryString("SchoolCode")
        Dim positionID As String = Page.Request.QueryString("PositionID")
        Dim postingCycle As String = Me.lblPostingCycle.Text


        Dim _mTo As String = getEmailToList()
        Dim _mFrom As String = WebConfigValue.getValuebyKey("eMailSender")
        Dim _mCC As String = WebConfigValue.getValuebyKey("eMailCC")
        _mCC = EmailNotification.CheckCCMailOwner(_mCC, Me.TextOwner.Text, User.Identity.Name)
        _mCC = EmailNotification.CheckCCMail(_mCC, "Principal", "Posting", appType, "1", Me.TextPositionTitle.Text, schoolcode)





        ' *** handle bandler position posting notification
        Dim pOperation As New ParametersForOperation
        With pOperation
            .Operate = "ActingPrincipal"
            .SchoolYear = schoolyear
            .SchoolCode = schoolcode
            .PositionID = positionID
        End With

        _mTo += CommonOperationExcute.ActingPrincipal(pOperation, "ActingPrincipal") '  "; " + PositionDetails.NoticeToActingPrincipal(schoolyear, schoolcode, positionID)
        pOperation.Operate = "MultipleSchoolPrincipal"
        _mCC += CommonOperationExcute.ActingPrincipal(pOperation, "MultipleSchoolPrincipal") ' "; " + PositionDetails.NoticeToPrincipalMultipleSchool(schoolyear, schoolcode, positionID)

        Dim action As String = "Notice"


        Dim myEmailTemple = EmailNotification.EmailSubjectAndTemple(JsonFile, hfPositionType.Value, action)
        Dim mSubject As String = Replace(myEmailTemple.Subject, "PositionTitle", Me.TextPositionTitle.Text) ' EmailNotification.Subject(JsonFile, WorkingProfile.ApplicationType, "Posting")
        Dim mTemplateFile = myEmailTemple.Template '  EmailNotification.Template(JsonFile, WorkingProfile.ApplicationType, "Posting")


        If Me.chbNoticeToPrincipal.Checked Then
            SMTPMailCall("Staff", action, _mTo, _mCC, _mFrom, mSubject, mTemplateFile)

        End If

        If Me.hfPositionType.Value = "LTO" And Me.chbNoticeToUnion.Checked Then
            Dim unioneMail As String = EmailNotification.UnionEmail(hfSchoolCode.Value, hfPositionType.Value)
            If Not unioneMail = "" Then
                _mCC = WebConfigValue.getValuebyKey("eMail_UnionA")
                _mTo = unioneMail
                SMTPMailCall("Union", action, _mTo, _mCC, _mFrom, mSubject, mTemplateFile)
            End If
        End If

    End Sub

    Private Sub SMTPMailCall(ByVal _who As String, ByVal action As String, ByVal _mTO As String, ByVal _mCC As String, ByVal _mFrom As String, ByVal mSubject As String, ByVal mTemplateFile As String)
        Dim _AditionInfo As String = ""
        '  Dim _mSubject As String = "Interview Candidate list for " + TextPositionTitle.Text + " Notification"
        Dim _mBcc As String = WebConfigValue.getValuebyKey("eMailBCC")
        Dim publicFolder As String = WebConfigValue.getValuebyKey("LTOadminFolder")
        _mBcc = _mBcc + publicFolder

        Try
            Dim eMailFileBody As String = getEmailfileHTML(_who, mTemplateFile)
            Dim myEmail As New EmailNotice2()
            With myEmail
                .UserID = User.Identity.Name
                .SchoolYear = Page.Request.QueryString("SchoolYear")
                .SchoolCode = Page.Request.QueryString("SchoolCode")
                .PositionType = Me.TextType.Text
                .PositionID = Page.Request.QueryString("PositionID")
                .PositionTitle = Me.TextPositionTitle.Text
                .PostingNum = Me.TextPostingNum.Text
                .NoticePrincipal = ddlSchoolPrincipal.SelectedItem.Text
                .NoticeFor = _who
                .EmailType = "Interview Candidate"
                .EmailTo = _mTO
                .EmailCC = _mCC
                .EmailBcc = _mBcc
                .EmailFrom = _mFrom
                .EmailSubject = mSubject
                .EmailBody = eMailFileBody
                .EmailFormat = "HTML"
                .Attachment1 = Server.MapPath("..") + "\Template\HM40.pdf"
                .Attachment2 = Server.MapPath("..") + "\Template\HM31.pdf"
                .Attachment3 = ""
            End With


            Dim LogID As String = EmailNotification.SaveEmailNotice(myEmail)
            Dim result = EmailNotification.SendEmail(myEmail)
        Catch ex As Exception

        End Try
    End Sub
    Private Function getEmailfileHTML(ByVal _who As String, ByVal mTemplateFile As String) As String

        '   Dim myHTML As String = "" 'Server.MapPath(".") + "\TPA_Notification.htm"
        Dim JsonFileHRstaff As String = Server.MapPath("..\Content\HRStaff.json")
        Dim contact As String = WebConfigValue.HRContact(JsonFileHRstaff, Me.TextOwner.Text).Extention


        Dim sDate As DateTime = Now()
        Dim _Datetime As String = sDate.ToString

        Dim myHTML As String = Server.MapPath("..") + "\Template\" + mTemplateFile
        Dim eMailFile As String = EmailNotification.EmailHTMLBody(myHTML)

        Try

            eMailFile = Replace(eMailFile, "[PostingNumberSTR]", Me.TextPostingNum.Text)
            eMailFile = Replace(eMailFile, "[PrincipalNameSTR]", ddlSchoolPrincipal.SelectedItem.Text)
            eMailFile = Replace(eMailFile, "[DateTimeSTR]", _Datetime)
            eMailFile = Replace(eMailFile, "[SchoolNameSTR]", TextSchool.Text)
            eMailFile = Replace(eMailFile, "[PositionTitleSTR]", TextPositionTitle.Text)
            eMailFile = Replace(eMailFile, "[PositionStartDateSTR]", TextStartDate.Text)
            eMailFile = Replace(eMailFile, "[PositionEndDateSTR]", Me.TextEndDate.Text)
            eMailFile = Replace(eMailFile, "[InterviewCandidateListSTR]", Me.interviewCandidate.InnerHtml)
            eMailFile = Replace(eMailFile, "[PositionPostedSTR]", Me.TextPostedDate.Text + " (" + Me.lblPostingCycle.Text + ")")
            eMailFile = Replace(eMailFile, "[BTCSTR]", Me.lblFTE.Text)
            eMailFile = Replace(eMailFile, "[PositionDescriptionSTR]", Me.TextPositionDescription.Text)
            eMailFile = Replace(eMailFile, "[PositionOwnerSTR]", contact)
            eMailFile = Replace(eMailFile, "[PostingCycleSTR]", Me.lblPostingCycle.Text)
            eMailFile = Replace(eMailFile, "[timeTable]", ViewState("timeTable"))
            eMailFile = Replace(eMailFile, "[multiSchool]", ViewState("multiSchool"))

            Dim TeacherbeReplaceSection As String = ""
            Dim hrefLink As String = ""

            If _who = "Staff" Then

                TeacherbeReplaceSection = " <tr> <td>Teacher be replaced:</td><td> " + Me.TextTeacherReplaced.Text + " </td>"
                TeacherbeReplaceSection += "<td  style='text-align:right;'>PID: </td> <td> " + Me.TextTeacherPersonID.Text + "</td></tr>"

                Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
                Dim schoolcode As String = Page.Request.QueryString("SchoolCode")
                Dim positionID As String = Page.Request.QueryString("PositionID")
                Dim appType As String = TextType.Text
                Dim schoolName As String = Replace(TextSchool.Text, "'", "`")
                Dim mobileSite As String = WebConfigValue.getValuebyKey("MobileSiteGo")
                hrefLink = "<a href='" + mobileSite + "?pID=InterviewTeam&SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&PositionID=" + positionID + "&appType=" + appType + "&SchoolName=" + schoolName + "'>" + "Setup Interview team for this job interview" + "</a>"

            End If
            eMailFile = Replace(eMailFile, "[TeacherBeReplacedSTR]", TeacherbeReplaceSection)
            eMailFile = Replace(eMailFile, "[appicationLinkSTR]", hrefLink)

        Catch ex As Exception
            eMailFile = ""
        End Try
        Return eMailFile

    End Function

End Class

