using ClassLibrary;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{

    public class CommonList<T> : ICommonList<T>
    {


        public List<T> MyList(T parameter)
        {
            try
            {
                var objName = (typeof(T)).Name;
                string sp = GetSP(objName); //  string sp = SPNameAndParameters.GetList<T>();
                var list = GeneralDataAccess.ListofT<T>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                throw;
            }
        }
        public List<T> MyGeneralList(object parameter)
        {
            try
            {
                var objName = (typeof(T)).Name;
                string sp = GetSP(objName); //  SPNameAndParameters.GetList<T>();
                var list = GeneralDataAccess.ListofT<T>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                throw; 
            }
        }
        public List<T> GeneralListOfT(string sp, object parameter)
        {
            try
            {            
                var list = GeneralDataAccess.ListofT<T>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                throw; 
            }
        }
        public IList<T> IGeneralListOfT(string sp, object parameter)
        {
            try
            {
                var list = GeneralDataAccess.ListofT<T>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
        public List<T> ListPositions(Parameters<T> parameter)
        {
            try
            {
                var objName = (typeof(T)).Name;
                string sp = GetSP(objName); // string sp = SPNameAndParameters.GetList<T>();
                var list = GeneralDataAccess.ListofT<T>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
        public List<T> ListPositions(ParametersForPositionList parameter)
        {
            try
            {
                var objName = (typeof(T)).Name;
                string sp = GetSP(objName); // string sp = SPNameAndParameters.GetList<T>();// getPositionsSP(className);
                var list = GeneralDataAccess.GetListofTypeT<T>(sp, parameter);
                //     var list = GeneralDataAccess.ListofT<T>(sp, parameter<>);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
        public List<T> ListPosition(ParametersForPosition parameter)
        {
            try
            {
                var objName = (typeof(T)).Name;
                string sp = GetSP(objName); //string sp = SPNameAndParameters.GetList<T>();// getPositionsSP(className);
                var list = GeneralDataAccess.GetListofTypeT<T>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
        public List<T> Qualfications(ParametersForPosition parameter)
        {
            try
            {
                var objName = (typeof(T)).Name;
                string sp = GetSP(objName); //  string sp = SPNameAndParameters.GetSingleList<T>();// getPositionsSP(className);
                var list = GeneralDataAccess.GetListofTypeT<T>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
        public List<T> ListCandidates(ParametersForPosition parameter)
        {
            try
            {
                var objName = (typeof(T)).Name;
                string sp = GetSP(objName); // string sp = SPNameAndParameters.GetList<T>();
                var list = GeneralDataAccess.ListofT<T>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
        public List<T> ListCandidate(ParametersForPosition parameter)
        {
            try
            {
                var objName = (typeof(T)).Name;
                string sp = GetSP(objName); // string sp = SPNameAndParameters.GetSingleList<T>();
                var list = GeneralDataAccess.ListofT<T>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
        public List<T> ListNoticeCandidates(ParametersForCandidate parameter)
        {
            try
            {
                var objName = (typeof(T)).Name;
                string sp = GetSP(objName); // string sp = SPNameAndParameters.GetList<T>();
                var list = GeneralDataAccess.ListofT<T>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
        public List<T> ListDefaultDate(LimitDate parameter)
        {
            try
            {
                var objName = (typeof(T)).Name;
                string sp = GetSP(objName); //string sp = SPNameAndParameters.GetSingleList<T>();//getPositionsSP(className);
                var list = GeneralDataAccess.GetListofTypeT<T>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }


        public string GetSP(string objName)
        {
            string pForSingle = " @SchoolYear,@PositionID";
            string pForList0 = " @Operate,@UserID,@SchoolYear,@PositionType,@SearchBy, @SearchValue1";
            string pForList = " @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2";
            switch (objName)
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
                case "ApplicantNoticeList":
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
                    return "dbo.tcdsb_LTO_PagePublish_DefaultDate @Operate, @PositionType, @SchoolYear, @DatePublish";
                case "ApplicantInterview":
                    return "dbo.tcdsb_LTO_PageSelectInterviewCandidate_Applicant" + pForSingle + ", @CPNum";
                case "ApplicantListSelect":
                    return "dbo.tcdsb_LTO_PageSelectInterviewCandidate_Applicants" + " @Operate, @SchoolYear, @PositionID";
                case "ApplicantContact":
                    return "dbo.tcdsb_LTO_PageApply_ApplicantContactInfo" + " @Operate, @CPNum";
                case "GeneralInfo":
                    return "dbo.tcdsb_LTO_PagePublish_GeneralInfo @AppType, @SchoolYear, @SchoolCode, @PositionID, @InfoType";
                case "List2Item":
                     return "dbo.tcdsb_LTO_ListDDLNew @Operate,@Para0,@Para1,@Para2,@Para3";
                case "NVListItem":
                    return "dbo.tcdsb_LTO_PageGeneral_List @Operate,@Para0,@Para1,@Para2,@Para3";
                case "ListSchool":
                    return "dbo.tcdsb_LTO_PageGeneral_ListSchools @Operate, @Para0, @Para1, @Para2, @Para3";

                default:
                    return "";
            }
        }

     

    }

 
  
}



