using static WinterIsComing.Common.Constants.ModelValidationConstants;
using System.ComponentModel.DataAnnotations;

namespace WinterIsComing.Core.Models.Comment
{
    public class AddCommentDto
    {
        [Required(ErrorMessage = CommentValidation.ContentIsRequiredErrorMsg)]
        [MinLength(CommentValidation.ContentMinLength, ErrorMessage = CommentValidation.ContentMinLengthErrorMsg)]
        [MaxLength(CommentValidation.ContentMaxLength, ErrorMessage = CommentValidation.ContentMaxLengthErrorMsg)]
        public string Content { get; set; } = null!;

        [Required]
        public string Author { get; set; } = null!;

        [Required]
        public DateTime PublishedOn => DateTime.UtcNow;

        public string AppUserId { get; set; } = null!;

        public string AuthorImage { get; set; } = null!;

    }
}
