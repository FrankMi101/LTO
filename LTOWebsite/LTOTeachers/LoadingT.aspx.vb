Imports AppOperate
Partial Class LoadingT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.Page.Response.Expires = 0
            Dim pID As String = Page.Request.QueryString("pID")
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
        If WebConfigValue.getValuebyKey("SiteClose") = "LTO" Then
            pID = "A"

        End If
        If WorkingProfile.UserRole = "New" Then
            Me.PageURL.HRef = "LoadingNotInLTOList.aspx"
        Else
            If pID = "1" Then
                Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
                Dim schoolcode As String = Page.Request.QueryString("SchoolCode")
                Dim positionID As String = Page.Request.QueryString("PositionID")
                Dim schoolname As String = Page.Request.QueryString("SchoolName")
                Me.PageURL.HRef = "ApplyPosition.aspx?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&SchoolName=" + schoolname + "&PositionID=" + positionID
            ElseIf pID = "2" Then
                Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
                Dim schoolcode As String = Page.Request.QueryString("SchoolCode")
                Dim positionID As String = Page.Request.QueryString("PositionID")
                Dim schoolname As String = Page.Request.QueryString("SchoolName")
                Me.PageURL.HRef = "SchoolLocationMap.aspx?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&SchoolName=" + schoolname + "&PositionID=" + positionID
            ElseIf pID = "3" Then
                If WorkingProfile.UserRole = "Pending" Then
                    Me.PageURL.HRef = "LoadingPending.aspx"
                Else
                    Me.PageURL.HRef = "ApplyPositionList2.aspx"
                End If
            ElseIf pID = "4" Then
                Me.PageURL.HRef = "ApplyPositionList2Applied.aspx"
            ElseIf pID = "5" Then
                Me.PageURL.HRef = "ApplyProfile.aspx"
            ElseIf pID = "9" Then
                Me.PageURL.HRef = "NoOpenPositionAvailable.aspx"
            Else
                Me.PageURL.HRef = "SiteClose.aspx"

            End If
        End If

    End Sub
End Class
