using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public class CommonListExecute
    {
        //ICommonList<T>   _ICommentList; 
        //public CommonListExecute()
        //{
        //    _ICommentList = ListClassFactory.GetListClassObj<T>();
        //}
        public static List<T> AllPositionList<T>(object parameter)
        {
            // return   _ICommentList.MyGeneralList(parameter);
            var mylist = ObjClassFactory.GetListClassObj<T>(); // new CommonList<T>();  //  Factory.GetClass<CommonList<T>>(); //
            return mylist.MyGeneralList(parameter);
 

        }

        public static List<PositionListRequesting> RequestPositions(ParametersForPositionList parameter)
        {
            // var mylist = new CommonList<PositionListRequesting>();
            //  return mylist.ListPositions(parameter);
            // return CommonListExecute<PositionListRequesting>.GeneralPositions(parameter);
            return AllPositionList<PositionListRequesting>(parameter);
        }
        public static List<PositionRequesting> RequestPosition(ParametersForPosition parameter)
        {
            return AllPositionList<PositionRequesting>(parameter);
        }

        public static List<PositionListApprove> ApprovePositions(ParametersForPositionList parameter)
        {
            return AllPositionList<PositionListApprove>(parameter);
        }
        public static List<PositionApprove> ApprovePosition(ParametersForPosition parameter)
        {
            return AllPositionList<PositionApprove>(parameter);
        }
        public static List<PositionListPublish> PublishPositions(ParametersForPositionList parameter)
        {
            return AllPositionList<PositionListPublish>(parameter);
        }
        public static List<PositionPublish> PublishPosition(ParametersForPosition parameter)
        {
            return AllPositionList<PositionPublish>(parameter);

        }

        public static List<PositionListPublished> PublishedPositions(ParametersForPositionList parameter)
        {
            return AllPositionList<PositionListPublished>(parameter);
        }
        public static List<ApplicantList> PublishedApplicants(ParametersForPosition parameter)
        {
            return AllPositionList<ApplicantList>(parameter);
        }
        public static List<PositionInfo> PublishPositionInfo(ParametersForPosition parameter)
        {
            return AllPositionList<PositionInfo>(parameter);
        }

        public static List<PositionListHired> HiredPositions(ParametersForPositionList parameter)
        {
            return AllPositionList<PositionListHired>(parameter);
        }
        public static List<PositionListConfirm> ConfirmPositions(ParametersForPositionList parameter)
        {
            return AllPositionList<PositionListConfirm>(parameter);
        }
        public static List<PositionHire> HirePosition(ParametersForPosition parameter)
        {
            return AllPositionList<PositionHire>(parameter);

        }
        public static List<PositionHired> HiredPosition(ParametersForPosition parameter)
        {
            return AllPositionList<PositionHired>(parameter);
        }
        public static List<PositionHire4thRound> HirePosition4thRound(ParametersForPosition parameter)
        {
            return AllPositionList<PositionHire4thRound>(parameter);

        }

        public static List<QualificationSelected> QualificationList(ParametersForPosition parameter)
        {
            return AllPositionList<QualificationSelected>(parameter);
        }
        public static List<LimitDate> LimitedDate(LimitDate parameter)
        {
            return AllPositionList<LimitDate>(parameter);
        }
        public static List<PositionListInterview> SchoolOpenPositions(ParametersForPositionList parameter)
        {
            return AllPositionList<PositionListInterview>(parameter);
        }
        public static List<CandidateList> InterviewCandidates(ParametersForPosition parameter)
        {
            return AllPositionList<CandidateList>(parameter);
        }
        public static List<PositionInterview> InterviewCandidate(ParametersForPosition parameter)
        {
            return AllPositionList<PositionInterview>(parameter);
        }
        public static List<PositionApplying> ApplyingPosition(ParametersForPosition parameter)
        {
            return AllPositionList<PositionApplying>(parameter);
        }
        public static List<CandidateListNotice> NoticeInterviewCandidate(ParametersForCandidate parameter)
        {
            return AllPositionList<CandidateListNotice>(parameter);
        }

        public static List<ApplicantNoticeList> ApplicantsNoticeList(ParametersForCandidate parameter)
        {
            return AllPositionList<ApplicantNoticeList>(parameter);
        }


        public static List<ApplicantListSelect> ApplicantListSelect(ParametersForApplicantList parameter)
        {
            return AllPositionList<ApplicantListSelect>(parameter);
        }


        public static List<ApplicantInterview> ApplicantInterviewProfile(IParametersForPosition parameter)
        {
            return AllPositionList<ApplicantInterview>(parameter);
        }

        public static List<ApplicantContact> ApplicantContactProfile(ApplicantContact parameter)
        {
            return AllPositionList<ApplicantContact>(parameter);
        }

        public static List<List2Item> GetListData(object parameter)
        {
            return AllPositionList<List2Item>(parameter);
            //string sp = "dbo.tcdsb_LTO_ListDDLNew @Operate,@Para0,@Para1,@Para2,@Para3";
            //var myListData = GeneralDataAccess.GetListofTypeT<List2Item>(sp, parameter);
            //return myListData;
        }
        public static List<ListSchool> GetSchoolListData(object parameter)
        {
            return AllPositionList<ListSchool>(parameter);
            
        }
        public static List<NvListItem> GetNVListData(object parameter)
        {
            return AllPositionList<NvListItem>(parameter);
            //string sp = "dbo.tcdsb_LTO_ListDDLNew @Operate,@Para0,@Para1,@Para2,@Para3";
            //var myListData = GeneralDataAccess.GetListofTypeT<List2Item>(sp, parameter);
            //return myListData;
        }
    }
    public class CommonListExecute<T>
    {

        //public static List<T> ListPositions<T>(object parameter)
        //{
        //    var mylist = new CommonList<T>();  //  Factory.GetClass<CommonList<T>>(); //
        //    return mylist.MyGeneralList(parameter);
        //}
        //public static List<T> ListPosition<T>(object parameter)
        //{
        //    var mylist = new CommonList<T>();  //  Factory.GetClass<CommonList<T>>(); //
        //    return mylist.MyGeneralList(parameter);
        //}

        public static List<T> GeneralPositions(ParametersForPositionList parameter)
        {
            var mylist = new CommonList<T>();
            return mylist.MyGeneralList(parameter);

        }
        public static List<T> GeneralPosition(ParametersForPosition parameter)
        {
            var mylist = new CommonList<T>();
            return mylist.MyGeneralList(parameter);
        }
        public static List<T> GeneralList(LimitDate parameter)
        {
            var mylist = new CommonList<T>();
            return mylist.MyGeneralList(parameter);
        }

        public static List<T> GeneralCandidate(ParametersForCandidate parameter)
        {
            var mylist = new CommonList<T>();
            return mylist.MyGeneralList(parameter);
        }
        public static string ObjSP(string objName ) 
        {
            var mylist = new CommonList<T>();
            return mylist.GetSP(objName);

        }
       
        public static string ObjSP(string page, string action)
        {
            var mylist = new CommonList<T>();
            return mylist.GetSP(page);

        }

        public static List<T> GeneralPositions(string SP, object parameter)
        {
            var mylist = new CommonList<T>();
            return mylist.GeneralListOfT(SP, parameter);
        }
        public static List<T> GeneralList(string SP, object parameter)
        {
            var mylist = new CommonList<T>();
            return mylist.GeneralListOfT(SP,parameter);
        }


    }

    //public class CommonListExecuteM
    //{
    //    public static List<PositionListRequesting> RequestPositions(ParametersForPositionList parameter)
    //    {

    //        // var mylist = new CommonList<PositionListRequesting>();
    //        //  return mylist.ListPositions(parameter);
    //        return CommonListExecute<PositionListRequesting>.GeneralPositions(parameter);
    //    }
    //    public static List<PositionRequesting> RequestPosition(ParametersForPosition parameter)
    //    {
    //        return CommonListExecute<PositionRequesting>.GeneralPosition(parameter);

    //    }

    //    public static List<PositionListApprove> ApprovePositions(ParametersForPositionList parameter)
    //    {

    //        return GeneralPositions<PositionListApprove>(parameter);
    //    }
    //    public static List<PositionApprove> ApprovePosition(ParametersForPosition parameter)
    //    {

    //        return GeneralPosition<PositionApprove>(parameter);
    //    }
    //    public static List<PositionListPublish> PublishPositions(ParametersForPositionList parameter)
    //    {
    //        //   return CommonListExecute<PositionListPublish>.GeneralPositions(parameter);
    //        return GeneralPositions<PositionListPublish>(parameter);

    //    }
    //    public static List<PositionPublish> PublishPosition(ParametersForPosition parameter)
    //    {
    //        //  return CommonListExecute<PositionPublish>.GeneralPosition(parameter);
    //        return GeneralPosition<PositionPublish>(parameter);


    //    }
    //    public static List<PositionInfo> PublishPositionInfo(ParametersForPosition parameter)
    //    {
    //        //   return CommonListExecute<PositionInfo>.GeneralPosition(parameter);
    //        return GeneralPosition<PositionInfo>(parameter);

    //    }

    //    public static List<PositionListHired> HiredPositions(ParametersForPositionList parameter)
    //    {
    //        // return CommonListExecute<PositionListHired>.GeneralPositions(parameter);
    //        return GeneralPositions<PositionListHired>(parameter);

    //    }
    //    public static List<PositionListConfirm> ConfirmPositions(ParametersForPositionList parameter)
    //    {
    //        //   return CommonListExecute<PositionListConfirm>.GeneralPositions(parameter);
    //        return GeneralPositions<PositionListConfirm>(parameter);

    //    }
    //    public static List<PositionHire> HirePosition(ParametersForPosition parameter)
    //    {
    //        // return CommonListExecute<PositionHire>.GeneralPosition(parameter);
    //        return GeneralPosition<PositionHire>(parameter);

    //    }
    //    public static List<PositionHired> HiredPosition(ParametersForPosition parameter)
    //    {
    //        // return CommonListExecute<PositionHired>.GeneralPosition(parameter);
    //        return GeneralPosition<PositionHired>(parameter);

    //    }
    //    public static List<PositionHire4thRound> HirePosition4thRound(ParametersForPosition parameter)
    //    {
    //        //  return CommonListExecute<PositionHire4thRound>.GeneralPosition(parameter);
    //        return GeneralPosition<PositionHire4thRound>(parameter);

    //    }


    //    public static List<QualificationSelected> QualificationList(ParametersForPosition parameter)
    //    {
    //        //  return CommonListExecute<QualificationSelected>.GeneralPosition(parameter);
    //        return GeneralPosition<QualificationSelected>(parameter);
    //    }
    //    public static List<LimitDate> LimitedDate(LimitDate parameter)
    //    {
    //        return GeneralList<LimitDate>(parameter);
    //    }
    //    public static List<PositionListInterview> SchoolOpenPositions(ParametersForPositionList parameter)
    //    {
    //        //    return CommonListExecute<PositionListInterview>.GeneralPositions(parameter);
    //        return GeneralPositions<PositionListInterview>(parameter);


    //    }
    //    public static List<CandidateList> InterviewCandidates(ParametersForPosition parameter)
    //    {
    //        //   return CommonListExecute<CandidateList>.GeneralPosition(parameter);
    //        return GeneralPosition<CandidateList>(parameter);

    //    }
    //    public static List<PositionInterview> InterviewCandidate(ParametersForPosition parameter)
    //    {
    //        //  return CommonListExecute<PositionInterview>.GeneralPosition(parameter);
    //        return GeneralPosition<PositionInterview>(parameter);

    //    }
    //    public static List<CandidateListNotice> NoticeInterviewCandidate(ParametersForCandidate parameter)
    //    {
    //        // return CommonListExecute<CandidateListNotice>.GeneralCandidate(parameter);
    //        return GeneralCandidate<CandidateListNotice>(parameter);

    //    }
    //    private static List<T> GeneralPositions<T>(ParametersForPositionList parameter)
    //    {
    //        var mylist11 = new CommonList<T>();
    //        //   return mylist11.ListPositions(parameter);
    //        return mylist11.MyGeneralList(parameter);
    //        //  return mylist11.MyList(parameter);
    //    }
    //    private static List<T> GeneralPosition<T>(ParametersForPosition parameter)
    //    {
    //        var mylist11 = new CommonList<T>();
    //        //  return mylist11.ListPosition(parameter);
    //        return mylist11.MyGeneralList(parameter);
    //    }

    //    private static List<T> GeneralList<T>(LimitDate parameter)
    //    {
    //        var mylist = new CommonList<T>();
    //        return mylist.MyGeneralList(parameter);
    //    }

    //    private static List<T> GeneralCandidate<T>(ParametersForCandidate parameter)
    //    {
    //        var mylist = new CommonList<T>();
    //        return mylist.MyGeneralList(parameter);
    //    }

    //    //public static List<T> AllPosition<T>(T parameter)
    //    //{
    //    //    var mylist = new CommonList<T>();
    //    //    return mylist.ListPositions(parameter);
    //    // //   ICommonList<T> repository = Factory.Get<CommonList<T>>();
    //    // //return repository.ListPositions(parameter);
    //    //}

    //    //public static List<T> PositionList<T>(object parameter)
    //    //{
    //    //    var mylist11 = new CommonList<T>();
    //    //    return mylist11.MyGeneralList(parameter);
    //    //}

    //}

}
