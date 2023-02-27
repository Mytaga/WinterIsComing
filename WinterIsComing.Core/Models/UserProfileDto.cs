using WinterIsComing.Infrastructure.Data.Models;

namespace WinterIsComing.Core.Models
{
    public class UserProfileDto
    {
        public string UserName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public virtual ICollection<Resort> MyResorts { get; set; } = null!;
    }
}
