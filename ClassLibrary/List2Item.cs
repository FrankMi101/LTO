using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   
    public class List2Item
    {
         public string Operate { get; set; }
        public string Para0 { get; set; }
        public string Para1 { get; set; }
        public string Para2 { get; set; }
        public string Para3 { get; set; }

    }
    public class List4Item : List2Item
    {
         public string Category { get; set; }
        public string Orderby { get; set; }
    }
  
}
