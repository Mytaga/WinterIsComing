namespace WinterIsComing.Core.Models.Resort
{
    public class AllResortsDto
    {
        public ICollection<ResortDto> Resorts { get; set; } = new HashSet<ResortDto>();
    }
}
