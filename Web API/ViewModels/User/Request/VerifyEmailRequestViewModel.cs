using System.ComponentModel.DataAnnotations;

namespace Web_API.ViewModels.User.Request
{
    public class VerifyEmailRequestViewModel
    {
        [Required]
        public string Token { get; set; }
    }
}