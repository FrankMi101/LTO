using System.Collections.Generic;
using System.Linq;
namespace AppOperate
{
    public class CommonExcute
    {
        public static string SPNameAndParameters(string page, string action)
        {
            try
            {
                return GetSpNameInClass(page, action);

            }
            catch (System.Exception ex)
            {
                var em = ex.Message;
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
                                                                               // Does not works
                                                                              //  DataSourceItem myitem = GetItemList("PageList", JsonFile, page, actio// DataSourceItem myitem = GetItemList("ItemList", JsonFile, page, action)// return myitem.objName + myitem.parameters;
               }
            }
            catch (System.Exception ex)
            {
                var em = ex.Message;
                return "";
            }

        }

        private static string GetSpNameInClass(string page,string action)
        {
            switch (page)
            {

                case "Request":
                    return RequestPostingExe.SPName(action);
                case "Approve":
                    return PostingPositionExe.SPName(action);
                case "Publish":
                    return PublishPositionExe.SpName(action);
                case "Candidate":
                    return SelectCandidateExe.SPName(action);
                case "Hiring":
                    return ConfirmHireExe.SPName(action);
                case "Hired":
                    return HiredPositionExe.SPName(action);
                case "Interview":
                    return InterviewProcessExe.SPName(action);
                case "Applying":
                    return ApplyProcessExe.SPName(action);
                case "MultipleSchools":
                    return MultipleSchoolsExe.SPName(action);
                case "Staff":
                    return LTOStaffManageExe.SPName(action);
                case "Summary":
                    return PostingSummaryExe.SPName(action);
                default:
                    return GeneralExe.SPName(action);
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
            return CommonExcute.GetSPandPara_FromItemList(jsonFile, page, action);
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
                var em = ex.Message;
                return null;
            }

        }

    }


    public class CommonExcute<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SP"> store procedure name and @parameters, for example dbo.tcdsb_LTO_PageGeneral_List @Operate,@Para1,@Para1,@Para2,@Para3</param>
        /// <param name="parameter"> store procedure parameters data object. for example List2Item { Operate = "PostingRound", Para0 = "20192020", Para1 = "0529" }</param>
        /// <returns> general list of T class type </returns>
        public static List<T> GeneralList(string SP, object parameter)
        {
            try
            {
                return   MyDapper.EasyDataAccess<T>.ListOfT(SP, parameter);

                ////  IListRepository<Employee2, string> repository = Factory.Get<CommonList<T>>();
                //var mylist = new CommonList<T>();
                //// var mylist = Factory.Get<CommonList<T>>(); Does not work;
                //return mylist.GeneralListOfT(SP, parameter); //  .IGeneralListOfT(SP, parameter);

            }
            catch (System.Exception ex)
            {
                var em = ex.Message;
                throw ex;
            }
        }
        public static List<T> GeneralList(string cPage, string action, object parameter)
        {
            try
            {

                var mylist = new CommonList<T>();
                var SPFile = SPSource.SPFile;
                var SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
                return mylist.GeneralListOfT(SP, parameter);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="SP"> store procedure name and @parameters. for example dbo.tcdsb_LTO_PagePublish_Operation @Operate, @UserID, @SchoolYear,@SchoolCode,@PositionID, @PositionType</param>
        /// <param name="parameter"> store procedure parameters data object. foxe example PositionPublish {Operate ="Update", UserID ="",SchoolYear="20192020",PositionID="11575"........} </param>
        /// <returns> single text value for example, school name or successfully/Failed </returns>

        public static string GeneralValue(string SP, T parameter)
        {
            try
            {
                return MyDapper.EasyDataAccess<string>.ValueOfT(SP, parameter);

                //var myval = new CommonOperation<T>();
                ////  var myval =  Factory.Get<CommonOperation<T>>();  Does not work;
                //return myval.GeneralValue(SP, parameter);
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
                return MyDapper.EasyDataAccess<string>.ValueOfT(SP, parameter);

                //var myval = new CommonOperation<T>();
                ////  var myval =  Factory.Get<CommonOperation<T>>();  Does not work;
                //return myval.GeneralValue(SP, parameter);
            }
            catch(System.Exception ex)
            {
                throw ex;
            }
        }
        public static string GeneralValue(string cPage, string action, T parameter)
        {
            var myval = new CommonOperation<T>();
            var SPFile = WebConfigValue.SPFile();
            var SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            return myval.GeneralValue(SP, parameter);
        }
        public static string ProfileValue(object parameter)
        {
            string SP = CommonExcute.SPNameAndParameters("", "General", "Profile");
            var myval = new CommonOperation<T>();

            return myval.GeneralValue(SP, parameter);
        }
        public static T GeneralValueOfT(string SP, object parameter)
        {
            try
            {
                var myval = new CommonOperation<T>();
                //  var myval =  Factory.Get<CommonOperation<T>>();  Does not work;
               return myval.GeneralValueOfT(SP, parameter);

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
