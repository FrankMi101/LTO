using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class InterviewResultsAsync : AppBaseAsync
    {
        public InterviewResultsAsync() : base()
        {
        }
        public InterviewResultsAsync(string dataSource) : base(dataSource)
        {
        }
        public override string SpName(string action, object parameter)
        {
            var spandParameter = new InterviewResults();
            return spandParameter.SpName(action, parameter);
        }
    }
     
 
}
