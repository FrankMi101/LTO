using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFake
{
    public  class CommonActions
    {
        public static T ActionResult<T>(string action)
        {
            string Actions = "Delete, Add, Update,New";

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
                return (T)Convert.ChangeType("Successfully", typeof(T));
            }
            else
                return (T)Convert.ChangeType("Successfully", typeof(T));

        }
    }
}
