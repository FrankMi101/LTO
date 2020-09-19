Imports TCDSB.Student.Data
Imports System.Data.SqlClient
Imports System.Web


Public Class CommentBank
    'Inherits TCDSB.Student.SC.TCBase
    Public Shared cPage As Object
    Public Shared _Domain As String = "CEC"
    Public Shared lenMessage As Integer
#Region "  Comment Tree "
 
    
    Public Shared ReadOnly Property TreeNode(ByVal _User As String, ByVal _type As String, ByVal _C0 As String) As DataSet
        Get
            Return GetCommentData3(_User, "Root", _C0)
        End Get
    End Property
    Public Shared ReadOnly Property TreeNode(ByVal _User As String, ByVal _type As String, ByVal _C0 As String, ByVal _C1 As String) As DataSet
        Get
            Return GetCommentData3(_User, "Node", _C0, _C1)
        End Get
    End Property
    Public Shared ReadOnly Property TreeNode(ByVal _User As String, ByVal _type As String, ByVal _C0 As String, ByVal _C1 As String, ByVal _C2 As String) As DataSet
        Get
            Return GetCommentData3(_User, "Node", _C0, _C1, _C2)
        End Get
    End Property
    Public Shared ReadOnly Property TreeNode(ByVal _User As String, ByVal _type As String, ByVal _C0 As String, ByVal _C1 As String, ByVal _C2 As String, ByVal _C3 As String) As DataSet
        Get
            Return GetCommentData3(_User, "Node", _C0, _C1, _C2, _C3)
        End Get
    End Property
    Public Shared ReadOnly Property TreeComment3(ByVal _User As String, ByVal _type As String, ByVal _C0 As String, ByVal _C1 As String, ByVal _C2 As String, ByVal _C3 As String) As DataSet
        Get
            Return GetCommentData3(_User, "Comments", _C0, _C1, _C2, _C3)
        End Get
    End Property
   
     
    Private Shared Function GetCommentData3(ByVal _User As String, ByVal _Type As String, _
                                            Optional ByVal _C0 As String = "NxN", _
                                            Optional ByVal _C1 As String = "NxN", _
                                            Optional ByVal _C2 As String = "NxN", _
                                            Optional ByVal _C3 As String = "NxN") As DataSet
        Try
            Dim _SP As String = "dbo.tcdsb_BIP2_CommentNode"
            Dim myPara(5) ' As tpaWS.MyParameter  ' TCDSB.Student.Data.MyParameter     
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _User)
            setParameterArray(myPara, 1, "@Type", DbType.String, 20, _Type)
            setParameterArray(myPara, 2, "@C0", DbType.String, 50, _C0)
            setParameterArray(myPara, 3, "@C1", DbType.String, 50, _C1)
            setParameterArray(myPara, 4, "@C2", DbType.String, 50, _C2)
            setParameterArray(myPara, 5, "@C3", DbType.String, 50, _C3)
            Return getMyDataSet(_SP, myPara)

        Catch ex As Exception
            'CommonTCDSB.ShowMsg. Exception(ex, cPage, " get Comments action.")
            Return Nothing
        End Try
    End Function



    Public Shared ReadOnly Property AppraisalYear(ByVal _Role As String, ByVal _TeacherID As String, ByVal _TextID As String, ByVal _schoolcode As String) As DataSet
        Get
            Return GetCopyData("User", "Year", _Role, _TeacherID, _TextID, _schoolcode)
        End Get
    End Property
    Public Shared ReadOnly Property AppraisalSession(ByVal _Role As String, ByVal _TeacherID As String, ByVal _TextID As String, ByVal _schoolcode As String, ByVal _schoolYear As String) As DataSet
        Get
            Return GetCopyData("User", "Session", _Role, _TeacherID, _TextID, _schoolcode, _schoolYear)
        End Get
    End Property
    Public Shared ReadOnly Property AppraisalTeacher(ByVal _Role As String, ByVal _TeacherID As String, ByVal _TextID As String, ByVal _schoolcode As String, ByVal _schoolYear As String, ByVal _Session As String) As DataSet
        Get
            Return GetCopyData("User", "Teacher", _Role, _TeacherID, _TextID, _schoolcode, _schoolYear, _Session)
        End Get
    End Property
    Public Shared ReadOnly Property AppraisalContext(ByVal _Role As String, ByVal _TeacherID As String, ByVal _TextID As String, ByVal _schoolcode As String, ByVal _schoolYear As String, ByVal _Session As String, ByVal _oTeacherID As String) As String
        Get
            Return GetCopyItemData("User", "Context", _Role, _TeacherID, _TextID, _schoolcode, _schoolYear, _Session, _oTeacherID)
        End Get
    End Property

    Private Shared Function GetCopyData(ByVal _User As String, ByVal _Type As String, _
                                          Optional ByVal _V1 As String = "NxN", _
                                          Optional ByVal _V2 As String = "NxN", _
                                          Optional ByVal _V3 As String = "NxN", _
                                          Optional ByVal _V4 As String = "NxN", _
                                          Optional ByVal _V5 As String = "NxN", _
                                          Optional ByVal _V6 As String = "NxN") As DataSet
        Try
            Dim _SP As String = "dbo.tcdsb_TPA_CommentCopyItem"
            Dim myPara(7) '' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _User)
            setParameterArray(myPara, 1, "@Type", DbType.String, 20, _Type)
            setParameterArray(myPara, 2, "@Role", DbType.String, 50, _V1)
            setParameterArray(myPara, 3, "@TeacherID", DbType.String, 50, _V2)
            setParameterArray(myPara, 4, "@TextID", DbType.String, 10, _V3)
            setParameterArray(myPara, 5, "@SchoolCode", DbType.String, 8, _V4)
            setParameterArray(myPara, 6, "@SchoolYear", DbType.String, 8, _V5)
            setParameterArray(myPara, 7, "@Session", DbType.String, 20, _V6)
            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            'CommonTCDSB.ShowMsg. Exception(ex, cPage, " get Comments action.")
            Return Nothing
        End Try
    End Function
    Private Shared Function GetCopyItemData(ByVal _User As String, ByVal _Type As String, _
                                              Optional ByVal _V1 As String = "NxN", _
                                              Optional ByVal _V2 As String = "NxN", _
                                              Optional ByVal _V3 As String = "NxN", _
                                              Optional ByVal _V4 As String = "NxN", _
                                              Optional ByVal _V5 As String = "NxN", _
                                              Optional ByVal _V6 As String = "NxN", _
                                              Optional ByVal _V7 As String = "NxN") As String
        Try
            Dim _SP As String = "dbo.tcdsb_TPA_CommentCopyItem"
            Dim myPara(8) ' As tpaWS.MyParameter  ' TCDSB.Student.Data.MyParameter     
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _User)
            setParameterArray(myPara, 1, "@Type", DbType.String, 20, _Type)
            setParameterArray(myPara, 2, "@Role", DbType.String, 50, _V1)
            setParameterArray(myPara, 3, "@TeacherID", DbType.String, 50, _V2)
            setParameterArray(myPara, 4, "@TextID", DbType.String, 10, _V3)
            setParameterArray(myPara, 5, "@SchoolCode", DbType.String, 8, _V4)
            setParameterArray(myPara, 6, "@SchoolYear", DbType.String, 8, _V5)
            setParameterArray(myPara, 7, "@Session", DbType.String, 20, _V6)
            setParameterArray(myPara, 8, "@oTeacher", DbType.String, 50, _V7)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            'CommonTCDSB.ShowMsg. Exception(ex, cPage, " get Comments action.")
            Return ""
        End Try
    End Function

#End Region

