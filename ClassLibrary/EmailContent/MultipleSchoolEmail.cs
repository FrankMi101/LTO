namespace ClassLibrary
{
    public class MultipleSchoolEmail : EmailNotice
    {
        public string PrincipalID { get; set; }
        public string PrinciaplName { get; set; }
        public string SchoolName { get; set; }
        public string DatePublish { get; set; }
        public string FTE { get; set; }
        public string Description { get; set; }
        public string ReplaceTeacher { get; set; }
        public string ReplaceReason { get; set; }
    }
}
