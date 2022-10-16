using Microsoft.AspNetCore.Identity;

namespace EasySchoolManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}
