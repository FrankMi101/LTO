Imports AppOperate
Partial Class LoadingT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.Page.Response.Expires = 0
            Dim pID As String = GetValueFromQS("pID") ' Page.Request.QueryString("pID")

            Dim appID As String = WorkingProfile.ApplicationType




            Dim appModel As String = WebConfigValue.getValuebyKey("ApplicationModel")
            If WorkingProfile.LoginRole = "Admin" Then
                LoadPage(pID)
            Else
                If appModel = "Production" Then
                    If Session("ApplicationEntry") = "NotSP" Then
                        Me.PageURL.HRef = "LoadingNotfromSP.aspx"
                    Else
                        LoadPage(pID)
                    End If
                Else
                    LoadPage(pID)
                End If



            End If

        End If
    End Sub
    Private Sub LoadPage(pID As String)
        Dim cpNum As String = Page.Request.QueryString("CPNum")
        If WebConfigValue.getValuebyKey("SiteClose") = "LTO" Then
            pID = "A"
        End If
        If WorkingProfile.UserRole = "New" Then
            Me.PageURL.HRef = "LoadingNotInLTOList.aspx"
        Else
            Dim schoolyear As String = GetValueFromQS("SchoolYear")  ' Page.Request.QueryString("SchoolYear")
            Dim schoolcode As String = GetValueFromQS("SchoolCode")  'Page.Request.QueryString("SchoolCode")
            Dim positionID As String = GetValueFromQS("PositionID")  'Page.Request.QueryString("PositionID")
            Dim schoolname As String = GetValueFromQS("SchoolName")  'Page.Request.QueryString("SchoolName")

            If pID = "1" Then
                Me.PageURL.HRef = "ApplyPosition.aspx?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&SchoolName=" + schoolname + "&PositionID=" + positionID
            ElseIf pID = "2" Then
                Me.PageURL.HRef = "SchoolLocationMap.aspx?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&SchoolName=" + schoolname + "&PositionID=" + positionID
            ElseIf pID = "3" Then
                If WorkingProfile.UserRole = "Pending" Then
                    Me.PageURL.HRef = "LoadingPending.aspx"
                Else
                    Me.PageURL.HRef = "ApplyPositionList2.aspx?CPNum=" + cpNum
                End If
            ElseIf pID = "4" Then
                Me.PageURL.HRef = "ApplyPositionList2Applied.aspx?CPNum=" + cpNum
            ElseIf pID = "5" Then
                Me.PageURL.HRef = "ApplyProfile.aspx"
            ElseIf pID = "9" Then
                Me.PageURL.HRef = "NoOpenPositionAvailable.aspx"
            Else
                Me.PageURL.HRef = "SiteClose.aspx"

            End If
        End If

    End Sub
    Private Function GetValueFromQS(ByVal key As String) As String
        Return BasePage.GetValueFromQS(Page, key)
    End Function
End Class
