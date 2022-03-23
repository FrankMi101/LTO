using ClassLibrary;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
                                         
    public class RequestingPost
    {  
        //public string CreateRequest(object position, int positionID)
        //{
        //    try
        //    {
        //        string sp = "dbo.tcdsb_LTO_PageRequest_CreateNewAndGetRequestID @Operate, @SchoolYear,  @PositionID, @PositionType,@UserID, @SchoolCode";
        //        var result = GeneralDataAccess.TextValue(sp, position);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        var exm = ex.Message;
        //        return "Failed";
        //    }
        //}
        //public string PostRequest(object position, int positionID)
        //{
        //    try
        //    {
        //        string sp = "dbo.tcdsb_LTO_PageRequest_Operation @Operate,  @SchoolYear,  @PositionID";
        //        var result = GeneralDataAccess.TextValue(sp, position);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        var exm = ex.Message;
        //        return "Failed";
        //    }
        //}
        //public string DeleteRequest(object position, int positionID)
        //{
        //    try
        //    {
        //        string sp = "dbo.tcdsb_LTO_PageRequest_Operation @Operate,  @SchoolYear, @PositionID";
        //        var result = GeneralDataAccess.TextValue(sp, position);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        var exm = ex.Message;
        //        return "Failed";
        //    }
        //}
   
        //public string UpdateRequest(object position, int positionID)
        //{
        //    try
        //    {    //  @Operate ="RePosting"
        //        string sp = "dbo.tcdsb_LTO_PageRequest_Operation @Operate, @SchoolYear,  @PositionID, @PositionType,@UserID, @SchoolCode, @StartDate, @EndDate, @Comments, @PositionLevel, @PositionTitle, @Description, @Qualification, @QualificationCode, @FTE, @FTEPanel, @ReplaceTeacherID, @ReplaceReason, @OtherReason, @Owner";
        //        var result = GeneralDataAccess.TextValue(sp, position);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        var exm = ex.Message;
        //        return "Failed";
        //    }
        //}
        //public string UpdateQualification(object qual, int positionID)
        //{
        //    try
        //    {    //  @Operate ="RePosting"
        //        string sp = "dbo.tcdsb_LTO_PageRequest_Qualification_Update @Operate,@UserID, @SchoolYear,@SchoolCode, @PositionID, @SourceID, @QualificationID, @Selected";
        //        var result = GeneralDataAccess.TextValue(sp, qual);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        var exm = ex.Message;
        //        return "Failed";
        //    }
        //}
        //public string RequestAttribute(object qual, int positionID)
        //{
        //    try
        //    {    //  @Operate ="RePosting"
        //        string sp = "dbo.tcdsb_LTO_PageRequest_Attribute @Operate,@UserID, @SchoolYear,@SchoolCode, @PositionID";
        //        var result = GeneralDataAccess.TextValue(sp, qual);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        var exm = ex.Message;
        //        return "Failed";
        //    }
        //}
        public string RequestingOperation(PositionRequesting position, string positionID)
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
        public string QualificationOperation(QualificationUpdate position, string positionID)
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
            string parameter = " @Operate, @UserID, @SchoolYear, @SchoolCode, @PositionID";
            string parameters = parameter + ", @PositionType";
            string parametersC = parameters + ", @StartDate, @EndDate, @Comments, @PositionLevel, @PositionTitle, @Description, @Qualification, @QualificationCode, @FTE, @FTEPanel, @ReplaceTeacherID, @ReplaceReason, @OtherReason, @Owner"; 
            switch (action)
            {
                case "Request":
                    return "dbo.tcdsb_LTO_PageRequest_CreateNewAndGetRequestID" + parameters;
                case "New":
                    return "dbo.tcdsb_LTO_PageRequest_CreateNewAndGetRequestID" + parameters;
                case "Request Posting":
                    return "dbo.tcdsb_LTO_PageRequest_Operation" + parameters;
                case "Delete":
                    return "dbo.tcdsb_LTO_PageRequest_Operation" + parameters;
                case "Update":
                    return "dbo.tcdsb_LTO_PageRequest_Operation" +  parametersC;
                case "RequestAttribute":
                    return "dbo.tcdsb_LTO_PageRequest_Attribute" + parameter;
                case "RequestSchool":
                    return "dbo.tcdsb_LTO_PageRequest_Attribute" + parameter;
                case "Qualification":
                    return "dbo.tcdsb_LTO_PageRequest_Qualification_Update" + parameter + ", @SourceID, @QualificationID, @Selected"; 
                default:
                    return "";

            }

        }
    }
}
