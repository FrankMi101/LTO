using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
   public  class PostingPublishExe
    {
        public static List<PositionListPublish> Positions(ParametersForPositionList parameter)
        {
           // var mylist = new PostingPublish();
           // return mylist.Positions(parameter);
            var mylist = new CommonList<PositionListPublish>();
            return mylist.ListPositions(parameter);
        }
        public static List<PositionPublish> Position(ParametersForPosition parameter)
        {
           // var mylist = new PostingPublish();
           // return mylist.Position(parameter);

            var mylist = new CommonList<PositionPublish>();
            return mylist.ListPosition(parameter);

        }
      

        public static string CancelPosting(ParametersForOperation operation, int positonID)
        {
            var myval = new PostingPublish();
            return myval.CancelPosting(operation, positonID);
        }
        public static string RePosting(ParametersForOperation operation, int positonID)
        {
            var myval = new PostingPublish();
            return myval.RePosting(operation, positonID);
        }
        public static string DeletePosting(ParametersForOperation operation, int positonID)
        {
            var myval = new PostingPublish();
            return myval.DeletePosting(operation, positonID);
        }
        public static string NewPosting(PositionPublish position, int positonID)
        {
            var myval = new PostingPublish();
            return myval.CreatePosting(position, positonID);
        }
        public static string SavePosting(PositionPublish position, int positonID)
        {
            var myval = new PostingPublish();
            return myval.SavePosting(position, positonID);
        }
        public static string TestCount(PositionPublish position, int positonID)
        {
            var myval = new PostingPublish();
            return myval.TestCount(position, positonID);
        }
        public static List<LimitDate> LimitedDate(object parameter)
        {
            var myval = new PostingPublish();
            return myval.LimitedDate(parameter);
        }
        public static string MutilpleSchoolPrincipals(ParametersForOperation operation )
        {
            var myval = new PostingPublish();
            return myval.MultiplePrinciaplEmail(operation);
        }

        public static ParametersForPosition GetParameters(string schoolYear, string positionId )
        {
            var parameter = new ParametersForPosition()
            {
                PositionID = positionId,
                SchoolYear = schoolYear
            };
            return parameter;
        }
    }
}
