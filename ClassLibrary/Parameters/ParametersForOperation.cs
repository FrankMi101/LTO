using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ParametersForOperation : IParametersForOperation 
    {
        public string Operate { get; set; }
        public string UserID { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
        public string SchoolYear { get; set; }
        public string SchoolCode { get; set; }
        public int PositionID { get; set; }
        public string  Comments { get; set; }
        public string PostingCycle { get; set; }
        public string TakeApplicant { get; set; }
        public string PositionType { get; set; }
         public string CPNum { get; set; }

     
    }
    public class ParametersForOperationHire : ParametersForOperation
    {
        public string DateConfirm { get; set; }
        public string DateEffective { get; set; }
        public string DateEnd { get; set; }
        public string Acceptance { get; set; }
        public string PrincipalEmail { get; set; }
        public string OfficerEmail { get; set; }
        public string PayStatus { get; set; }
        public string TeacherName { get; set; }    

    }
   
}
