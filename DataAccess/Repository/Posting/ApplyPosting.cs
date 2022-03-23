using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ApplyPosting : PostingBase, IApplyPosting
    {
         public ApplyPosting() : base()
        {
         }
      
        public ApplyPosting(string dataSource) : base(dataSource)
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
                case "PositionsApplied":
                    return "dbo.tcdsb_LTO_PageApply_AppliedPositions" ;
                case "Positions":
                    return "dbo.tcdsb_LTO_PageApply_AvailablePositions";
                case "Position":
                    return "dbo.tcdsb_LTO_PageApply_ApplyingPosition" ;
                case "Applied":
                case "Rescind":
                case "AppliedOnBehalf":
                case "Cancel":
                    return "dbo.tcdsb_LTO_PageApply_Operation" ;
                case "OCTQualification":
                    return "dbo.tcdsb_LTO_PageApply_OCTQualification" ;
                case "QualificationCheck":
                    return "dbo.tcdsb_LTO_PageApply_QualificationCheck" ;
                case "UpdateContact":
                case "ContactInfo":
                    return "dbo.tcdsb_LTO_PageApply_ApplicantContactInfo" ;
                case "ApplicantComment":
                    return "dbo.tcdsb_LTO_PageApply_ApplicantComments" ;
                default:
                    return action;

            }
        }
        private string GetParameters(string action)
        {
            string parameter = "@Operate, @UserID, @SchoolYear, @PositionID,@CPNum,@Action,@Comments";
            string pForList0 = "@Operate,@UserID,@SchoolYear,@PositionType,@SearchBy, @SearchValue1";
            switch (action)
            {
                case "PositionsApplied":    return "@Operate,@UserID,@SchoolYear,@PositionType,@CPNum";
                case "Positions":           return pForList0 + ",@UserRole, @CPNum";
                case "Position":            return "@SchoolYear,@PositionID,@CPNum";
                case "Applied":             return parameter;
                case "AppliedOnBehalf":     return parameter;
                case "Cancel":              return parameter;
                case "OCTQualification":    return "@SchoolYear, @PositionID, @CPNum";
                case "QualificationCheck":  return "@SchoolYear, @PositionID, @CPNum";
                case "UpdateContact":       return "@Operate, @CPNum, @HomePhone, @CellPhone, @Email, @PositionID ";
                case "ContactInfo":         return "@Operate, @CPNum";
                case "ApplicantComment":    return parameter;
                default:                    return "";

            }
        }
    }
}
