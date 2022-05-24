using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppOperate.Execute;
using DataAccess;
using DataAccess.Repository;

namespace AppOperate
{
    public class InterviewProcessExe
    {
        private readonly static IAppServices _action = new AppServices( new InterviewResults(DBConnection.DBSource));

        public InterviewProcessExe()
        {
        }
   
        public static List<PositionListInterview> Positions(object parameter)
        {
            string sp = GetSp("Positions");
            return _action.AppOne.CommonList<PositionListInterview>(sp, parameter);
           // return CommonExcute<PositionListInterview>.GeneralList(sp, parameter);
        }
        public static List<PositionInterview> Position(object parameter)
        {
            string sp = GetSp("Position");
            return _action.AppOne.CommonList<PositionInterview>(sp, parameter);
            //            return CommonExcute<PositionInterview>.GeneralList(sp, parameter);
        }
        public static List<CandidateList> Candidates(object parameter)
        {
            string sp = GetSp("Candidates");
            return _action.AppOne.CommonList<CandidateList>(sp, parameter);
            //             return CommonExcute<CandidateList>.GeneralList(sp, parameter);
        }
        public static List<PositionInterview> Candidate(object parameter)
        {
            string sp = GetSp("Candidate");
            return _action.AppOne.CommonList<PositionInterview>(sp, parameter);
            //            return CommonExcute<PositionInterview>.GeneralList(sp, parameter);
        }
        public static List<InterviewerTeam> TeamMember(object parameter)
        {
            string sp = GetSp("TeamMember");
            return _action.AppOne.CommonList<InterviewerTeam>(sp, parameter);
            //            return CommonExcute<InterviewerTeam>.GeneralList(sp, parameter);
        }
        public static List<InterviewerTeam> Signatures(object parameter)
        {
            string sp = GetSp("Signatures");
            return _action.AppOne.CommonList<InterviewerTeam>(sp, parameter);
            //            return CommonExcute<InterviewerTeam>.GeneralList(sp, parameter);
        }

        public static string UpdateMember(object parameter)
        {
            string sp = GetSp("UpdateMember");
            return _action.AppOne.CommonAction(sp, parameter);
           // return CommonExcute<string>.GeneralValue(sp, parameter);
        }

        public static string Update(object parameter)
        {
            string sp = GetSp("Update");
            return _action.AppOne.CommonAction(sp, parameter);
            //          return CommonExcute<string>.GeneralValue(sp, parameter);
        }

        public static string Recommend(object parameter)
        {
            string sp = GetSp("Recommend");
            return _action.AppOne.CommonAction(sp, parameter);
            //           return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string OutcomeUpdate(object parameter)
        {
            string sp = GetSp("OutcomeUpdate");
            return _action.AppOne.CommonAction(sp, parameter);
            //           return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string PositionHiringStatus(object parameter)
        {
            string sp = GetSp("PositionHiringStatus");
            return _action.AppOne.CommonAction(sp, parameter);
            //            return CommonExcute<string>.GeneralValue(sp, parameter);
        }

        public static string SignOffCount(object parameter)
        {
            string sp = GetSp("SignOffCount");
            return _action.AppOne.CommonAction(sp, parameter);
            //           return CommonExcute<string>.GeneralValue(sp, parameter);
        }

        public static string InterviewCount(object parameter)
        {
            string sp = GetSp("InterviewCount");
            return _action.AppOne.CommonAction(sp, parameter);
            //           return CommonExcute<string>.GeneralValue(sp, parameter);
        }

        public static string SignOffAction(object parameter)
        {
            string sp = GetSp("SignOffAction");
            return _action.AppOne.CommonAction(sp, parameter);
            //            return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string SendNoticeToPrincipal(object parameter)
        {
            string sp = GetSp("SendNoticeToPrincipal");
            return _action.AppOne.CommonAction(sp, parameter);
            //           return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string SignatureName(object parameter)
        {
            string sp = GetSp("SignatureName");
            return _action.AppOne.CommonAction(sp, parameter);
            //           return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string RequestMoreInterview(object parameter)
        {
            string sp = GetSp("RequestMoreInterview");
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
           
            return GetSpNameFormJsonFile.SPName(action, "Interview");
        }
    }

}
