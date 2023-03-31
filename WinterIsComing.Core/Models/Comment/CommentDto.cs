namespace WinterIsComing.Core.Models.Comment
{
    public class CommentDto
    {
        public string Id { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string Content { get; set; } = null!;

        public string PublishedOn { get; set; } = null!;

        public string AuthorImageUrl { get; set; } = null!;

        public string ResortId { get; set; } = null!;

        public string AuthorId { get; set; } = null!;

    }
}
