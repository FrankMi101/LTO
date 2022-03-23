using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RequestPosting : PostingBase , IRequestPosting
    {
        public RequestPosting() : base()
        {
        }
        public RequestPosting(string dataSource) : base(dataSource)
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
                    return "dbo.tcdsb_LTO_PageRequest_Positions" ;
                case "Position":
                    return "dbo.tcdsb_LTO_PageRequest_Position" ;
                case "Request":
                case "NewRequest":
                case "New":
                    return "dbo.tcdsb_LTO_PageRequest_CreateNew" ;
                case "Delete":
                case "Cancel":
                case "Call Back":
                    return "dbo.tcdsb_LTO_PageRequest_Operation" ;
                case "Save":
                    return "dbo.tcdsb_LTO_PageRequest_OperationSave" ;
                case "Update":
                    return "dbo.tcdsb_LTO_PageRequest_OperationSave2" ;
                case "RequestAttribute":
                case "RequestSchool":
                    return "dbo.tcdsb_LTO_PageRequest_Attribute" ;
                case "Qualifications":
                    return "dbo.tcdsb_LTO_PageRequest_Qualifications" ;
                case "Qualification":
                    return "dbo.tcdsb_LTO_PageRequest_Qualification_Update" ;
                case "QualificationSTR":
                    return "dbo.tcdsb_LTO_PageRequest_Qualification" ;
                case "TeachersList":
                    return "dbo.tcdsb_LTO_PageRequest_TeacherList" ;
                case "TeacherName":
                    return "dbo.tcdsb_LTO_PageRequest_TeacherName" ;

                default:
                    return action;

            }

        }
        private string GetParameters(string action)
        {
            string parameter0 = " @Operate, @UserID, @SchoolYear, @SchoolCode";
            string parameter = parameter0 + ", @PositionID";
            string parameters = parameter + ", @PositionType";
            string parametersC = parameters + ", @StartDate, @EndDate, @Comments, @PositionLevel, @PositionTitle, @Description, @Qualification, @QualificationCode, @FTE, @FTEPanel, @ReplaceTeacherID, @ReplaceReason, @OtherReason, @Owner, @Degree";
            switch (action)
            {
                case "Positions":           return "@Operate, @UserID, @SchoolYear, @SchoolCode";
                case "Position":            return " @SchoolYear, @PositionID";
                case "Request":             return parameters;
                case "NewRequest":          return parameters;
                case "New":                 return parameters;
                case "Delete":              return parameters;
                case "Cancel":              return parameters;
                case "Call Back":           return parameters;
                case "Save":                return parametersC;
                case "Update":              return parametersC;
                case "RequestAttribute":    return parameter;
                case "RequestSchool":       return parameter;
                case "Qualifications":      return "@SearchValue, @SelectedCode";
                case "Qualification":       return  parameter + ", @SourceID, @QualificationID, @Selected";
                case "QualificationSTR":    return parameter + ", @SourceID";
                case "TeachersList":        return parameter0 + ", @SearchValue1";
                case "TeacherName":         return parameter + ", @CPNum";

                default:                    return "";
            }
        }
    }
}
