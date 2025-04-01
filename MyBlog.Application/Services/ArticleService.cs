using MyBlog.Application.DTOs;
using MyBlog.Application.Services.BaseServices;
using MyBlog.Application.Utilities.IUnitOfWorks;
using MyBlog.Core.CoreEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Services
{
    public class ArticleService : BaseService<ArticleDTO,Article>
    {
        public ArticleService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
