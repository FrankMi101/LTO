'Imports System.Data.SqlClient
Imports TCDSB.Student.Data
Imports System.Data.SqlClient
Imports System.Web
'Namespace TCDSB.Student.BIP
Namespace CommonTCDSB
    Public Class Menus
        Public Shared cPage As Object
        Public Shared Function GetGroupMenus(ByVal Group_ID As String, ByVal _UserID As String, Optional ByVal permission As String = "")
            Try
                Dim _SP As String = "tcdsb_TPA_MenuList"
                Dim myPara(3) '' As tpaWS.MyParameter
                setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
                setParameterArray(myPara, 1, "@Domain", DbType.String, 30, _UserID)
                setParameterArray(myPara, 2, "@GroupID", DbType.String, 20, Group_ID)
                setParameterArray(myPara, 3, "@Permission", DbType.String, 20, permission)
                Return getMyDataSet(_SP, myPara)
            Catch ex As Exception
                ' CommonTCDSB.ShowMsg. Exception(ex, cPage, " get Comments bank action.")
                Return Nothing
            End Try
        End Function
        Public Shared Function LoginASshow(ByVal _userID As String) As String
            Try
                Dim _SP As String = "tcdsb_TPA_LoginASshow"
                Dim myPara(0) ' ' As tpaWS.MyParameter
                setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _userID)

                Return getMyDataValue(_SP, myPara)
            Catch ex As Exception
                '  CommonTCDSB.ShowMsg. Exception(ex, cPage, " get Comments bank action.")
                Return Nothing
            End Try
        End Function
        Public Shared Function getTopMenuList(ByVal _user As String, ByVal _Role As String, _
                                          Optional ByVal _SchoolYear As String = "NxN") As DataSet
            Dim _SP As String = "tcdsb_BIP2_sp_topMenu2"
            Try
                ' If Webconfig.Datasource = "WebService" Then
                Dim myPara(2) ' As tpaWS.MyParameter  ' TCDSB.Student.Data.MyParameter     
                setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _user)
                setParameterArray(myPara, 1, "@UserRole", DbType.String, 20, _Role)
                setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _SchoolYear)
                Return getMyDataSet(_SP, myPara)
            Catch ex As Exception
                CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
                Return Nothing
            End Try
        End Function
    End Class

    Public Class MenuSetup
        'Inherits TCDSB.Student.Data
        Public Shared cDataSet As DataSet
        Public Shared cPage As Object
        '   Public Shared _User As String '= HttpContext.Current.User.Identity.Name
        Private Shared _domain As String = HttpContext.Current.User.Identity.Name

