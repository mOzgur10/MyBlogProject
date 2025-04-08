using MyBlog.Application.Services.IServices;
using MyBlog.Application.Utilities.IUnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Utilities.UnitOfWorks
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public UnitOfWorkService(IUnitOfWork unitOfWork, IAppUserService appUserService, IArticleService articleService, ICategoryService categoryService, ICommentService commentService) 
        {
            _unitOfWork = unitOfWork;
            AppUserService = appUserService;
            ArticleService = articleService;
            CategoryService = categoryService;
            CommentService = commentService;
            
        }
        public IAppUserService AppUserService { get; }

        public IArticleService ArticleService { get; }

        public ICategoryService CategoryService { get; }

        public ICommentService CommentService { get; }
    }
}
