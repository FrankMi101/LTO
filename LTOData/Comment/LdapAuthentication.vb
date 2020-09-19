Imports System.DirectoryServices
Imports System.Text
Imports System.Web.Configuration
'Namespace TCDSB.Student.BIP
Namespace CommonTCDSB
    Public Class LDAP_Authentication
        Public Shared Function Authenticate(ByVal domain As String, ByVal username As String, ByVal pwd As String)
            Dim _path As String = WebConfigurationManager.AppSettings("LDAP")
            Dim domainAndUsername = domain + "\" + username
            Dim entry As DirectoryEntry = New DirectoryEntry(_path, domainAndUsername, pwd)
            Try
                Dim obj As Object = entry.NativeObject

                Dim search As DirectorySearcher = New DirectorySearcher(entry)

                search.Filter = "(SAMAccountName=" + username + ")"
                search.PropertiesToLoad.Add("cn")

                Dim result As SearchResult = search.FindOne

                If result Is Nothing Then
                    Return False
                End If

                'update the new path to the user in directory
                ' ''_path = result.Path
                ' ''_filterAttribute = CType(result.Properties("cn")(0), String)

            Catch ex As Exception
                Return False ' Throw New Exception("Error authenticating user." + ex.Message)
            End Try

            Return True
        End Function
    End Class
    Public Class LdapAuthentication

        Private _path As String
        Private _filterAttribute As String

        Public Sub New(ByVal path As String)
            _path = path
        End Sub
        'Public Function Authenticate(ByVal _domain As String, ByVal _username As String, ByVal _password As String) As String
        '    Dim auth1 As New AuthenticateWebService.Authenticate
        '    Return auth1.VerifyUser(_domain, _username, _password)
        'End Function


        Public Function IsAuthenticated(ByVal domain As String, ByVal username As String, ByVal pwd As String)
            Dim domainAndUsername = domain + "\" + username
            Dim entry As DirectoryEntry = New DirectoryEntry(_path, domainAndUsername, pwd)

            Try
                Dim obj As Object = entry.NativeObject

                Dim search As DirectorySearcher = New DirectorySearcher(entry)

                search.Filter = "(SAMAccountName=" + username + ")"
                search.PropertiesToLoad.Add("cn")

                Dim result As SearchResult = search.FindOne

                If result Is Nothing Then
                    Return False
                End If

                'update the new path to the user in directory
                _path = result.Path
                _filterAttribute = CType(result.Properties("cn")(0), String)

            Catch ex As Exception
                Throw New Exception("Error authenticating user." + ex.Message)
            End Try

            Return True
        End Function


        Public Function GetGroups() As String
            Dim search As DirectorySearcher = New DirectorySearcher(_path)
            search.Filter = "(cn=" + _filterAttribute + ")"
            search.PropertiesToLoad.Add("memberof")

            'HttpContext.Current.Response.Write(_path)

            Dim groupnames As StringBuilder = New StringBuilder

            Try
                Dim result As SearchResult = search.FindOne

                Dim propertyCount As Integer
                propertyCount = result.Properties("memberOf").Count

                Dim dn As String

                Dim equalsindex, commaindex, i As Integer

                For i = 0 To propertyCount - 1
                    dn = CType(result.Properties("memberof")(i), String)
                    equalsindex = dn.IndexOf("=", 1)
                    commaindex = dn.IndexOf(",", 1)

                    If equalsindex = -1 Then
                        Return ""
                    End If

                    groupnames.Append(dn.Substring((equalsindex + 1), (commaindex - equalsindex) - 1))
                    groupnames.Append("|")
                Next
            Catch ex As Exception
                Throw New Exception("Error obtaining group name." + ex.Message)
            End Try

            Return groupnames.ToString

        End Function


        Public Function GetDispalyName() As String
            Dim displayname As String = ""
            Dim search As DirectorySearcher = New DirectorySearcher(_path)
            search.Filter = "(cn=" + _filterAttribute + ")"
            search.PropertiesToLoad.Add("displayname")

            'HttpContext.Current.Session("Path") = _path

            Try
                Dim result As SearchResult = search.FindOne

                displayname = result.Properties("displayname")(0)
            Catch ex As Exception
                Throw New Exception("Error obtaining group name." + ex.Message)
            End Try

            Return displayname

        End Function

    End Class

End Namespace
'End Namespace