#Region " Top & left Menu  List & Tab List Data  "
        Public Shared ReadOnly Property getListMenu(ByVal _user As String, ByVal _Role As String, ByVal _Permission As String, ByVal _EvailationYear As String) As DataSet
            Get
                Return GetLeftMenuData(_user, _Role, _Permission, _EvailationYear)
            End Get
        End Property
        Public Shared ReadOnly Property getListTab(ByVal _user As String, ByVal _Role As String, ByVal _Permission As String, ByVal _Scope As String, ByVal _Position As String, ByVal _GroupID As String, ByVal _ItemsID As String) As DataSet
            Get
                Return GetTabMenuData(_user, _Role, _Permission, _Scope, _Position, _GroupID, _ItemsID)
            End Get
        End Property
        Private Shared Function GetLeftMenuData(ByVal _user As String, ByVal _Role As String, _
                                            Optional ByVal _vPar1 As String = "NxN", _
                                            Optional ByVal _vPar2 As String = "NxN", _
                                            Optional ByVal _vPar3 As String = "NxN", _
                                            Optional ByVal _vPar4 As String = "NxN", _
                                            Optional ByVal _vPar5 As String = "NxN") As DataSet
            Dim _SP As String = "tcdsb_TPA_ListMenu"
            Try
                ' If Webconfig.Datasource = "WebService" Then
                Dim myPara(7) ' As tpaWS.MyParameter  ' TCDSB.Student.Data.MyParameter     
                setParameterArray(myPara, 0, "@Domain", DbType.String, 30, _domain)
                setParameterArray(myPara, 1, "@UserID", DbType.String, 30, _user)
                setParameterArray(myPara, 2, "@Category", DbType.String, 20, _Role)
                setParameterArray(myPara, 3, "@permission", DbType.String, 20, _vPar1)
                setParameterArray(myPara, 4, "@sLevel", DbType.String, 20, _vPar2)
                setParameterArray(myPara, 5, "@Position", DbType.String, 20, _vPar3)
                setParameterArray(myPara, 6, "@GroupID", DbType.String, 20, _vPar4)
                setParameterArray(myPara, 7, "@ItemsID", DbType.String, 20, _vPar5)
                Return getMyDataSet(_SP, myPara)
            Catch ex As Exception
                CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
                Return Nothing
            End Try
        End Function


        Private Shared Function GetTabMenuData(ByVal _user As String, ByVal _Role As String, _
                                            Optional ByVal _vPar1 As String = "NxN", _
                                            Optional ByVal _vPar2 As String = "NxN", _
                                            Optional ByVal _vPar3 As String = "NxN", _
                                            Optional ByVal _vPar4 As String = "NxN", _
                                            Optional ByVal _vPar5 As String = "NxN") As DataSet
            Dim _SP As String = "tcdsb_TPA_ListTabMenu"
            Try
                ' If Webconfig.Datasource = "WebService" Then
                Dim myPara(7) ' As tpaWS.MyParameter  ' TCDSB.Student.Data.MyParameter     
                setParameterArray(myPara, 0, "@Domain", DbType.String, 30, _domain)
                setParameterArray(myPara, 1, "@UserID", DbType.String, 30, _user)
                setParameterArray(myPara, 2, "@Category", DbType.String, 20, _Role)
                setParameterArray(myPara, 3, "@permission", DbType.String, 20, _vPar1)
                setParameterArray(myPara, 4, "@sLevel", DbType.String, 20, _vPar2)
                setParameterArray(myPara, 5, "@Position", DbType.String, 20, _vPar3)
                setParameterArray(myPara, 6, "@GroupID", DbType.String, 20, _vPar4)
                setParameterArray(myPara, 7, "@ItemsID", DbType.String, 20, _vPar5)
                Return getMyDataSet(_SP, myPara)
            Catch ex As Exception
                CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
                Return Nothing
            End Try
        End Function

#End Region

