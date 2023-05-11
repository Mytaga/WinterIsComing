using System.ComponentModel.DataAnnotations;
using WinterIsComing.Common.Constants;

namespace WinterIsComing.Core.Models
{
    public class LoginDto
    {
        [Required(ErrorMessage = ModelValidationConstants.AppUserValidation.EmailIsRequiredErrorMsg)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
