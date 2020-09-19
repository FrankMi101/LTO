Module SetParameterSQL
    'Public Sub setParameterArray(ByVal _ParaArray() ' As tpaWS.MyParameter, ByVal X As Integer, ByVal _Name As String, ByVal _Type As System.Data.DbType, ByVal _Leng As Integer, ByVal _Value As String)
    '    Try
    '        _ParaArray(X) = New tpaWS.MyParameter 'TCDSB.Student.Data.MyParameter 

    '        _ParaArray(X).pName = _Name
    '        _ParaArray(X).pType = _Type
    '        _ParaArray(X).pLeng = _Leng
    '        _ParaArray(X).pValue = _Value
    '    Catch ex As Exception
    '        Dim exMsg As String = ex.Message
    '    End Try
    'End Sub
    'Public Sub setParameterArrayBase(ByVal _ParaArray() As TCDSB.Student.Data.MyParameter, ByVal X As Integer, ByVal _Name As String, ByVal _Type As System.Data.DbType, ByVal _Leng As Integer, ByVal _Value As String)
    '    Try
    '        _ParaArray(X) = New TCDSB.Student.Data.MyParameter ' tpaWS.MyParameter

    '        _ParaArray(X).pName = _Name
    '        _ParaArray(X).pType = _Type
    '        _ParaArray(X).pLeng = _Leng
    '        _ParaArray(X).pValue = _Value
    '    Catch ex As Exception
    '        Dim exMsg As String = ex.Message
    '    End Try
    'End Sub

    Public Sub setParameterArray(ByVal _ParaArray() As Object, ByVal X As Integer, ByVal _Name As String, ByVal _Type As System.Data.DbType, ByVal _Leng As Integer, ByVal _Value As String)
        Try

            '**************** This black is using Web services get data*******************************
            '_ParaArray(X) = New DataAccessWebService.MyParameter
            ' ****************Base classs get data************************************************
            _ParaArray(X) = New TCDSB.Student.Data.MyParameter  ' may 2 

            _ParaArray(X).pName = _Name
            _ParaArray(X).pType = _Type
            _ParaArray(X).pLeng = _Leng
            _ParaArray(X).pValue = _Value
        Catch ex As Exception
            Dim exMsg As String = ex.Message
        End Try
    End Sub
    Public Function getMyDataSet(ByVal _sp As String, ByRef mypara1 As Object) As DataSet
        Try
            '**************** This black is using Web services get data*******************************
            ' Dim ws1 As New DataAccessWebService.DataWS '  DataAccessWebService2.DataWS
            'Return ws1.WSDataSet(_sp, mypara1)
            ' ****************Base classs get data************************************************
            Return TCDSB.Student.Data.myDataSetA(_sp, mypara1)
        Catch ex As Exception
            Dim sr As String = ex.Message
            Return Nothing
        End Try
    End Function
    Public Function getMyDataValue(ByVal _sp As String, ByRef mypara1 As Object) As String
        Try
            '**************** This black is using Web services get data*******************************
            'Dim ws1 As New DataAccessWebService.DataWS
            'Return ws1.WSValue(_sp, mypara1)
            ' ****************Base classs get data************************************************
             Return TCDSB.Student.Data.myValueA(_sp, mypara1)
        Catch ex As Exception
            Dim sr As String = ex.Message
            Return ""
        End Try
    End Function

    Public Sub AddSQLParameter(ByVal myCom As SqlClient.SqlCommand, ByVal myType As SqlDbType, ByVal myLeng As Integer, ByVal myName As String, ByVal myValue As String)

        Dim myPara As SqlClient.SqlParameter = New SqlClient.SqlParameter(myName, myType, myLeng)
        myPara.Value = myValue
        myCom.Parameters.Add(myPara)
    End Sub
    Public Sub AddSQLParameter(ByVal myCom As SqlClient.SqlCommand, ByVal myType As SqlDbType, ByVal myLeng As Integer, ByVal myName As String, ByVal myValue As Integer)

        Dim myPara As SqlClient.SqlParameter = New SqlClient.SqlParameter(myName, myType, myLeng)
        myPara.Value = myValue
        myCom.Parameters.Add(myPara)
    End Sub
    Public Sub AddSQLParameter(ByVal myCom As SqlClient.SqlCommand, ByVal myType As SqlDbType, ByVal myLeng As Integer, ByVal myName As String, ByVal myValue() As Byte)

        Dim myPara As SqlClient.SqlParameter = New SqlClient.SqlParameter(myName, myType)
        myPara.Value = myValue
        myCom.Parameters.Add(myPara)
    End Sub
    Public Sub AddSQLParameter(ByVal myCom As SqlClient.SqlCommand, ByVal myType As SqlDbType, ByVal myLeng As Integer, ByVal myName As String, ByVal myValue As Date)

        Dim myPara As SqlClient.SqlParameter = New SqlClient.SqlParameter(myName, myType)
        myPara.Value = myValue
        myCom.Parameters.Add(myPara)
    End Sub

