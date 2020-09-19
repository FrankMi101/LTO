'Imports System.Data
'Imports System.Data.SqlClient
'Imports Microsoft.ApplicationInsights.Telemetry.Services
'Imports TCDSB.Student

Partial Class ApplicantVerification
    Inherits System.Web.UI.Page
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


                Me.Page.Response.Expires = 0
                Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
                Dim ApplyUserID As String = Page.Request.QueryString("ApplyUserID")
                Dim TeacherName As String = Page.Request.QueryString("TeacherName")
                Dim positionID As String = Page.Request.QueryString("PositionID")
                WorkingProfile.UserCPNum = ApplyUserID

                Dim userid As String = HttpContext.Current.User.Identity.Name
                Dim cpnum As String = ApplyUserID
                '***** Add tab menu by programm 
                '   SetupMenu_whenPageLoad()
 
            Catch ex As Exception

            End Try


        End If

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
                    Add_li_Item(myMenu, "155px", "aLinkTabH", "AV3", "Recommend for Hored", "LoadingV.aspx?pID=3")
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


    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Me.SAPProfile.Controls.Add(GetAplicatProfileString("SAP"))
        Me.LTOProfile.Controls.Add(GetAplicatProfileString("LTO"))
    End Sub
    Private Function GetAplicatProfileString(Type As String) As HtmlGenericControl
        Dim myli As HtmlGenericControl = New System.Web.UI.HtmlControls.HtmlGenericControl("li")
        Dim _searchNameF As String = Me.searchFirstName.Text
        Dim _searchNameL As String = Me.searchLastName.Text
        'Dim LTOProfile As DataSet = Applicant.ListSearchByName(Type, _searchNameF, _searchNameL)
        'Dim row As DataRow
        'If Not LTOProfile Is Nothing Then
        '    If LTOProfile.Tables(0).Rows.Count > 0 Then
        '        For Each row In LTOProfile.Tables(0).Rows
        '            myli.Controls.Add(getALink(row.Item(0), row.Item(1), row.Item(2), row.Item(3)))
        '        Next
        '    Else
        '        myli.InnerText = "No Result Return "
        '    End If
        'Else
        '    myli.InnerText = "No Result Return "

        'End If
        Return myli
    End Function
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