#Region "  Comment Bank Edit  "
    Public Shared Property CommentBankData(ByVal _user As String, ByVal _Type As String, ByVal _Owner As String) As DataSet
        Get
            Return GetCommentBankDataAll(_Type, _Owner)
        End Get
        Set(ByVal Value As DataSet)
            CommentBankSave(_user, Value, _Type, _Owner)
        End Set
    End Property
    Private Shared Function GetCommentBankDataAll(ByVal _vType As String, ByVal _Owner As String) As DataSet
        Try
            Dim _SP As String = "dbo.tcdsb_TPA_getCommentBank_Edit"
            Dim myPara(1) ' As tpaWS.MyParameter  ' TCDSB.Student.Data.MyParameter     
            setParameterArray(myPara, 0, "@Type", DbType.String, 30, _vType)
            setParameterArray(myPara, 1, "@Owner", DbType.String, 30, _Owner)
            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            ' CommonTCDSB.ShowMsg. Exception(ex, cPage, " get Comments bank action.")
            Return Nothing
        End Try
    End Function
    Private Shared Sub CommentBankSave(ByVal _user As String, ByVal DS As DataSet, ByVal _Type As String, ByVal _Owner As String)
        SaveCommentBankDataCategory(_user, DS.Tables(0), _Type, _Owner)
        SaveCommentBankDataComment(_user, DS.Tables(1), _Type, _Owner)
    End Sub
    Private Shared Sub SaveCommentBankDataCategory(ByVal _user As String, ByVal DT As DataTable, ByVal _Type As String, ByVal _Owner As String)
        Dim _V0, _V1, _V2, _V3, _V4 As String
        Try
            Dim _Operate As String
            Dim Row As DataRow
            For Each Row In DT.Rows ' .GetChanges(DataRowState.Deleted).Rows
                Try
                    If Not Row.RowState = DataRowState.Unchanged Then
                        _Operate = getOperate(Row)
                        If _Operate = "Delete" Then
                            _V0 = getmyItem(Row(0, DataRowVersion.Original))    'IDs, 
                            _V1 = getmyItem(Row(1, DataRowVersion.Original))
                            _V2 = "NxN" 'getmyItem(Row(2, DataRowVersion.Original))
                            _V3 = "NxN" '_Type ',getmyItem(Row(3, DataRowVersion.Original))
                            _V4 = "NxN" '_Owner 'getmyItem(Row(4, DataRowVersion.Original))
                        Else
                            _V0 = getmyItem(Row(0, DataRowVersion.Current))   'IDs, 
                            _V1 = getmyItem(Row(1, DataRowVersion.Current))   '	 
                            _V2 = IIf(getmyItemBool(Row(2, DataRowVersion.Current)), "1", "0")
                            _V3 = _Type 'getmyItem(Row(3, DataRowVersion.Current))   '	 
                            _V4 = _Owner 'getmyItem(Row(4, DataRowVersion.Current))    '	Notes,
                        End If
                        Dim _Resoult As String = IsSaveDataSetValueOK(_user, _Operate, _V0, _V1, _V2, _V3, _V4)
                        If _Operate = "Insert" Then Row(0) = _Resoult
                    End If
                Catch ex As Exception
                    Dim _exMsg As String = ex.Message
                End Try
            Next
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try
        'Category_ID, Shared,Status,Type,Owner 
    End Sub
    Private Shared Function IsSaveDataSetValueOK(ByVal _User As String, ByVal _Operate As String, _
                                     Optional ByVal _V0 As String = "NxN", _
                                     Optional ByVal _V1 As String = "NxN", _
                                     Optional ByVal _V2 As String = "NxN", _
                                     Optional ByVal _V3 As String = "NxN", _
                                     Optional ByVal _V4 As String = "NxN") As String
        Try
            Dim _SP As String = "dbo.tcdsb_TPA_Save_CommentBank_Category"
            Dim myPara(6) '' As tpaWS.MyParameter  ' TCDSB.Student.Data.MyParameter     
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _User)
            setParameterArray(myPara, 1, "@Oprate", DbType.String, 20, _Operate)
            setParameterArray(myPara, 2, "@P0", DbType.String, 10, _V0)
            setParameterArray(myPara, 3, "@P1", DbType.String, 200, _V1)
            setParameterArray(myPara, 4, "@P2", DbType.String, 2, _V2)
            setParameterArray(myPara, 5, "@P3", DbType.String, 20, _V3)
            setParameterArray(myPara, 6, "@P4", DbType.String, 30, _V4)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, " get Comments bank action.")
            Return ""
        End Try
    End Function
    Private Shared Sub SaveCommentBankDataComment(ByVal _user As String, ByVal DT As DataTable, ByVal _Type As String, ByVal _Owner As String)
        Dim _V0, _V1, _V2, _V3, _V4, _V5, _V6 As String
        Try
            Dim _Operate As String
            Dim Row As DataRow
            For Each Row In DT.Rows ' .GetChanges(DataRowState.Deleted).Rows
                Try
                    If Not Row.RowState = DataRowState.Unchanged Then
                        _Operate = getOperate(Row)
                        If _Operate = "Delete" Then
                            _V0 = getmyItem(Row(0, DataRowVersion.Original))    'IDs, 
                            _V1 = getmyItem(Row(1, DataRowVersion.Original))
                            _V2 = "NxN" '(getmyItem(Row(2, DataRowVersion.Original))"
                            _V3 = "NxN" '_Type 'getmyItem(Row(3, DataRowVersion.Original))
                            _V4 = "NxN" '_Owner 'getmyItem(Row(4, DataRowVersion.Original))
                            _V5 = "NxN"
                            _V6 = "NxN"

                        Else
                            _V0 = getmyItem(Row(0, DataRowVersion.Current))   'IDs, 
                            _V1 = getmyItem(Row(1, DataRowVersion.Current))   '	 
                            _V2 = IIf(getmyItemBool(Row(2, DataRowVersion.Current)), "1", "0")  '	Notes,
                            _V3 = _Type 'getmyItem(Row(3, DataRowVersion.Current))   '	 
                            _V4 = _Owner 'getmyItem(Row(4, DataRowVersion.Current))    '	Notes,
                            _V5 = getmyItem(Row(5, DataRowVersion.Current))    '	Notes,
                            _V6 = getmyItem(Row(6, DataRowVersion.Current))    '	Notes,

                        End If
                        Dim _Resoult As String = IsSaveDataSetValueOK1(_user, _Operate, _V0, _V1, _V2, _V3, _V4, _V5, _V6)
                    End If
                Catch ex As Exception
                    Dim _exMsg As String = ex.Message
                End Try
            Next
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try
        ' Bank_ID,Shared,Status,Type,Owner,Comments 
    End Sub
    Private Shared Function IsSaveDataSetValueOK1(ByVal _User As String, ByVal _Operate As String, _
                                     Optional ByVal _V0 As String = "NxN", _
                                     Optional ByVal _V1 As String = "NxN", _
                                     Optional ByVal _V2 As String = "NxN", _
                                     Optional ByVal _V3 As String = "NxN", _
                                     Optional ByVal _V4 As String = "NxN", _
                                     Optional ByVal _V5 As String = "NxN", _
                                     Optional ByVal _V6 As String = "NxN") As String
        Try
            Dim _SP As String = "dbo.tcdsb_TPA_Save_CommentBank_Comment"
            Dim myPara(8) '' As tpaWS.MyParameter  ' TCDSB.Student.Data.MyParameter     
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _User)
            setParameterArray(myPara, 1, "@Oprate", DbType.String, 20, _Operate)
            setParameterArray(myPara, 2, "@P0", DbType.String, 10, _V0)
            setParameterArray(myPara, 3, "@P1", DbType.String, 200, _V1)
            setParameterArray(myPara, 4, "@P2", DbType.String, 2, _V2)
            setParameterArray(myPara, 5, "@P3", DbType.String, 20, _V3)
            setParameterArray(myPara, 6, "@P4", DbType.String, 30, _V4)
            setParameterArray(myPara, 7, "@P5", DbType.String, 250, _V5)
            setParameterArray(myPara, 8, "@P6", DbType.String, 250, _V6)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, " get Comments bank action.")
            Return ""
        End Try
    End Function
#End Region

