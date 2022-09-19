using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFake
{
    public class DefaultDate<T>
    {
        public static List<T> ListData(string spName, string action, object para)
        {
            switch (action)
            {
                 case "DefaultDate": return PublishPositionDefaultDate(para);
                default:
                    break;
            }
            return null;
        }
        public static T ValueData(string spName, string action, object para)
        {
            switch (action)
            {
                case "PostingCycle": return (T)new object();
                case "Deadline":     return  (T)Convert.ChangeType("2021/03/09", typeof(T)); ;
                default:
                    break;
            }
            return (T)new object();
        }
 
        private static List<T> PublishPositionDefaultDate(object para)
        {
            var position = new List<LTODefalutDate>()
           { new LTODefalutDate()
               {
                   StartDate =  DateFC.YMD( new DateTime(2021, 9, 3)),
                   EndDate=   DateFC.YMD( new DateTime(2022, 6, 30)),
                   DatePublish =   DateFC.YMD( DateTime.Today), 
                   DateApplyOpen =  DateFC.YMD( new DateTime(2022, 3, 21)),
                   DateApplyClose = DateFC.YMD(  new DateTime(2022, 3, 23)),
               }
           };

            return position.OfType<T>().ToList();
        }
    }
}
