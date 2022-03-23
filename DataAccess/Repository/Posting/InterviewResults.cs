using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class InterviewResults : PostingBase, IInterviewResult
    {
        public InterviewResults() : base()
        {
        }

        public InterviewResults(string dataSource) : base(dataSource)
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
                case "Candidate":                    return "dbo.tcdsb_LTO_PageInterview_Candidate";
                case "Candidates":                   return "dbo.tcdsb_LTO_PageInterview_Candidates";
                case "Positions":                    return "tcdsb_LTO_PageInterview_Positions";
                case "Position":                     return "tcdsb_LTO_PageInterview_Position";
                case "Update":
                case "Recommend":                    return "dbo.tcdsb_LTO_PageInterview_Operation";
                case "PositionHiringStatus":
                case "SignOffCount":
                case "InterviewCount":              return "dbo.tcdsb_LTO_PageInterview_OperationCheck";
                case "SignOffAction":               return "dbo.tcdsb_LTO_PageInterview_SignOff";
                case "RequestMoreInterview":
                case "SendNoticeToPrincipal":       return "dbo.tcdsb_LTO_PageInterview_OperationNotice";
                case "MultipSchoolPrincipal":
                case "ActingPrincipal":            return "dbo.tcdsb_LTO_PageInterview_NoticePrincipal";
                case "TeamMembers":
                case "UpdateMember":               return "dbo.tcdsb_LTO_PageInterview_Team";
                case "Signatures":
                case "SignatureName":              return "dbo.tcdsb_LTO_PageInterview_Signature";
                case "OutcomeUpdate":         
                case "OutCome":                    return "dbo.tcdsb_LTO_PageInterview_OutcomeUpdate";
                case "Selected":                   return "dbo.tcdsb_LTO_PageCandidate_Select";
                default:
                    return "";

            }

        }
        private string GetParameters(string action)
        {
            string parameter = "@Operate, @UserID, @SchoolYear, @PositionID";
            string parameters = parameter + ", @CPNum";
            switch (action)
            {
                case "Candidate":               return "@SchoolYear,@PositionID,@CPNum";
                case "Candidates":              return "@SchoolYear, @PositionID";
                case "Positions":               return "@Operate, @UserID, @SchoolYear,@SchoolCode,@SearchValue1";
                case "Position":                return "@Operate, @UserID, @SchoolYear,@PositionID";
                case "Update":                  return parameters + ", @Recommendation, @InterviewDate, @EffectiveDate, @OutCome, @Acceptance";
                case "Recommend":               return parameters + ", @Recommendation, @InterviewDate, @EffectiveDate, @OutCome, @Acceptance";
                case "PositionHiringStatus":    return parameters;
                case "SignOffCount":            return parameters;
                case "InterviewCount":          return parameters;
                case "SignOffAction":           return parameters;
                case "RequestMoreInterview":    return parameter + ", @NoticeDate, @PrincipalID, @RequestCount";
                case "SendNoticeToPrincipal":   return parameter + ", @NoticeDate, @PrincipalID";
                case "MultipSchoolPrincipal":   return parameter + ", @SchoolCode";
                case "ActingPrincipal":         return parameter + ", @SchoolCode";
                case "TeamMembers":             return parameter;
                case "UpdateMember":            return parameter + ",@Sequesc,@MemberID";
                case "Signatures":              return "@SchoolYear,@PositionID,@CPNum";
                case "SignatureName":           return "@SchoolYear,@PositionID,@CPNum,@signature,@SignatureID";
                case "OutcomeUpdate":           return parameters + ",@Outcome";

                default:                    return "";

            }
        }
    }
}