#Region "  Message Board  "
    Public Shared ReadOnly Property MessageBoard(ByVal _Type As String) As String
        Get
            Return getshowMessage(_Type)
        End Get
    End Property
    Public Shared Property Message(ByVal _user As String, ByVal _role As String) As DataSet
        Get
            Return GetMessage(_user, _role)
        End Get
        Set(ByVal Value As DataSet)
            MessageSave(_user, Value)
        End Set
    End Property
    Private Shared Function getshowMessage(ByVal _type As String) As String
        Try
            Dim DS As DataSet
            Dim _SP As String = "dbo.tcdsb_TPA_Message"
            Dim myPara(1) ' ' As tpaWS.MyParameter  ' TCDSB.Student.Data.MyParameter     
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, "Mif")
            setParameterArray(myPara, 1, "@Oprate", DbType.String, 20, _type)

            DS = getMyDataSet(_SP, myPara)
            Dim _Folder As String = CommonTCDSB.Webconfig.AttFolder
            Dim row As DataRow
            Dim _Str As String = ""
            Dim lenStr As Integer = 0
            For Each row In DS.Tables(0).Rows
                If Len(row(7)) > 1 Then
                    If row(8) = "WebServer" Then
                        _Str = _Str + row(1) & ".  " & "<A href=" & """" & _Folder & "/" & row(7) & """" & " target=" & """" & "_blank" & """" & ">" + row(5) + "</A>" & ";  " & vbCrLf
                        lenStr = lenStr + Len(row(1)) + Len(row(5)) + 1
                    Else
                        _Str = _Str + row(1) & ".  " & "<A href=" & """" & "BaseAttachementShowPage.aspx?IDs=" & row(9) & """" & " target=" & """" & "_blank" & """" & ">" + row(5) + "</A>" & ";  " & vbCrLf
                        lenStr = lenStr + Len(row(1)) + Len(row(5)) + 1
                    End If
                Else
                    _Str = _Str + row(1) & ";  " & vbCrLf
                End If
            Next
            lenMessage = lenStr
            Return Trim(_Str)


        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Get Data from Database")
            Return ""
        End Try
    End Function
    Private Shared Function GetMessage(ByVal _user As String, ByVal _role As String) As DataSet
        Try
            Dim _SP As String = "dbo.tcdsb_TPA_Message"
            Dim myPara(1) ' As tpaWS.MyParameter  ' TCDSB.Student.Data.MyParameter     
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _user)
            setParameterArray(myPara, 1, "@Oprate", DbType.String, 20, _role)
            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, " get Comments bank action.")
            Return Nothing
        End Try
    End Function
    Private Shared Sub MessageSave(ByVal _user As String, ByVal DS As DataSet)
        Dim _V0, _V1, _V2, _V3, _V4 As String
        Try
            Dim _Operate As String
            Dim Row As DataRow
            For Each Row In DS.Tables(0).Rows ' .GetChanges(DataRowState.Deleted).Rows
                Try
                    If Not Row.RowState = DataRowState.Unchanged Then
                        _Operate = getOperate(Row)
                        If _Operate = "Delete" Then
                            _V0 = getmyItem(Row(0, DataRowVersion.Original))    'IDs, 
                            _V1 = getmyItem(Row(1, DataRowVersion.Original))

                            _V2 = "NxN"   '	School_Name,
                            _V3 = "NxN"    '	School_brief_name,
                            _V4 = "NxN"    '	default admin

                        Else
                            _V0 = getmyItem(Row(0, DataRowVersion.Current))   'IDs, 
                            _V1 = getmyItem(Row(1, DataRowVersion.Current))   'showType 	 
                            _V2 = getmyItem(Row(2, DataRowVersion.Current))   ' Message
                            _V3 = DateFC.YMD(getmyItem(Row(3, DataRowVersion.Current)))    '	Experid Date 
                            _V4 = getmyItem(Row(4, DataRowVersion.Current))   ' Attachment ID
                        End If
                        Dim _Resoult As String = IsSaveMessageDataValueOK(_user, _Operate, _V0, _V1, _V2, _V3, _V4)
                    End If
                Catch ex As Exception
                    Dim _exMsg As String = ex.Message
                End Try
            Next
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try
        'Category_ID, Shared,Status,Type,Owner 
    End Sub
    Private Shared Function IsSaveMessageDataValueOK(ByVal _user As String, ByVal _Operate As String, _
                                     Optional ByVal _V0 As String = "NxN", _
                                     Optional ByVal _V1 As String = "NxN", _
                                     Optional ByVal _V2 As String = "NxN", _
                                     Optional ByVal _V3 As String = "NxN", _
                                     Optional ByVal _V4 As String = "NxN") As String
        Try
            Dim _SP As String = "dbo.tcdsb_TPA_Message"
            Dim myPara(6) ' ' As tpaWS.MyParameter  ' TCDSB.Student.Data.MyParameter     
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _user)
            setParameterArray(myPara, 1, "@Oprate", DbType.String, 20, _Operate)
            setParameterArray(myPara, 2, "@IDs", DbType.String, 10, _V0)
            setParameterArray(myPara, 3, "@ShowType", DbType.String, 10, _V1)
            setParameterArray(myPara, 4, "@Messgae", DbType.String, 500, _V2)
            setParameterArray(myPara, 5, "@expDate", DbType.String, 10, _V3)
            setParameterArray(myPara, 6, "@attamentID", DbType.String, 10, _V4)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, " get Comments bank action.")
            Return ""
        End Try
    End Function

#End Region

#Region "  Generel Function "
    Private Shared Function getOperate(ByVal row As DataRow) As String
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
    Private Shared Function getmyItem(ByVal myItem As Object) As String '  myRow.Item(4)) 
        Dim x As String
        Try
            x = myItem
        Catch ex As Exception
            x = ""
        End Try
        Return x
    End Function
    Private Shared Function CheckBoxValue(ByVal _Seq As Integer, ByVal ds As DataSet) As Boolean
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
    Private Shared Function CheckBoxString(ByVal _temp As Boolean) As String
        Dim rVal As String
        If _temp = True Then
            rVal = "1"
        Else
            rVal = "0"
        End If
        Return rVal
    End Function

    Private Shared Function getmyItemBool(ByVal myItem As Object) As String '  myRow.Item(4)) 
        Dim x As Boolean
        Try
            x = myItem
        Catch ex As Exception
            x = False
        End Try
        Return x
    End Function
#End Region

End Class
Public Class SubmitData
    ' Inherits TCDSB.Student.Data
    Public Shared cPage As Object
    '  Public Shared _User As String ' = HttpContext.Current.User.Identity.Name
    Private Shared _domain As String = HttpContext.Current.User.Identity.Name


#Region "  Save Domain Data "

    Public Shared Sub Domain(ByVal _user As String, ByVal ds As DataSet)
        Dim _V0, _V1, _V2, _V3, _V4, _Operate As String
        Try
            Dim Row As DataRow
            Dim DT As DataTable = ds.Tables(0)
            Dim countR As Integer = ds.Tables(0).Rows.Count
            For Each Row In DT.Rows ' .GetChanges(DataRowState.Deleted).Rows
                Try
                    If Not Row.RowState = DataRowState.Unchanged Then
                        _Operate = getOperate(Row)
                        If _Operate = "Delete" Then
                            _V0 = getmyItem(Row(0, DataRowVersion.Original))    '	DomainID, 
                            _V1 = "NxN"   '	Domain_name,
                            _V2 = "NxN"    '	Notes,
                            _V3 = "NxN"     '	Status
                            _V4 = "NxN"     '	Inactive_date
                        Else
                            _V0 = getmyItem(Row(0, DataRowVersion.Current))   '	DomainID, 
                            _V1 = getmyItem(Row(1, DataRowVersion.Current))   '	Domain_name,
                            _V2 = getmyItem(Row(2, DataRowVersion.Current))   '	Notes,
                            _V3 = getmyItem(Row(3, DataRowVersion.Current))    '	Status
                            _V4 = DateFC.YMD(getmyItem(Row(4, DataRowVersion.Current)))     '	Inactive_date
                        End If
                        Dim _Resoult As String = IsSaveValueOK_domain(_user, _Operate, _V0, _V1, _V2, _V3, _V4)
                        ' If Not _Resoult = "OK" Then CommonTCDSB.ShowMsg. Message(cPage, "Data Update", _Resoult)
                    End If
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try

    End Sub

    Private Shared Function IsSaveValueOK_domain(ByVal _user As String, ByVal _Operate As String, _
                                         Optional ByVal _V0 As String = "NxN", _
                                         Optional ByVal _V1 As String = "NxN", _
                                         Optional ByVal _V2 As String = "NxN", _
                                         Optional ByVal _V3 As String = "NxN", _
                                         Optional ByVal _V4 As String = "NxN") As String

        Dim _SP As String = "dbo.tcdsb_TPA_Save_Domain"
        Try
            ' If Webconfig.Datasource = "WebService" Then
            Dim myPara(7) ' As tpaWS.MyParameter  'TCDSB.Student.Data.MyParameter      ' MyParameterStructure
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _user)
            setParameterArray(myPara, 1, "@Domain", DbType.String, 30, _domain)
            setParameterArray(myPara, 2, "@Operate", DbType.String, 20, _Operate)
            setParameterArray(myPara, 3, "@P0", DbType.String, 10, _V0)
            setParameterArray(myPara, 4, "@P1", DbType.String, 50, _V1)
            setParameterArray(myPara, 5, "@P2", DbType.String, 200, _V2)
            setParameterArray(myPara, 6, "@P3", DbType.String, 2, _V3)
            setParameterArray(myPara, 7, "@P4", DbType.String, 10, _V4)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try

    End Function

