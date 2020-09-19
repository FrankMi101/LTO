Imports TCDSB.Student.Data
Imports System.Data.SqlClient
Imports System.Web
Public Class Applicant
    Public Shared Function OCTQualification(ByVal userID As String, ByVal CPNum As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantProfile_OCT"
        Try
            Dim myPara(1)
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, userID)
            setParameterArray(myPara, 1, "@CPNum", DbType.String, 10, CPNum)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return ""
        End Try
    End Function
    Public Shared Function Staff_OT_PRNR(ByVal userID As String, ByVal CPNum As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantProfile_OTPRNR"
        Try
            Dim myPara(1)
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, userID)
            setParameterArray(myPara, 1, "@CPNum", DbType.String, 10, CPNum)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return ""
        End Try
    End Function
    Public Shared Function ListSearchByName(ByVal Type As String, ByVal SearchValue As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_RosterLTOSeachbyNameAndCPNum" ' "dbo.tcdsb_LTO_RosterLTOSeachbyName"
        Try
            Dim myPara(1) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@SearchType", DbType.String, 30, Type)
            setParameterArray(myPara, 1, "@SearchValue", DbType.String, 20, SearchValue)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception

            Return Nothing
        End Try
    End Function
    Public Shared Function ListSearchByName(ByVal Type As String, ByVal fName As String, ByVal lName As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantSeachbyName"
        Try
            Dim myPara(2) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@Type", DbType.String, 30, Type)
            setParameterArray(myPara, 1, "@FirstName", DbType.String, 20, fName)
            setParameterArray(myPara, 2, "@LastName", DbType.String, 20, lName)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception

            Return Nothing
        End Try
    End Function
    Public Shared Function NoticeToTeacher(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionNoticeToTeacher"
        Try

            Dim myPara(2) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 20, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception

            Return Nothing
        End Try
    End Function

    Public Shared Function List_AppliedbyPositionID(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _PostCycle As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantList_ApplyPosition"
        Try

            Dim myPara(3) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 10, _PositionID)
            setParameterArray(myPara, 3, "@PostCycle", DbType.String, 1, _PostCycle)
            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, "", _SP)
            Return Nothing
        End Try
    End Function

    Public Shared Function NewUserProfile(ByVal Operate As String, ByVal userID As String, ByVal CPNum As String, ByVal Schoolyear As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_RosterLTOProfileAction"
        Try
            Dim myPara(3)
            setParameterArray(myPara, 0, "@Oprate", DbType.String, 30, Operate)
            setParameterArray(myPara, 1, "@UserID", DbType.String, 30, userID)
            setParameterArray(myPara, 2, "@CPNum", DbType.String, 10, CPNum)
            setParameterArray(myPara, 3, "@SchoolYear", DbType.String, 8, Schoolyear)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception

            Return Nothing
        End Try
    End Function
    Public Shared Function NewUserProfile(ByVal Operate As String, ByVal userID As String, ByVal CPNum As String, ByVal Schoolyear As String, ByVal action As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_RosterLTOProfileAction"
        Try
            Dim myPara(4)
            setParameterArray(myPara, 0, "@Oprate", DbType.String, 30, Operate)
            setParameterArray(myPara, 1, "@UserID", DbType.String, 30, userID)
            setParameterArray(myPara, 2, "@CPNum", DbType.String, 10, CPNum)
            setParameterArray(myPara, 3, "@SchoolYear", DbType.String, 8, Schoolyear)
            setParameterArray(myPara, 4, "@LTOAction", DbType.String, 50, action)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return ""
        End Try
    End Function
End Class
