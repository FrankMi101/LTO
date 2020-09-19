'Imports TCDSB.Student
Imports AppOperate

Partial Class NoOpenPositionAvailable
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.Page.Response.Expires = 0
            '  Dim _goPage As String = Page.Request.QueryString("goPage")

            Dim appID As String = WorkingProfile.ApplicationType

            Dim tDate As Date = Date.Today
            Dim sDate As Date = WebConfigValue.getValuebyKey("AppStartDate")
            Dim sDateLTO As Date = WebConfigValue.getValuebyKey("AppStartDateLTO")
            Dim sDatePOP As Date = WebConfigValue.getValuebyKey("AppStartDatePOP")
            Me.Labelschoolyear1.Text = WorkingProfile.SchoolYear
            Me.Labelschoolyear2.Text = WorkingProfile.SchoolYear
            LabelDate1.Text = sDateLTO.ToString("D")
            Labelyear1.Text = Left(WorkingProfile.SchoolYear, 4)
            If (appID Is Nothing Or appID = "undefind") Then
                MessageLTOPOP.Visible = True
            Else
                If appID = "LTO" Then
                    If tDate < sDateLTO Then
                        Me.MessageLTO4.Visible = True
                    Else
                        If WorkingProfile.UserRole = "Roster" Then
                            Me.MessageLTO3.Visible = True
                        Else
                            MessageLTO.Visible = True
                        End If
                    End If
                Else
                    If tDate < sDatePOP Then
                        Me.MessagePOP4.Visible = True
                    Else
                        If WorkingProfile.UserRole = "Roster" Then
                            Me.MessagePOP3.Visible = True
                        Else
                            MessagePOP.Visible = True
                        End If

                    End If

                End If
            End If

        End If


    End Sub
End Class
