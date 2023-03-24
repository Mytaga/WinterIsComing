using WinterIsComing.Core.Models.Resort;

namespace WinterIsComing.Core.Models
{
    public class UserProfileDto
    {
        public string UserName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Email { get; set; } = null!;

        public virtual ICollection<ResortDto> MyResorts { get; set; } = null!;
    }
}
