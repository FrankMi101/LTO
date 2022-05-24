using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataSourceMap
    {
        private static readonly string _dbSource = "SQL";

        public static IDataOperateService DBSource()
        {
            return DBSource(_dbSource);
        }
        public static IDataOperateService DBSource(string dbSource)
        {
            switch (dbSource)
            {
                case "SQL":
                    return new DataOperateServiceSQL();
                case "Fake":
                    return new DataOperateServiceFake();
                default:
                    return new DataOperateServiceSQL();
            }

        }
    }
    public class DataSourceMapAsync
    {
        private static readonly string _dbSource = "SQL";

        public static IDataOperateServiceAsync DBSource()
        {
            return DBSource(_dbSource);
        }
        public static IDataOperateServiceAsync DBSource(string dbSource)
        {
            switch (dbSource)
            {
                case "SQL":
                    return new DataOperateServiceAsyncSQL(); 
                default:
                    return new DataOperateServiceAsyncSQL();
            }

        }
    }
    public class DataSourceMap<T>
    {
        private static readonly string _dbSource = "SQL";

        public static IDataOperateService<T> DBSource()
        {
            return DBSource(_dbSource);
        }
        public static IDataOperateService<T> DBSource(string dbSource)
        {
            switch (dbSource)
            {            
                case "SQL":
                    return new DataOperateServiceSQL<T>();
                case "API":
                    return new DataOperateServiceAPI<T>();
                case "CSV":
                    return new DataOperateServiceCSV<T>();
                case "Fake":
                    return new DataOperateServiceFake<T>();
                default:
                    return new DataOperateServiceSQL<T>();
            }

        }
    }

    
}
