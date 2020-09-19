using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public interface IOperate<T, TKey>
    {
        string SavePosting(object position, int positionID);
        string CancelPosting(object position, int positionID);
        string RePosting(object position, int positionID);
        string DeletePosting(object position, int positionID);
    }
    public interface IPositions<T, Tkey>
    {
        IList<T> Positions(ParametersForPositionList parameter);
    }
    public interface IPosition<T, Tkey>
    {
        IList<T> Position(ParametersForPosition parameter);
    }

    public interface IQualification<T>
    {
        List<T> rList(ParametersForPosition parameter);

    }
}
