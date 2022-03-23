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
    public class HiredPositionExe
    {
        private readonly static IAppServices _action = new AppServices(DBConnection.DBSource, new HiredPositions());

        public HiredPositionExe()
        {
        }
 
        public static List<PositionListHired> Positions(object parameter)
        {
            string SP = GetSP("Positions");
            return _action.AppOne.CommonList<PositionListHired>(SP, parameter);
            //            return CommonExcute<PositionListHired>.GeneralList(SP, parameter);
        }
        public static List<PositionHired> Position(object parameter)
        {
            string SP = GetSP("Position");
            return _action.AppOne.CommonList<PositionHired>(SP, parameter);
            //           return CommonExcute<PositionHired>.GeneralList(SP, parameter);
        }
        public static string Revoke(object parameter)
        {
            string SP = GetSP("Revoke");
            return _action.AppOne.CommonAction(SP, parameter);
            //           return CommonExcute<string>.GeneralValue(SP, parameter);
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
          return  GetSpNameFormJsonFile.SPName(action, "Hired");
        }
    }
}
