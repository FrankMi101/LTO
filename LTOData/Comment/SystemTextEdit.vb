Imports TCDSB.Student.Data
Namespace CommonTCDSB
    Public Class WebApplication
        Public Shared Function Version(ByVal _ApplID As String) As String
            Try
                Dim _SP As String = "tcdsb_BIP_sp_sysApplicationVersion"
                Dim myPara(0)   'TCDSB.Student.Data.MyParameter
                setParameterArray(myPara, 0, "@ApplID", DbType.String, 10, _ApplID)
                Return getMyDataValue(_SP, myPara)
            Catch ex As Exception
                Return "1.0.0"
            End Try
        End Function
    End Class
    Public Class SystemTextEdit
        Public Shared cPage As Object

        Public Shared Property FileLink(ByVal _Category As String, ByVal _Menu As String, ByVal _sMenu As String, ByVal _tab As String, ByVal _Items As String, ByVal _role As String, ByVal _type As String) As String
            Get
                Return getSaveFileLink(_Category, _Menu, _sMenu, _tab, _Items, _role, _type)
            End Get
            Set(ByVal Value As String)
                Dim ok As String = getSaveFileLink(_Category, _Menu, _sMenu, _tab, _Items, _role, _type, Value)
            End Set
        End Property
        Private Shared Function getSaveFileLink(ByVal _Category As String, _
                                                ByVal _Menu As String, _
                                                ByVal _sMenu As String, _
                                                ByVal _tab As String, _
                                                ByVal _Items As String, _
                                                ByVal _role As String, _
                                                ByVal _type As String, _
                                       Optional ByVal _val As String = "NxN") As String
            Try
                Dim _SP As String = "tcdsb_SES_HelpLinkFile"
                Dim myPara(7)   'TCDSB.Student.Data.MyParameter
                setParameterArray(myPara, 0, "@Category", DbType.String, 50, _Category)
                setParameterArray(myPara, 1, "@Menu", DbType.String, 50, _Menu)
                setParameterArray(myPara, 2, "@sMenu", DbType.String, 50, _sMenu)
                setParameterArray(myPara, 3, "@Tab", DbType.String, 50, _tab)
                setParameterArray(myPara, 4, "@Items", DbType.String, 50, _Items)
                setParameterArray(myPara, 5, "@Role", DbType.String, 50, _role)
                setParameterArray(myPara, 6, "@Type", DbType.String, 50, _type)
                setParameterArray(myPara, 7, "@Value", DbType.String, 200, _val)
                Return getMyDataValue(_SP, myPara)
            Catch ex As Exception
                ShowMsg.Exception(ex, cPage, "Get Data from Database")
                Return Nothing
            End Try
        End Function
        Public Shared Property HelpText(ByVal _Category As String, ByVal _Item As String) As String
            Get
                Return getSaveHelpText(_Category, _Item, "HelpText")
            End Get
            Set(ByVal Value As String)
                Dim ok As String = getSaveHelpText(_Category, _Item, "HelpText", Value)
            End Set
        End Property
        Public Shared Property TitleText(ByVal _Category As String, ByVal _Item As String) As String
            Get
                Return getSaveHelpText(_Category, _Item, "Title")
            End Get
            Set(ByVal Value As String)
                Dim ok As String = getSaveHelpText(_Category, _Item, "Title", Value)
            End Set
        End Property
        Public Shared Property SubTitleText(ByVal _Category As String, ByVal _Item As String) As String
            Get
                Return getSaveHelpText(_Category, _Item, "SubTitle")
            End Get
            Set(ByVal Value As String)
                Dim ok As String = getSaveHelpText(_Category, _Item, "SubTitle", Value)
            End Set
        End Property
        Private Shared Function getSaveHelpText(ByVal _Category As String, _
                                               ByVal _Item As String, _
                                               ByVal _type As String, _
                                      Optional ByVal _val As String = "NxN") As String
            Try
                Dim _SP As String = "dbo.tcdsb_LTO_HelpLIBText"
                Dim myPara(3)   'TCDSB.Student.Data.MyParameter
                setParameterArray(myPara, 0, "@Category", DbType.String, 20, _Category)
                setParameterArray(myPara, 1, "@Item", DbType.String, 20, _Item)
                setParameterArray(myPara, 2, "@type", DbType.String, 10, _type)
                setParameterArray(myPara, 3, "@Value", DbType.String, 4000, _val)
                Return getMyDataValue(_SP, myPara)
            Catch ex As Exception
                ShowMsg.Exception(ex, cPage, "Get Data from Database")
                Return Nothing
            End Try
        End Function

        Public Shared Function AppsSupportInfo(ByVal _UserID As String, ByVal _AppsID As String, ByVal _Role As String) As DataSet
            Try
                Dim _SP As String = "dbo.tcdsb_Apps_SupportInformation"
                Dim myPara(2)   'TCDSB.Student.Data.MyParameter
                setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
                setParameterArray(myPara, 1, "@AppsID", DbType.String, 10, _AppsID)
                setParameterArray(myPara, 2, "@Role", DbType.String, 20, _Role)
                Return getMyDataSet(_SP, myPara)
            Catch ex As Exception
                ShowMsg.Exception(ex, cPage, "Get Data from Database")
                Return Nothing
            End Try
        End Function
        Public Shared Function AppsSupportInfoShow(ByVal _UserID As String, ByVal _AppsID As String, ByVal _Role As String) As String
            Try
                Dim _SP As String = "dbo.tcdsb_Apps_SupportInformationShow"
                Dim myPara(2)   'TCDSB.Student.Data.MyParameter
                setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
                setParameterArray(myPara, 1, "@AppsID", DbType.String, 10, _AppsID)
                setParameterArray(myPara, 2, "@Role", DbType.String, 20, _Role)
                Return getMyDataValue(_SP, myPara)
            Catch ex As Exception
                ShowMsg.Exception(ex, cPage, "Get Data from Database")
                Return ""
            End Try
        End Function


    End Class

End Namespace
 