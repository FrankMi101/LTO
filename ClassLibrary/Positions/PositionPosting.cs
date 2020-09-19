using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class PositionPosting : PositionBase
    {
        public string DateNotice { get; set; }
        public string DateRemaider { get; set; }
        public string Applicant { get; set; }
        public int InterviewCount { get; set; }
        public int InterviewRequest { get; set; }
        public int RequestID { get; set; }
        public int LinkPositionID { get; set; }
        public string QualificationID { get; set; }
        public string SchoolArea { get; set; }
        public string PostingRound { get; set; }
        public string HiredInformation { get; set; }
        public string TakeApplicant { get; set; }


    }

}
