Imports TCDSB.Student.Data
Imports System.Data.SqlClient
Imports System.Web
Public Class PositionListReport
    Public Shared cPage As Object
    Private _schoolyear As String
    Private _VisitPhase As String

    Public Shared Function PositionTitlebyID(ByVal _Type As String, ByVal _SearchbyValue As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_getPositionProfilebyID"
        Try

            Dim myPara(1) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@Type", DbType.String, 8, _Type)
            setParameterArray(myPara, 1, "@PositionID", DbType.String, 20, _SearchbyValue)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return ""
        End Try
    End Function
    Public Shared Function HiredPositionList(ByVal _schoolyear As String, ByVal _PositionType As String, ByVal _searchBy As String, ByVal _SearchbyValue As String, ByVal _Round4 As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_Report_Position_Hired"
        Try

            Dim myPara(4) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 1, "@PositionType", DbType.String, 10, _PositionType)
            setParameterArray(myPara, 2, "@SearchBy", DbType.String, 20, _searchBy)
            setParameterArray(myPara, 3, "@SearchbyValue", DbType.String, 20, _SearchbyValue)
            setParameterArray(myPara, 4, "@Round4th", DbType.String, 1, _Round4)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function PostedPositionList(ByVal _schoolyear As String, ByVal _PositionType As String, ByVal _Panel As String, ByVal _Status As String, ByVal _searchBy As String, ByVal _SearchbyValue As String, ByVal _SearchbyValue2 As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_Report_Position_Publish"
        Try

            Dim myPara(6) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 1, "@AppType", DbType.String, 10, _PositionType)
            setParameterArray(myPara, 2, "@Panel", DbType.String, 10, _Panel)
            setParameterArray(myPara, 3, "@Status", DbType.String, 10, _Status)
            setParameterArray(myPara, 4, "@SearchBy", DbType.String, 20, _searchBy)
            setParameterArray(myPara, 5, "@SearchValue", DbType.String, 20, _SearchbyValue)
            setParameterArray(myPara, 6, "@SearchValue2", DbType.String, 20, _SearchbyValue2)


            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg. Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function PostedPositionList(ByVal _schoolyear As String, ByVal _PositionType As String, ByVal _Panel As String, ByVal _Status As String, ByVal _searchBy As String, ByVal _SearchbyValue As String, ByVal _SearchbyValue2 As String, ByVal _4thround As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_Report_Position_Publish"
        Try

            Dim myPara(7) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 1, "@AppType", DbType.String, 10, _PositionType)
            setParameterArray(myPara, 2, "@Panel", DbType.String, 10, _Panel)
            setParameterArray(myPara, 3, "@Status", DbType.String, 10, _Status)
            setParameterArray(myPara, 4, "@SearchBy", DbType.String, 20, _searchBy)
            setParameterArray(myPara, 5, "@SearchValue", DbType.String, 20, _SearchbyValue)
            setParameterArray(myPara, 6, "@SearchValue2", DbType.String, 20, _SearchbyValue2)
            setParameterArray(myPara, 7, "@4ThRound", DbType.String, 10, _4thround)


            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function InterViewPositionList(ByVal _schoolyear As String, ByVal _PositionType As String, ByVal _searchBy As String, ByVal _SearchbyValue As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_Report_Position_InterViewer"
        Try

            Dim myPara(3) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 1, "@PositionType", DbType.String, 10, _PositionType)
            setParameterArray(myPara, 2, "@SearchBy", DbType.String, 20, _searchBy)
            setParameterArray(myPara, 3, "@SearchbyValue", DbType.String, 20, _SearchbyValue)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg. Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function

    Public Shared Function InterViewPositionList(ByVal _schoolyear As String, ByVal _PositionType As String, ByVal _searchBy As String, ByVal _SearchbyValue As String, ByVal _Include As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_Report_Position_InterViewer"
        Try

            Dim myPara(4) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 1, "@PositionType", DbType.String, 10, _PositionType)
            setParameterArray(myPara, 2, "@SearchBy", DbType.String, 20, _searchBy)
            setParameterArray(myPara, 3, "@SearchbyValue", DbType.String, 20, _SearchbyValue)
            setParameterArray(myPara, 4, "@Include", DbType.String, 10, _Include)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg. Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
End Class