#Region "   Menu Tab List  Edit Data "
        Public Shared Function MenuTabEdit(ByVal _user As String, ByVal _Category As String, ByVal _Permission As String) As DataSet
            Dim _SP As String = "tcdsb_TPA_MenuTabListEdit"
            Try
                ' If Webconfig.Datasource = "WebService" Then
                Dim myPara(3) ' As tpaWS.MyParameter  ' 
                setParameterArray(myPara, 0, "@Domain", DbType.String, 30, _domain)
                setParameterArray(myPara, 1, "@UserID", DbType.String, 30, _user)
                setParameterArray(myPara, 2, "@permission", DbType.String, 20, _Permission)
                setParameterArray(myPara, 3, "@Category", DbType.String, 20, _Category)
                Return getMyDataSet(_SP, myPara)
            Catch ex As Exception
                CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
                Return Nothing
            End Try
        End Function

        Public Shared Sub MenuTabSave(ByVal _user As String, ByVal ds As DataSet, ByVal _Category As String)

            '    Dim Row As DataRow
            SvaeMenuTable(_user, ds.Tables(0), _Category, 0)
            SvaeMenuTable(_user, ds.Tables(1), _Category, 1)
            SvaeMenuTable(_user, ds.Tables(2), _Category, 2)
            '  Dim countR As Integer = ds.Tables(1).Rows.Count

        End Sub
        Private Shared Sub SvaeMenuTable(ByVal _user As String, ByVal DT As DataTable, ByVal _Category As String, ByVal _table As Integer)
            Try
                Dim Row As DataRow
                ' Dim DT As DataTable = ds.Tables(1)
                'Dim countR As Integer = ds.Tables(1).Rows.Count
                For Each Row In DT.Rows ' .GetChanges(DataRowState.Deleted).Rows
                    Select Case Row.RowState
                        Case DataRowState.Deleted
                            Dim _V0 As String = Row(0, DataRowVersion.Original)  '	IDs,
                            Dim _V1 As String = "" 'Row(1, DataRowVersion.Original) '	GroupID,
                            Dim _V2 As String = "" ' Row(2, DataRowVersion.Original) '	ItemsID,
                            Dim _Resoult As String = IsSaveValueOK_MenuTab(_user, "Delete", _V0, _V1, _V2)
                            If Not _Resoult = "OK" Then CommonTCDSB.ShowMsg.Message("", "Data Delete ", _Resoult)
                        Case DataRowState.Added
                            SaveDateSetToDatebase(_user, Row, "Insert", _Category, _table)
                        Case DataRowState.Modified
                            SaveDateSetToDatebase(_user, Row, "Update", _Category, _table)
                    End Select
                Next
            Catch ex As Exception
                CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
            End Try

        End Sub
        Private Shared Sub SaveDateSetToDatebase(ByVal _user As String, ByVal Row As DataRow, ByVal _opreate As String, ByVal _Category As String, ByVal _table As Integer)
            Try
                Dim _IDs As String = getmyItem(Row(0, DataRowVersion.Current)) '	IDs, 
                Dim _V0 As String = getmyItem(Row(1, DataRowVersion.Current)) '	    GroupID,
                Dim _V1 As String = getmyItem(Row(2, DataRowVersion.Current)) '	    ItemID,
                Dim _V2 As String = getmyItem(Row(3, DataRowVersion.Current)) '	    TabID,
                Dim _V3 As String = getmyItem(Row(4, DataRowVersion.Current))  '	myText,
                Dim _V4 As String = getmyItem(Row(5, DataRowVersion.Current)) '	 , TarUrl,
                Dim _V5 As String = getmyItem(Row(6, DataRowVersion.Current)) '	 , TarFrame,
                Dim _V6 As String = IIf(getmyItem(Row(7, DataRowVersion.Current)) = "True", "1", "0") '	 ShowStatus,
                Dim _V7 As String = getmyItem(Row(8, DataRowVersion.Current)) '	 , ShowPremission,
                Dim _V8 As String = getmyItem(Row(9, DataRowVersion.Current)) '	 ,ShowLevel,
                Dim _V9 As String = DateFC.YMD(getmyItem(Row(10, DataRowVersion.Current)))   '	ShowDate 
                Dim _Resoult As String = IsSaveValueOK_MenuTab(_user, _opreate, _Category, _IDs, _V0, _V1, _V2, _V3, _V4, _V5, _V6, _V7, _V8, _V9, _table)

                If Not _Resoult = "OK" Then CommonTCDSB.ShowMsg.Message(cPage, "Data Update", _Resoult)
            Catch ex As Exception
                CommonTCDSB.ShowMsg.Exception(ex, cPage, "Data Update")
            End Try
        End Sub

        Private Shared Function IsSaveValueOK_MenuTab(ByVal _user As String, ByVal _Operate As String, ByVal _Category As String, ByVal _IDs As String, _
                                             Optional ByVal _V0 As String = "NxN", _
                                             Optional ByVal _V1 As String = "NxN", _
                                             Optional ByVal _V2 As String = "NxN", _
                                             Optional ByVal _V3 As String = "NxN", _
                                             Optional ByVal _V4 As String = "NxN", _
                                             Optional ByVal _V5 As String = "NxN", _
                                             Optional ByVal _V6 As String = "NxN", _
                                             Optional ByVal _V7 As String = "NxN", _
                                             Optional ByVal _V8 As String = "NxN", _
                                             Optional ByVal _V9 As String = "NxN", _
                                             Optional ByVal _table As String = "NxN") As String
            Dim _SP As String = "tcdsb_TPA_Save_MenuTabList"
            Try
                ' If Webconfig.Datasource = "WebService" Then
                Dim myPara(15) ' As tpaWS.MyParameter  ' 
                setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _user)
                setParameterArray(myPara, 1, "@Domain", DbType.String, 30, _domain)
                setParameterArray(myPara, 2, "@Operate", DbType.String, 20, _Operate)
                setParameterArray(myPara, 3, "@Category", DbType.String, 20, _Category)
                setParameterArray(myPara, 4, "@IDs", DbType.String, 4, _IDs)
                setParameterArray(myPara, 5, "@P0", DbType.String, 4, _V0)
                setParameterArray(myPara, 6, "@P1", DbType.String, 4, _V1)
                setParameterArray(myPara, 7, "@P2", DbType.String, 4, _V2)
                setParameterArray(myPara, 8, "@P3", DbType.String, 80, _V3)
                setParameterArray(myPara, 9, "@P4", DbType.String, 200, _V4)
                setParameterArray(myPara, 10, "@P5", DbType.String, 20, _V5)
                setParameterArray(myPara, 11, "@P6", DbType.String, 2, _V6)
                setParameterArray(myPara, 12, "@P7", DbType.String, 20, _V7)
                setParameterArray(myPara, 13, "@P8", DbType.String, 20, _V8)
                setParameterArray(myPara, 14, "@P9", DbType.String, 10, _V9)
                setParameterArray(myPara, 15, "@Table", DbType.String, 10, _table)
                Return getMyDataValue(_SP, myPara)
            Catch ex As Exception
                CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
                Return ""
            End Try

        End Function

