using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ApplicantList : Applicant
    {
        public string ActionSign { get; set; }
        public string OCTLink { get; set; }
        public string SelectForInterview { get; set; }
        public string SelectCheck { get; set; }
        public int RowNo { get; set; }
    }
}
