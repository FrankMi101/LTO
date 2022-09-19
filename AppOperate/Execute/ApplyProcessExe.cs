using ClassLibrary;
using DataAccess;
using DataAccess.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AppOperate
{
    public class ApplyProcessExe
    {
        private readonly static IAppServices _action = new AppServices( new ApplyPosting(DBConnection.DBSource) );

        public ApplyProcessExe()
        {
        }
        public static List<PositionListApplying> Positions(object parameter)
        {
            string SP = GetSP("Positions", parameter);
            return _action.AppOne.CommonList<PositionListApplying>(SP, parameter);
           // return CommonExcute<PositionListApplying>.GeneralList(SP, parameter);
        }
        public static List<PositionListApplied> AppliedPositions(object parameter)
        {
            string SP = GetSP("PositionsApplied", parameter);
            return _action.AppOne.CommonList<PositionListApplied>(SP, parameter);
            //           return CommonExcute<PositionListApplied>.GeneralList(SP, parameter);
        }
        public static List<PositionApplying> Position(object parameter)
        {
            string SP = GetSP("Position", parameter);
            return _action.AppOne.CommonList<PositionApplying>(SP, parameter);
            //            return CommonExcute<PositionApplying>.GeneralList(SP, parameter);
        }
        public static List<ApplicantContact> ContactInfo(object parameter)
        {
            string SP = GetSP("ContactInfo", parameter);
            return _action.AppOne.CommonList<ApplicantContact>(SP, parameter);
            //           return CommonExcute<ApplicantContact>.GeneralList(SP, parameter);
        }
        public static List<PositionQualificationCheck> QualficationCheck(object parameter)
        {
            string SP = GetSP("QualificationCheck", parameter);
            return _action.AppOne.CommonList<PositionQualificationCheck>(SP, parameter);
            //           return CommonExcute<PositionQualificationCheck>.GeneralList(SP, parameter);
        }
        public static string Appied(object parameter)
        {
            string SP = GetSP("Applied", parameter);
            return _action.AppOne.CommonAction(SP, parameter);
            //            return CommonExcute<string>.GeneralValue(SP, parameter);
        }

        public static string UpdateContact(object parameter)
        {
            string SP = GetSP("UpdateContact", parameter);
            return _action.AppOne.CommonAction(SP, parameter);
            //           return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string OCTQualfication(object parameter)
        {
            string SP = GetSP("OCTQualification", parameter);
            return _action.AppOne.CommonAction(SP, parameter);
            //          return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        private static string GetSP(string action, object parameter)
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
            return  _action.AppOne.SpName(action, parameter);
 
        }
        private static string GetSPFromJsonFile(string action)
        {
            return GetSpNameFormJsonFile.SPName(action, "Apply");
        }
    }
}
