
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{

    public class AppServices : IAppServices
    {
        // private readonly string _dataSource;
        public AppServices(string dataSource, IPostingBase iPosting)
        {
            AppOne = iPosting;
        }
        public IPostingBase AppOne { get; private set; }

        public AppServices(string dataSource)
        {
            //   _dataSource = dataSource;
            AppDeadLine = new DeadLineR(dataSource);
            PageItem = new PageItemR(dataSource);
            AppNVList = new NameValueListR(dataSource);

            //AppPublishPosting = new PublishPosting(dataSource);
            //AppRequestPosting = new RequestPosting(dataSource);
            //AppInterview = new InterviewResults(dataSource);
            //AppApplicants = new Applicants(dataSource);
            //AppApplyPosting = new ApplyPosting(dataSource);
            //AppApproveRequest = new ApproveRequest(dataSource);
            //AppConfirmHire = new ConfirmHire(dataSource);
            //AppGeneralItems = new GeneralItems(dataSource);
            //AppHiredPosition = new HiredPositions(dataSource);
            //AppPositionsCheck = new PositionsCheck(dataSource);
            //AppSelectCandidate = new SelectCandidate(dataSource);
            //AppStaffManage = new StaffManage(dataSource);
            //AppPostingSummary = new PostingSummary(dataSource);
            //AppPostingOther = new PostingCommon(dataSource);
        }

        public IDeadLine AppDeadLine { get; private set; }
        public IPageItem PageItem { get; private set; }

        public INameValueList AppNVList { get; private set; }

 
        //public IPostingBase AppPublishPosting { get; private set; }

        //public IPostingBase AppInterview { get; private set; }

        //public IPostingBase AppPostingSummary { get; private set; }


        //public IPostingBase AppRequestPosting { get; private set; }

        //public IPostingBase AppApplicants { get; private set; }

        //public IPostingBase AppApplyPosting { get; private set; }

        //public IPostingBase AppApproveRequest { get; private set; }

        //public IPostingBase AppConfirmHire { get; private set; }

        //public IPostingBase AppGeneralItems { get; private set; }

        //public IPostingBase AppHiredPosition { get; private set; }

        //public IPostingBase AppPositionsCheck { get; private set; }

        //public IPostingBase AppSelectCandidate { get; private set; }
        //public IPostingBase AppStaffManage { get; private set; }
        //public IPostingCommon AppPostingOther { get; private set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

}
