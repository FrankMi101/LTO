using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI
{
    public class APIAction<T> : IAPIAction<T>
    {
        private readonly IDataOperateService<T> _dataOperate = (IDataOperateService<T>)DataSourceMap<T>.DBSource("SQL");  

        public List<T> ListOfT(string apiType, string sp, object parameter)
        {   
            return _dataOperate.ListOfT(apiType, sp, parameter);
        }

        public string ValueOfT(string apiType, string sp, object parameter)
        {
            
            return _dataOperate.ValueString(apiType, sp, parameter);
          
        }
    }
}