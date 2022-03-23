using ClassLibrary;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataAccess
{
   public class JsonFileReader
    {

        public static string JsonString(string jsonFile)
        {
            try
            {
                using (StreamReader sr = new StreamReader(jsonFile))  // Server.MapPath("~/test.json")))
                {
                    string jsonString = sr.ReadToEnd();
                    return jsonString;
                }
            }
            catch (System.Exception ex)
            {
                var em = ex.Message;
                return "";
            }
            finally
            { }
        }
        public static string GetSubject(string jsonFile, string pType, string action)
        {
            try
            {
                var jsonString = JsonString(jsonFile);
                var result = JsonConvert.DeserializeObject<EmailTemplate>(jsonString);

                var myList = pType == "POP" ? result.Pop : result.Lto;

                var subject = myList.FirstOrDefault(s => s.Action == action).Subject;//  .Where(s => s.Action == action).Select(s => s.Subject).FirstOrDefault();
                return subject;

            }
            catch (System.Exception ex)
            {
                var em = ex.Message;
                return "";
            }
            finally
            { }


        }
        public static string GetSubjectOld(string jsonFile, string pType, string action)
        {
            try
            {
                var jsonString = JsonString(jsonFile);
                var result = JsonConvert.DeserializeObject<EmailTemplate>(jsonString);

                List<EmailTemplateItem> myList;
                myList = pType == "POP" ? result.Pop : result.Lto;

                foreach (var item in myList)
                {
                    if (item.Action == action)
                        return item.Subject;
                }

                return "No Subject";


            }
            catch (System.Exception ex)
            {
                var em = ex.Message;
                return "";
            }
            finally
            { }


        }
        public static string GetTemplate(string jsonFile, string pType, string action)
        {
            try
            {
                return GetSubjectAndTemplate(jsonFile, pType, action).Template;
            }
            catch (System.Exception ex)
            {
                var em = ex.Message;
                return "";
            }
            finally
            { }


        }
        public static EmailTemplateItem GetSubjectAndTemplate(string jsonFile, string pType, string action)
        {
            try
            {
                var jsonString = JsonString(jsonFile);
                var result = JsonConvert.DeserializeObject<EmailTemplate>(jsonString);
                var myList = pType == "POP" ? result.Pop : result.Lto;
                return myList.FirstOrDefault(l => l.Action == action);// .Where(l => l.Action == action).FirstOrDefault();

            }
            catch (System.Exception ex)
            {
                var em = ex.Message;
                return null;
            }
        }
        public static EmailTemplateItem GetSubjectAndTemplate(TextReader jsonFile, string pType, string action)
        {
            try
            {
                var jsonString =  jsonFile.ToString();
                var result = JsonConvert.DeserializeObject<EmailTemplate>(jsonString);
                var myList = pType == "POP" ? result.Pop : result.Lto;
                return myList.FirstOrDefault(l => l.Action == action);// .Where(l => l.Action == action).FirstOrDefault();

            }
            catch (System.Exception ex)
            {
                var em = ex.Message;
                return null;
            }


        }
        public static EmailTemplateItem GetSubjectAndTemplateOld(string jsonFile, string pType, string action)
        {
            try
            {
                var jsonString = JsonString(jsonFile);
                var result = JsonConvert.DeserializeObject<EmailTemplate>(jsonString);
                List<EmailTemplateItem> myList;
                myList = pType == "POP" ? result.Pop : result.Lto;


                foreach (var item in myList)
                {
                    if (item.Action == action)
                    {
                        return item;
                    }
                }
                return null;


            }
            catch (System.Exception ex)
            {
                var em = ex.Message;
                return null;
            }


        }
        public static List<NameValueList> GetNvList(string jsonFile, string valueType)
        {
            var jsonString = JsonString(jsonFile);
            var result = JsonConvert.DeserializeObject<NvLists>(jsonString);
            //  var result = JsonConvert.DeserializeObject<dynamic>(jsonString);

            switch (valueType)
            {
                case "Area":
                    return result.SchoolArea;

                case "PostingCycle":
                    return result.RoundCycle;

                case "Panel":
                    return result.Panel;

                case "PostingState":
                    return result.PostingState;

                case "SearchByShort":
                    return result.SearchByShort;

                default:
                    return result.SearchBy;
            }
        }
        public static List<NameValueList> GetNvList(string jsonFile, string valueType, NvLists obj)
        {
            var jsonString = JsonString(jsonFile);
            var result = JsonConvert.DeserializeObject<dynamic>(jsonString);
            return result.obj;
        }

        public static Contact CurrentOwner(string jsonFile, string userId)
        {
            try
            {
                var jsonString = JsonString(jsonFile);
                var result = JsonConvert.DeserializeObject<Contacts>(jsonString);
                List<Contact> myList = result.ContactStaffs;

                return myList.FirstOrDefault(l => l.Userid == userId); 
            }
            catch (System.Exception ex)
            {
                var em = ex.Message;
                return null;
            }
        }

        public static string DataAccessSp(string jsonFile, string pType, string action)
        {
            try
            {
                var jsonString = JsonString(jsonFile);
                var result = JsonConvert.DeserializeObject<DataSourceItemList>(jsonString);


               var myList = GetSpList(pType, result);

               var sp =  myList.FirstOrDefault(l => l.Action == action);
               return sp.ObjName + sp.Parameters;

                //foreach (var item in myList)
                //{
                //    if (item.Action == action)
                //    {
                //        return item.ObjName + item.Parameters;
                //    }
                //}

                //return "";


            }
            catch (System.Exception ex)
            {
                var em = ex.Message;
                return "";
            }


        }

        private static List<DataSourceItem> GetSpList(string pType, DataSourceItemList result)
        {
          
            

            switch (pType)
            {
                case "General":
                    return result.General;
                case "Request":
                    return result.Request;
                case "Approve":
                    return result.Approve;
                case "Publish":
                    return result.Publish;
                case "Candidate":
                    return result.SelectCandidate;
                case "Hiring":
                    return result.Hiring;
                case "Hired":
                    return result.Hired;
                case "Interview":
                    return result.Interview;
                case "Apply":
                    return result.Apply;
                default:
                    return result.General;
            }

        }

        public static DataSourceItemList GetSP_fromItemList(string jsonFile, string pType, string action)
        {
            try
            {
                var jsonString = JsonString(jsonFile);
                var result = JsonConvert.DeserializeObject<DataSourceItemList>(jsonString);
                return result;

            }
            catch (System.Exception ex)
            {
                var em = ex.Message;
                return null;
            }

        }
        public static DataSourcePageList GetSP_fromPageList(string jsonFile, string pType, string action)
        {
            try
            {
                var jsonString = JsonString(jsonFile);
                //  var result = JsonConvert.DeserializeObject<SPName1>(jsonString);
                var result = JsonConvert.DeserializeObject<DataSourcePageList>(jsonString);

                return result;

            }
            catch (System.Exception ex)
            {
                var em = ex.Message;
                return null;
            }

        }

    }

}

