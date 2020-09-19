Imports TCDSB
Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Mail
Imports System.Web.Configuration
Imports System.Web
Public Class EmailNotification

    Public Shared Function UserProfileByID(ByVal type As String, ByVal userID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_GetUserProfilebyUserID"
        Try
            Dim currentUserID As String = HttpContext.Current.User.Identity.Name

            Dim myPara(1)    ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, userID)
            setParameterArray(myPara, 1, "@Type", DbType.String, 30, type) ' "TCDSBeMailAddress")
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return ""
        End Try
    End Function
    Public Shared Sub SendMail(ByVal Mail_Body As String, ByVal Mail_TO As String, ByVal Mail_CC As String, ByVal Mail_BCC As String, ByVal Mail_From As String, ByVal Mail_Subject As String, ByVal _Mail_Format As String, ByVal Action As String, ByVal userRole As String, ByVal postingNum As String)
        Try
            EMailLog("Mail", Mail_Body, Mail_TO, Mail_CC, Mail_BCC, Mail_From, Mail_Subject, _Mail_Format, Action, userRole, postingNum)
        Catch ex As Exception

        End Try
        Try

            Dim myMail As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient
            myMail.Host = WebConfigurationManager.AppSettings("SMTPServer")
            Dim Mailmsg As New System.Net.Mail.MailMessage
            Mailmsg.To.Clear()
            LoopAddress("eMailTo", Mail_TO, Mailmsg)
            LoopAddress("eMailCC", Mail_CC, Mailmsg)
            LoopAddress("eMailBcc", Mail_BCC, Mailmsg)
            LoopAddress("eMailFrom", Mail_From, Mailmsg)

            Mailmsg.Subject = Mail_Subject
            Mailmsg.Priority = MailPriority.High
            If _Mail_Format = "HTML" Then Mailmsg.IsBodyHtml = True
            Mailmsg.Body = Mail_Body
            Try
                myMail.Send(Mailmsg)
            Catch ex As Exception
                Dim errorMessage As String = ex.Message
            End Try
            Mailmsg.Dispose()

        Catch ex As Exception

        End Try


    End Sub
    Public Shared Sub SendMail(ByVal Mail_Body As String, ByVal Mail_TO As String, ByVal Mail_CC As String, ByVal Mail_BCC As String, ByVal Mail_From As String, ByVal Mail_Subject As String, ByVal _Mail_Format As String, _attachement As String, _attachement2 As String, ByVal Action As String, ByVal userRole As String, ByVal postingNum As String)
        Try
            EMailLog("MailWithAttachment", Mail_Body, Mail_TO, Mail_CC, Mail_BCC, Mail_From, Mail_Subject, _Mail_Format, Action, userRole, postingNum)
        Catch ex As Exception

        End Try
        Try

            Dim myMail As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient
            myMail.Host = WebConfigurationManager.AppSettings("SMTPServer")
            Dim Mailmsg As New System.Net.Mail.MailMessage
            Mailmsg.To.Clear()

            LoopAddress("eMailTo", Mail_TO, Mailmsg)
            LoopAddress("eMailCC", Mail_CC, Mailmsg)
            LoopAddress("eMailBcc", Mail_BCC, Mailmsg)
            LoopAddress("eMailFrom", Mail_From, Mailmsg)

            Mailmsg.Subject = Mail_Subject
            Mailmsg.Priority = MailPriority.High
            If _Mail_Format = "HTML" Then Mailmsg.IsBodyHtml = True
            Mailmsg.Body = Mail_Body
            Dim myAttachment As System.Net.Mail.Attachment
            myAttachment = New System.Net.Mail.Attachment(_attachement)
            Mailmsg.Attachments.Add(myAttachment)
            If Not _attachement2 = "" Then
                myAttachment = New System.Net.Mail.Attachment(_attachement2)
                Mailmsg.Attachments.Add(myAttachment)
            End If
            Try
                myMail.Send(Mailmsg)
            Catch ex As Exception

            End Try
            Mailmsg.Dispose()
        Catch ex As Exception

        End Try



    End Sub

    Private Shared Sub LoopAddress(ByVal aType As String, ByVal address As String, ByRef MailMsg As System.Net.Mail.MailMessage)
        Try
            If address.IndexOf("@") > 0 Then
                If Left(address, 1) = ";" Then
                    address = Mid(address, 2, address.Length)
                End If

                Dim myArray As String() = address.Split(";")
                Dim i As Integer
                For i = 0 To myArray.Length - 1
                    Dim myAdd = myArray(i)
                    Try
                        If myAdd.IndexOf("@") > 0 Then
                            Select Case aType
                                Case "eMailTo"
                                    MailMsg.To.Add(New System.Net.Mail.MailAddress(myAdd))
                                Case "eMailCC"
                                    MailMsg.CC.Add(New System.Net.Mail.MailAddress(myAdd))
                                Case "eMailBcc"
                                    MailMsg.Bcc.Add(New System.Net.Mail.MailAddress(myAdd))
                                Case "eMailFrom"
                                    MailMsg.From = New System.Net.Mail.MailAddress(myAdd)
                                Case Else
                                    MailMsg.From = New System.Net.Mail.MailAddress(myAdd)
                            End Select
                        End If

                    Catch ex As Exception

                    End Try

                    '  MailMsg.To.Add(New System.Net.Mail.MailAddress(myArray(i)))
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    'Public Shared Sub SendMail_old(ByVal Mail_Body As String, ByVal Mail_TO As String, ByVal Mail_CC As String, ByVal Mail_BCC As String, ByVal Mail_From As String, ByVal Mail_Sbject As String, ByVal _Mail_Format As String)
    '    Try

    '        Dim myMail As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient
    '        myMail.Host = WebConfigurationManager.AppSettings("SMTPServer")
    '        Dim Mailmsg As New System.Net.Mail.MailMessage
    '        Mailmsg.To.Clear()

    '        If Mail_TO.IndexOf("@") > 0 Then
    '            If Mail_TO.IndexOf(";") > 0 Then
    '                Dim myarray As String() = Mail_TO.Split(";")
    '                Dim i As Integer
    '                For i = 0 To myarray.Length - 1
    '                    Try
    '                        Mailmsg.To.Add(New System.Net.Mail.MailAddress(myarray(i)))
    '                    Catch ex As Exception

    '                    End Try
    '                Next
    '            Else
    '                Mailmsg.To.Add(New System.Net.Mail.MailAddress(Mail_TO))
    '            End If
    '        End If

    '        ''More than one recipient 
    '        If Mail_CC.IndexOf("@") > 0 Then
    '            If Mail_CC.IndexOf(";") > 0 Then
    '                Dim myarray As String() = Mail_CC.Split(";")
    '                Dim i As Integer
    '                For i = 0 To myarray.Length - 1
    '                    Try
    '                        Mailmsg.CC.Add(New System.Net.Mail.MailAddress(myarray(i)))

    '                    Catch ex As Exception

    '                    End Try
    '                Next
    '            Else
    '                Mailmsg.CC.Add(New System.Net.Mail.MailAddress(Mail_CC))
    '            End If
    '        End If
    '        'Mailmsg.To.Add(New System.Net.Mail.MailAddress(Mail_TO))
    '        'Mailmsg.CC.Add(New System.Net.Mail.MailAddress(Mail_CC))
    '        If Mail_BCC.IndexOf("@") > 0 Then
    '            If Mail_BCC.IndexOf(";") > 0 Then
    '                Dim myarray As String() = Mail_BCC.Split(";")
    '                Dim i As Integer
    '                For i = 0 To myarray.Length - 1
    '                    Try
    '                        Mailmsg.Bcc.Add(New System.Net.Mail.MailAddress(myarray(i)))

    '                    Catch ex As Exception

    '                    End Try
    '                Next
    '            Else
    '                Mailmsg.Bcc.Add(New System.Net.Mail.MailAddress(Mail_BCC))
    '            End If
    '        End If
    '        If Mail_From.IndexOf("@") > 0 Then
    '            Try
    '                Mailmsg.From = New System.Net.Mail.MailAddress(Mail_From)
    '            Catch ex As Exception
    '            End Try
    '        End If
    '        Mailmsg.Subject = Mail_Sbject
    '        Mailmsg.Priority = MailPriority.High
    '        If _Mail_Format = "HTML" Then Mailmsg.IsBodyHtml = True
    '        Mailmsg.Body = Mail_Body
    '        Try
    '            myMail.Send(Mailmsg)
    '        Catch ex As Exception
    '            Dim errorMessage As String = ex.Message

    '        End Try
    '        Mailmsg.Dispose()

    '    Catch ex As Exception

    '    End Try


    'End Sub
    'Public Shared Sub SendMail_old(ByVal Mail_Body As String, ByVal Mail_TO As String, ByVal Mail_CC As String, ByVal Mail_BCC As String, ByVal Mail_From As String, ByVal Mail_Sbject As String, ByVal _Mail_Format As String, _attachement As String, _attachement2 As String)
    '    Try

    '        Dim myMail As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient
    '        myMail.Host = WebConfigurationManager.AppSettings("SMTPServer")
    '        Dim Mailmsg As New System.Net.Mail.MailMessage
    '        Mailmsg.To.Clear()

    '        If Mail_TO.IndexOf("@") > 0 Then
    '            If Mail_TO.IndexOf(";") > 0 Then
    '                Dim myarray As String() = Mail_TO.Split(";")
    '                Dim i As Integer
    '                For i = 0 To myarray.Length - 1
    '                    Try
    '                        Mailmsg.To.Add(New System.Net.Mail.MailAddress(myarray(i)))
    '                    Catch ex As Exception

    '                    End Try
    '                Next
    '            Else
    '                Mailmsg.To.Add(New System.Net.Mail.MailAddress(Mail_TO))
    '            End If
    '        End If

    '        ''More than one recipient 
    '        If Mail_CC.IndexOf("@") > 0 Then
    '            If Mail_CC.IndexOf(";") > 0 Then
    '                Dim myarray As String() = Mail_CC.Split(";")
    '                Dim i As Integer
    '                For i = 0 To myarray.Length - 1
    '                    Try
    '                        Mailmsg.CC.Add(New System.Net.Mail.MailAddress(myarray(i)))

    '                    Catch ex As Exception

    '                    End Try
    '                Next
    '            Else
    '                Mailmsg.CC.Add(New System.Net.Mail.MailAddress(Mail_CC))
    '            End If
    '        End If
    '        'Mailmsg.To.Add(New System.Net.Mail.MailAddress(Mail_TO))
    '        'Mailmsg.CC.Add(New System.Net.Mail.MailAddress(Mail_CC))
    '        If Mail_BCC.IndexOf("@") > 0 Then
    '            If Mail_BCC.IndexOf(";") > 0 Then
    '                Dim myarray As String() = Mail_BCC.Split(";")
    '                Dim i As Integer
    '                For i = 0 To myarray.Length - 1
    '                    Try
    '                        Mailmsg.Bcc.Add(New System.Net.Mail.MailAddress(myarray(i)))

    '                    Catch ex As Exception

    '                    End Try
    '                Next
    '            Else
    '                Mailmsg.Bcc.Add(New System.Net.Mail.MailAddress(Mail_BCC))
    '            End If
    '        End If
    '        If Mail_From.IndexOf("@") > 0 Then
    '            Try
    '                Mailmsg.From = New System.Net.Mail.MailAddress(Mail_From)
    '            Catch ex As Exception
    '            End Try
    '        End If
    '        Mailmsg.Subject = Mail_Sbject
    '        Mailmsg.Priority = MailPriority.High
    '        If _Mail_Format = "HTML" Then Mailmsg.IsBodyHtml = True
    '        Mailmsg.Body = Mail_Body
    '        Dim myAttachment As System.Net.Mail.Attachment
    '        myAttachment = New System.Net.Mail.Attachment(_attachement)
    '        Mailmsg.Attachments.Add(myAttachment)
    '        If Not _attachement2 = "" Then
    '            myAttachment = New System.Net.Mail.Attachment(_attachement2)
    '            Mailmsg.Attachments.Add(myAttachment)
    '        End If
    '        Try
    '            myMail.Send(Mailmsg)
    '        Catch ex As Exception

    '        End Try
    '        Mailmsg.Dispose()
    '    Catch ex As Exception

    '    End Try



    'End Sub

    Public Shared Sub EMailLog(ByVal eType As String, ByVal Mail_Body As String, ByVal Mail_TO As String, ByVal Mail_CC As String, ByVal Mail_BCC As String, ByVal Mail_From As String, ByVal Mail_Subject As String, ByVal Mail_Format As String, ByVal action As String, ByVal userRole As String, ByVal postingNum As String)
        Try

            Dim _SP As String = "dbo.tcdsb_LTO_EmailNotificationLOG"
            Try
                Dim UserID As String = HttpContext.Current.User.Identity.Name

                Dim myPara(11)    ' 
                setParameterArray(myPara, 0, "@UserID", DbType.String, 30, UserID)
                setParameterArray(myPara, 1, "@MailType", DbType.String, 30, eType)
                setParameterArray(myPara, 2, "@MailTo", DbType.String, 100, Mail_TO)
                setParameterArray(myPara, 3, "@MailCC", DbType.String, 100, Mail_CC)
                setParameterArray(myPara, 4, "@MailBcc", DbType.String, 100, Mail_BCC)
                setParameterArray(myPara, 5, "@MailFrom", DbType.String, 30, Mail_From)
                setParameterArray(myPara, 6, "@MailFormat", DbType.String, 30, Mail_Format)
                setParameterArray(myPara, 7, "@MailSubject", DbType.String, 250, Mail_Subject)
                setParameterArray(myPara, 8, "@MailBody", DbType.String, 5000, Mail_Body)
                setParameterArray(myPara, 9, "@Action", DbType.String, 50, action)
                setParameterArray(myPara, 10, "@UserRole", DbType.String, 20, userRole)
                setParameterArray(myPara, 11, "@PositionID", DbType.String, 10, postingNum)

                getMyDataValue(_SP, myPara)
            Catch ex As Exception


            End Try

        Catch ex As Exception

        End Try


    End Sub

End Class
