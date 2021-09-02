using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{

    public class EmailNotice : EmailBase
    {
        public string UserID { get; set; }
        public string SchoolYear { get; set; }
        public string SchoolCode { get; set; }
        public string PositionType { get; set; }
        public string PositionID { get; set; }
        public string PositionTitle { get; set; }
        public string PostingNum { get; set; }
        public string EmailType { get; set; }

        public string NoticePrincipal { get; set; }
        public string Attachment1 { get; set; }
        public string Attachment2 { get; set; }
        public string Attachment3 { get; set; }

    }
}
