using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public class LimitDate
    {   public string Operate { get; set; }
        public string PositionType { get; set; }
        public string SchoolYear { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string DatePublish { get; set; }
        public string DateApplyOpen { get; set; }
        public string DateApplyClose { get; set; }
      
    }
    public class LTODefalutDate
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string DatePublish { get; set; }
        public string DateApplyOpen { get; set; }
        public string DateApplyClose { get; set; }
        public string BackDate { get; set; }
    }
}
