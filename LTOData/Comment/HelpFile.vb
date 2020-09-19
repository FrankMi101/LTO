'Namespace TCDSB.Student.BIP
Namespace CommonTCDSB
    Public Class HelpFile

        Public Shared Property FileLink(ByVal _Category As String, ByVal _Group As String, ByVal _SGroup As String, ByVal _tab As String, ByVal _Items As String, ByVal _role As String, ByVal _type As String) As String
            Get
                Return getFileLink(_Category, _Group, _SGroup, _tab, _Items, _role, _type)
            End Get
            Set(ByVal Value As String)
                getFileLink(_Category, _Group, _SGroup, _tab, _Items, _role, _type, Value)
            End Set
        End Property
        Public Shared Property FileLinkItems(ByVal _Category As String, ByVal _Group As String, ByVal _tab As String, ByVal _Page As String, ByVal _type As String) As String
            Get
                Return getFileLinkitems(_Category, _Group, _tab, _Page, _type)
            End Get
            Set(ByVal Value As String)
                getFileLinkitems(_Category, _Group, _tab, _Page, _type, Value)
            End Set
        End Property
        Public Shared ReadOnly Property Title(ByVal _category As String, ByVal _Group As String, Optional ByVal _Item As String = "NxN") As String
            Get
                Return (getTitle(_category, _Group, _Item))
            End Get
        End Property
        Private Shared Function getFileLink(ByVal _Category As String, ByVal _Group As String, ByVal _sGroup As String, ByVal _tab As String, ByVal _Items As String, ByVal _role As String, ByVal _type As String, _
                                            Optional ByVal _Value As String = "NxN") As String
            Try
                Dim _SP As String = "tcdsb_TPA_HelpLinkFileName"
                Dim myPara(7) 'As TCDSB.Student.Data.MyParameter may 2 
                setParameterArray(myPara, 0, "@Category", DbType.String, 50, _Category)
                setParameterArray(myPara, 1, "@Menu", DbType.String, 50, _Group)
                setParameterArray(myPara, 2, "@sMenu", DbType.String, 50, _sGroup)
                setParameterArray(myPara, 3, "@Tab", DbType.String, 50, _tab)
                setParameterArray(myPara, 4, "@Items", DbType.String, 50, _Items)
                setParameterArray(myPara, 5, "@Role", DbType.String, 50, _role)
                setParameterArray(myPara, 6, "@Type", DbType.String, 50, _type)
                setParameterArray(myPara, 7, "@Value", DbType.String, 200, _Value)
                ' Dim cn As IDbConnection = TCDSB.Student.Data.mydbConnecttion    ' Dim cn As New SqlConnection
                Return getMyDataValue(_SP, myPara)

            Catch ex As Exception
                ' ShowMsg.Exception(ex, cPage, "Get Data from Database")
                Return ""
            End Try
        End Function
        Private Shared Function getTitle(ByVal _Category As String, ByVal _Group As String, Optional ByVal _Items As String = "NxN") As String
            Try
                Dim _SP As String = "tcdsb_TPA_Title"
                Dim myPara(2) 'As TCDSB.Student.Data.MyParameter
                setParameterArray(myPara, 0, "@Category", DbType.String, 20, _Category)
                setParameterArray(myPara, 1, "@Menu", DbType.String, 10, _Group)
                setParameterArray(myPara, 2, "@Tab", DbType.String, 10, _Items)
                Return getMyDataValue(_SP, myPara)

            Catch ex As Exception
                Return "" ' ShowMsg.Exception(ex, cPage, "Get Data from Database")
            End Try
        End Function
        Private Shared Function getFileLinkitems(ByVal _Category As String, ByVal _Group As String, ByVal _tab As String, ByVal _page As String, ByVal _type As String, _
                                           Optional ByVal _Value As String = "NxN") As String
            Try
                Dim _SP As String = "tcdsb_TPA_HelpLinkFileItems"
                Dim myPara(5) 'As TCDSB.Student.Data.MyParameter
                setParameterArray(myPara, 0, "@Category", DbType.String, 50, _Category)
                setParameterArray(myPara, 1, "@Menu", DbType.String, 50, _Group)
                setParameterArray(myPara, 2, "@Tab", DbType.String, 50, _tab)
                setParameterArray(myPara, 3, "@Page", DbType.String, 50, _page)
                setParameterArray(myPara, 4, "@Type", DbType.String, 50, _type)
                setParameterArray(myPara, 5, "@Value", DbType.String, 200, _Value)
                ' Dim cn As IDbConnection = TCDSB.Student.Data.mydbConnecttion    ' Dim cn As New SqlConnection
                Return getMyDataValue(_SP, myPara)

            Catch ex As Exception
                ' ShowMsg.Exception(ex, cPage, "Get Data from Database")
                Return ""
            End Try
        End Function
    End Class
End Namespace

'End Namespace

