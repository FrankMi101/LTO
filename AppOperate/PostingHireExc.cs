using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
   public  class PostingHireExe
    {
        public static List<PositionListHire> Positions(ParametersForPositionList parameter)
        {
             var mylist = new CommonList<PositionListHire>();
            return mylist.ListPositions(parameter);
        }
        public static List<PositionListHire> Position(ParametersForPosition parameter)
        {
             var mylist = new CommonList<PositionListHire>();
            return mylist.ListPosition(parameter);
        }

        public static string RevokeHire(ParametersForOperationHire operation, int positonID)
        {
            var myval = new PostingHire();
            return myval.RevokeHire(operation, positonID);
        }
        public static string ConfirmHire(ParametersForOperationHire operation, int positonID)
        {
            var myval = new PostingHire();
            return myval.ConfirmHire(operation, positonID);
        }
        public static string ConfirmHire4thRound(ParametersForOperationHire operation, int positonID)
        {
            var myval = new PostingHire();
            return myval.ConfirmHire4thRound(operation, positonID);
        }
        //public static string SaveHire(ParametersForOperation operation, int positonID)
        //{
        //    var myval = new PostingHire();
        //    return myval.SavePosting(operation, positonID);
        //}
        public static string UpdatePosting(ParametersForOperationHire operation, int positonID)
        {
            var myval = new PostingHire();
            return myval.UpdatePosting(operation, positonID);
        }
        public static string HiringTeacherName(ParametersForOperationHire operation )
        {
            var myval = new PostingHire();
            return myval.HiringTeacherName(operation );
        }

        public static ParametersForPosition GetParameters(string schoolYear, string positionId ,string cpnum)
        {
            var parameter = new ParametersForPosition()
            {
                PositionID = positionId,
                SchoolYear = schoolYear ,
                CPNum = cpnum,
            };
            return parameter;
        }
    }
}
