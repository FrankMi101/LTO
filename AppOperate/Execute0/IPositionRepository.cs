using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public interface IPositionRepository<T, Tkey>
    {
        IList<T> GetPosition(ParametersForPosition parameter);
        IList<T> GetPosition(int positionID);

    }
}
