
using DataAccess.Repository;
using System.Collections.Generic;
using System.Linq;
namespace DataAccess
{
    public class CommonExcute1
    {
        public static string SPNameAndParameters(string page, string action)
        {
            try
            {
                return GetSpNameInClass(page, action);

            }
            catch (System.Exception ex)
            {
               // var em = ex.Message;
                return "";
            }
        }
        public static string SPNameAndParameters(string JsonFile, string page, string action)
        {
            try
            {
                if (JsonFile == "")
                {
                    return SPNameAndParameters(page, action);
                }
                else
                {
                    return GetSPandPara_FromItemList(JsonFile, page, action);  // for DataAccess.json
                                                                               //    return GetSPandPara_FromPageList(JsonFile, page, action); // for DataAccessSP.json 
                                                                               // Does not work                                                                             //  DataSourceItem myitem = GetItemList("PageList", JsonFile, page, actio// DataSourceItem myitem = GetItemList("ItemList", JsonFile, page, action)// return myitem.objName + myitem.parameters;
                }
            }
            catch (System.Exception ex)
            {
               // var em = ex.Message;
                return "";
            }
        }

        private static string GetSpNameInClass(string page, string action)
        {
            IPostingBase posting = PostingObj(page);
            return posting.SpName(action, false);

        }
        private static IPostingBase PostingObj(string page)
        {
            switch (page)
            {
                case "Applying": return new ApplyPosting();

                case "Approve": return new ApproveRequest();
                case "Candidate": return new SelectCandidate();
                case "Hiring": return new ConfirmHire();
                case "Hired": return new HiredPositions();
                case "Interview": return new InterviewResults();
                case "MultipleSchools": return new GeneralItems();
                case "Publish": return new PublishPosting();
                case "Request": return new RequestPosting();
                case "Staff": return new StaffManage();
                case "Summary": return new PostingSummary();
                default: return new ApplyPosting(); ;
            }
        }
        public static DataSourceItemList SPandPara(string JsonFile, string page, string action)
        {
            return JsonFileReader.GetSP_fromItemList(JsonFile, page, action);
        }
        public static DataSourcePageList SPandPara_fromPageList(string JsonFile, string page, string action)
        {
            return JsonFileReader.GetSP_fromPageList(JsonFile, page, action);

        }

        public static string GetSPandPara_FromItemList(string page, string action)
        {
            string jsonFile = SPSource.SPFile;
            return CommonExcute1.GetSPandPara_FromItemList(jsonFile, page, action);
        }

        public static string GetSPandPara_FromItemList(string JsonFile, string page, string action)
        {
            DataSourceItemList myspname = JsonFileReader<DataSourceItemList>.GetSP_fromList(JsonFile, page, action); // SPandPara(JsonFile, page, action);
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

        private static string GetSPandPara_FromPageList(string JsonFile, string page, string action)
        {
            DataSourcePageList myspname = JsonFileReader<DataSourcePageList>.GetSP_fromList(JsonFile, page, action);

            var mylist = from p in myspname.DataAccessSource
                         where p.Page == page
                         select p.SourceList;

            var myNewListOne = mylist.FirstOrDefault();

            //  var result = JsonConvert.DeserializeObject<SPName>(myNewListOneStr);

            var mylistOne = from s in myNewListOne
                            where s.Action == action
                            select s.ObjName.ToString() + s.Parameters.ToString();

            return mylistOne.FirstOrDefault();
        }

        public static DataSourceItem GetItemList(string JsonType, string JsonFile, string page, string action)
        {
            try
            {
                if (JsonType == "PageList")
                {
                    DataSourcePageList myspname = JsonFileReader<DataSourcePageList>.GetSP_fromList(JsonFile, page, action);

                    //  DataSourceItemList myNewListOne = new DataSourceItemList();
                    var mylistPage = from p in myspname.DataAccessSource
                                     where p.Page == page
                                     select p.SourceList.FirstOrDefault();


                    var mylistItem = from s in mylistPage
                                     where s.Action == action
                                     select s;

                    return mylistItem.FirstOrDefault();

                }
                else
                {
                    return JsonFileReader<DataSourceItemList>.GetSP_fromList(JsonFile, page, action).General.FirstOrDefault();
                }
            }

            catch (System.Exception ex)
            {
               // var em = ex.Message;
                return null;
            }

        }

    }


    public class CommonExcute1<T>
    {
        private static   string _db = "";
         private static  IDataOperateService<T> _dataOperate;

        public CommonExcute1()
        {
            _db = DBConnection.CurrentDB;
            _dataOperate = DataSourceMap<T>.DBSource();
        }

        public static T ObjectOfT(string SP, object parameter)
        {
            try
            {
               // return _dataOperate.ObjectOfT(_db, SP, parameter);

              return MyDapper.EasyDataAccess<T>.ListOfT(SP, parameter)[0];
            }
            catch (System.Exception ex)
            {
               // var em = ex.Message;
                throw ex;
            }
        }
        public static List<T> GeneralList(string SP, object parameter)
        {
            try
            {
               // return _dataOperate.ListOfT(_db, SP, parameter);
                return MyDapper.EasyDataAccess<T>.ListOfT(SP, parameter);

            }
            catch (System.Exception ex)
            {
                var em = ex.Message;
                throw ex;
            }
        }


        public static string GeneralValue(string SP, T parameter)
        {
            try
            {
             //   return _dataOperate.ValueString(_db, SP, parameter);
                return MyDapper.EasyDataAccess<string>.ValueOfT(SP, parameter);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public static string GeneralValue(string SP, object parameter)
        {
            try
            {
              //  return _dataOperate.ValueString(_db, SP, parameter);
               return MyDapper.EasyDataAccess<string>.ValueOfT(SP, parameter);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static string ProfileValue(object parameter)
        {
             string SP = CommonExcute1.SPNameAndParameters("", "General", "Profile");
           // return _dataOperate.ValueString(_db, SP, parameter);
          return MyDapper.EasyDataAccess<string>.ValueOfT(SP, parameter);

            //var myval = new CommonOperation<T>();
            //return myval.GeneralValue(SP, parameter);
        }
        public static T GeneralValueOfT(string SP, object parameter)
        {
            try
            {
            //    return _dataOperate.ValueOfT(_db, SP, parameter);
 
               return MyDapper.EasyDataAccess<T>.ValueOfT(SP, parameter);

             //   var myval = new CommonOperation<T>(); 
             //   return myval.GeneralValueOfT(SP, parameter);

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public static List<T> GeneralList(string cPage, string action, object parameter)
        {
            try
            {
                var SPFile = SPSource.SPFile;
                var SP = CommonExcute1.SPNameAndParameters(SPFile, cPage, action);
              //  return _dataOperate.ListOfT(_db, SP, parameter);

               return GeneralList(SP, parameter);  

            //    var mylist = new CommonList<T>();
           //     return mylist.GeneralListOfT(SP, parameter);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public static string GeneralValue(string cPage, string action, T parameter)
        {
            var SPFile = SPSource.SPFile;
            var SP = CommonExcute1.SPNameAndParameters(SPFile, cPage, action);
         //   return _dataOperate.ValueString(_db, SP, parameter);

            return GeneralValue(SP, parameter);
           //  var myval = new CommonOperation<T>();
           //return myval.GeneralValue(SP, parameter);
        }
    }
}
