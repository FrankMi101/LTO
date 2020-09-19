using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// position list for Applicant to apply the posting
    /// </summary>
    public class PositionListApplying : PositionListS
    {
        public string SchoolMap { get; set; }
        public int DaysToClose { get; set; }
        public string StartTime { get; set; }
        public string DateApplyStart { get; set; }
        public string DateDeadline { get; set; }
        public string DaystoEndImg { get; set; }
        public string Resume { get; set; }
        public string  CoverLetter { get; set; }
        public string UploadFile { get; set; }
    }
}
