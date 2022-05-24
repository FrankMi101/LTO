using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class HiredPositionsAsync : AppBaseAsync
    {
        public HiredPositionsAsync() : base()
        {
        }
        public HiredPositionsAsync(string dataSource) : base(dataSource)
        {
        }
        public override string SpName(string action, object parameter)
        {
            var spandParameter = new HiredPositions();
            return spandParameter.SpName(action, parameter);
        }
    }
     
 
}
