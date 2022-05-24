using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IAppBase
    {
        List<T> CommonList<T>(string action, object parameter);

        T CommonObject<T>(string action, object parameter);

        string CommonAction(string action, object parameter);


        List<T> CommonList<T>(string type, string action, object parameter);

        T CommonObject<T>(string type, string action, object parameter);

        string CommonAction(string type, string action, object parameter);

        string SpName(string action, object parameter);


    }

    
}