using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppOperate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.Web;
using System.IO;
using System.Net.Http;
using System.Reflection;

namespace AppOperate.Tests
{
    [TestClass()]
    public class eMailNotificationTests
    {
        string schoolyear = "20192020";

        string emailSubjectAndBodyTemplateFile = @"Content\eMailTemplate.json";

        string pType = "LTO";
        string jsonFile = "eMailTemplate.json";

        // ********************* Very import for testing include read a File *********************
        // For Read Json file for test
        // Must setup the file property [Copy to Output Diractory] to "Copy always"
        // eMailTemplate.json is example
        // ***************************************************************************************

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


            string expect = "Successfully,Failed,SMTP Server Failed, No Email Recieve";

            //Act
            var result = EmailNotification.SendEmail(testMail);


            //Assert
            StringAssert.Contains(expect, result, $"  RePosting email notification { result}");
        }

        [TestMethod()]
        [DeploymentItem("out//eMailTemplate.json")]
        public void SubjectTest_PostingLTOPositionEmailNotification_ReturnNewPositionPostingNotification()
        {
            //Arrange
            string action = "Posting";
            string expect = "New LTO/POP Position Posting Notification";

            // act
            string result = EmailNotification.Subject(jsonFile, pType, action);

            // Assert
            Assert.AreEqual(expect, result, $" {pType } {action} email notification subject is {result}");
        }

        public static TextReader GetJsonFile(string filename)
        {
            try
            {
                Assembly thisAssembly = Assembly.GetExecutingAssembly();
                string path = "My.Tool.Json";
                var myfile = thisAssembly.GetManifestResourceStream(path + "." + filename);
                return new StreamReader(myfile);
            }
            catch (Exception ex)
            {
                var ms = ex.Message;
                return null;
            }
        }

        //[TestMethod()]
        //public void SubjectTest_RePostingLTOPositionEmailNotification_ReturnRePostingNotificationSubject()
        //{
        //    //Arrange
        //    string action = "Repost";
        //    string expect = "Position Reposting Notification";

        //    // act
        //    string result = EmailNotification.Subject(jsonFile, pType, action);

        //    // Assert
        //    Assert.AreEqual(expect, result, $" {pType } {action} email notification subject is {result}");
        //}
        //[TestMethod()]
        //public void SubjectTest_CancelLTOPostingEmailNotification_ReturnCancelNotificationSubject()
        //{
        //    //Arrange
        //    string action = "CancelA";
        //    string expect = "Cancel Posted PositionTitle Notification";

        //    // act
        //    string result = EmailNotification.Subject(jsonFile, pType, action);

        //    // Assert
        //    Assert.AreEqual(expect, result, $" {pType } {action} email notification subject is {result}");
        //}
        //[TestMethod()]
        //public void SubjectTest_RejectPostingRequestEmailNotification_ReturnRejectNotificationSubject()
        //{
        //    //Arrange
        //    string action = "Reject";
        //    string expect = "Reject New posting Request Notification";
        //    // act
        //    string result = EmailNotification.Subject(jsonFile, pType, action);

        //    // Assert
        //    Assert.AreEqual(expect, result, $" {pType } {action} email notification subject is {result}");
        //}

        [TestMethod()]
        public void EmailSubjectAndTempleByAction_Return_Reject_TempleteFile_Test()
        {
            //Arrange
            string action = "Reject";
            string expect = "PostingNotification_Reject.htm";
            // act
            string result = EmailNotification.Template(jsonFile, pType, action);

            // Assert
            Assert.AreEqual(expect, result, $" {pType } {action} email notification subject is {result}");
        }

        //[TestMethod()]
        //public void EmailSubjectAndTempleByAction_Return_Post_TempleteFile_Test()
        //{
        //    //Arrange
        //    string action = "Posting";
        //    string expect = "PostingNotification.htm";

        //    // act
        //    string result = EmailNotification.Template(jsonFile, pType, action);

        //    // Assert
        //    Assert.AreEqual(expect, result, $" {pType } {action} email notification subject is {result}");
        //}
        //[TestMethod()]
        //public void EmailSubjectAndTempleByAction_Return_Repost_TempleteFile_Test()
        //{
        //    //Arrange
        //    string action = "Repost";
        //    string expect = "PostingNotification_Reposting.htm";

        //    // act
        //    string result = EmailNotification.Template(jsonFile, pType, action);

        //    // Assert
        //    Assert.AreEqual(expect, result, $" {pType } {action} email notification subject is {result}");
        //}




        [TestMethod()]
        [DataRow("Applied", "Confirmation for PositionTitle Notification")]
        [DataRow("CancelA", "Cancel Posted PositionTitle Notification")]
        [DataRow("ConfirmHire", "Confirm for PositionTitle hired Notification")]
        [DataRow("Notice", "Interview Candidate list for PositionTitle Notification")]
        [DataRow("Posting", "New LTO/POP Position Posting Notification")]
        [DataRow("Repost", "Position Reposting Notification")]
        [DataRow("Reject", "Reject New posting Request Notification")]
        [DataRow("Revoke", "Revoke Position confirm hired Notification")]
        public void EmailNotification_SubjectTest_byAction__ReturnEmailNotificationSubjectbyAction_Test(string action, string expect)
        {
            //Arrange
            // act
            string result = EmailNotification.Subject(jsonFile, pType, action);

            // Assert
            Assert.AreEqual(expect, result, $" {pType } {action} email notification subject is {result}");
        }

        [TestMethod()]
        [DataRow("Applied", "ConfirmApplyNotificationLTO.htm")]
        [DataRow("CancelA", "PostingNotification_CancelA.htm")]
        [DataRow("ConfirmHire", "ConfirmHiredNotification.htm")]
        [DataRow("Notice", "ConfirmInterviewNotificationLTO.htm")]
        [DataRow("Posting", "PostingNotification.htm")]
        [DataRow("Repost", "PostingNotification_Reposting.htm")]
        [DataRow("Reject", "PostingNotification_Reject.htm")]
        [DataRow("Revoke", "ConfirmHiredNotificationRevoke.htm")]
        public void EmailNotification_TempletTest_ByAction_Return_ActionTempleteFile_Test(string action, string expect)
        {
            //Arrange

            // act
            string result = EmailNotification.Template(jsonFile, pType, action);

            // Assert
            Assert.AreEqual(expect, result, $" {pType } {action} email notification subject is {result}");
        }

    }
}