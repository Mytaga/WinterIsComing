using WinterIsComing.Core.Models.Resort;

namespace WinterIsComing.Core.Models
{
    public class UserProfileDto
    {
        public string UserName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string Email { get; set; } = null!;
    }
}
