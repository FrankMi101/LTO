using ClassLibrary;
using DataAccess;
using DataAccess.Common;
using Microsoft.SqlServer.Server;
using System;
using System.IO;
using System.Net.Mail;
using System.Web.Configuration;

namespace AppOperate
{
    public class EmailNotification
    {
        public EmailNotification()
        { }
        public static string EmailHTMLBody(string eFile)
        {

            return JsonFileReader.JsonString(eFile);

        }
        public static string Subject(string JsonFile, string pType, string action)
        {
            return EmailSubjectAndTemple(JsonFile, pType, action).Subject; // JsonFileReader.GetSubject(JsonFile, pType, action);
        }
        public static string Subject(TextReader JsonFile, string pType, string action)
        {
            return EmailSubjectAndTemple(JsonFile, pType, action).Subject; // JsonFileReader.GetSubject(JsonFile, pType, action);
        }
        public static string Template(string JsonFile, string pType, string action)
        {
            return EmailSubjectAndTemple(JsonFile, pType, action).Template;  //JsonFileReader.GetTemplate(JsonFile, pType, action);
        }
        public static EmailTemplateItem EmailSubjectAndTemple(string JsonFile, string pType, string action)
        {
            return JsonFileReader.GetSubjectAndTemplate(JsonFile, pType, action);
        }
        public static EmailTemplateItem EmailSubjectAndTemple(TextReader JsonFile, string pType, string action)
        {
            return JsonFileReader.GetSubjectAndTemplate(JsonFile, pType, action);
        }

