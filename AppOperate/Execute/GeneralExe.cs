using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using AppOperate.Execute;

namespace AppOperate
{
    public class GeneralExe
    {
        public GeneralExe()
        {
        }
        public static string SPName(string action)
        {
            return GetSP(action);
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
            return CommonExcute<List2Item>.GeneralList(GetSP("DDList"), parameter);
        }
        public static List<NvListItem> DDListNV(object parameter)
        {
            return CommonExcute<NvListItem>.GeneralList(GetSP("DDList"), parameter);
        }
        public static List<ListSchool> SchoolList(object parameter)
        {
            return CommonExcute<ListSchool>.GeneralList(GetSP("Schools"), parameter);
        }
        public static List<NvListItem> SearchList(object parameter)
        {
            return CommonExcute<NvListItem>.GeneralList(GetSP("SearchList"), parameter);
        }
        public static List<LTODefalutDate> DefaultDate(object parameter)
        {
            return CommonExcute<LTODefalutDate>.GeneralList(GetSP("DefaultDate"), parameter);
        }
        public static List<LTODefalutDate> OpenCloseDate(object parameter)
        {
             return CommonExcute<LTODefalutDate>.GeneralList(GetSP("OpenCloseDate"), parameter);
        }
        public static List<LTODefalutDate> StartEndDate(object parameter)
        {
            return CommonExcute<LTODefalutDate>.GeneralList(GetSP("StartEndDate"), parameter);
        }
        public static List<TeachersListByCategory> TeachersList(object parameter)
        {
              return CommonExcute<TeachersListByCategory>.GeneralList(GetSP("TeachersList"), parameter);
        }

        public static List<Applicant> RandomApplicant(object parameter)
        {
             return CommonExcute<Applicant>.GeneralList(GetSP("RandomApplicant"), parameter);
        }

        public static string Profile(object parameter)
        {
  
            return CommonExcute<string>.GeneralValue(GetSP("Profile"), parameter);
        }
        public static string TeacherName(object parameter)
        {
            return CommonExcute<string>.GeneralValue(GetSP("TeacherName"), parameter);
        }
        public static string ValidateDate(object parameter)
        {
            return CommonExcute<string>.GeneralValue(GetSP("ValidateDate"), parameter);
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
        private static string GetSPInClass(string action, string page)
        {

            string parameters = " @Operate,@Para0,@Para1,@Para2,@Para3";
            string parameters2 = " @Operate,@SchoolYear,@PositionType";
        

            switch (action)
            {
                case "DDList":
                    return "dbo.tcdsb_LTO_PageGeneral_List" + parameters;
                case "Schools":
                    return "dbo.tcdsb_LTO_PageGeneral_ListSchools" + parameters;
                case "SearchList":
                    return "dbo.tcdsb_LTO_PageGeneral_ListSearch" + parameters2 + ",@SearchType";
                case "ValidateDate":
                    return "dbo.tcdsb_LTO_PageGeneral_ValidateDate" + parameters2 + ",@ValidateDate";
                case "DefaultDate":
                    return "dbo.tcdsb_LTO_PageGeneral_DefaultDate" + parameters2;
                case "OpenCloseDate":
                    return "dbo.tcdsb_LTO_PageGeneral_OpenCloseDate" + parameters2 + ",@DatePublish";
                case "StartEndDate":
                    return "dbo.tcdsb_LTO_PageGeneral_StartEndDate" + parameters2;
                case "Profile":
                    return "dbo.tcdsb_LTO_PageGeneral_Profile" + " @Operate,@UserID,@SchoolYear,@ProfileType,@CheckValue";
                case "TeachersList":
                    return "dbo.tcdsb_LTO_PageGeneral_TeacherList" + " @SchoolYear,@SchoolCode,@SearchValue1";
                case "TeacherName":
                    return "dbo.tcdsb_LTO_PageGeneral_TeacherName" + " @Operate,@CPNum";
                case "RandomApplicant":
                    return "dbo.tcdsb_LTO_PageGeneral_RandomApplicant" + " @Operate,@SchoolYear,@PositionID,@PositionType,@PostingCycle,@CPNum";
    
                default:
                    return action;

            }
        }
        private static string GetSPFromJsonFile(string action, string page)
        {
            return GetSpNameFormJsonFile.SPName(action, "General");

        }
    }
    public class GeneralExe<T>
    {
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
                string em = ex.Message;
                string es = ex.StackTrace;
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
                string em = ex.Message;
                string es = ex.StackTrace;
                throw;

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
                string em = ex.Message;
                string es = ex.StackTrace;
                throw;

            }
        }
    }
}
