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
    public class PostingSummaryExe
    {
        private readonly static IAppServices _action = new AppServices( new PostingSummary(DBConnection.DBSource));

        public PostingSummaryExe()
        {
        }

        public static List<PositionListPublish> Positions(object parameter)
        {
            string SP = GetSP("Positions");
            return _action.AppOne.CommonList<PositionListPublish>(SP, parameter);
           // return CommonExcute<PositionListPublish>.GeneralList(SP, parameter);
        }
        public static List<PositionListApplied> AppliedPositions(object parameter)
        {
            string SP = GetSP("AppliedHistory");
            return _action.AppOne.CommonList<PositionListApplied>(SP, parameter);
            //           return CommonExcute<PositionListApplied>.GeneralList(SP, parameter);
        }
        public static List<PositionPublish> Position(object parameter)
        {
            string SP = GetSP("Position");
            return _action.AppOne.CommonList<PositionPublish>(SP, parameter);
            //            return CommonExcute<PositionPublish>.GeneralList(SP, parameter);
        }
        public static List<ApplicantList> ApplicantApplied(object parameter)
        {
            string SP = GetSP("ApplicantApplied");
            return _action.AppOne.CommonList<ApplicantList>(SP, parameter);
            //           return CommonExcute<ApplicantList>.GeneralList(SP, parameter);
        }
        public static List<PositionPublish> ApplicantEmail(object parameter)
        {
            string SP = GetSP("ApplicantEmail");
            return _action.AppOne.CommonList<PositionPublish>(SP, parameter);
            //           return CommonExcute<PositionPublish>.GeneralList(SP, parameter);
        }
        public static List<PositionInterview> ApplicantInterview(object parameter)
        {
            string SP = GetSP("ApplicantInterview");
            return _action.AppOne.CommonList<PositionInterview>(SP, parameter);
            //           return CommonExcute<PositionInterview>.GeneralList(SP, parameter);
        }
        public static List<PositionPublish> PostingRounds(object parameter)
        {
            string SP = GetSP("PostingRounds");
            return _action.AppOne.CommonList<PositionPublish>(SP, parameter);
            //           return CommonExcute<PositionPublish>.GeneralList(SP, parameter);
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
            string JsonFile = SPSource.SPFile;
            DataSourceItemList myspname = JsonFileReader<DataSourceItemList>.GetSP_fromList(JsonFile);
            var mylist = from p in myspname.Summary
                         where p.Action == action
                         select p.ObjName.ToString() + p.Parameters.ToString();
           return mylist.FirstOrDefault();
         //   return GetSpNameFormJsonFile.SPName(action, "Summary");
        }
    }
}