#End Region
#Region "  Save Competency Data "
    Public Shared Sub Competency(ByVal _user As String, ByVal ds As DataSet, ByVal _DomainID As String)
        Dim _V0, _V1, _V2, _V3, _V4, _Operate As String
        Try
            Dim Row As DataRow
            Dim DT As DataTable = ds.Tables(0)
            Dim countR As Integer = ds.Tables(0).Rows.Count
            For Each Row In DT.Rows ' .GetChanges(DataRowState.Deleted).Rows
                Try
                    If Not Row.RowState = DataRowState.Unchanged Then
                        _Operate = getOperate(Row)
                        If _Operate = "Delete" Then
                            _V0 = getmyItem(Row(0, DataRowVersion.Original))    '	DomainID, 
                            _V1 = getmyItem(Row(1, DataRowVersion.Original))    '	Competency_ID,
                            _V2 = "NxN"
                            _V3 = "NxN"     '	Status
                            _V4 = "NxN"     '	Inactive_date
                        Else
                            _V0 = getmyItem(Row(0, DataRowVersion.Current))   '	DomainID, 
                            _V1 = getmyItem(Row(1, DataRowVersion.Current))   '	Competency_ID,
                            _V2 = getmyItem(Row(2, DataRowVersion.Current))   '	Competency,
                            _V3 = IIf(getmyItem(Row(3, DataRowVersion.Current)) = "true", "1", "0")    '	NewTeacherC
                            _V4 = DateFC.YMD(getmyItem(Row(4, DataRowVersion.Current)))     '	Inactive_date
                        End If
                        Dim _Resoult As String = IsSaveValueOK_Competency(_user, _Operate, _V0, _V1, _V2, _V3, _V4)
                    End If
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try

    End Sub
    Private Shared Function IsSaveValueOK_Competency(ByVal _user As String, ByVal _Operate As String, _
                                         Optional ByVal _V0 As String = "NxN", _
                                         Optional ByVal _V1 As String = "NxN", _
                                         Optional ByVal _V2 As String = "NxN", _
                                         Optional ByVal _V3 As String = "NxN", _
                                         Optional ByVal _V4 As String = "NxN") As String
        Dim _SP As String = "dbo.tcdsb_TPA_Save_Competency"
        Try
            ' If Webconfig.Datasource = "WebService" Then
            Dim myPara(7) ' As tpaWS.MyParameter  'TCDSB.Student.Data.MyParameter      ' MyParameterStructure
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _user)
            setParameterArray(myPara, 1, "@Domain", DbType.String, 30, _domain)
            setParameterArray(myPara, 2, "@Operate", DbType.String, 20, _Operate)
            setParameterArray(myPara, 3, "@P0", DbType.String, 10, _V0)
            setParameterArray(myPara, 4, "@P1", DbType.String, 10, _V1)
            setParameterArray(myPara, 5, "@P2", DbType.String, 250, _V2)
            setParameterArray(myPara, 6, "@P3", DbType.String, 2, _V3)
            setParameterArray(myPara, 7, "@P4", DbType.String, 10, _V4)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try

    End Function

#End Region
#Region "  Save Look For Data "

    Public Shared Sub LookFor(ByVal _user As String, ByVal ds As DataSet, ByVal _DomainID As String)
        Try
            Dim Row As DataRow
            Dim DT As DataTable = ds.Tables(1)
            Dim countR As Integer = ds.Tables(1).Rows.Count
            For Each Row In DT.Rows ' .GetChanges(DataRowState.Deleted).Rows
                Select Case Row.RowState
                    Case DataRowState.Deleted
                        Dim _V0 As String = Row(0, DataRowVersion.Original)   'Competency_ID,
                        Dim _V1 As String = Row(1, DataRowVersion.Original) '  DomainID, 
                        Dim _V2 As String = Row(2, DataRowVersion.Original) '	LookFor_ID,
                        Dim _Resoult As String = IsSaveValueOK_LookFor(_user, "Delete", _V0, _V1, _V2)
                        If Not _Resoult = "OK" Then CommonTCDSB.ShowMsg.Message("", "Data Delete ", _Resoult)
                    Case DataRowState.Added
                        getdataANDUpdate_LookFor(_user, Row, "Insert", _DomainID)
                    Case DataRowState.Modified
                        getdataANDUpdate_LookFor(_user, Row, "Update", _DomainID)
                End Select
            Next
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try

    End Sub
    Private Shared Sub getdataANDUpdate_LookFor(ByVal _user As String, ByVal Row As DataRow, ByVal _opreate As String, ByVal _domainID As String)
        Try
            Dim _V0 As String = getmyItem(Row(0, DataRowVersion.Current)) '		Competency_ID,
            Dim _V1 As String = _domainID  ' getmyItem(Row(1, DataRowVersion.Current)) 'DomainID, 
            Dim _V2 As String = getmyItem(Row(2, DataRowVersion.Current)) '	LookFor_ID,
            Dim _V3 As String = getmyItem(Row(3, DataRowVersion.Current)) '	Observed_LookFor,
            Dim _V4 As String = IIf(getmyItem(Row(4, DataRowVersion.Current)) = "True", "1", "0") '	Status
            Dim _V5 As String = DateFC.YMD(getmyItem(Row(5, DataRowVersion.Current))) '	inactive_ date
            Dim _Resoult As String = IsSaveValueOK_LookFor(_user, _opreate, _V0, _V1, _V2, _V3, _V4, _V5)
            If Not _Resoult = "OK" Then CommonTCDSB.ShowMsg.Message(cPage, "Data Update", _Resoult)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try
    End Sub
    Private Shared Function IsSaveValueOK_LookFor(ByVal _user As String, ByVal _Operate As String, _
                                         Optional ByVal _V0 As String = "NxN", _
                                         Optional ByVal _V1 As String = "NxN", _
                                         Optional ByVal _V2 As String = "NxN", _
                                         Optional ByVal _V3 As String = "NxN", _
                                         Optional ByVal _V4 As String = "NxN", _
                                         Optional ByVal _V5 As String = "NxN") As String
        Dim _SP As String = "dbo.tcdsb_TPA_Save_LookFor"
        Try
            ' If Webconfig.Datasource = "WebService" Then
            Dim myPara(8) ' As tpaWS.MyParameter  'TCDSB.Student.Data.MyParameter      ' MyParameterStructure
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _user)
            setParameterArray(myPara, 1, "@Domain", DbType.String, 30, _domain)
            setParameterArray(myPara, 2, "@Operate", DbType.String, 20, _Operate)
            setParameterArray(myPara, 3, "@P0", DbType.String, 10, _V0)
            setParameterArray(myPara, 4, "@P1", DbType.String, 10, _V1)
            setParameterArray(myPara, 5, "@P2", DbType.String, 10, _V2)
            setParameterArray(myPara, 6, "@P3", DbType.String, 250, _V3)
            setParameterArray(myPara, 7, "@P4", DbType.String, 2, _V4)
            setParameterArray(myPara, 8, "@P5", DbType.String, 10, _V5)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try

    End Function

