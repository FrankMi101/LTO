using ClassLibrary;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{



    public class PostingPublish : IPosition<PositionPublish, int>, IPositions<PositionListPublish, int>, IOperate<PositionPublish, int>
    {
       
        public  IList<PositionPublish> Position(ParametersForPosition parameter)
        {
            try
            {
                string sp = "dbo.tcdsb_LTO_PagePublish_Position @SchoolYear, @PositionID";
                var position = GeneralDataAccess.GetListofTypeT<PositionPublish>(sp, parameter);
                return position;
            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
                return null;
            }
        }
        public IList<PositionListPublish> Positions(ParametersForPositionList parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4  tcdsb_LTO_PositionList_RequestPostingWithSearch
                string sp = "dbo.tcdsb_LTO_PagePublish_Positions @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
                var list = GeneralDataAccess.GetListofTypeT<PositionListPublish>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
        public string CancelPosting(object position, int positionID)
        {
            try
            {   //  @Operate ="Cancel"
                string sp = GetSP("Cancel");// "dbo.tcdsb_LTO_PagePublish_Operation @Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID,@PositionType, @Comments";
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
            {    //  @Operate ="RePosting"
                string sp = GetSP("RePosting");// "dbo.tcdsb_LTO_PagePublish_Operation @Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID,@PositionType, @Comments,@PostingCycle,@TakeApplicant";
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
                string sp = "dbo.tcdsb_LTO_PagePublish_Operation @Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID";
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
            {  //  @Operate ="Delete"
                string sp = GetSP("Delete");// "dbo.tcdsb_LTO_PagePublish_Operation @Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID";
                var result = GeneralDataAccess.TextValue<string>(sp, position);
               // var result = GeneralDataAccess.TextValue(sp, position);
                return result.ToString();
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }
        public string CreatePosting(object position, int positionID)
        {
            try
            {    //Operate ="Save"
                 //  StaffProfile parameter = new StaffProfile { Operate = operate, UserID = userID, CPNum = CPNum, Action = action };
                string sp = GetSP("CreateNew") ;// "dbo.tcdsb_LTO_PagePublish_CreateNewAndGetRequestID @Operate, @SchoolYear, @PositionID, @PositionType,@UserID, @SchoolCode";
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
            {    //Operate ="Save"
                //  StaffProfile parameter = new StaffProfile { Operate = operate, UserID = userID, CPNum = CPNum, Action = action };
               // string paramaters = "@Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID,@PositionType, @Comments, @PositionTitle,@PositionLevel, @Description, @Qualification, @QualificationCode,@FTE, @FTEPanel, @StartDate, @EndDate, @DatePublish, @DateApplyOpen,@DateApplyClose,@ReplaceTeacherID, @ReplaceTeacher, @ReplaceReason, @OtherReason, @Owner";
                string sp = GetSP("Save");//  "dbo.tcdsb_LTO_PagePublish_OperationSave " + paramaters;
                var result = GeneralDataAccess.TextValue(sp, position);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }

        public List<LimitDate> LimitedDate(object parameter)
        {
            try
            {
                string sp = "dbo.tcdsb_LTO_PagePublish_DefaultDate @Operate, @AppType, @SchoolYear, @DatePublish";
                List<LimitDate> limitedate = GeneralDataAccess.GetListofTypeT<LimitDate>(sp, parameter);
                return limitedate;
            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
                return null;
            }
        }
        public List<LimitDate> LimitedDate(object parameter, DateTime publishDate)
        {
            try
            {
                string sp = "dbo.tcdsb_LTO_PagePublish_DefaultDate @Operate, @AppType, @SchoolYear,@DatePublish";
                List<LimitDate> limitedate = GeneralDataAccess.GetListofTypeT<LimitDate>(sp, parameter);
                return limitedate;
            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
                return null;
            }
        }
        public string MultiplePrinciaplEmail(ParametersForOperation parameter)
        {
            try
            {    //  @Operate ="RePosting"
                string sp = GetSP("MultiplePrinciapl");// "dbo.tcdsb_LTO_PagePublish_Operation @Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID";
                var result = GeneralDataAccess.TextValue(sp, parameter);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }
        public string PostingPublishOperation(PositionPublish position, string positionID)
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
            string parameter = " @Operate, @UserID, @SchoolYear, @SchoolCode, @PositionID";
            string parameters = parameter + ", @PositionType";
            string parameters2 = ", @Comments, @PositionTitle ,@PositionLevel, @Description, @Qualification, @QualificationCode,@FTE, @FTEPanel, @StartDate, @EndDate, @DatePublish, @DateApplyOpen,@DateApplyClose,@ReplaceTeacherID, @ReplaceTeacher, @ReplaceReason, @OtherReason, @Owner"; 
            switch (action)
            {
                case "Cancel":
                     return  "dbo.tcdsb_LTO_PagePublish_Operation " +  parameters + ", @Comments";
                case "RePosting":
                    return "dbo.tcdsb_LTO_PagePublish_Operation" + parameters + ", @Comments,@PostingCycle,@TakeApplicant";
                case "Delete":
                    return "dbo.tcdsb_LTO_PagePublish_Operation" + parameters;
                case "MultiplePrinciapl":
                    return "dbo.tcdsb_LTO_PagePublish_Operation" + parameter;
                case "Save":
                    return "dbo.tcdsb_LTO_PagePublish_OperationSave" + parameters + parameters2;
                case "CreateNew":
                    return "dbo.tcdsb_LTO_PagePublish_CreateNewAndGetRequestID" + parameters;
                default:
                    return "";

            }

        }
    }
}