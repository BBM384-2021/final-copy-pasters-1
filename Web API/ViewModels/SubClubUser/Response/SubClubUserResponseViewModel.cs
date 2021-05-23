using Web_API.Entities;

namespace Web_API.ViewModels.SubClubUser.Response
{
    public class SubClubUserResponseViewModel
    {
        public int SubClubId { get; set; }
        public int UserId { get; set; }
        public SubClubRole SubClubRole { get; set; }
        public int BanCount { get; set; }
    }
}