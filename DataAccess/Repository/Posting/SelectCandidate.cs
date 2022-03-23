using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class SelectCandidate : PostingBase, ISelectCandidate
    {
        public SelectCandidate() : base()
        {
        }

        public SelectCandidate(string dataSource) : base(dataSource)
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
               case "Positions":
                    return "dbo.tcdsb_LTO_PageCandidate_Positions";
                case "Position":
                    return "dbo.tcdsb_LTO_PagePublish_Position";
                case "NoticeCandidates":
                    return "dbo.tcdsb_LTO_PageCandidate_NoticeCandidates";
                case "NoticeUpdate":
                    return "dbo.tcdsb_LTO_PageCandidate_NoticeUpdate";
                case "Applicants":
                    return "dbo.tcdsb_LTO_PageCandidate_Applicants";
                case "Applicant":
                    return "dbo.tcdsb_LTO_PageCandidate_Applicant";
                case "Update":
                case "Save":
                    return "dbo.tcdsb_LTO_PageCandidate_Operation";
                case "SelectedForInterview":
                    return "dbo.tcdsb_LTO_PageCandidate_SelectedForInterview";
                case "Selected":
                case "UnSelected":
                    return "dbo.tcdsb_LTO_PageCandidate_Select";

                default:
                    return action;
            }
        }
        private string GetParameters(string action )
        {
            string parameter = "@Operate, @UserID, @SchoolYear, @PositionID";
            string Search = "@Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
            string parameter2 = "@UserID, @SchoolYear, @PositionID, @CPNum, @Action";
            switch (action)
            {

                case "Positions":               return Search;
                case "Position":                return "@SchoolYear, @PositionID";
                case "NoticeCandidates":        return "@Operate, @SchoolYear,@PositionID,@PositionType";
                case "NoticeUpdate":            return parameter + ",@PrincipalID, @RequestCount,@Comments";
                case "Applicants":              return "@Operate,@SchoolYear, @PositionID";
                case "Applicant":               return "@SchoolYear, @PositionID, @CPNum";
                case "Update":                  return parameter2;
                case "Save":                    return parameter2;
                case "SelectedForInterview":    return "@SchoolYear, @PositionID";
                case "Selected":                return parameter2;
                case "UnSelected":              return parameter2;

                default:                        return "";
            }
        }
    }
}
