namespace ClassLibrary
{
    public class StaffBasic
    {
        public string Operate { get; set; }
        public string Action { get; set; }
        public string Comments { get; set; }
        public string UserID { get; set; }
        public string CPNum { get; set; }

    }
    public class Staff : StaffBasic
    {
        public string SearchBy { get; set; }
        public string SearchValue { get; set; }
        public string ApplySign { get; set; }
        public string LTOAction { get; set; }

        public string TeacherName { get; set; }
        public string SchoolName { get; set; }
        public string OTType { get; set; }
        public string DateOfHire { get; set; }
        public string UploadDate { get; set; }
        public string OCTNumber { get; set; }
        public string Qualification { get; set; }
        public string Lots { get; set; }
        public string Ranking { get; set; }
        public int RowNo { get; set; }

    }
    public class HRComments : StaffBasic
    {
        public int IDs { get; set; }
        public string CommentsDate { get; set; }
        public string CommentsBy { get; set; }
        public string Ranking { get; set; }
        public string Lots { get; set; }
        public string DateOfHire { get; set; }
    }
}
