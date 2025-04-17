using MyBlog.Core.CoreEntities.Entities;
using MyBlog.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.DataSeeders
{
    public class ArticleSeeder : IDataSeeder
    {
        public async Task SeedAsync(AppDbContext appDbContext)
        {
            if (!appDbContext.Articles.Any())
            {
                var technologyCategory = appDbContext.Categories.FirstOrDefault(c => c.Name == "Technology");

                var articles = new[]
                {
                new Article { Id = Guid.NewGuid().ToString(), Title = "Tech Trends 2025", Content = "Content about tech trends...", CategoryId = technologyCategory?.Id ?? Guid.NewGuid().ToString() },
                new Article { Id = Guid.NewGuid().ToString(), Title = "New AI Technologies", Content = "Content about AI...", CategoryId = technologyCategory?.Id ?? Guid.NewGuid().ToString() }
            };

                await appDbContext.Articles.AddRangeAsync(articles);
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
