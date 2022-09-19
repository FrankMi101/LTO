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
         string addressType = "TCDSBeMailAddress";
        string action = "";
        string pType = "LTO";
        string jsonFile = "eMailTemplate.json";
        string bodyTemplateForTest = "BodyTemplate.htm";
        string expect = "Successfully, SMTP Server Failed,No Email Recieve";
        // ********************* Very import for testing include read a File *********************
        // For Read Json file for test
        // Must setup the file property [Copy to Output Diractory] to "Copy always"
        // eMailTemplate.json is example
        // ***************************************************************************************

        private PositionPublish position = new PositionPublish();

        
        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional)
            position.UserID = "mif";
            position.SchoolYear = "20212022";
            position.SchoolCode = "0205";
            position.PostingNumber = "2021-303033";
            position.PositionID = 303033;
            position.PositionType = "LTO";
            position.PositionTitle = "Unit Test Posting Position Title";
            position.StartDate = DateFC.YMD2("2021-09-06");
            position.EndDate = DateFC.YMD2("2022-06-30");
            position.DatePublish = "2021-06-10";
            position.DateApplyOpen = "2021-08-24";
            position.DateApplyClose = "2021-08-26";
            position.ReplaceTeacherID = "00054391";
            position.ReplaceTeacher = "Mr. Replace Teacher";
            position.Owner = "frijiom";
            position.PostingCycle = "1";
            position.PrincipalID = "ciancha";
            position.PrincipalName = "Antonietta Cianchetti";
        }

        [TestMethod()]
        public void UserProfileByIDTest()
        {
            //Arrange
            string type = "FullName";
            string _PrincipalID = "agostir";
            string expect = "Riccardo Agostino";

            //Act
            var result = EmailNotification.UserProfileByID(type, _PrincipalID, action);

            //Assert
            Assert.AreEqual(expect, result, $"  RePosting email notification { result}");

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
            var notice = new EmailNotification();
            var result = notice.SaveEmailNotice(testMail);


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
            var eNotice = new EmailNotification();
            var result = eNotice.SendEmail(testMail);


            //Assert
            StringAssert.Contains(expect, result, $"  RePosting email notification { result}");
        }

        [TestMethod()]
        [DeploymentItem("out//eMailTemplate.json")]
        [DataRow("LTO", "New LTO Position Posting Notification")]
        [DataRow("POP", "New POP Position Posting Notification")]
        public void SubjectTest_PostingLTOPositionEmailNotification_ReturnNewPositionPostingNotification(string appType, string subject)
        {
            //Arrange
            string action = "Posting";
            string expect = subject;

            // act
            var eNotice = new EmailNotification();
            string result = eNotice.Subject(jsonFile, appType, action);

            // Assert
            Assert.AreEqual(expect, result, $" {appType } {action} email notification subject is {result}");
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



        [TestMethod()]
        [DataRow("LTO", "Reject_PostingNotification_LTO.htm")]
        [DataRow("POP", "Reject_PostingNotification_POP.htm")]
        public void EmailSubjectAndTempleByAction_Return_Reject_TempleteFile_Test(string appType, string bodyTemplate)
        {
            //Arrange
            string action = "Reject";
            string expect = bodyTemplate;
            // act
            var eNotice = new EmailNotification();
            string result = eNotice.Template(jsonFile, appType, action);

            // Assert
            Assert.AreEqual(expect, result, $" {appType } {action} email notification subject is {result}");
        }



        [TestMethod()]
        [DataRow("Applied", "Confirmation for PositionTitle Notification")]
        [DataRow("CancelA", "Cancel Posted PositionTitle Notification")]
        [DataRow("ConfirmHire", "Confirm for PositionTitle hired Notification")]
        [DataRow("Notice", "Candidate list for PositionTitle Notification")]
        [DataRow("Posting", "New LTO Position Posting Notification")]
        [DataRow("Repost", "Position Reposting Notification")]
        [DataRow("Reject", "Reject New posting Request Notification")]
        [DataRow("Revoke", "Revoke confirm for PositionTitle hired Notification")]
        public void EmailNotification_SubjectTest_byAction__ReturnEmailNotificationSubjectbyAction_Test(string action, string expect)
        {
            //Arrange

            // act
            var eNotice = new EmailNotification();
            string result = eNotice.Subject(jsonFile, pType, action);

            // Assert
            Assert.AreEqual(expect, result, $" {pType } {action} email notification subject is {result}");
        }

        [TestMethod()]
        [DataRow("LTO", "Applied", "Apply_NotificationConfirm_LTO.htm")]
        [DataRow("LTO", "CancelA", "PostingNotification_CancelA.htm")]
        [DataRow("LTO", "ConfirmHire", "Hired_ConfirmNotification_LTO.htm")]
        [DataRow("LTO", "Notice", "Notice_CandidateList_LTO.htm")]
        [DataRow("LTO", "Posting", "Posting_Notification_LTO.htm")]
        [DataRow("LTO", "Repost", "Posting_Notification_LTO_Reposting.htm")]
        [DataRow("LTO", "Reject", "Reject_PostingNotification_LTO.htm")]
        [DataRow("LTO", "Revoke", "Revoke_HiredNotification_LTO.htm")]
        [DataRow("POP", "Applied", "Apply_NotificationConfirm_POP.htm")]
        [DataRow("POP", "CancelA", "PostingNotification_CancelA.htm")]
        [DataRow("POP", "ConfirmHire", "Hired_ConfirmNotification_POP.htm")]
        [DataRow("POP", "Notice", "Notice_CandidateList_POP.htm")]
        [DataRow("POP", "Posting", "Posting_Notification_POP.htm")]
        [DataRow("POP", "Repost", "Posting_Notification_POP_Reposting.htm")]
        [DataRow("POP", "Reject", "Reject_PostingNotification_POP.htm")]
        [DataRow("POP", "Revoke", "Revoke_HiredNotification_POP.htm")]

        public void EmailNotification_TempletTest_ByAction_Return_ActionTempleteFile_Test(string appType, string action, string expect)
        {
            //Arrange

            // act
            var eNotice = new EmailNotification();
            string result = eNotice.Template(jsonFile, appType, action);

            // Assert
            Assert.AreEqual(expect, result, $" {appType } {action} email notification subject is {result}");
        }

    }
}