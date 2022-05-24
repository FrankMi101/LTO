using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using AppOperate.Execute;
using DataAccess;
using DataAccess.Repository;

namespace AppOperate
{
    public class GeneralExe
    {
        private readonly static IAppServices _action = new AppServices( new GeneralItems(DBConnection.DBSource));

        public GeneralExe()
        {
        }
        public static string SPName(string action)
        {
            return   GetSP(action);
        }
        public static string SPName(string action, object parameter)
        {
             return GetSPInClass(action, parameter);
        }
        public static string SPName(string action, string page)
        {
            return GetSP(action, page);
        }
        public static string SPName(string action, string page, string func)
        {
            return GetSP(action, page, func);
        }
        public static List<List2Item> DDList(object parameter)
        {
           
            return _action.AppOne.CommonList<List2Item>(GetSP("DDList"), parameter);
        }
        public static List<NameValueList> DDListNV(object parameter)
        {
            return _action.AppOne.CommonList<NameValueList>(GetSP("DDList"), parameter);
        }
        public static List<ListSchool> SchoolList(object parameter)
        {
            return _action.AppOne.CommonList<ListSchool>(GetSP("Schools"), parameter);
        }
        public static List<NameValueList> SearchList(object parameter)
        {
            return _action.AppOne.CommonList<NameValueList>(GetSP("SearchList"), parameter);
        }
        public static List<LTODefalutDate> DefaultDate(object parameter)
        {
            return _action.AppOne.CommonList<LTODefalutDate>(GetSP("DefaultDate"), parameter);
        }
        public static List<LTODefalutDate> OpenCloseDate(object parameter)
        {
            return _action.AppOne.CommonList<LTODefalutDate>(GetSP("OpenCloseDate"), parameter);
        }
        public static List<LTODefalutDate> StartEndDate(object parameter)
        {
            return _action.AppOne.CommonList<LTODefalutDate>(GetSP("StartEndDate"), parameter);
        }
        public static List<TeachersListByCategory> TeachersList(object parameter)
        {
            return _action.AppOne.CommonList<TeachersListByCategory>(GetSP("TeachersList"), parameter);
        }

        public static List<Applicant> RandomApplicant(object parameter)
        {
            return _action.AppOne.CommonList<Applicant>(GetSP("RandomApplicant"), parameter);
        }

        public static string Profile(object parameter)
        {
  
            return  _action.AppOne.CommonAction(GetSP("Profile"), parameter);
        }
        public static string TeacherName(object parameter)
        {
            return _action.AppOne.CommonAction(GetSP("TeacherName"), parameter);
        }
        public static string ValidateDate(object parameter)
        {
            return _action.AppOne.CommonAction(GetSP("ValidateDate"), parameter);
        }
  

        private static string GetSP(string action)
        {
            if (SPSource.SPFile == "")
            { return GetSPInClass(action, ""); }
            else
            { return GetSPFromJsonFile(action, ""); }

        }
        private static string GetSP(string action, string page)
        {
            return GetSPbyDelegateHelp(action, page);
        }
        private static string GetSP(string action, string page, string func)
        {
            return GetSPbyDelegateFunc(action, page);
        }
        private delegate string GetSPNameAndParameters(string value, string value2);
        private static string GetSPHelper(GetSPNameAndParameters delegateFunc, string value, string value2)
        {
            return delegateFunc(value, value2);

        }
        private static string GetSPbyDelegateHelp(string action, string page)
        {
            if (SPSource.SPFile == "")
            {
                return GetSPHelper(GetSPInClass, action, page);
            }
            else
            {
                return GetSPHelper(GetSPFromJsonFile, action, page);
            }
        }

        private static string GetSPbyDelegateFunc(string action, string page)
        {
            Func<string, string, string> mySP;
            if (SPSource.SPFile == "")
            {
                mySP = GetSPInClass;
            }
            else
            {
                mySP = GetSPFromJsonFile;
            }
            return mySP(action, page);
        }
        private static string GetSPbyDelegate(string action, string page)
        {
            GetSPNameAndParameters spNameParameter;
            if (SPSource.SPFile == "")
            {
                spNameParameter = GetSPInClass;
            }
            else
            {
                spNameParameter = GetSPFromJsonFile;
            }

            return spNameParameter(action, page);
        }

        public static string SpName(string action, object para)
        {
            return GetSPInClass(action, para);
        }
        private static string GetSPInClass(string action)
        {
            return action;
        }
        private static string GetSPInClass(string action, object para)
        {
            return   _action.AppOne.SpName(action, para);
 
        }
        private static string GetSPFromJsonFile(string action, string page)
        {
            return GetSpNameFormJsonFile.SPName(action, "General");

        }
    }
    public class GeneralExe<T>
    {
        private readonly static IAppServices _action = new AppServices(DBConnection.DBSource);

        private delegate List<T> GetMyListDel(string spName, object parameter);
        private static List<T> GetListHelper(GetMyListDel delgateFunc, string spName, object parameter)
        {
            return delgateFunc(spName,parameter);
        }
        public static List<T> myListofT_DelegateHelp_Method(string action, object parameter)
        {          
             return GetListHelper(myListOfT, action, parameter);
        }

        public static List<T> myListOfT(string spName, object parameter)
        {
            try
            {
                string SP = GeneralExe.SPName(spName);
                return CommonExcute<T>.GeneralList(SP, parameter);

            }
            catch (Exception ex)
            {
                 throw;
            }
        }
       
        public static T myValueOfT(string spName, object parameter)
        {
            try
            {
                string SP = GeneralExe.SPName(spName);
                return CommonExcute<T>.GeneralValueOfT(SP, parameter);

            }
            catch (Exception ex)
            {
                 throw ;

            }
        }
        public static string myValueOfString(string spName, object parameter)
        {
            try
            {
                string SP = GeneralExe.SPName(spName);
                return CommonExcute<T>.GeneralValue(SP, parameter);

            }
            catch (Exception ex)
            {
                 throw;

            }
        }
    }
}
