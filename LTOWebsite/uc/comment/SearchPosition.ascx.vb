
Imports AppOperate
Imports ClassLibrary

Partial Class SearchPosition
    Inherits System.Web.UI.UserControl

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim searchby As String = "ShortList"
            If Session("ParentPage") = "PublishList" Then searchby = "LongList"
            If Session("ParentPage") = "RequestList" Then searchby = "MidList"
            If Session("ParentPage") = "ConfirmHiringList" Then searchby = "MidList"
            If Session("ParentPage") = "AvailablePositionList" Then searchby = "LongList"
            Dim parameter As New List2Item()
            With parameter
                .Operate = "SearchListType"
                .Para0 = WorkingProfile.SchoolYear
                .Para1 = WorkingProfile.ApplicationType
                .Para2 = searchby
            End With
            Dim JsonFile As String = Server.MapPath("..\Content\appList.json")
            AssemblingList.SetLists(JsonFile, ddlSearchby, "SearchByShort", parameter) ' AssembleListItem.SetListsFromJson(ddlSearchby, "SearchByShort", JsonFile)
            AssemblingList.SetValue(Me.ddlSearchby, "All")
            Me.ddlSearchbyValue.Visible = False
                Me.txtSearchbyValue.Visible = True
            End If

    End Sub
    Protected Sub ddlSearchby_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSearchby.SelectedIndexChanged

        Dim searchby As String = Me.ddlSearchby.SelectedValue
        Dim _UserID As String = HttpContext.Current.User.Identity.Name
        Dim _schoolYear As String = WorkingProfile.SchoolYear

        Dim parameter As New List2Item()
        With parameter
            .Operate = "SearchListType"
            .Para0 = WorkingProfile.SchoolYear
            .Para1 = WorkingProfile.ApplicationType
            .Para2 = searchby
        End With

        Me.ddlSearchbyValue.Visible = True
        Me.txtSearchbyValue.Visible = False
        Me.datepicker.Visible = False
        Me.datepicker2.Visible = False
        Dim JsonFile As String = Server.MapPath("..\Content\appList.json")
        Select Case searchby
            Case "School", "Level", "State", "PendingConfirm"
                AssemblingList.SetLists("", Me.ddlSearchbyValue, searchby, parameter)
                '  AssembleListItem.SetSearchList(Me.ddlSearchbyValue, searchby, _UserID, _schoolYear) '  SetupList.ListDDLSearch(Me.ddlSearchbyValue, searchby, _UserID, _schoolYear)
                Me.ddlSearchbyValue.Visible = True
            Case "Area", "PostingCycle", "PostingState", "Panel"
                '  AssembleListItem.SetListsFromJson(ddlSearchbyValue, searchby, JsonFile)
                AssemblingList.SetLists(JsonFile, ddlSearchbyValue, searchby, parameter)
            Case "PublishDate", "PositionStartDate", "PositionEndDate", "DeadlineDate", "OpenDate", "CloseDate"
                Me.ddlSearchbyValue.Visible = False
                Me.txtSearchbyValue.Visible = False
                Me.SearchDateDIV.Visible = True

                'Me.datepicker.Visible = True
                'If IsDate(WorkingProfile.SearchByValue) Then
                '    Me.datepicker.Value = WorkingProfile.SearchByValue
                'Else
                '    Me.datepicker.Value = DateFC.YMD(Now(), "/") ' DateFC.YMD2(Now())
                'End If


                'Me.datepicker2.Visible = True
                'Me.datepicker2.Value = WorkingProfile.SearchByValue2
                'Me.DateTo.Visible = True

            Case "All"
                Me.ddlSearchbyValue.ClearSelection()
                Me.ddlSearchbyValue.Items.Clear()
                Me.SearchDateDIV.Visible = False
                Me.txtSearchbyValue.Text = ""
                Me.ddlSearchbyValue.Visible = False
                Me.txtSearchbyValue.Visible = True

            Case Else
                Me.ddlSearchbyValue.Visible = False
                Me.ddlSearchbyValue.ClearSelection()
                Me.SearchDateDIV.Visible = False
                Me.txtSearchbyValue.Visible = True

        End Select
    End Sub
End Class
