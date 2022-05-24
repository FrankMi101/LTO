using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IAppBaseAsync
    {
        Task<string> CommonAction(string action, object parameter);
        Task<string> CommonAction(string type, string action, object parameter);

        Task<List<T>> CommonList<T>(string action, object parameter);
        Task<List<T>> CommonList<T>(string type, string action, object parameter);

        Task<T> CommonObject<T>(string action, object parameter);
        Task<T> CommonObject<T>(string type, string action, object parameter);

        string SpName(string action, object parameter);
    }
}