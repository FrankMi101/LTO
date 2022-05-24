using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class StaffManageAsync : AppBaseAsync
    {
        public StaffManageAsync() : base()
        {
        }
        public StaffManageAsync(string dataSource) : base(dataSource)
        {
        }
        public override string SpName(string action, object parameter)
        {
            var spandParameter = new StaffManage();
            return spandParameter.SpName(action, parameter);
        }
    }
     
 
}
