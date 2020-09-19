using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ApplicantContact : Applicant
    {
        public string Operate { get; set; }
        public string PositionID { get; set; }

        public string UploadFile { get; set; }
    }
}
