using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public class PostingApproveRequestExe
    {
    

        public static  List<PositionListApprove> Positions(ParametersForPositionList parameter)
        {
           // var mylist = new PostingApproveRequest();
           // return mylist.Positions(parameter);
            var mylist = new CommonList<PositionListApprove>();
            return mylist.ListPositions(parameter);
        }
        public static  List<PositionApprove> Position(ParametersForPosition parameter)
        {
           // var mylist = new PostingApproveRequest();
           // return mylist.Position(parameter);
           var mylist = new CommonList<PositionApprove>();
            return mylist.ListPosition(parameter);
        }
        public static IList<MultipleSchoolEmail> MultipleSchoolPrinciapls(ParametersForPosition parameter)
        {
            var mylist = new PostingApproveRequest();
            return mylist.MultipleSchoolPrinciapls(parameter);
        }
        public static string RejectRequest(PositionApprove operation, int positonID)
        {
            var myval = new PostingApproveRequest();
            return myval.RejectRequestPosting(operation, positonID);
        }
        public static string PostingRequest(PositionPublish operation, int positonID)
        {
            var myval = new PostingApproveRequest();
            return myval.Posting(operation, positonID);
        }
        //public static string UpdatePosting(PositionApprove position, int positonID)
        //{
        //    var myval = new PostingApproveRequest();
        //    return myval.UpdatePosting(position, positonID);
        //}
        public static string DeletePosting(PositionApprove operation, int positonID)
        {
            var myval = new PostingApproveRequest();
            return myval.DeletePosting(operation, positonID);
        }
        public static string SavePosting(PositionApprove position, int positonID)
        {
            var myval = new PostingApproveRequest();
            return myval.SavePosting(position, positonID);
        }
        public static string TestCount(PositionApprove position, int positonID)
        {
            var myval = new PostingApproveRequest();
            return myval.TestCount(position, positonID);
        }
        public static string PostingNumber( int positonID)
        {
            var myval = new PostingApproveRequest();
            return myval.GetPostingProperty("PostingNumber", positonID);
        }
        public static List<LimitDate> LimitedDate(object parameter)
        {
            var myval = new PostingPublish();
            return myval.LimitedDate(parameter);
        }
    }
}