        public static string UnionEmail(string schoolCode, string appType)
        {
            if (DataTools.SchoolPanel(schoolCode) == "E")
                return WebConfigValue.getValuebyKey("eMail_UnionE");
            else
                return WebConfigValue.getValuebyKey("eMail_UnionS");
        }
        public static string CheckCCMailOwner(string mCC, string owner, string cUser)
        {

            if (owner == cUser)
            { mCC = AddMail2(mCC, UserProfileByID("TCDSBeMailAddress", cUser)); }
            else
            {
                mCC = AddMail2(mCC, UserProfileByID("TCDSBeMailAddress", cUser));
                mCC = AddMail2(mCC, UserProfileByID("TCDSBeMailAddress", owner));
            }

            mCC = mCC.Replace("; ;", ";");
            mCC = mCC.Replace(";;", ";");
            return mCC;
        }
        public static string CheckFromMail(string appType)
        {

            if (appType == "POP") return "POP.Admin@tcdsb.org";
            return "LTO.Admin@tcdsb.org";
        }
        public static string CheckMailSubject(string appType, string schoolCode, string subject, string title)
        {
            string panel = "";
            if (schoolCode.Substring(0, 2) == "05")
            {
                if (title.IndexOf("Secondary") < 0) panel = "Secondary";
            }
            else
            {
                if (title.IndexOf("Elementary") < 0) panel = "Elementary";
            }
            return subject.Replace("for PositionTitle", appType + " " + panel + " " + title);
            //appType = "LTO"/"POP"
            //appAction = "Hired"/ "Interview" / "Post"
            // mailAction = "Confirm" / "Revoke" / "Reject"

            //  return mailAction + " " + appType + " " + panel + " " + appAction  + " Notification";
            // return  "Confirm POP Secondary Teacher hired Notification"
        }
        public static string CheckCCMail(string mCC, string who, string actionType, string appType, string postingCycle, string title, string schoolCode)
        {     // actionType :  Posting / interview / ConfirmHire  / Request
              // appType :  LTO /POP
              // who: Union / Staff / Principal / Applicant
            string unioneMail = "eMail_UnionE";
            if (DataTools.SchoolPanel(schoolCode) == "S")
            { unioneMail = "eMail_UnionS"; }

            if (who == "Union")
            {
                mCC = AddMail(mCC, unioneMail);
                if (appType == "LTO")
                {
                    mCC = AddMail(mCC, "eMailCC_LTO");
                }
            }
            else
            {
                if (appType == "LTO")
                {
                    mCC = AddMail(mCC, "eMailCC_LTO");
                    if (actionType == "ConfirmHire")
                    {
                        mCC = AddMail(mCC, "eMailCC_ConfirmHire_LTO");

                        mCC = AddMail(mCC, "eMailCC_ConfirmHire_LTO_" + DataTools.SchoolPanel(schoolCode));
                    }
                }
                else
                {
                    mCC = AddMail(mCC, "eMailCC_POP");
                    if (actionType == "ConfirmHire")
                    {
                        mCC = AddMail(mCC, "eMailCC_ConfirmHire_POP");
                        mCC = AddMail(mCC, "eMailCC_ConfirmHire_POP_" + DataTools.SchoolPanel(schoolCode));
                    }
                    else
                    {
                        mCC = AddMail(mCC, "eMailCC_POP_" + DataTools.SchoolPanel(schoolCode));
                    }

                    mCC = AddMail(mCC, unioneMail);
                }

                if (title.IndexOf("French") != -1)
                {
                    mCC = AddMail(mCC, "eMailCC_French");
                    mCC = AddMail(mCC, "eMailCC_French1");
                    mCC = AddMail(mCC, "eMailCC_French_" + DataTools.SchoolPanel(schoolCode));
                }

                if (title.IndexOf("FSL") != -1)
                {
                    mCC = AddMail(mCC, "eMailCC_French");
                    mCC = AddMail(mCC, "eMailCC_French1");
                    mCC = AddMail(mCC, "eMailCC_French_" + DataTools.SchoolPanel(schoolCode));
                }
                if (title.IndexOf("Music") != -1) mCC = AddMail(mCC, "eMailCC_Music");
                if (title.IndexOf("Deaf/Hard") != -1) mCC = AddMail(mCC, "eMailCC_DHH");
                if (title.IndexOf("Deaf and Hard") != -1) mCC = AddMail(mCC, "eMailCC_DHH");
                if (postingCycle == "4")
                {
                    mCC = AddMail(mCC, "eMailCC_4th");
                    if (appType == "LTO")
                    {
                        mCC = AddMail(mCC, "eMailCC_4th_" + DataTools.SchoolPanel(schoolCode));
                    }
                }
            }

            mCC = mCC.Replace("; ;", ";");
            mCC = mCC.Replace(";;", ";");
            return mCC;
        }
        private static string AddMail(string mCC, string checkMail)
        {
            string addM = WebConfigValue.getValuebyKey(checkMail);
            return AddMail2(mCC, addM);
        }
        private static string AddMail2(string mCC, string addM)
        {
            try
            {
                if (mCC.Contains(addM)) return mCC;

                if (addM.Length > 5) return mCC.Length > 5 ? mCC + ";" + addM : addM;

                return mCC;

            }
            catch (Exception)
            {
                return mCC;
            }
        }
        public static string UserProfileByID(string type, string userID)
        {
            try
            {
                string sp = "dbo.tcdsb_LTO_GetUserProfilebyUserID @UserID,@Type";
                ParameterCL parameter = new ParameterCL { UserID = userID, Type = type };
                string result = GeneralDataAccess.TextValue(sp, parameter);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "";
            }
        }
        public static string OfficeUserProfile(string type, string getBy, string byValue)
        {
            try
            {
                string sp = "dbo.tcdsb_LTO_getOfficerProfile @Type, @GetBy, @ByValue";
                ParameterProfile parameter = new ParameterProfile { GetBy = getBy, Type = type, ByValue = byValue };
                string result = GeneralDataAccess.TextValue(sp, parameter);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "";
            }
        }
        public static string GetMultipleSchoolEmail(string schoolYear, string schoolCode, int positionID)
        {
            try
            {
                String sp = "dbo.tcdsb_LTO_PositionNoticeToPrincipal_multipSchool @SchoolYear,@SchoolCode,@PositionID";
                ParameterCL parameter = new ParameterCL { SchoolYear = schoolYear, SchoolCode = schoolCode, PositionID = positionID };
                string result = GeneralDataAccess.TextValue(sp, parameter);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "";
            }


        }
        public static string SaveEmailNotice(EmailNotice2 mailItems)
        {
            try
            {
                //  String sp = "dbo.tcdsb_LTO_ConfirmForHir_Log2 @UserID,@SchoolYear,@SchoolCode,@PositionType, @PositionID, @PositionTitle, @PostingNum, @NoticePrincipal, @EmailType,@EmailTo, @EmailCC, @EmailFrom, @EmailSubject, @EmailBody";
                string sp = "dbo.tcdsb_LTO_EmailNotificaiton_Log @UserID,@SchoolYear,@SchoolCode,@PositionType, @PositionID, @PositionTitle, @PostingNum, @NoticePrincipal, @NoticeFor,@EmailType,@EmailTo, @EmailCC, @EmailFrom, @EmailSubject, @EmailBody";
                string result = GeneralDataAccess.TextValue(sp, mailItems);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }

        }
        public static string SendEmail(EmailNotice2 mailItems)
        {
            string result = "Failed";

            var eMailTo = mailItems.EmailTo;
            var eMailCC = mailItems.EmailCC;
            var eMailBcc = mailItems.EmailBcc;
            var eMailBody = CheckTestBody(mailItems.EmailBody, eMailTo, eMailCC, eMailBcc);
            if (eMailTo != "")
            {
                System.Net.Mail.SmtpClient myMail = new System.Net.Mail.SmtpClient();
                myMail.Host = WebConfigurationManager.AppSettings["SMTPServer"];

                System.Net.Mail.MailMessage Mailmsg = new System.Net.Mail.MailMessage();
                try
                {
                    if (WebConfigValue.eMailGo() == "Test" || WebConfigValue.eMailGo() == "Attack")
                    {

                        eMailTo = $"{mailItems.UserID}@tcdsb.org"; // userID + "@tcdsb.org";
                        eMailCC = "frank.mi@tcdsb.org";
                        eMailBcc = "";
                    }

                    Mailmsg = GetEmailMsg(eMailTo, eMailCC, eMailBcc, eMailBody, mailItems);
                    myMail.Send(Mailmsg);

                    result = "Successfully";
                }
                catch (Exception ex)
                {
                    var em = ex.Message;
                    result = "SMTP Server Failed";

                }
                Mailmsg.Dispose();

            }
            else
            {
                result = "No Email Recieve";
            }

            return result;
            //   NotificationeMail("Save", userID, schoolyear, schoolcode, employeeID, noticeType, noticeDate, deadlineDate, deadlineDate, eMailSubject, eMailBody);
            // string result = AssemblingeMail(eMailTo, eMailCC, eMailBcc, mailItems.EmailFrom, mailItems.EmailSubject, eMailBody, mailItems.EmailFormat);

        }

