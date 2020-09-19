using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using DataAccess.Common;

namespace AppOperate
{
    public class ListTeacherSelectnterviewCandidate : ITeacherListRepository<TeacherListSelectInterviewCandidate, int>
    {
        public IList<TeacherListSelectInterviewCandidate> GetList(int positionID)
        {
            throw new NotImplementedException();
        }

        public IList<TeacherListSelectInterviewCandidate> GetList(ParametersForPosition parameter)
        {
               try
            {
                 string sp = "dbo.tcdsb_LTO_TeacherList_InterviewCandidateSelect @SchoolYear,@PositionID"  ;
                var ilist = GeneralDataAccess.GetListofTypeT<TeacherListSelectInterviewCandidate>(sp, parameter);
                return ilist;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }

      
    }
}
