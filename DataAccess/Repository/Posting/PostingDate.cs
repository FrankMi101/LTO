using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PostingDate : PostingBase
    {
        public PostingDate() : base()
        {
        }
        public PostingDate(string dataSource) : base(dataSource)
        {
        }
        public override string SpName(string action, object parameter)
        {
            if (SPSource.SPFile == "") return GetspNameAndParameter(action, parameter); 
            return GetSPFromJSonFile.SPandParameter(SPSource.SPFile, "PublishDate", action);
        }

        private string GetspNameAndParameter(string action, object parameter)
        {
            bool IsAnonymous = parameter.GetType().FullName.Contains("AnonymousType");
            string sp = GetspName(action);
            if (IsAnonymous)
                return sp;
            else
            {
                string para = GetParameters(action);
                if (para.Length > 1) return sp + " " + para;

                return sp;
            }
        }
        private string GetspName(string action)
        {
            switch (action)
            {
                case "Deadline":          return "dbo.tcdsb_LTO_PagePublish_DeadlineExt";
                case "PostingDate":       return "dbo.tcdsb_LTO_PagePublish_DeadlineExt";
                case "DefaultDate":       return "dbo.tcdsb_LTO_PagePublish_DefaultDateExt";

                default:
                    return action;

            }

        }
        private string GetParameters(string action)
        {
            string parameter = "@Operate,@AppType,@SchoolYear";
             switch (action)
            {
                case "Deadline":    return parameter + ",@PublishDate";
                case "PostingDate": return parameter + ",@PublishDate";
                case "DefaultDate": return parameter;


                default: return "";

            }

       
        }
    }
     
 
}