        private static string CheckTestBody(string eMailBody, string eMailTo, string eMailCC, string eMailBcc)
        {
            if (WebConfigValue.eMailGo() == "Test" || WebConfigValue.eMailGo() == "Attack")
            {
                eMailBody = eMailBody.Replace("{{EmailTOSTR}}", "Email To: " + eMailTo);
                eMailBody = eMailBody.Replace("{{EmailCCSTR}}", "Email CC: " + eMailCC);
                eMailBody = eMailBody.Replace("{{EmailBCCSTR}}", "Email BCC: " + eMailBcc);
                eMailBody = eMailBody.Replace("[EmailTOSTR]", "Email To: " + eMailTo);
                eMailBody = eMailBody.Replace("[EmailCCSTR]", "Email CC: " + eMailCC);
                eMailBody = eMailBody.Replace("[EmailBCCSTR]", "Email BCC: " + eMailBcc);

            }
            else
            {
                eMailBody = eMailBody.Replace("[EmailTOSTR]", "");
                eMailBody = eMailBody.Replace("[EmailCCSTR]", "");
                eMailBody = eMailBody.Replace("[EmailBCCSTR]", "");
                eMailBody = eMailBody.Replace("{{EmailTOSTR}}", "");
                eMailBody = eMailBody.Replace("{{EmailCCSTR}}", "");
                eMailBody = eMailBody.Replace("{{EmailBCCSTR}}", "");
            }

            return eMailBody;

        }


        public static string SendEmail(EmailNotice2 mailItems, System.Net.Mail.Attachment iCal)
        {
            try
            {
                SendEmail(mailItems);
                // string result = AssemblingeMail(eMailTo, eMailCC, eMailBcc, eMailForm, eMailSubject, eMailBody, eMailFormat, iCal);
                return "Successfully";
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return "Failed";
            }

        }


