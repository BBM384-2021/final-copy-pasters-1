using System.ComponentModel.DataAnnotations;
using Web_API.Entities;

namespace Web_API.ViewModels.User.Request
{
    public class UpdateRequestViewModel
    {
        private string _password;
        private string _confirmPassword;
        private string _email;
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [EmailAddress]
        public string Email
        {
            get => _email;
            set => _email = ReplaceEmptyWithNull(value);
        }

        [MinLength(6)]
        public string Password
        {
            get => _password;
            set => _password = ReplaceEmptyWithNull(value);
        }

        [Compare("Password")]
        public string ConfirmPassword 
        {
            get => _confirmPassword;
            set => _confirmPassword = ReplaceEmptyWithNull(value);
        }

        // helpers

        private static string ReplaceEmptyWithNull(string value)
        {
            // replace empty string with null to make field optional
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}