using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ParametersForApply : ParametersForPosition
    {
        public string Operate { get; set; }
        public string UserID { get; set; }
        public string Action { get; set; }
        public string Comments { get; set; }
        public string Document { get; set; }
    }
}
