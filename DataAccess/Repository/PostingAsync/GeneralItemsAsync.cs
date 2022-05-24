using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class GeneralItemsAsync :AppBaseAsync
    {
        public GeneralItemsAsync() : base()
        {
        }
        public GeneralItemsAsync(string dataSource) : base(dataSource)
        {
        }

        public override string SpName(string action, object parameter)
        {
            var spandParameter = new GeneralItems();
            return spandParameter.SpName(action, parameter);
        }
 
    }
}
