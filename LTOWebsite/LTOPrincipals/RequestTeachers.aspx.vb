
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services

'Imports TCDSB.Student
Imports ClassLibrary
Imports AppOperate

Partial Class RequestTeachers
    Inherits System.Web.UI.Page
    Dim myRequestPosting As New PositionRequesting
    Protected myPage As String
    Protected myAppl As String

    Dim SPFile As String = SPSource.SPFile() '  WebConfigValue.SPFile()  '  Server.MapPath("..\Content\DataAccess.json")
    Dim cPage As String = "Request"

    Protected Sub Page_Error(sender As Object, e As EventArgs) Handles Me.Error
        Dim ex As Exception = Server.GetLastError()
        Dim ss As String = sender.ToString()

    End Sub
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
            Me.txtSearch.Text = Page.Request.QueryString("SearchVal")
            InitialPage()
            LoadTeacherList()

        End If
    End Sub
    Private Sub InitialPage()
        Me.Tab1.Visible = False
        Me.Tab2.Visible = False
        Me.Tab3.Visible = False
        Me.Tab4.Visible = False
        Me.Tab1.InnerHtml = "My School"
        Me.Tab2.InnerHtml = "TCDSB"
        Me.Tab3.InnerHtml = ""




        Me.Tab1.Visible = True
        setTabBehaviour(Me.Tab1, "myDIVList_1")
        Me.Tab2.Visible = True
        setTabBehaviour(Me.Tab2, "myDIVList_2")

        'If Page.Request.QueryString("pType") = "Vice Principal" Then
        '    Me.Tab3.Visible = True
        '    setTabBehaviour(Me.Tab3, "myDIVList_3")
        'End If

    End Sub

    Private Sub setTabBehaviour(ByRef myControl As Object, ByVal _page As String)
        myControl.Attributes.Add("onmouseenter", "javascript:setTabMouseEnter(" + myControl.ID + ",'TDFrame2','TDFrame4','" + _page + "')")
        '  myControl.Attributes.Add("onmouseout", "javascript:setTabMouseOut(" + myControl.ID + ",'TDFrame4')")

    End Sub

    Private Sub LoadTeacherList()

        Dim teacherList As List(Of TeachersListByCategory) = getDataSource()

        Try
            Dim mySchoolTecherCount As Integer = 0

            For Each teacher In teacherList
                Select Case teacher.Category
                    Case "mySchool"
                        addDIVElement(Me.myDIVList_1, teacher.UserID, teacher.CPNum, teacher.TeacherName)
                        mySchoolTecherCount = mySchoolTecherCount + 1
                    Case "TCDSB"
                        addDIVElement(Me.myDIVList_2, teacher.UserID, teacher.CPNum, teacher.TeacherName)
                    Case "Other"
                        addDIVElement(Me.myDIVList_3, teacher.UserID, teacher.CPNum, teacher.TeacherName)
                    Case "Type D"
                        addDIVElement(Me.myDIVList_4, teacher.UserID, teacher.CPNum, teacher.TeacherName)

                End Select
            Next

            Me.hfMySchoolTeacherCount.Value = mySchoolTecherCount
            If mySchoolTecherCount = 0 Then
                Me.hfcurrentDiv.Value = "myDIVList_2"
                Me.hfcurrentTab.Value = "Tab2"
            Else
                Me.hfcurrentDiv.Value = "myDIVList_1"
                Me.hfcurrentTab.Value = "Tab1"

            End If
        Catch ex As Exception

            '   ShowMsg.Exception(ex, Me.Page, "Retrieve data action")

        End Try
    End Sub
    Private Sub addDIVElement(ByRef myContainDIV As HtmlGenericControl, ByVal myID As String, ByVal myValue As String, ByVal myText As String)

        Try
            Dim myItemDIV As New HtmlGenericControl
            myItemDIV.ID = myValue
            myItemDIV.Attributes.Add("runat", "server")
            myItemDIV.Attributes.Add("class", "DivOut")
            myItemDIV.Attributes.Add("onclick", "javascript:Subject_ClickHandler()")
            myItemDIV.Attributes.Add("onmouseover", "javascript:setDIV()")
            myItemDIV.Attributes.Add("onmouseout", "javascript:setDIV()")

            myItemDIV.InnerHtml = myText
            myContainDIV.Controls.Add(myItemDIV)
            Dim myBR As New HtmlGenericControl
            myBR.InnerHtml = "<br />"
            myContainDIV.Controls.Add(myBR)
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        hftxtSearch.Value = Me.txtSearch.Text
        LoadTeacherList()
        ' txtSearch.Focus()
        SetSearchFocus()
        'txtSearch.Text = txtSearch.Text
    End Sub

    Private Function getDataSource() As List(Of TeachersListByCategory)


        Dim parameters As ParametersForPositionList = New ParametersForPositionList()
        With parameters
            .Operate = "List"
            .UserID = User.Identity.Name
            .SchoolYear = WorkingProfile.SchoolYear
            .SchoolCode = WorkingProfile.SchoolCode
            .SearchValue1 = Me.txtSearch.Text
        End With
        'Dim SP As String = CommonExcute.SPNameAndParameters(SPFile, cPage, "TeachersList")

        'Return CommonListExecute(Of TeachersListByCategory).GeneralPositions(SP, parameters)

        '  Return RequestPostingExe.TeachersList(parameters)

        Return GeneralExe(Of TeachersListByCategory).myListOfT("TeachersList", parameters)


    End Function

    Private Sub SetSearchFocus()
        Try

            Dim strScript As String = " setSearchFocus();"


            '   window.alert(action + " this position is " + resutl);
            '  ***  No Ajax
            ClientScript.RegisterStartupScript(GetType(String), "_focusscript", strScript, True)

            '  *** AJAX Save Message
            '   ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType, "save_script", strScript.ToString(), True)
        Catch ex As Exception

        End Try

    End Sub

End Class

