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
        public static List<T> DataList(string spName, string action, object para)
        {
            switch (action)
            {
                 case "DefaultDate": return PublishPositionDefaultDate(para);
                default:
                    break;
            }
            return null;
        }
        public static T DataValue(string spName, string action, object para)
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
                   StartDate = new DateTime(2021, 9, 3),
                   EndDate=  new DateTime(2022, 6, 30),
                   DatePublish =  DateTime.Today, 
                   DateApplyOpen = new DateTime(2022, 3, 21),
                   DateApplyClose = new DateTime(2022, 3, 23),
               }
           };

            return position.OfType<T>().ToList();
        }
    }
}
