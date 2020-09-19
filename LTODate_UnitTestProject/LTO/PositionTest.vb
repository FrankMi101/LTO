Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting 
Imports TCDSB.Student



'''<summary>
'''This is a test class for Responses_TypeCTest and is intended
'''to contain all Responses_TypeCTest Unit Tests
'''</summary>
<TestClass()> _
Public Class PositionTest

    Private dbCon As String = CommonTCDSB.Webconfig.getDBbyKey("DBconnection").ToString

    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(value As TestContext)
            testContextInstance = value
        End Set
    End Property

#Region "Additional test attributes"
    '
    'You can use the following additional attributes as you write your tests:
    '
    'Use ClassInitialize to run code before running the first test in the class
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup to run code after all tests in a class have run
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize to run code before running each test
    <TestInitialize()> _
    Public Sub MyTestInitialize()
        SetupData.myDBConStr = dbCon
    End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region




    <TestMethod()> _
    Public Sub RequestNewPositionbyIDTest()

        Dim Operate As String = "Update" 'TODO: Initialize to an appropriate value
        Dim UserID As String = "mif" ' TODO: Initialize to an appropriate value
        Dim school_year As String = "20132014" ' TODO: Initialize to an appropriate value
        Dim IDs As String = "1" ' TODO: Initialize to an appropriate value
        Dim PositionID As String = "512" ' TODO: Initialize to an appropriate value
        Dim expected As Integer = 0  ' String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As DataSet
        Try
            actual = Position.RequestNewPositionbyID(UserID, school_year, PositionID)
            Assert.IsNotNull(actual, "test Class Position get new postion by ID test 1 ok")

        Catch ex As AssertFailedException
            Trace.WriteLine(ex.Message)

        End Try


    End Sub


    <TestMethod()> _
    Public Sub RequestPositionCancelTest()

        Dim Operate As String = "Cancel" 'TODO: Initialize to an appropriate value
        Dim UserID As String = "mif" ' TODO: Initialize to an appropriate value
        Dim school_year As String = "20132014" ' TODO: Initialize to an appropriate value
        Dim IDs As String = "1" ' TODO: Initialize to an appropriate value
        Dim PositionID As String = "512" ' TODO: Initialize to an appropriate value
        Dim postComments As String = "Cancel posting" ' TODO: Initialize to an appropriate value
        Dim expected As String = "Successfully"   ' String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        Try
            actual = Position.RequestPositionCancel(Operate, UserID, school_year, PositionID, IDs, postComments)
            Assert.AreEqual(expected, actual, "test Class Position Request New Position Save test 1 ok")

        Catch ex As AssertFailedException
            Trace.WriteLine(ex.Message)

        End Try


    End Sub



    <TestMethod()> _
    Public Sub RePostingPositionSaveTest()

        Dim Operate As String = "Update" 'TODO: Initialize to an appropriate value
        Dim UserID As String = "mif" ' TODO: Initialize to an appropriate value
        Dim school_year As String = "20132014" ' TODO: Initialize to an appropriate value
        Dim IDs As String = "1" ' TODO: Initialize to an appropriate value
        Dim PositionID As String = "512" ' TODO: Initialize to an appropriate value
        Dim postingcycle As String = "2" ' TODO: Initialize to an appropriate value
        Dim takeapplicant As String = "2512" ' TODO: Initialize to an appropriate value
        Dim expected As String = "Successfully"  ' String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        Try
            actual = Position.RePostingPositionSave(Operate, UserID, school_year, PositionID, IDs, postingcycle, takeapplicant)
            Assert.AreEqual(expected, actual, "test Class Position Request New Position Save test 1 ok")

        Catch ex As AssertFailedException
            Trace.WriteLine(ex.Message)

        End Try


    End Sub




    <TestMethod()> _
    Public Sub RequestNewPositionSaveTest1()

        Dim Operate As String = "Update" 'TODO: Initialize to an appropriate value
        Dim UserID As String = "mif" ' TODO: Initialize to an appropriate value
        Dim school_year As String = "20132014" ' TODO: Initialize to an appropriate value
        Dim IDs As String = "1" ' TODO: Initialize to an appropriate value
        Dim PositionID As String = "512" ' TODO: Initialize to an appropriate value
        Dim expected As String = "Successfully" ' String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        Try
            actual = Position.RequestNewPositionSave(Operate, UserID, school_year, PositionID, IDs)
            Assert.AreEqual(expected, actual, "test Class Position Request New Position Save test 1 ok")

        Catch ex As AssertFailedException
            Trace.WriteLine(ex.Message)

        End Try


    End Sub
    '''<summary>
    '''A test for SaveComment
    '''</summary>
    <TestMethod()> _
    Public Sub RequestNewPositionSaveTest2()

        Dim Operate As String = "Update" 'TODO: Initialize to an appropriate value
        Dim UserID As String = "mif" ' TODO: Initialize to an appropriate value
        Dim school_year As String = "20132014" ' TODO: Initialize to an appropriate value
        Dim IDs As String = "1" ' TODO: Initialize to an appropriate value
        Dim PositionID As String = "512" ' TODO: Initialize to an appropriate value
        Dim SchoolCode As String = "0366" ' TODO: Initialize to an appropriate value
        Dim Positiontitle As String = "Grade 7 English " ' TODO: Initialize to an appropriate value
        Dim Qualification As String = "" ' TODO: Initialize to an appropriate value
        Dim Description As String = "Grade 7 English 50%  " ' TODO: Initialize to an appropriate value
        Dim PositionFTE As String = "0.5" ' TODO: Initialize to an appropriate value
        Dim DatePublish As String = "2013/08/17" ' TODO: Initialize to an appropriate value
        Dim DateStart As String = "2013/09/02" ' TODO: Initialize to an appropriate value
        Dim DateEndApply As String = "2013/08/23" ' TODO: Initialize to an appropriate value
        Dim PositionLevel As String = "SBC" ' TODO: Initialize to an appropriate value
        Dim appType As String = "LTO" ' TODO: Initialize to an appropriate value
        Dim DateEnd As String = "2014/06/25" ' TODO: Initialize to an appropriate value
        Dim PostedComments As String = "full year position" ' TODO: Initialize to an appropriate value
        Dim Link_PositionID As String = "0" ' TODO: Initialize to an appropriate value 
        Dim expected As String = "Successfully" ' String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        Try
            actual = Position.RequestNewPositionSave(Operate, UserID, school_year, SchoolCode, PositionID, IDs, Positiontitle, Qualification, Description, PositionFTE, DateEnd, DatePublish, DateStart, DateEndApply, PositionLevel, appType)
            Assert.AreEqual(expected, actual, "test Class Position Request New Position Save test 1 ok")

        Catch ex As AssertFailedException
            Trace.WriteLine(ex.Message)

        End Try


    End Sub
    <TestMethod()> _
    Public Sub RequestNewPositionSaveTest3()

        Dim Operate As String = "Update" 'TODO: Initialize to an appropriate value
        Dim UserID As String = "mif" ' TODO: Initialize to an appropriate value
        Dim school_year As String = "20132014" ' TODO: Initialize to an appropriate value
        Dim IDs As String = "1" ' TODO: Initialize to an appropriate value
        Dim PositionID As String = "512" ' TODO: Initialize to an appropriate value
        Dim SchoolCode As String = "0366" ' TODO: Initialize to an appropriate value
        Dim Positiontitle As String = "Grade 7 English " ' TODO: Initialize to an appropriate value
        Dim Qualification As String = "" ' TODO: Initialize to an appropriate value
        Dim Description As String = "Grade 7 English 50%  " ' TODO: Initialize to an appropriate value
        Dim PositionFTE As String = "0.5" ' TODO: Initialize to an appropriate value
        Dim DatePublish As String = "2013/08/17" ' TODO: Initialize to an appropriate value
        Dim DateStart As String = "2013/09/02" ' TODO: Initialize to an appropriate value
        Dim DateEndApply As String = "2013/08/23" ' TODO: Initialize to an appropriate value
        Dim PositionLevel As String = "SBC" ' TODO: Initialize to an appropriate value
        Dim appType As String = "LTO" ' TODO: Initialize to an appropriate value
        Dim DateEnd As String = "2014/06/25" ' TODO: Initialize to an appropriate value
        Dim PostedComments As String = "full year position" ' TODO: Initialize to an appropriate value
        Dim Link_PositionID As String = "0" ' TODO: Initialize to an appropriate value 
        Dim expected As String = "Successfully" ' String.Empty ' TODO: Initialize to an appropriate value
        Dim actual As String
        Try
            actual = Position.RequestNewPositionSave(Operate, UserID, school_year, SchoolCode, PositionID, IDs, Positiontitle, Qualification, Description, PositionFTE, DateEnd, DatePublish, DateStart, DateEndApply, PositionLevel, appType, PostedComments, Link_PositionID)
            Assert.AreEqual(expected, actual, "test Class Position Request New Position Save test 1 ok")

        Catch ex As AssertFailedException
            Trace.WriteLine(ex.Message)

        End Try


    End Sub
End Class
