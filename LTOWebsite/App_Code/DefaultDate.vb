Imports AppOperate
Imports ClassLibrary
Imports Microsoft.VisualBasic

Public Class DefaultDate
    Public Shared Sub SetDate(ByVal schoolYear As String, ByVal positionType As String, ByRef startDate As Object, ByRef endDate As Object)

        'Dim myDate As New List(Of LimitDate)
        'myDate = DateSource(schoolYear, positionType)
        Dim myDate As New List(Of PositionPublish)
        myDate = DateSourceNew(schoolYear, positionType)

        If startDate.Value = "" Then startDate.Value = myDate(0).StartDate
        If positionType = "LTO" Then
            If endDate.Value = "" Then endDate.Value = myDate(0).EndDate
        End If

    End Sub


    Public Shared Sub SetDate(ByVal schoolYear As String, ByVal positionType As String, ByRef startDate As Object, ByRef endDate As Object, ByRef datePublish As Object, ByRef dateApplyStart As Object, ByRef dateDeadline As Object)
        'Dim myDate As New List(Of LimitDate)
        'myDate = DateSourceNew(schoolYear, positionType)

        Dim myDate As New List(Of PositionPublish)
        myDate = DateSourceNew(schoolYear, positionType)

        If startDate.Value = "" Then startDate.Value = myDate(0).StartDate
        If positionType = "LTO" Then
            If endDate.Value = "" Then endDate.Value = myDate(0).EndDate
        End If
        If datePublish.Value = "" Then datePublish.Value = myDate(0).DatePublish
        If dateApplyStart.Value = "" Then dateApplyStart.Value = myDate(0).DateApplyOpen
        If dateDeadline.Value = "" Then dateDeadline.Value = myDate(0).DateApplyClose
    End Sub
    Public Shared Sub SetDate(ByVal schoolYear As String, ByVal positionType As String, ByRef startDate As Object, ByRef endDate As Object, ByRef datePublish As Object, ByRef dateApplyStart As Object, ByRef dateDeadline As Object, ByRef hfStartDate As Object, ByRef hfEndate As Object)
        'Dim myDate As New List(Of LimitDate)
        'myDate = DateSourceNew(schoolYear, positionType)

        Dim myDate As New List(Of PositionPublish)
        myDate = DateSourceNew(schoolYear, positionType)

        If startDate.Value = "" Then startDate.Value = myDate(0).StartDate
        If positionType = "LTO" Then
            If endDate.Value = "" Then endDate.Value = myDate(0).EndDate
        End If
        hfStartDate.Value = myDate(0).StartDate
        hfEndate.Value = myDate(0).EndDate
        If datePublish.Value = "" Then datePublish.Value = myDate(0).DatePublish
        If dateApplyStart.Value = "" Then dateApplyStart.Value = myDate(0).DateApplyOpen
        If dateDeadline.Value = "" Then dateDeadline.Value = myDate(0).DateApplyClose
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
    Private Shared Function DateSourceNew(ByVal schoolYear As String, ByVal positionType As String) As List(Of PositionPublish)
        Dim parameter As New LimitDate()
        With parameter
            .Operate = "DefaultDate"
            .PositionType = positionType
            .SchoolYear = schoolYear
        End With
        Return PublishPositionExe.DefaultDate(parameter)  ' CommonExcute(Of LimitDate).GeneralList(SP, parameter) '

    End Function
End Class
