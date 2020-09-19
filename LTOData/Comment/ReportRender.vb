Imports System.Web
Imports System.Net
'Namespace TCDSB.Student.BIP
Imports System.Data
Imports System.Data.SqlClient
Namespace CommonTCDSB
    Public Class ReportRender
        Inherits System.Web.UI.Page

        Public Shared ReadOnly Property PDF() As String
            Get
                Return "&rs:Command=Render&rs:Format=PDF&rs:ClearSession=true&rc:Toolbar=false&rc:LinkTarget=_blank"
            End Get
        End Property
        Public Shared ReadOnly Property CSV() As String
            Get
                Return "&rs:Command=Render&rs:Format=CSV&rc:Toolbar=false&rc:LinkTarget=_blank"
            End Get
        End Property
        Public Shared ReadOnly Property EXCEL() As String
            Get
                Return "&rs:Command=Render&rs:Format=EXCEL&rc:Toolbar=false&rc:LinkTarget=_blank"
            End Get
        End Property
        Public Shared ReadOnly Property IMAGE() As String
            Get
                Return "&rs:Command=Render&rs:Format=IMAGE&rc:Toolbar=false&rc:LinkTarget=_blank"
            End Get
        End Property
        Public Shared ReadOnly Property HTML() As String
            Get
                Return "&rs:Command=Render&rs:Format=HTML4.0&rc:Toolbar=false&rc:LinkTarget=_blank"
            End Get
        End Property
        Public Shared ReadOnly Property XML() As String
            Get
                Return "&rs:Command=Render&rs:Format=XML&rc:Toolbar=false&rc:LinkTarget=_blank"
            End Get
        End Property
        Public Shared ReadOnly Property RS() As String
            Get
                Return "&rs:Command=Render&rc:LinkTarget=_blank"
            End Get
        End Property
        Public Shared Function Format(ByVal vType As String) As String
            Dim rValue As String
            Select Case vType
                Case "PDF1"
                    rValue = "&rs:Command=Render&rs:Format=PDF&rs:ClearSession=true&rc:Toolbar=false"
                Case "PDF"
                    rValue = "&rs:Command=Render&rs:Format=PDF&rs:ClearSession=true&rc:Toolbar=false&rc:LinkTarget=_blank"
                Case "PDFV"
                    rValue = "&rs:Command=Render&rs:Format=PDF&rs:ClearSession=true&rc:Toolbar=true&rc:LinkTarget=_blank"
                Case "CSV"
                    rValue = "&rs:Command=Render&rs:Format=CSV&rc:Toolbar=false&rc:LinkTarget=_blank"
                Case "EXCEL"
                    rValue = "&rs:Command=Render&rs:Format=EXCEL&rc:Toolbar=false&rc:LinkTarget=_blank"
                Case "IMAGE"
                    rValue = "&rs:Command=Render&rs:Format=IMAGE&rc:Toolbar=false&rc:LinkTarget=_blank"
                Case "HTML"
                    rValue = "&rs:Command=Render&rs:Format=HTML4.0&rc:Toolbar=false&rc:LinkTarget=_blank"
                Case "HTMLV"
                    rValue = "&rs:Command=Render&rs:Format=HTML4.0&rc:Toolbar=true&rc:LinkTarget=_blank"
                Case "XML"
                    rValue = "&rs:Command=Render&rs:Format=XML&rc:Toolbar=false&rc:LinkTarget=_blank"
                Case Else
                    rValue = "&rs:Command=Render&rs:Format=HTML4.0&rc:Toolbar=false&rc:LinkTarget=_blank"
            End Select
            Return rValue
        End Function

        Public Shared Sub setParameterArray(ByVal _ParaArray() As Object, ByVal X As Integer, ByVal _Name As String, ByVal _Value As String)
            Try
                _ParaArray(X) = New TCDSB.Student.Data.MyParameter ' TCDSB.Student.Student.MyParameter  'TCDSB.Student.Data.MyParameterRS '

                _ParaArray(X).pName = _Name
                _ParaArray(X).pValue = _Value
            Catch ex As Exception
                Dim exMsg As String = ex.Message
            End Try
        End Sub
        'Public Sub RedenerReport(ByVal _reportServer As String, ByVal _reportPath As String, ByVal _reportName As String, ByVal _reportFormat As String, ByRef _reportParameter() As Object)
        '    Try

        '        Dim RS As New ReportingWebService.ReportingService  ' tpaRS.ReportingService    '    Dim rs As New ReportingService
        '        ''user a generic account to access reports may 2 
        '        Dim cache As CredentialCache = New CredentialCache
        '        Dim accessUser As String = Webconfig.ReportUser '  TCDSB.Student.Security.accessKey("TCDSB\ReportingWebService\User") ' Webconfig.getRWSUser()
        '        Dim accessRWSPW As String = Webconfig.ReportPW ' TCDSB.Student.Security.accessKey("TCDSB\ReportingWebService\Password") ' Webconfig.getRWSPW()
        '        'Dim accessUser As String = TCDSB.Student.Security.accessKey("TCDSB\ReportingWebService\User") ' Webconfig.getRWSUser()
        '        'Dim accessRWSPW As String = TCDSB.Student.Security.accessKey("TCDSB\ReportingWebService\Password") ' Webconfig.getRWSPW()

        '        cache.Add(New Uri(RS.Url), "Negotiate", New NetworkCredential(accessUser, accessRWSPW, "cec"))
        '        RS.Credentials = cache

        '        Dim report As String = _reportPath + _reportName ' Global.ReportPath + "/" + ListBox1.SelectedItem.Text

        '        'RS.Credentials = System.Net.CredentialCache.DefaultCredentials

        '        'Render reports initilization
        '        Dim format As String = _reportFormat ' RadioButtonList1.SelectedItem.Text.ToUpper '"MHTML"
        '        Dim historyID As String = Nothing
        '        Dim devInfo As String = "<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>"

        '        Dim credentials As ReportingWebService.DataSourceCredentials() = Nothing
        '        Dim showHideToggle As String = Nothing
        '        Dim encoding As String = ""
        '        Dim mimeType As String = ""
        '        Dim warnings As ReportingWebService.Warning() = Nothing
        '        Dim reportHistoryParameters As ReportingWebService.ParameterValue() = Nothing
        '        Dim streamIDs As String() = Nothing
        '        Dim sh As New ReportingWebService.SessionHeader   'ServerInfoHeader  
        '        RS.SessionHeaderValue = sh  'ServerInfoHeaderValue = sh  


        '        ''''Prepare the reports parameters and passing values
        '        Dim forRendering As Boolean = True
        '        Dim values As ReportingWebService.ParameterValue() = Nothing

        '        Dim parameters As ReportingWebService.ReportParameter()
        '        parameters = RS.GetReportParameters(report, historyID, forRendering, values, credentials)
        '        Dim i As Integer
        '        Dim cnt As Integer = 0

        '        If parameters.GetUpperBound(0) > 0 Then
        '            For i = 0 To parameters.GetUpperBound(0)
        '                If parameters(i).PromptUser = True Then
        '                    cnt = cnt + 1
        '                End If
        '            Next
        '        End If

        '        Dim rptParameters() As ReportingWebService.ParameterValue
        '        ReDim rptParameters(cnt - 1)

        '        If parameters.GetUpperBound(0) > 0 Then
        '            For i = 0 To parameters.GetUpperBound(0)
        '                If parameters(i).PromptUser = True Then
        '                    ''Check dependency
        '                    rptParameters(i) = New ReportingWebService.ParameterValue
        '                    rptParameters(i).Name = parameters(i).Name
        '                    rptParameters(i).Value = getParameterValue(parameters(i).Name, _reportParameter) 'RecurseThroughControlHierarchy(PlaceHolder1, "txtP" + i.ToString)
        '                End If
        '            Next
        '        Else
        '            rptParameters = Nothing
        '        End If



        '        'Render the report and return back to end user

        '        Dim result() As Byte

        '        result = RS.Render(report, format, historyID, devInfo, rptParameters, credentials, showHideToggle, encoding, mimeType, reportHistoryParameters, warnings, streamIDs)

        '        sh.SessionId = RS.SessionHeaderValue.SessionId


        '        'Response.AppendHeader("content-disposition", "filename=" & CStr(ListBox1.SelectedItem.Text))
        '        HttpContext.Current.Response.AppendHeader("content-disposition", "filename=" & _reportName + "." + _reportFormat) ' CStr(ListBox1.SelectedItem.Text))

        '        ' set the content type for the Response to that of the
        '        ' document to display.  For example. "application/msword"
        '        Select Case format
        '            Case "PDF"
        '                HttpContext.Current.Response.ContentType = "application/pdf"
        '            Case "EXCEL"
        '                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
        '            Case "IMAGE"
        '                HttpContext.Current.Response.ContentType = "image/tiff"
        '        End Select


        '        ' output the actual document contents to the response output stream
        '        HttpContext.Current.Response.OutputStream.Write(result, 0, result.GetLength(0))

        '        ' end the response
        '        HttpContext.Current.Response.End()


        '        'Dim name As New DEV01_ReportingService.Property

        '        'name.Name = "Name"

        '        'Dim description As New DEV01_ReportingService.Property
        '        'description.Name = "Description"

        '        'Dim properties(1) As DEV01_ReportingService.Property
        '        'properties(0) = name
        '        'properties(1) = description

        '        'Try
        '        '    Dim returnProperties As DEV01_ReportingService.Property() = RS.GetProperties(report, properties)

        '        '    Dim p As DEV01_ReportingService.Property
        '        '    For Each p In returnProperties
        '        '        Dim _showValue As String = p.Name + ": " + p.Value
        '        '        Console.WriteLine((p.Name + ": " + p.Value))
        '        '    Next p

        '        'Catch e As Exception
        '        '    Console.WriteLine(e.Message)
        '        'End Try

        '    Catch ex As Exception
        '        '   Console.WriteLine(ex.Message)
        '        'Dim showmsg As String = ex.Message
        '    End Try


        'End Sub
        'Public Sub RedenerReportandSave(ByVal schoolyear As String, ByVal schoolcode As String, ByVal goalGrade As String, ByVal goalFocus As String, ByVal publishDate As String, ByVal docType As String, ByVal userid As String, _
        '                                ByVal _reportServer As String, ByVal _reportPath As String, ByVal _reportName As String, ByVal _reportFormat As String, ByRef _reportParameter() As Object)
        '    Try

        '        Dim RS As New ReportingWebService.ReportingService  ' tpaRS.ReportingService    '    Dim rs As New ReportingService
        '        ''user a generic account to access reports may 2 
        '        Dim cache As CredentialCache = New CredentialCache
        '        Dim accessUser As String = Webconfig.ReportUser '  TCDSB.Student.Security.accessKey("TCDSB\ReportingWebService\User") ' Webconfig.getRWSUser()
        '        Dim accessRWSPW As String = Webconfig.ReportPW ' TCDSB.Student.Security.accessKey("TCDSB\ReportingWebService\Password") ' Webconfig.getRWSPW()
        '        'Dim accessUser As String = TCDSB.Student.Security.accessKey("TCDSB\ReportingWebService\User") ' Webconfig.getRWSUser()
        '        'Dim accessRWSPW As String = TCDSB.Student.Security.accessKey("TCDSB\ReportingWebService\Password") ' Webconfig.getRWSPW()

        '        cache.Add(New Uri(RS.Url), "Negotiate", New NetworkCredential(accessUser, accessRWSPW, "cec"))
        '        RS.Credentials = cache

        '        Dim report As String = _reportPath + _reportName ' Global.ReportPath + "/" + ListBox1.SelectedItem.Text

        '        'RS.Credentials = System.Net.CredentialCache.DefaultCredentials

        '        'Render reports initilization
        '        Dim format As String = _reportFormat ' RadioButtonList1.SelectedItem.Text.ToUpper '"MHTML"
        '        Dim historyID As String = Nothing
        '        Dim devInfo As String = "<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>"

        '        Dim credentials As ReportingWebService.DataSourceCredentials() = Nothing
        '        Dim showHideToggle As String = Nothing
        '        Dim encoding As String = ""
        '        Dim mimeType As String = ""
        '        Dim warnings As ReportingWebService.Warning() = Nothing
        '        Dim reportHistoryParameters As ReportingWebService.ParameterValue() = Nothing
        '        Dim streamIDs As String() = Nothing
        '        Dim sh As New ReportingWebService.SessionHeader   'ServerInfoHeader  
        '        RS.SessionHeaderValue = sh  'ServerInfoHeaderValue = sh  


        '        ''''Prepare the reports parameters and passing values
        '        Dim forRendering As Boolean = True
        '        Dim values As ReportingWebService.ParameterValue() = Nothing

        '        Dim parameters As ReportingWebService.ReportParameter()
        '        parameters = RS.GetReportParameters(report, historyID, forRendering, values, credentials)
        '        Dim i As Integer
        '        Dim cnt As Integer = 0

        '        If parameters.GetUpperBound(0) > 0 Then
        '            For i = 0 To parameters.GetUpperBound(0)
        '                If parameters(i).PromptUser = True Then
        '                    cnt = cnt + 1
        '                End If
        '            Next
        '        End If

        '        Dim rptParameters() As ReportingWebService.ParameterValue
        '        ReDim rptParameters(cnt - 1)

        '        If parameters.GetUpperBound(0) > 0 Then
        '            For i = 0 To parameters.GetUpperBound(0)
        '                If parameters(i).PromptUser = True Then
        '                    ''Check dependency
        '                    rptParameters(i) = New ReportingWebService.ParameterValue
        '                    rptParameters(i).Name = parameters(i).Name
        '                    rptParameters(i).Value = getParameterValue(parameters(i).Name, _reportParameter) 'RecurseThroughControlHierarchy(PlaceHolder1, "txtP" + i.ToString)
        '                End If
        '            Next
        '        Else
        '            rptParameters = Nothing
        '        End If



        '        'Render the report and return back to end user

        '        Dim result() As Byte

        '        result = RS.Render(report, format, historyID, devInfo, rptParameters, credentials, showHideToggle, encoding, mimeType, reportHistoryParameters, warnings, streamIDs)

        '        SavePublishedPDFFile(result, schoolyear, schoolcode, goalGrade, goalFocus, publishDate, userid, docType)
        '        sh.SessionId = RS.SessionHeaderValue.SessionId


        '        'Response.AppendHeader("content-disposition", "filename=" & CStr(ListBox1.SelectedItem.Text))
        '        HttpContext.Current.Response.AppendHeader("content-disposition", "filename=" & _reportName + "." + _reportFormat) ' CStr(ListBox1.SelectedItem.Text))

        '        ' set the content type for the Response to that of the
        '        ' document to display.  For example. "application/msword"
        '        Select Case format
        '            Case "PDF"
        '                HttpContext.Current.Response.ContentType = "application/pdf"
        '            Case "EXCEL"
        '                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
        '            Case "IMAGE"
        '                HttpContext.Current.Response.ContentType = "image/tiff"
        '        End Select


        '        ' output the actual document contents to the response output stream
        '        HttpContext.Current.Response.OutputStream.Write(result, 0, result.GetLength(0))

        '        ' end the response
        '        HttpContext.Current.Response.End()


        '        'Dim name As New DEV01_ReportingService.Property

        '        'name.Name = "Name"

        '        'Dim description As New DEV01_ReportingService.Property
        '        'description.Name = "Description"

        '        'Dim properties(1) As DEV01_ReportingService.Property
        '        'properties(0) = name
        '        'properties(1) = description

        '        'Try
        '        '    Dim returnProperties As DEV01_ReportingService.Property() = RS.GetProperties(report, properties)

        '        '    Dim p As DEV01_ReportingService.Property
        '        '    For Each p In returnProperties
        '        '        Dim _showValue As String = p.Name + ": " + p.Value
        '        '        Console.WriteLine((p.Name + ": " + p.Value))
        '        '    Next p

        '        'Catch e As Exception
        '        '    Console.WriteLine(e.Message)
        '        'End Try

        '    Catch ex As Exception
        '        '   Console.WriteLine(ex.Message)
        '        'Dim showmsg As String = ex.Message
        '    End Try


        'End Sub
        'Public Sub SavePublishedPDFFile(ByVal _result() As Byte, ByVal schoolyear As String, ByVal schoolcode As String, ByVal goalGrade As String, ByVal goalFocus As String, ByVal publishDate As String, ByVal userid As String, ByVal docType As String)
        '    Dim myCon As New SqlConnection(SetupData.myDBConStr)
        '    Dim myCom As New SqlCommand("dbo.tcdsb_BIP_SP_PublishSLIP", myCon)
        '    myCom.CommandType = CommandType.StoredProcedure
        '    Try
        '        Dim Para1 As New SqlParameter("@UserID", SqlDbType.VarChar, 30)
        '        Dim Para2 As New SqlParameter("@SchoolYear", SqlDbType.VarChar, 8)
        '        Dim Para3 As New SqlParameter("@SchoolCode", SqlDbType.VarChar, 8)
        '        Dim Para4 As New SqlParameter("@GoalGrade", SqlDbType.VarChar, 10)
        '        Dim Para5 As New SqlParameter("@GoalFocus", SqlDbType.VarChar, 20)
        '        Dim Para6 As New SqlParameter("@PublishDate", SqlDbType.VarChar, 10)
        '        Dim Para7 As New SqlParameter("@FileTitle", SqlDbType.VarChar, 200)
        '        Dim Para8 As New SqlParameter("@DocType", SqlDbType.VarChar, 10)
        '        Dim Para9 As New SqlParameter("@PDFResult", SqlDbType.Image)

        '        Para1.Value = userid
        '        Para2.Value = schoolyear
        '        Para3.Value = schoolcode
        '        Para4.Value = goalGrade
        '        Para5.Value = goalFocus
        '        Para6.Value = publishDate
        '        Para7.Value = schoolyear + " " + schoolcode + " SLIP Published" ' ("  ' + " - " + goalFocus + " " + goalGrade + ") at " + publishDate
        '        Para8.Value = docType
        '        Para9.Value = _result

        '        myCom.Parameters.Add(Para1)
        '        myCom.Parameters.Add(Para2)
        '        myCom.Parameters.Add(Para3)
        '        myCom.Parameters.Add(Para4)
        '        myCom.Parameters.Add(Para5)
        '        myCom.Parameters.Add(Para6)
        '        myCom.Parameters.Add(Para7)
        '        myCom.Parameters.Add(Para8)
        '        myCom.Parameters.Add(Para9)

        '        myCon.Open()
        '        myCom.ExecuteNonQuery()

        '    Catch ex As Exception

        '    Finally
        '        myCon.Close()
        '    End Try
        'End Sub

        'Private Function getParameterValue(ByVal rpName As String, ByVal reportParameter() As TCDSB.Student.Data.MyParameterRS) As String
        '    Dim i As Integer
        '    For i = 0 To reportParameter.GetUpperBound(0)
        '        If reportParameter(i).pName = rpName Then
        '            Return reportParameter(i).pValue
        '        End If
        '    Next
        'End Function
        'Public Shared Sub setParameterArrayRS(ByVal _ParaArray() As TCDSB.Student.Data.MyParameterRS, ByVal X As Integer, ByVal _Name As String, ByVal _Value As String)
        '    Try
        '        _ParaArray(X) = New TCDSB.Student.Data.MyParameterRS

        '        _ParaArray(X).pName = _Name
        '        _ParaArray(X).pValue = _Value
        '    Catch ex As Exception
        '        Dim exMsg As String = ex.Message
        '    End Try
        'End Sub
        'Public Sub RedenerReport(ByVal _reportServer As String, ByVal _reportPath As String, ByVal _reportName As String, ByVal _reportFormat As String, ByRef _reportParameter() As TCDSB.Student.Data.MyParameterRS)
        '    Try

        '        Dim RS As New ReportingWebService.ReportingService  ' tpaRS.ReportingService    '    Dim rs As New ReportingService
        '        ''user a generic account to access reports
        '        Dim cache As CredentialCache = New CredentialCache
        '        Dim accessUser As String = Webconfig.ReportUser '  TCDSB.Student.Security.accessKey("TCDSB\ReportingWebService\User") ' Webconfig.getRWSUser()
        '        Dim accessRWSPW As String = Webconfig.ReportPW ' TCDSB.Student.Security.accessKey("TCDSB\ReportingWebService\Password") ' Webconfig.getRWSPW()
        '        cache.Add(New Uri(RS.Url), "Negotiate", New NetworkCredential(accessUser, accessRWSPW, "cec"))
        '        RS.Credentials = cache

        '        Dim report As String = _reportPath + _reportName ' Global.ReportPath + "/" + ListBox1.SelectedItem.Text

        '        'RS.Credentials = System.Net.CredentialCache.DefaultCredentials

        '        '''Render reports initilization
        '        Dim format As String = _reportFormat ' RadioButtonList1.SelectedItem.Text.ToUpper '"MHTML"
        '        Dim historyID As String = Nothing
        '        Dim devInfo As String = "<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>"

        '        Dim credentials As ReportingWebService.DataSourceCredentials() = Nothing
        '        Dim showHideToggle As String = Nothing
        '        Dim encoding As String
        '        Dim mimeType As String
        '        Dim warnings As ReportingWebService.Warning() = Nothing
        '        Dim reportHistoryParameters As ReportingWebService.ParameterValue() = Nothing
        '        Dim streamIDs As String() = Nothing
        '        Dim sh As New ReportingWebService.SessionHeader
        '        RS.SessionHeaderValue = sh


        '        ''''Prepare the reports parameters and passing values
        '        Dim forRendering As Boolean = True
        '        Dim values As ReportingWebService.ParameterValue() = Nothing

        '        Dim parameters As ReportingWebService.ReportParameter()
        '        parameters = RS.GetReportParameters(report, historyID, forRendering, values, credentials)
        '        Dim i As Integer
        '        Dim cnt As Integer = 0

        '        If parameters.GetUpperBound(0) > 0 Then
        '            For i = 0 To parameters.GetUpperBound(0)
        '                If parameters(i).PromptUser = True Then
        '                    cnt = cnt + 1
        '                End If
        '            Next
        '        End If

        '        Dim rptParameters() As ReportingWebService.ParameterValue
        '        ReDim rptParameters(cnt - 1)

        '        If parameters.GetUpperBound(0) > 0 Then
        '            For i = 0 To parameters.GetUpperBound(0)
        '                If parameters(i).PromptUser = True Then
        '                    ''Check dependency
        '                    rptParameters(i) = New ReportingWebService.ParameterValue
        '                    rptParameters(i).Name = parameters(i).Name
        '                    rptParameters(i).Value = getParameterValue(parameters(i).Name, _reportParameter) 'RecurseThroughControlHierarchy(PlaceHolder1, "txtP" + i.ToString)
        '                End If
        '            Next
        '        Else
        '            rptParameters = Nothing
        '        End If



        '        '''Render the report and return back to end user

        '        Dim result() As Byte

        '        result = RS.Render(report, format, historyID, devInfo, rptParameters, _
        '            credentials, showHideToggle, encoding, mimeType, reportHistoryParameters, warnings, streamIDs)

        '        sh.SessionId = RS.SessionHeaderValue.SessionId


        '        'Response.AppendHeader("content-disposition", "filename=" & CStr(ListBox1.SelectedItem.Text))

        '        context.Current.Response.AppendHeader("content-disposition", "filename=" & _reportName + "." + _reportFormat) ' CStr(ListBox1.SelectedItem.Text))

        '        ' set the content type for the Response to that of the
        '        ' document to display.  For example. "application/msword"
        '        Select Case format
        '            Case "PDF"
        '                context.Current.Response.ContentType = "application/pdf"
        '            Case "EXCEL"
        '                context.Current.Response.ContentType = "application/vnd.ms-excel"
        '            Case "IMAGE"
        '                context.Current.Response.ContentType = "image/tiff"
        '        End Select


        '        ' output the actual document contents to the response output stream
        '        context.Current.Response.OutputStream.Write(result, 0, result.GetLength(0))

        '        ' end the response
        '        context.Current.Response.End()


        '        'Dim name As New DEV01_ReportingService.Property

        '        'name.Name = "Name"

        '        'Dim description As New DEV01_ReportingService.Property
        '        'description.Name = "Description"

        '        'Dim properties(1) As DEV01_ReportingService.Property
        '        'properties(0) = name
        '        'properties(1) = description

        '        'Try
        '        '    Dim returnProperties As DEV01_ReportingService.Property() = RS.GetProperties(report, properties)

        '        '    Dim p As DEV01_ReportingService.Property
        '        '    For Each p In returnProperties
        '        '        Dim _showValue As String = p.Name + ": " + p.Value
        '        '        Console.WriteLine((p.Name + ": " + p.Value))
        '        '    Next p

        '        'Catch e As Exception
        '        '    Console.WriteLine(e.Message)
        '        'End Try

        '    Catch ex As Exception
        '        '   Console.WriteLine(ex.Message)
        '        'Dim showmsg As String = ex.Message
        '    End Try


        'End Sub


        'Public Shared Function GetReport(ByVal _reportServer As String, _
        '                                 ByVal _reportPath As String, _
        '                                 ByVal _reportName As String, _
        '                                 ByVal _reportFormat As String, _
        '                                 ByRef _reportParameter() As Object) As Byte()
        '    Dim result() As Byte

        '    Try

        '        Dim RS As New ReportingWebService.ReportingService2005 ' .ReportingService  ' tpaRS.ReportingService    '    Dim rs As New ReportingService
        '        ''user a generic account to access reports may 2 
        '        Dim cache As CredentialCache = New CredentialCache
        '        Dim accessUser As String = Webconfig.ReportUser '  
        '        Dim accessRWSPW As String = Webconfig.ReportPW ' 

        '        cache.Add(New Uri(RS.Url), "Negotiate", New NetworkCredential(accessUser, accessRWSPW, "cec"))
        '        RS.Credentials = cache

        '        Dim report As String = _reportPath + _reportName ' Global.ReportPath + "/" + ListBox1.SelectedItem.Text

        '        'RS.Credentials = System.Net.CredentialCache.DefaultCredentials

        '        'Render reports initilization
        '        Dim format As String = _reportFormat ' RadioButtonList1.SelectedItem.Text.ToUpper '"MHTML"
        '        Dim historyID As String = Nothing
        '        Dim devInfo As String = "<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>"

        '        Dim credentials As ReportingWebService.DataSourceCredentials() = Nothing
        '        Dim showHideToggle As String = Nothing
        '        Dim encoding As String = ""
        '        Dim mimeType As String = ""
        '        Dim warnings As ReportingWebService.Warning() = Nothing
        '        Dim reportHistoryParameters As ReportingWebService.ParameterValue() = Nothing
        '        Dim streamIDs As String() = Nothing
        '        Dim sh As New ReportingWebService.ServerInfoHeader '.ServerInfoHeader .SessionHeader   'ServerInfoHeader  
        '        RS.ServerInfoHeaderValue = sh ' .SessionHeaderValue = sh  'ServerInfoHeaderValue = sh  


        '        ''''Prepare the reports parameters and passing values
        '        Dim forRendering As Boolean = True
        '        Dim values As ReportingWebService.ParameterValue() = Nothing

        '        Dim parameters As ReportingWebService.ReportParameter()
        '        parameters = RS.GetReportParameters(report, historyID, forRendering, values, credentials)
        '        Dim i As Integer = 0
        '        Dim cnt As Integer = parameters.Length()


        '         Dim rptParameters() As ReportingWebService.ParameterValue
        '        ReDim rptParameters(cnt - 1)

        '        Dim para As TCDSB.Student.Data.MyParameter
        '        For Each para In _reportParameter
        '            rptParameters(i) = New ReportingWebService.ParameterValue
        '            rptParameters(i).Name = para.pName
        '            rptParameters(i).Value = para.pValue
        '            i = i + 1
        '        Next

        '        '   result = RS.Render(report, format, historyID, devInfo, rptParameters, credentials, showHideToggle, encoding, mimeType, reportHistoryParameters, warnings, streamIDs)



        '        Return result




        '    Catch ex As Exception
        '        Return Nothing
        '        '   Console.WriteLine(ex.Message)
        '        'Dim showmsg As String = ex.Message
        '    End Try


        'End Function
        Public Shared Function GetReportR2(ByVal _reportServer As String, _
                                     ByVal _reportPath As String, _
                                     ByVal _reportName As String, _
                                     ByVal _reportFormat As String, _
                                     ByRef _reportParameter() As Object) As Byte()
            Dim result() As Byte

            Try

                Dim RS As New ReportingWebServiceR2.ReportExecutionService '  .ReportingService2005 ' .ReportingService  ' tpaRS.ReportingService    '    Dim rs As New ReportingService
                ''user a generic account to access reports may 2 
                Dim cache As CredentialCache = New CredentialCache
                Dim accessUser As String = Webconfig.ReportUser '  
                Dim accessRWSPW As String = Webconfig.ReportPW ' 
                Dim accessDomain As String = Webconfig.getValuebyKey("Domain")
                RS.Credentials = New System.Net.NetworkCredential(accessUser, accessRWSPW, accessDomain)

                '  cache.Add(New Uri(RS.Url), "Negotiate", New NetworkCredential(accessUser, accessRWSPW, "cec"))
                '  RS.Credentials = cache

                Dim report As String = _reportPath + _reportName ' Global.ReportPath + "/" + ListBox1.SelectedItem.Text

                'RS.Credentials = System.Net.CredentialCache.DefaultCredentials

                'Render reports initilization
                Dim format As String = _reportFormat ' RadioButtonList1.SelectedItem.Text.ToUpper '"MHTML"
                Dim historyID As String = Nothing
                Dim devInfo As String = "<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>"

                Dim credentials As ReportingWebServiceR2.DataSourceCredentials() = Nothing
                Dim showHideToggle As String = Nothing
                Dim encoding As String = ""
                Dim mimeType As String = ""
                Dim warnings As ReportingWebServiceR2.Warning() = Nothing
                Dim reportHistoryParameters As ReportingWebServiceR2.ParameterValue() = Nothing
                Dim streamIDs As String() = Nothing
                Dim sh As New ReportingWebServiceR2.ServerInfoHeader '.ServerInfoHeader .SessionHeader   'ServerInfoHeader  
                RS.ServerInfoHeaderValue = sh ' .SessionHeaderValue = sh  'ServerInfoHeaderValue = sh  


                ''''Prepare the reports parameters and passing values
                Dim forRendering As Boolean = True
                Dim values As ReportingWebServiceR2.ParameterValue() = Nothing

                '  Dim parameters As ReportingWebServiceR2.ReportParameter()
                '  parameters = RS.GetReportParameters(report, historyID, forRendering, values, credentials)
                Dim i As Integer = 0
                Dim cnt As Integer = _reportParameter.Length '  parameters.Length()


                Dim rptParameters() As ReportingWebServiceR2.ParameterValue
                ReDim rptParameters(cnt - 1)

                Dim para As TCDSB.Student.Data.MyParameter
                For Each para In _reportParameter
                    rptParameters(i) = New ReportingWebServiceR2.ParameterValue
                    rptParameters(i).Name = para.pName
                    rptParameters(i).Value = para.pValue
                    i = i + 1
                Next

                Dim execInfo As New ReportingWebServiceR2.ExecutionInfo
                Dim execHeader As New ReportingWebServiceR2.ExecutionHeader()
                Dim SessionId As String
                Dim extension As String = ""

                execInfo = RS.LoadReport(report, historyID)

                RS.SetExecutionParameters(rptParameters, "en-us")

                SessionId = RS.ExecutionHeaderValue.ExecutionID
                Console.WriteLine("SessionID: {0}", RS.ExecutionHeaderValue.ExecutionID)

                result = RS.Render(_reportFormat, devInfo, extension, encoding, mimeType, warnings, streamIDs)

                '     result = RS.Render(report, format, historyID, devInfo, rptParameters, credentials, showHideToggle, encoding, mimeType, reportHistoryParameters, warnings, streamIDs)

                Return result

            Catch ex As Exception
                Return Nothing
                '   Console.WriteLine(ex.Message)
                'Dim showmsg As String = ex.Message
            End Try


        End Function


    End Class
End Namespace
 