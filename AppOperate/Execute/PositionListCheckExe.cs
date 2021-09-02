using ClassLibrary;
using System.Collections.Generic;
using System.Linq;
namespace AppOperate
{
    public class PositionListCheckExe
    {
        public PositionListCheckExe()
        {
        }
        public static string SpName(string action)
        {
            return GetSp(action);
        }
        public static List<PositionListPublish> PublishPositions(object parameter)
        {
            string sp = GetSp("PublishPositions");
            return CommonExcute<PositionListPublish>.GeneralList(sp, parameter);
        }
        public static List<PositionListHired> HiredPositions(object parameter)
        {
            string sp = GetSp("HiredPositions");
            return CommonExcute<PositionListHired>.GeneralList(sp, parameter);
        }
        public static List<PositionListApplying> AvailablePositions(object parameter)
        {
            string sp = GetSp("AvailablePositions");
            return CommonExcute<PositionListApplying>.GeneralList(sp, parameter);
        }
        public static List<PositionListPublish> SelectPositions(object parameter)
        {
            string sp = GetSp("SelectPositions");
            return CommonExcute<PositionListPublish>.GeneralList(sp, parameter);
        }

        public static List<PositionListPublish> InterviewPositions(object parameter)
        {
            string sp = GetSp("InterviewPositions");
            return CommonExcute<PositionListPublish>.GeneralList(sp, parameter);
        }

        public static List<ApplicantListSelect> SelectCandidates(object parameter)
        {
            string sp = GetSp("SelectCandidates");
            return CommonExcute<ApplicantListSelect>.GeneralList(sp, parameter);
        }
        public static List<CandidateList> InterviewCandidates(object parameter)
        {
            string sp = GetSp("InterviewCandidates");
            return CommonExcute<CandidateList>.GeneralList(sp, parameter);
        }
        public static List<GeneralCheck> ConvertFunctionStringToTable(object parameter)
        {
            string sp = GetSp("ConvertFunction");
            return CommonExcute<GeneralCheck>.GeneralList(sp, parameter);
        }
        public static string ConvertFunctionTableToString(object parameter)
        {
            string sp = GetSp("ConvertFunction");
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

            string paraPositions = " @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy,@SearchValue1,@SearchValue2";

            switch (action)
            {
                case "PublishPositions":
                    return "dbo.tcdsb_LTO_PagePublish_Positions_Check" + paraPositions;
                case "HiredPositions":
                    return "dbo.tcdsb_LTO_PageHired_Positions_Check" + paraPositions;
                case "AvailablePositions":
                    return "dbo.tcdsb_LTO_PageApply_AvailablePositions_Check " + "@Operate,@UserID,@SchoolYear,@PositionType,@SearchBy,@SearchValue1,@UserRole,@CPNum";
                case "InterviewPositions":
                    return "dbo.tcdsb_LTO_PageInterview_Positions_Check" + " @Operate,@UserID,@SchoolYear,@SchoolCode,@SearchValue1";
                case "InterviewCandidates":
                    return "dbo.tcdsb_LTO_PageInterview_Candidates_Check" + " @SchoolYear,@PositionID";
                case "SelectCandidates":
                    return "dbo.tcdsb_LTO_PageSelectInterviewCandidate_Applicants_Check" +  " @Operate,@SchoolYear,@PositionID";
                case "SelectPositions":
                    return "dbo.tcdsb_LTO_PageSelectInterviewCandidate_Positions_check" + paraPositions;
                case "ConvertFunction":
                    return "dbo.tcdsb_LTO_PageGeneral_ConvertFunction_Check" + " @Operate,@StringValue,@Delimiter,@TableName,@CheckType";
                default:
                    return action;

            }

        }
        private static string GetSpFromJsonFile(string action)
        {
            return GetSpNameFormJsonFile.SPName(action, "Publish");
        }
    }
}
