using ClassLibrary;
using DataAccess;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public class HelpText
    {
        private static string sp = "dbo.EPA_sys_HelpTextContent";
        public HelpText() { }
        public static string GetHelpContent(string operate, string userID, string categoryID, string areaID, string itemCode)
        {
            try
            {
                List2Item parameter = new List2Item { Operate = operate   };
                return GeneralDataAccess.TextValue(sp, parameter);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return "";
            }

        }
        public static string GetHelpContent(string operate, string userID, string categoryID, string areaID, string itemCode, string value)
        {
            try
            {
                sp += ",@Value";
                List2Item parameter = new List2Item { Operate = operate  };
                return GeneralDataAccess.TextValue(sp, parameter);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return "";
            }

        }
    }
}
