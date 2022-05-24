
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataOperateServiceSQL : IDataOperateService
    {
        public List<T> ListOfT<T>(string db, string spName, object para)
        {
            return MyDapper.EasyDataAccess<T>.ListOfT(db, spName, para);
        }

        public T ObjectOfT<T>(string db, string spName, object para)
        {
            return MyDapper.EasyDataAccess<T>.ListOfT(db, spName, para)[0];
        }
        public T ValueOfT<T>(string db, string spName, object para)
        {
            return MyDapper.EasyDataAccess<T>.ValueOfT(db, spName, para);
        }


    }
    public class DataOperateServiceAsyncSQL : IDataOperateServiceAsync
    {
        public async Task<List<T>> ListOfT<T>(string db, string spName, object para)
        {
            var myDataAccess = new MyDapper.EasyDataAccessAsync<T>();
            return await myDataAccess.ListOfT(db, spName, para);
        }

        public async Task<T> ObjectOfT<T>(string db, string spName, object para)
        {
            var myDataAccess = new MyDapper.EasyDataAccessAsync<T>();
            return await  myDataAccess.ObjectOfT(db, spName, para);
        }
        public async Task<T> ValueOfT<T>(string db, string spName, object para)
        {
            var myDataAccess = new MyDapper.EasyDataAccessAsync<T>();
            return await myDataAccess.ValueOfT(db, spName, para);
        }


    }


    /// <summary>
    /// Data from SQL Server 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataOperateServiceSQL<T> : IDataOperateService<T>
    {
        public List<T> ListOfT(string db, string spName, object para)
        {
           return MyDapper.EasyDataAccess<T>.ListOfT(db, spName, para);
        }

        public T ObjectOfT(string db, string spName, object para)
        {
           return MyDapper.EasyDataAccess<T>.ListOfT(db, spName, para)[0];
        }
        public T ValueOfT(string db, string spName, object para)
        {
            return MyDapper.EasyDataAccess<T>.ValueOfT(db, spName, para);
        }

        public string ValueString(string db, string spName, object para)
        {
            return MyDapper.EasyDataAccess<string>.ValueOfT(db, spName, para);
        }
  
    }
}
