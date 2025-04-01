using AutoMapper;
using MyBlog.Application.IRepositories;
using MyBlog.Application.IRepositories.BaseRepos;
using MyBlog.Application.Utilities.IUnitOfWorks;
using MyBlog.Core.CoreEntities.BaseEntities;
using MyBlog.Infrastructure.Contexts;
using MyBlog.Infrastructure.Repositories.BaseRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Utilities.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IAppUserRepo AppUserRepo { get; }
        public IArticleRepo ArticleRepo { get; }
        public ICategoryRepo CategoryRepo { get; }
        public ICommentRepo CommentRepo { get; }
        public IMapper Mapper { get; }

        public UnitOfWork(AppDbContext context, IMapper mapper, IAppUserRepo appUserRepo, IArticleRepo articleRepo, ICategoryRepo categoryRepo, ICommentRepo commentRepo)
        {
            _context = context;
            Mapper = mapper;
            AppUserRepo = appUserRepo;
            ArticleRepo = articleRepo;
            CategoryRepo = categoryRepo;
            CommentRepo = commentRepo;
        }

        public IBaseRepo<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity
        {
            return new BaseRepo<TEntity>(_context);
        }

        
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync(); 
        }
    }
}
