using Microsoft.Extensions.DependencyInjection;
using MyBlog.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.DataSeeders
{
    public class DataSeederManager
    {
        private readonly AppDbContext _dbContext;
        private readonly IServiceProvider _serviceProvider;

        public DataSeederManager(AppDbContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
        }

        public async Task SeedAllAsync()
        {
            // ServiceProvider üzerinden her bir seeder'ı alıyoruz.
            var identitySeeder = _serviceProvider.GetRequiredService<AppUserSeeder>();
            await identitySeeder.SeedAsync(_dbContext);

            var categorySeeder = _serviceProvider.GetRequiredService<CategorySeeder>();
            await categorySeeder.SeedAsync(_dbContext);

            var articleSeeder = _serviceProvider.GetRequiredService<ArticleSeeder>();
            await articleSeeder.SeedAsync(_dbContext);

            var commentSeeder = _serviceProvider.GetRequiredService<CommentSeeder>();
            await commentSeeder.SeedAsync(_dbContext);
        }
    }
}
