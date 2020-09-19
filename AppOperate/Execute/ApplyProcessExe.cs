using ClassLibrary;
using System.Collections.Generic;
using System.Linq;

namespace AppOperate
{
    public class ApplyProcessExe
    {
        public ApplyProcessExe()
        {
        }

        public static string SPName(string action)
        {
            return GetSP(action);
        }
        public static List<PositionListApplying> Positions(object parameter)
        {
            string SP = GetSP("Positions");
            return CommonExcute<PositionListApplying>.GeneralList(SP, parameter);
        }
        public static List<PositionListApplied> AppliedPositions(object parameter)
        {
            string SP = GetSP("PositionsApplied");
            return CommonExcute<PositionListApplied>.GeneralList(SP, parameter);
        }
        public static List<PositionApplying> Position(object parameter)
        {
            string SP = GetSP("Position");
            return CommonExcute<PositionApplying>.GeneralList(SP, parameter);
        }
        public static List<ApplicantContact> ContactInfo(object parameter)
        {
            string SP = GetSP("ContactInfo");
            return CommonExcute<ApplicantContact>.GeneralList(SP, parameter);
        }
        public static List<PositionQualificationCheck> QualficationCheck(object parameter)
        {
            string SP = GetSP("QualificationCheck");
            return CommonExcute<PositionQualificationCheck>.GeneralList(SP, parameter);
        }
        public static string Appied(object parameter)
        {
            string SP = GetSP("Applied");
            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        //public static string Rescind(object parameter)
        //{
        //    string SP = GetSP("Rescind");
        //    return CommonExcute<string>.GeneralValue(SP, parameter);
        //}
        //public static string Cancel(object parameter)
        //{
        //    string SP = GetSP("Cancel");
        //    return CommonExcute<string>.GeneralValue(SP, parameter);
        //}
        public static string UpdateContact(object parameter)
        {
            string SP = GetSP("UpdateContact");
            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string OCTQualfication(object parameter)
        {
            string SP = GetSP("OCTQualfication");
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
            string parameter = " @Operate, @UserID, @SchoolYear, @PositionID,@CPNum,@Action,@Comments";
            string pForList0 = " @Operate,@UserID,@SchoolYear,@PositionType,@SearchBy, @SearchValue1";
            switch (action)
            {
                case "PositionsApplied":
                    return "dbo.tcdsb_LTO_PageApply_AppliedPositions" + "  @Operate,@UserID,@SchoolYear,@PositionType,@CPNum";
                case "Positions":
                    return "dbo.tcdsb_LTO_PageApply_AvailablePositions" + pForList0 + ",@UserRole, @CPNum";
                case "Position":
                    return "dbo.tcdsb_LTO_PageApply_ApplyingPosition" + " @SchoolYear,@PositionID,@CPNum";
                case "Applied":
                    return "dbo.tcdsb_LTO_PageApply_Operation" + parameter;
                case "Rescind":
                    return "dbo.tcdsb_LTO_PageApply_Operation" + parameter;
                case "AppliedOnBehalf":
                    return "dbo.tcdsb_LTO_PageApply_Operation" + parameter;
                case "Cancel":
                    return "dbo.tcdsb_LTO_PageApply_Operation" + parameter;
                case "OCTQualification":
                    return "dbo.tcdsb_LTO_PageApply_OCTQualification" + " @SchoolYear, @PositionID, @CPNum";
                case "QualificationCheck":
                    return "dbo.tcdsb_LTO_PageApply_QualificationCheck" + " @SchoolYear, @PositionID, @CPNum";
                case "UpdateContact":
                    return "dbo.tcdsb_LTO_PageApply_ApplicantContactInfo" + " @Operate, @CPNum, @HomePhone, @CellPhone, @Email, @PositionID ";
                case "ContactInfo":
                    return "dbo.tcdsb_LTO_PageApply_ApplicantContactInfo" + " @Operate, @CPNum";
                case "ApplicantComment":
                    return "dbo.tcdsb_LTO_PageApply_ApplicantComments" + parameter;
                default:
                    return action;

            }
        }
        private static string GetSPFromJsonFile(string action)
        {
            return GetSpNameFormJsonFile.SPName(action, "Apply");
        }
    }
}
