using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class PositionPublish : PositionInfo
    {
        public int RequestCount { get; set; }
        public string CanRecover { get; set; }
    }
}
