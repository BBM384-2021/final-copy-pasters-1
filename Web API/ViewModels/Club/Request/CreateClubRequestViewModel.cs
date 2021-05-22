using System.ComponentModel.DataAnnotations;

namespace Web_API.ViewModels.Club.Request
{
    public class CreateClubRequestViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}