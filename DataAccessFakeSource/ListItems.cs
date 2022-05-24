using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFake
{
    public class ListItems<T>
    {
        public static List<T> ListData(string spName, string action)
        {
            switch (action)
            {
                case "PostingCycle": return PostingCycleList();
                case "Area": return AreaList();
                case "PostingState": return PostingStateList();
                case "RequestState": return RequestStateList();
                case "School": return SchoolList();
                case "PositionLevel": return PositionLevelList();
                case "FTEList": return FTEList();
                case "SchoolYear": return SchoolYear();
                case "ApplicationType": return ApplicationType();
                default:
                    break;
            }
            return null;
        }
        public static T ValueData(string spName, string action)
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
        private static List<T> PostingCycleList()
        {

            var lists = new List<NameValueList>()
            {
                new NameValueList() { Name = "Round 1", Value = "1" },
                new NameValueList() { Name = "Round 2", Value = "2" },
                new NameValueList() { Name = "Round 3", Value = "3" },
                new NameValueList() { Name = "Round 4", Value = "4" }
            };

            return lists.Cast<T>().ToList();
        }
        private static List<T> AreaList()
        {
            var list = new List<NameValueList>()
            {   new NameValueList() {Name="Area 01", Value ="Area 01" },
                new NameValueList() {Name="Area 02", Value ="Area 02" },
                new NameValueList() {Name="Area 03", Value ="Area 03" },
                new NameValueList() {Name="Area 04", Value ="Area 04" },
                new NameValueList() {Name="Area 05", Value ="Area 05" }
           };
            return list.OfType<T>().ToList(); ;
        }
        private static List<T> PostingStateList()
        {
            var list = new List<NameValueList>()
            {   new NameValueList() {Name="Cancel Posting", Value ="Cancel Posting" },
                new NameValueList() {Name="New Posting", Value ="New Posting" },
                new NameValueList() {Name="Re Posting", Value ="Re Posting" },
                new NameValueList() {Name="Recommend", Value ="Recommend" },
                new NameValueList() {Name="Revoke", Value ="Revoke" },
                new NameValueList() {Name="Hired", Value ="Hired" }

           };
            return list.OfType<T>().ToList(); ;
        }
        private static List<T> RequestStateList()
        {
            var list = new List<NameValueList>()
            {   new NameValueList() {Name="Posted", Value ="Posted" },
                new NameValueList() {Name="Initial", Value ="Initial" },
                new NameValueList() {Name="Pending", Value ="Pending" },
                new NameValueList() {Name="Reject", Value ="Reject" }
           };
            return list.OfType<T>().ToList(); ;
        }
        private static List<T> SchoolList()
        {
            var list = new List<NameValueList>()
            {   new NameValueList() {Name="Annunciation", Value ="0299" },
                new NameValueList() {Name="Mary Ward Catholic Secondary School", Value ="0544" },
                new NameValueList() {Name="St. Paul Catholic School", Value ="0204" }
           };
            return list.OfType<T>().ToList(); ;
        }
        private static List<T> PositionLevelList()
        {
            var list = new List<NameValueList>()
            {   AddItem("BC001E","Primary and Junior"),
                AddItem("BC002E","Junior and Intermediate"),
                AddItem("BC003E", "Intermediate and Senior"),
                AddItem("BC011E", "Primary"),
                AddItem("BC012E", "Junior"),
                AddItem("BC013E", "Intermediate"),
                AddItem("BC708E", "Primary, Junior & Intermediate")
            };
            return list.OfType<T>().ToList(); ;
        }
        private static List<T> FTEList()
        {
            var list = new List<NameValueList>()
            {   AddItem("30","30%"),
                AddItem("50","50%"),
                 AddItem("75", "75%"),
                AddItem("100","100%")
           };
            return list.OfType<T>().ToList(); ;
        }
        private static List<T> SchoolYear()
        {
            var list = new List<NameValueList>()
            {  AddItem("20202021", "20202021" ),
                AddItem("20212022","20212022" ),
                AddItem("20192020", "20192020")
           };
            return list.OfType<T>().ToList(); ;
        }


        private static List<T> ApplicationType()
        {
            var list = new List<NameValueList>()
            {
                AddItem("LTO","Long Term Occouational"),
                AddItem("POP","Permanent Open Position"),
                AddItem("LTC","Long Term Contract"),
           };
            return list.OfType<T>().ToList(); ;
        }
        private static NameValueList AddItem(string value, string name)
        {
            return new NameValueList() { Name = name, Value = value };
        }

    }
}
