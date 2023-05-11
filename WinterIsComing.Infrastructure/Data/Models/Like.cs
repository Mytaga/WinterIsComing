using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinterIsComing.Infrastructure.Data.Models
{
    public class Like
    {
        public Like()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [ForeignKey(nameof(Resort))]
        public string ResortId { get; set; } = null!;

        public virtual Resort Resort { get; set; } = null!;

        [ForeignKey(nameof(AppUser))]
        public string AppUserId { get; set; } = null!;

        public virtual AppUser AppUser { get; set; } = null!;
    }
}
