using System;
using System.Collections.Generic;
using System.Text; 

namespace DataAccess
{
    public class DBConnection
    {
        public static string DBSource
        {
            get { return "SQL"; }
        }
        public static string CurrentDB
        {
            get { return getNamebyKey("CurrentDB"); }
        }
        public static string TestDB
        {
            get { return getNamebyKey("Test"); }
        }
        public static string LiveDB
        {
            get { return getNamebyKey("Live"); }
        }
        public static string ConnectionSTR(string name)
        {
            return getNamebyKey(name);
        }
        public static string APIUrl()
        {
            return getNamebyKey("APIUrl");
        }
        public static string AuthMethod()
        {
            return getNamebyKey("LDAP");
        }
        private static string getNamebyKey(string name)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[name].ToString(); 
            // WebConfigurationManager.ConnectionStrings[name].ToString(); 

        }
    }
}