#End Region
#Region "  Save Evidence  Data "

    Public Shared Sub Evidence(ByVal _user As String, ByVal ds As DataSet)
        Try
            Dim Row As DataRow
            Dim DT As DataTable = ds.Tables(0)
            Dim countR As Integer = ds.Tables(0).Rows.Count
            For Each Row In DT.Rows ' .GetChanges(DataRowState.Deleted).Rows
                Select Case Row.RowState
                    Case DataRowState.Deleted
                        Dim _V0 As String = Row(0, DataRowVersion.Original)  '	  Evidence_ID, 
                        Dim _V1 As String = "" 'Row(1, DataRowVersion.Original) '	Person_ID,
                        Dim _V2 As String = "" ' Row(2, DataRowVersion.Original) '	FormNo,
                        Dim _Resoult As String = IsSaveValueOK_Evidence(_user, "Delete", _V0, _V1, _V2)
                        If Not _Resoult = "OK" Then CommonTCDSB.ShowMsg.Message("", "Data Delete ", _Resoult)
                    Case DataRowState.Added
                        getdataANDUpdate_Evidence(_user, Row, "Insert")
                    Case DataRowState.Modified
                        getdataANDUpdate_Evidence(_user, Row, "Update")
                End Select
            Next
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try

    End Sub
    Private Shared Sub getdataANDUpdate_Evidence(ByVal _user As String, ByVal Row As DataRow, ByVal _opreate As String)
        Try
            Dim _V0 As String = getmyItem(Row(0, DataRowVersion.Current)) '	Evidence_ID, 
            Dim _V1 As String = getmyItem(Row(1, DataRowVersion.Current)) '	Evidence,
            Dim _V2 As String = getmyItem(Row(2, DataRowVersion.Current)) '	Notes,
            Dim _V3 As String = IIf(getmyItem(Row(3, DataRowVersion.Current)) = "True", "1", "0") '	Status
            Dim _V4 As String = DateFC.YMD(getmyItem(Row(4, DataRowVersion.Current)))   'inactive_date
            Dim _Resoult As String = IsSaveValueOK_Evidence(_user, _opreate, _V0, _V1, _V2, _V3, _V4)
            If Not _Resoult = "OK" Then CommonTCDSB.ShowMsg.Message(cPage, "Data Update", _Resoult)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try
    End Sub
    Private Shared Function IsSaveValueOK_Evidence(ByVal _user As String, ByVal _Operate As String, _
                                         Optional ByVal _V0 As String = "NxN", _
                                         Optional ByVal _V1 As String = "NxN", _
                                         Optional ByVal _V2 As String = "NxN", _
                                         Optional ByVal _V3 As String = "NxN", _
                                         Optional ByVal _V4 As String = "NxN") As String

        Dim _SP As String = "dbo.tcdsb_TPA_Save_Evidence"
        Try
            ' If Webconfig.Datasource = "WebService" Then
            Dim myPara(7) ' As tpaWS.MyParameter  'TCDSB.Student.Data.MyParameter      ' MyParameterStructure
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _user)
            setParameterArray(myPara, 1, "@Domain", DbType.String, 30, _domain)
            setParameterArray(myPara, 2, "@Operate", DbType.String, 20, _Operate)
            setParameterArray(myPara, 3, "@P0", DbType.String, 10, _V0)
            setParameterArray(myPara, 4, "@P1", DbType.String, 50, _V1)
            setParameterArray(myPara, 5, "@P2", DbType.String, 200, _V2)
            setParameterArray(myPara, 6, "@P3", DbType.String, 2, _V3)
            setParameterArray(myPara, 7, "@P4", DbType.String, 10, _V4)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try
    End Function

#End Region
#Region "  Save Comment Category  Data "

    Public Shared Sub CommentCategory(ByVal _user As String, ByVal ds As DataSet)
        Try
            Dim Row As DataRow
            Dim DT As DataTable = ds.Tables(0)
            Dim countR As Integer = ds.Tables(0).Rows.Count
            For Each Row In DT.Rows ' .GetChanges(DataRowState.Deleted).Rows
                Select Case Row.RowState
                    Case DataRowState.Deleted
                        Dim _V0 As String = Row(0, DataRowVersion.Original)  '	  Evidence_ID, 
                        Dim _V1 As String = "" 'Row(1, DataRowVersion.Original) '	Person_ID,
                        Dim _V2 As String = "" ' Row(2, DataRowVersion.Original) '	FormNo,
                        Dim _Resoult As String = IsSaveValueOK_CommentCategory(_user, "Delete", _V0, _V1, _V2)
                        If Not _Resoult = "OK" Then CommonTCDSB.ShowMsg.Message("", "Data Delete ", _Resoult)
                    Case DataRowState.Added
                        getdataANDUpdate_CommentCategory(_user, Row, "Insert")
                    Case DataRowState.Modified
                        getdataANDUpdate_CommentCategory(_user, Row, "Update")
                End Select
            Next
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try

    End Sub
    Private Shared Sub getdataANDUpdate_CommentCategory(ByVal _user As String, ByVal Row As DataRow, ByVal _opreate As String)
        Try
            Dim _V0 As String = getmyItem(Row(0, DataRowVersion.Current)) '	Category_ID, 
            Dim _V1 As String = getmyItem(Row(1, DataRowVersion.Current)) '	Comment Category,
            Dim _V2 As String = getmyItem(Row(2, DataRowVersion.Current)) '	Notes,
            Dim _V3 As String = IIf(getmyItem(Row(3, DataRowVersion.Current)) = "True", "1", "0") '	Status
            Dim _V4 As String = DateFC.YMD(getmyItem(Row(4, DataRowVersion.Current)))   'inactive_date
            Dim _Resoult As String = IsSaveValueOK_CommentCategory(_user, _opreate, _V0, _V1, _V2, _V3, _V4)
            If Not _Resoult = "OK" Then CommonTCDSB.ShowMsg.Message(cPage, "Data Update", _Resoult)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try
    End Sub
    Private Shared Function IsSaveValueOK_CommentCategory(ByVal _user As String, ByVal _Operate As String, _
                                         Optional ByVal _V0 As String = "NxN", _
                                         Optional ByVal _V1 As String = "NxN", _
                                         Optional ByVal _V2 As String = "NxN", _
                                         Optional ByVal _V3 As String = "NxN", _
                                         Optional ByVal _V4 As String = "NxN") As String

        Dim _SP As String = "dbo.tcdsb_TPA_Save_CommentCategory"
        Try
            ' If Webconfig.Datasource = "WebService" Then
            Dim myPara(7) ' As tpaWS.MyParameter  'TCDSB.Student.Data.MyParameter      ' MyParameterStructure
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _user)
            setParameterArray(myPara, 1, "@Domain", DbType.String, 30, _domain)
            setParameterArray(myPara, 2, "@Operate", DbType.String, 20, _Operate)
            setParameterArray(myPara, 3, "@P0", DbType.String, 10, _V0)
            setParameterArray(myPara, 4, "@P1", DbType.String, 50, _V1)
            setParameterArray(myPara, 5, "@P2", DbType.String, 200, _V2)
            setParameterArray(myPara, 6, "@P3", DbType.String, 2, _V3)
            setParameterArray(myPara, 7, "@P4", DbType.String, 10, _V4)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try
    End Function

