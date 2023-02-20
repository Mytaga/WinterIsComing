using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WinterIsComing.Common.Constants.ModelValidationConstants;

namespace WinterIsComing.Infrastructure.Data.Models
{
    public class Comment
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(CommentValidation.ContentMaxLength)]
        public string Content { get; set; } = null!;

        [Required]
        public string Author { get; set; } = null!;

        [Required]
        public DateTime PublishedOn { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string AppUserId { get; set; } = null!;

        public virtual AppUser User { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Resort))]
        public string ResortId { get; set; } = null!;

        public virtual Resort Resort { get; set; } = null!;
    }
}
