Imports AppOperate
Imports ClassLibrary
Imports Microsoft.VisualBasic

Public Class DefaultDate
    Public Shared Sub SetDate(ByVal schoolYear As String, ByVal positionType As String, ByRef startDate As Object, ByRef endDate As Object)

        'Dim myDate As New List(Of LimitDate)
        'myDate = DateSource(schoolYear, positionType)
        Dim myDate As New LTODefalutDate()
        myDate = DateSourceNew(schoolYear, positionType)

        If startDate.Value = "" Then startDate.Value = myDate.StartDate
        If positionType = "LTO" Then
            If endDate.Value = "" Then endDate.Value = myDate.EndDate
        End If

    End Sub


    Public Shared Sub SetDate(ByVal schoolYear As String, ByVal positionType As String, ByRef startDate As Object, ByRef endDate As Object, ByRef datePublish As Object, ByRef dateApplyStart As Object, ByRef dateDeadline As Object)
        'Dim myDate As New List(Of LimitDate)
        'myDate = DateSourceNew(schoolYear, positionType)

        Dim myDate As New LTODefalutDate()
        myDate = DateSourceNew(schoolYear, positionType)

        If startDate.Value = "" Then startDate.Value = myDate.StartDate
        If positionType = "LTO" Then
            If endDate.Value = "" Then endDate.Value = myDate.EndDate
        End If
        If datePublish.Value = "" Then datePublish.Value = myDate.DatePublish
        If dateApplyStart.Value = "" Then dateApplyStart.Value = myDate.DateApplyOpen
        If dateDeadline.Value = "" Then dateDeadline.Value = myDate.DateApplyClose
    End Sub
    Public Shared Sub SetDate(ByVal schoolYear As String, ByVal positionType As String, ByRef startDate As Object, ByRef endDate As Object, ByRef datePublish As Object, ByRef dateApplyStart As Object, ByRef dateDeadline As Object, ByRef hfStartDate As Object, ByRef hfEndate As Object)
        'Dim myDate As New List(Of LimitDate)
        'myDate = DateSourceNew(schoolYear, positionType)

        Dim myDate As New LTODefalutDate()
        myDate = DateSourceNew(schoolYear, positionType)

        If startDate.Value = "" Then startDate.Value = myDate.StartDate
        If positionType = "LTO" Then
            If endDate.Value = "" Then endDate.Value = myDate.EndDate
        End If
        hfStartDate.Value = myDate.StartDate
        hfEndate.Value = myDate.EndDate
        If datePublish.Value = "" Then datePublish.Value = myDate.DatePublish
        If dateApplyStart.Value = "" Then dateApplyStart.Value = myDate.DateApplyOpen
        If dateDeadline.Value = "" Then dateDeadline.Value = myDate.DateApplyClose
    End Sub

    Public Shared Async Sub SetDateAsync(ByVal schoolYear As String, ByVal positionType As String, ByVal startDate As Object, ByVal endDate As Object, ByVal datePublish As Object, ByVal dateApplyStart As Object, ByVal dateDeadline As Object, ByVal hfStartDate As Object, ByVal hfEndate As Object)
        'Dim myDate As New List(Of LimitDate)
        'myDate = DateSourceNew(schoolYear, positionType)

        Dim myDate As New LTODefalutDate()
        myDate = Await DateSourceNewAsync(schoolYear, positionType)

        If startDate.Value = "" Then startDate.Value = myDate.StartDate
        If positionType = "LTO" Then
            If endDate.Value = "" Then endDate.Value = myDate.EndDate
        End If
        hfStartDate.Value = myDate.StartDate
        hfEndate.Value = myDate.EndDate
        If datePublish.Value = "" Then datePublish.Value = myDate.DatePublish
        If dateApplyStart.Value = "" Then dateApplyStart.Value = myDate.DateApplyOpen
        If dateDeadline.Value = "" Then dateDeadline.Value = myDate.DateApplyClose
    End Sub

    Public Shared Function DateSource(ByVal schoolYear As String, ByVal positionType As String) As List(Of LimitDate)
        Dim parameter As New LimitDate()
        With parameter
            .Operate = "GetDefault"
            .PositionType = positionType
            .SchoolYear = schoolYear
        End With
        Dim SP = CommonExcute.SPNameAndParameters("", "Publish", "DefaultDate")
        Dim myDate = CommonExcute(Of LimitDate).GeneralList(SP, parameter) '
        '  CommonListExecute.LimitedDate(parameter) ' PostingPublishExe.LimitedDate(parameter) ' PositionPublished.LimitedDate(parameter)
        Return myDate
    End Function
    Private Shared Function DateSourceNew(ByVal schoolYear As String, ByVal positionType As String) As LTODefalutDate
        Dim parameter = New With
        {.Operate = "DefaultDate",
         .PositionType = positionType,
         .SchoolYear = schoolYear
        }

        Return PostingDateExe.DefaultDateObj(parameter)  ' CommonExcute(Of LimitDate).GeneralList(SP, parameter) '

    End Function
    Private Shared Async Function DateSourceNewAsync(ByVal schoolYear As String, ByVal positionType As String) As Threading.Tasks.Task(Of LTODefalutDate)
        Dim parameter = New With
        {.Operate = "DefaultDate",
         .PositionType = positionType,
         .SchoolYear = schoolYear
        }

        Return Await PostingDateExeAsync.DefaultDate(parameter)  ' PublishPositionExe(Of PositionPublish).DefaultDate(parameter)  ' CommonExcute(Of LimitDate).GeneralList(SP, parameter) '
        ' Return PublishPositionExe(Of PositionPublish).DefaultDate(parameter)  ' CommonExcute(Of LimitDate).GeneralList(SP, parameter) '

    End Function
End Class
