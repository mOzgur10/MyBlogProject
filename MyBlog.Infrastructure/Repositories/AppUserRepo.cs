using MyBlog.Application.IRepositories;
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
    public class AppUserRepo : BaseRepo<AppUser>, IAppUserRepo
    {
        public AppUserRepo(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
