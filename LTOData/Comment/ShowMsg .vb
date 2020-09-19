Imports System.Web
Namespace CommonTCDSB
    Public Class ShowMsg
        Private Shared showMethod As String = "Show" 'Message" '"Page"
        Public Shared Sub Exception(ByVal _ex As Exception, ByVal cPage As Object, ByVal ActionType As String)
            Dim show As String = Replace(_ex.Message, "'", " ")
            Select Case showMethod
                Case "Page"
                    WarningMessage(cPage, ActionType + " " + show)
                    ' TCDSB.Student.Exceptions.PublishException(_ex, "Conference")
                Case "Message"
                    WarningMessage(cPage, ActionType + " has error." + show)
                Case Else
                    WarningMessage(cPage, ActionType + " " + show)
            End Select
        End Sub
        Public Shared Sub Message(ByVal cPage As Object, ByVal ActionType As String, ByVal _resoult As String)
            Dim show As String = Replace(_resoult, "'", " ")
            WarningMessage(cPage, ActionType + " " + show)
        End Sub
        Public Shared Sub Help(ByVal _ex As Exception, ByVal cPage As Object, ByVal ActionType As String, ByVal HelpText As String)
            Dim show As String = Replace(_ex.Message, "'", " ")
            Select Case showMethod
                Case "Page"
                    WarningMessage(cPage, ActionType + " " + show)
                    ' TCDSB.Student.Exceptions.PublishException(_ex, "Conference")
                Case "Message"
                    WarningMessage(cPage, ActionType + " has error." + show)
                Case Else
                    WarningMessage(cPage, ActionType + " " + show + " " + HelpText)
            End Select
        End Sub

        Private Shared Sub WarningMessage(ByRef myPage As Object, ByRef msg As String)

            'Dim js As New System.Text.StringBuilder("")

            'js.Append("<Script LANGUAGE='JavaScript'>" & vbCrLf)

            'js.Append("window.alert('" & msg & "');")

            'js.Append("</SCRIPT>")

            ''  Return js.ToString

            'myPage.RegisterClientScriptBlock("OpenWinScript", js.ToString())

            Dim myUrl As String = "<script> window.alert('" & msg & "')</script>"
            myPage.Response.Write(myUrl)   '   Response.Write("<script>window.close()</script>")
        End Sub
        Public Shared Sub CloseMe(ByVal cPage As Object)
            Dim myUrl As String = "<script>window.close()</script>"
            cPage.Response.Write(myUrl)   '   Response.Write("<script>window.close()</script>")
        End Sub
    End Class
End Namespace
 