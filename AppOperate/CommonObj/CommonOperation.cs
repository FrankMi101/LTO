using DataAccess.Common;
using System;

namespace AppOperate
{
    public class CommonOperation<T> : ICommonOperation<T>
    {
        public string Operation(T position, string action)
        {
            try
            {
                string tName = typeof(T).Name;
                string sp = GetSPNameAndParametersbyType(tName, action);
                var result = GeneralDataAccess.TextValue(sp, position);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }
        public string Operation(T position, string sp,string action)
        {
            try
            {            
                var result = GeneralDataAccess.TextValue(sp, position);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                throw;
            }
        }

        public string MyGeneralValue( string SP, T parameter)
        {
            try
            {
                var result = GeneralDataAccess.TextValue(SP, parameter);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                throw;
            }
        }
        public string GeneralValue(string SP, object parameter)
        {
            try
            {
                var result = GeneralDataAccess.TextValue(SP, parameter);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                throw;
            }
        }
        // private T genericMemberVariable;
        public T GeneralValueOfT(string SP, object parameter)
        {
            try
            {
                T result = GeneralDataAccess.ValueOfT<T>(SP, parameter);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;

                throw;
            }
        }
        public string GetSPNameAndParametersbyType(string tName, string action)
        {
            switch (tName)
            {
                case "NewPosition":                         return GetSP_NewPosition(action);
                case "InterviewResult":                     return GetSP_Interview(action);
                case "InterviewNotice":                     return GetSP_Interview(action);
                case "PositionPublish":                     return GetSP_Publish(action);
                case "PositionRequesting":                  return GetSP_Request(action);
                case "PositionApprove":                   return GetSP_Approved(action);
                case "PositionHiring":                    return GetSP_Hiring(action);
                case "ParametersForOperationHire":        return GetSP_Hiring(action);
                case "PositionHired":                     return GetSP_Hiring(action);
                case "ParametersForOperation":            return GetSP_Operation(action);
                case "ApplicantContact":                  return GetSP_Appling(action);
                case "PositionApplying":                  return GetSP_Appling(action);
                case "ParametersForApply":                return GetSP_Appling(action);
                case "ParametersForTeacher":              return GetSP_Teacher(action);

                default:                                 return GetSP_Publish(action);
            }


        }

        private string GetSP_Interview(string action)
        {
            string parameter = " @Operate, @UserID, @SchoolYear, @PositionID";
            string parameters = parameter + ", @CPNum";
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
                case "Request More Interview":
                    return "dbo.tcdsb_LTO_PageInterview_OperationNotice" + parameter + ", @NoticeDate, @PrincipalID, @RequestCount";
                case "Send Notice ToPrincipal":
                    return "dbo.tcdsb_LTO_PageInterview_OperationNotice" + parameter + ", @NoticeDate, @PrincipalID";
                case "MultipSchoolPrincipal":
                    return "dbo.tcdsb_LTO_PageInterview_NoticePrincipal" + parameter + ", @SchoolCode";
                case "ActingPrincipal":
                    return "dbo.tcdsb_LTO_PageInterview_NoticePrincipal" + parameter + ", @SchoolCode";
                default:
                    return "";

            }

        }
        private string GetSP_Publish(string action)
        {
            string parameter = " @Operate, @UserID, @SchoolYear, @SchoolCode, @PositionID";
            string parameters = parameter + ", @PositionType";
            string parameters2 = ", @Comments, @PositionTitle ,@PositionLevel, @Description, @Qualification, @QualificationCode,@FTE, @FTEPanel, @StartDate, @EndDate, @DatePublish, @DateApplyOpen,@DateApplyClose,@ReplaceTeacherID, @ReplaceTeacher, @ReplaceReason, @OtherReason, @Owner";
            switch (action)
            {
                case "Cancel":
                    return "dbo.tcdsb_LTO_PagePublish_Operation " + parameters + ", @Comments";
                case "RePosting":
                    return "dbo.tcdsb_LTO_PagePublish_Operation" + parameters + ", @Comments,@PostingCycle,@TakeApplicant, @PostingNumber";
                case "Delete":
                    return "dbo.tcdsb_LTO_PagePublish_Operation" + parameters;
                case "MultiplePrincipal":
                    return "dbo.tcdsb_LTO_PagePublish_Operation" + parameter;
                case "Save":
                    return "dbo.tcdsb_LTO_PagePublish_OperationSave" + parameters + parameters2;
                case "Update":
                    return "dbo.tcdsb_LTO_PagePublish_OperationSave" + parameters + parameters2;
                case "CreateNew":
                    return "dbo.tcdsb_LTO_PagePublish_CreateNewAndGetRequestID" + parameters;
                case "New":
                    return "dbo.tcdsb_LTO_PagePublish_CreateNewAndGetRequestID" + parameters;
                default:
                    return "";

            }

        }
        private string GetSP_Request(string action)
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
                    return "dbo.tcdsb_LTO_PageRequest_Operation" + parametersC;
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
        private string GetSP_NewPosition(string action)
        {
            string parameter = " @Operate, @UserID, @SchoolYear, @SchoolCode, @PositionID, @PositionType";
             switch (action)
            {
                case "NewRequest":
                    return "dbo.tcdsb_LTO_PageRequest_CreateNewAndGetRequestID" + parameter;
                case "NewPublish":
                    return "dbo.tcdsb_LTO_PagePublish_CreateNewAndGetRequestID" + parameter;
                default:
                    return "";

            }

        }
        private string GetSP_Approved(string action)
        {
            string parameters = " @Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID, @Comments";
            string parameter2 = ", @CPNum, @StartDate, @EndDate, @DatePublish, @DateApplyOpen, @DateApplyClose, @RequestSource";
            string parameter3 = ", @PositionLevel, @Qualification, @QualificationCode, @Description, @FTE, @FTEPanel, @StartDate, @EndDate, @Owner";
            switch (action)
            {
                case "Reject":
                    return "dbo.tcdsb_LTO_PageApprove_Operation" + parameters + ", @CPNum";
                case "Update":
                    return "dbo.tcdsb_LTO_PageApprove_Operation " + parameters;
                case "Posting":
                    return "dbo.tcdsb_LTO_PageApprove_Operation" + parameters + parameter2;
                case "Save":
                    return "dbo.tcdsb_LTO_PageApprove_OperationSave" + parameters + parameter3;
                case "Property":
                    return "dbo.tcdsb_LTO_PageApprove_Property @Operate,@PositionID";
                default:
                    return "";

            }
        }
        private string GetSP_Hiring(string action)
        {

            string parameters = "  @Operate, @UserID, @SchoolYear, @PositionType, @PositionID, @CPNum";
            string parameter1 = " , @Comments,@Acceptance, @DateConfirm, @DateEffective, @DateEnd, @PrincipalEmail, @OfficerEmail, @Action, @PayStatus";
            switch (action)
            {
                case "Revoke":
                    return "dbo.tcdsb_LTO_PageHired_Operation" + parameters ;
                case "ConfirmHire":
                    return "dbo.tcdsb_LTO_PageConfirmForHiring_Operation" + parameters + parameter1;
                case "ConfirmHire4th":
                    return "dbo.tcdsb_LTO_PageConfirmForHiring4th_Operation " + parameters + parameter1 + ",@TeacherName";
                case "Update":
                    return "dbo.tcdsb_LTO_PageConfirmForHiring_Operation " + parameters;
                case "Property":
                    return "dbo.tcdsb_LTO_PageApprove_Property @Operate,@PositionID";
                case "TeacherName":
                    return "dbo.tcdsb_LTO_checkTeacherNamebyCPNum @SchoolYear, @PositionID, @CPNum";

                default:
                    return "";
            }
        }
        private string GetSP_Operation(string action)
        {
            string parameter = " @Operate, @UserID, @SchoolYear, @PositionID, @SchoolCode";
            switch (action)
            {
                case "MultipleSchoolPrincipal":
                    return "dbo.tcdsb_LTO_PageInterview_NoticePrincipal" + parameter;
                case "SchoolPrincipalID":
                    return "dbo.tcdsb_LTO_PagePublish_GeneralInfo" + parameter;
                case "ActingPrincipal":
                    return "dbo.tcdsb_LTO_PageInterview_NoticePrincipal" + parameter;
                case "SelectedInterview":
                    return "dbo.tcdsb_LTO_PageInterview_NoticePrincipal" + parameter;
                case "SelectForInterview":
                    return "dbo.tcdsb_LTO_PageSelectInterviewCandidate_Operation" + " @Operate, @UserID, @SchoolYear, @PositionID, @CPNum, @Action";
                case "ContactInfo":
                    return "dbo.tcdsb_LTO_PageApply_ApplicantContactInfo" + " @Operate, @CPNum, @HomePhone, @CellPhone, @Email";
                default:
                    return "";

            }

        }
        private string GetSP_Appling(string action)
        {
            string parameter = " @Operate, @UserID, @SchoolYear, @PositionID, @CPNum, @Action, @Comments";
            switch (action)
            {
                case "Applied":
                    return "dbo.tcdsb_LTO_PageApply_Operation" + parameter;
                case "Rescind":
                    return "dbo.tcdsb_LTO_PageApply_Operation" + parameter;
                case "Cancel":
                    return "dbo.tcdsb_LTO_PageApply_Operation" + parameter;
                case "OCTQualification":
                    return "dbo.tcdsb_LTO_PageApply_Operation" + parameter;
                case "AppliedOnBehalf":
                    return "dbo.tcdsb_LTO_PageApply_Operation" + parameter;
                case "Update":
                    return "dbo.tcdsb_LTO_PageApply_ApplicantContactInfo" + " @Operate, @CPNum, @HomePhone, @CellPhone, @Email";
                case "ContactInfo":
                    return "dbo.tcdsb_LTO_PageApply_ApplicantContactInfo" + " @Operate, @CPNum, @HomePhone, @CellPhone, @Email, @PositionID ";
                 default:
                    return "";

            }

        }
        private string GetSP_Teacher(string action)
        {
            string parameter = " @Operate, @UserID, @SchoolYear, @SchoolCode, @PositionID, @CPNum";
            switch (action)
            {
                case "TeacherName":
                    return "dbo.tcdsb_LTO_PageRequest_TeacherName" + parameter;
                default:
                    return "";

            }

        }

    }
}