#End Region

        Private Shared Function getmyItem(ByVal myItem As Object) As String '  myRow.Item(4)) 
            Dim x As String
            Try
                x = myItem
            Catch ex As Exception
                x = ""
            End Try
            Return x
        End Function
    End Class
    Public Class Tabs
        Public Shared ReadOnly Property TabList(ByVal _type As String, ByVal _schoolyear As String, ByVal _schoolcode As String) As DataSet
            Get
                Return getTabList(_type, _schoolyear, _schoolcode)
            End Get
        End Property
        Private Shared Function getTabList(ByVal _type As String, ByVal _schoolyear As String, ByVal _schoolcode As String) As DataSet
            Try
                Dim _SP As String = "dbo.tcdsb_BIP2_sp_TabList"
                Dim myPara(2) 'As Object ' TCDSB.Student.Data.MyParameter  'Object  ' Dim myPara(4) As DataAccessWebService.MyParameter '
                setParameterArray(myPara, 0, "@pType", DbType.String, 30, _type)
                setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
                setParameterArray(myPara, 2, "@Schoolcode", DbType.String, 8, _schoolcode)

                Return getMyDataSet(_SP, myPara)
                ' Return TCDSB.Student.Data.myDataSetA(_SP, myPara)
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Shared ReadOnly Property GradeTabList(ByVal _type As String, ByVal _uID As String, ByVal _uRole As String, ByVal _schoolyear As String, ByVal _schoolcode As String) As DataSet
            Get
                Return getgradeTabList(_type, _uID, _uRole, _schoolyear, _schoolcode)
            End Get
        End Property
        Public Shared ReadOnly Property UserGroupTabList(ByVal _uID As String, ByVal _uRole As String)
            Get
                Return getUserGroupList(_uID, _uRole)
            End Get
        End Property
        Private Shared Function getgradeTabList(ByVal _type As String, ByVal _uID As String, ByVal _uRole As String, ByVal _schoolyear As String, ByVal _schoolcode As String) As DataSet
            Try
                Dim _SP As String = "tcdsb_SES_ListStudents1"
                Dim myPara(4) 'As Object ' TCDSB.Student.Data.MyParameter  'Object  ' Dim myPara(4) As DataAccessWebService.MyParameter '
                setParameterArray(myPara, 0, "@pType", DbType.String, 30, _type)
                setParameterArray(myPara, 1, "@UserID", DbType.String, 30, _uID)
                setParameterArray(myPara, 2, "@uRole", DbType.String, 20, _uRole)
                setParameterArray(myPara, 3, "@SchoolYear", DbType.String, 8, _schoolyear)
                setParameterArray(myPara, 4, "@Schoolcode", DbType.String, 8, _schoolcode)



                Return getMyDataSet(_SP, myPara)
                ' Return TCDSB.Student.Data.myDataSetA(_SP, myPara)
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Private Shared Function getUserGroupList(ByVal _uID As String, ByVal _uRole As String) As DataSet
            Try
                Dim _SP As String = "tcdsb_SES_ListUserGroup"
                Dim myPara(1) 'As Object ' TCDSB.Student.Data.MyParameter  'Object  ' Dim myPara(4) As DataAccessWebService.MyParameter '
                setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _uID)
                setParameterArray(myPara, 1, "@uRole", DbType.String, 20, _uRole)
                Return getMyDataSet(_SP, myPara)
                ' Return TCDSB.Student.Data.myDataSetA(_SP, myPara)
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
    End Class
End Namespace
'End Namespace
