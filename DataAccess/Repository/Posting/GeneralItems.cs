using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class GeneralItems : PostingBase, IGeneralItems
    {
        public GeneralItems() : base()
        {
        }
        public GeneralItems(string dataSource) : base(dataSource)
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
                case "DDList":
                    return "dbo.tcdsb_LTO_PageGeneral_List";
                case "Schools":
                    return "dbo.tcdsb_LTO_PageGeneral_ListSchools";
                case "SearchList":
                    return "dbo.tcdsb_LTO_PageGeneral_ListSearch";
                case "ValidateDate":
                    return "dbo.tcdsb_LTO_PageGeneral_ValidateDate";
                case "DefaultDate":
                    return "dbo.tcdsb_LTO_PageGeneral_DefaultDate";
                case "OpenCloseDate":
                    return "dbo.tcdsb_LTO_PageGeneral_OpenCloseDate";
                case "StartEndDate":
                    return "dbo.tcdsb_LTO_PageGeneral_StartEndDate";
                case "Profile":
                    return "dbo.tcdsb_LTO_PageGeneral_Profile";
                case "TeachersList":
                    return "dbo.tcdsb_LTO_PageGeneral_TeacherList";
                case "TeacherName":
                    return "dbo.tcdsb_LTO_PageGeneral_TeacherName";
                case "RandomApplicant":
                    return "dbo.tcdsb_LTO_PageGeneral_RandomApplicant";
                default:
                    return action;

            }
        }
        private string GetParameters(string action)
        {
            string parameters = "@Operate,@Para0,@Para1,@Para2,@Para3";
            string parameters2 = "@Operate,@SchoolYear,@PositionType";

            switch (action)
            {
                case "DDList":          return parameters;
                case "Schools":         return parameters;
                case "SearchList":      return parameters2 + ",@SearchType";
                case "ValidateDate":    return parameters2 + ",@ValidateDate";
                case "DefaultDate":     return parameters2;
                case "OpenCloseDate":   return parameters2 + ",@DatePublish";
                case "StartEndDate":    return parameters2;
                case "Profile":         return "@Operate,@UserID,@SchoolYear,@ProfileType,@CheckValue";
                case "TeachersList":    return "@SchoolYear,@SchoolCode,@SearchValue1";
                case "TeacherName":     return "@Operate,@CPNum";
                case "RandomApplicant": return "@Operate,@SchoolYear,@PositionID,@PositionType,@PostingCycle,@CPNum";

                default:                return "";

            }
        }
    }
}
