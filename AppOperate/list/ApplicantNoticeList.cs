using ClassLibrary;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
   public  class ApplicantNoticeList
    {
        public static List<ApplicantNotice> ApplicantsNoticebyID(ApplicantNotice parameter)
        {
            try
            {
                string sp = "dbo.tcdsb_LTO_PagePublish_NoticeToTeacherList @UserID, @SchoolYear,@PositionID,@Action";
                List<ApplicantNotice> noticelist = GeneralDataAccess.GetListofTypeT<ApplicantNotice>(sp, parameter);
                return noticelist;
            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
                return null;
            }
        }

    }
}
