Imports System.DirectoryServices
Imports System.Text
Imports System.Web.Configuration
Public Class LoginIdentify
    Public Sub New()

    End Sub

    Public Shared Function ApplicantProfile(ByVal _UserID As String, ByVal _CPNum As String,
                                        ByVal _SchoolYear As String) As DataSet
        Try
            Dim _SP As String = "dbo.tcdsb_LTO_ApplicantProfile_Contact"
            Dim myPara(2)
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@CPNum", DbType.String, 10, _CPNum)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _SchoolYear)
            Return getMyDataSet(_SP, myPara)

        Catch ex As Exception

            Return Nothing
        End Try
    End Function
    Public Shared Sub ApplicantProfileSave(ByVal _UserID As String, ByVal _CPNum As String, _
                                      ByVal _SchoolYear As String, _
                                      ByVal _HomePhone As String, _
                                      ByVal _CellPhone As String, _
                                      ByVal _Email As String, _
                                      ByVal _comments As String)
        Try
            Dim _SP As String = "dbo.tcdsb_LTO_ApplicantProfile_contact"
            Dim myPara(6)
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@CPNum", DbType.String, 10, _CPNum)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _SchoolYear)
            setParameterArray(myPara, 3, "@HomePhone", DbType.String, 20, _HomePhone)
            setParameterArray(myPara, 4, "@CellPhone", DbType.String, 20, _CellPhone)
            setParameterArray(myPara, 5, "@Email", DbType.String, 30, _Email)
            setParameterArray(myPara, 6, "@Comment", DbType.String, 500, _comments)
            getMyDataValue(_SP, myPara)

        Catch ex As Exception


        End Try
    End Sub
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
    Public Shared Sub LoginParameter(ByVal _LoginUserID As String, _
                                         ByVal _LoginServer As String, _
                                         ByVal _ScreenSize As String, _
                                         ByVal _WorkRole As String, _
                                         ByVal _WorkYear As String, _
                                         ByVal _OnLine As String, _
                                         ByVal _Browse As String)
        Try
            Dim _SP As String = "dbo.tcdsb_LTO_Track_ProfileLoginParameter"
            Dim myPara(6)

            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _LoginUserID)
            setParameterArray(myPara, 1, "@LoginServer", DbType.String, 20, _LoginServer)
            setParameterArray(myPara, 2, "@ScreenSize", DbType.String, 20, _ScreenSize)
            setParameterArray(myPara, 3, "@WorkRole", DbType.String, 20, _WorkRole)
            setParameterArray(myPara, 4, "@WorkYear", DbType.String, 8, _WorkYear)
            setParameterArray(myPara, 5, "@OnLine", DbType.String, 10, _OnLine)
            setParameterArray(myPara, 6, "@Browse", DbType.String, 20, _Browse)
            getMyDataValue(_SP, myPara)

        Catch ex As Exception


        End Try
    End Sub
    Public Shared Sub UserActionTrack(ByVal _UserID As String, _
                                         ByVal _UserRole As String, _
                                         ByVal _SchoolYear As String, _
                                         ByVal _SchoolCode As String, _
                                         ByVal _WorkingPhase As String, _
                                         ByVal _WorkingType As String, _
                                         ByVal _WorkingArea As String, _
                                         ByVal _GQID As String, _
                                         ByVal _GoalID As String, _
                                         ByVal _UserAction As String, _
                                         ByVal _PageAction As String)
        Try
            Dim _SP As String = "dbo.tcdsb_LTO_Track_UserAction"
            Dim myPara(6)

            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@LoginServer", DbType.String, 20, _UserRole)
            setParameterArray(myPara, 2, "@ScreenSize", DbType.String, 20, _SchoolYear)
            setParameterArray(myPara, 3, "@WorkRole", DbType.String, 20, _SchoolCode)
            setParameterArray(myPara, 4, "@WorkYear", DbType.String, 8, _WorkingPhase)
            setParameterArray(myPara, 5, "@OnLine", DbType.String, 10, _WorkingType)
            setParameterArray(myPara, 6, "@Browse", DbType.String, 20, _WorkingArea)
            getMyDataValue(_SP, myPara)

        Catch ex As Exception


        End Try
    End Sub
    Public Shared Function WorkingTask(ByVal _UserID As String, ByVal _applID As String,
                                        ByVal _SchoolYear As String, ByVal _TaskType As String) As String
        Try
            Dim _SP As String = "dbo.tcdsb_LTO_TaskAccount"
            Dim myPara(3)
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@ApplID", DbType.String, 10, _applID)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _SchoolYear)
            setParameterArray(myPara, 3, "@TaskType", DbType.String, 20, _TaskType)
            Return getMyDataValue(_SP, myPara)

        Catch ex As Exception

            Return Nothing
        End Try
    End Function

End Class
