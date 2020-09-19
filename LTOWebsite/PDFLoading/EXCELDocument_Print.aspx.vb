Imports AppOperate
Partial Class EXCELDocument_Print
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            Dim userID As String = HttpContext.Current.User.Identity.Name
            Dim reportName As String = Page.Request.QueryString("repName")
            Dim schoolyear As String = Page.Request.QueryString("SchoolYear")
            Dim pID As String = Page.Request.QueryString("pID")
            Dim CPNum As String = Page.Request.QueryString("CPNum")
            Dim sID As String = Page.Request.QueryString("sID")
            Dim AppType As String = Page.Request.QueryString("AppType")
            Dim Panel = Page.Request.QueryString("Panel")
            Dim openClose = Page.Request.QueryString("OpenClose")
            Dim SearchBy As String = Page.Request.QueryString("SearchBy")
            Dim SearchValue1 As String = Page.Request.QueryString("SearchValue1")
            Dim SearchValue2 As String = Page.Request.QueryString("SearchValue2")
            If SearchValue2 = "undefined" Then SearchValue2 = "0"
            Dim IncludeAll As String = Page.Request.QueryString("IncludeAll")
            Dim reportType As String = "NonBlank"
            Dim reportServer As String = WebConfigValue.ReportServer
            Dim reportPath As String = WebConfigValue.ReportPathWS
            Dim reportFormat As String = WebConfigValue.ReportFormat
            Dim th4Round As String = Page.Request.QueryString("th4Round")




            '  Dim rr As New ReportRender

            Dim myParas As List(Of ReportParameter) = New List(Of ReportParameter)()


            Select Case reportName

                Case "PositionList_Publish"
                    myParas.Add(ReportRenderC.GetParameter(0, "SchoolYear", schoolyear))
                    myParas.Add(ReportRenderC.GetParameter(1, "AppType", AppType))
                    myParas.Add(ReportRenderC.GetParameter(2, "Panel", Panel))
                    myParas.Add(ReportRenderC.GetParameter(3, "Status", openClose))
                    myParas.Add(ReportRenderC.GetParameter(4, "SearchBy", SearchBy))
                    myParas.Add(ReportRenderC.GetParameter(5, "SearchValue", SearchValue1))
                    myParas.Add(ReportRenderC.GetParameter(6, "SearchValue2", SearchValue2))
                    myParas.Add(ReportRenderC.GetParameter(7, "Round4th", th4Round))
                Case "PositionList_Interview"

                    myParas.Add(ReportRenderC.GetParameter(0, "SchoolYear", schoolyear))
                    myParas.Add(ReportRenderC.GetParameter(1, "AppType", AppType))
                    myParas.Add(ReportRenderC.GetParameter(2, "Panel", Panel))
                    myParas.Add(ReportRenderC.GetParameter(3, "Status", openClose))
                    myParas.Add(ReportRenderC.GetParameter(4, "SearchBy", SearchBy))
                    myParas.Add(ReportRenderC.GetParameter(5, "SearchValue", SearchValue1))
                    myParas.Add(ReportRenderC.GetParameter(6, "SearchValue2", SearchValue2))
                Case "PositionList_Hired"

                    myParas.Add(ReportRenderC.GetParameter(0, "SchoolYear", schoolyear))
                    myParas.Add(ReportRenderC.GetParameter(1, "AppType", AppType))
                    myParas.Add(ReportRenderC.GetParameter(2, "Panel", Panel))
                    myParas.Add(ReportRenderC.GetParameter(3, "Status", openClose))
                    myParas.Add(ReportRenderC.GetParameter(4, "SearchBy", SearchBy))
                    myParas.Add(ReportRenderC.GetParameter(5, "SearchValue", SearchValue1))
                    myParas.Add(ReportRenderC.GetParameter(6, "SearchValue2", SearchValue2))
                    myParas.Add(ReportRenderC.GetParameter(7, "Round4th", IncludeAll))
                Case "PositionList_Hired4thRound"

                    myParas.Add(ReportRenderC.GetParameter(0, "SchoolYear", schoolyear))
                    myParas.Add(ReportRenderC.GetParameter(1, "AppType", AppType))
                    myParas.Add(ReportRenderC.GetParameter(2, "Panel", Panel))
                    myParas.Add(ReportRenderC.GetParameter(3, "Status", openClose))
                    myParas.Add(ReportRenderC.GetParameter(4, "SearchBy", SearchBy))
                    myParas.Add(ReportRenderC.GetParameter(5, "SearchValue", SearchValue1))
                    myParas.Add(ReportRenderC.GetParameter(6, "SearchValue2", SearchValue2))
                    myParas.Add(ReportRenderC.GetParameter(7, "Round4th", "1")
                        )
                Case "ApplicantList_Interview"

                    myParas.Add(ReportRenderC.GetParameter(0, "UserID", userID))
                    myParas.Add(ReportRenderC.GetParameter(1, "SchoolYear", schoolyear))
                    myParas.Add(ReportRenderC.GetParameter(2, "PositionID", pID))
                    myParas.Add(ReportRenderC.GetParameter(3, "IncluedAll", IncludeAll))
                Case "InterviewList"

                    myParas.Add(ReportRenderC.GetParameter(0, "UserID", userID))
                    myParas.Add(ReportRenderC.GetParameter(1, "SchoolYear", schoolyear))
                    myParas.Add(ReportRenderC.GetParameter(2, "PositionID", pID))
                    myParas.Add(ReportRenderC.GetParameter(3, "IncludeAll", "No"))

                Case Else

                    myParas.Add(ReportRenderC.GetParameter(0, "UserID", userID))
                    myParas.Add(ReportRenderC.GetParameter(1, "SchoolYear", schoolyear))
                    myParas.Add(ReportRenderC.GetParameter(2, "CPNum", CPNum))
                    myParas.Add(ReportRenderC.GetParameter(3, "PositionID", pID))

            End Select

            Dim pdfReport() As Byte
            pdfReport = ReportRenderC.GetReportR2(reportName, "EXCEL", myParas)
            ReportRenderC.RenderDocument(pdfReport, reportName, "EXCEL")


            ' pdfReport = ReportRender.GetReportR2(reportServer, reportPath, reportName, "EXCEL", myPara)

            'ShowPDFreport(pdfReport, reportName, "EXCEL")

        End If
    End Sub
    'Private Function ReportRenderC.GetParameter(ByVal Seq As Integer, ByVal pName As String, ByVal pVAlue As String) As ReportParameter
    '    Dim para1 As ReportParameter = New ReportParameter()
    '    para1.ParaName = pName
    '    para1.ParaValue = pVAlue
    '    Return para1
    'End Function
    'Private Sub ShowPDFreport(ByVal _pdfReport As Byte(), ByVal _reportName As String, ByVal _reportFormat As String)
    '    Try
    '        If Not _pdfReport Is Nothing Then

    '            'Response.AppendHeader("content-disposition", "filename=" & CStr(ListBox1.SelectedItem.Text))
    '            HttpContext.Current.Response.AppendHeader("content-disposition", "filename=" & _reportName + ".xls") ' CStr(ListBox1.SelectedItem.Text))
    '            HttpContext.Current.Response.ContentType = getContentType(_reportFormat)
    '            ' output the actual document contents to the response output stream
    '            HttpContext.Current.Response.OutputStream.Write(_pdfReport, 0, _pdfReport.GetLength(0))
    '            ' end the response
    '            HttpContext.Current.Response.Flush()
    '            HttpContext.Current.Response.End()

    '        End If
    '    Catch ex As Exception

    '    End Try


    'End Sub
    'Private Function getContentType(ByVal _repFormat As String) As String

    '    '                    myParas.Add(ReportRenderC.GetParameter( 0, "SchoolYear", schoolyear)

    '    Dim rValue As String = ""
    '    Select Case _repFormat
    '        Case "PDF"
    '            rValue = "application/pdf"
    '        Case "EXCEL"
    '            rValue = "application/vnd.ms-excel"
    '        Case "IMAGE"
    '            rValue = "image/tiff"
    '    End Select
    '    Return rValue

    'End Function




End Class

