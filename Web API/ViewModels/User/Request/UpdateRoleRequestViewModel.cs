using System.ComponentModel.DataAnnotations;
using Web_API.Entities;

namespace Web_API.ViewModels.User.Request
{
    public class UpdateRoleRequestViewModel
    {
        private string _role;
        [EnumDataType(typeof(Role))]
        public string Role
        {
            get => _role;
            set => _role = ReplaceEmptyWithNull(value);
        }

        private static string ReplaceEmptyWithNull(string value)
        {
            // replace empty string with null to make field optional
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}