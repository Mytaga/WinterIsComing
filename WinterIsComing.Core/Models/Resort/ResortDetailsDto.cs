namespace WinterIsComing.Core.Models.Resort
{
    public class ResortDetailsDto
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Elevation { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int Likes { get; set; }

        public int NumberOfSlopes { get; set; }

        public double SkiAreaSizes { get; set; }

        public string CountryName { get; set; } = null!;

        public ICollection<ResortPriceDto> LiftPrices { get; set; } = new HashSet<ResortPriceDto>();
    }
}
