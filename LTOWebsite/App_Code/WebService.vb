Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services
Imports ClassLibrary
Imports AppOperate
Imports Newtonsoft.Json
' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<WebService(Namespace:="http://tempuri.org/")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Public Class WebService
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function



    <WebMethod()>
    Public Function SelectInterview(ByVal schoolyear As String, ByVal PositionID As String, ByVal CPNum As String, ByVal Action As String) As String

        Try
            Dim UserID As String = HttpContext.Current.User.Identity.Name

            Dim operation As ParametersForOperation = New ParametersForOperation() ' ObjClassFactory.GetParametersObj() ' ObjClassFactory.GetParametersObj(Of ParametersForOperation)() 
            With operation
                .Operate = "SelectForInterview"
                .UserID = User.Identity.Name
                .SchoolYear = schoolyear
                .PositionID = PositionID
                .CPNum = CPNum
                .Action = Action
            End With
            '   Dim SP As String = CommonExcute.SPNameAndParameters("SelectInterview", "Selected")
            Dim result As String = SelectCandidateExe.Selected(operation) ' CommonExcute(Of ParametersForOperation).GeneralValue(SP, operation) '  CommonOperationExcute.SelectedForInterviewCandidate(operation, "SelectForInterview") ' PositionDetails.AcceptanceInterview(userid, schoolyear, positionID, cpnum, action)


            '  Dim SelectResult As String = TCDSB.Student.PositionDetails.SelectInterview(UserID, schoolyear, PositionID, CPNum, Action)
            Return result
        Catch ex As Exception

            Return "Failed"
        End Try


    End Function

    <WebMethod()>
    Public Function SaveInterviewOutcome(ByVal schoolyear As String, ByVal PositionID As String, ByVal CPNum As String, ByVal myKey As String, ByVal operateField As String, ByVal _Value As String) As String

        Try
            Dim UserID As String = HttpContext.Current.User.Identity.Name
            Dim outcome As InterviewResult = New InterviewResult()
            With outcome
                .Operate = operateField
                .UserID = User.Identity.Name
                .SchoolYear = schoolyear
                .PositionID = PositionID
                .CPNum = CPNum
                .OutCome = _Value
            End With
            '   Dim SP As String = CommonExcute.SPNameAndParameters("Interview", "OutcomeUpdate")
            Dim result = InterviewProcessExe.OutcomeUpdate(outcome) ' SelectCandidateExe.Selected(outcome) '  CommonExcute(Of InterviewResult).GeneralValue(SP, outcome)
            '  Dim result As String = TCDSB.Student.PositionDetails.RecommandforHiringbyItem(UserID, schoolyear, PositionID, CPNum, operateField, _Value)

            Return result

        Catch ex As Exception

            Return "Failed"
        End Try


    End Function

    <WebMethod(EnableSession:=True)>
    Public Function DeadLineDate(ByVal schoolyear As String, ByVal datepublish As String) As String

        Try
            '  Dim myDate As String = TCDSB.Student.PositionDetails.GetDeadlineDate2("mif", schoolyear, datepublish)

            Dim SP As String = CommonExcute.SPNameAndParameters("", "Publish", "Deadline")
            Dim parameter = New With {
                .Operate = "Deadline",
                .PositionType = WorkingProfile.ApplicationType,
                .SchoolYear = schoolyear,
                .PublishDate = datepublish
            }

            Dim myDate As String = PublishPositionExe(Of DeadlineDate).Deadline(parameter) '  CommonExcute(Of DeadlineDate).GeneralValue(SP, parameter)


            Return myDate

        Catch ex As Exception

            Return "Failed"
        End Try


    End Function
    <WebMethod(EnableSession:=True)>
    Public Function SaveSelectedQualification(ByVal _SourceID As String, ByVal _PositionID As String, ByVal _schoolyear As String, ByVal _schoolcode As String, ByVal _QualCode As String) As Boolean
        Try


            If Not SaveSelected(_SourceID, _PositionID, _schoolyear, _schoolcode, _QualCode) Then
                SaveSelected(_SourceID, _PositionID, _schoolyear, _schoolcode, _QualCode)
            End If

            Return True
        Catch ex As Exception

            Return False
        End Try


    End Function
    Private Function SaveSelected(ByVal _SourceID As String, ByVal _PositionID As String, ByVal _schoolyear As String, ByVal _schoolcode As String, ByVal _QualCode As String) As Boolean
        Try
            Dim _userID As String = WorkingProfile.UserID

            Dim qual As QualificationUpdate = New QualificationUpdate()
            With qual
                .PositionID = _PositionID
                .QualificationID = _QualCode
                .SchoolYear = _schoolyear
                .SchoolCode = _schoolcode
                .UserID = _userID
                .SourceID = _SourceID
            End With


            '  Qualifications.Qualification_List(_userID, _schoolyear, _schoolcode, _PositionID, _SourceID, _QualCode, "1")

            Dim SP As String = CommonExcute.SPNameAndParameters("", "Request", "Qualification")

            Dim result As String = CommonExcute(Of QualificationUpdate).GeneralValue(SP, qual)

            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function
    <WebMethod(EnableSession:=True)>
    Public Function SaveSelectedQualification(ByVal _qual As QualificationUpdate) As Boolean
        Try

            If Not SaveSelected(_qual) Then
                SaveSelected(_qual)
            End If

            Return True
        Catch ex As Exception

            Return False
        End Try


    End Function
    Private Function SaveSelected(ByVal _qual As QualificationUpdate) As Boolean
        Try
            Dim _userID As String = WorkingProfile.UserID

            Dim requestID As String = RequestingPostExe.UpdateQualification(_qual, 0)
            '   Return requestID
            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function

    <WebMethod(EnableSession:=True)>
    Public Function GetPositionQualification(ByVal _PositionID As String, ByVal _schoolyear As String, ByVal _schoolcode As String) As String
        Try

            Dim qual As QualificationUpdate = New QualificationUpdate()
            With qual
                .PositionID = _PositionID
                .SchoolYear = _schoolyear
                .SchoolCode = _schoolcode
                .UserID = WorkingProfile.UserID
            End With

            '  Dim SP As String = CommonExcute.SPNameAndParameters("", "Request", "QualificationSTR")
            '  Dim result As String =   CommonExcute(Of QualificationUpdate).GeneralValue(SP, qual)

            Dim result As String = RequestPostingExe.QualificationSTR(qual) ' CommonExcute(Of QualificationUpdate).GeneralValue(SP, qual)


            Return result
        Catch ex As Exception

            Return ""
        End Try


    End Function
    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function GetQualificationbySearch(ByVal selectedQualCode As String, ByVal searchValue As String) As String
        Try

            Dim qual As QualSearch = New QualSearch()
            With qual
                .SearchValue = searchValue
                .SelectedCode = selectedQualCode
            End With
            Dim result = GetJSONFromNewTowSoft(RequestPostingExe.QualificationList(qual)) ' CommonExcute(Of QualificationUpdate).GeneralValue(SP, qual)

            Return result
        Catch ex As Exception

            Return ""
        End Try


    End Function
    Private Function GetJSONFromNewTowSoft(ByVal table As Object) As String
        Dim JSONString As String = String.Empty
        JSONString = JsonConvert.SerializeObject(table)
        Return JSONString
    End Function




    <WebMethod(EnableSession:=True)>
    Public Function CreateNewPostingRequest(ByVal action As String, ByVal _schoolyear As String, ByVal _schoolcode As String, ByVal positionType As String, ByVal _positionID As String) As String
        Try
            Dim _userID As String = WorkingProfile.UserID
            Dim request As NewPosition = New NewPosition()
            With request
                .Operate = action
                .SchoolYear = _schoolyear
                .SchoolCode = _schoolcode
                .PositionType = positionType
                .PositionID = _positionID

            End With
            '  Dim SP As String = CommonExcute.SPNameAndParameters("", "Request", "New")

            '  Dim requestID As String = CommonExcute(Of NewPosition).GeneralValue(SP, request)
            Dim requestID As String = RequestPostingExe.Add(request)
            Return requestID
        Catch ex As Exception

            Return "0"
        End Try


    End Function

    <WebMethod(EnableSession:=True)>
    Public Function CreateNewPostingRequest(ByVal action As String, ByVal request As NewPosition) As String
        Try
            Dim _userID As String = WorkingProfile.UserID
            '  Dim positionType As String = WorkingProfile.ApplicationType
            '  Dim SP As String = CommonExcute.SPNameAndParameters("", "Request", "New")
            ' request.Operate = action
            Dim requestID As String = RequestPostingExe.Add(request) '  CommonExcute(Of NewPosition).GeneralValue(SP, request)

            '  Dim requestID As String = CommonOperationExcute.RequestNewOperation(request, "NewRequest") ' RequestingPostExe.NewRequest(request, 0)
            Return requestID
        Catch ex As Exception

            Return "0"
        End Try
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function CreateNewPublishRequest(ByVal action As String, ByVal request As NewPosition) As String
        Try

            request.Operate = action
            Dim requestID As String = PublishPositionExe(Of String).Add(request)
            ' Dim SP As String = CommonExcute.SPNameAndParameters("", "Publish", "New")
            ' Dim requestID As String = CommonExcute(Of NewPosition).GeneralValue(SP, request)
            '  Dim requestID As String = CommonOperationExcute.PublishNewOperation(request, "NewPublish") '  PostingPublishExe.NewPosting(request, 0)
            Return requestID
        Catch ex As Exception

            Return "0"
        End Try
    End Function

    <WebMethod(EnableSession:=True)>
    Public Function GetTeacherNamebyCPnum(ByVal request As ParametersForTeacher) As String
        Try
            Dim _userID As String = WorkingProfile.UserID
            '  Dim positionType As String = WorkingProfile.ApplicationType
            Dim teacherName As String = RequestPostingExe.TeacherName(request) '  CommonOperationExcute.TeacherNameByCPNum(request, "TeacherName") '  PostingPublishExe.NewPosting(request, 0)
            Return teacherName
        Catch ex As Exception

            Return "Error CPNum"
        End Try


    End Function

    <WebMethod(EnableSession:=True)>
    Public Function SearchbyValueList(ByVal dataSource As String, ByVal paramater As List2Item) As List(Of NameValueList)
        Try
            If dataSource = "Json" Then
                dataSource = Server.MapPath("..\Content\appList.json")
            Else
                dataSource = ""
            End If

            Dim SP As String = CommonExcute.SPNameAndParameters(dataSource, "General", "DDList")

            '  List<NVListItem> ListDataSource(string JsonSource, string ddlType, List2Item parameter)
            Dim list As List(Of NameValueList)

            list = CommonExcute(Of NameValueList).GeneralList(SP, paramater)
            '  Dim requestID As String = CommonOperationExcute.PublishNewOperation(request, "NewPublish") '  PostingPublishExe.NewPosting(request, 0)
            Return list
        Catch ex As Exception

            Return New List(Of NameValueList)
        End Try
    End Function



End Class