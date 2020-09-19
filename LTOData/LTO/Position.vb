Imports TCDSB.Student.Data
Imports System.Data.SqlClient
Imports System.Web
Public Class Position
    Public Shared cPage As Object
    Private _schoolyear As String
    Private _VisitPhase As String
    Private _SchoolCode As String
    Private Shared _Title As String
    Private Shared _replaceteacher As String
    Private _PositionID As String
    Private _Description As String
    Private _FTE As String
    Private _Qualification As String
    Private _Level As String
    Private _Comments As String
    Private _Owner As String
    Private _DateStart As Date
    Private _DateEnd As Date
    Private _DatePublish As Date
    Private _DateApply As Date
    Private _Type As String
    Private _LinkID As String
    Public Position()

    Public Property SchoolYear(ByVal ID As String) As String
        Get
            Return _schoolyear
        End Get
        Set(value As String)
            _schoolyear = value
        End Set
    End Property

    Public Property SchoolCode(ByVal ID As String) As String
        Get
            Return _SchoolCode
        End Get
        Set(value As String)
            _SchoolCode = value
        End Set
    End Property

    Public Shared ReadOnly Property Title(ByVal _PositionID As String) As String
        Get
            Return getPositionProfile(_PositionID, "Title")
        End Get
    End Property
    Public Shared ReadOnly Property ReplaceTeacher(ByVal _PositionID As String) As String
        Get
            Return getPositionProfile(_PositionID, "ReplaceTeacher")
        End Get
    End Property
    Public Shared ReadOnly Property PostingNumber(ByVal _PositionID As String) As String
        Get
            Return getPositionProfile(_PositionID, "PostingNumber")
        End Get
    End Property
    Public Shared ReadOnly Property StartDate(ByVal _PositionID As String) As String
        Get
            Return getPositionProfile(_PositionID, "StartDate")
        End Get
    End Property
    Public Shared ReadOnly Property EndDate(ByVal _PositionID As String) As String
        Get
            Return getPositionProfile(_PositionID, "EndDate")
        End Get
    End Property

    Private Shared Function getPositionProfile(ByVal _PositionID As String, ByVal _Action As String)
        Dim _SP As String = "dbo.tcdsb_LTO_PositionProfile"
        Try
            Dim myPara(1) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@Operate", DbType.String, 30, _Action)
            setParameterArray(myPara, 1, "@PositionID", DbType.String, 10, _PositionID)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function

    Public Shared Function RequestNewPositionSave(ByVal _Action As String, ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolCode As String, ByVal _PositionID As String, ByVal _IDs As String, ByVal _PositionTitle As String, ByVal _qualification As String, ByVal _description As String, ByVal _positionFTE As String, ByVal _enddateApply As String, ByVal _datePublish As String, ByVal _dateStart As String, ByVal _dateEnd As String, ByVal _Positionlevel As String, ByVal _appType As String, ByVal _PostedComments As String, _LinkPositionID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_RequestSave2"
        Try
            Dim myPara(17) ' As tpaWS.MyParameter  ' 
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

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function GeoCodebySchoolCode(ByVal Type As String, ByVal _Schoolcode As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_getSchoolGeoCode"
        Try
            Dim myPara(1) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@Type", DbType.String, 30, Type)
            setParameterArray(myPara, 1, "@SchoolCode", DbType.String, 8, _Schoolcode)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function RequestNewPositionbyID(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_RequestbyID2"
        Try
            Dim myPara(2) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 20, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function RequestNewPositionSave(ByVal _Action As String, ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _IDs As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_RequestSave2"
        Try
            Dim myPara(4) ' As tpaWS.MyParameter  ' 
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
            Dim myPara(5) ' As tpaWS.MyParameter  ' 
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
            Dim myPara(6) ' As tpaWS.MyParameter  ' 
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
    Public Shared Function RequestNewPositionSave(ByVal _Action As String, ByVal _UserID As String, ByVal _schoolyear As String, ByVal _schoolCode As String, ByVal _PositionID As String, ByVal _IDs As String, ByVal _PositionTitle As String, ByVal _qualification As String, ByVal _description As String, ByVal _positionFTE As String, ByVal _enddateApply As String, ByVal _datePublish As String, ByVal _dateStart As String, ByVal _dateEnd As String, ByVal _Positionlevel As String, ByVal _appType As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_RequestSave"
        Try
            Dim myPara(15) ' As tpaWS.MyParameter  ' 
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


    Public Shared Function DetailbyIDForLTOTeacher(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_forTeacher"
        Try

            Dim myPara(3) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@CPNum", DbType.String, 10, _CPNum)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 3, "@PositionID", DbType.String, 20, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function DetailbyIDForPrincipalNotice(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_forPrincipal"
        Try

            Dim myPara(2) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 20, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function DetailbyIDForHRStaffNotice(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_forHRStaff"
        Try

            Dim myPara(2) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 20, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function getOfficerProfile(ByVal _Type As String, ByVal _GetBy As String, ByVal _ByValue As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_getOfficerProfile"
        Try

            Dim myPara(2) ' As tpaWS.MyParameter  ' 
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

            Dim myPara(5) ' As tpaWS.MyParameter  ' 
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

            Dim myPara(4) ' As tpaWS.MyParameter  ' 
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
            Dim myPara(5) ' As tpaWS.MyParameter  ' 
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

            Dim myPara(2) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 20, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception

            Return Nothing
        End Try
    End Function
    Public Shared Function NoticeToTeacher(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_PositionNoticeToTeacher"
        Try

            Dim myPara(2) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 20, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception

            Return Nothing
        End Try
    End Function
    Public Shared Function NoticeToPrincipal(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _Datenotice As String, ByVal _PrincipalID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionNoticeToPrincipal"
        Try

            Dim myPara(4) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 20, _PositionID)
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

            Dim myPara(2) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 20, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception

            Return Nothing
        End Try
    End Function
    Public Shared Function NoticeToHRStaffForMoreInterviewCandidate(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _Count As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionNoticeToHRStaffForMoreInterviewCandidate"
        Try

            Dim myPara(3) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 20, _PositionID)
            setParameterArray(myPara, 3, "@Count", DbType.String, 10, _Count)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function ApplyThisPosition(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String, ByVal _Action As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionApply2"
        Try

            Dim myPara(4) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 20, _PositionID)
            setParameterArray(myPara, 3, "@CPNum", DbType.String, 10, _CPNum)
            setParameterArray(myPara, 4, "@Action", DbType.String, 20, _Action)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function ApplyThisPosition(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String, ByVal _Action As String, ByVal _comments As String, ByVal _homephone As String, ByVal _cellphone As String, ByVal _email As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_PositionApply2"
        Try

            Dim myPara(8) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 20, _PositionID)
            setParameterArray(myPara, 3, "@CPNum", DbType.String, 10, _CPNum)
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

            Dim myPara(3) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@CPNum", DbType.String, 10, _CPNum)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 3, "@PositionID", DbType.String, 20, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function ApplicantComment(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _PositionID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantComment"
        Try

            Dim myPara(3) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@CPNum", DbType.String, 10, _CPNum)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 3, "@PositionID", DbType.String, 20, _PositionID)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function InterviewCandidatePosition(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _PositionID As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantProfile_checkPositionProcess"
        Try

            Dim myPara(3) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@CPNum", DbType.String, 10, _CPNum)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 3, "@PositionID", DbType.String, 20, _PositionID)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return ""
        End Try
    End Function
    Public Shared Function InterviewCandidateProfile(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantProfile_Interview2"
        Try

            Dim myPara(3) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@CPNum", DbType.String, 10, _CPNum)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 3, "@PositionID", DbType.String, 20, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function HiringCandidateProfile(ByVal _UserID As String, ByVal _CPNum As String, ByVal _schoolyear As String, ByVal _PositionID As String) As DataSet
        Dim _SP As String = "dbo.tcdsb_LTO_ApplicantProfile_Hiring"
        Try

            Dim myPara(3) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@CPNum", DbType.String, 10, _CPNum)
            setParameterArray(myPara, 2, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 3, "@PositionID", DbType.String, 20, _PositionID)

            Return getMyDataSet(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try
    End Function
    Public Shared Function AcceptanceInterview(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String, ByVal _Action As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_SelectedForInterview"
        Try

            Dim myPara(4) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 20, _PositionID)
            setParameterArray(myPara, 3, "@CPNum", DbType.String, 10, _CPNum)
            setParameterArray(myPara, 4, "@Action", DbType.String, 20, _Action)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function RecommandforHiring(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String, ByVal _recommandation As String, ByVal _interviewDate As String, ByVal _effectiveDate As String, ByVal _acceptance As String, ByVal _InterviewProcess As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_RecommandForHiring"
        Try

            Dim myPara(8) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 20, _PositionID)
            setParameterArray(myPara, 3, "@CPNum", DbType.String, 10, _CPNum)
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
    Public Shared Function InterviewUpdate(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String, ByVal _recommandation As String, ByVal _interviewDate As String, ByVal _effectiveDate As String, ByVal _InterviewProcess As String, ByVal _acceptance As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_RecommandForInterview"
        Try

            Dim myPara(8) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 20, _PositionID)
            setParameterArray(myPara, 3, "@CPNum", DbType.String, 10, _CPNum)
            setParameterArray(myPara, 4, "@Recommendation", DbType.String, 1000, _recommandation)
            setParameterArray(myPara, 5, "@Dateinterview", DbType.String, 10, _interviewDate)
            setParameterArray(myPara, 6, "@InterviewProcess", DbType.String, 10, _InterviewProcess)
            setParameterArray(myPara, 7, "@DateEffective", DbType.String, 10, _effectiveDate)
            setParameterArray(myPara, 8, "@Acceptance", DbType.String, 1, _acceptance)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function

    Public Shared Function AcceptanceHiring(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String, ByVal _recommandation As String, ByVal _interviewDate As String, ByVal _acceptance As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_RecommandForHiring"
        Try

            Dim myPara(6) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 20, _PositionID)
            setParameterArray(myPara, 3, "@CPNum", DbType.String, 10, _CPNum)
            setParameterArray(myPara, 4, "@Recommendation", DbType.String, 1000, _recommandation)
            setParameterArray(myPara, 5, "@Dateinterview", DbType.String, 10, _interviewDate)
            setParameterArray(myPara, 6, "@Acceptance", DbType.String, 1, _acceptance)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function AcceptanceHire(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _PositionID As String, ByVal _CPNum As String, ByVal _recommandation As String, ByVal _interviewDate As String, ByVal _effectiveDate As String, ByVal _acceptance As String, ByVal _PrincipaleMail As String, ByVal _OfficereMail As String, ByVal _Action As String) As String
        Dim _SP As String = "dbo.tcdsb_LTO_ConfirmForHiring"
        Try

            Dim myPara(10) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@PositionID", DbType.String, 20, _PositionID)
            setParameterArray(myPara, 3, "@CPNum", DbType.String, 10, _CPNum)
            setParameterArray(myPara, 4, "@Comments", DbType.String, 1000, _recommandation)
            setParameterArray(myPara, 5, "@DateConfirm", DbType.String, 10, _interviewDate)
            setParameterArray(myPara, 6, "@Acceptance", DbType.String, 1, _acceptance)
            setParameterArray(myPara, 7, "@DateEffective", DbType.String, 10, _effectiveDate)
            setParameterArray(myPara, 8, "@PrincipalEmail", DbType.String, 10, _PrincipaleMail)
            setParameterArray(myPara, 9, "@OfficerEmail", DbType.String, 10, _OfficereMail)
            setParameterArray(myPara, 10, "@Action", DbType.String, 30, _Action)
            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception

            Return "Failed"
        End Try
    End Function
    Public Shared Function GetDeadlineDate(ByVal _UserID As String, ByVal _schoolyear As String, ByVal _publishDaye As String) As Date
        Dim _SP As String = "dbo.tcdsb_LTO_PositionDetails_DeadlineDate"
        Try
            Dim myPara(2) ' As tpaWS.MyParameter  ' 
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
            Dim myPara(2) ' As tpaWS.MyParameter  ' 
            setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _UserID)
            setParameterArray(myPara, 1, "@SchoolYear", DbType.String, 8, _schoolyear)
            setParameterArray(myPara, 2, "@publishDate", DbType.String, 10, _publishDaye)

            Return getMyDataValue(_SP, myPara)
        Catch ex As Exception
            CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
            Return Nothing
        End Try

    End Function
End Class
