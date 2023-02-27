namespace WinterIsComing.Core.Models.Resort
{
    public class AllResortsDto
    {
        public string? SearchQuerry { get; set; }

        public ICollection<ResortDto> Resorts { get; set; } = new HashSet<ResortDto>();
    }
}
