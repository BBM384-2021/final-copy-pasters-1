using System.ComponentModel.DataAnnotations;

namespace Web_API.ViewModels.User.Request
{
    public class ValidateResetTokenRequestViewModel
    {
        [Required]
        public string Token { get; set; }
    }
}