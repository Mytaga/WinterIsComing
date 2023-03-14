namespace WinterIsComing.Core.Models.Resort
{
    public class ResortPriceDto
    {
        public string Id { get; set; } = null!;

        public string PassType { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
