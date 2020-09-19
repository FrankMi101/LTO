Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports TCDSB.Student
<TestClass()> Public Class DateFCTest

    <TestMethod()> Public Sub FormatTest()


        Dim vDate As Date = "2013-05-25"
        Dim vFormat As String = "YYYYMMDD"  ' "DDMMYYYYY" '"MMDDYYYY"
        Dim expected As String = "2013/05/10" ' String.Empty ' TODO: Initialize to an appropriate value

        Dim actual As String
        Try
            actual = DateFC.Format(vDate, vFormat)
            Assert.AreEqual(expected, actual, "test Class Response TypeA save ok")
        Catch ex As AssertFailedException
            Trace.WriteLine(ex.Message)
        End Try

        vFormat = "DDMMYYYYY" '"MMDDYYYY"
        expected = "25/05/2013" ' String.Empty ' TODO: Initialize to an appropriate value

        Try
            actual = DateFC.Format(vDate, vFormat)
            Assert.AreEqual(expected, actual, "test Class Response TypeA save ok")
        Catch ex As AssertFailedException
            Trace.WriteLine(ex.Message)
        End Try

        vFormat = "MMDDYYYY"
        expected = "05/25/2013" ' String.Empty ' TODO: Initialize to an appropriate value

        Try
            actual = DateFC.Format(vDate, vFormat)
            Assert.AreEqual(expected, actual, "test Class Response TypeA save ok")
        Catch ex As AssertFailedException
            Trace.WriteLine(ex.Message)
        End Try


    End Sub

End Class
<TestClass()> _
Public Class SchoolYearDefaultDateTest
    <TestMethod()> _
    Public Sub StartDateTest()
        Dim AppType As String = "LTO"
        Dim schoolyear As String = "20132014"

        Dim expected As String = "2013/09/02" '  if Test date later than Steptmber 2 then    expected = DateFC.Format(Date.Now, "YYYYMMDD")
        Dim actual As String
        Try
            actual = SchoolYearDefaultDate.StartDate(AppType, schoolyear)
            Assert.AreEqual(expected, actual, "test Start Date from database ok.")
        Catch ex As AssertFailedException
            Trace.WriteLine(ex.Message)
        End Try
        '  Assert.Inconclusive("Verify the correctness of this test method.")

        AppType = "POP"
        expected = "2013/09/01" ' if Test date later than Steptmber 2 then    expected = DateFC.Format(Date.Now, "YYYYMMDD")
        Try
            actual = SchoolYearDefaultDate.StartDate(AppType, schoolyear)
            Assert.AreEqual(expected, actual, "test Start Date from database ok.")
        Catch ex As AssertFailedException
            Trace.WriteLine(ex.Message)
        End Try
        '  Assert.Inconclusive("Verify the correctness of this test method.")

        '  



    End Sub
    <TestMethod()> _
    Public Sub EndDateTest()

        Dim AppType As String = "LTO"
        Dim schoolyear As String = "20132014"

        Dim expected As String = "2014/06/25" '  if Test date later than Steptmber 2 then    expected = DateFC.Format(Date.Now, "YYYYMMDD")
        Dim actual As String
        Try
            actual = SchoolYearDefaultDate.EndDate(AppType, schoolyear)
            Assert.AreEqual(expected, actual, "test End Date from database ok.")
        Catch ex As AssertFailedException
            Trace.WriteLine(ex.Message)
        End Try
        '  Assert.Inconclusive("Verify the correctness of this test method.")

        AppType = "POP"
        expected = "" ' if Test date later than Steptmber 2 then    expected = DateFC.Format(Date.Now, "YYYYMMDD")
        Try
            actual = SchoolYearDefaultDate.StartDate(AppType, schoolyear)
            Assert.AreEqual(expected, actual, "test End Date from database ok.")
        Catch ex As AssertFailedException
            Trace.WriteLine(ex.Message)
        End Try
        '  Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    <TestMethod()> _
    Public Sub PublishDateTest()

        Dim AppType As String = "LTO"
        Dim schoolyear As String = "20132014"

        Dim expected As String = DateFC.Format(Date.Now, "YYYYMMDD") '  if Test date later than Steptmber 2 then    expected = DateFC.Format(Date.Now, "YYYYMMDD")
        Dim actual As String
        Try
            actual = SchoolYearDefaultDate.Publish(AppType, schoolyear)
            Assert.AreEqual(expected, actual, "test Publish Date from database ok.")
        Catch ex As AssertFailedException
            Trace.WriteLine(ex.Message)
        End Try
     
    End Sub
    <TestMethod()> _
    Public Sub DeadlineTest()

        Dim AppType As String = "LTO"
        Dim schoolyear As String = "20132014"

        Dim expected As String = DateFC.Format(Date.Now, "YYYYMMDD")    '  if Test date later than Steptmber 2 then    expected = DateFC.Format(Date.Now, "YYYYMMDD")
        Dim actual As String
        Try
            actual = SchoolYearDefaultDate.Deadline(AppType, schoolyear)
            Assert.AreEqual(expected, actual, "test Publish Date from database ok.")
        Catch ex As AssertFailedException
            Trace.WriteLine(ex.Message)
        End Try

    End Sub
   

End Class