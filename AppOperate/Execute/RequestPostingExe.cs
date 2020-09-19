using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public class RequestPostingExe
    {
        public RequestPostingExe()
        {
        }
        public static string SPName(string action)
        {
            return GetSP(action);
        }
        public static List<QualCheck> QualificationList(object parameter)
        {
            string SP = GetSP("Qualifications");
            return CommonExcute<QualCheck>.GeneralList(SP, parameter);
        }
        public static List<PositionListRequesting> Positions(object parameter)
        {
            string SP = GetSP("Positions");
            return CommonExcute<PositionListRequesting>.GeneralList(SP, parameter);
        }
        public static List<PositionRequesting> Position(object parameter)
        {
            string SP = GetSP("Position");
            return CommonExcute<PositionRequesting>.GeneralList(SP, parameter);
        }
        public static List<TeachersListByCategory> TeachersList(object parameter)
        {
            //string SP = GetSP("TeachersList");
            //return CommonExcute<TeachersListByCategory>.GeneralList(SP, parameter);

          return  GeneralExe<TeachersListByCategory>.myListOfT("TeachersList", parameter);

        }
        //public static List<PositionPublish> DefaultDate(object parameter)
        //{
        //    string SP = GetSP("DefaultDate");
        //    return CommonExcute<PositionPublish>.GeneralList(SP, parameter);
        //}
        //public static List<PositionPublish> PostingRounds(object parameter)
        //{
        //    string SP = GetSP("PostingRounds");
        //    return CommonExcute<PositionPublish>.GeneralList(SP, parameter);
        //}

        public static string Add(object parameter)
        {
            string SP = GetSP("New");
            return CommonExcute<NewPosition>.GeneralValue(SP, parameter);
        }
        //public static string Request(object parameter)
        //{
        //    string SP = GetSP("Request");
        //    return CommonExcute<NewPosition>.GeneralValue(SP, parameter);
        //}
     
        //public static string Save(object parameter)
        //{
        //    string SP = GetSP("Save");
        //    return CommonExcute<string>.GeneralValue(SP, parameter);
        //}
        public static string Update(object parameter)
        {
            string SP = GetSP("Update");
            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string Operation(string action, object parameter)
        {
            string SP = GetSP(action);
            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        //public static string Delete(object parameter)
        //{
        //    string SP = GetSP("Delete");
        //    return CommonExcute<string>.GeneralValue(SP, parameter);
        //}
        //public static string Cancel(object parameter)
        //{
        //    string SP = GetSP("Cancel");
        //    return CommonExcute<string>.GeneralValue(SP, parameter);
        //}
        public static string RequestSchool(object parameter)
        {
            string SP = GetSP("RequestSchool");
            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string RequestAttribute(object parameter)
        {
            string SP = GetSP("RequestAttribute");
            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string Qualification(object parameter)
        {
            string SP = GetSP("Qualification");
            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string QualificationSTR(object parameter)
        {
            string SP = GetSP("QualificationSTR");
            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string TeacherName(object parameter)
        {
            //string SP = GetSP("TeacherName");
            //return CommonExcute<string>.GeneralValue(SP, parameter);
            return GeneralExe.TeacherName(parameter);
        }
        private static string GetSP(string action)
        {
            if (SPSource.SPFile == "")
            { return GetSPInClass(action); }
            else
            { return GetSPFromJsonFile(action); }

        }
        private static string GetSPInClass(string action)
        {
            string parameter0 = " @Operate, @UserID, @SchoolYear, @SchoolCode";
            string parameter = parameter0 + ", @PositionID";
            string parameters = parameter + ", @PositionType";
            string parametersC = parameters + ", @StartDate, @EndDate, @Comments, @PositionLevel, @PositionTitle, @Description, @Qualification, @QualificationCode, @FTE, @FTEPanel, @ReplaceTeacherID, @ReplaceReason, @OtherReason, @Owner, @Degree";
            switch (action)
            {
                case "Positions":
                    return "dbo.tcdsb_LTO_PageRequest_Positions" + " @Operate, @UserID, @SchoolYear, @SchoolCode";
                case "Position":
                    return "dbo.tcdsb_LTO_PageRequest_Position" + " @SchoolYear, @PositionID";
                case "Request":
                    return "dbo.tcdsb_LTO_PageRequest_CreateNew" + parameters;
                case "NewRequest":
                    return "dbo.tcdsb_LTO_PageRequest_CreateNew" + parameters;
                case "New":
                    return "dbo.tcdsb_LTO_PageRequest_CreateNew" + parameters;
                 case "Delete":
                    return "dbo.tcdsb_LTO_PageRequest_Operation" + parameters;
                case "Cancel":
                    return "dbo.tcdsb_LTO_PageRequest_Operation" + parameters;
                case "Save":
                    return "dbo.tcdsb_LTO_PageRequest_OperationSave" + parametersC;
                case "Update":
                    return "dbo.tcdsb_LTO_PageRequest_OperationSave2" + parametersC;
                case "RequestAttribute":
                    return "dbo.tcdsb_LTO_PageRequest_Attribute" + parameter;
                case "RequestSchool":
                    return "dbo.tcdsb_LTO_PageRequest_Attribute" + parameter;
                case "Qualifications":
                    return "dbo.tcdsb_LTO_PageRequest_Qualifications @SearchValue, @SelectedCode";
                case "Qualification":
                    return "dbo.tcdsb_LTO_PageRequest_Qualification_Update" + parameter + ", @SourceID, @QualificationID, @Selected";
                case "QualificationSTR":
                    return "dbo.tcdsb_LTO_PageRequest_Qualification" + parameter + ", @SourceID";
                case "TeachersList":
                    return "dbo.tcdsb_LTO_PageRequest_TeacherList" + parameter0 + ", @SearchValue1";
                case "TeacherName":
                    return "dbo.tcdsb_LTO_PageRequest_TeacherName" + parameter + ", @CPNum";

                default:
                    return action;

            }

        }
        private static string GetSPFromJsonFile(string action)
        {
            return GetSpNameFormJsonFile.SPName(action, "Request");
        }
    }
}
