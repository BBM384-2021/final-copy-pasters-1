using System.ComponentModel.DataAnnotations;

namespace Web_API.ViewModels.Club.Request
{
    public class UpdateClubRequestViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}