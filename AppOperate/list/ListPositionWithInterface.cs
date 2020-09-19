using ClassLibrary;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public class ListPositionWithInterface
    {
    }
    public interface IListPositions<T>
    {
        List<T> rList(ParametersForPositionList parameter);
    }

 
    public class AppliedPositionList : IListPositions<PositionListApplied>
    {
        public List<PositionListApplied> rList(ParametersForPositionList parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4
                string sp = "dbo.tcdsb_LTO_PositionList_TeacherApplied @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
                var list = GeneralDataAccess.GetListofTypeT<PositionListApplied>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }

    }
    public class ApplyingPositionList : IListPositions<PositionListApplying>
    {
        public List<PositionListApplying> rList(ParametersForPositionList parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4
                string sp = "dbo.tcdsb_LTO_PositionList_ApplicantApplying @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
                var list = GeneralDataAccess.GetListofTypeT<PositionListApplying>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }

    }
    public class ApprovePositionList : IListPositions<PositionListApprove>
    {
        public List<PositionListApprove> rList(ParametersForPositionList parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4  tcdsb_LTO_PositionList_RequestPostingWithSearch
                string sp = "dbo.tcdsb_LTO_PositionList_ApprovingRequest @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
                var list = GeneralDataAccess.GetListofTypeT<PositionListApprove>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
    }

    public class ConfirmPositionList : IListPositions<PositionListConfirm>
    {
        public List<PositionListConfirm> rList(ParametersForPositionList parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4
                string sp = "dbo.tcdsb_LTO_PositionList_ConfrimForHire @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
                var list = GeneralDataAccess.GetListofTypeT<PositionListConfirm>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
    }
    public class HiredPositionList : IListPositions<PositionListHired>
    {
        public List<PositionListHired> rList(ParametersForPositionList parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4
                string sp = "dbo.tcdsb_LTO_PositionList_Hired @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
                var list = GeneralDataAccess.GetListofTypeT<PositionListHired>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }


    }
    public class InterviewPositionList : IListPositions<PositionListInterview>
    {
        public List<PositionListInterview> rList(ParametersForPositionList parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4
                string sp = "dbo.tcdsb_LTO_PositionList_Interview @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
                var list = GeneralDataAccess.GetListofTypeT<PositionListInterview>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
    }
    public class PostingPositionList : IListPositions<PositionListPosting>
    {        /// <summary>
             ///            get posting position list 
             /// </summary>
             /// <param name="parameter"></param>
             /// <returns></returns>
        public List<PositionListPosting> rList(ParametersForPositionList parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4
                string sp = "dbo.tcdsb_LTO_PositionList_Posting @Operate, @UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
                var list = GeneralDataAccess.GetListofTypeT<PositionListPosting>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
    }
    public class PublishPositionList : IListPositions<PositionListPublish>
    {


        public List<PositionListPublish> rList(ParametersForPositionList parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4
                string sp = "dbo.tcdsb_LTO_PositionList_Published @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
                var list = GeneralDataAccess.GetListofTypeT<PositionListPublish>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
    }
    public class RequestingPositionList : IListPositions<PositionListRequesting>
    {

        public List<PositionListRequesting> rList(ParametersForPositionList parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4
                string sp = "dbo.tcdsb_LTO_PositionList_RequestForApprove @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
                var list = GeneralDataAccess.GetListofTypeT<PositionListRequesting>(sp, parameter);
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
