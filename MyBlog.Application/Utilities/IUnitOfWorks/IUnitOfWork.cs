using AutoMapper;
using MyBlog.Application.IRepositories;
using MyBlog.Application.IRepositories.BaseRepos;
using MyBlog.Core.CoreEntities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Utilities.IUnitOfWorks
{
    public interface IUnitOfWork
    {
        IAppUserRepo AppUserRepo { get; }
        IArticleRepo ArticleRepo { get; }
        ICategoryRepo CategoryRepo { get; }
        ICommentRepo CommentRepo { get; }
        IMapper Mapper { get; }

        IBaseRepo<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity;

        Task<int> SaveChangesAsync();
    }
}