#End Region
#Region "  Save Level Achieved Data "

    Public Shared Sub Achieved(ByVal _user As String, ByVal ds As DataSet)
        Try
            Dim Row As DataRow
            Dim DT As DataTable = ds.Tables(0)
            Dim countR As Integer = ds.Tables(0).Rows.Count
            For Each Row In DT.Rows ' .GetChanges(DataRowState.Deleted).Rows
                Select Case Row.RowState
                    Case DataRowState.Deleted
                        Dim _V0 As String = Row(0, DataRowVersion.Original)  '	DomainID, 
                        Dim _V1 As String = "" 'Row(1, DataRowVersion.Original) '	Person_ID,
                        Dim _V2 As String = "" ' Row(2, DataRowVersion.Original) '	FormNo,
                        Dim _Resoult As String = IsSaveValueOK_Achieved(_user, "Delete", _V0, _V1, _V2)
                        If Not _Resoult = "OK" Then CommonTCDSB.ShowMsg.Message("", "Data Delete ", _Resoult)
                    Case DataRowState.Added
                        getdataANDUpdate_Achieved(_user, Row, "Insert")
                    Case DataRowState.Modified
                        getdataANDUpdate_Achieved(_user, Row, "Update")
                End Select
            Next
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try

    End Sub
    Private Shared Sub getdataANDUpdate_Achieved(ByVal _user As String, ByVal Row As DataRow, ByVal _opreate As String)
        Try
            Dim _V0 As String = getmyItem(Row(0, DataRowVersion.Current)) '	DomainID, 
            Dim _V1 As String = getmyItem(Row(1, DataRowVersion.Current)) '	Domain_name,
            Dim _V2 As String = getmyItem(Row(2, DataRowVersion.Current)) '	Notes,
            Dim _V3 As String = IIf(getmyItem(Row(3, DataRowVersion.Current)) = "True", "1", "0") '	Final_Rating
            Dim _V4 As String = DateFC.YMD(getmyItem(Row(4, DataRowVersion.Current)))   '	inactive_date

            Dim _Resoult As String = IsSaveValueOK_Achieved(_user, _opreate, _V0, _V1, _V2, _V3, _V4)
            If Not _Resoult = "OK" Then CommonTCDSB.ShowMsg.Message(cPage, "Data Update", _Resoult)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try
    End Sub
    Private Shared Function IsSaveValueOK_Achieved(ByVal _user As String, ByVal _Operate As String, _
                                         Optional ByVal _V0 As String = "NxN", _
                                         Optional ByVal _V1 As String = "NxN", _
                                         Optional ByVal _V2 As String = "NxN", _
                                          Optional ByVal _V3 As String = "NxN", _
                                        Optional ByVal _V4 As String = "NxN") As String
        Dim _SP As String = "dbo.tcdsb_TPA_Save_Achieved"
        Try
            ' If Webconfig.Datasource = "WebService" Then
            Dim myPara(7) ' As tpaWS.MyParameter  'TCDSB.Student.Data.MyParameter      ' MyParameterStructure
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _user)
            setParameterArray(myPara, 1, "@Domain", DbType.String, 30, _domain)
            setParameterArray(myPara, 2, "@Operate", DbType.String, 20, _Operate)
            setParameterArray(myPara, 3, "@P0", DbType.String, 10, _V0)
            setParameterArray(myPara, 4, "@P1", DbType.String, 50, _V1)
            setParameterArray(myPara, 5, "@P2", DbType.String, 200, _V2)
            setParameterArray(myPara, 6, "@P3", DbType.String, 2, _V3)
            setParameterArray(myPara, 7, "@P4", DbType.String, 10, _V4)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try
    End Function

#End Region
#Region "  Save Comment Bank Data "

    Public Shared Sub CommentBank(ByVal _user As String, ByVal ds As DataSet, ByVal _Type As String, ByVal _Schoolcode As String, ByVal _domainID As String, ByVal _Owner As String)
        Try
            Dim Row As DataRow
            Dim DT As DataTable = ds.Tables(0)
            Dim countR As Integer = ds.Tables(0).Rows.Count
            For Each Row In DT.Rows ' .GetChanges(DataRowState.Deleted).Rows
                Select Case Row.RowState
                    Case DataRowState.Deleted
                        Dim _V0 As String = Row(0, DataRowVersion.Original)  '	DomainID, 
                        Dim _V1 As String = Row(1, DataRowVersion.Original) '	Bank_ID,
                        Dim _V2 As String = "" ' Row(2, DataRowVersion.Original) '	FormNo,
                        Dim _Resoult As String = IsSaveValueOK_bank(_user, _Schoolcode, "Delete", _V0, _V1, _V2)
                        If Not _Resoult = "OK" Then CommonTCDSB.ShowMsg.Message("", "Data Delete ", _Resoult)
                    Case DataRowState.Added
                        getdataANDUpdate_bank(_user, Row, "Insert", _Type, _Schoolcode, _domainID, _Owner)
                    Case DataRowState.Modified
                        getdataANDUpdate_bank(_user, Row, "Update", _Type, _Schoolcode, _domainID, _Owner)
                End Select
            Next
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try

    End Sub
    Private Shared Sub getdataANDUpdate_bank(ByVal _user As String, ByVal Row As DataRow, ByVal _opreate As String, ByVal _Type As String, ByVal _Schoolcode As String, ByVal _domainID As String, ByVal _Owner As String)
        Try   'DomainID,Bank_ID,Shared,Status,Comments 
            Dim _V0 As String = _domainID 'getmyItem(Row(0, DataRowVersion.Current)) '	DomainID, 
            Dim _V1 As String = getmyItem(Row(1, DataRowVersion.Current)) '	Bank_ID,
            Dim _V2 As String = getmyItem(Row(2, DataRowVersion.Current)) '	shared
            Dim _V3 As String = IIf(getmyItem(Row(3, DataRowVersion.Current)) = "True", "1", "0") '	Status
            Dim _V4 As String = getmyItem(Row(4, DataRowVersion.Current)) 'Comment,
            Dim _V5 As String = DateFC.YMD(getmyItem(Row(5, DataRowVersion.Current))) 'inactive date
            Dim _V6 As String = _Type 'getmyItem(Row(2, DataRowVersion.Current)) '	Type,
            Dim _V7 As String = _Owner
            Dim _Resoult As String = IsSaveValueOK_bank(_user, _Schoolcode, _opreate, _V0, _V1, _V2, _V3, _V4, _V5, _V6, _V7)
            If Not _Resoult = "OK" Then CommonTCDSB.ShowMsg.Message(cPage, "Data Update", _Resoult)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try
    End Sub
    Private Shared Function IsSaveValueOK_bank(ByVal _user As String, ByVal _schoolcode As String, ByVal _Operate As String, _
                                         Optional ByVal _V0 As String = "NxN", _
                                         Optional ByVal _V1 As String = "NxN", _
                                         Optional ByVal _V2 As String = "NxN", _
                                         Optional ByVal _V3 As String = "NxN", _
                                         Optional ByVal _V4 As String = "NxN", _
                                         Optional ByVal _V5 As String = "NxN", _
                                         Optional ByVal _V6 As String = "NxN", _
                                         Optional ByVal _V7 As String = "NxN") As String
        Dim _SP As String = "dbo.tcdsb_TPA_Save_CommentBank"
        Try
            ' If Webconfig.Datasource = "WebService" Then
            Dim myPara(11) ' As tpaWS.MyParameter  'TCDSB.Student.Data.MyParameter      ' MyParameterStructure
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _user)
            setParameterArray(myPara, 1, "@Domain", DbType.String, 30, _domain)
            setParameterArray(myPara, 2, "@SchoolCode", DbType.String, 8, _schoolcode)
            setParameterArray(myPara, 3, "@Operate", DbType.String, 20, _Operate)
            setParameterArray(myPara, 4, "@P0", DbType.String, 10, _V0)
            setParameterArray(myPara, 5, "@P1", DbType.String, 10, _V1)
            setParameterArray(myPara, 6, "@P2", DbType.String, 20, _V2)
            setParameterArray(myPara, 7, "@P3", DbType.String, 2, _V3)
            setParameterArray(myPara, 8, "@P4", DbType.String, 250, _V4)
            setParameterArray(myPara, 9, "@P5", DbType.String, 10, _V5)
            setParameterArray(myPara, 10, "@Type", DbType.String, 20, _V6)
            setParameterArray(myPara, 11, "@Owner", DbType.String, 20, _V7)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try

    End Function

