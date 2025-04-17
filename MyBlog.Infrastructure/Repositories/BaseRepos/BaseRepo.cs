using Microsoft.EntityFrameworkCore;
using MyBlog.Application.IRepositories.BaseRepos;
using MyBlog.Core.CoreEntities.BaseEntities;
using MyBlog.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Repositories.BaseRepos
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class,IBaseEntity
    {
        
        private readonly DbSet<T> _table;

        public BaseRepo(AppDbContext appDbContext)
        {
           // _appDbContext = appDbContext;
            _table = appDbContext.Set<T>();
        }

        public void Create(T entity)
        {
           _table.Add(entity);
        }

        public void Delete(T entity)
        {
            _table.Update(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _table.FindAsync(id);
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }
    }
}
