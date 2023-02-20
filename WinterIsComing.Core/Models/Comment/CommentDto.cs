namespace WinterIsComing.Core.Models.Comment
{
    public class CommentDto
    {
        public string Id { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string Content { get; set; } = null!;

        public DateTime PublishedOn { get; set; }

        public string ResortId { get; set; } = null!;
    }
}
