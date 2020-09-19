using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class QualificationSelected
    {
        public int PositionID { get; set; }
        public string QualificationID { get; set; }
        public string Selected { get; set; }
    }
    public class QualificationUpdate : QualificationSelected
    {
        public string Operate { get; set; }
        public string UserID { get; set; }
        public string SchoolYear { get; set; }
        public string SchoolCode { get; set; }
        public string SourceID { get; set; }
   

    }
}
