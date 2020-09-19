Imports TCDSB.Student.Data
Imports System.Web.UI.WebControls
'Namespace TCDSB.Student.BIP
'    Namespace Common
Public Class SetupList
    Public Shared cPage As Object
   
#Region " Schoo list setup"
    Public Shared Sub SchoolListDDL(ByVal myDDL As Object, ByVal myDDL1 As Object, ByVal vType As String, ByVal UserID As String, ByVal uRole As String, ByVal SuperArea As String, ByVal SchoolYear As String)
        Try

            Dim SchoolListDDL As DataSet = myDDLReaderSchoolList(vType, UserID, uRole, SuperArea, SchoolYear)   'myDDLList(vType, vCo) 
            '  CType(myDDL, DropDownList).Items.Clear()
            'myDDL.Dispose()
            myDDL.Items.Clear()
            myDDL.DataSource = SchoolListDDL
            myDDL.DataTextField = "myText"
            myDDL.DataValueField = "myValue"
            myDDL.DataBind()
            Dim dvList As DataView
            dvList = SchoolListDDL.Tables(0).DefaultView
            dvList.Sort = "myValue"
            'CType(myDDL1, DropDownList).Items.Clear()
            'myDDL1.Dispose()
            myDDL1.Items.Clear()

            myDDL1.DataSource = dvList
            myDDL1.DataTextField = "myValue"
            myDDL1.DataValueField = "myValue"
            myDDL1.DataBind()
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "DataBase Login Failed")
            'Throw New Exception("DataBase Login Failed")
        End Try

    End Sub

    Public Shared Sub SchoolListDDL(ByVal myDDL As Object, ByVal vType As String, ByVal UserID As String, ByVal uRole As String, ByVal SuperArea As String, ByVal SchoolYear As String)
        Try

            Dim SchoolListDDL As DataSet = myDDLReaderSchoolList(vType, UserID, uRole, SuperArea, SchoolYear)   'myDDLList(vType, vCo) 
            '  CType(myDDL, DropDownList).Items.Clear()
            'myDDL.Dispose()
            myDDL.Items.Clear()
            myDDL.DataSource = SchoolListDDL
            myDDL.DataTextField = "myText"
            myDDL.DataValueField = "myValue"
            myDDL.DataBind()


        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, "DataBase Login Failed")
            'Throw New Exception("DataBase Login Failed")
        End Try

    End Sub
    Private Shared Function myDDLReaderSchoolList(ByVal vType As String, ByVal UserID As String, ByVal uRole As String, ByVal SuperArea As String, ByVal SchoolYear As String) As DataSet 'IDataReader '
        Try
            Dim _SP As String = "dbo.tcdsb_LTO_ListSchools"
            Dim myPara(4) 'As DataAccessWebService.MyParameter  'As TCDSB.Student.Data.MyParameter  'Object  ' Dim myPara(4)  '
            setParameterArray(myPara, 0, "@pType", DbType.String, 30, vType)
            setParameterArray(myPara, 1, "@UserID", DbType.String, 30, UserID)
            setParameterArray(myPara, 2, "@uRole", DbType.String, 50, uRole)
            setParameterArray(myPara, 3, "@SuperArea", DbType.String, 20, SuperArea)
            setParameterArray(myPara, 4, "@SchoolYear", DbType.String, 8, SchoolYear)

            Return getMyDataSet(_SP, myPara)

        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, " Bind List Action.")
            Return Nothing
        End Try

    End Function
