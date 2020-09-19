using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    ///  about the applicant list show on the HR select intwrview canadidate and principal interview page
    /// </summary>
    public abstract class TeacherList
    {
        public string ActionSign { get; set; }
        public string TeacherName { get; set; }
        public string OCTLink { get; set; }
        public string OCTQualification { get; set; }
        public string Comments { get; set; }
        public string DateHired { get; set; }
        public string DateApplied { get; set; }
        public string InterviewResult { get; set; }
        public string LTOAppraisal { get; set; }
        public string TeacherApplyComments { get; set; }
    }
    /// <summary>
    ///  interview candidate list show on the School Principal Open Position List 
    /// </summary>
    public class TeacherListForPrincipalInterview : TeacherList
    {
        public string DateInterview { get; set; }
        public string RecommendForHire { get; set; }
    }
    /// <summary>
    /// the applicant list show on the HR select interview canadidate list under the select interview Candidate and school interview list 
    /// </summary>
    public class TeacherListSelectInterviewCandidate : TeacherList
    {
        public bool SelectedAction { get; set; }
        public string SelectedInterview { get; set; }
        public bool NoticeToPrincipal { get; set; }
    }
    public class TeachersListByCategory
    {
        public string Category { get; set; }
        public string CPNum { get; set; }
        public string TeacherName { get; set; }
        public string UserID { get; set; }
    }
}
