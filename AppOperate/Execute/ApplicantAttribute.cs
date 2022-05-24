using ClassLibrary;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
   public  class ApplicantAttribute
    {
        private readonly static IAppServices _action = new AppServices( new Applicants(DBConnection.DBSource));

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
                return _action.AppOne.CommonList<T>(sp, parameter);
              //  return CommonExcute<T>.GeneralList(sp, parameter); 
            }
            catch (Exception ex)
            {
                 throw new Exception();
            }

        }
        public static T CommonValue<T>(string action, object parameter)
        {
            try
            {
                string sp = GetSP(action);
                return _action.AppOne.CommonObject<T>(sp, parameter);
              //  return CommonExcute<T>.GeneralValueOfT(sp, parameter); 
            }
            catch (Exception ex)
            {
                 throw new Exception();
            }
        }
        public static List<ResumeCoverLetter> ResumeCoverLetterList(object parameter)
        {
            string sp = GetSP("ResumeCoverLetterList");
            return _action.AppOne.CommonList<ResumeCoverLetter>(sp, parameter);
            //            return CommonExcute<ResumeCoverLetter>.GeneralList(GetSP("ResumeCoverLetterList"), parameter);
        }
        public static string ResumeCoverLetterSave(object parameter)
        {
            string sp = GetSP("ResumeCoverLetterSave");
            return _action.AppOne.CommonAction(sp, parameter);
            //           return CommonExcute<string>.GeneralValue(GetSP("ResumeCoverLetterSave"), parameter);
        }
        public static string ResumeCoverLetterPermission(object parameter)
        {
            string sp = GetSP("ResumeCoverLetterPermission");
            return _action.AppOne.CommonAction(sp, parameter);
            //           return CommonExcute<string>.GeneralValue(GetSP("ResumeCoverLetterPermission"), parameter);
        }
        public static string ResumeCoverLetterRemove(object parameter)
        {
            string sp = GetSP("ResumeCoverLetterRemove");
            return _action.AppOne.CommonAction(sp, parameter);
            //           return CommonExcute<string>.GeneralValue(GetSP("ResumeCoverLetterRemove"), parameter);
        }
        public static string ResumeCoverLetterName(object parameter)
        {
            string sp = GetSP("ResumeCoverLetterName");
            return _action.AppOne.CommonAction(sp, parameter);
            //return CommonExcute<string>.GeneralValue(GetSP("ResumeCoverLetterName"), parameter);
        }
        public static string OTType(object parameter)
        {
            return CommonValue<string>("OTType", parameter);
        }

        public static string SPName(string action)
        {
            return GetSPInClass(action);
        }
        public static string SPName(string action, object para)
        {
            return GetSPInClass(action, para);
        }
        private static string GetSPInClass(string action)
        {
            return action;
        }
        private static string GetSPInClass(string action, object parameter)
        {
            return   _action.AppOne.SpName(action, parameter);  
        }

    }
}