'Imports System.Data
'Imports System.Data.SqlClient
'Imports TCDSB.Student

Imports AppOperate
Partial Class PDFDocument_Print
        Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            Dim userID As String = HttpContext.Current.User.Identity.Name
            Dim reportName As String = Page.Request.QueryString("repName")
            Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
            Dim pID As String = Page.Request.QueryString("pID")
            Dim CPNum As String = Page.Request.QueryString("CPNum") ' "Question"
            Dim sID As String = Page.Request.QueryString("sID")
            Dim postingNo As String = Page.Request.QueryString("pNo")
            Dim postCycle As String = Page.Request.QueryString("cID")
            Dim reportType As String = "NonBlank"
            Dim reportServer As String = WebConfigValue.ReportServer
            Dim reportPath As String = WebConfigValue.ReportPathWS
            Dim reportFormat As String = WebConfigValue.ReportFormat



            Dim myParas As List(Of ReportParameter) = New List(Of ReportParameter)()


            Select Case reportName

                Case "PostSummary_Interview", "PostSummary_Applicant", "PostSummary_All", "PostSummary_AllRound"

                    myParas.Add(ReportRenderC.GetParameter(0, "UserID", userID))
                    myParas.Add(ReportRenderC.GetParameter(1, "SchoolYear", schoolyear))
                    myParas.Add(ReportRenderC.GetParameter(2, "PositionID", pID))
                    myParas.Add(ReportRenderC.GetParameter(3, "PostingNo", postingNo))
                    myParas.Add(ReportRenderC.GetParameter(4, "PostCycle", postCycle))

                Case "InterviewPackage"

                    myParas.Add(ReportRenderC.GetParameter(0, "UserID", userID))
                    myParas.Add(ReportRenderC.GetParameter(1, "SchoolYear", schoolyear))
                    myParas.Add(ReportRenderC.GetParameter(2, "CPNum", CPNum))
                    myParas.Add(ReportRenderC.GetParameter(3, "PositionID", pID))


                Case "AppraisalPackage"

                    myParas.Add(ReportRenderC.GetParameter(0, "UserID", userID))
                    myParas.Add(ReportRenderC.GetParameter(1, "SchoolYear", schoolyear))
                    myParas.Add(ReportRenderC.GetParameter(2, "CPNum", CPNum))
                    myParas.Add(ReportRenderC.GetParameter(3, "SessionID", sID))
                Case "HRPendingComments"

                    myParas.Add(ReportRenderC.GetParameter(0, "UserID", userID))
                    myParas.Add(ReportRenderC.GetParameter(1, "SchoolYear", schoolyear))

                Case Else

                    myParas.Add(ReportRenderC.GetParameter(0, "UserID", userID))
                    myParas.Add(ReportRenderC.GetParameter(1, "SchoolYear", schoolyear))
                    myParas.Add(ReportRenderC.GetParameter(2, "CPNum", CPNum))
                    myParas.Add(ReportRenderC.GetParameter(3, "PositionID", pID))

            End Select

            Dim pdfReport() As Byte
            pdfReport = ReportRenderC.GetReportR2(reportName, "PDF", myParas)
            ReportRenderC.RenderDocument(pdfReport, reportName, "PDF")

            '  pdfReport = ReportRenderC.GetReportR2(reportServer, reportPath, reportName, "PDF", myParas)
            ' ShowPDFreport(pdfReport, reportName, "PDF")
        End If
    End Sub

    'Private Sub ShowPDFreport(ByVal _pdfReport As Byte(), ByVal _reportName As String, ByVal _reportFormat As String)
    '        Try
    '            If Not _pdfReport Is Nothing Then

    '                'Response.AppendHeader("content-disposition", "filename=" & CStr(ListBox1.SelectedItem.Text))
    '                HttpContext.Current.Response.AppendHeader("content-disposition", "filename=" & _reportName + "." + _reportFormat) ' CStr(ListBox1.SelectedItem.Text))
    '                HttpContext.Current.Response.ContentType = getContentType(_reportFormat)
    '                ' output the actual document contents to the response output stream
    '                HttpContext.Current.Response.OutputStream.Write(_pdfReport, 0, _pdfReport.GetLength(0))
    '                ' end the response
    '                HttpContext.Current.Response.End()
    '            End If
    '        Catch ex As Exception

    '        End Try


    '    End Sub
    '    Private Function getContentType(ByVal _repFormat As String) As String
    '        Dim rValue As String = ""
    '        Select Case _repFormat
    '            Case "PDF"
    '                rValue = "application/pdf"
    '            Case "EXCEL"
    '                rValue = "application/vnd.ms-excel"
    '            Case "IMAGE"
    '                rValue = "image/tiff"
    '        End Select
    '        Return rValue

    '    End Function



End Class

 