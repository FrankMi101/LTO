using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{

    public class ParametersForCandidate : ParametersForPosition, IParametersForCandidate
    {
        public string Operate { get; set; }
    }
}
