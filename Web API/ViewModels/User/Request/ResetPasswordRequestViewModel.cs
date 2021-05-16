using System.ComponentModel.DataAnnotations;

namespace Web_API.ViewModels.User.Request
{
    public class ResetPasswordRequestViewModel
    {
        [Required]
        public string Token { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}