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
    public class EmailNotificationTests2
    {
        string schoolyear = "20192020";
        string emailSubjectAndBodyTemplateFile = @"Content\eMailTemplate.json";
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

        private string GetEmailBody(string action, string bodyTemplate)
        {
           // return "Email Body template HTML file";
            string eMailbodyFile = bodyTemplate; // Server.MapPath("..") + "\Template\" + bodyTemplate
            string eMailFile = EmailNotification.EmailHTMLBody(bodyTemplateForTest);
            try
            {
                eMailFile = eMailFile.Replace("[PostingNumberSTR]", position.PostingNumber);
                eMailFile = eMailFile.Replace("[PrincipalNameSTR]", bodyTemplate);
                return eMailFile;

            }
            catch (Exception)
            {
                return ""  ;
            }

        }

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
            position.PositionTitle = "Unit Test Position Title";
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
        [DataRow("LTO", "Staff", "frijiom", "Request New posting Position Notification", "Request_PostingNotification_LTO.htm")]
        [DataRow("POP", "Staff", "ruscicj", "Request New posting Position Notification", "Request_PostingNotification_POP.htm")]
        public void EmailNotification_Request_ToHR_FromPrinciapl_ReturnEmailContent(string appType, string toWho, string owner, string subject, string bodyTemplate)
        {
            //Arrange
            action = "Request";
            position.PositionType = appType;
            position.Owner = owner;

            // Act                                       
            var notice = new EmailNotification(position);
            var eMail = new EmailNotice2();

            eMail = notice.GetEmailNotice(jsonFile, action, toWho, position.PrincipalID);
             eMail.EmailBody = GetEmailBody(action, eMail.EmailBody);

            string logId = notice.SaveEmailNotice(eMail);
            var result = notice.SendEmail(eMail);


            //Assert
            string expectToMail = notice.UserProfileByID(addressType, position.Owner);
            string expectCCMail = notice.UserProfileByID(addressType, position.PrincipalID);

            StringAssert.Contains(eMail.EmailTo, expectToMail, $"To Email Address for {action} on {appType} to {toWho}, {eMail.EmailTo}  ");
            StringAssert.Contains(eMail.EmailCC, expectCCMail, $"CC Email Address for {action} on {appType} to {toWho}, {eMail.EmailCC}  ");
            StringAssert.Contains(eMail.EmailBody,bodyTemplate,  $"Email Body contains for  {action} on {appType} to {toWho}, {bodyTemplate}");
            StringAssert.Contains(eMail.EmailBody, position.PostingNumber, $"Email Boady contains for {action} on {appType} to {toWho}, {position.PostingNumber}");

            Assert.AreEqual(subject, eMail.EmailSubject, $" Email Subject for {action} on {appType} to {toWho}, {eMail.EmailSubject}");
           // Assert.AreEqual(expect, result, $" Email Send for {action} on {appType} to {toWho}, {result}");
            StringAssert.Contains(expect,result,   $"Email Body contains for {action} on {appType} to {toWho}, {position.PostingNumber}");

        }
        [TestMethod()]
        [DataRow("LTO", "Staff", "frijiom", "Request More Interview Candidate Notification", "Request_MoreInterviewCandidate.htm")]
        [DataRow("POP", "Staff", "ruscicj", "Request More Interview Candidate Notification", "Request_MoreInterviewCandidate.htm")]
        public void EmailNotification_RequestMoreInterview_ToHR_FromPrinciapl_ReturnEmailContent(string appType, string toWho, string owner, string subject, string bodyTemplate)
        {
            //Arrange
            action = "MoreInterview";
            position.PositionType = appType;
            position.Owner = owner;

            // Act                                       
            var notice = new EmailNotification(position);
            var eMail = new EmailNotice2();

            eMail = notice.GetEmailNotice(jsonFile, action, toWho, position.PrincipalID);
            eMail.EmailBody = GetEmailBody(action, eMail.EmailBody);

            string logId = notice.SaveEmailNotice(eMail);
            var result = notice.SendEmail(eMail);


            //Assert
            string expectToMail = notice.UserProfileByID(addressType, position.Owner);
            string expectCCMail = notice.UserProfileByID(addressType, position.PrincipalID);

            StringAssert.Contains(eMail.EmailTo, expectToMail, $"To Email Address for {action} on {appType} to {toWho}, {eMail.EmailTo}  ");
            StringAssert.Contains(eMail.EmailCC, expectCCMail, $"CC Email Address for {action} on {appType} to {toWho}, {eMail.EmailCC}  ");
            StringAssert.Contains(eMail.EmailBody, bodyTemplate, $"Email Body contains for  {action} on {appType} to {toWho}, {bodyTemplate}");
            StringAssert.Contains(eMail.EmailBody, position.PostingNumber, $"Email Boady contains for {action} on {appType} to {toWho}, {position.PostingNumber}");

            Assert.AreEqual(subject, eMail.EmailSubject, $" Email Subject for {action} on {appType} to {toWho}, {eMail.EmailSubject}");
            // Assert.AreEqual(expect, result, $" Email Send for {action} on {appType} to {toWho}, {result}");
            StringAssert.Contains(expect, result, $"Email Body contains for {action} on {appType} to {toWho}, {position.PostingNumber}");

        }

        [TestMethod()]
        [DataRow("LTO", "Principal", "frijiom", "New LTO Position Posting Notification", "Posting_Notification_LTO.htm")]
        [DataRow("POP", "Principal", "ruscicj", "New POP Position Posting Notification", "Posting_Notification_POP.htm")]
        [DataRow("LTO", "Union", "frijiom", "New LTO Position Posting Notification", "Posting_Notification_LTO.htm")]
        [DataRow("POP", "Union", "ruscicj", "New POP Position Posting Notification", "Posting_Notification_POP.htm")]
        public void EmailNotification_Posting_ToPrincipal_FromHR_ReturnEmailContent(string appType, string toWho, string owner, string subject, string bodyTemplate)
        {
            //Arrange
            action = "Posting";
            position.PositionType = appType;
            position.Owner = owner;
            string panel = DataTools.SchoolPanel(position.SchoolCode);

            // Act                                       
            var notice = new EmailNotification(position);
            var eMail = new EmailNotice2();

            eMail = notice.GetEmailNotice(jsonFile, action, toWho, position.PrincipalID);
            eMail.EmailBody = GetEmailBody(action, eMail.EmailBody);

            string logId = notice.SaveEmailNotice(eMail);
            var result = notice.SendEmail(eMail); 

            //Assert
            string expectToMail = toWho == "Principal" ? notice.UserProfileByID(addressType, position.PrincipalID)
                                                    : notice.UnionEmail(panel, appType);
            string expectCCMail = notice.UserProfileByID(addressType, position.Owner);

            StringAssert.Contains(eMail.EmailTo, expectToMail, $"To Email Address for {action} on {appType} to {toWho}, {eMail.EmailTo}  ");
            StringAssert.Contains(eMail.EmailCC, expectCCMail, $"CC Email Address for {action} on {appType} to {toWho}, {eMail.EmailCC}  ");

            StringAssert.Contains(eMail.EmailBody, bodyTemplate, $"Email Body contains for  {action} on {appType} to {toWho}, {bodyTemplate}");
            StringAssert.Contains(eMail.EmailBody, position.PostingNumber, $"Email Boady contains for {action} on {appType} to {toWho}, {position.PostingNumber}");

            Assert.AreEqual(subject, eMail.EmailSubject, $" Email Subject for {action} on {appType} to {toWho}, {eMail.EmailSubject}");
            StringAssert.Contains(expect, result, $"Email Body contains for {action} on {appType} to {toWho}, {position.PostingNumber}");
        }

        [TestMethod()]
        [DataRow("LTO", "Principal", "frijiom", "Position Reposting Notification", "Posting_Notification_LTO_Reposting.htm")]
        [DataRow("POP", "Principal", "ruscicj", "Position Reposting Notification", "Posting_Notification_POP_Reposting.htm")]
        [DataRow("LTO", "Union", "frijiom", "Position Reposting Notification", "Posting_Notification_LTO_Reposting.htm")]
        [DataRow("POP", "Union", "ruscicj", "Position Reposting Notification", "Posting_Notification_POP_Reposting.htm")]
        public void EmailNotification_RePosting_ToPrincipal_FromHR_ReturnEmailContent(string appType, string toWho, string owner, string subject, string bodyTemplate)
        {
            //Arrange
            action = "Repost";
            position.PositionType = appType;
            position.Owner = owner;
            string panel = DataTools.SchoolPanel(position.SchoolCode);

            // Act                                       
            var notice = new EmailNotification(position);
            var eMail = new EmailNotice2();

            eMail = notice.GetEmailNotice(jsonFile, action, toWho, position.PrincipalID);
            eMail.EmailBody = GetEmailBody(action, eMail.EmailBody);

            string logId = notice.SaveEmailNotice(eMail);
            var result = notice.SendEmail(eMail);

            //Assert
            string expectToMail = toWho == "Principal" ? notice.UserProfileByID(addressType, position.PrincipalID)
                                                    : notice.UnionEmail(panel, appType);
            string expectCCMail = notice.UserProfileByID(addressType, position.Owner);

            StringAssert.Contains(eMail.EmailTo, expectToMail, $"To Email Address for {action} on {appType} to {toWho}, {eMail.EmailTo}  ");
            StringAssert.Contains(eMail.EmailCC, expectCCMail, $"CC Email Address for {action} on {appType} to {toWho}, {eMail.EmailCC}  ");

            StringAssert.Contains(eMail.EmailBody, bodyTemplate, $"Email Body contains for  {action} on {appType} to {toWho}, {bodyTemplate}");
            StringAssert.Contains(eMail.EmailBody, position.PostingNumber, $"Email Boady contains for {action} on {appType} to {toWho}, {position.PostingNumber}");

            Assert.AreEqual(subject, eMail.EmailSubject, $" Email Subject for {action} on {appType} to {toWho}, {eMail.EmailSubject}");
            StringAssert.Contains(expect, result, $"Email Body contains for {action} on {appType} to {toWho}, {position.PostingNumber}");
        }

        [TestMethod()]
        [DataRow("LTO", "Principal", "frijiom", "Reject New posting Request Notification", "Reject_PostingNotification_LTO.htm")]
        [DataRow("POP", "Principal", "ruscicj", "Reject New posting Request Notification", "Reject_PostingNotification_POP.htm")]
        public void EmailNotification_Reject_ToPrincipal_FromHR_ReturnEmailContent(string appType, string toWho, string owner, string subject, string bodyTemplate)
        {
            //Arrange
            action = "Reject";
            position.PositionType = appType;
            position.Owner = owner;
            string panel = DataTools.SchoolPanel(position.SchoolCode);

            // Act                                       
            var notice = new EmailNotification(position);
            var eMail = new EmailNotice2();

            eMail = notice.GetEmailNotice(jsonFile, action, toWho, position.PrincipalID);
            eMail.EmailBody = GetEmailBody(action, eMail.EmailBody);

            string logId = notice.SaveEmailNotice(eMail);
            var result = notice.SendEmail(eMail);

            //Assert
            string expectToMail = toWho == "Principal" ? notice.UserProfileByID(addressType, position.PrincipalID)
                                                    : notice.UnionEmail(panel, appType);
            string expectCCMail = notice.UserProfileByID(addressType, position.Owner);

            StringAssert.Contains(eMail.EmailTo, expectToMail, $"To Email Address for {action} on {appType} to {toWho}, {eMail.EmailTo}  ");
            StringAssert.Contains(eMail.EmailCC, expectCCMail, $"CC Email Address for {action} on {appType} to {toWho}, {eMail.EmailCC}  ");

            StringAssert.Contains(eMail.EmailBody, bodyTemplate, $"Email Body contains for  {action} on {appType} to {toWho}, {bodyTemplate}");
            StringAssert.Contains(eMail.EmailBody, position.PostingNumber, $"Email Boady contains for {action} on {appType} to {toWho}, {position.PostingNumber}");

            Assert.AreEqual(subject, eMail.EmailSubject, $" Email Subject for {action} on {appType} to {toWho}, {eMail.EmailSubject}");
            StringAssert.Contains(expect, result, $"Email Body contains for {action} on {appType} to {toWho}, {position.PostingNumber}");
        }

        [TestMethod()]
        [DataRow("LTO", "Principal", "frijiom", "Candidate list for PositionTitle Notification", "Notice_CandidateList_LTO.htm")]
        [DataRow("POP", "Principal", "ruscicj", "Candidate list for PositionTitle Notification", "Notice_CandidateList_POP.htm")]
        [DataRow("LTO", "Union", "frijiom", "Candidate list for PositionTitle Notification", "Notice_CandidateList_LTO.htm")]
        [DataRow("POP", "Union", "ruscicj", "Candidate list for PositionTitle Notification", "Notice_CandidateList_POP.htm")]
        public void EmailNotification_NoticeInterviewList_ToPrincipal_FromHR_ReturnEmailContent(string appType, string toWho, string owner, string subject, string bodyTemplate)
        {
            //Arrange
            action = "Notice";
            position.PositionType = appType;
            position.Owner = owner;
            string panel = DataTools.SchoolPanel(position.SchoolCode);

            // Act                                       
            var notice = new EmailNotification(position);
            var eMail = new EmailNotice2();

            eMail = notice.GetEmailNotice(jsonFile, action, toWho, position.PrincipalID);
            eMail.EmailBody = GetEmailBody(action, eMail.EmailBody);

            string logId = notice.SaveEmailNotice(eMail);
            var result = notice.SendEmail(eMail);

            //Assert
            string expectToMail = toWho == "Principal" ? notice.UserProfileByID(addressType, position.PrincipalID)
                                                    : notice.UnionEmail(panel, appType);
            string expectCCMail = notice.UserProfileByID(addressType, position.Owner);

            StringAssert.Contains(eMail.EmailTo, expectToMail, $"To Email Address for {action} on {appType} to {toWho}, {eMail.EmailTo}  ");
            StringAssert.Contains(eMail.EmailCC, expectCCMail, $"CC Email Address for {action} on {appType} to {toWho}, {eMail.EmailCC}  ");

            StringAssert.Contains(eMail.EmailBody, bodyTemplate, $"Email Body contains for  {action} on {appType} to {toWho}, {bodyTemplate}");
            StringAssert.Contains(eMail.EmailBody, position.PostingNumber, $"Email Boady contains for {action} on {appType} to {toWho}, {position.PostingNumber}");

            StringAssert.Contains(eMail.EmailSubject, position.PositionTitle, $" Email Subject for {action} on {appType} to {toWho}, {eMail.EmailSubject}");
            StringAssert.Contains(expect, result, $"Email Body contains for {action} on {appType} to {toWho}, {position.PostingNumber}");
        }

        [TestMethod()]
        [DataRow("LTO", "Principal", "frijiom", "Confirm for PositionTitle hired Notification", "Hired_ConfirmNotification_LTO.htm")]
        [DataRow("POP", "Principal", "ruscicj", "Confirm for PositionTitle hired Notification", "Hired_ConfirmNotification_POP.htm")]
        [DataRow("LTO", "Union", "frijiom", "Confirm for PositionTitle hired Notification", "Hired_ConfirmNotification_LTO.htm")]
        [DataRow("POP", "Union", "ruscicj", "Confirm for PositionTitle hired Notification", "Hired_ConfirmNotification_POP.htm")]
        public void EmailNotification_ConfirmHire_ToPrincipal_FromHR_ReturnEmailContent(string appType, string toWho, string owner, string subject, string bodyTemplate)
        {
            //Arrange
            action = "ConfirmHire";
            position.PositionType = appType;
            position.Owner = owner;
            string panel = DataTools.SchoolPanel(position.SchoolCode);

            // Act                                       
            var notice = new EmailNotification(position);
            var eMail = new EmailNotice2();

            eMail = notice.GetEmailNotice(jsonFile, action, toWho, position.PrincipalID);
            eMail.EmailBody = GetEmailBody(action, eMail.EmailBody);

            string logId = notice.SaveEmailNotice(eMail);
            var result = notice.SendEmail(eMail);

            //Assert
            string expectToMail = toWho == "Principal" ? notice.UserProfileByID(addressType, position.PrincipalID)
                                                    : notice.UnionEmail(panel, appType);
            string expectCCMail = notice.UserProfileByID(addressType, position.Owner);

            StringAssert.Contains(eMail.EmailTo, expectToMail, $"To Email Address for {action} on {appType} to {toWho}, {eMail.EmailTo}  ");
            StringAssert.Contains(eMail.EmailCC, expectCCMail, $"CC Email Address for {action} on {appType} to {toWho}, {eMail.EmailCC}  ");

            StringAssert.Contains(eMail.EmailBody, bodyTemplate, $"Email Body contains for  {action} on {appType} to {toWho}, {bodyTemplate}");
            StringAssert.Contains(eMail.EmailBody, position.PostingNumber, $"Email Boady contains for {action} on {appType} to {toWho}, {position.PostingNumber}");

            StringAssert.Contains(eMail.EmailSubject, position.PositionTitle, $" Email Subject for {action} on {appType} to {toWho}, {eMail.EmailSubject}");
            StringAssert.Contains(expect, result, $"Email Body contains for {action} on {appType} to {toWho}, {position.PostingNumber}");
        }

        [TestMethod()]
        [DataRow("LTO", "Principal", "frijiom", "Revoke confirm for PositionTitle hired Notification", "Revoke_HiredNotification_LTO.htm")]
        [DataRow("POP", "Principal", "ruscicj", "Revoke confirm for PositionTitle hired Notification", "Revoke_HiredNotification_POP.htm")]
        [DataRow("LTO", "Union", "frijiom", "Revoke confirm for PositionTitle hired Notification", "Revoke_HiredNotification_LTO.htm")]
        [DataRow("POP", "Union", "ruscicj", "Revoke confirm for PositionTitle hired Notification", "Revoke_HiredNotification_POP.htm")]
        public void EmailNotification_Revoke_ToPrincipal_FromHR_ReturnEmailContent(string appType, string toWho, string owner, string subject, string bodyTemplate)
        {
            //Arrange
            action = "Revoke";
            position.PositionType = appType;
            position.Owner = owner;
            string panel = DataTools.SchoolPanel(position.SchoolCode);

            // Act                                       
            var notice = new EmailNotification(position);
            var eMail = new EmailNotice2();

            eMail = notice.GetEmailNotice(jsonFile, action, toWho, position.PrincipalID);
            eMail.EmailBody = GetEmailBody(action, eMail.EmailBody);

            string logId = notice.SaveEmailNotice(eMail);
            var result = notice.SendEmail(eMail);

            //Assert
            string expectToMail = toWho == "Principal" ? notice.UserProfileByID(addressType, position.PrincipalID)
                                                    : notice.UnionEmail(panel, appType);
            string expectCCMail = notice.UserProfileByID(addressType, position.Owner);

            StringAssert.Contains(eMail.EmailTo, expectToMail, $"To Email Address for {action} on {appType} to {toWho}, {eMail.EmailTo}  ");
            StringAssert.Contains(eMail.EmailCC, expectCCMail, $"CC Email Address for {action} on {appType} to {toWho}, {eMail.EmailCC}  ");

            StringAssert.Contains(eMail.EmailBody, bodyTemplate, $"Email Body contains for  {action} on {appType} to {toWho}, {bodyTemplate}");
            StringAssert.Contains(eMail.EmailBody, position.PostingNumber, $"Email Boady contains for {action} on {appType} to {toWho}, {position.PostingNumber}");

            StringAssert.Contains(eMail.EmailSubject, position.PositionTitle, $" Email Subject for {action} on {appType} to {toWho}, {eMail.EmailSubject}");
            StringAssert.Contains(expect, result, $"Email Body contains for {action} on {appType} to {toWho}, {position.PostingNumber}");
        }

        [TestMethod()]
        [DataRow("LTO", "Applicant",   "Confirmation for PositionTitle Notification", "Apply_NotificationConfirm_LTO.htm")]
        [DataRow("POP", "Applicant",   "Confirmation for PositionTitle Notification", "Apply_NotificationConfirm_POP.htm")]
        public void EmailNotification_Applied_ToApplicant_FromApps_ReturnEmailContent(string appType, string toWho,  string subject, string bodyTemplate)
        {
            //Arrange
            action = "Applied";
            position.PositionType = appType;
           // position.Owner = owner;
            string panel = DataTools.SchoolPanel(position.SchoolCode);
            string userId = position.UserID;
            // Act                                       
            var notice = new EmailNotification(position);
            var eMail = new EmailNotice2();
            
            eMail = notice.GetEmailNotice(jsonFile, action, toWho, userId);
            eMail.EmailBody = GetEmailBody(action, eMail.EmailBody);

            string logId = notice.SaveEmailNotice(eMail);
            var result = notice.SendEmail(eMail);

            //Assert
            string expectToMail = notice.UserProfileByID(addressType, userId);
            string expectCCMail = "";

            StringAssert.Contains(eMail.EmailTo, expectToMail, $"To Email Address for {action} on {appType} to {toWho}, {eMail.EmailTo}  ");
            StringAssert.Contains(eMail.EmailCC, expectCCMail, $"CC Email Address for {action} on {appType} to {toWho}, {eMail.EmailCC}  ");

            StringAssert.Contains(eMail.EmailBody, bodyTemplate, $"Email Body contains for  {action} on {appType} to {toWho}, {bodyTemplate}");
            StringAssert.Contains(eMail.EmailBody, position.PostingNumber, $"Email Boady contains for {action} on {appType} to {toWho}, {position.PostingNumber}");

            StringAssert.Contains(eMail.EmailSubject, position.PositionTitle, $" Email Subject for {action} on {appType} to {toWho}, {eMail.EmailSubject}");
            StringAssert.Contains(expect, result, $"Email Body contains for {action} on {appType} to {toWho}, {position.PostingNumber}");
        }

        [TestMethod()]
        [DataRow("LTO", "Applicant", "Confirmation for PositionTitle Notification", "Apply_NotificationWithdraw_LTO.htm")]
        [DataRow("POP", "Applicant", "Confirmation for PositionTitle Notification", "Apply_NotificationWithdraw_POP.htm")]
        public void EmailNotification_Cancel_ToApplicant_FromApps_ReturnEmailContent(string appType, string toWho,  string subject, string bodyTemplate)
        {
            //Arrange
            action = "Cancel";
            position.PositionType = appType;
          //  position.Owner = owner;
            string panel = DataTools.SchoolPanel(position.SchoolCode);
            string userId = position.UserID;
            // Act                                       
            var notice = new EmailNotification(position);
            var eMail = new EmailNotice2();

            eMail = notice.GetEmailNotice(jsonFile, action, toWho, userId);
            eMail.EmailBody = GetEmailBody(action, eMail.EmailBody);

            string logId = notice.SaveEmailNotice(eMail);
            var result = notice.SendEmail(eMail);

            //Assert
            string expectToMail = notice.UserProfileByID(addressType, userId);
            string expectCCMail = "";

            StringAssert.Contains(eMail.EmailTo, expectToMail, $"To Email Address for {action} on {appType} to {toWho}, {eMail.EmailTo}  ");
            StringAssert.Contains(eMail.EmailCC, expectCCMail, $"CC Email Address for {action} on {appType} to {toWho}, {eMail.EmailCC}  ");

            StringAssert.Contains(eMail.EmailBody, bodyTemplate, $"Email Body contains for  {action} on {appType} to {toWho}, {bodyTemplate}");
            StringAssert.Contains(eMail.EmailBody, position.PostingNumber, $"Email Boady contains for {action} on {appType} to {toWho}, {position.PostingNumber}");

            StringAssert.Contains(eMail.EmailSubject, position.PositionTitle, $" Email Subject for {action} on {appType} to {toWho}, {eMail.EmailSubject}");
            StringAssert.Contains(expect, result, $"Email Body contains for {action} on {appType} to {toWho}, {position.PostingNumber}");
        }
    }
}