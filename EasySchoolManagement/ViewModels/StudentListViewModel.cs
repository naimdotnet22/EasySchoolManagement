using EasySchoolManagement.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace EasySchoolManagement.ViewModels
{
    public class StudentListViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        [Display(Name = "Registration No")]
        public string RegistrationNo { get; set; }

        [Display(Name = "Current Class")]
        public Class? CurrentClass { get; set; }

        [Required]
        public Gender? Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Address { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
