using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFake
{
    public class RequestPosting
    {
        public static List<T> ListData<T>(string spName, string action, object para)
        {
            switch (action)
            {
                case "Position": return RequestPositionbyByID<T>(para);
                case "Positions": return RequestPostingPositions<T>(para);
                case "DefaultDate": return PublishPositionDefaultDate<T>(para);
                default:
                    break;
            }
            return null;
        }
        public static T ValueData<T>(string spName, string action, object para)
        {
            switch (action)
            {
                case "PostingCycle": return (T)new object();
                case "Deadline": return (T)new object();
                case "PublishDate": return (T)new object();
                default:
                    return CommonActions.ActionResult<T>(action);
            }
        }

        private static List<T> RequestPostingPositions<T>(object para)
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
        private static List<T> RequestPositionbyByID<T>(object para)
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
        private static List<T> PublishPositionDefaultDate<T>(object para)
        {
            var position = new List<LTODefalutDate>()
           { new LTODefalutDate()
               {
                   StartDate = DateFC.YMD( new DateTime(2021, 9, 3)),
                   EndDate=   DateFC.YMD( new DateTime(2022, 6, 30)),
                   DatePublish =  DateFC.YMD(  DateTime.Today), 
                   DateApplyOpen =  DateFC.YMD( new DateTime(2022, 3, 21)),
                   DateApplyClose =  DateFC.YMD( new DateTime(2022, 3, 23)),
               }
           };

            return position.OfType<T>().ToList(); 
        }
    }
}
