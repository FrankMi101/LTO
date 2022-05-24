using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PostingDateAsync : AppBaseAsync
    {
        public PostingDateAsync() : base()
        {
        }
        public PostingDateAsync(string dataSource) : base(dataSource)
        {
        }
        public override string SpName(string action, object parameter)
        {
            var spandParameter = new PostingDate();
            return spandParameter.SpName(action, parameter);
        }
    }
     
 
}
