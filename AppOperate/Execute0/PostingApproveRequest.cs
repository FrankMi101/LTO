using ClassLibrary;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{


    public class PostingApproveRequest : IPosition<PositionApprove, int>, IPositions<PositionListApprove, int>, IOperate<PositionApprove, int>
    {

        public IList<PositionApprove> Position(ParametersForPosition parameter)
        {
            try
            {
                string sp = "dbo.tcdsb_LTO_PageApprove_Position @SchoolYear, @PositionID";
                var position1 = GeneralDataAccess.GetListofTypeT<PositionApprove>(sp, parameter);
                return position1;
            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
                return null;
            }
        }

        public IList<PositionListApprove> Positions(ParametersForPositionList parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4  tcdsb_LTO_PositionList_RequestPostingWithSearch
                string sp = "dbo.tcdsb_LTO_PageApprove_Positions @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
                var list = GeneralDataAccess.GetListofTypeT<PositionListApprove>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }

        public IList<MultipleSchoolEmail> MultipleSchoolPrinciapls(ParametersForPosition parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4  tcdsb_LTO_PositionList_RequestPostingWithSearch
                string sp = "dbo.tcdsb_LTO_PageApprove_MultipleSchoolPrincipal @SchoolYear, @PositionID";
                var list = GeneralDataAccess.GetListofTypeT<MultipleSchoolEmail>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }


        public string RejectRequestPosting(object position, int positionID)
        {   // Exec Rejection 
            try
            {      // Operate = "Reject"
                string sp = GetSP("Reject");// "dbo.tcdsb_LTO_PageApprove_Operation @Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID, @Comments,@CPNum";
                var result = GeneralDataAccess.TextValue(sp, position);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }

        public string RePosting(object position, int positionID)
        {
            try
            {
                string sp = GetSP("RePosting");//  "dbo.tcdsb_LTO_PageApprove_Operation @Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID,@Comments,@CPNum,@StartDate,@EndDate,@DatePublish,@DateApplyOpen,@DateApplyClose";
                var result = GeneralDataAccess.TextValue(sp, position);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }
        public string Posting(object position, int positionID)
        {
            try
            {
                 string sp = GetSP("Posting");//"dbo.tcdsb_LTO_PageApprove_Operation @Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID,@Comments,@CPNum,@StartDate,@EndDate,@DatePublish,@DateApplyOpen,@DateApplyClose,@RequestSource";
                var result = GeneralDataAccess.TextValue(sp, position);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }
        public string TestCount(object position, int positionID)
        {
            try
            {    //  @Operate ="RePosting"
                string sp = GetSP("TestCount");//  "dbo.tcdsb_LTO_PageApprove_Operation @Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID";
                var result = GeneralDataAccess.TextValue(sp, position);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }
        public string SavePosting(object position, int positionID)
        {
            try
            {
                //  StaffProfile parameter = new StaffProfile { Operate = operate, UserID = userID, CPNum = CPNum, Action = action };
               // string paramaters = "@Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID, @Comments, @PositionLevel, @Qualification, @QualificationCode, @Description, @FTE, @FTEPanel, @StartDate,@EndDate, @Owner";
                string sp = GetSP("Save");//  = "dbo.tcdsb_LTO_PageApprove_OperationSave " + paramaters;
                var result = GeneralDataAccess.TextValue(sp, position);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }


        public string DeletePosting(object position, int positionID)
        {
            try
            {
                string sp = GetSP("Delete"); // "dbo.tcdsb_LTO_PageApprove_Operation @Operate,@UserID,@SchoolYear,@SchoolCode, @PositionID,@Comments";
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
                string sp = GetSP("Update"); //"ddbo.tcdsb_LTO_PageApprove_Operation @Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID,@Comments";
                var result = GeneralDataAccess.TextValue(sp, position);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }
        public string GetPostingProperty(string operate, int positionID)
        {
            try
            {    //  @Operate ="RePosting"
                string sp = GetSP("Property"); // = "dbo.tcdsb_LTO_PageApprove_Property @Operate,@PositionID";
                ParametersForOperation parameter = new ParametersForOperation { Operate = operate, PositionID = positionID };
                var result = GeneralDataAccess.TextValue(sp, parameter);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }

        public string CancelPosting(object position, int positionID)
        {
            throw new NotImplementedException();
        }
        public string PostingApproveOperation(PositionApprove position, string action)
        {
            try
            {
                string sp = GetSP(position.Operate);
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
            string parameters = " @Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID, @Comments";
            string parameter2 = ", @CPNum, @StartDate, @EndDate, @DatePublish, @DateApplyOpen, @DateApplyClose, @RequestSource";
            string parameter3 = ", @PositionLevel, @Qualification, @QualificationCode, @Description, @FTE, @FTEPanel, @StartDate,@EndDate @Owner";
            switch (action)
            {
                case "Reject":
                    return "dbo.tcdsb_LTO_PageApprove_Operation" + parameters + ", @CPNum";
                case "Update":
                    return "ddbo.tcdsb_LTO_PageApprove_Operation " + parameters;
                case "Posting":
                    return "dbo.tcdsb_LTO_PageApprove_Operation" + parameters + parameter2;
                case "Save":
                    return "dbo.tcdsb_LTO_PageApprove_OperationSave" + parameters + parameter3;
                case "Property":
                    return "dbo.tcdsb_LTO_PageApprove_Property @Operate,@PositionID";
                default:
                    return "";

            }

        }

    }
}
