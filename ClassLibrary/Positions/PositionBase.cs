using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public abstract class PositionBase
    {
        public int PositionID { get; set; }
        public string SchoolYear { get; set; }
        public string SchoolCode { get; set; }
        public string PositionType { get; set; }
        public string PositionTitle { get; set; }
        public string PositionLevel { get; set; }
        public string PositionState { get; set; }
        public string Qualification { get; set; }
        public string QualificationCode { get; set; }
        public string Description { get; set; }
        public decimal FTE { get; set; }
        public string FTEPanel { get; set; }
        public string ReplaceTeacherID { get; set; }
        public string ReplaceTeacher { get; set; }
        public string ReplaceReason { get; set; }
        public string OtherReason { get; set; }
        public string Comments { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Owner { get; set; }
        public string Operate { get; set; }
        public string UserID { get; set; }
        public string PostingCycle { get; set; }
        public string PostingNumber { get; set; }
        public string TimeTable { get; set; }
        public string MultipleSchool { get; set; }
        public string DatePublish { get; set; }
        public string DateApplyOpen { get; set; }
        public string DateApplyClose { get; set; }
        public string PrincipalID { get; set; }
        public string PrincipalName { get; set; }
        public string Superintendent { get; set; }
        public string CPNum { get; set; }
        public string RequestSource { get; set; }
        public int RequestSourceID { get; set; }
        public string PostingState { get; set; }
        public string  Degree { get; set; }

    }
}
