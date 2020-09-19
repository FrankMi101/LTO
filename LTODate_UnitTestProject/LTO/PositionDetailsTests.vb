Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports TCDSB.Student


Namespace TCDSB.Student.Tests

    <TestClass()> Public Class PositionDetailsTests

        Private dbCon As String = CommonTCDSB.Webconfig.getDBbyKey("DBconnection").ToString

        Private testContextInstance As TestContext
        <TestInitialize()>
        Public Sub MyTestInitialize()
            SetupData.myDBConStr = dbCon
        End Sub

        <TestMethod()> Public Sub GeoCodebySchoolCodeTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub RequestNewPositionbyIDTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub RequestNewPositionSaveTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub RequestPositionCancelTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub RePostingPositionSaveTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub RequestNewPositionSaveTest1()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub RequestNewPositionSaveTest2()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub DetailbyIDForLTOTeacherTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub DetailbyIDForPrincipalNoticeTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub DetailbyIDForHRStaffNoticeTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub getOfficerProfileTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub getEmailInterviewSchoolCCListTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub NoticeToOfficerForHiredTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub NoticeToOfficerForHiredTest1()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub NoticeToPrincipalTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub NoticeToTeacherTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub NoticeToPrincipalTest1()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub NoticeToHRStaffForMoreInterviewCandidateTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub NoticeToHRStaffForMoreInterviewCandidateTest1()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub ApplyThisPositionTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub ApplyThisPositionTest1()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub ApplicantProfileTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub ApplicantCommentTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub InterviewCandidatePositionTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub InterviewCandidateProfileTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub HiringCandidateProfileTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub HiringCandidateProfile4thTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub AcceptanceInterviewTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub RecommandforHiringTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub InterviewUpdateTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub AcceptanceHiringTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub AcceptanceHireTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub AcceptanceHire4ThTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub GetDeadlineDateTest()
            Assert.Fail()
        End Sub

        <TestMethod()> Public Sub GetDeadlineDate2Test()
            Assert.Fail()
        End Sub
    End Class


End Namespace


