using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class StaffManage : PostingBase, IStaffManage
    {
        public StaffManage() : base()
        {
        }

        public StaffManage(string dataSource) : base(dataSource)
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

                case "TCDSBStaffs":
                    return "dbo.tcdsb_LTO_PageStaffManage_TCDSBStaffList";
                case "LTOStaffs":
                    return "dbo.tcdsb_LTO_PageStaffManage_LTOList";
                case "Staff":
                    return "dbo.tcdsb_LTO_PageStaffManage_Staff";
                case "OTType":
                    return "dbo.tcdsb_LTO_PageStaffManager_OTType";
                case "Save":
                    return "dbo.tcdsb_LTO_PageStaffManager_Operation";
                case "SaveRanking":
                    return "dbo.tcdsb_LTO_PageStaffManager_OperationRanking";
                case "CommentsList":
                    return "dbo.tcdsb_LTO_PageStaffManager_HRComments";
                default:
                    return action;
            }
        }
        private string GetParameters(string action )
        {
            string ParaPositions = " @SearchBy,@SearchValue";

            switch (action)
            {
                case "TCDSBStaffs":     return ParaPositions;
                case "LTOStaffs":       return ParaPositions;
                case "Staff":           return  "@CPNum,@Source";
                case "OTType":          return "@CPNum";
                case "Save":            return "@UserID,@CPNum,@Action,@Comments,@IDs,@CommentsDate,@DateOfHire,@Ranking,@Lots";
                case "SaveRanking":     return "@Operate,@UserID,@CPNum,@DateOfHire,@Ranking,@Lots";
                case "CommentsList":    return "@UserID,@CPNum,@Action";
                default:                return "";

            }
        }
    }
}
