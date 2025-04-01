using MyBlog.Core.CoreEntities.Entities;
using MyBlog.Infrastructure.Contexts;
using MyBlog.Infrastructure.Repositories.BaseRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Repositories
{
    public class ArticleRepo : BaseRepo<Article>
    {
        public ArticleRepo(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
