using ClassLibrary;
using DataAccess;
using DataAccess.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AppOperate
{
    public class SelectCandidateExe
    {
        private readonly static IAppServices _action = new AppServices(new SelectCandidate(DBConnection.DBSource));

        public SelectCandidateExe() { }
 
        public static List<PositionListPublished> Positions(object parameter)
        {
            string SP = GetSP("Positions");
            return _action.AppOne.CommonList<PositionListPublished>(SP, parameter); 

           // return CommonExcute<PositionListPublished>.GeneralList(SP, parameter);
        }
        public static List<PositionPublished> Position(object parameter)
        {
            string SP = GetSP("Position");
            return _action.AppOne.CommonList<PositionPublished>(SP, parameter);

            //           return CommonExcute<PositionPublished>.GeneralList(SP, parameter);
        }
        public static List<ApplicantListSelect> Applicants(object parameter)
        {
            string SP = GetSP("Applicants");
            return _action.AppOne.CommonList<ApplicantListSelect>(SP, parameter);

            //           return CommonExcute<ApplicantListSelect>.GeneralList(SP, parameter);
        }
        public static List<ApplicantInterview> Applicant(object parameter)
        {
            string SP = GetSP("Applicant");
            return _action.AppOne.CommonList<ApplicantInterview>(SP, parameter);

            //           return CommonExcute<ApplicantInterview>.GeneralList(SP, parameter);
        }
        public static List<CandidateListNotice> NoticeCandidates(object parameter)
        {
            string SP = GetSP("NoticeCandidates");
            return _action.AppOne.CommonList<CandidateListNotice>(SP, parameter);

            //           return CommonExcute<CandidateListNotice>.GeneralList(SP, parameter);
        }
        public static string Save(object parameter)
        {
            string SP = GetSP("Save");
            return _action.AppOne.CommonAction(SP, parameter);
           // return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string NoticeUpdate(object parameter)
        {
            string SP = GetSP("NoticeUpdate");
            return _action.AppOne.CommonAction(SP, parameter);
            //             return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string SelectedForInterview(object parameter)
        {
            string SP = GetSP("SelectedForInterview");
            return _action.AppOne.CommonAction(SP, parameter);
            //             return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string Selected(object parameter)
        {
            string SP = GetSP("Selected");
            return _action.AppOne.CommonAction(SP, parameter);
            //             return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string UnSelected(object parameter)
        {
            string SP = GetSP("UnSelected");
            return _action.AppOne.CommonAction(SP, parameter);
            //             return CommonExcute<string>.GeneralValue(SP, parameter);
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
            return  _action.AppOne.SpName(action, parameter);
        }
        private static string GetSPFromJsonFile(string action)
        {
    
            return GetSpNameFormJsonFile.SPName(action, "SelectCandidate");
        }
    }
}

