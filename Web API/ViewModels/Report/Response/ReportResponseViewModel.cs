namespace Web_API.ViewModels.Report.Response
{
    public class ReportResponseViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ProofFilesUrl { get; set; }
        
        public int SubClubId { get; set; }
        public int UserId { get; set; }
    }
}