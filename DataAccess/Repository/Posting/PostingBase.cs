using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public abstract class PostingBase<T> :  IPostingBase<T>
    {
        private readonly string _db = "";
        private readonly IDataOperateService<T> _dataOperate;
        public PostingBase()
        {
            _db = DBConnection.CurrentDB;
            this._dataOperate = DataSourceMap<T>.DBSource();

            //var ds = new DataSourceMap2<T>();
            //this._dataOperate = ds.DBSource();  
        }
        public PostingBase(string dataSource)
        {
            _db = DBConnection.CurrentDB;
            this._dataOperate =  DataSourceMap<T>.DBSource(dataSource);

          //var ds = new DataSourceMap2<T>();
          //  this._dataOperate = ds.DBSource(dataSource);

        }
        public PostingBase(IDataOperateService<T> iData)
        {
            _db = DBConnection.CurrentDB;
            this._dataOperate = iData;
        }

     
 
        public List<T> CommonList(string action, object parameter)
        {
            return CommonList(_db, action, parameter);
        }
        public T CommonObject(string action,object parameter)
        {
            return CommonObject(_db, action, parameter);
        }
        public string CommonAction(string action, object parameter)
        {
            return CommonAction(_db, action, parameter);
        }

        public List<T> CommonList(string db,string action, object parameter)
        {
             string sp = SpName(action, parameter);
            return _dataOperate.ListOfT(db, sp, parameter);
        }
        public T CommonObject(string db, string action, object parameter)
        {
             string sp = SpName(action, parameter);
            return _dataOperate.ObjectOfT(db, sp, parameter);
        }
        public string CommonAction(string db,string action, object parameter)
        {
            string sp = SpName(action, parameter);
            return _dataOperate.ValueString(db, sp, parameter);
        }

        public virtual string SpName(string action, object parameter)
        {
            return GetspName(action) + " " + GetParameters(action, parameter);
        }

        private string GetspName(string action)
        {

            switch (action)
            {
                case "Deadline":
                    return "dbo.tcdsb_LTO_PagePublish_Deadline" ;
                case "Selected":
                    return "dbo.tcdsb_LTO_PageCandidate_Select" ;
                case "UnSelected":
                    return "dbo.tcdsb_LTO_PageCandidate_Select" ;
                default:
                    return action;

            }
        }

        // Get Store procedure name based on the parameter type.
        // If parameter type is Anonymous, no need to pass SP parameters. it will handle by Dapper ORM add in automaticlly.
        // If parameter type is not Anonymous will reture SP name and parameter
        private string GetParameters(string action, object para)
        {
            bool IsAnonymous = para.GetType().FullName.Contains("AnonymousType");
            if (IsAnonymous) return "";

         //   string para = IsAnonymous ? "" : action;

 
            switch (action)
            {
 
                case "Deadline":        return "@SchoolYear, @PublishDate, @PositionType";
                case "DefaultDate":     return "@SchoolYear, @DatePublish, @PositionType";
                case "Selected":        return "@SchoolYear, @SchoolCode, @PositionID";
                case "UnSelected":      return "@UserID, @SchoolYear, @PositionID";
  
                default: return "";

            }
        }
    }

    public abstract class PostingBase : IPostingBase
    {
        private readonly string _db = "";
        private readonly IDataOperateService _dataOperate;
        public PostingBase()
        {
            _db = DBConnection.CurrentDB;
            this._dataOperate = DataSourceMap.DBSource();

            //var ds = new DataSourceMap2<T>();
            //this._dataOperate = ds.DBSource();  
        }
        public PostingBase(string dataSource)
        {
            _db = DBConnection.CurrentDB;
            this._dataOperate = DataSourceMap.DBSource(dataSource);

            //var ds = new DataSourceMap2<T>();
            //  this._dataOperate = ds.DBSource(dataSource);

        }
   

        public  List<T> CommonList<T>(string action, object parameter)
        {
            return CommonList<T>(_db, action, parameter);
        }
        public T CommonObject<T>(string action, object parameter)
        {
            return CommonObject<T>(_db, action, parameter);
        }
        public string CommonAction(string action, object parameter)
        {
            return CommonAction(_db, action, parameter);
        }

        public List<T> CommonList<T>(string db, string action, object parameter)
        {
            string sp = SpName(action, parameter);
            return _dataOperate.ListOfT<T>(db, sp, parameter);
        }
        public T CommonObject<T>(string db, string action, object parameter)
        {
            string sp = SpName(action, parameter);
            return _dataOperate.ObjectOfT<T>(db, sp, parameter);
        }
        public string CommonAction(string db, string action, object parameter)
        {
            string sp = SpName(action, parameter);
            return _dataOperate.ValueOfT<string>(db, sp, parameter);
        }

        public virtual string SpName(string action, object parameter)
        {
            // Get Store procedure name based on the parameter type.
            // If parameter type is Anonymous, no need to pass SP parameters. it will handle by Dapper ORM add in automaticlly.
            // If parameter type is not Anonymous will reture SP name and parameter

            bool IsAnonymous = parameter.GetType().FullName.Contains("AnonymousType");
            string sp = GetspName(action);
            if (IsAnonymous)
                return sp;
            else
            {
                string para = GetParameters(action);
                if (para.Length > 1) return sp + " " + para;

                return sp;
            }
        }
 
        private string GetspName(string action)
        {

            switch (action)
            {
                case "Deadline":             return "dbo.tcdsb_LTO_PagePublish_Deadline";
                case "Selected":             return "dbo.tcdsb_LTO_PageCandidate_Select";
                case "UnSelected":           return "dbo.tcdsb_LTO_PageCandidate_Select";
                default:                    return action;
            }
        }

         private string GetParameters(string action)
        {
            switch (action)
            {

                case "Deadline": return "@SchoolYear, @PublishDate, @PositionType";
                case "DefaultDate": return "@SchoolYear, @DatePublish, @PositionType";
                case "Selected": return "@SchoolYear, @SchoolCode, @PositionID";
                case "UnSelected": return "@UserID, @SchoolYear, @PositionID";

                default: return "";

            }
        }
    }
}
