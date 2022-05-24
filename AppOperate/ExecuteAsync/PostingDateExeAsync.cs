using ClassLibrary;
using DataAccess;
using DataAccess.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppOperate
{
    public class PostingDateExeAsync
    {
        private readonly static IAppServicesAsync _action = new AppServiceAsync( new PostingDateAsync(DBConnection.DBSource)); 
        public PostingDateExeAsync()
        {
        }
     
        public async static Task<LTODefalutDate> DefaultDate(object parameter)
        {  
            string sp = GetSP("DefaultDate");
            return await _action.AppOne.CommonObject<LTODefalutDate>(sp, parameter);
         }
     
        public async static   Task<string> Deadline(object parameter)
        {
            string sp = GetSP("Deadline");
            return await _action.AppOne.CommonAction(sp, parameter);
        }
        public async static  Task<string> PostingDate(object parameter)
        {
            string sp = GetSP("PostingDate");
            return await  _action.AppOne.CommonAction(sp, parameter);
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
