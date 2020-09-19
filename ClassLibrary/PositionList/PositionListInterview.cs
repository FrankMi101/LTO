using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// position list for principal to do a interview page
    /// </summary>
    public class PositionListInterview : PositionListS
    {
        public string InterviewProgress { get; set; }
        public string RequestSchool { get; set; }
        public string HiredTeacher { get; set; }
        public string Team { get; set; }
    }
}
