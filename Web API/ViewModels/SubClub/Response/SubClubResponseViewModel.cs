namespace Web_API.ViewModels.SubClub.Response
{
    public class SubClubResponseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public float AverageRate { get; set; }
        
        public int ClubId { get; set; }
    }
}