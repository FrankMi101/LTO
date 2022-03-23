namespace AppOperate
{
    public class CommonSP
    {

        public CommonSP()
        {
        }
        public static string GetList<T>()
        {
            var typeName = (typeof(T)).Name;
            string pForSingle = " @SchoolYear,@PositionID";
            string pForList0 = " @Operate,@UserID,@SchoolYear,@PositionType,@SearchBy, @SearchValue1";
            string pForList = " @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
            switch (typeName)
            {
                case "PositionListApplying":
                    return "dbo.tcdsb_LTO_PageApply_AvailablePositions" + pForList0 + ", @UserRole, @CPNum";
                case "PositionListApplied":
                    return "dbo.tcdsb_LTO_PageApply_AppliedPositions" + pForList0 + ", @UserRole, @CPNum";
                case "PositionListRequesting":
                    return "dbo.tcdsb_LTO_PageRequest_Positions" + " @Operate, @UserID, @SchoolYear, @SchoolCode";
                case "PositionListPublish":
                    return "dbo.tcdsb_LTO_PagePublish_Positions" + pForList;
                case "PositionListPublished":
                    return "dbo.tcdsb_LTO_PageSelectInterviewCandidate_Positions" + pForList;
                case "PositionListRequest":
                    return "dbo.tcdsb_LTO_PageApprove_Positions" + pForList;
                case "PositionListApprove":
                    return "dbo.tcdsb_LTO_PageApprove_Positions" + pForList;
                case "PositionListConfirm":
                    return "dbo.tcdsb_LTO_PageConfirmHire_Positions" + pForList0;
                case "PositionListHired":
                    return "dbo.tcdsb_LTO_PageHired_Positions" + pForList;
                case "PositionListHire":
                    return "dbo.tcdsb_LTO_PageConfirmHire_Position" + pForList;
                case "PositionListPosting":
                    return "dbo.tcdsb_LTO_PagePosting_Positions" + pForList;
                case "PositionListInterview":
                    return "dbo.tcdsb_LTO_PageInterview_Positions" + " @Operate, @UserID, @SchoolYear,@SchoolCode";
                case "CandidateList":
                    return "dbo.tcdsb_LTO_PageInterview_Candidates" + pForSingle;
                case "CandidateListNotice":
                    return "dbo.tcdsb_LTO_PageInterview_NoticeCandidates" + " @Operate, @SchoolYear, @PositionID";
                case "ApplicantsNoticeList":
                    return "dbo.tcdsb_LTO_PagePublish_NoticeToTeacherList" + " @Operate, @SchoolYear, @PositionID";
                case "PositionRequesting":
                    return "dbo.tcdsb_LTO_PageRequest_Position" + pForSingle;
                case "PositionApprove":
                    return "dbo.tcdsb_LTO_PageApprove_Position" + pForSingle;
                case "PositionPublish":
                    return "dbo.tcdsb_LTO_PagePublish_Position" + pForSingle;
                case "PositionInfo":
                    return "dbo.tcdsb_LTO_PagePublish_Information" + pForSingle;
                case "PositionRequest":
                    return "dbo.tcdsb_LTO_PageApprove_Position" + pForSingle;
                case "PositionPosting":
                    return "dbo.tcdsb_LTO_PagePosting_Position" + pForSingle;
                case "PositionInterview":
                    return "dbo.tcdsb_LTO_PageInterview_Candidate" + pForSingle + ", @CPNum";
                case "PositionConfirmHire":
                    return "dbo.tcdsb_LTO_PageConfirmHire_Position" + pForSingle + ", @CPNum";
                case "PositionHire":
                    return "dbo.tcdsb_LTO_PageConfirmHire_Position" + pForSingle + ", @CPNum";
                case "PositionApplying":
                    return "dbo.tcdsb_LTO_PageApply_ApplyingPosition" + pForSingle + ", @CPNum";
                case "PositionHired":
                    return "dbo.tcdsb_LTO_PageHired_Position" + pForSingle + ", @CPNum";
                case "PositionHire4thRound":
                    return "dbo.tcdsb_LTO_PageConfirmHire4thRound_Position" + pForSingle + ", @CPNum";
                case "PositionQualificationCheck":
                    return "dbo.tcdsb_LTO_PageApply_QualificationCheck" + pForSingle + ", @CPNum";

                case "QualificationSelected":
                    return "dbo.tcdsb_LTO_QualificationSelectedList" + pForSingle;
                case "LimitDate":
                    return "dbo.tcdsb_LTO_PagePublish_DefaultDate @Operate, @AppType, @SchoolYear, @DatePublish";
                case "ApplicantInterview":
                    return "dbo.tcdsb_LTO_PageSelectInterviewCandidate_Applicant" + pForSingle + ", @CPNum";
                case "ApplicantListSelect":
                    return "dbo.tcdsb_LTO_PageSelectInterviewCandidate_Applicants" + " @Operate, @SchoolYear, @PositionID";
                case "ApplicantContact":
                    return "dbo.tcdsb_LTO_PageApply_ApplicantContactInfo" + " @Operate, @CPNum";
                case "GeneralInfo":
                    return "dbo.tcdsb_LTO_PagePublish_GeneralInfo @AppType, @SchoolYear, @SchoolCode, @PositionID, @InfoType";


                default:
                    return "";

            }

        }
        public static string GetSingleList<T>()
        {
            var typeName = (typeof(T)).Name;
            string pForSingle = " @SchoolYear,@PositionID";
            switch (typeName)
            {
                case "PositionRequesting":
                    return "dbo.tcdsb_LTO_PageRequest_Position" + pForSingle;
                case "PositionApprove":
                    return "dbo.tcdsb_LTO_PageApprove_Position" + pForSingle;
                case "PositionPublish":
                    return "dbo.tcdsb_LTO_PagePublish_Position" + pForSingle;
                case "PositionInfo":
                    return "dbo.tcdsb_LTO_PagePublish_Information" + pForSingle;
                case "PositionRequest":
                    return "dbo.tcdsb_LTO_PageApprove_Position" + pForSingle;
                case "PositionPosting":
                    return "dbo.tcdsb_LTO_PagePosting_Position" + pForSingle;
                case "CandidateList":
                    return "dbo.tcdsb_LTO_PageInterview_Candidates" + pForSingle;
                case "PositionInterview":
                    return "dbo.tcdsb_LTO_PageInterview_Candidate" + pForSingle + ", @CPNum";
                case "PositionConfirmHire":
                    return "dbo.tcdsb_LTO_PageConfirmHire_Position" + pForSingle + ", @CPNum";
                case "PositionHire":
                    return "dbo.tcdsb_LTO_PageConfirmHire_Position" + pForSingle + ", @CPNum";
                case "PositionHired":
                    return "dbo.tcdsb_LTO_PageHired_Position" + pForSingle + ", @CPNum";
                case "PositionHire4thRound":
                    return "dbo.tcdsb_LTO_PageConfirmHire4thRound_Position" + pForSingle + ", @CPNum";
                case "PositionQualificationCheck":
                    return "dbo.tcdsb_LTO_PageApply_QualificationCheck" + pForSingle + ", @CPNum";
                case "QualificationSelected":
                    return "dbo.tcdsb_LTO_QualificationSelectedList" + pForSingle;
                case "LimitDate":
                    return "dbo.tcdsb_LTO_PagePublish_DefaultDate @Operate, @AppType, @SchoolYear, @DatePublish";

                case "GeneralInfo":
                    return "dbo.tcdsb_LTO_PagePublish_GeneralInfo @AppType, @SchoolYear, @SchoolCode, @PositionID, @InfoType";
                default:
                    return "";

            }

        }

        public static string GetSPandParameters(CommonAction.PageCategory page, string action)
        {

            switch (page)
            {
                case CommonAction.PageCategory.New:
                    return GetSP_NewPosition(action);
                case CommonAction.PageCategory.Request:
                    return GetSP_Request(action);
                case CommonAction.PageCategory.Publish:
                    return GetSP_Publish(action);
                case CommonAction.PageCategory.Interview:
                    return GetSP_Interview(action);
                case CommonAction.PageCategory.Selector:
                    return GetSP_SelectInterview(action);
                case CommonAction.PageCategory.Approve:
                    return GetSP_Approve(action);
                case CommonAction.PageCategory.Confirm:
                    return GetSP_Hiring(action);
                case CommonAction.PageCategory.Hired:
                    return GetSP_Hired(action);
                case CommonAction.PageCategory.Applicant:
                    return GetSP_Teacher(action);
                case CommonAction.PageCategory.Applying:
                    return GetSP_Applying(action);
                case CommonAction.PageCategory.Summary:
                    return GetSP_Summary(action);
                case CommonAction.PageCategory.General:
                    return GetSP_Genderal(action);

                default:
                    return GetSP_Genderal(action);
            }


        }

        public static string GetSPNameAndParameters(string page, string action)
        {
            switch (page)
            {
                case "NewPosition":
                    return GetSP_NewPosition(action);
                case "InterviewResult":
                    return GetSP_Interview(action);
                case "InterviewNotice":
                    return GetSP_Interview(action);
                case "Request":
                    return GetSP_Request(action);
                case "Publish":
                    return GetSP_Publish(action);
                case "Interview":
                    return GetSP_Interview(action);
                case "SelectInterview":
                    return GetSP_SelectInterview(action);
                case "PositionRequesting":
                    return GetSP_Request(action);
                case "Approve":
                    return GetSP_Approve(action);
                case "PositionHiring":
                    return GetSP_Hiring(action);
                case "ParametersForOperationHire":
                    return GetSP_Hiring(action);
                case "PositionHired":
                    return GetSP_Hired(action);
                case "ParametersForOperation":
                    return GetSP_Operation(action);
                case "ApplicantContact":
                    return GetSP_Applying(action);
                case "Applying":
                    return GetSP_Applying(action);
                case "ParameterForApply":
                    return GetSP_Applying(action);
                case "ParametersForTeacher":
                    return GetSP_Teacher(action);
                case "Summary":
                    return GetSP_Summary(action);
                case "General":
                    return GetSP_Genderal(action);

                default:
                    return page; // direct stored and parameters
            }


        }
        private static string GetSP_Genderal(string action)
        {
            string parameter = " @Operate,@Para0,@Para1,@Para2,@Para3";
            string parameter1 = " @Operate,@UserID, @SchoolYear,@PositionType";
            switch (action)
            {

                case "DDList":
                    return "dbo.tcdsb_LTO_PageGeneral_List" + parameter;
                case "Schools":
                    return "dbo.tcdsb_LTO_PageGeneral_ListSchools" + parameter;
                case "SearchList":
                    return "dbo.tcdsb_LTO_PageGeneral_SearchList" + parameter1 + ",@SearchType";
                case "DefaulDate":
                    return "dbo.tcdsb_LTO_PageGeneral_DefaultDate" + parameter1;
                case "Profile":
                    return "dbo.tcdsb_LTO_PageGeneral_Profile" + " @UserID, @SchoolYear, @ProfileType, @CheckValue";
                default:
                    return "";

            }

        }

        private static string GetSP_Interview(string action)
        {
            string parameter = " @Operate, @UserID, @SchoolYear, @PositionID";
            string parameters = parameter + ", @CPNum";
            switch (action)
            {
                case "Candidate":
                    return "dbo.tcdsb_LTO_PageInterview_Candidate" + " @SchoolYear,@PositionID,@CPNum";
                case "Candidates":
                    return "dbo.tcdsb_LTO_PageInterview_Candidates" + " @SchoolYear, @PositionID";
                case "Positions":
                    return "tcdsb_LTO_PageInterview_Positions" + " @Operate, @UserID, @SchoolYear,@SchoolCode";
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
                case "TeamMembers":
                    return "dbo.tcdsb_LTO_PageInterview_Team" + parameter;
                case "UpdateMember":
                    return "dbo.tcdsb_LTO_PageInterview_Team" + parameter + ",@Sequesc,@MemberID";
                case "Signatures":
                    return "dbo.tcdsb_LTO_PageInterview_Signature" + " @SchoolYear,@PositionID,@CPNum";
                case "SignatureName":
                    return "dbo.tcdsb_LTO_PageInterview_Signature" + " @SchoolYear,@PositionID,@CPNum,@signature,@SignatureID";
                case "OutcomeUpdate":
                    return "dbo.tcdsb_LTO_PageInterview_OutcomeUpdate" + parameters + ",@Outcome";
                default:
                    return "";

            }

        }
        private static string GetSP_SelectInterview(string action)
        {
            string parameter = " @Operate, @UserID, @SchoolYear, @PositionID";
            string parameters = parameter + ", @CPNum";
            string ParaPositions = " @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";

            switch (action)
            {

                case "Applicant":
                    return "dbo.tcdsb_LTO_PageSelectInterviewCandidate_Applicant" + " @SchoolYear,@PositionID,@CPNum";
                case "Applicants":
                    return "dbo.tcdsb_LTO_PageSelectInterviewCandidate_Applicants" + " @Operate, @SchoolYear,@PositionID";
                case "Positions":
                    return "dbo.tcdsb_LTO_PageSelectInterviewCandidate_Positions" + ParaPositions;
                case "Update":
                    return "dbo.tcdsb_LTO_PageSelectInterviewCandidate_Operation" + " @Operate, @UserID, @SchoolYear, @PositionID, @CPNum, @Action";
                case "Selected":
                    return "dbo.tcdsb_LTO_PageSelectInterviewCandidate_Select" + " @UserID, @SchoolYear, @PositionID, @CPNum, @Action";

                default:
                    return "";
            }
        }
        private static string GetSP_Publish(string action)
        {
            string parameter = " @Operate, @UserID, @SchoolYear, @SchoolCode, @PositionID";
            string parameters = parameter + ", @PositionType";
            string parameters2 = ", @Comments, @PositionTitle ,@PositionLevel, @Description, @Qualification, @QualificationCode,@FTE, @FTEPanel, @StartDate, @EndDate, @DatePublish, @DateApplyOpen,@DateApplyClose,@ReplaceTeacherID, @ReplaceTeacher, @ReplaceReason, @OtherReason, @Owner,@PrincipalID";
            string ParaPosition = " @SchoolYear, @PositionID";
            string ParaPositions = " @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";

            switch (action)
            {
                case "Positions":
                    return "dbo.tcdsb_LTO_PagePublish_Positions" + ParaPositions;
                case "Position":
                    return "dbo.tcdsb_LTO_PagePublish_Position" + ParaPosition;
                case "Cancel":
                    return "dbo.tcdsb_LTO_PagePublish_Operation " + parameters + ", @Comments";
                case "RePosting":
                    return "dbo.tcdsb_LTO_PagePublish_OperationReposting" + parameters + ", @Comments,@PostingCycle,@TakeApplicant, @PostingNumber";
                case "Delete":
                    return "dbo.tcdsb_LTO_PagePublish_Operation" + parameters;
                case "MultiplePrincipal":
                    return "dbo.tcdsb_LTO_PagePublish_Operation" + parameter;
                case "MultipleSChool":
                    return "tcdsb_LTO_PagePublish_MultipleSchool" + " @UserID, @SchoolYear, @PositionID, @IDs,@SchoolCode,@PositionTitle,@FTE,@Description";
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

                case "PostingRound":
                    return "dbo.tcdsb_LTO_PagePublish_PostingRound" +" @SchoolYear, @PositionID";
                case "PositionInfo":
                    return "dbo.tcdsb_LTO_PagePublish_Information" + " @SchoolYear, @PositionID";
                default:
                    return "";

            }

        }
        private static string GetSP_Request(string action)
        {
            string parameter0 = " @Operate, @UserID, @SchoolYear, @SchoolCode";
            string parameter = parameter0 + ", @PositionID";
            string parameters = parameter + ", @PositionType";
            string parametersC = parameters + ", @StartDate, @EndDate, @Comments, @PositionLevel, @PositionTitle, @Description, @Qualification, @QualificationCode, @FTE, @FTEPanel, @ReplaceTeacherID, @ReplaceReason, @OtherReason, @Owner";
            switch (action)
            {
                case "Positions":
                    return "dbo.tcdsb_LTO_PageRequest_Positions" + " @Operate, @UserID, @SchoolYear, @SchoolCode";
                case "Position":
                    return "dbo.tcdsb_LTO_PageRequest_Position" + " @SchoolYear, @PositionID";
                case "Request":
                    return "dbo.tcdsb_LTO_PageRequest_CreateNew" + parameters;
                case "NewRequest":
                    return "dbo.tcdsb_LTO_PageRequest_CreateNew" + parameters;
                case "New":
                    return "dbo.tcdsb_LTO_PageRequest_CreateNew" + parameters;
                case "Request Posting":
                    return "dbo.tcdsb_LTO_PageRequest_Operation" + parameters;
                case "Call Back":
                    return "dbo.tcdsb_LTO_PageRequest_Operation" + parameters;
                case "Delete":
                    return "dbo.tcdsb_LTO_PageRequest_Operation" + parameters;
                case "Update":
                    return "dbo.tcdsb_LTO_PageRequest_OperationSave" + parametersC;
                case "Save":
                    return "dbo.tcdsb_LTO_PageRequest_OperationSave" + parametersC;
                case "RequestAttribute":
                    return "dbo.tcdsb_LTO_PageRequest_Attribute" + parameter;
                case "RequestSchool":
                    return "dbo.tcdsb_LTO_PageRequest_Attribute" + parameter;
                case "Qualification":
                    return "dbo.tcdsb_LTO_PageRequest_Qualification_Update" + parameter + ", @SourceID, @QualificationID, @Selected";
                case "QualificationSTR":
                    return "dbo.tcdsb_LTO_PageRequest_Qualification" + parameter + ", @SourceID";
                case "TeachersList":
                    return "dbo.tcdsb_LTO_PageRequest_TeacherList" + parameter0 + ", @SearchValue1";

                default:
                    return "";

            }

        }
        private static string GetSP_NewPosition(string action)
        {
            string parameter = " @Operate, @UserID, @SchoolYear, @SchoolCode, @PositionID, @PositionType";
            switch (action)
            {
                case "NewRequest":
                    return "dbo.tcdsb_LTO_PageRequest_CreateNewAndGetRequestID" + parameter;
                case "NewPublish":
                    return "dbo.tcdsb_LTO_PagePublish_CreateNewAndGetRequestID" + parameter;
                case "Request":
                    return "dbo.tcdsb_LTO_PageRequest_CreateNew" + parameter;
                case "Publish":
                    return "dbo.tcdsb_LTO_PagePublish_CreateNew" + parameter;
                default:
                    return "";

            }

        }
        private static string GetSP_Approve(string action)
        {
            string parameters = " @Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID, @Comments";
            string parameter2 = ", @CPNum, @StartDate, @EndDate, @DatePublish, @DateApplyOpen, @DateApplyClose, @RequestSource";
            string parameter3 = ", @PositionLevel, @Qualification, @QualificationCode,@Description,@FTE,@FTEPanel,@StartDate,@EndDate,@Owner,@ReplaceTeacherID";
            string ParaPosition = " @SchoolYear, @PositionID";
            string ParaPositions = " @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";

            switch (action)
            {
                case "Position":
                    return "dbo.tcdsb_LTO_PageApprove_Position" + ParaPosition;
                case "Positions":
                    return "dbo.tcdsb_LTO_PageApprove_Positions" + ParaPositions;
                case "Reject":
                    return "dbo.tcdsb_LTO_PageApprove_OperationReject" + parameters + ",@CPNum";
                case "Posting":
                    return "dbo.tcdsb_LTO_PageApprove_OperationPosting" + parameters + parameter2;
                case "Save":
                    return "dbo.tcdsb_LTO_PageApprove_OperationSave" + parameters + parameter3;
                case "PostingNumber":
                    return "dbo.tcdsb_LTO_PageApprove_PostingNumber @Operate,@PositionID";
                default:
                    return "";

            }
        }
        private static string GetSP_Hiring(string action)
        {

            string parameters = "  @Operate, @UserID, @SchoolYear, @PositionType, @PositionID, @CPNum";
            string parameter1 = " , @Comments,@Acceptance, @DateConfirm, @DateEffective, @DateEnd, @PrincipalEmail, @OfficerEmail, @Action, @PayStatus";
            switch (action)
            {
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
        private static string GetSP_Hired(string action)
        {
            string ParaRevoke = "  @Operate, @UserID, @SchoolYear, @PositionType, @PositionID,@CPNum";
            string ParaPosition = " @SchoolYear, @PositionID,@CPNum";
            string ParaPositions = " @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";


            switch (action)
            {
                case "Positions":
                    return "dbo.tcdsb_LTO_PageHired_Positions" + ParaPositions;
                case "Position":
                    return "dbo.tcdsb_LTO_PageHired_Position" + ParaPosition;
                case "Revoke":
                    return "dbo.tcdsb_LTO_PageHired_Operation" + ParaRevoke;

                default:
                    return "";
            }
        }
        private static string GetSP_Operation(string action)
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
        private static string GetSP_Applying(string action)
        {
            string parameter = " @Operate, @UserID, @SchoolYear, @PositionID, @CPNum";
            string pForList0 = " @Operate,@UserID,@SchoolYear,@PositionType,@SearchBy, @SearchValue1";
            switch (action)
            {
                case "PositionsApplied":
                    return "dbo.tcdsb_LTO_PageApply_AppliedPositions" + pForList0 + ", @UserRole,@CPNum";
                case "Positions":
                    return "dbo.tcdsb_LTO_PageApply_AvailablePositions" + pForList0 + ", @UserRole, @CPNum";
                case "Position":
                    return "dbo.tcdsb_LTO_PageApply_ApplyingPosition" + " @SchoolYear ,@PositionID,@CPNum";
                case "Applied":
                    return "dbo.tcdsb_LTO_PageApply_Operation" + parameter + ",@Action,@Comments";
                case "Rescind":
                    return "dbo.tcdsb_LTO_PageApply_Operation" + parameter + ",@Action,@Comments";
                case "Cancel":
                    return "dbo.tcdsb_LTO_PageApply_Operation" + parameter + ",@Action,@Comments";
                case "OCTQualification":
                    return "dbo.tcdsb_LTO_PageApply_Operation" + parameter + ",@Action,@Comments";
                case "QualificationCheck":
                    return "dbo.tcdsb_LTO_PageApply_QualificationCheck" + " @SchoolYear, @PositionID, @CPNum"; 
                case "AppliedOnBehalf":
                    return "dbo.tcdsb_LTO_PageApply_Operation" + parameter + ",@Action,@Comments";
                case "Update":
                    return "dbo.tcdsb_LTO_PageApply_ApplicantContactInfo" + " @Operate, @CPNum, @HomePhone, @CellPhone, @Email";
                case "ContactInfo":
                    return "dbo.tcdsb_LTO_PageApply_ApplicantContactInfo" + " @Operate, @CPNum, @HomePhone, @CellPhone, @Email, @PositionID ";
                case "ApplicantComment":
                    return "dbo.tcdsb_LTO_PageApply_ApplicantComments" + parameter;
                default:
                    return "";

            }

        }
        private static string GetSP_Teacher(string action)
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

        private static string GetSP_Summary(string action)
        {
            string ParaPosition = "  @UserID,@SchoolYear,@PositionType,@CPNum";
            string ParaPositions = " @UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
            string positionS = " @SchoolYear, @PositionID";
            switch (action)
            {
                case "Positions":
                    return "dbo.tcdsb_LTO_PageSummary_Positions" + ParaPositions;
                case "Position":
                    return "dbo.tcdsb_LTO_PageSummary_Position" + positionS;
                case "AppliedHistory":
                    return "dbo.tcdsb_LTO_PageSummary_AppliedHistory" + ParaPosition;
                case "ApplicantApplied":
                    return "dbo.tcdsb_LTO_PageSummary_ApplicantApplied" + positionS;
                case "ApplicantInterview":
                    return "dbo.tcdsb_LTO_PageSummary_ApplicantInterview" + positionS;
                case "ApplicantEmail":
                    return "dbo.tcdsb_LTO_PageSummary_ApplicantEmail" + positionS;

                default:
                    return "";

            }

        }

    }
}
