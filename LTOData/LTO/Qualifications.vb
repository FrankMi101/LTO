Imports TCDSB.Student.Data
Imports System.Data.SqlClient
Imports System.Web


Public Class Qualifications
    Private _SchoolYear As String
    Private _VisitPhase As String
    Private _QuestionID As String
    Private _QuestionType As String
    Public Shared cPage As Object
    Public Shared Function Qualification_Person(ByVal _schoolyear As String, ByVal _schoolcode As String, ByVal _cpNum As String, ByVal _QualType As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_Qualification_Person"
        Try
            Dim myPara(3) '' As tpaWS.MyParameter
            setParameterArray(myPara, 0, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 1, "@SchoolCode", DbType.String, 8, _schoolcode)
            setParameterArray(myPara, 2, "@cpNum", DbType.String, 10, _cpNum)
            setParameterArray(myPara, 3, "@QualType", DbType.String, 50, _QualType)
            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception

            Return Nothing
        End Try
    End Function
    Public Shared Function Qualification_Position(ByVal _UserID As String, ByVal _assignmentID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_Qualification_Position"
        Try
            Dim myPara(1) '' As tpaWS.MyParameter
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@AssignmentID", DbType.String, 10, _assignmentID)
            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception

            Return Nothing
        End Try
    End Function

    Public Shared Function QualificationString(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolcode As String, ByVal _PositionID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_QualificationsbyPosition"
        Try
            Dim myPara(3) '' As tpaWS.MyParameter
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@SchoolCode", DbType.String, 8, _schoolcode)
            setParameterArray(myPara, 3, "@PositionID", DbType.String, 10, _PositionID)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Shared Sub Qualification_Update(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolcode As String, ByVal _PositionID As String)
        Dim _SP As String = "dbo.tcdsb_LTO_QualificationMovebyPositionID"
        Try
            Dim myPara(3) '' As tpaWS.MyParameter
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@SchoolCode", DbType.String, 8, _schoolcode)
            setParameterArray(myPara, 3, "@PositionID", DbType.String, 10, _PositionID)
            getMyDataSet(_SP, myPara)
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Function Qualification_List(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolcode As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_QualificationSelectdList2"
        Try
            Dim myPara(3) '' As tpaWS.MyParameter
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@SchoolCode", DbType.String, 8, _schoolcode)
            setParameterArray(myPara, 3, "@PositionID", DbType.String, 10, _PositionID)
            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Shared Function Qualification_List(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolcode As String, ByVal _PositionID As String, ByVal _SourceID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_QualificationSelectdList2"
        Try
            Dim myPara(4) '' As tpaWS.MyParameter
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@SchoolCode", DbType.String, 8, _schoolcode)
            setParameterArray(myPara, 3, "@PositionID", DbType.String, 10, _PositionID)
            setParameterArray(myPara, 4, "@SourceID", DbType.String, 10, _SourceID)
            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Shared Function Qualification_List(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolcode As String, ByVal _PositionID As String, ByVal _SourceID As String, ByVal _Qualcode As String, ByVal _Checked As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_QualificationSelectdList2"
        Try
            Dim myPara(6) '' As tpaWS.MyParameter
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@SchoolCode", DbType.String, 8, _schoolcode)
            setParameterArray(myPara, 3, "@PositionID", DbType.String, 10, _PositionID)
            setParameterArray(myPara, 4, "@SourceID", DbType.String, 10, _SourceID)
            setParameterArray(myPara, 5, "@QualCode", DbType.String, 10, _Qualcode)
            setParameterArray(myPara, 6, "@Checked", DbType.String, 10, _Checked)
            Return getMyDataValue(_SP, myPara)



        Catch ex As Exception
            Return ""

        End Try
    End Function

End Class
