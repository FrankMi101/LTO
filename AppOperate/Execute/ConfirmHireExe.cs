using ClassLibrary;
using System.Collections.Generic;
using System.Linq;

namespace AppOperate
{
    public class ConfirmHireExe
    {
        public ConfirmHireExe()
        {
        }
        public static string SPName(string action)
        {
            return GetSP(action);
        }
        public static List<PositionListConfirm> Positions(object parameter)
        {
            string SP = GetSP("Positions");
            return CommonExcute<PositionListConfirm>.GeneralList(SP, parameter);
        }
        public static List<PositionHire> Position(object parameter)
        {
            string SP = GetSP("Position");
            return CommonExcute<PositionHire>.GeneralList(SP, parameter);
        }
        public static List<PositionHire4thRound> Position4th(object parameter)
        {
            string SP = GetSP("Position4th");
            return CommonExcute<PositionHire4thRound>.GeneralList(SP, parameter);
        }
        public static string Confirm(object parameter)
        {
            string SP = GetSP("Confirm");
            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string Confirm4th(object parameter)
        {
            string SP = GetSP("Confirm4th");
            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string Revoke(object parameter)
        {
            string SP = GetSP("Revoke");
            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string PernrNum(object parameter)
        {
            string SP = GetSP("PernrNum");
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

            string parameters = " @Operate,@UserID,@SchoolYear,@PositionType,@PositionID,@CPNum,@Comments,@Acceptance,@DateConfirm,@DateEffective,@DateEnd,@PrincipalEmail,@OfficerEmail,@PayStatus";
            string ParaPosition = " @SchoolYear, @PositionID, @CPNum";
            string ParaPositions = " @Operate,@UserID,@SchoolYear,@PositionType, @SearchBy, @SearchValue1";

            switch (action)
            {
                case "Positions":
                    return "dbo.tcdsb_LTO_PageConfirmHire_Positions" + ParaPositions;
                case "Position":
                    return "dbo.tcdsb_LTO_PageConfirmHire_Position" + ParaPosition;
                case "Position4th":
                    return "dbo.tcdsb_LTO_PageConfirmHire_Position4th" + ParaPosition;
                case "Confirm":
                    return "dbo.tcdsb_LTO_PageConfirmHire_Operation" + parameters;
                case "Confirm4th":
                    return "dbo.tcdsb_LTO_PageConfirmHire_Operation4th" + parameters + ",@TeacherName";
                case "Revoke":
                    return "dbo.tcdsb_LTO_PageConfirmHire_Revoke" + " @UserID,@SchoolYear,@PositionID,@CPNum,@Comments";
                case "PernrNum":
                    return "dbo.tcdsb_LTO_PageGeneral_Profile" + " @Operate,@UserID,@SchoolYear,@ProfileType,@CheckValue";
                default:
                    return action;

            }
        }
        private static string GetSPFromJsonFile(string action)
        {  
            return GetSpNameFormJsonFile.SPName(action, "ConfrimHire");
        }
    }
}
