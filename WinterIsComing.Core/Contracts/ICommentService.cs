using WinterIsComing.Core.Models.Comment;
using WinterIsComing.Infrastructure.Data.Models;

namespace WinterIsComing.Core.Contracts
{
    public interface ICommentService
    {
        Task<AllCommentsDto> GetResortComments(Resort resort);

        Task AddComment(AddCommentDto model, Resort resort);

        Task DeleteComment(Comment comment);

        Task<Comment> GetById(string id);
    }
}
