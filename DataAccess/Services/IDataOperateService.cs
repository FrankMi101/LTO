using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDataOperateService
    {

        List<T> ListOfT<T>(string db, string spName, object para);

        T ObjectOfT<T>(string db, string spName, object para);

        T ValueOfT<T>(string db, string spName, object para);
    }
    public interface IDataOperateService<T>
    {

        List<T> ListOfT(string db, string spName, object para);

        T ObjectOfT(string db, string spName, object para);

       string ValueString(string db, string spName, object para);
 
        T ValueOfT(string db, string spName, object para);
    }
    public interface IDataOperateServiceAsync
    {

        Task<List<T>> ListOfT<T>(string db, string spName, object para);

        Task<T> ObjectOfT<T>(string db, string spName, object para);

        Task<T> ValueOfT<T>(string db, string spName, object para);
    }
}
