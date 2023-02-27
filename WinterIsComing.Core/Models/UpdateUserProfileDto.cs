using System.ComponentModel.DataAnnotations;
using static WinterIsComing.Common.Constants.ModelValidationConstants;

namespace WinterIsComing.Core.Models
{
    public class UpdateUserProfileDto
    {
        [Required(ErrorMessage = AppUserValidation.UsernameIsRequiredErrorMsg)]
        [MinLength(AppUserValidation.UsernameMinLength, ErrorMessage = AppUserValidation.UsernameMinLengthErrorMsg)]
        [MaxLength(AppUserValidation.UsernameMaxLength, ErrorMessage = AppUserValidation.UsernameMaxLengthErrorMsg)]
        public string UserName { get; set; } = null!;

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

        [MaxLength(AppUserValidation.ImageUrlMaxLength, ErrorMessage = AppUserValidation.ImageUrlMaxLengthErrorMsg)]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; } = null!;
    }
}
