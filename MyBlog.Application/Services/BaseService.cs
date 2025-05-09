using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;
using MyBlog.Application.DTOs;
using MyBlog.Application.Services.IServices;
using MyBlog.Application.Utilities.IUnitOfWorks;
using MyBlog.Core.CoreEntities.BaseEntities;
using MyBlog.Core.CoreEntities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Services
{
    public class BaseService<TDto, TEntity> : IBaseService<TDto, TEntity> where TDto : IBaseEntityDTO where TEntity : class, IBaseEntity
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(TDto tDto)
        {
            var entity = _unitOfWork.Mapper.Map<TEntity>(tDto);
            entity.CreateDate = DateTime.Now;
            await _unitOfWork.GetRepository<TEntity>().CreateAsync(entity);
            
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _unitOfWork.GetRepository<TEntity>().GetByIdAsync(id);
            entity.Status = EntityStatus.Deleted;
            entity.DeleteDate = DateTime.Now;
            _unitOfWork.GetRepository<TEntity>().Delete(entity);
        }

        public async Task<IEnumerable<TDto>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var entityList = await _unitOfWork.GetRepository<TEntity>().GetAllAsync(filter);
            return _unitOfWork.Mapper.Map<IEnumerable<TDto>>(entityList);
        }

        public async Task<TDto> GetByIdAsync(string id)
        {
            var entity = await _unitOfWork.GetRepository<TEntity>().GetByIdAsync(id);
            return _unitOfWork.Mapper.Map<TDto>(entity);
        }

        public void Update(TDto tDto)
        {
            var entity = _unitOfWork.Mapper.Map<TEntity>(tDto);
            entity.Status = EntityStatus.Updated;
            entity.UpdateDate = DateTime.Now;
            _unitOfWork.GetRepository<TEntity>().Update(entity);
            
        }
        public async Task<IList<TDto>> GetFilteredListAsync(
    Expression<Func<TEntity, bool>> where = null,
    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> join = null)
        {
            var result = await _unitOfWork.GetRepository<TEntity>()
                .GetFilteredListModelAsync(x => x, where, orderBy, join);

            return _unitOfWork.Mapper.Map<IList<TDto>>(result);
        }

        public async Task<TDto> GetFilteredAsync(
            Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> join = null)
        {
            var result = await _unitOfWork.GetRepository<TEntity>()
                .GetFilteredModelAsync(x => x, where, orderBy, join);

            return _unitOfWork.Mapper.Map<TDto>(result);
        }
    }
}
