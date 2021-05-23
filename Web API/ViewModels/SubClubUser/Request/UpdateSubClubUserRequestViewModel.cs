using Web_API.Entities;

namespace Web_API.ViewModels.SubClubUser.Request
{
    public class UpdateSubClubUserRequestViewModel
    {
        public SubClubRole SubClubRole { get; set; }
        public int BanCount { get; set; }
    }
}