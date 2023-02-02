using System.ComponentModel.DataAnnotations;
using static WinterIsComing.Common.Constants.ModelValidationConstants;

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
        [StringLength(CountryValidation.NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Resort> Resorts { get; set; }
    }
}
