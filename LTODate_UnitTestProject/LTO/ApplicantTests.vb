Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports TCDSB.Student


Namespace TCDSB.Student.Tests

    <TestClass()> Public Class ApplicantTests

        Private dbCon As String = CommonTCDSB.Webconfig.getDBbyKey("DBconnection").ToString

        Private testContextInstance As TestContext
        <TestInitialize()>
        Public Sub MyTestInitialize()
            SetupData.myDBConStr = dbCon
        End Sub

        <TestMethod()> Public Sub ListSearchByNameTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub NoticeToTeacherTest()
            Assert.Fail()
        End Sub
    End Class


End Namespace