#End Region
#Region "  Save Summative Data "

    Public Shared Sub SummativeTab(ByVal _user As String, ByVal ds As DataSet)
        Try
            Dim Row As DataRow
            Dim DT As DataTable = ds.Tables(0)
            Dim countR As Integer = ds.Tables(0).Rows.Count
            For Each Row In DT.Rows ' .GetChanges(DataRowState.Deleted).Rows
                Select Case Row.RowState
                    Case DataRowState.Deleted
                        Dim _V0 As String = Row(0, DataRowVersion.Original)  '	DomainID, 
                        Dim _V1 As String = "" 'Row(1, DataRowVersion.Original) '	Person_ID,
                        Dim _V2 As String = "" ' Row(2, DataRowVersion.Original) '	FormNo,
                        Dim _Resoult As String = IsSaveValueOK_SummativeTab(_user, "Delete", _V0, _V1, _V2)
                        If Not _Resoult = "OK" Then CommonTCDSB.ShowMsg.Message("", "Data Delete ", _Resoult)
                    Case DataRowState.Added
                        getdataANDUpdate_SummativeTab(_user, Row, "Insert")
                    Case DataRowState.Modified
                        getdataANDUpdate_SummativeTab(_user, Row, "Update")
                End Select
            Next
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try

    End Sub
    Private Shared Sub getdataANDUpdate_SummativeTab(ByVal _user As String, ByVal Row As DataRow, ByVal _opreate As String)
        Try
            Dim _V0 As String = getmyItem(Row(0, DataRowVersion.Current)) '	DomainID, 
            Dim _V1 As String = getmyItem(Row(1, DataRowVersion.Current)) '	Domain_name,
            Dim _V2 As String = getmyItem(Row(2, DataRowVersion.Current)) '	Notes,
            Dim _V3 As String = getmyItem(Row(3, DataRowVersion.Current))  '	Status
            Dim _V4 As String = DateFC.YMD(getmyItem(Row(4, DataRowVersion.Current)))   '	Inactive_date
            Dim _Resoult As String = IsSaveValueOK_SummativeTab(_user, _opreate, _V0, _V1, _V2, _V3, _V4)
            If Not _Resoult = "OK" Then CommonTCDSB.ShowMsg.Message(cPage, "Data Update", _Resoult)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try
    End Sub
    Private Shared Function IsSaveValueOK_SummativeTab(ByVal _user As String, ByVal _Operate As String, _
                                         Optional ByVal _V0 As String = "NxN", _
                                         Optional ByVal _V1 As String = "NxN", _
                                         Optional ByVal _V2 As String = "NxN", _
                                         Optional ByVal _V3 As String = "NxN", _
                                         Optional ByVal _V4 As String = "NxN") As String
        Dim _SP As String = "dbo.tcdsb_TPA_Save_SummativeTab"
        Try
            ' If Webconfig.Datasource = "WebService" Then
            Dim myPara(7) ' As tpaWS.MyParameter  'TCDSB.Student.Data.MyParameter      ' MyParameterStructure
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _user)
            setParameterArray(myPara, 1, "@Domain", DbType.String, 30, _domain)
            setParameterArray(myPara, 2, "@Operate", DbType.String, 20, _Operate)
            setParameterArray(myPara, 3, "@P0", DbType.String, 10, _V0)
            setParameterArray(myPara, 4, "@P1", DbType.String, 50, _V1)
            setParameterArray(myPara, 5, "@P2", DbType.String, 200, _V2)
            setParameterArray(myPara, 6, "@P3", DbType.String, 2, _V3)
            setParameterArray(myPara, 7, "@P4", DbType.String, 10, _V4)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try

    End Function

#End Region
#Region "  Save TA Function "
    Public Shared Sub TAFunction(ByVal _user As String, ByVal ds As DataSet)
        Try
            Dim Row As DataRow
            Dim DT As DataTable = ds.Tables(0)
            Dim countR As Integer = ds.Tables(0).Rows.Count
            For Each Row In DT.Rows ' .GetChanges(DataRowState.Deleted).Rows
                Select Case Row.RowState
                    Case DataRowState.Deleted
                        Dim _V0 As String = Row(0, DataRowVersion.Original)  '	DomainID, 
                        Dim _V1 As String = "" 'Row(1, DataRowVersion.Original) '	Person_ID,
                        Dim _V2 As String = "" ' Row(2, DataRowVersion.Original) '	FormNo,
                        Dim _Resoult As String = IsSaveValueOK_TAFunction(_user, "Delete", _V0, _V1, _V2)
                        If Not _Resoult = "OK" Then CommonTCDSB.ShowMsg.Message("", "Data Delete ", _Resoult)
                    Case DataRowState.Added
                        getdataANDUpdate_TAFunction(_user, Row, "Insert")
                    Case DataRowState.Modified
                        getdataANDUpdate_TAFunction(_user, Row, "Update")
                End Select
            Next
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try

    End Sub
    Private Shared Sub getdataANDUpdate_TAFunction(ByVal _user As String, ByVal Row As DataRow, ByVal _opreate As String)
        Try
            Dim _V0 As String = getmyItem(Row(0, DataRowVersion.Current)) '	FunctionID, 
            Dim _V1 As String = getmyItem(Row(1, DataRowVersion.Current)) '	Domain_name,
            Dim _V2 As String = getmyItem(Row(2, DataRowVersion.Current)) '	Notes,
            Dim _V3 As String = getmyItem(Row(3, DataRowVersion.Current))  '	Status
            Dim _V4 As String = DateFC.YMD(getmyItem(Row(4, DataRowVersion.Current)))   '	Inactive_date
            Dim _Resoult As String = IsSaveValueOK_TAFunction(_user, _opreate, _V0, _V1, _V2, _V3, _V4)
            If Not _Resoult = "OK" Then CommonTCDSB.ShowMsg.Message(cPage, "Data Update", _Resoult)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try
    End Sub
    Private Shared Function IsSaveValueOK_TAFunction(ByVal _user As String, ByVal _Operate As String, _
                                         Optional ByVal _V0 As String = "NxN", _
                                         Optional ByVal _V1 As String = "NxN", _
                                         Optional ByVal _V2 As String = "NxN", _
                                         Optional ByVal _V3 As String = "NxN", _
                                         Optional ByVal _V4 As String = "NxN") As String

        Dim _SP As String = "dbo.tcdsb_TPA_Save_TAFunction"
        Try
            ' If Webconfig.Datasource = "WebService" Then
            Dim myPara(7) ' As tpaWS.MyParameter  'TCDSB.Student.Data.MyParameter      ' MyParameterStructure
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _user)
            setParameterArray(myPara, 1, "@Domain", DbType.String, 30, _domain)
            setParameterArray(myPara, 2, "@Operate", DbType.String, 20, _Operate)
            setParameterArray(myPara, 3, "@P0", DbType.String, 10, _V0)
            setParameterArray(myPara, 4, "@P1", DbType.String, 50, _V1)
            setParameterArray(myPara, 5, "@P2", DbType.String, 200, _V2)
            setParameterArray(myPara, 6, "@P3", DbType.String, 2, _V3)
            setParameterArray(myPara, 7, "@P4", DbType.String, 10, _V4)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try

    End Function

