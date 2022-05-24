using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ApplyPostingAsync : AppBaseAsync
    {
        public ApplyPostingAsync() : base()
        {
        }
        public ApplyPostingAsync(string dataSource) : base(dataSource)
        {
        }
        public override string SpName(string action, object parameter)
        {
            var spandParameter = new ApplyPosting();
            return spandParameter.SpName(action, parameter);
        }
    }
     
 
}
