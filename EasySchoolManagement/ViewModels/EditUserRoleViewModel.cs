using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasySchoolManagement.ViewModels
{
    public class EditUserRoleViewModel
    {
        public EditUserRoleViewModel()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }
        [Required, Display(Name = "Role Name")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}
