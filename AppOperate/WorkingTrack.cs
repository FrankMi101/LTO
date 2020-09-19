using ClassLibrary;
using System.Collections.Generic;

namespace AppOperate
{
    class WorkingTrack
    {
        public string UserID { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string SchoolCode { get; set; }
        public string SchoolYear { get; set; }
        public string Role { get; set; }
        public string TaskType { get; set; }
    }
    class LoginTrack
    {
        public string UserID { get; set; }
        public string LoginServer { get; set; }
        public string ScreenSize { get; set; }
        public string WorkRole { get; set; }
        public string WorkYear { get; set; }
        public string OnLine { get; set; }
        public string Browser { get; set; }
    }
    public class UserTrack
    {
        public static string SchoolProfile(string type, string schoolyear, string schoolcode)
        {
            string SP = "dbo.tcdsb_LTO_PageUser_SchoolProfile @SchoolYear, @SchoolCode, @Type";
            WorkingTrack wt = new WorkingTrack { SchoolYear = schoolyear, Type = type, SchoolCode = schoolcode };
            return CommonExcute<WorkingTrack>.GeneralValue(SP, wt);
        }
        public static string SchoolGeoProfile(string type, string schoolcode)
        {
            string SP = "dbo.tcdsb_LTO_PageUser_SchoolGeoProfile @Type, @SchoolCode";
            WorkingTrack wt = new WorkingTrack { Type = type, SchoolCode = schoolcode };
            return CommonExcute<WorkingTrack>.GeneralValue(SP, wt);
        }

        public static List<UserProfile> UserLastWorkingParameter(string userID)
        {
            string SP = "dbo.tcdsb_LTO_PageUser_Track @UserID, @Type";
            WorkingTrack wt = new WorkingTrack { UserID = userID, Type = "Allinfo" };
            return CommonExcute<UserProfile>.GeneralList(SP, wt);
        }
        public static string TrackInfo(string userID, string type)
        {
            string SP = "dbo.tcdsb_LTO_PageUser_Track @UserID, @Type";
            WorkingTrack wt = new WorkingTrack { UserID = userID, Type = type };
            return CommonExcute<WorkingTrack>.GeneralValue(SP, wt);
        }
        public static void TrackInfo(string userID, string type, string value)
        {
            string SP = "dbo.tcdsb_LTO_PageUser_Track @UserID, @Type, @Value";
            WorkingTrack wt = new WorkingTrack { UserID = userID, Type = type, Value = value };
            var result = CommonExcute<WorkingTrack>.GeneralValue(SP, wt);
        }
        public static string WorkingTask(string userID, string positionType, string schoolYear, string taskType)
        {
            string SP = "dbo.tcdsb_LTO_PageUser_TasksCount @UserID, @Type, @SchoolYear, @TaskType";
            WorkingTrack wt = new WorkingTrack { UserID = userID, Type = positionType, SchoolYear = schoolYear, TaskType = taskType };
            return CommonExcute<WorkingTrack>.GeneralValue(SP, wt);

        }
        public static void ActionTrack(string userID, string loginServer, string screenSize, string workRole, string workYear, string online, string browser)
        {

            string SP = "dbo.tcdsb_LTO_PageUser_LoginTrack @UserID, @LoginServer, @ScreenSize, @WorkRole, @WorkYear, @OnLine, @Browser ";
            LoginTrack lt = new LoginTrack { UserID = userID, LoginServer = loginServer, ScreenSize = screenSize, WorkRole = workRole, WorkYear = workYear, OnLine = online, Browser = browser };
            string result = CommonExcute<LoginTrack>.GeneralValue(SP, lt);
        }

    }



    public class ApplicantProfile
    {
        public static List<Applicant> ContactInfo(string userID, string cpNum)
        {

            string SP = "dbo.tcdsb_LTO_PageUser_ApplicantProfile @UserID, @CPNum";
            ApplicantNotice wt = new ApplicantNotice { UserID = userID, CPNum = cpNum };
            return CommonExcute<Applicant>.GeneralList(SP, wt);
        }
        public static void ContactInfo(string userID, string cpNum, string homePhone, string cellPhone, string eMail, string comments)
        {

            string SP = "dbo.tcdsb_LTO_PageUser_ApplicantProfile @UserID, @CPNum, @HomePhone, @CellPhone, @Email, @Comments";
            ApplicantNotice anotice = new ApplicantNotice { UserID = userID, CPNum = cpNum, HomePhone = homePhone, CellPhone = cellPhone, Email = eMail, Comments = comments };
            string result = CommonExcute<ApplicantNotice>.GeneralValue(SP, anotice);
        }



    }



}
