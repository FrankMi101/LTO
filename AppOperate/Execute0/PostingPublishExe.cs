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
        private readonly static PostingPublish posting = new PostingPublish();
 
        public static List<PositionListPublish> Positions(ParametersForPositionList parameter)
        {
           var mylist = new CommonList<PositionListPublish>();
            return mylist.ListPositions(parameter);
        }
        public static List<PositionPublish> Position(ParametersForPosition parameter)
        {
             var mylist = new CommonList<PositionPublish>();
            return mylist.ListPosition(parameter);
      }
      
        public static string CancelPosting(ParametersForOperation operation, int positonID)
        {
            return posting.CancelPosting(operation, positonID);
        }
        public static string RePosting(ParametersForOperation operation, int positonID)
        {
            return posting.RePosting(operation, positonID);
        }
        public static string DeletePosting(ParametersForOperation operation, int positonID)
        {
            return posting.DeletePosting(operation, positonID);
        }
        public static string NewPosting(PositionPublish position, int positonID)
        {
           return posting.CreatePosting(position, positonID);
        }
        public static string SavePosting(PositionPublish position, int positonID)
        {
            return posting.SavePosting(position, positonID);
        }
        public static string TestCount(PositionPublish position, int positonID)
        {
            return posting.TestCount(position, positonID);
        }
        public static List<LimitDate> LimitedDate(object parameter)
        {
            return posting.LimitedDate(parameter);
        }
        public static string MutilpleSchoolPrincipals(ParametersForOperation operation )
        {
            return posting.MultiplePrinciaplEmail(operation);
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
