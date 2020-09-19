using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// position list on HR approve school request page
    /// </summary>
    public class PositionListApprove : PositionListS
    {
        public string RequestStatus { get; set; }
        public int RequesID { get; set; }
        public string RequestDate { get; set; }

    }
}
