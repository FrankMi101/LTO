using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public  class Profile
    {
        public string  UserID { get; set; }
        public string  SchoolYear { get; set; }
        public string  ProfileType { get; set; }
        public string  CheckValue { get; set; }
        public string Operate { get; set; }
    }
    public class SearchParameter
    {
         public string Operate { get; set; }
        public string SchoolYear { get; set; }
        public string PositionType { get; set; }
        public string SearchType { get; set; }
        public string DatePublish   { get; set; }
    }
}
