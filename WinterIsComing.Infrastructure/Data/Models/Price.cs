using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinterIsComing.Infrastructure.Data.Models
{
    public class Price
    {
        public Price()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public Type PassType { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Resort))]
        public string ResortId { get; set; } = null!;

        public virtual Resort Resort { get; set; } = null!;
    }
}
