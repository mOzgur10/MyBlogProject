using MyBlog.Core.CoreEntities.Entities;
using MyBlog.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.DataSeeders
{
    public class CategorySeeder : IDataSeeder
    {
        public async Task SeedAsync(AppDbContext appDbContext)
        {
            if (!appDbContext.Categories.Any())
            {
                var categories = new[]
                {
                new Category { Id = Guid.NewGuid().ToString(), Name = "Technology" },
                new Category { Id = Guid.NewGuid().ToString(), Name = "Science" },
                new Category { Id = Guid.NewGuid().ToString(), Name = "Health" }
            };

                await appDbContext.Categories.AddRangeAsync(categories);
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
