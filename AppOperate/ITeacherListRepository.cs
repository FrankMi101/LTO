using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
   public  interface ITeacherListRepository  <T,Tkey>
    {
        IList<T> GetList(ParametersForPosition parameter);
    }

   
}
