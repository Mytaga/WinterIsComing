using WinterIsComing.Core.Models.Comment;
using WinterIsComing.Infrastructure.Data.Models;

namespace WinterIsComing.Core.Contracts
{
    public interface ICommentService
    {
        Task<AllCommentsDto> GetResortComments(Resort resort);

        Task AddComment(AddCommentDto model, Resort resort);

        Task EditComment(AddCommentDto model, Comment comment);

        Task<CommentDto> DeleteComment(Resort resort, string userId);

        Task<Comment> GetById(string id);
    }
}
