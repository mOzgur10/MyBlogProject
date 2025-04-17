using MyBlog.Core.CoreEntities.Entities;
using MyBlog.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.DataSeeders
{
    public class CommentSeeder : IDataSeeder
    {
        public async Task SeedAsync(AppDbContext appDbContext)
        {
            if (!appDbContext.Comments.Any())
            {
                var article = appDbContext.Articles.FirstOrDefault();
                var user = appDbContext.Users.FirstOrDefault();

                if (article != null && user != null)
                {
                    var comments = new[]
                    {
                    new Comment { Id = Guid.NewGuid().ToString(), Content = "Great article!", ArticleId = article.Id, AppUserId = user.Id },
                    new Comment { Id = Guid.NewGuid().ToString(), Content = "Very informative, thanks!", ArticleId = article.Id, AppUserId = user.Id }
                };

                    await appDbContext.Comments.AddRangeAsync(comments);
                    await appDbContext.SaveChangesAsync();
                }
            }
        }
    }
}
