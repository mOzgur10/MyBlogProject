using Microsoft.AspNetCore.Identity;
using MyBlog.Application.DTOs;
using MyBlog.Application.Services.IServices;
using MyBlog.Application.Utilities.IUnitOfWorks;
using MyBlog.Core.CoreEntities.BaseEntities;
using MyBlog.Core.CoreEntities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Services
{
    public class BaseService<TDto, TEntity> : IBaseService<TDto, TEntity> where TDto : IBaseEntityDTO where TEntity : class, IBaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Create(TDto tDto)
        {
            var entity = _unitOfWork.Mapper.Map<TEntity>(tDto);

            _unitOfWork.GetRepository<TEntity>().Create(entity);

            return _unitOfWork.SaveChangesAsync().Result;
        }

        public int Delete(TDto tDto)
        {
            var entity = _unitOfWork.Mapper.Map<TEntity>(tDto);
            _unitOfWork.GetRepository<TEntity>().Delete(entity);
            return _unitOfWork.SaveChangesAsync().Result;
        }



        public async Task<List<TDto>> GetAllAsync()
        {
            var entityList = await _unitOfWork.GetRepository<TEntity>().GetAllAsync();
            return _unitOfWork.Mapper.Map<List<TDto>>(entityList);
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<TEntity>().GetByIdAsync(id);
            return _unitOfWork.Mapper.Map<TDto>(entity);

        }

        public int Update(TDto tDto)
        {
            var entity = _unitOfWork.Mapper.Map<TEntity>(tDto);
            entity.Status = EntityStatus.Updated;
            entity.UpdateDate = DateTime.Now;
            _unitOfWork.GetRepository<TEntity>().Update(entity);
            return _unitOfWork.SaveChangesAsync().Result;
        }
    }
}
