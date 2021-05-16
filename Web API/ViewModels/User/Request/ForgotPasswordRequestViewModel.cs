using System.ComponentModel.DataAnnotations;

namespace Web_API.ViewModels.User.Request
{
    public class ForgotPasswordRequestViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}