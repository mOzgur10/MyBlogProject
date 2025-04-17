using MyBlog.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.DataSeeders
{
    public interface IDataSeeder
    {
        Task SeedAsync (AppDbContext appDbContext);
    }
}
