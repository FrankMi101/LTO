Imports System.Data.SqlClient
Imports TCDSB.Student.Data
Public Class SetupData
    'Public Shared Sub setParameterArray(ByVal _ParaArray() As Object, ByVal X As Integer, ByVal _Name As String, ByVal _Type As System.Data.DbType, ByVal _Leng As Integer, ByVal _Value As String)
    '    Try

    '        '**************** This black is using Web services get data*******************************
    '        '_ParaArray(X) = New DataAccessWebService.MyParameter
    '        ' ****************Base classs get data************************************************
    '        _ParaArray(X) = New TCDSB.Student.Data.MyParameter  ' may 2 

    '        _ParaArray(X).pName = _Name
    '        _ParaArray(X).pType = _Type
    '        _ParaArray(X).pLeng = _Leng
    '        _ParaArray(X).pValue = _Value
    '    Catch ex As Exception
    '        Dim exMsg As String = ex.Message
    '    End Try
    'End Sub
    'Public Shared Function getMyDataSet(ByVal _sp As String, ByRef mypara1 As Object) As DataSet
    '    Try
    '        '**************** This black is using Web services get data*******************************
    '        ' Dim ws1 As New DataAccessWebService.DataWS '  DataAccessWebService2.DataWS
    '        'Return ws1.WSDataSet(_sp, mypara1)
    '        ' ****************Base classs get data************************************************
    '        Return TCDSB.Student.Data.myDataSetA(_sp, mypara1)
    '    Catch ex As Exception
    '        Dim sr As String = ex.Message
    '        Return Nothing
    '    End Try
    'End Function
    'Public Shared Function getMyDataValue(ByVal _sp As String, ByRef mypara1 As Object) As String
    '    Try
    '        '**************** This black is using Web services get data*******************************
    '        'Dim ws1 As New DataAccessWebService.DataWS
    '        'Return ws1.WSValue(_sp, mypara1)
    '        ' ****************Base classs get data************************************************
    '        Return TCDSB.Student.Data.myValueA(_sp, mypara1)
    '    Catch ex As Exception
    '        Dim sr As String = ex.Message
    '        Return ""
    '    End Try
    'End Function
    Public Shared Property myDBConStr() As String
        Get
            Return TCDSB.Student.Data.dbConnectionSTR '    SC.TCBase.dbConnectionSTR
        End Get
        Set(ByVal Value As String)
            TCDSB.Student.Data.dbConnectionSTR = Value
        End Set
    End Property
    Public Shared Property myApplication() As String
        Get
            Return TCDSB.Student.Data.applicationName
        End Get
        Set(ByVal Value As String)
            TCDSB.Student.Data.applicationName = Value
        End Set
    End Property
    Public Shared ReadOnly Property myPagePermission(ByVal _user As String, ByVal _appl As String, ByVal _page As String) As String
        Get
            Return TCDSB.Student.Security.PagePermission(_user, _appl, _page)
        End Get
    End Property




 
End Class
