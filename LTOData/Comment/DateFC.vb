'Namespace TCDSB.Student.BIP
'    Namespace Common
Public Class DateFC
    Public Shared Function Format(ByVal vDate As Date, ByVal vFormat As String) As String
        Try
            Dim rValue As String
            If Not vDate = "" Then
                Dim oDate As Date = vDate
                If IsDate(oDate) Then
                    Dim vYY As String = Year(oDate)
                    Dim vMM As String = Month(oDate)
                    Dim vDD As String = Day(oDate)
                    If vMM < 10 Then vMM = "0" + Trim(vMM)
                    If vDD < 10 Then vDD = "0" + Trim(vDD)
                    Select Case vFormat
                        Case "YYYYMMDD"
                            rValue = vYY + "/" + vMM + "/" + vDD
                        Case "DDMMYYYYY"
                            rValue = vDD + "/" + vMM + "/" + vYY
                        Case "MMDDYYYY"
                            rValue = vMM + "/" + vDD + "/" + vYY
                        Case Else
                            rValue = oDate
                    End Select
                Else
                    rValue = oDate
                End If
            Else
                rValue = vDate
            End If
            Return rValue
        Catch ex As Exception
            Return ""
        End Try

    End Function
    Public Shared Function YMD(ByVal vDate) As String
        Try
            '   If vDate Is Nothing Then vDate = ""
            If IsDBNull(vDate) Then
                Return ""
            Else
                Dim oDate As Date = vDate
                Dim vYY As String = Year(oDate)
                Dim vMM As String = Month(oDate)
                Dim vDD As String = Day(oDate)
                If vMM < 10 Then vMM = "0" + Trim(vMM)
                If vDD < 10 Then vDD = "0" + Trim(vDD)
                Return vYY + "/" + vMM + "/" + vDD
            End If
        Catch ex As Exception
            Return ""
            'Throw New Exception
        End Try
    End Function
    Public Shared Function YMD2(ByVal vDate) As String
        Try
            '   If vDate Is Nothing Then vDate = ""
            If IsDBNull(vDate) Then
                Return ""
            Else
                Dim oDate As Date = vDate
                Dim vYY As String = Year(oDate)
                Dim vMM As String = Month(oDate)
                Dim vDD As String = Day(oDate)
                If vMM < 10 Then vMM = "0" + Trim(vMM)
                If vDD < 10 Then vDD = "0" + Trim(vDD)
                Return vYY + "-" + vMM + "-" + vDD
            End If
        Catch ex As Exception
            Return ""
            'Throw New Exception
        End Try
    End Function
    Public Shared Function DMY(ByVal vDate As String) As String
        Try
            If Not vDate = "" Then
                Dim oDate As Date = vDate
                Dim vYY As String = Year(oDate)
                Dim vMM As String = Month(oDate)
                Dim vDD As String = Day(oDate)
                If vMM < 10 Then vMM = "0" + Trim(vMM)
                If vDD < 10 Then vDD = "0" + Trim(vDD)
                Return vDD + "/" + vMM + "/" + vYY
            Else
                Return (vDate)
            End If
        Catch ex As Exception
            Return ""
        End Try

    End Function
    Public Shared Function MDY(ByVal vDate As String) As String
        Try
            If Not vDate = "" Then
                Dim oDate As Date = vDate
                Dim vYY As String = Year(oDate)
                Dim vMM As String = Month(oDate)
                Dim vDD As String = Day(oDate)
                If vMM < 10 Then vMM = "0" + Trim(vMM)
                If vDD < 10 Then vDD = "0" + Trim(vDD)
                Return vMM + "/" + vDD + "/" + vYY
            Else
                Return (vDate)
            End If
        Catch ex As Exception
            Return vDate
        End Try
    End Function
    Public Shared Function ChkNull(ByVal _obj As Object) As String
        If IsDBNull(_obj) Then
            Return ""
        Else
            Return _obj
        End If
    End Function
    Public Shared Function MMMDDYY(ByVal vDate As String) As String
        Try
            If Not vDate = "" Then
                Dim oDate As Date = vDate
                Dim vYY As String = Year(oDate)
                Dim vMM As String = MonthName(Month(oDate))
                Dim vDD As String = Day(oDate)
                ' If vMM < 10 Then vMM = "0" + Trim(vMM)
                If vDD < 10 Then vDD = "0" + Trim(vDD)
                Return vMM & " " + vDD & ", " & vYY
            Else
                Return (vDate)
            End If
        Catch ex As Exception
            Return ""
        End Try

    End Function

End Class
Public Class AppraisalSchoolYear
    Public Shared Function ApprasialYear(ByVal _currentSchoolYear As String) As String
        Dim rValue As String = _currentSchoolYear
        Dim perYear As Integer = CType(Left(_currentSchoolYear, 4), Integer) - 1
        rValue = CType(perYear, String) + Left(_currentSchoolYear, 4)
        Return rValue
    End Function
End Class
Public Class SchoolYearDefaultDate
    Public Shared Function StartDate(ByVal AppType As String, ByVal schoolyear As String) As String

        Dim _SP As String = "dbo.tcdsb_LTO_getSchoolYearDate"
        Try
            Dim myPara(2) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@AppType", DbType.String, 10, AppType)
            setParameterArray(myPara, 1, "@DateType", DbType.String, 10, "Start")
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, schoolyear)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            Return Date.Now()
        End Try

    End Function
    Public Shared Function EndDate(ByVal AppType As String, ByVal schoolyear As String) As String

        Dim _SP As String = "dbo.tcdsb_LTO_getSchoolYearDate"
        Try
            Dim myPara(2) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@AppType", DbType.String, 10, AppType)
            setParameterArray(myPara, 1, "@DateType", DbType.String, 10, "End")
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, schoolyear)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            Return Date.Now()
        End Try

    End Function
    Public Shared Function Publish(ByVal AppType As String, ByVal schoolyear As String) As String

        Dim _SP As String = "dbo.tcdsb_LTO_getSchoolYearDate"
        Try
            Dim myPara(2) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@AppType", DbType.String, 10, AppType)
            setParameterArray(myPara, 1, "@DateType", DbType.String, 10, "Publish")
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, schoolyear)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            Return Date.Now()
        End Try

    End Function
    Public Shared Function Deadline(ByVal AppType As String, ByVal schoolyear As String) As String

        Dim _SP As String = "dbo.tcdsb_LTO_getSchoolYearDate"
        Try
            Dim myPara(2) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@AppType", DbType.String, 10, AppType)
            setParameterArray(myPara, 1, "@DateType", DbType.String, 10, "Deadline")
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, schoolyear)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            Return Date.Now()
        End Try

    End Function

End Class
Public Class GetSchoolYear
    Public Shared Function YearCurrent(ByVal _schoolyear As String) As String
        Return _schoolyear
    End Function
    Public Shared Function YearNext(ByVal _schoolyear As String) As String
        Dim rValue = _schoolyear
        Dim nextYear As Integer = CType(Right(_schoolyear, 4), Integer) + 1
        rValue = Right(_schoolyear, 4) + CType(nextYear, String)
        Return rValue
 
    End Function
    Public Shared Function YearPrevious(ByVal _schoolyear As String) As String
        Dim rValue = _schoolyear
        Dim perYear As Integer = CType(Left(_schoolyear, 4), Integer) - 1
        rValue = CType(perYear, String) + Left(_schoolyear, 4)
        Return rValue
    End Function
End Class
'    End Namespace
'End Namespace