#End Region
#Region " Drop down list setup"

    Public Shared Sub ListDDL(ByVal myDDL As Object, ByVal vType As String)
        Try
            myDDL.Items.Clear() 'Dispose()
            myDDL.DataSource = myDDLReader1(vType) 'myDDLList(vType, vCo) 
            myDDL.DataTextField = "myText"
            myDDL.DataValueField = "myValue"
            myDDL.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub ListDDL(ByVal myDDL As Object, ByVal vType As String, ByVal vP0 As String)
        Try
            myDDL.Items.Clear() 'Dispose()
            myDDL.DataSource = myDDLReader1(vType, vP0) 'myDDLList(vType, vCo)
            myDDL.DataTextField = "myText"
            myDDL.DataValueField = "myValue"
            myDDL.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub ListDDL(ByVal myDDL As Object, ByVal vType As String, ByVal vP0 As String, ByVal vP1 As String)
        Try
            myDDL.Items.Clear() 'Dispose()
            myDDL.DataSource = myDDLReader1(vType, vP0, vP1) 'myDDLList(vType, vCo)
            myDDL.DataTextField = "myText"
            myDDL.DataValueField = "myValue"
            myDDL.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub ListDDL(ByVal myDDL As Object, ByVal vType As String, ByVal vP0 As String, ByVal vP1 As String, ByVal vP2 As String)
        Try
            myDDL.Items.Clear() 'Dispose()
            myDDL.DataSource = myDDLReader1(vType, vP0, vP1, vP2) 'myDDLList(vType, vCo)
            myDDL.DataTextField = "myText"
            myDDL.DataValueField = "myValue"
            myDDL.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub ListDDL(ByVal myDDL As Object, ByVal vType As String, ByVal vP0 As String, ByVal vP1 As String, ByVal vP2 As String, ByVal vP3 As String)
        Try
            myDDL.Items.Clear() 'Dispose()
            myDDL.DataSource = myDDLReader1(vType, vP0, vP1, vP2, vP3) 'myDDLList(vType, vCo)
            myDDL.DataTextField = "myText"
            myDDL.DataValueField = "myValue"
            myDDL.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub ListDDL(ByVal myDDL1 As Object, ByVal myDDL2 As Object, ByVal myDDL3 As Object, ByVal vType As String, ByVal vP0 As String, ByVal vP1 As String, ByVal vP2 As String, ByVal vP3 As String)
        Try
            Dim DS As DataSet = myDDLReader1(vType, vP0, vP1, vP2, vP3) 'myDDLList(vType, vCo)
            myDDL1.Items.Clear() 'Dispose()
            myDDL1.DataSource = DS.Tables(0)
            myDDL1.DataTextField = "myText"
            myDDL1.DataValueField = "myValue"
            myDDL1.DataBind()

            myDDL2.Items.Clear() 'Dispose()
            myDDL2.DataSource = DS.Tables(0)
            myDDL2.DataTextField = "myText"
            myDDL2.DataValueField = "myValue"
            myDDL2.DataBind()

            myDDL3.Items.Clear() 'Dispose()
            myDDL3.DataSource = DS.Tables(0)
            myDDL3.DataTextField = "myText"
            myDDL3.DataValueField = "myValue"
            myDDL3.DataBind()


        Catch ex As Exception

        End Try
    End Sub


    Public Shared Sub ListDDLSearch(ByVal myDDL As Object, ByVal vType As String, ByVal vP0 As String, ByVal vP1 As String)
        Try
            myDDL.Items.Clear() 'Dispose()
            myDDL.DataSource = myDDLReaderSearch(vType, vP0, vP1) 'myDDLList(vType, vCo)
            myDDL.DataTextField = "myText"
            myDDL.DataValueField = "myValue"
            myDDL.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Private Shared Function myDDLReaderSearch(ByVal vType As String, _
                                           Optional ByVal P0 As String = "NxN", _
                                           Optional ByVal P1 As String = "NxN") As DataSet 'IDataReader '
        Try
            Dim _SP As String = "dbo.tcdsb_LTO_ListDDLSearch2"
            Dim myPara(2)   ' ' As tpaWS.MyParameter       ' TCDSB.Student.Data.MyParameter
            setParameterArray(myPara, 0, "@pType", DbType.String, 30, vType)
            setParameterArray(myPara, 1, "@P0", DbType.String, 50, P0)
            setParameterArray(myPara, 2, "@P1", DbType.String, 50, P1)
            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, " Bind List Action.")
            Return Nothing
        End Try

    End Function
    Private Shared Function myDDLReader1(ByVal vType As String, _
                                       Optional ByVal P0 As String = "NxN", _
                                       Optional ByVal P1 As String = "NxN", _
                                       Optional ByVal P2 As String = "NxN", _
                                       Optional ByVal P3 As String = "NxN") As DataSet 'IDataReader '
        Try
            Dim _SP As String = "dbo.tcdsb_LTO_ListDDL"
            Dim myPara(4)   ' ' As tpaWS.MyParameter       ' TCDSB.Student.Data.MyParameter
            setParameterArray(myPara, 0, "@pType", DbType.String, 30, vType)
            setParameterArray(myPara, 1, "@P0", DbType.String, 50, P0)
            setParameterArray(myPara, 2, "@P1", DbType.String, 50, P1)
            setParameterArray(myPara, 3, "@P2", DbType.String, 50, P2)
            setParameterArray(myPara, 4, "@P3", DbType.String, 50, P3)
            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, " Bind List Action.")
            Return Nothing
        End Try

    End Function
