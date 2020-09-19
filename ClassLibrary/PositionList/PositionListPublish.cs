using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// position list for select interview candidate
    /// </summary>
    public class PositionListPublish : PositionListS
    {
        public string EmailNotice { get; set; }
        public int ApplicantCount { get; set; }
        public int DayToClose { get; set; }
    }
}
