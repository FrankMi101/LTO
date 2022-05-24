using ClassLibrary;
using DataAccess;
using DataAccess.Repository;
using System.Collections.Generic;
using System.Linq;
namespace AppOperate
{
    public class PostingDateExe
    {
        private readonly static IAppServices _action = new AppServices( new PostingDate(DBConnection.DBSource)); 
        public PostingDateExe()
        {
        }
     
        public static List<LTODefalutDate> DefaultDate(object parameter)
        {  
            string sp = GetSP("DefaultDate");
            return _action.AppOne.CommonList<LTODefalutDate>(sp, parameter);
         }
        public static LTODefalutDate DefaultDateObj(object parameter)
        {
            string sp = GetSP("DefaultDate");
            return _action.AppOne.CommonObject<LTODefalutDate>(sp, parameter);
        }
        public static string Deadline(object parameter)
        {
            string sp = GetSP("Deadline");
            return _action.AppOne.CommonAction(sp, parameter);
        }
        public static string PostingDate(object parameter)
        {
            string sp = GetSP("PostingDate");
            return _action.AppOne.CommonAction(sp, parameter);
         }

        private static string GetSP(string action)
        {
            if (SPSource.SPFile == "") return GetSPInClass(action);

            return GetSPFromJsonFile(action);
        }
        public static string SPName(string action)
        {
            return GetSPInClass(action);
        }
        public static string SPName(string action, object para)
        {
            return GetSPInClass(action, para);
        }
        private static string GetSPInClass(string action)
        {
            return action;
        }
        private static string GetSPInClass(string action, object parameter)
        {
            return _action.AppOne.SpName(action, parameter);
        }
        private static string GetSPFromJsonFile(string action)
        {
            return GetSpNameFormJsonFile.SPName(action, "PostingDate");
        }
    }
 
}
