using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WinterIsComing.Infrastructure.Data.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Id = Guid.NewGuid().ToString();
            FavouriteResorts = new HashSet<Resort>();
        }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(30)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<Resort> FavouriteResorts { get; set; }
    }
}
