using ClassLibrary;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public class ListPosition

    {

        public static List<PositionListPosting> PostingList(ParametersForPositionList parameter)
        {
            var mylist = new PostingPositionList();
            return mylist.rList(parameter);
        }
        public static List<PositionListApprove> ApproveList(ParametersForPositionList parameter)
        {
            var mylist = new ApprovePositionList();
            return mylist.rList(parameter);
        }
        public static List<PositionListPublish> PublishList(ParametersForPositionList parameter)
        {
            var mylist = new PublishPositionList();
            return mylist.rList(parameter);
        }
        public static List<PositionListConfirm> ConfirmList(ParametersForPositionList parameter)
        {
            var mylist = new ConfirmPositionList();
            return mylist.rList(parameter);
        }
        public static List<PositionListHired> HiredList(ParametersForPositionList parameter)
        {
            var mylist = new HiredPositionList();
            return mylist.rList(parameter);
        }
        public static List<PositionListInterview> InterviewList(ParametersForPositionList parameter)
        {
            var mylist = new InterviewPositionList();
            return mylist.rList(parameter);
        }
        public static List<PositionListApplying> ApplyingList(ParametersForPositionList parameter)
        {
            var mylist = new ApplyingPositionList();
            return mylist.rList(parameter);
        }
        public static List<PositionListApplied> AppliedList(ParametersForPositionList parameter)
        {
            var mylist = new AppliedPositionList();
            return mylist.rList(parameter);
        }
        public static List<PositionListRequesting> RequestingList(ParametersForPositionList parameter)
        {
            var mylist = new RequestingPositionList();
            return mylist.rList(parameter);
        }

        public static IList<PositionListPosting> PostingPositions(ParametersForPositionList parameter)
        {
            try
            {
                IPositionListRepository<PositionListPosting, string> repository = Factory.Get<ListPositionPosting>();
                IList<PositionListPosting> list = repository.GetList(parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
        public static IList<PositionListApprove> ApprovePositions(ParametersForPositionList parameter)
        {
            try
            {
                IPositionListRepository<PositionListApprove, string> repository = Factory.Get<ListPositionApprove>();
                IList<PositionListApprove> list = repository.GetList(parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }

        public static IList<PositionListPublish> PublishPositions(ParametersForPositionList parameter)
        {
            try
            {
                IPositionListRepository<PositionListPublish, string> repository = Factory.Get<ListPositionPublish>();
                IList<PositionListPublish> list = repository.GetList(parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }

        public static IList<PositionListConfirm> ConfirmPositions(ParametersForPositionList parameter)
        {
            try
            {
                IPositionListRepository<PositionListConfirm, string> repository = Factory.Get<ListPositionConfirm>();
                IList<PositionListConfirm> list = repository.GetList(parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
        public static IList<PositionListHired> HiredPositions(ParametersForPositionList parameter)
        {
            try
            {
                IPositionListRepository<PositionListHired, string> repository = Factory.Get<ListPositionHired>();
                IList<PositionListHired> list = repository.GetList(parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }

        public static IList<PositionListInterview> InterviewPositions(ParametersForPositionList parameter)
        {
            try
            {
                IPositionListRepository<PositionListInterview, string> repository = Factory.Get<ListPositionInterview>();
                IList<PositionListInterview> list = repository.GetList(parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
        public static IList<PositionListApplying> ApplyingPositions(ParametersForPositionList parameter)
        {
            try
            {
                IPositionListRepository<PositionListApplying, string> repository = Factory.Get<ListPositionApplying>();
                IList<PositionListApplying> list = repository.GetList(parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
        public static IList<PositionListApplied> AppliedPositions(ParametersForPositionList parameter)
        {
            try
            {
                IPositionListRepository<PositionListApplied, string> repository = Factory.Get<ListPositionApplied>();
                IList<PositionListApplied> list = repository.GetList(parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
        public static IList<PositionListRequesting> RequestingPositions(ParametersForPositionList parameter)
        {
            try
            {
                IPositionListRepository<PositionListRequesting, string> repository = Factory.Get<ListPositionRequesting>();
                IList<PositionListRequesting> list = repository.GetList(parameter);
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
