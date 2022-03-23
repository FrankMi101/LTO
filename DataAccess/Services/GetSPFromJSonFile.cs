using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class GetSPFromJSonFile
    {
       
        public static string SPandParameter(string JsonFile, string page, string action)
        {
            DataSourceItemList myspname = JsonFileReader<DataSourceItemList>.GetSP_fromList(JsonFile, page, action); 
            var mylist = from p in myspname.General
                         where p.Action == action
                         select p.ObjName.ToString() + p.Parameters.ToString(); ;
            switch (page)
            {

                case "Request":
                    mylist = from p in myspname.Request
                             where p.Action == action
                             select p.ObjName.ToString() + p.Parameters.ToString();
                    break;
                case "Approve":
                    mylist = from p in myspname.Approve
                             where p.Action == action
                             select p.ObjName.ToString() + p.Parameters.ToString();
                    break;
                case "Publish":
                    mylist = from p in myspname.Publish
                             where p.Action == action
                             select p.ObjName.ToString() + p.Parameters.ToString();
                    break;
                case "Candidate":
                    mylist = from p in myspname.SelectCandidate
                             where p.Action == action
                             select p.ObjName.ToString() + p.Parameters.ToString();
                    break;
                case "Hiring":
                    mylist = from p in myspname.Hiring
                             where p.Action == action
                             select p.ObjName.ToString() + p.Parameters.ToString();
                    break;
                case "Hired":
                    mylist = from p in myspname.Hired
                             where p.Action == action
                             select p.ObjName.ToString() + p.Parameters.ToString();
                    break;
                case "Interview":
                    mylist = from p in myspname.Interview
                             where p.Action == action
                             select p.ObjName.ToString() + p.Parameters.ToString();
                    break;
                case "Applying":
                    mylist = from p in myspname.Apply
                             where p.Action == action
                             select p.ObjName.ToString() + p.Parameters.ToString();
                    break;
                case "MultipleSchools":
                    mylist = from p in myspname.MultipleSchools
                             where p.Action == action
                             select p.ObjName.ToString() + p.Parameters.ToString();
                    break;
                case "Staff":
                    mylist = from p in myspname.Staff
                             where p.Action == action
                             select p.ObjName.ToString() + p.Parameters.ToString();
                    break;
                case "Summary":
                    mylist = from p in myspname.Summary
                             where p.Action == action
                             select p.ObjName.ToString() + p.Parameters.ToString();
                    break;

                default:
                    mylist = from p in myspname.General
                             where p.Action == action
                             select p.ObjName.ToString() + p.Parameters.ToString();
                    break;
            }

            return mylist.FirstOrDefault();
        }
    }
}
