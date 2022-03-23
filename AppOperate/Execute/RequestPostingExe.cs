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
    public class RequestPostingExe
    {
         private readonly static IAppServices _action = new AppServices(DBConnection.DBSource, new RequestPosting());

        public RequestPostingExe()
        {
        }
   
        public static List<QualCheck> QualificationList(object parameter)
        {
            string SP = GetSP("Qualifications");
            return _action.AppOne.CommonList<QualCheck>(SP, parameter);
           // return CommonExcute<QualCheck>.GeneralList(SP, parameter);
        }
        public static List<PositionListRequesting> Positions(object parameter)
        {
            string SP = GetSP("Positions");
          //  return CommonExcute<PositionListRequesting>.GeneralList(SP, parameter);
            return _action.AppOne.CommonList<PositionListRequesting>(SP, parameter);   
        }
        public static List<PositionRequesting> Position(object parameter)
        {
            string SP = GetSP("Position");
          // return CommonExcute<PositionRequesting>.GeneralList(SP, parameter);
            return _action.AppOne.CommonList<PositionRequesting>(SP,parameter);
            
        }
        public static List<TeachersListByCategory> TeachersList(object parameter)
        {
            string SP = GetSP("TeachersList");
            return _action.AppOne.CommonList<TeachersListByCategory>(SP, parameter);
         //   return  GeneralExe<TeachersListByCategory>.myListOfT("TeachersList", parameter);

        }
      
        public static string Add(object parameter)
        {
            string SP = GetSP("New");
            return _action.AppOne.CommonAction(SP, parameter);

         //   return CommonExcute<NewPosition>.GeneralValue(SP, parameter);
        }
      
        public static string Update(object parameter)
        {
            string SP = GetSP("Update");
            return _action.AppOne.CommonAction(SP, parameter);
            //   return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string Operation(string action, object parameter)
        {
            string SP = GetSP(action);
            return _action.AppOne.CommonAction(SP, parameter);
            //   return CommonExcute<string>.GeneralValue(SP, parameter);
        }

        public static string RequestSchool(object parameter)
        {
            string SP = GetSP("RequestSchool");
            return _action.AppOne.CommonAction(SP, parameter);
            //   return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string RequestAttribute(object parameter)
        {
            string SP = GetSP("RequestAttribute");
            return _action.AppOne.CommonAction(SP, parameter);
            //  return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string Qualification(object parameter)
        {
            string SP = GetSP("Qualification");
            return _action.AppOne.CommonAction(SP, parameter);
            //  return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string QualificationSTR(object parameter)
        {
            string SP = GetSP("QualificationSTR");
            return _action.AppOne.CommonAction(SP, parameter);
            //   return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string TeacherName(object parameter)
        {
             string SP = GetSP("TeacherName");
            //return CommonExcute<string>.GeneralValue(SP, parameter);
            return _action.AppOne.CommonAction(SP, parameter);
        }
        private static string GetSP(string action)
        {
            if (SPSource.SPFile == "")   return GetSPInClass(action);  
           
             return GetSPFromJsonFile(action); 
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
            return  _action.AppOne.SpName(action, parameter);  
        }
        private static string GetSPFromJsonFile(string action)
        {
            return GetSpNameFormJsonFile.SPName(action, "Request");
        }
    }
}