#Region "  Generel Function "
    Public Function getOperate(ByVal row As DataRow) As String
        Dim _Operate As String
        Select Case row.RowState
            Case DataRowState.Deleted
                _Operate = "Delete" ' getdataSetValue(_Type, Row, "Delete")
            Case DataRowState.Added
                _Operate = "Insert" ' getdataSetValue(_Type, Row, "Insert")
            Case DataRowState.Modified
                _Operate = "Update" ' getdataSetValue(_Type, Row, "Update")
            Case DataRowState.Detached
                _Operate = "Detach"
            Case Else
                _Operate = "Unchange"
        End Select
        Return _Operate
    End Function
    Public Function getmyItem(ByVal myItem As Object) As String '  myRow.Item(4)) 
        Dim x As String
        Try
            x = myItem
        Catch ex As Exception
            x = ""
        End Try
        Return IIf(x = "true", "True", x)
    End Function
    Public Function CheckBoxValue(ByVal _Seq As Integer, ByVal ds As DataSet) As Boolean
        Dim _temp As String
        If (Not IsDBNull(ds.Tables(0).Rows(0).ItemArray(_Seq))) Then
            _temp = CType(ds.Tables(0).Rows(0).ItemArray(_Seq), String)
        Else
            _temp = ""
        End If
        Dim rVal As Boolean
        If (_temp = "X" Or _temp = "x") Then
            rVal = True
        Else
            rVal = False
        End If
        Return rVal
    End Function
    Public Function CheckBoxString(ByVal _temp) As String
        Dim rVal As String
        If _temp = "True" Then
            rVal = "1"
        Else
            rVal = "0"
        End If
        Return rVal
    End Function

    Public Function getmyItemBool(ByVal myItem As Object) As String '  myRow.Item(4)) 
        Dim x As Boolean
        Try
            x = myItem
        Catch ex As Exception
            x = False
        End Try
        Return x
    End Function
    Public Function getMyValue(ByVal _value As Object)
        Try
            If _value = Nothing Then

            End If
            Return _value
        Catch ex As Exception
            Return ""
        End Try
    End Function
#End Region
End Module

