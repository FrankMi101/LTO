using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ApproveRequest : PostingBase, IApproveRequest
    {
          public ApproveRequest() : base()
        {
         }

        public ApproveRequest(string dataSource) : base(dataSource)
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
                case "Position":
                    return "dbo.tcdsb_LTO_PageApprove_Position";
                case "Positions":
                    return "dbo.tcdsb_LTO_PageApprove_Positions";
                case "Reject":
                    return "dbo.tcdsb_LTO_PageApprove_OperationReject";
                case "Posting":
                    return "dbo.tcdsb_LTO_PageApprove_OperationPostingNew";
                case "Save":
                    return "dbo.tcdsb_LTO_PageApprove_OperationSave";
                case "PostingNumber":
                    return "dbo.tcdsb_LTO_PageApprove_PostingNumber";
                default:
                    return action;

            }

        }

        private string GetParameters(string action)
        {
            string parameters = "@Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID,@Comments";
            string parameter1 = parameters + ",@PositionLevel,@Qualification,@QualificationCode,@Description,@FTE,@FTEPanel,@StartDate,@EndDate,@Owner,@ReplaceTeacherID";
            string search = "@Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy,@SearchValue1,@SearchValue2";

            switch (action)
            {
                case "Position":        return "@SchoolYear,@PositionID"; 
                case "Positions":       return search;
                case "Reject":          return parameters + ",@CPNum";
                case "Save":            return parameter1;
                case "Posting":         return parameter1 + ",@DatePublish,@DateApplyOpen,@DateApplyClose,@RequestSource";
                case "PostingNumber":   return "@Operate,@PositionID";

                default:                return "";

            }
        }

    }
}
