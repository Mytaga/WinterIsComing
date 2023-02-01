using System.ComponentModel.DataAnnotations;

namespace WinterIsComing.Infrastructure.Data.Models
{
    public class Country
    {
        public Country()
        {
            Id = Guid.NewGuid().ToString();
            Resorts = new HashSet<Resort>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Resort> Resorts { get; set; }
    }
}
