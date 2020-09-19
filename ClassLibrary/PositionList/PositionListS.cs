using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// Posting position List for  all related list on List Page
    /// </summary>
    public abstract class PositionListS : PositionBase
    {
        public string CurrentStep { get; set; }
        public string ActionSign { get; set; }
        public int RowNo { get; set; }
        public string SchoolName { get; set; }
        public string SchoolArea { get; set; }

    }

  
}
