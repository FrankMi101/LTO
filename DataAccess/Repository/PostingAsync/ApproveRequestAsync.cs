using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ApproveRequestAsync : AppBaseAsync
    {
        public ApproveRequestAsync() : base()
        {
        }
        public ApproveRequestAsync(string dataSource) : base(dataSource)
        {
        }
        public override string SpName(string action, object parameter)
        {
            var spandParameter = new ApproveRequest();
            return spandParameter.SpName(action, parameter);
        }
    }
     
 
}
