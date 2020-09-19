using System.Collections.Generic;

namespace AppOperate
{
    public interface ICommonList<T>
    {
        List<T> MyGeneralList(object parameter);
        List<T> MyList(T parameter);
        string GetSP(string objName);
    }
    public interface ICommenList
    {
        List<T> MyGeneralList<T>(object parameter);

    }
}