#End Region
#Region "  Save TA Tab Data "

    Public Shared Sub TATab(ByVal _user As String, ByVal ds As DataSet, ByVal _DomainID As String, ByVal _tabName As String)
        Try
            Dim Row As DataRow
            Dim DT As DataTable = ds.Tables(0)
            Dim countR As Integer = ds.Tables(0).Rows.Count
            For Each Row In DT.Rows ' .GetChanges(DataRowState.Deleted).Rows
                Select Case Row.RowState
                    Case DataRowState.Deleted
                        Dim _V0 As String = Row(0, DataRowVersion.Original)   '	FunctionID, 
                        Dim _V1 As String = Row(1, DataRowVersion.Original) '	Competency_ID,
                        Dim _V2 As String = "" ' Row(2, DataRowVersion.Original) '	FormNo,
                        Dim _Resoult As String = IsSaveValueOK_TATab(_user, "Delete", _V0, _V1, _V2)
                        If Not _Resoult = "OK" Then CommonTCDSB.ShowMsg.Message("", "Data Delete ", _Resoult)
                    Case DataRowState.Added
                        getdataANDUpdate_TATab(_user, Row, "Insert", _DomainID, _tabName)
                    Case DataRowState.Modified
                        getdataANDUpdate_TATab(_user, Row, "Update", _DomainID, _tabName)
                End Select
            Next
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try

    End Sub
    Private Shared Sub getdataANDUpdate_TATab(ByVal _user As String, ByVal Row As DataRow, ByVal _opreate As String, ByVal _domainID As String, ByVal _tabName As String)
        Try
            Dim _V0 As String = _domainID 'getmyItem(Row(0, DataRowVersion.Current)) '	FunctionID, 
            Dim _V1 As String = getmyItem(Row(1, DataRowVersion.Current)) '	Tab_ID,
            Dim _V2 As String = getmyItem(Row(2, DataRowVersion.Current)) '	Competency,
            Dim _V3 As String = getmyItem(Row(3, DataRowVersion.Current)) '	Competency,
            Dim _V4 As String = IIf(getmyItem(Row(4, DataRowVersion.Current)) = "True", "1", "0") '	Status
            Dim _V5 As String = DateFC.YMD(getmyItem(Row(5, DataRowVersion.Current))) '	inactive_ date
            Dim _V6 As String = getmyItem(Row(6, DataRowVersion.Current)) '	seqid
            Dim _V7 As String = _tabName
            Dim _Resoult As String = IsSaveValueOK_TATab(_user, _opreate, _V0, _V1, _V2, _V3, _V4, _V5, _V6, _V7)
            If Not _Resoult = "OK" Then CommonTCDSB.ShowMsg.Message(cPage, "Data Update", _Resoult)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try
    End Sub
    Private Shared Function IsSaveValueOK_TATab(ByVal _user As String, ByVal _Operate As String, _
                                         Optional ByVal _V0 As String = "NxN", _
                                         Optional ByVal _V1 As String = "NxN", _
                                         Optional ByVal _V2 As String = "NxN", _
                                         Optional ByVal _V3 As String = "NxN", _
                                         Optional ByVal _V4 As String = "NxN", _
                                         Optional ByVal _V5 As String = "NxN", _
                                         Optional ByVal _V6 As String = "NxN", _
                                         Optional ByVal _V7 As String = "NxN") As String
        Dim _SP As String = "dbo.tcdsb_TPA_Save_TAtab"
        Try
            ' If Webconfig.Datasource = "WebService" Then
            Dim myPara(10) ' As tpaWS.MyParameter  'TCDSB.Student.Data.MyParameter      ' MyParameterStructure
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _user)
            setParameterArray(myPara, 1, "@Domain", DbType.String, 30, _domain)
            setParameterArray(myPara, 2, "@Operate", DbType.String, 20, _Operate)
            setParameterArray(myPara, 3, "@P0", DbType.String, 10, _V0)
            setParameterArray(myPara, 4, "@P1", DbType.String, 10, _V1)
            setParameterArray(myPara, 5, "@P2", DbType.String, 50, _V2)
            setParameterArray(myPara, 6, "@P3", DbType.String, 250, _V3)
            setParameterArray(myPara, 7, "@P4", DbType.String, 2, _V4)
            setParameterArray(myPara, 8, "@P5", DbType.String, 10, _V5)
            setParameterArray(myPara, 9, "@P6", DbType.String, 10, _V6)
            setParameterArray(myPara, 10, "@P7", DbType.String, 100, _V7)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try

    End Function

#End Region
#Region "  Save New Staff  Data "

    Public Shared Sub NewStaff(ByVal _user As String, ByVal _NewStaffID As String, ByVal _NewStaffName As String, ByVal _SchoolCode As String, ByVal _AdminID As String)
        Try
            Dim _Resoult As String = IsSaveValueOK_NewStaff(_user, "Insert", _NewStaffID, _NewStaffName, _AdminID, _SchoolCode)
            If Not _Resoult = "OK" Then CommonTCDSB.ShowMsg.Message(cPage, "Data Insert ", _Resoult)

        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try
    End Sub
    Public Shared Sub MoveStaff(ByVal _user As String, ByVal _StaffID As String, ByVal _SchoolCode As String)
        Try
            Dim _Resoult As String = IsSaveValueOK_NewStaff(_user, "Delete", _StaffID, "Move", "Move", _SchoolCode)
            If Not _Resoult = "OK" Then CommonTCDSB.ShowMsg.Message(cPage, "Data Delete ", _Resoult)

        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
        End Try
    End Sub
    Private Shared Function IsSaveValueOK_NewStaff(ByVal _user As String, ByVal _Operate As String, _
                                         Optional ByVal _V0 As String = "NxN", _
                                         Optional ByVal _V1 As String = "NxN", _
                                         Optional ByVal _V2 As String = "NxN", _
                                         Optional ByVal _V3 As String = "NxN") As String

        Dim _SP As String = "dbo.tcdsb_TPA_Save_NewStaff"
        Try
            ' If Webconfig.Datasource = "WebService" Then
            Dim myPara(6) ' As tpaWS.MyParameter  'TCDSB.Student.Data.MyParameter      ' MyParameterStructure
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _user)
            setParameterArray(myPara, 1, "@Domain", DbType.String, 30, _domain)
            setParameterArray(myPara, 2, "@Operate", DbType.String, 20, _Operate)
            setParameterArray(myPara, 3, "@P0", DbType.String, 30, _V0)
            setParameterArray(myPara, 4, "@P1", DbType.String, 50, _V1)
            setParameterArray(myPara, 5, "@P2", DbType.String, 30, _V2)
            setParameterArray(myPara, 6, "@P3", DbType.String, 8, _V3)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try
    End Function

#End Region
#Region "  Generel Function "
    Private Shared Function getOperate(ByVal row As DataRow) As String
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
    Private Shared Function getmyItem(ByVal myItem As Object) As String '  myRow.Item(4)) 
        Dim x As String
        Try
            x = myItem
        Catch ex As Exception
            x = ""
        End Try
        Return x
    End Function
    Private Shared Function CheckBoxValue(ByVal _Seq As Integer, ByVal ds As DataSet) As Boolean
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
    Private Shared Function CheckBoxString(ByVal _temp As Boolean) As String
        Dim rVal As String
        If _temp = True Then
            rVal = "1"
        Else
            rVal = "0"
        End If
        Return rVal
    End Function

#End Region
End Class
Public Class QualificationSetup
    Public Shared Function MatchList(ByVal _Type As String, ByVal _UserID As String, ByVal _Action As String) As DataSet
        Try
            Dim _SP As String = "dbo.tcdsb_LTO_QualificationMatchSetup"
            Dim myPara(2) ' ' As tpaWS.MyParameter  ' TCDSB.Student.Data.MyParameter     
            setParameterArray(myPara, 0, "@Type", DbType.String, 20, _Type)
            setParameterArray(myPara, 1, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 2, "@Action", DbType.String, 20, _Action)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            'CommonTCDSB.ShowMsg. Exception(ex, , " get comment Comment.")
            Return Nothing
        End Try
    End Function
    Public Shared Sub Operation(ByVal _Type As String, ByVal _UserID As String, ByVal _Action As String, ByVal IDs As String, ByVal _Assignment As String, ByVal _Qualification As String, ByVal _Level As String, ByVal _Code As String)
        Try
            Dim _SP As String = "dbo.tcdsb_LTO_QualificationMatchSetup"
            Dim myPara(7) ' ' As tpaWS.MyParameter  ' TCDSB.Student.Data.MyParameter     
            setParameterArray(myPara, 0, "@Type", DbType.String, 20, _Type)
            setParameterArray(myPara, 1, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 2, "@Action", DbType.String, 20, _Action)
            setParameterArray(myPara, 3, "@IDs", DbType.String, 10, IDs)
            setParameterArray(myPara, 4, "@Assignment", DbType.String, 100, _Assignment)
            setParameterArray(myPara, 5, "@Qualification", DbType.String, 100, _Qualification)
            setParameterArray(myPara, 6, "@Level", DbType.String, 50, _Level)
            setParameterArray(myPara, 7, "@Code", DbType.String, 10, _Code)

            getMyDataSet(_SP, myPara)
        Catch ex As Exception
            'CommonTCDSB.ShowMsg. Exception(ex, , " get comment Comment.")

        End Try
    End Sub

End Class