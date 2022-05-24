using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFake
{

    public class EasyDataAccess<T>
    {

        public static List<T> ListOfT(string type, string spName, object para)
        {
            string action = GetAction(para);

            string typeT = typeof(T).Name;
            switch (typeT)
            {
                case "NameValueList": return ListItems<T>.ListData(spName, action);
                case "PositionPublish": return PublishPosting<T>.ListData(spName, action, para);
                case "RequestPosting": return RequestPosting.ListData<T>(spName, action, para);
                case "LTODefalutDate": return DefaultDate<T>.ListData(spName, action, para);
                default:
                    return ListItems<T>.ListData(spName, action);
            }
        }

        public static T ValueOfT(string type, string spName, object para)
        {
            string action = GetAction(para);
            string typeT = GetTypebySpName(spName);
            switch (typeT)
            {
                case "NameValueList": return ListItems<T>.ValueData(spName, action);
                case "PositionPublish": return PublishPosting<T>.ValueData(spName, action, para);
                case "RequestPosting": return RequestPosting.ValueData<T>(spName, action, para);
                 default:
                    return ListItems<T>.ValueData(spName, action);
            }
        }

        private static string GetAction(object para)
        {
            string searchby = GetValueFromObj.Value("Searchby", para);
            if (searchby != "") return searchby;

            return GetValueFromObj.Value("Operate", para);
        }
        private static string GetTypebySpName(string spName)
        {
             if (spName.Contains("PageGeneral")) return "NameValueList";
            if (spName.Contains("PagePublish")) return "PositionPublish";
            if (spName.Contains("PageRequest")) return "RequestPosting";
            return "";
        }
    }
}

