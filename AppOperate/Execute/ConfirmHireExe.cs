using ClassLibrary;
using DataAccess;
using DataAccess.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AppOperate
{
    public class ConfirmHireExe
    {
        private readonly static IAppServices _action = new AppServices(DBConnection.DBSource, new ConfirmHire());

        public ConfirmHireExe()
        {
        }
   
        public static List<PositionListConfirm> Positions(object parameter)
        {
            string SP = GetSP("Positions", parameter);
            // return CommonExcute<PositionListConfirm>.GeneralList(SP, parameter);
            return _action.AppOne.CommonList<PositionListConfirm>(SP, parameter);
        }
        public static List<PositionHire> Position(object parameter)
        {
            string SP = GetSP("Position", parameter);
            return _action.AppOne.CommonList<PositionHire>(SP, parameter);

          //  return CommonExcute<PositionHire>.GeneralList(SP, parameter);
        }
        public static List<PositionHire4thRound> Position4th(object parameter)
        {
            string SP = GetSP("Position4th", parameter);
            return _action.AppOne.CommonList<PositionHire4thRound>(SP, parameter);

            //        return CommonExcute<PositionHire4thRound>.GeneralList(SP, parameter);
        }
        public static string Confirm(object parameter)
        {
            string SP = GetSP("Confirm", parameter);
            return _action.AppOne.CommonAction(SP, parameter);
            //return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string Confirm4th(object parameter)
        {
            string SP = GetSP("Confirm4th", parameter);
            return _action.AppOne.CommonAction(SP, parameter);
            //           return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string Revoke(object parameter)
        {
            string SP = GetSP("Revoke",parameter);
            return _action.AppOne.CommonAction(SP, parameter);
            //          return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string PernrNum(object parameter)
        {
            string SP = GetSP("PernrNum", parameter);
            return _action.AppOne.CommonAction(SP, parameter);
            //           return CommonExcute<string>.GeneralValue(SP, parameter);
        }

        private static string GetSP(string action, object parameter)
        {
            if (SPSource.SPFile == "")
            { return GetSPInClass(action,parameter); }
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
            return _action.AppOne.SpName(action, parameter);
          
        }
        private static string GetSPFromJsonFile(string action)
        {  
            return GetSpNameFormJsonFile.SPName(action, "ConfrimHire");
        }
    }
}
