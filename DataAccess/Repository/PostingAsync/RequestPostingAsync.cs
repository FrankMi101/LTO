using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RequestPostingAsync : AppBaseAsync
    {
        public RequestPostingAsync() : base()
        {
        }
        public RequestPostingAsync(string dataSource) : base(dataSource)
        {
        }

        public override string SpName(string action, object parameter)
        {
            var spandParameter = new RequestPosting();
            return spandParameter.SpName(action, parameter);
        }

    }
}
