using WinterIsComing.Core.Models.Comment;
using WinterIsComing.Infrastructure.Data.Models;

namespace WinterIsComing.Core.Contracts
{
    public interface ICommentService
    {
        Task<ICollection<CommentDto>> GetResortComments(Resort resort);

        Task AddComment(AddCommentDto model, Resort resort, string userId);

        Task DeleteComment(Comment comment);

        Task<Comment> GetById(string id);
    }
}
