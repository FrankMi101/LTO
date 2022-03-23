using ClassLibrary;
using DataAccess;
using DataAccess.Repository;
using System.Collections.Generic;
using System.Linq;
namespace AppOperate
{
    public class PublishPositionExe
    {
        private readonly static IAppServices _action = new AppServices(DBConnection.DBSource, new PublishPosting()); 
        public PublishPositionExe()
        {
        }
        public static string SpName(string action)
        {
            return PublishSP.Name(action);
        }
        public static string SpName(string action, object para)
        {
            return PublishSP.Name(action, para);
        }
        public static List<PositionListPublish> Positions(object parameter)
        {
            string sp = GetSp("Positions");
            return _action.AppOne.CommonList<PositionListPublish>(sp, parameter);
           // return CommonExcute<PositionListPublish>.GeneralList(sp, parameter);
        }
        public static List<PositionPublish> Position(object parameter)
        {
            string sp = GetSp("Position");
            return _action.AppOne.CommonList<PositionPublish>(sp, parameter);
           // return CommonExcute<PositionPublish>.GeneralList(sp, parameter);
        }
        public static PositionPublish PositionbyID(object parameter)
        {
            string sp = GetSp("Position");
            return _action.AppOne.CommonObject<PositionPublish>(sp, parameter);
          //  return CommonExcute<PositionPublish>.ObjectOfT(sp, parameter);
        }
        public static List<PositionInfo> PositionInfo(object parameter)
        {
            string sp = GetSp("PositionInfo");
            return _action.AppOne.CommonList<PositionInfo>(sp, parameter);

           //  return CommonExcute<PositionInfo>.GeneralList(sp, parameter);
        }
        public static List<LTODefalutDate> DefaultDate(object parameter)
        {
            string sp = GetSp("DefaultDate");
            return _action.AppOne.CommonList<LTODefalutDate>(sp, parameter);
          //  return CommonExcute<PositionPublish>.GeneralList(sp, parameter);
        }
        public static List<PositionPublish> PostingRounds(object parameter)
        {
            string sp = GetSp("PostingRounds");
            return _action.AppOne.CommonList<PositionPublish>(sp, parameter);
         //   return CommonExcute<PositionPublish>.GeneralList(sp, parameter);
        }
        public static List<ApplicantNotice> NoticeApplicants(object parameter)
        {
            string sp = GetSp("NoticeApplicants");
            return _action.AppOne.CommonList<ApplicantNotice>(sp, parameter);
      //      return CommonExcute<ApplicantNotice>.GeneralList(sp, parameter);
        }

