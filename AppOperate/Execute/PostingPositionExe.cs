using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public class PostingPositionExe
    {
      
        public static string SPName(string action)
        {
            return GetSP(action);
        }
        public static List<PositionListApprove> Positions(object parameter)
        {
            return CommonExcute<PositionListApprove>.GeneralList(GetSP("Positions"), parameter);
        }
        public static List<PositionApprove> Position(object parameter)
        {
            return CommonExcute<PositionApprove>.GeneralList(GetSP("Position"), parameter);
        }
  
        public static string Save(object parameter)
        {
            return CommonExcute<string>.GeneralValue(GetSP("Save"), parameter);
        }
        public static string Update(object parameter)
        {
            return CommonExcute<string>.GeneralValue(GetSP("Save"), parameter);
        }
        public static string Reject(object parameter)
        {
             return CommonExcute<string>.GeneralValue(GetSP("Reject"), parameter);
        }
        public static string Posting(object parameter)
        {
             return CommonExcute<string>.GeneralValue(GetSP("Posting"), parameter);
        }
        public static string PostingNumber(object parameter)
        {
             return CommonExcute<string>.GeneralValue(GetSP("PostingNumber"), parameter);
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
            string parameters = " @Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID,@Comments";
            string parameter2 = ",@CPNum,@StartDate,@EndDate,@DatePublish,@DateApplyOpen,@DateApplyClose,@RequestSource";
            string parameter3 = ",@PositionLevel,@Qualification,@QualificationCode,@Description,@FTE,@FTEPanel,@StartDate,@EndDate,@Owner,@ReplaceTeacherID";
            string ParaPosition = " @SchoolYear,@PositionID";
            string ParaPositions = " @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy,@SearchValue1,@SearchValue2";

            switch (action)
            {
                case "Position":
                    return "dbo.tcdsb_LTO_PageApprove_Position" + ParaPosition;
                case "Positions":
                    return "dbo.tcdsb_LTO_PageApprove_Positions" + ParaPositions;
                case "Reject":
                    return "dbo.tcdsb_LTO_PageApprove_OperationReject" + parameters + ",@CPNum";
                case "Posting":
                    return "dbo.tcdsb_LTO_PageApprove_OperationPosting" + parameters + parameter2;
                case "Save":
                    return "dbo.tcdsb_LTO_PageApprove_OperationSave" + parameters + parameter3;
                case "PostingNumber":
                    return "dbo.tcdsb_LTO_PageApprove_PostingNumber @Operate,@PositionID";
                default:
                    return action;

            }
        }
        private static string GetSPFromJsonFile(string action)
        { 
            return GetSpNameFormJsonFile.SPName(action, "Approve");
        }
    }
}