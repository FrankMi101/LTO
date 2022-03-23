using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class NameValueListR : Repository<NameValueList>, INameValueList
    {
        //private readonly string _db = "";
        //private readonly IDataOperateService<NameValueList> _dataOperate;
        public NameValueListR():base()
        {

        }
        public NameValueListR(string dataSource)  :base(dataSource)
         {
        //    _db = DBConnection.CurrentDB;
        //    this._dataOperate = DataSourceMap<NameValueList>.DBSource();
        }
        public override string GetspName(string action)
        {
            if (action == "") return "dbo.tcdsb_LTO_PageGeneral_List";
            if (action == "School") return "dbo.tcdsb_LTO_PageGeneral_ListSchools";
            if (action == "SearchList") return "dbo.tcdsb_LTO_PageGeneral_ListSearch";
            if (action == "SchoolPrincipal") return "dbo.tcdsb_LTO_ListSchoolPrincipalsNew";
            return action;
        }
     
        public override object GetParameter(string action, NameValueList obj)
        {
            return new
            {
                Operate = action, 
            };
        }   
    }
}
