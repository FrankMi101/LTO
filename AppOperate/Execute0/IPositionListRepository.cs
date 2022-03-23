using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
   public interface IPositionListRepository<T, Tkey>
    {
        IList<T> GetList(ParametersForPositionList parameter);
    }
     
}
