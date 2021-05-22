namespace Web_API.ViewModels.ReviewAndRate.Response
{
    public class ReviewAndRateResponseViewModel
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public float Rate { get; set; }
        
        public int SubClubId { get; set; }
    }
}