using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
  
    public class SinglePosition  

    {


        public static List<PositionPosting> PostingPosition(ParametersForPosition parameter)
        {
            var mylist = new PostingPosition();
            return mylist.rPosition(parameter);
        }
        public static List<PositionApprove> ApprovePosition(ParametersForPosition parameter)
        {
            var mylist = new ApprovePosition();
            return mylist.rPosition(parameter);
        }
        public static List<PositionPublish> PublishPosition(ParametersForPosition parameter)
        {
            var mylist = new PublishPosition();
            return mylist.rPosition(parameter);
        }
        public static List<PositionConfirm> ConfirmPosition(ParametersForPosition parameter)
        {
            var mylist = new ConfirmPosition();
            return mylist.rPosition(parameter);
        }
        public static List<PositionHire> HirePosition(ParametersForPosition parameter)
        {
            var mylist = new HiredPosition();
            return mylist.rPosition(parameter);
        }
        public static List<PositionInterview> InterviewPosition(ParametersForPosition parameter)
        {
            var mylist = new InterviewPosition();
            return mylist.rPosition(parameter);
        }
        public static List<PositionApply> ApplyingPosition(ParametersForPosition parameter)
        {
            var mylist = new ApplyingPosition();
            return mylist.rPosition(parameter);
        }
        public static List<PositionApply> AppllyPosition(ParametersForPosition parameter)
        {
            var mylist = new ApplyPosition();
            return mylist.rPosition(parameter);
        }
        public static List<PositionRequesting> RequestingPosition(ParametersForPosition parameter)
        {
            var mylist = new RequestingPosition();
            return mylist.rPosition(parameter);
        }
    }
}
