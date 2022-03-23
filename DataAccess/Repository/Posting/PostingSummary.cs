using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PostingSummary : PostingBase, IPostingSummary
    {
        public PostingSummary() : base()
        {
        }

        public PostingSummary(string dataSource) : base(dataSource)
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
                    return "dbo.tcdsb_LTO_PageSummary_Positions" ;
                case "Position":
                    return "dbo.tcdsb_LTO_PageSummary_Position" ;
                case "AppliedPositions":
                    return "dbo.tcdsb_LTO_PageSummary_AppliedHistory" ;
                case "AppliedHistory":
                    return "dbo.tcdsb_LTO_PageSummary_AppliedHistory" ;
                case "ApplicantApplied":
                    return "dbo.tcdsb_LTO_PageSummary_ApplicantApplied" ;
                case "ApplicantEmail":
                    return "dbo.tcdsb_LTO_PageSummary_ApplicantEmail" ;
                case "ApplicantInterview":
                    return "dbo.tcdsb_LTO_PageSummary_ApplicantInterview" ;
                case "PostingRounds":
                    return "dbo.tcdsb_LTO_PagePublish_PostingRounds" ;
                default: return action;

            }
        }
        private string GetParameters(string action)
        {  
            string ParaPosition = "@SchoolYear, @PositionID";
            string ParaPositions = "@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy,@SearchValue1,@SearchValue2";

            switch (action)
            {
                case "Positions":           return ParaPositions;
                case "Position":            return ParaPosition;
                case "AppliedPositions":    return ParaPositions;
                case "AppliedHistory":      return "@UserID,@SchoolYear,@PositionType,@CPNum";
                case "ApplicantApplied":    return "@SchoolYear,@PositionID";
                case "ApplicantEmail":      return "@SchoolYear,@PositionID";
                case "ApplicantInterview":  return "@SchoolYear,@PositionID";
                case "PostingRounds":       return "@SchoolYear, @PositionID";

                default:                    return "";

            }
        }
    }
}
