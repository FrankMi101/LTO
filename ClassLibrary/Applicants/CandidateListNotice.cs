using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CandidateListNotice : Candidate
    {
        public string  InterViewSelected { get; set; }
        public string DateApplyOpen { get; set; }
        public string DateApplyClose { get; set; }
        public new string ApplyDate { get; set; }
    }
}
