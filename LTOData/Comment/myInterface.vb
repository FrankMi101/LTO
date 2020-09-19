
Module myInterface

    Interface IAnswer
        Sub Responses2()
        Sub Responses2(ByVal UserID As String, ByVal school_year As String, ByVal phase As String, ByVal questionID As String, ByVal workingItem As String, ByVal goalareaID As String, ByVal answerType As String)
        Sub Responses2(ByVal UserID As String, ByVal school_year As String, ByVal phase As String, ByVal questionID As String, ByVal workingItem As String, ByVal goalareaID As String, ByVal answerType As String, ByVal itemType As String)
        Property ResponsesAnswer(ByVal Operate As String, ByVal Own_code As String, ByVal GQ_type As String, ByVal GQ_code As String, ByVal Res_Type As String) As String

        '    Function getResponse(ByVal Operate As String, ByVal Own_code As String, ByVal GQ_type As String, ByVal GQ_code As String, ByVal Res_Type As String) As String
        '    Function saveResponse(ByVal Operate As String, ByVal Own_code As String, ByVal GQ_type As String, ByVal GQ_code As String, ByVal Res_Type As String, ByVal Val As String) As String
    End Interface

    Interface IValue
        Sub Render()
    End Interface
End Module

