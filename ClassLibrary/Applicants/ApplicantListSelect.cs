using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ApplicantListSelect : ApplicantList
    {
        public string Acceptance { get; set; }
        public string Noticed { get; set; }
        public string SelectedC { get; set; }
        public string ScoreLevel { get; set; }
        public string Ranking { get; set; }
        public string Lots { get; set; }
        public new  string ApplyDate { get; set; }
    }
}
