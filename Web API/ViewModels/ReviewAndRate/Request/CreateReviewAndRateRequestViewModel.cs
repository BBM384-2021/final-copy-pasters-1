namespace Web_API.ViewModels.ReviewAndRate.Request
{
    public class CreateReviewAndRateRequestViewModel
    {
        public string Review { get; set; }
        public float Rate { get; set; }
        public int SubClubId { get; set; }
    }
}