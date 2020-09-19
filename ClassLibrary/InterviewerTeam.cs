namespace ClassLibrary
{
    public class InterviewerTeam
    {
        public string UserID { get; set; }
        public string SchoolYear { get; set; }
        public string PositionID { get; set; }
        public string CPNum { get; set; }
        public string Signature { get; set; }
        public string SignatureID { get; set; }
        public string SignOff { get; set; }
        public string SignOffDate { get; set; }
        public string SignOffP1 { get; set; }
        public string SignOffP2 { get; set; }
        public string SignOffP3 { get; set; }
        public string InterviewName1 { get; set; }
        public string InterviewName2 { get; set; }
        public string InterviewName3 { get; set; }
        public string Member1ID { get; set; }
        public string Member2ID { get; set; }
        public string Member3ID { get; set; }
        public string CandidateName { get; set; }
        public string CandidateID { get; set; }

    }
    public class InterviewerTeamMembers
    {
        public string UserID { get; set; }
        public string SchoolYear { get; set; }
        public string PositionID { get; set; }
        public int Sequence { get; set; }
        public string MemberID { get; set; }
        public string Operate { get; set; }

    }
     
}
