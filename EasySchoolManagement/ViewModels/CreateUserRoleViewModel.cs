using System.ComponentModel.DataAnnotations;

namespace EasySchoolManagement.ViewModels
{
    public class CreateUserRoleViewModel
    {
        [Required, Display(Name = "Role Name")]
        public string RoleName { get; set;}
    }
}