#End Region

    Private Shared Function myRBLReader1(ByVal vType As String, _
                             Optional ByVal P0 As String = "NxN", _
                             Optional ByVal P1 As String = "NxN", _
                             Optional ByVal P2 As String = "NxN", _
                             Optional ByVal P3 As String = "NxN") As DataSet 'IDataReader '
        Try
            Dim _SP As String = "dbo.tcdsb_LTO_List"
            Dim myPara(4) 'As DataAccessWebService.MyParameter  'As TCDSB.Student.Data.MyParameter  'Object  ' Dim myPara(4)  '
            setParameterArray(myPara, 0, "@pType", DbType.String, 30, vType)
            setParameterArray(myPara, 1, "@P0", DbType.String, 50, P0)
            setParameterArray(myPara, 2, "@P1", DbType.String, 50, P1)
            setParameterArray(myPara, 3, "@P2", DbType.String, 50, P2)
            setParameterArray(myPara, 4, "@P3", DbType.String, 50, P3)

            Return getMyDataSet(_SP, myPara)

        Catch ex As Exception

            Return Nothing
        End Try

    End Function

    Public Shared Sub ListRBL(ByVal myList As RadioButtonList, ByVal vType As String, Optional ByVal P0 As String = "NxN")
        myList.Items.Clear() 'Dispose()
        myList.DataSource = myRBLReader1(vType, P0) 'myDDLList(vType, vCo) 
        myList.DataTextField = "myText"
        myList.DataValueField = "myValue"
        myList.DataBind()
    End Sub
    Public Shared Sub ListRBL(ByVal myList As RadioButtonList, ByVal vType As String, ByVal vP0 As String, ByVal vP1 As String, ByVal vP2 As String)
        myList.Items.Clear() 'Dispose()
        myList.DataSource = myDDLReader1(vType, vP0, vP1, vP2) 'myDDLList(vType, vCo)
        myList.DataTextField = "myText"
        myList.DataValueField = "myValue"
        myList.DataBind()
    End Sub

    Public Shared Sub ListCBL(ByVal myList As CheckBoxList, ByVal vType As String, Optional ByVal P0 As String = "NxN")
        myList.Items.Clear() 'Dispose()
        myList.DataSource = myCBLReader1(vType, P0) 'myDDLList(vType, vCo) 
        myList.DataTextField = "myText"
        myList.DataValueField = "myValue"
        myList.DataBind()
    End Sub
    Public Shared Sub ListCBL(ByVal myList As CheckBoxList, ByVal vType As String, Optional ByVal P0 As String = "NxN", Optional ByVal P1 As String = "NxN")
        myList.Items.Clear() 'Dispose()
        myList.DataSource = myCBLReader1(vType, P0, P1) 'myDDLList(vType, vCo) 
        myList.DataTextField = "myText"
        myList.DataValueField = "myValue"
        myList.DataBind()
    End Sub
    Public Shared Sub ListCBL(ByVal myList As CheckBoxList, ByVal vType As String, Optional ByVal P0 As String = "NxN", Optional ByVal P1 As String = "NxN", Optional ByVal P2 As String = "NxN")
        myList.Items.Clear() 'Dispose()
        myList.DataSource = myCBLReader1(vType, P0, P1, P2) 'myDDLList(vType, vCo) 
        myList.DataTextField = "myText"
        myList.DataValueField = "myValue"
        myList.DataBind()
    End Sub
    Private Shared Function myCBLReader1(ByVal vType As String,
                             Optional ByVal P0 As String = "NxN",
                             Optional ByVal P1 As String = "NxN",
                             Optional ByVal P2 As String = "NxN",
                             Optional ByVal P3 As String = "NxN") As DataSet 'IDataReader '
        Try
            Dim _SP As String = "dbo.tcdsb_LTO_ListCBL"
            Dim myPara(4) 'As DataAccessWebService.MyParameter  'As TCDSB.Student.Data.MyParameter  'Object  ' Dim myPara(4)  '
            setParameterArray(myPara, 0, "@pType", DbType.String, 30, vType)
            setParameterArray(myPara, 1, "@P0", DbType.String, 50, P0)
            setParameterArray(myPara, 2, "@P1", DbType.String, 50, P1)
            setParameterArray(myPara, 3, "@P2", DbType.String, 50, P2)
            setParameterArray(myPara, 4, "@P3", DbType.String, 50, P3)

            Return getMyDataSet(_SP, myPara)

        Catch ex As Exception

            Return Nothing
        End Try

    End Function

    Public Shared Sub ListLBL(ByVal myList As ListBox, ByVal vType As String, Optional ByVal P0 As String = "NxN")
        myList.Items.Clear() 'Dispose()
        myList.DataSource = myRBLReader1(vType, P0) 'myDDLList(vType, vCo) 
        myList.DataTextField = "myText"
        myList.DataValueField = "myValue"
        myList.DataBind()
    End Sub
 
End Class
'    End Namespace
'End Namespace