Public Class myDataSysDB
    Public Shared Sub setParameterArray(ByVal _ParaArray() As Object, ByVal X As Integer, ByVal _Name As String, ByVal _Type As System.Data.DbType, ByVal _Leng As Integer, ByVal _Value As Object)
        Try

            '**************** This black is using Web services get data*******************************
            '_ParaArray(X) = New DataAccessWebService.MyParameter
            ' ****************Base classs get data************************************************
            _ParaArray(X) = New TCDSB.Student.Data.MyParameter

            _ParaArray(X).pName = _Name
            _ParaArray(X).pType = _Type
            _ParaArray(X).pLeng = _Leng
            _ParaArray(X).pValue = _Value
        Catch ex As Exception
            Dim exMsg As String = ex.Message
        End Try
    End Sub


    Public Shared Function getMyDataSet(ByVal _sp As String, ByRef mypara1 As Object) As DataSet
        Try
            '**************** This black is using Web services get data*******************************
            ' Dim ws1 As New DataAccessWebService.DataWS '  DataAccessWebService2.DataWS
            'Return ws1.WSDataSet(_sp, mypara1)
            ' ****************Base classs get data************************************************
            Return TCDSB.Student.Data.myDataSet(_sp, mypara1)
        Catch ex As Exception
            Dim sr As String = ex.Message
            Return Nothing
        End Try
    End Function
    Public Shared Function getMyDataValue(ByVal _sp As String, ByRef mypara1 As Object) As String
        Try
            '**************** This black is using Web services get data*******************************
            'Dim ws1 As New DataAccessWebService.DataWS
            'Return ws1.WSValue(_sp, mypara1)
            ' ****************Base classs get data************************************************
            Return TCDSB.Student.Data.myValue(_sp, mypara1)
        Catch ex As Exception
            Dim sr As String = ex.Message
            Return ""
        End Try
    End Function
    Public Shared Sub saveMyData(ByVal _sp As String, ByRef mypara1 As Object)
        Try
            '**************** This black is using Web services get data*******************************
            'Dim ws1 As New DataAccessWebService.DataWS
            'Return ws1.WSValue(_sp, mypara1)
            ' ****************Base classs get data************************************************
            TCDSB.Student.Data.myDataSave(_sp, mypara1)

        Catch ex As Exception
            Dim sr As String = ex.Message

        End Try
    End Sub

End Class
Public Class myDataSqlDB
    Public Shared Sub setParameterArray(ByVal _ParaArray() As Object, ByVal X As Integer, ByVal _Name As String, ByVal _Type As SqlDbType, ByVal _Leng As Integer, ByVal _Value As Object)
        Try

            '**************** This black is using Web services get data*******************************
            '_ParaArray(X) = New DataAccessWebService.MyParameter
            ' ****************Base classs get data************************************************
            _ParaArray(X) = New TCDSB.Student.MyParameter2

            _ParaArray(X).pName = _Name
            _ParaArray(X).pType = _Type
            _ParaArray(X).pLeng = _Leng
            _ParaArray(X).pValue = _Value
        Catch ex As Exception
            Dim exMsg As String = ex.Message
        End Try
    End Sub


    Public Shared Function getMyDataSet(ByVal _sp As String, ByRef mypara1 As Object) As DataSet
        Try
            '**************** This black is using Web services get data*******************************
            ' Dim ws1 As New DataAccessWebService.DataWS '  DataAccessWebService2.DataWS
            'Return ws1.WSDataSet(_sp, mypara1)
            ' ****************Base classs get data************************************************
            Return TCDSB.Student.Data2.myDataSet(_sp, mypara1)
        Catch ex As Exception
            Dim sr As String = ex.Message
            Return Nothing
        End Try
    End Function
    Public Shared Function getMyDataValue(ByVal _sp As String, ByRef mypara1 As Object) As String
        Try
            '**************** This black is using Web services get data*******************************
            'Dim ws1 As New DataAccessWebService.DataWS
            'Return ws1.WSValue(_sp, mypara1)
            ' ****************Base classs get data************************************************
            Return TCDSB.Student.Data2.myValue(_sp, mypara1)
        Catch ex As Exception
            Dim sr As String = ex.Message
            Return ""
        End Try
    End Function
    Public Shared Function getMyDataDate(ByVal _sp As String, ByRef mypara1 As Object) As Date
        Try
            '**************** This black is using Web services get data*******************************
            'Dim ws1 As New DataAccessWebService.DataWS
            'Return ws1.WSValue(_sp, mypara1)
            ' ****************Base classs get data************************************************
            Return TCDSB.Student.Data2.myDataDate(_sp, mypara1)
        Catch ex As Exception
            Dim sr As String = ex.Message
            Return ""
        End Try
    End Function
    Public Shared Sub saveMyData(ByVal _sp As String, ByRef mypara1 As Object)
        Try
            '**************** This black is using Web services get data*******************************
            'Dim ws1 As New DataAccessWebService.DataWS
            'Return ws1.WSValue(_sp, mypara1)
            ' ****************Base classs get data************************************************
            TCDSB.Student.Data2.myDataSave(_sp, mypara1)

        Catch ex As Exception
            Dim sr As String = ex.Message

        End Try
    End Sub
End Class