using System.ComponentModel.DataAnnotations;

namespace Web_API.ViewModels.User.Request
{
    public class AuthenticateRequestViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}