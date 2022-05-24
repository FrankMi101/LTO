using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PublishPosting : PostingBase, IPublishPosting
    {
        public PublishPosting() : base()
        {
        }
        public PublishPosting(string dataSource) : base(dataSource)
        {
        }
        public override string SpName(string action, object parameter)
        {
            if (SPSource.SPFile == "") return PostingSPAndParameter.Name(action, parameter); 
            return GetSPFromJSonFile.SPandParameter(SPSource.SPFile, "Publish", action);
        }

    }
     
    public class PostingSPAndParameter
    {
        public static string Name(string action, object parameter)
        {
            
            bool IsAnonymous = parameter.GetType().FullName.Contains("AnonymousType");
            string sp = GetspName(action);

            if (IsAnonymous) 
                return sp;
            else
            { 
                string para = GetParameters(action);
                if (para.Length > 1) return sp + " " + para;

                return sp;
            }    
        }
        private static string GetspName(string action)
        {

            switch (action)
            {
                case "Positions":
                    return "dbo.tcdsb_LTO_PagePublish_Positions";
                case "Position":
                    return "dbo.tcdsb_LTO_PagePublish_Position";
                case "Cancel":
                case "Delete":
                    return "dbo.tcdsb_LTO_PagePublish_Operation";
                case "Save":
                case "Update":
                    return "dbo.tcdsb_LTO_PagePublish_OperationSave";
                case "CreateNew":
                case "New":
                    return "dbo.tcdsb_LTO_PagePublish_CreateNew";
                case "Recover":
                    return "dbo.tcdsb_LTO_PagePublish_Operation_Recover";
                case "RePosting":
                    return "dbo.tcdsb_LTO_PagePublish_OperationReposting";
                case "Deadline":
                    return "dbo.tcdsb_LTO_PagePublish_DeadlineExt";
                case "DefaultDate":
                    return "dbo.tcdsb_LTO_PagePublish_DefaultDateExt";
                case "PrincipalsEmail":
                    return "dbo.tcdsb_LTO_PagePublish_MultipleSchoolsPrincipalEmail";
                case "MultipleSChool":
                    return "dbo.tcdsb_LTO_PagePublish_MultipleSchool";
                case "PostingRounds":
                    return "dbo.tcdsb_LTO_PagePublish_PostingRounds";
                case "PositionInfo":
                    return "dbo.tcdsb_LTO_PagePublish_Information";
                case "Attribute":
                    return "dbo.tcdsb_LTO_PagePublish_Attribute";
                case "NoticeApplicants":
                    return "dbo.tcdsb_LTO_PagePublish_NoticeToTeacherList";

                default:
                    return action;

            }
        }
        private static string GetParameters(string action)
        {
            string parameter = "@Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID";
            string parameters = parameter + ",@PositionType";
            string parameters2 = ",@Comments,@PositionTitle,@PositionLevel,@Description,@Qualification,@QualificationCode,@FTE,@FTEPanel,@StartDate,@EndDate,@DatePublish,@DateApplyOpen,@DateApplyClose,@ReplaceTeacherID,@ReplaceTeacher,@ReplaceReason,@OtherReason, @Owner,@PrincipalID";
            string paraPosition = "@SchoolYear, @PositionID";
            string search = "@Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy,@SearchValue1,@SearchValue2";

            switch (action)
            {
                case "Positions": return search;
                case "Position": return paraPosition;
                case "Cancel": return parameters + ",@Comments";
                case "Recover": return "@UserID,@SchoolYear,@PostingNum,@PositionID";
                case "RePosting": return parameters + ",@Comments,@PostingCycle,@TakeApplicant, @PostingNumber";
                case "Delete": return parameters;
                case "Save":
                case "Update": return parameters + parameters2;
                case "CreateNew":
                case "New": return parameters;
                case "Deadline": return "@Operate,@PositionType,@SchoolYear,@PublishDate";
                case "DefaultDate": return "@Operate,@PositionType,@SchoolYear";// , @DatePublish";
                case "PrincipalsEmail": return "@SchoolYear, @SchoolCode, @PositionID";
                case "MultipleSChool": return "@UserID, @SchoolYear, @PositionID, @IDs,@SchoolCode,@PositionTitle,@FTE,@Description";
                case "PostingRounds": return "@SchoolYear, @PositionID";
                case "PositionInfo": return " @SchoolYear, @PositionID";
                case "Attribute": return parameter;
                case "NoticeApplicants": return " @Operate, @SchoolYear, @PositionID";

                default: return "";

            }
        }
    }
}
