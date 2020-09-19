using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public class SingleTeacher
    {
        public static IList<TeacherListForPrincipalInterview> InterviewCandidates(ParametersForPosition parameter)
        {
            try
            {
                ITeacherListRepository<TeacherListForPrincipalInterview, string> repository = Factory.Get<ListTeachertInterviewCandiate>();
                IList<TeacherListForPrincipalInterview> list = repository.GetList(parameter);
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
