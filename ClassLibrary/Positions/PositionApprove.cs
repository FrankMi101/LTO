using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class PositionApprove : PositionBase
    {
        public string RequestDate { get; set; }
        public string RequestUser { get; set; }
        public string WorkPlaceAccommodation { get; set; }
        public decimal WorkPlaceFTE { get; set; }

    }
}
