using ClassLibrary;
using System.Collections.Generic;
using System.Linq;

namespace AppOperate
{
    public class SelectCandidateExe
    {
        public SelectCandidateExe() { }
        public static string SPName(string action)
        {
            return GetSP(action);
        }
        public static List<PositionListPublished> Positions(object parameter)
        {
            string SP = GetSP("Positions");
            return CommonExcute<PositionListPublished>.GeneralList(SP, parameter);
        }
        public static List<PositionPublished> Position(object parameter)
        {
            string SP = GetSP("Position");
            return CommonExcute<PositionPublished>.GeneralList(SP, parameter);
        }
        public static List<ApplicantListSelect> Applicants(object parameter)
        {
            string SP = GetSP("Applicants");
            return CommonExcute<ApplicantListSelect>.GeneralList(SP, parameter);
        }
        public static List<ApplicantInterview> Applicant(object parameter)
        {
            string SP = GetSP("Applicant");
            return CommonExcute<ApplicantInterview>.GeneralList(SP, parameter);
        }
        public static List<CandidateListNotice> NoticeCandidates(object parameter)
        {
            string SP = GetSP("NoticeCandidates");
            return CommonExcute<CandidateListNotice>.GeneralList(SP, parameter);
        }
        public static string Save(object parameter)
        {
            string SP = GetSP("Save");
            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string NoticeUpdate(object parameter)
        {
            string SP = GetSP("NoticeUpdate");
            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string SelectedForInterview(object parameter)
        {
            string SP = GetSP("SelectedForInterview");
            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string Selected(object parameter)
        {
            string SP = GetSP("Selected");
            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string UnSelected(object parameter)
        {
            string SP = GetSP("UnSelected");
            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        private static string GetSP(string action)
        {
            if (SPSource.SPFile == "")
            { return GetSPInClass(action); }
            else
            { return GetSPFromJsonFile(action); }

        }
        private static string GetSPInClass(string action)
        {
            string parameter = " @Operate, @UserID, @SchoolYear, @PositionID";
            string parameters = parameter + ", @CPNum";
            string ParaPositions = " @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
            string parameter2 = " @UserID, @SchoolYear, @PositionID, @CPNum, @Action";
            switch (action)
            {

                case "Positions":
                    return "dbo.tcdsb_LTO_PageCandidate_Positions" + ParaPositions;
                case "Position":
                    return "dbo.tcdsb_LTO_PagePublish_Position" + " @SchoolYear, @PositionID";
                case "NoticeCandidates":
                    return "dbo.tcdsb_LTO_PageCandidate_NoticeCandidates" + " @Operate, @SchoolYear,@PositionID,@PositionType";
                case "NoticeUpdate":
                    return "dbo.tcdsb_LTO_PageCandidate_NoticeUpdate" + parameter + ",@PrincipalID, @RequestCount";
                case "Applicants":
                    return "dbo.tcdsb_LTO_PageCandidate_Applicants" + " @Operate,@SchoolYear, @PositionID"; 
                case "Applicant":
                    return "dbo.tcdsb_LTO_PageCandidate_Applicant" + " @SchoolYear, @PositionID, @CPNum";
                case "Update":
                    return "dbo.tcdsb_LTO_PageCandidate_Operation" + parameter2;
                case "Save":
                    return "dbo.tcdsb_LTO_PageCandidate_Operation" + parameter2;
                case "SelectedForInterview":
                    return "dbo.tcdsb_LTO_PageCandidate_SelectedForInterview" + " @SchoolYear, @PositionID";
                case "Selected":
                    return "dbo.tcdsb_LTO_PageCandidate_Select" + parameter2;
                case "UnSelected":
                    return "dbo.tcdsb_LTO_PageCandidate_Select" + parameter2;

                default:
                    return action;
            }
        }
        private static string GetSPFromJsonFile(string action)
        {
    
            return GetSpNameFormJsonFile.SPName(action, "SelectCandidate");
        }
    }
}

