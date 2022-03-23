using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PositionsCheck : PostingBase, IPositionsCheck
    {
        public PositionsCheck() : base()
        {
        }
        public PositionsCheck(string dataSource) : base(dataSource)
        {
        }
        public override string SpName(string action, object parameter)
        {
            if (SPSource.SPFile == "") return GetspNameAndParameter(action, parameter);

            return GetSPFromJSonFile.SPandParameter(SPSource.SPFile, "Applicant", action);
        }

        private string GetspNameAndParameter(string action, object parameter)
        {
            bool IsAnonymous = parameter.GetType().FullName.Contains("AnonymousType");
            string sp = GetspName(action);
            if (IsAnonymous)
                return sp;
            else
            {
                string para = GetParameters(action);
                if (para.Length > 1) return sp + " " + para;

                return sp;
            }
        }
        private string GetspName(string action)
        {

            switch (action)
            {
                case "PublishPositions":
                    return "dbo.tcdsb_LTO_PagePublish_Positions_Check";
                case "HiredPositions":
                    return "dbo.tcdsb_LTO_PageHired_Positions_Check";
                case "AvailablePositions":
                    return "dbo.tcdsb_LTO_PageApply_AvailablePositions_Check";
                case "InterviewPositions":
                    return "dbo.tcdsb_LTO_PageInterview_Positions_Check";
                case "InterviewCandidates":
                    return "dbo.tcdsb_LTO_PageInterview_Candidates_Check";
                case "SelectCandidates":
                    return "dbo.tcdsb_LTO_PageSelectInterviewCandidate_Applicants_Check";
                case "SelectPositions":
                    return "dbo.tcdsb_LTO_PageSelectInterviewCandidate_Positions_check";
                case "ConvertFunction":
                    return "dbo.tcdsb_LTO_PageGeneral_ConvertFunction_Check";
                default:
                    return action;

            }
        }
        private string GetParameters(string action)
        {
            string paraPositions = "@Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy,@SearchValue1,@SearchValue2";

            switch (action)
            {
                case "PublishPositions":        return paraPositions;
                case "HiredPositions":          return paraPositions;
                case "AvailablePositions":      return "@Operate,@UserID,@SchoolYear,@PositionType,@SearchBy,@SearchValue1,@UserRole,@CPNum";
                case "InterviewPositions":      return "@Operate,@UserID,@SchoolYear,@SchoolCode,@SearchValue1";
                case "InterviewCandidates":     return "@SchoolYear,@PositionID";
                case "SelectCandidates":        return "@Operate,@SchoolYear,@PositionID";
                case "SelectPositions":         return paraPositions;
                case "ConvertFunction":         return "@Operate,@StringValue,@Delimiter,@TableName,@CheckType";
                default:                        return action;
            }
        }
    }
}
