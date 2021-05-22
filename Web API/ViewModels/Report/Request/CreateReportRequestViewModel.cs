namespace Web_API.ViewModels.Report.Request
{
    public class CreateReportRequestViewModel
    {
        public string Description { get; set; }
        public string ProofFilesUrl { get; set; }
        
        public int SubClubId { get; set; }
        public int UserId { get; set; }
    }
}