        private static System.Net.Mail.MailMessage GetEmailMsg(string eMailTo, string eMailCC, string eMailBcc, string eMailBody, EmailNotice2 mailItems)
        {
            try
            {
                //  System.Net.Mail.SmtpClient myMail = new System.Net.Mail.SmtpClient();
                //   myMail.Host = WebConfigurationManager.AppSettings["SMTPServer"];

                System.Net.Mail.MailMessage Mailmsg = new System.Net.Mail.MailMessage();
                Mailmsg.To.Clear();
                LoopAddress("mailTo", eMailTo, ref Mailmsg);
                LoopAddress("mailCC", eMailCC, ref Mailmsg);
                LoopAddress("mailBcc", eMailBcc, ref Mailmsg);
                LoopAddress("mailFrom", mailItems.EmailFrom, ref Mailmsg);


                Mailmsg.Subject = mailItems.EmailSubject;
                Mailmsg.Priority = MailPriority.High;
                if (mailItems.EmailFormat == "HTML")
                { Mailmsg.IsBodyHtml = true; }
                Mailmsg.Body = eMailBody;

                if (!string.IsNullOrEmpty(mailItems.Attachment1)) AddAttachments(mailItems.Attachment1, ref Mailmsg);
                if (!string.IsNullOrEmpty(mailItems.Attachment2)) AddAttachments(mailItems.Attachment2, ref Mailmsg);
                if (!string.IsNullOrEmpty(mailItems.Attachment3)) AddAttachments(mailItems.Attachment3, ref Mailmsg);
                return Mailmsg;

            }
            catch
            {
                return null;
            }
        }
        private static System.Net.Mail.MailMessage GetEmailMsg(string eMailTo, string eMailCC, string eMailBcc, string eMailForm, string eMailSubject, string eMailBody, string eMailFormat, string attachement1, string attachement2, string attachement3)
        {

            try
            {
                //  System.Net.Mail.SmtpClient myMail = new System.Net.Mail.SmtpClient();
                //   myMail.Host = WebConfigurationManager.AppSettings["SMTPServer"];

                System.Net.Mail.MailMessage Mailmsg = new System.Net.Mail.MailMessage();
                Mailmsg.To.Clear();
                LoopAddress("mailTo", eMailTo, ref Mailmsg);
                LoopAddress("mailCC", eMailCC, ref Mailmsg);
                LoopAddress("mailBcc", eMailBcc, ref Mailmsg);
                LoopAddress("mailFrom", eMailForm, ref Mailmsg);


                Mailmsg.Subject = eMailSubject;
                Mailmsg.Priority = MailPriority.High;
                if (eMailFormat == "HTML")
                { Mailmsg.IsBodyHtml = true; }
                Mailmsg.Body = eMailBody;

                if (!string.IsNullOrEmpty(attachement1)) AddAttachments(attachement1, ref Mailmsg);
                if (!string.IsNullOrEmpty(attachement2)) AddAttachments(attachement2, ref Mailmsg);
                if (!string.IsNullOrEmpty(attachement3)) AddAttachments(attachement3, ref Mailmsg);
                return Mailmsg;

            }
            catch
            {
                return null;
            }

        }
        private static void AddAttachments(string atta, ref System.Net.Mail.MailMessage Mailmsg)
        {
            try
            {
                System.Net.Mail.Attachment myAttachment = new System.Net.Mail.Attachment(atta);
                Mailmsg.Attachments.Add(myAttachment);
            }
            catch
            {
            }
        }

        private static void LoopAddress(string Type, string eMailADD, ref System.Net.Mail.MailMessage Mailmsg)
        {
            try
            {
                if (eMailADD.IndexOf("@") > 0)
                {
                    string[] myArray = eMailADD.Split(';');
                    for (int x = 0; x < myArray.Length; x++)
                    {
                        try
                        {
                            AddAddress(Type, myArray[x], ref Mailmsg);
                        }
                        catch
                        { }
                    }
                }
            }
            catch
            { }

        }
        private static void AddAddress(string addType, string eMailAdd, ref System.Net.Mail.MailMessage mailmsg)
        {
            try
            {
                if (eMailAdd.Contains("@")) // (eMailAdd.IndexOf("@") > 0)
                {

                    switch (addType)
                    {
                        case "mailTo":
                            mailmsg.To.Add(new System.Net.Mail.MailAddress(eMailAdd));
                            break;
                        case "mailCC":
                            mailmsg.CC.Add(new System.Net.Mail.MailAddress(eMailAdd));
                            break;
                        case "mailBcc":
                            mailmsg.Bcc.Add(new System.Net.Mail.MailAddress(eMailAdd));
                            break;
                        default:
                            mailmsg.From = new System.Net.Mail.MailAddress(eMailAdd);
                            break;
                    }
                }

            }
            catch { }

        }


    }
}