public class JsonFileReader<T>
{
    private static string JsonString(string jsonFile)
    {
        try
        {
            using (StreamReader sr = new StreamReader(jsonFile))  // Server.MapPath("~/test.json")))
            {
                string jsonString = sr.ReadToEnd();
                return jsonString;
            }
        }
        catch (System.Exception ex)
        {
            var em = ex.Message;
            return "";
        }
        finally
        { }
    }

    public static T GetSP_fromList(string jsonFile)
    {
        var jsonString = JsonString(jsonFile);
        try
        {
            var result = JsonConvert.DeserializeObject<T>(jsonString);
            return result;
        }
        catch (System.Exception ex)
        {
            var em = ex.Message;
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

    }
    public static T GetSP_fromList(string jsonFile, string pType, string action)
    {
        var jsonString = JsonString(jsonFile);
        try
        {
            //  var result = JsonConvert.DeserializeObject<SPName1>(jsonString);
            var result = JsonConvert.DeserializeObject<T>(jsonString);

            return result;

        }
        catch (System.Exception ex)
        {
            var em = ex.Message;
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

    }
}

//public class NvListItem
//{
//    public string Name { get; set; }
//    public string Value { get; set; }
//}

public class NvLists
{
    public List<NameValueList> SearchBy { get; set; }
    public List<NameValueList> SearchByShort { get; set; }
    public List<NameValueList> SchoolArea { get; set; }
    public List<NameValueList> RoundCycle { get; set; }
    public List<NameValueList> PostingState { get; set; }
    public List<NameValueList> Panel { get; set; }
}
public class EmailTemplate
{
    public List<EmailTemplateItem> Lto { get; set; }
    public List<EmailTemplateItem> Pop { get; set; }

}
public class EmailTemplateItem
{
    public string Action { get; set; }
    public string Subject { get; set; }
    public string Template { get; set; }
}

public class Contacts
{
    public List<Contact> ContactStaffs { get; set; }
}
public class Contact
{
    public string Userid { get; set; }
    public string Extention { get; set; }
    public string Email { get; set; }
}



public class DataSourceItem
{
    public string Source { get; set; }
    public string Action { get; set; }
    public string ObjName { get; set; }
    public string Parameters { get; set; }

}
public class DataSourcePage
{
    public string Page { get; set; }
    public DataSourceItem[] SourceList { get; set; }
}

public class DataSourcePageList
{
    public List<DataSourcePage> DataAccessSource { get; set; }
}

public class DataSourceItemList
{
    public List<DataSourceItem> General { get; set; }
    public List<DataSourceItem> Request { get; set; }
    public List<DataSourceItem> Approve { get; set; }
    public List<DataSourceItem> Publish { get; set; }
    public List<DataSourceItem> SelectCandidate { get; set; }
    public List<DataSourceItem> Interview { get; set; }
    public List<DataSourceItem> Hiring { get; set; }
    public List<DataSourceItem> Hired { get; set; }
    public List<DataSourceItem> Apply { get; set; }
    public List<DataSourceItem> MultipleSchools { get; set; }
    public List<DataSourceItem> ConfirmHire { get; set; }
    public List<DataSourceItem> Staff { get; set; }
    public List<DataSourceItem> Summary { get; set; }

}