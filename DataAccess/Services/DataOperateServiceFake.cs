
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace DataAccess
{
    public class DataOperateServiceFake : IDataOperateService
    {
        public List<T> ListOfT<T>(string db, string spName, object para)
        {
            return MyFake.EasyDataAccess<T>.ListOfT(db, spName, para);
        }

        public T ObjectOfT<T>(string db, string spName, object para)
        {
            return MyFake.EasyDataAccess<T>.ListOfT(db, spName, para)[0];
        }
        public T ValueOfT<T>(string db, string spName, object para)
        {
            return MyFake.EasyDataAccess<T>.ValueOfT(db, spName, para);
        }

    }

    /// <summary>
    /// Data from SQL Server 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataOperateServiceFake<T> : IDataOperateService<T>
    {
        public List<T> ListOfT(string db, string spName, object para)
        {
            return  MyFake.EasyDataAccess<T>.ListOfT(db, spName, para);
        }

        public T ObjectOfT(string db, string spName, object para)
        {
            return MyFake.EasyDataAccess<T>.ListOfT(db, spName, para)[0];
        }
        public T ValueOfT(string db, string spName, object para)
        {
            return MyFake.EasyDataAccess<T>.ValueOfT(db, spName, para);
        }

        public string ValueString(string db, string spName, object para)
        {
            return MyFake.EasyDataAccess<string>.ValueOfT(db, spName, para);
        }
  
    }
}
