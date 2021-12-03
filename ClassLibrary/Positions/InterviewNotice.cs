using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class InterviewNotice : InterviewResult
    {
        public string NoticeDate { get; set; }
        public string PrincipalID { get; set; }
        public int RequestCount { get; set; }
        public string Comments { get; set; }

    }
}
