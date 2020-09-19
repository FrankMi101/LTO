namespace ClassLibrary
{
    public interface IParametersForOperation
    {
        string Action { get; set; }
        string Comments { get; set; }
        string CPNum { get; set; }
        string Operate { get; set; }
        int PositionID { get; set; }
        string PositionType { get; set; }
        string PostingCycle { get; set; }
        string SchoolCode { get; set; }
        string SchoolYear { get; set; }
        string TakeApplicant { get; set; }
        string Type { get; set; }
        string UserID { get; set; }
    }
}