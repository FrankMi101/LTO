using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public class LTOStaffManageExe
    {
        public LTOStaffManageExe()
        {
        }
        public static string SPName(string action)
        {
            return GetSP(action);
        }
        public static List<Staff> TCDSBStaffs(object parameter)
        {
            string SP = GetSP("TCDSBStaffs");
            return CommonExcute<Staff>.GeneralList(SP, parameter);
        }
        public static List<HRComments> CommentsList(object parameter)
        {
            string SP = GetSP("CommentsList");
            return CommonExcute<HRComments>.GeneralList(SP, parameter);
        }
        public static List<Staff> LTOStaffs(object parameter)
        {
            string SP = GetSP("LTOStaffs");
            return CommonExcute<Staff>.GeneralList(SP, parameter);
        }
        public static List<Staff> Staff(object parameter)
        {
            string SP = GetSP("Staff");
            return CommonExcute<Staff>.GeneralList(SP, parameter);
        }
        public static string Save(object parameter)
        {
            string SP = GetSP("Save");
            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string SaveRanking(object parameter)
        {
            string SP = GetSP("SaveRanking");
            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string ApplicantOTType(object parameter)
        {
            string SP = GetSP("OTType");
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
 
            string ParaPositions = "  @SearchBy,@SearchValue";

            switch (action)
            {
                case "TCDSBStaffs":
                    return "dbo.tcdsb_LTO_PageStaffManage_TCDSBStaffList" + ParaPositions;
                case "LTOStaffs":
                    return "dbo.tcdsb_LTO_PageStaffManage_LTOList" + ParaPositions;
                case "Staff":
                    return "dbo.tcdsb_LTO_PageStaffManage_Staff" + " @CPNum,@Source";
                case "OTType":
                    return "dbo.tcdsb_LTO_PageStaffManager_OTType" + " @CPNum";
                case "Save":
                    return "dbo.tcdsb_LTO_PageStaffManager_Operation" + " @UserID,@CPNum,@Action,@Comments,@IDs,@CommentsDate,@DateOfHire,@Ranking,@Lots";
                case "SaveRanking":
                    return "dbo.tcdsb_LTO_PageStaffManager_OperationRanking" + " @Operate,@UserID,@CPNum,@DateOfHire,@Ranking,@Lots";
                case "CommentsList":
                    return "dbo.tcdsb_LTO_PageStaffManager_HRComments" + " @UserID,@CPNum,@Action"; 
               default:
                    return action;

            }
        }
        private static string GetSPFromJsonFile(string action)
        {
            return GetSpNameFormJsonFile.SPName(action, "Staff");
        }
    }
}
