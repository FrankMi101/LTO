using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class SelectCandidateAsync : AppBaseAsync
    {
        public SelectCandidateAsync() : base()
        {
        }
        public SelectCandidateAsync(string dataSource) : base(dataSource)
        {
        }

        public override string SpName(string action, object parameter)
        {
            var spandParameter = new SelectCandidate();
            return spandParameter.SpName(action, parameter);
        }

    }
}
