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
    public class LTOStaffManageExe
    {
        private readonly static IAppServices _action = new AppServices( new StaffManage(DBConnection.DBSource));

        public LTOStaffManageExe()
        {
        }
  
        public static List<Staff> TCDSBStaffs(object parameter)
        {
            string SP = GetSP("TCDSBStaffs");
            return _action.AppOne.CommonList<Staff>(SP, parameter);
            // return CommonExcute<Staff>.GeneralList(SP, parameter);
        }
        public static List<HRComments> CommentsList(object parameter)
        {
            string SP = GetSP("CommentsList");
            return _action.AppOne.CommonList<HRComments>(SP, parameter);
            //            return CommonExcute<HRComments>.GeneralList(SP, parameter);
        }
        public static List<Staff> LTOStaffs(object parameter)
        {
            string SP = GetSP("LTOStaffs");
            return _action.AppOne.CommonList<Staff>(SP, parameter);
            //           return CommonExcute<Staff>.GeneralList(SP, parameter);
        }
        public static List<Staff> Staff(object parameter)
        {
            string SP = GetSP("Staff");
            return _action.AppOne.CommonList<Staff>(SP, parameter);
            //           return CommonExcute<Staff>.GeneralList(SP, parameter);
        }
        public static string Save(object parameter)
        {
            string SP = GetSP("Save"); 
            return _action.AppOne.CommonAction(SP, parameter);
            //            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string SaveRanking(object parameter)
        {
            string SP = GetSP("SaveRanking");
             return _action.AppOne.CommonAction(SP, parameter);
            //             return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string ApplicantOTType(object parameter)
        {
            string SP = GetSP("OTType");
             return _action.AppOne.CommonAction(SP, parameter);
            //            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        private static string GetSP(string action)
        {
            if (SPSource.SPFile == "")
            { return GetSPInClass(action); }
            else
            { return GetSPFromJsonFile(action); }

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
        private static string GetSPFromJsonFile(string action)
        {
            return GetSpNameFormJsonFile.SPName(action, "Staff");
        }
    }
}
