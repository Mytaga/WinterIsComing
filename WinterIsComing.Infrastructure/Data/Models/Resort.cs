using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinterIsComing.Infrastructure.Data.Models
{
    public class Resort
    {
        public Resort()
        {
            Id = Guid.NewGuid().ToString();
            Users = new HashSet<AppUser>();
            LiftPassPrices = new HashSet<Price>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(4)]
        public string Elevation { get; set; } = null!;

        [Required]
        [StringLength(150)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string ImageUrl { get; set;} = null!;

        public int Likes { get; set; }

        [Required]
        [ForeignKey(nameof(Country))]
        public string CountryId { get; set; } = null!;

        public virtual Country Country { get; set; } = null!;

        public virtual ICollection<AppUser> Users { get; set; }

        public virtual ICollection<Price> LiftPassPrices { get; set; }
    }
}
