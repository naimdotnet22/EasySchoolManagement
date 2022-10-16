using EasySchoolManagement.Enums;
using System;

namespace EasySchoolManagement.ViewModels
{
    public class StudentDetailViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string RegistrationNo { get; set; }
        public Class? CurrentClass { get; set; }
        public Gender? Gender { get; set; }
        public int Age { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
