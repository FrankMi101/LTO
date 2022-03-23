
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IAppServicesS : IDisposable
    {
        IDeadLine AppDeadLine { get; }
        INameValueList AppNVList { get; }
        IPageItem PageItem { get; }

        IPublishPosting AppPublishPosting { get; }

        IRequestPosting AppRequestPosting { get; }

        IInterviewResult AppInterview { get; }
        IApplicants AppApplicants { get; }
        IApplyPosting AppApplyPosting { get; }
        IApproveRequest AppApproveRequest { get; }
        IConfirmHire AppConfirmHire { get; }
        IGeneralItems AppGeneralItems { get; }
        IHiredPositions AppHiredPositions { get; }
        IPositionsCheck AppPositionsCheck { get; }
        ISelectCandidate AppSelectCandidate { get; }
        IStaffManage AppStaffManage { get; }
        IPostingSummary AppPostingSummary { get; }

        IPostingCommon AppPostingOther { get; }

    }
    public interface IAppServices : IDisposable
    {
        IPostingBase AppOne { get; }

        IDeadLine AppDeadLine { get; }
        INameValueList AppNVList { get; }
        IPageItem PageItem { get; }

        //IPostingBase AppPublishPosting { get; }
        //IPostingBase AppRequestPosting { get; }
        //IPostingBase AppInterview { get; }
        //IPostingBase AppApplicants { get; }
        //IPostingBase AppApplyPosting { get; }
        //IPostingBase AppApproveRequest { get; }
        //IPostingBase AppConfirmHire { get; }
        //IPostingBase AppGeneralItems { get; }
        //IPostingBase AppHiredPosition { get; }
        //IPostingBase AppPositionsCheck { get; }
        //IPostingBase AppSelectCandidate { get; }
        //IPostingBase AppStaffManage { get; }
        //IPostingBase AppPostingSummary { get; }

        //IPostingCommon AppPostingOther { get; }

    }
}
