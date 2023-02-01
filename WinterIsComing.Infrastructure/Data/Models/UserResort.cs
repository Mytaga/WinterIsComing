using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinterIsComing.Infrastructure.Data.Models
{
    public class UserResort
    {
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
