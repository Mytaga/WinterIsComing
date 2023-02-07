using System.ComponentModel.DataAnnotations;
using static WinterIsComing.Common.Constants.ModelValidationConstants;

namespace WinterIsComing.Core.Models
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = AppUserValidation.UsernameIsRequiredErrorMsg)]
        [MinLength(AppUserValidation.UsernameMinLength, ErrorMessage = AppUserValidation.UsernameMinLengthErrorMsg)]
        [MaxLength(AppUserValidation.UsernameMaxLength, ErrorMessage = AppUserValidation.UsernameMaxLengthErrorMsg)]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = AppUserValidation.FirstNameIsRequiredErrorMsg)]
        [MinLength(AppUserValidation.FirstNameMinLength, ErrorMessage = AppUserValidation.FirstNameMinLengthErrorMsg)]
        [MaxLength(AppUserValidation.FirstNameMaxLength, ErrorMessage = AppUserValidation.FirstNameMaxLengthErrorMsg)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = AppUserValidation.LastNameIsRequiredErrorMsg)]
        [MinLength(AppUserValidation.LastNameMinLength, ErrorMessage = AppUserValidation.LastNameMinLengthErrorMsg)]
        [MaxLength(AppUserValidation.LastNameMaxLength, ErrorMessage = AppUserValidation.LastNameMaxLengthErrorMsg)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
    }
}
