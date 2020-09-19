Imports TCDSB.Student.Data
Imports System.Data.SqlClient
Imports System.Web
Namespace CommonTCDSB

    Public Class UserTrack
        Public Shared Function AttributByID(ByVal _type As String, ByVal _schoolyear As String, _
                                            ByVal _ID As String) As String
            Try
                Dim _SP As String = "dbo.tcdsb_LTO_AttributebyID"
                Dim myPara(2)
                setParameterArray(myPara, 0, "@SchoolYear", DbType.String, 8, _schoolyear)
                setParameterArray(myPara, 1, "@vType", DbType.String, 30, _type)
                setParameterArray(myPara, 2, "@vID", DbType.String, 20, _ID)


                Return getMyDataValue(_SP, myPara)
            Catch ex As Exception
                Return ""
            End Try

        End Function
        Public Shared Function getUserLastParameter(ByVal _userID As String) As DataSet

            Try
                Dim _SP As String = "dbo.tcdsb_LTO_UsersTrack"
                Dim myPara(1)
                setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _userID)
                setParameterArray(myPara, 1, "@vType", DbType.String, 20, "Allinfo")


                Return getMyDataSet(_SP, myPara)
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Property TrackInfo(ByVal _userID As String, ByVal _type As String) As String
            Get
                Return TrackInfoGet(_userID, _type)
            End Get
            Set(ByVal value As String)
                TrackInfoGet(_userID, _type, value)
            End Set
        End Property
        Private Shared Function TrackInfoGet(ByVal _userID As String, ByVal _type As String, _
                                             Optional ByVal _Value As String = "NxN") As String
            Try
                Dim _SP As String = "dbo.tcdsb_LTO_UsersTrack"
                Dim myPara(2)
                setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _userID)
                setParameterArray(myPara, 1, "@vType", DbType.String, 20, _type)
                setParameterArray(myPara, 2, "@vValue", DbType.String, 30, _Value)


                Return getMyDataValue(_SP, myPara)
            Catch ex As Exception
                Return ""
            End Try

        End Function

    End Class
    Public Class UserSecurity
        Public Shared cPage As Object
        Public Shared _domain As String ' = HttpContext.Current.User.Identity.Name
        Public Shared Function showLogin(ByVal _Permission As String) As String
            If _Permission = "Super" Or _Permission = "Design" Then
                Return "Yes"
            Else
                Return "No"
            End If
        End Function
        Public Shared ReadOnly Property TestUserRole(ByVal _UserID As String) As String
            Get
                Return getSecurityRole(_UserID, "Role")
            End Get
        End Property
        Public Shared ReadOnly Property Role(ByVal _user As String) As String
            Get
                Return getSecurityRole(_user, "Role")
            End Get
        End Property
        Public Shared ReadOnly Property Permission(ByVal _user As String, ByVal _role As String) As String
            Get
                Return getSecurityRole(_user, "Permission", _role)
            End Get
        End Property
        Private Shared Function getSecurityRole(ByVal _user As String, ByVal _V0 As String, Optional ByVal _V1 As String = "NxN") As String
            Try
                Dim _SP As String = "dbo.tcdsb_LTO_UserPermissionControl"
                Dim myPara(2) '' As tpaWS.MyParameter  'TCDSB.Student.Data.MyParameter      ' MyParameterStructure
                setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _user)
                setParameterArray(myPara, 1, "@Type", DbType.String, 20, _V0)
                setParameterArray(myPara, 2, "@Role", DbType.String, 30, _V1)
                Return getMyDataValue(_SP, myPara)
            Catch ex As Exception
                CommonTCDSB.ShowMsg.Exception(ex, cPage, " get User promission Action.")
                Return ""
            End Try
        End Function
        Private Shared Function getSecurityRoleTest(ByVal _UserID As String, Optional ByVal _UserPW As String = "NxN") As String
            Try
                Dim _SP As String = "dbo.tcdsb_LTO_UserPermissionControl"
                Dim myPara(2) ' As tpaWS.MyParameter
                setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
                setParameterArray(myPara, 1, "@Type", DbType.String, 30, "TestRole")
                setParameterArray(myPara, 2, "@Role", DbType.String, 30, _UserPW)
                Return getMyDataValue(_SP, myPara)
            Catch ex As Exception
                CommonTCDSB.ShowMsg.Exception(ex, cPage, " get User promission Action.")
                Return ""
            End Try
        End Function


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
    Public Class UserProfile
        Public Shared Function Extension(ByVal userID As String) As String
            Dim rVal As String = ""
            If userID = "boreanf" Then rVal = "Fiorella Borean  Ext. 2321"
            If userID = "frijiom" Then rVal = "Mary Frijio Ext. 2730"
            If userID = "krasnor" Then rVal = "Rosemarie Krasnovitch  Ext. 2370"
            If userID = "difonzm" Then rVal = "Margherita Di Fonzo  Ext. 2322"
            Return rVal
        End Function
    End Class
End Namespace
