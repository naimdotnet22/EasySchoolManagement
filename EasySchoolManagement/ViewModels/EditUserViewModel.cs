using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasySchoolManagement.ViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Roles = new List<string>();
        }
        public string Id { get; set; }

        [Required][EmailAddress]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public IList<string> Roles { get; set; }

    }
}
