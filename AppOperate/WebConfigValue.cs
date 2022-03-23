using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace AppOperate
{
    public class WebConfigValue
    {

        public static string getValuebyKey(string key)
        {
            return WebConfigurationManager.AppSettings[key];
        }
        public static string SPFile()
        {
            return getValuebyKey("SPFile");
        }
        public static string RunningModel()
        {
            return getValuebyKey("RunningModel");
        }
        public static string SchoolSystem()
        {
            return getValuebyKey("SchoolSystem");
        }
        public static string currentDatabase()
        {
            return getValuebyKey("currentDB");
        }
        public static string CurrentDB()
        {
            return WebConfigurationManager.ConnectionStrings["currentDB"].ConnectionString;
        }
        public static string LDAPServer()
        {
            return getValuebyKey("LDAP");
        }
        public static string Reportsource()
        {
            return getValuebyKey("Reportsource");
        }
        public static string ReportServer()
        {
            return getValuebyKey("ReportServer");
        }
        public static string ReportServices()
        {
            return getValuebyKey("ReportingService");
        }
        public static string ReportPath()
        {
            return getValuebyKey("ReportPath");
        }
        public static string ReportFormat()
        {
            return getValuebyKey("ReportFormat");
        }
        public static string ReportPath2(string vSES)
        {
            return getValuebyKey("ReportPath") + vSES;
        }
        public static string ReportPathWS()
        {
            return getValuebyKey("ReportPathWS");
        }
        public static string ReportUser()
        {
            return getValuebyKey("WebServiceUser");
        }
        public static string ReportPW()
        {
            return getValuebyKey("WebServiceWP");
        }
        public static string DomainName()
        {
            return getValuebyKey("NetWorkDomain");
        }
        public static string AppName()
        {
            return getValuebyKey("Application");
        }
        public static string AppNameS()
        {
            return getValuebyKey("ApplicationS");
        }
        public static string DefaultPage()
        {
            return getValuebyKey("defaultPage");
        }
 

        public static string eMailGo()
        {
            return getValuebyKey("eMailTry");
        }

        public static string MessageNotAllow()
        {
            return getValuebyKey("MessageNoPermission");
        }
        public static string MessageLogin()
        {
            return getValuebyKey("MessageLogin");
        }
        public static string MessageDB()
        {
            return getValuebyKey("MessageDB");
        }

        public static Contact HRContact(string JsonFile, string UserID )
        {
            return CurrentOwner.PositionOwner( JsonFile, UserID);
        }
        public static string Extension(string userID)
        {
            string rVal = "";
            switch (userID)
            {
                case "boreanf":
                    rVal = "Fiorella Borean  Ext. 2321";
                    break;
                case "frijiom":
                    rVal = "Mary Frijio Ext. 2730";
                    break;
                case "krasnor":
                    rVal = "Rosemarie Krasnovitch  Ext. 2370";
                    break;
                case "difonzm":
                    rVal = "Margherita Di Fonzo  Ext. 2322";
                    break;
                default:
                    rVal = "";
                    break;
            }
            return rVal;
        }


    }
}
