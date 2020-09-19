using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ParametersForTeacher : ParametersForPosition
    {
        public string SchoolCode { get; set; }
        public string Operate { get; set; }
        public string UserID { get; set; }

    }
}
