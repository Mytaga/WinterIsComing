namespace WinterIsComing.Core.Models.Resort
{
    public class ResortDto
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Elevation { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int Likes { get; set; }

        public string CountryName { get; set; } = null!;

    }
}
