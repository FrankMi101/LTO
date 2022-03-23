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
                case "NameValueList": return ListItems<T>.DataList(spName, action);
                case "PositionPublish": return PublishPosting<T>.DataList(spName, action, para);
                case "LTODefalutDate": return DefaultDate<T>.DataList(spName, action, para);
                default:
                    return ListItems<T>.DataList(spName, action);
            }
        }

        public static T ValueOfT(string type, string spName, object para)
        {
            string action = GetAction(para);
            string Actions = "Delete, Add, Update,New,";

            if (action == "New")
            {
                return (T)Convert.ChangeType(0, typeof(T));
            }
            else if (action == "RePosting")
            {
                return (T)Convert.ChangeType(0, typeof(T));
            }
            else if (Actions.Contains(action))
            {
                if (typeof(T) == typeof(string)) return (T)Convert.ChangeType("Successfully", typeof(T));
                if (typeof(T) == typeof(int)) return (T)Convert.ChangeType(0, typeof(T));
                if (typeof(T) == typeof(bool)) return (T)Convert.ChangeType(false, typeof(T));
                if (typeof(T) == typeof(DateTime)) return (T)Convert.ChangeType(DateTime.Now, typeof(T));
            }
            else
            {
                switch (action)
                {
                    case "Deadline": return PublishPosting<T>.DataValue(spName, action, para);
                     default:
                        return (T)Convert.ChangeType("Successfully", typeof(T)); 
                }

            }
            return default(T);

        }

        private static string GetAction(object para)
        {
            string searchby = GetValueFromObj.Value("Searchby", para);
            if (searchby != "") return searchby;

            return GetValueFromObj.Value("Operate", para);
        }
    }
}

