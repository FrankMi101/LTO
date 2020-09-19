using System.Collections.Generic;

namespace AppOperate.ExecuteDelegate
{
    public class GeneralDelegate
    {
   
        public delegate int IntDelegate1(string val1);
        public delegate int IntDelegateObj1(string val1,object obj1);
        public delegate string StringDelegate1(string val1);
        public delegate string StringDelegateObj1(object obj1);
        public delegate string StringDelegate2(string val1, string val2);
        public delegate string StringDelegate3(string val1, object obj1);
    

      
        public static string RuningDelegate(StringDelegate1 delegateFunc, string val1)
        {
            return delegateFunc(val1);

        }
        public static string RuningDelegate(StringDelegateObj1 delegateFunc, object obj1)
        {
            return delegateFunc(obj1);

        }
        public static string RuningDelegate(StringDelegate2 delegateFunc, string val1, string val2)
        {
            return delegateFunc(val1,val2);

        }
        public static string RuningDelegate(StringDelegate3 delegateFunc, string val1, object obj1)
        {
            return delegateFunc(val1, obj1);

        }

        
    }
    public class GeneralDelegate<T>
    {
        public delegate T Delegate1(string val1);
        public delegate T Delegate2(string val1,string val2);
        public delegate T DelegateObj1(object obj1);
        public delegate T DelegateObj2(string val1, object obj1);

        public delegate List<T> ListDelegate1(string val1);
        public delegate List<T> ListDelegateObj1(object obj1);
        public delegate List<T> ListDelegateObj2(string val1,object obj1);

        public static T RunningTDelegate(Delegate1 delegateFunc, string val1)
        {
            return delegateFunc(val1);

        }
        public static T RunningTDelegate(Delegate2 delegateFunc, string val1, string val2)
        {
            return delegateFunc(val1,val2);

        }
        public static T RunningTDelegate(DelegateObj1 delegateFunc, object obj1)
        {
            return delegateFunc(obj1);

        }
        public static T RunningTDelegate(DelegateObj2 delegateFunc, string val1, object obj1)
        {
            return delegateFunc(val1,obj1);

        }

        public static List<T> RunningTDelegateList(ListDelegate1 delegateFunc, string val1)
        {
            return delegateFunc(val1);

        }
        public static List<T> RunningTDelegateList(ListDelegateObj1 delegateFunc, object obj1)
        {
            return delegateFunc(obj1);

        }

        public static List<T> RunningTDelegateList(ListDelegateObj2 delegateFunc, string val1, object obj1)
        {
            return delegateFunc(val1,obj1);

        }
    }

}
