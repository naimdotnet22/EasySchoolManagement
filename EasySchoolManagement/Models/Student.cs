using EasySchoolManagement.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasySchoolManagement.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, Display(Name = "Registration No")]
        public string RegistrationNo { get; set; }

        [Required, Display(Name = "Current Class")]
        public Class? CurrentClass { get; set; }

        [Required]
        public Gender? Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Required, Display(Name = "Contact No")]
        public string ContactNo { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }
       
        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [NotMapped]
        public string NotifyMessage { get; set; }
    }
}
