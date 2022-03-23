using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFake
{
    public class PublishPosting<T>
    {
        public static List<T> DataList(string spName, string action, object para)
        {
            switch (action)
            {
                case "School": return PublishPositionbySchool(para);
                case "GetbyID": return PublishPositionbyByID(para);
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
                case "Deadline":
                    var pDate = GetValueFromObj.Value("PublishDate", para);
                    if (pDate == "2022/03/06")
                        return (T)Convert.ChangeType("Invalid Date", typeof(T));
                    return  (T)Convert.ChangeType("2021/03/09", typeof(T));
                    break;
                default:
                    break;
            }
            return (T)new object();
        }

        private static List<T> PublishPositionbySchool(object para)
        {
            var position = new List<PositionPublish>()
           { new PositionPublish()
               {
                   PositionID = 1,
                   PositionTitle="New Posting from Test",
                   SchoolYear = GetValueFromObj.Value("SchoolYear", para),
                   SchoolCode = GetValueFromObj.Value("SearchValue1",para),
                   PositionType = GetValueFromObj.Value("PositionType",para),
                   Comments ="Unit Test for get Published position"
               } 
           };
 
            return position.OfType<T>().ToList();  
        }
        private static List<T> PublishPositionbyByID(object para)
        {
            var position = new List<PositionPublish>()
           { new PositionPublish()
               {
                   PositionID =  int.Parse(  GetValueFromObj.Value("PositionID", para)),
                   PositionTitle="New Posting from Test",
                   SchoolYear = GetValueFromObj.Value("SchoolYear", para),
                   SchoolCode = GetValueFromObj.Value("SearchValue1",para),
                   PositionType = GetValueFromObj.Value("PositionType",para),
                   PositionLevel = GetValueFromObj.Value("PositionLevel", para),
                   PostingNumber = "2022-0000",
                   Comments ="Unit Test for get Published position"
               }
           };

            return position.OfType<T>().ToList();
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
