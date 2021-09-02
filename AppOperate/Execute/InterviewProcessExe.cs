using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppOperate.Execute;

namespace AppOperate
{
    public class InterviewProcessExe
    {
        public InterviewProcessExe()
        {
        }
        public static string SPName(string action)
        {
            return GetSp(action);
        }
        public static List<PositionListInterview> Positions(object parameter)
        {
            string sp = GetSp("Positions");
            return CommonExcute<PositionListInterview>.GeneralList(sp, parameter);
        }
        public static List<PositionInterview> Position(object parameter)
        {
            string sp = GetSp("Position");
            return CommonExcute<PositionInterview>.GeneralList(sp, parameter);
        }
        public static List<CandidateList> Candidates(object parameter)
        {
            string sp = GetSp("Candidates");
            return CommonExcute<CandidateList>.GeneralList(sp, parameter);
        }
        public static List<PositionInterview> Candidate(object parameter)
        {
            string sp = GetSp("Candidate");
            return CommonExcute<PositionInterview>.GeneralList(sp, parameter);
        }
        public static List<InterviewerTeam> TeamMember(object parameter)
        {
            string sp = GetSp("TeamMember");
            return CommonExcute<InterviewerTeam>.GeneralList(sp, parameter);
        }
        public static List<InterviewerTeam> Signatures(object parameter)
        {
            string sp = GetSp("Signatures");
            return CommonExcute<InterviewerTeam>.GeneralList(sp, parameter);
        }
        
        public static string UpdateMember(object parameter)
        {
            string sp = GetSp("UpdateMember");
            return CommonExcute<string>.GeneralValue(sp, parameter);
        }

        public static string Update(object parameter)
        {
            string sp = GetSp("Update");
            return CommonExcute<string>.GeneralValue(sp, parameter);
        }
       
        public static string Recommend(object parameter)
        {
            string sp = GetSp("Recommend");
            return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string OutcomeUpdate(object parameter)
        {
            string sp = GetSp("OutcomeUpdate");
            return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string PositionHiringStatus(object parameter)
        {
            string sp = GetSp("PositionHiringStatus");
            return CommonExcute<string>.GeneralValue(sp, parameter);
        }

        public static string SignOffCount(object parameter)
        {
            string sp = GetSp("SignOffCount");
            return CommonExcute<string>.GeneralValue(sp, parameter);
        }

        public static string InterviewCount(object parameter)
        {
            string sp = GetSp("InterviewCount");
            return CommonExcute<string>.GeneralValue(sp, parameter);
        }

        public static string SignOffAction(object parameter)
        {
            string sp = GetSp("SignOffAction");
            return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string SendNoticeToPrincipal(object parameter)
        {
            string sp = GetSp("SendNoticeToPrincipal");
            return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string SignatureName(object parameter)
        {
            string sp = GetSp("SignatureName");
            return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string RequestMoreInterview(object parameter)
        {
            string sp = GetSp("RequestMoreInterview");
            return CommonExcute<string>.GeneralValue(sp, parameter);
        }


        private static string GetSp(string action)
        {
            if (SPSource.SPFile == "")
            { return GetSpInClass(action); }
            else
            { return GetSpFromJsonFile(action); }

        }
        private static string GetSpInClass(string action)
        {
            string parameter = " @Operate, @UserID, @SchoolYear, @PositionID";
            string parameters = parameter + ", @CPNum";
            switch (action)
            {
                case "Candidate":
                    return "dbo.tcdsb_LTO_PageInterview_Candidate" + " @SchoolYear,@PositionID,@CPNum";
                case "Candidates":
                    return "dbo.tcdsb_LTO_PageInterview_Candidates" + " @SchoolYear, @PositionID";
                case "Positions":
                    return "tcdsb_LTO_PageInterview_Positions" + " @Operate, @UserID, @SchoolYear,@SchoolCode,@SearchValue1";
                case "Position":
                    return "tcdsb_LTO_PageInterview_Position" + " @Operate, @UserID, @SchoolYear,@PositionID";
                case "Update":
                    return "dbo.tcdsb_LTO_PageInterview_Operation" + parameters + ", @Recommendation, @InterviewDate, @EffectiveDate, @OutCome, @Acceptance";
                case "Recommend":
                    return "dbo.tcdsb_LTO_PageInterview_Operation" + parameters + ", @Recommendation, @InterviewDate, @EffectiveDate, @OutCome, @Acceptance";
                case "PositionHiringStatus":
                    return "dbo.tcdsb_LTO_PageInterview_OperationCheck" + parameters;
                case "SignOffCount":
                    return "dbo.tcdsb_LTO_PageInterview_OperationCheck" + parameters;
                case "InterviewCount":
                    return "dbo.tcdsb_LTO_PageInterview_OperationCheck" + parameters;
                case "SignOffAction":
                    return "dbo.tcdsb_LTO_PageInterview_SignOff" + parameters;
                case "RequestMoreInterview":
                    return "dbo.tcdsb_LTO_PageInterview_OperationNotice" + parameter + ", @NoticeDate, @PrincipalID, @RequestCount";
                case "SendNoticeToPrincipal":
                    return "dbo.tcdsb_LTO_PageInterview_OperationNotice" + parameter + ", @NoticeDate, @PrincipalID";
                case "MultipSchoolPrincipal":
                    return "dbo.tcdsb_LTO_PageInterview_NoticePrincipal" + parameter + ", @SchoolCode";
                case "ActingPrincipal":
                    return "dbo.tcdsb_LTO_PageInterview_NoticePrincipal" + parameter + ", @SchoolCode";
                case "TeamMembers":
                    return "dbo.tcdsb_LTO_PageInterview_Team" + parameter;
                case "UpdateMember":
                    return "dbo.tcdsb_LTO_PageInterview_Team" + parameter + ",@Sequesc,@MemberID";
                case "Signatures":
                    return "dbo.tcdsb_LTO_PageInterview_Signature" + " @SchoolYear,@PositionID,@CPNum";
                case "SignatureName":
                    return "dbo.tcdsb_LTO_PageInterview_Signature" + " @SchoolYear,@PositionID,@CPNum,@signature,@SignatureID";
                case "OutcomeUpdate":
                    return "dbo.tcdsb_LTO_PageInterview_OutcomeUpdate" + parameters + ",@Outcome";
                default:
                    return "";

            }

        }
        private static string GetSpFromJsonFile(string action)
        {
           
            return GetSpNameFormJsonFile.SPName(action, "Interview");
        }
    }

}
