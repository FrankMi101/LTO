using ClassLibrary;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public class ListTeachertInterviewCandiate : ITeacherListRepository<TeacherListForPrincipalInterview, string>
    {
        public IList<TeacherListForPrincipalInterview> GetList(int positionID)
        {
            throw new NotImplementedException();
        }

        public IList<TeacherListForPrincipalInterview> GetList(ParametersForPosition parameter)
        {
            try
            {
                string sp = "dbo.tcdsb_LTO_TeacherList_InterviewCandidate @SchoolYear,@PositionID";
                var list = GeneralDataAccess.GetListofTypeT<TeacherListForPrincipalInterview>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
    }
}
