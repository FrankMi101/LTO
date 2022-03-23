
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly string _db = "";
        private readonly IDataOperateService<T> _dataOperate;
        public Repository()
        {
            _db = DBConnection.CurrentDB;
            this._dataOperate = DataSourceMap<T>.DBSource();
        }
        public Repository(string dataSource)
        {
            _db = DBConnection.CurrentDB;
            this._dataOperate = DataSourceMap<T>.DBSource(dataSource);
        }

        public List<T> ListOfT(string spName, object para)
        {
            return  ListOfT(_db, spName, para);
        }
        public List<T> ListOfT(string db, string spName, object para)
        {
            return _dataOperate.ListOfT(db, GetspName(spName), para);
        }


        public T ObjectOfT(string spName, object para)
        {
            return ObjectOfT(_db, spName, para);
        }
        public T ObjectOfT(string db, string spName, object para)
        {
            return _dataOperate.ObjectOfT(db, GetspName(spName), para);
        }


        public string ValueString(string spName, object para)
        {
            return ValueString(_db, spName, para);
        }
        public  string ValueString(string db, string spName, object para)
        {
            return _dataOperate.ValueString(db, GetspName(spName), para);
        }

        public virtual string ValueString(string db, string spName, T para)
        {
            return _dataOperate.ValueString(db, GetspName(spName), para);
        }
        public T ValueOfT(string spName, object para)
        {
            return ValueOfT(_db, spName, para);
        }
        public T ValueOfT(string db, string spName, object para)
        {
            return _dataOperate.ValueOfT(db, GetspName(spName), para);
        }

        public virtual object GetParameter(string operate, T obj)
        {
            return new { operate = operate };
        }
        public virtual string GetspName(string action)
        {
            return  GetDefaultspName(action);
        }
        private string GetDefaultspName(string action)
        {
            var objType = typeof(T).Name;
            switch (objType)
            {
                case "Deadline":
                    return "dbo.tcdsb_LTO_PagePublish_Deadline";// @SchoolYear, @DatePublish, @PositionType";
                 case "Selected":
                    return "dbo.tcdsb_LTO_PageCandidate_Select";
                case "UnSelected":
                    return "dbo.tcdsb_LTO_PageCandidate_Select";
                default:
                    return action;

            }
        }
    }
}
