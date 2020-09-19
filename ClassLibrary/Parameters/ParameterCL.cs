using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
     public class ParameterCL
    {
        public string UserID { get; set; }
        public string Type { get; set; }
        public string Operate { get;  set; }
        public string Action { get; set; }
        public string SchoolYear { get; set; }
        public string SchoolCode { get; set; }
        public int PositionID { get; set; }
    }
    public class ParameterProfile
    {
        public string UserID { get; set; }
        public string Type { get; set; }
        public string GetBy { get; set; }
        public string ByValue { get; set; }     
    }
}
