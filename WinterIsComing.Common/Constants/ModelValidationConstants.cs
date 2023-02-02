namespace WinterIsComing.Common.Constants
{
    public static class ModelValidationConstants
    {
        public static class ResortValidation
        {
            public const int NameMaxLength = 50;
            public const int ElevationMaxLength = 4;
            public const int DescriptionMaxLength = 150;
            public const int ImageUrlMaxLength = 100;

            public const string NameIsRequiredErrorMsg = "Name is required!";
            public const string NameMaxLengthErrorMsg = "Name length must be no more than 50 characters!";
            public const string ElevationIsRequiredErrorMsg = "Elevation is required!";
            public const string ElevationMaxLengthErrorMsg = "Elevation length must be no more than 4 characters!";
            public const string DescriptionIsRequiredErrorMsg = "Description is required!";
            public const string DescriptionMaxLengthErrorMsg = "Description length must be no more than 150 characters!";
            public const string ImageUrlIsRequiredErrorMsg = "ImageUrl is required!";
            public const string ImageUrlMaxLengthErrorMsg = "ImageUrl length must be no more than 100 characters!";
        }
        
        public static class CountryValidation
        {
            public const int NameMaxLength = 50;

            public const string NameIsRequiredErrorMsg = "Name is required!";
            public const string NameMaxLengthErrorMsg = "Name length must be no more than 50 characters!";
        }

        public static class AppUserValidation
        {
            public const int FirstNameMaxLength = 30;
            public const int LastNameMaxLength = 30;
            public const int ImageUrlMaxLength = 100;

            public const string FirstNameIsRequiredErrorMsg = "First Name is required!";
            public const string LastNameIsRequiredErrorMsg = "Last Name is required!";
            public const string FirstNameMaxLengthErrorMsg = "First Name length must be no more than 30 characters!";
            public const string LastNameMaxLengthErrorMsg = "Last Name length must be no more than 30 characters!";
            public const string ImageUrlMaxLengthErrorMsg = "ImageUrl length must be no more than 100 characters!";
        } 
    }
}
