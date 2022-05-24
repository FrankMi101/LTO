using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PublishPostingAsync : AppBaseAsync 
    {
        public PublishPostingAsync() : base()
        {
        }
        public PublishPostingAsync(string dataSource) : base(dataSource)
        {
        }

        public override string SpName(string action, object parameter)
        {
            var spandParameter = new PublishPosting();
            return spandParameter.SpName(action, parameter);
        }
 
    }
}
