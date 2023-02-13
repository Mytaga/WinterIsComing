using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static WinterIsComing.Common.Constants.ModelValidationConstants;

namespace WinterIsComing.Infrastructure.Data.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.FavouriteResorts = new HashSet<Resort>();
            this.Likes = new HashSet<Like>();
        }

        [Required]
        [StringLength(AppUserValidation.FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(AppUserValidation.LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [StringLength(AppUserValidation.ImageUrlMaxLength)]
        public string? ImageUrl { get; set; } 

        public virtual ICollection<Resort> FavouriteResorts { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
