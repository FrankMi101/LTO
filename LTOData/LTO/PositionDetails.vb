Imports TCDSB.Student.Data
Imports System.Data.SqlClient
Imports System.Web
Public Class PositionDetails
    Public Shared cPage As Object
    Private _schoolyear As String
    Private _VisitPhase As String
    Private Shared Sub setBaseParameters(ByRef myPara() As Object, ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String)
        setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
        setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
        setParameterArray(myPara, 2, "@PositionID", DbType.String, 10, _PositionID)
    End Sub
    Private Shared Sub setBaseParameters(ByRef myPara() As Object, ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String)
        setBaseParameters(myPara, _UserID, _schoolyear, _PositionID)
        setParameterArray(myPara, 3, "@CPNum", DbType.String, 10, _CPNum)
    End Sub
    Private Shared Sub setBaseParameters2(ByRef myPara() As Object, ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _PositionID As String)
        setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
        setParameterArray(myPara, 1, "@CPNum", DbType.String, 10, _CPNum)
        setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _schoolyear)
        setParameterArray(myPara, 3, "@PositionID", DbType.String, 10, _PositionID)
    End Sub
    Private Shared Sub setBaseParameters3(ByRef myPara() As Object, ByVal _action As String, ByVal _appType As String, ByVal _IDs As String, ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolcode As String)
        setParameterArray(myPara, 0, "@Oprate", DbType.String, 20, _action)
        setParameterArray(myPara, 1, "@appType", DbType.String, 10, _appType)
        setParameterArray(myPara, 2, "@IDs", DbType.String, 10, _IDs)
        setParameterArray(myPara, 3, "@UserID", DbType.String, 30, _UserID)
        setParameterArray(myPara, 4, "@SchoolYear", DbType.String, 8, _schoolyear)
        setParameterArray(myPara, 5, "@SchoolCode", DbType.String, 8, _schoolcode)
    End Sub

    Public Shared Function PostingNumber(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_getPostingNumberbyID"
        Try

            Dim myPara(2)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try
    End Function
    Public Shared Function LimitedDate(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _type As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_Date"
        Try

            Dim myPara(2)    ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@Action", DbType.String, 20, _type)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try
    End Function

    Public Shared Sub PostingNotificationToPrincipal(ByVal _UserID As String, ByVal _SchoolYear As String, ByVal _Schoolcode As String, ByVal _principalID As String, ByVal _PositionID As String)
        Dim _SP As String = "dbo.tcdsb_LTO_PositionNoticeToPrincipal_mark"
        Try
            Dim myPara(4)    ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _SchoolYear)
            setParameterArray(myPara, 2, "@SchoolCode", DbType.String, 8, _Schoolcode)
            setParameterArray(myPara, 3, "@PrincipalID", DbType.String, 20, _principalID)
            setParameterArray(myPara, 4, "@PositionID", DbType.String, 10, _PositionID)

            getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)

        End Try
    End Sub

    Public Shared Function checkpositionQualification(ByVal _SchoolYear As String, ByVal _PositionID As String, ByVal QualficationID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_checkpositionQualificationbyID"
        Try
            Dim myPara(2)    ' 
            setParameterArray(myPara, 0, "@SchoolYear", DbType.String, 8, _SchoolYear)
            setParameterArray(myPara, 1, "@PositionID", DbType.String, 10, _PositionID)
            setParameterArray(myPara, 2, "@QualificationID", DbType.String, 10, QualficationID)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function NoticeToActingPrincipal(ByVal _SchoolYear As String, ByVal _Schoolcode As String, ByVal _PositionID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionNoticeToPrincipal_Acting"
        Try
            Dim myPara(2)    ' 
            setParameterArray(myPara, 0, "@SchoolYear", DbType.String, 8, _SchoolYear)
            setParameterArray(myPara, 1, "@SchoolCode", DbType.String, 8, _Schoolcode)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 10, _PositionID)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function NoticeToPrincipalMultipleSchool(ByVal _SchoolYear As String, ByVal _Schoolcode As String, ByVal _PositionID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionNoticeToPrincipal_multipSchool"
        Try
            Dim myPara(2)    ' 
            setParameterArray(myPara, 0, "@SchoolYear", DbType.String, 8, _SchoolYear)
            setParameterArray(myPara, 1, "@SchoolCode", DbType.String, 8, _Schoolcode)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 10, _PositionID)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function RequestSchool(ByVal _SchoolYear As String, ByVal _Schoolcode As String, ByVal _PositionID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_PostingRequestSchool"
        Try
            Dim myPara(2)    ' 
            setParameterArray(myPara, 0, "@SchoolYear", DbType.String, 8, _SchoolYear)
            setParameterArray(myPara, 1, "@SchoolCode", DbType.String, 8, _Schoolcode)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 10, _PositionID)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function

    Public Shared Function GeoCodebySchoolCode(ByVal Type As String, ByVal _Schoolcode As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_getSchoolGeoCode"
        Try
            Dim myPara(1)    ' 
            setParameterArray(myPara, 0, "@Type", DbType.String, 30, Type)
            setParameterArray(myPara, 1, "@SchoolCode", DbType.String, 8, _Schoolcode)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Sub MultipleSchoolPositionSave(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal IDs As String, ByVal _pSchool As String, ByVal _pTitle As String, ByVal _pFTE As String, ByVal _pDescription As String)
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_MultipleSchool"
        Try
            Dim myPara(7)    ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 10, _PositionID)
            setParameterArray(myPara, 3, "@IDs", DbType.String, 10, IDs)
            setParameterArray(myPara, 4, "@SchoolCode", DbType.String, 8, _pSchool)
            setParameterArray(myPara, 5, "@Title", DbType.String, 150, _pTitle)
            setParameterArray(myPara, 6, "@FTE", DbType.String, 10, _pFTE)
            setParameterArray(myPara, 7, "@Description", DbType.String, 150, _pDescription)

            getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)

        End Try
    End Sub
    Public Shared Function MultipleSchoolPosition(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_MultipleSchool"
        Try
            Dim myPara(2)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID)
            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function RequestNewPositionbyID(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_RequestbyID2"
        Try
            Dim myPara(2)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function PositionSummarybyID(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_PostSummarybyID"
        Try
            Dim myPara(2)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID)
            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function PositionSummarybyID(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _PostingCycle As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_PostSummarybyID"
        Try
            Dim myPara(3)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID)
            setParameterArray(myPara, 3, "@Cycle", DbType.String, 10, _PostingCycle)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function RequestNewPositionSave(ByVal _Action As String, ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _IDs As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_RequestSave2"
        Try
            Dim myPara(4)    ' 
            setParameterArray(myPara, 0, "@Operate", DbType.String, 30, _Action)
            setParameterArray(myPara, 1, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 3, "@IDs", DbType.String, 10, _IDs)
            setParameterArray(myPara, 4, "@PositionID", DbType.String, 20, _PositionID)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function RequestPositionCancel(ByVal _Action As String, ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _IDs As String, ByVal _postComents As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_PostCancel"
        Try
            Dim myPara(5)    ' 
            setParameterArray(myPara, 0, "@Operate", DbType.String, 30, _Action)
            setParameterArray(myPara, 1, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 3, "@IDs", DbType.String, 10, _IDs)
            setParameterArray(myPara, 4, "@PositionID", DbType.String, 20, _PositionID)
            setParameterArray(myPara, 5, "@PostComments", DbType.String, 500, _postComents)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function

    Public Shared Function RePostingPositionSave(ByVal _Action As String, ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _IDs As String, ByVal postingcycle As String, ByVal takeApplicants As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_RePostingSave"
        Try
            Dim myPara(6)    ' 
            setParameterArray(myPara, 0, "@Operate", DbType.String, 30, _Action)
            setParameterArray(myPara, 1, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 3, "@IDs", DbType.String, 10, _IDs)
            setParameterArray(myPara, 4, "@PositionID", DbType.String, 20, _PositionID)
            setParameterArray(myPara, 5, "@PostingCycle", DbType.String, 1, postingcycle)
            setParameterArray(myPara, 6, "@takeApplicant", DbType.String, 10, takeApplicants)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function RePostingHiredPositionAndGetID(ByVal _Action As String, ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String, ByVal _comments As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_RePostingHiredGetID"
        Try
            Dim myPara(5)    ' 
            setParameterArray(myPara, 0, "@Operate", DbType.String, 30, _Action)
            setParameterArray(myPara, 1, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 3, "@PositionID", DbType.String, 10, _PositionID)
            setParameterArray(myPara, 4, "@CPNum", DbType.String, 10, _CPNum)
            setParameterArray(myPara, 5, "@Comments", DbType.String, 300, _comments)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function

    Public Shared Function RequestNewPositionSave(ByVal _Action As String, ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolCode As String, ByVal _PositionID As String, ByVal _IDs As String, ByVal _PositionTitle As String, ByVal _qualification As String, ByVal _description As String, ByVal _positionFTE As String, ByVal _enddateApply As String, ByVal _datePublish As String, ByVal _dateStart As String, ByVal _dateEnd As String, ByVal _Positionlevel As String, ByVal _appType As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_RequestSave"
        Try
            Dim myPara(15)    ' 
            setParameterArray(myPara, 0, "@Operate", DbType.String, 30, _Action)
            setParameterArray(myPara, 1, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 3, "@IDs", DbType.String, 10, _IDs)
            setParameterArray(myPara, 4, "@PositionID", DbType.String, 20, _PositionID)
            setParameterArray(myPara, 5, "@SchoolCode", DbType.String, 8, _schoolCode)
            setParameterArray(myPara, 6, "@Positiontitle", DbType.String, 150, _PositionTitle)
            setParameterArray(myPara, 7, "@Qualification", DbType.String, 250, _qualification)
            setParameterArray(myPara, 8, "@Description", DbType.String, 1500, _description)
            setParameterArray(myPara, 9, "@PositionFTE", DbType.String, 10, _positionFTE)
            setParameterArray(myPara, 10, "@DatePublish", DbType.String, 10, _datePublish)
            setParameterArray(myPara, 11, "@DateStart", DbType.String, 10, _dateStart)
            setParameterArray(myPara, 12, "@DateEndApply", DbType.String, 10, _enddateApply)
            setParameterArray(myPara, 13, "@PositionLevel", DbType.String, 10, _Positionlevel)
            setParameterArray(myPara, 14, "@appType", DbType.String, 10, _appType)
            setParameterArray(myPara, 15, "@DateEnd", DbType.String, 10, _dateEnd)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function RequestNewPositionSave(ByVal _Action As String, ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolCode As String, ByVal _PositionID As String, ByVal _IDs As String, ByVal _PositionTitle As String, ByVal _qualification As String, ByVal _description As String, ByVal _positionFTE As String, ByVal _enddateApply As String, ByVal _datePublish As String, ByVal _dateStart As String, ByVal _dateEnd As String, ByVal _Positionlevel As String, ByVal _appType As String, ByVal _PostedComments As String, _LinkPositionID As String, ByVal teacherbeingReplace As String, ByVal teacherbeingReplaceID As String, ByVal dateApplyStart As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_RequestSave"
        Try
            Dim myPara(20)    ' 
            setParameterArray(myPara, 0, "@Operate", DbType.String, 30, _Action)
            setParameterArray(myPara, 1, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 3, "@IDs", DbType.String, 10, _IDs)
            setParameterArray(myPara, 4, "@PositionID", DbType.String, 20, _PositionID)
            setParameterArray(myPara, 5, "@SchoolCode", DbType.String, 8, _schoolCode)
            setParameterArray(myPara, 6, "@Positiontitle", DbType.String, 150, _PositionTitle)
            setParameterArray(myPara, 7, "@Qualification", DbType.String, 250, _qualification)
            setParameterArray(myPara, 8, "@Description", DbType.String, 1500, _description)
            setParameterArray(myPara, 9, "@PositionFTE", DbType.String, 10, _positionFTE)
            setParameterArray(myPara, 10, "@DatePublish", DbType.String, 10, _datePublish)
            setParameterArray(myPara, 11, "@DateStart", DbType.String, 10, _dateStart)
            setParameterArray(myPara, 12, "@DateEndApply", DbType.String, 10, _enddateApply)
            setParameterArray(myPara, 13, "@PositionLevel", DbType.String, 10, _Positionlevel)
            setParameterArray(myPara, 14, "@appType", DbType.String, 10, _appType)
            setParameterArray(myPara, 15, "@DateEnd", DbType.String, 10, _dateEnd)
            setParameterArray(myPara, 16, "@PostedComments", DbType.String, 500, _PostedComments)
            setParameterArray(myPara, 17, "@Link_PositionID", DbType.String, 10, _LinkPositionID)
            setParameterArray(myPara, 18, "@TeacherBeingReplace", DbType.String, 50, teacherbeingReplace)
            setParameterArray(myPara, 19, "@TeacherBeingReplaceID", DbType.String, 10, teacherbeingReplaceID)
            setParameterArray(myPara, 20, "@DateStartApply", DbType.String, 10, dateApplyStart)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function RequestNewPostingByID(ByVal _action As String, ByVal _PositionType As String, ByVal _IDs As String, ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolCode As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_RequestPosting"
        Try

            Dim myPara(5)    ' 
            'setParameterArray(myPara, 0, "@Oprate", DbType.String, 10, _action)
            'setParameterArray(myPara, 1, "@appType", DbType.String, 10, _PositionType)
            'setParameterArray(myPara, 2, "@IDs", DbType.String, 10, _IDs)
            'setParameterArray(myPara, 3, "@UserID", DbType.String, 30, _UserID)
            'setParameterArray(myPara, 4, "@SchoolYear", DbType.String, 8, _schoolyear)
            'setParameterArray(myPara, 5, "@SchoolCode", DbType.String, 8, _schoolCode)
            setBaseParameters3(myPara, _action, _PositionType, _IDs, _UserID, _schoolyear, _schoolCode)
            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function RequestRejecting(ByVal Action As String, ByVal _PositionType As String, ByVal _IDs As String, ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolCode As String, ByVal _cpnum As String, ByVal comments As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_RequestReject"
        Try
            Dim myPara(7)    ' 
            setBaseParameters3(myPara, Action, _PositionType, _IDs, _UserID, _schoolyear, _schoolCode)
            setParameterArray(myPara, 6, "@CPNum", DbType.String, 10, _cpnum)
            setParameterArray(myPara, 7, "@Comments", DbType.String, 500, comments)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function RequestNewPostingSave(ByVal Action As String, ByVal _PositionType As String, ByVal _IDs As String, ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolCode As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_RequestPosting"
        Try
            Dim myPara(5)    ' 
            setBaseParameters3(myPara, Action, _PositionType, _IDs, _UserID, _schoolyear, _schoolCode)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function RequestNewPostingGet(ByVal Action As String, ByVal _PositionType As String, ByVal _IDs As String, ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolCode As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_RequestPosted"
        Try

            Dim myPara(5)    ' 
            setBaseParameters3(myPara, Action, _PositionType, _IDs, _UserID, _schoolyear, _schoolCode)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function RequestNewPostingSave(ByVal Action As String, ByVal _PositionType As String, ByVal _IDs As String, ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolCode As String,
              ByVal startDate As String, ByVal endDate As String, ByVal publishDate As String, ByVal deadline As String, ByVal comments As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_RequestPosted"
        Try
            Dim myPara(11)    ' 
            setBaseParameters3(myPara, Action, _PositionType, _IDs, _UserID, _schoolyear, _schoolCode)
            setParameterArray(myPara, 6, "@DateStart", DbType.String, 10, startDate)
            setParameterArray(myPara, 7, "@DateEnd", DbType.String, 10, endDate)
            setParameterArray(myPara, 8, "@DatePublish", DbType.String, 10, publishDate)
            setParameterArray(myPara, 9, "@DateApplyStart", DbType.String, 10, publishDate)
            setParameterArray(myPara, 10, "@DateDeadLine", DbType.String, 10, deadline)
            setParameterArray(myPara, 11, "@PostComments", DbType.String, 500, comments)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function RequestNewPostingSave(ByVal Action As String, ByVal _PositionType As String, ByVal _IDs As String, ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolCode As String,
              ByVal startDate As String, ByVal endDate As String, ByVal publishDate As String, ByVal dateApplyStart As String, ByVal deadline As String, ByVal comments As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_RequestPosted"
        Try
            Dim myPara(11)    ' 
            setBaseParameters3(myPara, Action, _PositionType, _IDs, _UserID, _schoolyear, _schoolCode)
            setParameterArray(myPara, 6, "@DateStart", DbType.String, 10, startDate)
            setParameterArray(myPara, 7, "@DateEnd", DbType.String, 10, endDate)
            setParameterArray(myPara, 8, "@DatePublish", DbType.String, 10, publishDate)
            setParameterArray(myPara, 9, "@DateApplyStart", DbType.String, 10, dateApplyStart)
            setParameterArray(myPara, 10, "@DateDeadLine", DbType.String, 10, deadline)
            setParameterArray(myPara, 11, "@PostComments", DbType.String, 500, comments)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function RequestNewPostingSave(ByVal Action As String, ByVal _PositionType As String, ByVal _IDs As String, ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolCode As String,
                                                 ByVal _Positionlevel As String, ByVal _PositionTitle As String,
                                                 ByVal _qualification As String, ByVal _description As String,
                                                 ByVal _BTC As String, ByVal _dateStart As String, ByVal _dateEnd As String,
                                                 ByVal _replacedTeacher As String, ByVal _ReasonReplacement As String, ByVal _HRStaff As String,
                                                 ByVal _RequestSource As String, ByVal _RequestSourceID As String, ByVal _RequestComments As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_RequestPosting"
        Try
            Dim myPara(18)    ' 
            setBaseParameters3(myPara, Action, _PositionType, _IDs, _UserID, _schoolyear, _schoolCode)
            setParameterArray(myPara, 6, "@DateStart", DbType.String, 10, _dateStart)
            setParameterArray(myPara, 7, "@DateEnd", DbType.String, 10, _dateEnd)
            setParameterArray(myPara, 8, "@RequestComments", DbType.String, 500, _RequestComments)
            setParameterArray(myPara, 9, "@PositionLevel", DbType.String, 10, _Positionlevel)
            setParameterArray(myPara, 10, "@Positiontitle", DbType.String, 250, _PositionTitle)
            setParameterArray(myPara, 11, "@Description", DbType.String, 1500, _description)
            setParameterArray(myPara, 12, "@Qualification", DbType.String, 500, _qualification)
            setParameterArray(myPara, 13, "@BTC", DbType.String, 20, _BTC)
            setParameterArray(myPara, 14, "@ReplacedTeacher", DbType.String, 50, _replacedTeacher)
            setParameterArray(myPara, 15, "@ReasonReplacement", DbType.String, 250, _ReasonReplacement)
            setParameterArray(myPara, 16, "@HRStaff", DbType.String, 20, _HRStaff)
            setParameterArray(myPara, 17, "@RequestSource", DbType.String, 20, _RequestSource)
            setParameterArray(myPara, 18, "@RequestSourceID", DbType.String, 10, _RequestSourceID)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function

    Public Shared Function DetailbyIDForLTOTeacher(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_forTeacher2"
        Try

            Dim myPara(3)    ' 
            setBaseParameters2(myPara, _UserID, _CPNum, _schoolyear, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function DetailbyIDForLTOTeacherNotQualified(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_forTeacher_NotQualified"
        Try

            Dim myPara(3)    ' 
            setBaseParameters2(myPara, _UserID, _CPNum, _schoolyear, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function DetailbyIDForPrincipalNotice(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_forPrincipal"
        Try

            Dim myPara(2)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function DetailbyIDForHRStaffNotice(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_forHRStaff"
        Try
            Dim myPara(2)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID)
            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function getOfficerProfile(ByVal _Type As String, ByVal _GetBy As String, ByVal _ByValue As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_getOfficerProfile"
        Try

            Dim myPara(2)    ' 
            setParameterArray(myPara, 0, "@Type", DbType.String, 30, _Type)
            setParameterArray(myPara, 1, "@GetBy", DbType.String, 20, _GetBy)
            setParameterArray(myPara, 2, "@ByValue", DbType.String, 20, _ByValue)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return Nothing
        End Try
    End Function
    Public Shared Function getEmailInterviewSchoolCCList(ByVal _Type As String, ByVal _schoolyear As String, ByVal _schoolcode As String, ByVal _positionID As String, ByVal _cpnum As String, ByVal _ApplType As String) As String



        Dim _SP As String = "dbo.tcdsb_LTO_getCCMailInterviewSchoolList"
        Try

            Dim myPara(5)    ' 
            setParameterArray(myPara, 0, "@Type", DbType.String, 30, _Type)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@SchoolCode", DbType.String, 8, _schoolcode)
            setParameterArray(myPara, 3, "@PositionID", DbType.String, 10, _positionID)
            setParameterArray(myPara, 4, "@CPNum", DbType.String, 10, _cpnum)
            setParameterArray(myPara, 5, "@ApplType", DbType.String, 3, _ApplType)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return Nothing
        End Try
    End Function

    Public Shared Function NoticeToOfficerForHired(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _Panel As String, ByVal _SchoolArea As String, ByVal _PositionType As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionNoticeToOfficer"
        Try

            Dim myPara(4)    ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@Panel", DbType.String, 20, _Panel)
            setParameterArray(myPara, 3, "@SchoolArea", DbType.String, 20, _SchoolArea)
            setParameterArray(myPara, 4, "@PositionType", DbType.String, 20, _PositionType)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception

            Return Nothing
        End Try
    End Function
    Public Shared Function NoticeToOfficerForHired(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _Panel As String, ByVal _SchoolArea As String, ByVal _PositionType As String, ByVal _Emaildate As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionNoticeToOfficer"
        Try
            Dim myPara(5)    ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@Panel", DbType.String, 20, _Panel)
            setParameterArray(myPara, 3, "@SchoolArea", DbType.String, 20, _SchoolArea)
            setParameterArray(myPara, 4, "@PositionType", DbType.String, 20, _PositionType)
            setParameterArray(myPara, 5, "@EmailDate", DbType.String, 10, _Emaildate)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function NoticeToPrincipal(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionNoticeToPrincipal"
        Try

            Dim myPara(2)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception

            Return Nothing
        End Try
    End Function
    Public Shared Function NoticeToPrincipal(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _RequestID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionNoticeToPrincipalMultipleSchool"
        Try

            Dim myPara(3)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID)
            setParameterArray(myPara, 3, "@RequestID", DbType.String, 10, _RequestID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception

            Return Nothing
        End Try
    End Function
    Public Shared Function NoticeToTeacher(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionNoticeToTeacher"
        Try

            Dim myPara(2)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception

            Return Nothing
        End Try
    End Function
    Public Shared Function NoticeToTeacher(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal action As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionNoticeToTeacher"
        Try
            Dim myPara(3)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID)
            setParameterArray(myPara, 3, "@Action", DbType.String, 20, action)
            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception

            Return Nothing
        End Try
    End Function
    Public Shared Function NoticeToPrincipal(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _Datenotice As String, ByVal _PrincipalID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionNoticeToPrincipal"
        Try

            Dim myPara(4)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID)
            setParameterArray(myPara, 3, "@NoticeDate", DbType.String, 10, _Datenotice)
            setParameterArray(myPara, 4, "@PrincipalID", DbType.String, 20, _PrincipalID)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function NoticeToHRStaffForMoreInterviewCandidate(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionNoticeToHRStaffForMoreInterviewCandidate"
        Try

            Dim myPara(2)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception

            Return Nothing
        End Try
    End Function
    Public Shared Function NoticeToHRStaffForMoreInterviewCandidate(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _Count As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionNoticeToHRStaffForMoreInterviewCandidate"
        Try

            Dim myPara(3)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID)
            setParameterArray(myPara, 3, "@Count", DbType.String, 10, _Count)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function NoticeToHRStaffInterviewNotSuitable(ByVal schoolyear As String, ByVal schoolcode As String, ByVal PositionID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionNoticeToHRStaffInterviewNotSuitable"
        Try

            Dim myPara(2)    ' 
            setParameterArray(myPara, 0, "@SchoolCode", DbType.String, 8, schoolcode)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 20, PositionID)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function

    Public Shared Function ApplyThisPosition(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String, ByVal _Action As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionApply2"
        Try

            Dim myPara(4)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID, _CPNum)
            setParameterArray(myPara, 4, "@Action", DbType.String, 20, _Action)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function ApplyThisPosition(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String, ByVal _Action As String, ByVal _comments As String, ByVal _homephone As String, ByVal _cellphone As String, ByVal _email As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionApply2"
        Try

            Dim myPara(8)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID, _CPNum)
            setParameterArray(myPara, 4, "@Action", DbType.String, 20, _Action)
            setParameterArray(myPara, 5, "@Comments", DbType.String, 500, _comments)
            setParameterArray(myPara, 6, "@HomePhone", DbType.String, 20, _homephone)
            setParameterArray(myPara, 7, "@CellPhone", DbType.String, 20, _cellphone)
            setParameterArray(myPara, 8, "@Emailadd", DbType.String, 50, _email)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function ApplyThisPositionOnBehalfCheck(ByVal _Action As String, ByVal _schoolyear As String, ByVal _schoolcode As String, ByVal _PositionID As String, ByVal _CPNum As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionApply_onbehalfCheck"
        Try

            Dim myPara(4)    ' 
            setParameterArray(myPara, 0, "@Action", DbType.String, 30, _Action)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@SchoolCode", DbType.String, 8, _schoolcode)
            setParameterArray(myPara, 3, "@PositionID", DbType.String, 20, _PositionID)
            setParameterArray(myPara, 4, "@CPNum", DbType.String, 10, _CPNum)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function ApplyThisPositionOnBehalf(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String, ByVal _Action As String, ByVal _comments As String, ByVal _homephone As String, ByVal _cellphone As String, ByVal _email As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionApply_onbehalf"
        Try

            Dim myPara(8)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID, _CPNum)
            setParameterArray(myPara, 4, "@Action", DbType.String, 20, _Action)
            setParameterArray(myPara, 5, "@Comments", DbType.String, 500, _comments)
            setParameterArray(myPara, 6, "@HomePhone", DbType.String, 20, _homephone)
            setParameterArray(myPara, 7, "@CellPhone", DbType.String, 20, _cellphone)
            setParameterArray(myPara, 8, "@Emailadd", DbType.String, 50, _email)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function ApplicantProfile(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantProfile"
        Try

            Dim myPara(3)    ' 
            setBaseParameters2(myPara, _UserID, _CPNum, _schoolyear, _PositionID)


            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function ApplicantComment(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _PositionID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantComment"
        Try

            Dim myPara(3)    ' 
            setBaseParameters2(myPara, _UserID, _CPNum, _schoolyear, _PositionID)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function InterviewCandidatePosition(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _PositionID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantProfile_checkPositionProcess"
        Try

            Dim myPara(3)    ' 
            setBaseParameters2(myPara, _UserID, _CPNum, _schoolyear, _PositionID)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try
    End Function
    Public Shared Function InterviewCandidateCount(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _PositionID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantProfile_InterviewCount"
        Try

            Dim myPara(3)    ' 
            setBaseParameters2(myPara, _UserID, _CPNum, _schoolyear, _PositionID)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try
    End Function
    Public Shared Function InterviewCandidateSignature(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _schoolcode As String, ByVal _PositionID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantProfile_CheckSignatureAll"
        Try

            Dim myPara(3)    ' 
            setBaseParameters2(myPara, _UserID, _CPNum, _schoolyear, _PositionID)
            setParameterArray(myPara, 4, "@SchoolCode", DbType.String, 8, _schoolcode)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try
    End Function
    Public Shared Function remaindSignOffCount(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _schoolcode As String, ByVal _PositionID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantProfile_CheckSignatureCount"
        Try

            Dim myPara(3)    ' 
            setBaseParameters2(myPara, _UserID, _CPNum, _schoolyear, _PositionID)
            setParameterArray(myPara, 4, "@SchoolCode", DbType.String, 8, _schoolcode)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try
    End Function


    Public Shared Function InterviewCandidateProfile(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantProfile_Interview2"
        Try

            Dim myPara(3)    ' 
            setBaseParameters2(myPara, _UserID, _CPNum, _schoolyear, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function InterviewTeam(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _sequence As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantProfile_InterviewTeam"
        Try

            Dim myPara(4)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID, _CPNum)
            setParameterArray(myPara, 4, "@Sequence", DbType.Int16, 0, _sequence)
            Return getMyDataValue(_SP, myPara)

        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try
    End Function
    Public Shared Function InterviewTeam(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _sequence As String, ByVal _memberID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantProfile_InterviewTeam"
        Try

            Dim myPara(5)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID, _CPNum)
            setParameterArray(myPara, 4, "@Sequence", DbType.Int16, 0, _sequence)
            setParameterArray(myPara, 5, "@MemberID", DbType.String, 30, _memberID)
            Return getMyDataValue(_SP, myPara)

        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try
    End Function
    Public Shared Function InterviewTeam(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _sequence As String, ByVal _memberID As String, ByVal _Action As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantProfile_InterviewTeam"
        Try

            Dim myPara(6)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID, _CPNum)
            setParameterArray(myPara, 4, "@Sequence", DbType.Int16, 0, _sequence)
            setParameterArray(myPara, 5, "@MemberID", DbType.String, 30, _memberID)
            setParameterArray(myPara, 6, "@Action", DbType.String, 30, _Action)
            Return getMyDataValue(_SP, myPara)

        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try
    End Function
    Public Shared Function InterviewSignature(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantProfile_Signature"
        Try
            Dim myPara(3)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID, _CPNum)
            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function InterviewSignature(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _Signature As String, ByVal _SignatureID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantProfile_Signature"
        Try
            Dim myPara(5)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID, _CPNum)
            setParameterArray(myPara, 4, "@Signature", DbType.String, 50, _Signature)
            setParameterArray(myPara, 5, "@SignatureID", DbType.String, 30, _SignatureID)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return "Failed"
        End Try
    End Function
    Public Shared Function HiringCandidateProfile(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantProfile_Hiring"
        Try

            Dim myPara(3)    ' 
            setBaseParameters2(myPara, _UserID, _CPNum, _schoolyear, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function HiringCandidateProfile4th(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantProfile_Hiring4th"
        Try

            Dim myPara(3)    ' 
            setBaseParameters2(myPara, _UserID, _CPNum, _schoolyear, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function HiringCandidateProfile4thRound(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantProfile_Hiring4thRound"
        Try

            Dim myPara(3)    ' 
            setBaseParameters2(myPara, _UserID, _CPNum, _schoolyear, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function AcceptanceInterview(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String, ByVal _Action As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_SelectedForInterview"
        Try

            Dim myPara(4)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID, _CPNum)
            setParameterArray(myPara, 4, "@Action", DbType.String, 20, _Action)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function

    Public Shared Function PositionHireStage(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_HireStage"
        Try

            Dim myPara(2)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function SelectInterview(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_SelectedInterviewCandidate"
        Try

            Dim myPara(2)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function SelectInterview(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String, ByVal _Action As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_SelectedInterviewCandidate"
        Try

            Dim myPara(4)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID, _CPNum)
            setParameterArray(myPara, 4, "@Action", DbType.String, 20, _Action)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function RecommandforHiring(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String, ByVal _recommandation As String, ByVal _interviewDate As String, ByVal _effectiveDate As String, ByVal _acceptance As String, ByVal _InterviewProcess As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_RecommandForHiring"
        Try

            Dim myPara(8)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID, _CPNum)
            setParameterArray(myPara, 4, "@Recommendation", DbType.String, 1000, _recommandation)
            setParameterArray(myPara, 5, "@Dateinterview", DbType.String, 10, _interviewDate)
            setParameterArray(myPara, 6, "@Acceptance", DbType.String, 1, _acceptance)
            setParameterArray(myPara, 7, "@InterviewProcess", DbType.String, 10, _InterviewProcess)
            setParameterArray(myPara, 8, "@DateEffective", DbType.String, 10, _effectiveDate)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function RecommandforHiringbyItem(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String, ByVal _operateField As String, ByVal _Value As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_RecommandForHiringbyItem"
        Try

            Dim myPara(5)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID, _CPNum)
            setParameterArray(myPara, 4, "@operateField", DbType.String, 50, _operateField)
            setParameterArray(myPara, 5, "@Value", DbType.String, 100, _Value)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function InterviewUpdate(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String, ByVal _recommandation As String, ByVal _interviewDate As String, ByVal _effectiveDate As String, ByVal _InterviewProcess As String, ByVal _acceptance As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_RecommandForInterview"
        Try

            Dim myPara(6)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID, _CPNum)
            setParameterArray(myPara, 4, "@Recommendation", DbType.String, 1000, _recommandation)
            setParameterArray(myPara, 5, "@Dateinterview", DbType.String, 10, _interviewDate)
            setParameterArray(myPara, 6, "@InterviewProcess", DbType.String, 10, _InterviewProcess)
            '   setParameterArray(myPara, 7, "@DateEffective", DbType.String, 10, _effectiveDate)
            '   setParameterArray(myPara, 8, "@Acceptance", DbType.String, 1, _acceptance)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function InterviewUpdateSignOff(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_RecommandForInterviewSignOff"
        Try

            Dim myPara(3)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID, _CPNum)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function AcceptanceHiring(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String, ByVal _recommandation As String, ByVal _interviewDate As String, ByVal _acceptance As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_RecommandForHiring"
        Try

            Dim myPara(6)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID, _CPNum)
            setParameterArray(myPara, 4, "@Recommendation", DbType.String, 1000, _recommandation)
            setParameterArray(myPara, 5, "@Dateinterview", DbType.String, 10, _interviewDate)
            setParameterArray(myPara, 6, "@Acceptance", DbType.String, 1, _acceptance)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function SaveConfirmHire_eMailLog(ByVal _UserID As String, ByVal _Type As String, ByVal _schoolyear As String, ByVal _schoolcode As String, ByVal _PositionID As String, ByVal _PositionTitle As String, ByVal _postingNum As String, ByVal _noticePrincipal As String, ByVal _emailType As String, ByVal _emailTo As String, ByVal _emailCC As String, ByVal _emailFrom As String, ByVal _emailSubject As String, ByVal _emailBody As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_ConfirmForHir_Log"
        Try

            Dim myPara(13)    ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@Type", DbType.String, 10, _Type)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 3, "@SchoolCode", DbType.String, 8, _schoolcode)
            setParameterArray(myPara, 4, "@PositionID", DbType.String, 10, _PositionID)
            setParameterArray(myPara, 5, "@PositionTitle", DbType.String, 250, _PositionTitle)
            setParameterArray(myPara, 6, "@PostingNum", DbType.String, 15, _postingNum)
            setParameterArray(myPara, 7, "@NoticePrincipal", DbType.String, 10, _noticePrincipal)
            setParameterArray(myPara, 8, "@EmailType", DbType.String, 20, _emailType)
            setParameterArray(myPara, 9, "@EmailTo", DbType.String, 50, _emailTo)
            setParameterArray(myPara, 10, "@EmailCC", DbType.String, 150, _emailCC)
            setParameterArray(myPara, 11, "@EmailFrom", DbType.String, 50, _emailFrom)
            setParameterArray(myPara, 12, "@EmailSubject", DbType.String, 250, _emailSubject)
            setParameterArray(myPara, 13, "@EmailBody", DbType.String, 4000, HttpContext.Current.Server.HtmlDecode(_emailBody))
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return ""
        End Try
    End Function
    Public Shared Sub SaveConfirmHire_eMailLogPDF(ByVal _UserID As String, ByVal _Type As String, ByVal _schoolyear As String, ByVal _schoolcode As String, ByVal _PositionID As String, ByVal _IDs As String, ByVal _emailFile As String)
        Dim _SP As String = "dbo.tcdsb_LTO_ConfirmForHir_Log"
        Try

            Dim myPara(6)    ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@Type", DbType.String, 10, _Type)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 3, "@SchoolCode", DbType.String, 8, _schoolcode)
            setParameterArray(myPara, 4, "@PositionID", DbType.String, 10, _PositionID)
            setParameterArray(myPara, 5, "@IDs", DbType.String, 10, _IDs)
            setParameterArray(myPara, 6, "@EmailFile", DbType.String, 8000, _emailFile)
            getMyDataValue(_SP, myPara)
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Function AcceptanceHire(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String, ByVal _recommandation As String, ByVal _interviewDate As String, ByVal _effectiveDate As String, ByVal _acceptance As String, ByVal _PrincipaleMail As String, ByVal _OfficereMail As String, ByVal _Action As String, ByVal _payStatus As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_ConfirmForHiring"
        Try

            Dim myPara(11)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID, _CPNum)
            setParameterArray(myPara, 4, "@Comments", DbType.String, 1000, _recommandation)
            setParameterArray(myPara, 5, "@DateConfirm", DbType.String, 10, _interviewDate)
            setParameterArray(myPara, 6, "@Acceptance", DbType.String, 1, _acceptance)
            setParameterArray(myPara, 7, "@DateEffective", DbType.String, 10, _effectiveDate)
            setParameterArray(myPara, 8, "@PrincipalEmail", DbType.String, 10, _PrincipaleMail)
            setParameterArray(myPara, 9, "@OfficerEmail", DbType.String, 10, _OfficereMail)
            setParameterArray(myPara, 10, "@Action", DbType.String, 30, _Action)
            setParameterArray(myPara, 11, "@PayStatus", DbType.String, 10, _payStatus)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function AcceptanceHire4ThRound(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String, ByVal _Name As String, ByVal _recommandation As String, ByVal _EndDate As String, ByVal _effectiveDate As String, ByVal _HireDate As String, ByVal _acceptance As String, ByVal _PrincipaleMail As String, ByVal _Action As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_ConfirmForHiring4thRound"
        Try

            Dim myPara(11)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID, _CPNum)
            setParameterArray(myPara, 4, "@Name", DbType.String, 50, _Name)
            setParameterArray(myPara, 5, "@Comments", DbType.String, 500, _recommandation)
            setParameterArray(myPara, 6, "@DateEnd", DbType.String, 10, _EndDate)
            setParameterArray(myPara, 7, "@Acceptance", DbType.String, 1, _acceptance)
            setParameterArray(myPara, 8, "@DateEffective", DbType.String, 10, _effectiveDate)
            setParameterArray(myPara, 9, "@DateHire", DbType.String, 10, _HireDate)
            setParameterArray(myPara, 10, "@PrincipalEmail", DbType.String, 10, _PrincipaleMail)
            setParameterArray(myPara, 11, "@Action", DbType.String, 30, _Action)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function AcceptanceHire4Th(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String, ByVal _FirstName As String, ByVal _LastName As String, ByVal _recommandation As String, ByVal _EndDate As String, ByVal _effectiveDate As String, ByVal _HireDate As String, ByVal _acceptance As String, ByVal _PrincipaleMail As String, ByVal _OfficereMail As String, ByVal _Action As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_ConfirmForHiring4th"
        Try

            Dim myPara(13)    ' 
            setBaseParameters(myPara, _UserID, _schoolyear, _PositionID, _CPNum)
            setParameterArray(myPara, 4, "@FirstName", DbType.String, 50, _FirstName)
            setParameterArray(myPara, 5, "@LastName", DbType.String, 50, _LastName)
            setParameterArray(myPara, 6, "@Comments", DbType.String, 1000, _recommandation)
            setParameterArray(myPara, 7, "@DateEnd", DbType.String, 10, _EndDate)
            setParameterArray(myPara, 8, "@Acceptance", DbType.String, 1, _acceptance)
            setParameterArray(myPara, 9, "@DateEffective", DbType.String, 10, _effectiveDate)
            setParameterArray(myPara, 10, "@DateHire", DbType.String, 10, _HireDate)
            setParameterArray(myPara, 11, "@PrincipalEmail", DbType.String, 10, _PrincipaleMail)
            setParameterArray(myPara, 12, "@OfficerEmail", DbType.String, 10, _OfficereMail)
            setParameterArray(myPara, 13, "@Action", DbType.String, 30, _Action)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function getNamebyCPNum(UserID, _schoolYear, _PositionID, checkCPNum) As String
        Dim _SP As String = "dbo.tcdsb_LTO_ConfirmForHiring4th_CheckTeacherName"
        Try

            Dim myPara(3)    ' 
            setBaseParameters(myPara, UserID, _schoolYear, _PositionID, checkCPNum)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return ""
        End Try
    End Function

    Public Shared Function GetDeadlineDate(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _publishDaye As String) As Date
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_DeadlineDate"
        Try
            Dim myPara(2)    ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@publishDate", DbType.String, 10, _publishDaye)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try

    End Function
    Public Shared Function GetDeadlineDate2(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _publishDaye As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_DeadlineDate2"
        Try
            Dim myPara(2)    ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@publishDate", DbType.String, 10, _publishDaye)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try

    End Function
    Public Shared Function GetRequestID(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolcode As String, ByVal _PositionType As String, ByVal _positionID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_RequestPostingID"
        Try
            Dim myPara(4)    ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@SchoolCode", DbType.String, 8, _schoolcode)
            setParameterArray(myPara, 3, "@PositionType", DbType.String, 20, _PositionType)
            setParameterArray(myPara, 4, "@PositionID", DbType.String, 10, _positionID)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try

    End Function
    Public Shared Function GetRequestID(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolcode As String, ByVal _PositionType As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PageRequest_CreateNewAndGetRequestID"
        Try
            Dim myPara(5)    ' 
            setParameterArray(myPara, 0, "@Operate", DbType.String, 30, "Create")
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 20, 0)
            setParameterArray(myPara, 3, "@PositionType", DbType.String, 20, _PositionType)
            setParameterArray(myPara, 4, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 5, "@SchoolCode", DbType.String, 8, _schoolcode)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try

    End Function
End Class
