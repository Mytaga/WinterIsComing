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

        public async Task AddComment(AddCommentDto model, Resort resort)
        {   
            var comment = new Comment
            {
                Content = model.Content,
                Author = model.Author,
                PublishedOn = model.PublishedOn,
                UserPhoto = model.AuthorImage,
                ResortId = resort.Id,
                AppUserId = model.AppUserId,
            };

            await this.repo.AddAsync(comment);
            await this.repo.SaveChangesAsync();
        }

        public async Task<CommentDto> DeleteComment(Resort resort, string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var comments = await this.repo.All<Comment>().Where(c => c.ResortId == resort.Id).ToListAsync();

            var model = new CommentDto();

            if (comments.Any(c => c.AppUserId == userId))
            {
                var comment = comments.FirstOrDefault(c => c.AppUserId == userId);

                model.Id = comment.Id;
                model.AuthorId = comment.AppUserId;
                model.ResortId = comment.ResortId;

                resort.Comments.Remove(comment);
                user.Comments.Remove(comment);
                this.repo.Delete<Comment>(comment);
            }

            await this.repo.SaveChangesAsync();

            return model;
        }

        public async Task EditComment(AddCommentDto model, Comment comment)
        {
            comment.Content = model.Content;
            
            this.repo.Update<Comment>(comment);

            await this.repo.SaveChangesAsync();
        }

        public async Task<Comment> GetById(string id)
        {
            return await this.repo
                .All<Comment>()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<AllCommentsDto> GetResortComments(Resort resort)
        {
            var result = new AllCommentsDto();

            var comments = this.repo
                .AllReadonly<Comment>()
                .Where(c => c.ResortId == resort.Id)
                .OrderByDescending(c => c.PublishedOn);

            result.Comments = await comments
                .Select(r => new CommentDto
                {
                    Id = r.Id,
                    Author = r.Author,
                    PublishedOn = r.PublishedOn.ToShortDateString(),
                    AuthorImage = r.User.ImageUrl,
                    Content = r.Content,
                    ResortId = resort.Id,
                    AuthorId = r.AppUserId,
                })
                .ToListAsync();

            return result;
        }
    }
}
