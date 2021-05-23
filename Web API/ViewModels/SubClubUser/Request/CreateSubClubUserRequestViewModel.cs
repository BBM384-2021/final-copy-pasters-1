using Web_API.Entities;

namespace Web_API.ViewModels.SubClubUser.Request
{
    public class CreateSubClubUserRequestViewModel
    {    
        public int SubClubId { get; set; }
        public int UserId { get; set; }
        public SubClubRole SubClubRole { get; set; }
        public int BanCount { get; set; }
    }
}