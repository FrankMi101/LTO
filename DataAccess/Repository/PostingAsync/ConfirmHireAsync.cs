using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ConfirmHireAsync : AppBaseAsync
    {
        public ConfirmHireAsync() : base()
        {
        }
        public ConfirmHireAsync(string dataSource) : base(dataSource)
        {
        }
        public override string SpName(string action, object parameter)
        {
            var spandParameter = new ConfirmHire();
            return spandParameter.SpName(action, parameter);
        }
    }
     
 
}
