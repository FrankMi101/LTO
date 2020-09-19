Imports TCDSB.Student.Data
Imports System.Data.SqlClient
Imports System.Web
Public Class PositionList
    Public Shared cPage As Object
    Private _schoolyear As String
    Private _VisitPhase As String
    Public Shared Function LTOTeacherApplyHistroy(ByVal _UserID As String, ByVal _CPnum As String, ByVal _schoolyear As String, ByVal _searchText As String, ByVal _appType As String, ByVal _userRole As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_TeacherApplyHistory"
        Try

            Dim myPara(5) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@CPnum", DbType.String, 10, _CPnum)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 3, "@SearchText", DbType.String, 20, _searchText)
            setParameterArray(myPara, 4, "@appType", DbType.String, 20, _appType)
            setParameterArray(myPara, 5, "@UserRole", DbType.String, 15, _userRole)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function LTOTeacher(ByVal _UserID As String, ByVal _CPnum As String, ByVal _schoolyear As String, ByVal _searchBy As String, ByVal _searchText As String, ByVal _appType As String, ByVal _userRole As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_TeacherWithSearch2"
        Try

            Dim myPara(6) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@CPnum", DbType.String, 10, _CPnum)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 3, "@SearchBy", DbType.String, 20, _searchBy)
            setParameterArray(myPara, 4, "@SearchText", DbType.String, 20, _searchText)
            setParameterArray(myPara, 5, "@AppType", DbType.String, 20, _appType)
            setParameterArray(myPara, 6, "@UserRole", DbType.String, 15, _userRole)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function LTOTeacherApplied(ByVal _UserID As String, ByVal _CPnum As String, ByVal _schoolyear As String, ByVal _searchBy As String, ByVal _searchText As String, ByVal _appType As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_TeacherApplied"
        Try

            Dim myPara(5) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@CPnum", DbType.String, 10, _CPnum)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 3, "@SearchBy", DbType.String, 20, _searchBy)
            setParameterArray(myPara, 4, "@SearchText", DbType.String, 20, _searchText)
            setParameterArray(myPara, 5, "@appType", DbType.String, 10, _appType)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function SchoolPositionList(ByVal _UserID As String, ByVal _schoolcode As String, ByVal _schoolyear As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_School"
        Try

            Dim myPara(2) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@Schoolcode", DbType.String, 10, _schoolcode)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _schoolyear)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function SchoolPositionList(ByVal _UserID As String, ByVal _schoolcode As String, ByVal _schoolyear As String, ByVal _listType As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_School"
        Try

            Dim myPara(3) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@Schoolcode", DbType.String, 8, _schoolcode)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 3, "@ListType", DbType.String, 20, _listType)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function SchoolRequestPostingListWithSearch(ByVal _UserID As String, ByVal _schoolcode As String, ByVal _schoolyear As String, ByVal _listType As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_SchoolRequest"
        Try

            Dim myPara(3) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@Schoolcode", DbType.String, 8, _schoolcode)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 3, "@ListType", DbType.String, 20, _listType)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function InterviewList(ByVal _UserID As String, ByVal _schoolcode As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_InterviewCandidateForPrincipal2"
        Try

            Dim myPara(3) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@Schoolcode", DbType.String, 8, _schoolcode)
            setParameterArray(myPara, 3, "@PositionID", DbType.String, 10, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function InterviewList(ByVal _UserID As String, ByVal _schoolcode As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _type As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_InterViewList_Principal2"
        Try

            Dim myPara(3) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@Schoolcode", DbType.String, 8, _schoolcode)
            setParameterArray(myPara, 3, "@PositionID", DbType.String, 10, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function

    Public Shared Function BoardPublishedList(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolcode As String, ByVal _panel As String, ByVal _Area As String, ByVal _pageID As String, ByVal _appType As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_Published"
        Try

            Dim myPara(6) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@Schoolcode", DbType.String, 8, _schoolcode)
            setParameterArray(myPara, 3, "@SchoolArea", DbType.String, 10, _Area)
            setParameterArray(myPara, 4, "@Panel", DbType.String, 10, _panel)
            setParameterArray(myPara, 5, "@PageID", DbType.String, 20, _pageID)
            setParameterArray(myPara, 6, "@appType", DbType.String, 20, _appType)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try

    End Function
    Public Shared Function BoardPublishedListWithSearch(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _pageID As String, ByVal _appType As String, ByVal _searchby As String, ByVal _searchValue As String, ByVal _searchValue2 As String, ByVal _NeedNotice As String) As DataSet

        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_PublishedWithSearch2"
        Try

            Dim myPara(7) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PageID", DbType.String, 20, _pageID)
            setParameterArray(myPara, 3, "@appType", DbType.String, 20, _appType)
            setParameterArray(myPara, 4, "@SearchBy", DbType.String, 20, _searchby)
            setParameterArray(myPara, 5, "@SearchValue", DbType.String, 20, _searchValue)
            setParameterArray(myPara, 6, "@SearchValue2", DbType.String, 20, _searchValue2)
            setParameterArray(myPara, 7, "@NeedNotice", DbType.String, 10, _NeedNotice)


            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function BoardPublishedList(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _pageID As String, ByVal _appType As String, ByVal _Panel As String, ByVal _searchby As String, ByVal _searchValue As String, ByVal _searchValue2 As String, ByVal _NeedNotice As String, ByVal _C4th As String) As DataSet

        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_Published"
        Try

            Dim myPara(9) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PageID", DbType.String, 20, _pageID)
            setParameterArray(myPara, 3, "@appType", DbType.String, 20, _appType)
            setParameterArray(myPara, 4, "@SearchBy", DbType.String, 20, _searchby)
            setParameterArray(myPara, 5, "@SearchValue", DbType.String, 20, _searchValue)
            setParameterArray(myPara, 6, "@SearchValue2", DbType.String, 20, _searchValue2)
            setParameterArray(myPara, 7, "@NeedNotice", DbType.String, 10, _NeedNotice)
            setParameterArray(myPara, 8, "@Panel", DbType.String, 10, _Panel)
            setParameterArray(myPara, 9, "@Check4th", DbType.String, 2, _C4th)
            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function BoardPublishedListWithSearch2(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _pageID As String, ByVal _appType As String, ByVal _Panel As String, ByVal _searchby As String, ByVal _searchValue As String, ByVal _searchValue2 As String, ByVal _NeedNotice As String) As DataSet

        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_PublishedWithSearch2"
        Try

            Dim myPara(8) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PageID", DbType.String, 20, _pageID)
            setParameterArray(myPara, 3, "@appType", DbType.String, 20, _appType)
            setParameterArray(myPara, 4, "@SearchBy", DbType.String, 20, _searchby)
            setParameterArray(myPara, 5, "@SearchValue", DbType.String, 20, _searchValue)
            setParameterArray(myPara, 6, "@SearchValue2", DbType.String, 20, _searchValue2)
            setParameterArray(myPara, 7, "@NeedNotice", DbType.String, 10, _NeedNotice)
            setParameterArray(myPara, 8, "@Panel", DbType.String, 10, _Panel)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function BoardUnPublishedList(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolcode As String, ByVal _panel As String, ByVal _Area As String, ByVal _apptype As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_UnPublished"
        Try

            Dim myPara(5) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@Schoolcode", DbType.String, 8, _schoolcode)
            setParameterArray(myPara, 3, "@SchoolArea", DbType.String, 10, _Area)
            setParameterArray(myPara, 4, "@Panel", DbType.String, 10, _panel)
            setParameterArray(myPara, 5, "@appType", DbType.String, 10, _apptype)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function PendingConfirmList(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _appType As String, ByVal _searchby As String, ByVal _searchbyValue As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_PendingConfirm"
        Try

            Dim myPara(4) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@AppType", DbType.String, 10, _appType)
            setParameterArray(myPara, 3, "@Searchby", DbType.String, 20, _searchby)
            setParameterArray(myPara, 4, "@SearchValue", DbType.String, 20, _searchbyValue)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function

    Public Shared Sub PendingConfirmListSave(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String)
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_PendingConfirmMonitering"
        Try

            Dim myPara(2) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 10, _PositionID)
            getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)

        End Try
    End Sub

    Public Shared Function PendingConfirmGetPrincipalInfobyID(ByVal Type As String, ByVal SchoolYear As String, ByVal PrincipalID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_PendingConfirmPrincipalProfile"
        Try

            Dim myPara(2) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@Type", DbType.String, 20, Type)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, SchoolYear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 30, PrincipalID)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try
    End Function
    Public Shared Function PendingConfirmGetPrincipalInfobyID(ByVal Type As String, ByVal SchoolYear As String, ByVal PositionID As String, ByVal SchoolCode As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_PendingConfirmPrincipalProfile"
        Try

            Dim myPara(3) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@Type", DbType.String, 20, Type)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, SchoolYear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 30, PositionID)
            setParameterArray(myPara, 3, "@SchoolCode", DbType.String, 8, SchoolCode)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try
    End Function


    Public Shared Function BoardUnPublishedListWithSearch(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _appType As String, ByVal _searchby As String, ByVal _searchbyValue As String, ByVal _searchbyValue2 As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_UnPublishedWithSearch"
        Try

            Dim myPara(5) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@AppType", DbType.String, 10, _appType)
            setParameterArray(myPara, 3, "@Searchby", DbType.String, 20, _searchby)
            setParameterArray(myPara, 4, "@SearchValue", DbType.String, 20, _searchbyValue)
            setParameterArray(myPara, 5, "@SearchValue2", DbType.String, 20, _searchbyValue2)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function PostingListSummary(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _appType As String, ByVal _Panel As String, ByVal _searchby As String, ByVal _searchbyValue As String, ByVal _searchbyValue2 As String, ByVal _Status As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_PostingListSummary"
        Try

            Dim myPara(7) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@AppType", DbType.String, 10, _appType)
            setParameterArray(myPara, 3, "@Panel", DbType.String, 10, _Panel)
            setParameterArray(myPara, 4, "@Searchby", DbType.String, 20, _searchby)
            setParameterArray(myPara, 5, "@SearchValue", DbType.String, 20, _searchbyValue)
            setParameterArray(myPara, 6, "@SearchValue2", DbType.String, 20, _searchbyValue2)
            setParameterArray(myPara, 7, "@Status", DbType.String, 10, _Status)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function BoardUnPublishedListWithSearch(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _appType As String, ByVal _Panel As String, ByVal _searchby As String, ByVal _searchbyValue As String, ByVal _searchbyValue2 As String, ByVal _Status As String, ByVal _c4th As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_UnPublishedWithSearch"
        Try

            Dim myPara(8) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@AppType", DbType.String, 10, _appType)
            setParameterArray(myPara, 3, "@Panel", DbType.String, 10, _Panel)
            setParameterArray(myPara, 4, "@Searchby", DbType.String, 20, _searchby)
            setParameterArray(myPara, 5, "@SearchValue", DbType.String, 20, _searchbyValue)
            setParameterArray(myPara, 6, "@SearchValue2", DbType.String, 20, _searchbyValue2)
            setParameterArray(myPara, 7, "@Status", DbType.String, 10, _Status)
            setParameterArray(myPara, 8, "@Check4th", DbType.String, 2, _c4th)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function BoardRequestPostingListWithSearch(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _appType As String, ByVal _Panel As String, ByVal _searchby As String, ByVal _searchbyValue As String, ByVal _searchbyValue2 As String, ByVal _Status As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_RequestPostingWithSearch"
        Try

            Dim myPara(7) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@AppType", DbType.String, 10, _appType)
            setParameterArray(myPara, 3, "@Panel", DbType.String, 10, _Panel)
            setParameterArray(myPara, 4, "@Searchby", DbType.String, 20, _searchby)
            setParameterArray(myPara, 5, "@SearchValue", DbType.String, 20, _searchbyValue)
            setParameterArray(myPara, 6, "@SearchValue2", DbType.String, 20, _searchbyValue2)
            setParameterArray(myPara, 7, "@Status", DbType.String, 10, _Status)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function BoardHiredPositionList(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolcode As String, ByVal _panel As String, ByVal _Area As String, ByVal _appType As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_Hired2"
        Try

            Dim myPara(5) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@Schoolcode", DbType.String, 8, _schoolcode)
            setParameterArray(myPara, 3, "@SchoolArea", DbType.String, 10, _Area)
            setParameterArray(myPara, 4, "@Panel", DbType.String, 10, _panel)
            setParameterArray(myPara, 5, "@appType", DbType.String, 10, _appType)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function BoardHiringPositionListSearch(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _appType As String, ByVal _searchby As String, ByVal _searchbyValue As String, ByVal _Round4th As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_HiringWithSearch"
        Try

            Dim myPara(5) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@appType", DbType.String, 10, _appType)
            setParameterArray(myPara, 3, "@SearchBy", DbType.String, 20, _searchby)
            setParameterArray(myPara, 4, "@SearchByValue", DbType.String, 20, _searchbyValue)
            setParameterArray(myPara, 5, "@Round4th", DbType.String, 1, _Round4th)



            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function BoardHiredPositionListSearch(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _appType As String, ByVal _searchby As String, ByVal _searchValue As String, ByVal _searchValue2 As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_HiredWithSearch2"
        Try

            Dim myPara(5) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@appType", DbType.String, 10, _appType)
            setParameterArray(myPara, 3, "@SearchBy", DbType.String, 20, _searchby)
            setParameterArray(myPara, 4, "@SearchValue", DbType.String, 20, _searchValue)
            setParameterArray(myPara, 5, "@SearchValue2", DbType.String, 20, _searchValue2)


            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function BoardHiredPositionListSearch2(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _appType As String, ByVal _Panel As String, ByVal _searchby As String, ByVal _searchValue As String, ByVal _searchValue2 As String, ByVal _Round4th As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_HiredWithSearch2"
        Try

            Dim myPara(7) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@appType", DbType.String, 10, _appType)
            setParameterArray(myPara, 3, "@SearchBy", DbType.String, 20, _searchby)
            setParameterArray(myPara, 4, "@SearchValue", DbType.String, 20, _searchValue)
            setParameterArray(myPara, 5, "@SearchValue2", DbType.String, 20, _searchValue2)
            setParameterArray(myPara, 6, "@Panel", DbType.String, 10, _Panel)
            setParameterArray(myPara, 7, "@Round4th", DbType.String, 1, _Round4th)


            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function ApplicantList(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _pageID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionList_Applicants"
        Try

            Dim myPara(3) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 20, _PositionID)
            setParameterArray(myPara, 3, "@PageID", DbType.String, 20, _pageID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function ApplicantList(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _pageID As String, ByVal IncludeAll As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantList_byPosition2"
        Try

            Dim myPara(4) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 20, _PositionID)
            setParameterArray(myPara, 3, "@PageID", DbType.String, 20, _pageID)
            setParameterArray(myPara, 4, "@InCludeAll", DbType.String, 10, IncludeAll)
            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function


End Class
