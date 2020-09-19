using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public class PostingSummaryExe
    {
        public PostingSummaryExe()
        {
        }

        public static string SPName(string action)
        {
            return GetSP(action);
        }
        public static List<PositionListPublish> Positions(object parameter)
        {
            string SP = GetSP("Positions");
            return CommonExcute<PositionListPublish>.GeneralList(SP, parameter);
        }
        public static List<PositionListApplied> AppliedPositions(object parameter)
        {
            string SP = GetSP("AppliedHistory");
            return CommonExcute<PositionListApplied>.GeneralList(SP, parameter);
        }
        public static List<PositionPublish> Position(object parameter)
        {
            string SP = GetSP("Position");
            return CommonExcute<PositionPublish>.GeneralList(SP, parameter);
        }
        public static List<ApplicantList> ApplicantApplied(object parameter)
        {
            string SP = GetSP("ApplicantApplied");
            return CommonExcute<ApplicantList>.GeneralList(SP, parameter);
        }
        public static List<PositionPublish> ApplicantEmail(object parameter)
        {
            string SP = GetSP("ApplicantEmail");
            return CommonExcute<PositionPublish>.GeneralList(SP, parameter);
        }
        public static List<PositionInterview> ApplicantInterview(object parameter)
        {
            string SP = GetSP("ApplicantInterview");
            return CommonExcute<PositionInterview>.GeneralList(SP, parameter);
        }
        public static List<PositionPublish> PostingRounds(object parameter)
        {
            string SP = GetSP("PostingRounds");
            return CommonExcute<PositionPublish>.GeneralList(SP, parameter);
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

            string ParaPosition = " @SchoolYear, @PositionID";
            string ParaPositions = " @UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy,@SearchValue1,@SearchValue2";

            switch (action)
            {
                case "Positions":
                    return "dbo.tcdsb_LTO_PageSummary_Positions" + ParaPositions;
                case "Position":
                    return "dbo.tcdsb_LTO_PageSummary_Position" + ParaPosition;
                case "AppliedPositions":
                    return "dbo.tcdsb_LTO_PageSummary_AppliedHistory" + ParaPositions;
                case "AppliedHistory":
                    return "dbo.tcdsb_LTO_PageSummary_AppliedHistory" + " @UserID,@SchoolYear,@PositionType,@CPNum";
                case "ApplicantApplied":
                    return "dbo.tcdsb_LTO_PageSummary_ApplicantApplied" + " @SchoolYear,@PositionID";
                case "ApplicantEmail":
                    return "dbo.tcdsb_LTO_PageSummary_ApplicantEmail" + " @SchoolYear,@PositionID";
                case "ApplicantInterview":
                    return "dbo.tcdsb_LTO_PageSummary_ApplicantInterview" + " @SchoolYear,@PositionID";
                case "PostingRounds":
                    return "dbo.tcdsb_LTO_PagePublish_PostingRounds" + " @SchoolYear, @PositionID";

                default:
                    return action;

            }
        }
        private static string GetSPFromJsonFile(string action)
        {
            string JsonFile = SPSource.SPFile;
            DataSourceItemList myspname = JsonFileReader<DataSourceItemList>.GetSP_fromList(JsonFile);
            var mylist = from p in myspname.Summary
                         where p.Action == action
                         select p.ObjName.ToString() + p.Parameters.ToString();
           return mylist.FirstOrDefault();
         //   return GetSpNameFormJsonFile.SPName(action, "Summary");
        }
    }
}
