using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppOperate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.Web;

namespace AppOperate.Tests
{
    [TestClass()]
    public class eMailNotificationTests
    {
        string schoolyear = "20192020";

        string emailSubjectAndBodyTemplateFile = @"Content\eMailTemplate.json";

        [TestMethod()]
        public void UserProfileByIDTest()
        {
            //Arrange
            string type = "FullName";
            string _PrincipalID = "agostir";
            string expect = "Riccardo Agostino";

            //Act
            var result = EmailNotification.UserProfileByID(type, _PrincipalID);

            //Assert
            Assert.AreEqual(expect, result, $"  RePosting email notification { result}");



        }

        [TestMethod()]
        public void GetMultipleSchoolEmailTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveEmailNoticeTest()
        {
            //Arrange
            var testMail = new EmailNotice2()
            {
                UserID = "mif",
                SchoolYear = schoolyear,
                SchoolCode = "0204",
                PositionType = "LTO",
                PositionID = "20112",
                PositionTitle = "Posting Title English Gr.6",
                PostingNum = "2018-20122",
                NoticePrincipal = "School Principal Name",
                EmailType = "Repost",
                EmailTo = "principal@tcdsb.org",
                EmailCC = "HRstaff@tcdsb.org",
                EmailFrom = "LTOPOP@tcdsb.org",
                EmailSubject = "Posting Reposting Notification",
                EmailBody = "",
                EmailFormat = "HTML",
                Attachment1 = "",
                Attachment2 = "",
                Attachment3 = "",
            };


            string expect = "Successfully";

            //Act
            var result = EmailNotification.SaveEmailNotice(testMail);


            //Assert
            Assert.AreEqual(expect, result, $"  RePosting email notification { result}");
        }

        [TestMethod()]
        public void SendeMail_Reposting_Test()
        {
            //Arrange
            var testMail = new EmailNotice2()
            {
                UserID = "mif",
                SchoolYear = schoolyear,
                SchoolCode = "0204",
                PositionType = "LTO",
                PositionID = "20112",
                PositionTitle = "Posting Title English Gr.6",
                PostingNum = "2018-20122",
                NoticePrincipal = "School Principal Name",
                NoticeFor = "Principal",
                EmailType = "Repost",
                EmailTo = "principal@tcdsb.org",
                EmailCC = "HRstaff@tcdsb.org",
                EmailFrom = "LTOPOP@tcdsb.org",
                EmailSubject = "Posting Reposting Notification",
                EmailBody = "",
                EmailFormat = "HTML",
                Attachment1 = "",
                Attachment2 = "",
                Attachment3 = "",
            };


            string expect = "Successfully";

            //Act
            var result = EmailNotification.SendEmail(testMail);


            //Assert
            Assert.AreEqual(expect, result, $"  RePosting email notification { result}");
        }

        [TestMethod()]
        [DeploymentItem(@"eMailTemplate.json", "Content")]
        public void SubjectTest_PostingLTOPositionEmailNotification_ReturnNewPositionPostingNotification()
        {
           //Arrange
           string action = "Posting";
           string expect = "New LTO/POP Position Posting Notification";
           string pType = "LTO";

            // act
           string jsonFile = HttpContext.Current.Server.MapPath("eMailTemplate.json");
           string result = EmailNotification.Subject(jsonFile, pType, action);


           // Assert
           Assert.AreEqual(expect,result, $" {pType } {action} email notification subject is {result}");
        }
        [TestMethod()]
        public void SubjectTest_RePostingLTOPositionEmailNotification_ReturnRePostingNotificationSubject()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void SubjectTest_CancelLTOPostingEmailNotification_ReturnCancelNotificationSubject()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void SubjectTest_RejectPostingRequestEmailNotification_ReturnRejectNotificationSubject()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EmailSubjectAndTempleTest()
        {
            Assert.Fail();
        }
    }
}