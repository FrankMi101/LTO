using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// position list for publish page
    /// </summary>
    public class PositionListPosting : PositionListS
    {
        public int DayToClose { get; set; }
        public string SubstituedSign { get; set; }

    }
}
