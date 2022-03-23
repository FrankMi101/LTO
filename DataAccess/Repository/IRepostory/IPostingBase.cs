using System.Collections.Generic;

namespace DataAccess.Repository
{
    public interface IPostingBase
    {
        List<T> CommonList<T>(string action, object parameter);

        T CommonObject<T>(string action, object parameter);

        string CommonAction(string action, object parameter);


        List<T> CommonList<T>(string type, string action, object parameter);

        T CommonObject<T>(string type, string action, object parameter);

        string CommonAction(string type, string action, object parameter);

        string SpName(string action, object parameter);
    }


    public interface IPostingBase<T>
    {


        List<T> CommonList(string action, object parameter);

        T CommonObject(string action, object parameter);

        string CommonAction(string action,object parameter);

        List<T> CommonList(string type,string action, object parameter);

        T CommonObject(string type, string action, object parameter);

        string CommonAction(string type,string action, object parameter);

        string SpName(string action, object parameter);
    }
  
}