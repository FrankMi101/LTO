using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public class RequestingPostExe
    {
    

        public static  List<PositionListRequesting> Positions(ParametersForPositionList parameter)
        {
           // var mylist = new PostingApproveRequest();
           // return mylist.Positions(parameter);
            var mylist = new CommonList<PositionListRequesting>();
            return mylist.ListPositions(parameter);
        }
        public static  List<PositionRequesting> Position(ParametersForPosition parameter)
        {
           // var mylist = new PostingApproveRequest();
           // return mylist.Position(parameter);
           var mylist = new CommonList<PositionRequesting>();
            return mylist.ListPosition(parameter);
        }
        public static List<PositionInfo> PositionInfo(ParametersForPosition parameter)
        {
            // var mylist = new PostingApproveRequest();
            // return mylist.Position(parameter);
            var mylist = new CommonList<PositionInfo>();
            return mylist.ListPosition(parameter);
 
        }


        public static string RequestOperation(PositionRequesting operation, string positonID)
        {
            var myval = new RequestingPost();
            return myval.RequestingOperation(operation, positonID);
        }

        public static string SaveRequest(PositionRequesting operation, string positonID)
        {
            var myval = new RequestingPost() ;
            return myval.RequestingOperation(operation, positonID);
        }
        public static string PostRequest(PositionRequesting operation, string positonID)
        {
            var myval = new RequestingPost();
            return myval.RequestingOperation(operation, positonID);
        }
        public static string DeleteRequest(PositionRequesting position, string positonID)
        {
            var myval = new RequestingPost();
            return myval.RequestingOperation(position, positonID);
        }
        public static string NewRequest(PositionRequesting position, string positonID)
        {
            var myval = new RequestingPost();
            return myval.RequestingOperation(position, positonID);
        }
       public static string RequestPositionAttribute(PositionRequesting operation, string positonID)
        {
            var myval = new RequestingPost();
            return myval.RequestingOperation(operation, positonID);
        }
         public static string UpdateQualification(QualificationUpdate qual, string positonID)
        {
            var myval = new RequestingPost();
            return myval.QualificationOperation(qual, positonID);
        }
    }
}
