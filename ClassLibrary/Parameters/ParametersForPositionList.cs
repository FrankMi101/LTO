using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public  class ParametersForPositionList : IParametersForPositionList 
    {  public string Operate { get; set; }
        public string  UserID { get; set; }
        public string SchoolYear { get; set; }
        public string SchoolCode { get; set; }
        public string PositionType { get; set; }
        public string  Panel { get; set; }
        public string  Status { get; set; }
        public string  SearchBy { get; set; }
        public string SearchValue1 { get; set; }
        public string SearchValue2 { get; set; } 
        public string UserRole { get; set; }
        public string CPNum { get; set; }
      
    }
   
}
