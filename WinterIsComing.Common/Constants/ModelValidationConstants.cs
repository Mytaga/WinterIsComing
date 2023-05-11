
namespace WinterIsComing.Common.Constants
{
    public static class ModelValidationConstants
    {
        public static class ResortValidation
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 2;
            public const int ElevationMaxLength = 4;
            public const int ElevationMinLength = 2;
            public const int DescriptionMaxLength = 300;
            public const int DescriptionMinLength = 20;
            public const int ImageUrlMaxLength = 200;
            public const int ImageUrlMinLength = 10;
            public const int NumberOfSlopesMinLength = 1;
            public const int NumberOfSlopesMaxLength = 1000;

            public const string NameIsRequiredErrorMsg = "Name is required!";
            public const string NameMaxLengthErrorMsg = "Name length must be no more than 50 characters!";
            public const string NameMinLengthErrorMsg = "Name length must at least 2 characters!";
            public const string ElevationIsRequiredErrorMsg = "Elevation is required!";
            public const string ElevationMaxLengthErrorMsg = "Elevation length must be no more than 4 characters!";
            public const string ElevationMinLengthErrorMsg = "Elevation length must be at least 2 characters!";
            public const string DescriptionIsRequiredErrorMsg = "Description is required!";
            public const string DescriptionMaxLengthErrorMsg = "Description length must be no more than 300 characters!";
            public const string DescriptionMinLengthErrorMsg = "Description length must be at least 20 characters!";
            public const string ImageUrlIsRequiredErrorMsg = "ImageUrl is required!";
            public const string ImageUrlMaxLengthErrorMsg = "ImageUrl length must be no more than 200 characters!";
            public const string ImageUrlMinLengthErrorMsg = "ImageUrl length must be at least 10 characters!";
            public const string NumberOfSlopesIsRequiredErrorMsg = "Number of slopes is required!";
            public const string NumberOfSlopesMinLengthErrorMsg = "Number of slopes must be at least 1!";
            public const string SkiAreSizeIsRequiredErrorMsg = "Ski area size is required!";
            public const string CountryIsRequiredErrorMsg = "Country is required!";
        }
        
        public static class CountryValidation
        {
            public const int NameMaxLength = 50;

            public const string NameIsRequiredErrorMsg = "Name is required!";
            public const string NameMaxLengthErrorMsg = "Name length must be no more than 50 characters!";
        }

        public static class AppUserValidation
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 30;
            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 30;
            public const int ImageUrlMaxLength = 200;
            public const int UsernameMinLength = 2;
            public const int UsernameMaxLength = 50;

            public const string FirstNameIsRequiredErrorMsg = "First Name is required!";
            public const string LastNameIsRequiredErrorMsg = "Last Name is required!";
            public const string UsernameIsRequiredErrorMsg = "Username is required!";
            public const string FirstNameMinLengthErrorMsg = "First Name length must be at least 2 characters!";
            public const string FirstNameMaxLengthErrorMsg = "First Name length must be no more than 30 characters!";
            public const string LastNameMinLengthErrorMsg = "Last Name length must be at least 2 characters!";
            public const string LastNameMaxLengthErrorMsg = "Last Name length must be no more than 30 characters!";
            public const string ImageUrlMaxLengthErrorMsg = "ImageUrl length must be no more than 200 characters!";        
            public const string UsernameMinLengthErrorMsg = "Username length must be no more than 50 characters!";
            public const string UsernameMaxLengthErrorMsg = "Username length must be at least 1 character!";
        } 

        public static class CommentValidation
        {
            public const int ContentMaxLength = 300;
            public const int ContentMinLength = 10;

            public const string ContentIsRequiredErrorMsg = "Content is required!";
            public const string ContentMinLengthErrorMsg = "Content must be at least 10 characters!";
            public const string ContentMaxLengthErrorMsg = "Content must be no more than 300 characters!";
        }

        public static class PriceValidation 
        {
            public const int ValueMin = 0;
            public const int ValueMax = 10000;

            public const string PriceValueIsRequiredErrorMsg = "Value is required!";
            public const string PriceValueMinError = "Value must me more than 0!";
            public const string PriceValueMaxError = "Value must be no more than 10000!";
            public const string PassTypeIsRequiredErrorMsg = "Pass type is required!";
            public const string ResortIsRequiredErrorMsg = "Resort is required!";
        }
    }
}
