using ClassLibrary;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
                                         
    public class PostingHire 
    {  
        public string RevokeHire(object position, int positionID)
        {
            try
            {
                string sp = "dbo.tcdsb_LTO_PageHired_Operation @Operate, @UserID, @SchoolYear, @PositionType, @PositionID, @CPNum, @Action";
                var result = GeneralDataAccess.TextValue(sp, position);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }
        public string ConfirmHire(object position, int positionID)
        {
            try
            {
                string sp = "dbo.tcdsb_LTO_PageConfirmForHiring_Operation @Operate, @UserID, @SchoolYear, @PositionType, @PositionID, @CPNum, @Comments,@Acceptance, @DateConfirm, @DateEffective, @DateEnd, @PrincipalEmail, @OfficerEmail, @Action, @PayStatus";
                var result = GeneralDataAccess.TextValue(sp, position);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }
        public string ConfirmHire4thRound(object position, int positionID)
        {
            try
            {
                string sp = "dbo.tcdsb_LTO_PageConfirmForHiring4th_Operation @Operate, @UserID, @SchoolYear, @PositionType, @PositionID, @CPNum, @Comments,@Acceptance, @DateConfirm, @DateEffective, @DateEnd, @PrincipalEmail, @OfficerEmail, @Action, @PayStatus,@TeacherName";
                var result = GeneralDataAccess.TextValue(sp, position);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }

        public string HiringTeacherName(object position)
        {
            try
            {
                string paramaters = "@SchoolYear, @PositionID, @CPNum";
                string sp = "dbo.tcdsb_LTO_checkTeacherNamebyCPNum " + paramaters;
                var result = GeneralDataAccess.TextValue(sp, position);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }
 
        public string UpdatePosting(object position, int positionID)
        {
            try
            {    //  @Operate ="RePosting"
                string sp = "dbo.tcdsb_LTO_PageConfirmForHiring_Operation @Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID,@Comments";
                var result = GeneralDataAccess.TextValue(sp, position);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }

        public string HiringOperation(ParametersForOperationHire position, string action)
        {
            try
            {
                string sp =  GetSP(action);
                var result = GeneralDataAccess.TextValue(sp, position);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }


        private string GetSP(string action)
        {
            string parameters = "  @Operate, @UserID, @SchoolYear, @PositionType, @PositionID, @CPNum";
             switch (action)
            {
                case "Revoke":
                     return "dbo.tcdsb_LTO_PageHired_Operation" + parameters + ", @Action";
                case "ConfirmHire":
                    return "dbo.tcdsb_LTO_PageConfirmForHiring_Operation" + parameters + ", @Comments,@Acceptance, @DateConfirm, @DateEffective, @DateEnd, @PrincipalEmail, @OfficerEmail, @Action, @PayStatus";
                case "ConfirmHire4th":
                    return "dbo.tcdsb_LTO_PageConfirmForHiring_Operation " + parameters + ", @Comments,@Acceptance, @DateConfirm, @DateEffective, @DateEnd, @PrincipalEmail, @OfficerEmail, @Action, @PayStatus";
                case "Update":
                    return "dbo.tcdsb_LTO_PageConfirmForHiring_Operation " + parameters   ;
                case "Property":
                    return "dbo.tcdsb_LTO_PageApprove_Property @Operate,@PositionID";
                default:
                    return "";

            }

        }

    }
}
