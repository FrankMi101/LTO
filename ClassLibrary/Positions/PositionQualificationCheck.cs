using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class PositionQualificationCheck : PositionBase
    {
        public string OCTQualification { get; set; }
        public string QualificationCheck { get; set; }
        public string NonQualification { get; set; }
        public string CurrentAssignment { get; set; }
    }

    public class QualCheck
    {
        public string Value { get; set; }
        public string  Name { get; set; }
        public string  Checked { get; set; }
    }
    public class QualSearch
    {
        public string  SelectedCode { get; set; }
        public string  SearchValue { get; set; }
    }
}
