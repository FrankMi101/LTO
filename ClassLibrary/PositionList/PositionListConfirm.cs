using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// positionlist for HR confirm hire
    /// </summary>
    public class PositionListConfirm : PositionListS
    {
        public string DateApplied { get; set; }
        public string DateInterview { get; set; }
        public string TeacherName { get; set; }
        public string Acceptance { get; set; }
        public string Acceptance1 { get; set; }
        public string Appraisal { get; set; }
        public string ApplicantQualification { get; set; }
    }
}
