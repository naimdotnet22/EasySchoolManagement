using EasySchoolManagement.Enums;
using System.ComponentModel.DataAnnotations;

namespace EasySchoolManagement.ViewModels
{
    public class StudentCreateViewModel
    {
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, Display(Name = "Registration No")]
        public string RegistrationNo { get; set; }

        [Required(ErrorMessage = "Class is Required"), Display(Name = "Current Class")]
        public Class? CurrentClass { get; set; }

        [Required(ErrorMessage ="Gender is Required")]
        public Gender? Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Required, Display(Name = "Contact No")]
        public string ContactNo { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
