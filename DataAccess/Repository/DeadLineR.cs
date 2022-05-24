using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class DeadLineR : Repository<DeadlineDate>, IDeadLine
    {
        private readonly string _db = "";
        private readonly IDataOperateService<DeadlineDate> _dataOperate;

        public DeadLineR(string dataSource) : base(dataSource)
        {
            _db = DBConnection.CurrentDB;
            this._dataOperate = DataSourceMap<DeadlineDate>.DBSource();
        }
        public override string GetspName(string action)
        {
            if (action == "") return "dbo.tcdsb_LTO_PagePublish_DeadlineExt";
            return action;
        }
  
        public override object GetParameter(string action, DeadlineDate obj)
        {
            return new
            {
                Operate = action,
                obj.SchoolYear,
                obj.PublishDate,
                obj.PositionType
            };
        }
 
    }
}
