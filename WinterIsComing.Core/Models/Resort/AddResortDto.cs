using static WinterIsComing.Common.Constants.ModelValidationConstants;
using System.ComponentModel.DataAnnotations;

namespace WinterIsComing.Core.Models.Resort
{
    public class AddResortDto
    {
        [Required(ErrorMessage = ResortValidation.NameIsRequiredErrorMsg)]
        [MinLength(ResortValidation.NameMinLength, ErrorMessage = ResortValidation.NameMinLengthErrorMsg)]
        [MaxLength(ResortValidation.NameMaxLength, ErrorMessage = ResortValidation.NameMaxLengthErrorMsg)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = ResortValidation.DescriptionIsRequiredErrorMsg)]
        [MinLength(ResortValidation.ElevationMinLength, ErrorMessage = ResortValidation.ElevationMinLengthErrorMsg)]
        [MaxLength(ResortValidation.ElevationMaxLength, ErrorMessage = ResortValidation.ElevationMaxLengthErrorMsg)]
        public string Elevation { get; set; } = null!;

        [Required(ErrorMessage = ResortValidation.DescriptionIsRequiredErrorMsg)]
        [MinLength(ResortValidation.DescriptionMinLength, ErrorMessage = ResortValidation.DescriptionMinLengthErrorMsg)]
        [MaxLength(ResortValidation.DescriptionMaxLength, ErrorMessage = ResortValidation.DescriptionMaxLengthErrorMsg)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = ResortValidation.ImageUrlIsRequiredErrorMsg)]
        [MinLength(ResortValidation.ImageUrlMinLength, ErrorMessage = ResortValidation.ImageUrlMinLengthErrorMsg)]
        [MaxLength(ResortValidation.ImageUrlMaxLength, ErrorMessage = ResortValidation.ImageUrlMaxLengthErrorMsg)]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = ResortValidation.NumberOfSlopesIsRequiredErrorMsg)]
        [Range(ResortValidation.NumberOfSlopesMinLength, ResortValidation.NumberOfSlopesMaxLength, ErrorMessage = ResortValidation.NumberOfSlopesMinLengthErrorMsg)]
        [Display(Name = "Number Of Slopes")]
        public int NumberOfSlopes { get; set; }

        [Required(ErrorMessage = ResortValidation.NumberOfSlopesIsRequiredErrorMsg)]
        [Display(Name = "Ski Area Size")]
        public double SkiAreaSize { get; set; }

        [Required(ErrorMessage = ResortValidation.CountryIsRequiredErrorMsg)]
        public string CountryId { get; set; } = null!;
    }
}
