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

        public async Task<ICollection<CommentDto>> GetResortComments(Resort resort)
        {
            var result = await this.repo
                .AllReadonly<Comment>()
                .Where(c => c.ResortId == resort.Id)
                .Select(c => new CommentDto
                {
                    Id = c.Id,
                    Author = c.Author,
                    Content = c.Content,
                    PublishedOn = c.PublishedOn,

                })
                .ToListAsync();

            return result;
        }
    }
}
