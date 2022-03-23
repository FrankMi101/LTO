using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using DataAccess;

namespace AppOperate.ExecuteDelegate
{
   public class DataProcessDelegate<T>
    {
        public DataProcessDelegate()
        {
                
        }
        //private delegate List<T> DelegateClassFunc( string sp, object value3);
        //private static List<T> GetListHelper(DelegateClassFunc delegateFunc, string sp,  object value3)
        //{
        //    return delegateFunc(sp, value3);

        //}

        public static List<T> ListOfT(string page, string action, object parameter)
        {
            var sp = CommonExcute.SPNameAndParameters(page, action);


            //return (List) PublishPositionExe.Position(parameter);
             return  GeneralDelegate<T>.RunningTDelegateList(CommonExcute<T>.GeneralList, sp, parameter);

          //  return GeneralDelegate<PositionPublish>.RuningTDelegateList(PublishPositionExe<PositionPublish>.Position, sp, parameter);



        }

        public static string  ValueOfT(string page, string action, object parameter)
        {
            var sp = CommonExcute.SPNameAndParameters(page, action);
            return GeneralDelegate<string>.RunningTDelegate(CommonExcute<string>.GeneralValue, sp, parameter);
        }
        public static int IntValueOfT(string page, string action, object parameter)
        {
            var sp = CommonExcute.SPNameAndParameters(page, action);
            return GeneralDelegate<int>.RunningTDelegate(CommonExcute<int>.GeneralValueOfT, sp, parameter);
        }
    }
}