        public static string Add(object parameter)
        {
            string sp = GetSp("New");
            return _action.AppOne.CommonAction(sp, parameter);

         //   return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string Update(object parameter)
        {
            string sp = GetSp("Update");
            return _action.AppOne.CommonAction(sp, parameter);

            //            return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string Delete(object parameter)
        {
            string sp = GetSp("Delete");
            return _action.AppOne.CommonAction(sp, parameter);

            //           return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string Cancel(object parameter)
        {
            string sp = GetSp("Cancel");
            return _action.AppOne.CommonAction(sp, parameter);

            //            return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string Recover(object parameter)
        {
            string sp = GetSp("Recover");
            return _action.AppOne.CommonAction(sp, parameter);

            //             return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string RePosting(object parameter)
        {
            string sp = GetSp("RePosting");
            return _action.AppOne.CommonAction(sp, parameter);

            //             return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string Deadline(object parameter)
        {
            string sp = GetSp("Deadline");
            return _action.AppOne.CommonAction(sp, parameter);

            //            return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string PrincipalsEmail(object parameter)
        {
            string sp = GetSp("PrincipalsEmail");
            return _action.AppOne.CommonAction(sp, parameter);

            //            return CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string Attribute(object parameter)
        {
            string sp = GetSp("Attribute");
            return _action.AppOne.CommonAction(sp, parameter);

            //            return CommonExcute<string>.GeneralValue(sp, parameter);
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

    public class PublishPositionExe<T>
    {
         private readonly static IAppServices _action = new AppServices(DBConnection.DBSource, new PublishPosting());

        public PublishPositionExe()
        {
        }
        public static string SpName(string action)
        {
            return  PublishSP.Name(action);
        }
        public static string SpName(string action, object para)
        {
            return PublishSP.Name(action, para);
        }
        public static List<T> Positions(object parameter)
        {
              string sp = GetSp("Positions");
            return _action.AppOne.CommonList<T>(sp, parameter);// CommonExcute<T>.GeneralList(sp, parameter);
        }
        public static List<T> Position(object parameter)
        {
            string sp = GetSp("Position");
            return _action.AppOne.CommonList<T>(sp, parameter);// CommonExcute<T>.GeneralList(sp, parameter);
        }
        public static T PositionbyID(object parameter)
        {
            string sp = GetSp("Position");
            return _action.AppOne.CommonObject<T>(sp, parameter);// CommonExcute<T>.ObjectOfT(sp, parameter);
        }
        public static List<T> PositionInfo(object parameter)
        {
            string sp = GetSp("PositionInfo");
            return _action.AppOne.CommonList<T>(sp, parameter);// CommonExcute<T>.GeneralList(sp, parameter);
        }
        public static List<T> DefaultDate(object parameter)
        {
            string sp = GetSp("DefaultDate");
            return _action.AppOne.CommonList<T>(sp, parameter);//CommonExcute<T>.GeneralList(sp, parameter);
        }
        public static List<T> PostingRounds(object parameter)
        {
            string sp = GetSp("PostingRounds");
            return _action.AppOne.CommonList<T>(sp, parameter);//CommonExcute<T>.GeneralList(sp, parameter);
        }
        public static List<T> NoticeApplicants(object parameter)
        {
            string sp = GetSp("NoticeApplicants");
            return _action.AppOne.CommonList<T>(sp, parameter);//CommonExcute<T>.GeneralList(sp, parameter);
        }

        public static string Add(object parameter)
        {
            string sp = GetSp("New");
            return _action.AppOne.CommonAction(sp, parameter);// CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string Update(object parameter)
        {
            string sp = GetSp("Update");
            return _action.AppOne.CommonAction(sp, parameter);// CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string Delete(object parameter)
        {
            string sp = GetSp("Delete");
            return _action.AppOne.CommonAction(sp, parameter);// CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string Cancel(object parameter)
        {
            string sp = GetSp("Cancel");
            return _action.AppOne.CommonAction(sp, parameter);// CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string Recover(object parameter)
        {
            string sp = GetSp("Recover");
            return _action.AppOne.CommonAction(sp, parameter);// CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string RePosting(object parameter)
        {
            string sp = GetSp("RePosting");
            return _action.AppOne.CommonAction(sp, parameter);// CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string Deadline(object parameter)
        {
            string sp = GetSp("Deadline");
            return _action.AppOne.CommonAction(sp, parameter);// CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string PrincipalsEmail(object parameter)
        {
            string sp = GetSp("PrincipalsEmail");
            return _action.AppOne.CommonAction(sp, parameter);// CommonExcute<string>.GeneralValue(sp, parameter);
        }
        public static string Attribute(object parameter)
        {
            string sp = GetSp("Attribute");
            return _action.AppOne.CommonAction(sp, parameter);// CommonExcute<string>.GeneralValue(sp, parameter);
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
    public class PublishSP
    {
        private readonly static IAppServices _action = new AppServices(DBConnection.DBSource, new PublishPosting());

        public static string Name(string action)
        {
            return action;
        }
        public static string Name(string action, object para)
        {
            return _action.AppOne.SpName(action, para);
        }
        private static string GetSpFromJsonFile(string action)
        {
            return GetSpNameFormJsonFile.SPName(action, "Publish");
        }
    }
}
