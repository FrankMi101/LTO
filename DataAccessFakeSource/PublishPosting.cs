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
        public static List<T> ListData(string spName, string action, object para)
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
        public static T ValueData(string spName, string action, object para)
        {
            switch (action)
            {
                case "PostingCycle": return (T)new object();
                case "Deadline": return PublishDeadline<T>(para);
                case "PublishDate": return PublishDate<T>(para);
                case "PostingDate": return PublishDate<T>(para);
                default:
                    return CommonActions.ActionResult<T>(action);
            }
            
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
            var dDate = new List<LTODefalutDate>()
           { new LTODefalutDate()
               {
                   StartDate = new DateTime(2021, 9, 3),
                   EndDate=  new DateTime(2022, 6, 30),
                   DatePublish =  DateTime.Today,
                   DateApplyOpen = new DateTime(2022, 3, 21),
                   DateApplyClose = new DateTime(2022, 3, 23),
               }
           };

            var rList = dDate.OfType<T>().ToList();
            return rList;
        }
        private static T PublishDeadline<T>(object para)
        {
            var rVal = "";
            var vDate = DateFC.YMD(GetValueFromObj.Value("PublishDate", para));
            vDate = vDate.AddDays(2);
            if (vDate.DayOfWeek == DayOfWeek.Saturday) vDate = vDate.AddDays(1); 

            if (vDate.DayOfWeek == DayOfWeek.Sunday) vDate = vDate.AddDays(1);

            vDate = DateFC.WorkDay(vDate);

            rVal = DateFC.YMD(vDate, "/");

            return (T)Convert.ChangeType(rVal, typeof(T));
        }

        private static T PublishDate<T>(object para)
        {
            var rVal = "";
            var vDate = DateFC.YMD(GetValueFromObj.Value("PublishDate", para));

            if (vDate.DayOfWeek == DayOfWeek.Saturday) rVal = "Invalid Date";
            else if (vDate.DayOfWeek == DayOfWeek.Sunday) rVal = "Invalid Date";
            else   rVal = DateFC.YMD(vDate, "/");

            return (T)Convert.ChangeType(rVal, typeof(T));
        }

    }
}
