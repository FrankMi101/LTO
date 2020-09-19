using ClassLibrary;
using System.Collections.Generic;
using System.Linq;
namespace AppOperate
{
    public class PublishPositionExe
    {

        public PublishPositionExe()
        {
        }
        public static string SpName(string action)
        {
            return GetSp(action);
        }
        public static List<PositionListPublish> Positions(object parameter)
        {
            string sp = GetSp("Positions");
            return CommonExcute<PositionListPublish>.GeneralList(sp, parameter);
        }
        public static List<PositionPublish> Position(object parameter)
        {
            string sp = GetSp("Position");
            return CommonExcute<PositionPublish>.GeneralList(sp, parameter);
        }
        public static List<PositionInfo> PositionInfo(object parameter)
        {
            string sp = GetSp("PositionInfo");
            return CommonExcute<PositionInfo>.GeneralList(sp, parameter);
        }
        public static List<PositionPublish> DefaultDate(object parameter)
        {
            string sp = GetSp("DefaultDate");
            return CommonExcute<PositionPublish>.GeneralList(sp, parameter);
        }
        public static List<PositionPublish> PostingRounds(object parameter)
        {
            string sp = GetSp("PostingRounds");
            return CommonExcute<PositionPublish>.GeneralList(sp, parameter);
        }
        public static List<ApplicantNotice> NoticeApplicants(object parameter)
        {
            string sp = GetSp("NoticeApplicants");
            return CommonExcute<ApplicantNotice>.GeneralList(sp, parameter);
        }

        public static string Add(object parameter)
        {
            string sp = GetSp("New");
            return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string Update(object parameter)
        {
            string sp = GetSp("Update");
            return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string Delete(object parameter)
        {
            string sp = GetSp("Delete");
            return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string Cancel(object parameter)
        {
            string sp = GetSp("Cancel");
            return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string RePosting(object parameter)
        {
            string sp = GetSp("RePosting");
            return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string Deadline(object parameter)
        {
            string sp = GetSp("Deadline");
            return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string PrincipalsEmail(object parameter)
        {
            string sp = GetSp("PrincipalsEmail");
            return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string Attribute(object parameter)
        {
            string sp = GetSp("Attribute");
            return CommonExcute<string>.GeneralValue(sp, parameter);
        }

        private static string GetSp(string action)
        {
            if (SPSource.SPFile == "")
            { return GetSpInClass(action); }
            else
            { return GetSpFromJsonFile(action); }

        }
        private static string GetSpInClass(string action)
        {
            string parameter = " @Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID";
            string parameters = parameter + ",@PositionType";
            string parameters2 = ",@Comments,@PositionTitle,@PositionLevel,@Description,@Qualification,@QualificationCode,@FTE,@FTEPanel,@StartDate,@EndDate,@DatePublish,@DateApplyOpen,@DateApplyClose,@ReplaceTeacherID,@ReplaceTeacher,@ReplaceReason,@OtherReason, @Owner,@PrincipalID";
            string paraPosition = " @SchoolYear, @PositionID";
            string paraPositions = " @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy,@SearchValue1,@SearchValue2";

            switch (action)
            {
                case "Positions":
                    return "dbo.tcdsb_LTO_PagePublish_Positions" + paraPositions;
                case "Position":
                    return "dbo.tcdsb_LTO_PagePublish_Position" + paraPosition;
                case "Cancel":
                    return "dbo.tcdsb_LTO_PagePublish_Operation " + parameters + ",@Comments";
                case "RePosting":
                    return "dbo.tcdsb_LTO_PagePublish_OperationReposting" + parameters + ",@Comments,@PostingCycle,@TakeApplicant, @PostingNumber";
                case "Delete":
                    return "dbo.tcdsb_LTO_PagePublish_Operation" + parameters;
                case "Save":
                    return "dbo.tcdsb_LTO_PagePublish_OperationSave" + parameters + parameters2;
                case "Update":
                    return "dbo.tcdsb_LTO_PagePublish_OperationSave" + parameters + parameters2;
                case "CreateNew":
                    return "dbo.tcdsb_LTO_PagePublish_CreateNew" + parameters;
                case "New":
                    return "dbo.tcdsb_LTO_PagePublish_CreateNew" + parameters;
                case "Deadline":
                    return "dbo.tcdsb_LTO_PagePublish_Deadline @SchoolYear, @DatePublish, @PositionType";
                case "DefaultDate":
                    return "dbo.tcdsb_LTO_PagePublish_DateDefault @SchoolYear, @DatePublish, @PositionType";
                case "PrincipalsEmail":
                    return "dbo.tcdsb_LTO_PagePublish_MultipleSchoolsPrincipalEmail" + " @SchoolYear, @SchoolCode, @PositionID";
                case "MultipleSChool":
                    return "dbo.tcdsb_LTO_PagePublish_MultipleSchool" + " @UserID, @SchoolYear, @PositionID, @IDs,@SchoolCode,@PositionTitle,@FTE,@Description";
                case "PostingRounds":
                    return "dbo.tcdsb_LTO_PagePublish_PostingRounds" + " @SchoolYear, @PositionID";
                case "PositionInfo":
                    return "dbo.tcdsb_LTO_PagePublish_Information" + " @SchoolYear, @PositionID";
                case "Attribute":
                    return "dbo.tcdsb_LTO_PagePublish_Attribute" + parameter;
                case "NoticeApplicants":
                    return "dbo.tcdsb_LTO_PagePublish_NoticeToTeacherList" + " @Operate, @SchoolYear, @PositionID";

                default:
                    return action;

            }

        }
        private static string GetSpFromJsonFile(string action)
        {
            return GetSpNameFormJsonFile.SPName(action, "Publish");
        }
    }
}
