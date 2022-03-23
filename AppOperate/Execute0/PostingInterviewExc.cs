using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public class PostingInterviewExc
    {
    
        public static  List<PositionListInterview> Positions(ParametersForPositionList parameter)
        {
             var mylist = new CommonList<PositionListInterview>();
            return mylist.ListPositions(parameter);
        }
        public static  List<PositionListInterview> Position(ParametersForPosition parameter)
        {
            var mylist = new CommonList<PositionListInterview>();
            return mylist.ListPosition(parameter);
        }
        public static List<CandidateList> InterviewCandidates(ParametersForPosition parameter)
        {
            var mylist = new CommonList<CandidateList>();
            return mylist.ListCandidates(parameter);

        }
         public static List<PositionInterview> Candidate(ParametersForPosition parameter)
        {
             var mylist = new CommonList<PositionInterview>();
            return mylist.ListPosition(parameter);
        }
        public static string InterviewOperation(InterviewResult operation, string positonID)
        {
            var myval = new PostingInterview();
            return myval.InterviewOperation(operation, positonID );
 
        }
        /// <summary>
        /// InterviewOperation is general Method. It can replace all follow 6 procedures
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="positonID"></param>
        /// <returns></returns>
        public static string SaveInterview( InterviewResult operation, string positonID)
        {
            var myval = new  PostingInterview() ;
            return   myval.InterviewOperation(operation, positonID );
           // var myval = new CommonOperation<InterviewResult>();//  PostingInterview() ;
          //  return myval.Operation(operation, positonID);   //  myval.InterviewOperation(operation, positonID );

        }
        public static string RecommendHire(InterviewResult operation, string positonID)
        {
            var myval = new PostingInterview();
            return myval.InterviewOperation(operation, positonID );
        }
      public static string InterviewSignOffAction(InterviewResult operation, string positonID)
        {
            var myval = new PostingInterview();
            return myval.InterviewOperation(operation, positonID );
        }
        public static string CheckInterviewCount(InterviewResult operation, string positonID)
        {
            var myval = new PostingInterview();
            return myval.InterviewOperation(operation, positonID );
        }
        public static string CheckSignOffCount(InterviewResult operation, string positonID)
        {
            var myval = new PostingInterview();
            return myval.InterviewOperation(operation, positonID );
        }
        public static string CheckHiringProcessStatus(InterviewResult operation, string positonID)
        {
            var myval = new PostingInterview();
            return myval.InterviewOperation(operation, positonID );
        }
  
    }
}
