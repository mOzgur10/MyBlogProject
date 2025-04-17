using MyBlog.Application.Services;
using MyBlog.Application.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Utilities.IUnitOfWorks
{
    public interface IUnitOfWorkService
    {
        public IAppUserService AppUserService { get; }
        public IArticleService ArticleService { get; }
        public ICategoryService CategoryService { get; }
        public ICommentService CommentService { get; }
        Task<int> CommitChangesAsync();
    }
}
