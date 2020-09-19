using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public class EmailNotice
    {  public string UserID { get; set; }
        public string SchoolYear { get; set; }
        public string SchoolCode { get; set; }
        public string PositionType { get; set; }
        public string PositionID { get; set; }
        public string PositionTitle { get; set; }
        public string PostingNum { get; set; }
        public string EmailType { get; set; }
        public string EmailTo { get; set; }
        public string EmailCC { get; set; }
        public string EmailBcc { get; set; }
        public string EmailFrom { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public string EmailFormat { get; set; }
        public string NoticePrincipal { get; set; }
        public string Attachment1 { get; set; }
        public string Attachment2 { get; set; }
        public string Attachment3 { get; set; }

    }
public class EmailNotice2 :EmailNotice
    {
        public string  NoticeFor { get; set; }
    }
  public class MultipleSchoolEmail : EmailNotice
    {
        public string PrincipalID { get; set; }
        public string  PrinciaplName { get; set; }
        public string SchoolName   { get; set; }
        public string  DatePublish { get; set; }
        public string FTE { get; set; }
        public string Description { get; set; }
        public string  ReplaceTeacher { get; set; }
        public string ReplaceReason { get; set; }    
    }   
}
