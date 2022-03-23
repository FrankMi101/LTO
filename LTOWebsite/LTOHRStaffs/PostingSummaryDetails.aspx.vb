'Imports System.Data
Imports AppOperate
Imports ClassLibrary
'Imports System.Data.SqlClient
'Imports Microsoft.ApplicationInsights.Telemetry.Services
'Imports TCDSB.Student

Partial Class PostingSummaryDetails
    Inherits System.Web.UI.Page
    Dim JsonFile As String = Server.MapPath("..\Content\appList.json")
    Dim DataAccesssFile As String = "" ' Server.MapPath("..\Content\DataAccess.json")
    Dim cPage As String = "Summary"
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
            Try
                Session("currentDataSet") = Nothing

                Me.Page.Response.Expires = 0
                BindPositionDataandTabmenu()
            Catch ex As Exception

            End Try


        End If

    End Sub
    Private Function getDataSource(ByVal schoolyear As String, ByVal positionID As String) As PositionPublish

        Dim parameter = CommonParameter.GetParameters(schoolyear, positionID)

        Dim SP As String = CommonExcute.SPNameAndParameters(DataAccesssFile, cPage, "Position") '  CommonExcute.SPNameAndParameters(SPFile, cPage, "Position")
        Dim position = PublishPositionExe(Of PositionPublish).Position(parameter) ' CommonExcute(Of PositionPublish).GeneralList(SP, parameter)(0) '  PostingPublishExe.Position(parameter) '  SinglePosition.PostingPosition(parameter) '.PositionByID(parameter)
        Return position(0)

    End Function
    Private Sub BindPositionDataandTabmenu()
        Try
            Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
            Dim positionID As String = Page.Request.QueryString("PositionID")
            Dim position = getDataSource(schoolyear, positionID)


            Me.LabelPostingNumber.Value = BasePage.getMyValue(position.PostingNumber)
            Me.LabelTitle.Value = BasePage.getMyValue(position.PositionTitle)
            Me.LabelSchool.Value = BasePage.getMyValue(position.SchoolName)
            Me.LabelReplace.Value = BasePage.getMyValue(position.ReplaceTeacher)
            Me.LabelFTE.Value = BasePage.getMyValue(position.FTE)

            Me.LabelLevel.Value = BasePage.getMyValue(position.PositionLevel)
            Me.LabelQualification.Value = BasePage.getMyValue(position.Qualification)
            Me.LabelDescription.Value = BasePage.getMyValue(position.Description)
            menu_PR1.Visible = False
            menu_PR2.Visible = False
            menu_PR3.Visible = False
            menu_PR4.Visible = False

            Dim parameter = CommonParameter.GetParameters(schoolyear, positionID)
            ' Dim SP As String = CommonExcute.SPNameAndParameters("Publish", "PostingRound")
            Dim round = PublishPositionExe(Of PositionPublish).PostingRounds(parameter) ' CommonExcute(Of PositionPublish).GeneralList(SP, parameter)
            ' Dim row As DataRow
            Dim x As Int16 = 1
            For Each item In round ' row In ds.Tables(1).Rows
                ' PR1.HRef = "LoadingSub.aspx?schoolyear=" + schoolyear + "&PositionID=" + row.Item(2) + "&Cycle=" + row.Item(3)
                Dim hrefSTR As HtmlAnchor = FindControl("PR" + x.ToString())
                Dim goControl As String = "menu_PR" + x.ToString()
                Dim cycle As String = item.PostingCycle.ToString()
                Dim positionIDSub As String = item.PositionID.ToString()
                If x = 1 Then myContentPageH.Attributes.Add("src", "LoadingSub.aspx?schoolyear=" + schoolyear + "&PositionID=" + positionIDSub + "&Cycle=" + cycle)
                'If x = 2 Then menu_PR2.Visible = True
                'If x = 3 Then menu_PR3.Visible = True
                'If x = 4 Then menu_PR4.Visible = True
                FindControl(goControl).Visible = True
                hrefSTR.HRef = "LoadingSub.aspx?schoolyear=" + schoolyear + "&PositionID=" + positionIDSub + "&Cycle=" + cycle
                x = x + 1
            Next
        Catch ex As Exception
            '   CommonTCDSB.ShowMsg.Exception(ex, Me.Page, "Retrieve data action")
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


    Private Sub SetupMenu_whenPageLoad()
        If Not Page.IsPostBack Then
            Dim goPage As String = Page.Request.QueryString("pID")
            Dim myMenu As HtmlGenericControl = New System.Web.UI.HtmlControls.HtmlGenericControl("ul")
            Me.myMenuDIV.Controls.Add(myMenu)

            Select Case goPage
                Case "Setup_Class"

                    Me.hfPreTitle.Value = "Setup > Class Template >"
                    '   myContentPageH.Attributes.Add("src", "LoadingPage.aspx?pID=TMM_Department_Setup.aspx")
                    Add_li_Item(myMenu, "100px", "aLinkHTabSelected", "CL1", "Class Template", "TMM_Department_Setup.aspx")
                    Add_li_Item(myMenu, "250px", "aLinkHTab", "CL2", "Department Class Weigh", "TMM_DepartmentWeight_Main.aspx")

                Case Else
                    Me.hfPreTitle.Value = ""
                    Add_li_Item(myMenu, "155px", "aLinkTabHS", "AV1", "Applicant Applied Position", "LoadingV.aspx?pID=1")
                    Add_li_Item(myMenu, "155px", "aLinkTabH", "AV2", "Selected Interview Candidate", "LoadingV.aspx?pID=2")
                    Add_li_Item(myMenu, "155px", "aLinkTabH", "AV3", "Recommend For Hored", "LoadingV.aspx?pID=3")
                    Add_li_Item(myMenu, "155px", "aLinkTabH", "AV4", "Applicant Profile", "LoadingV.aspx?pID=4")



            End Select

        End If

    End Sub

    Private Sub Add_li_Item(ByVal my_ul As HtmlGenericControl, ByVal minW As String, ByVal aClass As String, ByVal aID As String, ByVal aText As String, ByVal aHref As String)
        Dim myAlink As HtmlAnchor = New Web.UI.HtmlControls.HtmlAnchor
        myAlink.ID = aID ' "AL1"
        myAlink.InnerText = aText '  
        myAlink.HRef = aHref  ' "LoadingV.aspx?pID=" + aHref
        myAlink.Target = "myContentPageH"
        myAlink.Style.Add("min-width", minW) '"165px")
        myAlink.Attributes.Add("class", aClass) ' "aLinkHTabSelected")

        Dim myli As HtmlGenericControl = New System.Web.UI.HtmlControls.HtmlGenericControl("li")
        myli.Controls.Add(myAlink)
        my_ul.Controls.Add(myli)


        If Right(aID, 1) = "1" Then
            Me.hfPreaLinkID.Value = aID
            ' if loading first page uncommend this line  myContentPageH.Attributes.Add("src", aHref) '  
        End If

    End Sub



    Private Function getALink(ByVal userid As String, ByVal cpnum As String, ByVal name As String, ByVal type As String) As HtmlAnchor
        Dim myAlink As HtmlAnchor = New Web.UI.HtmlControls.HtmlAnchor
        '   myAlink.ID = "P-" + Seq ' "AL1"
        myAlink.InnerText = type + "--" + cpnum + "--" + name
        myAlink.HRef = "javascript:getCPNum('" + cpnum + "')"  ' "LoadingV.aspx?pID=" + aHref
        myAlink.Target = ""
        '  myAlink.Style.Add("min-width", "100px") '"165px")
        Return myAlink
    End Function
End Class

