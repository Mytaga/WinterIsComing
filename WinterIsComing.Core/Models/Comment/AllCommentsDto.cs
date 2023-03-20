namespace WinterIsComing.Core.Models.Comment
{
    public class AllCommentsDto
    {
        public ICollection<CommentDto> Comments { get; set; } = new HashSet<CommentDto>();
    }
}
