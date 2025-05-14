using Microsoft.EntityFrameworkCore.Query;
using MyBlog.Application.DTOs;
using MyBlog.Core.CoreEntities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Services.IServices
{
    public interface IBaseService<TDto, TEntity> where TDto : IBaseEntityDTO where TEntity : IBaseEntity
    {
        Task<TDto> GetByIdAsync(string id);
        Task<IEnumerable<TDto>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
        Task CreateAsync(TDto tDto);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null);
        void Update(TDto tDto);
        Task DeleteAsync(string id);
        Task<IList<TDto>> GetFilteredListAsync(
        Expression<Func<TEntity, bool>> where = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> join = null, int? take = null
    );

        Task<TDto> GetFilteredAsync(
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> join = null
        );

    }
}
