using ClassLibrary;
using DataAccess;
using DataAccess.Repository;
using System.Collections.Generic;
using System.Linq;
namespace AppOperate
{
    public class PositionListCheckExe
    {
        private readonly static IAppServices _action = new AppServices( new PositionsCheck(DBConnection.DBSource));

        public PositionListCheckExe()
        {
        }
   
        public static List<PositionListPublish> PublishPositions(object parameter)
        {
            string sp = GetSp("PublishPositions");
            return _action.AppOne.CommonList<PositionListPublish>(sp, parameter);
           // return CommonExcute<PositionListPublish>.GeneralList(sp, parameter);
        }
        public static List<PositionListHired> HiredPositions(object parameter)
        {
            string sp = GetSp("HiredPositions");
            return _action.AppOne.CommonList<PositionListHired>(sp, parameter);
            //           return CommonExcute<PositionListHired>.GeneralList(sp, parameter);
        }
        public static List<PositionListApplying> AvailablePositions(object parameter)
        {
            string sp = GetSp("AvailablePositions");
            return _action.AppOne.CommonList<PositionListApplying>(sp, parameter);
            //           return CommonExcute<PositionListApplying>.GeneralList(sp, parameter);
        }
        public static List<PositionListPublish> SelectPositions(object parameter)
        {
            string sp = GetSp("SelectPositions");
            return _action.AppOne.CommonList<PositionListPublish>(sp, parameter);
            //           return CommonExcute<PositionListPublish>.GeneralList(sp, parameter);
        }

        public static List<PositionListPublish> InterviewPositions(object parameter)
        {
            string sp = GetSp("InterviewPositions");
            return _action.AppOne.CommonList<PositionListPublish>(sp, parameter);
            //           return CommonExcute<PositionListPublish>.GeneralList(sp, parameter);
        }

        public static List<ApplicantListSelect> SelectCandidates(object parameter)
        {
            string sp = GetSp("SelectCandidates");
            return _action.AppOne.CommonList<ApplicantListSelect>(sp, parameter);
            //          return CommonExcute<ApplicantListSelect>.GeneralList(sp, parameter);
        }
        public static List<CandidateList> InterviewCandidates(object parameter)
        {
            string sp = GetSp("InterviewCandidates");
            return _action.AppOne.CommonList<CandidateList>(sp, parameter);
            //           return CommonExcute<CandidateList>.GeneralList(sp, parameter);
        }
        public static List<GeneralCheck> ConvertFunctionStringToTable(object parameter)
        {
            string sp = GetSp("ConvertFunction");
            return _action.AppOne.CommonList<GeneralCheck>(sp, parameter);
            //            return CommonExcute<GeneralCheck>.GeneralList(sp, parameter);
        }
        public static string ConvertFunctionTableToString(object parameter)
        {
            string sp = GetSp("ConvertFunction");
            return _action.AppOne.CommonAction(sp, parameter);
            //           return CommonExcute<string>.GeneralValue(sp, parameter);
        }

        private static string GetSp(string action)
        {
            if (SPSource.SPFile == "")
            { return GetSPInClass(action); }
            else
            { return GetSpFromJsonFile(action); }

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
        private static string GetSpFromJsonFile(string action)
        {
            return GetSpNameFormJsonFile.SPName(action, "Publish");
        }
    }
}
