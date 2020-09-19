using ClassLibrary;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{

    public class PostingInterview
    {

        //public string UpdateResult(object position, int positionID)
        //{
        //    try
        //    {
        //        string sp = "dbo.tcdsb_LTO_PageInterview_Operation @Operate, @UserID, @SchoolYear, @PositionID, @CPNum, @Recommendation, @InterviewDate, @EffectiveDate, @OutCome, @Acceptance";
        //        var result = GeneralDataAccess.TextValue(sp, position);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        var exm = ex.Message;
        //        return "Failed";
        //    }
        //}
        //public string RecommendForHire(object position, int positionID)
        //{
        //    try
        //    {
        //        string sp = "dbo.tcdsb_LTO_PageInterview_Operation @Operate, @UserID, @SchoolYear, @PositionID, @CPNum, @Recommendation, @InterviewDate, @EffectiveDate, @OutCome, @Acceptance";
        //        var result = GeneralDataAccess.TextValue(sp, position);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        var exm = ex.Message;
        //        return "Failed";
        //    }
        //}

        //public string CheckInterviewCount(object position, int positionID)
        //{
        //    try
        //    {
        //        string sp = "dbo.tcdsb_LTO_PageInterview_OperationCheck @Operate, @UserID, @SchoolYear, @PositionID";
        //        var result = GeneralDataAccess.TextValue(sp, position);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        var exm = ex.Message;
        //        return "0";
        //    }
        //}
        //public string CheckSignOffCount(object position, int positionID)
        //{
        //    try
        //    {
        //        string sp = "dbo.tcdsb_LTO_PageInterview_OperationCheck @Operate, @UserID, @SchoolYear, @PositionID, @CPNum";
        //        var result = GeneralDataAccess.TextValue(sp, position);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        var exm = ex.Message;
        //        return "0";
        //    }
        //}
        //public string CheckHiringProcessStatus(object position, int positionID)
        //{
        //    try
        //    {
        //        string sp = "dbo.tcdsb_LTO_PageInterview_OperationCheck @Operate, @UserID, @SchoolYear, @PositionID";
        //        var result = GeneralDataAccess.TextValue(sp, position);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        var exm = ex.Message;
        //        return "Failed";
        //    }
        //}
        //public string InterviewSignOffAction(object position, int positionID)
        //{
        //    try
        //    {
        //        string sp = "dbo.tcdsb_LTO_PageInterview_SignOff @Operate, @UserID, @SchoolYear, @PositionID, @CPNum";
        //        var result = GeneralDataAccess.TextValue(sp, position);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        var exm = ex.Message;
        //        return "0";
        //    }
        //}
        public string InterviewOperation(InterviewResult position, string positonID)
        {
            try
            {
                string sp = GetSP(position.Operate);
                var result = GeneralDataAccess.TextValue(sp, position);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }
        private string GetSP(string action)
        {
            string parameters = " @Operate, @UserID, @SchoolYear, @PositionID, @CPNum";
            switch (action)
            {
                case "Update":
                    return "dbo.tcdsb_LTO_PageInterview_Operation" + parameters + ", @Recommendation, @InterviewDate, @EffectiveDate, @OutCome, @Acceptance";
                case "Recommend":
                    return "dbo.tcdsb_LTO_PageInterview_Operation" + parameters + ", @Recommendation, @InterviewDate, @EffectiveDate, @OutCome, @Acceptance";
                case "PositionHiringStatus":
                    return "dbo.tcdsb_LTO_PageInterview_OperationCheck" + parameters;
                case "SignOffCount":
                    return "dbo.tcdsb_LTO_PageInterview_OperationCheck" + parameters;
                case "InterviewCount":
                    return "dbo.tcdsb_LTO_PageInterview_OperationCheck" + parameters;
                case "SignOffAction":
                    return "dbo.tcdsb_LTO_PageInterview_SignOff" + parameters;
                default:
                    return "";

            }

        }
    }
}
