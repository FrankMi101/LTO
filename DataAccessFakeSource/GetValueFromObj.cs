using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFake
{
    public class GetValueFromObj
    {
        public static string Value(string key, object para)
        {
            return GetActionFromParameter(para, key);
        }
        private static string GetActionFromParameter(object obj, string action)
        {
            var myP = PropertiesOfType<string>(obj);
             return myP.FirstOrDefault(p => p.Key == action).Value;

            //foreach (var item in myP)
            //{
            //    if (item.Key == action) return item.Value;
            //};
            //return "";
        }
        private static string GetParameterStrFromParameterObj(object obj)
        {
            var myP = PropertiesOfType<string>(obj);
            int x = 0;
            var para = "";
            foreach (var item in myP)
            {
                if (item.Value != null)
                {
                    if (item.Key != "ObjType")
                    {
                        if (x == 0)
                            para = " @" + item.Key;
                        else
                            para = para + ",@" + item.Key;
                        x++;
                    }
                }
            };
            return para;
        }
        private static IEnumerable<KeyValuePair<string, T>> PropertiesOfType<T>(object obj)
        {
            return from p in obj.GetType().GetProperties()
                   where p.PropertyType == typeof(T)
                   select new KeyValuePair<string, T>(p.Name, (T)p.GetValue(obj));

        }

    }
}
