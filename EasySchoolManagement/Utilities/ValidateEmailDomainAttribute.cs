using System.ComponentModel.DataAnnotations;

namespace EasySchoolManagement.Utilities
{
    public class ValidateEmailDomainAttribute : ValidationAttribute
    {
        private readonly string _allowedDomain;

        public ValidateEmailDomainAttribute(string allowedDomain)
        {
            _allowedDomain = allowedDomain;
        }
        public override bool IsValid(object value)
        {
            string[] strings = value.ToString().Split('@');
            return strings[1].ToUpper() == _allowedDomain.ToUpper();
        }
    }
}
