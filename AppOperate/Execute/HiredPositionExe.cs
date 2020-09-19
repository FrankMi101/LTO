using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppOperate.Execute;

namespace AppOperate
{
    public class HiredPositionExe
    {
        public HiredPositionExe()
        {
        }
        public static string SPName(string action)
        {
            return GetSP(action);
        }
        public static List<PositionListHired> Positions(object parameter)
        {
            string SP = GetSP("Positions");
            return CommonExcute<PositionListHired>.GeneralList(SP, parameter);
        }
        public static List<PositionHired> Position(object parameter)
        {
            string SP = GetSP("Position");
            return CommonExcute<PositionHired>.GeneralList(SP, parameter);
        }     
        public static string Revoke(object parameter)
        {
            string SP = GetSP("Revoke");
            return CommonExcute<string>.GeneralValue(SP, parameter);
        }


        private static string GetSP(string action)
        {
            if (SPSource.SPFile == "")
            { return GetSPInClass(action); }
            else
            { return GetSPFromJsonFile(action); }

        }
        private static string GetSPInClass(string action)
        {

             string ParaPosition = " @SchoolYear, @PositionID, @CPNum";
            string ParaPositions = " @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy,@SearchValue1,@SearchValue2";

            switch (action)
            {
                case "Positions":
                    return "dbo.tcdsb_LTO_PageHired_Positions" + ParaPositions;
                case "Position":
                    return "dbo.tcdsb_LTO_PageHired_Position" + ParaPosition;
                case "Revoke":
                    return "dbo.tcdsb_LTO_PageHired_OperationRevoke" + " @UserID," + ParaPosition;
                case "Delete":
                    return "dbo.tcdsb_LTO_PageHired_Operation" + " @UserID," + ParaPosition;
                default:
                    return "";

            }
        }
        private static string GetSPFromJsonFile(string action)
        {
          return  GetSpNameFormJsonFile.SPName(action, "Hired");
        }
    }
}
