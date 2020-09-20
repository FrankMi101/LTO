using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using DataAccess.Common;

namespace AppOperate
{
    public  class PositionWithInterface
    {
    }

    public interface ISinglePositions<T>
    {
        List<T> rPosition(ParametersForPosition parameter);
    }

    public class ApplyPosition : ISinglePositions<PositionApply>
    {
        public List<PositionApply> rPosition(ParametersForPosition parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4
                string sp = "dbo.tcdsb_LTO_PositionList_TeacherApplied @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
              
             var list = GeneralDataAccess.GetListofTypeT<PositionApply>(sp, parameter);
               
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
    }
    public class ApplyingPosition : ISinglePositions<PositionApply>
    {
       
        public List<PositionApply> rPosition(ParametersForPosition parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4
                string sp = "dbo.tcdsb_LTO_PositionList_ApplicantApplying @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
                 
                  var list = GeneralDataAccess.GetListofTypeT<PositionApply>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }

    }
    public class ApprovePosition : ISinglePositions<PositionApprove>
    {
        public List<PositionApprove> rPosition(ParametersForPosition parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4  tcdsb_LTO_PositionList_RequestPostingWithSearch
                string sp = "dbo.tcdsb_LTO_PositionList_ApprovingRequest @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
                var list = GeneralDataAccess.GetListofTypeT<PositionApprove>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
    }

    public class ConfirmPosition : ISinglePositions<PositionConfirm>
    {


        public List<PositionConfirm> rPosition(ParametersForPosition parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4
                string sp = "dbo.tcdsb_LTO_PositionList_ConfrimForHire @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
                var list = GeneralDataAccess.GetListofTypeT<PositionConfirm>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
    }
    public class HiredPosition : ISinglePositions<PositionHire>
    {
        public List<PositionHire> rPosition(ParametersForPosition parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4
                string sp = "dbo.tcdsb_LTO_PositionList_Hired @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
                var list = GeneralDataAccess.GetListofTypeT<PositionHire>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }


    }
    public class InterviewPosition : ISinglePositions<PositionInterview>
    {


        public List<PositionInterview> rPosition(ParametersForPosition parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4
                string sp = "dbo.tcdsb_LTO_PositionList_Interview @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
                var list = GeneralDataAccess.GetListofTypeT<PositionInterview>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
    }
    public class PostingPosition : ISinglePositions<PositionPosting>
    {        /// <summary>
             ///            get posting position list 
             /// </summary>
             /// <param name="parameter"></param>
             /// <returns></returns>
        public List<PositionPosting> rPosition(ParametersForPosition parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4
                string sp = "dbo.tcdsb_LTO_PositionList_Posting @Operate, @UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
                var list = GeneralDataAccess.GetListofTypeT<PositionPosting>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
    }
    public class PublishPosition : ISinglePositions<PositionPublish>
    {


        public List<PositionPublish> rPosition(ParametersForPosition parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4
                string sp = "dbo.tcdsb_LTO_PositionList_Published @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
                var list = GeneralDataAccess.GetListofTypeT<PositionPublish>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
    }
    public class RequestingPosition : ISinglePositions<PositionRequesting>
    {

        public List<PositionRequesting> rPosition(ParametersForPosition parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4
                string sp = "dbo.tcdsb_LTO_PositionList_RequestForApprove @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
                var list = GeneralDataAccess.GetListofTypeT<PositionRequesting>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
    }
}
