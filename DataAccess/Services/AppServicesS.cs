
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
  
    public class AppServicesS : IAppServicesS
    {
        // private readonly string _dataSource;
        public AppServicesS(string dataSource)
        {
            //   _dataSource = dataSource;
            AppDeadLine = new DeadLineR(dataSource);
            PageItem = new PageItemR(dataSource);
            AppNVList = new NameValueListR(dataSource); 

            AppPublishPosting = new PublishPosting(dataSource);
            AppRequestPosting = new RequestPosting(dataSource);
            AppInterview = new InterviewResults(dataSource);
            AppApplicants = new Applicants(dataSource);
            AppApplyPosting = new ApplyPosting(dataSource);
            AppApproveRequest = new ApproveRequest(dataSource);
            AppConfirmHire = new ConfirmHire(dataSource);
            AppGeneralItems = new GeneralItems(dataSource);
            AppHiredPositions = new HiredPositions(dataSource);
            AppPositionsCheck = new PositionsCheck(dataSource);
            AppSelectCandidate = new SelectCandidate(dataSource);
            AppStaffManage = new StaffManage(dataSource);
            AppPostingSummary = new PostingSummary(dataSource);
            AppPostingOther = new PostingCommon(dataSource);
        }

         public IDeadLine AppDeadLine { get; private set; }
        public IPageItem PageItem { get; private set; }

        public INameValueList AppNVList { get; private set; }

        public IPublishPosting AppPublishPosting { get; private set; }

        public IInterviewResult AppInterview { get; private set; }

        public IPostingSummary AppPostingSummary { get; private set; }


        public IRequestPosting AppRequestPosting { get; private set; }

        public IApplicants AppApplicants { get; private set; }

        public IApplyPosting AppApplyPosting { get; private set; }

        public IApproveRequest AppApproveRequest { get; private set; }

        public IConfirmHire AppConfirmHire { get; private set; }

        public IGeneralItems AppGeneralItems { get; private set; }

        public IHiredPositions AppHiredPositions { get; private set; }

        public IPositionsCheck AppPositionsCheck { get; private set; }

        public ISelectCandidate AppSelectCandidate { get; private set; }
        public IStaffManage AppStaffManage { get; private set; }


        public IPostingCommon AppPostingOther { get; private set; }

         
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

}
