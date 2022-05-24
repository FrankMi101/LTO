using ClassLibrary;
using DataAccess;
using DataAccess.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppOperate
{
    public class PublishPositionExeAsync
    {
        private readonly static IAppServicesAsync _action = new AppServiceAsync(new PublishPostingAsync(DBConnection.DBSource)); 
        public PublishPositionExeAsync()
        {
        }
        public  static  string  SpName(string action)
        {
            return PublishSP.Name(action);
        }
        public  static  string  SpName(string action, object para)
        {
            return PublishSP.Name(action, para);
        }
        public async static Task<List<PositionListPublish>> Positions(object parameter)
        {
            string sp = GetSp("Positions");
            return await _action.AppOne.CommonList<PositionListPublish>(sp, parameter);
        }
        public async static Task<PositionPublish> Position(object parameter)
        {
            string sp = GetSp("Position");
            return await _action.AppOne.CommonObject<PositionPublish>(sp, parameter);
        }
        public async static Task<PositionPublish> PositionbyID(object parameter)
        {
            string sp = GetSp("Position");
            return await _action.AppOne.CommonObject<PositionPublish>(sp, parameter);
        }
        public async static Task<PositionInfo> PositionInfo(object parameter)
        {
            string sp = GetSp("PositionInfo");
            return await _action.AppOne.CommonObject<PositionInfo>(sp, parameter);
        }
        public async static Task<LTODefalutDate> DefaultDate(object parameter)
        {
            string sp = GetSp("DefaultDate");
            return await _action.AppOne.CommonObject<LTODefalutDate>(sp, parameter);
        }
        public async static Task<List<PositionPublish>> PostingRounds(object parameter)
        {
            string sp = GetSp("PostingRounds");
            return await  _action.AppOne.CommonList<PositionPublish>(sp, parameter);
         }
        public async static Task< List<ApplicantNotice>> NoticeApplicants(object parameter)
        {
            string sp = GetSp("NoticeApplicants");
            return await _action.AppOne.CommonList<ApplicantNotice>(sp, parameter);
        }

        public async static Task<string> Add(object parameter)
        {
            string sp = GetSp("New");
            return await _action.AppOne.CommonAction(sp, parameter);
        }
        public async static Task<string> Update(object parameter)
        {
            string sp = GetSp("Update");
            return await _action.AppOne.CommonAction(sp, parameter);
        }
        public async static Task<string> Delete(object parameter)
        {
            string sp = GetSp("Delete");
            return await _action.AppOne.CommonAction(sp, parameter);
        }
        public async static Task<string> Cancel(object parameter)
        {
            string sp = GetSp("Cancel");
            return await _action.AppOne.CommonAction(sp, parameter);
        }
        public async static Task<string> Recover(object parameter)
        {
            string sp = GetSp("Recover");
            return await _action.AppOne.CommonAction(sp, parameter);
       }
        public async static Task<string> RePosting(object parameter)
        {
            string sp = GetSp("RePosting");
            return await _action.AppOne.CommonAction(sp, parameter);
        }
        public async static Task<string> Deadline(object parameter)
        {
            string sp = GetSp("Deadline");
            return await _action.AppOne.CommonAction(sp, parameter);
        }
        public async static Task<string> PrincipalsEmail(object parameter)
        {
            string sp = GetSp("PrincipalsEmail");
            return await _action.AppOne.CommonAction(sp, parameter);
        }
        public async static Task<string> Attribute(object parameter)
        {
            string sp = GetSp("Attribute");
            return await _action.AppOne.CommonAction(sp, parameter);
       }

        private static string GetSp(string action)
        {
            return action;
            if (SPSource.SPFile == "")
            { return PublishSP.Name(action); }
            else
            { return GetSpFromJsonFile(action); }

        }
        private static string GetSpFromJsonFile(string action)
        {
            return GetSpNameFormJsonFile.SPName(action, "Publish");
        }
    }

    public class PublishPositionExeAsync<T>
    {
         private readonly static IAppServicesAsync _action = new AppServiceAsync(new PublishPostingAsync(DBConnection.DBSource));

        public PublishPositionExeAsync()
        {
        }
    
        public async static Task<List<T>> Positions(object parameter)
        {
              string sp = GetSp("Positions");
            return await _action.AppOne.CommonList<T>(sp, parameter);// CommonExcute<T>.GeneralList(sp, parameter);
        }
        public async static Task<T> Position(object parameter)
        {
            string sp = GetSp("Position");
            return await _action.AppOne.CommonObject<T>(sp, parameter);// CommonExcute<T>.GeneralList(sp, parameter);
        }
        public async static Task<T> PositionbyID(object parameter)
        {
            string sp = GetSp("Position");
            return await _action.AppOne.CommonObject<T>(sp, parameter);// CommonExcute<T>.ObjectOfT(sp, parameter);
        }
        public async static Task<T> PositionInfo(object parameter)
        {
            string sp = GetSp("PositionInfo");
            return await _action.AppOne.CommonObject<T>(sp, parameter);// CommonExcute<T>.GeneralList(sp, parameter);
        }
        public async static Task<T> DefaultDate(object parameter)
        {
            string sp = GetSp("DefaultDate");
            return await _action.AppOne.CommonObject<T>(sp, parameter);//CommonExcute<T>.GeneralList(sp, parameter);
        }
        public async static Task<List<T>> PostingRounds(object parameter)
        {
            string sp = GetSp("PostingRounds");
            return await _action.AppOne.CommonList<T>(sp, parameter);//CommonExcute<T>.GeneralList(sp, parameter);
        }
        public async static Task<List<T>> NoticeApplicants(object parameter)
        {
            string sp = GetSp("NoticeApplicants");
            return await _action.AppOne.CommonList<T>(sp, parameter);//CommonExcute<T>.GeneralList(sp, parameter);
        }

        public async static Task<string> Add(object parameter)
        {
            string sp = GetSp("New");
            return await _action.AppOne.CommonAction(sp, parameter);// CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public async static Task<string> Update(object parameter)
        {
            string sp = GetSp("Update");
            return await _action.AppOne.CommonAction(sp, parameter);// CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public async static Task<string> Delete(object parameter)
        {
            string sp = GetSp("Delete");
            return await _action.AppOne.CommonAction(sp, parameter);// CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public async static Task<string> Cancel(object parameter)
        {
            string sp = GetSp("Cancel");
            return await _action.AppOne.CommonAction(sp, parameter);// CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public async static Task<string> Recover(object parameter)
        {
            string sp = GetSp("Recover");
            return await _action.AppOne.CommonAction(sp, parameter);// CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public async static Task<string> RePosting(object parameter)
        {
            string sp = GetSp("RePosting");
            return await _action.AppOne.CommonAction(sp, parameter);// CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public async static Task<string> Deadline(object parameter)
        {
            string sp = GetSp("Deadline");
            return await _action.AppOne.CommonAction(sp, parameter);// CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public async static Task<string> PrincipalsEmail(object parameter)
        {
            string sp = GetSp("PrincipalsEmail");
            return await _action.AppOne.CommonAction(sp, parameter);// CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public async static Task<string> Attribute(object parameter)
        {
            string sp = GetSp("Attribute");
            return await _action.AppOne.CommonAction(sp, parameter);// CommonExcute<string>.GeneralValue(sp, parameter);
        }

        private static string GetSp(string action)
        {
            return action;
 
        }
        private static string GetSpFromJsonFile(string action)
        {
            return GetSpNameFormJsonFile.SPName(action, "Publish");
        }
    }
   
}
