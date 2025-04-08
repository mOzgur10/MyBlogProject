using MyBlog.Application.DTOs;
using MyBlog.Core.CoreEntities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Services.IServices
{
    public interface IBaseService<TDto, TEntity> where TDto : IBaseEntityDTO where TEntity : IBaseEntity
    {
        Task<TDto> GetByIdAsync(int id);
        Task<List<TDto>> GetAllAsync();
        int Create(TDto tDto);
        int Update(TDto tDto);
        int Delete(TDto tDto);
    }
}
