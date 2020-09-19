using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ApplicantNotice : Applicant
    {
        public string Operate { get; set; }
         public string PositionID { get; set; }
        public string SchoolYear { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilNumber { get; set; }
        public string MailTo { get; set; }
        public string MailCC { get; set; }
        public string PositionOwner { get; set; }
    }
}
