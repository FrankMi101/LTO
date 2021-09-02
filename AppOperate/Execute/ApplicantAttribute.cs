using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
   public  class ApplicantAttribute
    {
        public static string GetSP(string action)
        {
            switch (SPSource.SPFile)
            {
                case "JsonFile":
                    return GetSpNameFormJsonFile.SPName(action, "ApplicantAttribute");
                case "DBTable":
                    return ""; 
                default:
                    return GetSPInClass(action);
            }
        }

        public static List<T> CommonList<T>(string action, object parameter)
        {
            try
            {
                string sp = GetSP(action);
                return CommonExcute<T>.GeneralList(sp, parameter); 
            }
            catch (Exception ex)
            {
                string em = ex.StackTrace;
                throw new Exception();
            }

        }
        public static T CommonValue<T>(string action, object parameter)
        {
            try
            {
                string sp = GetSP(action);
                return CommonExcute<T>.GeneralValueOfT(sp, parameter); 
            }
            catch (Exception ex)
            {
                string em = ex.StackTrace;
                throw new Exception();
            }
        }
        public static List<ResumeCoverLetter> ResumeCoverLetterList(object parameter)
        {
            return CommonExcute<ResumeCoverLetter>.GeneralList(GetSP("ResumeCoverLetterList"), parameter);
        }
        public static string ResumeCoverLetterSave(object parameter)
        {
            return CommonExcute<string>.GeneralValue(GetSP("ResumeCoverLetterSave"), parameter);
        }
        public static string ResumeCoverLetterPermission(object parameter)
        {
            return CommonExcute<string>.GeneralValue(GetSP("ResumeCoverLetterPermission"), parameter);
        }
        public static string ResumeCoverLetterRemove(object parameter)
        {
            return CommonExcute<string>.GeneralValue(GetSP("ResumeCoverLetterRemove"), parameter);
        }
        public static string ResumeCoverLetterName(object parameter)
        {
            return CommonExcute<string>.GeneralValue(GetSP("ResumeCoverLetterName"), parameter);
        }
        public static string OTType(object parameter)
        {
            return CommonValue<string>("OTType", parameter);
        }


        private static string GetSPInClass(string action)
        {

            string parameters = " @Operate, @UserID, @Type, @Owner";

            string parameters3 = " @Operate,@UserID,@CPNum,@PositionID";

            switch (action)
            {
                case "OTType":
                    return "dbo.tcdsb_LTO_PageUser_Attribute" + " @SchoolYear,@Type,@ID";
                case "Status":
                    return "dbo.tcdsb_LTO_PageUser_Attribute" + " @SchoolYear,@Type,@ID";
                case "ApplicantProfile":
                    return "dbo.tcdsb_LTO_PageUser_ApplicantProfile" + " @UserID, @CPNum";

                case "ApplicantProfileSave":
                    return "dbo.tcdsb_LTO_PageUser_ApplicantProfile" + " @UserID, @CPNum,@HomePhone,@CellPhone,@Email,@Comment";

                case "ResumeCoverLetterSave":
                    return "dbo.tcdsb_LTO_PageUser_ApplicantResumeCoverLetter" + parameters3 + ",@SchoolYear,@GrantView,@FileType,@FileName,@FileContent";
                case "ResumeCoverLetterList":
                    return "dbo.tcdsb_LTO_PageUser_ApplicantResumeCoverLetter" + parameters3;
                case "ResumeCoverLetterPermission":
                    return "dbo.tcdsb_LTO_PageUser_ApplicantResumeCoverLetterPermission" + parameters3 + ",@SchoolYear,@GrantView";
                case "ResumeCoverLetterRemove":
                    return "dbo.tcdsb_LTO_PageUser_ApplicantResumeCoverLetterRemove" + parameters3;
                case "ResumeCoverLetterName":
                    return "dbo.tcdsb_LTO_PageUser_ApplicantResumeCoverLetterName" + parameters3;

                default:
                    return action;

            }
        }

    }
}