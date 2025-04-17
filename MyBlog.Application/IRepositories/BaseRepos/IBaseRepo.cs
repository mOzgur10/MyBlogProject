using MyBlog.Core.CoreEntities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.IRepositories.BaseRepos
{
    public interface IBaseRepo<T> where T : IBaseEntity
    {
        Task<T> GetByIdAsync(string id);

        Task<List<T>> GetAllAsync();

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
