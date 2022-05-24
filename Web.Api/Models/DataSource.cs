using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Api.Models
{
   
    public class DataSource
    {
        private readonly static string _dataSource = "Database";
        private readonly static string _dbType = "SQL";
        private readonly static string _spType = "_dbSP";
        private readonly static string _currentDb = DBConnection.CurrentDB;
        public static string Type()
        {
            return _dbType;
        }
        public static string dbSP()
        {
            return _spType;
        }
        public static string Source()
        {
            return _dataSource;
        }
        public static string currentDB()
        {
            return _currentDb;
        }
    }
}