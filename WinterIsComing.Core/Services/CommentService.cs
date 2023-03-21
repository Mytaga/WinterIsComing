using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WinterIsComing.Core.Contracts;
using WinterIsComing.Core.Models.Comment;
using WinterIsComing.Infrastructure.Data.Common;
using WinterIsComing.Infrastructure.Data.Models;

namespace WinterIsComing.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository repo;
        private readonly UserManager<AppUser> userManager;

        public CommentService(IRepository repo, UserManager<AppUser> userManager)
        {
            this.repo = repo;
            this.userManager= userManager;
        }

        public async Task AddComment(AddCommentDto model, Resort resort, string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            
            var comment = new Comment
            {
                Content = model.Content,
                Author = user.UserName,
                PublishedOn = model.PublishedOn,
                ResortId = resort.Id,
                AppUserId = userId,
            };

            await this.repo.AddAsync(comment);
            await this.repo.SaveChangesAsync();
        }

        public async Task DeleteComment(Comment comment)
        {
            await this.repo
                .DeleteAsync<Comment>(comment);
        }

        public async Task<Comment> GetById(string id)
        {
            return await this.repo
                .AllReadonly<Comment>()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<AllCommentsDto> GetResortComments(Resort resort)
        {
            var result = new AllCommentsDto();

            var comments = this.repo.AllReadonly<Comment>().Where(c => c.ResortId == resort.Id);

            result.Comments = await comments
                .Select(r => new CommentDto
                {
                    Id = r.Id,
                    Author = r.Author,
                    PublishedOn = r.PublishedOn.ToShortDateString(),
                    AuthorImageUrl = r.User.ImageUrl,
                    Content = r.Content,
                    ResortId = resort.Id,
                })
                .ToListAsync();

            return result;
        }
    }
}
