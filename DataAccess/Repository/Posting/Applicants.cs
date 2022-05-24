using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class Applicants : PostingBase, IApplicants
    {
        public Applicants() : base()
        {
        }

        public Applicants(string dataSource) : base(dataSource)
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
                case "OTType":
                case "Status":
                    return "dbo.tcdsb_LTO_PageUser_Attribute" ;
                case "ApplicantProfile":
                case "ApplicantProfileSave":
                    return "dbo.tcdsb_LTO_PageUser_ApplicantProfile" ;
                case "ResumeCoverLetterSave":
                case "ResumeCoverLetterList":
                    return "dbo.tcdsb_LTO_PageUser_ApplicantResumeCoverLetter" ;
                case "ResumeCoverLetterPermission":
                    return "dbo.tcdsb_LTO_PageUser_ApplicantResumeCoverLetterPermission" ;
                case "ResumeCoverLetterRemove":
                    return "dbo.tcdsb_LTO_PageUser_ApplicantResumeCoverLetterRemove" ;
                case "ResumeCoverLetterName":
                    return "dbo.tcdsb_LTO_PageUser_ApplicantResumeCoverLetterName" ;
                case "SecurityRole":
                    return "dbo.tcdsb_LTO_PageUser_RoleAndPermission";
                case "UserRole":
                    return "dbo.tcdsb_LTO_PageUser_Role";

                default: return action;

            }
        }
        private string GetParameters(string action)
        {
             string parameters3 = "@Operate,@UserID,@CPNum,@PositionID";

            switch (action)
            {
                case "OTType":                      return "@SchoolYear,@Type,@ID";
                case "Status":                      return "@SchoolYear,@Type,@ID";
                case "ApplicantProfile":            return "@UserID, @CPNum";
                case "ApplicantProfileSave":        return "@UserID, @CPNum,@HomePhone,@CellPhone,@Email,@Comment";
                case "ResumeCoverLetterSave":       return parameters3 + ",@SchoolYear,@GrantView,@FileType,@FileName,@FileContent";
                case "ResumeCoverLetterList":       return parameters3;
                case "ResumeCoverLetterPermission": return parameters3 + ",@SchoolYear,@GrantView";
                case "ResumeCoverLetterRemove":     return parameters3;
                case "ResumeCoverLetterName":       return parameters3;
                case "SecurityRole":                return "@UserID, @Type, @Role";
                case "UserRole":                    return "@UserID";


                default:                            return "";
            }
        }
    }
}
