using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PageItemR : Repository<PageItem>, IPageItem
    {
        //private readonly string _db = "";
        //private readonly IDataOperateService<PageItem> _dataOperate;

        public PageItemR() : base()
        { 
        }
        public PageItemR(string dataSource) : base(dataSource)
        { 
        }
        public override string GetspName(string action)
        {
            if (action == "") return "dbo.EPA_Appr_AppraisalProcess_GoPage";
            return action;
        }
        //public override string ValueString(string action, string spName, PageItem para)
        //{
        //    return _dataOperate.ValueString(_db, GetspName(spName), GetParameter(action,para));
        //}

        public override object GetParameter(string action, PageItem obj)
        {
            return new
            {
                Operate = action,
                obj.UserID, 
                obj.Category,
                obj.Area,
                obj.Code
            };
        }
 
    }
}
